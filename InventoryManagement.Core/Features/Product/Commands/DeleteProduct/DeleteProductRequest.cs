using InventoryManagement.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Product.Commands.DeleteProduct
{
    public class DeleteProductRequest : IRequest<ApiResponse<DeleteProductResponse>>
    {
        public int Id { get; set; }

    }
}
