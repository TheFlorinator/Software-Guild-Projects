using ProtalOfLife.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IApplicantRepository
    {
        void AddApplicant(Applicant applicant);
    }
}
