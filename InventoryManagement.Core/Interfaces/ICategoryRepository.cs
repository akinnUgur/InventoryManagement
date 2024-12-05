using InventoryManagement.Core.DTOs;
using InventoryManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Interfaces
{
    public interface ICategoryRepository
    {
        void Add(Category category);

        void Update(Category category);

        void Delete(Category category);

        Category? GetById(int id);
        IEnumerable<Category> GetAll();

        IEnumerable<Category> GetRootCategories();

        IEnumerable<Category> GetSubCategories(int parentId);

    }
}
