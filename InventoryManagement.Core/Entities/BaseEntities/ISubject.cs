using InventoryManagement.Core.Enums;
using InventoryManagement.Core.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Entities.BaseEntities
{
    public interface ISubject<T> where T : class
    {

        void AddObserver(Interfaces.Base.IObserver<T> observer);
        void RemoveObserver(Interfaces.Base.IObserver<T> observer);
        Task NotifyObservers();

    }
}
