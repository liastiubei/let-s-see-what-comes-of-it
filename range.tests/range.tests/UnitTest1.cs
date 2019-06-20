using System;
using Xunit;

namespace range.tests
{
    public class UnitTest1
    {
        [Fact]
        public void ChecksRangeForRangeOf1Letter_ShouldReturnTrue()
        {
            var range = new Range('a', 'a');
            Assert.True(range.Match("a"));
        }

        [Fact]
        public void ChecksRangeForRangeOf1Letter_ShouldReturnFalse()
        {
            var range = new Range('a', 'a');
            Assert.True(!range.Match("c"));
        }

        [Fact]
        public void ChecksRangeForRangeOfSeveralLetter_ShouldReturnTrue()
        {
            var range = new Range('a', 'r');
            Assert.True(range.Match("pampom"));
        }

        [Fact]
        public void ChecksRangeForRangeOfNumbers_ShouldReturnTrue()
        {
            var range = new Range('1', '7');
            Assert.True(range.Match("45"));
        }

        [Fact]
        public void ChecksRangeForRangeOfNumbersAndLetters_ShouldReturnTrue()
        {
            var range = new Range('1', 'p');
            Assert.True(range.Match("9A2" +
                ""));
        }


    }
}
