using InventoryManagement.Core.DTOs;
using InventoryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Order.Queries.GetOrderById
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdRequest, ApiResponse<GetOrderByIdResponse>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ApiResponse<GetOrderByIdResponse>> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);

            GetOrderByIdResponse response = new GetOrderByIdResponse
            {
                Email = order.Email,
                Id = order.Id,
                Items = order.OrderItems.Select(item => new OrderItemDTO
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice
                }).ToList(),
                OrderDate = order.OrderDate,
                Status = order.Status
            };

            return ApiResponse<GetOrderByIdResponse>.Success(response, "Order received successfully", 201);
        }
    }
}
