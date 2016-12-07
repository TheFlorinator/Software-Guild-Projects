using LeagueOfBaseball.Logic;
using LeagueOfBaseball.Models;
using LeagueOfBaseball.Models.DTO;
using LeagueOfBaseball.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;

namespace LeagueOfBaseball.UI.Controllers
{
    public class UserController : Controller
    {
        private League _league;
        public UserController()
        {
            _league = new League();
        }

       [HttpGet]
       public ActionResult GetAllTeams()
        { 
            TeamsVM teams = new TeamsVM();
            teams.TeamList = _league.GetAllTeams().ResponseType;
            return View(teams);
        }

        [HttpPost]
        public ActionResult GetAllTeams(string currentTeamName)
        {
            var viewModel = new TeamsVM();
            var teamList = _league.GetAllPlayersForTeam(currentTeamName).ResponseType;
            viewModel.TeamList = _league.GetAllTeams().ResponseType;
            viewModel.PlayerList = teamList;
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult GetOnePlayer(int id)
        {
            var player = _league.GetAPlayer(id);
            return View(player.ResponseType);
        }

        //need to complete
        [HttpGet]
        public ActionResult EditOnePlayer(int id)
        {
            var viewModel = new PlayerVM();
            viewModel.Player = _league.GetAPlayer(id).ResponseType;
            viewModel.SetTeamNames(_league.GetAllTeams().ResponseType);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditOnePlayer(PlayerVM model)
        {
            _league.AddPlayer(model.Player);
            return RedirectToAction("GetAllTeams");
        }

        [HttpGet]
        public ActionResult AddTeam()
        {
            Team team = new Team();
            return View(team);
        }

        [HttpPost]
        public ActionResult AddTeam(Team team)
        {
            if (ModelState.IsValid)
            {
                var response = _league.AddTeam(team);
                return RedirectToAction("GetAllTeams", response);
            }
            return View(team);
        }

        [HttpGet]
        public ActionResult EditTeam(string currentTeamName)
        {
            var viewModel = new TeamsVM();
            viewModel.Team = _league.GetAllTeams().ResponseType.FirstOrDefault(t => t.Name == currentTeamName);
            viewModel.SetPlayers(_league.GetAllPlayersForTeam(viewModel.Team.Name).ResponseType);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditTeam(TeamsVM viewModel)
        {
            if (ModelState.IsValid)
            {
                _league.EditTeam(viewModel.Team);
                return RedirectToAction("GetAllTeams");
            }
            viewModel.SetPlayers(_league.GetAllPlayersForTeam(viewModel.Team.Name).ResponseType);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult AddPlayer()
        {
            var viewModel = new PlayerVM();
            viewModel.SetTeamNames(_league.GetAllTeams().ResponseType);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddPlayer(PlayerVM viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.Player.PositionId = viewModel.position;
                _league.AddPlayer(viewModel.Player);
                return RedirectToAction("GetAllTeams");
            }
            viewModel.SetTeamNames(_league.GetAllTeams().ResponseType);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult DeletePlayer(int id)
        {
            var player = _league.GetAPlayer(id);
            return View(player.ResponseType);
        }

        [HttpPost]
        public ActionResult DeletePlayer(Player oldPlayer)
        {
            _league.DeleteAPlayer(oldPlayer);
            return RedirectToAction("GetAllTeams");
        }

        [HttpGet]
        public ActionResult DeleteTeam(string name)
        {
            var teams = _league.GetAllTeams();
            TeamResponse team = new TeamResponse();
            team.NewTeam = (Team)teams.ResponseType.FirstOrDefault(t => t.Name == name);
            return View(team);
        }

        [HttpPost]
        public ActionResult DeleteTeam(Team team)
        {
            _league.DeleteATeam(team);
            var viewModel = new TeamsVM();
            viewModel.TeamList = _league.GetAllTeams().ResponseType;
            return RedirectToAction("GetAllTeams");
        }

        [HttpGet]
        public ActionResult DisplayTeams()
        {
            var viewModel = new TeamsVM();
            viewModel.TeamList = _league.GetAllTeams().ResponseType;
            return View(viewModel);
        }
    }
}