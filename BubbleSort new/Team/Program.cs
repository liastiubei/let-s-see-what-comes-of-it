using System;

namespace Team
{
    public class Program
    {
        public class Teams
        {
            private string name;
            private int score;

            public Teams(string name, int score)
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

            public bool Equal(Teams that)
            {
                return this.name == that.name && this.score == that.score;
            }
            public bool IsSmallerThan(Teams that)
            {
                return this.score < that.score;
            }

            public void Swap(Teams that)
            {
                string swapName = this.name;
                this.name = that.name;
                that.name = swapName;

                int swapNum = this.score;
                this.score = that.score;
                that.score = swapNum;
            }

            public void Print()
            {
                Console.WriteLine(this.name + "- " + this.score);
            }
        }




        static void Main(string[] args)
        {
            ;
        }
    }
}
