using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBlogToRestart.Data;
using TheBlogToRestart.Models;

namespace TheBlogToRestart.Logic
{
    public class RulesFactory
    {
        public static IRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "Test":
                    return new InMemoryRepo();
                case "Live":
                    return new LiveRepo();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
