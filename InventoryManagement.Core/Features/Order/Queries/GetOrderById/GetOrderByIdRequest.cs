using InventoryManagement.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Order.Queries.GetOrderById
{
    public class GetOrderByIdRequest : IRequest<ApiResponse<GetOrderByIdResponse>>
    {
        public int Id { get; set; }
    }
}
