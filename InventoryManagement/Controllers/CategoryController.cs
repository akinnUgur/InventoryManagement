using InventoryManagement.Core.Features.Category.Commands.CreateCategory;
using InventoryManagement.Core.Features.Category.Commands.DeleteCategory;
using InventoryManagement.Core.Features.Category.Commands.UpdateCategory;
using InventoryManagement.Core.Features.Category.Queries.GetAllCategories;
using InventoryManagement.Core.Features.Category.Queries.GetCategoryById;
using InventoryManagement.Core.Features.Category.Queries.GetCategoryTree;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.WebAPI.Controllers
{
     [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseApiController
    {

        [HttpGet("GetById")]
        public async Task<IActionResult> GetCategoryById([FromQuery] GetCategoryByIdRequest request)
        {
            var data = await Mediator.Send(request);
            return Ok(data);
        }

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories([FromQuery] GetAllCategoriesRequest request)
        {
            var data = await Mediator.Send(request);
            return Ok(data);
        }


        [HttpGet("GetCategoryTree")]
        public async Task<IActionResult> GetCategoryTree([FromQuery] GetCategoryTreeRequest request)
        {
            var data = await Mediator.Send(request);
            return Ok(data);
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
        {
            var data = await Mediator.Send(request);
            return Ok(data);
        }

        [HttpPost("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryRequest request)
        {
            var data = await Mediator.Send(request);
            return Ok(data);
        }

        [HttpPost("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryRequest request)
        {
            var data = await Mediator.Send(request);
            return Ok(data);
        }




     }
}
