using System;
using Xunit;

namespace BBS_program.tests
{
    public class UnitTest1
    {
        [Fact]
        public void CheckIfReadCorrectly_ShouldReturnTrue()
        {
            Team.Program.Teams[] teams1 ={new Team.Program.Teams("",0),
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
            Program.Ranking ranking = new Program.Ranking(teams1);
            string[] lines = { "Echipa1 - 3 - 4",
                            "Echipa2 - 13 - 5",
                            "Echipa3 - 23 - 6",
                            "Echipa4 - 33 - 7",
                            "Echipa5 - 43 - 8",
                            "Echipa6 - 53 - 9",
                            "Echipa7 - 63 - 10",
                            "Echipa8 - 73 - 11",
                            "Echipa9 - 83 - 12",
                            "Echipa10 - 93 - 13",
                            "Echipa11 - 103 - 14",
                            "Echipa12 - 113 - 15",
                            "Echipa13 - 123 - 16",
                            "Echipa14 - 133 - 17"};
            Team.Program.Teams[] teams ={new Team.Program.Teams("Echipa1 ", 7),
                                    new Team.Program.Teams("Echipa2 ", 18),
                                    new Team.Program.Teams("Echipa3 ", 29),
                                    new Team.Program.Teams("Echipa4 ", 40),
                                    new Team.Program.Teams("Echipa5 ", 51),
                                    new Team.Program.Teams("Echipa6 ", 62),
                                    new Team.Program.Teams("Echipa7 ", 73),
                                    new Team.Program.Teams("Echipa8 ", 84),
                                    new Team.Program.Teams("Echipa9 ", 95),
                                    new Team.Program.Teams("Echipa10 ", 106),
                                    new Team.Program.Teams("Echipa11 ", 117),
                                    new Team.Program.Teams("Echipa12 ", 128),
                                    new Team.Program.Teams("Echipa13 ", 139),
                                    new Team.Program.Teams("Echipa14 ", 150)};
            Program.Ranking correctRanking = new Program.Ranking(teams);
            ranking.Read(lines);
            Assert.True(ranking.Equal(correctRanking));
        }

        [Fact]
        public void CheckIfRandom1SwitchBubbleSortWorks_ShouldReturnTrue()
        {
            Team.Program.Teams[] correctTeams ={new Team.Program.Teams("Echipa1 ", 100),
                                    new Team.Program.Teams("Echipa2 ", 96),
                                    new Team.Program.Teams("Echipa3 ", 90),
                                    new Team.Program.Teams("Echipa4 ", 89),
                                    new Team.Program.Teams("Echipa5 ", 83),
                                    new Team.Program.Teams("Echipa6 ", 80),
                                    new Team.Program.Teams("Echipa7 ", 73),
                                    new Team.Program.Teams("Echipa8 ", 61),
                                    new Team.Program.Teams("Echipa9 ", 59),
                                    new Team.Program.Teams("Echipa10 ", 42),
                                    new Team.Program.Teams("Echipa11 ", 33),
                                    new Team.Program.Teams("Echipa12 ", 31),
                                    new Team.Program.Teams("Echipa13 ", 27),
                                    new Team.Program.Teams("Echipa14 ", 20)};
            Team.Program.Teams[] teams = {new Team.Program.Teams("Echipa1 ", 100),
                                    new Team.Program.Teams("Echipa2 ", 96),
                                    new Team.Program.Teams("Echipa4 ", 89),
                                    new Team.Program.Teams("Echipa3 ", 90),
                                    new Team.Program.Teams("Echipa5 ", 83),
                                    new Team.Program.Teams("Echipa6 ", 80),
                                    new Team.Program.Teams("Echipa7 ", 73),
                                    new Team.Program.Teams("Echipa8 ", 61),
                                    new Team.Program.Teams("Echipa9 ", 59),
                                    new Team.Program.Teams("Echipa10 ", 42),
                                    new Team.Program.Teams("Echipa11 ", 33),
                                    new Team.Program.Teams("Echipa12 ", 31),
                                    new Team.Program.Teams("Echipa13 ", 27),
                                    new Team.Program.Teams("Echipa14 ", 20)};
            Program.Ranking wrongRanking = new Program.Ranking(teams);
            Program.Ranking correctRanking = new Program.Ranking(correctTeams);
            wrongRanking.Sorting();
            Assert.True(correctRanking.Equal(wrongRanking));
        }

        [Fact]
        public void CheckIfRandomSeveralNotOverlappingSwitchesBubbleSortWorks_ShouldReturnTrue()
        {
            Team.Program.Teams[] correctTeams ={new Team.Program.Teams("Echipa1 ", 100),
                                    new Team.Program.Teams("Echipa2 ", 96),
                                    new Team.Program.Teams("Echipa3 ", 90),
                                    new Team.Program.Teams("Echipa4 ", 89),
                                    new Team.Program.Teams("Echipa5 ", 83),
                                    new Team.Program.Teams("Echipa6 ", 80),
                                    new Team.Program.Teams("Echipa7 ", 73),
                                    new Team.Program.Teams("Echipa8 ", 61),
                                    new Team.Program.Teams("Echipa9 ", 59),
                                    new Team.Program.Teams("Echipa10 ", 42),
                                    new Team.Program.Teams("Echipa11 ", 33),
                                    new Team.Program.Teams("Echipa12 ", 31),
                                    new Team.Program.Teams("Echipa13 ", 27),
                                    new Team.Program.Teams("Echipa14 ", 20)};
            Team.Program.Teams[] teams = {new Team.Program.Teams("Echipa1 ", 100),
                                    new Team.Program.Teams("Echipa2 ", 96),
                                    new Team.Program.Teams("Echipa4 ", 89),
                                    new Team.Program.Teams("Echipa3 ", 90),
                                    new Team.Program.Teams("Echipa6 ", 80),
                                    new Team.Program.Teams("Echipa5 ", 83),
                                    new Team.Program.Teams("Echipa7 ", 73),
                                    new Team.Program.Teams("Echipa8 ", 61),
                                    new Team.Program.Teams("Echipa10 ", 42),
                                    new Team.Program.Teams("Echipa9 ", 59),
                                    new Team.Program.Teams("Echipa11 ", 33),
                                    new Team.Program.Teams("Echipa12 ", 31),
                                    new Team.Program.Teams("Echipa13 ", 27),
                                    new Team.Program.Teams("Echipa14 ", 20)};
            Program.Ranking wrongRanking = new Program.Ranking(teams);
            Program.Ranking correctRanking = new Program.Ranking(correctTeams);
            wrongRanking.Sorting();
            Assert.True(correctRanking.Equal(wrongRanking));
        }

        [Fact]
        public void CheckIfRandomSeveralOverlappingAndNormalSwitchesBubbleSortWorks_ShouldReturnTrue()
        {
            Team.Program.Teams[] correctTeams ={new Team.Program.Teams("Echipa1 ", 100),
                                    new Team.Program.Teams("Echipa2 ", 96),
                                    new Team.Program.Teams("Echipa3 ", 90),
                                    new Team.Program.Teams("Echipa4 ", 89),
                                    new Team.Program.Teams("Echipa5 ", 83),
                                    new Team.Program.Teams("Echipa6 ", 80),
                                    new Team.Program.Teams("Echipa7 ", 73),
                                    new Team.Program.Teams("Echipa8 ", 61),
                                    new Team.Program.Teams("Echipa9 ", 59),
                                    new Team.Program.Teams("Echipa10 ", 42),
                                    new Team.Program.Teams("Echipa11 ", 33),
                                    new Team.Program.Teams("Echipa12 ", 31),
                                    new Team.Program.Teams("Echipa13 ", 27),
                                    new Team.Program.Teams("Echipa14 ", 20)};
            Team.Program.Teams[] teams = {new Team.Program.Teams("Echipa1 ", 100),
                                    new Team.Program.Teams("Echipa4 ", 89),
                                    new Team.Program.Teams("Echipa2 ", 96),
                                    new Team.Program.Teams("Echipa3 ", 90),
                                    new Team.Program.Teams("Echipa6 ", 80),
                                    new Team.Program.Teams("Echipa5 ", 83),
                                    new Team.Program.Teams("Echipa7 ", 73),
                                    new Team.Program.Teams("Echipa8 ", 61),
                                    new Team.Program.Teams("Echipa10 ", 42),
                                    new Team.Program.Teams("Echipa11 ", 33),
                                    new Team.Program.Teams("Echipa9 ", 59),
                                    new Team.Program.Teams("Echipa13 ", 27),
                                    new Team.Program.Teams("Echipa12 ", 31),
                                    new Team.Program.Teams("Echipa14 ", 20)};
            Program.Ranking wrongRanking = new Program.Ranking(teams);
            Program.Ranking correctRanking = new Program.Ranking(correctTeams);
            wrongRanking.Sorting();
            Assert.True(correctRanking.Equal(wrongRanking));
        }
    }
}
