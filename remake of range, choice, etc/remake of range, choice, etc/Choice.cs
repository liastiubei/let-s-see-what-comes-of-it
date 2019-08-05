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

        public void Add(IPattern newPattern)
        {
            IPattern[] rewrittenPattern = new IPattern[Pattern.Length + 1];
            for (int i = 0; i < Pattern.Length; i++)
            {
                rewrittenPattern[i] = Pattern[i];
            }

            rewrittenPattern[Pattern.Length] = newPattern;
            this.Pattern = rewrittenPattern;
        }
    }
}
