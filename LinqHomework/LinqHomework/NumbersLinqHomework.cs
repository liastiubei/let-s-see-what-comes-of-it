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

        public static int[][] AllCombinationsWithNAndSumOfK(int n, int k)
        {
            int[][] allCombinations = new int[Convert.ToInt32(Math.Pow(2, n))][];
            allCombinations[0] = Enumerable.Range(1, n).ToArray();
            allCombinations = AllCombinations(allCombinations, n, 1);
            return allCombinations.Where(x => x.Sum() <= k).ToArray();
        }

        private static int[][] AllCombinations(int[][] source, int number, int start)
        {
            if (start == source.Length)
            {
                return source;
            }

            int j = start;
            Func<int, int> ChangeIndex = x =>
            {
                return x == number ? -x : x;
            };

            for (int i = 0; i < start; i++)
            {
                source[j++] = source[i].Select(ChangeIndex).ToArray();
            }

            return AllCombinations(source, number - 1, j);
        }
    }
}
