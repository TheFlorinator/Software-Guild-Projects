using ProtalOfLife.Models.Data;
using ProtalOfLife.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtalOfLife.Models.Responses
{
    public class CategoryResponse : Repsonse
    {
        public Category NewCategory { get; set; }

        public CategoryResponse()
        {
            NewCategory = new Category();
        }
    }
}
