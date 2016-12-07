using LeagueOfBaseball.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfBaseball.Models.Interfaces
{
    public interface IRepository
    {
        Player GetOnePlayer(int playerId);
        IEnumerable<Player> GetallPlayers();
        Player SavePlayer(Player player);
        bool DeletePlayer(Player player);
        IEnumerable<Team> GetAllTeams();
        Team GetOneTeam(string teamName);
        bool SaveTeam(Team team);
        void DeleteTeam(Team team);
    }
}
