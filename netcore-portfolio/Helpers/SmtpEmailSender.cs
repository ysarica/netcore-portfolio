using Microsoft.AspNetCore.Identity.UI.Services;
using netcore_portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace netcore_portfolio.Helpers
{
    public class SmtpEmailSender
    {
        private readonly Context _context;

        public SmtpEmailSender(Context context)
        {
            _context = context;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var smtpConfig = _context.SmtpConfigs.FirstOrDefault();

            var emailMessage = new MailMessage();
            emailMessage.To.Add(new MailAddress(toEmail));
            emailMessage.From = new MailAddress(smtpConfig.UserName);
            emailMessage.Subject = subject;
            emailMessage.Body = body;
            emailMessage.IsBodyHtml = true;

            using (var client = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = smtpConfig.UserName,
                    Password = smtpConfig.Password
                };

                client.Credentials = credential;
                client.Host = smtpConfig.Server;
                client.Port = smtpConfig.Port;
                client.EnableSsl = smtpConfig.EnableSSL;
                await client.SendMailAsync(emailMessage);
            }
        }
    }
}

