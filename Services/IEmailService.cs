using System.Net;
using System.Net.Mail;

namespace BTL_Web_NC.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body, bool isHtml = true);


        
    }
}