using InventoryManagement.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Interfaces.Base
{
    public interface IObserver<T>  
    {
        Task NotifyAsync(T subject);  
    }
}
