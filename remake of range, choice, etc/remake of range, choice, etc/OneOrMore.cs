using System;
using System.Collections.Generic;
using System.Text;

namespace RemakeOfRangeChoiceEtc
{
    class OneOrMore : IPattern
    {
        private IPattern pattern;

        public OneOrMore(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            if (!this.pattern.Match(text).Success())
            {
                return new Match(false, text);
            }

            this.pattern = new Sequence(new Many(this.pattern));

            return this.pattern.Match(text);
        }
    }
}
