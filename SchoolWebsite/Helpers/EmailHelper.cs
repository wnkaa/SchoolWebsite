using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
namespace SchoolWebsite.Helpers
{
    public class EmailHelper: IMailSender
    {
        
        private SmtpClient smtpClinet = new SmtpClient("smtp.gmail.com", 587)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential("wisniacrims@gmail.com", "123456pw")
        };
        public void send(string emailAdr, string name, string content)
        {
            string subject = "Question from " + name + " " + emailAdr;

            MailMessage msg = new MailMessage()
            {
                Subject = subject,
                Body = content
            };
            msg.From = new MailAddress("wisniacrims@gmail.com");
            msg.To.Add("wisniacrims@gmail.com");
          
            
            smtpClinet.Send(msg);
        }
    }
}