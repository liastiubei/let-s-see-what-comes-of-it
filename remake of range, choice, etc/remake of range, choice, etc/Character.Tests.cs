using System;
using Xunit;

namespace RemakeOfRangeChoiceEtc
{
    public class CharacterTests
    {
        [Fact]
        public void CheckIfCharacterWorks1ShouldReturnTrue()
        {
            Character c = new Character('a');
            Assert.True(c.Match("aura").Success());
        }

        [Fact]
        public void CheckIfCharacterWorks2ShouldReturnFalse()
        {
            Character c = new Character('a');
            Assert.False(c.Match("Chocolate").Success());
        }

        [Fact]
        public void CheckIfCharacterWorksWhenTextIsNullShouldReturnFalse()
        {
            Character c = new Character('c');
            Assert.False(c.Match(null).Success());
        }

        [Fact]
        public void CheckIfCharacterWorksWhenTextIsEmptyShouldReturnFalse()
        {
            Character c = new Character('c');
            Assert.False(c.Match("").Success());
        }
    }
}