using FreeRoamProject.Server.FreeRoam.Scripts.FreeroamEvents;
using FreeRoamProject.Shared.Core.Buckets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeRoamProject.Server.Core.Buckets
{
    public class FreeRoamBucketContainer
    {
        public Dictionary<int, Bucket> Servers { get; set; }

        public int GetTotalPlayers()
        {
            int total = 0;
            if (Servers != null)
                foreach (KeyValuePair<int, Bucket> b in Servers)
                    total += b.Value.TotalPlayers;
            return total;
        }

        public FreeRoamBucketContainer()
        {
            Servers = new()
            {
                // bucket 0 is the default bucket on player join.. i want to keep all restrict here and allowe the other buckets.
                [0] = new Bucket(0, "freeroam") { PopulationEnabled = false, LockdownMode = BucketLockdownMode.strict },
                [10] = new Bucket(10, "freeroam") { PopulationEnabled = true, LockdownMode = BucketLockdownMode.relaxed }
            };
            EventDispatcher.Mount("tlg:Select_FreeRoamChar", new Func<PlayerClient, int, Task<FreeRoamChar>>(LoadFreeRoamChar));
            EventDispatcher.Mount("tlg:Save_FreeRoamChar", new Action<PlayerClient>(SavePlayerData));
        }

        public void AddPlayer(PlayerClient client)
        {
            // TODO: COMPLETE SO THAT EACH BUCKETS HAS ITS OWN EVENT HANDLING, AND TICK HANDLING
            // here we check buckets.. if any bucket has less than 64 players.. we add a player to it..
            // if all current buckets are full we make a new one and add the player to it.. 
            // each bucket is on its own so that events and everything is handled differently on every bucket
            if (Servers.Any(x => x.Key != 0 && x.Value.Name == "freeroam" && x.Value.Players.Count < 64))
            {
                KeyValuePair<int, Bucket> avail = Servers.FirstOrDefault(x => x.Key != 0 && x.Value.Name == "freeroam" && x.Value.Players.Count < 64);
                // TODO: simple check for future reserved buckets... (minigames, races)
                // TODO: check for solo sessions and private sessions
                avail.Value.AddPlayer(client);
            }
            else
            {
                int missing = FindFirstMissingBucket();
                int id = missing != -1 ? missing : Servers.Count;
                Bucket b = new Bucket(id, "freeroam") { PopulationEnabled = true, LockdownMode = BucketLockdownMode.relaxed };
                Servers.Add(id, b);
                b.AddPlayer(client);
            }
            ServerMain.Logger.Info($"Player {client.Player.Name} joined bucket {GetPlayerBucket(client.Handle).ID}, total players: {GetPlayerBucket(client.Handle).Players.Count}");
            client.Status.Clear();


            // TODO: PORT THIS INTO THE PLUGINS
            List<PlayerScore> highscores = new();
            foreach (WorldEvent worldEvent in WorldEventsManager.WorldEvents)
                highscores.Add(new PlayerScore { EventId = worldEvent.Id, BestAttempt = 0, CurrentAttempt = 0, EventXpMultiplier = worldEvent.EventXpMultiplier });
            client.User.PlayerScores = highscores;
            // TODO: DO WE WANT CULLING RADIUS HANDLING? MAYBE NOT.... but how do we manage blips?
        }


        public async void RemovePlayer(PlayerClient client, string reason = "")
        {
            int bucketID = GetPlayerRoutingBucket(client.Handle.ToString());
            SavePlayerData(client);
            Servers[bucketID].RemovePlayer(client, reason);
            if (Servers[bucketID].Players.Count > 0)
            {
                EventDispatcher.Send(Servers[bucketID].Players, "tlg:PlayerLeft", client.Player.Name, reason);
            }
            else
            {
                // TODO: TO AVOID THE RACE CONDITION WHERE A PLAYER IS CONNECTING TO THE BUCKET WHILE THE BUCKET IS BEING DELETED DUE TO ITS EMPTINESS..
                // WE CAN OPT 2 SOLUTIONS:
                // 1. ADD A TIMER BEFORE KILLING THE BUCKET IF STILL EMPTY
                // 2. ADD A CANCELATION TOKEN WHICH SETS THE BUCKET AS READY TO BE DELETED SO THAT ANY PLAYER CAN'T JOIN IT
                // 3. (possible) WE CAN KEEP ALL THE BUCKETS AND NEVER DELETE THEM KEEPING THEM AS ALWAYS AVAILABLE
                Servers.Remove(bucketID);
            }
            ServerMain.Logger.Info($"Player {client.Player.Name} [{client.Identifiers.License}] left.");
        }

        // TODO: PORT THIS INTO THE PLUGINS
        public void UpdateCurrentAttempt(PlayerClient client, int eventId, float currentAttempt)
        {
            try
            {
                if (client != null)
                {
                    PlayerScore data = client.User.PlayerScores.FirstOrDefault(x => x.EventId == eventId);
                    if (data != null)
                    {
                        data.CurrentAttempt = currentAttempt;
                        if (currentAttempt > data.BestAttempt)
                            data.BestAttempt = currentAttempt;
                    }
                    else
                        ServerMain.Logger.Warning($"Data for Event {eventId} does not exist for Player {client.Player.Name}");
                }
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error(e.ToString());
            }
        }

        public void ResetAllCurrentAttempts(int eventId)
        {
            try
            {
                foreach (KeyValuePair<int, Bucket> server in Servers)
                {
                    if (server.Value.Name != "freeroam" || server.Value.Players.Count == 0) return;
                    foreach (PlayerClient player in server.Value.Players)
                    {
                        player.User.PlayerScores.First(x => x.EventId == eventId).CurrentAttempt = 0;
                    }
                }
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error(e.ToString());
            }
        }

        public void UpdateBestAttempt(PlayerClient client, int eventId, int bestAttempt)
        {
            try
            {
                Bucket server = GetPlayerBucket(client.Handle);
                if (server.Name != "freeroam" || server.Players.Count == 0) return;
                if (client != null)
                {
                    PlayerScore score = client.User.PlayerScores.FirstOrDefault(x => x.EventId == eventId);
                    if (score != null && score.BestAttempt < bestAttempt)
                        score.BestAttempt = bestAttempt;
                }
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error(e.ToString());
            }
        }


        public void SendFinalTop3Players(int eventId, float eventMultiplier)
        {
            try
            {
                foreach (KeyValuePair<int, Bucket> server in Servers)
                {
                    if (server.Value.Name != "freeroam" || server.Value.Players.Count == 0) return;

                    Dictionary<string, float> tempDictionary = new Dictionary<string, float>();

                    foreach (PlayerClient player in server.Value.Players)
                    {
                        PlayerScore score = player.User.PlayerScores.Where(x => x.EventId == eventId).FirstOrDefault();
                        if (score != null && score.CurrentAttempt > 0)
                        {
                            int xpGain = (int)Math.Min(score.CurrentAttempt * eventMultiplier, Experience.RankRequirement[player.User.Character.Level + 1] - Experience.RankRequirement[player.User.Character.Level]);

                            if (xpGain != 0)
                                ExperienceManager.OnAddExperience(player, xpGain);

                            tempDictionary.Add(player.Player.Name, score.CurrentAttempt);
                        }
                    }

                    if (tempDictionary.Count == 0)
                    {
                        tempDictionary.Add("-1", 0);
                        tempDictionary.Add("-2", 0);
                        tempDictionary.Add("-3", 0);
                    }
                    else if (tempDictionary.Count == 1)
                    {
                        tempDictionary.Add("-1", 0);
                        tempDictionary.Add("-2", 0);
                    }
                    else if (tempDictionary.Count == 2)
                    {
                        tempDictionary.Add("-1", 0);
                    }

                    IOrderedEnumerable<KeyValuePair<string, float>> orderByDescending = tempDictionary.OrderByDescending(x => x.Value);

                    Dictionary<string, float> newerDict = orderByDescending.ToDictionary(x => x.Key, x => x.Value);

                    EventDispatcher.Send(server.Value.Players, "worldEventsManage.Client:FinalTop3", eventId, newerDict.ToJson());
                }
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error(e.ToString());
            }
        }

        public void SendTop3Players(int eventId)
        {
            try
            {
                foreach (KeyValuePair<int, Bucket> server in Servers)
                {
                    if (server.Value.Name != "freeroam" || server.Value.Players.Count == 0) return;

                    Dictionary<string, float> tempDictionary = new Dictionary<string, float>();

                    foreach (PlayerClient player in server.Value.Players)
                    {
                        PlayerScore score = player.User.PlayerScores.Where(x => x.EventId == eventId).FirstOrDefault();
                        if (score != null && score.CurrentAttempt > 0)
                        {
                            if (!tempDictionary.ContainsKey(player.Player.Name))
                                tempDictionary.Add(player.Player.Name, score.CurrentAttempt);
                        }
                    }

                    if (tempDictionary.Count == 1)
                    {
                        tempDictionary.Add("Player 1", 0);
                        tempDictionary.Add("Player 2", 0);
                    }
                    else if (tempDictionary.Count == 2)
                    {
                        tempDictionary.Add("Player 1", 0);
                    }

                    Dictionary<string, float> newDict = tempDictionary.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                    if (newDict.Count < 3) { return; }

                    EventDispatcher.Send(server.Value.Players, "worldEventsManage.Client:GetTop3", newDict.ToJson());
                }
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error(e.ToString());
            }
        }

        public void SendEventData(int eventId)
        {
            try
            {
                foreach (KeyValuePair<int, Bucket> server in Servers)
                {
                    foreach (PlayerClient p in server.Value.Players)
                    {
                        if (p != null)
                        {
                            PlayerScore eventData = p.User.PlayerScores.FirstOrDefault(x => x.EventId == eventId);
                            p.Player.TriggerEvent("worldeventsManager.Client:GetEventData", eventData.EventId, eventData.CurrentAttempt, eventData.BestAttempt);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error(e.ToString());
            }
        }

        public int GetCurrentLevel(PlayerClient client)
        {
            try
            {
                if (client != null)
                {
                    return client.User.Character.Level;
                }
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error(e.ToString());
            }

            return -1;
        }

        public int GetCurrentExperiencePoints(PlayerClient client)
        {
            try
            {
                if (client != null)
                {
                    return client.User.Character.TotalXp;
                }
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error(e.ToString());
            }

            return 0;
        }

        public void AddExperience(PlayerClient client, int experiencePoints)
        {
            try
            {
                if (client != null)
                {
                    int nextLevelTotalXp = Experience.NextLevelExperiencePoints(client.User.Character.Level);

                    if (client.User.Character.TotalXp + experiencePoints >= nextLevelTotalXp)
                    {
                        int remainder = client.User.Character.TotalXp + experiencePoints - nextLevelTotalXp;

                        client.User.Character.Level++;

                        if (remainder > 0)
                            AddExperience(client, remainder);
                    }
                    else
                        client.User.Character.TotalXp += experiencePoints;
                }
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error(e.ToString());
            }
        }

        private async Task<FreeRoamChar> LoadFreeRoamChar([FromSource] PlayerClient source, int id)
        {
            //API.DeleteResourceKvpNoSync($"freeroam:player_{source.User.Identifiers.License}:char_model");
            if (source.User.ID != id) return null;
            string sbytes = API.GetResourceKvpString($"freeroam:player_{source.User.Identifiers.License}:char_model");
            if (string.IsNullOrWhiteSpace(sbytes) || sbytes == "00")
            {
                source.User.Character = new();
            }
            else
            {
                byte[] bytes = sbytes.StringToBytes();
                source.User.Character = bytes.FromBytes<FreeRoamChar>();
            }
            return source.User.Character;
        }

        private void SavePlayerData([FromSource] PlayerClient client)
        {
            if (client == null || client.User == null || client.User.Character == null) return;
            Position pos = new Position(client.Ped.Position, client.Ped.Rotation);
            client.User.Character.Position = pos;
            API.SetResourceKvp($"freeroam:player_{client.User.Identifiers.License}:char_model", client.User.Character.ToBytes().BytesToString(true));
        }

        // TODO: will be externalized for plugins api
        public Bucket GetPlayerBucket(int id)
        {
            return GetPlayerBucket(id.ToString());
        }

        public Bucket GetPlayerBucket(string id)
        {
            return Servers[GetPlayerRoutingBucket(id)];
        }

        /// <summary>
        /// Returns the bucket with corresponding ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Bucket GetServerFromId(int id)
        {
            return Servers.FirstOrDefault(x => x.Key == id).Value;
        }

        /// <summary>
        /// Checks the Servers keys to find the first missing bucket id.. if we have a List<int>{10, 11, 13, 15, 20}, the function will return 12 as first missing bucket.
        /// If no buckets missing, then it returns -1
        /// </summary>
        /// <returns>first missing index of the bucket list (servers) or -1 if there are no missing indexes</returns>
        public int FindFirstMissingBucket()
        {
            List<int> numbers = Servers.Keys.OrderBy(x => x).ToList();
            int first = 0;
            int last = numbers.Count - 1;
            int middle = (first + last) / 2;

            while (first < last)
            {
                if (numbers[middle] - numbers[first] != middle - first)
                {
                    if ((middle - first) == 1 && (numbers[middle] - numbers[first] > 1))
                    {
                        return numbers[middle] - 1;
                    }

                    last = middle;
                }
                else if (numbers[last] - numbers[middle] != last - middle)
                {
                    if ((last - middle) == 1 && (numbers[last] - numbers[middle] > 1))
                    {
                        return numbers[middle] + 1;
                    }

                    first = middle;
                }
                else
                {
                    return -1;
                }

                middle = (first + last) / 2;
            }

            return -1;
        }
    }
}
