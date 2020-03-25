using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class ListCollection<T> : IList<T>
    {
        protected T[] array;
        private bool isReadOnly;

        public ListCollection()
        {
            this.array = new T[8];
            isReadOnly = false;
            Count = 0;
        }

        public void MakeReadOnly()
        {
            if (isReadOnly)
            {
                return;
            }

            isReadOnly = true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return array[i];
            }
        }

        public virtual T this[int index]
        {
            get => this.array[index];
            set => this.array[index] = value;
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

        public int Count { get; protected set; }

        public bool IsReadOnly => isReadOnly;

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.array[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(T item)
        {
            return this.IndexOf(item) != -1;
        }

        public virtual void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException("Index is out of range");
            }

            if (IsReadOnly)
            {
                throw new NotSupportedException("The array is readonly");
            }

            Resize();
            ShiftRight(index);
            this.array[index] = item;
            Count++;
        }

        public void Clear()
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("The array is readonly");
            }

            Array.Clear(this.array, 0, this.array.Length);
        }

        public bool Remove(T item)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("The array is readonly");
            }

            RemoveAt(IndexOf(item));
            return true;
        }

        public void RemoveAt(int index)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("The array is readonly");
            }

            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException("Index is out of bounds");
            }

            ShiftLeft(index);
            Array.Resize(ref this.array, this.array.Length - 1);
            Count--;
        }

        public void AddList(IEnumerable<T> list)
        {
            foreach (var obj in list)
            {
                this.Add(obj);
            }
        }

        public void ShiftLeft(int index)
        {
            for (int i = index; i < Count; i++)
            {
                this.array[i] = this.array[i + 1];
            }
        }

        public void ShiftRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                this.array[i] = this.array[i - 1];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        public void CopyTo(T[] otherArray, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("The array is null");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("ArrayIndex is less than zero");
            }

            if (otherArray.Length < arrayIndex + Count)
            {
                Array.Resize(ref otherArray, arrayIndex + Count);
            }

            int k = 0;
            for (int i = arrayIndex; i < arrayIndex + Count; i++)
            {
                otherArray[i] = array[k++];
            }
        }
    }
}
