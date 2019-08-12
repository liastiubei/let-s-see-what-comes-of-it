using System;
using Xunit;

namespace Json
{
    public class AnyTests
    {
        [Fact]
        public void CheckIfAnyWorksWith1Letter()
        {
            Any any = new Any("a");
            Assert.True(any.Match("aura").Success());
        }

        [Fact]
        public void CheckIfAnyWorksWithSeveralLetters()
        {
            Any any = new Any("alfabet");
            Assert.True(any.Match("laura").Success());
        }

        [Fact]
        public void CheckIfAnyWorksWithSeveralLettersShouldReturnFalse()
        {
            Any any = new Any("alfabet");
            Assert.False(any.Match("nabucodonosor").Success());
        }

        [Fact]
        public void CheckIfRemainingLettersAreCorrect()
        {
            Any any = new Any("alfabet");
            Assert.Equal("aura", any.Match("laura").RemainingText());
        }
    }
}