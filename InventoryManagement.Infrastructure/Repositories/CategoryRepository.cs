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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);

        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);

        }
        public void Delete(Category category)
        {
            _context.Categories.Remove(category);

        }

        public Category? GetById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id); 
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
    }
}
