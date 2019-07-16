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
                var matchingPattern = pattern.Match(match.RemainingText());
                if (matchingPattern.Success())
                {
                    return new Match(false, text);
                }

                match = new Match(true, matchingPattern.RemainingText());
            }

            return match;
        }
    }
}
