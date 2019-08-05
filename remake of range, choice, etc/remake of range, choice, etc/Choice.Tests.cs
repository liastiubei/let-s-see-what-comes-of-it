using System;
using Xunit;

namespace RemakeOfRangeChoiceEtc
{
    public class ChoiceTests
    {
        [Fact]
        public void CheckIfChoiceWorks1ShouldReturnTrue()
        {
            var choice = new Choice(new Character('a'), new Range('c', 'f'));
            Assert.True(choice.Match("elefant").Success());
        }

        [Fact]
        public void CheckIfChoiceWorks2ShouldReturnFalse()
        {
            var choice = new Choice(new Character('a'), new Range('c', 'f'));
            Assert.False(choice.Match("bicicle").Success());
        }

        [Fact]
        public void CheckIfChoiceWorks3ShouldReturnTrue()
        {
            Choice choice = new Choice(new Character('a'), new Range('c', 'f'));
            var stuff = new Choice(choice, new Character('z'));
            Assert.True(stuff.Match("zilnic").Success());
        }

        [Fact]
        public void CheckIfChoiceHasCorrectRemainingTextIfSuccessIsTrue()
        {
            Choice choice = new Choice(new Character('a'), new Range('c', 'f'));
            var stuff = new Choice(choice, new Character('z'));
            Assert.Equal("ilnic", stuff.Match("zilnic").RemainingText());
        }

        [Fact]
        public void CheckIfChoiceHasCorrectRemainingTextIfSuccessIsFalse()
        {
            Choice choice = new Choice(new Character('a'), new Range('c', 'f'));
            var stuff = new Choice(choice, new Character('p'));
            Assert.Equal("zilnic", stuff.Match("zilnic").RemainingText());
        }

        [Fact]
        public void CheckIfChoiceHasCorrectAddOption()
        {
            Choice choice = new Choice(new Character('a'), new Range('c', 'f'));
            choice.Add(new Character('p'));
            Assert.True(choice.Match("adp").Success());
        }
    }
}