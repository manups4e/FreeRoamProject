using FreeRoamProject.Shared.Properties.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace FreeRoamProject.Shared.Core.Character
{
    public enum DrawableIndexes
    {
        Face = 0,
        Mask = 1,
        Hair = 2,
        Torso = 3,
        Pants = 4,
        Bag_Parachute = 5,
        Shoes = 6,
        Accessories = 7,
        Undershirt = 8,
        Kevlar = 9,
        Badge = 10,
        Torso_2 = 11,
    }

    public enum PropIndexes
    {
        Hats_Masks = 0,
        Glasses = 1,
        Ears = 2,
        Unk_3 = 3,
        Unk_4 = 4,
        Unk_5 = 5,
        Watches = 6,
        Bracelets = 7,
        Unk_8 = 8,
    }
    /// <summary>
    /// When selected an option "withSomeone", please specify also the other player's name
    /// </summary>
    public enum BankTransactionType
    {
        AdminAdd = -2,
        AdminRemove = -1,
        Withdraw,
        Deposit,
        DepositedBySomeone,
        CashSentToSomeone,
        VirtualCurrencyBought,
        MoneySpent,
        MoneyEarn,
    }

    public class Finance
    {
        public int Money { get; set; } = 1000;
        public int Bank { get; set; } = 3000;
        public List<BankTransaction> Transactions = [];

        public Finance() { }

        public Finance(int cash, int bank)
        {
            Money = cash;
            Bank = bank;
        }

    }
    public class BankTransaction
    {
        public bool Paid { get; set; }
        public long Amount { get; set; }
        public string Label { get; set; }
        public string PlayerName { get; set; }
        public DateTime TransactionDate { get; set; }
        public BankTransaction() { }
        public BankTransaction(bool paid, long amount, string label, string playerName = null)
        {
            Paid = paid;
            Amount = amount;
            Label = label;
            PlayerName = playerName;
            TransactionDate = DateTime.Now;
        }
    }

    public class PhoneData
    {
        public int Id { get; set; } = 1;
        public int Theme { get; set; } = 1;
        public int Wallpaper { get; set; } = 4;
        public int Ringtone { get; set; } = 0;
        public int SleepMode { get; set; } = 0;
        public int Vibration { get; set; } = 1;
        public int InviteSound { get; set; } = 1;
        public int QuickLaunch { get; set; } = 0;
        public List<Message> Messages = [];
        public List<Email> Emails = [];
        public List<Contact> Contacts =
        [
            new("CELL_165", "CELL_MP_329", false),
            //new("Assistant", assistant, false), player needs to choose the assistant sex //       "CELL_P_ASSIST": "Assistant", "CELL_P_ASSISTF": "Assistant",
            new("CELL_447", "CELL_MP_329", false),
            new("CELL_BRYONY_N", "CELL_BRYONY_P", false),
            new("CELL_YACHT", "CELL_YACHTPIC", false),
            new("CELL_114", "CELL_314", false),
            new("CELL_115", "CELL_315", false),
            new("CELL_150", "CELL_350", false),
            new("CELL_163", "CELL_394", false),
            new("CELL_131", "CELL_331", false),
            new("CELL_NCLUBE_N", "CELL_NCLUBE_PIC", false),
            new("CELL_FRANKLIN_N", "CELL_FRANKLIN_P", false),
            new("CELL_418", "CELL_318", false),
            new("CELL_E_228", "CELL_MP_349", false),
            new("CELL_IMANI_N", "CELL_IMANI_P", false),
            new("CELL_117", "CELL_317", false),
            new("CELL_112", "CELL_312", false),
            new("CELL_128", "CELL_328", false),
            new("CELL_NCLUBL_N", "CELL_NCLUBL_PIC", false),
            new("CELL_111", "CELL_311", false), // lester
            new("CELL_CH_BIK2", "CELL_BIK2_PIC", false),
            new("CELL_CH_BIK1", "CELL_BIK1_PIC", false),
            new("CELL_144", "CELL_344", false),
            new("CELL_180", "CELL_E_309", false),
            new("CELL_E_221", "CELL_MP_344", false),
            new("CELL_E_275", "CELL_MP_348", false),
            new("CELL_CAS_MAN_N", "CELL_CAS_MAN_P", false),
            new("CELL_413", "CELL_313", false),
            new("CELL_BBPAIGE_N", "CELL_BBPAIGE_P", false),
            new("CELL_PAVEL_N", "CELL_PAVEL_P", false),
            new("CELL_419", "CELL_319", false),
            new("CELL_E_247", "CELL_E_347", false),
            new("CELL_429", "CELL_329", false),
            new("CELL_416", "CELL_316", false),
            new("CELL_SES_N", "CELL_SES_P", false),
            new("CELL_427", "CELL_327", false),
            new("CELL_NCLUBT_N", "CELL_NCLUBT_PIC", false),
            new("CELL_WENDY_N", "CELL_WENDY_P", false),
            new("CELL_YOHAN_N", "CELL_YOHAN_P", false),
            new("CELL_CELEB_N", "CELL_CELEB_P", false)
        ];

        public PhoneData() { }

        internal string GetPlayerRingtoneString()
        {
            return Ringtone switch
            {
                1 or 2 or 3 => "PHONE_GENERIC_RING_0" + Ringtone,
                _ => "Silent Ringtone Dummy",
            };
        }
    }

    public enum DeliveryType
    {
        Received = 0,
        Sent
    }
    public enum MessageState
    {
        NONE = -1,
        UNREAD_EMAIL = 0,
        READ_EMAIL = 1,
        REPLIED_EMAIL = 2,
        UNREAD_SMS = 33,
        READ_SMS = 34
    }
    public class Message
    {
        public string From { get; set; }
        public string TxtMessage { get; set; }
        public DateTime Date { get; set; }
        public MessageState Read { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public string Mugshot { get; set; } = "CHAR_HUMANDEFAULT";

        public Message() { }
        public Message(string _from, string _message, DateTime _data, MessageState read, DeliveryType state)
        {
            this.From = _from;
            this.TxtMessage = _message;
            this.Date = _data;
            Read = read;
            DeliveryType = state;
        }
    }

    public class Email : Message
    {
        public string PictureTXD { get; set; }
        public string PictureTXN { get; set; }
        public string To { get; set; }
        public Email() { }
        public Email(string _from, string _to, string _message, DateTime _data, MessageState read, DeliveryType state, string pictureTXD = null, string pictureTXN = null)
            : base(_from, _message, _data, read, state)
        {
            To = _to;
            PictureTXD = pictureTXD;
            PictureTXN = pictureTXN;
        }
    }


    public class Contact
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public bool IsPlayer { get; set; }
        public int ServerID { get; set; }
        public Contact() { }
        public Contact(string name, string icon, bool isPlayer, int serverId = 0)
        {
            this.Name = name;
            this.Icon = icon;
            this.IsPlayer = isPlayer;
            this.ServerID = serverId;
        }
    }

    public class Weapons
    {
        public string Name { get; set; }
        public int Ammo { get; set; }
        public int Tint { get; set; }
        public List<Components> Components = [];
        public Weapons() { }
        public Weapons(string _name, int _ammo, dynamic data, int _tint)
        {
            this.Name = _name;
            this.Ammo = _ammo;
            this.Tint = _tint;
            if (data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    Components.Add(new Components(data[i]["name"].Value, (bool)data[i]["active"].Value));
                }
            }
        }

        public Weapons(string _name, int _ammo, List<Components> data, int _tint)
        {
            this.Name = _name;
            this.Ammo = _ammo;
            this.Tint = _tint;
            Components = data.ToList();
        }
    }

    public class Components
    {
        public string name { get; set; }
        public bool active { get; set; }
        public Components() { }
        public Components(string _name)
        {
            name = _name;
            active = false;
        }
        public Components(string _name, bool _ac)
        {
            this.name = _name;
            this.active = _ac;
        }
    }


    public class Tints
    {
        public string name { get; set; }
        public int value { get; set; }
        public Tints() { }
        public Tints(string _name, int _value)
        {
            this.name = _name;
            this.value = _value;
        }
    }

    public class Dressing
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ComponentDrawables ComponentDrawables { get; set; }
        public ComponentDrawables ComponentTextures { get; set; }
        public PropIndices PropIndices { get; set; }
        public PropIndices PropTextures { get; set; }

        public Dressing() { }
        public Dressing(string name, string description, ComponentDrawables ComponentDrawables, ComponentDrawables ComponentTextures, PropIndices PropIndices, PropIndices PropTextures)
        {
            this.Name = name;
            this.Description = description;
            this.ComponentDrawables = ComponentDrawables;
            this.ComponentTextures = ComponentTextures;
            this.PropIndices = PropIndices;
            this.PropTextures = PropTextures;
        }
    }


    public class ComponentDrawables
    {
        public int Face { get; set; }
        public int Mask { get; set; }
        public int Hair { get; set; }
        public int Torso { get; set; }
        public int Pants { get; set; }
        public int Bag_Parachute { get; set; }
        public int Shoes { get; set; }
        public int Accessories { get; set; }
        public int Undershirt { get; set; }
        public int Kevlar { get; set; }
        public int Badge { get; set; }
        public int Torso_2 { get; set; }
        public ComponentDrawables() { }
        public ComponentDrawables(int face, int mask, int hair, int torso, int pantaloni, int parachute_bag, int shoes, int accessory, int undershirt, int kevlar, int badge, int torso_2)
        {
            Face = face;
            Mask = mask;
            Hair = hair;
            Torso = torso;
            Pants = pantaloni;
            Bag_Parachute = parachute_bag;
            Shoes = shoes;
            Accessories = accessory;
            Undershirt = undershirt;
            Kevlar = kevlar;
            Badge = badge;
            Torso_2 = torso_2;
        }
    }


    public class PropIndices
    {
        public int Hats_masks { get; set; }
        public int Ears { get; set; }
        public int Glasses { get; set; }
        public int Unk_3 { get; set; }
        public int Unk_4 { get; set; }
        public int Unk_5 { get; set; }
        public int Watches { get; set; }
        public int Bracelets { get; set; }
        public int Unk_8 { get; set; }

        public PropIndices() { }
        public PropIndices(int cappelli_maschere, int orecchie, int occhiali_occhi, int unk_3, int unk_4, int unk_5, int orologi, int bracciali, int unk_8)
        {
            Hats_masks = cappelli_maschere;
            Ears = orecchie;
            Glasses = occhiali_occhi;
            Unk_3 = unk_3;
            Unk_4 = unk_4;
            Unk_5 = unk_5;
            Watches = orologi;
            Bracelets = bracciali;
            Unk_8 = unk_8;
        }
    }
    public class Statistics
    {
        public float STAMINA { get; set; }
        public float STRENGTH { get; set; }
        public float LUNG_CAPACITY { get; set; }
        public float SHOOTING_ABILITY { get; set; }
        public float WHEELIE_ABILITY { get; set; }
        public float FLYING_ABILITY { get; set; }
        public float DRUGS { get; set; }
        public float FISHING { get; set; }
        public float HUNTING { get; set; }
    }

    public class Gang
    {
        public string? Name { get; set; } = "Incensurato";
        public int Grade { get; set; } = 0;
        public Gang() { }
        public Gang(string name, int grade)
        {
            this.Name = name;
            this.Grade = grade;
        }
    }

    public class Skin
    {
        public string Sex { get; set; } = "Male";
        public uint Model { get; set; } = 1885233650u;
        public float Resemblance { get; set; } = 0.5f;
        public float Skinmix { get; set; } = 0.5f;
        public Face Face { get; set; }
        public A2 Ageing { get; set; }
        public A2 Makeup { get; set; }
        public A2 Blemishes { get; set; }
        public A2 Complexion { get; set; }
        public A2 SkinDamage { get; set; }
        public A2 Freckles { get; set; }
        public A3 Lipstick { get; set; }
        public A3 Blusher { get; set; }
        public Facial FacialHair { get; set; }
        public Hair Hair { get; set; }
        public Eye Eye { get; set; }
        public Ears Ears { get; set; }

        public Skin() { }
        public Skin(string sex, uint model, float resemblance, float skinmix, Face face, A2 ageing, A2 makeup, A2 blemishes, A2 complexion, A2 skinDamage, A2 freckles, A3 lipstick, A3 blusher, Facial facialHair, Hair hair, Eye eye, Ears ears)
        {
            this.Sex = sex;
            this.Model = model;
            this.Resemblance = resemblance;
            this.Skinmix = skinmix;
            this.Face = face;
            this.Ageing = ageing;
            this.Makeup = makeup;
            this.Blemishes = blemishes;
            this.Complexion = complexion;
            this.SkinDamage = skinDamage;
            this.Freckles = freckles;
            this.Lipstick = lipstick;
            this.Blusher = blusher;
            this.FacialHair = facialHair;
            this.Hair = hair;
            this.Eye = eye;
            this.Ears = ears;
        }

    }


    public class Face
    {
        public int Mom { get; set; } = 0;
        public int Dad { get; set; } = 0;
        public float[] Traits { get; set; } = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

        public Face() { }
        public Face(int mom, int dad, float[] tratti)
        {
            this.Mom = mom;
            this.Dad = dad;
            this.Traits = tratti;
        }
    }


    public class A2
    {
        public int Style { get; set; }
        public float Opacity { get; set; }

        public A2() { }
        public A2(int style, float opacity)
        {
            this.Style = style;
            this.Opacity = opacity;
        }
    }


    public class Facial
    {
        public A3 Beard { get; set; } = new();
        public A3 Eyebrow { get; set; } = new();

        public Facial() { }
        public Facial(A3 beard, A3 eyebrow)
        {
            this.Beard = beard;
            this.Eyebrow = eyebrow;
        }
    }


    public class A3
    {
        public int Style { get; set; } = 0;
        public float Opacity { get; set; } = 0f;
        public int[] Color { get; set; } = [0, 0];

        public A3() { }
        public A3(int style, float opacity, int[] color)
        {
            this.Style = style;
            this.Opacity = opacity;
            this.Color = color;
        }
    }


    public class Hair
    {
        public int Style { get; set; } = 0;
        public int[] Color { get; set; } = [0, 0];
        public Hair() { }
        public Hair(int style, int[] color)
        {
            this.Style = style;
            this.Color = color;
        }
    }


    public class Eye
    {
        public int Style { get; set; }
        public Eye() { }
        public Eye(int style)
        {
            this.Style = style;
        }
    }


    public class Ears
    {
        public int Style { get; set; }
        public int Color { get; set; }
        public Ears() { }
        public Ears(int style, int color)
        {
            this.Style = style;
            this.Color = color;
        }
    }


    public class OwnedVehicle
    {

        [JsonIgnore]
        internal Vehicle Vehicle = null;
        public string? Plate { get; set; }
        public VehicleData VehData { get; set; }
        public VehGarage Garage { get; set; }


        public OwnedVehicle() { }
        public OwnedVehicle(Vehicle veh, string targa, VehicleData data, VehGarage garage, string stato)
        {
            Vehicle = veh;
            Plate = targa;
            VehData = data;
            Garage = garage;
        }
        public OwnedVehicle(string targa, VehicleData data, VehGarage garage, string stato)
        {
            Plate = targa;
            VehData = data;
            Garage = garage;
        }
    }


    public class VehGarage
    {
        public bool InGarage { get; set; }
        public string? ID { get; set; }
        public int Place { get; set; }
        public VehGarage() { }
        public VehGarage(bool ingarage, string garageName, int posto)
        {
            InGarage = ingarage;
            ID = garageName;
            Place = posto;
        }
        public VehGarage(dynamic data)
        {
            InGarage = data.ingarage;
            ID = data.garageName;
            Place = data.posto;
        }
    }

    public class VehicleData
    {
        public VehProp Props = new();
        public bool HasInsurance { get; set; }
        public VehicleData() { }
        public VehicleData(VehProp dati)
        {
            Props = dati;
        }
    }

    public class VehProp
    {
        public int Model { get; set; }
        public string? Name { get; set; }
        public string? Plate { get; set; }
        public int PlateIndex { get; set; }
        public float DirtLevel { get; set; }
        public int PrimaryColor { get; set; }
        public int SecondaryColor { get; set; }
        public Color CustomPrimaryColor { get; set; }
        public Color CustomSecondaryColor { get; set; }
        public bool HasCustomPrimaryColor { get; set; }
        public bool HasCustomSecondaryColor { get; set; }
        public int PearlescentColor { get; set; }
        public int WheelColor { get; set; }
        public int Wheels { get; set; }
        public int WindowTint { get; set; }
        public bool[] NeonEnabled = new bool[4];
        public bool[] Extras = new bool[13];
        public Color NeonColor { get; set; }
        public Color TireSmokeColor { get; set; }
        public List<VehMod> Mods { get; set; }
        public bool ModKitInstalled { get; set; }
        public int ModLivery { get; set; }
        public VehProp() { }
        public VehProp(int model, string? name, string? plate, int plateIndex, float bodyHealth, float engineHealth, float fuelLevel, float dirtLevel, int color1, int color2, Color custom1, Color custom2, bool hasCustom1, bool hasCustom2, int pearlescentColor, int wheelColor, int wheels, int windowTint, bool[] neonEnabled, bool[] extras, Color neonColor, Color tyreSmokeColor, bool modkit, List<VehMod> mods, int modLivery)
        {
            Model = model;
            Name = name;
            Plate = plate;
            PlateIndex = plateIndex;
            DirtLevel = dirtLevel;
            PrimaryColor = color1; SecondaryColor = color2;
            CustomPrimaryColor = custom1; CustomSecondaryColor = custom2;
            HasCustomPrimaryColor = hasCustom1; HasCustomSecondaryColor = hasCustom2;
            PearlescentColor = pearlescentColor; WheelColor = wheelColor;
            Wheels = wheels;
            WindowTint = windowTint;
            NeonEnabled = neonEnabled;
            Extras = extras;
            NeonColor = neonColor;
            TireSmokeColor = tyreSmokeColor;
            ModKitInstalled = modkit;
            Mods = mods;
            ModLivery = modLivery;
        }
    }

    public class VehMod
    {
        public int ModIndex { get; set; }
        public int Value { get; set; }
        public string ModName { get; set; }
        public string ModType { get; set; }

        public VehMod(int modIndex, int value, string name, string type)
        {
            ModIndex = modIndex;
            Value = value;
            ModName = name;
            ModType = type;
        }
    }

    public class OwnedProperty
    {
        public int ID { get; set; }
        public int InteriorOption { get; set; } = -1;
        public int TintOption { get; set; } = -1;
        public OwnedPropertyGarage Garage = new();
    }

    public class OwnedPropertyGarage
    {
        public GarageSize GarageSize { get; set; }
        public int[] VehicleInSlot { get; set; }
        public int[] VehicleStateSlot { get; set; }
    }
}
