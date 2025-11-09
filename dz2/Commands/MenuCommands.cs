using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2.Commands
{
    internal class MenuCommands(IAccountFacade accountFacade,
                                ICategoryFacade categoryFacade,
                                IOperationFacade operationFacade)
    {
        private readonly AccountCommands _accountCommands = new(accountFacade);
        private readonly CategoryCommands _categoryCommands = new(categoryFacade);
        private readonly OperationCommands _operationCommands = new(operationFacade, 
                                                    accountFacade, categoryFacade);
        private readonly AnalyticsCommands _analyticsCommands = new(operationFacade,
                                                    categoryFacade);

        public void ShowAccountCommands()
        {
            string userInput;

            while (true)
            {
                do
                {
                    Console.WriteLine("\nChoose option:");
                    Console.WriteLine("(1) Show all accounts");
                    Console.WriteLine("(2) Create account");
                    Console.WriteLine("(3) Redact account");
                    Console.WriteLine("(4) Delete account");

                    userInput = Console.ReadLine();

                    if (userInput != "1" && userInput != "2" && userInput != "3" && userInput != "4")
                    {
                        Console.WriteLine("Invalid input.");
                    }
                } while (userInput != "1" && userInput != "2" && userInput != "3" && userInput != "4");

                switch (userInput)
                {
                    case "1":
                        _accountCommands.ShowAllAccounts(); 
                        return;

                    case "2":
                        _accountCommands.CreateAccount();
                        return;

                    case "3":
                        _accountCommands.RedactAccount();
                        return;

                    case "4":
                        _accountCommands.DeleteAccount();
                        return;

                }
            }
        }

        public void ShowCategoryCommands()
        {
            string userInput;

            while (true)
            {
                do
                {
                    Console.WriteLine("\nChoose option:");
                    Console.WriteLine("(1) Show all caregories");
                    Console.WriteLine("(2) Create category");
                    Console.WriteLine("(3) Redact category");
                    Console.WriteLine("(4) Delete category");

                    userInput = Console.ReadLine();

                    if (userInput != "1" && userInput != "2" && userInput != "3" && userInput != "4")
                    {
                        Console.WriteLine("Invalid input.");
                    }
                } while (userInput != "1" && userInput != "2" && userInput != "3" && userInput != "4");

                switch (userInput)
                {
                    case "1":
                        _categoryCommands.ShowAllCategories();
                        return;

                    case "2":
                        _categoryCommands.CreateCategory();
                        return;

                    case "3":
                        _categoryCommands.RedactCategory();
                        return;

                    case "4":
                        _categoryCommands.DeleteCategory();
                        return;

                }
            }
        }

        public void ShowOperationCommands()
        {
            string userInput;

            while (true)
            {
                do
                {
                    Console.WriteLine("\nChoose option:");
                    Console.WriteLine("(1) Show all operations");
                    Console.WriteLine("(2) Create operation");
                    Console.WriteLine("(3) Redact operation");
                    Console.WriteLine("(4) Delete operation");

                    userInput = Console.ReadLine();

                    if (userInput != "1" && userInput != "2" && userInput != "3" && userInput != "4")
                    {
                        Console.WriteLine("Invalid input.");
                    }
                } while (userInput != "1" && userInput != "2" && userInput != "3" && userInput != "4");

                switch (userInput)
                {
                    case "1":
                        _operationCommands.ShowAllOperations();
                        return;

                    case "2":
                        _operationCommands.CreateOperation();
                        return;

                    case "3":
                        _operationCommands.RedactOperation();
                        return;

                    case "4":
                        _operationCommands.DeleteOperation();
                        return;

                }
            }
        }

        public void ShowAnalyticsCommands()
        {
            string userInput;

            while (true)
            {
                do
                {
                    Console.WriteLine("\nChoose option:");
                    Console.WriteLine("(1) Analyze period");
                    Console.WriteLine("(2) Analyze category");

                    userInput = Console.ReadLine();

                    if (userInput != "1" && userInput != "2")
                    {
                        Console.WriteLine("Invalid input.");
                    }
                } while (userInput != "1" && userInput != "2");

                switch (userInput)
                {
                    case "1":
                        _analyticsCommands.AnalyzePeriod();
                        return;

                    case "2":
                        _analyticsCommands.AnalyzeCategory();
                        return;
                }
            }
        }
    }
}
