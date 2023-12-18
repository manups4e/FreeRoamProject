using FreeRoamProject.Client.FREEROAM.Phone.Models;
using FreeRoamProject.Client.Handlers;
using FreeRoamProject.Shared.Core.Character;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.FREEROAM.Phone.Apps
{
    public enum CallState
    {
        DIALING,
        INCOMING_CALL,
        CONNECTED,
        BUSY
    }
    internal class CallScreen : App
    {
        int Time;
        Contact contact;
        internal CallState CallStatus = 0;
        bool answered = false;
        internal int SoundId;
        bool callEnded = false;
        /*
      "CELL_211": "DIALING...", // waiting response..
      "CELL_217": "INCOMING CALL", // receiving call
      "CELL_219": "CONNECTED", // answered both incoming and outgoing
      "CELL_220": "BUSY", // not respond
       
         */

        public CallScreen(Phone phone) : base("callscreen", IconLabels.ON_CALL, phone, PhoneView.CALLSCREEN)
        {

        }

        public async Task TickVisual()
        {
            switch (CallStatus)
            {
                case CallState.DIALING:
                    if (Game.GameTime - Time > 1700 && Game.GameTime - Time < 1750)
                    {
                        ClientMain.Logger.Debug("IS_MOBILE_PHONE_CALL_ONGOING: " + IsMobilePhoneCallOngoing());
                        //SoundId = Audio.PlaySoundFrontend("Remote_Ring", "Phone_SoundSet_Default");
                    }
                    else if (Game.GameTime - Time > 3400 && Game.GameTime - Time < 3425)
                    {
                        if (contact.IsPlayer)
                        {
                            // check if player connected else status = BUSY
                            CallStatus = CallState.BUSY;
                            Time = GetGameTimer();
                            UpdateScreen();
                        }
                        else
                        {
                            CallStatus = CallState.CONNECTED;
                            UpdateScreen();
                            await CheckIfBotCanAnswerAndRespond();
                            Game.PlaySound("Hang_Up", "Phone_SoundSet_Default");
                            Phone.ClosePhone();
                        }
                    }
                    break;
                case CallState.INCOMING_CALL:
                    break;
                case CallState.CONNECTED:
                    break;
                case CallState.BUSY:
                    break;
            }
        }

        public void UpdateScreen()
        {
            Phone.Scaleform.CallFunction("SET_DATA_SLOT_EMPTY", (int)CurrentView);
            BeginScaleformMovieMethod(Phone.Scaleform.Handle, "SET_DATA_SLOT");
            ScaleformMovieMethodAddParamInt((int)CurrentView);
            ScaleformMovieMethodAddParamInt(0);
            ScaleformMovieMethodAddParamInt(0);
            if (contact.IsPlayer)
            {
                BeginTextCommandScaleformString("STRING");
                AddTextComponentSubstringPhoneNumber(contact.Name, -1);
                EndTextCommandScaleformString();
            }
            else
            {
                BeginTextCommandScaleformString(contact.Name);
                EndTextCommandScaleformString();
            }
            BeginTextCommandScaleformString(contact.Icon);
            EndTextCommandScaleformString();
            switch (CallStatus)
            {
                case CallState.DIALING:
                    BeginTextCommandScaleformString("CELL_211");
                    EndTextCommandScaleformString();
                    break;
                case CallState.INCOMING_CALL:
                    BeginTextCommandScaleformString("CELL_217");
                    EndTextCommandScaleformString();
                    //
                    break;
                case CallState.CONNECTED:
                    BeginTextCommandScaleformString("CELL_219");
                    EndTextCommandScaleformString();
                    //Remote_Engaged
                    break;
                case CallState.BUSY:
                    BeginTextCommandScaleformString("CELL_220");
                    EndTextCommandScaleformString();
                    break;
            }
            EndScaleformMovieMethod();
            Phone.Scaleform.CallFunction("DISPLAY_VIEW", (int)CurrentView);
        }


        public override async Task TickControls()
        {
            if (Input.IsControlJustPressed(Control.PhoneSelect))
            {
                if (CallStatus == CallState.INCOMING_CALL)
                {
                    if (CallStatus == CallState.INCOMING_CALL)
                    {
                        // accepted.
                        if (IsPedRingtonePlaying(PlayerPedId()))
                            StopPedRingtone(PlayerPedId());
                        Phone.SetSoftKeys(1, SoftKeys.BLANK, false, SColor.White);
                        Phone.SetSoftKeys(2, SoftKeys.BLANK, false, SColor.White);
                        Phone.SetSoftKeys(3, SoftKeys.HANGUP, true, SColor.HUD_Red);
                        CallStatus = CallState.CONNECTED;
                    }
                }
            }
            if (Input.IsControlJustPressed(Control.PhoneCancel))
            {
                if (IsPedRingtonePlaying(PlayerPedId()))
                    StopPedRingtone(PlayerPedId());
                Game.PlaySound("Hang_Up", "Phone_SoundSet_Default");
                Kill();
                Phone.ClosePhone();
            }
            //TODO: in case of scripted call.. restart random timers for scripted chars to call the player
        }

        public void SetContact(Contact c)
        {
            contact = c;
        }

        public override void Initialize(Phone phone)
        {
            Phone = phone;
            ClientMain.Instance.AddTick(TickVisual);
            ClientMain.Instance.AddTick(TickControls);
            if (CallStatus == CallState.INCOMING_CALL)
            {
                Phone.SetSoftKeys(1, SoftKeys.BLANK, false, SColor.White);
                Phone.SetSoftKeys(2, SoftKeys.CALL, true, SColor.HUD_Green);
                Phone.SetSoftKeys(3, SoftKeys.BLANK, false, SColor.White);
            }
            else if (CallStatus == CallState.CONNECTED)
            {
                Phone.SetSoftKeys(1, SoftKeys.BLANK, false, SColor.White);
                Phone.SetSoftKeys(2, SoftKeys.BLANK, false, SColor.White);
                Phone.SetSoftKeys(3, SoftKeys.HANGUP, true, SColor.HUD_Red);
            }
            Time = GetGameTimer();
            TaskUseMobilePhone(PlayerPedId(), 1);
            callEnded = false;
            UpdateScreen();
        }
        public override void Kill()
        {
            Audio.StopSound(SoundId);
            Audio.ReleaseSound(SoundId);
            ClientMain.Instance.RemoveTick(TickVisual);
            ClientMain.Instance.RemoveTick(TickControls);
            TaskUseMobilePhone(PlayerPedId(), 0);
        }

        private async Task CheckIfBotCanAnswerAndRespond()
        {

            // Local_122.f_180 could be the speaker id..

            Audio.StopSound(SoundId);
            Audio.ReleaseSound(SoundId);
            // check and get voice of all the peds :D easy peasy
            switch (contact.Name)
            {

                // strippers
                case "CELL_114": //chastity
                case "CELL_115": //cheetah
                case "CELL_418": //fufu
                case "CELL_117": //infernus
                case "CELL_112": //giuliet
                case "CELL_413": //nikki
                case "CELL_419": //peach
                case "CELL_416": //sapphire
                    string voice;
                    int id;
                    switch (contact.Name)
                    {
                        case "CELL_114": //chastity
                            id = 2;
                            voice = "chastity";
                            break;
                        case "CELL_115": //cheetah
                            id = 3;
                            voice = "cheetah";
                            break;
                        case "CELL_418": //fufu
                            id = 7;
                            voice = "fufu";
                            break;
                        case "CELL_117": //infernus
                            id = 6;
                            voice = "infernus";
                            break;
                        case "CELL_112": //giuliet
                            id = 0;
                            voice = "giuliet";
                            break;
                        case "CELL_413": //nikki
                            id = 1;
                            voice = "nikki";
                            break;
                        case "CELL_419": //peach
                            id = 8;
                            voice = "peach";
                            break;
                        case "CELL_416": //sapphire
                            id = 4;
                            voice = "sapphire";
                            break;
                        default:
                            id = 0;
                            voice = "giuliet";
                            break;
                    }
                    await DialogueControllerClient.RunRandomizedDialogue("CT_AUD", "MPCT_MORE_" + id, voice, -1, false, true, false);
                    break;
                case "CELL_165": // agent 14
                    //gxt dlc is SM2AGAU
                    // char is AGENT14
                    // if answers SM2AG_PC_1A
                    // if checks SM2AG_PC_2A
                    // if sends over SM2AG_PC_3A
                    // if accepts SM2AG_PC_4A
                    // if refuses SM2AG_PC_5A
                    // if hang idle SM2AG_PC_6A
                    // if player hangup SM2AG_PC_7A
                    await DialogueControllerClient.RunRandomizedDialogue("SM2AGAU", "SM2AG_PC_1A", "AGENT14", -1, false, true, false);

                    break;
                case "CELL_P_ASSIST": // secretary male
                case "CELL_P_ASSISTF": // secretary female
                    string execSec = "EXECPA_MALE";
                    string execLine = "EXCAL_GREETM";
                    int speaker = 3;
                    if (contact.Name == "CELL_P_ASSISTF")
                    {
                        /* if the player can interact with them
                        execSec = "EXECPA_FEMALE";
                        exeLine = "EXCAL_GREETF";
                        await DialogueControllerClient.RunRandomizedDialogue("EXCALAU", exeLine, execSec, -1, false, true, false);
                        */
                        execSec = "EXCAL_BUSYM";
                        execLine = "EXCAL_BUSYF";
                        speaker = 2;
                    }
                    await DialogueControllerClient.RunDialogue("EXCALAU", new Dictionary<int, string> { [speaker] = execSec }, execLine, null, false, true, false);
                    break;
                case "CELL_447": // brucie
                    await DialogueControllerClient.RunRandomizedDialogue("CT_AUD", "MPCT_3", "BRUCIE", -1, false, true, false);

                    break;
                case "CELL_BRYONY_N":
                    break;
                case "CELL_YACHT": // captain
                    //TODO: NEED UNDERSTANDING.. AS IT'S NOT LOADING THE LABELS FOR APCALAU
                    if (GetRoomKeyFromEntity(PlayerPedId()) == Functions.HashInt("YachtRm_Bridge"))
                    {
                        await DialogueControllerClient.RunDialogue("APCALAU", new Dictionary<int, string> { [2] = "YACHTCAPTAIN" }, "APCAL_GEBUS", null, false, true, false);
                    }
                    else
                    {
                        // genpg also if inside office/things like that..
                        await DialogueControllerClient.RunRandomizedDialogue("APCALAU", "APCAL_GENPG", "YACHTCAPTAIN", -1, false, true, false);
                    }
                    break;
                case "CELL_150":
                    break;
                case "CELL_163":
                    break;
                case "CELL_131":
                    break;
                case "CELL_NCLUBE_N":
                    break;
                case "CELL_FRANKLIN_N":
                    // fix-franklin
                    // gxt dlc is FXFRAUD
                    // if answers FXFR_PM_1
                    // if hang in idle FXFR_PM_2
                    // if accept something for later FXFR_PM_3
                    // if same as _3 FXFR_PM_4
                    // if suv on the way FXFR_PM_5
                    // if veh on the way FXFR_PM_6
                    // if supply request FXFR_PM_7
                    // if accept FXFR_PM_8
                    // if refuses FXFR_PM_9
                    // if player hangs up FXFR_PM_10
                    await DialogueControllerClient.RunRandomizedDialogue("FXFRAUD", "FXFR_PM_1", "FIX_FRANKLIN", -1, false, true, false);

                    break;
                case "CELL_E_228": // gerald
                    // if answer MPCT_GER
                    // if yes MPCT_GGEN1
                    // if no MPCT_GGEN2
                    // if whassup? MPCT_GGEN3
                    // if close MPCT_GGEN4
                    // if player hangs MPCT_GHANG
                    // if player awaits MPCT_GIDLE
                    // if job selected MPCT_GJOB
                    // if no job atm MPCT_GJOBCOO
                    // if nothing avail MPCT_GJOBNO
                    // if no money MPCT_GMON
                    // if gerald calls you MPCT_GREM
                    await DialogueControllerClient.RunRandomizedDialogue("CT_AUD", "MPCT_GJOBNO", "Gerald", -1, false, true, false);
                    break;
                case "CELL_IMANI_N":
                    // fix-imani
                    // gxt dlc is FXIMAUD
                    // if answers FXIM_PM_1A
                    // if hang idle FXIM_PM_2A
                    // if go ghost selected FXIM_PM_3A
                    // if asking for a location FXIM_PM_4A
                    // if dead zone? selected FXIM_PM_5A
                    // if something selected FXIM_PM_6A
                    // if refused FXIM_PM_7A
                    // if player hags up FXIM_PM_8A

                    await DialogueControllerClient.RunRandomizedDialogue("FXIMAUD", "FXIM_PM_1A", "FIX_IMANI", -1, false, true, false);

                    break;
                case "CELL_128": // lamar
                    //if we unlock something about lamar services
                    //  if myped female
                    //      await DialogueControllerClient.RunRandomizedDialogue("CT_AUD", "MPCT_LMansF", "Lamar", -1, false, true, false);
                    //  else
                    //      await DialogueControllerClient.RunRandomizedDialogue("CT_AUD", "MPCT_1", "Lamar", -1, false, true, false);
                    //else voice mail
                    await DialogueControllerClient.RunRandomizedDialogue("CT_AUD", "MPCT_6", "Lamar", -1, false, true, false);

                    //if selected the hide from map  MPCT_RDR (1 minute) / MPCT_RDR2 (no time.. > 1 minute?) / MPCT_RDRNO (already used.. can't use again)


                    break;
                case "CELL_NCLUBL_N":
                    break;
                case "CELL_111": // lester
                    //check if ped can access menu
                    //await DialogueControllerClient.RunRandomizedDialogue("CT_AUD", "MPCT_0", "Lester", -1, false, true, false);
                    //else voice mail
                    await DialogueControllerClient.RunDialogue("ANAUD", new Dictionary<int, string> { [1] = "LESTER" }, "LES_APH2", null, false, true, false);
                    break;
                case "CELL_CH_BIK2":
                    break;
                case "CELL_CH_BIK1":
                    break;
                case "CELL_144": // martin
                    // if no job MPCT_MJOBNO
                    // if no job for the moment MPCT_MJOBCOO
                    // if answer MPCT_MART (random)
                    // if left hanging without selecting MPCT_Midle (random)
                    // if job MPCT_MJOB
                    // if player hangs MPCT_Mhang (random)
                    // if player has no money MPCT_MMON (random)
                    // if player... insults him? MPCT_MMAD (random)
                    await DialogueControllerClient.RunDialogue("CT_AUD", new Dictionary<int, string> { [1] = "MARTIN" }, "MPCT_MJOBNO", null, false, true, false);

                    break;
                case "CELL_180": // mecanic
                    // if unavail, or no garage.. MPCT_MCGEN2 (random)
                    // if garage is empty.. MPCT_NoVeh (random)
                    // if mechanic cannot bring you the vehicle MPCT_11 (random)
                    // if mechanic can bring you the veh MPCT_10 (random)
                    await DialogueControllerClient.RunRandomizedDialogue("CT_AUD", "MPCT_MCGEN2", "Mechanic", -1, false, true, false);

                    break;
                case "CELL_E_221": // merryweather

                    // if merryweather available
                    // val must be MPCT_2 (random)
                    int iVar0 = SharedMath.GetRandomInt(0, 4);
                    string val = "";
                    switch (iVar0)
                    {
                        case 0:
                            val = "MPCT_21";
                            break;

                        case 1:
                            val = "MPCT_21b";
                            break;

                        case 2:
                            val = "MPCT_21c";
                            break;

                        case 3:
                            val = "MPCT_21d";
                            break;
                    }
                    await DialogueControllerClient.RunDialogue("CT_AUD", new Dictionary<int, string> { [3] = "FM_MERRYWEATHER" }, val, null, false, true, false);
                    break;
                case "CELL_E_275": // mors mutual
                    // we start with MPCT_INS0 to answer the call (random)
                    // while the player decides.. if more than 10 / 15 seconds passed we use MPCT_INSIDLE (random)
                    // 3 options:
                    // - if player hangs: MPCT_INHANG (random)
                    // - if player can pay and we restore veh MPCT_INSCON (random)
                    // - if player cannot pay MPCT_INSMON (random)
                    await DialogueControllerClient.RunRandomizedDialogue("CT_AUD", "MPCT_INS0", "MorsMutual", -1, false, true, false);
                    // make a while here for player decision.. not a bool.. but a int state..
                    // if player hangs value goes 0, if player decides it goes 1.. if we wait it stays -1
                    // so we can handle the responses with phone opened
                    break;
                case "CELL_CAS_MAN_N": // Ms. Baker
                    // gxt dlc is CAGTAU
                    // when answer CAGT_PM_1
                    // when hang idle CAGT_PM_2
                    // when going back to conversation i think? or maybe another handle in idle? CAGT_PM_3
                    // no can't do CAGT_PM_4
                    // sure no problem CAGT_PM_5
                    // something she will call later for... CAGT_PM_7
                    // requested limo CAGT_PM_8
                    // requested supercar CAGT_PM_9
                    await DialogueControllerClient.RunRandomizedDialogue("CAGTAU", "CAGT_PM_1", "CAS_AGATHA", -1, false, true, false);
                    break;
                case "CELL_BBPAIGE_N":
                    break;
                case "CELL_PAVEL_N": // pavel
                    // dictionary is HS4PAAU
                    // char is HS4_PAVEL
                    // if answer HS4PA_PCR_1
                    // if accept HS4PA_PCR_2
                    // if no possible HS4PA_PCR_3
                    // if hang idle HS4PA_PCR_4
                    // if hang call HS4PA_PCR_5
                    await DialogueControllerClient.RunRandomizedDialogue("HS4PAAU", "HS4PA_PCR_3", "HS4_PAVEL", -1, false, true, false);

                    break;
                case "CELL_E_247": // pegasus
                    // if no pegasus ANAUD - ANS_PGbusy (normal diag)
                    // if pegasis CT_AUD - MPCT_12 (random)
                    await DialogueControllerClient.RunDialogue("ANAUD", new Dictionary<int, string> { [1] = "PEGASUS" }, "ANS_PGbusy", null, false, true, false);
                    break;
                case "CELL_429": // ron
                    // what are the GEN ones for??
                    // yes MPCT_RGEN1
                    // no MPCT_RGEN2
                    // hi MPCT_RGEN3
                    // bye MPCT_RGEN4
                    // if player hangs MPCT_RHANG
                    // if idle too much time MPCT_RIDLE
                    // if job avail and selected MPCT_RJOB
                    // if no job avail at the moment MPCT_RJOBCOO
                    // if no job avail MPCT_RJOBNO
                    // if player has no money MPCT_RMON
                    // if he answers job MPCT_RON
                    // bewlow all the possible calls he can make.. a lot!
                    // MPCT_RREM (random)
                    // MPCT_RREM2B (normal)
                    // MPCT_RREM2C (normal)
                    // MPCT_RREM2D (normal)
                    // MPCT_RREM2E (normal)
                    // MPCT_RREM2F (normal)
                    // MPCT_RREM2 (normal)
                    // MPCT_RREM3B (normal)
                    // MPCT_RREM3C (normal)
                    // MPCT_RREM3D (normal)
                    // MPCT_RREM3E (normal)
                    // MPCT_RREM3 (normal)
                    // MPCT_RTJOB (random)
                    // example call via dialog
                    // await DialogueControllerClient.RunDialogue("CT_AUD", new Dictionary<int, string> { [2] = "NERVOUSRON" }, "MPCT_RREM2B", null, false, true, false);

                    await DialogueControllerClient.RunRandomizedDialogue("CT_AUD", "MPCT_RJOBNO", "NERVOUSRON", -1, false, true, false);

                    break;
                case "CELL_SES_N": // sessanta
                    // gxt dlc is TNSSAUD
                    //if she answer TNSS_PC_AN1
                    //if player hangs call TNSS_PC_BY1
                    //if she refues TNSS_PC_GN1
                    //if she accept TNSS_PC_GP1
                    //if she hang in idle TNSS_PC_ID1
                    await DialogueControllerClient.RunRandomizedDialogue("TNSSAUD", "TNSS_PC_GN1", "TUN_SESSANTA", -1, false, true, false);

                    break;
                case "CELL_427": // simeon
                    /*
                    voice mail for no jobs with simeon MPCT_SJOBNO 
                    if no job he answer with this.. like a voicemail.. MPCT_SJOBCOO (random)
                    (random) 
                    if job:
                     - when simeon answer MPCT_SIME (random)
                     - if simeon awaits (like the mors mutual) MPCT_SIDLE  (random)
                     - if player has money MPCT_SJOB (random)
                     - no money MPCT_SMON (random)
                    for the random calls while free roaming.. MPCT_SREM (random)
                    */
                    await DialogueControllerClient.RunRandomizedDialogue("CT_AUD", "MPCT_SJOBNO", "Simeon", -1, false, true, false);
                    break;
                case "CELL_NCLUBT_N": // tony
                    // gxt label is SM2TOAU
                    //char is BTL_TONY
                    // if answers SM2TO_PC_1A
                    // if checks to-do list SM2TO_PC_2A
                    // if sends something over SM2TO_PC_3A
                    // if accepts SM2TO_PC_4A
                    // if no money SM2TO_PC_5A
                    // if hang idle SM2TO_PC_6A
                    // if player hangup SM2TO_PC_7A
                    await DialogueControllerClient.RunRandomizedDialogue("SM2TOAU", "SM2TO_PC_1A", "BTL_TONY", -1, false, true, false);
                    break;
                case "CELL_WENDY_N": // Wendy.... 

                    break;
                case "CELL_YOHAN_N": // yohan
                    // gxt dlc is SM2YOAU
                    // char is BTL_YOHAN
                    // if answers SM2YO_PC_1A
                    // if checks SM2YO_PC_2A
                    // if accepts SM2YO_PC_3A
                    // if refuses SM2YO_PC_4A
                    // if hung idle SM2YO_PC_5A
                    // if player hangup SM2YO_PC_6A
                    await DialogueControllerClient.RunRandomizedDialogue("SM2YOAU", "SM2YO_PC_1A", "BTL_YOHAN", -1, false, true, false);

                    break;
                case "CELL_CELEB_N":
                    break;
            }
            await BaseScript.Delay(1000);
        }
    }
}
