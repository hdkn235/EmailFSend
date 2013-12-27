using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace 邮件群发
{
    public partial class FrmAddContact : Form
    {
        Action<string> myAction;

        public FrmAddContact()
        {
            InitializeComponent();
        }

        public FrmAddContact(Action<string> addContact)
            : this()
        {
            myAction = addContact;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
            myAction(txtContact.Text.Trim());
        }

    }
}
