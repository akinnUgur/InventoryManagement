using InventoryManagement.Core.DTOs;
using InventoryManagement.Core.Features.Category.Commands.CreateCategory;
using InventoryManagement.Core.Features.Category.Commands.UpdateCategory;
using InventoryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesRequest, ApiResponse<List<GetAllCategoriesResponse>>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoriesHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<ApiResponse<List<GetAllCategoriesResponse>>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
        {
            var categories = _categoryRepository.GetAll();

            var response = categories.Select(category => new GetAllCategoriesResponse
            {
                Id = category.Id,
                Name = category.Name,
                ParentId = category.ParentId
            }).ToList();
            

            return Task.FromResult(ApiResponse<List<GetAllCategoriesResponse>>.Success(response, "Categories retrieved successfully", 201));
        }
    }
}
