using System;

namespace Data_Structures
{
    public class IntArray
    {
        protected int[] array;

        public IntArray()
        {
            this.array = new int[8];
            Count = 0;
        }

        public int this[int index]
        {
            get => this.array[index];
            set => this.array[index] = value;
        }

        public virtual void Add(int element)
        {
            if(Count == array.Length)
            {
                Array.Resize(ref this.array, this.array.Length * 2);
            }

            this.array[Count] = element;
            Count++;            
        }

        public int Count { get; protected set; }

        public int Element(int index)
        {
            return this.array[index];
        }

        public virtual void SetElement(int index, int element)
        {
            this.array[index] = element;
        }

        public int IndexOf(int element)
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
            if(this.IndexOf(element) != -1)
            {
                return true;
            }

            return false;
        }
        
        public virtual void Insert(int index, int element)
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

        public void Remove(int element)
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
