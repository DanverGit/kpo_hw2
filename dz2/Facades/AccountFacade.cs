using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2
{
    internal class AccountFacade(IBankFactory factory, IAccountStorage storage) : IAccountFacade
    {
        public BankAccount Create(string name, double initialBalance = 0)
        {
            BankAccount account = factory.CreateAccount(name, initialBalance);
            storage.Add(account);
            return account;
        }
        public BankAccount Get(Guid id)
        {
            return storage.FindWithId(id);
        }
        public void ChangeName(Guid id, string newName)
        {
            BankAccount account = storage.FindWithId(id);
            account.ChangeName(newName);
            storage.Update(account);
        }
        public void Delete(Guid id)
        {
            storage.Remove(id);
        }
        public IEnumerable<BankAccount> GetAll()
        {
            return storage.GetAll();
        }
    }
}
