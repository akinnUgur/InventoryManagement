using InventoryManagement.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Category.Commands.UpdateCategory
{ 
    public class UpdateCategoryRequest : IRequest<ApiResponse<UpdateCategoryResponse>>
    {
        public int Id { get; set; }

        public string Name { get; set; }

    }
}
