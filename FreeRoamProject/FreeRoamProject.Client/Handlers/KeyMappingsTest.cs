/*
using System;
using System.Collections.Generic;
using System.Linq;
using CitizenFX.Core;
using System.Threading.Tasks;
using static CitizenFX.Core.Native.API;
using System.Drawing;
using CitizenFX.Core.UI;

namespace FreeRoamProject.Client.Handlers
{
    public enum InputType
	{
        Keyboard,
        Controller
	}
	public class KeyMappingsTest
	{
        public static List<KeyMappingController> InputList = new List<KeyMappingController>();
        public KeyMappingsTest()
		{
            KeyMappingController example = new KeyMappingController("ExampleCommand", "To open the door", KeyboardMappers.A, InputType.Keyboard, new Action<ForwardInputData>(Whatever));
            example.ForwardedData.Data = new List<dynamic>() { "Test", 123, "Whatever you want" };
            InputList.Add(example);
            
            RegisterCommand("+key", new Action<int, List<dynamic>, string>(KeyPressed), false);
            RegisterCommand("-key", new Action<int, List<dynamic>, string>(KeyReleased), false);
            
            Tick+=MappingHandling;
            // this is the last class to be Initiated (it waits all other classes to register their input before processing them)
        }

        private void Whatever(ForwardInputData aa)
		{
            Debug.WriteLine(aa.player.Name + ", pressing buttons so kawaiii!");
		}
        private void KeyPressed(int source, List<dynamic>args, string rawCommand)
        {
            try
            {
                //IF YOU CHANGE FROM +key OR -key REMEMBER TO COUNT THE MIN CHARS "+key " is 5 for the substring
                KeyMappingController input = InputList.FirstOrDefault(x => x.CommandName == rawCommand.Substring(5));
                input.IsPressed = true;
                input.ForwardedData.player = Cache.Player;
                input.Action.DynamicInvoke(input.ForwardedData);
            }
            catch(Exception e)
			{
                Debug.WriteLine(e.ToString());
			}
        }

        private void KeyReleased(int source, List<dynamic> args, string rawCommand)
        {
            //IF YOU CHANGE FROM +key OR -key REMEMBER TO COUNT THE MIN CHARS "+key " is 5 for the substring
            KeyMappingController input = InputList.FirstOrDefault(x=> x.CommandName == rawCommand.Substring(5));
            if(input!=null)
                input.IsPressed = false;
        }

        private int RegisterKeyWow(KeyMappingController input)
        {
            //IF YOU CHANGE FROM +key TO SOMETHING ELSE REMEMBER TO CHANGE IT IN HERE TOO!!
            RegisterKeyMapping($"+key {input.CommandName}", input.CommandDescription, input.Type == InputType.Keyboard ? "keyboard" : "pad_digitalbutton", input.Key);
            return InputList.IndexOf(input) + 1;
        }

        // this is made as a tick because: if you add a new keymapping with server already open it'll be registered on the go
        public async Task MappingHandling()
		{
            //using Cache.PlayerPed means calling Cache.Player.Character means 3 natives PlayerId() (once), GetPlayerPed() (twice)
            //this way i only call it once with PlayerPedId()
            Ped playerPed = Cache.PlayerPed;
            foreach (var input in InputList)
            {
                //if the input id is 0 register it and give it an id.. this way it gets registered once only
                if (input.Id == 0)
                    input.Id = RegisterKeyWow(input);
                //if the input id is different than 0
                if(input.Id > 0)
				{
                    //if not is yet pressed
                    if (!input.IsPressed)
                    {
                        //if its position has been declared
                        if (input.Position != Vector3.Zero)
                        {
                            //if the ped range from the position is inside the max radius let's draw the marker if the marker is not null
                            if (playerPed.IsInRangeOf(input.Position, input.Radius.MarkerDistance))
                            {
                                if (input.Marker != null)
                                    input.Marker.Draw();
                                //if you're inside the minimum range then i'll show you the best notification ever to press the damn key
                                if (playerPed.IsInRangeOf(input.Position, input.Radius.MinInputDistance))
                                {
                                    if (!string.IsNullOrWhiteSpace(input.InputMessage))
                                        Screen.DisplayHelpTextThisFrame(input.InputMessage);
                                }
                            }
                        }
                    }
				}
            }
            await Task.FromResult(0);
		}
    }

    public class KeyMappingController
	{
        public int Id;
        public string CommandName;
        public string CommandDescription;
        public string Key;
        public InputType Type;
        public bool IsPressed;
        public Vector3 Position = Vector3.Zero;
        public float W = -1f;
        public Radius Radius;
        public string InputMessage = null;
        public Marker Marker = null;
        public Delegate Action;
        public ForwardInputData ForwardedData = new ForwardInputData();
        public KeyMappingController(string nome, string command, string key, InputType type, Delegate action = null)
        {
            CommandName = nome;
            CommandDescription = command;
            Key = key;
            Type = type;
			Action = action;
        }
        public KeyMappingController(string nome, string command, string key, InputType type, Vector3 pos, Radius rad, string inputMessage, Marker marker, Delegate action = null)
        {
            CommandName = nome;
            CommandDescription = command;
            Key = key;
            Type = type;
            Position = pos;
            Radius = rad;
            InputMessage = inputMessage;
            Marker = marker;
			Action = action;
        }
        public KeyMappingController(string nome, string command, string key, InputType type, Vector4 pos, Radius rad, string inputMessage, Marker marker, Delegate action = null)
        {
            CommandName = nome;
            CommandDescription = command;
            Key = key;
            Type = type;
            Position = new Vector3(pos.X, pos.Y, pos.Z);
            W = pos.W;
            Radius = rad;
            InputMessage = inputMessage;
            Marker = marker;
			Action = action;
        }
    }

    public static class KeyboardMappers
    {
        public static string BACK = "BACK";
        public static string TAB = "TAB";
        public static string RETURN = "RETURN";
        public static string PAUSE = "PAUSE";
        public static string CAPITAL = "CAPITAL";
        public static string ESCAPE = "ESCAPE";
        public static string SPACE = "SPACE";
        public static string PAGEUP = "PAGEUP";
        public static string PRIOR = "PRIOR";
        public static string PAGEDOWN = "PAGEDOWN";
        public static string NEXT = "NEXT";
        public static string END = "END";
        public static string HOME = "HOME";
        public static string LEFT = "LEFT";
        public static string UP = "UP";
        public static string RIGHT = "RIGHT";
        public static string DOWN = "DOWN";
        public static string SYSRQ = "SYSRQ";
        public static string SNAPSHOT = "SNAPSHOT";
        public static string INSERT = "INSERT";
        public static string DELETE = "DELETE";
        public static string N0 = "0";
        public static string N1 = "1";
        public static string N2 = "2";
        public static string N3 = "3";
        public static string N4 = "4";
        public static string N5 = "5";
        public static string N6 = "6";
        public static string N7 = "7";
        public static string N8 = "8";
        public static string N9 = "9";
        public static string A = "A";
        public static string B = "B";
        public static string C = "C";
        public static string D = "D";
        public static string E = "E";
        public static string F = "F";
        public static string G = "G";
        public static string H = "H";
        public static string I = "I";
        public static string J = "J";
        public static string K = "K";
        public static string L = "L";
        public static string M = "M";
        public static string N = "N";
        public static string O = "O";
        public static string P = "P";
        public static string Q = "Q";
        public static string R = "R";
        public static string S = "S";
        public static string T = "T";
        public static string U = "U";
        public static string V = "V";
        public static string W = "W";
        public static string X = "X";
        public static string Y = "Y";
        public static string Z = "Z";
        public static string LWIN = "LWIN";
        public static string RWIN = "RWIN";
        public static string APPS = "APPS";
        public static string NUMPAD0 = "NUMPAD0";
        public static string NUMPAD1 = "NUMPAD1";
        public static string NUMPAD2 = "NUMPAD2";
        public static string NUMPAD3 = "NUMPAD3";
        public static string NUMPAD4 = "NUMPAD4";
        public static string NUMPAD5 = "NUMPAD5";
        public static string NUMPAD6 = "NUMPAD6";
        public static string NUMPAD7 = "NUMPAD7";
        public static string NUMPAD8 = "NUMPAD8";
        public static string NUMPAD9 = "NUMPAD9";
        public static string MULTIPLY = "MULTIPLY";
        public static string ADD = "ADD";
        public static string SUBTRACT = "SUBTRACT";
        public static string DECIMAL = "DECIMAL";
        public static string DIVIDE = "DIVIDE";
        public static string NUMPADEQUALS = "NUMPADEQUALS";
        public static string NUMPADENTER = "NUMPADENTER";
        public static string F1 = "F1";
        public static string F2 = "F2";
        public static string F3 = "F3";
        public static string F4 = "F4";
        public static string F5 = "F5";
        public static string F6 = "F6";
        public static string F7 = "F7";
        public static string F8 = "F8";
        public static string F9 = "F9";
        public static string F10 = "F10";
        public static string F11 = "F11";
        public static string F12 = "F12";
        public static string F13 = "F13";
        public static string F14 = "F14";
        public static string F15 = "F15";
        public static string F16 = "F16";
        public static string F17 = "F17";
        public static string F18 = "F18";
        public static string F19 = "F19";
        public static string F20 = "F20";
        public static string F21 = "F21";
        public static string F22 = "F22";
        public static string F23 = "F23";
        public static string F24 = "F24";
        public static string NUMLOCK = "NUMLOCK";
        public static string SCROLL = "SCROLL";
        public static string LSHIFT = "LSHIFT";
        public static string RSHIFT = "RSHIFT";
        public static string LCONTROL = "LCONTROL";
        public static string RCONTROL = "RCONTROL";
        public static string LMENU = "LMENU";
        public static string RMENU = "RMENU";
        public static string OEM_1 = "OEM_1";
        public static string SEMICOLON = "SEMICOLON";
        public static string EQUALS = "EQUALS";
        public static string PLUS = "PLUS";
        public static string COMMA = "COMMA";
        public static string MINUS = "MINUS";
        public static string PERIOD = "PERIOD";
        public static string SLASH = "SLASH";
        public static string OEM_2 = "OEM_2";
        public static string OEM_3 = "OEM_3";
        public static string GRAVE = "GRAVE";
        public static string LBRACKET = "LBRACKET";
        public static string OEM_4 = "OEM_4";
        public static string OEM_5 = "OEM_5";
        public static string BACKSLASH = "BACKSLASH";
        public static string OEM_6 = "OEM_6";
        public static string RBRACKET = "RBRACKET";
        public static string APOSTROPHE = "APOSTROPHE";
        public static string OEM_7 = "OEM_7";
        public static string OEM_102 = "OEM_102";
        public static string RAGE_EXTRA1 = "RAGE_EXTRA1";
        public static string RAGE_EXTRA2 = "RAGE_EXTRA2";
        public static string RAGE_EXTRA3 = "RAGE_EXTRA3";
        public static string RAGE_EXTRA4 = "RAGE_EXTRA4";
        public static string CHATPAD_GREEN_SHIFT = "CHATPAD_GREEN_SHIFT";
        public static string CHATPAD_ORANGE_SHIFT = "CHATPAD_ORANGE_SHIFT";
    }
    public static class GamepadMappers
    {
        public static string L1 = "L1_INDEX";
        public static string R1 = "R1_INDEX";
        public static string L2 = "L2_INDEX";
        public static string R2 = "R2_INDEX";
        public static string L3 = "L3_INDEX";
        public static string R3 = "R3_INDEX";
        public static string Dpad_UP = "LUP_INDEX";
        public static string Dpad_RIGHT = "LRIGHT_INDEX";
        public static string Dpad_DOWN = "LDOWN_INDEX";
        public static string Dpad_LEFT = "LLEFT_INDEX";
        public static string Y = "RUP_INDEX";
        public static string B = "RRIGHT_INDEX";
        public static string A = "RDOWN_INDEX";
        public static string X = "RLEFT_INDEX";
        public static string SELECT = "SELECT_INDEX";
        public static string START = "START_INDEX";
        public static string TOUCH = "TOUCH_INDEX";
    }

    public class ForwardInputData
	{
        public Player player { get; internal set; }
        public List<dynamic> Data = new List<dynamic>();
    }

    public class Marker
    {
        public MarkerType MarkerType = MarkerType.VerticalCylinder;
        public Vector3 Position = Vector3.Zero;
        public Vector3 Direction = Vector3.Zero;
        public Vector3 Rotation = Vector3.Zero;
        public Vector3 Scale = new Vector3(1.5f);
        public Color Color = Color.WhiteSmoke;
        public bool BobUpDown = false;
        public bool Rotate = false;
        public bool FaceCamera = false;
        public Marker(MarkerType type, Vector3 position, Color color, bool bobUpDown = false, bool rotate = false, bool faceCamera = false)
        {
            MarkerType = type;
            Position = position;
            Color = color;
            BobUpDown = bobUpDown;
            Rotate = rotate;
            FaceCamera = faceCamera;
        }
        public Marker(MarkerType type, Vector3 position, Vector3 scale, Color color, bool bobUpDown = false, bool rotate = false, bool faceCamera = false)
        {
            MarkerType = type;
            Position = position;
            Scale = scale;
            Color = color;
            BobUpDown = bobUpDown;
            Rotate = rotate;
            FaceCamera = faceCamera;
        }

        public async void Draw()
        {
            World.DrawMarker(MarkerType, Position, Direction, Rotation, Scale, Color, BobUpDown, FaceCamera, Rotate);
        }
    }

    public class Radius
    {
        public float MinInputDistance = 1.375f; // default R* inside marker distance to press input
        public float MarkerDistance = 100f; // default 100
        public Radius(float minimum, float markerDistance)
        {
            MinInputDistance = minimum;
            MarkerDistance = markerDistance;
        }
    }

}
*/
