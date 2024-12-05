using InventoryManagement.Core.DTOs;
using InventoryManagement.Core.Features.Category.Commands.CreateCategory;
using InventoryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryRequest, ApiResponse<DeleteCategoryResponse>>
    {

        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ApiResponse<DeleteCategoryResponse>> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            await _categoryRepository.Delete(category);



            return  ApiResponse<DeleteCategoryResponse>.Success(new(), "Category deleted successfully", 201);
        }
    }
}
