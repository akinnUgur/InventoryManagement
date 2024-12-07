using InventoryManagement.Core.DTOs.Mail;
using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Enums;
using InventoryManagement.Core.Interfaces.Base;
using InventoryManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Core.Entities.BaseEntities;

namespace InventoryManagement.Infrastructure.Services
{
    public class EmailObserver : Core.Interfaces.Base.IObserver<Order>  // IObserver<Order> implement ediliyor
    {
        private readonly IEmailService _emailService;

        public EmailObserver(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task NotifyAsync(Order order)
        {
            // Durum değişikliklerine göre e-posta gönderme
            if (order.Status == OrderStatus.Pending)
            {
                var mailRequest = new MailRequest
                {
                    To = order.Email,
                    Subject = "Your Order is currently in pending",
                    Body = $"Your order with ID {order.Id} has been received and is currently pending! If there will be any changes we will inform you via Email"
                };
                await _emailService.SendEmail(mailRequest);
            }
            else if (order.Status == OrderStatus.InProgress)
            {
                var mailRequest = new MailRequest
                {
                    To = order.Email,
                    Subject = "Your Order is currently in progress",
                    Body = $"Your order with ID {order.Id} is currently being processed. We plan to deliver your order to you as soon as possible."
                };
                await _emailService.SendEmail(mailRequest);
            }
            else if(order.Status == OrderStatus.Cancelled)
            {
                var mailRequest = new MailRequest
                {
                    To = order.Email,
                    Subject = "Your Order has been cancelled",
                    Body = $"Your order with ID {order.Id} has been cancelled due to problems on our side. We apologize for the inconvenience."
                };
                await _emailService.SendEmail(mailRequest);
            }
            else if (order.Status == OrderStatus.Refunded)
            {
                var mailRequest = new MailRequest
                {
                    To = order.Email,
                    Subject = "Your Order is refunded",
                    Body = $"The amount of your order has been refunded to you. We apologize for the inconvenience that occurred again. (order id: {order.Id})"
                };
                await _emailService.SendEmail(mailRequest);
            }
            else if (order.Status == OrderStatus.Completed)
            {
                var mailRequest = new MailRequest
                {
                    To = order.Email,
                    Subject = "Your Order is completed",
                    Body = $"Your order with ID {order.Id} has been completed and sent to you. We would like to thank you for choosing us."
                };
                await _emailService.SendEmail(mailRequest);
            }

        }
    }

}
