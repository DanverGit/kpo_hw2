using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2
{
    internal interface ICategoryStorage : IStorage<Category>
    {
        IEnumerable<Category> FindWithType(string type);
    }
}
