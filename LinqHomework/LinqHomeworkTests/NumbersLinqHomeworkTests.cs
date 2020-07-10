using System;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LinqHomeworkTests
{
    public class NumbersLinqHomeworkTests
    {
        [Fact]
        public void CheckIfAllSubsequencesWithSumEqualOrSmallerThanKWorksCorrectly()
        {
            int[] array = { 1, 5, 3, 8};
            var result = new List<IEnumerable<int>>();
            result.Add(new int[] { 1 });
            result.Add(new int[] { 1, 5 });
            result.Add(new int[] { 5 });
            result.Add(new int[] { 3 });
            var x = LinqHomework.NumbersLinqHomework.AllSubsequencesWithSumEqualOrSmallerThanK(array, 7);
            Assert.Equal(result, x);
        }

        [Fact]
        public void CheckIfAllCombinationsWithNAndSumOfKWorksCorrectly()
        {
            string[] array = { "++-", "+--", "-+-", "--+", "---" };
            var combo = LinqHomework.NumbersLinqHomework.AllCombinationsWithNAndSumOfK(3, 0);
            Assert.Equal(array, combo);
        }

        [Fact]
        public void CheckIfAllTripletsThatFulfilla2b2c2EqualityWorksCorrectly()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            var combo = LinqHomework.NumbersLinqHomework.AllTripletsThatFulfilla2b2c2Equality(array);
            List<int[]> final = new List<int[]>();
            final.Add(new int[] { 3, 4, 5 });
            final.Add(new int[] { 4, 3, 5 });
            Assert.Equal(final, combo);
        }

        [Fact]
        public void CheckIfValidateSudokuWorksCorrectlyIfValid()
        {
            int[] s1 = { 5, 3, 4, 6, 7, 8, 9, 1, 2};
            int[] s2 = { 6, 7, 2, 1, 9, 5, 3, 4, 8 };
            int[] s3 = { 1, 9, 8, 3, 4, 2, 5, 6, 7 };
            int[] s4 = { 8, 5, 9, 7, 6, 1, 4, 2, 3 };
            int[] s5 = { 4, 2, 6, 8, 5, 3, 7, 9, 1 };
            int[] s6 = { 7, 1, 3, 9, 2, 4, 8, 5, 6 };
            int[] s7 = { 9, 6, 1, 5, 3, 7, 2, 8, 4 };
            int[] s8 = { 2, 8, 7, 4, 1, 9, 6, 3, 5 };
            int[] s9 = { 3, 4, 5, 2, 8, 6, 1, 7, 9 };

            int[][] sudoku = { s1, s2, s3, s4, s5, s6, s7, s8, s9 };
            Assert.True(LinqHomework.NumbersLinqHomework.ValidateSudoku(sudoku));
        }

        [Fact]
        public void CheckIfValidateSudokuWorksCorrectlyIfNotValid()
        {
            int[] s1 = { 5, 3, 4, 6, 7, 9, 8, 1, 2 };
            int[] s2 = { 6, 7, 2, 1, 9, 3, 5, 4, 8 };
            int[] s3 = { 1, 9, 8, 3, 4, 5, 2, 6, 7 };
            int[] s4 = { 8, 5, 9, 7, 6, 4, 1, 2, 3 };
            int[] s5 = { 4, 2, 6, 8, 5, 7, 3, 9, 1 };
            int[] s6 = { 7, 1, 3, 9, 2, 8, 4, 5, 6 };
            int[] s7 = { 9, 6, 1, 5, 3, 2, 7, 8, 4 };
            int[] s8 = { 2, 8, 7, 4, 1, 6, 9, 3, 5 };
            int[] s9 = { 3, 4, 5, 2, 8, 1, 6, 7, 9 };

            int[][] sudoku = { s1, s2, s3, s4, s5, s6, s7, s8, s9 };
            Assert.False(LinqHomework.NumbersLinqHomework.ValidateSudoku(sudoku));
        }
    }
}
