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
        private readonly IProductRepository _productRepository;

        public CreateOrderHandler(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        async Task<ApiResponse<CreateOrderResponse>> IRequestHandler<CreateOrderRequest, ApiResponse<CreateOrderResponse>>.Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            // Sipariş oluşturuluyor
            var order = new Entities.Order
            {
                Email = request.Email,
                OrderDate = DateTime.UtcNow,
                Status = OrderStatus.Pending,
                OrderItems = new List<OrderItem>()
            };

            foreach (var item in request.Items)
            {
           
                var product = await _productRepository.GetByIdAsync(item.ProductId);

                if (product == null)
                {
                    return ApiResponse<CreateOrderResponse>.Error("Product not found", 404);
                }

              
                if (product.Stock < item.Quantity)
                {
                    return ApiResponse<CreateOrderResponse>.Error($"Not enough stock for product {product.Name}", 400);
                }

           
                var orderItem = new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    TotalPrice = product.Price * item.Quantity
                };

                order.OrderItems.Add(orderItem);

               
                product.Stock -= item.Quantity;
                await _productRepository.Update(product);  

            }

            // Siparişi veritabanına kaydediyoruz
            await _orderRepository.AddAsync(order);

            var response = new CreateOrderResponse
            {
                OrderId = order.Id
            };

            return ApiResponse<CreateOrderResponse>.Success(response, "Order created successfully", 201);
        }
    }
}
