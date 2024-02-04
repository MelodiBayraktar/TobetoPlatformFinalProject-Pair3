using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concretes;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Core.Utilities.Business.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(EmailDto emailDtoRequest)
        {
            var emailPortValue = _config.GetSection("EmailConfig:EmailPort").Value;
            var emailPort = int.Parse(emailPortValue);
            var emailHostValue = _config.GetSection("EmailConfig:EmailHost").Value;
            var emailUsername = _config.GetSection("EmailConfig:EmailUsername").Value;
            var emailPassword = _config.GetSection("EmailConfig:EmailPassword").Value;
            var emailFrom = _config.GetSection("EmailConfig:EmailFrom").Value;


            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(emailFrom));
            email.To.Add(MailboxAddress.Parse(emailDtoRequest.To));
            email.Subject = emailDtoRequest.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = emailDtoRequest.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(emailHostValue, emailPort, MailKit.Security.SecureSocketOptions.StartTls); //gmail, outlook vb.
            smtp.Authenticate(emailUsername, emailPassword);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
