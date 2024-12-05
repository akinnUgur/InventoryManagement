using InventoryManagement.Core.Features.Order.Commands.ChangeStatus;
using InventoryManagement.Core.Features.Order.Commands.CreateOrder;
using InventoryManagement.Core.Features.Order.Queries.GetAllOrders;
using InventoryManagement.Core.Features.Order.Queries.GetOrderById;
using InventoryManagement.Core.Features.Order.Queries.GetOrdersByStatus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseApiController
    {
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            var data = await Mediator.Send(request);
            return Ok(data);
        }

        [HttpPost("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusRequest request)
        {
            var data = await Mediator.Send(request);
            return Ok(data);

        }


        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders([FromQuery] GetAllOrdersRequest request)
        {
            var data = await Mediator.Send(request);
            return Ok(data);
        }


        [HttpGet("GetOrderById")]
        public async Task<IActionResult> GetOrderById([FromQuery] GetOrderByIdRequest request)
        {
            var data = await Mediator.Send(request);
            return Ok(data);
        }

        [HttpGet("GetOrdersByStatus")]
        public async Task<IActionResult> GetOrdersByStatus([FromQuery] GetOrdersByStatusRequest request)
        {
            var data = await Mediator.Send(request);
            return Ok(data);
        }

    }
}
