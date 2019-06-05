using System;
using Xunit;

namespace BBS_tests
{
    public class UnitTest2
    {
        [Fact]
        public void CheckIfUpdateWorks_ShouldReturnTrue()
        {
            Team[] teams ={new Team("Echipa1 ", 1),
                                    new Team("Echipa2 ", 2),
                                    new Team("Echipa3 ", 3),
                                    new Team("Echipa4 ", 4)};
            Ranking rankings = new Ranking(teams);
            rankings.Update(new Game("Echipa1 ","Echipa3 ",4,20));
            Team[] newTeams={new Team("Echipa3 ", 6),
                   new Team("Echipa4 ", 4),
                   new Team("Echipa2 ", 2),
                   new Team("Echipa1 ", 1)};
            Ranking newRankings = new Ranking(newTeams);
            Assert.True(newRankings.Equal(rankings));
        }
        
    }
}
