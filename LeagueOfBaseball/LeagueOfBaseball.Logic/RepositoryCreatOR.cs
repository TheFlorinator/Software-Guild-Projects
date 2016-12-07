using LeagueOfBaseball.Data;
using LeagueOfBaseball.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfBaseball.Logic
{
    public class RepositoryCreatOR
    {
        public static IRepository Synthesize()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "InMemory":
                    return new InMemoryRepo();
                case "Dapper":
                    return new DapperRepo();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
