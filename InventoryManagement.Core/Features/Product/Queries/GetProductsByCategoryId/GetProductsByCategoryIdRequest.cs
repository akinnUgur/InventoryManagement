using InventoryManagement.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Product.Queries.GetProductsByCategoryId
{
    public class GetProductsByCategoryIdRequest : IRequest<ApiResponse<List<GetProductsByCategoryIdResponse>>>
    {
        public int CategoryId { get; set; }

    }
}
