using SomeExtensions;

namespace SomeExtensionsTests
{
    public class DateTimeExtensionsTests
    {
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
        public void day_start_end_test()
        {
            var baseDate = new DateTime(2023, 06, 22, 12, 11, 33);
            var start = baseDate.DayStart();
            var end = baseDate.DayEnd();

            Assert.Equal(new DateTime(2023, 06, 22, 0, 0, 0), start);
            Assert.Equal(new DateTime(2023, 06, 22, 23, 59, 59, 999), end);
        }

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
            var baseDate = new DateTime(2023, 06, 22).Date;
            var date0601 = baseDate + TimeSpan.Parse("06:01:01");
            var date1359 = baseDate + TimeSpan.Parse("13:59:01");
            var date1400 = baseDate.AddHours(14);
            var date1401 = baseDate.AddHours(14).AddMinutes(1);
            var date2200 = baseDate.AddHours(22);
            var date2359 = baseDate.AddHours(23).AddMinutes(59);
            var date0101 = baseDate.AddDays(1).AddHours(1).AddMinutes(1);

            DateTime start = DateTime.MinValue;
            start = date0601.CurrentShiftStart();

            Assert.Equal(baseDate.AddHours(6), start);

            start = date1359.CurrentShiftStart();

            Assert.Equal(baseDate.AddHours(6), start);

            start = date1400.CurrentShiftStart();
            Assert.Equal(baseDate.AddHours(14), start);

            start = date1401.CurrentShiftStart();
            Assert.Equal(baseDate.AddHours(14), start);

            start = date2200.CurrentShiftStart();
            Assert.Equal(baseDate.AddHours(22), start);

            start = date2359.CurrentShiftStart();
            Assert.Equal(baseDate.AddHours(22), start);

            start = date0101.CurrentShiftStart();
            Assert.Equal(baseDate.AddHours(22), start);
        }

        [Fact]
        public void current_shift_end()
        {
            var baseDate = new DateTime(2023, 06, 22).Date;

            var date0601 = baseDate + TimeSpan.Parse("06:01:01");
            var date1359 = baseDate + TimeSpan.Parse("13:59:01");
            var date1400 = baseDate.AddHours(14);
            var date1401 = baseDate.AddHours(14).AddMinutes(1);
            var date2200 = baseDate.AddHours(22);
            var date2359 = baseDate.AddHours(23).AddMinutes(59);
            var date0101 = baseDate.AddDays(1).AddHours(1).AddMinutes(1);

            DateTime end = DateTime.MinValue;
            end = date0601.CurrentShiftEnd();

            Assert.Equal(baseDate.AddHours(14), end);

            end = date1359.CurrentShiftEnd();

            Assert.Equal(baseDate.AddHours(14), end);

            end = date1400.CurrentShiftEnd();
            Assert.Equal(baseDate.AddHours(22), end);

            end = date1401.CurrentShiftEnd();
            Assert.Equal(baseDate.AddHours(22), end);

            end = date2200.CurrentShiftEnd();
            Assert.Equal(baseDate.AddHours(30), end);

            end = date2359.CurrentShiftEnd();
            Assert.Equal(baseDate.AddHours(30), end);

            end = date0101.CurrentShiftEnd();
            Assert.Equal(baseDate.AddHours(30), end);
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