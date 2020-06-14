using System;
using System.Collections.Generic;

namespace DataStructures
{
    class BackwardsComparer<TKey> : IComparer<TKey>
    {
        private readonly IComparer<TKey> comparer;

        internal BackwardsComparer(IComparer<TKey> comparer)
        {
            this.comparer = comparer;
        }

        public int Compare(TKey first, TKey second)
        {
            return comparer.Compare(second, first);
        }
    }
}
