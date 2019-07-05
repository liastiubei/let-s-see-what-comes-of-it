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

        public IMatch Match(string line)
        {
            foreach (IPattern p in this.pattern)
            {
                if(p.Match(line).Succes())
                {
                    Match trueMatch = new Match(p.Match(line).Succes(),"");
                    return trueMatch;
                }
            }
            Match falseMatch = new Match(false,"");
            return falseMatch;
            
        }
    }
}
