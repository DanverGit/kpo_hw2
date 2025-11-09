using dz2.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace dz2
{
    internal class Menu (IAccountFacade accountFacade,
                        ICategoryFacade categoryFacade,
                        IOperationFacade operationFacade) : IMenu
    {
        private readonly MenuCommands _menuCommands = new(accountFacade, 
                                                            categoryFacade, 
                                                            operationFacade);

        string userInput;
        public void Launch()
        {
            while (true)
            {
                do
                {
                    Console.WriteLine("\nChoose option:");
                    Console.WriteLine("(1) Accounts");
                    Console.WriteLine("(2) Categories");
                    Console.WriteLine("(3) Operations");
                    Console.WriteLine("(4) Analytics");

                    userInput = Console.ReadLine();

                    if (userInput != "1" && userInput != "2" && userInput != "3" && userInput != "4")
                    {
                        Console.WriteLine("Invalid input.");
                    }
                } while (userInput != "1" && userInput != "2" && userInput != "3" && userInput != "4");

                switch (userInput)
                {
                    case "1":
                        _menuCommands.ShowAccountCommands(); 
                        break;

                    case "2":
                        _menuCommands.ShowCategoryCommands();
                        break;

                    case "3":
                        _menuCommands.ShowOperationCommands();
                        break;

                    case "4":
                        _menuCommands.ShowAnalyticsCommands();
                        break;
                }
            }
        }
    }
}
