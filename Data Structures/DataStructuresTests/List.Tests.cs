using System;
using Xunit;

namespace DataStructuresTests
{
    public class ListTests
    {
        [Fact]
        public void CheckIfIEnumWorksCorrectly()
        {
            var array = new Data_Structures.List<int> { 0, 1, 2, 3 };
            Assert.Equal(0, array[0]);
        }

        [Fact]
        public void CheckIfAddWorksCorrectly()
        {
            var array = new Data_Structures.List<int> { 0, 1, 2, 3 };
            array.Add(4);
            Assert.Equal(4, array[4]);
        }
    }
}
