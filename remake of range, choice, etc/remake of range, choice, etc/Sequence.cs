using System;
using System.Collections.Generic;
using System.Text;

namespace RemakeOfRangeChoiceEtc
{
    class Sequence : IPattern
    {
        private readonly IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            var match = new Match(true, text);
            foreach (var pattern in patterns)
            {
                if (!pattern.Match(match.RemainingText()).Success())
                {
                    return new Match(false, text);
                }

                string remainingText = match.RemainingText();
                match = new Match(true, pattern.Match(match.RemainingText()).RemainingText());
            }

            return match;
        }
    }
}
