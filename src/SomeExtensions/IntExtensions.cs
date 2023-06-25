using System;
using System.Linq;

namespace SomeExtensions
{
    public static class IntExtensions
    {
        public static DateTime DaysAgo(this int i)
        {
            return DateTime.Now.Date.AddDays(-i);
        }

        public static bool InSet(this int x, params int[] set)
        {
            return set.Contains(x);
        }

        /// <summary>
        /// Czy wartość x jest w set, za ienia elementy set na int (same cyfry, nieodporna na przecinki, kropki)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="set"></param>
        /// <returns></returns>
        public static bool InSetDirty(this int x, params string[] set)
        {
            var setInt = set.Select(a => a.ToIntDirty()).ToArray();

            return setInt.Contains(x);
        }

        public static bool ArrayContains(this int[] s, int x)
        {
            return s.Contains(x);
        }
    }
}