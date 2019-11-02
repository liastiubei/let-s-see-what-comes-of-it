using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures
{
    public class DoubleLink<T>
    {
        public T value { get; set; }
        public DoubleLink<T> PreviousLink { get; set; }
        public DoubleLink<T> NextLink { get; set; }
        
        public DoubleLink(T value)
        {
            this.value = value;
        }
    }
}
