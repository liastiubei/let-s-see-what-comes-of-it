using System;
using System.Collections.Generic;
using System.Text;

namespace Json
{
    public class Character : IPattern
    {
        private readonly char character;

        public Character(char character)
        {
            this.character = character;
        }

        public IMatch Match(string text)
        {
            return !string.IsNullOrEmpty(text) && text[0] == this.character
                 ? new Match(true, text.Substring(1))
                 : new Match(false, text);
        }
    }
}
