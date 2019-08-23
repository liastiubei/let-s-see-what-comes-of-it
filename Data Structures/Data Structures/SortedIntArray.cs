using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures
{
    public class SortedIntArray : IntArray
    {
        public SortedIntArray()
        {
            this.array = new int[8];
            Count = 0;
        }

        public override void Add(int element)
        {
            if (Count == array.Length)
            {
                Array.Resize(ref this.array, this.array.Length * 2);
            }

            bool check = false;
            for(int i = 0; i < Count; i++)
            {
                if(this.array[i] > element)
                {
                    ShiftRight(i);
                    this.array[i] = element;
                    check = true;
                    break;
                }
            }

            if(!check)
            {
                this.array[Count] = element;
            }

            Count++;
        }
        
        public override void SetElement(int index, int element)
        {
            if (element < array[index - 1])
            {
                for (int i = index-1; i >= 0; i--)
                {
                    if (element > array[i])
                    {
                        for (int j = i+1; j < index; j++)
                        {
                            this.array[j+1] = this.array[j];
                        }

                        array[i+1] = element;
                        break;
                    }
                }
            }

            else if (element > array[index + 1])
            {
                for (int i = index + 1; i < Count; i++)
                {
                    if (element < array[i])
                    {
                        for (int j = index; j < i-1; j++)
                        {
                            this.array[j] = this.array[j + 1];
                        }

                        array[i-1] = element;
                        break;
                    }
                }
            }

            else array[index] = element;
        }
        
        public override void Insert(int index, int element)
        {
            if(array[index]>element && array[index-1]<element)
            {
                this.Add(element);
            }
        }
    }
}
