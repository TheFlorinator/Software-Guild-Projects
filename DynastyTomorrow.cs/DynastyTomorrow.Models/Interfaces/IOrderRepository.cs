using DynastyTomorrow.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynastyTomorrow.Models.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> LookUpOrders(Order newOrder);
        bool AddOrders(Order newOrder);
        Order LookUpIndividualOrder(Order newOrder);
        bool WriteOrders(Order order);
        bool DeleteOrder(Order order);
    }
}
