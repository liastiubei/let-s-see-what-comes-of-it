using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    public class OrderedEnumerable<T> : IOrderedEnumerable<T>
    {
        private readonly List<T> list;
        private readonly IComparer<T> comparer;

        public OrderedEnumerable(IEnumerable<T> newList, IComparer<T> comparer)
        {
            this.list = new List<T>(newList);
            this.comparer = comparer;
        }

        public IEnumerable<T> UnorderedList()
        {
            return this.list;
        }

        public IOrderedEnumerable<T> CreateOrderedEnumerable<TKey>(Func<T, TKey> keySelector, IComparer<TKey> otherComparer, bool descending)
        {
            if (keySelector == null)
            {
                throw new ArgumentNullException("KeySelector is null");
            }

            IComparer<T> newComparer = new KeyComparerUsingValue<T, TKey>(keySelector, otherComparer);
            if (descending)
            {
                newComparer = new BackwardsComparer<T>(newComparer);
            }

            return new OrderedEnumerable<T>(list, new OrderComparer<T>(comparer, newComparer));
        }

        public IEnumerator<T> GetEnumerator()
        {
            var newList = list;
            newList.Sort(comparer);
            foreach (var obj in newList)
            {
                yield return obj;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
}
