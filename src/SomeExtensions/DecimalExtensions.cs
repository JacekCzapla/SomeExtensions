using System;

namespace SomeExtensions
{
    public static class DecimalExtensions
    {
        public static decimal? Round(this decimal? value, int round)
        {
            decimal? res = null;

            if (value.HasValue)
                res = Math.Round(value.Value, round, MidpointRounding.AwayFromZero);

            return res;
        }

        public static decimal Round(this decimal value, int round)
        {
            decimal res = 0;
            res = Math.Round(value, round, MidpointRounding.AwayFromZero);
            return res;
        }
    }
}