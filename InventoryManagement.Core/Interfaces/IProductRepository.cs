using InventoryManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(Product product); 
        Task Update(Product product); 
        Task Delete(Product product); 
        Task<Product> GetByIdAsync(int id); 
        IEnumerable<Product> GetAll(); 
        IEnumerable<Product> GetByCategoryId(int categoryId); 
    }
}

