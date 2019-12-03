using System;
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
            var linkedList = new DataStructures.DoubleLinkedListCollection<int>();
            linkedList.Add(3);
            linkedList.Add(2);
            linkedList.Add(1);
            Assert.Equal(1, linkedList.Find(2).NextLink.Value);
        }

        [Fact]
        public void CheckIfAddBeforeWorksCorrectly()
        {
            var linkedList = new DataStructures.DoubleLinkedListCollection<int>();
            linkedList.Add(1);
            linkedList.Add(3);
            linkedList.AddBefore(linkedList.Find(3), 2);
            Assert.Equal(2, linkedList.Find(1).NextLink.Value);
        }

        [Fact]
        public void CheckIfAddAfterWorksCorrectly()
        {
            var linkedList = new DataStructures.DoubleLinkedListCollection<int>();
            linkedList.Add(1);
            linkedList.Add(3);
            linkedList.AddAfter(linkedList.Find(1), 2);
            Assert.Equal(2, linkedList.Find(1).NextLink.Value);
        }

        [Fact]
        public void CheckIfAddFirstWorksCorrectly()
        {
            var linkedList = new DataStructures.DoubleLinkedListCollection<int>();
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.AddFirst(1);
            Assert.Equal(1, linkedList.Find(2).PreviousLink.Value);
        }

        [Fact]
        public void CheckIfInsertAfterValueWorksCorrectly()
        {
            var linkedList = new DataStructures.DoubleLinkedListCollection<int>();
            linkedList.Add(3);
            linkedList.Add(2);
            linkedList.Add(1);
            linkedList.AddAfter(linkedList.Find(3), 4);
            Assert.Equal(4, linkedList.Find(3).NextLink.Value);
        }

        [Fact]
        public void CheckIfContainsWorksCorrectly1()
        {
            var linkedList = new DataStructures.DoubleLinkedListCollection<int>();
            linkedList.Add(3);
            linkedList.Add(2);
            linkedList.Add(1);
            Assert.True(linkedList.Contains(2));
        }

        [Fact]
        public void CheckIfContainsWorksCorrectly2()
        {
            var linkedList = new DataStructures.DoubleLinkedListCollection<int>();
            linkedList.Add(3);
            linkedList.Add(2);
            linkedList.Add(1);
            Assert.False(linkedList.Contains(4));
        }

        [Fact]
        public void CheckIfClearWorksCorrectly()
        {
            var linkedList = new DataStructures.DoubleLinkedListCollection<int>();
            linkedList.Add(3);
            linkedList.Add(2);
            linkedList.Add(1);
            linkedList.Clear();
            Assert.False(linkedList.Contains(1));
        }

        [Fact]
        public void CheckIfRemoveWorksCorrectly()
        {
            var linkedList = new DataStructures.DoubleLinkedListCollection<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Remove(2);
            Assert.Equal(3, linkedList.Find(1).NextLink.Value);
        }

        [Fact]
        public void CheckIfRemoveFirstWorksCorrectly()
        {
            var linkedList = new DataStructures.DoubleLinkedListCollection<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.RemoveFirst();
            Assert.Equal(null, linkedList.Find(1));
        }

        [Fact]
        public void CheckIfRemoveLastWorksCorrectly()
        {
            var linkedList = new DataStructures.DoubleLinkedListCollection<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.RemoveLast();
            Assert.Equal(null, linkedList.Find(3));
        }

        [Fact]
        public void CheckIfEqualsWorksCorrectly1()
        {
            var linkedList = new DataStructures.DoubleLinkedListCollection<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            var equalObject = linkedList;
            Assert.True(linkedList.Equals(equalObject));
        }

        [Fact]
        public void CheckIfEqualsWorksCorrectly2()
        {
            var linkedList = new DataStructures.DoubleLinkedListCollection<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            var equalObject = new DataStructures.DoubleLinkedListCollection<int>();
            equalObject.Add(4);
            Assert.False(equalObject.Equals(linkedList));
        }

        [Fact]
        public void CheckIfFindLastWorksCorrectly()
        {
            var linkedList = new DataStructures.DoubleLinkedListCollection<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            const int i = 2;
            linkedList.Add(i);
            Assert.Equal(linkedList.Find(2).NextLink.NextLink, linkedList.FindLast(2));
        }

        [Fact]
        public void CheckIfAddBeforeExceptionReadOnlyWorksCorrectly()
        {
            var linkedList = new DataStructures.DoubleLinkedListCollection<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.MakeReadOnly();
            Assert.Throws<NotSupportedException>(() => linkedList.AddBefore(linkedList.Find(3), 2));
        }

        [Fact]
        public void CheckIfAddBeforeArgumentNullExceptionWorksCorrectly()
        {
            var linkedList = new DataStructures.DoubleLinkedListCollection<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            Assert.Throws<ArgumentNullException>(() => linkedList.AddBefore(null, 2));
        }

        [Fact]
        public void CheckIfAddBeforeInvalidOperationExceptionWorksCorrectly()
        {
            var linkedList = new DataStructures.DoubleLinkedListCollection<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            var newLink = new DataStructures.DoubleLink<int>(5);
            Assert.Throws<InvalidOperationException>(() => linkedList.AddBefore(newLink, 2));
        }

        [Fact]
        public void CheckIfClearReadonlyExceptionWorksCorrectly()
        {
            var linkedList = new DataStructures.DoubleLinkedListCollection<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.MakeReadOnly();
            Assert.Throws<NotSupportedException>(() => linkedList.Clear());
        }

        [Fact]
        public void CheckIfCopyToNullArrayExceptionWorksCorrectly()
        {
            var linkedList = new DataStructures.DoubleLinkedListCollection<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            var array = new int[2];
            array = null;
            Assert.Throws<ArgumentNullException>(() => linkedList.CopyTo(array, 1));
        }

        [Fact]
        public void CheckIfCopyToIndexSmallerThanZeroExceptionWorksCorrectly()
        {
            var linkedList = new DataStructures.DoubleLinkedListCollection<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            var array = new int[20];
            Assert.Throws<ArgumentOutOfRangeException>(() => linkedList.CopyTo(array, -10));
        }

        [Fact]
        public void CheckIfCopyToNotEnoughSpaceExceptionWorksCorrectly()
        {
            var linkedList = new DataStructures.DoubleLinkedListCollection<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            var array = new int[3];
            Assert.Throws<ArgumentException>(() => linkedList.CopyTo(array, 1));
        }

        [Fact]
        public void CheckIfRemoveReadonlyExceptionWorksCorrectly()
        {
            var linkedList = new DataStructures.DoubleLinkedListCollection<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.MakeReadOnly();
            Assert.Throws<NotSupportedException>(() => linkedList.Remove(2));
        }

        [Fact]
        public void CheckIfRemoveFirstReadonlyExceptionWorksCorrectly()
        {
            var linkedList = new DataStructures.DoubleLinkedListCollection<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.MakeReadOnly();
            Assert.Throws<NotSupportedException>(() => linkedList.RemoveFirst());
        }

        [Fact]
        public void CheckIfRemoveFirstEmptyExceptionWorksCorrectly()
        {
            var linkedList = new DataStructures.DoubleLinkedListCollection<int>();
            Assert.Throws<InvalidOperationException>(() => linkedList.RemoveFirst());
        }

        [Fact]
        public void CheckIfRemoveLastReadonlyExceptionWorksCorrectly()
        {
            var linkedList = new DataStructures.DoubleLinkedListCollection<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.MakeReadOnly();
            Assert.Throws<NotSupportedException>(() => linkedList.RemoveLast());
        }

        [Fact]
        public void CheckIfRemoveLastEmptyExceptionWorksCorrectly()
        {
            var linkedList = new DataStructures.DoubleLinkedListCollection<int>();
            Assert.Throws<InvalidOperationException>(() => linkedList.RemoveLast());
        }
    }
}
