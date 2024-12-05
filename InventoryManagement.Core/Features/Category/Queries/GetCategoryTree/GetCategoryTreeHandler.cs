using InventoryManagement.Core.DTOs;
using InventoryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Category.Queries.GetCategoryTree
{
    public class GetCategoryTreeHandler : IRequestHandler<GetCategoryTreeRequest, ApiResponse<List<CategoryTreeDTO>>>
    {

        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryTreeHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        async Task<ApiResponse<List<CategoryTreeDTO>>> IRequestHandler<GetCategoryTreeRequest, ApiResponse<List<CategoryTreeDTO>>>.Handle(GetCategoryTreeRequest request, CancellationToken cancellationToken)
        {
            var categories = _categoryRepository.GetAll().ToList();
            var categoryTree = BuildCategoryTree(categories);

            return ApiResponse<List<CategoryTreeDTO>>.Success(categoryTree, "Category tree fetched successfully", 200);
        }

        private List<CategoryTreeDTO> BuildCategoryTree(List<Entities.Category> categories)
        {
      
            var roots = categories.Where(c => c.ParentId == null).ToList();

    
            return roots.Select(root => MapToCategoryTreeDTO(root, categories)).ToList();
        }

        private CategoryTreeDTO MapToCategoryTreeDTO(Entities.Category category, List<Entities.Category> allCategories)
        {
            // DTO'ya eşleme yapıyoruz
            return new CategoryTreeDTO
            {
                Id = category.Id,
                Name = category.Name,
                SubCategories = allCategories
                    .Where(c => c.ParentId == category.Id) // Alt kategorileri bul
                    .Select(subCategory => MapToCategoryTreeDTO(subCategory, allCategories)) // Alt kategorileri yinelemeli olarak işle
                    .ToList()
            };
        }
    }
}
