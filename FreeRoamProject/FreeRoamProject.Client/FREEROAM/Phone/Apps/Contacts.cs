using FreeRoamProject.Client.FREEROAM.Phone.Models;
using FreeRoamProject.Shared.Core.Character;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.FREEROAM.Phone.Apps
{
    public class Contacts : App
    {
        public Contacts(Phone phone) : base("CELL_0", IconLabels.CALL, phone, PhoneView.CONTACTLIST)
        {
            // default contacts

            /*
             agent 14
            assistant (ceo)
            brucie
            charlie
            dom
            downtown cab co
            gerald
            lamar
            lester
            martin
            mechanic
            merryweather
            mors mutual
            pegasus
            ron
            simeon
            tom connors
             */
        }

        private List<ContactsSubMenuItem> ContactsMenu =
        [
            new ContactsSubMenuItem("CELL_MP_1000", 0, 5), // call
            /*
              "CELL_MP_1009H": "There is a short wait before you can send another message to ~a~.",
              "CELL_MP_1009M": "It is currently not possible to send a message to ~a~.",
              "CELL_MP_1009N": "It is currently not possible to send a message.",
            */
            new ContactsSubMenuItem("CELL_MP_1009", 1, 9), // send text
            new ContactsSubMenuItem("PIM_DFRQ2", 2, 0) // friend request
        ];

        public Dictionary<string, string> pedHeadshots = [];
        private bool rimosso = false;
        private string nome = "Nome";
        private string numero = "Numero";
        private static bool FirstTick = true;
        private Contact CurrentSubMenu = null;
        public int contactAmount = 0;
        private int currentPage = 0;
        private int currentRow = 0;
        int min = 0;
        int max = 4;
        bool isCalling = false;
        Contact SelectedContact;
        private int SelectedItem
        {
            get => PhoneContacts.Count == 0 ? 0 : selectedItem % PhoneContacts.Count;
            set
            {
                if (PhoneContacts.Count == 0)
                    selectedItem = 0;
                selectedItem = 1000000 - (1000000 % PhoneContacts.Count) + value;
                if (SelectedItem > max)
                {
                    max = SelectedItem;
                    min = SelectedItem - 4;
                }
                else if (SelectedItem < min)
                {
                    max = SelectedItem + 4;
                    min = SelectedItem;
                }
            }
        }
        internal List<Contact> PhoneContacts = new List<Contact>();
        private int selectedItem = 0;

        private async Task countPlayers()
        {
            HandleList();
            await BaseScript.Delay(1000);
        }

        private void HandleList()
        {
            PhoneContacts.Clear();
            foreach (PlayerClient cli in ClientMain.Instance.Clients)
            {
                //TODO: FOR DEBUGGING AND SENDING TO MYSELF COMMENT THE LINE BELOW.. KEEP UNCOMMENTED.. WE DON'T WANT PLAYERS TO SEE THEMSELVES
                //if (cli.Handle == PlayerCache.MyClient.Handle) continue;

                //TODO: check for blocked players / being blocked by players
                // if blocked/blocking, continue..
                PhoneContacts.Add(new Contact(cli.Player.Name, "CELL_MP_999", true, cli.Handle));
            }
            PhoneContacts = [.. PhoneContacts, .. Phone.getCurrentCharPhone().Contacts];
            // same as playerContacts = playerContacts.Concat(Phone.getCurrentCharPhone().Contacts).ToList();
        }

        public override async Task TickVisual()
        {
            Phone.Scaleform.CallFunction("SET_DATA_SLOT_EMPTY", (int)CurrentView);

            if (CurrentSubMenu != null)
            {
                foreach (ContactsSubMenuItem subMenu in ContactsMenu)
                {
                    BeginScaleformMovieMethod(Phone.Scaleform.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt((int)CurrentView);
                    ScaleformMovieMethodAddParamInt(ContactsMenu.IndexOf(subMenu));
                    ScaleformMovieMethodAddParamBool(false);
                    BeginTextCommandScaleformString(subMenu.Name);
                    EndTextCommandScaleformString();
                    EndScaleformMovieMethod();
                }
                BeginScaleformMovieMethod(Phone.Scaleform.Handle, "SET_HEADER");
                BeginTextCommandScaleformString("STRING");
                AddTextComponentSubstringPhoneNumber("<C>" + CurrentSubMenu.Name + "</C>", -1);
                EndTextCommandScaleformString();
                EndScaleformMovieMethod();
                Phone.Scaleform.CallFunction("DISPLAY_VIEW", (int)CurrentView, SelectedItem);
            }
            else
            {
                BeginScaleformMovieMethod(Phone.Scaleform.Handle, "SET_HEADER");
                BeginTextCommandScaleformString(Title);
                EndTextCommandScaleformString();
                EndScaleformMovieMethod();
                if (PhoneContacts.Count > 0)
                {
                    for (int j = min; j <= max; j++)
                    {
                        Contact contact = PhoneContacts[j];
                        BeginScaleformMovieMethod(Phone.Scaleform.Handle, "SET_DATA_SLOT");
                        ScaleformMovieMethodAddParamInt((int)CurrentView);
                        ScaleformMovieMethodAddParamInt(j - min);
                        ScaleformMovieMethodAddParamBool(false); // missed call? 
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
                        // empty space.. CONTACTLIST.as shows how it checks dataProviderUI[_loc2_][1] and dataProviderUI[_loc2_][3];
                        // but there's no trace of dataProviderUI[_loc2_][2].. so empty space..
                        ScaleformMovieMethodAddParamPlayerNameString("");
                        BeginTextCommandScaleformString(contact.Icon);
                        EndTextCommandScaleformString();
                        EndScaleformMovieMethod();

                        //Phone.Scaleform.CallFunction("SET_DATA_SLOT", (int)CurrentView, j - min, 0, contact.Name, "", contact.Icon);
                    }
                }
                Phone.Scaleform.CallFunction("DISPLAY_VIEW", (int)CurrentView, SelectedItem - min);
            }
        }

        public override async Task TickControls()
        {
            if (Input.IsControlJustPressed(Control.PhoneUp))
            {
                CellCamMoveFinger(1);
                if (CurrentSubMenu == null)
                {
                    if (SelectedItem > 0)
                    {
                        SelectedItem--;
                    }
                    else
                    {
                        min = PhoneContacts.Count - 5;
                        max = PhoneContacts.Count - 1;
                        SelectedItem = PhoneContacts.Count - 1;
                    }
                }
                else
                {
                    if (SelectedItem > 0)
                        SelectedItem--;
                    else
                        SelectedItem = ContactsMenu.Count - 1;
                }
                Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
            }
            else if (Input.IsControlJustPressed(Control.PhoneDown))
            {
                CellCamMoveFinger(2);
                if (CurrentSubMenu == null)
                {
                    if (SelectedItem < PhoneContacts.Count - 1)
                    {
                        SelectedItem++;
                    }
                    else
                    {
                        min = 0;
                        max = 4;
                        SelectedItem = 0;
                    }
                }
                else
                {
                    if (SelectedItem < ContactsMenu.Count - 1)
                        SelectedItem++;
                    else
                        SelectedItem = 0;
                }
                Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
            }
            else if (Input.IsControlJustPressed(Control.PhoneLeft))
            {
                if (CurrentSubMenu == null)
                {
                    SelectedItem -= 5;
                    Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                }
            }
            else if (Input.IsControlJustPressed(Control.PhoneRight))
            {
                if (CurrentSubMenu == null)
                {
                    SelectedItem += 5;
                    Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                }
            }
            else if (Input.IsControlJustPressed(Control.PhoneSelect))
            {
                CellCamMoveFinger(5);
                if (CurrentSubMenu == null)
                {
                    if (PhoneContacts[SelectedItem].IsPlayer)
                    {
                        SelectedContact = PhoneContacts[SelectedItem];
                        CurrentSubMenu = PhoneContacts[SelectedItem];
                        SelectedItem = 0;
                        Phone.SetSoftKeys(1, SoftKeys.BLANK, false, SColor.HUD_Freemode);
                        Phone.SetSoftKeys(2, SoftKeys.SELECT, true, SColor.HUD_Freemode);
                        Phone.SetSoftKeys(3, SoftKeys.BACK, true, SColor.HUD_Red);
                    }
                    else
                    {
                        ((CallScreen)Phone.Callscreen).SetContact(PhoneContacts[SelectedItem]);
                        Phone.StartApp("callscreen", true);
                        await BaseScript.Delay(250);
                        //((CallScreen)Phone.Callscreen).SoundId = Audio.PlaySoundFrontend("Dial_and_Remote_Ring", "Phone_SoundSet_Default");
                        ((CallScreen)Phone.Callscreen).SoundId = Audio.PlaySoundFrontend("Remote_Ring", "Phone_SoundSet_Default");
                        ((CallScreen)Phone.Callscreen).CallStatus = 0;
                        // we call the cpu char
                    }
                }
                else
                {
                    switch (SelectedItem)
                    {
                        case 0:
                            isCalling = true;
                            break;
                        case 1:
                            // textMessage
                            string title = "FMMC_KEY_TIP8";
                            int max = 60;
                            if (Game.Language == Language.Russian || Game.Language == Language.Chinese || Game.Language == Language.Korean || Game.Language == Language.Japanese || Game.Language == (Language)12)
                            {
                                title = "FMMC_KEY_TIP8S";
                                max = 20;
                            }
                            string text = (await Functions.GetUserInput(Game.GetGXTEntry(title), "", max)).Trim();
                            Main.InstructionalButtons.AddSavingText(LoadingSpinnerType.Clockwise1, GetLabelText("ERROR_CHECKPROFANITY"));
                            await BaseScript.Delay(100);
                            ProfanityCheck profanityRes = await Functions.CheckStringHasProfanity(text);
                            await BaseScript.Delay(100);
                            Main.InstructionalButtons.HideSavingText();
                            if (profanityRes == ProfanityCheck.SAFE)
                            {
                                EventDispatcher.Send("tlg:phone:sendTextToPlayer", SelectedContact.ServerID, text);
                                Notifications.ShowNotification(Game.GetGXTEntry("CP_TM_SENT").Replace("~a~", $"<C>{SelectedContact.Name}</C>"));
                            }
                            else
                            {
                                Notifications.ShowHelpNotification(Game.GetGXTEntry("ERROR_FAILEDPROFANITY"), 5000);
                            }
                            break;
                        case 2:
                            // friend req
                            break;
                    }

                }
                Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
            }
            else if (Input.IsControlJustPressed(Control.PhoneCancel))
            {
                CellCamMoveFinger(5);
                if (CurrentSubMenu != null)
                {
                    CurrentSubMenu = null;
                    SelectedItem = 0;
                    Phone.SetSoftKeys(1, SoftKeys.KEYPAD, true, SColor.HUD_Freemode);
                    Phone.SetSoftKeys(2, SoftKeys.CALL, true, SColor.HUD_Green);
                    Phone.SetSoftKeys(3, SoftKeys.BACK, true, SColor.HUD_Red);
                }
                else
                {
                    Phone.StartApp("MAINMENU");
                }
                Game.PlaySound("Menu_Back", "Phone_SoundSet_Default");
            }
        }

        public override void Initialize(Phone phone)
        {
            Phone = phone;
            CurrentSubMenu = null;
            rimosso = false;
            contactAmount = 0;
            HandleList();
            ClientMain.Instance.AddTick(countPlayers);
            ClientMain.Instance.AddTick(TickVisual);
            ClientMain.Instance.AddTick(TickControls);
            SelectedItem = 0;
            Phone.SetSoftKeys(1, SoftKeys.KEYPAD, true, SColor.HUD_Freemode);
            Phone.SetSoftKeys(2, SoftKeys.CALL, true, SColor.HUD_Green);
            Phone.SetSoftKeys(3, SoftKeys.BACK, true, SColor.HUD_Red);
        }

        public override void Kill()
        {
            PhoneContacts.Clear();
            ClientMain.Instance.RemoveTick(countPlayers);
            ClientMain.Instance.RemoveTick(TickVisual);
            ClientMain.Instance.RemoveTick(TickControls);
        }
    }

    public class ContactsSubMenuItem
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Icon { get; set; }

        public ContactsSubMenuItem(string name, int id, int icon)
        {
            Name = name;
            Id = id;
            Icon = icon;
        }

    }
}
