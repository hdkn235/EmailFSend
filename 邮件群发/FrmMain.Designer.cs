namespace 邮件群发
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.cmbEmailList = new System.Windows.Forms.ComboBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbService = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDomain = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clbContactList = new System.Windows.Forms.CheckedListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddContact = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tslSelAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslReverSel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tslDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tslImp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tslPick = new System.Windows.Forms.ToolStripButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gbProgramSet = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtDelay = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rtxtContent = new System.Windows.Forms.RichTextBox();
            this.txtProject = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSet = new System.Windows.Forms.Button();
            this.txtCount = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbProgramSet.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.cmbEmailList);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.cmbService);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPwd);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbDomain);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(875, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "发件人信息";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(295, 56);
            this.txtID.Name = "txtID";
            this.txtID.PasswordChar = '*';
            this.txtID.Size = new System.Drawing.Size(32, 23);
            this.txtID.TabIndex = 14;
            this.txtID.Visible = false;
            // 
            // cmbEmailList
            // 
            this.cmbEmailList.BackColor = System.Drawing.Color.Azure;
            this.cmbEmailList.FormattingEnabled = true;
            this.cmbEmailList.Location = new System.Drawing.Point(99, 25);
            this.cmbEmailList.Name = "cmbEmailList";
            this.cmbEmailList.Size = new System.Drawing.Size(175, 22);
            this.cmbEmailList.TabIndex = 0;
            this.cmbEmailList.SelectedIndexChanged += new System.EventHandler(this.cmbEmailList_SelectedIndexChanged);
            // 
            // btnNew
            // 
            this.btnNew.AutoSize = true;
            this.btnNew.Location = new System.Drawing.Point(605, 59);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 24);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "新建";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDel
            // 
            this.btnDel.AutoSize = true;
            this.btnDel.Location = new System.Drawing.Point(769, 59);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 24);
            this.btnDel.TabIndex = 7;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.Azure;
            this.txtName.Location = new System.Drawing.Point(99, 59);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(175, 23);
            this.txtName.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 9;
            this.label7.Text = "发件人";
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.Location = new System.Drawing.Point(687, 59);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbService
            // 
            this.cmbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbService.FormattingEnabled = true;
            this.cmbService.Items.AddRange(new object[] {
            "SMTP"});
            this.cmbService.Location = new System.Drawing.Point(724, 25);
            this.cmbService.Name = "cmbService";
            this.cmbService.Size = new System.Drawing.Size(121, 22);
            this.cmbService.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(683, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 6;
            this.label6.Text = "服务";
            // 
            // txtPwd
            // 
            this.txtPwd.BackColor = System.Drawing.Color.Azure;
            this.txtPwd.Location = new System.Drawing.Point(514, 24);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(153, 23);
            this.txtPwd.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(473, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "密码";
            // 
            // cmbDomain
            // 
            this.cmbDomain.BackColor = System.Drawing.Color.Azure;
            this.cmbDomain.FormattingEnabled = true;
            this.cmbDomain.Location = new System.Drawing.Point(334, 23);
            this.cmbDomain.Name = "cmbDomain";
            this.cmbDomain.Size = new System.Drawing.Size(121, 22);
            this.cmbDomain.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(293, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "域名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "邮箱账号";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.clbContactList);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.toolStrip1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 471);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "收件人信息";
            // 
            // clbContactList
            // 
            this.clbContactList.BackColor = System.Drawing.Color.Azure;
            this.clbContactList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.clbContactList.FormattingEnabled = true;
            this.clbContactList.Location = new System.Drawing.Point(3, 59);
            this.clbContactList.Name = "clbContactList";
            this.clbContactList.Size = new System.Drawing.Size(256, 382);
            this.clbContactList.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAddContact);
            this.panel2.Controls.Add(this.txtEmail);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(256, 33);
            this.panel2.TabIndex = 11;
            // 
            // btnAddContact
            // 
            this.btnAddContact.AutoSize = true;
            this.btnAddContact.Location = new System.Drawing.Point(205, 6);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(48, 24);
            this.btnAddContact.TabIndex = 4;
            this.btnAddContact.Text = "添加";
            this.btnAddContact.UseVisualStyleBackColor = true;
            this.btnAddContact.Click += new System.EventHandler(this.btnAddContact_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.Azure;
            this.txtEmail.Location = new System.Drawing.Point(3, 6);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(196, 23);
            this.txtEmail.TabIndex = 9;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslSelAll,
            this.toolStripSeparator1,
            this.tslReverSel,
            this.toolStripSeparator2,
            this.tslDel,
            this.toolStripSeparator3,
            this.tslImp,
            this.toolStripSeparator4,
            this.tslPick});
            this.toolStrip1.Location = new System.Drawing.Point(3, 441);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(256, 27);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tslSelAll
            // 
            this.tslSelAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tslSelAll.Image = ((System.Drawing.Image)(resources.GetObject("tslSelAll.Image")));
            this.tslSelAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tslSelAll.Name = "tslSelAll";
            this.tslSelAll.Size = new System.Drawing.Size(41, 24);
            this.tslSelAll.Text = "全选";
            this.tslSelAll.Click += new System.EventHandler(this.btnSelAll_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tslReverSel
            // 
            this.tslReverSel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tslReverSel.Image = ((System.Drawing.Image)(resources.GetObject("tslReverSel.Image")));
            this.tslReverSel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tslReverSel.Name = "tslReverSel";
            this.tslReverSel.Size = new System.Drawing.Size(41, 24);
            this.tslReverSel.Text = "反选";
            this.tslReverSel.Click += new System.EventHandler(this.btnReverSel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // tslDel
            // 
            this.tslDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tslDel.Image = ((System.Drawing.Image)(resources.GetObject("tslDel.Image")));
            this.tslDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tslDel.Name = "tslDel";
            this.tslDel.Size = new System.Drawing.Size(41, 24);
            this.tslDel.Text = "删除";
            this.tslDel.Click += new System.EventHandler(this.btnDelContact_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // tslImp
            // 
            this.tslImp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tslImp.Image = ((System.Drawing.Image)(resources.GetObject("tslImp.Image")));
            this.tslImp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tslImp.Name = "tslImp";
            this.tslImp.Size = new System.Drawing.Size(41, 24);
            this.tslImp.Text = "导入";
            this.tslImp.Click += new System.EventHandler(this.btnImpContact_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // tslPick
            // 
            this.tslPick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tslPick.Image = ((System.Drawing.Image)(resources.GetObject("tslPick.Image")));
            this.tslPick.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tslPick.Name = "tslPick";
            this.tslPick.Size = new System.Drawing.Size(41, 24);
            this.tslPick.Text = "采集";
            this.tslPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gbProgramSet);
            this.groupBox3.Controls.Add(this.rtxtContent);
            this.groupBox3.Controls.Add(this.txtProject);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(265, 88);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(610, 439);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "邮件内容";
            // 
            // gbProgramSet
            // 
            this.gbProgramSet.Controls.Add(this.label9);
            this.gbProgramSet.Controls.Add(this.btnCancel);
            this.gbProgramSet.Controls.Add(this.btnConfirm);
            this.gbProgramSet.Controls.Add(this.txtDelay);
            this.gbProgramSet.Controls.Add(this.label8);
            this.gbProgramSet.Location = new System.Drawing.Point(156, 148);
            this.gbProgramSet.Name = "gbProgramSet";
            this.gbProgramSet.Size = new System.Drawing.Size(282, 142);
            this.gbProgramSet.TabIndex = 4;
            this.gbProgramSet.TabStop = false;
            this.gbProgramSet.Text = "设置";
            this.gbProgramSet.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(218, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 14);
            this.label9.TabIndex = 4;
            this.label9.Text = "秒";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(164, 99);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(44, 99);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtDelay
            // 
            this.txtDelay.BackColor = System.Drawing.Color.Azure;
            this.txtDelay.Location = new System.Drawing.Point(114, 47);
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.Size = new System.Drawing.Size(100, 23);
            this.txtDelay.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(44, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "发送延迟：";
            // 
            // rtxtContent
            // 
            this.rtxtContent.BackColor = System.Drawing.Color.Azure;
            this.rtxtContent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtxtContent.Location = new System.Drawing.Point(3, 82);
            this.rtxtContent.Name = "rtxtContent";
            this.rtxtContent.Size = new System.Drawing.Size(604, 354);
            this.rtxtContent.TabIndex = 0;
            this.rtxtContent.Text = "";
            // 
            // txtProject
            // 
            this.txtProject.BackColor = System.Drawing.Color.Azure;
            this.txtProject.Location = new System.Drawing.Point(4, 36);
            this.txtProject.Name = "txtProject";
            this.txtProject.Size = new System.Drawing.Size(603, 23);
            this.txtProject.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(3, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "主题";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "正文";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSet);
            this.panel1.Controls.Add(this.txtCount);
            this.panel1.Controls.Add(this.lblState);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(262, 527);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(613, 32);
            this.panel1.TabIndex = 5;
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(446, 5);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 6;
            this.btnSet.Text = "设置";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // txtCount
            // 
            this.txtCount.AutoSize = true;
            this.txtCount.Location = new System.Drawing.Point(231, 10);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(0, 14);
            this.txtCount.TabIndex = 5;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(294, 9);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(0, 14);
            this.lblState.TabIndex = 4;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(7, 5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(219, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(526, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(366, 5);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(875, 559);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "邮件群发系统 by 雨隹";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbProgramSet.ResumeLayout(false);
            this.gbProgramSet.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox clbContactList;
        private System.Windows.Forms.TextBox txtProject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtxtContent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnAddContact;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbService;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDomain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.ComboBox cmbEmailList;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label txtCount;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tslSelAll;
        private System.Windows.Forms.ToolStripButton tslReverSel;
        private System.Windows.Forms.ToolStripButton tslDel;
        private System.Windows.Forms.ToolStripButton tslImp;
        private System.Windows.Forms.ToolStripButton tslPick;
        private System.Windows.Forms.GroupBox gbProgramSet;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox txtDelay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSet;
    }
}

