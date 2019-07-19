using System;
using System.Collections.Generic;
using System.Text;

namespace RemakeOfRangeChoiceEtc
{
    class Optional : IPattern
    {
        private readonly IPattern pattern;

        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            var optionalMatch = this.pattern.Match(text);
            if (optionalMatch.Success())
            {
                return new Match(true, optionalMatch.RemainingText());
            }

            return new Match(true, text);
        }
    }
}
