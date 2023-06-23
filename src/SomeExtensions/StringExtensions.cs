using System;
using System.Linq;
using System.Text;

namespace SomeExtensions
{
    public static class StringExtensions
    {
        public const string Default = "";
        public static bool IsEmpty(this string val)
        {
            return val == string.Empty;
        }

        //public static bool Empty(this string value)
        //{
        //    return string.IsNullOrEmpty(value);
        //}

        public static string FirstLimit(this string val, int limit)
        {
            return val.Length > limit ? val.Substring(0, limit) : val;
        }

        public static string FirstLimitWithDots(this string val, int limit)
        {
            return val.Length > limit ? $"{val.Substring(0, limit)}..." : val;
        }

        public static bool InSet(this string x, params string[] set)
        {
            return set.Contains(x);
        }

        public static int ToIntDirty(this string s)
        {
            string ss = new string(s.Where(x => Char.IsDigit(x)).ToArray());
            int.TryParse(ss, out int res);
            return res;
        }

        public static string FirstOrEmpty(this string str)
        {
            return str.Length > 0 ? str.First().ToString() : "";
        }

        public static bool IsInt(this string val)
        {
            return val.All(x => char.IsDigit(x));
        }

        public static bool IsDecimal(this string val)
        {
            decimal dec = 0;
            return decimal.TryParse(val, out dec);

            //return val.All(x => Char.IsDigit(x)) && val.Length == 1;
        }

        public static bool IsDigit(this string val)
        {
            return val.All(x => char.IsDigit(x)) && val.Length == 1;
        }

        public static bool IsDigit(this char val)
        {
            return char.IsDigit(val);
        }

        //public static string? FirstLimit(this string? val, int limit)
        //{
        //    //string? res;
        //    //if(string.)
        //    //return ResolveEventArgs
        //    ////if(val.)
        //    return val.Length > 12 ? val.Substring(0, limit) : val;
        //}

        /// <summary>
        /// Encodes string to base64
        /// </summary>
        /// <param name="val">String to encode</param>
        /// <returns></returns>
        public static string EncodeBase64(this string val)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(val));
        }

        /// <summary>
        /// Decodes string from base64
        /// </summary>
        /// <param name="val">String to decode</param>
        /// <returns></returns>
        public static string DecodeBase64(this string val)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(val));
        }
    }
}