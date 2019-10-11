using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Data_Structures
{
    public class List<T> : IList<T>
    {
        readonly protected T[] array;

        public List()
        {
            this.array = new T[8];
            Count = 0;
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
            try
            {
                Resize();
                this.array[Count] = element;
                Count++;
            }
            catch
            {
                throw new NotSupportedException("The array is readonly");
            }
        }

        public void Resize()
        {
            if (Count == array.Length)
            {
                Array.Resize(ref this.array, this.array.Length * 2);
            }
        }

        public int Count { get; protected set; }

        bool ICollection<T>.IsReadOnly => ((IList<T>)array).IsReadOnly;

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
            Resize();
            ShiftRight(index);
            this.array[index] = element;
            Count++;
        }

        public void Clear()
        {
            Array.Clear(this.array, 0, this.array.Length);
        }

        public bool Remove(T element)
        {
            RemoveAt(IndexOf(element));
            return true;
        }

        public void RemoveAt(int index)
        {
            if (index > Count - 1)
            {
                return;
            }

            ShiftLeft(index);
            Array.Resize(ref this.array, this.array.Length - 1);
            Count--;
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
            return ((IEnumerable<T>)array).GetEnumerator();
        }

        public void CopyTo(T[] otherArray, int arrayIndex)
        {
            Array.Resize(ref otherArray, otherArray.Length + 1);
            otherArray[otherArray.Length - 1] = this.array[arrayIndex];
        }
    }
}
