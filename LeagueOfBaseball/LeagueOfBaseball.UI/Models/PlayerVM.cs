using LeagueOfBaseball.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueOfBaseball.UI.Models
{
    public class PlayerVM
    {
        public Player Player { get; set; }
        public List<SelectListItem> TeamList { get; set; }
        public Positions position { get; set; }

        public List<SelectListItem> PositionList()
        {
            List<SelectListItem> choices = new List<SelectListItem>();
            foreach (string position in Enum.GetValues(typeof(Positions)))
            {
                choices.Add(new SelectListItem() { Text = position, Value = bool.TrueString });
            }
            return choices;
        }

        public PlayerVM()
        {
            TeamList = new List<SelectListItem>();
        }

        public void SetTeamNames(IEnumerable<Team> teams)
        {
            foreach (var team in teams)
            {
                TeamList.Add(new SelectListItem()
                {
                    Value = team.Name.ToString(),
                    Text = team.Name
                });
            }
        }
    }
}