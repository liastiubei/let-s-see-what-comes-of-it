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
            var minus = text[0] == '-' ? -1 : 1;

            Func<int, char, int> Accumulate = (n, character) =>
            {
                if (character == '-')
                {
                    return n;
                }

                return n * 10 + Convert.ToInt32(char.GetNumericValue(character));
            };

            return minus * text.Aggregate(0, Accumulate);

        }

        public char FindCharacterWhoAppearTheMost()
        {
            return text.GroupBy(y => y).OrderByDescending(y => y.Count()).First().Key;
        }

        public IEnumerable<string> ResultingPalindromes()
        {
            return Enumerable
                .Range(1, text.Length)
                .SelectMany(length => Enumerable.Range(0, text.Length - length + 1)
                                                .Select(x => text.Substring(x, length)))
                                                .Where(x => x.SequenceEqual(x.Reverse()))
                .ToArray();
        }

        public List<string> TopOfMostUsedWords(int n)
        {
            string[] words = text.Split(' ');
            var top = words.GroupBy(x => x).OrderByDescending(x => x.Count()).Select(x => x.Key);
            return top.Count() <= n ? top.ToList() : top.Take(n).ToList();
        }
    }
}
