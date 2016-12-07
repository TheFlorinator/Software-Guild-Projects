using ProtalOfLife.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Data.Models
{
    [Serializable]
    [XmlRoot ("ApplicationDatabase")]
    public class ApplicantContainer
    {
        public List<Applicant> ApplicationList { get; set; }

        public ApplicantContainer()
        {
            ApplicationList = new List<Applicant>();
        }
    }
}
