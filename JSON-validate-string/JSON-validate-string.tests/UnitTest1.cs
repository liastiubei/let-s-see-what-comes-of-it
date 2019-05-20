using System;
using Xunit;

namespace JSON_validate_string.tests
{
    public class UnitTest1
    {
        [Fact]
        public void CheckIfQuotationMarksArePresentInTheBeginningAndEnd_ShouldReturnTrue()
        {
            Assert.Equal(true, Program.CheckIfValidString("\"text\""));
        }

        [Fact]
        public void CheckIfQuotationMarksAreUsedCorrectlyForTheRestOfTheString_ShouldReturnFalse()
        {
            Assert.Equal(false, Program.CheckIfValidString("\"t\"ext\""));
        }

        [Fact]
        public void CheckIfAsciiBiggerThan31_ShouldReturnFalse()
        {
            char a ='\u0000';
            string line = "\"text"+a.ToString()+ "\"";
            Assert.Equal(false, Program.CheckIfValidString(line));
        }

        [Fact]
        public void CheckIfBackslashIsUsedCorrectly1_ShouldReturnTrue()
        {
            Assert.Equal(true, Program.CheckIfValidString("\"text\\\"\""));
        }

        [Fact]
        public void CheckIfBackslashIsUsedCorrectly2_ShouldReturnTrue()
        {
            Assert.Equal(true, Program.CheckIfValidString("\"text\\\\\""));
        }

        [Fact]
        public void CheckIfBackslashIsUsedCorrectly3_ShouldReturnTrue()
        {
            string line = "\"text\\" + "\u002F" + "\"";
            Assert.Equal(true, Program.CheckIfValidString(line));
        }

        [Fact]
        public void CheckIfBackslashIsUsedCorrectly4_ShouldReturnTrue()
        {
            string line = "\"text\\b\"";
            Assert.Equal(true, Program.CheckIfValidString(line));
        }

        [Fact]
        public void CheckIfBackslashIsUsedCorrectly5_ShouldReturnTrue()
        {
            string line = "\"text\\f\"";
            Assert.Equal(true, Program.CheckIfValidString(line));
        }

        [Fact]
        public void CheckIfBackslashIsUsedCorrectly6_ShouldReturnTrue()
        {
            string line = "\"text\\n\"";
            Assert.Equal(true, Program.CheckIfValidString(line));
        }

        [Fact]
        public void CheckIfBackslashIsUsedCorrectly7_ShouldReturnTrue()
        {
            string line = "\"text\\r\"";
            Assert.Equal(true, Program.CheckIfValidString(line));
        }

        [Fact]
        public void CheckIfBackslashIsUsedCorrectly8_ShouldReturnTrue()
        {
            string line = "\"text\\t\"";
            Assert.Equal(true, Program.CheckIfValidString(line));
        }

        [Fact]
        public void CheckIfBackslashIsUsedCorrectly9_ShouldReturnTrue()
        {
            string line = "\"text\\u002F\"";
            Assert.Equal(true, Program.CheckIfValidString(line));
        }
    }
}
