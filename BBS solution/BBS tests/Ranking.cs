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
            bool check = false;
            while (!check)
            {
                check = true;
                for (int i = 0; i < this.teams.Length - 1; i++)
                {
                    if (this.teams[i].IsSmallerThan(this.teams[i + 1]))
                    {
                        this.teams[i].Swap(this.teams[i + 1]);
                        check = false;
                    }
                }
            }
        }

        internal void Update(Game game)
        {
            (int index1, int index2, int score1, int score2) = this.Search(game);
            if (index1 == -1 || index2 == -1)
            {
                Console.WriteLine("Can't update the ranking because one of the teams cannot be found");
            }
            else
            {
                this.teams[index1].AddToScore(score1);
                this.teams[index2].AddToScore(score2);
                this.Sorting();
            }
        }

        internal (int index1, int index2, int score1, int score2) Search(Game game)
        {
            int index1=-1, index2=-1, score1=0, score2=0;
            for(int i=0;i<this.teams.Length;i++)
            {
                if (this.teams[i].Search1stTeam(game, ref score1))
                {
                    index1 = i;
                }

                if (this.teams[i].Search2ndTeam(game,ref score2))
                {
                    index2 = i;
                }
            }
            return (index1, index2, score1, score2);
        }
    }
}
