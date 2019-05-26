using System;
using Xunit;

namespace Incapsulation_bubblesort.tests
{
    public class UnitTest1
    {
        
        [Fact]
        public void CheckIfBubbleSortingWorksForGivenTask()
        {
            Soccer.Program.SoccerTeam[] allTeams = { new Soccer.Program.SoccerTeam("CFR Cluj ", 36),
                                    new Soccer.Program.SoccerTeam("FCSB ", 31),
                                    new Soccer.Program.SoccerTeam("U Craiova ", 32),
                                    new Soccer.Program.SoccerTeam("Dinamo ", 24),
                                    new Soccer.Program.SoccerTeam("Viitorul ",24),
                                    new Soccer.Program.SoccerTeam("Astra Giurgiu ", 25),
                                    new Soccer.Program.SoccerTeam("CSMS Iasi ", 21),
                                    new Soccer.Program.SoccerTeam("FC Botosani ", 22),
                                    new Soccer.Program.SoccerTeam("FC Voluntari ", 17),
                                    new Soccer.Program.SoccerTeam("Chiajna ", 18),
                                    new Soccer.Program.SoccerTeam("ACS Poli Tim ", 14),
                                    new Soccer.Program.SoccerTeam("Sepsi OSK ", 14),
                                    new Soccer.Program.SoccerTeam("Gaz Metan ", 8),
                                    new Soccer.Program.SoccerTeam("Juventus ", 10)};
            Soccer.Program.SoccerTeam[] rearangedTeam = { new Soccer.Program.SoccerTeam("CFR Cluj ", 36),
                                    new Soccer.Program.SoccerTeam("U Craiova ", 32),
                                    new Soccer.Program.SoccerTeam("FCSB ", 31),
                                    new Soccer.Program.SoccerTeam("Astra Giurgiu ", 25),
                                    new Soccer.Program.SoccerTeam("Dinamo ", 24),
                                    new Soccer.Program.SoccerTeam("Viitorul ", 24),
                                    new Soccer.Program.SoccerTeam("FC Botosani ", 22),
                                    new Soccer.Program.SoccerTeam("CSMS Iasi ", 21),
                                    new Soccer.Program.SoccerTeam("Chiajna ", 18),
                                    new Soccer.Program.SoccerTeam("FC Voluntari ", 17),
                                    new Soccer.Program.SoccerTeam("ACS Poli Tim ", 14),
                                    new Soccer.Program.SoccerTeam("Sepsi OSK ", 14),
                                    new Soccer.Program.SoccerTeam("Juventus ", 10),
                                    new Soccer.Program.SoccerTeam("Gaz Metan ", 8)};
            Program.BubbleSort teams = new Program.BubbleSort(allTeams);
            Program.BubbleSort newTeams =new Program.BubbleSort(rearangedTeam);
            teams.BubbleSorting();
            Assert.True(newTeams.CompareRanking(teams));
        }

        [Fact]
        public void CheckIfMinMaxWorks()
        {
            Soccer.Program.SoccerTeam[] allTeams = { new Soccer.Program.SoccerTeam("CFR Cluj ", 36),
                                    new Soccer.Program.SoccerTeam("FCSB ", 31),
                                    new Soccer.Program.SoccerTeam("U Craiova ", 32),
                                    new Soccer.Program.SoccerTeam("Dinamo ", 24),
                                    new Soccer.Program.SoccerTeam("Viitorul ",24),
                                    new Soccer.Program.SoccerTeam("Astra Giurgiu ", 25),
                                    new Soccer.Program.SoccerTeam("CSMS Iasi ", 21),
                                    new Soccer.Program.SoccerTeam("FC Botosani ", 22),
                                    new Soccer.Program.SoccerTeam("FC Voluntari ", 17),
                                    new Soccer.Program.SoccerTeam("Chiajna ", 18),
                                    new Soccer.Program.SoccerTeam("ACS Poli Tim ", 14),
                                    new Soccer.Program.SoccerTeam("Sepsi OSK ", 14),
                                    new Soccer.Program.SoccerTeam("Gaz Metan ", 8),
                                    new Soccer.Program.SoccerTeam("Juventus ", 10)};
            Program.BubbleSort teams = new Program.BubbleSort(allTeams);
            Assert.Equal((45, 64), teams.GetMinMaxIndex(45, 64));
        }
    }
}
