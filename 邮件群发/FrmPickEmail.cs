using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using System.Configuration;
using System.Xml;
using mshtml;

namespace 邮件群发
{
    public partial class FrmPickEmail : Form
    {
        Action<string> ImpEmail = null;

        /// <summary>
        /// 开始采集标志
        /// </summary>
        bool flag = false;

        /// <summary>
        /// 存放采集的邮箱
        /// </summary>
        StringBuilder outSb = new StringBuilder();

        /// <summary>
        /// 全局实例变量，用来完成单例模式
        /// </summary>
        private static FrmPickEmail instance;

        /// <summary>
        /// 无参构造方法
        /// </summary>
        private FrmPickEmail()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 重载的构造函数，获得回调方法
        /// </summary>
        /// <param name="act"></param>
        private FrmPickEmail(Action<string> act)
            : this()
        {
            ImpEmail = act;
        }

        /// <summary>
        /// 获得窗体实例，保证唯一
        /// </summary>
        /// <returns></returns>
        public static FrmPickEmail GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmPickEmail();
            }
            return instance;
        }

        /// <summary>
        /// 获得窗体实例，保证唯一
        /// </summary>
        /// <param name="act">泛型委托，用于回调主窗体加载邮箱方法</param>
        /// <returns></returns>
        public static FrmPickEmail GetInstanceArgs(Action<string> act)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmPickEmail(act);
            }
            return instance;
        }

        /// <summary>
        /// 导出txt按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGet_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "文本文件|*.txt";
            saveFileDialog1.FileName = "Email";
            if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            EmailClass ec = new EmailClass();
            ec.Path = saveFileDialog1.FileName;
            ec.Content = webBrowser1.DocumentText;
            if (ec.Content == null || ec.Content == "") return;
            Thread th = new Thread(DownEmail);
            th.IsBackground = true;
            th.Start(ec);
        }

        /// <summary>
        /// 使用多线程提取Email地址到txt中
        /// </summary>
        /// <param name="obj"></param>
        private void DownEmail(object obj)
        {
            try
            {
                #region 网址下载
                //WebClient wc = new WebClient();
                //wc.Encoding = Encoding.UTF8;
                //string content = wc.DownloadString(url.ToString()); 
                #endregion

                EmailClass ec = obj as EmailClass;
                if (ec != null)
                {
                    //string sb = PickEmail(ec.Content);
                    File.WriteAllText(ec.Path, outSb.ToString());
                    MessageBox.Show("导出Email地址成功！");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("导出Email地址失败，原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 从字符串中提取email地址
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private string PickEmail(string content)
        {
            string txt = "";
            if (cbEnable.Checked && !string.IsNullOrEmpty(txtEmailSet.Text))
            {
                string[] str = txtEmailSet.Text.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries);
                List<string> list = new List<string>();
                for (int i = 0; i < str.Length; i++)
                {
                    list.Add("(" + str[i] + ")");
                }
                txt = "(" + string.Join("|", list) + ")";
            }
            else
            {
                txt = @"@[0-9A-Za-z_-]+(\.[0-9A-Za-z_-]+)+";
            }
            MatchCollection mc = Regex.Matches(content.ToString(), @"[0-9A-Za-z_-]+(\.[0-9A-Za-z_-]+)*" + txt);
            StringBuilder sb = new StringBuilder();
            foreach (Match m in mc)
            {
                if (m.Success)
                {
                    sb.Append(m.Value + "\r\n");
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 访问按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(txtPath.Text.Trim());
        }

        /// <summary>
        /// 后退按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        /// <summary>
        /// 前进按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnForward_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        /// <summary>
        /// 跳转页面时更新地址栏地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            txtPath.Text = webBrowser1.Url.ToString();
        }

        /// <summary>
        /// 可以在webBrowser中打开新网页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            if (webBrowser1.Document.ActiveElement != null)
            {
                webBrowser1.Navigate(webBrowser1.Document.ActiveElement.GetAttribute("href"));
                txtPath.Text = webBrowser1.Document.ActiveElement.GetAttribute("href");
            }
        }

        /// <summary>
        /// 提取按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCollect_Click(object sender, EventArgs e)
        {
            outSb.Clear();
            if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {
                msgDiv1.Text = "正在努力采集中，请稍等~~";
                msgDiv1.Show();
                flag = true;
                NextPage();
            }
            else
            {
                MessageBox.Show("页面还没加载完成，请稍等！");
            }
        }

        /// <summary>
        /// 采集邮箱方法
        /// </summary>
        private void Collect()
        {
            string content = webBrowser1.DocumentText;
            if (content == null || content == "") return;
            outSb.Append(PickEmail(content));
            //ImpEmail(PickEmail(content));
        }

        /// <summary>
        /// 鼠标点中地址栏时选中地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPath_MouseClick(object sender, MouseEventArgs e)
        {
            txtPath.SelectAll();
        }

        /// <summary>
        /// 设置按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfig_Click(object sender, EventArgs e)
        {
            gbSetEmail.Visible = true;
        }

        /// <summary>
        /// 设置--取消按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtEmailSet.Text = CommonFunc.ReadSet("format");
            cbEnable.Checked = CommonFunc.ReadSet("cbEnable") == "true" ? true : false;
            gbSetEmail.Visible = false;
        }

        /// <summary>
        /// 设置--确定按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            CommonFunc.SaveSet("format", txtEmailSet.Text.Trim());
            CommonFunc.SaveSet("cbEnable", cbEnable.Checked.ToString());
            CommonFunc.SaveSet("nextPageKey", txtNextPageKey.Text.Trim());
            gbSetEmail.Visible = false;
        }

        /// <summary>
        /// 窗体加载事件，读取配置文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPickEmail_Load(object sender, EventArgs e)
        {
            cbEnable.Checked = CommonFunc.ReadSet("cbEnable") == "True" ? true : false;
            txtEmailSet.Text = CommonFunc.ReadSet("format");
            txtNextPageKey.Text = CommonFunc.ReadSet("nextPageKey");
            txtEmailSet.Enabled = cbEnable.Checked;

        }

        /// <summary>
        /// 是否启用邮箱自定义配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbEnable_CheckedChanged(object sender, EventArgs e)
        {
            txtEmailSet.Enabled = cbEnable.Checked;
        }

        /// <summary>
        /// webBrowser1加载完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {
                NextPage();
            }
        }

        /// <summary>
        /// 打开下一页方法
        /// </summary>
        private void NextPage()
        {
            #region 链接方式跳转
            //if (flag)
            //{
            //    Collect();
            //    string path = "";
            //    HtmlElementCollection hd = webBrowser1.Document.GetElementsByTagName("a");
            //    foreach (HtmlElement he in hd)
            //    {
            //        if (he.InnerText != null)
            //        {
            //            if (he.InnerText.Contains(txtNextPageKey.Text.Trim()))
            //            {
            //                path = he.GetAttribute("href");
            //                break;
            //            }
            //        }
            //    }
            //    if (!string.IsNullOrEmpty(path))
            //    {
            //        webBrowser1.Navigate(path);
            //    }
            //    else
            //    {
            //        ImpEmail(PickEmail(outSb.ToString()));
            //        //MessageBox.Show("采集完成！");
            //        msgDiv1.MsgDivShow("采集完成！");
            //        flag = false;
            //    }

            //} 
            #endregion

            #region 模拟下一页点击按钮动作
            if (flag)
            {
                Collect();
                HtmlElement anchor = null;
                HtmlElementCollection hd = webBrowser1.Document.GetElementsByTagName("a");
                foreach (HtmlElement he in hd)
                {
                    if (he.InnerText != null)
                    {
                        if (he.InnerText.Contains(txtNextPageKey.Text.Trim()))
                        {
                            anchor = he;
                            break;
                        }
                    }
                }
                if (anchor != null)
                {
                    IHTMLElement ie = (IHTMLElement)anchor.DomElement;
                    ie.click();
                }
                else
                {
                    ImpEmail(PickEmail(outSb.ToString()));
                    msgDiv1.MsgDivShow("采集完成！",5);
                    flag = false;
                }

            } 
            #endregion
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    /// <summary>
    /// 用于多线程写txt 存储数据的类
    /// </summary>
    public class EmailClass
    {
        public string Content { get; set; }

        public string Path { get; set; }
    }
}
