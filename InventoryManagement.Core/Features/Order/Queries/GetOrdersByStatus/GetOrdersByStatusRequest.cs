using InventoryManagement.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Order.Queries.GetOrdersByStatus
{
    public class GetOrdersByStatusRequest : IRequest<ApiResponse<List<GetOrdersByStatusResponse>>>
    {
        public int Status { get; set; }
    }
}
