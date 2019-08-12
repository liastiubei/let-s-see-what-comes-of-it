using System;
using Xunit;

namespace Json
{
    public class SequenceTests
    {
        [Fact]
        public void CheckIfSequenceWorksBoolValue1ShouldReturnTrue()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            Assert.True(ab.Match("abcd").Success());
        }

        [Fact]
        public void CheckIfSequenceWorksBoolValue2ShouldReturnFalse()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            Assert.False(ab.Match("acbd").Success());
        }

        [Fact]
        public void CheckIfSequenceWorksRemainingText1ShouldReturnAppropiateResponse()
        {
            var ab = new Sequence(new Character('a'));
            Assert.Equal("bcd", ab.Match("abcd").RemainingText());
        }

        [Fact]
        public void CheckIfSequenceWorksRemainingText2ShouldReturnAppropiateResponse()
        {
            var abc = new Sequence(new Character('b'), new Character('c'), new Character('d'));
            Assert.Equal("alfabet", abc.Match("alfabet").RemainingText());
        }

        [Fact]
        public void CheckIfSequenceWorksRemainingText3ShouldReturnAppropiateResponse()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            var seq = new Sequence(ab, new Character('0'), new Range('a', 'e'));
            Assert.Equal("", seq.Match("ab0d").RemainingText());
        }
    }
}
