using System;

namespace Incapsulation_bubblesort
{
    public class Program
    {
        public class SoccerTeam
        {
            private string name;
            private int points;
            private int index;

            public SoccerTeam(string name, int points, int index)
            {
                this.name = name;
                this.points = points;
                this.index = index;
            }

            public void Swap(SoccerTeam theOtherTeam, SoccerTeam[] teams)
            {
                (SoccerTeam minIndexTeam, SoccerTeam maxIndexTeam) = this.GetMinMaxIndex(theOtherTeam);
                string message = "Swapping elements with indexes ({0}, {1}) and values ({2}, {3})";
                Console.WriteLine(string.Format(message, minIndexTeam.index, maxIndexTeam.index, minIndexTeam.name, maxIndexTeam.name));

                SoccerTeam temp = teams[minIndexTeam.index];
                teams[minIndexTeam.index] = teams[maxIndexTeam.index];
                teams[maxIndexTeam.index] = temp;
                int indexSwitch = minIndexTeam.index;
                minIndexTeam.index = maxIndexTeam.index;
                maxIndexTeam.index = indexSwitch;
            }

            public (SoccerTeam minIndexTeam, SoccerTeam maxIndexTeam) GetMinMaxIndex(SoccerTeam secondTeam)
            {
                if (this.index > secondTeam.index)
                    return (secondTeam, this);
                return (this, secondTeam);
            }

            public void PrintThisLine()
            {
                Console.WriteLine(this.name + "- " + this.points);
            }

            public bool CompareIfSmaller(SoccerTeam secondTeam)
            {
                return this.points < secondTeam.points;
            }
            
        }

        public static SoccerTeam[] BubbleSort(SoccerTeam[] teams)
        {
            bool checkIfCorrect = false;
            while (checkIfCorrect == false)
            {
                checkIfCorrect = true;
                for (int i = 0; i < teams.Length - 1; i++)
                {
                    if (teams[i].CompareIfSmaller(teams[i+1]))
                    {
                        teams[i].Swap(teams[i+1], teams);
                        checkIfCorrect = false;
                    }
                }
            }
            return teams;
        }

        private static SoccerTeam ReadTeam(int i)
        {
            string[] teamData = Console.ReadLine().Split('-');
            int points = Convert.ToInt32(teamData[1]) + Convert.ToInt32(teamData[2]);
            SoccerTeam result = new SoccerTeam(teamData[0], points, i);
            return result;
        }

        private static SoccerTeam[] ReadAllTeams()
        {
            SoccerTeam[] teams = new SoccerTeam[14];
            for (int i = 0; i < 14; i++)
            {
                teams[i] = ReadTeam(i);
            }
            return teams;
        }

        public static void DoTheBubbleSortAndPrint()
        {
            SoccerTeam[] teams = ReadAllTeams();
            teams=BubbleSort(teams);
            for (int i = 0; i < teams.Length; i++)
                teams[i].PrintThisLine();
            Console.Read();
        }

        static void Main(string[] args)
        {
            DoTheBubbleSortAndPrint();
            
        }
    }
}
