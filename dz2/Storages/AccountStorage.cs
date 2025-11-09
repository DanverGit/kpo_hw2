using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2
{
    internal class AccountStorage : IAccountStorage
    {
        public Dictionary<Guid, BankAccount> accounts = new Dictionary<Guid, BankAccount>();

        public void Add(BankAccount account)
        {
            accounts[account.Id] = account;
        }
        public void Remove(Guid id)
        {
            accounts.Remove(id);
        }
        public void Update(BankAccount account)
        {
            accounts[account.Id] = account;
        }
        public BankAccount FindWithId(Guid id)
        {
            return accounts.GetValueOrDefault(id);
        }
        public IEnumerable<BankAccount> GetAll()
        {
            return accounts.Values;
        }
    }
}
