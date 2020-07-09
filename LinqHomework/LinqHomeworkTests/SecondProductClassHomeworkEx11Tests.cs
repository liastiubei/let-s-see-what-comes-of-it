using LinqHomework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LinqHomeworkTests
{
    public class SecondProductClassHomeworkEx11Tests
    {
        [Fact]
        public void CheckIfReturnProductsWithAtLeastOneFeatureFromTheListWorksCorrectly()
        {
            List<ProductExercise11> list1 = new List<ProductExercise11>();
            List<ProductExercise11> list2 = new List<ProductExercise11>();
            List<ProductExercise11> finalList = new List<ProductExercise11>();

            ProductExercise11 item11 = new ProductExercise11("apple", 2);
            list1.Add(item11);
            ProductExercise11 item12 = new ProductExercise11("cinnamon", 4);
            list1.Add(item12);
            ProductExercise11 item13 = new ProductExercise11("beer", 5);
            list1.Add(item13);
            ProductExercise11 item14 = new ProductExercise11("tequila", 6);
            list1.Add(item14);
            ProductExercise11 item15 = new ProductExercise11("water", 1);
            list1.Add(item15);
            ProductExercise11 item16 = new ProductExercise11("pear", 0);
            list1.Add(item16);
            ProductExercise11 item17 = new ProductExercise11("japanesePeopleForSale", 20);
            list1.Add(item17);

            ProductExercise11 item21 = new ProductExercise11("coke", 5);
            list2.Add(item21);
            ProductExercise11 item22 = new ProductExercise11("apple", 1);
            list2.Add(item22);
            ProductExercise11 item23 = new ProductExercise11("fries", 4);
            list2.Add(item23);
            ProductExercise11 item24 = new ProductExercise11("tequila", 2);
            list2.Add(item24);
            ProductExercise11 item25 = new ProductExercise11("cinnamon", 3);
            list2.Add(item25);
            ProductExercise11 item26 = new ProductExercise11("pear", 2);
            list2.Add(item26);
            ProductExercise11 item27 = new ProductExercise11("flyer", 1);
            list2.Add(item27);

            SecondProductClassHomeworkEx11 theList = new SecondProductClassHomeworkEx11(list1, list2);

            ProductExercise11 finalItem1 = new ProductExercise11("apple", 3);
            finalList.Add(finalItem1);
            ProductExercise11 finalItem2 = new ProductExercise11("cinnamon", 7);
            finalList.Add(finalItem2);
            ProductExercise11 finalItem3 = new ProductExercise11("beer", 5);
            finalList.Add(finalItem3);
            ProductExercise11 finalItem4 = new ProductExercise11("tequila", 8);
            finalList.Add(finalItem4);
            ProductExercise11 finalItem5 = new ProductExercise11("water", 1);
            finalList.Add(finalItem5);
            ProductExercise11 finalItem6 = new ProductExercise11("pear", 2);
            finalList.Add(finalItem6);
            ProductExercise11 finalItem7 = new ProductExercise11("japanesePeopleForSale", 20);
            finalList.Add(finalItem7);
            ProductExercise11 finalItem8 = new ProductExercise11("coke", 5);
            finalList.Add(finalItem8);
            ProductExercise11 finalItem9 = new ProductExercise11("fries", 4);
            finalList.Add(finalItem9);
            ProductExercise11 finalItem10 = new ProductExercise11("flyer", 1);
            finalList.Add(finalItem10);

            Assert.Equal(finalList, theList.MashEverythingIntoOne());
        }
    }
}
