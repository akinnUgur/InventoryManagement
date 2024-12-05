using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Interfaces;
using InventoryManagement.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ApplicationDbContext _context;

        public InventoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Inventory inventory)
        {
            _context.Inventory.Add(inventory);

        }

        public void Update(Inventory inventory)
        {
            _context.Inventory.Update(inventory);

        }

        public void Delete(Inventory inventory)
        {
            _context.Inventory.Remove(inventory);

        }

        public Inventory? GetById(int id)
        {
            return _context.Inventory.FirstOrDefault(i => i.Id == id); 
        }

        public Inventory? GetByProductId(int productId)
        {
            return _context.Inventory.FirstOrDefault(i => i.ProductId == productId); 
        }

        public IEnumerable<Inventory> GetAll()
        {
            return _context.Inventory.ToList();
        }
    }
}
