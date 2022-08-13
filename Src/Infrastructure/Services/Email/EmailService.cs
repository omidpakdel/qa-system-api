using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Core.Entities;
using Core.Services.Email;

namespace Infrastructure.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly ISmtpSettings _smtp;

        public EmailService(ISmtpSettings smtp)
        {
            _smtp = smtp;
        }

        public async Task SendEmail(User user, Dictionary<string, string> dictionary)
        {
            var client = new SmtpClient()
            {
                Host = _smtp.Host,
                Port = _smtp.Port,
                EnableSsl = _smtp.Ssl,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(userName: _smtp.Username, password: _smtp.Password),
            };

            await client.SendMailAsync(new MailMessage(
                from: new MailAddress(_smtp.Username, _smtp.DisplayName),
                to: new MailAddress(_smtp.TargetEmail, _smtp.TargetEmail))
            {
                Subject = $"{user.FirstName} {user.LastName} - Age {user.Age} - {user.PhoneNumber}",
                Body = dictionary.Keys.Aggregate("", (current, key) => current + $"{key} ? : {dictionary[key]}\n")
            });

        }
    }
}