using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfBaseball.Models.DTO
{
    public class Team
    {
        public Team()
        {
            PLayerIdList = new List<int>();
        }
        [Required (ErrorMessage = "A Name must be provided")]
        public string Name { get; set; }
        public int TeamId { get; set; }
        public string ManagerName { get; set; }
        public string LeagueName { get; set; }
        public List<int> PLayerIdList {get; set; }
    }
}
