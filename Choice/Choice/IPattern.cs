﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Choice
{
    interface IPattern
    {
        IMatch Match(string text);
    }
}
