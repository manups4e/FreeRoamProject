using FreeRoamProject.Client.FREEROAM.Phone.Apps.BrowserData;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Model.Dynasty
{
    internal class Office : PropertyBase
    {
        public string Label(int n) => n switch
        {
            87 => "MP_PROP_OFF1" /* GXT: Lombank West */,
            88 => "MP_PROP_OFF2" /* GXT: Maze Bank West */,
            89 => "MP_PROP_OFF3" /* GXT: Arcadius Business Center */,
            90 => "MP_PROP_OFF4" /* GXT: Maze Bank Tower */,
            _ => ""
        };
        public string Description(int n) => n switch
        {
            87 => "MP_PROP_96DES",
            88 => "MP_PROP_97DES",
            89 => "MP_PROP_98DES",
            90 => "MP_PROP_99DES",
            _ => ""
        };

        public string TXD(int n) => n switch
        {
            87 => "DYN_OFFICE_1",
            88 => "DYN_OFFICE_2",
            89 => "DYN_OFFICE_3",
            90 => "DYN_OFFICE_4",
            _ => "",
        };
        public Office(int slot, int id) : base(slot, id) //func_7345
        {
            BaseCost = Ceil(func_5723(id) * Tunables.Global_262145.Value<float>("f_78"));
            Position = GetPosition(id);
        }

        public void AddToScaleform(ScaleformWideScreen sc)
        {
            int iVar3 = -1;
            int iVar4 = -1;
            int iVar5 = -1;
            int iVar6 = -1;
            int iVar7 = -1;
            int iVar8 = -1;
            int iVar9 = -1;
            int iVar10 = -1;
            int iVar11 = -1;
            int iVar12 = -1;
            int iVar13 = -1;
            int iVar14 = -1;
            int iVar15 = -1;
            int iVar16 = -1;
            int iVar17 = -1;
            int iVar18 = -1;
            int iVar19 = -1;
            int iVar20 = -1;
            int iVar21 = -1;
            int iVar22 = -1;
            int iVar23 = -1;
            int iVar24 = -1;
            int iVar25 = -1;
            int iVar26 = -1;
            int iVar27 = -1;
            int iVar28 = -1;
            int iVar29 = -1;
            int iVar30 = -1;
            int iVar31 = -1;
            int iVar32 = -1;
            int iVar33 = -1;
            int iVar34 = -1;
            int iVar35 = -1;
            int iVar36 = -1;
            int iVar37 = -1;
            int iVar38 = -1;
            int iVar39 = -1;
            int iVar40 = -1;
            int iVar41 = -1;
            int iVar42 = -1;
            int iVar43 = -1;
            int iVar44 = -1;
            int iVar45 = -1;
            int iVar46 = -1;
            int iVar47 = -1;
            int iVar48 = -1;
            int iVar49 = -1;
            int iVar50 = -1;
            int iVar51 = -1;
            int iVar52 = -1;
            int iVar53 = -1;
            int iVar54 = -1;
            int iVar55 = -1;
            int iVar56 = -1;
            int iVar57 = -1;
            int iVar58 = -1;
            int iVar59 = -1;
            int iVar60 = -1;
            int iVar61 = -1;
            int iVar62 = -1;
            int iVar63 = -1;
            int iVar64 = -1;
            int iVar65 = -1;
            int iVar66 = -1;
            int iVar67 = -1;
            int iVar68 = -1;
            int iVar69 = -1;
            int iVar70 = -1;
            int iVar71 = -1;
            int iVar72 = -1;
            int iVar73 = -1;
            int iVar74 = -1;
            int iVar75 = -1;
            int iVar76 = -1;
            int iVar77 = -1;
            int iVar78 = -1;
            int iVar79 = -1;
            int iVar80 = -1;
            int iVar81 = -1;
            int iVar82 = -1;
            int iVar83 = -1;
            int iVar84 = -1;
            int iVar85 = -1;
            int iVar86 = -1;
            int iVar87 = -1;
            int iVar88 = -1;
            int iVar89 = -1;
            int iVar90 = -1;
            int iVar91 = -1;
            int iVar92 = -1;
            int iVar93 = -1;
            int iVar94 = -1;
            int iVar95 = -1;
            int iVar96 = -1;
            int iVar97 = -1;
            int iVar98 = -1;
            int iVar99 = -1;
            int iVar100 = -1;
            int iVar101 = -1;
            int iVar102 = -1;
            int iVar103 = -1;
            int iVar104 = -1;
            int iVar105 = -1;
            BeginScaleformMovieMethod(sc.Handle, "SET_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(Id);
            Tools.SetScaleformString(Label(Id));
            ScaleformMovieMethodAddParamFloat(Position.X);
            ScaleformMovieMethodAddParamFloat(Position.Y);
            Tools.SetTextureDictionary(TXD(Id));
            Tools.SetScaleformString(Description(Id));
            ScaleformMovieMethodAddParamInt(BaseCost);
            if (iVar3 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_6347(4, Id));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_6346(4, Id));
            }
            if (iVar4 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_6347(5, Id));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_6346(5, Id));
            }
            if (iVar5 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_6347(3, Id));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_6346(3, Id));
            }
            if (iVar6 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_6347(0, Id));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_6346(0, Id));
            }
            if (iVar7 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_6347(1, Id));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_6346(1, Id));
            }
            if (iVar8 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_6347(2, Id));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_6346(2, Id));
            }
            if (iVar9 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_6347(6, Id));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_6346(6, Id));
            }
            if (iVar10 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_6347(7, Id));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_6346(7, Id));
            }
            if (iVar11 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_6347(8, Id));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_6346(8, Id));
            }
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            if (iVar12 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_5722(1, 0));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_6348(1, 0));
            }
            if (iVar13 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_5722(1, 1));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_6348(1, 1));
            }
            if (iVar14 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_5722(2, -1));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_6348(2, -1));
            }
            if (iVar15 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_5722(7, -1));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_6348(7, -1));
            }
            if (iVar16 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_5722(4, -1));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_6348(4, -1));
            }
            if (iVar17 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_5722(5, -1));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_6348(5, -1));
            }
            if (iVar18 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_5722(6, -1));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_6348(6, -1));
            }
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(BaseCost);
            ScaleformMovieMethodAddParamInt(iVar3);
            ScaleformMovieMethodAddParamInt(iVar4);
            ScaleformMovieMethodAddParamInt(iVar5);
            ScaleformMovieMethodAddParamInt(iVar6);
            ScaleformMovieMethodAddParamInt(iVar7);
            ScaleformMovieMethodAddParamInt(iVar8);
            ScaleformMovieMethodAddParamInt(iVar9);
            ScaleformMovieMethodAddParamInt(iVar10);
            ScaleformMovieMethodAddParamInt(iVar11);
            ScaleformMovieMethodAddParamInt(iVar12);
            ScaleformMovieMethodAddParamInt(iVar13);
            ScaleformMovieMethodAddParamInt(iVar14);
            ScaleformMovieMethodAddParamInt(iVar15);
            ScaleformMovieMethodAddParamInt(iVar16);
            ScaleformMovieMethodAddParamInt(iVar17);
            ScaleformMovieMethodAddParamInt(iVar18);
            EndScaleformMovieMethod();
            // Garages
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            Tools.SetScaleformString(func_7346(Id));
            if (iVar19 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7356(Id));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7357(Id));
            }
            if (iVar20 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7354(0, 103));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7355(0, 103));
            }
            if (iVar21 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7354(1, 103));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7355(1, 103));
            }
            if (iVar22 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7354(2, 103));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7355(2, 103));
            }
            if (iVar23 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7354(3, 103));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7355(3, 103));
            }
            if (iVar24 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(103, 8, 0));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(103, 8, 0));
            }
            if (iVar25 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(103, 8, 1));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(103, 8, 1));
            }
            if (iVar26 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(103, 8, 2));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(103, 8, 2));
            }
            if (iVar27 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(103, 8, 3));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(103, 8, 3));
            }
            if (iVar28 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(103, 8, 4));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(103, 8, 4));
            }
            if (iVar29 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(103, 8, 5));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(103, 8, 5));
            }
            if (iVar30 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(103, 8, 6));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(103, 8, 6));
            }
            if (iVar31 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(103, 8, 7));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(103, 8, 7));
            }
            if (iVar32 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(103, 8, 8));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(103, 8, 8));
            }
            if (iVar33 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(103, 9, 0));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(103, 9, 0));
            }
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            if (iVar34 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(103, 9, 1));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(103, 9, 1));
            }
            if (iVar35 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(103, 9, 2));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(103, 9, 2));
            }
            if (iVar36 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(103, 9, 3));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(103, 9, 3));
            }
            if (iVar37 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(103, 9, 4));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(103, 9, 4));
            }
            if (iVar38 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(103, 9, 5));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(103, 9, 5));
            }
            if (iVar39 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(103, 9, 6));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(103, 9, 6));
            }
            if (iVar40 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(103, 9, 7));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(103, 9, 7));
            }
            if (iVar41 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(103, 9, 8));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(103, 9, 8));
            }
            if (iVar42 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7354(0, 104));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7355(0, 104));
            }
            if (iVar43 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7354(1, 104));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7355(1, 104));
            }
            if (iVar44 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7354(2, 104));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7355(2, 104));
            }
            if (iVar45 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7354(3, 104));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7355(3, 104));
            }
            if (iVar46 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(104, 8, 0));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(104, 8, 0));
            }
            if (iVar47 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(104, 8, 1));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(104, 8, 1));
            }
            if (iVar48 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(104, 8, 2));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(104, 8, 2));
            }
            if (iVar49 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(104, 8, 3));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(104, 8, 3));
            }
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            if (iVar50 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(104, 8, 4));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(104, 8, 4));
            }
            if (iVar51 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(104, 8, 5));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(104, 8, 5));
            }
            if (iVar52 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(104, 8, 6));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(104, 8, 6));
            }
            if (iVar53 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(104, 8, 7));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(104, 8, 7));
            }
            if (iVar54 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(104, 8, 8));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(104, 8, 8));
            }
            if (iVar55 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(104, 9, 0));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(104, 9, 0));
            }
            if (iVar56 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(104, 9, 1));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(104, 9, 1));
            }
            if (iVar57 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(104, 9, 2));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(104, 9, 2));
            }
            if (iVar58 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(104, 9, 3));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(104, 9, 3));
            }
            if (iVar59 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(104, 9, 4));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(104, 9, 4));
            }
            if (iVar60 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(104, 9, 5));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(104, 9, 5));
            }
            if (iVar61 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(104, 9, 6));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(104, 9, 6));
            }
            if (iVar62 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(104, 9, 7));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(104, 9, 7));
            }
            if (iVar63 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(104, 9, 8));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(104, 9, 8));
            }
            if (iVar64 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7354(0, 105));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7355(0, 105));
            }
            if (iVar65 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7354(1, 105));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7355(1, 105));
            }
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            if (iVar66 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7354(2, 105));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7355(2, 105));
            }
            if (iVar67 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7354(3, 105));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7355(3, 105));
            }
            if (iVar68 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(105, 8, 0));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(105, 8, 0));
            }
            if (iVar69 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(105, 8, 1));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(105, 8, 1));
            }
            if (iVar70 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(105, 8, 2));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(105, 8, 2));
            }
            if (iVar71 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(105, 8, 3));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(105, 8, 3));
            }
            if (iVar72 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(105, 8, 4));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(105, 8, 4));
            }
            if (iVar73 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(105, 8, 5));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(105, 8, 5));
            }
            if (iVar74 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(105, 8, 6));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(105, 8, 6));
            }
            if (iVar75 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(105, 8, 7));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(105, 8, 7));
            }
            if (iVar76 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(105, 8, 8));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(105, 8, 8));
            }
            if (iVar77 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(105, 9, 0));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(105, 9, 0));
            }
            if (iVar78 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(105, 9, 1));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(105, 9, 1));
            }
            if (iVar79 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(105, 9, 2));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(105, 9, 2));
            }
            if (iVar80 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(105, 9, 3));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(105, 9, 3));
            }
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            if (iVar81 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(105, 9, 4));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(105, 9, 4));
            }
            if (iVar82 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(105, 9, 5));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(105, 9, 5));
            }
            if (iVar83 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(105, 9, 6));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(105, 9, 6));
            }
            if (iVar84 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(105, 9, 7));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(105, 9, 7));
            }
            if (iVar85 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7350(105, 9, 8));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7353(105, 9, 8));
            }
            if (iVar86 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7347(Id, 1));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7348(Id, 1));
            }
            if (iVar87 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7347(Id, 2));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7348(Id, 2));
            }
            if (iVar88 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7347(Id, 3));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7348(Id, 3));
            }
            if (iVar89 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7347(Id, 4));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7348(Id, 4));
            }
            if (iVar90 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7347(Id, 5));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7348(Id, 5));
            }
            if (iVar91 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7347(Id, 6));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7348(Id, 6));
            }
            if (iVar92 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7347(Id, 7));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7348(Id, 7));
            }
            if (iVar93 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7347(Id, 8));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7348(Id, 8));
            }
            if (iVar94 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7347(Id, 9));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7348(Id, 9));
            }
            if (iVar95 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7347(Id, 10));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7348(Id, 10));
            }
            if (iVar96 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7347(Id, 11));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7348(Id, 11));
            }
            if (iVar97 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7347(Id, 12));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7348(Id, 12));
            }
            if (iVar98 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7347(Id, 13));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7348(Id, 13));
            }
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            if (iVar99 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7347(Id, 14));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7348(Id, 14));
            }
            if (iVar100 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7347(Id, 15));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7348(Id, 15));
            }
            if (iVar101 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7347(Id, 16));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7348(Id, 16));
            }
            if (iVar102 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7347(Id, 17));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7348(Id, 17));
            }
            if (iVar103 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7347(Id, 18));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7348(Id, 18));
            }
            if (iVar104 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7347(Id, 19));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7348(Id, 19));
            }
            if (iVar105 == -1)
            {
                ScaleformMovieMethodAddParamInt(func_7347(Id, 20));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(func_7348(Id, 20));
            }
            ScaleformMovieMethodAddParamInt(iVar19);
            ScaleformMovieMethodAddParamInt(iVar20);
            ScaleformMovieMethodAddParamInt(iVar21);
            ScaleformMovieMethodAddParamInt(iVar22);
            ScaleformMovieMethodAddParamInt(iVar23);
            ScaleformMovieMethodAddParamInt(iVar24);
            ScaleformMovieMethodAddParamInt(iVar25);
            ScaleformMovieMethodAddParamInt(iVar26);
            ScaleformMovieMethodAddParamInt(iVar27);
            ScaleformMovieMethodAddParamInt(iVar28);
            ScaleformMovieMethodAddParamInt(iVar29);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(iVar30);
            ScaleformMovieMethodAddParamInt(iVar31);
            ScaleformMovieMethodAddParamInt(iVar32);
            ScaleformMovieMethodAddParamInt(iVar33);
            ScaleformMovieMethodAddParamInt(iVar34);
            ScaleformMovieMethodAddParamInt(iVar35);
            ScaleformMovieMethodAddParamInt(iVar36);
            ScaleformMovieMethodAddParamInt(iVar37);
            ScaleformMovieMethodAddParamInt(iVar38);
            ScaleformMovieMethodAddParamInt(iVar39);
            ScaleformMovieMethodAddParamInt(iVar40);
            ScaleformMovieMethodAddParamInt(iVar41);
            ScaleformMovieMethodAddParamInt(iVar42);
            ScaleformMovieMethodAddParamInt(iVar43);
            ScaleformMovieMethodAddParamInt(iVar44);
            ScaleformMovieMethodAddParamInt(iVar45);
            ScaleformMovieMethodAddParamInt(iVar46);
            ScaleformMovieMethodAddParamInt(iVar47);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(iVar48);
            ScaleformMovieMethodAddParamInt(iVar49);
            ScaleformMovieMethodAddParamInt(iVar50);
            ScaleformMovieMethodAddParamInt(iVar51);
            ScaleformMovieMethodAddParamInt(iVar52);
            ScaleformMovieMethodAddParamInt(iVar53);
            ScaleformMovieMethodAddParamInt(iVar54);
            ScaleformMovieMethodAddParamInt(iVar55);
            ScaleformMovieMethodAddParamInt(iVar56);
            ScaleformMovieMethodAddParamInt(iVar57);
            ScaleformMovieMethodAddParamInt(iVar58);
            ScaleformMovieMethodAddParamInt(iVar59);
            ScaleformMovieMethodAddParamInt(iVar60);
            ScaleformMovieMethodAddParamInt(iVar61);
            ScaleformMovieMethodAddParamInt(iVar62);
            ScaleformMovieMethodAddParamInt(iVar63);
            ScaleformMovieMethodAddParamInt(iVar64);
            ScaleformMovieMethodAddParamInt(iVar65);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(iVar66);
            ScaleformMovieMethodAddParamInt(iVar67);
            ScaleformMovieMethodAddParamInt(iVar68);
            ScaleformMovieMethodAddParamInt(iVar69);
            ScaleformMovieMethodAddParamInt(iVar70);
            ScaleformMovieMethodAddParamInt(iVar71);
            ScaleformMovieMethodAddParamInt(iVar72);
            ScaleformMovieMethodAddParamInt(iVar73);
            ScaleformMovieMethodAddParamInt(iVar74);
            ScaleformMovieMethodAddParamInt(iVar75);
            ScaleformMovieMethodAddParamInt(iVar76);
            ScaleformMovieMethodAddParamInt(iVar77);
            ScaleformMovieMethodAddParamInt(iVar78);
            ScaleformMovieMethodAddParamInt(iVar79);
            ScaleformMovieMethodAddParamInt(iVar80);
            ScaleformMovieMethodAddParamInt(iVar81);
            ScaleformMovieMethodAddParamInt(iVar82);
            ScaleformMovieMethodAddParamInt(iVar83);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(iVar84);
            ScaleformMovieMethodAddParamInt(iVar85);
            ScaleformMovieMethodAddParamInt(iVar86);
            ScaleformMovieMethodAddParamInt(iVar87);
            ScaleformMovieMethodAddParamInt(iVar88);
            ScaleformMovieMethodAddParamInt(iVar89);
            ScaleformMovieMethodAddParamInt(iVar90);
            ScaleformMovieMethodAddParamInt(iVar91);
            ScaleformMovieMethodAddParamInt(iVar92);
            ScaleformMovieMethodAddParamInt(iVar93);
            ScaleformMovieMethodAddParamInt(iVar94);
            ScaleformMovieMethodAddParamInt(iVar95);
            ScaleformMovieMethodAddParamInt(iVar96);
            ScaleformMovieMethodAddParamInt(iVar97);
            ScaleformMovieMethodAddParamInt(iVar98);
            ScaleformMovieMethodAddParamInt(iVar99);
            ScaleformMovieMethodAddParamInt(iVar100);
            ScaleformMovieMethodAddParamInt(iVar101);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(iVar102);
            ScaleformMovieMethodAddParamInt(iVar103);
            ScaleformMovieMethodAddParamInt(iVar104);
            ScaleformMovieMethodAddParamInt(iVar105);
            if ((VehicleSitesHandler.func_5728() && func_5727(Id)) && func_5731(Id))
            {
                ScaleformMovieMethodAddParamBool(true);
            }
            else
            {
                ScaleformMovieMethodAddParamBool(false);
            }
            EndScaleformMovieMethod();
        }

        Vector3 GetPosition(int id)
        {
            return id switch
            {
                87 => new(-1572.1869f, -570.8315f, 109.9879f),
                88 => new(-1383.9543f, -476.7112f, 73.507f),
                89 => new(-138.0029f, -629.739f, 170.2854f),
                90 => new(-74.8895f, -817.6883f, 244.8508f),
                _ => new(0)
            };
        }


        int func_5723(int iParam0)//Position - 0x1D3A85
        {
            int iVar0;
            bool bVar1;
            int iVar2;

            iVar0 = 0;
            bVar1 = false;
            if (func_5731(iParam0))
            {
                if (!func_5727(iParam0))
                {
                    iVar0 = 1;
                }
                else
                {
                    bVar1 = true;
                }
            }
            iVar2 = func_5724(iParam0, iVar0, bVar1);
            if (NetGameserverCatalogItemExistsHash((uint)iVar2))
            {
                return NetGameserverGetPrice((uint)iVar2, (uint)GetHashKey("CATEGORY_PROPERTIE"), true);
            }
            return func_67(iParam0);
        }
        internal bool func_5731(int iParam0)//Position - 0x1D43B6
        {
            if (iParam0 == 31)
            {
                return true;
            }
            if (VehicleSitesHandler.func_5728())
            {
                if (func_5727(iParam0))
                {
                    return true;
                }
            }
            return false;
        }
        bool func_5727(int iParam0)//Position - 0x1D4307
        {
            if (VehicleSitesHandler.func_5728())
            {
                if (((iParam0 == 88 || iParam0 == 94) || iParam0 == 18) || iParam0 == 56)
                {
                    return true;
                }
            }
            return false;
        }
        int func_5724(int iParam0, int iParam1, bool bParam2)//Position - 0x1D3AE5
        {
            string sVar0 = "";

            func_5725(ref sVar0, iParam0, iParam1, bParam2);
            return GetHashKey(sVar0);
        }

        void func_5725(ref string sParam0, int iParam1, int iParam2, bool bParam3)//Position - 0x1D3AFF
        {
            string Var0;

            //sParam0 = "FACTORY_INDEX_";
            Var0 = func_5726(iParam1);
            sParam0 += "PR_";
            sParam0 += Var0;
            sParam0 += "_t0_v";
            sParam0 += iParam2;
            if (bParam3)
            {
                sParam0 += "_CESP";
            }
        }

        string func_5726(int iParam0)//Position - 0x1D3B46
        {

            string Var0 = "";

            switch (iParam0)
            {
                case 1:
                    Var0 = "MP_PROP_1" /* GXT: Eclipse Towers, Apt 31 */;
                    break;

                case 2:
                    Var0 = "MP_PROP_2" /* GXT: Eclipse Towers, Apt 9 */;
                    break;

                case 3:
                    Var0 = "MP_PROP_3" /* GXT: Eclipse Towers, Apt 40 */;
                    break;

                case 4:
                    Var0 = "MP_PROP_4" /* GXT: Eclipse Towers, Apt 5 */;
                    break;

                case 5:
                    Var0 = "MP_PROP_5" /* GXT: 3 Alta St, Apt 10 */;
                    break;

                case 6:
                    Var0 = "MP_PROP_6" /* GXT: 3 Alta St, Apt 57 */;
                    break;

                case 7:
                    Var0 = "MP_PROP_7" /* GXT: Del Perro Heights, Apt 20 */;
                    break;

                case 8:
                    Var0 = "MP_PROP_8" /* GXT: 1162 Power St, Apt 3 */;
                    break;

                case 9:
                    Var0 = "MP_PROP_9" /* GXT: 0605 Spanish Ave, Apt 1 */;
                    break;

                case 10:
                    Var0 = "MP_PROP_10" /* GXT: 0604 Las Lagunas Blvd, Apt 4 */;
                    break;

                case 11:
                    Var0 = "MP_PROP_11" /* GXT: 0184 Milton Rd, Apt 13 */;
                    break;

                case 12:
                    Var0 = "MP_PROP_12" /* GXT: The Royale, Apt 19 */;
                    break;

                case 13:
                    Var0 = "MP_PROP_13" /* GXT: 0504 S Mo Milton Dr */;
                    break;

                case 14:
                    Var0 = "MP_PROP_14" /* GXT: 0115 Bay City Ave, Apt 45 */;
                    break;

                case 15:
                    Var0 = "MP_PROP_15" /* GXT: 0325 South Rockford Dr */;
                    break;

                case 16:
                    Var0 = "MP_PROP_16" /* GXT: Dream Tower, Apt 15 */;
                    break;

                case 17:
                    Var0 = "MP_PROP_17" /* GXT: 2143 Las Lagunas Blvd, Apt 9 */;
                    break;

                case 18:
                    Var0 = "MP_PROP_18" /* GXT: 1561 San Vitas St, Apt 2 */;
                    break;

                case 19:
                    Var0 = "MP_PROP_19" /* GXT: 0112 S Rockford Dr, Apt 13 */;
                    break;

                case 20:
                    Var0 = "MP_PROP_20" /* GXT: 2057 Vespucci Blvd, Apt 1 */;
                    break;

                case 21:
                    Var0 = "MP_PROP_21" /* GXT: 0069 Cougar Ave, Apt 19 */;
                    break;

                case 22:
                    Var0 = "MP_PROP_22" /* GXT: 1237 Prosperity St, Apt 21 */;
                    break;

                case 23:
                    Var0 = "MP_PROP_23" /* GXT: 1115 Blvd Del Perro, Apt 18 */;
                    break;

                case 24:
                    Var0 = "MP_PROP_24" /* GXT: 0120 Murrieta Heights */;
                    break;

                case 25:
                    Var0 = "MP_PROP_25" /* GXT: Unit 14 Popular St */;
                    break;

                case 26:
                    Var0 = "MP_PROP_26" /* GXT: Unit 2 Popular St */;
                    break;

                case 27:
                    Var0 = "MP_PROP_27" /* GXT: 331 Supply St */;
                    break;

                case 28:
                    Var0 = "MP_PROP_28" /* GXT: Unit 1 Olympic Fwy */;
                    break;

                case 29:
                    Var0 = "MP_PROP_29" /* GXT: 0754 Roy Lowenstein Blvd */;
                    break;

                case 30:
                    Var0 = "MP_PROP_30" /* GXT: 12 Little Bighorn Ave */;
                    break;

                case 31:
                    Var0 = "MP_PROP_31" /* GXT: Unit 124 Popular St */;
                    break;

                case 32:
                    Var0 = "MP_PROP_32" /* GXT: 0552 Roy Lowenstein Blvd */;
                    break;

                case 33:
                    Var0 = "MP_PROP_33" /* GXT: 0432 Davis Ave */;
                    break;

                case 34:
                    Var0 = "MP_PROP_34" /* GXT: Del Perro Heights, Apt 7 */;
                    break;

                case 35:
                    Var0 = "MP_PROP_35" /* GXT: Weazel Plaza, Apt 101 */;
                    break;

                case 36:
                    Var0 = "MP_PROP_36" /* GXT: Weazel Plaza, Apt 70 */;
                    break;

                case 37:
                    Var0 = "MP_PROP_37" /* GXT: Weazel Plaza, Apt 26 */;
                    break;

                case 38:
                    Var0 = "MP_PROP_38" /* GXT: 4 Integrity Way, Apt 30 */;
                    break;

                case 39:
                    Var0 = "MP_PROP_39" /* GXT: 4 Integrity Way, Apt 35 */;
                    break;

                case 40:
                    Var0 = "MP_PROP_40" /* GXT: Richards Majestic, Apt 4 */;
                    break;

                case 41:
                    Var0 = "MP_PROP_41" /* GXT: Richards Majestic, Apt 51 */;
                    break;

                case 42:
                    Var0 = "MP_PROP_42" /* GXT: Tinsel Towers, Apt 45 */;
                    break;

                case 43:
                    Var0 = "MP_PROP_43" /* GXT: Tinsel Towers, Apt 29 */;
                    break;

                case 44:
                    Var0 = "MP_PROP_44" /* GXT: 142 Paleto Blvd */;
                    break;

                case 45:
                    Var0 = "MP_PROP_45" /* GXT: 1 Strawberry Ave */;
                    break;

                case 46:
                    Var0 = "MP_PROP_46" /* GXT: 1932 Grapeseed Ave */;
                    break;

                case 47:
                    Var0 = "MP_PROP_48" /* GXT: 1920 Senora Way */;
                    break;

                case 48:
                    Var0 = "MP_PROP_49" /* GXT: 2000 Great Ocean Highway */;
                    break;

                case 49:
                    Var0 = "MP_PROP_50" /* GXT: 197 Route 68 */;
                    break;

                case 50:
                    Var0 = "MP_PROP_51" /* GXT: 870 Route 68 Approach */;
                    break;

                case 51:
                    Var0 = "MP_PROP_52" /* GXT: 1200 Route 68 */;
                    break;

                case 52:
                    Var0 = "MP_PROP_57" /* GXT: 8754 Route 68 */;
                    break;

                case 53:
                    Var0 = "MP_PROP_59" /* GXT: 1905 Davis Ave */;
                    break;

                case 54:
                    Var0 = "MP_PROP_60" /* GXT: 1623 South Shambles St */;
                    break;

                case 55:
                    Var0 = "MP_PROP_61" /* GXT: 4531 Dry Dock St */;
                    break;

                case 56:
                    Var0 = "MP_PROP_62" /* GXT: 1337 Exceptionalists Way */;
                    break;

                case 57:
                    Var0 = "MP_PROP_63" /* GXT: Unit 76 Greenwich Parkway */;
                    break;

                case 58:
                    Var0 = "MP_PROP_64" /* GXT: Garage Innocence Blvd */;
                    break;

                case 59:
                    Var0 = "MP_PROP_65" /* GXT: 634 Blvd Del Perro */;
                    break;

                case 60:
                    Var0 = "MP_PROP_66" /* GXT: 0897 Mirror Park Blvd */;
                    break;

                case 61:
                    Var0 = "MP_PROP_67" /* GXT: Eclipse Towers, Apt 3 */;
                    break;

                case 62:
                    Var0 = "MP_PROP_68" /* GXT: Del Perro Heights, Apt 4 */;
                    break;

                case 63:
                    Var0 = "MP_PROP_69" /* GXT: Richards Majestic, Apt 2 */;
                    break;

                case 64:
                    Var0 = "MP_PROP_70" /* GXT: Tinsel Towers, Apt 42 */;
                    break;

                case 65:
                    Var0 = "MP_PROP_71" /* GXT: 4 Integrity Way, Apt 28 */;
                    break;

                case 66:
                    Var0 = "MP_PROP_72" /* GXT: 4 Hangman Ave */;
                    break;

                case 67:
                    Var0 = "MP_PROP_73" /* GXT: 12 Sustancia Rd */;
                    break;

                case 68:
                    Var0 = "MP_PROP_74" /* GXT: 4584 Procopio Dr */;
                    break;

                case 69:
                    Var0 = "MP_PROP_75" /* GXT: 4401 Procopio Dr */;
                    break;

                case 70:
                    Var0 = "MP_PROP_76" /* GXT: 0232 Paleto Blvd */;
                    break;

                case 71:
                    Var0 = "MP_PROP_77" /* GXT: 140 Zancudo Ave */;
                    break;

                case 72:
                    Var0 = "MP_PROP_78" /* GXT: 1893 Grapeseed Ave */;
                    break;

                case 83:
                    Var0 = "MP_PROP_79" /* GXT: Eclipse Towers, Penthouse Suite 1 */;
                    break;

                case 84:
                    Var0 = "MP_PROP_80" /* GXT: Eclipse Towers, Penthouse Suite 2 */;
                    break;

                case 85:
                    Var0 = "MP_PROP_81" /* GXT: Eclipse Towers, Penthouse Suite 3 */;
                    break;

                case 73:
                    Var0 = "MP_PROP_83" /* GXT: 3655 Wild Oats Drive */;
                    break;

                case 74:
                    Var0 = "MP_PROP_84" /* GXT: 2044 North Conker Avenue */;
                    break;

                case 75:
                    Var0 = "MP_PROP_85" /* GXT: 2868 Hillcrest Avenue */;
                    break;

                case 76:
                    Var0 = "MP_PROP_86" /* GXT: 2862 Hillcrest Avenue */;
                    break;

                case 77:
                    Var0 = "MP_PROP_87" /* GXT: 3677 Whispymound Drive */;
                    break;

                case 78:
                    Var0 = "MP_PROP_89" /* GXT: 2117 Milton Road */;
                    break;

                case 79:
                    Var0 = "MP_PROP_90" /* GXT: 2866 Hillcrest Avenue */;
                    break;

                case 80:
                    Var0 = "MP_PROP_92" /* GXT: 2874 Hillcrest Avenue */;
                    break;

                case 81:
                    Var0 = "MP_PROP_94" /* GXT: 2113 Mad Wayne Thunder Drive */;
                    break;

                case 82:
                    Var0 = "MP_PROP_95" /* GXT: 2045 North Conker Avenue */;
                    break;

                case 86:
                    Var0 = "PM_SPAWN_Y" /* GXT: Private Yacht */;
                    break;

                case 87:
                    Var0 = "MP_PROP_OFF1" /* GXT: Lombank West */;
                    break;

                case 88:
                    Var0 = "MP_PROP_OFF2" /* GXT: Maze Bank West */;
                    break;

                case 89:
                    Var0 = "MP_PROP_OFF3" /* GXT: Arcadius Business Center */;
                    break;

                case 90:
                    Var0 = "MP_PROP_OFF4" /* GXT: Maze Bank Tower */;
                    break;

                case 91:
                    Var0 = "MP_PROP_CLUBH1" /* GXT: Rancho Clubhouse */;
                    break;

                case 92:
                    Var0 = "MP_PROP_CLUBH2" /* GXT: Del Perro Beach Clubhouse */;
                    break;

                case 93:
                    Var0 = "MP_PROP_CLUBH3" /* GXT: Pillbox Hill Clubhouse */;
                    break;

                case 94:
                    Var0 = "MP_PROP_CLUBH4" /* GXT: Great Chaparral Clubhouse */;
                    break;

                case 95:
                    Var0 = "MP_PROP_CLUBH5" /* GXT: Paleto Bay Clubhouse */;
                    break;

                case 96:
                    Var0 = "MP_PROP_CLUBH6" /* GXT: Sandy Shores Clubhouse */;
                    break;

                case 97:
                    Var0 = "MP_PROP_CLUBH7" /* GXT: La Mesa Clubhouse */;
                    break;

                case 98:
                    Var0 = "MP_PROP_CLUBH8" /* GXT: Downtown Vinewood Clubhouse */;
                    break;

                case 99:
                    Var0 = "MP_PROP_CLUBH9" /* GXT: Hawick Clubhouse */;
                    break;

                case 100:
                    Var0 = "MP_PROP_CLUBH10" /* GXT: Grapeseed Clubhouse */;
                    break;

                case 101:
                    Var0 = "MP_PROP_CLUBH11" /* GXT: Paleto Bay Clubhouse */;
                    break;

                case 102:
                    Var0 = "MP_PROP_CLUBH12" /* GXT: Vespucci Beach Clubhouse */;
                    break;

                case 103:
                case 106:
                case 109:
                case 112:
                    Var0 = "MP_PROP_OFFG1" /* GXT: Office Garage 1 */;
                    break;

                case 104:
                case 107:
                case 110:
                case 113:
                    Var0 = "MP_PROP_OFFG2" /* GXT: Office Garage 2 */;
                    break;

                case 105:
                case 108:
                case 111:
                case 114:
                    Var0 = "MP_PROP_OFFG3" /* GXT: Office Garage 3 */;
                    break;

                case 115:
                    Var0 = "IE_WARE_1" /* GXT: Vehicle Warehouse */;
                    break;
            }
            return Var0;
        }
        int func_67(int iParam0)//Position - 0x2239B
        {
            int iVar0;
            bool bVar1;
            string sVar2 = "";
            int iVar18;
            int iVar19;

            iVar0 = 0;
            bVar1 = false;
            if (func_5731(iParam0))
            {
                if (!func_5727(iParam0))
                {
                    iVar0 = 1;
                }
                else
                {
                    bVar1 = true;
                }
            }
            func_68(ref sVar2, iParam0, iVar0, bVar1);
            iVar18 = GetHashKey(sVar2);
            if (NetGameserverCatalogItemExistsHash((uint)iVar18))
            {
                iVar19 = NetGameserverGetPrice((uint)iVar18, (uint)GetHashKey("CATEGORY_PROPERTIE"), true);
                return iVar19;
            }

            return iParam0 switch
            {
                1 => Tunables.Global_262145.Value<int>("f_3960") /* Tunable: PROPERTY_HIGH_APT_1_EXPENDITURE_MODIFIER */,
                2 => Tunables.Global_262145.Value<int>("f_3961") /* Tunable: PROPERTY_HIGH_APT_2_EXPENDITURE_MODIFIER */,
                3 => Tunables.Global_262145.Value<int>("f_3962") /* Tunable: PROPERTY_HIGH_APT_3_EXPENDITURE_MODIFIER */,
                4 => Tunables.Global_262145.Value<int>("f_3963") /* Tunable: PROPERTY_HIGH_APT_4_EXPENDITURE_MODIFIER */,
                5 => Tunables.Global_262145.Value<int>("f_3964") /* Tunable: PROPERTY_HIGH_APT_5_EXPENDITURE_MODIFIER */,
                6 => Tunables.Global_262145.Value<int>("f_3965") /* Tunable: PROPERTY_HIGH_APT_6_EXPENDITURE_MODIFIER */,
                7 => Tunables.Global_262145.Value<int>("f_3966") /* Tunable: PROPERTY_HIGH_APT_7_EXPENDITURE_MODIFIER */,
                34 => Tunables.Global_262145.Value<int>("f_3967") /* Tunable: PROPERTY_HIGH_APT_8_EXPENDITURE_MODIFIER */,
                35 => Tunables.Global_262145.Value<int>("f_3968") /* Tunable: PROPERTY_HIGH_APT_9_EXPENDITURE_MODIFIER */,
                36 => Tunables.Global_262145.Value<int>("f_3969") /* Tunable: PROPERTY_HIGH_APT_10_EXPENDITURE_MODIFIER */,
                37 => Tunables.Global_262145.Value<int>("f_3970") /* Tunable: PROPERTY_HIGH_APT_11_EXPENDITURE_MODIFIER */,
                38 => Tunables.Global_262145.Value<int>("f_3971") /* Tunable: PROPERTY_HIGH_APT_12_EXPENDITURE_MODIFIER */,
                39 => Tunables.Global_262145.Value<int>("f_3972") /* Tunable: PROPERTY_HIGH_APT_13_EXPENDITURE_MODIFIER */,
                40 => Tunables.Global_262145.Value<int>("f_3973") /* Tunable: PROPERTY_HIGH_APT_14_EXPENDITURE_MODIFIER */,
                41 => Tunables.Global_262145.Value<int>("f_3974") /* Tunable: PROPERTY_HIGH_APT_15_EXPENDITURE_MODIFIER */,
                42 => Tunables.Global_262145.Value<int>("f_3975") /* Tunable: PROPERTY_HIGH_APT_16_EXPENDITURE_MODIFIER */,
                43 => Tunables.Global_262145.Value<int>("f_3976") /* Tunable: PROPERTY_HIGH_APT_17_EXPENDITURE_MODIFIER */,
                8 => Tunables.Global_262145.Value<int>("f_3977") /* Tunable: PROPERTY_MEDIUM_APT_1_EXPENDITURE_MODIFIER */,
                9 => Tunables.Global_262145.Value<int>("f_3978") /* Tunable: PROPERTY_MEDIUM_APT_2_EXPENDITURE_MODIFIER */,
                10 => Tunables.Global_262145.Value<int>("f_3979") /* Tunable: PROPERTY_MEDIUM_APT_3_EXPENDITURE_MODIFIER */,
                11 => Tunables.Global_262145.Value<int>("f_3980") /* Tunable: PROPERTY_MEDIUM_APT_4_EXPENDITURE_MODIFIER */,
                12 => Tunables.Global_262145.Value<int>("f_3981") /* Tunable: PROPERTY_MEDIUM_APT_5_EXPENDITURE_MODIFIER */,
                13 => Tunables.Global_262145.Value<int>("f_3982") /* Tunable: PROPERTY_MEDIUM_APT_6_EXPENDITURE_MODIFIER */,
                14 => Tunables.Global_262145.Value<int>("f_3983") /* Tunable: PROPERTY_MEDIUM_APT_7_EXPENDITURE_MODIFIER */,
                15 => Tunables.Global_262145.Value<int>("f_3984") /* Tunable: PROPERTY_MEDIUM_APT_8_EXPENDITURE_MODIFIER */,
                16 => Tunables.Global_262145.Value<int>("f_3985") /* Tunable: PROPERTY_MEDIUM_APT_9_EXPENDITURE_MODIFIER */,
                17 => Tunables.Global_262145.Value<int>("f_3986") /* Tunable: PROPERTY_LOW_APT_1_EXPENDITURE_MODIFIER */,
                18 => Tunables.Global_262145.Value<int>("f_3987") /* Tunable: PROPERTY_LOW_APT_2_EXPENDITURE_MODIFIER */,
                19 => Tunables.Global_262145.Value<int>("f_3988") /* Tunable: PROPERTY_LOW_APT_3_EXPENDITURE_MODIFIER */,
                20 => Tunables.Global_262145.Value<int>("f_3989") /* Tunable: PROPERTY_LOW_APT_4_EXPENDITURE_MODIFIER */,
                21 => Tunables.Global_262145.Value<int>("f_3990") /* Tunable: PROPERTY_LOW_APT_5_EXPENDITURE_MODIFIER */,
                22 => Tunables.Global_262145.Value<int>("f_3991") /* Tunable: PROPERTY_LOW_APT_6_EXPENDITURE_MODIFIER */,
                23 => Tunables.Global_262145.Value<int>("f_3992") /* Tunable: PROPERTY_LOW_APT_7_EXPENDITURE_MODIFIER */,
                24 => Tunables.Global_262145.Value<int>("f_3993") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_1_EXPENDITURE_MODIFIER */,
                25 => Tunables.Global_262145.Value<int>("f_3994") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_2_EXPENDITURE_MODIFIER */,
                26 => Tunables.Global_262145.Value<int>("f_3995") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_3_EXPENDITURE_MODIFIER */,
                27 => Tunables.Global_262145.Value<int>("f_3996") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_4_EXPENDITURE_MODIFIER */,
                28 => Tunables.Global_262145.Value<int>("f_3997") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_5_EXPENDITURE_MODIFIER */,
                29 => Tunables.Global_262145.Value<int>("f_3998") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_6_EXPENDITURE_MODIFIER */,
                30 => Tunables.Global_262145.Value<int>("f_3999") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_7_EXPENDITURE_MODIFIER */,
                31 => Tunables.Global_262145.Value<int>("f_4000") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_8_EXPENDITURE_MODIFIER */,
                32 => Tunables.Global_262145.Value<int>("f_4001") /* Tunable: PROPERTY_GARAGE_SOUTH_LOS_SANTOS_1_EXPENDITURE_MODIFIER */,
                33 => Tunables.Global_262145.Value<int>("f_4002") /* Tunable: PROPERTY_GARAGE_SOUTH_LOS_SANTOS_2_EXPENDITURE_MODIFIER */,
                44 => Tunables.Global_262145.Value<int>("f_4003") /* Tunable: PROPERTY_GARAGE_NEW_1_EXPENDITURE_MODIFIER */,
                45 => Tunables.Global_262145.Value<int>("f_4004") /* Tunable: PROPERTY_GARAGE_NEW_2_EXPENDITURE_MODIFIER */,
                46 => Tunables.Global_262145.Value<int>("f_4005") /* Tunable: PROPERTY_GARAGE_NEW_3_EXPENDITURE_MODIFIER */,
                47 => Tunables.Global_262145.Value<int>("f_4006") /* Tunable: PROPERTY_GARAGE_NEW_5_EXPENDITURE_MODIFIER */,
                48 => Tunables.Global_262145.Value<int>("f_4007") /* Tunable: PROPERTY_GARAGE_NEW_6_EXPENDITURE_MODIFIER */,
                49 => Tunables.Global_262145.Value<int>("f_4008") /* Tunable: PROPERTY_GARAGE_NEW_7_EXPENDITURE_MODIFIER */,
                50 => Tunables.Global_262145.Value<int>("f_4009") /* Tunable: PROPERTY_GARAGE_NEW_8_EXPENDITURE_MODIFIER */,
                51 => Tunables.Global_262145.Value<int>("f_4010") /* Tunable: PROPERTY_GARAGE_NEW_9_EXPENDITURE_MODIFIER */,
                52 => Tunables.Global_262145.Value<int>("f_4011") /* Tunable: PROPERTY_GARAGE_NEW_14_EXPENDITURE_MODIFIER */,
                53 => Tunables.Global_262145.Value<int>("f_4012") /* Tunable: PROPERTY_GARAGE_NEW_16_EXPENDITURE_MODIFIER */,
                54 => Tunables.Global_262145.Value<int>("f_4013") /* Tunable: PROPERTY_GARAGE_NEW_17_EXPENDITURE_MODIFIER */,
                55 => Tunables.Global_262145.Value<int>("f_4014") /* Tunable: PROPERTY_GARAGE_NEW_18_EXPENDITURE_MODIFIER */,
                56 => Tunables.Global_262145.Value<int>("f_4015") /* Tunable: PROPERTY_GARAGE_NEW_19_EXPENDITURE_MODIFIER */,
                57 => Tunables.Global_262145.Value<int>("f_4016") /* Tunable: PROPERTY_GARAGE_NEW_20_EXPENDITURE_MODIFIER */,
                58 => Tunables.Global_262145.Value<int>("f_4017") /* Tunable: PROPERTY_GARAGE_NEW_21_EXPENDITURE_MODIFIER */,
                59 => Tunables.Global_262145.Value<int>("f_4018") /* Tunable: PROPERTY_GARAGE_NEW_22_EXPENDITURE_MODIFIER */,
                60 => Tunables.Global_262145.Value<int>("f_4019") /* Tunable: PROPERTY_GARAGE_NEW_23_EXPENDITURE_MODIFIER */,
                61 => Tunables.Global_262145.Value<JArray>("f_7146").ToObject<List<int>>()[0],
                62 => Tunables.Global_262145.Value<JArray>("f_7146").ToObject<List<int>>()[1],
                63 => Tunables.Global_262145.Value<JArray>("f_7146").ToObject<List<int>>()[2],
                64 => Tunables.Global_262145.Value<JArray>("f_7146").ToObject<List<int>>()[3],
                65 => Tunables.Global_262145.Value<JArray>("f_7146").ToObject<List<int>>()[4],
                66 => Tunables.Global_262145.Value<int>("f_8461") /* Tunable: PROPERTY_3_ACE_JONES_DR */,
                67 => Tunables.Global_262145.Value<int>("f_8462") /* Tunable: PROPERTY_12_SUSTANCIA_RD */,
                68 => Tunables.Global_262145.Value<int>("f_8463") /* Tunable: PROPERTY_4584_PROCOPIO_DR */,
                69 => Tunables.Global_262145.Value<int>("f_8464") /* Tunable: PROPERTY_4401_PROCOPIO_DR */,
                70 => Tunables.Global_262145.Value<int>("f_8465") /* Tunable: PROPERTY_0232_PALETO_BLVD */,
                71 => Tunables.Global_262145.Value<int>("f_8466") /* Tunable: PROPERTY_140_ZANCUDO_AVE */,
                72 => Tunables.Global_262145.Value<int>("f_8467") /* Tunable: PROPERTY_1893_GRAPESEED_AVE */,
                73 => Tunables.Global_262145.Value<int>("f_13488") /* Tunable: APARTMENT_CAR_MODSSTILT_3655_WILD_OATS_DRIVE */,
                74 => Tunables.Global_262145.Value<int>("f_13489") /* Tunable: APARTMENT_CAR_MODSSTILT_2044_NORTH_CONKER_AVENUE */,
                75 => Tunables.Global_262145.Value<int>("f_13490") /* Tunable: APARTMENT_CAR_MODSSTILT_2868_HILLCREST_AVENUE */,
                76 => Tunables.Global_262145.Value<int>("f_13491") /* Tunable: APARTMENT_CAR_MODSSTILT_2862_HILLCREST_AVENUE */,
                77 => Tunables.Global_262145.Value<int>("f_13492") /* Tunable: APARTMENT_CAR_MODSSTILT_3677_WHISPYMOUND_DRIVE */,
                78 => Tunables.Global_262145.Value<int>("f_13493") /* Tunable: APARTMENT_CAR_MODSSTILT_2117_MILTON_ROAD */,
                79 => Tunables.Global_262145.Value<int>("f_13494") /* Tunable: APARTMENT_CAR_MODSSTILT_2866_HILLCREST_AVENUE */,
                80 => Tunables.Global_262145.Value<int>("f_13495") /* Tunable: APARTMENT_CAR_MODSSTILT_2874_HILLCREST_AVENUE */,
                81 => Tunables.Global_262145.Value<int>("f_13496") /* Tunable: APARTMENT_CAR_MODSSTILT_2113_MAD_WAYNE_THUNDER_DRIVE */,
                82 => Tunables.Global_262145.Value<int>("f_13497") /* Tunable: APARTMENT_CAR_MODSSTILT_2045_NORTH_CONKER_AVENUE */,
                83 => Tunables.Global_262145.Value<int>("f_13485") /* Tunable: APARTMENT_CAR_MODSECLIPSE_TOWERS_PENTHOUSE_SUITE_1 */,
                84 => Tunables.Global_262145.Value<int>("f_13486") /* Tunable: APARTMENT_CAR_MODSECLIPSE_TOWERS_PENTHOUSE_SUITE_2 */,
                85 => Tunables.Global_262145.Value<int>("f_13487") /* Tunable: APARTMENT_CAR_MODSECLIPSE_TOWERS_PENTHOUSE_SUITE_3 */,
                86 => 27000000,
                87 => Tunables.Global_262145.Value<int>("f_16072") /* Tunable: EXEC1_OFFICE1_LOMBANK */,
                88 => Tunables.Global_262145.Value<int>("f_16073") /* Tunable: EXEC1_OFFICE2_MAZE1 */,
                89 => Tunables.Global_262145.Value<int>("f_16074") /* Tunable: EXEC1_OFFICE3_ARCADIUS */,
                90 => Tunables.Global_262145.Value<int>("f_16075") /* Tunable: EXEC1_OFFICE4_MAZE2 */,
                91 => Tunables.Global_262145.Value<int>("f_18167") /* Tunable: 819519215 */,
                92 => Tunables.Global_262145.Value<int>("f_18169") /* Tunable: 471352940 */,
                93 => Tunables.Global_262145.Value<int>("f_18165") /* Tunable: 2023136086 */,
                94 => Tunables.Global_262145.Value<int>("f_18174") /* Tunable: 217858651 */,
                95 => Tunables.Global_262145.Value<int>("f_18171") /* Tunable: -1058611921 */,
                96 => Tunables.Global_262145.Value<int>("f_18173") /* Tunable: -1767762009 */,
                97 => Tunables.Global_262145.Value<int>("f_18166") /* Tunable: -1390109608 */,
                98 => Tunables.Global_262145.Value<int>("f_18164") /* Tunable: 2033735347 */,
                99 => Tunables.Global_262145.Value<int>("f_18163") /* Tunable: -1219608517 */,
                100 => Tunables.Global_262145.Value<int>("f_18172") /* Tunable: 1669688233 */,
                101 => Tunables.Global_262145.Value<int>("f_18170") /* Tunable: 1241258301 */,
                102 => Tunables.Global_262145.Value<int>("f_18168") /* Tunable: 813618473 */,
                103 => Tunables.Global_262145.Value<int>("f_19835") /* Tunable: IMPEXP_GARAGE_LEVEL1 */,
                104 => Tunables.Global_262145.Value<int>("f_19728") /* Tunable: IMPEXP_GARAGE_LEVEL2_COST */,
                105 => Tunables.Global_262145.Value<int>("f_19729") /* Tunable: IMPEXP_GARAGE_LEVEL3_COST */,
                106 => Tunables.Global_262145.Value<int>("f_19835") /* Tunable: IMPEXP_GARAGE_LEVEL1 */,
                107 => Tunables.Global_262145.Value<int>("f_19728") /* Tunable: IMPEXP_GARAGE_LEVEL2_COST */,
                108 => Tunables.Global_262145.Value<int>("f_19729") /* Tunable: IMPEXP_GARAGE_LEVEL3_COST */,
                109 => Tunables.Global_262145.Value<int>("f_19835") /* Tunable: IMPEXP_GARAGE_LEVEL1 */,
                110 => Tunables.Global_262145.Value<int>("f_19728") /* Tunable: IMPEXP_GARAGE_LEVEL2_COST */,
                111 => Tunables.Global_262145.Value<int>("f_19729") /* Tunable: IMPEXP_GARAGE_LEVEL3_COST */,
                112 => Tunables.Global_262145.Value<int>("f_19835") /* Tunable: IMPEXP_GARAGE_LEVEL1 */,
                113 => Tunables.Global_262145.Value<int>("f_19728") /* Tunable: IMPEXP_GARAGE_LEVEL2_COST */,
                114 => Tunables.Global_262145.Value<int>("f_19729") /* Tunable: IMPEXP_GARAGE_LEVEL3_COST */,
                115 => 3000000,
                _ => 0,
            };
        }

        void func_68(ref string sParam0, int iParam1, int iParam2, bool bParam3)//Position - 0x22C36
        {

            //StringCopy(sParam0, "FACTORY_INDEX_", 64);
            string Var0 = func_66(iParam1);
            sParam0 = $"PR_{Var0}_t0_v{iParam2}{(bParam3 ? "_CESP" : "")}";
        }
        string func_66(int iParam0)//Position - 0x21C48
        {

            string Var0 = "";

            switch (iParam0)
            {
                case 1:
                    Var0 = "MP_PROP_1" /* GXT: Eclipse Towers, Apt 31 */;
                    break;

                case 2:
                    Var0 = "MP_PROP_2" /* GXT: Eclipse Towers, Apt 9 */;
                    break;

                case 3:
                    Var0 = "MP_PROP_3" /* GXT: Eclipse Towers, Apt 40 */;
                    break;

                case 4:
                    Var0 = "MP_PROP_4" /* GXT: Eclipse Towers, Apt 5 */;
                    break;

                case 5:
                    Var0 = "MP_PROP_5" /* GXT: 3 Alta St, Apt 10 */;
                    break;

                case 6:
                    Var0 = "MP_PROP_6" /* GXT: 3 Alta St, Apt 57 */;
                    break;

                case 7:
                    Var0 = "MP_PROP_7" /* GXT: Del Perro Heights, Apt 20 */;
                    break;

                case 8:
                    Var0 = "MP_PROP_8" /* GXT: 1162 Power St, Apt 3 */;
                    break;

                case 9:
                    Var0 = "MP_PROP_9" /* GXT: 0605 Spanish Ave, Apt 1 */;
                    break;

                case 10:
                    Var0 = "MP_PROP_10" /* GXT: 0604 Las Lagunas Blvd, Apt 4 */;
                    break;

                case 11:
                    Var0 = "MP_PROP_11" /* GXT: 0184 Milton Rd, Apt 13 */;
                    break;

                case 12:
                    Var0 = "MP_PROP_12" /* GXT: The Royale, Apt 19 */;
                    break;

                case 13:
                    Var0 = "MP_PROP_13" /* GXT: 0504 S Mo Milton Dr */;
                    break;

                case 14:
                    Var0 = "MP_PROP_14" /* GXT: 0115 Bay City Ave, Apt 45 */;
                    break;

                case 15:
                    Var0 = "MP_PROP_15" /* GXT: 0325 South Rockford Dr */;
                    break;

                case 16:
                    Var0 = "MP_PROP_16" /* GXT: Dream Tower, Apt 15 */;
                    break;

                case 17:
                    Var0 = "MP_PROP_17" /* GXT: 2143 Las Lagunas Blvd, Apt 9 */;
                    break;

                case 18:
                    Var0 = "MP_PROP_18" /* GXT: 1561 San Vitas St, Apt 2 */;
                    break;

                case 19:
                    Var0 = "MP_PROP_19" /* GXT: 0112 S Rockford Dr, Apt 13 */;
                    break;

                case 20:
                    Var0 = "MP_PROP_20" /* GXT: 2057 Vespucci Blvd, Apt 1 */;
                    break;

                case 21:
                    Var0 = "MP_PROP_21" /* GXT: 0069 Cougar Ave, Apt 19 */;
                    break;

                case 22:
                    Var0 = "MP_PROP_22" /* GXT: 1237 Prosperity St, Apt 21 */;
                    break;

                case 23:
                    Var0 = "MP_PROP_23" /* GXT: 1115 Blvd Del Perro, Apt 18 */;
                    break;

                case 24:
                    Var0 = "MP_PROP_24" /* GXT: 0120 Murrieta Heights */;
                    break;

                case 25:
                    Var0 = "MP_PROP_25" /* GXT: Unit 14 Popular St */;
                    break;

                case 26:
                    Var0 = "MP_PROP_26" /* GXT: Unit 2 Popular St */;
                    break;

                case 27:
                    Var0 = "MP_PROP_27" /* GXT: 331 Supply St */;
                    break;

                case 28:
                    Var0 = "MP_PROP_28" /* GXT: Unit 1 Olympic Fwy */;
                    break;

                case 29:
                    Var0 = "MP_PROP_29" /* GXT: 0754 Roy Lowenstein Blvd */;
                    break;

                case 30:
                    Var0 = "MP_PROP_30" /* GXT: 12 Little Bighorn Ave */;
                    break;

                case 31:
                    Var0 = "MP_PROP_31" /* GXT: Unit 124 Popular St */;
                    break;

                case 32:
                    Var0 = "MP_PROP_32" /* GXT: 0552 Roy Lowenstein Blvd */;
                    break;

                case 33:
                    Var0 = "MP_PROP_33" /* GXT: 0432 Davis Ave */;
                    break;

                case 34:
                    Var0 = "MP_PROP_34" /* GXT: Del Perro Heights, Apt 7 */;
                    break;

                case 35:
                    Var0 = "MP_PROP_35" /* GXT: Weazel Plaza, Apt 101 */;
                    break;

                case 36:
                    Var0 = "MP_PROP_36" /* GXT: Weazel Plaza, Apt 70 */;
                    break;

                case 37:
                    Var0 = "MP_PROP_37" /* GXT: Weazel Plaza, Apt 26 */;
                    break;

                case 38:
                    Var0 = "MP_PROP_38" /* GXT: 4 Integrity Way, Apt 30 */;
                    break;

                case 39:
                    Var0 = "MP_PROP_39" /* GXT: 4 Integrity Way, Apt 35 */;
                    break;

                case 40:
                    Var0 = "MP_PROP_40" /* GXT: Richards Majestic, Apt 4 */;
                    break;

                case 41:
                    Var0 = "MP_PROP_41" /* GXT: Richards Majestic, Apt 51 */;
                    break;

                case 42:
                    Var0 = "MP_PROP_42" /* GXT: Tinsel Towers, Apt 45 */;
                    break;

                case 43:
                    Var0 = "MP_PROP_43" /* GXT: Tinsel Towers, Apt 29 */;
                    break;

                case 44:
                    Var0 = "MP_PROP_44" /* GXT: 142 Paleto Blvd */;
                    break;

                case 45:
                    Var0 = "MP_PROP_45" /* GXT: 1 Strawberry Ave */;
                    break;

                case 46:
                    Var0 = "MP_PROP_46" /* GXT: 1932 Grapeseed Ave */;
                    break;

                case 47:
                    Var0 = "MP_PROP_48" /* GXT: 1920 Senora Way */;
                    break;

                case 48:
                    Var0 = "MP_PROP_49" /* GXT: 2000 Great Ocean Highway */;
                    break;

                case 49:
                    Var0 = "MP_PROP_50" /* GXT: 197 Route 68 */;
                    break;

                case 50:
                    Var0 = "MP_PROP_51" /* GXT: 870 Route 68 Approach */;
                    break;

                case 51:
                    Var0 = "MP_PROP_52" /* GXT: 1200 Route 68 */;
                    break;

                case 52:
                    Var0 = "MP_PROP_57" /* GXT: 8754 Route 68 */;
                    break;

                case 53:
                    Var0 = "MP_PROP_59" /* GXT: 1905 Davis Ave */;
                    break;

                case 54:
                    Var0 = "MP_PROP_60" /* GXT: 1623 South Shambles St */;
                    break;

                case 55:
                    Var0 = "MP_PROP_61" /* GXT: 4531 Dry Dock St */;
                    break;

                case 56:
                    Var0 = "MP_PROP_62" /* GXT: 1337 Exceptionalists Way */;
                    break;

                case 57:
                    Var0 = "MP_PROP_63" /* GXT: Unit 76 Greenwich Parkway */;
                    break;

                case 58:
                    Var0 = "MP_PROP_64" /* GXT: Garage Innocence Blvd */;
                    break;

                case 59:
                    Var0 = "MP_PROP_65" /* GXT: 634 Blvd Del Perro */;
                    break;

                case 60:
                    Var0 = "MP_PROP_66" /* GXT: 0897 Mirror Park Blvd */;
                    break;

                case 61:
                    Var0 = "MP_PROP_67" /* GXT: Eclipse Towers, Apt 3 */;
                    break;

                case 62:
                    Var0 = "MP_PROP_68" /* GXT: Del Perro Heights, Apt 4 */;
                    break;

                case 63:
                    Var0 = "MP_PROP_69" /* GXT: Richards Majestic, Apt 2 */;
                    break;

                case 64:
                    Var0 = "MP_PROP_70" /* GXT: Tinsel Towers, Apt 42 */;
                    break;

                case 65:
                    Var0 = "MP_PROP_71" /* GXT: 4 Integrity Way, Apt 28 */;
                    break;

                case 66:
                    Var0 = "MP_PROP_72" /* GXT: 4 Hangman Ave */;
                    break;

                case 67:
                    Var0 = "MP_PROP_73" /* GXT: 12 Sustancia Rd */;
                    break;

                case 68:
                    Var0 = "MP_PROP_74" /* GXT: 4584 Procopio Dr */;
                    break;

                case 69:
                    Var0 = "MP_PROP_75" /* GXT: 4401 Procopio Dr */;
                    break;

                case 70:
                    Var0 = "MP_PROP_76" /* GXT: 0232 Paleto Blvd */;
                    break;

                case 71:
                    Var0 = "MP_PROP_77" /* GXT: 140 Zancudo Ave */;
                    break;

                case 72:
                    Var0 = "MP_PROP_78" /* GXT: 1893 Grapeseed Ave */;
                    break;

                case 83:
                    Var0 = "MP_PROP_79" /* GXT: Eclipse Towers, Penthouse Suite 1 */;
                    break;

                case 84:
                    Var0 = "MP_PROP_80" /* GXT: Eclipse Towers, Penthouse Suite 2 */;
                    break;

                case 85:
                    Var0 = "MP_PROP_81" /* GXT: Eclipse Towers, Penthouse Suite 3 */;
                    break;

                case 73:
                    Var0 = "MP_PROP_83" /* GXT: 3655 Wild Oats Drive */;
                    break;

                case 74:
                    Var0 = "MP_PROP_84" /* GXT: 2044 North Conker Avenue */;
                    break;

                case 75:
                    Var0 = "MP_PROP_85" /* GXT: 2868 Hillcrest Avenue */;
                    break;

                case 76:
                    Var0 = "MP_PROP_86" /* GXT: 2862 Hillcrest Avenue */;
                    break;

                case 77:
                    Var0 = "MP_PROP_87" /* GXT: 3677 Whispymound Drive */;
                    break;

                case 78:
                    Var0 = "MP_PROP_89" /* GXT: 2117 Milton Road */;
                    break;

                case 79:
                    Var0 = "MP_PROP_90" /* GXT: 2866 Hillcrest Avenue */;
                    break;

                case 80:
                    Var0 = "MP_PROP_92" /* GXT: 2874 Hillcrest Avenue */;
                    break;

                case 81:
                    Var0 = "MP_PROP_94" /* GXT: 2113 Mad Wayne Thunder Drive */;
                    break;

                case 82:
                    Var0 = "MP_PROP_95" /* GXT: 2045 North Conker Avenue */;
                    break;

                case 86:
                    Var0 = "PM_SPAWN_Y" /* GXT: Private Yacht */;
                    break;

                case 87:
                    Var0 = "MP_PROP_OFF1" /* GXT: Lombank West */;
                    break;

                case 88:
                    Var0 = "MP_PROP_OFF2" /* GXT: Maze Bank West */;
                    break;

                case 89:
                    Var0 = "MP_PROP_OFF3" /* GXT: Arcadius Business Center */;
                    break;

                case 90:
                    Var0 = "MP_PROP_OFF4" /* GXT: Maze Bank Tower */;
                    break;

                case 91:
                    Var0 = "MP_PROP_CLUBH1" /* GXT: Rancho Clubhouse */;
                    break;

                case 92:
                    Var0 = "MP_PROP_CLUBH2" /* GXT: Del Perro Beach Clubhouse */;
                    break;

                case 93:
                    Var0 = "MP_PROP_CLUBH3" /* GXT: Pillbox Hill Clubhouse */;
                    break;

                case 94:
                    Var0 = "MP_PROP_CLUBH4" /* GXT: Great Chaparral Clubhouse */;
                    break;

                case 95:
                    Var0 = "MP_PROP_CLUBH5" /* GXT: Paleto Bay Clubhouse */;
                    break;

                case 96:
                    Var0 = "MP_PROP_CLUBH6" /* GXT: Sandy Shores Clubhouse */;
                    break;

                case 97:
                    Var0 = "MP_PROP_CLUBH7" /* GXT: La Mesa Clubhouse */;
                    break;

                case 98:
                    Var0 = "MP_PROP_CLUBH8" /* GXT: Downtown Vinewood Clubhouse */;
                    break;

                case 99:
                    Var0 = "MP_PROP_CLUBH9" /* GXT: Hawick Clubhouse */;
                    break;

                case 100:
                    Var0 = "MP_PROP_CLUBH10" /* GXT: Grapeseed Clubhouse */;
                    break;

                case 101:
                    Var0 = "MP_PROP_CLUBH11" /* GXT: Paleto Bay Clubhouse */;
                    break;

                case 102:
                    Var0 = "MP_PROP_CLUBH12" /* GXT: Vespucci Beach Clubhouse */;
                    break;

                case 103:
                case 106:
                case 109:
                case 112:
                    Var0 = "MP_PROP_OFFG1" /* GXT: Office Garage 1 */;
                    break;

                case 104:
                case 107:
                case 110:
                case 113:
                    Var0 = "MP_PROP_OFFG2" /* GXT: Office Garage 2 */;
                    break;

                case 105:
                case 108:
                case 111:
                case 114:
                    Var0 = "MP_PROP_OFFG3" /* GXT: Office Garage 3 */;
                    break;

                case 115:
                    Var0 = "IE_WARE_1" /* GXT: Vehicle Warehouse */;
                    break;
            }
            return Var0;
        }



        int func_6347(int iParam0, int iParam1)//Position - 0x1FF37B
        {
            int iVar0;
            string sVar1 = "";
            int iVar17;
            int iVar18;


            iVar0 = 0;
            func_5589(ref sVar1, iParam0, iParam1, iVar0);
            iVar17 = GetHashKey(sVar1);
            if (NetGameserverCatalogItemExistsHash((uint)iVar17))
            {
                iVar18 = NetGameserverGetPrice((uint)iVar17, (uint)GetHashKey("CATEGORY_PROPERTY_INTERIOR"), true);
                return iVar18;
            }

            if (func_5591(iParam1) == 83)
            {
                switch (iParam0)
                {
                    case 0:
                        return Tunables.Global_262145.Value<int>("f_13498") /* Tunable: APARTMENT_CAR_MODSHIGH_END_INTERIOR_MODERN */;

                    case 1:
                        return Tunables.Global_262145.Value<int>("f_13499") /* Tunable: APARTMENT_CAR_MODSHIGH_END_INTERIOR_MOODY */;

                    case 2:
                        return Tunables.Global_262145.Value<int>("f_13500") /* Tunable: APARTMENT_CAR_MODSHIGH_END_INTERIOR_VIBRANT */;

                    case 3:
                        return Tunables.Global_262145.Value<int>("f_13501") /* Tunable: APARTMENT_CAR_MODSHIGH_END_INTERIOR_SHARP */;

                    case 4:
                        return Tunables.Global_262145.Value<int>("f_13502") /* Tunable: APARTMENT_CAR_MODSHIGH_END_INTERIOR_MONOCHROME */;

                    case 5:
                        return Tunables.Global_262145.Value<int>("f_13503") /* Tunable: APARTMENT_CAR_MODSHIGH_END_INTERIOR_SEDUCTIVE */;

                    case 6:
                        return Tunables.Global_262145.Value<int>("f_13504") /* Tunable: APARTMENT_CAR_MODSHIGH_END_INTERIOR_REGAL */;

                    case 7:
                        return Tunables.Global_262145.Value<int>("f_13505") /* Tunable: APARTMENT_CAR_MODSHIGH_END_INTERIOR_AQUA */;
                }
            }
            else if (func_5591(iParam1) == 88)
            {
                switch (iParam0)
                {
                    case 0:
                        return Tunables.Global_262145.Value<int>("f_16079") /* Tunable: DYNASTY8_OFFICE_DECOR_WARM */;

                    case 1:
                        return Tunables.Global_262145.Value<int>("f_16080") /* Tunable: DYNASTY8_OFFICE_DECOR_CLASSICAL */;

                    case 2:
                        return Tunables.Global_262145.Value<int>("f_16081") /* Tunable: DYNASTY8_OFFICE_DECOR_VINTAGE */;

                    case 3:
                        return Tunables.Global_262145.Value<int>("f_16078") /* Tunable: DYNASTY8_OFFICE_DECOR_CONTRAST */;

                    case 4:
                        return Tunables.Global_262145.Value<int>("f_16076") /* Tunable: DYNASTY8_OFFICE_DECOR_RICH */;

                    case 5:
                        return Tunables.Global_262145.Value<int>("f_16077") /* Tunable: DYNASTY8_OFFICE_DECOR_COOL */;

                    case 6:
                        return Tunables.Global_262145.Value<int>("f_16082") /* Tunable: DYNASTY8_OFFICE_DECOR_ICE */;

                    case 7:
                        return Tunables.Global_262145.Value<int>("f_16083") /* Tunable: DYNASTY8_OFFICE_DECOR_CONSERVATIVE */;

                    case 8:
                        return Tunables.Global_262145.Value<int>("f_16084") /* Tunable: DYNASTY8_OFFICE_DECOR_POLISHED */;
                }
            }
            else if (func_5591(iParam1) == 91 || func_5591(iParam1) == 97)
            {
                switch (iParam0)
                {
                    case 0:
                        return Tunables.Global_262145.Value<int>("f_18175") /* Tunable: BIKER_CLUBHOUSE_MURAL_1 */;

                    case 1:
                        return Tunables.Global_262145.Value<int>("f_18176") /* Tunable: BIKER_CLUBHOUSE_MURAL_2 */;

                    case 2:
                        return Tunables.Global_262145.Value<int>("f_18177") /* Tunable: BIKER_CLUBHOUSE_MURAL_3 */;

                    case 3:
                        return Tunables.Global_262145.Value<int>("f_18178") /* Tunable: BIKER_CLUBHOUSE_MURAL_4 */;

                    case 4:
                        return Tunables.Global_262145.Value<int>("f_18179") /* Tunable: BIKER_CLUBHOUSE_MURAL_5 */;

                    case 5:
                        return Tunables.Global_262145.Value<int>("f_18180") /* Tunable: BIKER_CLUBHOUSE_MURAL_6 */;

                    case 6:
                        return Tunables.Global_262145.Value<int>("f_18181") /* Tunable: BIKER_CLUBHOUSE_MURAL_7 */;

                    case 7:
                        return Tunables.Global_262145.Value<int>("f_18182") /* Tunable: BIKER_CLUBHOUSE_MURAL_8 */;

                    case 8:
                        return Tunables.Global_262145.Value<int>("f_18183") /* Tunable: BIKER_CLUBHOUSE_MURAL_9 */;
                }
            }
            else if (func_5591(iParam1) == 109)
            {
                switch (iParam0)
                {
                    case 0:
                        return Tunables.Global_262145.Value<int>("f_19730") /* Tunable: IMPEXP_GARAGE_INTERIOR1_COST */;

                    case 1:
                        return Tunables.Global_262145.Value<int>("f_19731") /* Tunable: IMPEXP_GARAGE_INTERIOR2_COST */;

                    case 2:
                        return Tunables.Global_262145.Value<int>("f_19732") /* Tunable: IMPEXP_GARAGE_INTERIOR3_COST */;

                    case 3:
                        return Tunables.Global_262145.Value<int>("f_19733") /* Tunable: IMPEXP_GARAGE_INTERIOR4_COST */;
                }
            }
            return 0;
        }
        int func_5591(int iParam0)//Position - 0x1CDAF5
        {
            return iParam0 switch
            {
                1 or 2 or 3 or 4 or 5 or 6 or 7 => 1,
                8 or 9 or 10 or 11 or 12 or 13 or 14 or 15 or 16 or 69 or 68 or 66 or 67 => 8,
                17 or 18 or 19 or 20 or 21 or 22 or 23 or 70 or 71 or 72 => 17,
                61 or 62 or 63 or 64 or 65 => 61,
                73 or 74 or 75 or 76 => 73,
                77 or 78 or 79 or 80 or 81 or 82 => 77,
                83 or 84 or 85 => 83,
                86 => 86,
                87 or 88 or 89 or 90 => 88,
                91 or 92 or 93 or 94 or 95 or 96 => 91,
                97 or 98 or 99 or 100 or 101 or 102 => 97,
                103 or 106 or 109 or 112 or 104 or 107 or 110 or 113 or 105 or 108 or 111 or 114 => 109,
                _ => -1,
            };
        }

        void func_5589(ref string sParam0, int iParam1, int iParam2, int iParam3)//Position - 0x1CD84F
        {
            sParam0 = $"PR_{func_5590(iParam1, iParam2)}_t{iParam3}_v0";
        }

        string func_5590(int iParam0, int iParam1)//Position - 0x1CD889
        {
            if (func_5591(iParam1) == 83)
            {
                switch (iParam0)
                {
                    case 0:
                        return "PM_APT_VAR_0" /* GXT: Modern */;
                    case 1:
                        return "PM_APT_VAR_1" /* GXT: Moody */;
                    case 2:
                        return "PM_APT_VAR_2" /* GXT: Vibrant */;
                    case 3:
                        return "PM_APT_VAR_3" /* GXT: Sharp */;
                    case 4:
                        return "PM_APT_VAR_4" /* GXT: Monochrome */;
                    case 5:
                        return "PM_APT_VAR_5" /* GXT: Seductive */;
                    case 6:
                        return "PM_APT_VAR_6" /* GXT: Regal */;
                    case 7:
                        return "PM_APT_VAR_7" /* GXT: Aqua */;
                }
            }
            else if (func_5591(iParam1) == 88)
            {
                switch (iParam0)
                {
                    case 0:
                        return "PM_OFF_VAR_3" /* GXT: Old Spice: Warm */;
                    case 1:
                        return "PM_OFF_VAR_4" /* GXT: Old Spice: Classical */;
                    case 2:
                        return "PM_OFF_VAR_5" /* GXT: Old Spice: Vintage */;
                    case 3:
                        return "PM_OFF_VAR_2" /* GXT: Executive: Contrast */;
                    case 4:
                        return "PM_OFF_VAR_0" /* GXT: Executive: Rich */;
                    case 5:
                        return "PM_OFF_VAR_1" /* GXT: Executive: Cool */;
                    case 6:
                        return "PM_OFF_VAR_6" /* GXT: Power Broker: Ice */;
                    case 7:
                        return "PM_OFF_VAR_7" /* GXT: Power Broker: Conservative */;
                    case 8:
                        return "PM_OFF_VAR_8" /* GXT: Power Broker: Polished */;
                }
            }
            else if (func_5591(iParam1) == 91 || func_5591(iParam1) == 97)
            {
                switch (iParam0)
                {
                    case 0:
                        return "FC_MURAL_0" /* GXT: Mural 1 */;
                    case 1:
                        return "FC_MURAL_1" /* GXT: Mural 2 */;
                    case 2:
                        return "FC_MURAL_2" /* GXT: Mural 3 */;
                    case 3:
                        return "FC_MURAL_3" /* GXT: Mural 4 */;
                    case 4:
                        return "FC_MURAL_4" /* GXT: Mural 5 */;
                    case 5:
                        return "FC_MURAL_5" /* GXT: Mural 6 */;
                    case 6:
                        return "FC_MURAL_6" /* GXT: Mural 7 */;
                    case 7:
                        return "FC_MURAL_7" /* GXT: Mural 8 */;
                    case 8:
                        return "FC_MURAL_8" /* GXT: Mural 9 */;
                }
            }
            else if (func_5591(iParam1) == 109)
            {
                switch (iParam0)
                {
                    case 0:
                        return "PM_OFF_GAR_0" /* GXT: Garage Interior 1 */;
                    case 1:
                        return "PM_OFF_GAR_1" /* GXT: Garage Interior 2 */;
                    case 2:
                        return "PM_OFF_GAR_2" /* GXT: Garage Interior 3 */;
                    case 3:
                        return "PM_OFF_GAR_3" /* GXT: Garage Interior 4 */;
                }
            }
            return "NONE" /* GXT: None */;
        }
        int func_6346(int iParam0, int iParam1)//Position - 0x1FF18B
        {
            if (func_5591(iParam1) == 83)
            {
                switch (iParam0)
                {
                    case 0:
                        return 280000;

                    case 1:
                        return 235000;

                    case 2:
                        return 220000;

                    case 3:
                        return 325000;

                    case 4:
                        return 295000;

                    case 5:
                        return 250000;

                    case 6:
                        return 265000;

                    case 7:
                        return 310000;

                }
            }
            else if (func_5591(iParam1) == 88)
            {
                switch (iParam0)
                {
                    case 0:
                        return 950000;

                    case 1:
                        return 685000;

                    case 2:
                        return 760000;

                    case 3:
                        return 500000;

                    case 4:
                        return 300000;

                    case 5:
                        return 415000;

                    case 6:
                        return 1000000;

                    case 7:
                        return 835000;

                    case 8:
                        return 910000;

                }
            }
            else if (func_5591(iParam1) == 91 || func_5591(iParam1) == 97)
            {
                switch (iParam0)
                {
                    case 0:
                        return 80000;

                    case 1:
                        return 86500;

                    case 2:
                        return 93000;

                    case 3:
                        return 99500;

                    case 4:
                        return 106000;

                    case 5:
                        return 112500;

                    case 6:
                        return 119000;

                    case 7:
                        return 132000;

                    case 8:
                        return 150000;

                }
            }
            else if (func_5591(iParam1) == 109)
            {
                switch (iParam0)
                {
                    case 0:
                        return 150000;

                    case 1:
                        return 285000;

                    case 2:
                        return 415000;

                    case 3:
                        return 500000;
                }

            }
            return 0;
        }
        int func_5722(int iParam0, int iParam1)//Position - 0x1D3723
        {
            switch (iParam0)
            {
                case 0:
                    return 0;

                case 1:
                    if (iParam1 == 0)
                    {
                        return Tunables.Global_262145.Value<int>("f_16085") /* Tunable: DYNASTY8_OFFICE_PERSONNEL_FEMALE */;
                    }
                    else if (iParam1 == 1)
                    {
                        return Tunables.Global_262145.Value<int>("f_16086") /* Tunable: DYNASTY8_OFFICE_PERSONNEL_MALE */;
                    }
                    return 0;

                case 2:
                    return Tunables.Global_262145.Value<int>("f_16950") /* Tunable: DYNASTY8_OFFICE_FONT_COST */;

                case 3:
                    return 0;

                case 4:
                    return Tunables.Global_262145.Value<int>("f_16087") /* Tunable: DYNASTY8_OFFICE_GUNLOCKER */;

                case 5:
                    return Tunables.Global_262145.Value<int>("f_16088") /* Tunable: DYNASTY8_OFFICE_VAULT */;

                case 6:
                    return Tunables.Global_262145.Value<int>("f_16089") /* Tunable: DYNASTY8_OFFICE_ACCOMMODATION */;

                case 7:
                    return Tunables.Global_262145.Value<int>("f_16071") /* Tunable: EXEC1_RENAME_ORGANIZATION */;

                case 8:
                case 10:
                case 12:
                    return iParam1 switch
                    {
                        0 => Tunables.Global_262145.Value<int>("f_19734") /* Tunable: IMPEXP_GARAGE_LIGHTING1_COST */,
                        1 => Tunables.Global_262145.Value<int>("f_19735") /* Tunable: IMPEXP_GARAGE_LIGHTING2_COST */,
                        2 => Tunables.Global_262145.Value<int>("f_19736") /* Tunable: IMPEXP_GARAGE_LIGHTING3_COST */,
                        3 => Tunables.Global_262145.Value<int>("f_19737") /* Tunable: IMPEXP_GARAGE_LIGHTING4_COST */,
                        4 => Tunables.Global_262145.Value<int>("f_19738") /* Tunable: IMPEXP_GARAGE_LIGHTING5_COST */,
                        5 => Tunables.Global_262145.Value<int>("f_19739") /* Tunable: IMPEXP_GARAGE_LIGHTING6_COST */,
                        6 => Tunables.Global_262145.Value<int>("f_19740") /* Tunable: IMPEXP_GARAGE_LIGHTING7_COST */,
                        7 => Tunables.Global_262145.Value<int>("f_19741") /* Tunable: IMPEXP_GARAGE_LIGHTING8_COST */,
                        8 => Tunables.Global_262145.Value<int>("f_19742") /* Tunable: IMPEXP_GARAGE_LIGHTING9_COST */,
                        _ => 0,
                    };

                case 9:
                case 11:
                case 13:
                    return iParam1 switch
                    {
                        0 => Tunables.Global_262145.Value<int>("f_19743") /* Tunable: IMPEXP_GARAGE_SIGNAGE1_COST */,
                        1 => Tunables.Global_262145.Value<int>("f_19744") /* Tunable: IMPEXP_GARAGE_SIGNAGE2_COST */,
                        2 => Tunables.Global_262145.Value<int>("f_19745") /* Tunable: IMPEXP_GARAGE_SIGNAGE3_COST */,
                        3 => Tunables.Global_262145.Value<int>("f_19746") /* Tunable: IMPEXP_GARAGE_SIGNAGE4_COST */,
                        4 => Tunables.Global_262145.Value<int>("f_19747") /* Tunable: IMPEXP_GARAGE_SIGNAGE5_COST */,
                        5 => Tunables.Global_262145.Value<int>("f_19748") /* Tunable: IMPEXP_GARAGE_SIGNAGE6_COST */,
                        6 => Tunables.Global_262145.Value<int>("f_19749") /* Tunable: IMPEXP_GARAGE_SIGNAGE7_COST */,
                        7 => Tunables.Global_262145.Value<int>("f_19750") /* Tunable: IMPEXP_GARAGE_SIGNAGE8_COST */,
                        8 => Tunables.Global_262145.Value<int>("f_19751") /* Tunable: IMPEXP_GARAGE_SIGNAGE9_COST */,
                        _ => 0,
                    };

                case 14:
                    return iParam1 switch
                    {
                        0 => 0,
                        1 => Tunables.Global_262145.Value<int>("f_19752") /* Tunable: IMPEXP_MODSHOP_FLOORING1_PURCHASE_COST */,
                        2 => Tunables.Global_262145.Value<int>("f_19753") /* Tunable: IMPEXP_MODSHOP_FLOORING2_PURCHASE_COST */,
                        3 => Tunables.Global_262145.Value<int>("f_19754") /* Tunable: IMPEXP_MODSHOP_FLOORING3_PURCHASE_COST */,
                        4 => Tunables.Global_262145.Value<int>("f_19755") /* Tunable: IMPEXP_MODSHOP_FLOORING4_PURCHASE_COST */,
                        5 => Tunables.Global_262145.Value<int>("f_19756") /* Tunable: IMPEXP_MODSHOP_FLOORING5_PURCHASE_COST */,
                        6 => Tunables.Global_262145.Value<int>("f_19757") /* Tunable: IMPEXP_MODSHOP_FLOORING6_PURCHASE_COST */,
                        7 => Tunables.Global_262145.Value<int>("f_19758") /* Tunable: IMPEXP_MODSHOP_FLOORING7_PURCHASE_COST */,
                        8 => Tunables.Global_262145.Value<int>("f_19759") /* Tunable: IMPEXP_MODSHOP_FLOORING8_PURCHASE_COST */,
                        9 => Tunables.Global_262145.Value<int>("f_19760") /* Tunable: IMPEXP_MODSHOP_FLOORING9_PURCHASE_COST */,
                        10 => Tunables.Global_262145.Value<int>("f_19761") /* Tunable: IMPEXP_MODSHOP_FLOORING10_PURCHASE_COST */,
                        11 => Tunables.Global_262145.Value<int>("f_19762") /* Tunable: IMPEXP_MODSHOP_FLOORING11_PURCHASE_COST */,
                        12 => Tunables.Global_262145.Value<int>("f_19763") /* Tunable: IMPEXP_MODSHOP_FLOORING12_PURCHASE_COST */,
                        13 => Tunables.Global_262145.Value<int>("f_19764") /* Tunable: IMPEXP_MODSHOP_FLOORING13_PURCHASE_COST */,
                        14 => Tunables.Global_262145.Value<int>("f_19765") /* Tunable: IMPEXP_MODSHOP_FLOORING14_PURCHASE_COST */,
                        15 => Tunables.Global_262145.Value<int>("f_19766") /* Tunable: IMPEXP_MODSHOP_FLOORING15_PURCHASE_COST */,
                        16 => Tunables.Global_262145.Value<int>("f_19767") /* Tunable: IMPEXP_MODSHOP_FLOORING16_PURCHASE_COST */,
                        17 => Tunables.Global_262145.Value<int>("f_19768") /* Tunable: IMPEXP_MODSHOP_FLOORING17_PURCHASE_COST */,
                        18 => Tunables.Global_262145.Value<int>("f_19769") /* Tunable: IMPEXP_MODSHOP_FLOORING18_PURCHASE_COST */,
                        19 => Tunables.Global_262145.Value<int>("f_19770") /* Tunable: IMPEXP_MODSHOP_FLOORING19_PURCHASE_COST */,
                        20 => Tunables.Global_262145.Value<int>("f_19771") /* Tunable: IMPEXP_MODSHOP_FLOORING20_PURCHASE_COST */,
                        _ => 0,
                    };
            }
            return 0;
        }
        int func_6348(int iParam0, int iParam1)//Position - 0x1FF623
        {
            switch (iParam0)
            {
                case 0:
                    return 0;

                case 1:
                    if (iParam1 == 0)
                    {
                        return 150000;
                    }
                    else if (iParam1 == 1)
                    {
                        return 150000;
                    }
                    return 0;

                case 2:
                    return 50000;

                case 3:
                    return 0;

                case 4:
                    return 520000;

                case 5:
                    return 335000;

                case 6:
                    return 795000;

                case 7:
                    return 50000;

                case 8:
                case 10:
                case 12:
                    return iParam1 switch
                    {
                        0 => 75000,
                        1 => 81500,
                        2 => 85000,
                        3 => 87500,
                        4 => 92500,
                        5 => 99500,
                        6 => 105000,
                        7 => 127500,
                        8 => 150000,
                        _ => 0,
                    };

                case 9:
                case 11:
                case 13:
                    return iParam1 switch
                    {
                        0 => 50000,
                        1 => 62500,
                        2 => 75000,
                        3 => 87500,
                        4 => 100000,
                        5 => 132500,
                        6 => 165000,
                        7 => 197500,
                        8 => 250000,
                        _ => 0,
                    };
                case 14:
                    return iParam1 switch
                    {
                        0 => 0,
                        1 => 100000,
                        2 => 120000,
                        3 => 132500,
                        4 => 145000,
                        5 => 157500,
                        6 => 170000,
                        7 => 182500,
                        8 => 195000,
                        9 => 207500,
                        10 => 220000,
                        11 => 245000,
                        12 => 270000,
                        13 => 295000,
                        14 => 320000,
                        15 => 345000,
                        16 => 370000,
                        17 => 395000,
                        18 => 420000,
                        19 => 465000,
                        20 => 500000,
                        _ => 0,
                    };
            }
            return 0;
        }
        string func_7346(int iParam0)//Position - 0x26B83E
        {
            return iParam0 switch
            {
                87 => "MP_GAR_96DES" /* GXT: This is what your collection deserves: an enormous, air-conditioned, humidity-controlled, hyper-secure storage facility for up to 60 vehicles, surging up the main shaft of your city-center office cock. Block. Whatever. */,
                88 => "MP_GAR_97DES" /* GXT: This is what your collection deserves: an enormous, air-conditioned, humidity-controlled, hyper-secure storage facility for up to 60 vehicles, surging up the main shaft of your city-center office cock. Block. Whatever. */,
                89 => "MP_GAR_98DES" /* GXT: This is what your collection deserves: an enormous, air-conditioned, humidity-controlled, hyper-secure storage facility for up to 60 vehicles, surging up the main shaft of your city-center office cock. Block. Whatever. */,
                90 => "MP_GAR_99DES" /* GXT: This is what your collection deserves: an enormous, air-conditioned, humidity-controlled, hyper-secure storage facility for up to 60 vehicles, surging up the main shaft of your city-center office cock. Block. Whatever. */,
                _ => "",
            };
        }
        int func_7353(int iParam0, int iParam1, int iParam2)//Position - 0x26BAE2
        {
            int iVar0;

            iVar0 = func_6348(iParam1, iParam2);
            switch (iParam0)
            {
                case 103:
                case 106:
                case 109:
                case 112:
                    if (iParam2 == 0)
                    {
                        iVar0 = 0;
                    }
                    else if (iParam1 == 8)
                    {
                        if (func_5587(iParam2) == func_67(5308))
                        {
                            iVar0 = 0;
                        }
                    }
                    else if (iParam1 == 9)
                    {
                        if (func_5583(iParam2) == func_67(5309))
                        {
                            iVar0 = 0;
                        }
                    }
                    break;

                case 104:
                case 107:
                case 110:
                case 113:
                    if (iParam2 == 0)
                    {
                        iVar0 = 0;
                    }
                    else if (iParam1 == 10)
                    {
                        if (func_5587(iParam2) == func_67(5310))
                        {
                            iVar0 = 0;
                        }
                    }
                    else if (iParam1 == 11)
                    {
                        if (func_5583(iParam2) == func_67(5311))
                        {
                            iVar0 = 0;
                        }
                    }
                    break;

                case 105:
                case 108:
                case 111:
                case 114:
                    if (iParam2 == 0)
                    {
                        iVar0 = 0;
                    }
                    else if (iParam1 == 12)
                    {
                        if (func_5587(iParam2) == func_67(5312))
                        {
                            iVar0 = 0;
                        }
                    }
                    else if (iParam1 == 13)
                    {
                        if (func_5583(iParam2) == func_67(5313))
                        {
                            iVar0 = 0;
                        }
                    }
                    break;
            }
            return iVar0;
        }

        int func_7354(int iParam0, int iParam1)//Position - 0x26BC35
        {
            int iVar0;
            int iVar1;

            iVar0 = 0;
            iVar1 = func_6347(iParam0, iParam1);
            switch (iParam1)
            {
                case 103:
                case 106:
                case 109:
                case 112:
                    iVar0 = func_6628(iParam1);
                    if (iParam0 == 0)
                    {
                        iVar1 = 0;
                    }
                    else if (func_5593(iParam0) == 1)
                    {
                        iVar1 = 0;
                    }
                    break;

                case 104:
                case 107:
                case 110:
                case 113:
                    iVar0 = func_6628(iParam1);
                    if (iParam0 == 0)
                    {
                        iVar1 = 0;
                    }
                    else if (func_5593(iParam0) == 1)
                    {
                        iVar1 = 0;
                    }
                    break;

                case 105:
                case 108:
                case 111:
                case 114:
                    iVar0 = func_6628(iParam1);
                    if (iParam0 == 0)
                    {
                        iVar1 = 0;
                    }
                    else if (func_5593(iParam0) == 1)
                    {
                        iVar1 = 0;
                    }
                    break;
            }
            return (iVar0 + iVar1);
        }

        int func_7355(int iParam0, int iParam1)//Position - 0x26BD34
        {
            int iVar0;
            int iVar1;

            iVar0 = 0;
            iVar1 = func_6346(iParam0, iParam1);
            switch (iParam1)
            {
                case 103:
                case 106:
                case 109:
                case 112:
                    iVar0 = func_6663(iParam1);
                    if (iParam0 == 0)
                    {
                        iVar1 = 0;
                    }

                    else if (func_5593(iParam0) == 1)
                    {
                        iVar1 = 0;
                    }
                    break;

                case 104:
                case 107:
                case 110:
                case 113:
                    iVar0 = func_6663(iParam1);
                    if (iParam0 == 0)
                    {
                        iVar1 = 0;
                    }
                    else if (func_5593(iParam0) == 1)
                    {
                        iVar1 = 0;
                    }
                    break;

                case 105:
                case 108:
                case 111:
                case 114:
                    iVar0 = func_6663(iParam1);
                    if (iParam0 == 0)
                    {
                        iVar1 = 0;
                    }
                    else if (func_5593(iParam0) == 1)
                    {
                        iVar1 = 0;
                    }
                    break;
            }
            return (iVar0 + iVar1);
        }
        int func_7356(int iParam0)//Position - 0x26BE33
        {
            switch (iParam0)
            {
                case 87:
                    return func_6628(103);

                case 88:
                    return func_6628(106);

                case 89:
                    return func_6628(109);

                case 90:
                    return func_6628(112);
            }
            return 0;
        }
        int func_7357(int iParam0)//Position - 0x26BE7F
        {
            switch (iParam0)
            {
                case 87:
                    return func_6663(103);

                case 88:
                    return func_6663(106);

                case 89:
                    return func_6663(109);

                case 90:
                    return func_6663(112);
            }
            return 0;
        }
        int func_5593(int iParam0)//Position - 0x1CDD62
        {
            if (iParam0 == 0)
            {
                return 1;
            }
            else if (iParam0 == 1)
            {
                return 2;
            }
            else if (iParam0 == 2)
            {
                return 4;
            }
            else if (iParam0 == 3)
            {
                return 3;
            }
            return 1;
        }
        int func_6628(int iParam0)//Position - 0x20F426
        {
            int iVar0;
            bool bVar1;
            string sVar2 = "";
            int iVar18;
            int iVar19;

            iVar0 = 0;
            bVar1 = false;
            if (func_5731(iParam0))
            {
                if (!func_5727(iParam0))
                {
                    iVar0 = 1;
                }
                else
                {
                    bVar1 = true;
                }
            }
            func_5725(ref sVar2, iParam0, iVar0, bVar1);
            iVar18 = GetHashKey(sVar2);
            if (NetGameserverCatalogItemExistsHash((uint)iVar18))
            {
                iVar19 = NetGameserverGetPrice((uint)iVar18, (uint)GetHashKey("CATEGORY_PROPERTIE"), true);
                return iVar19;
            }

            return iParam0 switch
            {
                1 => Tunables.Global_262145.Value<int>("f_3960") /* Tunable: PROPERTY_HIGH_APT_1_EXPENDITURE_MODIFIER */,
                2 => Tunables.Global_262145.Value<int>("f_3961") /* Tunable: PROPERTY_HIGH_APT_2_EXPENDITURE_MODIFIER */,
                3 => Tunables.Global_262145.Value<int>("f_3962") /* Tunable: PROPERTY_HIGH_APT_3_EXPENDITURE_MODIFIER */,
                4 => Tunables.Global_262145.Value<int>("f_3963") /* Tunable: PROPERTY_HIGH_APT_4_EXPENDITURE_MODIFIER */,
                5 => Tunables.Global_262145.Value<int>("f_3964") /* Tunable: PROPERTY_HIGH_APT_5_EXPENDITURE_MODIFIER */,
                6 => Tunables.Global_262145.Value<int>("f_3965") /* Tunable: PROPERTY_HIGH_APT_6_EXPENDITURE_MODIFIER */,
                7 => Tunables.Global_262145.Value<int>("f_3966") /* Tunable: PROPERTY_HIGH_APT_7_EXPENDITURE_MODIFIER */,
                34 => Tunables.Global_262145.Value<int>("f_3967") /* Tunable: PROPERTY_HIGH_APT_8_EXPENDITURE_MODIFIER */,
                35 => Tunables.Global_262145.Value<int>("f_3968") /* Tunable: PROPERTY_HIGH_APT_9_EXPENDITURE_MODIFIER */,
                36 => Tunables.Global_262145.Value<int>("f_3969") /* Tunable: PROPERTY_HIGH_APT_10_EXPENDITURE_MODIFIER */,
                37 => Tunables.Global_262145.Value<int>("f_3970") /* Tunable: PROPERTY_HIGH_APT_11_EXPENDITURE_MODIFIER */,
                38 => Tunables.Global_262145.Value<int>("f_3971") /* Tunable: PROPERTY_HIGH_APT_12_EXPENDITURE_MODIFIER */,
                39 => Tunables.Global_262145.Value<int>("f_3972") /* Tunable: PROPERTY_HIGH_APT_13_EXPENDITURE_MODIFIER */,
                40 => Tunables.Global_262145.Value<int>("f_3973") /* Tunable: PROPERTY_HIGH_APT_14_EXPENDITURE_MODIFIER */,
                41 => Tunables.Global_262145.Value<int>("f_3974") /* Tunable: PROPERTY_HIGH_APT_15_EXPENDITURE_MODIFIER */,
                42 => Tunables.Global_262145.Value<int>("f_3975") /* Tunable: PROPERTY_HIGH_APT_16_EXPENDITURE_MODIFIER */,
                43 => Tunables.Global_262145.Value<int>("f_3976") /* Tunable: PROPERTY_HIGH_APT_17_EXPENDITURE_MODIFIER */,
                8 => Tunables.Global_262145.Value<int>("f_3977") /* Tunable: PROPERTY_MEDIUM_APT_1_EXPENDITURE_MODIFIER */,
                9 => Tunables.Global_262145.Value<int>("f_3978") /* Tunable: PROPERTY_MEDIUM_APT_2_EXPENDITURE_MODIFIER */,
                10 => Tunables.Global_262145.Value<int>("f_3979") /* Tunable: PROPERTY_MEDIUM_APT_3_EXPENDITURE_MODIFIER */,
                11 => Tunables.Global_262145.Value<int>("f_3980") /* Tunable: PROPERTY_MEDIUM_APT_4_EXPENDITURE_MODIFIER */,
                12 => Tunables.Global_262145.Value<int>("f_3981") /* Tunable: PROPERTY_MEDIUM_APT_5_EXPENDITURE_MODIFIER */,
                13 => Tunables.Global_262145.Value<int>("f_3982") /* Tunable: PROPERTY_MEDIUM_APT_6_EXPENDITURE_MODIFIER */,
                14 => Tunables.Global_262145.Value<int>("f_3983") /* Tunable: PROPERTY_MEDIUM_APT_7_EXPENDITURE_MODIFIER */,
                15 => Tunables.Global_262145.Value<int>("f_3984") /* Tunable: PROPERTY_MEDIUM_APT_8_EXPENDITURE_MODIFIER */,
                16 => Tunables.Global_262145.Value<int>("f_3985") /* Tunable: PROPERTY_MEDIUM_APT_9_EXPENDITURE_MODIFIER */,
                17 => Tunables.Global_262145.Value<int>("f_3986") /* Tunable: PROPERTY_LOW_APT_1_EXPENDITURE_MODIFIER */,
                18 => Tunables.Global_262145.Value<int>("f_3987") /* Tunable: PROPERTY_LOW_APT_2_EXPENDITURE_MODIFIER */,
                19 => Tunables.Global_262145.Value<int>("f_3988") /* Tunable: PROPERTY_LOW_APT_3_EXPENDITURE_MODIFIER */,
                20 => Tunables.Global_262145.Value<int>("f_3989") /* Tunable: PROPERTY_LOW_APT_4_EXPENDITURE_MODIFIER */,
                21 => Tunables.Global_262145.Value<int>("f_3990") /* Tunable: PROPERTY_LOW_APT_5_EXPENDITURE_MODIFIER */,
                22 => Tunables.Global_262145.Value<int>("f_3991") /* Tunable: PROPERTY_LOW_APT_6_EXPENDITURE_MODIFIER */,
                23 => Tunables.Global_262145.Value<int>("f_3992") /* Tunable: PROPERTY_LOW_APT_7_EXPENDITURE_MODIFIER */,
                24 => Tunables.Global_262145.Value<int>("f_3993") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_1_EXPENDITURE_MODIFIER */,
                25 => Tunables.Global_262145.Value<int>("f_3994") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_2_EXPENDITURE_MODIFIER */,
                26 => Tunables.Global_262145.Value<int>("f_3995") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_3_EXPENDITURE_MODIFIER */,
                27 => Tunables.Global_262145.Value<int>("f_3996") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_4_EXPENDITURE_MODIFIER */,
                28 => Tunables.Global_262145.Value<int>("f_3997") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_5_EXPENDITURE_MODIFIER */,
                29 => Tunables.Global_262145.Value<int>("f_3998") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_6_EXPENDITURE_MODIFIER */,
                30 => Tunables.Global_262145.Value<int>("f_3999") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_7_EXPENDITURE_MODIFIER */,
                31 => Tunables.Global_262145.Value<int>("f_4000") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_8_EXPENDITURE_MODIFIER */,
                32 => Tunables.Global_262145.Value<int>("f_4001") /* Tunable: PROPERTY_GARAGE_SOUTH_LOS_SANTOS_1_EXPENDITURE_MODIFIER */,
                33 => Tunables.Global_262145.Value<int>("f_4002") /* Tunable: PROPERTY_GARAGE_SOUTH_LOS_SANTOS_2_EXPENDITURE_MODIFIER */,
                44 => Tunables.Global_262145.Value<int>("f_4003") /* Tunable: PROPERTY_GARAGE_NEW_1_EXPENDITURE_MODIFIER */,
                45 => Tunables.Global_262145.Value<int>("f_4004") /* Tunable: PROPERTY_GARAGE_NEW_2_EXPENDITURE_MODIFIER */,
                46 => Tunables.Global_262145.Value<int>("f_4005") /* Tunable: PROPERTY_GARAGE_NEW_3_EXPENDITURE_MODIFIER */,
                47 => Tunables.Global_262145.Value<int>("f_4006") /* Tunable: PROPERTY_GARAGE_NEW_5_EXPENDITURE_MODIFIER */,
                48 => Tunables.Global_262145.Value<int>("f_4007") /* Tunable: PROPERTY_GARAGE_NEW_6_EXPENDITURE_MODIFIER */,
                49 => Tunables.Global_262145.Value<int>("f_4008") /* Tunable: PROPERTY_GARAGE_NEW_7_EXPENDITURE_MODIFIER */,
                50 => Tunables.Global_262145.Value<int>("f_4009") /* Tunable: PROPERTY_GARAGE_NEW_8_EXPENDITURE_MODIFIER */,
                51 => Tunables.Global_262145.Value<int>("f_4010") /* Tunable: PROPERTY_GARAGE_NEW_9_EXPENDITURE_MODIFIER */,
                52 => Tunables.Global_262145.Value<int>("f_4011") /* Tunable: PROPERTY_GARAGE_NEW_14_EXPENDITURE_MODIFIER */,
                53 => Tunables.Global_262145.Value<int>("f_4012") /* Tunable: PROPERTY_GARAGE_NEW_16_EXPENDITURE_MODIFIER */,
                54 => Tunables.Global_262145.Value<int>("f_4013") /* Tunable: PROPERTY_GARAGE_NEW_17_EXPENDITURE_MODIFIER */,
                55 => Tunables.Global_262145.Value<int>("f_4014") /* Tunable: PROPERTY_GARAGE_NEW_18_EXPENDITURE_MODIFIER */,
                56 => Tunables.Global_262145.Value<int>("f_4015") /* Tunable: PROPERTY_GARAGE_NEW_19_EXPENDITURE_MODIFIER */,
                57 => Tunables.Global_262145.Value<int>("f_4016") /* Tunable: PROPERTY_GARAGE_NEW_20_EXPENDITURE_MODIFIER */,
                58 => Tunables.Global_262145.Value<int>("f_4017") /* Tunable: PROPERTY_GARAGE_NEW_21_EXPENDITURE_MODIFIER */,
                59 => Tunables.Global_262145.Value<int>("f_4018") /* Tunable: PROPERTY_GARAGE_NEW_22_EXPENDITURE_MODIFIER */,
                60 => Tunables.Global_262145.Value<int>("f_4019") /* Tunable: PROPERTY_GARAGE_NEW_23_EXPENDITURE_MODIFIER */,
                61 => Tunables.Global_262145.Value<JArray>("f_7146").ToObject<List<int>>()[0],
                62 => Tunables.Global_262145.Value<JArray>("f_7146").ToObject<List<int>>()[1],
                63 => Tunables.Global_262145.Value<JArray>("f_7146").ToObject<List<int>>()[2],
                64 => Tunables.Global_262145.Value<JArray>("f_7146").ToObject<List<int>>()[3],
                65 => Tunables.Global_262145.Value<JArray>("f_7146").ToObject<List<int>>()[4],
                66 => Tunables.Global_262145.Value<int>("f_8461") /* Tunable: PROPERTY_3_ACE_JONES_DR */,
                67 => Tunables.Global_262145.Value<int>("f_8462") /* Tunable: PROPERTY_12_SUSTANCIA_RD */,
                68 => Tunables.Global_262145.Value<int>("f_8463") /* Tunable: PROPERTY_4584_PROCOPIO_DR */,
                69 => Tunables.Global_262145.Value<int>("f_8464") /* Tunable: PROPERTY_4401_PROCOPIO_DR */,
                70 => Tunables.Global_262145.Value<int>("f_8465") /* Tunable: PROPERTY_0232_PALETO_BLVD */,
                71 => Tunables.Global_262145.Value<int>("f_8466") /* Tunable: PROPERTY_140_ZANCUDO_AVE */,
                72 => Tunables.Global_262145.Value<int>("f_8467") /* Tunable: PROPERTY_1893_GRAPESEED_AVE */,
                73 => Tunables.Global_262145.Value<int>("f_13488") /* Tunable: APARTMENT_CAR_MODSSTILT_3655_WILD_OATS_DRIVE */,
                74 => Tunables.Global_262145.Value<int>("f_13489") /* Tunable: APARTMENT_CAR_MODSSTILT_2044_NORTH_CONKER_AVENUE */,
                75 => Tunables.Global_262145.Value<int>("f_13490") /* Tunable: APARTMENT_CAR_MODSSTILT_2868_HILLCREST_AVENUE */,
                76 => Tunables.Global_262145.Value<int>("f_13491") /* Tunable: APARTMENT_CAR_MODSSTILT_2862_HILLCREST_AVENUE */,
                77 => Tunables.Global_262145.Value<int>("f_13492") /* Tunable: APARTMENT_CAR_MODSSTILT_3677_WHISPYMOUND_DRIVE */,
                78 => Tunables.Global_262145.Value<int>("f_13493") /* Tunable: APARTMENT_CAR_MODSSTILT_2117_MILTON_ROAD */,
                79 => Tunables.Global_262145.Value<int>("f_13494") /* Tunable: APARTMENT_CAR_MODSSTILT_2866_HILLCREST_AVENUE */,
                80 => Tunables.Global_262145.Value<int>("f_13495") /* Tunable: APARTMENT_CAR_MODSSTILT_2874_HILLCREST_AVENUE */,
                81 => Tunables.Global_262145.Value<int>("f_13496") /* Tunable: APARTMENT_CAR_MODSSTILT_2113_MAD_WAYNE_THUNDER_DRIVE */,
                82 => Tunables.Global_262145.Value<int>("f_13497") /* Tunable: APARTMENT_CAR_MODSSTILT_2045_NORTH_CONKER_AVENUE */,
                83 => Tunables.Global_262145.Value<int>("f_13485") /* Tunable: APARTMENT_CAR_MODSECLIPSE_TOWERS_PENTHOUSE_SUITE_1 */,
                84 => Tunables.Global_262145.Value<int>("f_13486") /* Tunable: APARTMENT_CAR_MODSECLIPSE_TOWERS_PENTHOUSE_SUITE_2 */,
                85 => Tunables.Global_262145.Value<int>("f_13487") /* Tunable: APARTMENT_CAR_MODSECLIPSE_TOWERS_PENTHOUSE_SUITE_3 */,
                86 => 27000000,
                87 => Tunables.Global_262145.Value<int>("f_16072") /* Tunable: EXEC1_OFFICE1_LOMBANK */,
                88 => Tunables.Global_262145.Value<int>("f_16073") /* Tunable: EXEC1_OFFICE2_MAZE1 */,
                89 => Tunables.Global_262145.Value<int>("f_16074") /* Tunable: EXEC1_OFFICE3_ARCADIUS */,
                90 => Tunables.Global_262145.Value<int>("f_16075") /* Tunable: EXEC1_OFFICE4_MAZE2 */,
                91 => Tunables.Global_262145.Value<int>("f_18167") /* Tunable: 819519215 */,
                92 => Tunables.Global_262145.Value<int>("f_18169") /* Tunable: 471352940 */,
                93 => Tunables.Global_262145.Value<int>("f_18165") /* Tunable: 2023136086 */,
                94 => Tunables.Global_262145.Value<int>("f_18174") /* Tunable: 217858651 */,
                95 => Tunables.Global_262145.Value<int>("f_18171") /* Tunable: -1058611921 */,
                96 => Tunables.Global_262145.Value<int>("f_18173") /* Tunable: -1767762009 */,
                97 => Tunables.Global_262145.Value<int>("f_18166") /* Tunable: -1390109608 */,
                98 => Tunables.Global_262145.Value<int>("f_18164") /* Tunable: 2033735347 */,
                99 => Tunables.Global_262145.Value<int>("f_18163") /* Tunable: -1219608517 */,
                100 => Tunables.Global_262145.Value<int>("f_18172") /* Tunable: 1669688233 */,
                101 => Tunables.Global_262145.Value<int>("f_18170") /* Tunable: 1241258301 */,
                102 => Tunables.Global_262145.Value<int>("f_18168") /* Tunable: 813618473 */,
                103 => Tunables.Global_262145.Value<int>("f_19835") /* Tunable: IMPEXP_GARAGE_LEVEL1 */,
                104 => Tunables.Global_262145.Value<int>("f_19728") /* Tunable: IMPEXP_GARAGE_LEVEL2_COST */,
                105 => Tunables.Global_262145.Value<int>("f_19729") /* Tunable: IMPEXP_GARAGE_LEVEL3_COST */,
                106 => Tunables.Global_262145.Value<int>("f_19835") /* Tunable: IMPEXP_GARAGE_LEVEL1 */,
                107 => Tunables.Global_262145.Value<int>("f_19728") /* Tunable: IMPEXP_GARAGE_LEVEL2_COST */,
                108 => Tunables.Global_262145.Value<int>("f_19729") /* Tunable: IMPEXP_GARAGE_LEVEL3_COST */,
                109 => Tunables.Global_262145.Value<int>("f_19835") /* Tunable: IMPEXP_GARAGE_LEVEL1 */,
                110 => Tunables.Global_262145.Value<int>("f_19728") /* Tunable: IMPEXP_GARAGE_LEVEL2_COST */,
                111 => Tunables.Global_262145.Value<int>("f_19729") /* Tunable: IMPEXP_GARAGE_LEVEL3_COST */,
                112 => Tunables.Global_262145.Value<int>("f_19835") /* Tunable: IMPEXP_GARAGE_LEVEL1 */,
                113 => Tunables.Global_262145.Value<int>("f_19728") /* Tunable: IMPEXP_GARAGE_LEVEL2_COST */,
                114 => Tunables.Global_262145.Value<int>("f_19729") /* Tunable: IMPEXP_GARAGE_LEVEL3_COST */,
                115 => 3000000,
                _ => 0,
            };
        }
        int func_6663(int iParam0)//Position - 0x211CCE
        {
            return iParam0 switch
            {
                1 => 400000,
                2 => 373000,
                3 => 391000,
                4 => 382000,
                5 => 217000,
                6 => 223000,
                7 => 205000,
                34 => 200000,
                35 => 335000,
                36 => 319000,
                37 => 304000,
                38 => 235000,
                39 => 247000,
                40 => 241000,
                41 => 253000,
                42 => 270000,
                43 => 286000,
                8 => 130000,
                9 => 128000,
                10 => 126000,
                11 => 146000,
                12 => 125000,
                13 => 141000,
                14 => 150000,
                15 => 137000,
                16 => 134000,
                17 => 115000,
                18 => 99000,
                19 => 80000,
                20 => 87000,
                21 => 112000,
                22 => 105000,
                23 => 93000,
                24 => 150000,
                25 => 77500,
                26 => 142500,
                27 => 135000,
                28 => 70000,
                29 => 29500,
                30 => 32000,
                31 => 25000,
                32 => 80000,
                33 => 72500,
                44 => 26500,
                45 => 26000,
                46 => 27500,
                47 => 32000,
                48 => 31500,
                49 => 29000,
                50 => 62500,
                51 => 28000,
                52 => 65000,
                53 => 75000,
                54 => 105000,
                55 => 67500,
                56 => 112500,
                57 => 120000,
                58 => 34000,
                59 => 33500,
                60 => 35000,
                61 => 500000,
                62 => 468000,
                63 => 484000,
                64 => 492000,
                65 => 476000,
                66 => 175000,
                67 => 143000,
                68 => 155000,
                69 => 165000,
                70 => 121000,
                71 => 120000,
                72 => 118000,
                73 => 800000,
                74 => 762000,
                75 => 672000,
                76 => 705000,
                77 => 478000,
                78 => 608000,
                79 => 525000,
                80 => 571000,
                81 => 449000,
                82 => 727000,
                83 => 985000,
                84 => 905000,
                85 => 1100000,
                86 => 27000000,
                87 => 3100000,
                88 => 1000000,
                89 => 2250000,
                90 => 4000000,
                91 => 420000,
                92 => 365000,
                93 => 455000,
                94 => 200000,
                95 => 242000,
                96 => 210000,
                97 => 449000,
                98 => 472000,
                99 => 495000,
                100 => 225000,
                101 => 250000,
                102 => 395000,
                103 => 1150000,
                104 => 855000,
                105 => 745000,
                106 => 1150000,
                107 => 855000,
                108 => 745000,
                109 => 1150000,
                110 => 855000,
                111 => 745000,
                112 => 1150000,
                113 => 855000,
                114 => 745000,
                115 => 3000000,
                _ => 0,
            };
        }
        int func_5587(int iParam0)//Position - 0x1CD6A2
        {
            return iParam0 switch
            {
                0 => 0,
                1 => 3,
                2 => 2,
                3 => 6,
                4 => 5,
                5 => 4,
                6 => 7,
                7 => 1,
                8 => 8,
                _ => 1,
            };
        }
        int func_5583(int iParam0)//Position - 0x1CD380
        {
            return iParam0 switch
            {
                0 => 6,
                1 => 7,
                2 => 8,
                3 => 1,
                4 => 2,
                5 => 0,
                6 => 5,
                7 => 4,
                8 => 3,
                _ => 1,
            };
        }
        int func_7350(int iParam0, int iParam1, int iParam2)//Position - 0x26B96D
        {
            int iVar0;

            iVar0 = func_5722(iParam1, iParam2);
            switch (iParam0)
            {
                case 103:
                case 106:
                case 109:
                case 112:
                    if (iParam2 == 0)
                    {
                        iVar0 = 0;
                    }

                    else if (iParam1 == 8)
                    {
                        if (func_5587(iParam2) == func_67(5308))
                        {
                            iVar0 = 0;
                        }
                    }
                    else if (iParam1 == 9)
                    {
                        if (func_5583(iParam2) == func_67(5309))
                        {
                            iVar0 = 0;
                        }
                    }
                    break;

                case 104:
                case 107:
                case 110:
                case 113:
                    if (iParam2 == 0)
                    {
                        iVar0 = 0;
                    }
                    else if (iParam1 == 10)
                    {
                        if (func_5587(iParam2) == func_67(5310))
                        {
                            iVar0 = 0;
                        }
                    }
                    else if (iParam1 == 11)
                    {
                        if (func_5583(iParam2) == func_67(5311))
                        {
                            iVar0 = 0;
                        }
                    }
                    break;

                case 105:
                case 108:
                case 111:
                case 114:
                    if (iParam2 == 0)
                    {
                        iVar0 = 0;
                    }
                    else if (iParam1 == 12)
                    {
                        if (func_5587(iParam2) == func_67(5312))
                        {
                            iVar0 = 0;
                        }
                    }
                    else if (iParam1 == 13)
                    {
                        if (func_5583(iParam2) == func_67(5313))
                        {
                            iVar0 = 0;
                        }
                    }
                    break;
            }
            return iVar0;
        }
        int func_7347(int iParam0, int iParam1)//Position - 0x26B88F
        {
            int iVar0;
            int iVar1;

            iVar0 = 0;
            iVar1 = func_5722(14, iParam1);
            if (!func_5603())
            {
                iVar0 = func_6350(iParam0);
                if (iParam1 == 1)
                {
                    iVar1 = 0;
                }
                else
                {
                    iVar1 = func_5722(14, iParam1);
                }
            }
            else
            {
                iVar1 = func_5722(14, iParam1);
            }
            return (iVar0 + iVar1);
        }
        bool func_5603()//Position - 0x1CED01
        {
            return func_67(5314) != 0;
        }
        int func_6350(int iParam0)//Position - 0x1FFBA8
        {
            return iParam0 switch
            {
                87 => Tunables.Global_262145.Value<int>("f_19836") /* Tunable: IMPEXP_OFFICE_MODSHOP_COST */,
                88 => Tunables.Global_262145.Value<int>("f_19836") /* Tunable: IMPEXP_OFFICE_MODSHOP_COST */,
                89 => Tunables.Global_262145.Value<int>("f_19836") /* Tunable: IMPEXP_OFFICE_MODSHOP_COST */,
                90 => Tunables.Global_262145.Value<int>("f_19836") /* Tunable: IMPEXP_OFFICE_MODSHOP_COST */,
                _ => 0,
            };
        }
        int func_7348(int iParam0, int iParam1)//Position - 0x26B8DC
        {
            int iVar0;
            int iVar1;

            iVar0 = 0;
            iVar1 = func_6348(14, iParam1);
            if (!func_5603())
            {
                iVar0 = func_7349(iParam0);
                if (iParam1 == 1)
                {
                    iVar1 = 0;
                }
                else
                {
                    iVar1 = func_6348(14, iParam1);
                }
            }
            else
            {
                iVar1 = func_6348(14, iParam1);
            }
            return (iVar0 + iVar1);
        }
        int func_7349(int iParam0)//Position - 0x26B929
        {
            return iParam0 switch
            {
                87 => 900000,
                88 => 900000,
                89 => 900000,
                90 => 900000,
                _ => 0,
            };
        }
    }
}
