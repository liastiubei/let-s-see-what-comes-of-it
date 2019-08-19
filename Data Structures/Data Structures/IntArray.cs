using System;

namespace Data_Structures
{
    public class IntArray
    {
        private int[] array;
        private int count;

        public IntArray()
        {
            this.array = new int[8];
            this.count = 0;
        }

        public int this[int index]
        {
            get => this.array[index];
            set => this.array[index] = value;
        }

        public void Add(int element)
        {
            if(count == array.Length)
            {
                Array.Resize(ref this.array, this.array.Length * 2);
            }

            this.array[count] = element;
            this.count++;            
        }

        public int Count
        {
            get => this.count;
            private set => this.count = value;
        }

        public int Element(int index)
        {
            return this.array[index];
        }

        public void SetElement(int index, int element)
        {
            this.array[index] = element;
        }

        public int IndexOf(int element)
        {
            for (int i = 0; i < this.count; i++)
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
        
        public void Insert(int index, int element)
        {
            if (count > this.array.Length)
            {
                Array.Resize(ref this.array, this.array.Length * 2);
            }

            ShiftRight(index);
            this.array[index] = element;
            this.count++;
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
            if (index > this.count - 1)
            {
                return;
            }

            ShiftLeft(index);
            Array.Resize(ref this.array, this.array.Length - 1);
            this.count--;
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < this.count; i++)
            {
                this.array[i] = this.array[i + 1];
            }
        }

        private void ShiftRight(int index)
        {
            for (int i = this.count - 1; i > index; i--)
            {
                this.array[i] = this.array[i - 1];
            }
        }
    }
}
