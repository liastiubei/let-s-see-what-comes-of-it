using System;
using Xunit;

namespace DataStructuresTests
{
    public class UnitTest1
    {
        [Fact]
        public void CheckIfAddWorksCorrectly()
        {
            int[] newArray = { 1, 2, 3, 4, 5, 6 };
            Data_Structures.IntArray array = new Data_Structures.IntArray(newArray);
            int[] changedArray = { 1, 2, 3, 4, 5, 6, 7 };
            array.Add(7);
            Assert.Equal(changedArray, array.ShowArray());
        }

        [Fact]
        public void CheckIfCountReturnsTheCorrectAnswer()
        {
            int[] newArray = { 1, 2, 3, 4, 5, 6 };
            Data_Structures.IntArray array = new Data_Structures.IntArray(newArray);
            Assert.Equal(6, array.Count());
        }

        [Fact]
        public void CheckIfElementWorksCorrectly()
        {
            int[] newArray = { 1, 2, 3, 4, 5, 6 };
            Data_Structures.IntArray array = new Data_Structures.IntArray(newArray);
            Assert.Equal(5, array.Element(4));
        }

        [Fact]
        public void CheckIfSetElementWorksCorrectly()
        {
            int[] newArray = { 1, 2, 3, 4, 5, 6 };
            Data_Structures.IntArray array = new Data_Structures.IntArray(newArray);
            newArray[3] = 3;
            array.SetElement(3, 3);
            Assert.Equal(newArray, array.ShowArray());
        }

        [Fact]
        public void CheckIfSetContainsWorksCorrectly1ShouldReturnTrue()
        {
            int[] newArray = { 1, 2, 3, 4, 5, 6 };
            Data_Structures.IntArray array = new Data_Structures.IntArray(newArray);
            Assert.Equal(true, array.Contains(5));
        }

        [Fact]
        public void CheckIfSetContainsWorksCorrectly2ShouldReturnFalse()
        {
            int[] newArray = { 1, 2, 3, 4, 5, 6 };
            Data_Structures.IntArray array = new Data_Structures.IntArray(newArray);
            Assert.Equal(false, array.Contains(9));
        }

        [Fact]
        public void CheckIfSetIndexOfsWorksCorrectly1ShouldReturnNumber()
        {
            int[] newArray = { 1, 2, 3, 4, 5, 6 };
            Data_Structures.IntArray array = new Data_Structures.IntArray(newArray);
            Assert.Equal(4, array.IndexOf(5));
        }

        [Fact]
        public void CheckIfSetIndexOfsWorksCorrectly2ShouldReturnMinus1()
        {
            int[] newArray = { 1, 2, 3, 4, 5, 6 };
            Data_Structures.IntArray array = new Data_Structures.IntArray(newArray);
            Assert.Equal(-1, array.IndexOf(10));
        }

        [Fact]
        public void CheckIfSetClearWorksCorrectly()
        {
            int[] newArray = { 1, 2, 3, 4, 5, 6 };
            Data_Structures.IntArray array = new Data_Structures.IntArray(newArray);
            array.Clear();
            int[] clearArray = {0, 0, 0, 0, 0, 0};
            Assert.Equal(clearArray, array.ShowArray());
        }

        [Fact]
        public void CheckIfSetRemoveWorksCorrectly()
        {
            int[] newArray = { 1, 2, 3, 4, 5, 6 };
            Data_Structures.IntArray array = new Data_Structures.IntArray(newArray);
            array.Remove(4);
            int[] removedArray = { 1, 2, 3, 5, 6};
            Assert.Equal(removedArray, array.ShowArray());
        }

        [Fact]
        public void CheckIfSetRemoveAtWorksCorrectly()
        {
            int[] newArray = { 1, 2, 3, 4, 5, 6 };
            Data_Structures.IntArray array = new Data_Structures.IntArray(newArray);
            array.RemoveAt(4);
            int[] removedArray = { 1, 2, 3, 4, 6 };
            Assert.Equal(removedArray, array.ShowArray());
        }
    }
}
