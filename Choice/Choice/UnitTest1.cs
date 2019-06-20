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
    }
}
