using System;

namespace Data_Structures
{
    public class IntArray
    {
        private int[] array;

        public IntArray(int[] array)
        {
            this.array = array;
        }

        public int[] ShowArray()
        {
            return this.array;
        }

        public void Add(int element)
        {
            Array.Resize(ref this.array, this.array.Length + 1);
            this.array[this.array.Length - 1] = element;
        }

        public int Count()
        {
            return this.array.Length;
        }

        public int Element(int index)
        {
            return this.array[index];
        }

        public void SetElement(int index, int element)
        {
            this.array[index] = element;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < this.array.Length; i++)
            {
                if(this.array[i] == element)
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(int element)
        {
            for (int i = 0; i < this.array.Length; i++)
            {
                if (this.array[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, int element)
        {
            Array.Resize(ref this.array, this.array.Length + 1);
            for(int i = this.array.Length - 1; i > index; i--)
            {
                this.array[i] = this.array[i - 1];
            }
            this.array[index] = element;
        }

        public void Clear()
        {
            Array.Clear(this.array, 0, this.array.Length);
        }

        public void Remove(int element)
        {
            int i;
            for(i=0;i<this.array.Length;i++)
            {
                if(element == array[i])
                {
                    break;
                }
            }

            if(i == this.array.Length)
            {
                return;
            }

            if(i == this.array.Length - 1)
            {
                Array.Resize(ref this.array, this.array.Length - 1);
                return;
            }

            while(i < this.array.Length - 1)
            {
                this.array[i] = this.array[i + 1];
                i++;
            }

            Array.Resize(ref this.array, this.array.Length - 1);
        }

        public void RemoveAt(int index)
        {
            if(index > this.array.Length - 1)
            {
                return;
            }

            for(int i = index; i < this.array.Length - 1; i++)
            {
                this.array[i] = this.array[i + 1];
            }

            Array.Resize(ref this.array, this.array.Length - 1);
        }
    }
}
