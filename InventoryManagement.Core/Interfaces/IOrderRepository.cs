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
        void Add(Order order);
        void Update(Order order);
        void Delete(Order order); 
        Order? GetById(int id); 
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetByDateRange(DateTime startDate, DateTime endDate);
        Task ChangeStatusAsync(int orderId, OrderStatus newStatus);


    }
}
