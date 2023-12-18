using FreeRoamProject.Client.FREEROAM.Phone.Apps.BrowserData;
using FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Data;

namespace FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Model
{
    public class Hangar : PropertyBase
    {
        /// <summary>
        /// Returns a label which can be read by the scaleform, you can create your own using AddTextEntry
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string Label(int n) => $"MP_HANGAR_{n}";

        /// <summary>
        /// Returns a description which can be read by the scaleform, you can create your own using AddTextEntry
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string Description(int n) => $"MP_HANDES_{n}";
        public string Address => "";

        /// <summary>
        /// Returns a texture which can be used by the scaleform, you can create your own with AddReplaceTexture using mp_hngr1-5 or create more and stream them.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string TXD(int n) => $"mp_hngr{n}";

        public eOfficePropertyType OfficeType { get; private set; } = eOfficePropertyType.Hangar;

        public int[] StyleCost = [0, 0, 0, 0, 0, 0, 0, 0, 0];
        public int[] LightingCost = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
        public int[] DecalCost = [0, 0, 0, 0, 0, 0, 0, 0, 0];
        public int[] FurnatureCost = [0, 0, 0];
        public int[] QuartersCost = [0, 0, 0];
        public int WorkshopCost = 0;

        public int[] StyleSaleCost = [-1, -1, -1, -1, -1, -1, -1, -1, -1];
        public int[] LightingSaleCost = [-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1];
        public int[] DecalSaleCost = [-1, -1, -1, -1, -1, -1, -1, -1, -1];
        public int[] FurnatureSaleCost = [-1, -1, -1];
        public int[] QuartersSaleCost = [-1, -1, -1];
        public int WorkshopSaleCost = -1;

        public bool StarterPack = false;

        public Hangar(int slot, int hangarId) : base(slot, hangarId)
        {
            Slot = slot;
            Id = hangarId;
            OfficeType = eOfficePropertyType.Hangar;
            int defaultId = GetDefaultId(hangarId);
            Position = GetDefaultPosition(defaultId);
            if (hangarId == 3)
                Position = new Vector3(-2055.4353f, 3179.971f, 31.8103f);
            else if (hangarId == 4)
                Position = new Vector3(-1857.9939f, 3106.2363f, 31.8103f);
            BaseCost = GetDefaultCost(hangarId);
            StyleCost = [
                GetHangerComponentPrice(0, hangarId, 0),
                GetHangerComponentPrice(0, hangarId, 1),
                GetHangerComponentPrice(0, hangarId, 2),
                GetHangerComponentPrice(0, hangarId, 3),
                GetHangerComponentPrice(0, hangarId, 4),
                GetHangerComponentPrice(0, hangarId, 5),
                GetHangerComponentPrice(0, hangarId, 6),
                GetHangerComponentPrice(0, hangarId, 7),
                GetHangerComponentPrice(0, hangarId, 8)
            ];
            LightingCost = [
                GetHangerComponentPrice(1, hangarId, func_5497(0, 0)),
                GetHangerComponentPrice(1, hangarId, func_5497(0, 1)),
                GetHangerComponentPrice(1, hangarId, func_5497(1, 0)),
                GetHangerComponentPrice(1, hangarId, func_5497(1, 1)),
                GetHangerComponentPrice(1, hangarId, func_5497(2, 0)),
                GetHangerComponentPrice(1, hangarId, func_5497(2, 1)),
                GetHangerComponentPrice(1, hangarId, func_5497(3, 0)),
                GetHangerComponentPrice(1, hangarId, func_5497(3, 1)),
                GetHangerComponentPrice(1, hangarId, func_5497(4, 0)),
                GetHangerComponentPrice(1, hangarId, func_5497(4, 1)),
                GetHangerComponentPrice(1, hangarId, func_5497(5, 0)),
                GetHangerComponentPrice(1, hangarId, func_5497(5, 1)),
                GetHangerComponentPrice(1, hangarId, func_5497(6, 0)),
                GetHangerComponentPrice(1, hangarId, func_5497(6, 1)),
                GetHangerComponentPrice(1, hangarId, func_5497(6, 2)),
                GetHangerComponentPrice(1, hangarId, func_5497(6, 3)),
                GetHangerComponentPrice(1, hangarId, func_5497(7, 0)),
                GetHangerComponentPrice(1, hangarId, func_5497(7, 1)),
                GetHangerComponentPrice(1, hangarId, func_5497(7, 2)),
                GetHangerComponentPrice(1, hangarId, func_5497(7, 3)),
                GetHangerComponentPrice(1, hangarId, func_5497(8, 0)),
                GetHangerComponentPrice(1, hangarId, func_5497(8, 1)),
                GetHangerComponentPrice(1, hangarId, func_5497(8, 2)),
                GetHangerComponentPrice(1, hangarId, func_5497(8, 3))
            ];
            DecalCost = [
                GetHangerComponentPrice(2, hangarId, 0),
                GetHangerComponentPrice(2, hangarId, 1),
                GetHangerComponentPrice(2, hangarId, 2),
                GetHangerComponentPrice(2, hangarId, 3),
                GetHangerComponentPrice(2, hangarId, 4),
                GetHangerComponentPrice(2, hangarId, 5),
                GetHangerComponentPrice(2, hangarId, 6),
                GetHangerComponentPrice(2, hangarId, 7),
                GetHangerComponentPrice(2, hangarId, 8)
            ];
            QuartersCost[1] = GetHangerComponentPrice(4, hangarId, 1);
            QuartersCost[2] = GetHangerComponentPrice(4, hangarId, 2);
            FurnatureCost = [
                GetHangerComponentPrice(3, hangarId, 0),
                GetHangerComponentPrice(3, hangarId, 1),
                GetHangerComponentPrice(3, hangarId, 2),
            ];
            WorkshopCost = GetHangerComponentPrice(5, hangarId, -1);

        }

        public void AddToScaleform(ScaleformWideScreen scaleform) // func_7313
        {
            // These are near the same for all offices in setup
            API.BeginScaleformMovieMethod(scaleform.Handle, "SET_DATA_SLOT");
            API.ScaleformMovieMethodAddParamInt(Slot);
            API.ScaleformMovieMethodAddParamInt(Id);
            Tools.SetScaleformString(Label(Id));
            API.ScaleformMovieMethodAddParamInt((int)OfficeType); // TYPE
            API.ScaleformMovieMethodAddParamFloat(Position.X); // X
            API.ScaleformMovieMethodAddParamFloat(Position.Y); // Y
            Tools.SetTextureDictionary(TXD(Id)); // TXD
            Tools.SetScaleformString(Description(Id)); // DESCRIPTION
            Tools.SetScaleformString(Address); // ADDRESS
            API.ScaleformMovieMethodAddParamInt(BaseCost); // BASE_COST
            // end of simalarities
            API.ScaleformMovieMethodAddParamInt(StyleCost[0]); // STYLE_COST_RANGE 9
            API.ScaleformMovieMethodAddParamInt(StyleCost[1]); // STYLE_COST_RANGE 10
            API.ScaleformMovieMethodAddParamInt(StyleCost[2]); // STYLE_COST_RANGE 11
            API.ScaleformMovieMethodAddParamInt(StyleCost[3]); // STYLE_COST_RANGE 12
            API.ScaleformMovieMethodAddParamInt(StyleCost[4]); // STYLE_COST_RANGE 13
            API.ScaleformMovieMethodAddParamInt(StyleCost[5]); // STYLE_COST_RANGE 14
            API.ScaleformMovieMethodAddParamInt(StyleCost[6]); // STYLE_COST_RANGE 15
            API.ScaleformMovieMethodAddParamInt(StyleCost[7]); // STYLE_COST_RANGE 16
            API.ScaleformMovieMethodAddParamInt(StyleCost[8]); // STYLE_COST_RANGE 17
            API.EndScaleformMovieMethod();

            API.BeginScaleformMovieMethod(scaleform.Handle, "APPEND_OFFICE_DATA_SLOT");
            API.ScaleformMovieMethodAddParamInt(Slot);
            API.ScaleformMovieMethodAddParamInt(LightingCost[0]); // LIGHTING_COST_RANGE 18 -> STYLE_COST_RANGE 9
            API.ScaleformMovieMethodAddParamInt(LightingCost[1]); // LIGHTING_COST_RANGE 19 -> STYLE_COST_RANGE 9
            API.ScaleformMovieMethodAddParamInt(LightingCost[2]); // LIGHTING_COST_RANGE 20 -> STYLE_COST_RANGE 10
            API.ScaleformMovieMethodAddParamInt(LightingCost[3]); // LIGHTING_COST_RANGE 21 -> STYLE_COST_RANGE 10
            API.ScaleformMovieMethodAddParamInt(LightingCost[4]); // LIGHTING_COST_RANGE 22 -> STYLE_COST_RANGE 11
            API.ScaleformMovieMethodAddParamInt(LightingCost[5]); // LIGHTING_COST_RANGE 23 -> STYLE_COST_RANGE 11
            API.ScaleformMovieMethodAddParamInt(LightingCost[6]); // LIGHTING_COST_RANGE 24 -> STYLE_COST_RANGE 12
            API.ScaleformMovieMethodAddParamInt(LightingCost[7]); // LIGHTING_COST_RANGE 25 -> STYLE_COST_RANGE 12
            API.ScaleformMovieMethodAddParamInt(LightingCost[8]); // LIGHTING_COST_RANGE 26 -> STYLE_COST_RANGE 13
            API.ScaleformMovieMethodAddParamInt(LightingCost[9]); // LIGHTING_COST_RANGE 27 -> STYLE_COST_RANGE 13
            API.ScaleformMovieMethodAddParamInt(LightingCost[10]); // LIGHTING_COST_RANGE 28 -> STYLE_COST_RANGE 14
            API.ScaleformMovieMethodAddParamInt(LightingCost[11]); // LIGHTING_COST_RANGE 29 -> STYLE_COST_RANGE 14
            API.EndScaleformMovieMethod();

            API.BeginScaleformMovieMethod(scaleform.Handle, "APPEND_OFFICE_DATA_SLOT");
            API.ScaleformMovieMethodAddParamInt(Slot);
            API.ScaleformMovieMethodAddParamInt(LightingCost[12]); // LIGHTING_COST_RANGE 30 -> STYLE_COST_RANGE 15
            API.ScaleformMovieMethodAddParamInt(LightingCost[13]); // LIGHTING_COST_RANGE 31 -> STYLE_COST_RANGE 15
            API.ScaleformMovieMethodAddParamInt(LightingCost[14]); // LIGHTING_COST_RANGE 32 -> STYLE_COST_RANGE 15
            API.ScaleformMovieMethodAddParamInt(LightingCost[15]); // LIGHTING_COST_RANGE 33 -> STYLE_COST_RANGE 15
            API.ScaleformMovieMethodAddParamInt(LightingCost[16]); // LIGHTING_COST_RANGE 34 -> STYLE_COST_RANGE 16
            API.ScaleformMovieMethodAddParamInt(LightingCost[17]); // LIGHTING_COST_RANGE 35 -> STYLE_COST_RANGE 16
            API.ScaleformMovieMethodAddParamInt(LightingCost[18]); // LIGHTING_COST_RANGE 36 -> STYLE_COST_RANGE 16
            API.ScaleformMovieMethodAddParamInt(LightingCost[19]); // LIGHTING_COST_RANGE 37 -> STYLE_COST_RANGE 16
            API.ScaleformMovieMethodAddParamInt(LightingCost[20]); // LIGHTING_COST_RANGE 38 -> STYLE_COST_RANGE 17
            API.ScaleformMovieMethodAddParamInt(LightingCost[21]); // LIGHTING_COST_RANGE 39 -> STYLE_COST_RANGE 17
            API.ScaleformMovieMethodAddParamInt(LightingCost[22]); // LIGHTING_COST_RANGE 40 -> STYLE_COST_RANGE 17
            API.ScaleformMovieMethodAddParamInt(LightingCost[23]); // LIGHTING_COST_RANGE 41 -> STYLE_COST_RANGE 17
            API.EndScaleformMovieMethod();

            API.BeginScaleformMovieMethod(scaleform.Handle, "APPEND_OFFICE_DATA_SLOT");
            API.ScaleformMovieMethodAddParamInt(Slot);
            // Numbers are shifted in the Scaleform, don't ask why
            API.ScaleformMovieMethodAddParamInt(DecalCost[6]); // DECAL_COST_RANGE 42 - DECAL 6 - optionButton_0
            API.ScaleformMovieMethodAddParamInt(DecalCost[1]); // DECAL_COST_RANGE 43 - DECAL 1 - optionButton_1
            API.ScaleformMovieMethodAddParamInt(DecalCost[7]); // DECAL_COST_RANGE 44 - DECAL 7 - optionButton_2
            API.ScaleformMovieMethodAddParamInt(DecalCost[8]); // DECAL_COST_RANGE 45 - DECAL 8 - optionButton_3
            API.ScaleformMovieMethodAddParamInt(DecalCost[0]); // DECAL_COST_RANGE 46 - DECAL 0 - optionButton_4
            API.ScaleformMovieMethodAddParamInt(DecalCost[5]); // DECAL_COST_RANGE 47 - DECAL 5 - optionButton_5
            API.ScaleformMovieMethodAddParamInt(DecalCost[3]); // DECAL_COST_RANGE 48 - DECAL 3 - optionButton_6
            API.ScaleformMovieMethodAddParamInt(DecalCost[2]); // DECAL_COST_RANGE 49 - DECAL 2 - optionButton_7
            API.ScaleformMovieMethodAddParamInt(DecalCost[4]); // DECAL_COST_RANGE 50 - DECAL 4 - optionButton_8
            API.ScaleformMovieMethodAddParamInt(FurnatureCost[0]); // FURNITURE_COST_RANGE 51
            API.ScaleformMovieMethodAddParamInt(FurnatureCost[1]); // FURNITURE_COST_RANGE 52
            API.ScaleformMovieMethodAddParamInt(FurnatureCost[2]); // FURNITURE_COST_RANGE 53
            API.ScaleformMovieMethodAddParamInt(QuartersCost[1]); // QUARTERS_COST_RANGE 54
            API.ScaleformMovieMethodAddParamInt(QuartersCost[2]); // QUARTERS_COST_RANGE 55
            API.ScaleformMovieMethodAddParamInt(WorkshopCost); // WORKSHOP_COST_RANGE 56
            API.EndScaleformMovieMethod();

            // If costs for sales are set to 0, the item is free, default is -1

            API.BeginScaleformMovieMethod(scaleform.Handle, "APPEND_OFFICE_DATA_SLOT");
            API.ScaleformMovieMethodAddParamInt(Slot);
            API.ScaleformMovieMethodAddParamInt(BaseSaleCost); // BASE_SALE_COST 57
            API.ScaleformMovieMethodAddParamInt(StyleSaleCost[0]); // STYLE_SALE_COST_RANGE 58 <- STYLE_COST_RANGE 9
            API.ScaleformMovieMethodAddParamInt(StyleSaleCost[1]); // STYLE_SALE_COST_RANGE 59 <- STYLE_COST_RANGE 10
            API.ScaleformMovieMethodAddParamInt(StyleSaleCost[2]); // STYLE_SALE_COST_RANGE 60 <- STYLE_COST_RANGE 11
            API.ScaleformMovieMethodAddParamInt(StyleSaleCost[3]); // STYLE_SALE_COST_RANGE 61 <- STYLE_COST_RANGE 12
            API.ScaleformMovieMethodAddParamInt(StyleSaleCost[4]); // STYLE_SALE_COST_RANGE 62 <- STYLE_COST_RANGE 13
            API.ScaleformMovieMethodAddParamInt(StyleSaleCost[5]); // STYLE_SALE_COST_RANGE 63 <- STYLE_COST_RANGE 14
            API.ScaleformMovieMethodAddParamInt(StyleSaleCost[6]); // STYLE_SALE_COST_RANGE 64 <- STYLE_COST_RANGE 15
            API.ScaleformMovieMethodAddParamInt(StyleSaleCost[7]); // STYLE_SALE_COST_RANGE 65 <- STYLE_COST_RANGE 16
            API.ScaleformMovieMethodAddParamInt(StyleSaleCost[8]); // STYLE_SALE_COST_RANGE 66 <- STYLE_COST_RANGE 17
            API.EndScaleformMovieMethod();

            API.BeginScaleformMovieMethod(scaleform.Handle, "APPEND_OFFICE_DATA_SLOT");
            API.ScaleformMovieMethodAddParamInt(Slot);
            API.ScaleformMovieMethodAddParamInt(LightingSaleCost[0]); // LIGHTING_SALE_COST_RANGE 67 -> STYLE_COST_RANGE 9
            API.ScaleformMovieMethodAddParamInt(LightingSaleCost[1]); // LIGHTING_SALE_COST_RANGE 68 -> STYLE_COST_RANGE 9
            API.ScaleformMovieMethodAddParamInt(LightingSaleCost[2]); // LIGHTING_SALE_COST_RANGE 69 -> STYLE_COST_RANGE 10
            API.ScaleformMovieMethodAddParamInt(LightingSaleCost[3]); // LIGHTING_SALE_COST_RANGE 70 -> STYLE_COST_RANGE 10
            API.ScaleformMovieMethodAddParamInt(LightingSaleCost[4]); // LIGHTING_SALE_COST_RANGE 71 -> STYLE_COST_RANGE 11
            API.ScaleformMovieMethodAddParamInt(LightingSaleCost[5]); // LIGHTING_SALE_COST_RANGE 72 -> STYLE_COST_RANGE 11
            API.ScaleformMovieMethodAddParamInt(LightingSaleCost[6]); // LIGHTING_SALE_COST_RANGE 73 -> STYLE_COST_RANGE 12
            API.ScaleformMovieMethodAddParamInt(LightingSaleCost[7]); // LIGHTING_SALE_COST_RANGE 74 -> STYLE_COST_RANGE 12
            API.ScaleformMovieMethodAddParamInt(LightingSaleCost[8]); // LIGHTING_SALE_COST_RANGE 75 -> STYLE_COST_RANGE 13
            API.ScaleformMovieMethodAddParamInt(LightingSaleCost[9]); // LIGHTING_SALE_COST_RANGE 76 -> STYLE_COST_RANGE 13
            API.ScaleformMovieMethodAddParamInt(LightingSaleCost[10]); // LIGHTING_SALE_COST_RANGE 77 -> STYLE_COST_RANGE 14
            API.ScaleformMovieMethodAddParamInt(LightingSaleCost[11]); // LIGHTING_SALE_COST_RANGE 78 -> STYLE_COST_RANGE 14
            API.EndScaleformMovieMethod();

            API.BeginScaleformMovieMethod(scaleform.Handle, "APPEND_OFFICE_DATA_SLOT");
            API.ScaleformMovieMethodAddParamInt(Slot);
            API.ScaleformMovieMethodAddParamInt(LightingSaleCost[12]); // LIGHTING_SALE_COST_RANGE 79 -> STYLE_COST_RANGE 15
            API.ScaleformMovieMethodAddParamInt(LightingSaleCost[13]); // LIGHTING_SALE_COST_RANGE 80 -> STYLE_COST_RANGE 15
            API.ScaleformMovieMethodAddParamInt(LightingSaleCost[14]); // LIGHTING_SALE_COST_RANGE 81 -> STYLE_COST_RANGE 15
            API.ScaleformMovieMethodAddParamInt(LightingSaleCost[15]); // LIGHTING_SALE_COST_RANGE 82 -> STYLE_COST_RANGE 15
            API.ScaleformMovieMethodAddParamInt(LightingSaleCost[16]); // LIGHTING_SALE_COST_RANGE 83 -> STYLE_COST_RANGE 16
            API.ScaleformMovieMethodAddParamInt(LightingSaleCost[17]); // LIGHTING_SALE_COST_RANGE 84 -> STYLE_COST_RANGE 16
            API.ScaleformMovieMethodAddParamInt(LightingSaleCost[18]); // LIGHTING_SALE_COST_RANGE 85 -> STYLE_COST_RANGE 16
            API.ScaleformMovieMethodAddParamInt(LightingSaleCost[19]); // LIGHTING_SALE_COST_RANGE 86 -> STYLE_COST_RANGE 16
            API.ScaleformMovieMethodAddParamInt(LightingSaleCost[20]); // LIGHTING_SALE_COST_RANGE 87 -> STYLE_COST_RANGE 17
            API.ScaleformMovieMethodAddParamInt(LightingSaleCost[21]); // LIGHTING_SALE_COST_RANGE 88 -> STYLE_COST_RANGE 17
            API.ScaleformMovieMethodAddParamInt(LightingSaleCost[22]); // LIGHTING_SALE_COST_RANGE 89 -> STYLE_COST_RANGE 17
            API.ScaleformMovieMethodAddParamInt(LightingSaleCost[23]); // LIGHTING_SALE_COST_RANGE 90 -> STYLE_COST_RANGE 17
            API.EndScaleformMovieMethod();

            API.BeginScaleformMovieMethod(scaleform.Handle, "APPEND_OFFICE_DATA_SLOT");
            API.ScaleformMovieMethodAddParamInt(Slot);
            API.ScaleformMovieMethodAddParamInt(DecalSaleCost[6]); // DECAL_SALE_COST_RANGE 91 - DECAL 7
            API.ScaleformMovieMethodAddParamInt(DecalSaleCost[1]); // DECAL_SALE_COST_RANGE 92 - DECAL 2
            API.ScaleformMovieMethodAddParamInt(DecalSaleCost[7]); // DECAL_SALE_COST_RANGE 93 - DECAL 8
            API.ScaleformMovieMethodAddParamInt(DecalSaleCost[8]); // DECAL_SALE_COST_RANGE 94 - DECAL 9
            API.ScaleformMovieMethodAddParamInt(DecalSaleCost[0]); // DECAL_SALE_COST_RANGE 95 - DECAL 1
            API.ScaleformMovieMethodAddParamInt(DecalSaleCost[5]); // DECAL_SALE_COST_RANGE 96 - DECAL 6
            API.ScaleformMovieMethodAddParamInt(DecalSaleCost[3]); // DECAL_SALE_COST_RANGE 97 - DECAL 4
            API.ScaleformMovieMethodAddParamInt(DecalSaleCost[2]); // DECAL_SALE_COST_RANGE 98 - DECAL 3
            API.ScaleformMovieMethodAddParamInt(DecalSaleCost[4]); // DECAL_SALE_COST_RANGE 99 - DECAL 5
            API.ScaleformMovieMethodAddParamInt(FurnatureSaleCost[0]); // FURNITURE_SALE_COST_RANGE 100
            API.ScaleformMovieMethodAddParamInt(FurnatureSaleCost[1]); // FURNITURE_SALE_COST_RANGE 101
            API.ScaleformMovieMethodAddParamInt(FurnatureSaleCost[2]); // FURNITURE_SALE_COST_RANGE 102
            API.ScaleformMovieMethodAddParamInt(QuartersSaleCost[1]); // QUARTERS_SALE_COST_RANGE 103
            API.ScaleformMovieMethodAddParamInt(QuartersSaleCost[2]); // QUARTERS_SALE_COST_RANGE 104
            API.ScaleformMovieMethodAddParamInt(WorkshopSaleCost); // WORKSHOP_SALE_COST_RANGE 105
            API.ScaleformMovieMethodAddParamInt(StarterPack ? 1 : 0); // STARTER_PACK_FLAG 106
            API.EndScaleformMovieMethod();
        }

        public void GetPurchasedData(int bitwiseValue, ref int hangarIndex, ref int styleIndex, ref int lightingIndex, ref int decalIndex, ref int furnatureIndex, ref int quartersIndex, ref bool purchasedWorkshop)
        {
            hangarIndex = Tools.GetValueFromBitwiseValue(bitwiseValue, 0, 6);

            styleIndex = Tools.GetValueFromBitwiseValue(bitwiseValue, 6, 4);
            lightingIndex = Tools.GetValueFromBitwiseValue(bitwiseValue, 10, 2);
            // LIGHTING_INDEXES_BY_STYLE = [0,2,4,6,8,10,12,16,20]
            // There is a better way, just lazy atm
            if (styleIndex == 1)
                lightingIndex += 2;
            else if (styleIndex == 2)
                lightingIndex += 4;
            else if (styleIndex == 3)
                lightingIndex += 6;
            else if (styleIndex == 4)
                lightingIndex += 8;
            else if (styleIndex == 5)
                lightingIndex += 10;
            else if (styleIndex == 6)
                lightingIndex += 12;
            else if (styleIndex == 7)
                lightingIndex += 16;
            else if (styleIndex == 8)
                lightingIndex += 20;

            decalIndex = Tools.GetValueFromBitwiseValue(bitwiseValue, 12, 4);

            // new decal index, because some R* employee wanted to ruin someones day
            if (decalIndex == 0)
                decalIndex = 6;
            else if (decalIndex == 1)
                decalIndex = 1;
            else if (decalIndex == 2)
                decalIndex = 7;
            else if (decalIndex == 3)
                decalIndex = 8;
            else if (decalIndex == 4)
                decalIndex = 0;
            else if (decalIndex == 5)
                decalIndex = 5;
            else if (decalIndex == 6)
                decalIndex = 3;
            else if (decalIndex == 7)
                decalIndex = 2;
            else if (decalIndex == 8)
                decalIndex = 4;

            furnatureIndex = Tools.GetValueFromBitwiseValue(bitwiseValue, 16, 2);
            quartersIndex = Tools.GetValueFromBitwiseValue(bitwiseValue, 18, 2);
            purchasedWorkshop = Tools.GetValueFromBitwiseValue(bitwiseValue, 20, 1) == 1;
        }

        public int GetTotalValueOfPurchases(int bitwiseValue)
        {
            int hangarIndex = 0;
            int styleIndex = 0;
            int lightingIndex = 0;
            int decalIndex = 0;
            int furnatureIndex = 0;
            int quartersIndex = 0;
            bool purchasedWorkshop = false;

            GetPurchasedData(bitwiseValue, ref hangarIndex, ref styleIndex, ref lightingIndex, ref decalIndex, ref furnatureIndex, ref quartersIndex, ref purchasedWorkshop);

            int total = 0;
            total += Tools.GetBestPrice(BaseCost, BaseSaleCost);
            total += Tools.GetBestPrice(StyleCost[styleIndex], StyleSaleCost[styleIndex]);
            total += Tools.GetBestPrice(LightingCost[lightingIndex], LightingSaleCost[lightingIndex]);
            total += Tools.GetBestPrice(DecalCost[decalIndex], DecalSaleCost[decalIndex]);
            total += Tools.GetBestPrice(FurnatureCost[furnatureIndex], FurnatureSaleCost[furnatureIndex]);
            total += Tools.GetBestPrice(QuartersCost[quartersIndex], QuartersSaleCost[quartersIndex]);
            total += (purchasedWorkshop) ? Tools.GetBestPrice(WorkshopCost, WorkshopSaleCost) : 0;
            return total;
        }

        public int GetDefaultId(int hanger)
        {
            return hanger switch
            {
                1 => 83,
                2 => 84,
                3 => 85,
                4 => 86,
                5 => 87,
                _ => -1,
            };
        }

        /// <summary>
        /// Returns default positions for the 5 hangars
        /// </summary>
        /// <param name="hanger"></param>
        /// <returns></returns>
        public Vector3 GetDefaultPosition(int hanger)
        {
            return hanger switch
            {
                83 => new Vector3(-1153.0896f, -3411.8274f, 12.945f),
                84 => new Vector3(-1396.2682f, -3268.0266f, 12.9448f),
                85 => new Vector3(-2055.4353f, 3179.971f, 31.8103f),
                86 => new Vector3(-1857.9939f, 3106.2363f, 31.8103f),
                87 => new Vector3(-2469.0989f, 3276.5771f, 31.8302f),
                _ => Vector3.Zero,
            };
        }

        /// <summary>
        /// Returns default costs for the 5 hangars
        /// </summary>
        /// <param name="hanger"></param>
        /// <returns></returns>
        public int GetDefaultCost(int hanger)//Position - 0x1E2211
        {
            if (Tunables.Global_262145.Value<int>("f_13353") == 1/* Tunable: PROPERTYWEBSITE_SALE */)
            {
                return hanger switch
                {
                    1 => Tunables.Global_262145.Value<int>("f_22783") /* Tunable: SMUG_HANGAR_LSIA_HANGAR_1 */,
                    2 => Tunables.Global_262145.Value<int>("f_22784") /* Tunable: SMUG_HANGAR_LSIA_HANGAR_A17 */,
                    3 => Tunables.Global_262145.Value<int>("f_22785") /* Tunable: SMUG_HANGAR_FORT_ZANCUDO_HANGAR_A2 */,
                    4 => Tunables.Global_262145.Value<int>("f_22786") /* Tunable: SMUG_HANGAR_FORT_ZANCUDO_HANGAR_3497 */,
                    5 => Tunables.Global_262145.Value<int>("f_22787") /* Tunable: SMUG_HANGAR_FORT_ZANCUDO_HANGAR_3499 */,
                    _ => 0,
                };
            }
            string label = "HANGAR_INDEX_" + hanger + "_t0_v0";
            int hash = API.GetHashKey(label);
            if (API.NetGameserverCatalogItemExistsHash((uint)hash))
            {
                return API.NetGameserverGetPrice((uint)hash, (uint)API.GetHashKey("CATEGORY_PROPERTIE"), true);

            }
            return hanger switch
            {
                1 => 1525000,
                2 => 1200000,
                3 => 3250000,
                4 => 2085000,
                5 => 2650000,
                _ => 0,
            };
        }

        public int GetHangerComponentPrice(int iParam0, int iParam1, int iParam2, bool renovation = false)
        {
            int iVar0;
            int iVar1;
            string sVar2 = "";
            int iVar18;
            int iVar19;
            string cVar20;
            string cVar24;
            iVar1 = 0;
            if (iParam0 == 4)
            {
                iVar1 = 1;
            }
            GetHangerPriceLabel(ref sVar2, iParam0, iParam2, iVar1);
            iVar18 = API.GetHashKey(sVar2);
            if (API.NetGameserverCatalogItemExistsHash((uint)iVar18))
            {
                return API.NetGameserverGetPrice((uint)iVar18, (uint)API.GetHashKey("CATEGORY_PROPERTIE"), true);
            }
            switch (iParam0)
            {
                case 0:
                    return iParam2 switch
                    {
                        0 => Tunables.Global_262145.Value<int>("f_22788") /* Tunable: SMUG_HANGAR_STYLE_1_RENOVATION_PRICE */,
                        1 => Tunables.Global_262145.Value<int>("f_22789") /* Tunable: SMUG_HANGAR_STYLE_2 */,
                        2 => Tunables.Global_262145.Value<int>("f_22790") /* Tunable: SMUG_HANGAR_STYLE_3 */,
                        3 => Tunables.Global_262145.Value<int>("f_22791") /* Tunable: SMUG_HANGAR_STYLE_4 */,
                        4 => Tunables.Global_262145.Value<int>("f_22792") /* Tunable: SMUG_HANGAR_STYLE_5 */,
                        5 => Tunables.Global_262145.Value<int>("f_22793") /* Tunable: SMUG_HANGAR_STYLE_6 */,
                        6 => Tunables.Global_262145.Value<int>("f_22794") /* Tunable: SMUG_HANGAR_STYLE_7 */,
                        7 => Tunables.Global_262145.Value<int>("f_22795") /* Tunable: SMUG_HANGAR_STYLE_8 */,
                        8 => Tunables.Global_262145.Value<int>("f_22796") /* Tunable: SMUG_HANGAR_STYLE_9 */,
                        _ => 0,
                    };
                case 1:
                    return iParam2 switch
                    {
                        0 => Tunables.Global_262145.Value<int>("f_22797") /* Tunable: SMUG_HANGAR_LIGHTING_STYLE_1_STANDARD_RENOVATION_PRICE */,
                        1 => Tunables.Global_262145.Value<int>("f_22798") /* Tunable: SMUG_HANGAR_LIGHTING_STYLE_1_VIBRANT_LIGHTING */,
                        2 => Tunables.Global_262145.Value<int>("f_22799") /* Tunable: SMUG_HANGAR_LIGHTING_STYLE_2_STANDARD_RENOVATION_PRICE */,
                        3 => Tunables.Global_262145.Value<int>("f_22800") /* Tunable: SMUG_HANGAR_LIGHTING_STYLE_2_VIBRANT_LIGHTING */,
                        4 => Tunables.Global_262145.Value<int>("f_22801") /* Tunable: SMUG_HANGAR_LIGHTING_STYLE_3_STANDARD_RENOVATION_PRICE */,
                        5 => Tunables.Global_262145.Value<int>("f_22802") /* Tunable: SMUG_HANGAR_LIGHTING_STYLE_3_VIBRANT_LIGHTING */,
                        6 => Tunables.Global_262145.Value<int>("f_22803") /* Tunable: SMUG_HANGAR_LIGHTING_STYLE_4_STANDARD_RENOVATION_PRICE */,
                        7 => Tunables.Global_262145.Value<int>("f_22804") /* Tunable: SMUG_HANGAR_LIGHTING_STYLE_4_VIBRANT_LIGHTING */,
                        8 => Tunables.Global_262145.Value<int>("f_22805") /* Tunable: SMUG_HANGAR_LIGHTING_STYLE_5_STANDARD_RENOVATION_PRICE */,
                        9 => Tunables.Global_262145.Value<int>("f_22806") /* Tunable: SMUG_HANGAR_LIGHTING_STYLE_5_VIBRANT_LIGHTING */,
                        10 => Tunables.Global_262145.Value<int>("f_22807") /* Tunable: SMUG_HANGAR_LIGHTING_STYLE_6_STANDARD_RENOVATION_PRICE */,
                        11 => Tunables.Global_262145.Value<int>("f_22808") /* Tunable: SMUG_HANGAR_LIGHTING_STYLE_6_VIBRANT_LIGHTING */,
                        12 => Tunables.Global_262145.Value<int>("f_22809") /* Tunable: SMUG_HANGAR_LIGHTING_STYLE_7_STANDARD_RENOVATION_PRICE */,
                        13 => Tunables.Global_262145.Value<int>("f_22810") /* Tunable: SMUG_HANGAR_LIGHTING_STYLE_7_VIBRANT_LIGHTING_1 */,
                        14 => Tunables.Global_262145.Value<int>("f_22811") /* Tunable: SMUG_HANGAR_LIGHTING_STYLE_7_VIBRANT_LIGHTING_2 */,
                        15 => Tunables.Global_262145.Value<int>("f_22812") /* Tunable: SMUG_HANGAR_LIGHTING_STYLE_7_VIBRANT_LIGHTING_3 */,
                        16 => Tunables.Global_262145.Value<int>("f_22813") /* Tunable: SMUG_HANGAR_LIGHTING_STYLE_8_STANDARD_RENOVATION_PRICE */,
                        17 => Tunables.Global_262145.Value<int>("f_22814") /* Tunable: SMUG_HANGAR_LIGHTING_STYLE_8_VIBRANT_LIGHTING_1 */,
                        18 => Tunables.Global_262145.Value<int>("f_22815") /* Tunable: SMUG_HANGAR_LIGHTING_STYLE_8_VIBRANT_LIGHTING_2 */,
                        19 => Tunables.Global_262145.Value<int>("f_22816") /* Tunable: SMUG_HANGAR_LIGHTING_STYLE_8_VIBRANT_LIGHTING_3 */,
                        20 => Tunables.Global_262145.Value<int>("f_22817") /* Tunable: SMUG_HANGAR_LIGHTING_STYLE_9_STANDARD_RENOVATION_PRICE */,
                        21 => Tunables.Global_262145.Value<int>("f_22818") /* Tunable: SMUG_HANGAR_LIGHTING_STYLE_9_VIBRANT_LIGHTING_1 */,
                        22 => Tunables.Global_262145.Value<int>("f_22819") /* Tunable: SMUG_HANGAR_LIGHTING_STYLE_9_VIBRANT_LIGHTING_2 */,
                        23 => Tunables.Global_262145.Value<int>("f_22820") /* Tunable: SMUG_HANGAR_LIGHTING_STYLE_9_VIBRANT_LIGHTING_3 */,
                        _ => 0,
                    };
                case 2:
                    return iParam2 switch
                    {
                        0 => Tunables.Global_262145.Value<int>("f_22827") /* Tunable: SMUG_HANGAR_FLOOR_GRAPHICS_7 */,
                        1 => Tunables.Global_262145.Value<int>("f_22822") /* Tunable: SMUG_HANGAR_FLOOR_GRAPHICS_2 */,
                        2 => Tunables.Global_262145.Value<int>("f_22828") /* Tunable: SMUG_HANGAR_FLOOR_GRAPHICS_8 */,
                        3 => Tunables.Global_262145.Value<int>("f_22829") /* Tunable: SMUG_HANGAR_FLOOR_GRAPHICS_9 */,
                        4 => Tunables.Global_262145.Value<int>("f_22821") /* Tunable: SMUG_HANGAR_FLOOR_GRAPHICS_1_RENOVATION_PRICE */,
                        5 => Tunables.Global_262145.Value<int>("f_22826") /* Tunable: SMUG_HANGAR_FLOOR_GRAPHICS_6 */,
                        6 => Tunables.Global_262145.Value<int>("f_22824") /* Tunable: SMUG_HANGAR_FLOOR_GRAPHICS_4 */,
                        7 => Tunables.Global_262145.Value<int>("f_22823") /* Tunable: SMUG_HANGAR_FLOOR_GRAPHICS_3 */,
                        8 => Tunables.Global_262145.Value<int>("f_22825") /* Tunable: SMUG_HANGAR_FLOOR_GRAPHICS_5 */,
                        _ => 0,
                    };
                case 3:
                    return iParam2 switch
                    {
                        0 => Tunables.Global_262145.Value<int>("f_22830") /* Tunable: SMUG_HANGAR_OFFICE_STANDARD_RENOVATION_PRICE */,
                        1 => Tunables.Global_262145.Value<int>("f_22831") /* Tunable: SMUG_HANGAR_OFFICE_TRADITIONAL */,
                        2 => Tunables.Global_262145.Value<int>("f_22832") /* Tunable: SMUG_HANGAR_OFFICE_MODERN */,
                        _ => 0,
                    };
                case 4:
                    switch (iParam2)
                    {
                        case 0:
                            return 0;

                        case 1:
                            if (!renovation)
                            {
                                return Tunables.Global_262145.Value<int>("f_22833") /* Tunable: SMUG_HANGAR_LIVING_QUARTERS */;
                            }
                            else
                            {
                                return (0 + Tunables.Global_262145.Value<int>("f_22834") /* Tunable: SMUG_HANGAR_LIVING_QUARTERS_TRADITIONAL_INTERIOR_RENOVATION_PRICE */);
                            }

                        case 2:
                            if (!renovation)
                            {
                                return Tunables.Global_262145.Value<int>("f_22833") /* Tunable: SMUG_HANGAR_LIVING_QUARTERS */ + Tunables.Global_262145.Value<int>("f_22835") /* Tunable: SMUG_HANGAR_LIVING_QUARTERS_MODERN_INTERIOR */;
                            }
                            else
                            {
                                return (0 + Tunables.Global_262145.Value<int>("f_22835") /* Tunable: SMUG_HANGAR_LIVING_QUARTERS_MODERN_INTERIOR */);
                            }
                    }
                    return 0;

                case 5:
                    return Tunables.Global_262145.Value<int>("f_22836") /* Tunable: SMUG_HANGAR_AIRCRAFT_WORKSHOP */;
            }
            return 0;
        }
        private int func_5497(int iParam0, int iParam1)//Position - 0x1C3038
        {
            switch (iParam0)
            {
                case 0:
                    switch (iParam1)
                    {
                        case 0:
                            return 0;
                        case 1:
                            return 1;
                    }
                    break;

                case 1:
                    switch (iParam1)
                    {
                        case 0:
                            return 2;
                        case 1:
                            return 3;
                    }
                    break;

                case 2:
                    switch (iParam1)
                    {
                        case 0:
                            return 4;
                        case 1:
                            return 5;
                    }
                    break;

                case 3:
                    switch (iParam1)
                    {
                        case 0:
                            return 6;
                        case 1:
                            return 7;
                    }
                    break;

                case 4:
                    switch (iParam1)
                    {
                        case 0:
                            return 8;
                        case 1:
                            return 9;
                    }
                    break;

                case 5:
                    switch (iParam1)
                    {
                        case 0:
                            return 10;
                        case 1:
                            return 11;
                    }
                    break;

                case 6:
                    switch (iParam1)
                    {
                        case 0:
                            return 12;
                        case 1:
                            return 13;
                        case 2:
                            return 14;
                        case 3:
                            return 15;
                    }
                    break;

                case 7:
                    switch (iParam1)
                    {
                        case 0:
                            return 16;
                        case 1:
                            return 17;
                        case 2:
                            return 18;
                        case 3:
                            return 19;
                    }
                    break;

                case 8:
                    switch (iParam1)
                    {
                        case 0:
                            return 20;
                        case 1:
                            return 21;
                        case 2:
                            return 22;
                        case 3:
                            return 23;
                    }
                    break;
            }
            return -1;
        }

        /*
        public int GetComponentPrice(int iParam0, int iParam1)
        {
            int iVar0 = iParam1;
            string sVar1 = "";
            int iVar17;
            int iVar18;

            if (iVar0 == -1) iVar0 = 0;


        }
        */

        public void GetHangerPriceLabel(ref string sParam0, int iParam1, int iParam2, int iParam3)
        {
            sParam0 = "HANGAR_MOD_";
            switch (iParam1)
            {
                case 2:
                    sParam0 += "FLOOR_DECAL_";
                    break;

                case 4:
                    sParam0 += "SAVEBED_";
                    break;

                case 3:
                    sParam0 += "FURNITURE_";
                    break;

                case 5:
                    sParam0 += "MODSHOP_";
                    break;

                case 0:
                    sParam0 += "COLOUR_";
                    break;

                case 1:
                    sParam0 += "LIGHTING_";
                    break;
            }
            sParam0 += iParam2;
            sParam0 += "_t0_v";
            sParam0 += iParam3;

        }
        public void GetPriceComponentLabel(ref string sParam0, int iParam1, int iParam2, int iParam3)
        {
            string cVar0 = "";
            switch (iParam1)
            {
                case 0:
                    cVar0 = "PM_BWALL_";
                    cVar0 += iParam2;
                    break;

                case 1:
                    cVar0 = "PM_BHANGING_";
                    cVar0 += iParam2;
                    break;

                case 2:
                    cVar0 = "PM_BFURNITURE_";
                    cVar0 += iParam2;
                    break;

                case 4:
                    cVar0 = "PM_BFONT_";
                    cVar0 += iParam2;
                    break;

                case 5:
                    cVar0 = "PM_BFCOLOUR_";
                    cVar0 += iParam2;
                    break;

                case 6:
                    cVar0 = "PM_BEMBLEM_";
                    cVar0 += iParam2;
                    break;

                case 7:
                    cVar0 = "PM_BHIDESINAGE_";
                    cVar0 += iParam2;
                    break;

                case 8:
                    cVar0 = "PM_BGUNLOCK_";
                    cVar0 += iParam2;
                    break;

                case 9:
                    cVar0 = "PM_BGARAGE_";
                    cVar0 += iParam2;
                    break;

                case 10:
                    cVar0 = "PM_BNAME_";
                    cVar0 += iParam2;
                    break;
            }
            sParam0 = "PR_";
            sParam0 += cVar0;
            sParam0 += "_t";
            sParam0 += iParam3;
            sParam0 += "_v0";
        }

    }
}
