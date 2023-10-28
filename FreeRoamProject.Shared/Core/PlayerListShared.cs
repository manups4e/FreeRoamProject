using FxEvents.Shared.Attributes;

namespace FreeRoamProject.Shared
{
    public class PlayerSlotConfig
    {
        public string crewName;
        public int jobPoints;
        public bool showJobPointsIcon;
    }
    public enum SlotScoreDisplayType
    {
        NUMBER_ONLY = 0,
        ICON = 1,
        NONE = 2
    };

    public enum SlotScoreRightIconType
    {
        NONE = 0,
        INACTIVE_HEADSET = 48,
        MUTED_HEADSET = 49,
        ACTIVE_HEADSET = 47,
        RANK_FREEMODE = 65,
        KICK = 64,
        LOBBY_DRIVER = 79,
        LOBBY_CODRIVER = 80,
        SPECTATOR = 66,
        BOUNTY = 115,
        DEAD = 116,
        DPAD_GANG_CEO = 121,
        DPAD_GANG_BIKER = 122,
        DPAD_DOWN_TARGET = 123
    };

    /// <summary>
    /// Struct used for the player info row options.
    /// </summary>
    
    public class PlayerSlot
    {
        public int ServerId;
        public string? Name;
        public string? RightText;
        public int Color;
        public string? IconOverlayText;
        public string? JobPointsText;
        public string? CrewLabelText;
        public SlotScoreDisplayType JobPointsDisplayType;
        public SlotScoreRightIconType RightIcon;
        public string? TextureString;
        public char FriendType;

        public PlayerSlot() { }
        public PlayerSlot(int serverid, string name, string rightText, int hudcolor, string iconoverlaytext, string jobpointstext, string crewlabeltext, SlotScoreDisplayType jobpointstype, SlotScoreRightIconType righticon, string texturestring, char friendtype)
        {
            ServerId = serverid;
            Name = name;
            RightText = rightText;
            Color = hudcolor;
            IconOverlayText = iconoverlaytext;
            JobPointsText = jobpointstext;
            CrewLabelText = crewlabeltext;
            JobPointsDisplayType = jobpointstype;
            RightIcon = righticon;
            TextureString = texturestring;
            FriendType = friendtype;
        }

    }
}
