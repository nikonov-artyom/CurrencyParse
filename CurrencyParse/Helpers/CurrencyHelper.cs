using System;

namespace CurrencyParse.Helpers
{
    public static class CurrencyHelper
    {
        public static string TryParseString(this string value, Func<string, bool> function)
        {
            return function.Invoke(value)
                ? value
                : string.Empty;
        }

        public static decimal TryParseDecimal(this string value, Func<string, bool> function)
        {
            decimal outputValue = 0m;
            if (function.Invoke(value) && decimal.TryParse(value, out outputValue))
            {
                return outputValue;
            }

            return outputValue;
        }

        public static int TryParseInt(this string value, Func<string, bool> function)
        {
            int outputValue = 0;
            if (function.Invoke(value) && int.TryParse(value, out outputValue))
            {
                return outputValue;
            }

            return outputValue;
        }
    }
}
