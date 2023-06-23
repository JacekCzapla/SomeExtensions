using System;
using System.Text;

namespace SomeExtensions
{
    public static class BaseEncoder
    {
        public static string EncodeBase64(string val)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(val));
        }

        public static string DecodeBase64(string val)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(val));
        }
    }
}