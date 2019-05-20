using System;
using Xunit;

namespace Json_number_check.tests
{
    public class UnitTest1
    {
        [Fact]
        public void ChecksIfNumberHasTheCorrectCharacters1_ShouldReturnTrue()
        {
            Assert.Equal(true, Program.JsonNumCheck("1234.7e-2"));
        }

        [Fact]
        public void ChecksIfNumberHasTheCorrectCharacters2_ShouldReturnFalse()
        {
            Assert.Equal(false, Program.JsonNumCheck("a01b 7e-2"));
        }

        [Fact]
        public void ChecksIfTooManyDots1_ShouldReturnFalse()
        {
            Assert.Equal(false, Program.JsonNumCheck("123.4.5"));
        }

        [Fact]
        public void ChecksIfTooManyDots2_ShouldReturnFalse()
        {
            Assert.Equal(false, Program.JsonNumCheck("123.45E23..3"));
        }

        [Fact]
        public void ChecksIfTooManyDots_ShouldReturnFalse()
        {
            Assert.Equal(false, Program.JsonNumCheck("123.4.5"));
        }

        [Fact]
        public void ChecksIfCorrectPlacementOfMinus1_ShouldReturnTrue()
        {
            Assert.Equal(true, Program.JsonNumCheck("-123.4"));
        }

        [Fact]
        public void ChecksIfCorrectPlacementOfMinus2_ShouldReturnTrue()
        {
            Assert.Equal(true, Program.JsonNumCheck("-123.4e-45"));
        }

        [Fact]
        public void ChecksIfCorrectPlacementOfMinus3_ShouldReturnFalse()
        {
            Assert.Equal(false, Program.JsonNumCheck("12-3.4"));
        }

        [Fact]
        public void ChecksIfCorrectPlacementOfMinus4_ShouldReturnFalse()
        {
            Assert.Equal(false, Program.JsonNumCheck("123.4e45-"));
        }

        [Fact]
        public void ChecksIfCorrectNumberOfE_ShouldReturnFalse()
        {
            Assert.Equal(false, Program.JsonNumCheck("123.4e45E"));
        }

        [Fact]
        public void ChecksIfCorrectBeginning1_ShouldReturnFalse()
        {
            Assert.Equal(false, Program.JsonNumCheck("0123"));
        }

        [Fact]
        public void ChecksIfCorrectBeginning2_ShouldReturnFalse()
        {
            Assert.Equal(false, Program.JsonNumCheck("+123"));
        }

        [Fact]
        public void ChecksIfCorrectBeginning3_ShouldReturnFalse()
        {
            Assert.Equal(false, Program.JsonNumCheck(".12"));
        }

        [Fact]
        public void ChecksIfCorrectBeginning4_ShouldReturnFalse()
        {
            Assert.Equal(false, Program.JsonNumCheck("-.0123"));
        }

        [Fact]
        public void ChecksIfCorrectBeginning5_ShouldReturnFalse()
        {
            Assert.Equal(false, Program.JsonNumCheck("-2.01+23"));
        }

        [Fact]
        public void ChecksIfCorrectEnding1_ShouldReturnFalse()
        {
            Assert.Equal(false, Program.JsonNumCheck("123.5e9-7"));
        }

        [Fact]
        public void ChecksIfCorrectEnding2_ShouldReturnFalse()
        {
            Assert.Equal(false, Program.JsonNumCheck("123.5e.97"));
        }

        [Fact]
        public void ChecksIfCorrectEnding3_ShouldReturnFalse()
        {
            Assert.Equal(false, Program.JsonNumCheck("123.5e++47"));
        }

        [Fact]
        public void ChecksIfCorrectEnding4_ShouldReturnFalse()
        {
            Assert.Equal(false, Program.JsonNumCheck("123.5E"));
        }

        [Fact]
        public void ChecksIfCorrectPerTotal1_ShouldReturnTrue()
        {
            Assert.Equal(true, Program.JsonNumCheck("0.123"));
        }

        [Fact]
        public void ChecksIfCorrectPerTotal2_ShouldReturnTrue()
        {
            Assert.Equal(true, Program.JsonNumCheck("-45.9E12398.6"));
        }
    }
}