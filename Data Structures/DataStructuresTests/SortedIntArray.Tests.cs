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
            int[] newArray = new int[5];
            for(int i=0;i<5;i++)
            {
                newArray[i] = writtenArray[i];
            }
            Assert.True(writtenArray[0]==-1 && writtenArray[1]==1 && writtenArray[2]==2 && writtenArray[3]==3 && writtenArray[4]==5);
        }
    }
}
