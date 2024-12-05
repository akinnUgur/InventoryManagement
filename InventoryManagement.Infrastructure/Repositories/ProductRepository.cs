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

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
    
        }

        public async Task Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products
                           .Include(p => p.Category) 
                           .FirstOrDefaultAsync(p => p.Id == id);
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
