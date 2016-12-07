using DynastyTomorrow.BLL;
using DynastyTomorrow.Models;
using DynastyTomorrow.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynastyTomorrow.WorkFlow
{
    class AddOrderWorkflow
    {
        Order NewOrder = new Order();
        ConsoleIO EditCheck = new ConsoleIO();
        OrderRules addingOrderRules = new OrderRules();
        OrderManager manager = OrderManagerFactory.Builder();

        public void AddingOrder()
        {
            Display();
            GetName();
            GetState();
            GetOrderType();
            GetArea();
            Display();
            EditCheck.DisplayOrderToConsole(NewOrder);
            Continue();
        }

        public void GetName()
        {
            var newName = "";
            do
            {
                newName = EditCheck.GetString("Please enter name: ");
                NewOrder.CustomerName = newName;
            } while (!EditCheck.NullOrEmpty(newName));
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("====================================================");
            Console.WriteLine("|                                                  |");
            Console.WriteLine("|                    Add Order                     |");
            Console.WriteLine("|                                                  |");
            Console.WriteLine("====================================================");
            Console.WriteLine();
        }

        public void GetState()
        {
            string newState = "";
            do
            {
                newState = EditCheck.GetString("Please provide state: ");
            } while (!EditCheck.NullOrEmpty(newState) || !addingOrderRules.StateCheck(newState));
            NewOrder.State = (States)Enum.Parse(typeof(States), newState.ToUpper());
            AddOrderResponse response = manager.StateTaxCheck(NewOrder.State);
            NewOrder.TaxRate = response.Order.TaxRate;
        }

        public void GetOrderType()
        {
            string orderType = "";
            do
            {
                orderType = EditCheck.GetString("Please provide product type: ");
            } while (!EditCheck.NullOrEmpty(orderType) || !addingOrderRules.ProdcutCheck(orderType));
            NewOrder.Product.Type = (ProductType)Enum.Parse(typeof(ProductType), orderType.ToUpper());
            AddOrderResponse response = manager.GetProductInfo(NewOrder.Product.Type);
            NewOrder.Product.CostPerSquareFoot = response.Order.Product.CostPerSquareFoot;
            NewOrder.Product.LaborCostPerSquareFoot = response.Order.Product.LaborCostPerSquareFoot;
        }

        public void GetArea()
        {
            decimal area;
            do
            {
                area = EditCheck.GetDecimalRange("What is the area that needs to be covered: ");

            } while (!addingOrderRules.NumberCheck(area));
            NewOrder.Area = area;

            NewOrder.LaborCost = Calculator.LaborCalculator(NewOrder);
            NewOrder.MaterialCost = Calculator.MaterialCalculator(NewOrder);
            NewOrder.TaxOfTotal = Calculator.TaxCalculator(NewOrder);
            NewOrder.TotalCost = Calculator.TotalCost(NewOrder);
        }

        public void Continue()
        {
            Console.WriteLine("Do you wish to add this order? Y/N");
            string userInput = "";
            do
            {
                userInput = Console.ReadLine();
                if (userInput.ToUpper() == "Y")
                {
                    manager.AddOrder(NewOrder);
                    Console.Clear();
                }
                else if (userInput.ToUpper() == "N")
                {
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (!EditCheck.QuestionAnswer(userInput));
        }
    }
}
