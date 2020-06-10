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

        class Person
        {
            public string Name { get; set; }
        }

        class Pet
        {
            public string Name { get; set; }

            public Person Owner { get; set; }
        }

        [Fact]
        public void CheckIfJoinWorksCorrectly()
        {
            Person magnus = new Person { Name = "Magnus" };
            Person terry = new Person { Name = "Terry" };
            Person charlotte = new Person { Name = "Charlotte" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            List<Person> people = new List<Person> { magnus, terry, charlotte };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, daisy };

            Func<Person, Person> outerKey = x => x;
            Func<Pet, Person> innerKey = x => x.Owner;
            Func<Person, Pet, object> resultSelector = (pers, pet) => (pers.Name, pet.Name);

            List<object> join = new List<object>() { ("Magnus", "Daisy"), ("Terry", "Barley"), ("Terry", "Boots"), ("Charlotte", "Whiskers") };

            Assert.Equal(DataStructures.LinqFunctions.Join<Person, Pet, Person, object>(people, pets, outerKey, innerKey, resultSelector), join);
        }

        [Fact]
        public void CheckIfJoinArgumentsWorksCorrectly()
        {
            Person magnus = new Person { Name = "Magnus" };
            Person terry = new Person { Name = "Terry" };
            Person charlotte = new Person { Name = "Charlotte" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            List<Person> people = null;
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, daisy };

            Func<Person, Person> outerKey = x => x;
            Func<Pet, Person> innerKey = x => x.Owner;
            Func<Person, Pet, object> resultSelector = (pers, pet) => (pers.Name, pet.Name);

            Func<object, bool> isString = x => Equals(x, x.ToString());

            Assert.Throws<ArgumentNullException>(() =>
            DataStructures.LinqFunctions.All<object>(DataStructures.LinqFunctions.Join<Person, Pet, Person, object>(people, pets, outerKey, innerKey, resultSelector), isString));
        }

        class IntEqualityComparer : IEqualityComparer<int>
        {
            public bool Equals(int num1, int num2)
            {
                return num1 == num2;
            }

            public int GetHashCode(int number)
            {
                return number.GetHashCode();
            }
        }

        [Fact]
        public void CheckIfDistinctWorksCorrectly()
        {
            int[] source = { 11, 12, 53, 12, 15, 15, 36, 87, 78, 90, 11 };
            int[] result = { 11, 12, 53, 15, 36, 87, 78, 90 };
            IntEqualityComparer equal = new IntEqualityComparer();
            Assert.Equal(result, DataStructures.LinqFunctions.Distinct<int>(source, equal));
        }

        [Fact]
        public void CheckIfDistinctArgumentWorksCorrectly()
        {
            int[] source = null;
            int[] result = { 53, 12, 15, 36, 87, 78, 90, 11 };
            IntEqualityComparer equal = new IntEqualityComparer();

            Func<int, bool> isString = x => Equals(x, x.ToString());

            Assert.Throws<ArgumentNullException>(() =>
             DataStructures.LinqFunctions.All<int>(DataStructures.LinqFunctions.Distinct<int>(source, equal), isString));
        }

        [Fact]
        public void CheckIfUnionWorksCorrectly()
        {
            int[] first = { 2, 4, 6, 8, 10, 12 };
            int[] second = { 3, 6, 9, 12, 15 };
            int[] final = { 2, 4, 6, 8, 10, 12, 3, 9, 15 };
            IntEqualityComparer equal = new IntEqualityComparer();
            Assert.Equal(final, DataStructures.LinqFunctions.Union<int>(first, second, equal));
        }

        [Fact]
        public void CheckIfUnionArgumentWorksCorrectly()
        {
            int[] first = null;
            int[] second = { 3, 6, 9, 12, 15 };
            int[] final = { 2, 4, 8, 10, 3, 6, 9, 12, 15 };
            IntEqualityComparer equal = new IntEqualityComparer();
            Assert.Throws<ArgumentNullException>(() => final.Equals(DataStructures.LinqFunctions.Union<int>(first, second, equal)));
        }

        [Fact]
        public void CheckIfIntersectWorksCorrectly()
        {
            int[] first = { 2, 4, 6, 8, 10, 12 };
            int[] second = { 3, 6, 9, 12, 12, 15 };
            int[] final = { 6, 12 };
            IntEqualityComparer equal = new IntEqualityComparer();
            Assert.Equal(final, DataStructures.LinqFunctions.Intersect<int>(first, second, equal));
        }

        [Fact]
        public void CheckIfIntersectArgumentWorksCorrectly()
        {
            int[] first = null;
            int[] second = { 3, 6, 9, 12, 12, 15 };
            int[] final = { 6, 12 };
            IntEqualityComparer equal = new IntEqualityComparer();
            Assert.Throws<ArgumentNullException>(() => final.Equals(DataStructures.LinqFunctions.Union<int>(first, second, equal)));
        }

        [Fact]
        public void CheckIfExceptWorksCorrectly()
        {
            int[] first = { 2, 4, 6, 8, 10, 12 };
            int[] second = { 3, 6, 9, 12, 12, 15 };
            int[] final = { 2, 4, 8, 10 };
            IntEqualityComparer equal = new IntEqualityComparer();
            Assert.Equal(final, DataStructures.LinqFunctions.Except<int>(first, second, equal));
        }

        [Fact]
        public void CheckIfExceptArgumentWorksCorrectly()
        {
            int[] first = null;
            int[] second = { 3, 6, 9, 12, 12, 15 };
            int[] final = { 2, 4, 8, 10 };
            IntEqualityComparer equal = new IntEqualityComparer();
            Assert.Throws<ArgumentNullException>(() => final.Equals(DataStructures.LinqFunctions.Except<int>(first, second, equal)));
        }

        class PersonEqualityComparer : IEqualityComparer<Person>
        {
            public bool Equals(Person name1, Person name2)
            {
                return name1 == name2;
            }

            public int GetHashCode(Person name)
            {
                return name.GetHashCode();
            }
        }

        [Fact]
        public void CheckIfGroupByWorksCorrectly()
        {
            Person magnus = new Person { Name = "Magnus" };
            Person terry = new Person { Name = "Terry" };
            Person charlotte = new Person { Name = "Charlotte" };
            List<Pet> pets = new List<Pet>
            {
                new Pet { Name = "Barley", Owner = magnus },
                new Pet { Name = "Maddison", Owner = terry },
                new Pet { Name = "Pudding", Owner = charlotte },
                new Pet { Name = "Apple", Owner = magnus },
                new Pet { Name = "Ketchup", Owner = terry },
                new Pet { Name = "Rufus", Owner = charlotte },
                new Pet { Name = "Donut", Owner = magnus },
                new Pet { Name = "Roger", Owner = terry },
                new Pet { Name = "Kitten", Owner = charlotte }
            };
            Func<Pet, Person> ownerSelector = x => x.Owner;
            Func<Pet, string> nameSelector = x => x.Name;
            Func<Person, IEnumerable<string>, DataStructures.Grouping<Person, string>> resultSelector = (x, y) => new DataStructures.Grouping<Person, string>(x, y);
            DataStructures.ListCollection<DataStructures.Grouping<Person, string>> finalGroups = new DataStructures.ListCollection<DataStructures.Grouping<Person, string>>
            {
                new DataStructures.Grouping<Person, string>(magnus, new DataStructures.ListCollection<string> { "Barley", "Apple", "Donut" }),
                new DataStructures.Grouping<Person, string>(terry, new DataStructures.ListCollection<string> { "Maddison", "Ketchup", "Roger" }),
                new DataStructures.Grouping<Person, string>(charlotte, new DataStructures.ListCollection<string> { "Pudding", "Rufus", "Kitten" })
            };

            PersonEqualityComparer comparer = new PersonEqualityComparer();
            Assert.Equal(
                finalGroups,
                DataStructures.LinqFunctions.GroupBy<Pet, Person, string, DataStructures.Grouping<Person, string>>(pets, ownerSelector, nameSelector, resultSelector, comparer));
        }

        class CharComparer : IComparer<char>
        {
            public int Compare(char x, char y)
            {
                if (x < y)
                {
                    return -1;
                }

                if (x > y)
                {
                    return 1;
                }

                return 0;
            }
        }

        [Fact]
        public void CheckIfOrderByWorksCorrectly()
        {
            List<string> names = new List<string>
            {
                "Ana", "Vlad", "Dorina", "Croc", "Hook", "Andrei"
            };
            Func<string, char> firstLetterSelector = x => x[0];
            DataStructures.OrderedEnumerable<string> orderedNames = new DataStructures.OrderedEnumerable<string>();
            orderedNames.Add("Ana");
            orderedNames.Add("Andrei");
            orderedNames.Add("Croc");
            orderedNames.Add("Dorina");
            orderedNames.Add("Hook");
            orderedNames.Add("Vlad");
            CharComparer comparer = new CharComparer();
            var finalOrdered = DataStructures.LinqFunctions.OrderBy<string, char>(names, firstLetterSelector, comparer);
            Assert.True(orderedNames.EqualityBetweenThisAPureIOrderedEnumerable(finalOrdered));
        }
    }
}
