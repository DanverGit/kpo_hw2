using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2
{
    internal class BankAccount
    {
        public Guid Id { get; set; } // уникальный идентификатор счета
        public string Name { get; set; } // название счета (например, "Основной счет").
        public double Balance { get; set; } // текущий баланс счета.
        public void ChangeName(string newName)
        {
            if (newName != "")
            {
                Name = newName;
            }
            else
            {
                Console.WriteLine("InvalidInput");
            }
        }
        public BankAccount (Guid id, string name, double balance)
        {
            Id = id;
            Name = name;
            Balance = balance;
        }


    }
}
