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
            var ws = new Any(" \n\t\r");
            var hex = new Choice(new Range('0', '9'), new Range('a', 'f'), new Range('A', 'F'));
            var backslash = new Choice(new Any("\"\\/bfnrt"), new Sequence(new Character('u'), hex, hex, hex, hex));
            var allThatIsInside = new Choice(new Range(' ', '!'), new Range('#', '['), new Range(']', '\u007F'), new Sequence(new Character('\\'), backslash));
            var afterEverything = new Choice(ws, new Text(""));
            this.pattern = new Sequence(new Character('\"'), new OneOrMore(allThatIsInside), new Character('\"'));
        }

        public IMatch Match(string text)
        {
            if (pattern.Match(text).RemainingText().Length > 0 && (!" \n\t\r".Contains(pattern.Match(text).RemainingText()[0])))
            {
                return new Match(false, text);
            }

            return pattern.Match(text);
        }
    }
}
