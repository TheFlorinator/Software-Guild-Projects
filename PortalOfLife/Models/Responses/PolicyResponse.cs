using ProtalOfLife.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtalOfLife.Models.Responses
{
    public class PolicyResponse : Repsonse
    {
        public Policy NewPolicy { get; set; }

        public PolicyResponse()
        {
            NewPolicy = new Policy();
        }
    }
}
