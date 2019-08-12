using System;
using Xunit;

namespace Json
{
    public class TestTests
    {
        [Fact]
        public void CheckIfTextWorksWith1Letter()
        {
            Text text = new Text("a");
            Assert.True(text.Match("aura").Success());
        }

        [Fact]
        public void CheckIfTextWorksWithSeveralLetters()
        {
            Text text = new Text("aur");
            Assert.True(text.Match("aura").Success());
        }

        [Fact]
        public void CheckIfTextWorksWithSeveralLettersShouldReturnFalse()
        {
            Text text = new Text("aur");
            Assert.False(text.Match("nabuco").Success());
        }

        [Fact]
        public void CheckIfRemainingLettersAreCorrect()
        {
            Text text = new Text("alfabet");
            Assert.Equal("ar", text.Match("alfabetar").RemainingText());
        }
    }
}