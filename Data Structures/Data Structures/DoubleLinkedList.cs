using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures
{
    public class DoubleLinkedList<T> : ICollection<T>
    {
        protected DoubleLink<T> first;
        private bool isReadOnly;

        public int Count {get; protected set; }

        public bool IsReadOnly { get => isReadOnly; }

        public DoubleLinkedList()
        {
            first = new DoubleLink<T>(default(T));
            first.NextLink = first;
            first.PreviousLink = first;
            Count = 0;
        }
        
        public void InsertAfterValue(T afterValue, T addedValue)
        {
            DoubleLink<T> searchLink = this.Find(afterValue);

            if(searchLink != first)
            {
                DoubleLink<T> link = new DoubleLink<T>(addedValue);
                link.NextLink = searchLink.NextLink;
                searchLink.NextLink.PreviousLink = link;
                link.PreviousLink = searchLink;
                searchLink.NextLink = link;
                Count++;
            }
        }

        public DoubleLink<T> Find(T findValue)
        {
            bool checkIfFound = false;
            DoubleLink<T> searchLink = first.NextLink;
            while (searchLink != first)
            {
                if (searchLink.value.Equals(findValue))
                {
                    checkIfFound = true;
                    break;
                }

                searchLink = searchLink.NextLink;
            }
            
            if(checkIfFound)
            {
                return searchLink;
            }

            return first;
        }

        public void Add(T item)
        {
            DoubleLink<T> link = new DoubleLink<T>(item);

            if (first.NextLink == first)
            {
                first.NextLink = link;
            }

            link.NextLink = first;
            link.PreviousLink = first.PreviousLink;
            first.PreviousLink.NextLink = link;
            first.PreviousLink = link;
            Count++;
        }

        public void Clear()
        {
            first.value = default(T);
            first.NextLink = first;
            first.PreviousLink = first;
            Count = 0;
        }

        public bool Contains(T item)
        {
            if(this.Find(item) != first)
            {
                return true;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            DoubleLink<T> link = first.NextLink;
            for(int i = arrayIndex; i < arrayIndex + Count; i++)
            {
                array[i] = link.value;
                link = link.NextLink;
            }
        }

        public bool Remove(T item)
        {
            DoubleLink<T> link = this.Find(item);
            link.PreviousLink.NextLink = link.NextLink;
            link.NextLink.PreviousLink = link.PreviousLink;
            link = null;
            Count--;
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            DoubleLink<T> link = first.NextLink;
            while (link != first)
            {
                yield return link.value;
                link = link.NextLink;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        public void MakeReadOnly()
        {
            if (isReadOnly)
            {
                return;
            }

            isReadOnly = true;
        }
    }
}
