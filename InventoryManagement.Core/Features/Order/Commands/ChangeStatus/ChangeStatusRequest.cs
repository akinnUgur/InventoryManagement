using InventoryManagement.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Order.Commands.ChangeStatus
{
    public class ChangeStatusRequest : IRequest<ApiResponse<ChangeStatusResponse>>
    {
        public int OrderId { get; set; }
        public int OrderStatus { get; set; }
    }
}
