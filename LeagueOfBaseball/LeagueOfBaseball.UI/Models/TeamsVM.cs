using LeagueOfBaseball.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueOfBaseball.UI.Models
{
    public class TeamsVM
    {
        public IEnumerable<Team> TeamList { get; set; }
        public IEnumerable<Player> PlayerList { get; set; }
        public List<SelectListItem> SelectPlayerList { get; set; }
        public Team Team { get; set; }
        public Team NewTeam { get; set; }

        public TeamsVM()
        {
            SelectPlayerList = new List<SelectListItem>();
            NewTeam = new Team();
        }

        public void SetPlayers(IEnumerable<Player> players)
        {
            foreach (var player in players)
            {
                SelectPlayerList.Add(new SelectListItem()
                {
                    Value = player.PlayerId.ToString(),
                    Text = player.Name
                });
            }
        }
    }
}