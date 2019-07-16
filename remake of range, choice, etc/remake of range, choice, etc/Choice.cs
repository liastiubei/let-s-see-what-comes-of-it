using System;
using System.Collections.Generic;
using System.Text;

namespace RemakeOfRangeChoiceEtc
{
    class Choice : IPattern
    {
        public IPattern[] Pattern;

        public Choice(params IPattern[] pattern)
        {
            this.Pattern = pattern;
        }

        public IMatch Match(string line)
        {
            foreach (IPattern p in this.Pattern)
            {
                var match = p.Match(line);
                if (match.Success())
                {
                    return match;
                }
            }

            return new Match(false, line);
        }
    }
}
