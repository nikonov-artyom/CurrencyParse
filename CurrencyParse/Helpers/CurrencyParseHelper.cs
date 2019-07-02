using System.Text.RegularExpressions;

namespace CurrencyParse.Helpers
{
    public static class CurrencyParseHelper
    {
        public static bool IsCurrencyCodeField(this string value)
        {
            return value.IsMatch("^\\d{3}$");
        }

        public static bool IsCurrencyCodeDescriptionField(this string value)
        {
            return value.IsMatch("^[A-Z]{3}$");
        }

        public static bool IsCurrencyUnitField(this string value)
        {
            return value.IsMatch("(^1$|^10$|^100$|^1000$|^10000$|^100000$)");
        }

        public static bool IsCurrencyNameField(this string value)
        {
            return value.IsMatch("^\\D{4,}$");
        }

        public static bool IsCurrencyValueField(this string value)
        {
            return value.IsMatch("^\\d{0,}\\,\\d{1,4}?$");
        }

        private static bool IsMatch(this string value, string pattern)
        {
            Regex regex = new Regex(pattern);
            return regex.IsMatch(value);
        }
    }
}
