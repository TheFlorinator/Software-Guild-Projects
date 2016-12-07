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
    public class LookUpOrderWorkflow
    {
        ConsoleIO displayManager = new ConsoleIO();
        Order newOrder = new Order();

        public void TheBeginningOfTheEnd()
        {
            OrderManager manager = OrderManagerFactory.Builder();
            Display();
            Console.WriteLine("   Format needs to be MMDDYEAR");
            Console.Write("   Enter Date: ");
            newOrder.Date = Console.ReadLine();
            Console.WriteLine();
            SuccessOrNot(manager);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public static void Display()
        {
            Console.Clear();
            Console.WriteLine("====================================================");
            Console.WriteLine("|                                                  |");
            Console.WriteLine("|                  Display Order                   |");
            Console.WriteLine("|                                                  |");
            Console.WriteLine("====================================================");
            Console.WriteLine();
        }

        public void SuccessOrNot(OrderManager manager)
        {
            LookUpOrderResponse response = manager.LookUpOrderList(newOrder);
            if (response.Success)
            {
                displayManager.DisplayListToConsole(response.OrderList);
            }
            else
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(response.Message);
            }
        }
    }
}
