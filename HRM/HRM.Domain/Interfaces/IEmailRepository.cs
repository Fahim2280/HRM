using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.Domain.Interfaces
{
    public interface IEmailRepository
    {
        Task<bool> SendEmailAsync(string toEmail, string subject, string body);
    }
}
