using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures
{
    public class SortedList<T> : List<T> where T : IComparable<T>
    {
        public SortedList()
        {
            this.array = new T[8];
            Count = 0;
        }

        public override T this[int index]
        {
            get => this.array[index];
            set
            {
                if((index == 0 || this.array[index - 1].CompareTo(value) <= 0) && 
                    (index == Count - 1 || this.array[index + 1].CompareTo(value) >= 0))
                {
                    this.array[index] = value;
                }
            }
        }

        public override void Add(T element)
        {
            Resize();
            bool check = false;
            for (int i = 0; i < Count; i++)
            {
                if (this.array[i].CompareTo(element) == 1)
                {
                    ShiftRight(i);
                    this.array[i] = element;
                    check = true;
                    break;
                }
            }

            if (!check)
            {
                this.array[Count] = element;
            }

            Count++;
        }

        public override void Insert(int index, T element)
        {
            if ((index == 0 || this.array[index - 1].CompareTo(element) <= 0) &&
                    (index == Count || this.array[index + 1].CompareTo(element) >= 0))
            {
                this.Add(element);
            }
        }
    }
}
