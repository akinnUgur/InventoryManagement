using InventoryManagement.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Product.Queries.GetProductById
{
    public class GetProductByIdRequest : IRequest<ApiResponse<GetProductByIdResponse>>
    {
        public int Id { get; set; }
    }
}
