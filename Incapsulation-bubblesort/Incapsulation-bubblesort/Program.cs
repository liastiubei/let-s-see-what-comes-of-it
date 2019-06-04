using System;

namespace Incapsulation_bubblesort
{
    public class Program
    {
        public class BubbleSort
        {
            private Soccer.Program.SoccerTeam[] teams;

            public BubbleSort(Soccer.Program.SoccerTeam[] teams)
            {
                this.teams = teams;
            }
            
            public Soccer.Program.SoccerTeam[] Copy()
            {
                Soccer.Program.SoccerTeam[] copiedTeams = this.teams;
                return copiedTeams;
            }

            public void BubbleSorting()
            {
                bool checkIfCorrect = false;
                while (checkIfCorrect == false)
                {
                    checkIfCorrect = true;
                    for (int i = 0; i < this.teams.Length - 1; i++)
                    {
                        if (teams[i].CompareIfSmaller(teams[i + 1]))
                        {
                            this.Swap(i, i+1);
                            checkIfCorrect = false;
                        }
                    }
                }
            }

            public (int minIndex, int maxIndex) GetMinMaxIndex(int index1, int index2)
            {
                if (index1 > index2)
                    return (index2, index1);
                return (index1, index2);
            }

            private void Swap(int index1, int index2)
            {
                (int minIndex, int maxIndex) = this.GetMinMaxIndex(index1, index2);
                Console.WriteLine(this.teams[minIndex].StringSwappingMessage(minIndex,maxIndex, this.teams[maxIndex]));
                Soccer.Program.SoccerTeam temp = this.teams[minIndex];
                this.teams[minIndex] = this.teams[maxIndex];
                this.teams[maxIndex] = temp;
            }

            public void ReadAllTeams()
            {
                for (int i = 0; i < 14; i++)
                {
                    string[] teamData = Console.ReadLine().Split('-');
                    int points = Convert.ToInt32(teamData[1]) + Convert.ToInt32(teamData[2]);
                    this.teams[i] = new Soccer.Program.SoccerTeam(teamData[0], points);
                }
            }

            public bool CompareRanking(BubbleSort newRanking)
            {
                for (int i = 0; i < 14; i++)
                    if (!this.teams[i].CompareIfTheSame(newRanking.teams[i])) return false;
                return true;
            }

        }

        static void Main(string[] args)
        {
            BubbleSort teams = new BubbleSort(new Soccer.Program.SoccerTeam[14]);
            teams.ReadAllTeams();
            BubbleSort oldTeams = teams;
            for (int i = 0; i < 14; i++)
                Console.WriteLine(teams.Copy()[i].Print());
            Console.Read();

        }


    
    }
}
