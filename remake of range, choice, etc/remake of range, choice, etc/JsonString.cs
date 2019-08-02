using System;
using System.Collections.Generic;
using System.Text;

namespace RemakeOfRangeChoiceEtc
{
    class JsonString : IPattern
    {
        private readonly IPattern pattern;

        public JsonString()
        {
            Choice hex = new Choice(new Range('0', '9'), new Range('a', 'f'), new Range('A', 'F'));
            Choice backslash = new Choice(new Any("\"\\/bfnrt"), new Sequence(new Character('u'), hex, hex, hex, hex));
            Choice choice = new Choice(new Range(' ', '!'), new Range('#', '['), new Range(']', '\u007F'), new Sequence(new Character('\\'), backslash));
            this.pattern = new Sequence(new Character('\"'), new OneOrMore(choice), new Character('\"'));
        }

        public IMatch Match(string text)
        {
            if (pattern.Match(text).RemainingText() != "")
            {
                return new Match(false, text);
            }

            return pattern.Match(text);
        }
    }
}
