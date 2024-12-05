using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Interfaces
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        Task Update(Order order);
        Task Delete(Order order); 
        Task<Order> GetByIdAsync(int id); 
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetByDateRange(DateTime startDate, DateTime endDate);
        Task ChangeStatusAsync(int orderId, OrderStatus newStatus);


    }
}
