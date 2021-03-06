﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Json
{
    public class Sequence : IPattern
    {
        private readonly IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            IMatch match = new Match(true, text);
            foreach (var pattern in patterns)
            {

                match = pattern.Match(match.RemainingText());
                if (!match.Success())
                {
                    return new Match(false, text);
                }
            }

            return match;
        }
    }
}
