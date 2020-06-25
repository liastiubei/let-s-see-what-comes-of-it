using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqHomework
{
    public static class NumbersLinqHomework
    {
        public static IEnumerable<IEnumerable<int>> AllSubsequencesWithSumEqualOrSmallerThanK(this IEnumerable<int> array, int k)
        {
            return from i in Enumerable.Range(0, array.Count())
                   from j in Enumerable.Range(i, array.Count() - i)
                   let elements = array.Skip(i).Take(j - i + 1)
                   let sum = elements.Sum()
                   where sum <= k
                   select elements;
        }

        public static List<string> AllCombinationsWithNAndSumOfK(int n, int k)
        {
            List<string> combinations = new List<string>();
            combinations.Add("");
            Func<string, List<string>> newList = y =>
            {
                var list = new List<string>();
                list.Add(y + "+");
                list.Add(y + "-");
                return list;
            };

            Func<int, List<string>> AddingToTheLists = x =>
            {
                combinations = combinations.SelectMany(newList).ToList();
                return combinations;
            };

            int i = 1;
            Func<char, string, int> CharToInt = (x, g) =>
            {
                var y = x == '-' ? - i : i;
                _ = i == 3 ? i = 1 : i++;
                return y;
            };

            return Enumerable.Range(1, n).SelectMany(AddingToTheLists).Where(x => x.Length == n && x.Sum(y => CharToInt(y, x)) <= k).ToList();
        }
    }
}
