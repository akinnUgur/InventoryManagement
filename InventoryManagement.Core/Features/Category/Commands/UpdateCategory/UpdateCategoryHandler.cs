using InventoryManagement.Core.DTOs;
using InventoryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Category.Commands.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryRequest, ApiResponse<UpdateCategoryResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ApiResponse<UpdateCategoryResponse>> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            if(category == null)
            {
                return ApiResponse<UpdateCategoryResponse>.Error("Category not found", 404);
            }
            category.Name = request.Name;

            await _categoryRepository.Update(category);

            return ApiResponse<UpdateCategoryResponse>.Success(new(), "Category updated successfully", 201);
        }
    }
}
