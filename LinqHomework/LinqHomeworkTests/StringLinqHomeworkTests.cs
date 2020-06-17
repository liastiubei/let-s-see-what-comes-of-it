using System;
using System;
using System.Collections.Generic;
using Xunit;

namespace LinqHomeworkTests
{
    public class StringLinqHomeworkTests
    {
        [Fact]
        public void CheckIfNumberOfConsonantsAndVowelsInAStringWorksCorrectly1()
        {
            LinqHomework.StringLinqHomework text = new LinqHomework.StringLinqHomework("Ana are mere");
            Assert.Equal((4, 6), text.NumberOfConsonantsAndVowelsInAString());
        }

        [Fact]
        public void CheckIfNumberOfConsonantsAndVowelsInAStringWorksCorrectly2()
        {
            LinqHomework.StringLinqHomework text = new LinqHomework.StringLinqHomework("abcdefghijklmnopqrstuvwxyz");
            Assert.Equal((21, 5), text.NumberOfConsonantsAndVowelsInAString());
        }

        [Fact]
        public void CheckIfFirstCharacterThatDoesntRepeatWorksCorrectly1()
        {
            LinqHomework.StringLinqHomework text = new LinqHomework.StringLinqHomework("ana are banane cu capsuni roz");
            Assert.Equal('b', text.FirstCharacterThatDoesntRepeat());
        }
    }
}
