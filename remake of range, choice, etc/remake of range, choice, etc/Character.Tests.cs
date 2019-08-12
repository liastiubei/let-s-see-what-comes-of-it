using System;
using Xunit;

namespace Json
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

        [Fact]
        public void CheckIfCharacterReturnsCorrectRemainingTextWhenSuccesIsTrue()
        {
            Character c = new Character('c');
            Assert.Equal("ola", c.Match("cola").RemainingText());
        }

        [Fact]
        public void CheckIfCharacterReturnsCorrectRemainingTextWhenSuccesIsFalse()
        {
            Character c = new Character('c');
            Assert.Equal("parfum", c.Match("parfum").RemainingText());
        }
    }
}