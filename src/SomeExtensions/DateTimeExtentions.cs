using System;
using System.Linq;

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

    public static class DateTimeExtentions
    {
        public static int GetDateInt(this DateTime d)
        {
            return int.Parse(d.ToString("yyMMdd"));
        }

        public static int GetDateInt(this DateTime? d)
        {
            return d == null ? 0 : int.Parse(d.Value.ToString("yyMMdd"));
        }

        public static int GetHourInt(this DateTime d)
        {
            return int.Parse(d.ToString("HHmmss"));
        }

        public static int GetHourInt(this DateTime? d)
        {
            return d == null ? 0 : int.Parse(d.Value.ToString("HHmmss"));
        }

        public static DateTime DaysAgo(this int i)
        {
            return DateTime.Now.Date.AddDays(-i);
        }

        /// <summary>
        /// Returns Date with 0 hour 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateTime DayStart(this DateTime d)
        {
            return d.Date;
        }
        public static DateTime DayEnd(this DateTime d)
        {
            return d.Date.AddDays(1).AddMilliseconds(-1);
        }

        /// <summary>
        /// Returns current shift start date and time for date
        /// </summary>
        /// <param name="date"></param>
        /// <param name="shiftStartHour"></param>
        /// <param name="shiftHourLen"></param>
        /// <returns></returns>
        public static DateTime CurrentShiftStart(this DateTime date, int shiftStartHour = 6, int shiftHourLen = 8)
        {
            DateTime res;
            DateTime start = new DateTime(date.Year, date.Month, date.Day, shiftStartHour, 0, 0, 0);

            if (date.Hour < shiftStartHour)
            {
                res = start.AddHours(-shiftHourLen);
            }
            else if (date.Hour >= shiftStartHour && date.Hour < (shiftStartHour + shiftHourLen))
            {
                // 6 - 14
                res = start.AddHours(0);
            }
            else if (date.Hour >= (shiftStartHour + shiftHourLen) && date.Hour < (shiftStartHour + 2 * shiftHourLen))
            {
                // 14 - 22
                res = start.AddHours(shiftHourLen);
            }
            else
            {
                // > 22
                res = start.AddHours(2 * shiftHourLen);
            }
            return res;
        }

        /// <summary>
        /// Returns current shift end datetime for date
        /// </summary>
        /// <param name="date"></param>
        /// <param name="shiftStartHour"></param>
        /// <param name="shiftHourLen"></param>
        /// <returns></returns>
        public static DateTime CurrentShiftEnd(this DateTime date, int shiftStartHour = 6, int shiftHourLen = 8)
        {
            DateTime res;
            DateTime start = new DateTime(date.Year, date.Month, date.Day, shiftStartHour, 0, 0, 0);

            if (date.Hour < shiftStartHour)
            {
                res = start.AddHours(0);
            }
            else if (date.Hour >= shiftStartHour && date.Hour < (shiftStartHour + shiftHourLen))
            {
                // 6 - 14
                res = start.AddHours(shiftHourLen);
            }
            else if (date.Hour >= (shiftStartHour + shiftHourLen) && date.Hour < (shiftStartHour + 2 * shiftHourLen))
            {
                // 14 - 22
                res = start.AddHours(2 * shiftHourLen);
            }
            else
            {
                // > 22 < 24
                res = start.AddHours(3 * shiftHourLen);
            }
            return res;
        }

        /// <summary>
        /// Calculates start and end work shifts for date and shiftStartHour
        /// </summary>
        /// <param name="date"></param>
        /// <param name="Start"></param>
        /// <param name="End"></param>
        /// <param name="shiftStartHour"></param>
        public static void GetShiftDates(this DateTime date, out DateTime Start, out DateTime End, int shiftStartHour = 6, int shiftLengthHours = 8)
        {
            Start = date.CurrentShiftStart();
            End = date.CurrentShiftEnd();
        }

        /// <summary>
        /// Returns begining year and month datetime for year
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateTime MonthStart(this DateTime d)
        {
            return DateTime.Parse($"{d.Year}-{d.Month:D2}-01 00:00:00");
        }

        /// <summary>
        /// Returns begining year datetime for year
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateTime YearStart(this DateTime d)
        {
            return DateTime.Parse($"{d.Year}-01-01 00:00:00");
        }

        /// <summary>
        /// Returns DateTime in 24 hours long number format (yyyyMMddHHmmss) eg. 2023-02-12 12:23:11 => 20230212122311
        /// </summary>
        /// <param name="dat"></param>
        /// <returns>long numer for date</returns>
        public static long ToLong(this DateTime dat)
        {
            return long.Parse(dat.ToString("yyyyMMddHHmmss"));
        }

        /// <summary>
        /// Returns DateTime in 24 hours long number format (yyyyMMddHHmmss) eg. 2023-02-12 12:23:11 => 20230212122311
        /// </summary>
        /// <param name="dat"></param>
        /// <returns>long numer for date</returns>
        public static long ToLong(this DateTime? dat)
        {
            if (!dat.HasValue)
                return 0;
            return long.Parse(dat.Value.ToString("yyyyMMddHHmmss"));
        }

        /// <summary>
        /// Returns shift start datetime for all day
        /// </summary>
        /// <param name="date"></param>
        /// <param name="shiftStartHour"></param>
        /// <returns></returns>
        public static DateTime DayShiftStart(this DateTime date, int shiftStartHour = 6)
        {
            return date.Hour < 6 ? new DateTime(date.Year, date.Month, date.Day-1, shiftStartHour, 0, 0) : new DateTime(date.Year, date.Month, date.Day, shiftStartHour, 0, 0);
        }

        /// <summary>
        /// Returns shift end datetime for all day
        /// </summary>
        /// <param name="dat"></param>
        /// <param name="shiftStartHour"></param>
        /// <returns></returns>
        public static DateTime DayShiftEnd(this DateTime dat, int shiftStartHour = 6)
        {
            return dat.AddDays(1).Date.Add(new TimeSpan(0, shiftStartHour - 1, 59, 59, 999));
        }

        /// <summary>
        /// globalna data i godzina rozpoczęcia zmainy dla aktualnego tygodnia (poniedziałek 06:00:00) 
        /// dla okreslania calej doby zmiany czyli od 6:00 do 5:59 pierwszego dnia tygodnia
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime WeekShiftStart(this DateTime date)
        {
            var dat = date.WeekStart();
            return new DateTime(dat.Year, dat.Month, dat.Day, 6, 0, 0, 000);
        }
        /// <summary>
        /// globalna data i godzina zakonczenia zmainy dla aktualnego tygodnia (05:59:59 dnia nastepnego) 
        /// dla okreslania calej doby zmiany czyli od 6:00 do 5:59 ostatniego dnia tygodnia
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime WeekShiftEnd(this DateTime date)
        {
            var dat = date.WeekEnd();
            return new DateTime(dat.Year, dat.Month, dat.Day, 5, 59, 59, 999).AddDays(1);
        }

        public static DateTime WeekStart(this DateTime dt, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        public static DateTime WeekEnd(this DateTime dt, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            var firstDay = dt.WeekStart(startOfWeek);
            return firstDay.AddDays(6);
        }

        public static DateTime Shift1Start(this DateTime dat, int shiftStartHour = 6)
        {
            return dat.Date.AddHours(6);// Add(new TimeSpan(0, shiftStartHour, 0, 0, 0));
        }

        public static DateTime Shift1End(this DateTime dat, int shiftStartHour = 6, int shiftLengthHours = 8)
        {
            return dat.Date.AddHours(shiftStartHour + shiftLengthHours).AddMilliseconds(-1);
        }

        public static DateTime Shift2Start(this DateTime dat, int shiftStartHour = 6, int shiftLengthHours = 8)
        {
            return dat.Date.AddHours(shiftStartHour + shiftLengthHours);
        }

        public static DateTime Shift2End(this DateTime dat, int shiftStartHour = 6, int shiftLengthHours = 8)
        {
            return dat.Date.AddHours(shiftStartHour + 2*shiftLengthHours).AddMilliseconds(-1);
        }

        public static DateTime Shift3Start(this DateTime dat, int shiftStartHour = 6, int shiftLengthHours = 8)
        {
            return dat.Date.AddHours(shiftStartHour + 2 * shiftLengthHours);
        }

        public static DateTime Shift3End(this DateTime dat, int shiftStartHour = 6, int shiftLengthHours = 8)
        {
            return dat.Date.AddHours(shiftStartHour + 3 * shiftLengthHours).AddMilliseconds(-1);
        }
    }
}