using System;
using Xunit;

namespace RemakeOfRangeChoiceEtc
{
    public class ValueTests
    {
        readonly Value checkString = new Value();

        [Fact]
        public void CheckIfCharacterReturnsCorrectRemainingTextWhenSuccesIsFalse()
        {
            Assert.Equal(true, checkString.Match("\"text\"").Success());
        }
    }
}
