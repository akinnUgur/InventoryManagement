using InventoryManagement.Core.DTOs;
using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Enums;
using InventoryManagement.Core.Interfaces;
using InventoryManagement.Core.Interfaces.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Order.Commands.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, ApiResponse<CreateOrderResponse>>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;

        }

        async Task<ApiResponse<CreateOrderResponse>> IRequestHandler<CreateOrderRequest, ApiResponse<CreateOrderResponse>>.Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var order = new Entities.Order
            {
                Email = request.Email,
                OrderDate = DateTime.UtcNow,
                Status = OrderStatus.Pending,
                OrderItems = request.Items.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    TotalPrice = i.TotalPrice * i.Quantity,
                }).ToList()
            };



            await _orderRepository.AddAsync(order);


            var response = new CreateOrderResponse
            {
                OrderId = order.Id
            };

            return ApiResponse<CreateOrderResponse>.Success(response, "Order created successfully", 201);

        }
    }
}
