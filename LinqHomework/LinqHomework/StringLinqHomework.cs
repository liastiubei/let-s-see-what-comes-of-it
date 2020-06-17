using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqHomework
{
    public class StringLinqHomework
    {
        string text;

        public StringLinqHomework(string text)
        {
            this.text = text;
        }

        public (int, int) NumberOfConsonantsAndVowelsInAString()
        {
            string vowels = "aeiou";
            Func<char, bool> isVowel = x => vowels.IndexOf(char.ToLower(x)) != -1;
            Func<char, bool> isConsonant = x =>
            {
                return char.IsLetter(x) && vowels.IndexOf(char.ToLower(x)) == -1;
            };
            return (text.Where(isConsonant).Count(), text.Where(isVowel).Count());
        }

        public char? FirstCharacterThatDoesntRepeat()
        {
            return text.GroupBy(x => x).FirstOrDefault(y => y.Count() == 1).Key;
        }
    }
}
