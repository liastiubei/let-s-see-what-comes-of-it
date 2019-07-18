using System;
using System.Collections.Generic;
using System.Text;

namespace RemakeOfRangeChoiceEtc
{
    class Many
    {
        private readonly IPattern pattern;

        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            while (this.pattern.Match(text).Success())
            {
                text = this.pattern.Match(text).RemainingText();
            }

            return new Match(true, text);
        }
    }
}
