using System;

namespace FreeRoamProject.Client
{
    [Flags]
    public enum ControlModifier
    {
        Any = -1,
        None = 0,
        Ctrl = 1 << 0,
        Alt = 1 << 1,
        Shift = 1 << 2
    }
}