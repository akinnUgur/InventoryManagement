using InventoryManagement.Core.DTOs;
using InventoryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Order.Queries.GetOrdersByStatus
{
    public class GetOrdersByStatusResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemDTO> Items { get; set; } = new();
    }
}
