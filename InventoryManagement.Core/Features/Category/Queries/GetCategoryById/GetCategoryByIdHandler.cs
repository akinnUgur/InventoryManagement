using InventoryManagement.Core.DTOs;
using InventoryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdRequest, ApiResponse<GetCategoryByIdResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByIdHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ApiResponse<GetCategoryByIdResponse>> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if(category == null)
            {
                return ApiResponse<GetCategoryByIdResponse>.Error("Category not found", 404);
            }

            var response = new GetCategoryByIdResponse
            {
                Id = request.Id,
                Name = category.Name,
                ParentId = category.ParentId,
            };


            return ApiResponse<GetCategoryByIdResponse>.Success(response);
        }
    }
}
