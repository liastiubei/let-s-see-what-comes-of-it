﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Json
{
    public class List : IPattern
    {
        private readonly IPattern elementAndSeparator;

        public List(IPattern element, IPattern separator)
        {
            this.elementAndSeparator = new Sequence(element, new Many(new Sequence(separator, element)));
        }

        public IMatch Match(string text)
        {
            return new Match(true, this.elementAndSeparator.Match(text).RemainingText());
        }
    }
}
