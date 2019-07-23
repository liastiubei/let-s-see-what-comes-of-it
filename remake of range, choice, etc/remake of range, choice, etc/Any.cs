using System;
using System.Collections.Generic;
using System.Text;

namespace RemakeOfRangeChoiceEtc
{
    class Any
    {
        private readonly string accepted;

        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(string text)
        {
            return !string.IsNullOrEmpty(text) && this.accepted.Contains(text[0])
                ? new Match(true, text.Substring(1))
                : new Match(false, text);
        }
    }
}
