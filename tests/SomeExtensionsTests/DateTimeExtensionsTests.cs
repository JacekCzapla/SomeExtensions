using SomeExtensions;

namespace SomeExtensionsTests
{
    public class DateTimeExtensionsTests
    {
        private const string baseDateStr = "2023-06-22";
        [Fact]
        public void day_shift_start_test()
        {
            //var baseDate = new DateTime(2023, 06, 22).Date;
            var date_01_01_0501 = DateTime.Parse("2023-01-01 05:01:01");

            var date0601 = DateTime.Parse("2023-06-22 06:01:01");
            var date1359 = DateTime.Parse("2023-06-22 13:59:01");

            var date1400 = DateTime.Parse("2023-06-22 14:00:00");
            var date1401 = DateTime.Parse("2023-06-22 14:01:01");
            var date2200 = DateTime.Parse("2023-06-22 22:00:01");
            var date2359 = DateTime.Parse("2023-06-22 23:59:00");

            var date0101 = DateTime.Parse("2023-06-23 01:01:00");
            var date0559 = DateTime.Parse("2023-06-23 05:59:00");

            Assert.Equal(DateTime.Parse("2022-12-31 06:00:00"), date_01_01_0501.DayShiftStart());

            Assert.Equal(DateTime.Parse("2023-06-22 06:00:00"), date0601.DayShiftStart());
            Assert.Equal(DateTime.Parse("2023-06-22 06:00:00"), date1359.DayShiftStart());

            Assert.Equal(DateTime.Parse("2023-06-22 06:00:00"), date1400.DayShiftStart());
            Assert.Equal(DateTime.Parse("2023-06-22 06:00:00"), date1401.DayShiftStart());
            Assert.Equal(DateTime.Parse("2023-06-22 06:00:00"), date2200.DayShiftStart());
            Assert.Equal(DateTime.Parse("2023-06-22 06:00:00"), date2359.DayShiftStart());
         
            Assert.Equal(DateTime.Parse("2023-06-22 06:00:00"), date0101.DayShiftStart());
            Assert.Equal(DateTime.Parse("2023-06-22 06:00:00"), date0559.DayShiftStart());
        }

        [Fact]
        public void day_shift_end_test()
        {
            var date0601 = DateTime.Parse("2023-06-22 06:01:01");
            var date1359 = DateTime.Parse("2023-06-22 13:59:01");

            var date1400 = DateTime.Parse("2023-06-22 14:00:00");
            var date1401 = DateTime.Parse("2023-06-22 14:01:01");
            var date2200 = DateTime.Parse("2023-06-22 22:00:01");
            var date2359 = DateTime.Parse("2023-06-22 23:59:00");

            var date0101 = DateTime.Parse("2023-06-23 01:01:00");
            var date0559 = DateTime.Parse("2023-06-23 05:59:00");

            Assert.Equal(DateTime.Parse("2023-06-23 06:00:00"), date0601.DayShiftEnd());
            Assert.Equal(DateTime.Parse("2023-06-23 06:00:00"), date1359.DayShiftEnd());

            Assert.Equal(DateTime.Parse("2023-06-23 06:00:00"), date1400.DayShiftEnd());
            Assert.Equal(DateTime.Parse("2023-06-23 06:00:00"), date1401.DayShiftEnd());
            Assert.Equal(DateTime.Parse("2023-06-23 06:00:00"), date2200.DayShiftEnd());
            Assert.Equal(DateTime.Parse("2023-06-23 06:00:00"), date2359.DayShiftEnd());

            Assert.Equal(DateTime.Parse("2023-06-23 06:00:00"), date0101.DayShiftEnd());
            Assert.Equal(DateTime.Parse("2023-06-23 06:00:00"), date0559.DayShiftEnd());
        }

        [Fact]
        public void get_date_int_test()
        {
            var baseDate = new DateTime(2023, 06, 22, 12, 11, 33);
            int resd = baseDate.GetDateInt();
            Assert.Equal(230622, resd);

            int resh = baseDate.GetHourInt();
            Assert.Equal(121133, resh);
        }

        [Fact]
        public void days_ago_test()
        {
            int daysago = 1;
            var res = daysago.DaysAgo();
            Assert.Equal(res.Day, DateTime.Now.AddDays(-1).Day);

        }

        [Fact]
        public void work_day_start()
        {
            var date0601 = DateTime.Parse("2023-06-22 06:01:01");
            var date1359 = DateTime.Parse("2023-06-22 13:59:01");

            var date1400 = DateTime.Parse("2023-06-22 14:00:00");
            var date1401 = DateTime.Parse("2023-06-22 14:01:01");
            var date2200 = DateTime.Parse("2023-06-22 22:00:01");
            var date2359 = DateTime.Parse("2023-06-22 23:59:00");

            var date0101 = DateTime.Parse("2023-06-23 01:01:00");
            var date0559 = DateTime.Parse("2023-06-23 05:59:00");

            Assert.Equal(DateTime.Parse("2023-06-22 06:00:00"), date0601.WorkDayStart());
            Assert.Equal(DateTime.Parse("2023-06-22 06:00:00"), date1359.WorkDayStart());

            Assert.Equal(DateTime.Parse("2023-06-22 06:00:00"), date1400.WorkDayStart());
            Assert.Equal(DateTime.Parse("2023-06-22 06:00:00"), date1401.WorkDayStart());
            Assert.Equal(DateTime.Parse("2023-06-22 06:00:00"), date2200.WorkDayStart());
            Assert.Equal(DateTime.Parse("2023-06-22 06:00:00"), date2359.WorkDayStart());

            Assert.Equal(DateTime.Parse("2023-06-23 06:00:00"), date0101.WorkDayStart());
            Assert.Equal(DateTime.Parse("2023-06-23 06:00:00"), date0559.WorkDayStart());
        }

        [Fact]
        public void work_day_end()
        {
            var date0601 = DateTime.Parse("2023-06-22 06:01:01");
            var date1359 = DateTime.Parse("2023-06-22 13:59:01");

            var date1400 = DateTime.Parse("2023-06-22 14:00:00");
            var date1401 = DateTime.Parse("2023-06-22 14:01:01");
            var date2200 = DateTime.Parse("2023-06-22 22:00:01");
            var date2359 = DateTime.Parse("2023-06-22 23:59:00");

            var date0101 = DateTime.Parse("2023-06-23 01:01:00");
            var date0559 = DateTime.Parse("2023-06-23 05:59:00");

            Assert.Equal(DateTime.Parse("2023-06-23 06:00:00"), date0601.WorkDayEnd());
            Assert.Equal(DateTime.Parse("2023-06-23 06:00:00"), date1359.WorkDayEnd());

            Assert.Equal(DateTime.Parse("2023-06-23 06:00:00"), date1400.WorkDayEnd());
            Assert.Equal(DateTime.Parse("2023-06-23 06:00:00"), date1401.WorkDayEnd());
            Assert.Equal(DateTime.Parse("2023-06-23 06:00:00"), date2200.WorkDayEnd());
            Assert.Equal(DateTime.Parse("2023-06-23 06:00:00"), date2359.WorkDayEnd());

            Assert.Equal(DateTime.Parse("2023-06-24 06:00:00"), date0101.WorkDayEnd());
            Assert.Equal(DateTime.Parse("2023-06-24 06:00:00"), date0559.WorkDayEnd());
        }

        //[Fact]
        //public void day_start_end_test()
        //{
        //    var baseDate = new DateTime(2023, 06, 22, 12, 11, 33);
        //    var start = baseDate.DayStart();
        //    var end = baseDate.DayEnd();

        //    Assert.Equal(new DateTime(2023, 06, 22, 0, 0, 0), start);
        //    Assert.Equal(new DateTime(2023, 06, 22, 23, 59, 59, 999), end);
        //}

        [Fact]
        public void year_month_start_test()
        {
            var baseDate = new DateTime(2023, 06, 22, 12, 11, 33);
            var yearStart = baseDate.YearStart();
            var monthStart = baseDate.MonthStart();
            
            Assert.Equal(new DateTime(2023, 1, 1, 0, 0, 0), yearStart);
            Assert.Equal(new DateTime(2023, 6, 1, 0, 0, 0), monthStart);
        }

        [Fact]
        public void get_shift_dates_test()
        {
            var baseDate = new DateTime(2023, 06, 22).Date;
            var date0601 = baseDate + TimeSpan.Parse("06:01:01");
            var date1359 = baseDate + TimeSpan.Parse("13:59:01");
            var date1400 = baseDate.AddHours(14);
            var date1401 = baseDate.AddHours(14).AddMinutes(1);
            var date2200 = baseDate.AddHours(22);
            var date2359 = baseDate.AddHours(22);
            var date0101 = baseDate.AddDays(1).AddHours(1).AddMinutes(1);

            DateTime start = DateTime.MinValue, end = DateTime.MinValue;
            date0601.GetShiftDates(out start, out end, 6, 8);

            Assert.Equal(baseDate.AddHours(6), start);
            Assert.Equal(baseDate.AddHours(14), end);

            date1359.GetShiftDates(out start, out end, 6, 8);

            Assert.Equal(baseDate.AddHours(6), start);
            Assert.Equal(baseDate.AddHours(14), end);
            
            date1400.GetShiftDates(out start, out end);
            Assert.Equal(baseDate.AddHours(14), start);
            Assert.Equal(baseDate.AddHours(22), end);
            
            date1401.GetShiftDates(out start, out end);
            Assert.Equal(baseDate.AddHours(14), start);
            Assert.Equal(baseDate.AddHours(22), end);
            
            date2200.GetShiftDates(out start, out end);
            Assert.Equal(baseDate.AddHours(22), start);
            Assert.Equal(baseDate.AddHours(30), end);
            
            date2359.GetShiftDates(out start, out end);
            Assert.Equal(baseDate.AddHours(22), start);
            Assert.Equal(baseDate.AddHours(30), end);

            
            Console.WriteLine(date0101.ToString());
            date0101.GetShiftDates(out start, out end);
            Assert.Equal(baseDate.AddHours(22), start);
            Assert.Equal(baseDate.AddHours(30), end);
        }

        [Fact]
        public void current_shift_start()
        {
            var date0601 = DateTime.Parse("2023-06-22 06:01:01");
            var date1359 = DateTime.Parse("2023-06-22 13:59:01");

            var date1400 = DateTime.Parse("2023-06-22 14:00:00");
            var date1401 = DateTime.Parse("2023-06-22 14:01:01");
            var date2200 = DateTime.Parse("2023-06-22 22:00:01");
            var date2359 = DateTime.Parse("2023-06-22 23:59:00");

            var date0101 = DateTime.Parse("2023-06-22 01:01:00");
            var date0559 = DateTime.Parse("2023-06-22 05:59:00");


            Assert.Equal(DateTime.Parse("2023-06-22 06:00:00"), date0601.CurrentShiftStart());
            Assert.Equal(DateTime.Parse("2023-06-22 06:00:00"), date1359.CurrentShiftStart());

            Assert.Equal(DateTime.Parse("2023-06-22 14:00:00"), date1400.CurrentShiftStart());
            Assert.Equal(DateTime.Parse("2023-06-22 14:00:00"), date1401.CurrentShiftStart());
            Assert.Equal(DateTime.Parse("2023-06-22 22:00:00"), date2200.CurrentShiftStart());
            Assert.Equal(DateTime.Parse("2023-06-22 22:00:00"), date2359.CurrentShiftStart());

            Assert.Equal(DateTime.Parse("2023-06-21 22:00:00"), date0101.CurrentShiftStart());
            Assert.Equal(DateTime.Parse("2023-06-21 22:00:00"), date0559.CurrentShiftStart());
        }

        [Fact]
        public void current_shift_end()
        {
            var date0601 = DateTime.Parse("2023-06-22 06:01:01");
            var date1359 = DateTime.Parse("2023-06-22 13:59:01");

            var date1400 = DateTime.Parse("2023-06-22 14:00:00");
            var date1401 = DateTime.Parse("2023-06-22 14:01:01");
            var date2200 = DateTime.Parse("2023-06-22 22:00:01");
            var date2359 = DateTime.Parse("2023-06-22 23:59:00");

            var date0101 = DateTime.Parse("2023-06-22 01:01:00");
            var date0559 = DateTime.Parse("2023-06-22 05:59:00");


            Assert.Equal(DateTime.Parse("2023-06-22 14:00:00"), date0601.CurrentShiftEnd());
            Assert.Equal(DateTime.Parse("2023-06-22 14:00:00"), date1359.CurrentShiftEnd());

            Assert.Equal(DateTime.Parse("2023-06-22 22:00:00"), date1400.CurrentShiftEnd());
            Assert.Equal(DateTime.Parse("2023-06-22 22:00:00"), date1401.CurrentShiftEnd());
            Assert.Equal(DateTime.Parse("2023-06-23 06:00:00"), date2200.CurrentShiftEnd());
            Assert.Equal(DateTime.Parse("2023-06-23 06:00:00"), date2359.CurrentShiftEnd());

            Assert.Equal(DateTime.Parse("2023-06-22 06:00:00"), date0101.CurrentShiftEnd());
            Assert.Equal(DateTime.Parse("2023-06-22 06:00:00"), date0559.CurrentShiftEnd());
        }

        [Fact]
        public void to_long_test()
        {
            var baseDate = new DateTime(2023, 06, 22, 12, 11, 33);
            long res = baseDate.ToLong();
            Assert.Equal(20230622121133, res);

            DateTime? dnull = null;
            long resnull = dnull.ToLong();
            Assert.Equal(0, resnull);
        }
    }
}