using DynastyTomorrow.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynastyTomorrow.BLL
{
    public static class OrderManagerFactory
    {
        public static OrderManager Builder()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "BasicTest":
                    return new OrderManager(new TestOrderRepo());
                case "LiveTest":
                    return new OrderManager(new FileOrderRepo());
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
