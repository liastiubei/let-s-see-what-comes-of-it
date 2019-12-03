using System;
using Xunit;

namespace DataStructuresTests
{
    public class SortedIntArrayTests
    {
        [Fact]
        public void CheckIfAddAndSortWorksCorrectly()
        {
            DataStructures.SortedIntArray writtenArray = new DataStructures.SortedIntArray();
            writtenArray.Add(1);
            writtenArray.Add(5);
            writtenArray.Add(2);
            writtenArray.Add(-1);
            writtenArray.Add(3);
            bool a = writtenArray[0] == -1 && writtenArray[1] == 1 && writtenArray[2] == 2;
            Assert.True(a && writtenArray[3] == 3 && writtenArray[4] == 5);
        }

        [Fact]
        public void CheckIfSetElementAndSortWorksCorrectly1()
        {
            DataStructures.SortedIntArray writtenArray = new DataStructures.SortedIntArray();
            writtenArray.Add(1);
            writtenArray.Add(5);
            writtenArray.Add(2);
            writtenArray.Add(-1);
            writtenArray.Add(3);
            writtenArray.SetElement(2, 4);
            bool a = writtenArray[0] == -1 && writtenArray[1] == 1 && writtenArray[2] == 3;
            Assert.True(a && writtenArray[3] == 4 && writtenArray[4] == 5);
        }

        [Fact]
        public void CheckIfSetElementAndSortWorksCorrectly2()
        {
            DataStructures.SortedIntArray writtenArray = new DataStructures.SortedIntArray();
            writtenArray.Add(1);
            writtenArray.Add(5);
            writtenArray.Add(2);
            writtenArray.Add(-1);
            writtenArray.Add(3);
            writtenArray.SetElement(2, 0);
            bool a = writtenArray[0] == -1 && writtenArray[1] == 0 && writtenArray[2] == 1;
            Assert.True(a && writtenArray[3] == 3 && writtenArray[4] == 5);
        }

        [Fact]
        public void CheckIfInsertWorksCorrectly1()
        {
            DataStructures.SortedIntArray writtenArray = new DataStructures.SortedIntArray();
            writtenArray.Add(1);
            writtenArray.Add(5);
            writtenArray.Add(2);
            writtenArray.Add(-1);
            writtenArray.Add(3);
            writtenArray.Insert(4, 4);
            bool a = writtenArray[0] == -1 && writtenArray[1] == 1 && writtenArray[2] == 2;
            bool b = writtenArray[3] == 3 && writtenArray[4] == 4 && writtenArray[5] == 5;
            Assert.True(a && b);
        }

        [Fact]
        public void CheckIfInsertWorksCorrectly2()
        {
            DataStructures.SortedIntArray writtenArray = new DataStructures.SortedIntArray();
            writtenArray.Add(1);
            writtenArray.Add(5);
            writtenArray.Add(2);
            writtenArray.Add(-1);
            writtenArray.Add(3);
            writtenArray.Insert(4, 2);
            bool a = writtenArray[0] == -1 && writtenArray[1] == 1 && writtenArray[2] == 2;
            Assert.True(a && writtenArray[3] == 3 && writtenArray[4] == 5);
        }
    }
}
