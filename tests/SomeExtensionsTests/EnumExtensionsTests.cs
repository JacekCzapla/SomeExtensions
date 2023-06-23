using SomeExtensions;
using System.ComponentModel.DataAnnotations;

namespace SomeExtensionsTests
{
    public enum EnumTest 
    {
        [Display(Name ="AOne", ShortName ="AO", Description ="this is one")]
        One,
        [Display(Name = "ATwo", ShortName = "AT", Description = "this is two")]
        Two,
        [Display]
        Three,
        Four
    }

    public class EnumExtensionsTests
    {
        [Fact]
        public void name_test()
        {

            EnumTest one = EnumTest.One;
            EnumTest two = EnumTest.Two;
            EnumTest three = EnumTest.Three;
            EnumTest four = EnumTest.Four;

            Assert.Equal("AOne", one.Name());
            Assert.Equal("ATwo", two.Name());
            Assert.Equal("Three", three.Name());
            Assert.Equal("Four", four.Name());
        }

        [Fact]
        public void shortname_test()
        {
            EnumTest one = EnumTest.One;
            EnumTest two = EnumTest.Two;
            EnumTest three = EnumTest.Three;
            EnumTest four = EnumTest.Four;

            Assert.Equal("AO", one.ShortName());
            Assert.Equal("AT", two.ShortName());
            Assert.Equal("Three", three.ShortName());
            Assert.Equal("Four", four.ShortName());
        }

        [Fact]
        public void description_test()
        {
            EnumTest one = EnumTest.One;
            EnumTest two = EnumTest.Two;
            EnumTest three = EnumTest.Three;
            EnumTest four = EnumTest.Four;

            Assert.Equal("this is one", one.Description());
            Assert.Equal("this is two", two.Description());
            Assert.Equal("Three", three.Description());
            Assert.Equal("Four", four.Description());
        }

        [Fact]
        public void names_test()
        {
            var res = EnumExtensions.Names<EnumTest>();

            Assert.Equal(4, res.Count);
            Assert.Contains("AOne", res);
            Assert.Contains("ATwo", res);
            Assert.Contains("Three", res);
            Assert.Contains("Four", res);
        }

        [Fact]
        public void get_value_test()
        {
            var one = EnumExtensions.GetValueFromName<EnumTest>("AOne");
            var two = EnumExtensions.GetValueFromName<EnumTest>("ATwo");
            var three = EnumExtensions.GetValueFromName<EnumTest>("Three");
            var four = EnumExtensions.GetValueFromName<EnumTest>("Four");

            Assert.Equal(EnumTest.One, one);
            Assert.Equal(EnumTest.Two, two);
            Assert.Equal(EnumTest.Three, three);
            Assert.Equal(EnumTest.Four, four);
        }
    }
}