using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.Handlers
{
    // I LOVE THIS CLASS.. THIS LETS YOU HANDLE ALL THE CONTROLS IN ONE ONLY TICKS.. AND CONTROLS CAN BE HANDLED INSIDE MARKERS (INVISIBLE OR NOT)
    // WITH THIS YOU CAN HAVE PERMANENT CONTROLS AND DYNAMIC CONTROLS CHECKED ONLY WHEN PLAYER IS IN A CERTAIN RANGE / INSIDE MARKER
    public enum InputCallingModifier
    {
        OnFoot,
        InVehicle
    }

    internal static class InputHandler
    {
        private static readonly List<InputController> _listaInput = [];
        public static List<InputController> ToList => _listaInput.ToList();

        public static void AddInput(InputController input)
        {
            if (_listaInput.Contains(input)) return;
            _listaInput.Add(input);
        }

        public static void RemoveInput(InputController input)
        {
            if (!_listaInput.Contains(input)) return;
            _listaInput.Remove(input);
        }

        public static void AddInputList(List<InputController> inputs)
        {
            foreach (InputController input in inputs)
            {
                if (_listaInput.Contains(input)) continue;
                _listaInput.Add(input);
            }
        }

        public static void RemoveInputList(List<InputController> inputs)
        {
            foreach (InputController input in inputs)
            {
                if (!_listaInput.Contains(input)) continue;
                _listaInput.Remove(input);
            }
        }


        public static void Clear()
        {
            _listaInput.Clear();
        }

        public static void Init()
        {
            ClientMain.Instance.AddTick(InputHandling);
        }

        public static void Stop()
        {
            _listaInput.Clear();
            ClientMain.Instance.RemoveTick(InputHandling);
        }

        public static async Task InputHandling()
        {
            try
            {
                await Cache.PlayerCache.Loaded();
                Ped p = Cache.PlayerCache.MyClient.Ped;

                foreach (InputController input in _listaInput)
                {
                    try
                    {
                        if (input.Position != Position.Zero || input.Marker != null || input.InputMessage != null)
                        {
                            if (p.IsInRangeOf(input.Position.ToVector3, 100f)) // custom big range otherwise default 50f
                            {
                                if (input.Marker is null)
                                {
                                    ClientMain.Logger.Debug($"Input with null marker =>{input.Control}, {input.InputMessage}, {input.Position}");
                                    continue;
                                }

                                input.Marker.Draw();
                                if (input.Marker.IsInMarker && !MenuHandler.IsAnyMenuOpen) // custom radius if not default 1.375f
                                {
                                    if (!string.IsNullOrWhiteSpace(input.InputMessage)) Notifications.ShowHelpNotification(input.InputMessage);

                                    if (Input.IsControlJustPressed(input.Control, input.Check, input.Modifier))
                                    {
                                        switch (input.Check)
                                        {
                                            case PadCheck.Any:
                                                input.Action.DynamicInvoke(p, input.parameters);

                                                break;
                                            case PadCheck.Controller:
                                                if (Input.WasLastInputFromController()) input.Action.DynamicInvoke(p, input.parameters);

                                                break;
                                            case PadCheck.Keyboard:
                                                if (!Input.WasLastInputFromController()) input.Action.DynamicInvoke(p, input.parameters);
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (Input.IsControlJustPressed(input.Control, input.Check, input.Modifier) && !MenuHandler.IsAnyMenuOpen)
                            {
                                switch (input.Check)
                                {
                                    case PadCheck.Any:
                                        input.Action.DynamicInvoke(p, input.parameters);
                                        break;
                                    case PadCheck.Controller:
                                        if (Input.WasLastInputFromController())
                                            input.Action.DynamicInvoke(p, input.parameters);
                                        break;
                                    case PadCheck.Keyboard:
                                        if (!Input.WasLastInputFromController())
                                            input.Action.DynamicInvoke(p, input.parameters);
                                        break;
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        ClientMain.Logger.Error(input.ToJson());
                        ClientMain.Logger.Error(e.ToString());
                    }
                    await Task.FromResult(0);
                }
            }
            catch (Exception e)
            {
                ClientMain.Logger.Error(e.ToString());
            }
        }
    }
}