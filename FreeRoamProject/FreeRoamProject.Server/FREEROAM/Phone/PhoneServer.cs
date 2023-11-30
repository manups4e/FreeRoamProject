using FreeRoamProject.Shared.Core.Character;
using System;
using System.Linq;

namespace FreeRoamProject.Server.FREEROAM.Phone
{
    public static class PhoneServer
    {
        public static void Init()
        {
            EventDispatcher.Mount("tlg:phone:setSettings", new Action<PlayerClient, string, int>(SetSettings));
            EventDispatcher.Mount("tlg:phone:sendTextToPlayer", new Action<PlayerClient, int, string>(SendTextToPlayer));
            EventDispatcher.Mount("tlg:phone:deleteTextMessage", new Action<PlayerClient, int>(DeleteText));
            EventDispatcher.Mount("tlg:phone:setTextMessageRead", new Action<PlayerClient, int>(SetAsRead));
        }

        public static void SetSettings([FromSource] PlayerClient player, string setting, int value)
        {
            switch (setting)
            {
                case "theme":
                    player.User.Character.PhoneData.Theme = value;
                    break;
                case "wall":
                    player.User.Character.PhoneData.Wallpaper = value;
                    break;
                case "invite":
                    player.User.Character.PhoneData.InviteSound = value;
                    break;
                case "ring":
                    player.User.Character.PhoneData.Ringtone = value;
                    break;
                case "vibe":
                    player.User.Character.PhoneData.Vibration = value;
                    break;
                case "snapmatic":
                    player.User.Character.PhoneData.QuickLaunch = value;
                    break;
                case "sleep":
                    player.User.Character.PhoneData.SleepMode = value;
                    break;
            }
        }

        private static void SendTextToPlayer([FromSource] PlayerClient sender, int recevierHandle, string message)
        {
            PlayerClient receiver = ServerMain.Instance.Clients[recevierHandle];
            Message msgToSend = new(sender.Player.Name, message, DateTime.Now, MessageState.UNREAD_SMS, DeliveryType.Received);
            receiver.User.Character.PhoneData.Messages.Add(msgToSend);
            receiver.TriggerSubsystemEvent("tlg:phone:receiveTextMessage", sender.Handle, msgToSend);
        }

        private static void DeleteText([FromSource] PlayerClient player, int messageIndex)
        {
            player.User.Character.PhoneData.Messages.RemoveAt(messageIndex);
            player.User.Character.PhoneData.Messages.OrderByDescending(x => x.Date);
        }
        private static void SetAsRead([FromSource] PlayerClient player, int messageIndex)
        {
            player.User.Character.PhoneData.Messages[messageIndex].Readed = MessageState.READ_SMS;
        }
    }
}
