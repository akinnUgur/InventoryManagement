using InventoryManagement.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Product.Queries.GetALlProducts
{
    public class GetALlProductsRequest : IRequest<ApiResponse<List<GetAllProductsResponse>>>    
    {
    }
}
