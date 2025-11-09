using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2.Commands
{
    internal class CategoryCommands(ICategoryFacade categoryFacade)
    {
        public void ShowAllCategories()
        {
            List<Category> categories = categoryFacade.GetAll().ToList();

            Console.WriteLine("\nCategories available: \n");
            foreach (Category category in categories)
            {
                Console.WriteLine("Name: " + category.Name + "\n" +
                                "Type: " + category.Type + "\n" +
                                "Id: " + category.Id + "\n");
            }
        }

        public void CreateCategory()
        {
            string userInput;
            string name;
            string type;

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

            categoryFacade.Create(type, name);

            Console.WriteLine("Category created.");
        }

        public void RedactCategory()
        {
            string userInput;
            string newName;
            Guid id;

            List<Category> categories = categoryFacade.GetAll().ToList();

            Console.WriteLine("Categories available for redacting: \n");
            foreach (Category category in categories)
            {
                Console.WriteLine("Name: " + category.Name + "\n" +
                                "Type: " + category.Type + "\n" +
                                "Id: " + category.Id + "\n");
            }


            do
            {
                Console.WriteLine("Input id to redact category or \"Cancel\" to go back:");
                userInput = Console.ReadLine();

                if (userInput.ToLower() == "cancel") { return; }

                if (!Guid.TryParse(userInput, out id))
                {
                    Console.WriteLine("Invalid id.");
                }

                if (categoryFacade.Get(id) == null)
                {
                    Console.WriteLine("No matching id.");
                }

            } while (!Guid.TryParse(userInput, out id) || categoryFacade.Get(id) == null);

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

            categoryFacade.ChangeName(id, newName);

            Console.WriteLine("Category redacted.");
        }

        public void DeleteCategory()
        {
            string userInput;
            Guid id;

            List<Category> categories = categoryFacade.GetAll().ToList();

            Console.WriteLine("Categories available for deleting: \n");
            foreach (Category category in categories)
            {
                Console.WriteLine("Name: " + category.Name + "\n" +
                                "Type: " + category.Type + "\n" +
                                "Id: " + category.Id + "\n");
            }


            do
            {
                Console.WriteLine("Input id to delete category or \"Cancel\" to go back:");
                userInput = Console.ReadLine();

                if (userInput.ToLower() == "cancel") { return; }

                if (!Guid.TryParse(userInput, out id))
                {
                    Console.WriteLine("Invalid id.");
                }

                if (categoryFacade.Get(id) == null)
                {
                    Console.WriteLine("No matching id.");
                }

            } while (!Guid.TryParse(userInput, out id) || categoryFacade.Get(id) == null);

            categoryFacade.Delete(id);

            Console.WriteLine("Category deleted.");
        }
    }
}
