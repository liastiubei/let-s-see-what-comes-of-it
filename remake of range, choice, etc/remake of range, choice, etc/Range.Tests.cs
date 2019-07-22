using System;
using Xunit;

namespace RemakeOfRangeChoiceEtc
{
    public class RangeTests
    {
        [Fact]
        public void CheckIfRangeWorks1ShouldReturnTrue()
        {
            Range range = new Range('a', 'i');
            Assert.True(range.Match("hellicopter").Success());
        }

        [Fact]
        public void CheckIfRangeWorks2ShouldReturnFalse()
        {
            Range range = new Range('a', 'g');
            Assert.False(range.Match("xulescu").Success());
        }

        [Fact]
        public void CheckIfRanceWorksWhenTextIsNullShouldReturnFalse()
        {
            Range range = new Range('a', 'g');
            Assert.False(range.Match(null).Success());
        }

        [Fact]
        public void CheckIfRangeWorksWhenTextIsEmptyShouldReturnFalse()
        {
            Range range = new Range('a', 'g');
            Assert.False(range.Match("").Success());
        }

        [Fact]
        public void CheckIfRemainingTextIsCorrect()
        {
            Range range = new Range('a', 'g');
            Assert.Equal("lfabet", range.Match("alfabet").RemainingText());
        }
    }
}