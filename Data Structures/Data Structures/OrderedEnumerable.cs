using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    public class OrderedEnumerable<T> : IOrderedEnumerable<T>
    {
        protected List<T> list;

        public OrderedEnumerable()
        {
            this.list = new List<T>();
        }

        public virtual void Add(T item)
        {
            list.Add(item);
        }

        public IOrderedEnumerable<T> CreateOrderedEnumerable<TKey>(Func<T, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            SortedDictionary<TKey, List<T>> sortedlist = new SortedDictionary<TKey, List<T>>(comparer);
            for (int i = 0; i < list.Count; i++)
            {
                if (sortedlist.ContainsKey(keySelector(list[i])))
                {
                    sortedlist[keySelector(list[i])].Add(list[i]);
                }
                else
                {
                    sortedlist.Add(keySelector(list[i]), new List<T> { list[i] });
                }
            }

            if (descending)
            {
                int i = list.Count - 1;
                foreach (var obj in sortedlist)
                {
                    foreach (var value in obj.Value)
                    {
                        list[i--] = value;
                    }
                }
            }
            else
            {
                int i = 0;
                foreach (var obj in sortedlist)
                {
                    foreach (var value in obj.Value)
                    {
                        list[i++] = value;
                    }
                }
            }

            return this;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
        }

        public bool EqualityBetweenThisAPureIOrderedEnumerable(IOrderedEnumerable<T> another)
        {
            int i = 0;
            foreach (var obj in another)
            {
                if (i == list.Count)
                {
                    return false;
                }

                if (!list[i].Equals(obj))
                {
                    return false;
                }

                i++;
            }

            return i == list.Count;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
}
