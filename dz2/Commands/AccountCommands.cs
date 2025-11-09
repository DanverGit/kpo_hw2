using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace dz2.Commands
{
    internal class AccountCommands(IAccountFacade accountFacade)
    {
        public void ShowAllAccounts()
        {
            List<BankAccount> accounts = accountFacade.GetAll().ToList();

            Console.WriteLine("\nAccounts available: \n");
            foreach (BankAccount account in accounts)
            {
                Console.WriteLine("Name: " + account.Name + "\n" +
                                "Balance: " + account.Balance + "\n" +
                                "Id: " + account.Id + "\n");
            }
        }

        public void CreateAccount()
        {
            string userInput;
            string name;
            double balance;

            do
            {
                Console.WriteLine("Input name:");
                userInput = Console.ReadLine();
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Invalid name.");
                }
            } while (string.IsNullOrEmpty(userInput));
            name = userInput;

            do
            {
                Console.WriteLine("Input initial balance:");
                userInput = Console.ReadLine();
                if (!double.TryParse(userInput, out balance))
                {
                    Console.WriteLine("Invalid balance");
                }
            } while (!double.TryParse(userInput, out balance));

            accountFacade.Create(name, balance);

            Console.WriteLine("Account created.");
        }

        public void RedactAccount()
        {
            string userInput;
            string newName;
            Guid id;

            List<BankAccount> accounts = accountFacade.GetAll().ToList();

            Console.WriteLine("Accounts available for redacting: \n");
            foreach (BankAccount account in accounts)
            {
                Console.WriteLine("Name: " + account.Name + "\n" +
                                "Balance: "+ account.Balance + "\n" + 
                                "Id: " + account.Id + "\n");
            }

            
            do
            {
                Console.WriteLine("Input id to redact account or \"Cancel\" to go back:");
                userInput = Console.ReadLine();
                
                if (userInput.ToLower() == "cancel") { return; }

                if (!Guid.TryParse(userInput, out id))
                {
                    Console.WriteLine("Invalid id.");
                }

                if (accountFacade.Get(id) == null)
                {
                    Console.WriteLine("No matching id.");
                }

            } while (!Guid.TryParse(userInput, out id) || accountFacade.Get(id) == null);

            do
            {
                Console.WriteLine("Input new name:");
                userInput = Console.ReadLine();
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Invalid new name.");
                }
            } while (string.IsNullOrEmpty(userInput));
            newName = userInput;

            accountFacade.ChangeName(id, newName);

            Console.WriteLine("Account redacted.");
        }
    
        public void DeleteAccount()
        {
            string userInput;
            Guid id;

            List<BankAccount> accounts = accountFacade.GetAll().ToList();

            Console.WriteLine("Accounts available for deleting: \n");
            foreach (BankAccount account in accounts)
            {
                Console.WriteLine("Name: " + account.Name + "\n" +
                                "Balance: " + account.Balance + "\n" +
                                "Id: " + account.Id + "\n");
            }


            do
            {
                Console.WriteLine("Input id to delete account or \"Cancel\" to go back:");
                userInput = Console.ReadLine();

                if (userInput.ToLower() == "cancel") { return; }

                if (!Guid.TryParse(userInput, out id))
                {
                    Console.WriteLine("Invalid id.");
                }

                if (accountFacade.Get(id) == null)
                {
                    Console.WriteLine("No matching id.");
                }

            } while (!Guid.TryParse(userInput, out id) || accountFacade.Get(id) == null);

            accountFacade.Delete(id);

            Console.WriteLine("Account deleted.");
        }
    }
}
