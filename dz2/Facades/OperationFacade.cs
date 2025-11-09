using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace dz2
{
    internal class OperationFacade(IBankFactory factory, IOperationStorage storage,
                                    IAccountStorage accountStorage) : IOperationFacade
    {
        public Operation Create(string type, Guid bankAccountId, double amount,
        DateOnly date, Guid categoryId, string description = "")
        {
            Operation operation = factory.CreateOperation(type, bankAccountId, amount, 
                                                        date, categoryId, description);
            BankAccount account = accountStorage.FindWithId(bankAccountId);
            if (type == "deposit") { account.Balance += amount; }
            else { account.Balance -= amount; }
            
            accountStorage.Update(account);
            storage.Add(operation);

            return operation;
        }
        public Operation Get(Guid id)
        {
            return storage.FindWithId(id);
        }
        public void ChangeDescription(Guid id, string newDescription)
        {
            Operation operation = storage.FindWithId(id);
            operation.ChangeDescription(newDescription);
            storage.Update(operation);
        }
        public void Delete(Guid id)
        {
            storage.Remove(id);
        }
        public IEnumerable<Operation> GetAll()
        {
            return storage.GetAll();
        }
        public IEnumerable<Operation> GetByPeriod(DateOnly start, DateOnly end)
        {
            return storage.GetPeriod(start, end);
        }
        public IEnumerable<Operation> GetByCategory(Guid categoryId)
        {
            return storage.FindWithCategoryId(categoryId);
        }
    }
}
