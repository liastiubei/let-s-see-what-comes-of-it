using System;
using Xunit;

namespace BBS_tests
{
    public class UnitTest2
    {
        [Fact]
        public void CheckIfUpdateWorks_ShouldReturnTrue()
        {
            Team[] teams ={new Team("Echipa1 ", 100),
                                    new Team("Echipa2 ", 96),
                                    new Team("Echipa3 ", 90),
                                    new Team("Echipa4 ", 89)};
            Ranking rankings = new Ranking(teams);
            rankings.Update(new Game("Echipa1 ","Echipa3 ",4,20));
            Team[] newTeams={new Team("Echipa3 ", 110),
                   new Team("Echipa1 ", 104),
                   new Team("Echipa2 ", 96),
                   new Team("Echipa4 ", 89)};
            Ranking newRankings = new Ranking(newTeams);
            Assert.True(newRankings.Equal(rankings));
        }
        
    }
}
