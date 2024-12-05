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
        private readonly IOrderService _orderService;

        public ChangeStatusHandler(IOrderRepository orderRepository, IOrderService orderService)
        {
            _orderRepository = orderRepository;
            _orderService = orderService;
        }

        public async Task<ApiResponse<ChangeStatusResponse>> Handle(ChangeStatusRequest request, CancellationToken cancellationToken)
        {
            await _orderService.UpdateOrderStatusAsync(request.OrderId, (Enums.OrderStatus)request.OrderStatus);


            return ApiResponse<ChangeStatusResponse>.Success(new(), $"Order No: {request.OrderId}'s Status has been changed to {(Enums.OrderStatus)request.OrderStatus} successfully", 201);
        }
    }
}
