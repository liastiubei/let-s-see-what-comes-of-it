using System;
using System.Collections.Generic;
using System.Text;

namespace Json
{
    public class Text : IPattern
    {
        private readonly string prefix;

        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            return string.IsNullOrEmpty(text) || text.Length < this.prefix.Length || !text.StartsWith(this.prefix)
                ? new Match(false, text)
                : new Match(true, text.Substring(this.prefix.Length));
        }
    }
}
