using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2
{
    internal class CategoryFacade(IBankFactory factory, ICategoryStorage storage) : ICategoryFacade
    {
        public Category Create(string type, string name)
        {
            Category category = factory.CreateCategory(type, name);
            storage.Add(category);
            return category;
        }
        public Category Get(Guid id)
        {
            return storage.FindWithId(id);
        }
        public void ChangeName(Guid id, string newName)
        {
            Category category = storage.FindWithId(id);
            category.ChangeName(newName);
            storage.Update(category);
        }
        public void Delete(Guid id)
        {
            storage.Remove(id);
        }
        public IEnumerable<Category> GetAll()
        {
            return storage.GetAll();
        }
        public IEnumerable<Category> GetByType(string type)
        {
            return storage.FindWithType(type);
        }
    }
}
