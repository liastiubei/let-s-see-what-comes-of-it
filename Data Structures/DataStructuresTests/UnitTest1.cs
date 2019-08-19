using System;
using Xunit;

namespace DataStructuresTests
{
    public class UnitTest1
    {
        Data_Structures.IntArray array = new Data_Structures.IntArray();
        
        [Fact]
        public void CheckIfAddWorksCorrectly()
        {
            array.Add(1);
            Assert.Equal(0, array.IndexOf(1));
        }
        
        [Fact]
        public void CheckIfCountReturnsTheCorrectAnswer()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);
            Assert.Equal(3, array.Count);
        }

        [Fact]
        public void CheckIfElementWorksCorrectly()
        {
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
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.SetElement(1, 4);
            Assert.Equal(4, array.Element(1));
        }

        [Fact]
        public void CheckIfContainsWorksCorrectly1ShouldReturnTrue()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);
            Assert.Equal(true, array.Contains(2));
        }

        [Fact]
        public void CheckIfContainsWorksCorrectly2ShouldReturnFalse()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);
            Assert.Equal(false, array.Contains(9));
        }

        [Fact]
        public void CheckIfIndexOfsWorksCorrectly1ShouldReturnNumber()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);
            Assert.Equal(1, array.IndexOf(2));
        }

        [Fact]
        public void CheckIfIndexOfsWorksCorrectly2ShouldReturnMinus1()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);
            Assert.Equal(-1, array.IndexOf(10));
        }

        [Fact]
        public void CheckIfSetClearWorksCorrectly()
        {
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Clear();
            bool check = true;
            for(int i = 0; i < 6; i++)
            {
                if(array.Element(i) != 0)
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
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Add(5);
            array.Add(6);
            array.Remove(4);
            Assert.True(array.Element(3)==5);
        }

        [Fact]
        public void CheckIfSetRemoveAtWorksCorrectly()
        {
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
