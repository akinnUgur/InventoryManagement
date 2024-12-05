using InventoryManagement.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Order.Commands.CreateOrder
{
    public class CreateOrderRequest: IRequest<ApiResponse<CreateOrderResponse>>
    {
        public string Email { get; set; }
        public List<OrderItemDTO> Items { get; set; }


    }
}
