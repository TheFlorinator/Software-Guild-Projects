using DynastyTomorrow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynastyTomorrow.BLL
{
    public class OrderRules
    {
        public bool StateCheck(string stateInput)
        {
            string state = stateInput.ToUpper();
            switch (state)
            {
                case "AK":
                    return true;
                case "AL":
                    return true;
                case "AR":
                    return true;
                case "AZ":
                    return true;
                case "CA":
                    return true;
                case "CO":
                    return true;
                case "CT":
                    return true;
                case "DE":
                    return true;
                case "FL":
                    return true;
                case "GA":
                    return true;
                case "HI":
                    return true;
                case "IA":
                    return true;
                case "ID":
                    return true;
                case "IL":
                    return true;
                case "IN":
                    return true;
                case "KS":
                    return true;
                case "KY":
                    return true;
                case "LA":
                    return true;
                case "MA":
                    return true;
                case "MD":
                    return true;
                case "ME":
                    return true;
                case "MI":
                    return true;
                case "MN":
                    return true;
                case "MO":
                    return true;
                case "MS":
                    return true;
                case "MT":
                    return true;
                case "NC":
                    return true;
                case "ND":
                    return true;
                case "NE":
                    return true;
                case "NH":
                    return true;
                case "NJ":
                    return true;
                case "NM":
                    return true;
                case "NV":
                    return true;
                case "NY":
                    return true;
                case "OH":
                    return true;
                case "OK":
                    return true;
                case "OR":
                    return true;
                case "PA":
                    return true;
                case "RI":
                    return true;
                case "SC":
                    return true;
                case "SD":
                    return true;
                case "TN":
                    return true;
                case "TX":
                    return true;
                case "UT":
                    return true;
                case "VA":
                    return true;
                case "VT":
                    return true;
                case "WA":
                    return true;
                case "WI":
                    return true;
                case "WV":
                    return true;
                case "WY":
                    return true;
                default:
                    return false;
            }
        }

        public bool ProdcutCheck(string productInput)
        {
            string product = productInput.ToUpper();
            switch (product)
            {
                case "CARPET":
                    return true;
                case "LAMINATE":
                    return true;
                case "TILE":
                    return true;
                case "WOOD":
                    return true;
                default:
                    return false;
            }
        }

        public bool NumberCheck(decimal area)
        {
            if (area > 0)
            {
                return true;
            }
            return false;
        }
    }
}
