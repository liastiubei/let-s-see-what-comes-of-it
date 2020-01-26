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
        public void CheckIfAllArgumentsWorkCorrectly()
        {
            DataStructures.ListCollection<string> array = null;
            Func<string, bool> isUpperCase = x => x[0] >= 65 && x[0] <= 90;
            Assert.Throws<ArgumentNullException>(() => DataStructures.LinqFunctions.All<string>(array, isUpperCase));
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
        public void CheckIfAnyArgumentsWorksCorrectly()
        {
            DataStructures.ListCollection<string> array = null;
            Func<string, bool> isUpperCase = x => x[0] >= 65 && x[0] <= 90;
            Assert.Throws<ArgumentNullException>(() => DataStructures.LinqFunctions.Any<string>(array, isUpperCase));
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
            array.Add("Paul");
            array.Add("zero");
            array.Add("penelope");
            Func<string, bool> isUpperCase = x => x[0] >= 65 && x[0] <= 90;
            Assert.True(DataStructures.LinqFunctions.First<string>(array, isUpperCase) == "Paul");
        }

        [Fact]
        public void CheckIfFirstArgumentsWorksCorrectly1()
        {
            DataStructures.ListCollection<string> array = new DataStructures.ListCollection<string>();
            Func<string, bool> isUpperCase = x => x[0] >= 65 && x[0] <= 90;
            Assert.Throws<InvalidOperationException>(() => DataStructures.LinqFunctions.First<string>(array, isUpperCase) == "Ana");
        }

        [Fact]
        public void CheckIfFirstArgumentsWorksCorrectly2()
        {
            DataStructures.ListCollection<string> array = null;
            Func<string, bool> isUpperCase = x => x[0] >= 65 && x[0] <= 90;
            Assert.Throws<ArgumentNullException>(() => DataStructures.LinqFunctions.First<string>(array, isUpperCase));
        }

        [Fact]
        public void CheckIfSelectArgumentsWorksCorrectly()
        {
            DataStructures.ListCollection<string> array = null;
            Func<string, string> makeUpperCase = x =>
            {
                string y = x;
                if (x[0] >= 97 && x[0] <= 122)
                {
                    y = x[0].ToString().ToUpper() + x.Substring(1, x.Length - 1);
                }

                return y;
            };

            Func<string, bool> isUpperCase = x => x[0] >= 65 && x[0] <= 90;
            Assert.Throws<ArgumentNullException>(() => DataStructures.LinqFunctions.All(DataStructures.LinqFunctions.Select(array, makeUpperCase), isUpperCase));
        }

        [Fact]
        public void CheckIfSelectWorksCorrectly1()
        {
            DataStructures.ListCollection<string> array = new DataStructures.ListCollection<string>();
            array.Add("ana");
            array.Add("paul");
            array.Add("zero");
            array.Add("penelope");
            Func<string, string> makeUpperCase = x =>
            {
                string y = x;
                if (x[0] >= 97 && x[0] <= 122)
                {
                    y = x[0].ToString().ToUpper() + x.Substring(1, x.Length - 1);
                }

                return y;
            };

            Func<string, bool> isUpperCase = x => x[0] >= 65 && x[0] <= 90;
            Assert.True(DataStructures.LinqFunctions.All(DataStructures.LinqFunctions.Select(array, makeUpperCase), isUpperCase));
        }

        [Fact]
        public void CheckIfSelectWorksCorrectly2()
        {
            DataStructures.ListCollection<string> array = new DataStructures.ListCollection<string>();
            array.Add("ana");
            array.Add("paul");
            array.Add("zero");
            array.Add("penelope");
            Func<string, string> makeUpperCase = x =>
            {
                string y = x;
                if (x[0] >= 97 && x[0] <= 122)
                {
                    y = x[0].ToString().ToUpper() + x.Substring(1, x.Length - 1);
                }

                return y;
            };

            Func<string, bool> isLowerCase = x => x[0] >= 97 && x[0] <= 122;
            Assert.False(DataStructures.LinqFunctions.Any(DataStructures.LinqFunctions.Select(array, makeUpperCase), isLowerCase));
        }

        [Fact]
        public void CheckIfSelectManyArgumentsWorksCorrectly()
        {
            DataStructures.ListCollection<List<string>> array = null;
            Func<List<string>, List<List<string>>> makeUpperCaseFirstAndAll = x =>
            {
                List<List<string>> returnList = new List<List<string>>();
                foreach (var obj in x)
                {
                    string first = obj;
                    if (obj[0] >= 97 && obj[0] <= 122)
                    {
                        first = obj[0].ToString().ToUpper() + obj.Substring(1, obj.Length - 1);
                    }

                    string all = obj.ToUpper();
                    returnList.Add(new List<string> { first, all });
                }

                return returnList;
            };

            Func<List<string>, bool> isFirstUpperCase = x =>
            {
                foreach (var obj in x)
                {
                    if (!(obj[0] >= 65 && obj[0] <= 90))
                    {
                        return false;
                    }
                }

                return true;
            };

            Assert.Throws<ArgumentNullException>(() => DataStructures.LinqFunctions.SelectMany<List<string>, List<string>>(array, makeUpperCaseFirstAndAll));
        }

        [Fact]
        public void CheckIfSelectManyWorksCorrectly()
        {
            DataStructures.ListCollection<List<string>> array = new DataStructures.ListCollection<List<string>>();
            array.Add(new List<string> { "Ana", "alex", "Andrei" });
            array.Add(new List<string> { "Paul", "paula", "Pelena", "penelope" });
            array.Add(new List<string> { "zero", "Zen", "zohan" });
            Func<List<string>, List<List<string>>> makeUpperCaseFirstAndAll = x =>
            {
                List<List<string>> returnList = new List<List<string>>();
                foreach (var obj in x)
                {
                    string first = obj;
                    if (obj[0] >= 97 && obj[0] <= 122)
                    {
                        first = obj[0].ToString().ToUpper() + obj.Substring(1, obj.Length - 1);
                    }

                    string all = obj.ToUpper();
                    returnList.Add(new List<string> { first, all });
                }

                return returnList;
            };

            Func<List<string>, bool> isFirstUpperCase = x =>
            {
                foreach (var obj in x)
                {
                    if (!(obj[0] >= 65 && obj[0] <= 90))
                    {
                        return false;
                    }
                }

                return true;
            };

            Assert.True(DataStructures.LinqFunctions.All(DataStructures.LinqFunctions.SelectMany<List<string>, List<string>>(array, makeUpperCaseFirstAndAll), isFirstUpperCase));
        }
    }
}
