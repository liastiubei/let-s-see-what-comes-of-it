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
            List<List<int>> array = new List<List<int>>();
            List<int> x = new List<int>();
            List<int> y = new List<int>();
            List<int> z = new List<int>();
            List<int> p = new List<int>();
            List<int> w = new List<int>();
            x.Add(1);
            x.Add(2);
            x.Add(-3);
            array.Add(x);
            y.Add(1);
            y.Add(-2);
            y.Add(-3);
            array.Add(y);
            z.Add(-1);
            z.Add(2);
            z.Add(-3);
            array.Add(z);
            p.Add(-1);
            p.Add(-2);
            p.Add(3);
            array.Add(p);
            w.Add(-1);
            w.Add(-2);
            w.Add(-3);
            array.Add(w);
            Assert.Equal(array, LinqHomework.NumbersLinqHomework.AllCombinationsWithNAndSumOfK(3, 0));
        }
    }
}
