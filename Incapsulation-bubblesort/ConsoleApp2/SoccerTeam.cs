using System;

namespace SoccerTeamNamespace
{
    public class ProgramST
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

            public (int minIndex, int maxIndex) GetMinMaxIndex(SoccerTeam secondTeam, int index1, int index2)
            {
                if (index1 > index2)
                    return (index2, index1);
                return (index1, index2);
            }

            public string Print()
            {
                return this.name.ToString() + "- " + this.points.ToString();
            }

            public bool CompareIfSmaller(SoccerTeam secondTeam)
            {
                return this.points < secondTeam.points;
            }
        }
        static void Main(string[] args)
        {
            ;

        }
    }
}
