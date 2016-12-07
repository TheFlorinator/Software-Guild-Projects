using LeagueOfBaseball.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueOfBaseball.Models.DTO;
using LeagueOfBaseball.Models;

namespace LeagueOfBaseball.Logic
{
    public class League
    {

        private IRepository _teamAndPlayerRepository;

        public League()
        {
            _teamAndPlayerRepository = RepositoryCreatOR.Synthesize();
        }

        public Response<Player> AddPlayer(Player player)
        {
            Response<Player> response = new Response<Player>();
            if (string.IsNullOrWhiteSpace(player.Name))
            {
                response.Success = false;
                response.Message = "A name must be provided";
            }
            else if (player.PositionId == Positions.NoPosition)
            {
                response.Success = false;
                response.Message = "A position must be provided";
            }
            else if (string.IsNullOrWhiteSpace(player.TeamName))
            {
                response.Success = false;
                response.Message = "A team name must be provided";
            }
            else
            {
                response.Success = true;
                _teamAndPlayerRepository.SavePlayer(player);
            }
            return response;
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            IEnumerable<Player> playerList = new List<Player>();
            return playerList = _teamAndPlayerRepository.GetallPlayers();
        }

        public Response<Player> GetAPlayer(int playerId)
        {
            Response<Player> repsonse = new Response<Player>();
            IEnumerable<Player> playerCount = GetAllPlayers().ToList();
            repsonse.Success = true;
            repsonse.ResponseType = playerCount.FirstOrDefault(p => p.PlayerId == playerId);
            return repsonse;
        }

        public Response<Team> AddTeam(Team team)
        {
            Response<Team> response = new Response<Team>();
            IEnumerable<Team> teamList = _teamAndPlayerRepository.GetAllTeams();
            if (team.Name == null || string.IsNullOrWhiteSpace(team.Name))
            {
                response.Success = false;
                response.Message = "A team name must be provided";
                return response;
            }
            else if (teamList.Any(n => n.Name == team.Name))
            {
                response.Success = false;
                response.Message = "You cannot name a team the same as a team that already exsists";
                return response;
            }
            else
            {
                response.Success = _teamAndPlayerRepository.SaveTeam(team);
            }

            return response;
        }

        public Response<IEnumerable<Team>> GetAllTeams()
        {
            Response<IEnumerable<Team>> response = new Response<IEnumerable<Team>>();
            response.ResponseType = _teamAndPlayerRepository.GetAllTeams();
            return response;
        }

        public Response<List<Player>> GetAllPlayersForTeam(string teamName)
        {
            Response<List<Player>> response = new Response<List<Player>>() { ResponseType = new List<Player>() };
            IEnumerable<Player> playersOfTeam = _teamAndPlayerRepository.GetallPlayers();
            var teamSearch = _teamAndPlayerRepository.GetOneTeam(teamName);
            if (teamSearch == null)
            {
                response.Success = false;
                response.Message = "An error has occurred";
            }
            else
            {
                foreach (var player in playersOfTeam)
                {
                    if (teamSearch.Name == player.TeamName)
                    {
                        response.ResponseType.Add(player);
                        response.Success = true;
                    }
                }
            }
            return response;
        }

    public bool DeleteAPlayer(Player player)
    {
        var didDelete = false;
        var playerList = _teamAndPlayerRepository.GetallPlayers();
        if (!playerList.Any(i => i.PlayerId == player.PlayerId))
        {
            didDelete = false;
            return didDelete;
        }
        didDelete = _teamAndPlayerRepository.DeletePlayer(player);
        return didDelete;
    }

    public bool DeleteATeam(Team team)
    {
        bool didDelete = false;
        var teamList = _teamAndPlayerRepository.GetAllTeams();
        var playerLIst = _teamAndPlayerRepository.GetallPlayers();
            foreach (var player in playerLIst)
            {
                if (player.TeamName == team.Name)
                {
                    _teamAndPlayerRepository.DeletePlayer(player);
                }
            }
        if (!teamList.Any(n => n.Name == team.Name))
        {
            didDelete = false;
            return didDelete;
        }
        else
        {
            _teamAndPlayerRepository.DeleteTeam(team);
            didDelete = true;
            return didDelete;
        }
    }

    public Response<Player> EditPlayer(Player player)
    {
        Response<Player> response = new Response<Player>();
        response.ResponseType = player;
        if (string.IsNullOrWhiteSpace(response.ResponseType.Name))
        {
            response.Success = false;
            response.Message = "A name must be provided";
        }
        else if (response.ResponseType.PositionId == Positions.NoPosition)
        {
            response.Success = false;
            response.Message = "A position must be chosen";
        }
        else if (response.ResponseType.JerseyNumber <= 0)
        {
            response.Success = false;
            response.Message = "Your number must be greater than one";
        }
        else
        {
            response.Success = true;
            _teamAndPlayerRepository.SavePlayer(response.ResponseType);
        }
        return response;
    }

    public Response<Team> EditTeam(Team team)
    {
        Response<Team> response = new Response<Team>();
        response.ResponseType = team;
        if (string.IsNullOrWhiteSpace(response.ResponseType.Name))
        {
            response.Success = false;
            response.Message = "You must provide a Team Name";
        }
        else
        {
            _teamAndPlayerRepository.SaveTeam(response.ResponseType);
            response.Success = true;
        }
        return response;
    }
}
}
