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

        public void Add(Order order)
        {
            _context.Orders.Add(order);

        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);

        }

        public void Delete(Order order)
        {
            _context.Orders.Remove(order);

        }

        public Order? GetById(int id)
        {
            return _context.Orders
                           .Include(o => o.OrderItems) 
                           .FirstOrDefault(o => o.Id == id); 
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

        public async Task ChangeStatusAsync(int orderId, OrderStatus newStatus)
        {
            var order = await _context.Orders
                                 .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order != null && order.Status != newStatus) 
            {
                await order.ChangeStatus(newStatus); 
                await _context.SaveChangesAsync(); 
            }
        }
    }
}
