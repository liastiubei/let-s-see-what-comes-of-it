using System;
using System.Collections.Generic;
using System.Text;

namespace remake_of_range__choice__etc
{
    class Match:IMatch
    {
        public IPattern[] pattern;
        bool itMatches;

        public Match(bool itMatches ,params IPattern[] pattern)
        {
            this.pattern = pattern;
            this.itMatches = itMatches;
        }

        public bool Succes()
        {
            return this.itMatches;
        }

        public string RemainingText(string text)
        {
            if (this.Succes())
                return text.Substring(this.pattern.Length);
            else return text;
        }
    }
}
