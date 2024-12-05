using InventoryManagement.Core.DTOs;
using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Features.Order.Queries.GetAllOrders;
using InventoryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Product.Queries.GetALlProducts
{
    public class GetALlProductsHandler : IRequestHandler<GetALlProductsRequest, ApiResponse<List<GetAllProductsResponse>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GetALlProductsHandler(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public async Task<ApiResponse<List<GetAllProductsResponse>>> Handle(GetALlProductsRequest request, CancellationToken cancellationToken)
        {
            var products = _productRepository.GetAll().ToList();

            var response = new List<GetAllProductsResponse>();

            foreach (var product in products)
            {
                var category = await _categoryRepository.GetByIdAsync(product.CategoryId);
                response.Add(new GetAllProductsResponse
                {
                    CategoryId = product.CategoryId,
                    CategoryName = category.Name,
                    Price = product.Price,
                    Name = product.Name,
                    Description = product.Description,
                    Id = product.Id,
                    Stock = product.Stock,
                });
            }
  


            return ApiResponse<List<GetAllProductsResponse>>.Success(response, "Products Received Successfully", 201);
        }
    }
}
