using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace OnlineBookStore.Utility
{
    
    public class EmailSender : IEmailSender
    {
        private readonly EmailOptions _emailOptions;
        public EmailSender(IOptions<EmailOptions> options)
        {
            _emailOptions = options.Value;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            string fromMail = _emailOptions.FromEmail;
            string fromPassword = _emailOptions.FromPassword;

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = subject;
            message.To.Add(new MailAddress(email));
            message.Body = "<html><body> " + htmlMessage + " </body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };
            smtpClient.Send(message);
        }
/*        private Task Execute(string sendGridKey, string subject, string message, string email)
        {
            var client = new SendGridClient(sendGridKey);
            var from = new EmailAddress("admin@OnlineBookStore.com", "Online Book Store");
            var to = new EmailAddress(email, "End User");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, "");
            return client.SendEmailAsync(msg);
        }*/
    }
   
}
