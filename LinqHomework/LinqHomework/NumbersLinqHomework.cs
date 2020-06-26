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
            return Enumerable.Range(1, n).Aggregate<int, List<string>>(combinations, (list, x) => list.SelectMany(y => new[] { y + "+", y + "-" }).ToList()).Where(x => x.Length == n && x.Select((character, index) => character == '+' ? index + 1 : -index - 1).ToList().Sum() <= k).ToList();
        }
    }
}
