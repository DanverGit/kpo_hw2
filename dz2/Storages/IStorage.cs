using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2
{
    internal interface IStorage<T>
    {
        void Add(T entity);
        void Remove(Guid id);
        void Update(T entity);
        T FindWithId(Guid id); // не забыть
        IEnumerable<T> GetAll();
    }
}
