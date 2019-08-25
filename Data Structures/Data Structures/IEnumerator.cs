using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures
{
    public interface IEnumerator
    {
        object Current { get;}
        bool MoveNext();
        void Reset();
    }
}
