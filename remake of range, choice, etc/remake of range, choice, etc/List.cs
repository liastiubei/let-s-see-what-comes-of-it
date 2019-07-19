using System;
using System.Collections.Generic;
using System.Text;

namespace RemakeOfRangeChoiceEtc
{
    class List
    {
        private readonly IPattern element;
        private readonly IPattern separator;

        public List(IPattern element, IPattern separator)
        {
            this.element = element;
            this.separator = separator;
        }

        public IMatch Match(string text)
        {
            if (!this.element.Match(text).Success())
            {
                return new Match(true, text);
            }

            while (this.element.Match(text).Success())
            {
                text = this.element.Match(text).RemainingText();
                if (this.separator.Match(text).Success())
                {
                    text = this.separator.Match(text).RemainingText();
                }
            }

            return new Match(true, text);
        }
    }
}
