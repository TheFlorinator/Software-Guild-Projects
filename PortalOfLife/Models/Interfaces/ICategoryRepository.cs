using ProtalOfLife.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category Get(string name);
        bool AddCategory(Category category);
        bool AddPolicy(Policy policy);
        bool RemovePolicy(Policy policy);
        Policy GetPolicy(Policy policy);
        bool DeleteCategory(string name);
    }
}
