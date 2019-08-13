using System;
using System.Collections.Generic;
using System.Text;

namespace Json
{
    public class Range : IPattern
    {
        readonly char start;
        readonly char end;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public IMatch Match(string text)
        {
            bool a = (!string.IsNullOrEmpty(text) && (this.start <= text[0] && text[0] <= this.end));
            return !string.IsNullOrEmpty(text) && (this.start <= text[0] && text[0] <= this.end)
                 ? new Match(true, text.Substring(1))
                 : new Match(false, text);
        }
    }
}
