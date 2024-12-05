using InventoryManagement.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Order.Queries.GetAllOrders
{
    public class GetAllOrdersRequest : IRequest<ApiResponse<List<GetAllOrdersResponse>>>
    {
    }
}
