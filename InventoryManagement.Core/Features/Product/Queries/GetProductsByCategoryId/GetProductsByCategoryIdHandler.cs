using InventoryManagement.Core.DTOs;
using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Features.Order.Queries.GetOrdersByStatus;
using InventoryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Product.Queries.GetProductsByCategoryId
{
    public class GetProductsByCategoryIdHandler : IRequestHandler<GetProductsByCategoryIdRequest, ApiResponse<List<GetProductsByCategoryIdResponse>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GetProductsByCategoryIdHandler(ICategoryRepository categoryRepository, IProductRepository repository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = repository;
        }

        public async Task<ApiResponse<List<GetProductsByCategoryIdResponse>>> Handle(GetProductsByCategoryIdRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);

            var products = _productRepository.GetAll();

            products = products.Where(p => p.CategoryId == request.CategoryId);


            var response = products.Select(product => new GetProductsByCategoryIdResponse
            {
                Id = product.Id,
                CategoryId = category.Id,
                CategoryName = category.Name,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
            }).ToList();

            return ApiResponse<List<GetProductsByCategoryIdResponse>>.Success(response, "Products Recieved Successfully", 201);
        }
    }
}
