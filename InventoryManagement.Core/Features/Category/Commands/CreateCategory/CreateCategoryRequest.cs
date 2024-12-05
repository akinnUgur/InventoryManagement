using InventoryManagement.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryRequest : IRequest<ApiResponse<CreateCategoryResponse>>
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }

    }
}
