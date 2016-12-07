using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtalOfLife.Models.Data
{
    [Serializable]
    public class Applicant
    {
        [Required(ErrorMessage = "You must provide a First Name")]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You must provide a Last Name")]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You must provide Content")]
        public string Resume { get; set; }
        public int Id { get; set; }
    }
}
