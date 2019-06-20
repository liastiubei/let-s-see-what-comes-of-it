using System;
using System.Collections.Generic;
using System.Text;

namespace Choice
{
    class Choice : IPattern
    {
        public IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public bool Match(string text)
        {
            foreach (var pattern in this.patterns)
                if (pattern.Match(text)) return true;

            return false;
        }
    }
}
