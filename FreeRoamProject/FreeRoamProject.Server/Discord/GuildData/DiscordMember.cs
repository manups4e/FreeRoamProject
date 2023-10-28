using System;
using System.Collections.Generic;

namespace FreeRoamProject.Server.Discord.GuildData
{
    public class DiscordMember
    {
        public List<long> roles = new List<long>();
        public DateTime joined_at;
        public bool is_deafened;
        public bool is_muted;
        public string username;
        public string discriminator;
        public string avatar;
        public bool bot;
        public int? public_flags;
        public ulong? id;
    }
}
