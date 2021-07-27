using JsonChecker;
using Xunit;

namespace BracketCheckerTests
{
    public class BracketCheckerTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("{}")]
        [InlineData("")]
        [InlineData("abc{}abc")]
        [InlineData("{{{{{}}}}}")]
        [InlineData("{Tester test}")]
        [InlineData("{[]}")]
        [InlineData("[{}]")]
        [InlineData("[]{}")]
        public void PositiveTests(string testString)
        {
            Assert.True(Program.JsonChecker(testString));
        }

        [Theory]
        [InlineData("}{")]
        [InlineData("{{}")]
        [InlineData("{{{{{")]
        [InlineData("{}{{{{")]
        [InlineData("{}{}")]
        public void NegativeTests(string testString)
        {
            Assert.False(Program.JsonChecker(testString));
        }
    }
}