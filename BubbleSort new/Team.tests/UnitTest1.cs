using System;
using Xunit;

namespace Team.tests
{
    public class UnitTest1
    {
        [Fact]
        public void ChecksIfTeamsAreReadCorrectly_ShouldReturnTrue()
        {
            Program.Teams newTeam = new Program.Teams("", 0);
            newTeam.Read("Echipa1 - 23 - 4");
            Program.Teams correctTeam = new Program.Teams("Echipa1 ", 27);
            Assert.True(newTeam.Equal(correctTeam));
        }

        [Fact]
        public void ChecksIfSmaller_ShouldReturnTrue()
        {
            Program.Teams smallerTeam = new Program.Teams("team1", 45);
            Program.Teams biggerTeam = new Program.Teams("team2", 65);
            Assert.True(smallerTeam.IsSmallerThan(biggerTeam));
        }

    }
}
