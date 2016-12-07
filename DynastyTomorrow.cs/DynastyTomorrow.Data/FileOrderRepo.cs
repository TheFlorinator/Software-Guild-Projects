using DynastyTomorrow.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynastyTomorrow.Models;
using System.IO;
using DynastyTomorrow.Models.Responses;

namespace DynastyTomorrow.Data
{
    public class FileOrderRepo : IOrderRepository
    {
        const string FilePath = @"C:\src\softwareGuild\repos\jason-florin-individual-work\DynastyTomorrow.cs\DynastyTomorrow\bin\Debug\OrderRepos\Orders_";
        public int NumberOfOrders = 0;

        public List<Order> LookUpOrders(Order order)
        {
            List<Order> orderList = new List<Order>();
            string fileLocation = string.Format("{0}{1}{2}", FilePath, order.Date, ".txt");
            if (File.Exists(fileLocation))
            {
                orderList = ReadFile(order);
                return orderList;
            }
            else
            {
                return null;
            }
        }

        public Order LookUpIndividualOrder(Order newOrder)
        {
            string fileLocation = string.Format("{0}{1}{2}", newOrder.Date, newOrder.OrderNumber, ".txt");
            var orderList = LookUpOrders(newOrder);
            if (orderList == null)
            {
                return null;
            }
            foreach (var order in orderList)
            {
                if (newOrder.OrderNumber == order.OrderNumber)
                {
                    return newOrder = order;
                }
            }
            return newOrder;
        }

        public bool DeleteOrder(Order order)
        {
            OrderResponse response = new OrderResponse();
            int orderCounter = 1;
            string fileLocation = string.Format("{0}{1}{2}", FilePath, order.Date, ".txt");
            var allOrders = ReadFile(order);
            using (StreamWriter sw = new StreamWriter(fileLocation))
            {
                sw.Write("OrderNumber|?|CustomerName|?|State|?|TaxRate|?|ProductType|?|Area|?|CostPerSquareFoot|?|LaborCostPerSquareFoot|?|MaterialCost|?|LaborCost|?|Tax|?|Total");
                sw.WriteLine();
                foreach (var item in allOrders)
                {
                    if (item.OrderNumber == order.OrderNumber)
                    {
                        return true;
                    }
                    else
                    {
                        sw.Write($"{item.OrderNumber = $"{orderCounter}"}|?|{item.CustomerName}|?|{item.State}|?|{item.TaxRate}|?|{item.Product.Type}|?|{item.Area}|?|{item.Product.CostPerSquareFoot}|?|{item.Product.LaborCostPerSquareFoot}|?|{item.MaterialCost}|?|{item.LaborCost}|?|{item.TaxOfTotal}|?|{item.TotalCost}|?|{item.Date}");
                        sw.WriteLine();
                        orderCounter++;
                        return false;
                    }
                }
            }
            return false;
        }

        public bool WriteOrders(Order order)
        {
            string fileLocation = string.Format("{0}{1}{2}", FilePath, order.Date, ".txt");
            var allOrders = ReadFile(order);
            using (StreamWriter sw = new StreamWriter(fileLocation))
            {
                sw.Write("OrderNumber|?|CustomerName|?|State|?|TaxRate|?|ProductType|?|Area|?|CostPerSquareFoot|?|LaborCostPerSquareFoot|?|MaterialCost|?|LaborCost|?|Tax|?|Total|?|Date");
                sw.WriteLine();
                foreach (var item in allOrders)
                {
                    if (item.OrderNumber == order.OrderNumber)
                    {
                        sw.Write($"{order.OrderNumber}|?|{order.CustomerName}|?|{order.State}|?|{order.TaxRate}|?|{order.Product.Type}|?|{order.Area}|?|{order.Product.CostPerSquareFoot}|?|{order.Product.LaborCostPerSquareFoot}|?|{order.MaterialCost}|?|{order.LaborCost}|?|{order.TaxOfTotal}|?|{order.TotalCost}|?|{order.Date}");
                        sw.WriteLine();
                    }
                    else
                    {
                        sw.Write($"{item.OrderNumber}|?|{item.CustomerName}|?|{item.State}|?|{item.TaxRate}|?|{item.Product.Type}|?|{item.Area}|?|{item.Product.CostPerSquareFoot}|?|{item.Product.LaborCostPerSquareFoot}|?|{item.MaterialCost}|?|{item.LaborCost}|?|{item.TaxOfTotal}|?|{item.TotalCost}|?|{item.Date}");
                        sw.WriteLine();
                    }
                }
            }
            return false;
        }

        public bool AddOrders(Order newOrder)
        {
            AddOrderResponse response = new AddOrderResponse();
            int counter = 1;
            newOrder.Date = DateTime.Now.ToString("MMddyyyy");
            string fileLocation = string.Format("{0}{1}{2}", FilePath, newOrder.Date, ".txt");
            if (File.Exists(fileLocation))
            {
                var orderList = ReadFile(newOrder);
                using (StreamWriter sw = new StreamWriter(fileLocation))
                {
                    sw.Write("OrderNumber|?|CustomerName|?|State|?|TaxRate|?|ProductType|?|Area|?|CostPerSquareFoot|?|LaborCostPerSquareFoot|?|MaterialCost|?|LaborCost|?|Tax|?|Total|?|Date");
                    sw.WriteLine();
                    foreach (var order in orderList)
                    {
                        sw.Write($"{order.OrderNumber}|?|{order.CustomerName}|?|{order.State}|?|{order.TaxRate}|?|{order.Product.Type}|?|{order.Area}|?|{order.Product.CostPerSquareFoot}|?|{order.Product.LaborCostPerSquareFoot}|?|{order.MaterialCost}|?|{order.LaborCost}|?|{order.TaxOfTotal}|?|{order.TotalCost}|?|{order.Date}");
                        sw.WriteLine();
                        counter++;
                    }
                    sw.Write($"{newOrder.OrderNumber = $"{counter}"}|?|{newOrder.CustomerName}|?|{newOrder.State}|?|{newOrder.TaxRate}|?|{newOrder.Product.Type}|?|{newOrder.Area}|?|{newOrder.Product.CostPerSquareFoot}|?|{newOrder.Product.LaborCostPerSquareFoot}|?|{newOrder.MaterialCost}|?|{newOrder.LaborCost}|?|{newOrder.TaxOfTotal}|?|{newOrder.TotalCost}|?|{newOrder.Date}");
                }
                return true;
            }
            else if(!File.Exists(fileLocation))
            {
                using (StreamWriter sw = File.CreateText(fileLocation))
                {
                    sw.Write("OrderNumber|?|CustomerName|?|State|?|TaxRate|?|ProductType|?|Area|?|CostPerSquareFoot|?|LaborCostPerSquareFoot|?|MaterialCost|?|LaborCost|?|Tax|?|Total|?|Date");
                    sw.WriteLine();
                    sw.Write($"{newOrder.OrderNumber = "1"}|?|{newOrder.CustomerName}|?|{newOrder.State}|?|{newOrder.TaxRate}|?|{newOrder.Product.Type}|?|{newOrder.Area}|?|{newOrder.Product.CostPerSquareFoot}|?|{newOrder.Product.LaborCostPerSquareFoot}|?|{newOrder.MaterialCost}|?|{newOrder.LaborCost}|?|{newOrder.TaxOfTotal}|?|{newOrder.TotalCost}|?|{newOrder.Date}");
                }
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public void SaveOrders(List<Order> order)
        {
            throw new NotImplementedException();
        }

        public List<Order> ReadFile(Order newOrder)
        {
            string fileLocation = string.Format("{0}{1}{2}", FilePath, newOrder.Date, ".txt");
            List<Order> orderList = new List<Order>();
            using (StreamReader reader = new StreamReader(fileLocation))
            {
                string lines;
                string[] delimeter = new string[] { "|?|" };
                lines = reader.ReadLine();
                while ((lines = reader.ReadLine()) != null)
                {
                    Order order = new Order();
                    string[] split = lines.Split(delimeter, StringSplitOptions.None);
                    order.OrderNumber = split[0];
                    order.CustomerName = split[1];
                    order.State = (States)Enum.Parse(typeof(States), split[2]);
                    order.TaxRate = decimal.Parse(split[3]);
                    order.Product.Type = (ProductType)Enum.Parse(typeof(ProductType), split[4]);
                    order.Area = decimal.Parse(split[5]);
                    order.Product.CostPerSquareFoot = decimal.Parse(split[6]);
                    order.Product.LaborCostPerSquareFoot = decimal.Parse(split[7]);
                    order.MaterialCost = decimal.Parse(split[8]);
                    order.LaborCost = decimal.Parse(split[9]);
                    order.TaxOfTotal = decimal.Parse(split[10]);
                    order.TotalCost = decimal.Parse(split[11]);
                    order.Date = split[12];
                    orderList.Add(order);
                    NumberOfOrders++;
                }
            }
            return orderList;
        }
    }
}
