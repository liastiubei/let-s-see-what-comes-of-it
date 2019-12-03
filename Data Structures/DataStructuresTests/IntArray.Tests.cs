using System;
using Xunit;

namespace DataStructuresTests
{
    public class UnitTest1
    {
        [Fact]
        public void CheckIfAddWorksCorrectly()
        {
            DataStructures.IntArray array = new DataStructures.IntArray();
            array.Add(1);
            Assert.Equal(0, array.IndexOf(1));
        }

        [Fact]
        public void CheckIfCountReturnsTheCorrectAnswer()
        {
            DataStructures.IntArray array = new DataStructures.IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            Assert.Equal(3, array.Count);
        }

        [Fact]
        public void CheckIfElementWorksCorrectly()
        {
            DataStructures.IntArray array = new DataStructures.IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Add(5);
            array.Add(6);
            Assert.Equal(5, array.Element(4));
        }

        [Fact]
        public void CheckIfSetElementWorksCorrectly()
        {
            DataStructures.IntArray array = new DataStructures.IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.SetElement(1, 4);
            Assert.Equal(4, array.Element(1));
        }

        [Fact]
        public void CheckIfContainsWorksCorrectly1ShouldReturnTrue()
        {
            DataStructures.IntArray array = new DataStructures.IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            Assert.Equal(true, array.Contains(2));
        }

        [Fact]
        public void CheckIfContainsWorksCorrectly2ShouldReturnFalse()
        {
            DataStructures.IntArray array = new DataStructures.IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            Assert.Equal(false, array.Contains(9));
        }

        [Fact]
        public void CheckIfIndexOfsWorksCorrectly1ShouldReturnNumber()
        {
            DataStructures.IntArray array = new DataStructures.IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            Assert.Equal(1, array.IndexOf(2));
        }

        [Fact]
        public void CheckIfIndexOfsWorksCorrectly2ShouldReturnMinus1()
        {
            DataStructures.IntArray array = new DataStructures.IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            Assert.Equal(-1, array.IndexOf(10));
        }

        [Fact]
        public void CheckIfSetClearWorksCorrectly()
        {
            DataStructures.IntArray array = new DataStructures.IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Clear();
            bool check = true;
            for (int i = 0; i < 6; i++)
            {
                if (array.Element(i) != 0)
                {
                    check = false;
                    break;
                }
            }

            Assert.True(check);
        }

        [Fact]
        public void CheckIfRemoveWorksCorrectly()
        {
            DataStructures.IntArray array = new DataStructures.IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Add(5);
            array.Add(6);
            array.Remove(4);
            Assert.True(array.Element(3) == 5);
        }

        [Fact]
        public void CheckIfSetRemoveAtWorksCorrectly()
        {
            DataStructures.IntArray array = new DataStructures.IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Add(5);
            array.Add(6);
            array.RemoveAt(4);
            Assert.True(array.Element(4) == 6);
        }
    }
}
