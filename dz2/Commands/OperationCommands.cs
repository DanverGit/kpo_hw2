using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace dz2.Commands
{
    internal class OperationCommands(IOperationFacade operationFacade,
                                    IAccountFacade accountFacade,
                                    ICategoryFacade categoryFacade)
    {
        public void ShowAllOperations()
        {
            List<Operation> operations = operationFacade.GetAll().ToList();

            Console.WriteLine("\nOperations available: \n");
            foreach (Operation operation in operations)
            {
                Console.WriteLine("Id: " + operation.Id + "\n" +
                                "Account Id: " + operation.BankAccountId + "\n" +
                                "Category Id: " + operation.CategoryId + "\n" +
                                "Type: " + operation.Type + "\n" +
                                "Amount: " + operation.Amount + "\n" +
                                "Date: " + operation.Date + "\n" +
                                "Description: " + operation.Description);
            }
        }

        public void CreateOperation()
        {
            List<BankAccount> accounts = accountFacade.GetAll().ToList();
            List<Category> categories = categoryFacade.GetAll().ToList();

            string userInput;
            Guid categoryId;
            Guid accountId;
            string type;
            double amount;
            DateOnly date;
            string description;

            // Type
            do
            {
                Console.WriteLine("Chose type:");
                Console.WriteLine("(1) Deposit");
                Console.WriteLine("(2) Withdrawal");
                userInput = Console.ReadLine();
                if (userInput != "1" && userInput != "2")
                {
                    Console.WriteLine("Invalid input");
                }
            } while (userInput != "1" && userInput != "2");
            if (userInput == "1") { type = "Deposit"; }
            else { type = "Withdrawal"; }

            // Account Id
            Console.WriteLine("Accounts available for operation: \n");
            foreach (BankAccount account in accounts)
            {
                Console.WriteLine("Name: " + account.Name + "\n" +
                                "Balance: " + account.Balance + "\n" +
                                "Id: " + account.Id + "\n");
            }

            do
            {
                Console.WriteLine("Input id to redact account or \"Cancel\" to go back:");
                userInput = Console.ReadLine();

                if (userInput.ToLower() == "cancel") { return; }

                if (!Guid.TryParse(userInput, out accountId))
                {
                    Console.WriteLine("Invalid id.");
                }

                if (accountFacade.Get(accountId) == null)
                {
                    Console.WriteLine("No matching id.");
                }

            } while (!Guid.TryParse(userInput, out accountId) || accountFacade.Get(accountId) == null);

            // Category Id
            Console.WriteLine("Categories available for operation: \n");
            foreach (Category category in categories)
            {
                Console.WriteLine("Name: " + category.Name + "\n" +
                                "Type: " + category.Type + "\n" +
                                "Id: " + category.Id + "\n");
            }

            do
            {
                Console.WriteLine("Input one of available category id or \"Cancel\" to go back:");
                userInput = Console.ReadLine();

                if (userInput.ToLower() == "cancel") { return; }

                if (!Guid.TryParse(userInput, out categoryId))
                {
                    Console.WriteLine("Invalid id.");
                }

                if (categoryFacade.Get(categoryId) == null)
                {
                    Console.WriteLine("No matching id.");
                }

            } while (!Guid.TryParse(userInput, out categoryId) || categoryFacade.Get(categoryId) == null);

            // Amount
            do
            {
                Console.WriteLine("Input operation amount:");
                userInput = Console.ReadLine();
                if (!double.TryParse(userInput, out amount))
                {
                    Console.WriteLine("Invalid balance");
                }
            } while (!double.TryParse(userInput, out amount));

            // Date
            do
            {
                Console.WriteLine("Input operation date (yyyy-mm-dd):");
                userInput = Console.ReadLine();
                if (!DateOnly.TryParse(userInput, out date))
                {
                    Console.WriteLine("Invalid balance");
                }
            } while (!DateOnly.TryParse(userInput, out date));

            // Description
            Console.WriteLine("Input description:");
            description = Console.ReadLine();

            operationFacade.Create(type, accountId, amount, date, categoryId, description);

            Console.WriteLine("Operation created.");
        }

        public void RedactOperation()
        {
            string userInput;
            string newDescription;
            Guid id;

            List<Operation> operations = operationFacade.GetAll().ToList();

            Console.WriteLine("Operations available for redacting: \n");
            foreach (Operation operation in operations)
            {
                Console.WriteLine("Id: " + operation.Id + "\n" +
                                "Account Id: " + operation.BankAccountId + "\n" +
                                "Category Id: " + operation.CategoryId + "\n" +
                                "Type: " + operation.Type + "\n" +
                                "Amount: " + operation.Amount + "\n" +
                                "Date: " + operation.Date + "\n" +
                                "Description: " + operation.Description);
            }

            do
            {
                Console.WriteLine("Input id to redact operation or \"Cancel\" to go back:");
                userInput = Console.ReadLine();

                if (userInput.ToLower() == "cancel") { return; }

                if (!Guid.TryParse(userInput, out id))
                {
                    Console.WriteLine("Invalid id.");
                }

                if (operationFacade.Get(id) == null)
                {
                    Console.WriteLine("No matching id.");
                }

            } while (!Guid.TryParse(userInput, out id) || operationFacade.Get(id) == null);


            Console.WriteLine("Input new description:");
            newDescription = Console.ReadLine();

            operationFacade.ChangeDescription(id, newDescription);

            Console.WriteLine("Opertaion redacted.");
        }

        public void DeleteOperation()
        {
            string userInput;
            Guid id;

            List<Operation> operations = operationFacade.GetAll().ToList();

            Console.WriteLine("Operations available for redacting: \n");
            foreach (Operation operation in operations)
            {
                Console.WriteLine("Id: " + operation.Id + "\n" +
                                "Account Id: " + operation.BankAccountId + "\n" +
                                "Category Id: " + operation.CategoryId + "\n" +
                                "Type: " + operation.Type + "\n" +
                                "Amount: " + operation.Amount + "\n" +
                                "Date: " + operation.Date + "\n" +
                                "Description: " + operation.Description);
            }


            do
            {
                Console.WriteLine("Input id to delete operation or \"Cancel\" to go back:");
                userInput = Console.ReadLine();

                if (userInput.ToLower() == "cancel") { return; }

                if (!Guid.TryParse(userInput, out id))
                {
                    Console.WriteLine("Invalid id.");
                }

                if (operationFacade.Get(id) == null)
                {
                    Console.WriteLine("No matching id.");
                }

            } while (!Guid.TryParse(userInput, out id) || operationFacade.Get(id) == null);

            operationFacade.Delete(id);

            Console.WriteLine("Operation deleted.");
        }
    }
}
