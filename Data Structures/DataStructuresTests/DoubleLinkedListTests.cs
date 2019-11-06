using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;

namespace DataStructuresTests
{
    public class DoubleLinkedListTests
    {
        [Fact]
        public void CheckIfAddWorksCorrectly()
        {
            var linkedList = new Data_Structures.DoubleLinkedList<int>();
            linkedList.Add(3);
            linkedList.Add(2);
            linkedList.Add(1);
            Assert.Equal(1, linkedList.Find(2).NextLink.value);
        }

        [Fact]
        public void CheckIfAddBeforeWorksCorrectly()
        {
            var linkedList = new Data_Structures.DoubleLinkedList<int>();
            linkedList.Add(1);
            linkedList.Add(3);
            linkedList.AddBefore(linkedList.Find(3), 2);
            Assert.Equal(2, linkedList.Find(1).NextLink.value);
        }

        [Fact]
        public void CheckIfAddAfterWorksCorrectly()
        {
            var linkedList = new Data_Structures.DoubleLinkedList<int>();
            linkedList.Add(1);
            linkedList.Add(3);
            linkedList.AddAfter(linkedList.Find(1), 2);
            Assert.Equal(2, linkedList.Find(1).NextLink.value);
        }

        [Fact]
        public void CheckIfAddFirstWorksCorrectly()
        {
            var linkedList = new Data_Structures.DoubleLinkedList<int>();
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.AddFirst(1);
            Assert.Equal(1, linkedList.Find(2).PreviousLink.value);
        }

        [Fact]
        public void CheckIfInsertAfterValueWorksCorrectly()
        {
            var linkedList = new Data_Structures.DoubleLinkedList<int>();
            linkedList.Add(3);
            linkedList.Add(2);
            linkedList.Add(1);
            linkedList.AddAfter(linkedList.Find(3), 4);
            Assert.Equal(4, linkedList.Find(3).NextLink.value);
        }

        [Fact]
        public void CheckIfContainsWorksCorrectly1()
        {
            var linkedList = new Data_Structures.DoubleLinkedList<int>();
            linkedList.Add(3);
            linkedList.Add(2);
            linkedList.Add(1);
            Assert.True(linkedList.Contains(2));
        }

        [Fact]
        public void CheckIfContainsWorksCorrectly2()
        {
            var linkedList = new Data_Structures.DoubleLinkedList<int>();
            linkedList.Add(3);
            linkedList.Add(2);
            linkedList.Add(1);
            Assert.False(linkedList.Contains(4));
        }

        [Fact]
        public void CheckIfClearWorksCorrectly()
        {
            var linkedList = new Data_Structures.DoubleLinkedList<int>();
            linkedList.Add(3);
            linkedList.Add(2);
            linkedList.Add(1);
            linkedList.Clear();
            Assert.False(linkedList.Contains(1));
        }

        [Fact]
        public void CheckIfRemoveWorksCorrectly()
        {
            var linkedList = new Data_Structures.DoubleLinkedList<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Remove(2);
            Assert.Equal(3, linkedList.Find(1).NextLink.value);
        }
    }
}
