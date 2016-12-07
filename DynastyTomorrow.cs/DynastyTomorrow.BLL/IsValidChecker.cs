using DynastyTomorrow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynastyTomorrow.BLL
{
    public class IsValidChecker
    {
        public Order ValidOrderChecker(Order newOrder)
        {
            if (string.IsNullOrEmpty(newOrder.CustomerName))
            {
                newOrder.IsValid = false;
            }
            else if (newOrder.State == States.noState)
            {
                newOrder.IsValid = false;
            }
            else if (newOrder.Product.Type == ProductType.noProductType)
            {
                newOrder.IsValid = false;
            }
            else if (newOrder.Area < 0)
            {
                newOrder.IsValid = false;
            }
            else
            {
                newOrder.IsValid = true;
                
            }
            return newOrder;
        }
    }
}
