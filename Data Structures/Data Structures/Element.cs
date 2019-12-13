using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class Element<TKey, TValue>
    {
        public TKey Key;
        public TValue Value;
        public int Next;

        public Element()
        {
            Key = default;
            Value = default;
            Next = -1;
        }

        public Element(TKey key, TValue value, int next)
        {
            Key = key;
            Value = value;
            Next = next;
        }
    }
}
