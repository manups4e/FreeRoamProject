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
    public enum BankTransactionType
    {
        Withdraw,
        Deposit,
        Receiving,
        Sending
    }

    public class CharData
    {
        public ulong CharID { get; set; }
        public bool Is_dead { get; set; }
        public Finance Finance { get; set; }
        public Position Position { get; set; }
        public Gang Gang { get; set; }
        public Skin Skin { get; set; }
        public List<Weapons> Weapons = new();
        public List<string> Properties = new(); // properties have their own data to be stored
        public List<OwnedVehicle> Vehicles = new();
        public Dressing Dressing { get; set; }
        public Statistics Statistics { get; set; }

    }

    public class Finance
    {
        public int Money { get; set; } = 1000;
        public int Bank { get; set; } = 3000;
        public List<BankTransaction> Transactions = new();

        public Finance() { }

        public Finance(int cash, int bank)
        {
            Money = cash;
            Bank = bank;
        }

    }
    public class BankTransaction
    {
        public BankTransactionType Type { get; set; }
        public long Amount { get; set; }
        [JsonIgnore] public DateTime Date { get; set; }
        public string Information { get; set; }

        [JsonProperty("Date")] public string _Date => Date.ToString("MM/dd/yyyy HH:mm:ss");
    }

    public class Weapons
    {
        public string Name { get; set; }
        public int Ammo { get; set; }
        public int Tint { get; set; }
        public List<Components> Components = new();
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
        public float[] Traits { get; set; } = new float[20] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

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
        public int[] Color { get; set; } = new int[2] { 0, 0 };

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
        public int[] Color { get; set; } = new int[2] { 0, 0 };
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
        public OwnedVehicle(string targa, string veh_data, string garage, string stato)
        {
            Plate = targa;
            VehData = veh_data.FromJson<VehicleData>(settings: JsonHelper.IgnoreJsonIgnoreAttributes);
            Garage = garage.FromJson<VehGarage>(settings: JsonHelper.IgnoreJsonIgnoreAttributes);
        }

        public OwnedVehicle(dynamic data)
        {
            Plate = data.targa;
            VehData = (data.vehicle_data as string).FromJson<VehicleData>(settings: JsonHelper.IgnoreJsonIgnoreAttributes);
            Garage = (data.garage as string).FromJson<VehGarage>(settings: JsonHelper.IgnoreJsonIgnoreAttributes);
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
}
