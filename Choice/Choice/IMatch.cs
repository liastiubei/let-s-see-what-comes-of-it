using System;
using System.Collections.Generic;
using System.Text;

namespace Choice
{
    interface IMatch
    {
        bool Success(string text);
        string RemainingText(string text);
    }
}
