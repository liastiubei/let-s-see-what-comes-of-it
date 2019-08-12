using System;
using Xunit;

namespace RemakeOfRangeChoiceEtc
{
    public class JsonStringTests
    {
        readonly JsonString checkString = new JsonString();

        [Fact]
        public void CheckIfQuotationMarksArePresentInTheBeginningAndEndShouldReturnTrue()
        {
            Assert.Equal("", checkString.Match("\"text\"").RemainingText());
        }

        [Fact]
        public void CheckIfQuotationMarksAreUsedCorrectlyForTheRestOfTheStringShouldReturnFalse()
        {
            Assert.Equal(false, checkString.Match("\"t\"ext\"").Success());
        }

        [Fact]
        public void CheckIfAsciiBiggerThan31ShouldReturnFalse()
        {
            const string line = "\"text\u0000\"";
            Assert.Equal(false, checkString.Match(line).Success());
        }

        [Fact]
        public void CheckIfBackslashIsUsedCorrectly1ShouldReturnTrue()
        {
            Assert.Equal(true, checkString.Match("\"text\\\"\"").Success());
        }

        [Fact]
        public void CheckIfBackslashIsUsedCorrectly2ShouldReturnTrue()
        {
            Assert.Equal(true, checkString.Match("\"text\\\\\"").Success());
        }

        [Fact]
        public void CheckIfBackslashIsUsedCorrectly3ShouldReturnTrue()
        {
            const string line = "\"text\\\u002F\"";
            Assert.Equal(true, checkString.Match(line).Success());
        }

        [Fact]
        public void CheckIfBackslashIsUsedCorrectly4ShouldReturnTrue()
        {
            const string line = "\"text\\b\"";
            Assert.Equal(true, checkString.Match(line).Success());
        }

        [Fact]
        public void CheckIfBackslashIsUsedCorrectly5ShouldReturnTrue()
        {
            const string line = "\"text\\f\"";
            Assert.Equal(true, checkString.Match(line).Success());
        }

        [Fact]
        public void CheckIfBackslashIsUsedCorrectly6ShouldReturnTrue()
        {
            const string line = "\"text\\n\"";
            Assert.Equal(true, checkString.Match(line).Success());
        }

        [Fact]
        public void CheckIfBackslashIsUsedCorrectly7ShouldReturnTrue()
        {
            const string line = "\"text\\r\"";
            Assert.Equal(true, checkString.Match(line).Success());
        }

        [Fact]
        public void CheckIfBackslashIsUsedCorrectly8ShouldReturnTrue()
        {
            const string line = "\"text\\t\"";
            Assert.Equal(true, checkString.Match(line).Success());
        }

        [Fact]
        public void CheckIfBackslashIsUsedCorrectly9ShouldReturnTrue()
        {
            const string line = "\"text\\u002F\"";
            Assert.Equal(true, checkString.Match(line).Success());
        }
    }
}
