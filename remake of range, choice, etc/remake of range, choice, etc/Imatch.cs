using System;
using System.Collections.Generic;
using System.Text;

namespace RemakeOfRangeChoiceEtc
{
    public interface IMatch
    {
        bool Success();

        string RemainingText();
    }
}
