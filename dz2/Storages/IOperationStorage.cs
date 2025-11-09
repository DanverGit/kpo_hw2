using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2
{
    internal interface IOperationStorage : IStorage<Operation>
    {
        IEnumerable<Operation> FindWithCategoryId(Guid categoryId);
        IEnumerable<Operation> GetPeriod(DateOnly start, DateOnly end);
    }
}
