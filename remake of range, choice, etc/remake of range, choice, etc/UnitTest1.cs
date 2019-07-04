using System;
using Xunit;

namespace remake_of_range__choice__etc
{
    public class UnitTest1
    {
        [Fact]
        public void CheckIfRangeWorks1_ShouldReturnTrue()
        {
            Range range = new Range('a', 'i');
            Assert.True(range.Match("hellicopter"));
        }

        [Fact]
        public void CheckIfRangeWorks2_ShouldReturnFalse()
        {
            Range range = new Range('a', 'g');
            Assert.True(!range.Match("xulescu"));
        }

        [Fact]
        public void CheckIfCharacterWorks_ShouldReturnTrue()
        {
            Character c = new Character('a');
            Assert.True(c.Match("aura"));
        }
    }
}