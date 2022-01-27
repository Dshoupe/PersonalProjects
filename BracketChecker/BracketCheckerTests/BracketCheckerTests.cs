using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        private static readonly Dictionary<long, long> FibSequence = new Dictionary<long, long>
        {
            {0, 0},
            {1, 1},
            {2, 1},
            {3, 2},
            {4, 3},
            {5, 5},
            {6, 8},
            {7, 13},
            {8, 21},
            {9, 34},
            {10, 55},
            {11, 89},
            {12, 144},
            //Largest fib sequence we can get to before reaching max of a long
            {92, 7540113804746346429}
        };

        [Fact]
        public void FibTestsUpTo12()
        {
            for (var i = 0; i <= 12; i++)
            {
                Assert.True(Program.FibonacciSequence(i) == FibSequence[i]);
            }
        }

        [Fact]
        public void FibTestsAt92()
        {
            Assert.True(Program.FibonacciSequence(92) == FibSequence[92]);
        }

        [Fact]
        public void FibTestsExceptions()
        {
            Assert.Throws<ArgumentException>(() => Program.FibonacciSequence(-1));
            Assert.Throws<OverflowException>(() => Program.FibonacciSequence(93));
        }
    }
}