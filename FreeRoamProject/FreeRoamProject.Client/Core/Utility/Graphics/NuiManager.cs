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
        /// true se NUI è attivo.
        /// </summary>
        public bool IsNuiFocusOn => _hasFocus;

        /// <summary>
        /// Restituisce la posizione del cursore nello schermo
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
        /// Attiva o disattiva l'interfaccia html del gioco
        /// </summary>
        /// <param name="hasFocus">per attivare / disattivare il focus del gioco</param>
        /// <param name="showCursor">per mostrare o no il cursore del mouse</param>
        public void SetFocus(bool hasFocus, bool showCursor = true)
        {
            SetNuiFocus(hasFocus, showCursor);
            _hasFocus = hasFocus;
        }

        /// <summary>
        /// Attiva o disattiva l'interfaccia html del gioco mantenendo l'input nel gioco
        /// </summary>
        /// <param name="keepInput">se attivato l'input della tastiera rimane al gioco</param>
        public void SetFocusKeepInput(bool keepInput)
        {
            SetNuiFocusKeepInput(keepInput);
            if (!_hasFocus) _hasFocus = true;
        }

        /// <summary>
        /// Invia un messaggio all'interfaccia NUI contenente dei dati
        /// </summary>
        /// <param name="data">un oggetto da serializzare</param>
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
        /// Invia un messaggio all'interfaccia NUI contenente dei dati
        /// </summary>
        /// <param name="data">un oggetto serializzato</param>
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