using SomeExtensions;

namespace SomeExtensionsTests
{
    public class ListExtensionsTests
    {
        [Fact]
        public void list_cartesian_test()
        {
            var list = new List<List<int>>() { new List<int> { 1, 2, 3 }, new List<int> { 4, 5 } };
            var res = list.CartesianProduct().ToList();

            Assert.Equal(6, res.Count);
            //System.Console.WriteLine(res.ToString());
        }
    }
}