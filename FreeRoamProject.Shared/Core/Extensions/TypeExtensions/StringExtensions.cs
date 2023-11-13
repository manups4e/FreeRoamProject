using System;


namespace FreeRoamProject.Shared.TypeExtensions
{

    public static class StringExtensions
    {
        public static bool Contains(this string source, string target, StringComparison comparison)
        {
            return source?.IndexOf(target, comparison) >= 0;
        }

        public static string Remove(this string source, string pattern)
        {
            return source.Replace(pattern, string.Empty);
        }

        public static string Surround(this string source, string value)
        {
            return !string.IsNullOrWhiteSpace(source) ? value + source + value : string.Empty;
        }

        public static int ToInt(this string source)
        {
            return int.Parse(source);
        }

        public static float ToFloat(this string source)
        {
            return float.Parse(source);
        }

        public static bool ToBool(this string source)
        {
            if (int.TryParse(source, out int number))
            {
                return number >= 1;
            }

            return bool.Parse(source);
        }
        public static string ReplaceFirst(this string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
    }
}