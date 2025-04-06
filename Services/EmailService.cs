using System.Net;
using System.Net.Mail;

namespace BTL_Web_NC.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _host;
        private readonly int _port;
        private readonly bool _enableSsl;
        private readonly string _userName;
        private readonly string _password;
        private readonly string _from;

        public EmailService(IConfiguration configuration)
        {
            _host = configuration["EmailSettings:Host"];
            _port = int.Parse(configuration["EmailSettings:Port"]);
            _enableSsl = bool.Parse(configuration["EmailSettings:EnableSsl"]);
            _userName = configuration["EmailSettings:UserName"];
            _password = configuration["EmailSettings:Password"];
            _from = configuration["EmailSettings:From"];
        }

        public async Task SendEmailAsync(string to, string subject, string body, bool isHtml = true)
        {
            using (var client = new SmtpClient(_host, _port))
            {
                client.EnableSsl = _enableSsl;
                client.Credentials = new NetworkCredential(_userName, _password);
                
                using (var message = new MailMessage())
                {
                    message.From = new MailAddress(_from);
                    message.To.Add(to);
                    message.Subject = subject;
                    message.Body = body;
                    message.IsBodyHtml = isHtml;
                    
                    await client.SendMailAsync(message);
                }
            }
        }


        
    }
}