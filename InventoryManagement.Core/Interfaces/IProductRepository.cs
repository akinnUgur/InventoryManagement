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
        void Add(Product product); 
        void Update(Product product); 
        void Delete(Product product); 
        Product? GetById(int id); 
        IEnumerable<Product> GetAll(); 
        IEnumerable<Product> GetByCategoryId(int categoryId); 
    }
}

