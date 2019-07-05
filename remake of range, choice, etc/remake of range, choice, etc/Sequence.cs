using System;
using System.Collections.Generic;
using System.Text;

namespace remake_of_range__choice__etc
{
    class Sequence
    {
        public IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            Match match = new Match(true, text);
            for(int i=0;i<this.patterns.Length;i++)
            {
                if(patterns[i].Match(match.remainedText).Succes())
                {
                    match.remainedText = match.RemainingText();
                }
                else
                {
                    match = new Match(false, text);
                    return match;
                }
            }
            return match;
        }
    }
}
