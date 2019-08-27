using System;
using Xunit;

namespace DataStructuresTests
{
    public class ObjectArrayTests
    {
        [Fact]
        public void CheckIfAddWorksCorrectly1()
        {
            object[] objArray = {"hat", 1, "hercules", 'a' };
            var newArray = new object[1]
            {
                "hat"
            };
            var array = new Data_Structures.ObjectArray(newArray);
            array.Add(1);
            array.Add("hercules");
            array.Add('a');
            int i = 0;
            bool k = true;
            foreach(var obj in array)
            {
                if(!Object.Equals(objArray[i], obj))
                {
                    k = false;
                    break;
                }

                i++;
            }
            Assert.True(k);
        }
    }
}
