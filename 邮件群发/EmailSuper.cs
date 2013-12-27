using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 邮件群发
{
    public class EmailSuper
    {
        public string DomainName { get; set; }

        public string POP3 { get; set; }

        public string SMTP { get; set; }

        public string GetServiceName(string mode)
        {
            switch (mode)
            {
                case "POP3":
                    return POP3;
                case "SMTP":
                    return SMTP;
            }
            return "";
        }

        public override string ToString()
        {
            return this.DomainName;
        }
    }
}
