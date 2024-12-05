using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Enums;
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
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Order order)
        {
           
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

        }

        public async Task Update(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

        }

        public async Task<Order> GetByIdAsync(int id)
        {

            return await _context.Orders
                           .Include(o => o.OrderItems)
                           .FirstOrDefaultAsync(o => o.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders
                           .Include(o => o.OrderItems)
                           .ToList();
        }

        public IEnumerable<Order> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return _context.Orders
                           .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                           .Include(o => o.OrderItems)
                           .ToList();
        }

    

   
    }
}
