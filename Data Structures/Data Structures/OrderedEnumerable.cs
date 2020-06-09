using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    public class OrderedEnumerable<T> : IOrderedEnumerable<T>
    {
        protected T[] array;
        private bool isReadOnly;

        public int Count { get; protected set; }

        public bool IsReadOnly => isReadOnly;

        public OrderedEnumerable()
        {
            this.array = new T[8];
            isReadOnly = false;
            Count = 0;
        }

        public virtual void Add(T item)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("The array is readonly");
            }

            Resize();
            this.array[Count] = item;
            Count++;
        }

        public void Resize()
        {
            if (Count != array.Length)
            {
                return;
            }

            Array.Resize(ref array, array.Length * 2);
        }

        public void ResizeToCount()
        {
            Array.Resize(ref array, Count);
        }

        public IOrderedEnumerable<T> CreateOrderedEnumerable<TKey>(Func<T, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            SortedDictionary<TKey, List<T>> list = new SortedDictionary<TKey, List<T>>(comparer);
            for (int i = 0; i < Count; i++)
            {
                if (list.ContainsKey(keySelector(array[i])))
                {
                    list[keySelector(array[i])].Add(array[i]);
                }
                else
                {
                    list.Add(keySelector(array[i]), new List<T> { array[i] });
                }
            }

            if (descending)
            {
                int i = Count - 1;
                foreach (var obj in list)
                {
                    foreach (var value in obj.Value)
                    {
                        array[i--] = value;
                    }
                }
            }
            else
            {
                int i = 0;
                foreach (var obj in list)
                {
                    foreach (var value in obj.Value)
                    {
                        array[i++] = value;
                    }
                }
            }

            ResizeToCount();
            return this;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
}
