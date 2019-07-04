using System;
using System.Collections.Generic;
using System.Text;

namespace remake_of_range__choice__etc
{
    class Choice:IPattern
    {
        public IPattern[] pattern;

        public Choice(params IPattern[] pattern)
        {
            this.pattern=pattern;
        }

        public bool Match(string line)
        {
            foreach (var p in this.pattern)
            {
                if (p.Match(line)) return true;
            }
            return false;
        }
    }
}
