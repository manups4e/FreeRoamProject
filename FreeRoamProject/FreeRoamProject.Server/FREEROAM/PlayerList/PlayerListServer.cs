using FreeRoamProject.Server;
using FreeRoamProject.Server.Core.Buckets;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FivemPlayerlistServer
{
    public static class PlayerListServer
    {

        private static ConcurrentDictionary<int, dynamic[]> list = new ConcurrentDictionary<int, dynamic[]>();
        public static void Init()
        {

            EventDispatcher.Mount("tlg:pl:getMaxPlayers", new Func<PlayerClient, Task<int>>(ReturnMaxPlayers));
            EventDispatcher.Mount("tlg:pl:getPlayers", new Func<PlayerClient, Task<List<PlayerSlot>>>(ReturnPlayers));
            ServerMain.Instance.RegisterExport("setPlayerRowConfig", new Action<string, string, string, string>(SetPlayerConfig2));
            EventDispatcher.Mount("tlg:pl:setPlayerRowConfig", new Action<int, string, int, bool>(SetPlayerConfig));
        }

        private static async Task<int> ReturnMaxPlayers([FromSource] PlayerClient source)
        {
            FreeRoamProject.Shared.Core.Buckets.Bucket server = BucketsHandler.FreeRoam.GetPlayerBucket(source.Handle);
            return server.Players.Count;
        }
        private static async Task<List<PlayerSlot>> ReturnPlayers([FromSource] PlayerClient source)
        {
            FreeRoamProject.Shared.Core.Buckets.Bucket server = BucketsHandler.FreeRoam.GetPlayerBucket(source.Handle);
            List<PlayerSlot> result = new();
            foreach (PlayerClient client in server.Players)
            {
                PlayerSlot slot = new()
                {
                    CrewLabelText = String.Empty,
                    FriendType = ' ',
                    IconOverlayText = String.Empty,
                    JobPointsDisplayType = SlotScoreDisplayType.NONE,
                    JobPointsText = String.Empty,
                    Name = client.Player.Name.Replace("<", "").Replace(">", "").Replace("^", "").Replace("~", "").Trim(),
                    RightIcon = SlotScoreRightIconType.RANK_FREEMODE,
                    RightText = $"{client.User.Character.Level}",
                    Color = 116,
                    ServerId = client.Handle
                };
                result.Add(slot);
            }
            return result;
        }
        private static void SetPlayerConfig2(string playerServerId, string crewName, string jobPoints, string showJobPointsIcon)
        {
            SetPlayerConfig(int.Parse(playerServerId), crewName, int.Parse(jobPoints ?? "-1"), bool.Parse(showJobPointsIcon ?? "false"));
        }

        private static void SetPlayerConfig(int playerServerId, string crewName, int jobPoints, bool showJobPointsIcon)
        {
            if (playerServerId > 0)
            {
                list[playerServerId] = new dynamic[4] { playerServerId, crewName ?? "", jobPoints, showJobPointsIcon };
                BaseScript.TriggerClientEvent("tlg:fs:setPlayerConfig", playerServerId, crewName ?? "", jobPoints,
                    showJobPointsIcon);
            }
        }
    }
}
