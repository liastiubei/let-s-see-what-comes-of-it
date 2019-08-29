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
            bool k = true;
            for(int i = 0; i < array.Count; i++)
            {
                if(!Object.Equals(objArray[i], objArray[i]))
                {
                    k = false;
                    break;
                }
            }
            Assert.True(k);
        }
    }
}
