using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace FreeRoamProject.Client.Core.Utility
{
    public enum ShopCharacterType
    {
        Michael,
        Franklin,
        Trevor,
        MPMale,
        MPFemale,
    }
    public static class ShopPed
    {
        [StructLayout(LayoutKind.Explicit, Size = 0x88)]
        private unsafe struct UnsafePedComponentData
        {
            [FieldOffset(0x00)] private int lockHash;

            [FieldOffset(0x08)] private int hash; // componentHash

            [FieldOffset(0x10)] private int locate;

            [FieldOffset(0x18)] private int drawable;

            [FieldOffset(0x20)] private int texture;

            [FieldOffset(0x28)] private int f_5; // price

            [FieldOffset(0x30)] private int componentType;

            [FieldOffset(0x38)] private int f_7;

            [FieldOffset(0x40)] private int f_8;

            [FieldOffset(0x48)] private unsafe fixed sbyte gxt[0x40];

            public PedComponentData GetData()
            {
                /*string label;
				fixed (sbyte* ptr = gxt)
				{
						label = new string(ptr);
				}
				return new PedComponentData(lockHash, hash, locate, drawable, texture, f_5, componentType, f_7, f_8, label);*/
                string label;
                fixed (sbyte* ptr = gxt)
                {
                    byte[] bytes = new byte[64];
                    int index = 0;
                    for (sbyte* counter = ptr; *counter != 0; counter++)
                    {
                        bytes[index++] = (byte)*counter;
                    }
                    label = System.Text.Encoding.UTF8.GetString(bytes, 0, index);
                }
                return new PedComponentData(lockHash, hash, locate, drawable, texture, f_5, componentType, f_7, f_8, label);
            }

        }

        [StructLayout(LayoutKind.Explicit, Size = 0x78)]
        private unsafe struct UnsafePedOutfitData
        {
            [FieldOffset(0x00)] private int lockHash;

            [FieldOffset(0x08)] private int hash; // componentHash

            [FieldOffset(0x10)] private int price;

            [FieldOffset(0x18)] private int unk1;

            [FieldOffset(0x20)] private int totalItems;

            [FieldOffset(0x28)] private int unk2; // price

            [FieldOffset(0x30)] private int unk3;

            [FieldOffset(0x38)] private unsafe fixed sbyte gxt[0x40];

            public PedOutfitData GetData()
            {
                /*string label;
				fixed (sbyte* ptr = gxt)
				{
						label = new string(ptr);
				}
				return new PedOutfitData(lockHash, hash, price, unk1, totalItems, unk2, unk3, label);*/
                string label;
                fixed (sbyte* ptr = gxt)
                {
                    byte[] bytes = new byte[64];
                    int index = 0;
                    for (sbyte* counter = ptr; *counter != 0; counter++)
                    {
                        bytes[index++] = (byte)*counter;
                    }
                    label = System.Text.Encoding.UTF8.GetString(bytes, 0, index);
                }
                return new PedOutfitData(lockHash, hash, price, unk1, totalItems, unk2, unk3, label);
            }

        }
        public class PedOutfitData
        {
            //for prop:	0			0	Price:-449919479	0	Unk1:99 0	Unk1:1	0	TotalItems:6	0	Unk2:0	0	unk3:3	0	f7:1599032387 // 0xB7952076E444979D
            //for sa:	lock:-2014967816	0	hash:21067119		0	price:99	0	Unk1:1	0	TotalItems:6	0	Unk2:0	0	unk3:3	0	f7:1599032387 //0x6D793F03A631FE56
            //for sac:	lock:-2014967816	0	hash:21067119		0	price:99	0	Unk1:1	0	TotalItems:6	0	unk2:0	0	unk3:3	0	f7:1599032387
            //GET_SHOP_PED_QUERY_OUTFIT
            //self = lockHash ? CU_HEIST3_CLOTHES/CU_HEIST3_MASKS/CU_VINEWOOD_CLOTHES...
            //f1 = hash? DLC_MP_VWD_M_BERD_0_0/DLC_MP_VWD_M_TORSO_0_0/DLC_MP_VWD_M_LEGS_0_0...
            // f2= prix
            //f3= int
            //f4= totalItem(count)
            // f7= label
            public int LockHash { get; }
            public int Hash { get; } //1
            public int Price { get; }//2
            public int TotalProps { get; }//3
            public int TotalComponents { get; } //4
            public int Unk2 { get; } //5
            public int Unk3 { get; } //6
            public string Label { get; } //7

            public PedOutfitData() { }
            public PedOutfitData(int lockHash, int hash, int price, int unk1, int totalItems, int unk2, int unk3, string label)
            {
                LockHash = lockHash;
                Hash = hash;
                Price = price;
                TotalProps = unk1;
                TotalComponents = totalItems;
                Unk2 = unk2;
                Unk3 = unk3;
                Label = label;
            }

            public PedOutfitData(dynamic obj)
            {
                LockHash = Convert.ToInt32(obj.LockHash);
                Hash = Convert.ToInt32(obj.Hash);
                Price = obj.Price;
                TotalProps = obj.TotalProps;
                TotalComponents = obj.TotalComponents;
                Unk2 = obj.Unk2;
                Unk3 = obj.Unk3;
                Label = obj.Label;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class PedComponentData
        {
            public int LockHash { get; }
            public int Hash { get; }
            public int Locate { get; } // f2
            public int Drawable { get; } // 3
            public int Texture { get; } //4
            public int Price { get; } // f5 = price
            public int ComponentType { get; }
            public int f_7 { get; }
            public int f_8 { get; }
            public string Label { get; } // f9

            public PedComponentData() { }
            public PedComponentData(int lockHash, int hash, int locate, int drawable, int texture, int f_5, int componentType, int f_7, int f_8, string label)
            {
                this.LockHash = lockHash;
                this.Hash = hash;
                this.Locate = locate;
                this.Drawable = drawable;
                this.Texture = texture;
                this.Price = f_5;
                this.ComponentType = componentType;
                this.f_7 = f_7;
                this.f_8 = f_8;
                this.Label = label;
            }

            public PedComponentData(dynamic obj)
            {
                LockHash = Convert.ToInt32(obj.LockHash);
                Hash = Convert.ToInt32(obj.Hash);
                Locate = obj.Locate;
                Drawable = obj.Drawable;
                Texture = obj.Texture;
                Price = obj.Price;
                ComponentType = obj.ComponentType;
                f_7 = obj.f_7;
                f_8 = obj.f_8;
                Label = obj.Label;
            }
        }

        //Global_4267002[Global_4267254] 
        //Global_4267368 = current category? check line 157959
        private static PedComponentData _GetShopPedComponent(uint componentHash)
        {
            UnsafePedComponentData data;
            unsafe
            {
                CitizenFX.Core.Native.Function.Call(CitizenFX.Core.Native.Hash.GET_SHOP_PED_COMPONENT, componentHash, new IntPtr(&data).ToInt64());
            }
            return data.GetData();
        }
        // equivaut à GetShopData de TestStruct
        public static PedComponentData GetShopPedComponent(uint componentHash)
        {
            //return _GetShopPedComponent(componentHash);
            dynamic obj = ClientMain.Instance.GetExports["frp"].GetShopPedComponent(componentHash);
            PedComponentData data = new(obj);
            return data;
        }
        private static PedComponentData _GetShopPedProp(uint propHash)
        {
            UnsafePedComponentData data;
            unsafe
            {
                CitizenFX.Core.Native.Function.Call(CitizenFX.Core.Native.Hash.GET_SHOP_PED_PROP, propHash, new IntPtr(&data).ToInt64());
            }
            return data.GetData();
        }


        // equivaut à GetShopPedProp de TestStruct
        public static PedComponentData GetShopPedProp(uint propHash)
        {
            //return _GetShopPedProp(propHash);
            string json = ClientMain.Instance.GetExports["frp"].GetShopPedProp(propHash);
            PedComponentData data = json.FromJson<PedComponentData>();
            return data;
        }

        #region Query components
        private static PedComponentData _GetShopPedQueryComponent(int componentId, int componentType, ShopCharacterType characterType)
        {
            UnsafePedComponentData data;
            long ptr;
            unsafe
            {
                ptr = new IntPtr(&data).ToInt64();
                CitizenFX.Core.Native.Function.Call(CitizenFX.Core.Native.Hash.INIT_SHOP_PED_COMPONENT, ptr);
            }

            int max = CitizenFX.Core.Native.Function.Call<int>(CitizenFX.Core.Native.Hash.SETUP_SHOP_PED_APPAREL_QUERY_TU, (int)characterType, 0, -1, 0/*0=component/1=props*/, -1, componentType);

            if (componentId > max)
                return new PedComponentData();

            unsafe
            {
                //ptr = new IntPtr(&data).ToInt32();
                CitizenFX.Core.Native.Function.Call(CitizenFX.Core.Native.Hash.GET_SHOP_PED_QUERY_COMPONENT, componentId, ptr);
            }
            return data.GetData();
        }
        private static PedComponentData[] _GetShopPedQueryComponents(int componentType, ShopCharacterType characterType, int locate = -1)
        {
            UnsafePedComponentData data;
            long ptr;
            unsafe
            {
                ptr = new IntPtr(&data).ToInt64();
                CitizenFX.Core.Native.Function.Call(CitizenFX.Core.Native.Hash.INIT_SHOP_PED_COMPONENT, ptr);
            }

            int max = CitizenFX.Core.Native.Function.Call<int>(CitizenFX.Core.Native.Hash.SETUP_SHOP_PED_APPAREL_QUERY_TU, (int)characterType, 0, locate, 0/*0=component/1=props*/, -1/*propreleated?*/, componentType);

            if (max == 0)
                return null;
            PedComponentData[] items = new PedComponentData[max];
            unsafe
            {
                for (int i = 0; i < max; i++)
                {
                    CitizenFX.Core.Native.Function.Call(CitizenFX.Core.Native.Hash.GET_SHOP_PED_QUERY_COMPONENT, i, ptr);
                    items[i] = data.GetData();
                }
            }
            return items;
        }
        private static int _QueryGetComponentIndex(uint nameHash, ShopCharacterType characterType, int componentType)
        {
            UnsafePedComponentData data;
            long ptr;
            unsafe
            {
                ptr = new IntPtr(&data).ToInt64();
                CitizenFX.Core.Native.Function.Call(CitizenFX.Core.Native.Hash.INIT_SHOP_PED_COMPONENT, ptr);
            }
            int max = CitizenFX.Core.Native.Function.Call<int>(CitizenFX.Core.Native.Hash.SETUP_SHOP_PED_APPAREL_QUERY_TU, (int)characterType, 0, -1, 0/*0=component/1=props*/, -1, componentType);
            if (max <= 0)
                return -1;

            PedComponentData safe;
            for (int i = 0; i < max; i++)
            {
                unsafe
                {
                    CitizenFX.Core.Native.Function.Call(CitizenFX.Core.Native.Hash.GET_SHOP_PED_QUERY_COMPONENT, i, ptr);
                    safe = data.GetData();
                }
                if ((uint)safe.Hash == nameHash)
                {
                    return i;
                }
            }

            return -1;
        }

        public static PedComponentData GetShopPedQueryComponent(int componentId, int componentType, ShopCharacterType characterType)
        {
            //return _GetShopPedQueryComponent(componentId, componentType, (int)characterType);
            dynamic obj = ClientMain.Instance.GetExports["frp"].GetShopPedQueryComponent(componentId, componentType, (int)characterType);
            PedComponentData data = new(obj);
            return data;
        }
        public static PedComponentData[] GetShopPedQueryComponents(int componentType, ShopCharacterType characterType, int locate = -1)
        {
            //return _GetShopPedQueryComponents(componentType, (int)characterType, locate);
            List<PedComponentData> comps = new();
            dynamic obj = ClientMain.Instance.GetExports["frp"].GetShopPedQueryComponents(componentType, (int)characterType, locate);
            foreach (dynamic o in obj) comps.Add(new(o));
            return comps.ToArray();
        }
        public static int QueryGetComponentIndex(uint nameHash, ShopCharacterType characterType, int componentType)
        {
            //return _QueryGetComponentIndex(nameHash, (int)characterType, componentType);
            int idx = ClientMain.Instance.GetExports["frp"].QueryGetComponentIndex(nameHash, (int)characterType, componentType);
            return idx;
        }
        #endregion

        #region Query Props
        private static PedComponentData _GetShopPedQueryProp(int propId, ShopCharacterType characterType)
        {
            UnsafePedComponentData data;
            long ptr;
            unsafe
            {
                ptr = new IntPtr(&data).ToInt64();
                CitizenFX.Core.Native.Function.Call(CitizenFX.Core.Native.Hash.INIT_SHOP_PED_PROP, ptr);
            }
            int max = CitizenFX.Core.Native.Function.Call<int>(CitizenFX.Core.Native.Hash.SETUP_SHOP_PED_APPAREL_QUERY_TU, (int)characterType, 0, -1, 1/*0=component/1=props*/, -1, -1);
            if (propId > max)
                return new PedComponentData();

            unsafe
            {
                CitizenFX.Core.Native.Function.Call(CitizenFX.Core.Native.Hash.GET_SHOP_PED_QUERY_PROP, propId, ptr);
            }
            return data.GetData();
        }
        private static PedComponentData[] _GetShopPedQueryProps(ShopCharacterType characterType)
        {

            UnsafePedComponentData data;
            long ptr;
            unsafe
            {
                ptr = new IntPtr(&data).ToInt64();
                CitizenFX.Core.Native.Function.Call(CitizenFX.Core.Native.Hash.INIT_SHOP_PED_PROP, ptr);
            }
            int max = CitizenFX.Core.Native.Function.Call<int>(CitizenFX.Core.Native.Hash.SETUP_SHOP_PED_APPAREL_QUERY_TU, (int)characterType, 0, -1, 1, -1, -1);
            if (max == 0)
                return null;
            PedComponentData[] items = new PedComponentData[max];
            unsafe
            {
                for (int i = 0; i < max; i++)
                {
                    CitizenFX.Core.Native.Function.Call(CitizenFX.Core.Native.Hash.GET_SHOP_PED_QUERY_PROP, i, ptr);
                    items[i] = data.GetData();
                }
            }
            return items;
        }
        private static int _QueryGetPropIndex(uint nameHash, ShopCharacterType characterType)
        {
            UnsafePedComponentData data;
            long ptr;
            unsafe
            {
                ptr = new IntPtr(&data).ToInt64();
                CitizenFX.Core.Native.Function.Call(CitizenFX.Core.Native.Hash.INIT_SHOP_PED_PROP, ptr);
            }
            int max = CitizenFX.Core.Native.Function.Call<int>(CitizenFX.Core.Native.Hash.SETUP_SHOP_PED_APPAREL_QUERY_TU, (int)characterType, 0, -1, 1/*0=component/1=props*/, -1, -1);
            if (max <= 0)
                return -1;

            PedComponentData safe;
            for (int i = 0; i < max; i++)
            {
                unsafe
                {
                    CitizenFX.Core.Native.Function.Call(CitizenFX.Core.Native.Hash.GET_SHOP_PED_QUERY_PROP, i, ptr);
                    safe = data.GetData();
                }
                if ((uint)safe.Hash == nameHash)
                {
                    return i;
                }
            }

            return -1;
        }
        public static PedComponentData GetShopPedQueryProp(int propId, ShopCharacterType characterType)
        {
            //return _GetShopPedQueryProp(propId, (int)characterType);
            dynamic obj = ClientMain.Instance.GetExports["frp"].GetShopPedQueryProp(propId, (int)characterType);
            PedComponentData data = new(obj);
            return data;
        }

        public static PedComponentData[] GetShopPedQueryProps(ShopCharacterType characterType)
        {
            //return _GetShopPedQueryProps((int)characterType);
            List<PedComponentData> comps = new();
            dynamic obj = ClientMain.Instance.GetExports["frp"].GetShopPedQueryProps((int)characterType);
            foreach (dynamic o in obj) comps.Add(new(o));
            return comps.ToArray();
        }
        public static int QueryGetPropIndex(uint nameHash, ShopCharacterType characterType)
        {
            //return _QueryGetPropIndex(nameHash, (int)characterType);
            int idx = ClientMain.Instance.GetExports["frp"].QueryGetPropIndex(nameHash, (int)characterType);
            return idx;
        }
        #endregion

        private static PedOutfitData _GetShopPedQueryOutfit(int outfitId, ShopCharacterType characterType)
        {
            UnsafePedOutfitData data;
            int max = CitizenFX.Core.Native.API.N_0xf3fbe2d50a6a8c28((int)characterType, false);
            if (outfitId > max)
                return new PedOutfitData();

            unsafe
            {
                CitizenFX.Core.Native.Function.Call(CitizenFX.Core.Native.Hash.GET_SHOP_PED_QUERY_OUTFIT, outfitId, new IntPtr(&data).ToInt64());
            }
            return data.GetData();
        }
        private static PedOutfitData[] _GetShopPedQueryOutfits(ShopCharacterType characterType)
        {
            UnsafePedOutfitData data;
            int max = CitizenFX.Core.Native.API.N_0xf3fbe2d50a6a8c28((int)characterType, false);

            if (max == 0)
                return null;
            PedOutfitData[] items = new PedOutfitData[max];
            unsafe
            {
                long ptr = new IntPtr(&data).ToInt64();
                for (int i = 0; i < max; i++)
                {
                    CitizenFX.Core.Native.Function.Call(CitizenFX.Core.Native.Hash.GET_SHOP_PED_QUERY_OUTFIT, i, ptr);
                    items[i] = data.GetData();
                }
            }
            return items;
        }
        public static PedOutfitData GetShopPedQueryOutfit(int outfitId, ShopCharacterType characterType)
        {
            //return _GetShopPedQueryOutfit(outfitId, (int)characterType);
            string json = ClientMain.Instance.GetExports["frp"].GetShopPedQueryOutfit(outfitId, (int)characterType);
            PedOutfitData data = new(json);
            return data;
        }
        public static PedOutfitData[] GetShopPedQueryOutfits(ShopCharacterType characterType)
        {
            //return _GetShopPedQueryOutfits((int)characterType);
            List<object> obj = ClientMain.Instance.GetExports["frp"].GetShopPedQueryOutfits((int)characterType);
            PedOutfitData[] result = new PedOutfitData[obj.Count];
            for (int i = 0; i < obj.Count; i++)
            {
                dynamic o = obj[i];
                result[i] = new PedOutfitData((int)o.LockHash, (int)o.Hash, (int)o.Price, (int)o.TotalProps, (int)o.TotalComponents, (int)o.Unk2, (int)o.Unk3, (string)o.Label);
            }
            return result;
        }

        // -------

        private static PedOutfitData _GetShopPedOutfit(uint outfitHash)
        {
            UnsafePedOutfitData data;
            unsafe
            {
                CitizenFX.Core.Native.Function.Call(CitizenFX.Core.Native.Hash.GET_SHOP_PED_OUTFIT, outfitHash, new IntPtr(&data).ToInt64());
            }
            return data.GetData();
        }
        public static PedOutfitData GetShopPedOutfit(uint outfitHash)
        {
            //return _GetShopPedOutfit(outfitHash);
            string json = ClientMain.Instance.GetExports["frp"].GetShopPedOutfit(outfitHash);
            PedOutfitData data = json.FromJson<PedOutfitData>();
            return data;
        }

        // -------

        //GET_SHOP_PED_OUTFIT_COMPONENT_VARIANT
        [StructLayout(LayoutKind.Explicit, Size = 0x10)]
        private unsafe struct UnsafePedOutfitComponentVariantData
        {
            [FieldOffset(0x00)] private int hash;

            [FieldOffset(0x08)] private int enumValue;

            [FieldOffset(0x10)] private int componentType;

            public PedOutfitComponentVariantData GetData()
            {

                return new PedOutfitComponentVariantData(hash, enumValue, componentType);
            }

        }
        public struct PedOutfitComponentVariantData
        {
            public int Hash; // x
            public int EnumValue; //y
            public int ComponentType; //z

            public PedOutfitComponentVariantData(int hash, int enumValue, int componentType)
            {
                Hash = hash;
                EnumValue = enumValue;
                ComponentType = componentType;
            }
        }

        private static PedOutfitComponentVariantData _GetShopPedOutfitComponentVariant(int componentHash, int slot)
        {
            UnsafePedOutfitComponentVariantData data;
            unsafe
            {
                CitizenFX.Core.Native.Function.Call(CitizenFX.Core.Native.Hash.GET_SHOP_PED_OUTFIT_COMPONENT_VARIANT, componentHash, slot, new IntPtr(&data).ToInt64());
            }
            return data.GetData();
        }
        public static PedOutfitComponentVariantData GetShopPedOutfitComponentVariant(int componentHash, int slot)
        {
            //return _GetShopPedOutfitComponentVariant(componentHash, slot);
            string json = ClientMain.Instance.GetExports["frp"].GetShopPedOutfitComponentVariant(componentHash, slot);
            PedOutfitComponentVariantData data = json.FromJson<PedOutfitComponentVariantData>();
            return data;
        }

        //----
        private static PedOutfitComponentVariantData _GetShopPedOutfitPropVariant(int componentHash, int slot)
        {
            UnsafePedOutfitComponentVariantData data;
            unsafe
            {
                CitizenFX.Core.Native.Function.Call(CitizenFX.Core.Native.Hash.GET_SHOP_PED_OUTFIT_PROP_VARIANT, componentHash, slot, new IntPtr(&data).ToInt64());
            }
            return data.GetData();
        }
        public static PedOutfitComponentVariantData GetShopPedOutfitPropVariant(int componentHash, int slot)
        {
            //return _GetShopPedOutfitPropVariant(componentHash, slot);
            string json = ClientMain.Instance.GetExports["frp"].GetShopPedOutfitComponentVariant(componentHash, slot);
            PedOutfitComponentVariantData data = json.FromJson<PedOutfitComponentVariantData>();
            return data;
        }

        //public static string GetItemCategoryLabel(string sParam0, bool bParam1)
        //{
        //	int iVar0;
        //	int iVar1;

        //	if (string.IsNullOrEmpty(sParam0) || sParam0 == "NULL")
        //	{
        //		return "";
        //	}
        //	if (sParam0.Length < 6)
        //	{
        //		return "";
        //	}
        //	iVar0 = CitizenFX.Core.Native.API.GetHashKey(sParam0);
        //	iVar1 = CitizenFX.Core.Native.API.GetHashKey(sParam0.Substring(0, 6));
        //	switch (iVar1)
        //	{
        //		case -272077744:
        //		case -217636000:
        //			return "SHOP_CONTENT_1";
        //			break;

        //		case -291739204:
        //		case -1724452987:
        //			return "SHOP_CONTENT_2";
        //			break;

        //		case -680965302:
        //		case 436097115:
        //		case 927511879:
        //			if (!bParam1)
        //			{
        //				return "SHOP_CONTENT_3";
        //			}
        //			else
        //			{
        //				return "SHOP_CONTENT_3b";
        //			}
        //			break;

        //		case -1376583914:
        //			return "SHOP_CONTENT_4";
        //			break;

        //		case 753969907:
        //			return "SHOP_CONTENT_5";
        //			break;

        //		case -1461214493:
        //		case 469261390:
        //		case 1454369070:
        //			if (!bParam1)
        //			{
        //				return "SHOP_CONTENT_6";
        //			}
        //			else
        //			{
        //				return "SHOP_CONTENT_6b";
        //			}
        //			break;

        //		case -1497129317:
        //			if (!bParam1)
        //			{
        //				return "SHOP_CONTENT_7";
        //			}
        //			else
        //			{
        //				return "SHOP_CONTENT_7b";
        //			}
        //			break;

        //		case 2070857446:
        //			if (!bParam1)
        //			{
        //				return "SHOP_CONTENT_8";
        //			}
        //			else
        //			{
        //				return "SHOP_CONTENT_8b";
        //			}
        //			break;

        //		case 790660019:
        //			return "SHOP_CONTENT_9";
        //			break;

        //		case -1899372144:
        //			if (!bParam1)
        //			{
        //				return "SHOP_CONTENT_10";
        //			}
        //			else
        //			{
        //				return "SHOP_CONTENT_10b";
        //			}
        //			break;

        //		case 2009248638:
        //		case -434342601:
        //			if (((((iVar0 == -1357324997 || iVar0 == 64652989) || iVar0 == 1023408391) || iVar0 == 513852309) || iVar0 == 799565220) || iVar0 == -1823527696)
        //			{
        //				return "SHOP_CONTENT_14";
        //			}
        //			return "SHOP_CONTENT_12";
        //			break;

        //		case 1759048931:
        //			switch (iVar0)
        //			{
        //				case -1351684992:
        //				case -1657386993:
        //				case -1946409573:
        //				case -170362538:
        //				case -726555483:
        //				case -372257055:
        //				case -114397794:
        //				case -1749374280:
        //					return "";
        //					break;
        //			}
        //			return "SHOP_CONTENT_13";
        //			break;

        //		case 1974808259:
        //		case -1053480147:
        //			return "SHOP_CONTENT_14";
        //			break;

        //		case -2115296325:
        //		case -1917727053:
        //			return "SHOP_CONTENT_15";
        //			break;

        //		case -1647080257:
        //		case -1635032722:
        //			return "SHOP_CONTENT_16";
        //			break;

        //		case -32105449:
        //		case -723723000:
        //			return "SHOP_CONTENT_17";
        //			break;

        //		case 1310830821:
        //		case -2080815574:
        //			return "SHOP_CONTENT_18";
        //			break;

        //		case 1264005900:
        //		case -2124002991:
        //			if (iVar0 == -273286091 || iVar0 == 1363073245)
        //			{
        //				return "";
        //			}
        //			return "SHOP_CONTENT_19";
        //			break;

        //		case -845498475:
        //			return "SHOP_CONTENT_26";
        //			break;

        //		case 1585373207:
        //			return "SHOP_CONTENT_21";
        //			break;

        //		case -2100506294:
        //			return "SHOP_CONTENT_22";
        //			break;

        //		case 982652206:
        //		case 1960353061:
        //			return "SHOP_CONTENT_23";
        //			break;

        //		case 911341914:
        //		case -1177833238:
        //			return "SHOP_CONTENT_24";
        //			break;

        //		case -33829882:
        //		case -2114785687:
        //			return "SHOP_CONTENT_25";
        //			break;

        //		case 967837046:
        //		case 1713900776:
        //			return "SHOP_CONTENT_27";
        //			break;

        //		case -1236923236:
        //		case -374634807:
        //			return "SHOP_CONTENT_28";
        //			break;

        //		case 495538029:
        //		case 1755484029:
        //			return "SHOP_CONTENT_29";
        //			break;

        //		case 843134448:
        //		case 1237563348:
        //			return "SHOP_CONTENT_30";
        //			break;

        //		case 817135047:
        //		case -1866897369:
        //			return "SHOP_CONTENT_31";
        //			break;

        //		case 751562226:
        //			return "SHOP_CONTENT_32";
        //			break;

        //		case 1068076045:
        //		case -1417079707:
        //			if (!bParam1)
        //			{
        //				return "SHOP_CONTENT_33";
        //			}
        //			else
        //			{
        //				return "SHOP_CONTENT_33";
        //			}
        //			break;

        //		case 1976270828:
        //		case 1024899158:
        //			if (iVar0 == -2071198975)
        //			{
        //				return "";
        //			}
        //			if (((iVar0 == 1168285768 || iVar0 == 932073242) || iVar0 == 495988257) || iVar0 == -1968412186)
        //			{
        //				return "";
        //			}
        //			return "SHOP_CONTENT_34";
        //			break;

        //		case -1043587080:
        //		case 1556381710:
        //			return "SHOP_CONTENT_35";
        //			break;

        //		case -1453558291:
        //		case 2000920079:
        //			return "SHOP_CONTENT_38";
        //			break;

        //		case 217574226:
        //		case -1750609005:
        //			return "SHOP_CONTENT_39";
        //			break;
        //	}
        //	if (sParam0 == "CC_M_HS_16" || sParam0 == "CC_M_HS_17" || sParam0 == "CC_F_HS_17" || sParam0 == "CC_F_HS_16")
        //	{
        //		return "SHOP_CONTENT_1";
        //	}
        //	else if (sParam0 == "CC_M_HS_18" || sParam0 == "CC_M_HS_19" || sParam0 == "CC_F_HS_18" || sParam0 == "CC_F_HS_19")
        //	{
        //		return "SHOP_CONTENT_2";
        //	}
        //	else if (sParam0 == "CC_F_HS_23")
        //	{
        //		return "SHOP_CONTENT_4";
        //	}
        //	else if ( sParam0 == "CC_M_HS_20" || sParam0 == "CC_M_HS_21" || sParam0 == "CC_F_HS_20" || sParam0 == "CC_F_HS_21")
        //	{
        //		if (!bParam1)
        //		{
        //			return "SHOP_CONTENT_6";
        //		}
        //		else
        //		{
        //			return "SHOP_CONTENT_6b";
        //		}
        //	}
        //	else if ((MISC::ARE_STRINGS_EQUAL(sParam0, "CC_M_HS_22") || MISC::ARE_STRINGS_EQUAL(sParam0, "CC_F_HS_22")) || MISC::ARE_STRINGS_EQUAL(sParam0, "CC_MKUP_33"))
        //	{
        //		if (!bParam1)
        //		{
        //			return "SHOP_CONTENT_8";
        //		}
        //		else
        //		{
        //			return "SHOP_CONTENT_8b";
        //		}
        //	}
        //	switch (iVar0)
        //	{
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_42"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_43"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_44"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_45"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_46"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_47"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_48"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_49"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_50"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_51"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_52"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_53"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_54"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_55"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_56"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_57"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_58"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_59"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_60"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_61"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_62"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_63"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_64"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_65"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_66"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_67"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_68"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_69"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_70"):
        //		case CitizenFX.Core.Native.API.GetHashKey("CC_MKUP_71"):
        //			return "SHOP_CONTENT_16";
        //			break;
        //	}
        //	switch (iVar0)
        //	{
        //		case 1416268745:
        //		case -708047258:
        //		case 26371570:
        //		case 621780057:
        //		case 954254331:
        //		case -1639280951:
        //		case -780274385:
        //		case -1031153849:
        //		case -212322077:
        //		case 1963703368:
        //		case -2016091686:
        //		case 2039498065:
        //		case -1443879404:
        //		case -1878067362:
        //		case 705702754:
        //		case 1012584439:
        //		case 1147920409:
        //		case -799016957:
        //		case 1661443408:
        //		case 1833284044:
        //		case 2106937963:
        //		case -34090190:
        //		case 266827537:
        //		case -474374046:
        //		case 41606628:
        //		case 1539608682:
        //			return "SHOP_CONTENT_30";
        //			break;
        //	}
        //	switch (iVar0)
        //	{
        //		case -81735992:
        //		case 90628948:
        //		case -1608542009:
        //		case -1309590422:
        //		case -801604532:
        //			return "SHOP_CONTENT_31";
        //			break;
        //	}
        //	return "";
        //}
        //func_494
    }
}
