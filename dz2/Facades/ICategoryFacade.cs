using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2
{
    internal interface ICategoryFacade
    {
        Category Create(string type, string name);
        Category Get(Guid id);
        void ChangeName(Guid id, string newName);
        void Delete(Guid id);
        IEnumerable<Category> GetAll();
        IEnumerable<Category> GetByType(string type);
    }
}
