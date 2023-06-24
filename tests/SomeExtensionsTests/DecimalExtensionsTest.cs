using SomeExtensions;

namespace SomeExtensionsTests
{
    public class LongExtensionsTest
    {

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