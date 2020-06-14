using System;
using System.Collections.Generic;

namespace DataStructures
{
    class KeyComparerUsingValue<TElement, TKey> : IComparer<TElement>
    {
        private readonly Func<TElement, TKey> keySelector;
        private readonly IComparer<TKey> comparer;

        internal KeyComparerUsingValue(Func<TElement, TKey> keySelector, IComparer<TKey> comparer)
        {
            this.keySelector = keySelector;
            this.comparer = comparer ?? Comparer<TKey>.Default;
        }

        public int Compare(TElement first, TElement second)
        {
            TKey firstKey = keySelector(first);
            TKey secondKey = keySelector(second);
            return comparer.Compare(firstKey, secondKey);
        }
    }
}
