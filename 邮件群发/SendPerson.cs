using System;
using System.Collections.Generic;
using System.Text;

namespace 邮件群发
{
    public class SendPerson
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string uAccount;

        public string UAccount
        {
            get { return uAccount; }
            set { uAccount = value; }
        }

        private string uPwd;

        public string UPwd
        {
            get { return uPwd; }
            set { uPwd = value; }
        }

        private string uDomain;

        public string UDomain
        {
            get { return uDomain; }
            set { uDomain = value; }
        }

        private string uEmail;

        public string UEmail
        {
            get { return uEmail; }
            set { uEmail = value; }
        }

        private string uServiceName;

        public string UServiceName
        {
            get { return uServiceName; }
            set { uServiceName = value; }
        }

        private string uServiceFullName;

        public string UServiceFullName
        {
            get { return uServiceFullName; }
            set { uServiceFullName = value; }
        }

        private string uName;

        public string UName
        {
            get { return uName; }
            set { uName = value; }
        }

        public override string ToString()
        {
            return this.UAccount;
        }
    }
}
