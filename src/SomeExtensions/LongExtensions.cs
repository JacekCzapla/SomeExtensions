using System;

namespace SomeExtensions
{
    public static class LongExtensions
    {
        /// <summary>
        /// Returns DateTime for long value in longd datetime format eg. 20230203123456 => "2023-02-03 12:34:56"
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        public static DateTime ToDateTime(this long val)
        {
            //20230101121212
            string sd = val.ToString();
            
            if (sd.Length != 14)
            {
                throw new InvalidCastException();
            }

            return new DateTime(
                int.Parse(sd.Substring(0, 4)),
                int.Parse(sd.Substring(4, 2)),
                int.Parse(sd.Substring(6, 2)),
                int.Parse(sd.Substring(8, 2)),
                int.Parse(sd.Substring(10, 2)),
                int.Parse(sd.Substring(12, 2))
                );
        }
    }
}