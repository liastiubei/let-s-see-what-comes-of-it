using System;
using Xunit;

namespace BBS_tests
{
    public class UnitTest2
    {
        [Fact]
        public void CheckIfReadCorrectly_ShouldReturnTrue()
        {
            Team[] teams1 ={new Team("",0),
                            new Team("",0),
                            new Team("",0)};
            Ranking rankings = new Ranking(teams1);
            string[] lines = { "Echipa1 - 3 - 4",
                            "Echipa2 - 13 - 5",
                            "Echipa3 - 23 - 6"};
            Team[] teams ={new Team("Echipa1 ", 7),
                           new Team("Echipa2 ", 18),
                           new Team("Echipa3 ", 29)};
            Ranking correctRankings = new Ranking(teams);
            rankings.Read(lines);
            Assert.True(rankings.Equal(correctRankings));
        }
    }
}
