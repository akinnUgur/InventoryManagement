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
            if (order.Status == OrderStatus.Shipped)
            {
                var mailRequest = new MailRequest
                {
                    To = order.Email,
                    Subject = "Your Order has Shipped",
                    Body = $"Your order with ID {order.Id} has been shipped and is on its way!"
                };
                await _emailService.SendEmail(mailRequest);
            }
            else if (order.Status == OrderStatus.Arrived)
            {
                var mailRequest = new MailRequest
                {
                    To = order.Email,
                    Subject = "Your Order has Arrived",
                    Body = $"Your order with ID {order.Id} has arrived at its destination."
                };
                await _emailService.SendEmail(mailRequest);
            }
        }
    }

}
