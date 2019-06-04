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

        public void Read(string line)
        {
            string[] teamData = line.Split('-');
            this.score = Convert.ToInt32(teamData[1]) + Convert.ToInt32(teamData[2]);
            this.name = teamData[0];
        }

        public bool Equal(Team that)
        {
            return this.name == that.name && this.score == that.score;
        }

        internal bool IsSmallerThan(Team that)
        {
            return this.score < that.score;
        }

        internal void Swap(Team that)
        {
            string swapName = this.name;
            this.name = that.name;
            that.name = swapName;

            int swapNum = this.score;
            this.score = that.score;
            that.score = swapNum;
        }

        internal bool Search1stTeam(Game game, ref int score1)
        {
            return game.CheckIfNamesMatch1(this.name, ref score1);
        }

        internal bool Search2ndTeam(Game game, ref int score2)
        {
            return game.CheckIfNamesMatch2(this.name, ref score2);
        }

        internal void AddToScore(int score)
        {
            this.score += score;
        }
    }
}
