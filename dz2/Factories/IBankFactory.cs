using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2
{
    internal interface IBankFactory
    {
        BankAccount CreateAccount(string name, double balance);
        Category CreateCategory(string type, string name);
        public Operation CreateOperation(string type, Guid bankAccountId, double amount,
            DateOnly date, Guid categoryId, string description = "");
    }
}
