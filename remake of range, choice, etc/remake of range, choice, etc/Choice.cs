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
                var success = p.Match(line).Success();
                if (success)
                {
                    return new Match(success, line.Substring(1));
                }
            }

            return new Match(false, line);
        }
    }
}
