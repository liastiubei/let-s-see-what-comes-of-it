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
            Assert.True(range.Match("hellicopter").Succes());
        }

        [Fact]
        public void CheckIfRangeWorks2_ShouldReturnFalse()
        {
            Range range = new Range('a', 'g');
            Assert.False(range.Match("xulescu").Succes());
        }

        [Fact]
        public void CheckIfCharacterWorks1_ShouldReturnTrue()
        {
            Character c = new Character('a');
            Assert.True(c.Match("aura").Succes());
        }

        [Fact]
        public void CheckIfCharacterWorks2_ShouldReturnFalse()
        {
            Character c = new Character('a');
            Assert.False(c.Match("Chocolate").Succes());
        }

        [Fact]
        public void CheckIfChoiceWorks1_ShouldReturnTrue()
        {
            var choice = new Choice(new Character('a'), new Range('c', 'f'));
            Assert.True(choice.Match("elefant").Succes());
        }

        [Fact]
        public void CheckIfChoiceWorks2_ShouldReturnFalse()
        {
            var choice = new Choice(new Character('a'), new Range('c', 'f'));
            Assert.False(choice.Match("bicicle").Succes());
        }

        [Fact]
        public void CheckIfChoiceWorks3_ShouldReturnTrue()
        {
            Choice choice = new Choice(new Character('a'), new Range('c', 'f'));
            var stuff = new Choice(choice, new Character('z'));
            Assert.True(stuff.Match("zilnic").Succes());
        }

        [Fact]
        public void CheckIfSequenceWorksBoolValue1_ShouldReturnTrue()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            Assert.True(ab.Match("abcd").Succes());
        }

        [Fact]
        public void CheckIfSequenceWorksBoolValue2_ShouldReturnFalse()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            Assert.False(ab.Match("acbd").Succes());
        }
        
        [Fact]
        public void CheckIfSequenceWorksRemainingText1_ShouldReturnAppropiateResponse()
        {
            var ab = new Sequence(new Character('a'));
            Assert.Equal("bcd",ab.Match("abcd").RemainingText());
        }

        [Fact]
        public void CheckIfSequenceWorksRemainingText2_ShouldReturnAppropiateResponse()
        {
            var ab = new Sequence(new Character('a'), new Character('b'), new Character('c'));
            Assert.Equal("alfabet", ab.Match("alfabet").RemainingText());
        }

    }
}
