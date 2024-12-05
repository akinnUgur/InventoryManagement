using InventoryManagement.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesRequest : IRequest<ApiResponse<GetAllCategoriesResponse>>
    {
    }
}
