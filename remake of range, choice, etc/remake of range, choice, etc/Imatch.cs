using System;
using System.Collections.Generic;
using System.Text;

namespace RemakeOfRangeChoiceEtc
{
    interface IMatch
    {
        bool Success();

        string RemainingText();
    }
}
