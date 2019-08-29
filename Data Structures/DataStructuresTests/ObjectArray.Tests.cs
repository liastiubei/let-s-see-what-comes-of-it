using System;
using Xunit;

namespace DataStructuresTests
{
    public class ObjectArrayTests
    {
        [Fact]
        public void CheckIfIEnumWorksCorrectly1()
        {
            object[] objArray = {"hat", 1, "hercules", 'a' };
            var newArray = new object[1]
            {
                "hat"
            };
            Data_Structures.ObjectArray array = new Data_Structures.ObjectArray { "hat", 1, "hercules", 'a' };
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
