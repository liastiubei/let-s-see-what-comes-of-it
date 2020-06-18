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

        [Fact]
        public void CheckIfChangeFromStringToIntWorksCorrectly1()
        {
            LinqHomework.StringLinqHomework text = new LinqHomework.StringLinqHomework("118932");
            Assert.Equal(118932, text.ChangeFromStringToInt());
        }

        [Fact]
        public void CheckIfChangeFromStringToIntWorksCorrectly2()
        {
            LinqHomework.StringLinqHomework text = new LinqHomework.StringLinqHomework("-118932");
            Assert.Equal(-118932, text.ChangeFromStringToInt());
        }

        [Fact]
        public void CheckIfFindCharacterWhoAppearTheMostWorksCorrectly2()
        {
            LinqHomework.StringLinqHomework text = new LinqHomework.StringLinqHomework("ana are banane cu capsuni roz");
            Assert.Equal('a', text.FindCharacterWhoAppearTheMost());
        }

        [Fact]
        public void CheckIfResultingPalindromesWorksCorrectly()
        {
            LinqHomework.StringLinqHomework text = new LinqHomework.StringLinqHomework("aabaac");
            string[] result = { "a", "a", "b", "a", "a", "c", "aa", "aa", "aba", "aabaa" };
            Assert.Equal(result, text.ResultingPalindromes());
        }
    }
}
