using System;
using Xunit;

namespace RemakeOfRangeChoiceEtc
{
    public class UnitTest1
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
        public void CheckIfChoiceWorks1ShouldReturnTrue()
        {
            var choice = new Choice(new Character('a'), new Range('c', 'f'));
            Assert.True(choice.Match("elefant").Success());
        }

        [Fact]
        public void CheckIfChoiceWorks2ShouldReturnFalse()
        {
            var choice = new Choice(new Character('a'), new Range('c', 'f'));
            Assert.False(choice.Match("bicicle").Success());
        }

        [Fact]
        public void CheckIfChoiceWorks3ShouldReturnTrue()
        {
            Choice choice = new Choice(new Character('a'), new Range('c', 'f'));
            var stuff = new Choice(choice, new Character('z'));
            Assert.True(stuff.Match("zilnic").Success());
        }

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
