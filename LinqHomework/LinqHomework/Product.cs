using System;
using System.Collections.Generic;
using System.Text;

namespace LinqHomework
{
    public class Product
    {
        public string Name;
        public int Price;
        public int Quantity;

        public Product(string Name, int Price, int Quantity)
        {
            this.Name = Name;
            this.Price = Price;
            this.Quantity = Quantity;
        }
    }
}
