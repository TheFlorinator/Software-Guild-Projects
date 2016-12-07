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
    public class EditOrderWorkflow
    {
        //not displaying order
        bool YesorNo;
        ConsoleIO EditOrderManager = new ConsoleIO();
        OrderRules OrderingRule = new OrderRules();
        AddOrderResponse totalResponse = new AddOrderResponse();
        OrderManager manager = OrderManagerFactory.Builder();
        OrderResponse response = new OrderResponse();
        ConsoleIO displayManager = new ConsoleIO();
        Order newOrder = new Order();
    
        public void CreateEditWorkflow()
        {

            Display();
            SearchAccount();
            Display();
            if (SuccessOrNot())
            {
                Console.Clear();
                return;
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadKey();
            Display();
            NameChange();
            Display();
            StateChange();
            Display();
            ProductChange();
            Display();
            AreaChange();
            Display();
            EditOrderManager.DisplayOrderToConsole(response.Order);
            Continue();
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("====================================================");
            Console.WriteLine("|                                                  |");
            Console.WriteLine("|                    Edit Order                    |");
            Console.WriteLine("|                                                  |");
            Console.WriteLine("====================================================");
            Console.WriteLine();
        }

        public void SearchAccount()
        {
            Console.Write("   Please enter date to search: ");
            string dateSearch = Console.ReadLine();
            newOrder.Date = dateSearch;
            Console.Write("   Enter Order Number: ");
            string orderNumber = Console.ReadLine();
            newOrder.OrderNumber = orderNumber;
            response = manager.DisplaySingleOrder(newOrder);
        }

        public void NameChange()
        {
            do
            {
                Console.WriteLine("Begin typing if you wish to change field, or press enter to continue");
                Console.WriteLine();
                Console.WriteLine($@"Current Name:({response.Order.CustomerName})");
                Console.Write("Name change: ");
                string nameInput = Console.ReadLine();
                if (string.IsNullOrEmpty(nameInput))
                {
                    break;
                }
                else
                {
                    response.Order.CustomerName = nameInput;
                    YesorNo = false;
                }
            } while (YesorNo);
            Console.Clear();
        }

        public void StateChange()
        {
            string stateInput = "";
            do
            {
                Console.WriteLine($"Current state: ({response.Order.State})");
                Console.Write("State Change: ");
                stateInput = Console.ReadLine();
                if (string.IsNullOrEmpty(stateInput))
                {
                    break;
                }
                response.Order.State = (States)Enum.Parse(typeof(States), stateInput.ToUpper());
            } while (!OrderingRule.StateCheck(stateInput));
            totalResponse = manager.StateTaxCheck(response.Order.State);
            response.Order.TaxRate = totalResponse.Order.TaxRate;
        }

        public void ProductChange()
        {
            do
            {
                Console.WriteLine($"Current Product: ({response.Order.Product.Type})");
                Console.Write("Product Change: ");
                string productTypeInput = Console.ReadLine();
                if (string.IsNullOrEmpty(productTypeInput))
                {
                    break;
                }
                else
                {
                    response.Order.Product.Type = (ProductType)Enum.Parse(typeof(ProductType), productTypeInput.ToUpper());
                    totalResponse = manager.GetProductInfo(response.Order.Product.Type);
                    response.Order.Product.CostPerSquareFoot = totalResponse.Order.Product.CostPerSquareFoot;
                    response.Order.Product.LaborCostPerSquareFoot = totalResponse.Order.Product.LaborCostPerSquareFoot;
                    YesorNo = false;
                }
            } while (YesorNo);
        }

        public void AreaChange()
        {
            do
            {
                Console.WriteLine($"Current Area: ({response.Order.Area})");
                Console.Write("Area Change: ");
                string areaInput = Console.ReadLine();
                if (string.IsNullOrEmpty(areaInput))
                {
                    break;
                }
                else
                {
                    response.Order.Area = decimal.Parse(areaInput);

                }

            } while (YesorNo);
            response.Order.LaborCost = Calculator.LaborCalculator(response.Order);
            response.Order.MaterialCost = Calculator.MaterialCalculator(response.Order);
            response.Order.TaxOfTotal = Calculator.TaxCalculator(response.Order);
            response.Order.TotalCost = Calculator.TotalCost(response.Order);
        }

        public void Continue()
        {
            Console.Write("Do you with to save these changes? Y/N: ");
            string userInput = "";
            do
            {
                userInput = Console.ReadLine();
                if (userInput.ToUpper() == "Y")
                {
                    manager.WriteEditedOrder(response.Order);
                    Console.Clear();
                }
                else if (userInput.ToUpper() == "N")
                {
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (!displayManager.QuestionAnswer(userInput));
        }

        public bool SuccessOrNot()
        {
            if (response.Success)
            {
                EditOrderManager.DisplayOrderToConsole(response.Order);
                newOrder.Date = response.Order.Date;
                return false;
            }
            else
            {
                Console.WriteLine($"An error occurred:");
                Console.WriteLine(response.Message);
                Console.ReadLine();
                return true;
            }
        }
    }
}
