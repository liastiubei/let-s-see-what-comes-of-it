using System;
using System.Collections.Generic;
using System.Text;

namespace RemakeOfRangeChoiceEtc
{
    class Any
    {
        private readonly string accepted;

        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new Match(false, text);
            }

            for (int i = 0; i < accepted.Length; i++)
            {
                if (text[0] == this.accepted[i])
                {
                    return new Match(true, text.Substring(1));
                }
            }

            return new Match(false, text);
        }
    }
}
