using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;

namespace Restaurant.Services
{
    public class EmailService
    {
        public void SendEmail(string emailBody, string emailTo)
        {
            //https://ethereal.email/ was used for this project.

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("earl.labadie@ethereal.email"));
            email.To.Add(MailboxAddress.Parse(emailTo));
            email.Subject = "Restaurant Check";
            email.Body = new TextPart(TextFormat.Plain) { Text = emailBody };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("earl.labadie@ethereal.email", "Qy1CeM7vjPqRkJ1F8V");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
