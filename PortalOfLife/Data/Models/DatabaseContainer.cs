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
    [XmlRoot("Database")]
    public class DatabaseContainer
    {
        public List<Category> Categories { get; set; }

        public DatabaseContainer()
        {
            Categories = new List<Category>();
        }
    }
}
