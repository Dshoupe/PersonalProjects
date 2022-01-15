using JsonChecker;
using Xunit;

namespace BracketCheckerTests
{
    public class BracketCheckerTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("{}")]
        [InlineData("abc{}abc")]
        [InlineData("{{{{{}}}}}")]
        [InlineData("{Tester test}")]
        [InlineData("{[]}")]
        [InlineData("[{}]")]
        [InlineData("[]{}")]
        [InlineData("{}{}")]
        [InlineData("{{}{{{}}}}")]
        public void PositiveTests(string testString)
        {
            Assert.True(Program.BracketChecker(testString));
        }

        [Theory]
        [InlineData("}{")]
        [InlineData("{{}")]
        [InlineData("{{{{{")]
        [InlineData("{}{{{{")]
        [InlineData("{{{{{{}}}}}")]
        [InlineData("{{}}}{{}}{}}{}{{}}{{{{{}{}{}{}{{}{}}}}")]
        [InlineData("{{}}}{}{}{}{{}{{{{{}}}}{}{{}{}}}")]
        [InlineData("{}}}{}{}{{}}{{{{}}}{{{}{}}")]
        [InlineData("{}}}{{}{{}}{{{{}}}{{}}{}")]
        [InlineData("}{{{}}{{}{{}}}")]
        public void NegativeTests(string testString)
        {
            Assert.False(Program.BracketChecker(testString));
        }
    }
}