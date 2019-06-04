using System;
using Xunit;

namespace BBS_tests
{
    public class UnitTest3
    {
        [Fact]
        public void ChecksIfNamesMatch1_ShouldReturnTrue()
        {
            int i = 0;
            Game game = new Game("a", "b", 1, 2);
            Assert.True(game.CheckIfNamesMatch1("a", ref i));
        }

    }
}