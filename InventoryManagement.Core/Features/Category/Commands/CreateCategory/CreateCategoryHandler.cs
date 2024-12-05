using InventoryManagement.Core.DTOs;
using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryRequest, ApiResponse<CreateCategoryResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


      

        async Task<ApiResponse<CreateCategoryResponse>> IRequestHandler<CreateCategoryRequest, ApiResponse<CreateCategoryResponse>>.Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            Entities.Category category = new Entities.Category()
            {
                Name = request.Name,
                ParentId = request.ParentId
            };
            if (request.ParentId.HasValue)
            {
                var parentCategory = await _categoryRepository.GetByIdAsync(request.ParentId.Value);
                if (parentCategory != null)
                {
                    category.ParentCategory = parentCategory;
                }
            }
            await _categoryRepository.AddAsync(category);

            var response = new CreateCategoryResponse
            {
                Id = category.Id
            };
            return ApiResponse<CreateCategoryResponse>.Success(response, "Category created successfully", 201);
        }
    }
}
