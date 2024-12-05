using InventoryManagement.Core.Entities.BaseEntities;
using InventoryManagement.Core.Enums;
using InventoryManagement.Core.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Entities
{
    public class Order : ISubject<Order>
    {
        public int Id { get; set; }
        public OrderStatus Status{ get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public string Email {  get; set; }


    

    }


}
