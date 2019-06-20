using System;
using Xunit;

namespace Choice
{
    public class UnitTest1
    {
        [Fact]
        public void CheckIfCharacterMatchWorks1_ShouldReturnTrue()
        {
            var character = new Character('a');
            Assert.True(character.Match("asparagus"));
        }

        [Fact]
        public void CheckIfCharacterMatchWorks2_ShouldReturnFalse()
        {
            var character = new Character('a');
            Assert.True(!character.Match("118932a"));
        }

        [Fact]
        public void CheckIfChoiceWorks1_ShouldReturnTrue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
                );
            Assert.True(digit.Match("118932a"));
        }

        [Fact]
        public void CheckIfChoiceWorks2_ShouldReturnFalse()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
                );
            Assert.True(!digit.Match("a145"));
        }
    }
}
