using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqHomework
{
    public class Stocks
    {
        private List<Product> stock = new List<Product>();

        public Action<Product, int> StockNotification;

        public void Add(Product product)
        {
            stock.Add(product);
        }

        public void AddQuantity(string name, int quantity)
        {
            foreach (var item in stock)
            {
                if (item.Name == name)
                {
                    item.Quantity += quantity;
                    return;
                }
            }

            throw new ArgumentException("Name not found");
        }

        public void Remove(string name, int quantity)
        {
            Product item = stock.First(x => x.Name == name);
            if (item.Quantity < quantity)
            {
                throw new ArgumentException("Not enough items to remove");
            }
            int oldQuantity = item.Quantity;
            item.Quantity = oldQuantity - quantity;
            int[] warnings = { 2, 5, 10 };
            if (warnings.Any(number => item.Quantity < number && oldQuantity >= number))
            {
                StockNotification.Invoke(item, item.Quantity);
            }
        }
    }
}
