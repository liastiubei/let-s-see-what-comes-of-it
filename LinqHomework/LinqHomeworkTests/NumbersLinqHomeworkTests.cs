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
    }
}
