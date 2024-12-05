using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.DTOs
{
    public class OrderItemDTO
    {
        public int ProductId { get; set; } 
        public int Quantity { get; set; }  
        public decimal TotalPrice { get; set; } 
    }
}
