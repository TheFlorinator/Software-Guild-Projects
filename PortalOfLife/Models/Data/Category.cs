using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProtalOfLife.Models.Data
{
    [Serializable]
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You must provide a name!")]
        [StringLength(50)]
        public string Name { get; set; }
        public List<Policy> Policies {get; set;}
        public bool isValid { get; set; }

        public Category()
        {
            Policies = new List<Policy>();
        }
    }
}