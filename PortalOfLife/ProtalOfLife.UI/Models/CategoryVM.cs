using ProtalOfLife.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProtalOfLife.UI.Models
{
    public class CategoryVM
    {
        public IEnumerable<Category> CategoryList { get; set; }
        public Category Category { get; set; }
    }
}