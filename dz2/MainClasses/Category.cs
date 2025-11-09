using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2
{
    internal class Category
    {
        public Guid Id { get; set; } // уникальный идентификатор категории
        public string Name { get; set; } // название категории (например, "Кафе", "Зарплата").
        public string Type { get; set; } // тип категории (доход или расход).
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

        public Category(Guid id, string name, string type)
        {
            Id = id;
            Name = name;
            Type = type;
        }
    }
}
