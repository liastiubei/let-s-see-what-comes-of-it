using System;
using System.Collections.Generic;
using System.Text;

namespace RemakeOfRangeChoiceEtc
{
    class List
    {
        private readonly IPattern separator;
        private IPattern element;

        public List(IPattern element, IPattern separator)
        {
            this.element = element;
            this.separator = separator;
        }

        public IMatch Match(string text)
        {
            this.element = new Sequence(this.element, new Many(new Sequence(this.separator, this.element)));
            return new Match(true, this.element.Match(text).RemainingText());
        }
    }
}
