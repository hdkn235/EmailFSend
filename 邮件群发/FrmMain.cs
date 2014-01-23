using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using HDHelper;
using System.Data.OleDb;

namespace 邮件群发
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        //关闭按钮事件
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //保存发件人信息到xml按钮事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region 序列化SendPerson对象

            ////序列化SendPerson对象
            //using (FileStream fs = new FileStream("SendPerson.xml", FileMode.Create, FileAccess.Write))
            //{
            //    XmlSerializer xs = new XmlSerializer(typeof(SendPerson));
            //    xs.Serialize(fs, sp);
            //} 
            #endregion

            if (CheckSendPerson())
            {
                SendPerson sp = ControlsToPerson();

                #region 保存数据到Access数据库

                if (string.IsNullOrEmpty(txtID.Text))
                {
                    InertUsers(sp);
                }
                else
                {
                    UpdateUsers(sp, Convert.ToInt32(txtID.Text));
                }

                #endregion
            }


        }

        /// <summary>
        /// 检查发件人信息
        /// </summary>
        /// <returns></returns>
        private bool CheckSendPerson()
        {
            if (string.IsNullOrEmpty(cmbEmailList.Text))
            {
                MessageBox.Show("邮箱账号不能为空！");
                return false;
            }
            if (string.IsNullOrEmpty(cmbDomain.Text))
            {
                MessageBox.Show("域名不能为空！");
                return false;
            }
            if (string.IsNullOrEmpty(txtPwd.Text))
            {
                MessageBox.Show("密码不能为空！");
                return false;
            }
            return true;
        }

        //插入新User
        private void InertUsers(SendPerson sp)
        {
            if (!CheckAccount(sp.UAccount))
            {
                MessageBox.Show("该账号已存在，请重新输入！");
                return;
            }
            string sql = @"insert into Users(uAccount,uPwd,uDomain,uName,uEmail,uServiceName,uServiceFullName) values(@uAccount,@uPwd,@uDomain,@uName,@uEmail,@uServiceName,@uServiceFullName)";
            OleDbParameter[] oPara = {new OleDbParameter("@uAccount",sp.UAccount)
                                     ,new OleDbParameter("@uPwd",sp.UPwd)
                                     ,new OleDbParameter("@uDomain",sp.UDomain)
                                     ,new OleDbParameter("@uName",sp.UName)
                                     ,new OleDbParameter("@uEmail",sp.UEmail)
                                     ,new OleDbParameter("@uServiceName",sp.UServiceName)
                                     ,new OleDbParameter("@uServiceFullName",sp.UServiceFullName)
                                     };
            try
            {
                AccessHelper.ExecuteNonQuery(sql, oPara);
                MessageBox.Show("保存成功！");
                LoadAccount();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        //更新users
        private void UpdateUsers(SendPerson sp, int id)
        {
            string sql = @"update Users set uAccount=@uAccount,uPwd=@uPwd,uDomain=@uDomain,uName=@uName,uEmail=@uEmail,uServiceName=@uServiceName,uServiceFullName=@uServiceFullName where ID=@ID";
            OleDbParameter[] oPara = {new OleDbParameter("@uAccount",sp.UAccount)
                                     ,new OleDbParameter("@uPwd",sp.UPwd)
                                     ,new OleDbParameter("@uDomain",sp.UDomain)
                                     ,new OleDbParameter("@uName",sp.UName)
                                     ,new OleDbParameter("@uEmail",sp.UEmail)
                                     ,new OleDbParameter("@uServiceName",sp.UServiceName)
                                     ,new OleDbParameter("@uServiceFullName",sp.UServiceFullName)
                                     ,new OleDbParameter("@ID",id)
                                     };
            try
            {
                AccessHelper.ExecuteNonQuery(sql, oPara);
                MessageBox.Show("保存成功！");
                LoadAccount();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        //检查账号是否已经输入
        private bool CheckAccount(string account)
        {
            string sql = @"select count(*) from Users where uAccount=@uAccount";
            OleDbParameter opara = new OleDbParameter("@uAccount", account);
            try
            {
                return Convert.ToInt32(AccessHelper.ExecuteScalar(sql, opara)) == 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //加载事件
        private void FrmMain_Load(object sender, EventArgs e)
        {
            EmailSuper[] es = { new EmailQQ(), new Email163() };
            cmbDomain.Items.AddRange(es);
            cmbDomain.Items.Insert(0, "");
            cmbService.SelectedIndex = 0;
            txtDelay.Text = CommonFunc.ReadSet("delay");

            #region 加载xml发件人信息
            //if (!File.Exists("SendPerson.xml")) return;

            //SendPerson sp;
            ////反序列化SendPerson对象
            //using (FileStream fs = new FileStream("SendPerson.xml", FileMode.Open, FileAccess.Read))
            //{
            //    XmlSerializer xs = new XmlSerializer(typeof(SendPerson));
            //    sp = xs.Deserialize(fs) as SendPerson;
            //}

            //cmbEmailList.Text = sp.UAccount;
            //txtPwd.Text = sp.UPwd;
            //cmbDomain.Text = sp.UDomain;
            //cmbService.Text = sp.UServiceName;
            //txtName.Text = sp.UName; 
            #endregion

            LoadAccount();
        }

        //加载账号列表
        private void LoadAccount()
        {
            cmbEmailList.Items.Clear();
            string sql = @"select * from Users";
            SendPerson[] sps = DataTableToPerson(AccessHelper.GetDataSet(sql).Tables[0]);
            if (sps != null)
            {
                cmbEmailList.Items.AddRange(sps);
            }
        }

        //添加联系人
        private void AddContact(string contact)
        {
            clbContactList.Items.Add(contact);
            clbContactList.SetItemChecked(clbContactList.Items.Count - 1, true);
        }

        //添加按钮事件
        private void btnAddContact_Click(object sender, EventArgs e)
        {
            //FrmAddContact frm = new FrmAddContact(AddContact);
            //frm.ShowDialog();
            string email = txtEmail.Text.Trim();
            if (!string.IsNullOrEmpty(email))
            {
                AddContact(email);
            }
        }

        /// <summary>
        /// 发送邮件方法
        /// </summary>
        /// <param name="sp">发件人对象</param>
        /// <param name="contacts">收件人数组</param>
        /// <param name="subject">主题</param>
        /// <param name="content">内容</param>
        /// <param name="delay">延迟</param>
        private void SendEmail(SendPerson sp, string[] contacts, string subject, string content, int delay)
        {
            int temp = 0;
            for (int i = 0; i < contacts.Length; i++)
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(sp.UEmail, sp.UName);//原邮件地址，发件人
                mail.To.Add(contacts[i]);//目的邮件地址，可以有多个人
                mail.Subject = subject;//发送邮件的标题
                mail.SubjectEncoding = Encoding.UTF8;
                mail.Body = content;//发送邮件内容
                mail.BodyEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;
                //SMTP服务器
                SmtpClient client = new SmtpClient(sp.UServiceFullName);//默认端口为25
                //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //client.EnableSsl = true;
                //client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential(sp.UAccount, sp.UPwd);//获取或者设置用户验证发件人的凭据    用户名和密码初始化
                try
                {
                    client.Send(mail);
                    temp++;
                }
                catch (Exception ex)
                {
                    continue;
                }
                SetCount(contacts.Length, temp, true);
                Thread.Sleep(delay);
            }
            SetCount(contacts.Length, temp, false);
            MessageBox.Show("发送完毕！");
        }

        /// <summary>
        /// 跨线程调用控件 设置发送状态
        /// </summary>
        /// <param name="total">总数</param>
        /// <param name="index">第几封</param>
        private void SetCount(int total, int index, bool isPb)
        {
            if (txtCount.InvokeRequired)
            {
                Action<int, int, bool> a = SetCount;
                this.Invoke(a, total, index, isPb);
            }
            else
            {
                txtCount.Text = string.Format("总共{0}封，已发送{1}封", total, index);
                if (isPb)
                {
                    progressBar1.Value += 1;
                }
            }
        }

        //发送按钮事件
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                SendPerson sp = ControlsToPerson();

                List<string> list = new List<string>();
                for (int i = 0; i < clbContactList.Items.Count; i++)
                {
                    if (clbContactList.GetItemChecked(i))
                    {
                        list.Add(clbContactList.Items[i].ToString());
                    }
                }

                if (list.Count == 0)
                {
                    MessageBox.Show("请选择收件人！");
                    return;
                }
                else
                {
                    progressBar1.Maximum = list.Count;
                    progressBar1.Value = 0;
                }
                string subject = txtProject.Text;
                string content = rtxtContent.Text;
                int delay = Convert.ToInt32(txtDelay.Text) * 1000;

                Thread thread = new Thread(delegate() { SendEmail(sp, list.ToArray(), subject, content, delay); });
                thread.Name = "sendEmail";
                thread.IsBackground = true;
                thread.Start();
            }
        }

        //将datatable转化成sendperson数组
        private SendPerson[] DataTableToPerson(DataTable dt)
        {
            if (dt.Rows.Count == 0) return null;
            List<SendPerson> list = new List<SendPerson>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SendPerson sp = new SendPerson();
                sp.Id = Convert.ToInt32(dt.Rows[i]["ID"]);
                sp.UAccount = dt.Rows[i]["uAccount"].ToString();
                sp.UPwd = dt.Rows[i]["uPwd"].ToString();
                sp.UDomain = dt.Rows[i]["uDomain"].ToString();
                sp.UEmail = dt.Rows[i]["uEmail"].ToString();
                sp.UName = dt.Rows[i]["uName"].ToString();
                sp.UServiceName = dt.Rows[i]["uServiceName"].ToString();
                sp.UServiceFullName = dt.Rows[i]["uServiceFullName"].ToString();
                list.Add(sp);
            }

            return list.ToArray();
        }

        //输入添加到对象中
        private SendPerson ControlsToPerson()
        {
            SendPerson sp = new SendPerson();
            sp.UAccount = cmbEmailList.Text;
            sp.UDomain = cmbDomain.SelectedItem.ToString();
            sp.UEmail = cmbEmailList.Text + cmbDomain.SelectedItem.ToString();
            sp.UServiceName = cmbService.SelectedItem.ToString();
            sp.UPwd = txtPwd.Text;
            sp.UName = txtName.Text;
            sp.UServiceFullName = (cmbDomain.SelectedItem as EmailSuper).GetServiceName(cmbService.SelectedItem.ToString());
            return sp;
        }

        //全选按钮事件
        private void btnSelAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbContactList.Items.Count; i++)
            {
                clbContactList.SetItemChecked(i, true);
            }
        }

        //删除按钮事件
        private void btnDelContact_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbContactList.Items.Count; i++)
            {
                if (clbContactList.GetItemChecked(i))
                {
                    clbContactList.Items.RemoveAt(i);
                    i--;
                }
            }
        }

        //导入按钮事件
        private void btnImpContact_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string txt = File.ReadAllText(openFileDialog1.FileName);
                ImpEmail(txt);
            }
        }

        //将UEmail批量加入列表中
        private void ImpEmail(string txt)
        {
            List<string> list = new List<string>();
            MatchCollection mc = Regex.Matches(txt, @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)");
            foreach (Match m in mc)
            {
                if (m.Success)
                {
                    list.Add(m.Groups[1].Value);
                }
            }
            int length = clbContactList.Items.Count;
            clbContactList.Items.AddRange(list.ToArray());
            for (int i = length; i < clbContactList.Items.Count; i++)
            {
                clbContactList.SetItemChecked(i, true);
            }
        }

        //反选按钮事件
        private void btnReverSel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbContactList.Items.Count; i++)
            {
                if (clbContactList.GetItemChecked(i))
                {
                    clbContactList.SetItemChecked(i, false);
                }
                else
                {
                    clbContactList.SetItemChecked(i, true);
                }
            }
        }

        //检查输入项
        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(cmbEmailList.Text))
            {
                MessageBox.Show("邮箱账号不能为空！");
                return false;
            }
            if (string.IsNullOrEmpty(cmbDomain.SelectedItem.ToString()))
            {
                MessageBox.Show("域名不能为空！");
                return false;
            }
            if (string.IsNullOrEmpty(txtPwd.Text))
            {
                MessageBox.Show("密码不能为空！");
                return false;
            }
            if (string.IsNullOrEmpty(cmbService.SelectedItem.ToString()))
            {
                MessageBox.Show("服务不能为空！");
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("发件人不能为空！");
                return false;
            }
            if (string.IsNullOrEmpty(txtProject.Text))
            {
                MessageBox.Show("主题不能为空！");
                return false;
            }
            return true;
        }

        //采集qq邮箱
        private void btnPick_Click(object sender, EventArgs e)
        {
            FrmPickEmail fpe = FrmPickEmail.GetInstanceArgs(ImpEmail);
            fpe.Show();
        }

        //账号列表选择事件
        private void cmbEmailList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PersonToControls(cmbEmailList.SelectedItem as SendPerson);
        }

        //sendperson对象添加到控件中
        private void PersonToControls(SendPerson sp)
        {
            cmbEmailList.Text = sp.UAccount;
            txtPwd.Text = sp.UPwd;
            cmbDomain.Text = sp.UDomain;
            cmbService.Text = sp.UServiceName;
            txtName.Text = sp.UName;
            txtID.Text = sp.Id.ToString();
        }

        //新建按钮事件
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        //清楚发件人信息输入
        private void ClearInput()
        {
            cmbEmailList.Text = "";
            txtPwd.Text = "";
            cmbDomain.SelectedIndex = 0;
            cmbService.SelectedIndex = 0;
            txtName.Text = "";
            txtID.Text = "";
        }

        //删除按钮事件
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) return;
            if (MessageBox.Show("确定要删除该账号吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                string sql = @"delete from Users where ID = @ID";
                OleDbParameter osp = new OleDbParameter("@ID", Convert.ToInt32(txtID.Text));
                try
                {
                    AccessHelper.ExecuteNonQuery(sql, osp);
                    MessageBox.Show("删除成功！");
                    ClearInput();
                    LoadAccount();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            gbProgramSet.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtDelay.Text = CommonFunc.ReadSet("delay");
            gbProgramSet.Visible = false;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            CommonFunc.SaveSet("delay", txtDelay.Text.Trim());
            gbProgramSet.Visible = false;
        }
    }
}
