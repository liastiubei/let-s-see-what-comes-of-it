using System;
using System.Collections.Generic;
using System.Text;

namespace RemakeOfRangeChoiceEtc
{
    class Text
    {
        private readonly string prefix;

        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text) || text.Length < this.prefix.Length)
            {
                return new Match(false, text);
            }

            for (int i = 0; i < this.prefix.Length; i++)
            {
                if (text[i] != this.prefix[i])
                {
                   return new Match(false, text);
                }
            }

            return new Match(true, text.Substring(this.prefix.Length));
        }
    }
}
