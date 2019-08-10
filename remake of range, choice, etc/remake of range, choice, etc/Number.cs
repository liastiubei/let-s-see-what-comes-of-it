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
            OneOrMore digits = new OneOrMore(new Range('0', '9'));
            Choice firstdigits = new Choice(new Character('0'), new Sequence(new Range('1', '9'), new Many(new Range('0', '9'))));
            Optional fraction = new Optional(
                new Sequence(
                    new Character('.'),
                    digits));
            Optional exponent = new Optional(
                new Sequence(
                    new Any("eE"),
                    new Optional(new Any("-+")),
                    firstdigits,
                    fraction));
            this.pattern = new Sequence(minus, firstdigits, fraction, exponent);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
