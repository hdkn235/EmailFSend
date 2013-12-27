using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace 邮件群发
{
    public static class CommonFunc
    {
        /// <summary>
        /// 保存配置信息到配置文件中
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">值</param>
        public static void SaveSet(string key, string value)
        {
            string path = Path.Combine(Application.StartupPath, "ProgramSet.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode node = doc.SelectSingleNode(string.Format("configuration/appSettings/add[@key=\"{0}\"]", key));
            XmlElement xe = (XmlElement)node;
            xe.SetAttribute("value", value);
            doc.Save(path);
        }

        /// <summary>
        /// 读取配置信息
        /// </summary>
        /// <param name="key">关键字</param>
        /// <returns>返回值</returns>
        public static string ReadSet(string key)
        {
            string path = Path.Combine(Application.StartupPath, "ProgramSet.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode node = doc.SelectSingleNode(string.Format("configuration/appSettings/add[@key=\"{0}\"]", key));
            XmlElement xe = (XmlElement)node;
            return xe.GetAttribute("value");

        }
    }
}
