using System;

namespace BBS_program
{
    public class Program
    {
        public class Ranking
        {
            private Team.Program.Teams[] teams;

            public Ranking(Team.Program.Teams[] teams)
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
                for(int i=0;i<14;i++)
                {
                    if(!this.teams[i].Equal(that.teams[i])) return false;
                }
                return true;
            }

            public void Sorting()
            {
                bool check =false;                
                while(!check)
                {
                    check = true;
                    for (int i = 0; i < 13; i++)
                    {
                        if (this.teams[i].IsSmallerThan(this.teams[i + 1]))
                        {
                            this.teams[i].Swap(this.teams[i + 1]);
                            check = false;
                        }
                    }
                    
                }
            }

            public void Print()
            {
                for (int i = 0; i < 14; i++) this.teams[i].Print();
            }

        }


        static void Main(string[] args)
        {
            Team.Program.Teams[] teams ={new Team.Program.Teams("",0),
                                    new Team.Program.Teams("",0),
                                    new Team.Program.Teams("",0),
                                    new Team.Program.Teams("",0),
                                    new Team.Program.Teams("",0),
                                    new Team.Program.Teams("",0),
                                    new Team.Program.Teams("",0),
                                    new Team.Program.Teams("",0),
                                    new Team.Program.Teams("",0),
                                    new Team.Program.Teams("",0),
                                    new Team.Program.Teams("",0),
                                    new Team.Program.Teams("",0),
                                    new Team.Program.Teams("",0),
                                    new Team.Program.Teams("",0)};
            Program.Ranking ranking = new Program.Ranking(teams);
            string[] lines=new string[14];
            for (int i = 0; i < 14; i++) lines[i]=Console.ReadLine();
            ranking.Read(lines);
            ranking.Sorting();
            ranking.Print();

        }
    }
}
