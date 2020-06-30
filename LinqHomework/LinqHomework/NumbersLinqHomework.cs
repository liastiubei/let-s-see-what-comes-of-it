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
            IEnumerable<string> seed = new[] { "" };
            return Enumerable.Range(1, n)
                    .Aggregate<int, IEnumerable<string>>(seed, (list, x) => list.SelectMany(y => new[] { y + "+", y + "-" }))
                    .Where(x => x.Length == n && x.Select((character, index) => character == '+' ? index + 1 : -index - 1).Sum() <= k).ToList();
        }

        public static List<int[]> AllTripletsThatFulfilla2b2c2Equality(int[] n)
        {
            var combinations = from i in n
                               from j in n
                               from p in n
                               select new[] { i, j, p };
            return combinations.Where(x => x.Length == x.Distinct().Count() && Math.Pow(x[0], 2) + Math.Pow(x[1], 2) == Math.Pow(x[2], 2)).ToList();
        }
    }
}
