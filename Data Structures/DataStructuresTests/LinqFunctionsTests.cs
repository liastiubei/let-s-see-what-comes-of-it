using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;

namespace DataStructuresTests
{
    public class LinqFunctionsTests
    {
        [Fact]
        public void CheckIfAllWorksCorrectly()
        {
            DataStructures.ListCollection<string> array = new DataStructures.ListCollection<string>();
            array.Add("Ana");
            array.Add("Paul");
            array.Add("zero");
            array.Add("Penelope");
            Func<string, bool> isUpperCase = x => x[0] >= 65 && x[0] <= 90;
            Assert.False(DataStructures.LinqFunctions.All<string>(array, isUpperCase));
        }
    }
}
