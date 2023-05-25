using Do_an_co_so.Intefaces;
using MailChimp.Net.Models;
using MailKit.Net.Smtp;
using System.Net;
using System.Net;
using System.Net.Mail;

namespace Do_an_co_so.Repositories
{
    public class EmailSender:IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new System.Net.Mail.SmtpClient("smtp.office365.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("your.email@live.com", "your password")
            };

            return client.SendMailAsync(
                new MailMessage(from: "your.email@live.com",
                                to: email,
                                subject,
                                message
                                ));
        }
    }
}
