using System;
using Xunit;

namespace Soccer.tests
{
    public class UnitTest1
    {
        [Fact]
        public void CheckWhichOneIsSmaller_ShouldReturnTrue()
        {
            var test1 = new Program.SoccerTeam("CFR Cluj ", 36);
            var test2 = new Program.SoccerTeam("FCSB ", 31);
            bool check = test2.CompareIfSmaller(test1);
            Assert.True(check);
        }

        [Fact]
        public void CheckIfPrintWorks_ShouldReturnTrue()
        {
            var test1 = new Program.SoccerTeam("CFR Cluj ", 36);
            Assert.Equal("CFR Cluj - 36",test1.Print());
        }

        [Fact]
        public void CheckIfSwappingMessageWorks_ShouldReturnTrue()
        {
            var test1 = new Program.SoccerTeam("CFR Cluj ", 36);
            var test2 = new Program.SoccerTeam("FCSB ", 31);
            Assert.Equal("Swapping elements with indexes (0, 1) and values (CFR Cluj , FCSB )", test1.StringSwappingMessage(0, 1, test2));
        }
        

    }
}
