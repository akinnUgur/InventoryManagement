using InventoryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Interfaces
{
    public interface IOrderService
    {
        Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus);
    }
}
