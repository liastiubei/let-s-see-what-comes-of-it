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
            Sequence seq = new Sequence(this.element, new Many(new Sequence(this.separator, this.element)), new Optional(this.separator));
            return new Match(true, seq.Match(text).RemainingText());
        }
    }
}
