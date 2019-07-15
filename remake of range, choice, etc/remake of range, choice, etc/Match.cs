using System;
using System.Collections.Generic;
using System.Text;

namespace RemakeOfRangeChoiceEtc
{
    class Match : IMatch
    {
        readonly bool itMatches;
        private readonly string remainedText;

        public Match(bool itMatches, string remainedText)
        {
            this.itMatches = itMatches;
            this.remainedText = remainedText;
        }

        public bool Success()
        {
            return this.itMatches;
        }

        public string RemainingText()
        {
            return this.remainedText;
        }
    }
}
