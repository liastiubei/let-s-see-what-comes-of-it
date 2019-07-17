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
    }
}