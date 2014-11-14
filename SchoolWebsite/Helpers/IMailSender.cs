using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebsite.Helpers
{
    public interface IMailSender
    {
         void send(string emailAdr, string name, string content);
    }
}
