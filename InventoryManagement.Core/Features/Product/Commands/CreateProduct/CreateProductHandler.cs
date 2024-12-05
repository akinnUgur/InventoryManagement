using InventoryManagement.Core.DTOs;
using InventoryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Product.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, ApiResponse<CreateProductResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CreateProductHandler(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        async Task<ApiResponse<CreateProductResponse>> IRequestHandler<CreateProductRequest, ApiResponse<CreateProductResponse>>.Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            Entities.Product product = new()
            {
                Name = request.Name,
                CategoryId = request.CategoryId,
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock,
            };

            await _productRepository.AddAsync(product);
            CreateProductResponse response = new()
            {
                Id = product.Id,
            };

            return ApiResponse<CreateProductResponse>.Success(response, "Product Created Successfully", 201);
        }
    }
}
