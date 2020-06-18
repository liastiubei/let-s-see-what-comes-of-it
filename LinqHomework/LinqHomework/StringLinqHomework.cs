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
            var x = text.GroupBy(y => y).FirstOrDefault(y => y.Count() == 1);
            return x != default ? x.Key : default;
        }

        public int ChangeFromStringToInt()
        {
            int i;
            int minus;
            if (text[0] == '-')
            {
                i = text.Length - 2;
                minus = -1;
            }
            else
            {
                i = text.Length - 1;
                minus = 1;
            }

            Func<int, char, int> Accumulate = (n, character) =>
            {
                if (character == '-')
                {
                    return n;
                }

                int x = Convert.ToInt32(Math.Pow(10, i--));
                return n + Convert.ToInt32(char.GetNumericValue(character) * x);
            };

            return minus * text.Aggregate(0, Accumulate);

        }
    }
}
