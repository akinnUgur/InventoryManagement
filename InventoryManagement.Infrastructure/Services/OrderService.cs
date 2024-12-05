using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Enums;
using InventoryManagement.Core.Interfaces;
using InventoryManagement.Core.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly Core.Interfaces.Base.IObserver<Order> _emailObserver;

        public OrderService(IOrderRepository orderRepository, Core.Interfaces.Base.IObserver<Order> emailObserver)
        {
            _orderRepository = orderRepository;
            _emailObserver = emailObserver;
        }

        public async Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                throw new Exception("Order not found");

            order.Status = newStatus;

            // Observer’ları tetikle
            await _emailObserver.NotifyAsync(order);

            await _orderRepository.Update(order);
        }
    }
}
