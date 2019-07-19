using System;
using Xunit;

namespace RemakeOfRangeChoiceEtc
{
    public class OneOrMoreTests
    {
        [Fact]
        public void CheckIfItReturnsTrueIfItMatchesOne()
        {
            OneOrMore variable = new OneOrMore(new Character('a'));
            Assert.True(variable.Match("abcde").Success());
        }

        [Fact]
        public void CheckIfItReturnsTrueIfItMatchesSeveral()
        {
            OneOrMore variable = new OneOrMore(new Character('a'));
            Assert.True(variable.Match("aaaaabcde").Success());
        }

        [Fact]
        public void CheckIfItReturnsFalseIfItDoesntMatch()
        {
            OneOrMore variable = new OneOrMore(new Character('a'));
            Assert.False(variable.Match("bcde").Success());
        }

        [Fact]
        public void CheckIfRemainingTextIsCorrect()
        {
            OneOrMore variable = new OneOrMore(new Character('a'));
            Assert.Equal("bcde", variable.Match("aaaabcde").RemainingText());
        }
    }
}
