using InventoryManagement.Core.Features.Category.Commands.CreateCategory;
using InventoryManagement.Core.Features.Category.Queries.GetCategoryById;
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


        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
        {
            var data = await Mediator.Send(request);
            return Ok(data);
        }

    }
}
