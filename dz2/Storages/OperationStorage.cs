using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2
{
    internal class OperationStorage : IOperationStorage
    {
        public Dictionary<Guid, Operation> operations = new Dictionary<Guid, Operation>();

        public void Add(Operation operation)
        {
            operations[operation.Id] = operation;
        }
        public void Remove(Guid id)
        {
            operations.Remove(id);
        }
        public void Update(Operation operation)
        {
            operations[operation.Id] = operation;
        }
        public Operation FindWithId(Guid id)
        {
            return operations.GetValueOrDefault(id);
        }
        public IEnumerable<Operation> FindWithCategoryId(Guid categoryId)
        {
            return operations.Values.Where(operation => operation.CategoryId == categoryId); // спасибо чатгпт
        }
        public IEnumerable<Operation> GetPeriod(DateOnly start, DateOnly end)
        {
            return operations.Values.Where(operation => operation.Date >= start && operation.Date <= end);
        }
        public IEnumerable<Operation> GetAll()
        {
            return operations.Values;
        }
    }
}
