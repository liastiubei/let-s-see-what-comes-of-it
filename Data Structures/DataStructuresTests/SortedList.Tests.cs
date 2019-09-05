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
        public void CheckIfSetElementWorksCorrectly1()
        {
            var array = new Data_Structures.SortedList<int> { 0, 1, 2, 3, 4 };
            array.SetElement(2, 5);
            bool x = (array[2] == 3);
            bool y = (array[4] == 5);
            Assert.True(x && y);
        }

        [Fact]
        public void CheckIfSetElementWorksCorrectly2()
        {
            var array = new Data_Structures.SortedList<int> { 0, 1, 2, 3, 4 };
            array.SetElement(3, 1);
            bool x = (array[2] == 1);
            bool y = (array[1] == 1);
            bool z = (array[3] == 2);
            Assert.True(x && y && z);
        }

        [Fact]
        public void CheckIfInsertWorksCorrectly()
        {
            var array = new Data_Structures.SortedList<int> { 0, 1, 2, 3, 4 };
            array.Insert(3, 1);
            Assert.False(array[3] == 1);
        }
    }
}
