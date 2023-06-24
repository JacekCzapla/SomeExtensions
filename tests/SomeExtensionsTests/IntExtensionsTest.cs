using SomeExtensions;

namespace SomeExtensionsTests
{

    public class IntExtensionsTest
    {
        [Fact]
        public void in_set_test()
        {
            int i = 1;
            Assert.True(i.InSet(1, 2, 3));
            Assert.False(i.InSet( 3, 4));
        }

        [Fact]
        public void in_set_dirty_test() 
        {
            int i = 1;
            Assert.True(i.InSetDirty("1a", "2c"));
            Assert.False(i.InSetDirty("2", "2a"));
        }

        [Fact]
        public void array_contains_test()
        {
            int[] i = new int[2] { 1, 2 };
            Assert.True(i.ArrayContains(1));
            Assert.False(i.ArrayContains(3));
        }
    }
}