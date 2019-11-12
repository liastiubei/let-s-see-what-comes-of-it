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
            first.MyList = this;
            first.NextLink = first;
            first.PreviousLink = first;
            isReadOnly = false;
            Count = 0;
        }
        
        public DoubleLink<T> Find(T findValue)
        {
            bool checkIfFound = false;
            DoubleLink<T> searchLink;
            for (searchLink = first.NextLink; searchLink != first; searchLink = searchLink.NextLink)
            {
                if (searchLink.value.Equals(findValue))
                {
                    checkIfFound = true;
                    break;
                }
            }
            
            if(checkIfFound)
            {
                return searchLink;
            }

            return null;
        }

        public DoubleLink<T> FindLast(T findValue)
        {
            bool checkIfFound = false;
            DoubleLink<T> searchLink;
            for (searchLink = first.PreviousLink; searchLink != first; searchLink = searchLink.PreviousLink)
            {
                if (searchLink.value.Equals(findValue))
                {
                    checkIfFound = true;
                    break;
                }
            }

            if (checkIfFound)
            {
                return searchLink;
            }

            return null;
        }

        public void AddBefore(DoubleLink<T> neededLink, T item)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("The array is readonly");
            }

            if(neededLink == null)
            {
                throw new ArgumentNullException("The node is null");
            }

            if(neededLink.MyList != this)
            {
                throw new InvalidOperationException("The node is not in the current list");
            }

            DoubleLink<T> link = new DoubleLink<T>(item);
            link.MyList = this;
            link.NextLink = neededLink;
            link.PreviousLink = neededLink.PreviousLink;
            neededLink.PreviousLink.NextLink = link;
            neededLink.PreviousLink = link;
            Count++;
        }

        public void Add(T item)
        {
            AddBefore(first, item);
        }

        public void AddAfter(DoubleLink<T> afterLink, T item)
        {
            AddBefore(afterLink.NextLink, item);
        }

        public void AddFirst(T item)
        {
            AddBefore(first.NextLink, item);
        }

        public void Clear()
        {
            if (isReadOnly)
            {
                throw new NotSupportedException("The list is readonly");
            }

            for (DoubleLink<T> link = first.NextLink; link != first; link = link.NextLink)
            {
                link.MyList = null;
            }

            first.value = default(T);
            first.NextLink = first;
            first.PreviousLink = first;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return this.Find(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if(array == null)
            {
                throw new ArgumentNullException("Array is null");
            }
            
            if(arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Index is less than zero");
            }

            if(Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("The number of elements in the list is greater than the available space from index to the end of the array");
            }

            DoubleLink<T> link = first.NextLink;
            for (int i = arrayIndex; i < arrayIndex + Count; i++)
            {
                array[i] = link.value;
                link = link.NextLink;
            }
        }

        public bool Remove(T item)
        {            
            return Remove(Find(item));
        }

        public bool Remove(DoubleLink<T> link)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("The array is readonly");
            }

            link.PreviousLink.NextLink = link.NextLink;
            link.NextLink.PreviousLink = link.PreviousLink;
            link.MyList = null;
            link = null;
            Count--;

            return true;
        }

        public bool RemoveFirst()
        {
            if (first.NextLink == first)
            {
                throw new InvalidOperationException("The list is empty");
            }

            return Remove(first.NextLink);
        }

        public bool RemoveLast()
        {
            if (first.NextLink == first)
            {
                throw new InvalidOperationException("The list is empty");
            }

            return Remove(first.PreviousLink);
        }

        public bool Equals(object obj)
        {
            return obj == this;
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
