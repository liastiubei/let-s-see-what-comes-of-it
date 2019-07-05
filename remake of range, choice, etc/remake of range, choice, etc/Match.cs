using System;
using System.Collections.Generic;
using System.Text;

namespace remake_of_range__choice__etc
{
    class Match:IMatch
    {
        bool itMatches;
        public string remainedText;

        public Match(bool itMatches ,string remainedText)
        {
            this.itMatches = itMatches;
            this.remainedText = remainedText;
        }

        public bool Succes()
        {
            return this.itMatches;
        }

        public string RemainingText()
        {
            if (this.Succes())
            {
                this.remainedText = this.remainedText.Substring(1);
                return this.remainedText;
            }
            else return this.remainedText;
        }
    }
}
