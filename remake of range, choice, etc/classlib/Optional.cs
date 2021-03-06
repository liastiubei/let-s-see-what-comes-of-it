﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Json
{
    public class Optional : IPattern
    {
        private readonly IPattern pattern;

        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            var optionalMatch = this.pattern.Match(text);
            return new Match(true, optionalMatch.RemainingText());
        }
    }
}
