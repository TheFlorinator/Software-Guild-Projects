using MemeConglomerate.Data;
using MemeConglomerate.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeConglomerate.Logic
{
    public class MemeManagerFactory
    {
        public static IRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "Test":
                    return new InMemory();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
