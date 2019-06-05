using System;
using System.Collections.Generic;
using System.Text;

namespace BBS_tests
{
    class Team
    {
        private string name;
        private int score;

        public Team(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
        
        public bool Equal(Team that)
        {
            return this.name == that.name && this.score == that.score;
        }

        internal bool IsSmallerThan(Team that)
        {
            return this.score < that.score;
        }

        internal void Update(Game game)
        {
            this.score += game.GiveScore(this.name) ;
        }
        
    }
}
