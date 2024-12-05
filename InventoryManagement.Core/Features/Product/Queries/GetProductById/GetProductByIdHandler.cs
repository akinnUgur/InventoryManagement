using InventoryManagement.Core.DTOs;
using InventoryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Product.Queries.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, ApiResponse<GetProductByIdResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GetProductByIdHandler(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public async Task<ApiResponse<GetProductByIdResponse>> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            var category = await _categoryRepository.GetByIdAsync(product.CategoryId);

            var response = new GetProductByIdResponse
            {
                CategoryId = category.Id,
                CategoryName = category.Name,
                Description = product.Description,
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,

            };

            return ApiResponse<GetProductByIdResponse>.Success(response, "Product received successfully", 201);


        }
    }
}
