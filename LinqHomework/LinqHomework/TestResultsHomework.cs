using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqHomework
{
    public class TestResultsHomework
    {
        List<TestResults> allTestResults;

        public TestResultsHomework(List<TestResults> list)
        {
            this.allTestResults = list;
        }

        public List<TestResults> HighestScorePerFamily()
        {
            var list = allTestResults.GroupBy(x => x.FamilyId).Select(x => Max(x)).ToList();
            return list;
        }

        public TestResults Max(IGrouping<string, TestResults> group)
        {
            int max = 0;
            TestResults person = null;
            foreach(var obj in group)
            {
                if(obj.Score > max)
                {
                    person = obj;
                    max = obj.Score;
                }
            }

            return person;
        }
    }

    public class TestResults
    {
        public string Id { get; set; }
        public string FamilyId { get; set; }
        public int Score { get; set; }

        public TestResults(string id, string familyId, int score)
        {
            this.Id = id;
            this.FamilyId = familyId;
            this.Score = score;
        }
    }

    public class TestResultsComparer : IEqualityComparer<TestResults>
{
        public bool Equals(TestResults x, TestResults y)
        {
            return x.FamilyId == y.FamilyId && x.Id == y.Id && x.Score == y.Score;
        }

        public int GetHashCode(TestResults obj)
        {
            return 15 * obj.FamilyId.GetHashCode() + obj.Id.GetHashCode() + obj.Score;
        }
    }
}
