
using ASPNetCoreWebAPIClass.Domain.Services.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace ASPNetCoreWebAPIClass.Domain.Services
{
    public interface IEmailService
    {
        void SendEmail(EmailModel model);
    }

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(EmailModel model)
        {
            var smtpConnection = _config.GetSection("Email:SmtpConnection").Value;
            var senderEmail = _config.GetSection("Email:SenderEmail").Value;
            var senderPassword = _config.GetSection("Email:SenderPassword").Value;



            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(model.emailFrom));
            email.To.Add(MailboxAddress.Parse(model.emailTo));
            email.Subject = model.subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = model.body
            };

            using var smtp = new SmtpClient();
            smtp.Connect(smtpConnection, 465, useSsl: true);
            smtp.Authenticate(senderEmail, senderPassword);

            smtp.Send(email);
            smtp.Disconnect(true);



        }
    }

    // 
}
