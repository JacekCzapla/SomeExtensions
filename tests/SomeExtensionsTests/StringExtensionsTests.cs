using SomeExtensions;

namespace SomeExtensionsTests
{
    public class StringExtensionsTests
    {
        [Fact]
        public void base64_encode_string()
        {
            string s = "Test encode";
            string encoded = s.EncodeBase64();

            string decoded = encoded.DecodeBase64();

            Assert.Equal(s, decoded);
        }

        [Fact]
        public void string_is_empty_test()
        {
            string empty = "";
            string notempty = "123";

            bool isempty = empty.IsEmpty();
            bool isnotempty = notempty.IsEmpty();

            Assert.True(isempty);
            Assert.False(isnotempty);
        }

        [Fact]
        public void first_limit_test()
        {
            string s = "12345";
            string res = s.FirstLimit(2);
            Assert.Equal("12", res);
            Assert.NotEqual(s, res);
        }

        [Fact]
        public void first_limit_woth_dots_test()
        {
            string s = "12345";
            string res = s.FirstLimitWithDots(2);
            Assert.Equal("12...", res);
            Assert.NotEqual(s, res);
        }

        [Fact]
        public void isint_test()
        {
            string s = "12345";
            bool ok = s.IsInt();
            bool err = "123a".IsInt();

            Assert.True(ok);
            Assert.False(err);
        }

        [Fact]
        public void isdecimal_test()
        {
            string sok1 = "12345";
            string sok2 = "123,45";

            string serr1 = "a";
            string serr2 = "123a45";
            string serr3 = "123.45";

            Assert.True(sok1.IsDecimal());
            Assert.True(sok2.IsDecimal());

            Assert.False(serr1.IsDecimal());
            Assert.False(serr2.IsDecimal());
            Assert.False(serr3.IsDecimal());
        }

        [Fact]
        public void isigit_test()
        {
            Assert.True("1".IsDigit());
            Assert.True("2".IsDigit());

            Assert.False("11".IsDigit());
            Assert.False("1a".IsDigit());
            Assert.False("a".IsDigit());
        }
    }
}