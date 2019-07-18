using System;
using Xunit;

namespace RemakeOfRangeChoiceEtc
{
    public class ManyTests
    {
        [Fact]
        public void CheckIfManyReturnsTrueMatch()
        {
            Many many = new Many(new Character('a'));
            Assert.True(many.Match("bcde").Success());
        }

        [Fact]
        public void CheckIfManyConsumes1Letter()
        {
            Many many = new Many(new Character('a'));
            Assert.Equal("bc", many.Match("abc").RemainingText());
        }

        [Fact]
        public void CheckIfManyConsumesSeveralLetters()
        {
            Many many = new Many(new Character('a'));
            Assert.Equal("bc", many.Match("aaaaaaabc").RemainingText());
        }
    }
}