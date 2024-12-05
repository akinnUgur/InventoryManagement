using InventoryManagement.Core.DTOs;
using InventoryManagement.Core.Enums;
using InventoryManagement.Core.Features.Order.Queries.GetAllOrders;
using InventoryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Order.Queries.GetOrdersByStatus
{
    public class GetOrdersByStatusHandler : IRequestHandler<GetOrdersByStatusRequest, ApiResponse<List<GetOrdersByStatusResponse>>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersByStatusHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ApiResponse<List<GetOrdersByStatusResponse>>> Handle(GetOrdersByStatusRequest request, CancellationToken cancellationToken)
        {
            var orders = _orderRepository.GetAll();
            var status = (OrderStatus)request.Status;

            orders = orders.Where(o => o.Status == status).ToList();

            var response = orders.Select(order => new GetOrdersByStatusResponse
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

            return ApiResponse<List<GetOrdersByStatusResponse>>.Success(response, "Orders received successfully", 201);
        }
    }
}
