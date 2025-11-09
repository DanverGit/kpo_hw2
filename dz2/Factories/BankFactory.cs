using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2
{
    internal class BankFactory : IBankFactory
    {
        public BankAccount CreateAccount(string name, double initialBalance = 0)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Invalid account name.");
            }

            return new BankAccount(Guid.NewGuid(), name, initialBalance);
        }

        public Category CreateCategory(string type, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Invalid category name.");
            }

            return new Category(Guid.NewGuid(), type, name);
        }

        public Operation CreateOperation(string type, Guid bankAccountId, double amount,
            DateOnly date, Guid categoryId, string description = "")
        {
            if (amount <= 0)
            {
                throw new Exception("Invalid ammount.");
            }

            return new Operation(Guid.NewGuid(), type, bankAccountId, amount, date, description, categoryId);
        }
    }
}
