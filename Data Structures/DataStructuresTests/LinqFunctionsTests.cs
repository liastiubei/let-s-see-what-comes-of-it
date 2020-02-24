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

            Assert.Throws<ArgumentNullException>(() => DataStructures.LinqFunctions.All(
                DataStructures.LinqFunctions.SelectMany<List<string>, List<string>>(array, makeUpperCaseFirstAndAll), isFirstUpperCase));
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

        [Fact]
        public void CheckIfWhereWorksCorrectly1()
        {
            DataStructures.ListCollection<string> array = new DataStructures.ListCollection<string>();
            array.Add("ana");
            array.Add("Paul");
            array.Add("zero");
            array.Add("penelope");
            Func<string, bool> isUpperCase = x => x[0] >= 65 && x[0] <= 90;
            List<string> list = new List<string>();
            list.Add("Paul");
            Assert.Equal(DataStructures.LinqFunctions.Where<string>(array, isUpperCase), list);
        }

        [Fact]
        public void CheckIfWhereWorksCorrectly2()
        {
            DataStructures.ListCollection<string> array = new DataStructures.ListCollection<string>();
            array.Add("ana");
            array.Add("paul");
            array.Add("zero");
            array.Add("penelope");
            Func<string, bool> isUpperCase = x => x[0] >= 65 && x[0] <= 90;
            List<string> list = new List<string>();
            Assert.Equal(DataStructures.LinqFunctions.Where<string>(array, isUpperCase), list);
        }

        [Fact]
        public void CheckIfWhereArgumentsWorksCorrectly1()
        {
            DataStructures.ListCollection<string> array = null;
            Func<string, bool> isUpperCase = x => x[0] >= 65 && x[0] <= 90;
            List<string> list = new List<string>();
            list.Add("Paul");
            Func<string, bool> isFirstUpperCase = x => (x[0] >= 65 && x[0] <= 90);
            Assert.Throws<ArgumentNullException>(() => DataStructures.LinqFunctions.All<string>(DataStructures.LinqFunctions.Where<string>(array, isUpperCase), isFirstUpperCase));
        }

        class Package
        {
            public string Company { get; set; }

            public long TrackingNumber { get; set; }
        }

        [Fact]
        public void CheckIfToDictionaryWorksCorrectly1()
        {
            List<Package> packages = new List<Package>
            {
                new Package { Company = "Coho Vineyard", TrackingNumber = 89453312L },
                new Package { Company = "Lucerne Publishing", TrackingNumber = 89112755L },
                new Package { Company = "Wingtip Toys", TrackingNumber = 299456122L },
                new Package { Company = "Adventure Works", TrackingNumber = 4665518773L }
            };
            Func<Package, long> key = x => x.TrackingNumber;
            Func<Package, string> name = x => x.Company;
            Assert.True(DataStructures.LinqFunctions.ToDictionary<Package, long, string>(packages, key, name)[89453312L] == "Coho Vineyard");
        }

        [Fact]
        public void CheckIfToDictionaryArgumentsWorksCorrectly1()
        {
            List<Package> packages = null;
            Func<Package, long> key = x => x.TrackingNumber;
            Func<Package, string> name = x => x.Company;
            Assert.Throws<ArgumentNullException>(() => DataStructures.LinqFunctions.ToDictionary<Package, long, string>(packages, key, name)[89453312L] == "Coho Vineyard");
        }

        [Fact]
        public void CheckIfZipWorksCorrectly()
        {
            int[] first = { 1, 2, 3, 4 };
            int[] second = { 1, 2, 3, 4 };
            Func<int, int, int> combine = (x, y) => x + y;
            List<int> zip = new List<int>() { 2, 4, 6, 8 };
            Assert.Equal(DataStructures.LinqFunctions.Zip<int, int, int>(first, second, combine), zip);
        }

        [Fact]
        public void CheckIfZipArgumentsWorksCorrectly()
        {
            int[] first = null;
            int[] second = { 1, 2, 3, 4 };
            Func<int, int, int> combine = (x, y) => x + y;
            Func<int, bool> isEvenNumber = x => x % 2 == 0;
            Assert.Throws<ArgumentNullException>(() => DataStructures.LinqFunctions.All<int>(DataStructures.LinqFunctions.Zip<int, int, int>(first, second, combine), isEvenNumber));
        }

        [Fact]
        public void CheckIfAggregateWorksCorrectly()
        {
            int[] source = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Func<int, int, int> howManyEvenNumbers = (seed, obj) =>
            {
                if (obj % 2 == 0)
                {
                    seed++;
                }

                return seed;
            };

            Assert.Equal(5, DataStructures.LinqFunctions.Aggregate<int, int>(source, 0, howManyEvenNumbers));
        }

        [Fact]
        public void CheckIfAggregateArgumentWorksCorrectly()
        {
            int[] source = null;
            Func<int, int, int> howManyEvenNumbers = (seed, obj) =>
            {
                if (obj % 2 == 0)
                {
                    seed++;
                }

                return seed;
            };

            Assert.Throws<ArgumentNullException>(() => DataStructures.LinqFunctions.Aggregate<int, int>(source, 0, howManyEvenNumbers));
        }
    }
}
