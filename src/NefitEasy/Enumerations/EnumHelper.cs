namespace NefitEasy.Enumerations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class EnumHelper
    {
        public static TTarget Map<TSouce, TTarget>(TSouce source)
            => (TTarget) Enum.Parse(typeof(TTarget), source.ToString());

        public static bool Contains<TEnum>(string value)
            => ToStringArray<TEnum>().Contains(value);

        public static IEnumerable<string> ToStringArray<TEnum>()
            => Enum.GetNames(typeof(TEnum));

        public static IEnumerable<TEnum> ToArray<TEnum>()
            => Enum.GetValues(typeof(TEnum)).OfType<TEnum>().ToArray();
    }
}