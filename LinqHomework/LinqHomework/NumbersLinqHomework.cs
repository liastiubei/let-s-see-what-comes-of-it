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

        public static List<List<int>> AllCombinationsWithNAndSumOfK(int n, int k)
        {
            List<List<int>> combinations = new List<List<int>>();
            combinations.Add(Enumerable.Range(1, n).ToList());
            int index = n;
            Func<List<int>, List<int>> ChangeIndex = x =>
            {
                return x.Select(y => y == index ? -y : y).ToList();
            };

            for (int i = 1; i <= n; i++)
            {
                foreach (var obj in combinations.Select(ChangeIndex).ToList())
                {
                    combinations.Add(obj);
                }

                index--;
            }

            return combinations.Where(x => x.Sum() <= k).ToList();
        }
    }
}
