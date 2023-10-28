using FreeRoamProject.Server.Core.Buckets;
using FreeRoamProject.Server.Core.PlayerChar;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FreeRoamProject.Server.Core
{

    internal static class ChatServer
    {
        public static List<ChatCommand> Commands = new List<ChatCommand>();
        public static List<ChatSuggestion> Suggestions = new List<ChatSuggestion>();

        public static void Init()
        {
            ServerMain.Instance.AddEventHandler("chatMessage", new Action<int, string, string>(chatMessage));
            //ServerMain.Instance.AddEventHandler("consoleCommand", new Action<string, string>(ConsoleCommand));
            ServerMain.Instance.AddEventHandler("lprp:chat:commands", new Action<Player>(SendComms));
        }

        public static void chatMessage(int id, string name, string message)
        {
            try
            {
                PlayerClient p = Functions.GetClientFromPlayerId(id);
                if ((int)p.User.group_level < 0) return;

                if (message.StartsWith("/"))
                {
                    string fullCommand = message.Replace("/", "");
                    string[] command = fullCommand.Split(' ');
                    string cmd = command[0];
                    ChatCommand comm = null;
                    if (Commands.Any(x => x.CommandName.ToLower() == cmd.ToLower())) comm = Commands.FirstOrDefault(x => x.CommandName.ToLower() == cmd.ToLower());

                    if (comm is not null)
                    {
                        if (p.User.group_level >= comm.Restriction)
                        {
                            comm.Source = p.Player;
                            comm.rawCommand = message;
                            if (command.Length > 1)
                                comm.Args = command.Skip(1).ToList();
                            else
                                comm.Args = new List<string>();
                            comm.Action.DynamicInvoke(p, comm.Args, comm.rawCommand);
                        }
                    }
                    chatCommandEntered(p.Player, fullCommand, command, cmd, comm);
                }
                else
                {
                    Shared.Core.Buckets.Bucket server = BucketsHandler.FreeRoam.GetPlayerBucket(p.Handle);
                    foreach (PlayerClient player in server.Players)
                    {
                        p.Player.TriggerEvent("chat:addMessage", new
                        {
                            color = new[] { 255, 255, 255 },
                            multiline = true,
                            args = new[] { name, message }
                        });
                    }
                    //BaseScript.TriggerClientEvent("lprp:triggerProximityDisplay", Convert.ToInt32(p.Handle), /*user.FullName + ":",*/ message);
                }
                CancelEvent();
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error(e.ToString());
            }
        }

        //private static void ConsoleCommand(string name, string command) { }

        public static void chatCommandEntered(Player sender, string fullCommand, string[] command, string cmd, ChatCommand comm)
        {
            User user = Functions.GetUserFromPlayerId(sender.Handle);

            if (comm != null)
            {
                if (user.group_level >= comm.Restriction)
                {
                    string txt;
                    if (command.Length > 1)
                        txt = $"Command: /{cmd} invoked by{sender.Name} with text: {fullCommand.Substring(cmd.Length + 1)}";
                    else
                        txt = $"Command: /{cmd} invoked by{sender.Name}";
                    ServerMain.Logger.Info(txt);
                }
                else
                {
                    user.showNotification("You do not have permission to use this command!");
                    ServerMain.Logger.Warning($"{sender.Name} tried to use the {cmd} command");
                }
            }
            else
            {
                user.showNotification("You entered an invalid command!");
                ServerMain.Logger.Warning($"{sender.Name} entered an invalid command: {cmd}");
            }
        }

        private static void SendComms([FromSource] Player p)
        {
            List<object> suggestions = new List<object>();

            foreach (ChatSuggestion sug in Suggestions)
            {
                List<object> paramss = new List<object>();
                foreach (SuggestionParam par in sug.@params) paramss.Add(new { par.name, par.help });
                suggestions.Add(new { sug.name, sug.help, @params = paramss });
            }

            p.TriggerEvent("chat:addSuggestions", suggestions);
        }
    }


    public class ChatMessage
    {

    }
    public class ChatSuggestion
    {
        public string name;
        public string help;
        public SuggestionParam[] @params;

        public ChatSuggestion(string help, SuggestionParam[] args)
        {
            this.help = help;
            @params = args;
        }
        public ChatSuggestion(string help)
        {
            this.help = help;
            @params = new SuggestionParam[0];
        }
    }
    public class SuggestionParam
    {
        public string name;
        public string help;
        public SuggestionParam(string name, string help)
        {
            this.name = name;
            this.help = help;
        }
    }
    public class ChatCommand
    {
        public string CommandName;
        public Delegate Action;
        public Player Source;
        public string rawCommand;
        public List<string> Args;
        public UserGroup Restriction;
        public ChatCommand(string commandName, UserGroup minGroupAllowed, Delegate handler)
        {
            CommandName = commandName;
            Restriction = minGroupAllowed;
            Action = handler;
        }
    }
}