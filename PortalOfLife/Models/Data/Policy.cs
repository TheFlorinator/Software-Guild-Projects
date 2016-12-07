using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProtalOfLife.Models.Data
{
    [Serializable]
    public class Policy
    {
        [Required(ErrorMessage = "You must provide a name!")]
        [StringLength(20)]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "You must provide content!")]
        public string Content { get; set; }
        public bool isValid { get; set; }
    }
}