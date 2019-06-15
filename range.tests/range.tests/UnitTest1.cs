using System;
using Xunit;

namespace range.tests
{
    public class UnitTest1
    {
        [Fact]
        public void ChecksRangeForRangeOf1Letter_ShouldReturnTrue()
        {
            var range = new Range('a', 'a');
            Assert.True(range.Match("a"));
        }
    }
}
