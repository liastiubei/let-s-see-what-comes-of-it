using System;
using System.Collections.Generic;
using System.Text;

namespace Json
{
    public class OneOrMore : IPattern
    {
        private readonly IPattern pattern;

        public OneOrMore(IPattern pattern)
        {
            this.pattern = new Sequence(pattern, new Many(pattern));
        }

        public IMatch Match(string text)
        {
            bool a = pattern.Match(text).Success();
            return this.pattern.Match(text);
        }
    }
}
