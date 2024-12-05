using InventoryManagement.Core.DTOs.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmail(MailRequest request);
    }
}
