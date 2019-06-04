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

        internal bool CheckIfNamesMatch1(string name, ref int score1)
        {
            if(this.team1==name)
            {
                score1 = this.score1;
                return true;
            }
            return false;
        }

        internal bool CheckIfNamesMatch2(string name, ref int score2)
        {
            if (this.team2 == name)
            {
                score2 = this.score2;
                return true;
            }
            return false;
        }
    }
}
