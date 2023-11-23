using FreeRoamProject.Client.FREEROAM.Phone.Models;
using FreeRoamProject.Shared.Core.Character;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.FREEROAM.Phone.Apps
{
    public class Contacts : App
    {
        public Contacts(Phone phone) : base(Game.GetGXTEntry("CELL_0"), 5, phone)
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

        private List<ContactsSubMenuItem> MenuContatti = new List<ContactsSubMenuItem>
        {
            new ContactsSubMenuItem("Scrivi un Messaggio", 0, 9),
            new ContactsSubMenuItem("Chiama", 1, 5),
        };

        public Dictionary<string, string> pedHeadshots = new Dictionary<string, string>();
        private bool rimosso = false;
        private string nome = "Nome";
        private string numero = "Numero";
        private int SelectedItem { get; set; } = 0;
        private static bool FirstTick = true;
        private Contact CurrentSubMenu = null;
        public List<Contact> loadedContacts = new List<Contact>();
        public int contactAmount = 0;
        private int currentPage = 0;
        private int currentRow = 0;

        public override async Task Tick()
        {
            if (FirstTick)
            {
                FirstTick = false;
                await BaseScript.Delay(100);
                return;
            }

            Phone.Scaleform.CallFunction("SET_DATA_SLOT_EMPTY", 2);

            string appName = "Contatti";
            if (CurrentSubMenu != null)
            {
                foreach (ContactsSubMenuItem subMenu in MenuContatti)
                    Phone.Scaleform.CallFunction("SET_DATA_SLOT", 2, MenuContatti.IndexOf(subMenu), subMenu.Icon, "~l~" + subMenu.Name);
                if (SelectedItem < Phone.getCurrentCharPhone().Contacts.Count)
                    if (!String.IsNullOrEmpty(CurrentSubMenu.Name))
                        appName = CurrentSubMenu.Name;
            }
            else
            {
                foreach (Contact contatto in Phone.getCurrentCharPhone().Contacts)
                {
                    Phone.Scaleform.CallFunction("SET_DATA_SLOT", 2, Phone.getCurrentCharPhone().Contacts.IndexOf(contatto), 0, contatto.Name, "", contatto.Icon);
                }
            }
            Phone.Scaleform.CallFunction("DISPLAY_VIEW", 2, SelectedItem);

            bool navigated = true;
            int direction = 0;
            if (Input.IsControlJustPressed(Control.PhoneUp))
            {
                CellCamMoveFinger(1);
                if (SelectedItem > 0)
                    SelectedItem -= 1;
                else
                {
                    if (CurrentSubMenu != null)
                        SelectedItem = MenuContatti.Count - 1;
                    else
                        SelectedItem = Phone.getCurrentCharPhone().Contacts.Count - 1;
                }
                direction = 1;
            }
            else if (Input.IsControlJustPressed(Control.PhoneDown))
            {
                CellCamMoveFinger(2);
                if (CurrentSubMenu == null)
                {
                    if (SelectedItem < Phone.getCurrentCharPhone().Contacts.Count - 1)
                        SelectedItem += 1;
                    else
                        SelectedItem = 0;
                }
                else
                {
                    if (SelectedItem < MenuContatti.Count - 1)
                        SelectedItem += 1;
                    else
                        SelectedItem = 0;
                }
                direction = 3;
            }
            else if (Input.IsControlJustPressed(Control.FrontendAccept))
            {
                CellCamMoveFinger(5);
                if (CurrentSubMenu == null)
                {
                    CurrentSubMenu = Phone.getCurrentCharPhone().Contacts[SelectedItem];
                    //					SelectedItem = 0;
                    if ((CurrentSubMenu.Name == "Polizia" || CurrentSubMenu.Name == "Medico" || CurrentSubMenu.Name == "Meccanico" || CurrentSubMenu.Name == "Taxi" || CurrentSubMenu.Name == "Concessionario" || CurrentSubMenu.Name == "Agente Immobiliare" || CurrentSubMenu.Name == "Reporter") && !rimosso)
                    {
                        MenuContatti.RemoveAt(1);
                        rimosso = true;
                    }
                    if (CurrentSubMenu.Name == "Aggiungi Contact")
                    {
                        MenuContatti.Clear();
                        MenuContatti.Add(new ContactsSubMenuItem(nome, 0, 0));
                        MenuContatti.Add(new ContactsSubMenuItem(numero, 1, 0));
                        MenuContatti.Add(new ContactsSubMenuItem("Salva Contact", 2, 0));
                    }
                }
                else
                {
                    if (MenuContatti[SelectedItem].Name == "Scrivi un Messaggio")
                    {
                        string msg = await Functions.GetUserInput("Inserisci un Messaggio", "", 100);
                        BaseScript.TriggerServerEvent("phone_server:receiveMessage", PlayerCache.MyPlayer.Name, msg, PlayerCache.MyPlayer.Handle);
                    }
                    if (MenuContatti[SelectedItem].Name == "Chiama")
                        BaseScript.TriggerServerEvent("phoneServer:Chiama");
                    if (MenuContatti[SelectedItem].Name == nome)
                        nome = await Functions.GetUserInput("Inserisci il Nome", "", 30);
                    if (MenuContatti[SelectedItem].Name == numero)
                        numero = await Functions.GetUserInput("Inserisci il numero", "", 30);
                    if (MenuContatti[SelectedItem].Name == "Salva Contact")
                        BaseScript.TriggerServerEvent("phoneServer:aggiungiContact", nome, numero);
                }
            }
            else if (Input.IsControlJustPressed(Control.FrontendCancel))
            {
                CellCamMoveFinger(5);
                if (CurrentSubMenu != null)
                {
                    CurrentSubMenu = null;
                    SelectedItem = 0;
                    MenuContatti.Clear();
                    rimosso = false;
                    MenuContatti = new List<ContactsSubMenuItem>
                    {
                        new ContactsSubMenuItem("Scrivi un Messaggio", 0, 0),
                        new ContactsSubMenuItem("Chiama", 1, 0),
                    };
                }
                else
                {
                    navigated = false;
                    PhoneMainClient.StartApp("Main");
                }
            }
            else
                navigated = false;
            if (navigated)
            {
                Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                Phone.Scaleform.CallFunction("SET_INPUT_EVENT", direction);
            }
        }


        private void SetContactRow(int start, int end)
        {
            for (int i = start; i < end + 1; i++)
            {
                Contact contatto = Phone.getCurrentCharPhone().Contacts[i];
                Phone.Scaleform.CallFunction("SET_DATA_SLOT", 2, Phone.getCurrentCharPhone().Contacts.IndexOf(contatto), 0, contatto.Name, "", contatto.Icon);
                /*
				BeginScaleformMovieMethod(Phone.Scaleform.Handle, "SET_DATA_SLOT");
				ScaleformMovieMethodAddParamInt(2);
				ScaleformMovieMethodAddParamInt(Phone.getCurrentCharPhone().contatti.IndexOf(contatto));
				ScaleformMovieMethodAddParamInt(0);
				BeginTextCommandScaleformString("STRING");
				AddTextComponentSubstringPlayerName(contatto.Name);
				EndTextCommandScaleformString();
				BeginTextCommandScaleformString("CELL_999");
				EndTextCommandScaleformString();
				BeginTextCommandScaleformString("CELL_2000");
				AddTextComponentSubstringPlayerName(contatto.Icon);
				EndTextCommandScaleformString();
				EndScaleformMovieMethod();
				*/
            }
        }

        private void SetContactRow(Contact contatto)
        {
            Phone.Scaleform.CallFunction("SET_DATA_SLOT", 2, Phone.getCurrentCharPhone().Contacts.IndexOf(contatto), 0, contatto.Name, "", contatto.Icon);
            /*
			BeginScaleformMovieMethod(Phone.Scaleform.Handle, "SET_DATA_SLOT");
			ScaleformMovieMethodAddParamInt(2);
			ScaleformMovieMethodAddParamInt(Phone.getCurrentCharPhone().contatti.IndexOf(contatto));
			ScaleformMovieMethodAddParamInt(0);
			BeginTextCommandScaleformString("STRING");
			AddTextComponentSubstringPlayerName(contatto.Name);
			EndTextCommandScaleformString();
			BeginTextCommandScaleformString("CELL_999");
			EndTextCommandScaleformString();
			BeginTextCommandScaleformString("CELL_2000");
			AddTextComponentSubstringPlayerName(contatto.Icon);
			EndTextCommandScaleformString();
			EndScaleformMovieMethod();
			*/
        }

        public override void Initialize(Phone phone)
        {
            Phone = phone;
            FirstTick = true;
            SelectedItem = 0;
            CurrentSubMenu = null;
            rimosso = false;
            contactAmount = 0;
        }

        public override void Kill()
        {
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
