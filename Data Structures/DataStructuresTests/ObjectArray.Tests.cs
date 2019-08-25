using System;
using Xunit;

namespace DataStructuresTests
{
    public class ObjectArrayTests
    {
        Data_Structures.ObjectArray array = new Data_Structures.ObjectArray();

        [Fact]
        public void CheckIfAddWorksCorrectly1()
        {
            array.Add(1);
            array.Add("hercules");
            array.Add('a');
            Assert.Equal(array.Element(0), 1);
        }

        [Fact]
        public void CheckIfAddWorksCorrectly2()
        {
            array.Add(1);
            array.Add("hercules");
            array.Add('a');
            Assert.Equal(array.Element(1), "hercules");
        }

        [Fact]
        public void CheckIfAddWorksCorrectly3()
        {
            array.Add(1);
            array.Add("hercules");
            array.Add('a');
            Assert.Equal(array.Element(2), 'a');
        }
    }
}
