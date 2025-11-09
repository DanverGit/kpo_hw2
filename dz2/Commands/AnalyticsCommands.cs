using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2.Commands
{
    internal class AnalyticsCommands(IOperationFacade operationFacade, ICategoryFacade categoryFacade)
    {
        public IEnumerable<Operation> AnalyzePeriod()
        {
            string userInput;
            DateOnly start;
            DateOnly end;

            List<Operation> operations = operationFacade.GetAll().ToList();

            do
            {
                Console.WriteLine("Input starting date:");
                userInput = Console.ReadLine();
                if (!DateOnly.TryParse(userInput, out start))
                {
                    Console.WriteLine("Invalid date");
                }
            } while (!DateOnly.TryParse(userInput, out start));

            do
            {
                Console.WriteLine("Input ending date:");
                userInput = Console.ReadLine();
                if (!DateOnly.TryParse(userInput, out end))
                {
                    Console.WriteLine("Invalid date");
                }
            } while (!DateOnly.TryParse(userInput, out end));

            var result = operationFacade.GetByPeriod(start, end);

            Console.WriteLine("\nOperations in this date period: \n");
            foreach (Operation operation in result)
            {
                Console.WriteLine("Id: " + operation.Id + "\n" +
                                "Account Id: " + operation.BankAccountId + "\n" +
                                "Category Id: " + operation.CategoryId + "\n" +
                                "Type: " + operation.Type + "\n" +
                                "Amount: " + operation.Amount + "\n" +
                                "Date: " + operation.Date + "\n" +
                                "Description: " + operation.Description);
            }

            return result;
        }

        public IEnumerable<Operation> AnalyzeCategory()
        {
            string userInput;
            Guid categoryId;

            List<Operation> operations = operationFacade.GetAll().ToList();
            List<Category> categories = categoryFacade.GetAll().ToList();

            Console.WriteLine("\nCategories available: \n");
            foreach (Category category in categories)
            {
                Console.WriteLine("Name: " + category.Name + "\n" +
                                "Type: " + category.Type + "\n" +
                                "Id: " + category.Id + "\n");
            }

            do
            {
                Console.WriteLine("Input one of available category id:");
                userInput = Console.ReadLine();

                if (!Guid.TryParse(userInput, out categoryId))
                {
                    Console.WriteLine("Invalid id.");
                }

                if (categoryFacade.Get(categoryId) == null)
                {
                    Console.WriteLine("No matching id.");
                }

            } while (!Guid.TryParse(userInput, out categoryId) || categoryFacade.Get(categoryId) == null);

            var result = operationFacade.GetByCategory(categoryId);

            Console.WriteLine("\nOperations of this category: \n");
            foreach (Operation operation in result)
            {
                Console.WriteLine("Id: " + operation.Id + "\n" +
                                "Account Id: " + operation.BankAccountId + "\n" +
                                "Category Id: " + operation.CategoryId + "\n" +
                                "Type: " + operation.Type + "\n" +
                                "Amount: " + operation.Amount + "\n" +
                                "Date: " + operation.Date + "\n" +
                                "Description: " + operation.Description);
            }

            return result;
        }
    }
}
