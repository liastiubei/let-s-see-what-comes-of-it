using System;
using System.Collections.Generic;
using System.Text;

namespace remake_of_range__choice__etc
{
    class Choice:IPattern
    {
        Character character;
        Range range;

        public Choice(Character character, Range range)
        {
            this.character = character;
            this.range = range;
        }

        public bool Match(string line)
        {
            return this.character.Match(line) || this.range.Match(line);
        }
    }
}
