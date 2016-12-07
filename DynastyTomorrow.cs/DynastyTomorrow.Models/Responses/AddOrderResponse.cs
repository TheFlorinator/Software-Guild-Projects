using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynastyTomorrow.Models.Responses
{
    public class AddOrderResponse : Response
    {
        public Order Order { get; set; }

        public AddOrderResponse()
        {
            Order = new Order();
        }
    }
}
