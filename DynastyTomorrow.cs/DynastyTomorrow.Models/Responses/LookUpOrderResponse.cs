using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynastyTomorrow.Models.Responses
{
    public class LookUpOrderResponse : Response
    {
        public List<Order> OrderList { get; set; }
    }
}
