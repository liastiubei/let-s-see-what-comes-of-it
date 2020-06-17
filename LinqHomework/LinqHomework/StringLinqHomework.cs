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
            var comparer = new LetterCaseInsensitiveEqualityComparer();
            string vowels = "aeiou";
            Func<char, bool> isVowel = x => vowels.Contains(x, comparer);
            Func<char, bool> isConsonant = x =>
            {
                return char.IsLetter(x) && !vowels.Contains(x, comparer);
            };
            return (text.Where(isConsonant).Count(), text.Where(isVowel).Count());
        }

        public char FirstCharacterThatDoesntRepeat()
        {
            Func<char, bool> doesntRepeat = x => text.IndexOf(x) == text.LastIndexOf(x);
            return text.First(doesntRepeat);
        }

        class LetterCaseInsensitiveEqualityComparer : IEqualityComparer<char>
        {
            public bool Equals(char x, char y)
            {
                return char.ToUpper(x) == char.ToUpper(y);
            }

            public int GetHashCode(char obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
