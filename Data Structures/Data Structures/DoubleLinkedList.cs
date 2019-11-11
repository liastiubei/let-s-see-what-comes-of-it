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
            isReadOnly = false;
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

        public DoubleLink<T> FindLast(T findValue)
        {
            bool checkIfFound = false;
            DoubleLink<T> searchLink = first.PreviousLink;
            while (searchLink != first)
            {
                if (searchLink.value.Equals(findValue))
                {
                    checkIfFound = true;
                    break;
                }

                searchLink = searchLink.PreviousLink;
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

            else if(neededLink == null)
            {
                throw new ArgumentNullException("The node is null");
            }

            else if(Find(neededLink.value) == null && neededLink != first)
            {
                throw new InvalidOperationException("The node is not in the current list");
            }

            else
            {
                DoubleLink<T> link = new DoubleLink<T>(item);
                link.NextLink = neededLink;
                link.PreviousLink = neededLink.PreviousLink;
                neededLink.PreviousLink.NextLink = link;
                neededLink.PreviousLink = link;
                Count++;
            }
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

            else
            {
                first.value = default(T);
                first.NextLink = first;
                first.PreviousLink = first;
                Count = 0;
            }
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
            
            else if(arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Index is less than zero");
            }

            else if(Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("The number of elements in the list is greater than the available space from index to the end of the array");
            }

            else
            {
                DoubleLink<T> link = first.NextLink;
                for (int i = arrayIndex; i < arrayIndex + Count; i++)
                {
                    array[i] = link.value;
                    link = link.NextLink;
                }
            }
        }

        public bool Remove(T item)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("The array is readonly");
            }

            else
            {
                DoubleLink<T> link = this.Find(item);
                link.PreviousLink.NextLink = link.NextLink;
                link.NextLink.PreviousLink = link.PreviousLink;
                link = null;
                Count--;
            }
            return true;
        }

        public bool RemoveFirst()
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("The array is readonly");
            }

            else if (first.NextLink == first)
            {
                throw new InvalidOperationException("The list is empty");
            }

            else
            {
                first.NextLink = first.NextLink.NextLink;
                first.NextLink.PreviousLink = first;
                Count--;
                return true;
            }
        }

        public bool RemoveLast()
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("The array is readonly");
            }

            else if (first.NextLink == first)
            {
                throw new InvalidOperationException("The list is empty");
            }

            else
            {
                first.PreviousLink = first.PreviousLink.PreviousLink;
                first.PreviousLink.NextLink = first;
                Count--;
                return true;
            }
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
