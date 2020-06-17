using System;
using System.Collections.Generic;
using Xunit;

namespace LinqHomeworkTests
{
    public class StocksTests
    {
        [Fact]
        public void CheckIfNotificationAppearsWhenLessThan10ProductsInStock()
        {
            LinqHomework.Stocks stocks = new LinqHomework.Stocks();
            stocks.Add(new LinqHomework.Product("Lightbulb", 25, 12));
            stocks.Add(new LinqHomework.Product("Matches", 2, 70));
            stocks.Add(new LinqHomework.Product("Notebook", 10, 30));
            List<string> notificationList = new List<string>();
            void GetNotified(LinqHomework.Product item, int itemsLeft)
            {
                notificationList.Add(itemsLeft + " " + item.Name + " left.");
            }

            stocks.StockNotification = GetNotified;
            stocks.Remove("Lightbulb", 5);
            Assert.Equal("7 Lightbulb left.", notificationList[0]);
        }

        [Fact]
        public void CheckIfNotificationAppearsWhenLessThan5ProductsInStock()
        {
            LinqHomework.Stocks stocks = new LinqHomework.Stocks();
            stocks.Add(new LinqHomework.Product("Lightbulb", 25, 12));
            stocks.Add(new LinqHomework.Product("Matches", 2, 70));
            stocks.Add(new LinqHomework.Product("Notebook", 10, 30));
            List<string> notificationList = new List<string>();
            void GetNotified(LinqHomework.Product item, int itemsLeft)
            {
                notificationList.Add(itemsLeft + " " + item.Name + " left.");
            }

            stocks.StockNotification = GetNotified;
            stocks.Remove("Lightbulb", 8);
            Assert.Equal("4 Lightbulb left.", notificationList[0]);
        }

        [Fact]
        public void CheckIfNotificationAppearsWhenLessThan2ProductsInStock()
        {
            LinqHomework.Stocks stocks = new LinqHomework.Stocks();
            stocks.Add(new LinqHomework.Product("Lightbulb", 25, 12));
            stocks.Add(new LinqHomework.Product("Matches", 2, 70));
            stocks.Add(new LinqHomework.Product("Notebook", 10, 30));
            List<string> notificationList = new List<string>();
            void GetNotified(LinqHomework.Product item, int itemsLeft)
            {
                notificationList.Add(itemsLeft + " " + item.Name + " left.");
            }

            stocks.StockNotification = GetNotified;
            stocks.Remove("Lightbulb", 11);
            Assert.Equal("1 Lightbulb left.", notificationList[0]);
        }
    }
}
