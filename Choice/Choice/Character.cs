using System;
using System.Collections.Generic;
using System.Text;

namespace Choice
{
    class Character
    {
        private char character;

        public Character(char character)
        {
            this.character = character;
        }

        public bool Match(string text)
        {
            return text[0] == this.character;
        }
    }
}
