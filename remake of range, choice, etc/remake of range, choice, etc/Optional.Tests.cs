using System;
using Xunit;

namespace Json
{
    public class OptionalTests
    {
        [Fact]
        public void CheckIfOptionalReturnsTrueMatchIfItMatches()
        {
            Optional many = new Optional(new Character('a'));
            Assert.True(many.Match("abcde").Success());
        }

        [Fact]
        public void CheckIfOptionalReturnsTrueMatchIfItDoesntMatch()
        {
            Optional many = new Optional(new Character('a'));
            Assert.True(many.Match("bcde").Success());
        }

        [Fact]
        public void CheckIfOptionalRemovesThePatternIfItMatches()
        {
            Optional many = new Optional(new Character('a'));
            Assert.Equal("bcde", many.Match("abcde").RemainingText());
        }
    }
}