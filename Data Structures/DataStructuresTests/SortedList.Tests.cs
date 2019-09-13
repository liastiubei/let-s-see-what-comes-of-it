using System;
using Xunit;

namespace DataStructuresTests
{
    public class SortedListTests
    {
        [Fact]
        public void CheckIfIEnumWorksCorrectly()
        {
            var array = new Data_Structures.SortedList<int> { 0, 1, 4, 2, 3 };
            Assert.Equal(4, array[4]);
        }

        [Fact]
        public void CheckIfIAddWorksCorrectly()
        {
            var array = new Data_Structures.SortedList<int> { 0, 1, 3, 4 };
            array.Add(2);
            Assert.Equal(2, array[2]);
        }

        [Fact]
        public void CheckIfInsertWorksCorrectly1()
        {
            var array = new Data_Structures.SortedList<int> { 0, 1, 2, 3, 4 };
            array.Insert(3, 1);
            Assert.False(array[3] == 1);
        }

        [Fact]
        public void CheckIfInsertWorksCorrectly2()
        {
            var array = new Data_Structures.SortedList<int> { 0, 1, 2, 4, 5 };
            array.Insert(3, 3);
            Assert.True(array[3] == 3);
        }

        [Fact]
        public void CheckIfInsertWorksCorrectly3()
        {
            var array = new Data_Structures.SortedList<int> { 0, 1, 2, 3, 4 };
            array.Insert(0, 1);
            Assert.False(array[0] == 1);
        }

        [Fact]
        public void CheckIfInsertWorksCorrectly4()
        {
            var array = new Data_Structures.SortedList<int> { 0, 1, 2, 3, 4 };
            array.Insert(0, -1);
            Assert.True(array[0] == -1);
        }

        [Fact]
        public void CheckIfInsertWorksCorrectly5()
        {
            var array = new Data_Structures.SortedList<int> { 0, 1, 2, 3, 4 };
            array.Insert(5, 1);
            Assert.False(array[5] == 1);
        }

        [Fact]
        public void CheckIfInsertWorksCorrectly6()
        {
            var array = new Data_Structures.SortedList<int> { 0, 1, 2, 3, 4 };
            array.Insert(5, 5);
            Assert.True(array[5] == 5);
        }
    }
}
