using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 邮件群发
{
    public class EmailQQ:EmailSuper
    {
        public EmailQQ()
        {
            this.DomainName = "@qq.com";
            this.POP3 = "pop3.qq.com";
            this.SMTP = "smtp.qq.com";
        }

    }
}
