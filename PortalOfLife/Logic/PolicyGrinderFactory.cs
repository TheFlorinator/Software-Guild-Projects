using Data.Repos;
using ProtalOfLife.Data.Repos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class PolicyGrinderFactory
    {
        public static PolicyGrinder Synthesize()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "InMemoryTest":
                    return new PolicyGrinder(new CategoryRepo(), new LiveApplicantRepo());
                case "LiveTest":
                    return new PolicyGrinder(new LiveRepo(), new LiveApplicantRepo());
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
