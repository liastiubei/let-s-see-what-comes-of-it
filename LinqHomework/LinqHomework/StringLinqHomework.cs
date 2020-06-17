using System;
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
            char[] textArray = this.text.ToCharArray();
            char[] vowels = { 'A', 'a', 'E', 'e', 'I', 'i', 'O', 'o', 'U', 'u' };
            char[] consonants = { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z',
                                  'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z'};
            Func<char, bool> isVowel = x => vowels.Contains(x);
            Func<char, bool> isConsonant = x => consonants.Contains(x);
            var z = textArray.Where(isConsonant).ToList();
            var y = textArray.Where(isVowel).ToList();
            return (textArray.Where(isConsonant).Count(), textArray.Where(isVowel).Count());
        }
    }
}
