using System;

namespace FreeRoamProject.Shared
{
    public class GameLabel
    {
        private string name;
        public uint Hash;
        public string? Name { get => name; private set => name = value; }

        public GameLabel(string name)
        {
            this.name = name;
        }
        public GameLabel(uint hash)
        {
            Hash = hash;
        }
        public GameLabel() { }
    }

    public enum CustomArguments
    {
        None = 0,
        PlayerName,
        TextLabel,
    }

    public struct LabelArgument
    {
        public object Value;
        public Type type;
        public bool FormattedInt;
        public int DecimalPlaces;
        public CustomArguments CustomArgument;
        public string DateFormat;
        public LabelArgument(int value, bool formattedInt = false)
        {
            Value = value;
            type = typeof(int);
            FormattedInt = formattedInt;
        }
        public LabelArgument(float value, int decimalPlaces = 2)
        {
            Value = value;
            type = typeof(float);
            DecimalPlaces = decimalPlaces;
        }
        public LabelArgument(string value, CustomArguments customArgument)
        {
            Value = value;
            type = typeof(string);
            CustomArgument = customArgument;
        }
        public LabelArgument(bool value)
        {
            Value = value;
            type = typeof(bool);
        }
        public LabelArgument(DateTime value, string format = "")
        {
            Value = value;
            DateFormat = format;
            type = typeof(DateTime);
        }
        public LabelArgument(TimeSpan value, string format = "")
        {
            Value = value;
            DateFormat = format;
            type = typeof(DateTime);
        }

#if CLIENT
        public override string ToString()
        {
            switch (Value)
            {
                case int argInt:
                    if (FormattedInt)
                        return argInt.ToString("N0");
                    else
                        return argInt.ToString();
                case string:
                case char:
                    return CustomArgument switch
                    {
                        CustomArguments.PlayerName => "<C>" + Value.ToString() + "</C>",
                        CustomArguments.TextLabel => Game.GetGXTEntry(Value.ToString()),
                        _ => Value.ToString(),
                    };
                case bool:
                    return Value.ToString();
                case double:
                case float:
                    return ((float)Value).ToString($"F{DecimalPlaces}");
                case DateTime:
                    return ((DateTime)Value).ToString(DateFormat);
                case TimeSpan:
                    return ((TimeSpan)Value).ToString(DateFormat);
                default:
                    return Value.ToString();
            }
        }
#endif
    }
}
