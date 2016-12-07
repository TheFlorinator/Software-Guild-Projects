using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfBaseball.Models.DTO
{
    public class Player
    {
        [Required(ErrorMessage = "A name must be provided!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A number between 1 and 45 must provided!")]
        [Range(1,100)]
        public int JerseyNumber { get; set; }

        [Required(ErrorMessage = "A position must be chosen!")]
        public Positions PositionId { get; set; }
        public decimal BattingAverage { get; set; }

        [Required(ErrorMessage = "The player must be assigned to a Team!")]
        public string TeamName { get; set; }

        public int NumberYearsPlayed { get; set; }
        public int PlayerId { get; set; }
    }
}
