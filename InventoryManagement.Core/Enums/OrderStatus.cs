using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Enums
{
    public enum OrderStatus
    {
        Pending = 1,
        InProgress = 0,
        Completed = -1,
        Cancelled = -2,
        Refunded = -3
    }
}
