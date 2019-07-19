using System;
using Xunit;

namespace RemakeOfRangeChoiceEtc
{
    public class ListTests
    {
        [Fact]
        public void CheckIfItReturnsTrueIfElementMatches()
        {
            List variable = new List(new Character('a'), new Range('0', '9'));
            Assert.True(variable.Match("abcde").Success());
        }

        [Fact]
        public void CheckIfItReturnsTrueIfElementDoesntMatch()
        {
            List variable = new List(new Character('a'), new Range('0', '9'));
            Assert.True(variable.Match("bcdefgh").Success());
        }

        [Fact]
        public void CheckIfItRemovesTheCorrectLettersSoThatRemainingTextIsCorrect()
        {
            List variable = new List(new Character('a'), new Range('0', '9'));
            Assert.Equal("bcde", variable.Match("a0a9a4a7abcde").RemainingText());
        }
    }
}
