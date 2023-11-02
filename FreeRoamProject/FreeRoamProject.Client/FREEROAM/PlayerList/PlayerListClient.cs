using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.FREEROAM.PlayerList
{
    internal static class PlayerListClient
    {
        static int maxPlayers = 0;
        public static void Init()
        {
            ClientMain.Instance.AddTick(DisplayController);
        }

        public static void ShowMoney()
        {
            N_0x170f541e1cadd1de(true);
            SetMultiplayerWalletCash();
            SetMultiplayerBankCash();
            N_0x170f541e1cadd1de(false);
        }

        public static void NascondiMoney()
        {
            RemoveMultiplayerWalletCash();
            RemoveMultiplayerBankCash();
        }

        /// <summary>
        /// Manages the display and page setup of the playerlist.
        /// </summary>
        /// <returns></returns>
        private static async Task DisplayController()
        {
            if (Input.IsControlJustPressed(Control.MultiplayerInfo) && !MenuHandler.IsAnyMenuOpen && !IsPedRunningMobilePhoneTask(PlayerPedId()))
            {
                Main.PlayerListInstance.PlayerRows.Clear();
                int num = await EventDispatcher.Get<int>("tlg:pl:getMaxPlayers");
                List<PlayerSlot> list = await EventDispatcher.Get<List<PlayerSlot>>("tlg:pl:getPlayers");

                foreach (PlayerSlot p in list)
                {
                    Ped ped = p.ServerId == PlayerCache.MyPlayer.Handle ? PlayerCache.MyPlayer.Ped : Functions.GetPlayerClientFromServerId(p.ServerId)?.Ped;
                    System.Tuple<int, string> mug = await Functions.GetPedMugshotAsync(ped);
                    if (Main.PlayerListInstance.PlayerRows.Any(x => x.ServerId == p.ServerId)) continue;
                    PlayerRow row = new PlayerRow()
                    {
                        Color = p.Color,
                        CrewLabelText = p.CrewLabelText,
                        FriendType = p.FriendType,
                        IconOverlayText = p.IconOverlayText,
                        JobPointsDisplayType = (ScoreDisplayType)p.JobPointsDisplayType,
                        JobPointsText = p.JobPointsText,
                        Name = p.Name,
                        RightIcon = (ScoreRightIconType)p.RightIcon,
                        RightText = p.RightText,
                        ServerId = p.ServerId,
                        TextureString = mug.Item2
                    };
                    Main.PlayerListInstance.AddRow(row);
                    UnregisterPedheadshot(mug.Item1);
                }
                // TODO: HANDLE SOLO, INVITE, CREW, FRIENDS, PUBLIC SESSIONS FOR TITLE
                Main.PlayerListInstance.SetTitle($"The Last Galaxy (Public, {num})", $"{Main.PlayerListInstance.CurrentPage + 1} / {Main.PlayerListInstance.MaxPages}", 2);
                Main.PlayerListInstance.CurrentPage++;
            }
            if (Main.PlayerListInstance.Enabled)
            {
                if (!Screen.Hud.IsComponentActive(HudComponent.MpCash)) ShowMoney();
                if (Main.PlayerListInstance.PlayerRows.Count > 0)
                {
                    foreach (PlayerRow p in Main.PlayerListInstance.PlayerRows)
                    {
                        int player = GetPlayerFromServerId(p.ServerId);
                        int index = Main.PlayerListInstance.PlayerRows.IndexOf(p);
                        if (NetworkIsPlayerTalking(player) || MumbleIsPlayerTalking(player))
                            Main.PlayerListInstance.SetIcon(index, ScoreRightIconType.ACTIVE_HEADSET, "");
                        else
                            Main.PlayerListInstance.SetIcon(index, p.RightIcon, p.RightText);
                    }
                }
            }
            else
            {
                if (Screen.Hud.IsComponentActive(HudComponent.MpCash)) NascondiMoney();
            }
        }
    }
}
