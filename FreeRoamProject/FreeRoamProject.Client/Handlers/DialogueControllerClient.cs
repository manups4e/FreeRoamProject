using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.Handlers
{
    public static class DialogueControllerClient
    {

        /*
         * !!!!!!!!!!!!!!!!!! DOES NOT SUPPORT NETWORKING AT THIS MOMENT !!!!!!!!!!!!!!!!!!!!!!
         * Need to figure out the behavior to make it more consistent. (i.e doesn't play on first run)
         * Run on all clients that should hear it in the meantime.
         */

        //ct_aud has all the phone responses! and phone calls!
        /*
            "MPCT_LWNT_01": "~z~Can't handle the heat my friend? Okay, leave it with creepy Uncle Lester.",
            "MPCT_LWNT_02": "~z~No problem, I'll get them off your back.",
            "MPCT_LWNT_03": "~z~Okay, my friend. I'll take care of the LSPD. Leave it to me.",
            "MPCT_LWNT_04": "~z~So you don't want to get in serious trouble, huh? Okay, leave it with me.",
            "MPCT_LWNT_05": "~z~Okay, so you're in serious trouble and you need my help? Okay, okay.",
            "MPCT_LWNT_06": "~z~I take it this isn't a purely social call? Of course not... you're in trouble and you need my help... no problem.",
            "MPCT_LWNT_07": "~z~Oh hey... you're in trouble... hmmm... okay... I'll deal with it.",
            "MPCT_LWNT_08": "~z~Okay, okay, I'll get you out of trouble. No problem.",
         */

        public static void Init()
        {
            SetAudioFlag("EnableHeadsetBeep", true); // enables beep, this doesn't affect anything but scripted conversation and it seems the game will not do these on non-radio filtered lines.

            RegisterCommand("dialoguenormal", new Action<int, List<object>, string>(async (source, args, raw) =>
            {
                // example input:
                // /dialoguenormal fximaud FXIM_FL_8 2-FIX_IMANI 3-FIX_FRANKLIN
                // Should run
                // RunDialogue("fximaud", new Dictionary<int, string>() { { 2, "FIX_IMANI" }, { 3, "FIX_FRANKLIN" } }, "FXIM_FL_8")
                ClientMain.Logger.Debug(raw);
                string[] split = raw.Split(' ');
                split = split.Skip(1).ToArray();
                string gxt = split[0];
                string line = split[1];
                bool forceRadio = false;
                Dictionary<int, string> speakers = new Dictionary<int, string>();
                Dictionary<int, int> peds = null;
                for (int i = 2; i < split.Length; i += 1)
                {
                    if (split[i] == "true")
                    {
                        forceRadio = true;
                        continue;
                    }
                    string[] speaker = split[i].Split('-');
                    ClientMain.Logger.Debug($"{speaker[0]} - {speaker[1]}");
                    speakers.Add(ConvertCharToNum(char.Parse(speaker[0])), speaker[1]);
                    if (speaker.Length == 3)
                    {
                        //we are probably being given a ped handle aswell
                        peds ??= new Dictionary<int, int>();
                        peds.Add(ConvertCharToNum(char.Parse(speaker[0])), int.Parse(speaker[2]));
                    }
                }
                await RunDialogue(gxt, speakers, line, peds, false, forceRadio, false);
            }), false);

            RegisterCommand("dialoguerandom", new Action<int, List<object>, string>(async (source, aargs, raw) =>
            {
                string[] args = raw.Split(' ');
                args = args.Skip(1).ToArray();
                string gxt = args[0];
                string line = args[1];
                string speaker = args[2];
                bool radioFrontend = false;
                int ped = -1;
                if (speaker.Split('-').Count() > 2)
                {
                    string[] speakersplit = speaker.Split('-');
                    ped = int.Parse(speakersplit.Last());
                    speaker = speakersplit.First();
                }
                else
                {
                    string[] speakersplit = speaker.Split('-');
                    ped = -1;
                    speaker = speakersplit.First();
                }
                if (args.Length > 2)
                    if (args[3] == "true")
                        radioFrontend = true;
                await RunRandomizedDialogue(gxt, line, speaker, ped, radioFrontend, radioFrontend);
            }), false);
        }

        // functions for running dialogue through commands without the need for exports.
        // Only debug builds hook this up.

        /*
        private static void RunDialogueJson(string json)
        {
            var obj = RunDialogueObject.FromJson(json);

            Dictionary<int, string> speakers = new Dictionary<int, string>();
            foreach (var s in obj.Speakers)
            {
                speakers.Add(ConvertCharToNum(s.Key[0]), s.Value);
            }

            Dictionary<int, int> peds = new Dictionary<int, int>();
            if (obj.Peds != null)
            {
                foreach (var p in obj.Peds)
                {
                    peds.Add(int.Parse(p.Key), p.Value);
                }
            }

            RunDialogue(obj.Gxt, speakers, obj.Line, peds, obj.ForcePedsVisible, obj.PhoneCall, obj.ForceRadio); ;
        }
        */
        /*
        private static void RunRandomizedDialogueJson(string json)
        {
            var obj = RunRandomizedDialogueObject.FromJson(json);

            RunRandomizedDialogue(obj.Gxt, obj.Line, obj.Voice, obj.Ped, obj.ForceRadio, obj.ForceFrontend);
        }
        */
        #region RunDialog
        public static async Task RunDialogue(string gxt, Dictionary<int, string> speakers, string line, Dictionary<int, int> peds = null, bool forcePedsVisible = false, bool phoneCall = false, bool forceRadio = false)
        {
            bool isCT_AUD = false;
            int iVar1 = 1;
            StopScriptedConversation(true);
            await BaseScript.Delay(0);
            if (DoesTextBlockExist(gxt) && gxt.ToLower() == "ct_aud")
            {
                isCT_AUD = true;
            }
            if (func_98(Functions.HashInt(gxt)))
            {
                //check Global_21607;
                isCT_AUD = false;
                iVar1 = 0;
            }

            ClearAdditionalText(7, true);
            ClearAdditionalText(15, true);
            ClearAdditionalText(6, true);
            ClearAdditionalText(14, true);

            int timeout = GetGameTimer();
            int slot;
            if (gxt.ToLower() == "anaud" || gxt.ToLower() == "bacalau")
            {
                if (iVar1 == 1 || isCT_AUD)
                    slot = 7;
                else
                    slot = 15;
            }
            else
            {
                if (iVar1 == 1 || isCT_AUD)
                    slot = 6;
                else
                    slot = 14;
            }
            ClientMain.Logger.Debug("Slot: " + slot);
            if (slot == 6 || slot == 7)
                RequestAdditionalText(gxt, slot);
            else
                RequestAdditionalTextForDlc(gxt, slot);
            while (!HasAdditionalTextLoaded(slot))
            {
                await BaseScript.Delay(0);
                if (GetGameTimer() - timeout >= 5000)
                {
                    ClientMain.Logger.Error($"Error loading {gxt} gxt in slot {slot}");
                    return;
                }
            }

            timeout = GetGameTimer() + 2500;
            while (!DoesTextLabelExist(line + "SL"))
            {
                if (GetGameTimer() >= timeout)
                {
                    ClientMain.Logger.Error($"GXT {gxt} loaded but the line {line} doesn't appear to exist.");
                    return;
                }
                await BaseScript.Delay(0);
            }
            ClientMain.Logger.Debug("Voiceline confirmed loaded and valid.");
            // find valid lines
            List<string> lines = new List<string>();
            for (int i = 1; i < 100; i++)
            {
                string l = $"{line}_{i}A";
                if (!DoesTextLabelExist(l))
                {
                    break;
                }
                lines.Add(l);
            }
            bool pedsAreTemp = peds == null || peds.Count == 0;
            if (pedsAreTemp)
            {
                peds = new Dictionary<int, int>();
                foreach (KeyValuePair<int, string> i in speakers)
                {
                    Ped ped = await Functions.CreatePedLocally(Game.PlayerPed.Model, Game.PlayerPed.Position, 0f);
                    peds.Add(i.Key, ped.Handle);
                    SetBlockingOfNonTemporaryEvents(ped.Handle, true);
                    if (forcePedsVisible)
                    {
                        int gamertag = CreateFakeMpGamerTag(ped.Handle, i.Key.ToString() + "-" + i.Value, true, true, "", 1);
                    }
                    else
                    {
                        ped.IsVisible = false;
                        ped.IsCollisionEnabled = false;
                        ped.IsPainAudioEnabled = false;
                        ped.IsInvincible = true;
                        ped.IsPositionFrozen = true;
                        ped.AttachTo(Game.PlayerPed, new Vector3(0f, 0f, -2f));
                    }
                    //NetworkUnregisterNetworkedEntity(ped.Handle); // this should not change when networking is eventually done
                }
            }
            string speakerList = GetLabelText($"{line}SL");
            string lineFlags = GetLabelText($"{line}LF");
            List<int> speakList = new List<int>();
            List<int> listenerList = new List<int>();

            List<string> speakerListParts = new List<string>();
            for (int i = 0; i < speakerList.Length; i += 3)
                speakerListParts.Add(GetTextSubstring(speakerList, i, Math.Min(3, speakerList.Length - i)));

            ClientMain.Logger.Debug($"Found {lines.Count} valid lines");
            ClientMain.Logger.Debug(speakerList);
            ClientMain.Logger.Debug("Just speaker ids:");
            string justSpeakerOutput = "";
            foreach (string i in speakerListParts)
            {
                justSpeakerOutput += GetTextSubstring(i, 0, 1) + " ";
            }
            ClientMain.Logger.Debug(justSpeakerOutput);

            CreateNewScriptedConversation();
            // assign peds to voices
            foreach (KeyValuePair<int, string> s in speakers)
            {
                AddPedToConversation(s.Key, peds[s.Key], s.Value);
                SetPedCanUseAutoConversationLookat(peds[s.Key], true);
            }


            bool anyRadio = false;
            foreach (string l in lines)
            {
                int lidx = lines.IndexOf(l);
                string voiceline = GetLabelText(l);
                string subtitle = GetLabelText(l.TrimEnd('A')); // used for debug writeline
                int speaker = GetSpeakerFromSL(speakerList, lidx); // confirmed
                int listener = func_87(speakerList, lidx); // probably not confirmed

                // dialogue_handler functions
                int unkInt0 = func_85(speakerList, lidx);
                bool bVar6 = func_81(lineFlags, lidx);
                bool bVar7 = func_80(lineFlags, lidx);
                bool bVar8 = func_79(lineFlags, lidx);
                int iVar12 = func_78(lineFlags, lidx);
                bool radioEffect = func_77(lineFlags, lidx); // bVar9
                bool bVar10 = func_76(lineFlags, lidx);
                bool bVar11 = func_75(lineFlags, lidx);

                if (!anyRadio && radioEffect)
                    anyRadio = true;

                if (forceRadio)
                {
                    radioEffect = true;
                    bVar11 = true;
                }

                string lineSl = GetTextSubstring(speakerList, lidx * 3, lidx * 3 + 3);
                string lineLineFlags = GetTextSubstring(lineFlags, lidx * 7, lidx * 7 + 7);
                ClientMain.Logger.Debug($"SL:{lineSl} LF:{lineLineFlags} | {speaker}->{listener} - {voiceline} - {subtitle}");
                AddLineToConversation(
                    speaker,
                    voiceline,
                    l.TrimEnd('A'),
                    listener,
                    unkInt0,
                    false, // hardcoded to false/true based on a label existing? leaving as false for now
                    bVar6, // bVar6, line flags func_81
                    bVar7, // bVar7 func_80
                    bVar8, // bVar8 func_79
                    iVar12, // iVar12 func_78
                    radioEffect, // bVar9
                    bVar10,
                    bVar11 /* frontend */);
            }
            if (anyRadio)
            {
                // wait some time to let radio effect intro play
                await BaseScript.Delay(300);
            }

            // this doesn't really have that much practical use.
            // edit.. it does.. 
            if (phoneCall)
            {
                ClientMain.Logger.Debug("Phone call");
                StartScriptPhoneConversation(SubtitleCheck(), false);
            }
            else
            {
                ClientMain.Logger.Debug("Regular conversation");
                StartScriptConversation(SubtitleCheck(), false, false, false);
            }
            if (peds.Count > 0)
            {
                if (phoneCall)
                {
                    while (!IsMobilePhoneCallOngoing()) await BaseScript.Delay(0);
                    while (IsMobilePhoneCallOngoing()) await BaseScript.Delay(0);
                }
                else
                {
                    while (!IsScriptedConversationOngoing()) await BaseScript.Delay(0);
                    while (IsScriptedConversationOngoing()) await BaseScript.Delay(0);
                }
                foreach (KeyValuePair<int, int> p in peds)
                {
                    int pp = p.Value;
                    DeletePed(ref pp);
                }
                ClearAdditionalText(6, true);
                ClearAdditionalText(14, true);
            }
            ClientMain.Logger.Debug("Hit end of RunDialogue conversation");
        }
        #endregion

        /// <summary>
        /// Plays a randomized dialogue, these are identifiable by them having label entries like the following:
        /// JH_SWITCH_01 -> JH_SWITCH_03
        /// Voiceline: JH_SWITCHA
        /// JHSWITCHSL
        /// </summary>
        /// <param name="gxt">The GXT label set to load into 13/14</param>
        /// <param name="line">The voiceline to play</param>
        /// <param name="voice">The voice of the ped, required to be correct for the voiceline.</param>
        /// <param name="ped">The ped to play it on, if <see langword="null"/> then creates a ped attached to the player.</param>
        /// <param name="forceRadio">Overrides LF flags to force playback on radio</param>
        /// <param name="forceFrontend">Overrides LF flags to force frontend playback</param>
        /// <exception cref="Exception"></exception>
        public static async Task RunRandomizedDialogue(string gxt, string line, string voice, int ped = -1, bool forceRadio = false, bool phoneCall = false, bool forceFrontend = false)
        {

            bool isCtAud = false;
            int iVar1 = 1;
            StopScriptedConversation(true);
            await BaseScript.Delay(0);
            ClientMain.Logger.Debug("Loading GXT: " + gxt);
            if (DoesTextBlockExist(gxt) && gxt.ToLower() == "ct_aud")
            {
                isCtAud = true;
            }
            if (func_98(Functions.HashInt(gxt)))
            {
                //check Global_21607;
                isCtAud = false;
                iVar1 = 0;
            }

            ClearAdditionalText(7, true);
            ClearAdditionalText(15, true);
            ClearAdditionalText(6, true);
            ClearAdditionalText(14, true);

            int timeout = GetGameTimer();
            int slot;
            if (gxt.ToLower() == "anaud" || gxt.ToLower() == "bacalau")
            {
                if (iVar1 == 1 || isCtAud)
                    slot = 7;
                else
                    slot = 15;
            }
            else
            {
                if (iVar1 == 1 || isCtAud)
                    slot = 6;
                else
                    slot = 14;
            }

            if (slot == 6 || slot == 7)
                RequestAdditionalText(gxt, slot);
            else
                RequestAdditionalTextForDlc(gxt, slot);
            while (!HasAdditionalTextLoaded(slot))
            {
                await BaseScript.Delay(0);
                if (GetGameTimer() - timeout >= 5000)
                {
                    ClientMain.Logger.Error($"Error loading {gxt} gxt in slot {slot}");
                    return;
                }
            }


            ClientMain.Logger.Debug("Loaded GXT");

            timeout = GetGameTimer();
            while (!DoesTextLabelExist(line + "SL"))
            {
                if (GetGameTimer() - timeout >= 5000)
                {
                    ClientMain.Logger.Error($"GXT {gxt} loaded but the line {line} doesn't appear to exist.");
                    return;
                }
                await BaseScript.Delay(0);
            }


            string speakerList = GetLabelText($"{line}SL");
            string lineFlags = GetLabelText($"{line}LF");

            bool pedIsTemp = false;

            if (ped == -1)
            {
                ClientMain.Logger.Debug("Creating stand in ped");
                Ped p = await Functions.CreatePedLocally(Game.PlayerPed.Model, Game.PlayerPed.Position, 0f);
                NetworkUnregisterNetworkedEntity(p.Handle);
                p.IsVisible = false;
                p.IsInvincible = true;
                p.IsCollisionEnabled = true;
                p.IsPositionFrozen = true;
                p.IsPainAudioEnabled = false;
                p.AttachTo(Game.PlayerPed, new Vector3(0f, 0f, -2f));
                ped = p.Handle;
                pedIsTemp = true;
            }

            // find all the flags
            int listener = func_87(speakerList, 0);

            int unkInt0 = func_85(speakerList, 0);
            bool bVar6 = func_81(lineFlags, 0);
            bool bVar7 = func_80(lineFlags, 0);
            bool bVar8 = func_79(lineFlags, 0);
            int iVar12 = func_78(lineFlags, 0);
            bool radioEffect = func_77(lineFlags, 0); // bVar9



            bool bVar10 = func_76(lineFlags, 0);
            bool bVar11 = func_75(lineFlags, 0);

            if (forceRadio)
                radioEffect = true;
            if (forceFrontend)
                bVar11 = true;

            CreateNewScriptedConversation();
            AddPedToConversation(0, ped, voice);
            AddLineToConversation(
                0,
                GetLabelText($"{line}A"),
                line,
                listener,
                unkInt0,
                true, // hardcoded to false/true based on a label existing? leaving as TRUE for now
                bVar6, // bVar6, line flags func_81
                bVar7, // bVar7 func_80
                bVar8, // bVar8 func_79
                iVar12, // iVar12 func_78
                radioEffect, // bVar9
                bVar10,
                bVar11 /* frontend */);

            ClientMain.Logger.Debug(line);
            ClientMain.Logger.Debug(GetLabelText($"{line}A"));

            // wait for 500ms if radioEffect is true to let the effect play
            if (radioEffect)
            {
                await BaseScript.Delay(300);
            }

            if (phoneCall)
            {
                StartScriptPhoneConversation(SubtitleCheck(), false);
            }
            else
            {
                StartScriptConversation(SubtitleCheck(), false, false, false);
            }

            ClientMain.Logger.Debug("Started randomized line");
            if (pedIsTemp)
            {
                if (phoneCall)
                {
                    while (!IsMobilePhoneCallOngoing()) await BaseScript.Delay(0);
                    while (IsMobilePhoneCallOngoing()) await BaseScript.Delay(0);
                }
                else
                {
                    while (!IsScriptedConversationOngoing()) await BaseScript.Delay(0);
                    while (IsScriptedConversationOngoing()) await BaseScript.Delay(0);
                }
                DeletePed(ref ped);
            }
            ClearAdditionalText(6, true);
            ClearAdditionalText(14, true);
            ClientMain.Logger.Debug("Hit end of randomized conversation");
        }

        // dialogue_handler.c functions for filling in parameters from LF/SL
        // func_88
        private static int GetSpeakerFromSL(string speakerList, int line)
        {
            string sVar0 = GetTextSubstring(speakerList, line * 3, line * 3 + 1);
            return ConvertCharToNum(sVar0[0]);
        }

        // most likely listener
        private static int func_87(string speakerList, int line)
        {
            string sVar0 = GetTextSubstring(speakerList, line * 3 + 1, line * 3 + 2);
            return ConvertCharToNum(sVar0[0]);
        }

        // thing after listener
        private static int func_85(string speakerList, int line)
        {
            string sVar0 = GetTextSubstring(speakerList, line * 3 + 2, line * 3 + 3);
            return ConvertCharToNum(sVar0[0]);
        }

        private static bool func_83(string flagList)//Position - 0x3D33
        {
            string sVar0 = GetTextSubstring(flagList, 1, 2);
            if (sVar0 == "0")
            {
                return false;
            }
            return true;
        }


        private static bool func_81(string flagList, int line)
        {
            string sVar0 = GetTextSubstring(flagList, line * 7, line * 7 + 1);
            if (sVar0 == "0")
            {
                return false;
            }
            return true;
        }

        private static bool func_80(string flagList, int Line)
        {
            string sVar0 = GetTextSubstring(flagList, Line * 7 + 1, Line * 7 + 2);
            if (sVar0 == "0")
            {
                return false;
            }
            return true;
        }

        private static bool func_79(string flagList, int line)
        {
            string sVar0 = GetTextSubstring(flagList, line * 7 + 2, line * 7 + 3);
            if (sVar0 == "0")
            {
                return false;
            }
            return true;
        }

        // ??? 
        private static int func_78(string flagList, int line)
        {
            string sVar0 = GetTextSubstring(flagList, line * 7 + 3, line * 7 + 4);
            char sVar0c = sVar0[0];
            switch (sVar0c)
            {
                case '0':
                    return 1;
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                default:
                    return 0;
            }
        }

        private static bool func_77(string flagList, int line)
        {
            string sVar0 = GetTextSubstring(flagList, line * 7 + 4, line * 7 + 5);
            if (sVar0 == "0")
            {
                return false;
            }
            return true;
        }

        private static bool func_76(string flagList, int line)
        {
            string sVar0 = GetTextSubstring(flagList, line * 7 + 5, line * 7 + 6);
            if (sVar0 == "0")
            {
                return false;
            }
            return true;
        }

        private static bool func_75(string flagList, int line)
        {
            string sVar0 = GetTextSubstring(flagList, line * 7 + 6, line * 7 + 7);
            if (sVar0 == "0")
            {
                return false;
            }
            return true;
        }

        public static IEnumerable<string> SplitStringInParts(string s, int partLength)
        {
            for (int i = 0; i < s.Length; i += partLength)
                yield return GetTextSubstring(s, i, Math.Min(partLength, s.Length - i));
        }
        public static int ConvertCharToNum(char c)
        {
            if (c >= '0' && c <= '9')
                return c - '0';
            else if (c >= 'A' && c <= 'Z')
                return c - 'A' + 10;
            else
                return -1;
        }

        private static bool SubtitleCheck()
        {
            ClientMain.Logger.Debug(IsSubtitlePreferenceSwitchedOn().ToString());
            return IsSubtitlePreferenceSwitchedOn();
        }

        private static bool func_98(int iParam0)//Position - 0x47C8
        {
            switch (iParam0)
            {
                case -1311531715: //apcutau
                case -389729032: //apair
                case -2064440312: //apcalau
                case 1151576899: //pbpau
                case -360992886: //pbbau
                case 677852396: //expowau
                case 1017913414: //excalau
                case 1994430427: //excpaau
                case 1430620518: //exhelau
                case 1883599394: //bplesau
                case 1146168957: //bpmalau
                case 785850502: //lowreau
                case 1566303118:
                case 1220013368:
                case 71115730:
                case -251854137:
                case -243052328:
                case -1417718107:
                case -351584050: //impaaud
                case 1854373416: //imdunau
                case -1753835094: //imruiau
                case -353948811: //immecau
                case -1883622926: //imarmau
                case -46742865: //imblzau
                case 1260190997: //imphaau
                case 1080008561: //imtecau
                case 1151572586: //imvolau
                case 964109535: //imwasau
                case -436910453: //gnrcaud
                case 659972380: //gnrweau
                case 2120484290: //grapcau
                case 1439733926: //grhalau
                case 26437732: //grdunau
                case 303339033: //grmocau
                case 2088730730: //groppau
                case -1771498136: //grop2au
                case -1993049002: //grtamau
                case -1370815517: //grtrsau
                case -1267951531: //smgcaud
                case 60077066: //smgfzau
                case 1821448936: //iaafiau
                case 2043251532: //iaamoau
                case 1314391445: //iaasfau
                case -1267946537: //iaadeau
                case 1507036282: //silprau
                case 214936528: //subbmau
                case 1071832486: //subfiau
                case 379745124: //subfoau
                case 409276020: //subosau
                case -495085533: //subcaau
                case -383711312: //xmfmaud
                case -1809286053: //tufin
                case -229061423: //subriau
                case 1399593776: //silbcau
                case -1592188591: //silspau
                case 2119072113: //siltaau
                case -2005721953: //silfiau
                case -439426052: //h2cutau
                case 101634771: //batfmau
                case -7767504: //lazfmau
                case -1576797630: //paifmau
                case -556967217: //arintau
                case 510894735: //arannau
                case -96774198: //arasau
                case 1931750438:
                case 962651001: //cagtau
                case -805815803: //ctomau
                case -1396474296: //caspaud
                case 188331744: //cas1aud
                case -667145730: //cas2aud
                case 1027410289: //cas3aud
                case -190066836: //cas4aud
                case 5422313: //cas5aud
                case -591754196: //cas6aud
                case 1414208944: //casuiau
                case -657203993: //casinau
                case 365230037:
                case -1508790734: //casbkau
                case 1751613877: //hs3faau
                case 502358067: //hs3prau
                case -701873518: //hs3cwau
                case -387856564: //hs3leau
                case -342942601:
                case -450026770: //hs3ceau
                case -2121613853: //hs3reau
                case 1192484316: //hs3fiau
                case -839727634: //hs3mnau
                case 700260812: //hs3vnau
                case -1133857112: //ccycaud
                    return true;
            }
            switch (iParam0)
            {
                case 1971768146:
                case 368696214: //hs4paau
                case -519616352:
                case 718322585:
                case 1295831246: //hs4edau
                case -12653036: //hs4bpau
                case -768557360: //hs4moau
                case -31194878: //hs4piau
                case -1352319498: //hs4fiau
                case -1778740544: //h4scpau
                case 972121350: //hs4faud
                case 342937602: //hs4csau
                case 1546600067: //hs4psau
                case 504458761: //tnssaud
                case -1176094125: //tnmmaud
                case 2088767998: //tnrpaud
                case -2090807707: //tnfudau
                case -1452261483: //tnfmcau
                case 1863087954: //tnfiaau
                case 1824767511: //tnfftau
                case -295088776: //tnfboau
                case -650178123: //tnfflau
                case 717392335: //tnfbkau
                case -2003600127: //tnfmhau
                case -855291381: //tnfbbau
                case -1346657670: //tncutau
                case -2127380210: //tnheaud
                case -407018317: //tnaraud
                case 377179274: //tumsaud
                case 1846630598: //tncsbau
                case 1189722080: //lowcaau
                case 2060867368: //lcau
                case 755151809: //fxdl0au
                case 999726434: //fxdl1au
                case 1784376108: //fxdl2au
                case -954494704: //fxdl3au
                case -216515191: //fxdl4au
                case -733016344: //fxdl5au
                case 141855421: //fxflaud
                case -1334558826: //fxfraud
                case 466915412: //fximaud
                case -2139147773: //fxlmaud
                case 49883587: //fxbaaud
                case -1566063990: //fxfaaud
                case 2116454097: //fxcutau
                case -204827863: //fxigaud
                case -1018917633:
                case 1332392277:
                case -1889985881:
                case -1536828534:
                case -580715848:
                case -947428706:
                case -790967848:
                case 1475512972:
                case -9119060:
                case 1748914928:
                case -105714609:
                case -1463539315:
                    return true;
            }
            return false;
        }
    }
}