using InventoryManagement.Core.Features.Product.Commands.CreateProduct;
using InventoryManagement.Core.Features.Product.Commands.DeleteProduct;
using InventoryManagement.Core.Features.Product.Queries.GetALlProducts;
using InventoryManagement.Core.Features.Product.Queries.GetProductById;
using InventoryManagement.Core.Features.Product.Queries.GetProductsByCategoryId;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseApiController
    {

        [HttpPost("Createproduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
        {
            var data = await Mediator.Send(request);
            return Ok(data);
        }


        [HttpPost("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductRequest request)
        {
            var data = await Mediator.Send(request);
            return Ok(data);
        }


        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetALlProductsRequest request)
        {
            var data = await Mediator.Send(request);
            return Ok(data);
        }

        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductById([FromQuery] GetProductByIdRequest request)
        {
            var data = await Mediator.Send(request);
            return Ok(data);
        }


        [HttpGet("GetProductByCategoryId")]
        public async Task<IActionResult> GetProductByCategoryId([FromQuery] GetProductsByCategoryIdRequest request)
        {
            var data = await Mediator.Send(request);
            return Ok(data);
        }
    }
}
