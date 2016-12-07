using DynastyTomorrow.BLL;
using DynastyTomorrow.Models;
using DynastyTomorrow.Models.Responses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynastyTomorrow.Tests
{
    [TestFixture]
    class InMemoryOrderRepoTests
    {
        [TestCase("1", "Tom", States.MN, 2.5, ProductType.CARPET, 100, 2.5, 2.75, 25, 27.50, 25.75, 175.00, true)] //13
        [TestCase("1", "Tom", States.MN, 2.5, ProductType.noProductType, 100, 2.5, 2.75, 25, 27.50, 25.75, 175.00, false)]
        [TestCase("1", "", States.MN, 2.5, ProductType.CARPET, 100, 2.5, 2.75, 25, 27.50, 25.75, 175.00, false)]
        [TestCase("1", "Tom", States.noState, 2.5, ProductType.CARPET, 100, 2.5, 2.75, 25, 27.50, 25.75, 175.00, false)]
        [TestCase("1", "Tom", States.MN, 2.5, ProductType.CARPET, 100, 2.5, 2.75, 25, 27.50, 25.75, 175.00, true)]
        [TestCase("1", "Tom", States.MN, 2.5, ProductType.CARPET, 100, 2.5, 2.75, 25, 27.50, 25.75, 175.00, true)]

        public void IsAValidOrder(string accountNumber, string name, States state, decimal taxRate, ProductType productType, decimal area, decimal perFootCost, decimal labor, decimal materialCost, decimal lanorCost, decimal tax, decimal total, bool expectedResult)
        {
            OrderManager manager = OrderManagerFactory.Builder();
            IsValidChecker isValidOrder = new IsValidChecker();
            Order order = new Order();
            order.OrderNumber = accountNumber;
            order.CustomerName = name;
            order.State = state;
            order.TaxRate = taxRate;
            order.Product.Type = productType;
            order.Area = area;
            order.Product.CostPerSquareFoot = perFootCost;
            order.Product.LaborCostPerSquareFoot = labor;
            order.MaterialCost = materialCost;
            order.LaborCost = lanorCost;
            order.TaxOfTotal = tax;
            order.TotalCost = total;
            isValidOrder.ValidOrderChecker(order);
            Assert.AreEqual(expectedResult, order.IsValid);
        }

        [Test]
        public void CanDisplayAccount()
        {
            Order newOrder = new Order();
            OrderManager manager = OrderManagerFactory.Builder();
            LookUpOrderResponse response = manager.LookUpOrderList(newOrder);
            Assert.IsNotNull(response.OrderList);
            Assert.IsTrue(response.Success);
        }

        [TestCase("1", "Jon", "10102016", true)]
        [TestCase("2", "Hannah", "10102016", true)]
        [TestCase("3", "Jess", "10102016", true)]
        [TestCase("1", "", "10102016", false)]
        [TestCase("2", "", "10102016", false)]

        public void CanEditOrder(string accountNumber, string name, string date, bool expectedResult)
        {
            OrderManager manager = OrderManagerFactory.Builder();
            OrderResponse oldOrder = new OrderResponse();
            OrderResponse newOrder = new OrderResponse();
            oldOrder.Order.OrderNumber = accountNumber;
            oldOrder.Order.Date = date;
            oldOrder = manager.DisplaySingleOrder(oldOrder.Order);
            newOrder.Order.CustomerName = name;
            oldOrder.Order.CustomerName = newOrder.Order.CustomerName;
            oldOrder = manager.WriteEditedOrder(oldOrder.Order);

            Assert.AreEqual(expectedResult, oldOrder.Success);


        }

        [TestCase("1", "Tom", States.MN, 2.5, ProductType.CARPET, 100, 2.5, 2.75, 25, 27.50, 25.75, 175.00, "10102016", true)] //13
        [TestCase("1", "Tom", States.MN, 2.5, ProductType.noProductType, 100, 2.5, 2.75, 25, 27.50, 25.75, 175.00, "10102016",false)]
        [TestCase("1", "", States.MN, 2.5, ProductType.CARPET, 100, 2.5, 2.75, 25, 27.50, 25.75, 175.00, "10102016", false)]
        [TestCase("1", "Tom", States.noState, 2.5, ProductType.CARPET, 100, 2.5, 2.75, 25, 27.50, 25.75, 175.00, "10102016", false)]
        [TestCase("1", "Tom", States.MN, 2.5, ProductType.CARPET, 100, 2.5, 2.75, 25, 27.50, 25.75, 175.00, "10102016", true)]
        [TestCase("1", "Tom", States.MN, 2.5, ProductType.CARPET, 100, 2.5, 2.75, 25, 27.50, 25.75, 175.00, "10102016", true)]

        public void CanAddOrder(string accountNumber, string name, States state, decimal taxRate, ProductType productType, decimal area, decimal perFootCost, decimal labor, decimal materialCost, decimal lanorCost, decimal tax, decimal total, string date, bool expectedResult)
        {
            
            OrderManager manager = OrderManagerFactory.Builder();
            Order order = new Order();
            order.OrderNumber = accountNumber;
            order.CustomerName = name;
            order.State = state;
            order.TaxRate = taxRate;
            order.Product.Type = productType;
            order.Area = area;
            order.Product.CostPerSquareFoot = perFootCost;
            order.Product.LaborCostPerSquareFoot = labor;
            order.MaterialCost = materialCost;
            order.LaborCost = lanorCost;
            order.TaxOfTotal = tax;
            order.TotalCost = total;
            order.Date = date;
            manager.AddOrder(order);
            Assert.AreEqual(expectedResult, order.IsValid);
        }
        [TestCase("1", "10102016", true)]
        [TestCase("2", "10102016", true)]
        [TestCase("3", "10102016", true)]

        public void CanDelete(string orderNUmber, string orderDate, bool expectedResults)
        {
            OrderManager manager = OrderManagerFactory.Builder();
            OrderResponse orderToDelete = new OrderResponse();
            OrderResponse orderList = new OrderResponse();
            orderToDelete.Order.OrderNumber = orderNUmber;
            orderToDelete.Order.Date = orderDate;
            orderList.Order.Date = "10102016";
            orderToDelete = manager.DisplaySingleOrder(orderToDelete.Order);
            manager.DeletingOrder(orderToDelete.Order);
            LookUpOrderResponse response = manager.LookUpOrderList(orderList.Order);
            response.OrderList.Count();
            Assert.AreEqual(expectedResults, response.Success);

        }
    }
}
