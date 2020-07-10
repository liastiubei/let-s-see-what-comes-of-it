using LinqHomework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LinqHomeworkTests
{
    public class TestResultsHomeworkTests
    {
        [Fact]
        public void CheckIfHighestScorePerFamilyWorksCorrectly()
        {
            List<TestResults> ListOfTestResults = new List<TestResults>();

            TestResults result1 = new TestResults("alex", "popescu", 28);
            TestResults result2 = new TestResults("ion", "ionescu", 60);
            TestResults result3 = new TestResults("zaniba", "georgescu", 55);
            TestResults result4 = new TestResults("pica", "gabrilescu", 1);
            TestResults result5 = new TestResults("zahar", "popescu", 112);
            TestResults result6 = new TestResults("alexandra", "ionescu", 98);
            TestResults result7 = new TestResults("ionela", "georgescu", 87);
            TestResults result8 = new TestResults("andreea", "gabrilescu", 2);
            TestResults result9 = new TestResults("zorzoana", "popescu", 74);
            TestResults result10 = new TestResults("marius", "ionescu", 47);
            TestResults result11 = new TestResults("mihai", "georgescu", 12);
            TestResults result12 = new TestResults("mihaela", "gabrilescu", 3);
            TestResults result13 = new TestResults("mona", "popescu", 15);
            TestResults result14 = new TestResults("alexa", "ionescu", 99);

            ListOfTestResults.Add(result1);
            ListOfTestResults.Add(result2);
            ListOfTestResults.Add(result3);
            ListOfTestResults.Add(result4); 
            ListOfTestResults.Add(result5);
            ListOfTestResults.Add(result6);
            ListOfTestResults.Add(result7);
            ListOfTestResults.Add(result8);
            ListOfTestResults.Add(result9);
            ListOfTestResults.Add(result10);
            ListOfTestResults.Add(result11);
            ListOfTestResults.Add(result12);
            ListOfTestResults.Add(result13);
            ListOfTestResults.Add(result14);

            TestResultsHomework allResults = new TestResultsHomework(ListOfTestResults);

            List<TestResults> final = new List<TestResults>();

            TestResults finalResult1 = new TestResults("zahar", "popescu", 112);
            TestResults finalResult2 = new TestResults("alexa", "ionescu", 99);
            TestResults finalResult3 = new TestResults("ionela", "georgescu", 87);
            TestResults finalResult4 = new TestResults("mihaela", "gabrilescu", 3);

            final.Add(finalResult1);
            final.Add(finalResult2);
            final.Add(finalResult3);
            final.Add(finalResult4);

            var comparer = new TestResultsComparer();
            Assert.Equal(final, allResults.HighestScorePerFamily(), comparer);
        }
    }
}
