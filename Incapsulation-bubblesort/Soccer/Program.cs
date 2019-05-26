using System;

namespace Soccer
{
    public class Program
    { 
        public class SoccerTeam
        {
            private string name;
            private int points;

            public SoccerTeam(string name, int points)
            {
                this.name = name;
                this.points = points;
            }
            
            public string StringSwappingMessage(int minIndex, int maxIndex, SoccerTeam teamMax )
            {
                string message = "Swapping elements with indexes ({0}, {1}) and values ({2}, {3})";
                return string.Format(message, minIndex, maxIndex, this.name, teamMax.name);
            }

            public string Print()
            {
                return this.name.ToString() + "- " + this.points.ToString();
            }

            public bool CompareIfSmaller(SoccerTeam secondTeam)
            {
                return this.points < secondTeam.points;
            }

            public bool CompareIfTheSame(SoccerTeam secondTeam)
            {
                return this.name == secondTeam.name && this.points == secondTeam.points;
            }
        }
        static void Main(string[] args)
        {
            ;

        }
    }
}
