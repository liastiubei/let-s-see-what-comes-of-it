using System;
using Xunit;

namespace BBS_tests
{
    public class UnitTest1
    {
        [Fact]
        public void ChecksIfTeamsAreReadCorrectly_ShouldReturnTrue()
        {
            Team newTeam = new Team("", 0);
            newTeam.Read("Echipa1 - 23 - 4");
            Team correctTeam = new Team("Echipa1 ", 27);
            Assert.True(newTeam.Equal(correctTeam));
        }
    }
}
