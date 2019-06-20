using System;
using Xunit;

namespace Choice
{
    public class UnitTest1
    {
        [Fact]
        public void CheckIfCharacterMatchWorks_ShouldReturnTrue()
        {
            var character = new Character('a');
            Assert.True(character.Match("asparagus"));
        }
    }
}
