using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures
{
    public class ObjectArray : IEnumerable
    {
        object[] array;

        public ObjectArray(object[] newArray)
        {
            this.array = new object[(newArray.Length / 8 + 1) * 8];
            for(int i = 0; i < newArray.Length; i++)
            {
                this.array[i] = newArray[i];
            }

            Count = newArray.Length;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            int count = 0;
            foreach (var obj in array)
            {
                if (count < Count)
                {
                    count += 1;
                    yield return obj;
                }
                if (Count == count)
                {
                    yield break;
                }
            }
        }
        
        public object this[int index]
        {
            get => this.array[index];
            set => this.array[index] = value;
        }

        public void Add(object element)
        {
            if (Count == array.Length)
            {
                Array.Resize(ref this.array, this.array.Length * 2);
            }

            this.array[Count] = element;
            Count++;
        }

        public int Count { get; protected set; }

        public object Element(int index)
        {
            return this.array[index];
        }

        public void SetElement(int index, int element)
        {
            this.array[index] = element;
        }

        public int IndexOf(object element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.array[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(int element)
        {
            if (this.IndexOf(element) != -1)
            {
                return true;
            }

            return false;
        }

        public void Insert(int index, object element)
        {
            if (Count > this.array.Length)
            {
                Array.Resize(ref this.array, this.array.Length * 2);
            }

            ShiftRight(index);
            this.array[index] = element;
            Count++;
        }

        public void Clear()
        {
            Array.Clear(this.array, 0, this.array.Length);
        }

        public void Remove(object element)
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
    }
}
