using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueOfBaseball.Models;
using LeagueOfBaseball.Models.DTO;
using LeagueOfBaseball.Models.Interfaces;
using Dapper;
using System.Data.SqlClient;

namespace LeagueOfBaseball.Data
{
    public class DapperRepo : IRepository
    {
        public bool DeletePlayer(Player player)
        {
            string cmdString = "Delete from Players where PlayerID = (@playerId)";
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = cn;
                    comm.CommandText = cmdString;
                    comm.Parameters.AddWithValue("@playerId", player.PlayerId);
                    cn.Open();
                    if (comm.ExecuteNonQuery() <= 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void DeleteTeam(Team team)
        {
            string cmdString = "Delete from Teams where Name = (@teamName)";
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = cn;
                    comm.CommandText = cmdString;
                    comm.Parameters.AddWithValue("@teamName", team.Name);
                    cn.Open();
                    comm.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Player> GetallPlayers()
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var players = cn.Query<Player>("Select PlayerId, Players.Name, JerseyNumber, BattingAverage, NumberYearsPlayed, PositionId, Teams.Name TeamName From Players inner join Teams on Teams.TeamId = Players.TeamId ").ToList();
                return players;
            }
        }

        public IEnumerable<Team> GetAllTeams()
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var teams = cn.Query<Team>("Select TeamId, Name From Teams").ToList();
                return teams;
            }
        }

        public Player GetOnePlayer(int playerId)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var players = cn.Query<Player>("Select PlayerId, Name, JerseyNumber, BattingAverage, NumberYearsPlayed, PositionId, TeamId From Players").ToList();
                return players.FirstOrDefault(i => i.PlayerId.Equals(playerId));
            }
        }

        public Team GetOneTeam(string teamName)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var teams = cn.Query<Team>("Select TeamId, Name From Teams").ToList();
                return teams.FirstOrDefault(t => t.Name.Equals(teamName));
            }
        }

        public Player SavePlayer(Player player)
        {
            //insert and upadte for edit
            string cmdString = "insert into Players (Name, JerseyNumber, BattingAverage, NumberYearsPlayed, PositionId, TeamId) values(@name, @jerseyNumber, @battingAv, @yearPlayed, @positionId, (Select TeamId from Teams where Name = @teamName))";
            string updateString = "update Players set Name = @name, JerseyNumber = @jerseyNumber, BattingAverage = @battingAverage, NumberYearsPlayed = @numberYearsPlayed, PositionId = @positionId where PlayerId = @playerId, ";
                using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
                {
                    if (player.PlayerId <= 0)
                    {
                        using (SqlCommand comm = new SqlCommand())
                        {
                            comm.Connection = cn;
                            comm.CommandText = cmdString;
                            comm.Parameters.AddWithValue("@name", player.Name);
                            comm.Parameters.AddWithValue("@jerseyNumber", player.JerseyNumber);
                            comm.Parameters.AddWithValue("@battingAv", (decimal)player.BattingAverage);
                            comm.Parameters.AddWithValue("@yearPlayed", player.NumberYearsPlayed);
                            comm.Parameters.AddWithValue("@positionId", (int)player.PositionId);
                            comm.Parameters.AddWithValue("@teamName", player.TeamName);
                            cn.Open();
                            comm.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (SqlCommand comm = new SqlCommand())
                        {
                            comm.Connection = cn;
                            comm.CommandText = updateString;
                            comm.Parameters.AddWithValue("@name", player.Name);
                            comm.Parameters.AddWithValue("@jerseyNumber", player.JerseyNumber);
                            comm.Parameters.AddWithValue("@battingAverage", player.BattingAverage);
                            comm.Parameters.AddWithValue("@numberYearsPlayed", player.NumberYearsPlayed);
                            comm.Parameters.AddWithValue("@positionId", player.PositionId);
                            comm.Parameters.AddWithValue("@playerId", player.PlayerId);
                            cn.Open();
                            comm.ExecuteNonQuery();
                        }
                    }
                    return player;
                }
            }

        public bool SaveTeam(Team team)
        {
            string cmdString = "Insert into Teams (Name) values(@name)";
            string updateString = "update Teams set Name = @name where TeamId = @teamId";
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                if (team.TeamId <= 0)
                {
                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = cn;
                        comm.CommandText = cmdString;
                        comm.Parameters.AddWithValue("@name", team.Name);
                        cn.Open();
                        if (comm.ExecuteNonQuery() <= 0)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = cn;
                        comm.CommandText = updateString;
                        comm.Parameters.AddWithValue("@name", team.Name);
                        comm.Parameters.AddWithValue("@teamId", team.TeamId);
                        cn.Open();
                        if (comm.ExecuteNonQuery() <= 0)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
