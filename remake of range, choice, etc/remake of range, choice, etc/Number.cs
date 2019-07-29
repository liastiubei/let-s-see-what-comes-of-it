using System;
using System.Collections.Generic;
using System.Text;

namespace RemakeOfRangeChoiceEtc
{
    class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            Optional minus = new Optional(new Character('-'));
            OneOrMore theActualNumbers = new OneOrMore(new Range('0', '9'));
            Sequence zeroAndDotAndNumber = new Sequence(new Optional(new Sequence(new Text("0."), new Many(new Character('0')))), new Any("123456789"), new Optional(theActualNumbers));
            Optional dot = new Optional(new Sequence(new Character('.'), theActualNumbers));
            Optional e = new Optional(new Sequence(new Any("eE"), new Optional(new Any("-+")), theActualNumbers, dot));
            this.pattern = new Sequence(minus, zeroAndDotAndNumber, dot, e);
        }

        public IMatch Match(string text)
        {
            if (pattern.Match(text).Success() && pattern.Match(text).RemainingText().Length == 0)
            {
                return pattern.Match(text);
            }

            return new Match(false, pattern.Match(text).RemainingText());
        }
    }
}
