using System;
using Xunit;

namespace RemakeOfRangeChoiceEtc
{
    public class ValueTests
    {
        readonly Value value = new Value();

        [Fact]
        public void CheckIfValueMatchesCorrectlyNullShouldReturnTrue()
        {
            Assert.Equal(true, value.Match("null").Success());
        }

        [Fact]
        public void CheckIfValueMatchesCorrectlyTrueShouldReturnTrue()
        {
            Assert.Equal(true, value.Match("true").Success());
        }

        [Fact]
        public void CheckIfValueMatchesCorrectlyFalseShouldReturnTrue()
        {
            Assert.Equal(true, value.Match("false").Success());
        }

        [Fact]
        public void CheckIfValueMatchesCorrectlyNumberShouldReturnTrue()
        {
            Assert.Equal(true, value.Match("-123.4e-45").Success());
        }
    }
}
