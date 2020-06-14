using System;
using System.Collections.Generic;

namespace DataStructures
{
    class OrderComparer<T> : IComparer<T>
    {
        private readonly IComparer<T> first;
        private readonly IComparer<T> second;

        internal OrderComparer(IComparer<T> first, IComparer<T> second)
        {
            this.first = first;
            this.second = second;
        }

        public int Compare(T firstT, T secondT)
        {
            int firstResult = first.Compare(firstT, secondT);
            if (firstResult != 0)
            {
                return firstResult;
            }

            return second.Compare(firstT, secondT);
        }
    }
}