using System;
using System.Collections.Generic;

namespace FreeRoamProject.Server.Discord
{
    public class Member
    {
        public List<ulong> roles { get; set; }
        public DateTime joined_at { get; set; }
        public bool is_deafened { get; set; }
        public bool is_muted { get; set; }
        public string username { get; set; }
        public string discriminator { get; set; }
        public string avatar { get; set; }
        public bool bot { get; set; }
        public bool mfa_enabled { get; set; }
        public bool verified { get; set; }
        public string locale { get; set; }
        public int flags { get; set; }
        public int public_flags { get; set; }
        public ulong id { get; set; }
    }
}
