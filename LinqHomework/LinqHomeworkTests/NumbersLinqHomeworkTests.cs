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
            int[][] array = { new int[] { 1, 2, -3 }, new int[] { 1, -2, -3 }, new int[] { -1, 2, -3 }, new int[] { -1, -2, 3 }, new int[] { -1, -2, -3 } };
            Assert.Equal(array, LinqHomework.NumbersLinqHomework.AllCombinationsWithNAndSumOfK(3, 0));
        }
    }
}
