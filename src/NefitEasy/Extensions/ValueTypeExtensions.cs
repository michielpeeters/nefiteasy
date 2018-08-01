namespace NefitEasy.Extensions
{
    using System.Globalization;

    public static class ValueTypeExtensions
    {
        public static string ToJson(this double value) => "{\"value\":" + value.ToString(CultureInfo.InvariantCulture) + "}";

        public static string ToJson(this string value) => "{\"value\":'" + value.ToLowerInvariant() + "'}";
    }
}