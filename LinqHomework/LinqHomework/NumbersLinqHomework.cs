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

        public class TripletComparer : IEqualityComparer<int[]>
        {
            public bool Equals(int[] x, int[] y)
            {
                return x[0] == y[0] && x[1] == y[1] && x[2] == y[2];
            }

            public int GetHashCode(int[] obj)
            {
                var tuple = Tuple.Create(obj[0], obj[1], obj[2]);
                return tuple.GetHashCode();
            }
        }

        public static List<int[]> AllTripletsThatFulfilla2b2c2Equality(int[] n)
        {
            var combinations = from i in n
                               from j in n
                               from p in n
                               select new [] { i, j, p };

            TripletComparer comparer = new TripletComparer();
            Func<int[], int[][]> ramificationForCombinations = x => new[] { new[] { x[0], x[1], x[2] }, new[] { x[0], x[2], x[1] }, new[] { x[2], x[1], x[0] } };

            return combinations.SelectMany(ramificationForCombinations).Distinct(comparer).Where(x => Math.Pow(x[0], 2) + Math.Pow(x[1], 2) == Math.Pow(x[2], 2)).ToList();
        }

        public static bool ValidateSudoku(int[][] sudoku)
        {
            if(sudoku.Length != 9 || sudoku.Any(x => x.Count() != 9))
            {
                return false;
            }

            int[] validate = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            if(validate.Any(x => sudoku.Any(y => !y.Contains(x))))
            {
                return false;
            }

            for(int i = 0; i < 9; i++)
            {
                var obj = sudoku.Select(x => x[i]);
                if(validate.Any(x => !obj.Contains(x)))
                {
                    return false;
                }
            }

            for(int i = 0; i < 9; i = i + 3)
            {
                var first = Enumerable.Range(i, 3).SelectMany(x => sudoku[x].Take(3));
                var second = Enumerable.Range(i, 3).SelectMany(x => sudoku[x].Skip(3).Take(3));
                var third = Enumerable.Range(i, 3).SelectMany(x => sudoku[x].Skip(6));
                if (validate.Any(y => !first.Contains(y) || !second.Contains(y) || !third.Contains(y)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
