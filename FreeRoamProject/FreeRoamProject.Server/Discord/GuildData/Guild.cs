using System;
using System.Collections.Generic;

namespace FreeRoamProject.Server.Discord.GuildData
{
    public class Guild
    {
        public List<Role> Roles = new List<Role>();
        public List<Emoji> emojis = new List<Emoji>();
        public List<VoiceState> voice_states = new List<VoiceState>();
        public List<Channel> channels = new List<Channel>();
        public List<Member> members = new List<Member>();
        public string name;
        public string icon;
        public string preferred_locale;
        public ulong? owner_id;
        public string region;
        public ulong? afk_channel_id;
        public int? afk_timeout;
        public bool embed_enabled;
        public ulong? embed_channel_id;
        public int? verification_level;
        public int? default_message_notifications;
        public int? explicit_content_filter;
        public ulong? system_channel_id;
        public int? system_channel_flags;
        public ulong? rules_channel_id; // TO BE UNDERSTOOD
        public ulong? public_updates_channel_id; // TO BE UNDERSTOOD
        public ulong? application_id; // TO BE UNDERSTOOD
        public List<dynamic> features = new List<dynamic>(); // TO BE UNDERSTOOD
        public int? mfa_level;
        public DateTime joined_at;
        public bool large;
        public bool unavailable;
        public int? member_count;
        public int? max_members; // TO BE UNDERSTOOD
        public int? max_presences; // TO BE UNDERSTOOD
        public bool is_owner;
        public dynamic vanity_url_code; // TO BE UNDERSTOOD
        public dynamic description; // TO BE UNDERSTOOD
        public dynamic banner; // TO BE UNDERSTOOD
        public ulong? Pressum_tier = 0;
        public int? Pressum_subscription_count;
        public ulong? id;
    }
}
