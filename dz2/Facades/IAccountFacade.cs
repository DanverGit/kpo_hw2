using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2
{
    internal interface IAccountFacade
    {
        BankAccount Create(string name, double initialBalance = 0);
        BankAccount Get(Guid id);
        void ChangeName(Guid id, string newName);
        void Delete(Guid id);
        IEnumerable<BankAccount> GetAll();
    }
}
