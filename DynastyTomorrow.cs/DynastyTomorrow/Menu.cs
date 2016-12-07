using DynastyTomorrow.WorkFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynastyTomorrow
{
    public class Menu
    {
        public static void Start()
        {
            while (true)
            {
            Console.WriteLine("====================================================");
            Console.WriteLine("|                                                  |");
            Console.WriteLine("|                Dynasty Tomorrow                  |");
            Console.WriteLine("|                                                  |");
            Console.WriteLine("====================================================");
            Console.WriteLine("|                                                  |");
            Console.WriteLine("|   1. Display Orders                              |");
            Console.WriteLine("|   2. Add an Order                                |");
            Console.WriteLine("|   3. Edit an Order                               |");
            Console.WriteLine("|   4. Remove an Order                             |");
            Console.WriteLine("|   5. Quit                                        |");
            Console.WriteLine("|                                                  |");
            Console.WriteLine("====================================================");

            string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        LookUpOrderWorkflow OrderLookUp = new LookUpOrderWorkflow();
                        OrderLookUp.TheBeginningOfTheEnd();
                        break;
                    case "2":
                        AddOrderWorkflow AddOrder = new AddOrderWorkflow();
                        AddOrder.AddingOrder();
                        break;
                    case "3":
                        EditOrderWorkflow EditOrder = new EditOrderWorkflow();
                        EditOrder.CreateEditWorkflow();
                        break;
                    case "4":
                        DeleteOrderWorkflow DeleteOrder = new DeleteOrderWorkflow();
                        DeleteOrder.EnterDeleteOrder();
                        break;
                    case "Q":
                        return;

                }
            }
        }
    }
}
