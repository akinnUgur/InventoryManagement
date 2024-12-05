using InventoryManagement.Core.DTOs;
using InventoryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Order.Queries.GetAllOrders
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersRequest, ApiResponse<List<GetAllOrdersResponse>>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllOrdersHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ApiResponse<List<GetAllOrdersResponse>>> Handle(GetAllOrdersRequest request, CancellationToken cancellationToken)
        {
            var orders = _orderRepository.GetAll();
            var response = orders.Select(order => new GetAllOrdersResponse
            {
                Id = order.Id,
                Email = order.Email,
                Status = order.Status,
                OrderDate = order.OrderDate,
                Items = order.OrderItems.Select(item => new OrderItemDTO
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice 
                }).ToList()
            }).ToList();

            return ApiResponse<List<GetAllOrdersResponse>>.Success(response, "Orders retrieved successfully.");
        }
    }
}
