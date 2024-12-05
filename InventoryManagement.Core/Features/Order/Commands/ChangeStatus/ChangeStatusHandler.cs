using InventoryManagement.Core.DTOs;
using InventoryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Features.Order.Commands.ChangeStatus
{
    public class ChangeStatusHandler : IRequestHandler<ChangeStatusRequest, ApiResponse<ChangeStatusResponse>>
    {
        private readonly IOrderRepository _orderRepository;

        public ChangeStatusHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ApiResponse<ChangeStatusResponse>> Handle(ChangeStatusRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId);

            switch (request.OrderStatus)
            {
                case 1: order.Status = Enums.OrderStatus.Pending; break;
                case 2: order.Status = Enums.OrderStatus.Shipped; break;
                case 3: order.Status = Enums.OrderStatus.Arrived; break;
                    default: break;    
            }

            await _orderRepository.Update(order);


            return ApiResponse<ChangeStatusResponse>.Success(new(), $"Order No: {order.Id}'s Status has been changed to {order.Status} successfully", 201);
        }
    }
}
