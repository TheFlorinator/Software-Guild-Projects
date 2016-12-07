using LeagueOfBaseball.Logic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueOfBaseball.Models;
using LeagueOfBaseball.Models.DTO;

namespace LeagueOfBaseball.Tests
{
    [TestFixture]
    public class InMemoryTests
    {
        [Test]
        public void CanSearchAllTeams()
        {
            League league = new League();
            var response = league.GetAllTeams();
            Assert.AreEqual(2, response.ResponseType.Count());
            Assert.IsTrue(response.ResponseType.Where(t => t.Name == "Lightning").Count() == 1);
        }

        [TestCase("The Knights of the Round Table", true)]
        [TestCase("Lightning", true)]
        [TestCase("Not a Team", false)]
        [TestCase("Also not a team", false)]
        [TestCase("", false)]
        public void CanGetAllPlayersForTeam(string name, bool expectedResults)
        {
            Team team = new Team();
            League league = new League();
            var response = league.GetAllPlayersForTeam(name);
            Assert.AreEqual(response.Success, expectedResults);
        }

        [TestCase("New Team", true)]
        [TestCase("Another New Team", true)]
        [TestCase("", false)]
        [TestCase("Lightning", false)]
        [TestCase("The Knights of the Round Table", false)]
        public void CanAddTeam(string name, bool expectedResults)
        {
            League league = new League();
            Team team = new Team();
            team.Name = name;
            var response = league.AddTeam(team);
            Assert.AreEqual(response.Success, expectedResults);
        }

        [TestCase(1, true)]
        [TestCase(2, true)]
        [TestCase(7, false)]
        [TestCase(45, false)]
        public void CanGetAPlayer(int id, bool expectedResult)
        {
            League league = new League();
            var response = league.GetAPlayer(id);
            Assert.AreEqual(response.Success, expectedResult);

        }

        [TestCase("Jason Florin", Positions.Catcher, "Lightning", true)]
        [TestCase("Jason The Great", Positions.Pitcher, "A New Team", true)]
        [TestCase("", Positions.Firstbase, "Lightning", false)]
        [TestCase("Jason", Positions.NoPosition, "Lightning", false)]
        public void CanAddPlayer(string name, Positions position, string teamName, bool expectedResults)
        {
            League league = new League();
            Player player = new Player();
            player.Name = name;
            player.PositionId = position;
            player.TeamName = teamName;
            var response = league.AddPlayer(player);
            Assert.AreEqual(response.Success, expectedResults);
        }

        [TestCase(1, "Lightning", true)]
        [TestCase(2, "Lightning", true)]
        [TestCase(9, "Lightning", false)]
        [TestCase(57, "Lightning", false)]
        public void CanDeletePlayer(int playerId, string name, bool expectedResults)
        {
            League league = new League();
            Player player = new Player();
            player.PlayerId = playerId;
            player.TeamName = name;
            var response = league.DeleteAPlayer(player);
            Assert.AreEqual(response, expectedResults);
        }

        [TestCase("Lightning", true)]
        [TestCase("The Knights of the Round Table", true)]
        [TestCase("Some Team", false)]
        [TestCase("A Crappy Team", false)]
        [TestCase("", false)]
        public void CanDeleteATeam(string name,bool expectedResults)
        {
            League league = new League();
            Team team = new Team();
            team.Name = name;
            var response = league.DeleteATeam(team);
            Assert.AreEqual(response, expectedResults);
        }

        [TestCase(1, "Jas the Mace", 11, Positions.Catcher, 1000, "Lightning", 10, true)]
        [TestCase(1, "Jason the great", 11, Positions.Catcher, 1000, "Lightning", 10, true)]
        [TestCase(1, "Jason Florin", 0, Positions.Catcher, 1000, "Lightning", 10, false)]
        [TestCase(1, "Jason Florin", 11, Positions.Catcher, 1000, "Lightning", 10, true)]
        [TestCase(1, "", 11, Positions.Catcher, 1000, "Lightning", 10, false)]

        public void CanEditPlayer(int id, string name, int jerseyNumber, Positions position, int battingAverage, string teamName, int yearsPlayed, bool expectedResults)
        {
            League league = new League();
            Player player = new Player();
            player.PlayerId = id;
            player.Name = name;
            player.JerseyNumber = jerseyNumber;
            player.PositionId = position;
            player.BattingAverage = battingAverage;
            player.TeamName = teamName;
            player.NumberYearsPlayed = yearsPlayed;
            var response = league.EditPlayer(player);
            Assert.AreEqual(response.Success, expectedResults);
        }

        [TestCase("Here is a team name","The Best", "a new manager", true)]
        [TestCase("A Different Team", "The Best", "Another Manager", true)]
        [TestCase("", "The Best", "A manager", false)]
        [TestCase("A Crappy Team", "The Best", "", false)]
        [TestCase("", "The Best", "", false)]
        public void CanEditTeam(string teamName, string leagueName, string managerName, bool expectedResults)
        {
            League league = new League();
            Team team = new Team();
            team.Name = teamName;
            team.LeagueName = leagueName;
            team.ManagerName = managerName;
            var response = league.EditTeam(team);
            Assert.AreEqual(response.Success, expectedResults);
        }
    }
}
