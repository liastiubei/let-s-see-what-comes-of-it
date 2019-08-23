using System;
using Xunit;

namespace DataStructuresTests
{
    public class SortedIntArrayTests
    {
        Data_Structures.SortedIntArray writtenArray = new Data_Structures.SortedIntArray();

        [Fact]
        public void CheckIfAddAndSortWorksCorrectly()
        {
            writtenArray.Add(1);
            writtenArray.Add(5);
            writtenArray.Add(2);
            writtenArray.Add(-1);
            writtenArray.Add(3);
            Assert.True(writtenArray[0]==-1 && writtenArray[1]==1 && writtenArray[2]==2 && writtenArray[3]==3 && writtenArray[4]==5);
        }

        [Fact]
        public void CheckIfSetElementAndSortWorksCorrectly1()
        {
            writtenArray.Add(1);
            writtenArray.Add(5);
            writtenArray.Add(2);
            writtenArray.Add(-1);
            writtenArray.Add(3);
            writtenArray.SetElement(2, 4);
            Assert.True(writtenArray[0] == -1 && writtenArray[1] == 1 && writtenArray[2] == 3 && writtenArray[3] == 4 && writtenArray[4] == 5);
        }

        [Fact]
        public void CheckIfSetElementAndSortWorksCorrectly2()
        {
            writtenArray.Add(1);
            writtenArray.Add(5);
            writtenArray.Add(2);
            writtenArray.Add(-1);
            writtenArray.Add(3);
            writtenArray.SetElement(2, 0);
            Assert.True(writtenArray[0] == -1 && writtenArray[1] == 0 && writtenArray[2] == 1 && writtenArray[3] == 3 && writtenArray[4] == 5);
        }

        [Fact]
        public void CheckIfInsertWorksCorrectly1()
        {
            writtenArray.Add(1);
            writtenArray.Add(5);
            writtenArray.Add(2);
            writtenArray.Add(-1);
            writtenArray.Add(3);
            writtenArray.Insert(4, 4);
            Assert.True(writtenArray[0] == -1 && writtenArray[1] == 1 && writtenArray[2] == 2 && writtenArray[3] == 3 && writtenArray[4] == 4 && writtenArray[5] == 5);
        }

        [Fact]
        public void CheckIfInsertWorksCorrectly2()
        {
            writtenArray.Add(1);
            writtenArray.Add(5);
            writtenArray.Add(2);
            writtenArray.Add(-1);
            writtenArray.Add(3);
            writtenArray.Insert(4, 2);
            Assert.True(writtenArray[0] == -1 && writtenArray[1] == 1 && writtenArray[2] == 2 && writtenArray[3] == 3 && writtenArray[4] == 5);
        }

    }
}
