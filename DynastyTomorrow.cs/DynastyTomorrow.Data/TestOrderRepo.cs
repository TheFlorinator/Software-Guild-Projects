using DynastyTomorrow.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynastyTomorrow.Models;
using DynastyTomorrow.Models.Responses;

namespace DynastyTomorrow.Data
{
    public class TestOrderRepo : IOrderRepository
    {
        private static readonly List<Order> orderList = new List<Order>();

        static TestOrderRepo()
        {
            Order order1 = new Order();
            order1.OrderNumber = "1";
            order1.CustomerName = "Jason";
            order1.State = States.MN;
            order1.TaxRate = 2.5M;
            order1.Product.Type = ProductType.CARPET;
            order1.Area = 400M;
            order1.Product.CostPerSquareFoot = 2.5M;
            order1.Product.LaborCostPerSquareFoot = 1.5M;
            order1.MaterialCost = 4.5M;
            order1.LaborCost = 450M;
            order1.TaxOfTotal = 25.34M;
            order1.TotalCost = 455.34M;
            order1.Date = "10102016";
            orderList.Add(order1);
            

            Order order2 = new Order();
            order2.OrderNumber = "2";
            order2.CustomerName = "Heidi";
            order2.State = States.TX;
            order2.TaxRate = 2.5M;
            order2.Product.Type = ProductType.TILE;
            order2.Area = 100M;
            order2.Product.CostPerSquareFoot = 2.5M;
            order2.Product.LaborCostPerSquareFoot = 1.5M;
            order2.MaterialCost = 4.5M;
            order2.LaborCost = 150M;
            order2.TaxOfTotal = 25.34M;
            order2.TotalCost = 500M;
            order2.Date = "10102016";
            orderList.Add(order2);

            Order order3 = new Order();
            order3.OrderNumber = "3";
            order3.CustomerName = "Hannah";
            order3.State = States.WA;
            order3.TaxRate = 2.5M;
            order3.Product.Type = ProductType.WOOD;
            order3.Area = 100M;
            order3.Product.CostPerSquareFoot = 2.5M;
            order3.Product.LaborCostPerSquareFoot = 1.5M;
            order3.MaterialCost = 4.5M;
            order3.LaborCost = 700M;
            order3.TaxOfTotal = 15.65M;
            order3.TotalCost = 143M;
            order3.Date = "10102016";
            orderList.Add(order3);
        }
      
        public bool AddOrders(Order newOrder)
        {
            if (newOrder.Date == "10102016")
            {
                orderList.Add(newOrder);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteOrder(Order newOrder)
        {
            if (orderList.Any(o => o.OrderNumber == newOrder.OrderNumber))
            {
                orderList.RemoveAll(order => order.OrderNumber == newOrder.OrderNumber);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Order LookUpIndividualOrder(Order newOrder)
        {
            return orderList.FirstOrDefault(order => order.OrderNumber == newOrder.OrderNumber);
        }

        public List<Order> LookUpOrders(Order order)
        {
            return orderList.Where(o => o.Date == order.Date).ToList();
        }

        public bool WriteOrders(Order order)
        {
            bool writeOrder = true;
            OrderResponse newOrder = new OrderResponse();
            for (int i = 0; i < orderList.Count; i++)
            {
                if (order.OrderNumber == orderList[i].OrderNumber)
                {
                    orderList[i] = order;
                }
            }
            return writeOrder;
        }
    }
}
