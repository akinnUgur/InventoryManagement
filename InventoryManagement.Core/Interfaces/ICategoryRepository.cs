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
        Task AddAsync(Category category);

        Task Update(Category category);

        Task Delete(Category category);

        Task<Category> GetByIdAsync(int id);
        IEnumerable<Category> GetAll();

        IEnumerable<Category> GetRootCategories();

        IEnumerable<Category> GetSubCategories(int parentId);

    }
}
