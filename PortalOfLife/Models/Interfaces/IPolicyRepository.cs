using ProtalOfLife.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IPolicyRepository
    {
        IEnumerable<Policy> GetAll();
        Policy Get(Policy policy);
        void Add(Policy policy);
        void Delete(int policyId);
        void Edit(Policy policy);
    }
}
