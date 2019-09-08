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

        public void SetElement(int index, T element)
        {
            if (array[index + 1].CompareTo(element) >= 0 && array[index - 1].CompareTo(element) <= 0)
            {
                this.array[index] = element;
            }
        }

        public override void Insert(int index, T element)
        {
            if (array[index].CompareTo(element) >= 0 && array[index - 1].CompareTo(element) <= 0)
            {
                this.Add(element);
            }
        }
    }
}
