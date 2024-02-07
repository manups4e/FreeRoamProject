using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// ReSharper disable All

namespace FreeRoamProject.Client
{
    public enum PadCheck
    {
        Any = 0,
        Keyboard = 1,
        Controller = 2
    }

    /// <summary>
    /// Reference page: https://wiki.fivem.net/wiki/Controls
    /// Or /dev keycodetester in game and press a key
    /// Be careful... the keys press multiple commands at a time
    /// </summary>
    public static class Input
    {
        // da far diventare costanti
        const int defaultControlGroup = 0;
        const int controllerControlGroup = 2;
        public static Dictionary<ControlModifier, int> ModifierFlagToKeyCode = new() { [ControlModifier.Ctrl] = 36, [ControlModifier.Alt] = 19, [ControlModifier.Shift] = 21 };

        /// <summary>
        /// True if the controller pressed
        /// </summary>
        /// <returns></returns>
        public static bool WasLastInputFromController() => !IsInputDisabled(controllerControlGroup);

        /// <summary>
        /// Takes into account whether a modifier (alt, ctrl, shift) has been pressed
        /// </summary>
        /// <param name="modifier">You can specify just 1 modifier or more than one (with |)</param>
        /// <returns></returns>
        public static bool IsControlModifierPressed(ControlModifier modifier)
        {
            //           if (Phone.PhoneKeyboardOpen) return false;

            if (modifier == ControlModifier.Any)
                return true;
            else
            {
                ControlModifier BitMask = 0;
                ModifierFlagToKeyCode.ToList().ForEach(w =>
                {
                    if (Game.IsControlPressed(defaultControlGroup, (Control)w.Value) && IsInputDisabled(2)) BitMask |= w.Key;
                });

                if (BitMask == modifier)
                    return true;
                else
                    return false;
            }
        }

        public static bool IsControlJustPressed(Control control, PadCheck keyboardOnly = PadCheck.Any, ControlModifier modifier = ControlModifier.None) { return Game.IsControlJustPressed(0, control) && (keyboardOnly == PadCheck.Keyboard ? !WasLastInputFromController() : keyboardOnly == PadCheck.Controller ? WasLastInputFromController() : !WasLastInputFromController() || WasLastInputFromController()) && IsControlModifierPressed(modifier); }

        public static bool IsControlPressed(Control control, PadCheck keyboardOnly = PadCheck.Any, ControlModifier modifier = ControlModifier.None) { return Game.IsControlPressed(0, control) && (keyboardOnly == PadCheck.Keyboard ? !WasLastInputFromController() : keyboardOnly == PadCheck.Controller ? WasLastInputFromController() : !WasLastInputFromController() || WasLastInputFromController()) && IsControlModifierPressed(modifier); }

        public static bool IsControlJustReleased(Control control, PadCheck keyboardOnly = PadCheck.Any, ControlModifier modifier = ControlModifier.None) { return Game.IsControlJustReleased(0, control) && (keyboardOnly == PadCheck.Keyboard ? !WasLastInputFromController() : keyboardOnly == PadCheck.Controller ? WasLastInputFromController() : !WasLastInputFromController() || WasLastInputFromController()) && IsControlModifierPressed(modifier); }

        public static bool IsDisabledControlJustPressed(Control control, PadCheck keyboardOnly = PadCheck.Any, ControlModifier modifier = ControlModifier.None) { return Game.IsDisabledControlJustPressed(0, control) && (keyboardOnly == PadCheck.Keyboard ? !WasLastInputFromController() : keyboardOnly == PadCheck.Controller ? WasLastInputFromController() : !WasLastInputFromController() || WasLastInputFromController()) && IsControlModifierPressed(modifier); }

        public static bool IsDisabledControlJustReleased(Control control, PadCheck keyboardOnly = PadCheck.Any, ControlModifier modifier = ControlModifier.None) { return Game.IsDisabledControlJustReleased(0, control) && (keyboardOnly == PadCheck.Keyboard ? !WasLastInputFromController() : keyboardOnly == PadCheck.Controller ? WasLastInputFromController() : !WasLastInputFromController() || WasLastInputFromController()) && IsControlModifierPressed(modifier); }

        public static bool IsDisabledControlPressed(Control control, PadCheck keyboardOnly = PadCheck.Any, ControlModifier modifier = ControlModifier.None) { return Game.IsDisabledControlPressed(0, control) && (keyboardOnly == PadCheck.Keyboard ? !WasLastInputFromController() : keyboardOnly == PadCheck.Controller ? WasLastInputFromController() : !WasLastInputFromController() || WasLastInputFromController()) && IsControlModifierPressed(modifier); }

        public static bool IsEnabledControlJustPressed(Control control, PadCheck keyboardOnly = PadCheck.Any, ControlModifier modifier = ControlModifier.None) { return Game.IsEnabledControlJustPressed(0, control) && (keyboardOnly == PadCheck.Keyboard ? !WasLastInputFromController() : keyboardOnly == PadCheck.Controller ? WasLastInputFromController() : !WasLastInputFromController() || WasLastInputFromController()) && IsControlModifierPressed(modifier); }

        public static bool IsEnabledControlJustReleased(Control control, PadCheck keyboardOnly = PadCheck.Any, ControlModifier modifier = ControlModifier.None) { return Game.IsEnabledControlJustPressed(0, control) && (keyboardOnly == PadCheck.Keyboard ? !WasLastInputFromController() : keyboardOnly == PadCheck.Controller ? WasLastInputFromController() : !WasLastInputFromController() || WasLastInputFromController()) && IsControlModifierPressed(modifier); }

        public static bool IsEnabledControlPressed(Control control, PadCheck keyboardOnly = PadCheck.Any, ControlModifier modifier = ControlModifier.None) { return Game.IsEnabledControlPressed(0, control) && (keyboardOnly == PadCheck.Keyboard ? !WasLastInputFromController() : keyboardOnly == PadCheck.Controller ? WasLastInputFromController() : !WasLastInputFromController() || WasLastInputFromController()) && IsControlModifierPressed(modifier); }

        /// <summary>
        /// Waits until a key has been released and returns true if the key is still pressed
        /// </summary>
        /// <param name="control">The <see cref="Control"/> you want to wait for</param>
        /// <param name="keyboardOnly">Keyboard only, GamePad only, or both?</param>
        /// <param name="modifier">The additional <see cref="ControlModifier"/></param>
        /// <param name="timeout">How long to wait before the check starts checking in milliseconds</param>
        /// <returns>Returns if the player held down longer than the specified time</returns>
        public static async Task<bool> IsControlStillPressedAsync(Control control, PadCheck keyboardOnly = PadCheck.Any, ControlModifier modifier = ControlModifier.None, int timeout = 1000)
        {
            int currentTicks = GetNetworkTime() + 1;
            while (IsControlPressed(control, keyboardOnly, modifier) && GetNetworkTime() - currentTicks < timeout) await BaseScript.Delay(0);

            return GetNetworkTime() - currentTicks >= timeout;
        }

        public static async Task<Tuple<bool, int>> HasControlBeenPressedMultipleTimes(Control control, PadCheck keyboardOnly = PadCheck.Any, ControlModifier modifier = ControlModifier.None, int times = 2, int frameTime = 250)
        {
            if (IsControlJustPressed(control, keyboardOnly, modifier))
            {
                int i = 1;
                int time = GetNetworkTime();
                while (i < times)
                {
                    await BaseScript.Delay(0);
                    if (GetNetworkTime() - time > frameTime) break;
                    if (IsControlJustPressed(control, keyboardOnly, modifier))
                    {
                        i++;
                    }

                }
                return new(i == times, i);
            }
            return new(false, 0);
        }

        public static async Task<Tuple<bool, int>> HasControlBeenPressedMultipleTimes(Control control_1, Control control_2, PadCheck keyboardOnly = PadCheck.Any, ControlModifier modifier = ControlModifier.None, int times = 2, int frameTime = 250)
        {
            if ((IsControlJustPressed(control_1, keyboardOnly, modifier) && IsControlPressed(control_2, keyboardOnly, modifier)) ||
                (IsControlPressed(control_1, keyboardOnly, modifier) && IsControlJustPressed(control_2, keyboardOnly, modifier)))
            {
                int i = 1;
                int time = GetNetworkTime();
                while (i < times)
                {
                    await BaseScript.Delay(0);
                    if (GetNetworkTime() - time > frameTime) break;
                    if ((IsControlJustPressed(control_1, keyboardOnly, modifier) && IsControlPressed(control_2, keyboardOnly, modifier)) ||
                        (IsControlPressed(control_1, keyboardOnly, modifier) && IsControlJustPressed(control_2, keyboardOnly, modifier)))
                    {
                        i++;
                    }
                }
                return new(i == times, i);
            }
            return new(false, 0);
        }
    }
}