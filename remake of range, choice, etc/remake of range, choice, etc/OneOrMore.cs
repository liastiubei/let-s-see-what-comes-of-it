using System;
using System.Collections.Generic;
using System.Text;

namespace RemakeOfRangeChoiceEtc
{
    class OneOrMore : IPattern
    {
        private readonly IPattern pattern;

        public OneOrMore(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            Sequence seq = new Sequence(new Many(this.pattern));
            if (!this.pattern.Match(text).Success())
            {
                return new Match(false, text);
            }

            return new Match(true, seq.Match(text).RemainingText());
        }
    }
}
