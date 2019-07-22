using System;
using System.Collections.Generic;
using System.Text;

namespace RemakeOfRangeChoiceEtc
{
    class Many : IPattern
    {
        private readonly IPattern pattern;

        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            var match = this.pattern.Match(text);
            while (match.Success())
            {
                text = match.RemainingText();
                match = this.pattern.Match(text);
            }

            return new Match(true, text);
        }
    }
}
