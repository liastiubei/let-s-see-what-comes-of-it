using System;
using Xunit;

namespace RemakeOfRangeChoiceEtc
{
    public class NumberTests
    {
        readonly Number num = new Number();

        [Fact]
        public void ChecksIfNumberHasTheCorrectCharacters1ShouldReturnTrue()
        {
            Assert.Equal(true, num.Match("1234.7e-2").Success());
        }

        [Fact]
        public void ChecksIfNumberHasTheCorrectCharacters2ShouldReturnFalse()
        {
            Assert.Equal(false, num.Match("a01b 7e-2").Success());
        }

        [Fact]
        public void ChecksIfTooManyDots1ShouldReturnFalse()
        {
            Assert.Equal(false, num.Match("123.4.5").Success());
        }

        [Fact]
        public void ChecksIfTooManyDots2ShouldReturnFalse()
        {
            Assert.Equal(false, num.Match("123.45E23..3").Success());
        }

        [Fact]
        public void ChecksIfTooManyDotsShouldReturnFalse()
        {
            Assert.Equal(false, num.Match("123.4.5").Success());
        }

        [Fact]
        public void ChecksIfCorrectPlacementOfMinus1ShouldReturnTrue()
        {
            Assert.Equal(true, num.Match("-123.4").Success());
        }

        [Fact]
        public void ChecksIfCorrectPlacementOfMinus2ShouldReturnTrue()
        {
            Assert.Equal(true, num.Match("-123.4e-45").Success());
        }

        [Fact]
        public void ChecksIfCorrectPlacementOfMinus3ShouldReturnFalse()
        {
            Assert.Equal(false, num.Match("12-3.4").Success());
        }

        [Fact]
        public void ChecksIfCorrectPlacementOfMinus4ShouldReturnFalse()
        {
            Assert.Equal(false, num.Match("123.4e45-").Success());
        }

        [Fact]
        public void ChecksIfCorrectNumberOfEShouldReturnFalse()
        {
            Assert.Equal(false, num.Match("123.4e45E").Success());
        }

        [Fact]
        public void ChecksIfCorrectBeginning1ShouldReturnFalse()
        {
            Assert.Equal(false, num.Match("0123").Success());
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
        public void ChecksIfCorrectBeginning5ShouldReturnFalse()
        {
            Assert.Equal(false, num.Match("-2.01+23").Success());
        }

        [Fact]
        public void ChecksIfCorrectEnding1ShouldReturnFalse()
        {
            Assert.Equal(false, num.Match("123.5e9-7").Success());
        }

        [Fact]
        public void ChecksIfCorrectEnding2ShouldReturnFalse()
        {
            Assert.Equal(false, num.Match("123.5e.97").Success());
        }

        [Fact]
        public void ChecksIfCorrectEnding3ShouldReturnFalse()
        {
            Assert.Equal(false, num.Match("123.5e++47").Success());
        }

        [Fact]
        public void ChecksIfCorrectEnding4ShouldReturnFalse()
        {
            Assert.Equal(false, num.Match("123.5E").Success());
        }

        [Fact]
        public void ChecksIfCorrectPerTotal1ShouldReturnTrue()
        {
            Assert.Equal(true, num.Match("0.123").Success());
        }

        [Fact]
        public void ChecksIfCorrectPerTotal2ShouldReturnTrue()
        {
            Assert.Equal(true, num.Match("-45.9E12398.6").Success());
        }
    }
}