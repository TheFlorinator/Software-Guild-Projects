using LeagueOfBaseball.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfBaseball.Models
{
    public class TeamResponse
    {
        public Team NewTeam { get; set; }

        public TeamResponse()
        {
            NewTeam = new Team();
        }
    }
}
