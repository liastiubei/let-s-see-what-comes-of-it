using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;

namespace DataStructuresTests
{
    public class LinqFunctionsTests
    {
        [Fact]
        public void CheckIfAllWorksCorrectly1()
        {
            DataStructures.ListCollection<string> array = new DataStructures.ListCollection<string>();
            array.Add("Ana");
            array.Add("Paul");
            array.Add("zero");
            array.Add("Penelope");
            Func<string, bool> isUpperCase = x => x[0] >= 65 && x[0] <= 90;
            Assert.False(DataStructures.LinqFunctions.All<string>(array, isUpperCase));
        }

        [Fact]
        public void CheckIfAllWorksCorrectly2()
        {
            DataStructures.ListCollection<string> array = new DataStructures.ListCollection<string>();
            array.Add("Ana");
            array.Add("Paul");
            array.Add("Zero");
            array.Add("Penelope");
            Func<string, bool> isUpperCase = x => x[0] >= 65 && x[0] <= 90;
            Assert.True(DataStructures.LinqFunctions.All<string>(array, isUpperCase));
        }

        [Fact]
        public void CheckIfAnyWorksCorrectly1()
        {
            DataStructures.ListCollection<string> array = new DataStructures.ListCollection<string>();
            array.Add("Ana");
            array.Add("paul");
            array.Add("zero");
            array.Add("penelope");
            Func<string, bool> isUpperCase = x => x[0] >= 65 && x[0] <= 90;
            Assert.True(DataStructures.LinqFunctions.Any<string>(array, isUpperCase));
        }

        [Fact]
        public void CheckIfAnyWorksCorrectly2()
        {
            DataStructures.ListCollection<string> array = new DataStructures.ListCollection<string>();
            array.Add("ana");
            array.Add("paul");
            array.Add("zero");
            array.Add("penelope");
            Func<string, bool> isUpperCase = x => x[0] >= 65 && x[0] <= 90;
            Assert.False(DataStructures.LinqFunctions.Any<string>(array, isUpperCase));
        }

        [Fact]
        public void CheckIfFirstWorksCorrectly1()
        {
            DataStructures.ListCollection<string> array = new DataStructures.ListCollection<string>();
            array.Add("Ana");
            array.Add("paul");
            array.Add("zero");
            array.Add("penelope");
            Func<string, bool> isUpperCase = x => x[0] >= 65 && x[0] <= 90;
            Assert.True(DataStructures.LinqFunctions.First<string>(array, isUpperCase) == "Ana");
        }

        [Fact]
        public void CheckIfFirstWorksCorrectly2()
        {
            DataStructures.ListCollection<string> array = new DataStructures.ListCollection<string>();
            array.Add("ana");
            array.Add("paul");
            array.Add("zero");
            array.Add("penelope");
            Func<string, bool> isUpperCase = x => x[0] >= 65 && x[0] <= 90;
            Assert.True(DataStructures.LinqFunctions.First<string>(array, isUpperCase) == null);
        }
    }
}
