using InventoryManagement.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryRequest : IRequest<ApiResponse<DeleteCategoryResponse>>
    {
        public int Id { get; set; }

    }
}
