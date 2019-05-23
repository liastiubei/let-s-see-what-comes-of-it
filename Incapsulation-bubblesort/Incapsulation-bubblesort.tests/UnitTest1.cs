using System;
using Xunit;

namespace Incapsulation_bubblesort.tests
{
    public class UnitTest1
    {
        
        [Fact]
        public void Test1()
        {
            Program.SoccerTeam[] team = { new Program.SoccerTeam("CFR Cluj ", 36, 0),
                                    new Program.SoccerTeam("FCSB ", 31, 1),
                                    new Program.SoccerTeam("U Craiova ", 32, 2),
                                    new Program.SoccerTeam("Dinamo ", 24, 3),
                                    new Program.SoccerTeam("Viitorul ", 22, 4),
                                    new Program.SoccerTeam("Astra Giurgiu ", 25, 5),
                                    new Program.SoccerTeam("CSMS Iasi ", 21, 6),
                                    new Program.SoccerTeam("FC Botosani ", 22, 7),
                                    new Program.SoccerTeam("FC Voluntari ", 17, 8),
                                    new Program.SoccerTeam("Chiajna ", 18, 9),
                                    new Program.SoccerTeam("ACS Poli Tim ", 14, 10),
                                    new Program.SoccerTeam("Sepsi OSK ", 14, 11),
                                    new Program.SoccerTeam("Gaz Metan ", 8, 12),
                                    new Program.SoccerTeam("Juventus ", 10, 13)};

            Program.SoccerTeam[] rearangedTeam = { new Program.SoccerTeam("CFR Cluj ", 36, 0),
                                    new Program.SoccerTeam("U Craiova ", 32, 1),
                                    new Program.SoccerTeam("FCSB ", 31, 2),
                                    new Program.SoccerTeam("Astra Giurgiu ", 25, 3),
                                    new Program.SoccerTeam("Dinamo ", 24, 4),
                                    new Program.SoccerTeam("Viitorul ", 22, 5),
                                    new Program.SoccerTeam("FC Botosani ", 22, 6),
                                    new Program.SoccerTeam("CSMS Iasi ", 21,7),
                                    new Program.SoccerTeam("Chiajna ", 18, 8),
                                    new Program.SoccerTeam("FC Voluntari ", 17, 9),
                                    new Program.SoccerTeam("ACS Poli Tim ", 14, 10),
                                    new Program.SoccerTeam("Sepsi OSK ", 14, 11),
                                    new Program.SoccerTeam("Juventus ", 10, 12),
                                    new Program.SoccerTeam("Gaz Metan ", 8, 13)};
            
            Assert.Equal(rearangedTeam, Program.BubbleSort(team));
        }
    }
}
