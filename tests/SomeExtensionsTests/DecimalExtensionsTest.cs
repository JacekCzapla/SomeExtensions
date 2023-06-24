using SomeExtensions;

namespace SomeExtensionsTests
{
    public class LongExtensionsTest
    {
        [Fact]
        public void t()
        {
            long i = 1;
            i.ToDateTime();
        }
    }

    public class DecimalExtensionsTest
    {
        [Fact]
        public void round_test()
        {
            decimal d = 123.456M;
            Assert.Equal(123.46M, d.Round(2));

            Assert.Equal(123.45M, 123.454M.Round(2));
        }
    }
}