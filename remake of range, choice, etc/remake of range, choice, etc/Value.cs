using System;
using System.Collections.Generic;
using System.Text;

namespace RemakeOfRangeChoiceEtc
{
    public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            this.pattern = new Choice(new JsonString(), new Number());
        }

        public IMatch Match(string text)
        {
            return this.pattern.Match(text);
        }
    }
}
