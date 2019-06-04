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

        public void Read(string[] lines)
        {
            for (int i = 0; i < this.teams.Length; i++)
            {
                this.teams[i].Read(lines[i]);
            }
        }

        public bool Equal(Ranking that)
        {
            for (int i = 0; i < that.teams.Length; i++)
            {
                if (!this.teams[i].Equal(that.teams[i])) return false;
            }
            return true;
        }

        public void Sorting()
        {
            for (int i = 0; i < this.teams.Length-1; i++)
            {
                if (this.teams[i].IsSmallerThan(this.teams[i + 1]))
                {
                    this.teams[i].Swap(this.teams[i + 1]);
                }
            }
        }
    }
}
