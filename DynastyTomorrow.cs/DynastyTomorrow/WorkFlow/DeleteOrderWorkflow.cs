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
    public class DeleteOrderWorkflow
    {
        OrderManager manager = OrderManagerFactory.Builder();
        ConsoleIO displayManager = new ConsoleIO();
        Order order = new Order();
       
        public void EnterDeleteOrder()
        {
            Display();
            Console.Write("   Please enter date to search: ");
            order.Date = Console.ReadLine();
            Console.Write("   Enter Order Number: ");
            order.OrderNumber = Console.ReadLine();
            Display();
            SuccessOrNot();
            
        }
        public void Continue()
        {
            Console.WriteLine("Delete this order Y/N");
            string userInput = "";
            do
            {
                userInput = Console.ReadLine();
                if (userInput.ToUpper() == "Y")
                {
                    manager.DeletingOrder(order);
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

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("====================================================");
            Console.WriteLine("|                                                  |");
            Console.WriteLine("|                   Delete Order                   |");
            Console.WriteLine("|                                                  |");
            Console.WriteLine("====================================================");
            Console.WriteLine();
        }

        public void SuccessOrNot()
        {
            OrderResponse response = manager.DisplaySingleOrder(order);
            if (response.Success)
            {
                displayManager.DisplayOrderToConsole(response.Order);
                Continue();
            }
            else
            {
                Console.WriteLine(response.Message);
                Console.ReadKey();
                Console.Clear();
                return;
            }
        }
       
    }
}
