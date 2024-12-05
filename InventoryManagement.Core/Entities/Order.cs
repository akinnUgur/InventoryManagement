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


        private readonly List<Interfaces.Base.IObserver<Order>> _observers = new List<Interfaces.Base.IObserver<Order>>();

        public void AddObserver(Interfaces.Base.IObserver<Order> observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(Interfaces.Base.IObserver<Order> observer)
        {
            _observers.Remove(observer);
        }

        public async Task NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                await observer.NotifyAsync(this);  // Observer'a bildirimi yap
            }
        }

        public async Task ChangeStatus(OrderStatus newStatus)
        {
            Status = newStatus;
            await NotifyObservers(); 
        }


    }


}
