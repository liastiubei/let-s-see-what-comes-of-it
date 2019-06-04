using System;
using System.Collections.Generic;
using System.Text;

namespace BBS_tests
{
    class Ranking
    {
        private Team[] teams;

        public Ranking(Team[] teams)
        {
            this.teams = teams;
        }

        public bool Equal(Ranking that)
        {
            for (int i = 0; i < that.teams.Length; i++)
            {
                if (!this.teams[i].Equal(that.teams[i])) return false;
            }
            return true;
        }

        private void Swap(int index1, int index2)
        {
            Team team = this.teams[index1];
            this.teams[index1] = this.teams[index2];
            this.teams[index2] = team;
        }

        private void Sorting()
        {
            bool check = false;
            while (!check)
            {
                check = true;
                for (int i = 0; i < this.teams.Length - 1; i++)
                {
                    if (this.teams[i].IsSmallerThan(this.teams[i + 1]))
                    {
                        this.Swap(i, i+1);
                        check = false;
                    }
                }
            }
        }

        internal void Update(Game game)
        {
            for(int i=0;i<this.teams.Length;i++)
            {
                this.teams[i].AddToScore(this.teams[i].GetPoints(game));
            }
            this.Sorting();
        }
        
    }
}
