using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqHomework
{
    public class SecondProductClassHomeworkEx11
    {
        List<ProductExercise11> listNumber1;
        List<ProductExercise11> listNumber2;

        public SecondProductClassHomeworkEx11(List<ProductExercise11> list1, List<ProductExercise11> list2)
        {
            this.listNumber1 = list1;
            this.listNumber2 = list2;
        }

        public List<ProductExercise11> MashEverythingIntoOne()
        {
            Func<IGrouping<string, ProductExercise11>, ProductExercise11> groupToProduct = x =>
            {
                var product = new ProductExercise11();
                product.Name = x.Key;
                product.Quantity = x.Aggregate(0, (totalNumberOfItems, i) => totalNumberOfItems + i.Quantity);
                return product;
            };

            return listNumber1.Concat(listNumber2).GroupBy(x => x.Name).Select(groupToProduct).ToList();
        }
    }

    public struct ProductExercise11
    {
        public string Name;
        public int Quantity;

        public ProductExercise11(string name, int quantity) : this()
        {
            this.Name = name;
            this.Quantity = quantity;
        }
    }

}
