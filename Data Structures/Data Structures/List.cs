using System;
using System.Collections;
using System.Collections.Generic;

namespace Data_Structures
{
    public class List<T> : IList<T>
    {
        protected T[] array;
        private bool isReadOnly;

        public List()
        {
            this.array = new T[8];
            isReadOnly = false;
            Count = 0;
        }

        public void MakeReadOnly()
        {
            if(isReadOnly)
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

        public virtual void Add(T element)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("The array is readonly");
            }
            else
            {
                Resize();
                this.array[Count] = element;
                Count++;
            }
        }
        
        public void Resize()
        {
            if (Count == array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }
        }

        public int Count { get; protected set; }

        public bool IsReadOnly => isReadOnly;

        public int IndexOf(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.array[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(T element)
        {
            return (this.IndexOf(element) != -1);
        }

        public virtual void Insert(int index, T element)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException("Index is out of range");
            }

            else if(IsReadOnly)
            {
                throw new NotSupportedException("The array is readonly");
            }

            else
            {
                Resize();
                ShiftRight(index);
                this.array[index] = element;
                Count++;
            }
        }

        public void Clear()
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("The array is readonly");
            }

            else
            {
                Array.Clear(this.array, 0, this.array.Length);
            }
        }
        public bool Remove(T element)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("The array is readonly");
            }

            else
            {
                RemoveAt(IndexOf(element));
                return true;
            }
        }

        public void RemoveAt(int index)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("The array is readonly");
            }

            else if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException("Index is out of bounds");
            }

            else
            {
                ShiftLeft(index);
                Array.Resize(ref this.array, this.array.Length - 1);
                Count--;
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
            if(array == null)
            {
                throw new ArgumentNullException("The array is null");
            }

            else if(arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("ArrayIndex is less than zero");
            }

            else
            {
                if(otherArray.Length < arrayIndex + Count)
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
}
