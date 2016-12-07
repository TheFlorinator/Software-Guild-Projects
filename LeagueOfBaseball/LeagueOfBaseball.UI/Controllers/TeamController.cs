using LeagueOfBaseball.Logic;
using LeagueOfBaseball.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LeagueOfBaseball.UI.Controllers
{
    public class TeamController : ApiController
    {

        [HttpGet]
        public List<Team> GetTeams()
        {
            League league = new League();
            var teams = league.GetAllTeams();
            return teams.ResponseType.ToList();
        }

        [HttpGet]
        public Team GetTeams(string name)
        {
            League league = new League();
            var team = league.GetAllTeams().ResponseType.FirstOrDefault(t => t.Name == name);
            return team;
        }

        //[HttpGet]
        //public List<Player> GetPlayersFromTeam(Team team)
        //{
        //    League league = new League();
        //    var players = league.GetAllPlayersForTeam(team);
        //    return players.ResponseType;
        //}

        [HttpPost]
        public HttpResponseMessage Post(Team team)
        {
            League league = new League();
            league.AddTeam(team);
            var response = Request.CreateResponse(HttpStatusCode.Created, team);
            string uri = Url.Link("DefaultApi", new { id = team.Name });
            response.Headers.Location = new Uri(uri);
            return response;
        } 
    }
}
