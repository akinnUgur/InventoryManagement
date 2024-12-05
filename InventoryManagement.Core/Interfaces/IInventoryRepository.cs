using InventoryManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Interfaces
{
    public interface IInventoryRepository
    {
        void Add(Inventory inventory); 
        void Update(Inventory inventory); 
        void Delete(Inventory inventory); 
        Inventory? GetById(int id); 
        Inventory? GetByProductId(int productId); 
        IEnumerable<Inventory> GetAll();
    }
}
