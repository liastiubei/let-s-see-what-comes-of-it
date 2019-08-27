using System;
using Xunit;

namespace DataStructuresTests
{
    public class ObjectArrayTests
    {
        [Fact]
        public void CheckIfAddWorksCorrectly1()
        {
            var newArray = new object[1]
            {
                "hat"
            };
            var array = new Data_Structures.ObjectArray(newArray);
            array.Add(1);
            Assert.Equal(array[1], 1);
        }

        [Fact]
        public void CheckIfAddWorksCorrectly2()
        {
            var newArray = new object[1]
            {
                "hat"
            };
            var array = new Data_Structures.ObjectArray(newArray);
            array.Add("hercules");
            Assert.Equal(array[1], "hercules");
        }

        [Fact]
        public void CheckIfAddWorksCorrectly3()
        {
            var newArray = new object[1]
            {
                "hat"
            };
            var array = new Data_Structures.ObjectArray(newArray);
            array.Add('a');
            Assert.Equal(array[1], 'a');
        }
    }
}
