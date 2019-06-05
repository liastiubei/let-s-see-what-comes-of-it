using System;
using System.Collections.Generic;
using System.Text;

namespace BBS_tests
{
    class Game
    {
        private string team1;
        private string team2;
        private int score1;
        private int score2;

        public Game(string team1, string team2, int score1, int score2)
        {
            this.team1 = team1;
            this.team2 = team2;
            this.score1 = score1;
            this.score2 = score2;
        }

        internal int GiveScore(string name)
        {
            if (this.team1 == name&&score1>score2) return 3;
            if (this.team1 == name&&score1==score2) return 1;
            
            if (this.team2 == name && score2 > score1) return 3;
            if (this.team2 == name && score2 == score1) return 1;
            
            return 0;
        }
        
    }
}
