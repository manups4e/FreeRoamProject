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
    /// Pagina di riferimento: https://wiki.fivem.net/wiki/Controls
    /// Oppure /dev keycodetester in gioco e premere un tasto
    /// Occhio.. i tasti premono piu comandi per volta
    /// </summary>
    public static class Input
    {
        // da far diventare costanti
        const int defaultControlGroup = 0;
        const int controllerControlGroup = 2;
        public static Dictionary<ControlModifier, int> ModifierFlagToKeyCode = new Dictionary<ControlModifier, int>() { [ControlModifier.Ctrl] = 36, [ControlModifier.Alt] = 19, [ControlModifier.Shift] = 21 };

        /// <summary>
        /// Vero se a premere è stato il controller
        /// </summary>
        /// <returns></returns>
        public static bool WasLastInputFromController() => !IsInputDisabled(controllerControlGroup);

        /// <summary>
        /// Tiene conto se un modifier (alt, ctrl, shift) è stato premuto
        /// </summary>
        /// <param name="modifier">Si può specificare 1 solo modifier o più di uno (con |)</param>
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
        /// Aspetta finchè un tasto non è stato rilasciato e ritorna vero se il tasto è ancora premuto
        /// </summary>
        /// <param name="control">Il <see cref="Control"/> che si vuole aspettare</param>
        /// <param name="keyboardOnly">Solo tastiera, solo GamePad o entrambi?</param>
        /// <param name="modifier">Il <see cref="ControlModifier"/> aggiuntivo</param>
        /// <param name="timeout">Quanto aspettare prima che il controllo cominci a verificare in millisecondi</param>
        /// <returns>Ritorna se il player ha tenuto premuto più del tempo specificato</returns>
        public static async Task<bool> IsControlStillPressedAsync(Control control, PadCheck keyboardOnly = PadCheck.Any, ControlModifier modifier = ControlModifier.None, int timeout = 1000)
        {
            int currentTicks = GetNetworkTime() + 1;
            while (IsControlPressed(control, keyboardOnly, modifier) && GetNetworkTime() - currentTicks < timeout) await BaseScript.Delay(0);

            return GetNetworkTime() - currentTicks >= timeout;
        }
        public static async Task<Tuple<bool, int>> HasControlBeenPressedMultipleTimes(Control control, PadCheck keyboardOnly = PadCheck.Any, ControlModifier modifier = ControlModifier.None, int times = 2, int frameTime = 250)
        {
            if (Input.IsControlJustPressed(control, keyboardOnly, modifier))
            {
                int i = 1;
                int time = GetNetworkTime();
                while (i < times)
                {
                    await BaseScript.Delay(0);
                    if (GetNetworkTime() - time > frameTime) break;
                    if (Input.IsControlJustPressed(control, keyboardOnly, modifier))
                    {
                        time = GetNetworkTime();
                        i++;
                    }

                }
                return new(i == times, i);
            }
            return new(false, 0);
        }
    }
}