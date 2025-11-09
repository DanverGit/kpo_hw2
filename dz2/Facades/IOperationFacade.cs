using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2
{
    internal interface IOperationFacade
    {
        Operation Create(string type, Guid bankAccountId, double amount,
        DateOnly date, Guid categoryId, string description = "");
        Operation Get(Guid id);
        void ChangeDescription(Guid id, string newDescription);
        void Delete(Guid id);
        IEnumerable<Operation> GetAll();
        IEnumerable<Operation> GetByPeriod(DateOnly startDate, DateOnly endDate);
        IEnumerable<Operation> GetByCategory(Guid categoryId);
    }
}
