using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2
{
    internal class CategoryStorage : ICategoryStorage
    {
        public Dictionary<Guid, Category> categories = new Dictionary<Guid, Category>();

        public void Add(Category category)
        {
            categories[category.Id] = category;
        }
        public void Remove(Guid id)
        {
            categories.Remove(id);
        }
        public void Update(Category category)
        {
            categories[category.Id] = category;
        }
        public Category FindWithId(Guid id)
        {
            return categories.GetValueOrDefault(id);
        }
        public IEnumerable<Category> FindWithType(string type)
        {
            return categories.Values.Where(category => category.Type == type); // спасибо чатгпт
        }
        public IEnumerable<Category> GetAll()
        {
            return categories.Values;
        }
    }
}
