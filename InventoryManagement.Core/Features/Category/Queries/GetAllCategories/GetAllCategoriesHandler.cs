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
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesRequest, ApiResponse<GetAllCategoriesResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoriesHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<ApiResponse<GetAllCategoriesResponse>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
        {
            var categories = _categoryRepository.GetAll();

            GetAllCategoriesResponse response = new GetAllCategoriesResponse();

            foreach (var category in categories)
            {
                response.Categories.Add(category);
            }

            return Task.FromResult(ApiResponse<GetAllCategoriesResponse>.Success(response, "Categories retrieved successfully", 201));
        }
    }
}
