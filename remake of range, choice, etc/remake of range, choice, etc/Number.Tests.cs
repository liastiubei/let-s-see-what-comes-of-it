using System;
using Xunit;

namespace Json
{
    public class NumberTests
    {
        readonly Number num = new Number();

        [Fact]
        public void ChecksIfNumberHasTheCorrectCharacters1()
        {
            Assert.Equal("", num.Match("1234.7e-2").RemainingText());
        }

        [Fact]
        public void ChecksIfNumberHasTheCorrectCharacters2ShouldReturnFalse()
        {
            Assert.Equal(false, num.Match("a01b 7e-2").Success());
        }

        [Fact]
        public void ChecksIfTooManyDots1()
        {
            Assert.Equal(".5", num.Match("123.4.5").RemainingText());
        }

        [Fact]
        public void ChecksIfTooManyDots2()
        {
            Assert.Equal("..3", num.Match("123.45E23..3").RemainingText());
        }

        [Fact]
        public void ChecksIfCorrectPlacementOfMinus1()
        {
            Assert.Equal("", num.Match("-123.4").RemainingText());
        }

        [Fact]
        public void ChecksIfCorrectPlacementOfMinus2()
        {
            Assert.Equal("", num.Match("-123.4e-45").RemainingText());
        }

        [Fact]
        public void ChecksIfCorrectPlacementOfMinus3()
        {
            Assert.Equal("-3.4", num.Match("12-3.4").RemainingText());
        }

        [Fact]
        public void ChecksIfCorrectPlacementOfMinus4()
        {
            Assert.Equal("-", num.Match("123.4e45-").RemainingText());
        }

        [Fact]
        public void ChecksIfCorrectNumberOfE()
        {
            Assert.Equal("E", num.Match("123.4e45E").RemainingText());
        }

        [Fact]
        public void ChecksIfCorrectBeginning1()
        {
            Assert.Equal("123", num.Match("0123").RemainingText());
        }

        [Fact]
        public void ChecksIfCorrectBeginning2ShouldReturnFalse()
        {
            Assert.Equal(false, num.Match("+123").Success());
        }

        [Fact]
        public void ChecksIfCorrectBeginning3ShouldReturnFalse()
        {
            Assert.Equal(false, num.Match(".12").Success());
        }

        [Fact]
        public void ChecksIfCorrectBeginning4ShouldReturnFalse()
        {
            Assert.Equal(false, num.Match("-.0123").Success());
        }

        [Fact]
        public void ChecksIfCorrectBeginning5()
        {
            Assert.Equal("+23", num.Match("-2.01+23").RemainingText());
        }

        [Fact]
        public void ChecksIfCorrectEnding1()
        {
            Assert.Equal("-7", num.Match("123.5e9-7").RemainingText());
        }

        [Fact]
        public void ChecksIfCorrectEnding2()
        {
            Assert.Equal("e.97", num.Match("123.5e.97").RemainingText());
        }

        [Fact]
        public void ChecksIfCorrectEnding3()
        {
            Assert.Equal("e++47", num.Match("123.5e++47").RemainingText());
        }

        [Fact]
        public void ChecksIfCorrectEnding4()
        {
            Assert.Equal("E", num.Match("123.5E").RemainingText());
        }

        [Fact]
        public void ChecksIfCorrectPerTotal1()
        {
            Assert.Equal("", num.Match("0.123").RemainingText());
        }

        [Fact]
        public void ChecksIfCorrectPerTotal2ShouldReturnTrue()
        {
            Assert.Equal("", num.Match("-45.9E12398.6").RemainingText());
        }
    }
}