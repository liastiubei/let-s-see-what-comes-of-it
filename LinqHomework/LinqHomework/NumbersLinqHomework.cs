﻿using System;
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

            List<int[]> listOfLinesColumnsAndSquares = sudoku.ToList();

            var columns = listOfLinesColumnsAndSquares.SelectMany(x => x.Select((a, num) => (num, a).ToTuple()))
                                    .GroupBy(x => x.Item1)
                                    .Select(x => x.AsEnumerable().Select(y => y.Item2).ToArray())
                                    .ToArray();
            listOfLinesColumnsAndSquares.AddRange(columns);

            var squares = Enumerable.Range(1, 3)
                            .SelectMany(i => Enumerable.Range(1, 3)
                                    .Select(z => sudoku.Take(i * 3).Skip((i - 1) * 3)
                                                    .SelectMany(y => y.Take(z * 3).Skip((z - 1) * 3))
                                                    .ToArray()))
                            .ToArray();
            listOfLinesColumnsAndSquares.AddRange(squares);

            int[] validate = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            return !validate.Any(x => listOfLinesColumnsAndSquares.Any(y => !y.Contains(x)));
        }

        public static double ResultOfPostfixExpression(string postfixExpression)
        {
            List<string> numbersAndSigns = postfixExpression.Split(' ').ToList();
            Func<IEnumerable<double>, string, IEnumerable<double>> calculator = (expression, next) =>
            {
                var x = double.TryParse(next, out double num) ? expression.Append(num)
                    : expression.SkipLast(2).Append(SmallArithmeticOperationBetweenTwo(expression.TakeLast(2), next));
                return x;
            };
            var result = numbersAndSigns.Aggregate(Enumerable.Empty<double>(), (expression, next) => calculator(expression, next));
            return result.First();

        }

        public static double SmallArithmeticOperationBetweenTwo(IEnumerable<double> theTwoNumbers, string sign)
        {
            if (sign == "+")
            {
                return theTwoNumbers.First() + theTwoNumbers.Last();
            }

            if (sign == "-")
            {
                return theTwoNumbers.First() - theTwoNumbers.Last();
            }

            if (sign == "*")
            {
                return theTwoNumbers.First() * theTwoNumbers.Last();
            }

            if (sign == "/")
            {
                return theTwoNumbers.First() / theTwoNumbers.Last();
            }

            return 0;
        }
    }
}
