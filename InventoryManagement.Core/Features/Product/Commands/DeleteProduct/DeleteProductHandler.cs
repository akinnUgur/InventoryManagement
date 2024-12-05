using InventoryManagement.Core.DTOs;
using InventoryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Product.Commands.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, ApiResponse<DeleteProductResponse>>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ApiResponse<DeleteProductResponse>> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            await _productRepository.Delete(await _productRepository.GetByIdAsync(request.Id));


            return ApiResponse<DeleteProductResponse>.Success(new(), "Product Deleted Successfully", 201);
        }
    }
}
