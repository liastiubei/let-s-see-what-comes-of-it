using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures
{
    public class List<T> : IEnumerable<T>
    {
        protected T[] array;

        public List()
        {
            this.array = new T[8];
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }

        public T this[int index]
        {
            get => this.array[index];
            set => this.array[index] = value;
        }

        public virtual void Add(T element)
        {
            Resize();
            this.array[Count] = element;
            Count++;
        }

        public void Resize()
        {
            if (Count == array.Length)
            {
                Array.Resize(ref this.array, this.array.Length * 2);
            }
        }

        public int Count { get; protected set; }

        public object Element(int index)
        {
            return this.array[index];
        }

        public virtual void SetElement(int index, T element)
        {
            this.array[index] = element;
        }

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

        public void Remove(T element)
        {
            RemoveAt(IndexOf(element));
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
    }
}
