using LeagueOfBaseball.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueOfBaseball.Models;
using LeagueOfBaseball.Models.DTO;

namespace LeagueOfBaseball.Data
{
    public class InMemoryRepo : IRepository
    {
        private static Dictionary<int, Player> _players;
        private static Dictionary<string, Team> _team;
        private static int playerIdCounter = 7;
        //private string _name;

        static InMemoryRepo()
        {
            _players = new Dictionary<int, Player>();
            var playerOne = new Player()
            {
                Name = "Jason Florin",
                JerseyNumber = 11,
                PositionId = Positions.Pitcher,
                BattingAverage = 1000,
                TeamName = "Lightning",
                NumberYearsPlayed = 10,
                PlayerId = 1,

            };
            _players.Add(playerOne.PlayerId, playerOne);
            var playerTwo = new Player()
            {
                Name = "Tom Florin",
                JerseyNumber = 29,
                PositionId = Positions.RightField,
                BattingAverage = .500m,
                TeamName = "Lightning",
                NumberYearsPlayed = 7,
                PlayerId = 2
            };
            _players.Add(playerTwo.PlayerId, playerTwo);
            var playerThree = new Player()
            {
                Name = "Hannah Florin",
                JerseyNumber = 20,
                PositionId = Positions.Pitcher,
                BattingAverage = 1000,
                TeamName = "Lightning",
                NumberYearsPlayed = 15,
                PlayerId = 3
            };
            _players.Add(playerThree.PlayerId, playerThree);
            var playerFour = new Player()
            {
                Name = "Kaylee Florin",
                JerseyNumber = 8,
                PositionId = Positions.Pitcher,
                BattingAverage = 1000,
                TeamName = "The Knights of the Round Table",
                NumberYearsPlayed = 10,
                PlayerId = 4
            };
            _players.Add(playerFour.PlayerId, playerFour);
            var playerFive = new Player()
            {
                Name = "Greg Florin",
                JerseyNumber = 20,
                PositionId = Positions.LeftField,
                BattingAverage = .500m,
                TeamName = "The Knights of the Round Table",
                NumberYearsPlayed = 25,
                PlayerId = 5,
            };
            _players.Add(playerFive.PlayerId, playerFive);
            var playerSix = new Player()
            {
                Name = "Jolyn Florin",
                JerseyNumber = 20,
                PositionId = Positions.Catcher,
                BattingAverage = 1000,
                TeamName = "The Knights of the Round Table",
                NumberYearsPlayed = 15,
                PlayerId = 6
            };
            _players.Add(playerSix.PlayerId, playerSix);
            _team = new Dictionary<string, Team>();

            var teamOne = new Team()
            {
                Name = "Lightning",
                LeagueName = "The Best",
                ManagerName = "Jason Florin",
            };
            teamOne.PLayerIdList.Add(playerOne.PlayerId);
            teamOne.PLayerIdList.Add(playerTwo.PlayerId);
            teamOne.PLayerIdList.Add(playerThree.PlayerId);
            _team.Add(teamOne.Name, teamOne);
            var teamTwo = new Team()
            {
                Name = "The Knights of the Round Table",
                LeagueName = "The Best",
                ManagerName = "Greg Florin",
            };
            teamTwo.PLayerIdList.Add(playerFour.PlayerId);
            teamTwo.PLayerIdList.Add(playerFive.PlayerId);
            teamTwo.PLayerIdList.Add(playerSix.PlayerId);
            _team.Add(teamTwo.Name, teamTwo);
        }

        public Player SavePlayer(Player player)
        {
            if (_players.Any(p => p.Key == player.PlayerId))
            {
                var team = GetOneTeam(player.TeamName);
                foreach (var aTeam in _team)
                {
                    foreach (var aPlayer in aTeam.Value.PLayerIdList)
                    {
                        if (aPlayer == player.PlayerId)
                        {
                            aTeam.Value.PLayerIdList.Remove(aPlayer);
                            break;
                        }
                    }
                }
                _team.FirstOrDefault(t => t.Key == player.TeamName).Value.PLayerIdList.Add(player.PlayerId);
                _players.Remove(player.PlayerId);
                _players.Add(player.PlayerId, player);
                return player;
            }
            else
            {
                player.PlayerId = playerIdCounter;
                playerIdCounter++;
                _players.Add(player.PlayerId, player);

                if (!_team.ContainsKey(player.TeamName))
                {
                    var team = new Team() { Name = player.TeamName };
                    _team.Add(team.Name, team);
                }
                _team[player.TeamName].PLayerIdList.Add(player.PlayerId);
                return player;
            }
        }

        public bool DeletePlayer(Player player)
        {
            var team = _team[player.TeamName];
            team.PLayerIdList.Remove(player.PlayerId);
            _players.Remove(player.PlayerId);
            return true;
        }

        public IEnumerable<Player> GetallPlayers()
        {
            return _players.Select(p => p.Value);
        }

        public Player GetOnePlayer(int playerId)
        {
            return _players[playerId];
        }

        public Team GetOneTeam(string teamName)
        {
            return _team.Values.FirstOrDefault(n => n.Name == teamName);
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return _team.Select(t => t.Value);
        }

        public bool SaveTeam(Team team)
        {
            _team.Add(team.Name, team);
            return true;
        }

        public void DeleteTeam(Team team)
        {
            _team.Remove(team.Name);
        }
    }
}
