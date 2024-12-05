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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category category)
        {
            if (category.ParentId.HasValue)
            {
                var parentCategory = await _context.Categories.FindAsync(category.ParentId.Value);
                if (parentCategory != null)
                {
                    category.ParentCategory = parentCategory;  // Set the ParentCategory if exists
                }
            }

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();  
        }

        public async Task Update(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

        }
        public async Task Delete(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

        }

      

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList(); 
        }

        public IEnumerable<Category> GetRootCategories()
        {
            return _context.Categories.Where(c => c.ParentId == null).ToList(); 
        }

        public IEnumerable<Category> GetSubCategories(int parentId)
        {
            return _context.Categories.Where(c => c.ParentId == parentId).ToList(); 
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        
        }
    }
}
