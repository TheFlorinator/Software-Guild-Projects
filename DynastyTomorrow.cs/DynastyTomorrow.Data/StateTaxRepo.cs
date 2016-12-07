using DynastyTomorrow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynastyTomorrow.Data
{
    public static class StateTaxRepo
    {
        public static decimal GetStateTax(States stateInput)
        {
            switch (stateInput)
            {
                case States.AK:
                    return 2.5M;
                case States.AL:
                    return 2.5M;
                case States.AR:
                    return 2.5M;
                case States.AZ:
                    return 2.5M;
                case States.CA:
                    return 2.5M;
                case States.CO:
                    return 2.5M;
                case States.CT:
                    return 2.5M;
                case States.DE:
                    return 2.5M;
                case States.FL:
                    return 2.5M;
                case States.GA:
                    return 2.5M;
                case States.HI:
                    return 2.5M;
                case States.IA:
                    return 2.5M;
                case States.ID:
                    return 2.5M;
                case States.IL:
                    return 2.5M;
                case States.IN:
                    return 2.5M;
                case States.KS:
                    return 2.5M;
                case States.KY:
                    return 2.5M;
                case States.LA:
                    return 2.5M;
                case States.MA:
                    return 2.5M;
                case States.MD:
                    return 2.5M;
                case States.ME:
                    return 2.5M;
                case States.MI:
                    return 2.5M;
                case States.MN:
                    return 2.5M;
                case States.MO:
                    return 2.5M;
                case States.MS:
                    return 2.5M;
                case States.MT:
                    return 2.5M;
                case States.NC:
                    return 2.5M;
                case States.ND:
                    return 2.5M;
                case States.NE:
                    return 2.5M;
                case States.NH:
                    return 2.5M;
                case States.NJ:
                    return 2.5M;
                case States.NM:
                    return 2.5M;
                case States.NV:
                    return 2.5M;
                case States.NY:
                    return 2.5M;
                case States.OH:
                    return 2.5M;
                case States.OK:
                    return 2.5M;
                case States.OR:
                    return 2.5M;
                case States.PA:
                    return 2.5M;
                case States.RI:
                    return 2.5M;
                case States.SC:
                    return 2.5M;
                case States.SD:
                    return 2.5M;
                case States.TN:
                    return 2.5M;
                case States.TX:
                    return 2.5M;
                case States.UT:
                    return 2.5M;
                case States.VA:
                    return 2.5M;
                case States.VT:
                    return 2.5M;
                case States.WA:
                    return 2.5M;
                case States.WI:
                    return 2.5M;
                case States.WV:
                    return 2.5M;
                default:
                case States.WY:
                    return 2.5M;
            }
        }
    }
}
