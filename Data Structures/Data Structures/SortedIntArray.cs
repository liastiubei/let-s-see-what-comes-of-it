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
        
        private void ShiftRight(int index)
        {
            base.ShiftRight(index);
        }

        public int Element(int index)
        {
            return base.Element(index);
        }

        public void SetElement(int index, int element)
        {
            base.SetElement(index, element);
        }

        public int IndexOf(int element)
        {
            return base.IndexOf(element);
        }

        public bool Contains(int element)
        {
            return base.Contains(element);
        }

        public void Insert(int index, int element)
        {
            base.Insert(index, element);
        }

        public void Clear()
        {
            base.Clear();
        }

        public void Remove(int element)
        {
            base.Remove(element);
        }

        public void RemoveAt(int index)
        {
            base.RemoveAt(index);
        }

        public void ShiftLeft(int index)
        {
            base.ShiftLeft(index);
        }

    }
}
