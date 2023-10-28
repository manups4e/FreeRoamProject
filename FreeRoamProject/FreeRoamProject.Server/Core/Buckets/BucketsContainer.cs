using FreeRoamProject.Server.FreeRoam.Scripts.FreeroamEvents;
using FreeRoamProject.Shared.Core.Buckets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeRoamProject.Server.Core.Buckets
{

    // TODO: TO BE HANDLED AND MAYBE REMOVED AFTER A CONTAINER FOR EACH MODE WILL BE SET
    public class FreeRoamBucketContainer
    {
        public List<Bucket> Servers { get; set; }

        public int GetTotalPlayers()
        {
            int total = 0;
            if (Servers != null)
                foreach (Bucket b in Servers)
                    total += b.TotalPlayers;
            return total;
        }

        public FreeRoamBucketContainer()
        {
            Servers = new List<Bucket>() { new Bucket(0, "freeroam") };
            EventDispatcher.Mount("tlg:Select_FreeRoamChar", new Func<PlayerClient, int, Task<FreeRoamChar>>(LoadFreeRoamChar));
            EventDispatcher.Mount("tlg:Save_FreeRoamChar", new Action<PlayerClient>(SavePlayerData));
        }

        public void AddPlayer(PlayerClient client)
        {
            // here we check buckets.. if any bucket has less than 64 players.. we add a player to it..
            // if all current buckets are full we make a new one and add the player to it.. 
            // each bucket is on its own so that events and everything is handled differently on every bucket
            if (GetTotalPlayers() % 64 != 0)
            {
                foreach (Bucket b in Servers)
                {
                    if (b.TotalPlayers < 64)
                    {
                        b.AddPlayer(client);
                        break;
                    }
                }
            }
            else
            {
                Bucket b = new Bucket(Servers.Count, "freeroam");
                Servers.Add(b);
                b.AddPlayer(client);
            }

            // TODO: PORT THIS INTO THE PLUGINS
            List<PlayerScore> highscores = new();
            foreach (WorldEvent worldEvent in WorldEventsManager.WorldEvents)
                highscores.Add(new PlayerScore { EventId = worldEvent.Id, BestAttempt = 0, CurrentAttempt = 0, EventXpMultiplier = worldEvent.EventXpMultiplier });
            client.User.PlayerScores = highscores;
            // TODO: DO WE WANT CULLING RADIUS HANDLING? MAYBE NOT.... but how do we manage blips?
            //SetPlayerCullingRadius(client.Handle.ToString(), 5000f);
        }


        public async void RemovePlayer(PlayerClient client, string reason = "")
        {
            SetPlayerCullingRadius(client.Handle.ToString(), 0f);
            int bucketID = GetPlayerRoutingBucket(client.Handle.ToString());
            Servers[bucketID].RemovePlayer(client, reason);
            SavePlayerData(client);
            if (Servers[bucketID].Players.Count > 0)
            {
                await Servers[bucketID].Players.ForEachAsync(async (x) =>
                {
                    x.User.showNotification($"Player {client.Player.Name} left.");
                    await Task.FromResult(0);
                });
            }
            ServerMain.Logger.Info($"Player {client.Player.Name} [{client.Identifiers.Discord}] left.");
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
                foreach (Bucket server in Servers)
                {
                    if (server.Name != "freeroam" || server.Players.Count == 0) return;
                    foreach (PlayerClient player in server.Players)
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
                foreach (Bucket server in Servers)
                {
                    if (server.Name != "freeroam" || server.Players.Count == 0) return;

                    Dictionary<string, float> tempDictionary = new Dictionary<string, float>();

                    foreach (PlayerClient player in server.Players)
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

                    EventDispatcher.Send(server.Players, "worldEventsManage.Client:FinalTop3", eventId, newerDict.ToJson());
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
                foreach (Bucket server in Servers)
                {
                    if (server.Name != "freeroam" || server.Players.Count == 0) return;

                    Dictionary<string, float> tempDictionary = new Dictionary<string, float>();

                    foreach (PlayerClient player in server.Players)
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
                        tempDictionary.Add("Giocatore 1", 0);
                        tempDictionary.Add("Giocatore 2", 0);
                    }
                    else if (tempDictionary.Count == 2)
                    {
                        tempDictionary.Add("Player 1", 0);
                    }

                    Dictionary<string, float> newDict = tempDictionary.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                    if (newDict.Count < 3) { return; }

                    EventDispatcher.Send(server.Players, "worldEventsManage.Client:GetTop3", newDict.ToJson());
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
                foreach (Bucket server in Servers)
                {
                    foreach (PlayerClient p in server.Players)
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
            //API.DeleteResourceKvpNoSync($"freeroam:player_{source.User.Identifiers.Discord}:char_model");
            if (source.User.ID != id) return null;
            string sbytes = API.GetResourceKvpString($"freeroam:player_{source.User.Identifiers.Discord}:char_model");
            if (string.IsNullOrWhiteSpace(sbytes) || sbytes == "00")
            {
                source.User.Character = new();
            }
            else
            {
                byte[] bytes = sbytes.StringToBytes();
                source.User.Character = bytes.FromBytes<FreeRoamChar>();
            }
            await BaseScript.Delay(0);
            return source.User.Character;
        }

        private void SavePlayerData([FromSource] PlayerClient client)
        {
            client.User.Character.Position = client.Ped.Position.ToPosition();
            API.SetResourceKvpNoSync($"freeroam:player_{client.User.Identifiers.Discord}:char_model", BitConverter.ToString(client.User.Character.ToBytes()));
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

        public Bucket GetServerFromId(int id)
        {
            return Servers.FirstOrDefault(x => x.ID == id);
        }
    }
}
