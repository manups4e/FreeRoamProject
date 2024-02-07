using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.Core.Utility.HUD
{
    // I MEAN.. THIS IS AWESOME AS IT IS
    public class NuiManager
    {
        private bool _hasFocus;
        /// <summary>
        /// true if NUI is active.
        /// </summary>
        public bool IsNuiFocusOn => _hasFocus;

        /// <summary>
        /// Returns the position of the cursor in the screen
        /// </summary>
        public Point NuiCursorPosition
        {
            get
            {
                int x = 0, y = 0;
                GetNuiCursorPosition(ref x, ref y);

                return new Point(x, y);
            }
        }

        /// <summary>
        /// Activates or deactivates the html interface of the game
        /// </summary>
        /// <param name="hasFocus">To turn on/off the focus of the game</param>
        /// <param name="showCursor">To show or not to show the mouse cursor</param>
        public void SetFocus(bool hasFocus, bool showCursor = true)
        {
            SetNuiFocus(hasFocus, showCursor);
            _hasFocus = hasFocus;
        }

        /// <summary>
        /// Activates or deactivates the html interface of the game while keeping the input in the game
        /// </summary>
        /// <param name="keepInput">If activated keyboard input remains at the game</param>
        public void SetFocusKeepInput(bool keepInput)
        {
            SetNuiFocusKeepInput(keepInput);
            if (!_hasFocus) _hasFocus = true;
        }

        /// <summary>
        /// Sends a message to the NUI interface containing data
        /// </summary>
        /// <param name="data">An object to be serialized</param>
        public void SendMessage(object data)
        {
            SendNuiMessage(data.ToJson());
        }

        public void SendMessage(string type, object data)
        {
            string[] pippo = type.Split(':');
            object invio = new { identifier = pippo[0], @event = pippo[1], data };
            ClientMain.Logger.Debug(invio.ToJson());
            ClientMain.Logger.Debug($"Inviato messaggio NUI [{type}] con Payload {data.ToJson()}");
            SendNuiMessage(invio.ToJson());
        }

        /// <summary>
        /// Sends a message to the NUI interface containing data
        /// </summary>
        /// <param name="data">A serialized object</param>
        public void SendMessage(string data)
        {
            SendNuiMessage(data);
        }

        public void RegisterCallback(string @event, Action action)
        {
            API.RegisterNuiCallback(@event, new Action<IDictionary<string, object>, CallbackDelegate>((data, callback) =>
            {
                ClientMain.Logger.Debug($"Chiamato NUI Callback [{@event}] con Payload {data.ToJson()}");
                action();
                callback("ok");
            }));
        }

        public void RegisterCallback<T>(string @event, Action<T> action)
        {
            API.RegisterNuiCallback(@event, new Action<IDictionary<string, object>, CallbackDelegate>((data, callback) =>
            {
                ClientMain.Logger.Debug($"Chiamato NUI Callback {@event} con Payload {data.ToJson()} di tipo {typeof(T)}");
                T typedData = data.Count == 1 ? Shared.TypeCache<T>.IsSimpleType ? (T)data.Values.ElementAt(0) : data.Values.ElementAt(0).ToJson().FromJson<T>() : data.ToJson().FromJson<T>();
                action(typedData);
                callback("ok");
            }));
        }

        public void RegisterCallback<TReturn>(string @event, Func<Task<TReturn>> action)
        {
            API.RegisterNuiCallback(@event, new Action<IDictionary<string, object>, CallbackDelegate>(async (data, callback) =>
            {
                ClientMain.Logger.Debug($"Chiamato NUI Callback {@event} con Payload {data.ToJson()}");
                TReturn result = await action();
                callback(result.ToJson());
            }));
        }

        public void RegisterCallback<T, TReturn>(string @event, Func<T, Task<TReturn>> action)
        {
            API.RegisterNuiCallback(@event, new Action<IDictionary<string, object>, CallbackDelegate>(async (data, callback) =>
            {
                ClientMain.Logger.Debug($"Chiamato NUI Callback {@event} con Payload {data.ToJson()}");
                T typedData = data.Count == 1 ? FxEvents.Shared.TypeExtensions.TypeCache<T>.IsSimpleType ? (T)data.Values.ElementAt(0) : data.Values.ElementAt(0).ToJson().FromJson<T>() : data.ToJson().FromJson<T>();
                TReturn result = await action(typedData);
                callback(result.ToJson());
            }));
        }
    }
}