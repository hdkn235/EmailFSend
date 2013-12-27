using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 邮件群发
{
    class Email163 : EmailSuper
    {
        public Email163()
        {
            this.DomainName = "@163.com";
            this.POP3 = "pop3.163.com";
            this.SMTP = "smtp.163.com";
        }
    }
}
