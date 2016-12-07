using DynastyTomorrow.Models;
using DynastyTomorrow.WorkFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynastyTomorrow
{
    public class ConsoleIO
    {
        public void DisplayListToConsole(List<Order> orders)
        {
            foreach (var order in orders)
            {
                Console.WriteLine($"   Order Number: {order.OrderNumber}");
                Console.WriteLine($"   Customer Name: {order.CustomerName}");
                Console.WriteLine($"   State: {order.State}");
                Console.WriteLine($"   Tax Rate: {order.TaxRate}");
                Console.WriteLine($"   Product Type: {order.Product.Type}");
                Console.WriteLine($"   Product Area: {order.Area}");
                Console.WriteLine($"   Product cost per square foot: {order.Product.CostPerSquareFoot}");
                Console.WriteLine($"   Labor cost per square foot: {order.Product.LaborCostPerSquareFoot}");
                Console.WriteLine($"   Material Cost: {order.MaterialCost}");
                Console.WriteLine($"   Labor Cost: {order.LaborCost}");
                Console.WriteLine($"   Total Tax: {order.TaxOfTotal}");
                Console.WriteLine($"   Total Cost: {order.TotalCost}");
                Console.WriteLine();
                Console.WriteLine("******* Press enter to see next customer... ********");
                Console.ReadKey();
                Console.Clear();
                LookUpOrderWorkflow.Display();
                Console.WriteLine();

            }
        }

        public void DisplayOrderToConsole(Order order)
        {
            Console.WriteLine($"   Order Number: {order.OrderNumber}");
            Console.WriteLine($"   Customer Name: {order.CustomerName}");
            Console.WriteLine($"   State: {order.State}");
            Console.WriteLine($"   Tax Rate: {order.TaxRate}");
            Console.WriteLine($"   Product Type: {order.Product.Type}");
            Console.WriteLine($"   Product Area: {order.Area}");
            Console.WriteLine($"   Product cost per square foot: {order.Product.CostPerSquareFoot}");
            Console.WriteLine($"   Labor cost per square foot: {order.Product.LaborCostPerSquareFoot}");
            Console.WriteLine($"   Material Cost: {order.MaterialCost}");
            Console.WriteLine($"   Labor Cost: {order.LaborCost}");
            Console.WriteLine($"   Total Tax: {order.TaxOfTotal}");
            Console.WriteLine($"   Total Cost: {order.TotalCost}");
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine();
        }
        public string GetString(string prompt)
        {
            Console.Write(prompt);
            string userInput = Console.ReadLine();
            return userInput;
        }

        public decimal GetDecimalRange(string prompt)
        {
            Console.Write(prompt);
            bool numberSwitch;
            decimal number;
            
            do
            {
                string userInput = Console.ReadLine();
                numberSwitch = decimal.TryParse(userInput, out number);
                Console.Write("Please provide a number: ");
            } while (numberSwitch == false);
            
                
            
            return number;
        }

        public bool QuestionAnswer(string userInput)
        {
            bool yup = false;
                if (userInput.ToUpper().Contains("Y"))
                {
                    return yup = true;
                }
                else if (userInput.ToUpper().Contains("N"))
                {
                    return yup = true;
                }
            return yup;
        }

        public bool NullOrEmpty(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Please provide valid input");
                return false;
            }
            return true;
        }

    }
}
