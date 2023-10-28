using System.Collections.Generic;

namespace FreeRoamProject.Server.Discord.GuildData
{
    public class Channel
    {
        public List<PermissionOverwrite> permission_overwrites = new List<PermissionOverwrite>();
        public ulong? guild_id;
        public ulong? parent_id;
        public string name;
        public int? type;
        public int? position;
        public string topic;
        public ulong last_message_id;
        public int? bitrate;
        public int? user_limit;
        public int? rate_limit_per_user;
        public bool nsfw;
        public ulong? id;
    }

    public class PermissionOverwrite
    {
        public int? type;
        public ulong? allow;
        public ulong? deny;
        public ulong? id;
    }
}
