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

            return null;
        }

        private void AddBasic(DoubleLink<T> neededLink, DoubleLink<T> link)
        {
            link.NextLink = neededLink;
            link.PreviousLink = neededLink.PreviousLink;
            neededLink.PreviousLink.NextLink = link;
            neededLink.PreviousLink = link;
            Count++;
        }

        public void Add(T item)
        {
            DoubleLink<T> link = new DoubleLink<T>(item);
            if (first.NextLink == first)
            {
                first.NextLink = link;
            }
            AddBasic(first, link);
        }

        public void AddBefore(DoubleLink<T> beforeLink, T item)
        {
            DoubleLink<T> link = new DoubleLink<T>(item);
            AddBasic(beforeLink, link);
        }

        public void AddAfter(DoubleLink<T> afterLink, T item)
        {
            DoubleLink<T> link = new DoubleLink<T>(item);
            AddBasic(afterLink.NextLink, link);
        }

        public void AddFirst(T item)
        {
            DoubleLink<T> link = new DoubleLink<T>(item);
            AddBasic(first.NextLink, link);
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
            return this.Find(item) != null
                ? true
                : false;
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
