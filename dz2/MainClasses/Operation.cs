using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2
{
    internal class Operation
    {
        public Guid Id { get; set; } // уникальный идентификатор операции.
        public string Type { get; set; } // тип операции (доход или расход).
        public Guid BankAccountId { get; set; } // ссылка на счет, к которому относится операция.
        public double Amount { get; set; } // сумма операции.
        public DateOnly Date { get; set; } // дата операции.
        public string Description { get; set; } // описание операции (необязательное поле).
        public Guid CategoryId { get; set; } // ссылка на категорию, к которой относится операция.
        public void ChangeDescription(string newDescription)
        {
            if (newDescription != "")
            {
                Description = newDescription;
            }
            else
            {
                Console.WriteLine("InvalidInput");
            }
        }
        public Operation(Guid id, string type, Guid bankAccountId, double amount, 
            DateOnly date, string description, Guid categoryId)
        {
            Id = id;
            Type = type;
            BankAccountId = bankAccountId;
            Amount = amount;
            Date = date;
            Description = description;
            this.CategoryId = categoryId;
        }
    }
}
