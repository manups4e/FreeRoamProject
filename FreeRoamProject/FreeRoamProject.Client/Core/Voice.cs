namespace FreeRoamProject.Client.Core
{
    public enum Mode
    {
        whisper = 0,
        normal,
        scream
    }

    //TODO: CONVERT THIS INTO USING MUMBLE.. high priority?
    //TODO: THIS WAS FOR THE RP SIDE.. ON A FREE ROAM SERVER WE ONLY NEED TO SET THIS TO TEAM/ALL/MUTE AND MAYBE STILL PORT IT TO MUMBLE...
    internal static class Voice
    {
        /*
        private static List<Modes> VoiceMode = new List<Modes>() { new Modes(3, "Sei Sottovoce.", false), new Modes(8, "Parli Normalmente.", false), new Modes(14, "Urli.", false) };
        private static Dictionary<int, bool> Listeners = new Dictionary<int, bool>();
        private static Mode Mode = Mode.normal;
        private static float CheckDistance = 8.0f;
        private static bool OnlyVehicle = false;
        private static bool shouldReset = false;

        public static void Init()
        {
            ClientMain.Instance.AddTick(OnTick);
            ClientMain.Instance.AddTick(OnTick2);
            ClientMain.Instance.GetPlayers.ToList().ForEach(x => SendVoiceToPlayer(x, false));
            NetworkSetTalkerProximity(-1000.0f);
        }

        public static void SendVoiceToPlayer(Player player, bool Send) { NetworkOverrideSendRestrictions(player.Handle, Send); }

        public static async void UpdateVoices()
        {
            Ped pl = Cache.PlayerCache.MyPlayer.Ped;

            foreach (Player p in ClientMain.Instance.GetPlayers.ToList())
            {
                int serverID = GetPlayerServerId(p.Handle);

                if (CanPedBeListened(pl, p.Character))
                {
                    if (!Listeners.ContainsKey(serverID))
                        Listeners.Add(serverID, true);
                    else if (!Listeners[serverID]) Listeners[serverID] = true;
                    SendVoiceToPlayer(p, true);
                }
                else
                {
                    if (!Listeners.ContainsKey(serverID))
                    {
                        Listeners.Add(serverID, false);
                    }
                    else if (Listeners[serverID])
                    {
                        Listeners[serverID] = false;
                        SendVoiceToPlayer(p, false);
                    }
                }
            }
        }

        private static Notifica a = null;

        public static async void OnModeModified()
        {
            Modes modeData = VoiceMode[(int)Mode];

            if (modeData != null)
            {
                if (a != null) a.Hide();
                CheckDistance = modeData.dist;
                OnlyVehicle = modeData.veh;
                UpdateVoices();
                a = HUD.ShowNotification(modeData.msg);
            }
        }

        public static bool CanPedBeListened(Ped ped, Ped otherPed)
        {
            Vector3 listenerHeadPos = otherPed.Bones[Bone.IK_Head].Position;
            //			bool InSameVeh = (ped.IsInVehicle() && otherPed.IsInVehicle() && ped.CurrentVehicle == otherPed.CurrentVehicle);
            bool InSameVeh = ped.IsInVehicle() && otherPed.IsInVehicle(ped.CurrentVehicle);
            float distance = Vector3.Distance(listenerHeadPos, ped.Position);

            return InSameVeh || !OnlyVehicle && (HasEntityClearLosToEntityInFront(ped.Handle, otherPed.Handle) || distance < Math.Max(0, Math.Min(18, CheckDistance)) * 0.6f) && distance < CheckDistance;
        }

        public static bool ShouldSendVoice() { return NetworkIsPlayerTalking(Cache.PlayerCache.MyPlayer.Player.Handle) || Input.IsControlPressed(Control.PushToTalk); }

        public static async Task OnTick()
        {
            await BaseScript.Delay(300);

            if (ShouldSendVoice() && !shouldReset)
            {
                shouldReset = true;
            }
            else if (!ShouldSendVoice() && shouldReset)
            {
                shouldReset = false;
                ClientMain.Instance.GetPlayers.ToList().ForEach(x => SendVoiceToPlayer(x, false));
                SetPedTalk(PlayerPedId());
            }

            UpdateVoices();
            await Task.FromResult(0);
        }

        public static void UpdateVocalMode(int mode)
        {
            int nextMode = mode;
            if (nextMode > 2 && Cache.PlayerCache.MyPlayer.Status.PlayerStates.InVehicle == false) nextMode = 0;
            Mode = (Mode)nextMode;
            OnModeModified();
        }

        public static void UpdateVocalMode()
        {
            int nextMode = (int)Mode + 1;
            if (nextMode > 2) nextMode = 0;
            Mode = (Mode)nextMode;
            OnModeModified();
        }

        private static bool Permesso = true;
        private static bool notif = false;

        public static async Task OnTick2()
        {
            Ped playerPed = Cache.PlayerCache.MyPlayer.Ped;

            if (Permesso)
            {
                if (Input.IsControlPressed(Control.VehicleHeadlight, PadCheck.Keyboard, ControlModifier.Shift))
                {
                    Vector3 headPos = playerPed.Bones[Bone.IK_Head].Position;
                    World.DrawMarker(MarkerType.DebugSphere, headPos, Vector3.Zero, Vector3.Zero, new Vector3(CheckDistance), System.Drawing.Color.FromArgb(30, 20, 192, 255));
                }

                if (Input.IsControlJustPressed(Control.FrontendSocialClub, PadCheck.Keyboard, ControlModifier.Shift)) UpdateVocalMode();
            }

            if (Cache.PlayerCache.MyPlayer.Status.PlayerStates.InVehicle == true)
            {
                Vehicle veh = playerPed.CurrentVehicle;

                if (veh == null) return;
        */
        /*
        switch (veh.Windows.AreAllWindowsIntact)
        {
            case true when EventsPersonalMenu.WindowsDown:
                Permesso = true;
                notif = false;

                break;
            case true when !EventsPersonalMenu.WindowsDown:
                {
                    if (!notif)
                    {
                        HUD.ShowNotification("Range vocale settato all'interno del veicolo\nPer parlare al di fuori abbassa i finestrini...... o rompili.");
                        notif = true;
                    }

                    Permesso = false;

                    foreach (Player p in ClientMain.Instance.GetPlayers.ToList())
                        if (CanPedBeListened(playerPed, p.Character))
                        {
                            if (!Listeners.ContainsKey(p.ServerId))
                                Listeners.Add(p.ServerId, true);
                            else
                                Listeners[p.ServerId] = true;
                            SendVoiceToPlayer(p, true);
                        }
                        else
                        {
                            if (!Listeners.ContainsKey(p.ServerId))
                                Listeners.Add(p.ServerId, false);
                            else
                                Listeners[p.ServerId] = false;
                            SendVoiceToPlayer(p, false);
                        }

                    break;
                }
            case false:
                Permesso = true;
                notif = false;

                break;
        }
        */
        /*
    }
            else
            {
                Permesso = true;
            }

await Task.FromResult(0);
        }
        */
    }

    public class Modes
    {
        public int dist;
        public string msg;
        public bool veh;

        public Modes(int d, string m, bool v)
        {
            dist = d;
            msg = m;
            veh = v;
        }
    }
}