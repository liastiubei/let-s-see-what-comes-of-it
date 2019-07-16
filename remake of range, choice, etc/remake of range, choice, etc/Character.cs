using System;
using System.Collections.Generic;
using System.Text;

namespace RemakeOfRangeChoiceEtc
{
    class Character : IPattern
    {
        private readonly char character;

        public Character(char character)
        {
            this.character = character;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new Match(false, text);
            }

            return new Match(text[0] == this.character, text.Substring(1));
        }
    }
}
