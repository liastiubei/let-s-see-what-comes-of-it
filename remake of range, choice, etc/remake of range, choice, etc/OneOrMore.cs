using System;
using System.Collections.Generic;
using System.Text;

namespace RemakeOfRangeChoiceEtc
{
    class OneOrMore
    {
        private readonly IPattern pattern;

        public OneOrMore(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            var oneOrMoreMatches = this.pattern.Match(text);
            if (!oneOrMoreMatches.Success())
            {
                return new Match(false, text);
            }

            while (oneOrMoreMatches.Success())
            {
                oneOrMoreMatches = this.pattern.Match(oneOrMoreMatches.RemainingText());
            }

            return new Match(true, oneOrMoreMatches.RemainingText());
        }
    }
}
