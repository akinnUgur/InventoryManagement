using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Interfaces;
using InventoryManagement.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
    
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);

        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);

        }

        public Product? GetById(int id)
        {
            return _context.Products
                           .Include(p => p.Category) 
                           .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products
                           .Include(p => p.Category) 
                           .ToList(); 
        }

        public IEnumerable<Product> GetByCategoryId(int categoryId)
        {
            return _context.Products
                           .Where(p => p.CategoryId == categoryId) 
                           .Include(p => p.Category) 
                           .ToList(); 
        }
    }
}
