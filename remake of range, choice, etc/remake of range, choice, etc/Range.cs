using System;
using System.Collections.Generic;
using System.Text;

namespace remake_of_range__choice__etc
{
    class Range
    {
        char start;
        char end;
        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }
        public bool Match(string text)
        {
            return text[0] >= this.start && text[0] <= this.end;
        }
    }
}
