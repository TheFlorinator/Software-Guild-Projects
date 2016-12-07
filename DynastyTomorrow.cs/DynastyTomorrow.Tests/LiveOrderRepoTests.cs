using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DynastyTomorrow.Data;
using DynastyTomorrow.Models;
using System.IO;
using DynastyTomorrow.Models.Responses;
using DynastyTomorrow.BLL;

namespace DynastyTomorrow.Tests
{
    [TestFixture]
    class LiveOrderRepoTests
    {
        private const string _filePath = @"C:\src\softwareGuild\repos\jason-florin-individual-work\DynastyTomorrow.cs\DynastyTomorrow\bin\Debug\OrderRepos\OrderTests.txt";
        private const string _originalData = @"C:\src\softwareGuild\repos\jason-florin-individual-work\DynastyTomorrow.cs\DynastyTomorrow\bin\Debug\OrderRepos\OrderTestsSeed.txt";

        [SetUp]
        public void Setup()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
            File.Copy(_originalData, _filePath);
        }
        [Test]
        public void CanAddOrder()
        {
            FileOrderRepo repo = new FileOrderRepo();
            Order order = new Order();
            order.OrderNumber = "1";
            order.CustomerName = "TesterTest";
            order.State = States.CO;
            order.TaxRate = 1.0M;
            order.Product.Type = ProductType.TILE;
            order.Area = 1000M;
            order.Product.CostPerSquareFoot = 3.0M;
            order.Product.LaborCostPerSquareFoot = 4.9M;
            order.MaterialCost = 500M;
            order.LaborCost = 700M;
            order.TaxOfTotal = 250M;
            order.TotalCost = 7000M;

            repo.AddOrders(order);

            
        }
        [Test]
        public void CanReadDataFile()
        {
            Order newOrder = new Order();
            FileOrderRepo repo = new FileOrderRepo();
            List<Order> orders = repo.LookUpOrders(newOrder);
            Order check = orders[1];

            Assert.AreEqual("2", check.OrderNumber);
            Assert.AreEqual("Tom Florin", check.CustomerName);
            Assert.AreEqual(States.AL, check.State);
            Assert.AreEqual(2.35, check.TaxRate);
            Assert.AreEqual(ProductType.CARPET, check.Product.Type);
            Assert.AreEqual(290, check.Area);
            Assert.AreEqual(3.00, check.Product.CostPerSquareFoot);
            Assert.AreEqual(2.14, check.Product.LaborCostPerSquareFoot);
            Assert.AreEqual(780, check.MaterialCost);
            Assert.AreEqual(900, check.LaborCost);
            Assert.AreEqual(24.50, check.TaxOfTotal);
            Assert.AreEqual(2405.12, check.TotalCost);
        }

        [Test]
        public void CanDeleteStudent()
        {
            FileOrderRepo repo = new FileOrderRepo();

            Order order = new Order();
            order.OrderNumber = "1";
            order.CustomerName = "TesterTest";
            order.State = States.CO;
            order.TaxRate = 1.0M;
            order.Product.Type = ProductType.TILE;
            order.Area = 1000M;
            order.Product.CostPerSquareFoot = 3.0M;
            order.Product.LaborCostPerSquareFoot = 4.9M;
            order.MaterialCost = 500M;
            order.LaborCost = 700M;
            order.TaxOfTotal = 250M;
            order.TotalCost = 7000M;

            repo.AddOrders(order);

            repo.DeleteOrder(order);

            List<Order> orderList = repo.LookUpOrders(order);

            Order check = orderList[1];

            Assert.AreEqual("2", check.OrderNumber);
            Assert.AreEqual("Tom Florin", check.CustomerName);
            Assert.AreEqual(States.AL, check.State);
            Assert.AreEqual(2.35, check.TaxRate);
            Assert.AreEqual(ProductType.CARPET, check.Product.Type);
            Assert.AreEqual(290, check.Area);
            Assert.AreEqual(3.00, check.Product.CostPerSquareFoot);
            Assert.AreEqual(2.14, check.Product.LaborCostPerSquareFoot);
            Assert.AreEqual(780, check.MaterialCost);
            Assert.AreEqual(900, check.LaborCost);
            Assert.AreEqual(24.50, check.TaxOfTotal);
            Assert.AreEqual(2405.12, check.TotalCost);
        }

        [Test]
        public void CanEditStudent()
        {
            Order order = new Order(); //no functionality
            FileOrderRepo repo = new FileOrderRepo();
            List<Order> orderList = repo.LookUpOrders(order);
            
            var newOrder = repo.LookUpIndividualOrder(order);

            newOrder.CustomerName = "Jeffery";

            OrderManager manager = new OrderManager(repo);
            manager.WriteEditedOrder(newOrder);
            repo.LookUpOrders(order);

            Assert.AreEqual("1", newOrder.OrderNumber);
            Assert.AreEqual("Jeffery", newOrder.CustomerName);
            Assert.AreEqual(States.MN, newOrder.State);
            Assert.AreEqual(1.75, newOrder.TaxRate);
            Assert.AreEqual(ProductType.CARPET, newOrder.Product.Type);
            Assert.AreEqual(400, newOrder.Area);
            Assert.AreEqual(2.75, newOrder.Product.CostPerSquareFoot);
            Assert.AreEqual(1.95, newOrder.Product.LaborCostPerSquareFoot);
            Assert.AreEqual(1140, newOrder.MaterialCost);
            Assert.AreEqual(780, newOrder.LaborCost);
            Assert.AreEqual(17.85, newOrder.TaxOfTotal);
            Assert.AreEqual(1984.98, newOrder.TotalCost);
        }

    }
}


