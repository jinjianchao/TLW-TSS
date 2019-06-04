using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Collections;

namespace LydTOPDP.Service
{
    /// <summary>
    /// 选项对话框，可选
    /// </summary>
    public class OptionModel
    {
        public String Namesapce { get; set; }
        public String Name { get; set; }
        public String Text { get; set; }
    }

    /// <summary>
    /// 通讯类别
    /// </summary>
    public enum CommunicationWay
    {
        All = 0,
        Serialport = 1,
        Network = 2
    }

    /// <summary>
    /// 键值对数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="K"></typeparam>
    public class KeyValue<T, K>
    {
        public T Text { get; set; }
        public K Value { get; set; }
    }

    /// <summary>
    /// 初始化参数，可选项
    /// </summary>
    public class PluginInitModel
    {
        public CommunicationWay CommType { get; set; }
    }

    public class PluginProtected
    {
        public bool Protected { get; set; }
        public string Password { get; set; }
    }

    public class PluginModel
    {
        public String GUID { get; set; }
        public String Namesapce { get; set; }
        public String Communication { get; set; }
        public String Name { get; set; }
        public String Text { get; set; }
        public String Tips { get; set; }
        public string FunID { get; set; }
        public string LibPath { get; set; }
        public string Version { get; set; }
        public IList<OptionModel> Options { get; set; }
        public PluginInitModel Init { get; set; }
        public String CabinateType { get; set; }//箱体类型
        public PluginProtected Protected { get; set; }

    }

    class PluginPro
    {
        public string Version { get; set; }
        public string Communication { get; set; }
        public string LibPath { get; set; }
        public IList<PluginModel> Items { get; set; }
        public String Namespace { get; set; }
    }

    class PluginService
    {
        string customerFolder = AppDomain.CurrentDomain.BaseDirectory + @"Plugin\Customer";
        string _menuConfigData = AppDomain.CurrentDomain.BaseDirectory + @"ConfigData\Menu.xml";

        bool CheckPluginHasUsed(string guid)
        {
            IList<ArrayList> menuItem = new List<ArrayList>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_menuConfigData);

            XmlNodeList menuItemsNodes = xmlDoc.SelectNodes("menus/menu");
            foreach (XmlNode item in menuItemsNodes)
            {
                XmlNodeList menuSubItemNodes = item.SelectNodes("menu");
                foreach (XmlNode subItem in menuSubItemNodes)
                {
                    if (subItem.Attributes["guid"].Value == guid)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private string[] GetPlugins()
        {
            string[] tmp = Directory.GetDirectories(customerFolder);
            Array.Reverse(tmp);
            Array.Sort(tmp);
            return tmp;
        }

        //得到插件信息
        public IList<PluginModel> GetPluginItems(int funID, string language)
        {
            IList<PluginModel> modes = new List<PluginModel>();
            string[] pgs = GetPlugins();
            foreach (string str in pgs)
            {
                try
                {
                    if (File.Exists(str + @"\Plugin.xml"))
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(str + @"\Plugin.xml");

                        if (xmlDoc.SelectSingleNode("plugins").Attributes["version"] == null)
                        {//插件1.0
                            string dllName = str + @"\" + xmlDoc.SelectSingleNode("plugins/dll").Attributes["name"].Value;

                            XmlNodeList itemNodeList = xmlDoc.SelectNodes("plugins/plugin/item");
                            foreach (XmlNode item in itemNodeList)
                            {
                                if (funID.ToString() == item.SelectSingleNode("fun").Attributes["id"].Value)
                                {
                                    PluginModel pm = new PluginModel();
                                    pm.Version = "1.0";
                                    pm.FunID = funID.ToString();
                                    pm.Namesapce = item.Attributes["namespace"].Value;
                                    pm.GUID = item.Attributes["guid"].Value.Trim();
                                    pm.Name = item.SelectSingleNode("name").InnerText.Trim();
                                    XmlNode pluginsNode = xmlDoc.SelectSingleNode("plugins");
                                    if (pluginsNode.Attributes["cabinatetype"] != null)
                                    {
                                        pm.CabinateType = pluginsNode.Attributes["cabinatetype"].Value;
                                    }
                                    pm.Text = item.SelectSingleNode("text").InnerText.Trim();
                                    XmlNode lanNode = item.SelectSingleNode("title/lan_" + language);
                                    if (lanNode != null)
                                    {
                                        pm.Text = lanNode.InnerText;
                                    }
                                    pm.LibPath = dllName;

                                    if (item.SelectSingleNode("init") != null)
                                    {
                                        XmlNode initNode = item.SelectSingleNode("init");
                                        PluginInitModel pmInit = new PluginInitModel();
                                        pm.Init = pmInit;
                                    }

                                    modes.Add(pm);
                                }
                            }
                        }
                        else
                        {
                            //插件2.0
                            string dllName = str + @"\" + xmlDoc.SelectSingleNode("plugins/dll").Attributes["name"].Value;

                            XmlNodeList itemNodeList = xmlDoc.SelectNodes("plugins/item");
                            foreach (XmlNode item in itemNodeList)
                            {
                                if (funID.ToString() == item.Attributes["position"].Value)
                                {
                                    PluginModel pm = new PluginModel();
                                    pm.Version = xmlDoc.SelectSingleNode("plugins").Attributes["version"].Value;
                                    pm.FunID = funID.ToString();
                                    pm.Namesapce = item.Attributes["namespace"].Value;
                                    pm.GUID = item.Attributes["guid"].Value.Trim();
                                    pm.Name = item.Attributes["form"].Value;
                                    pm.Text = item.Attributes["defaultTitle"].Value;
                                    XmlNode pluginsNode = xmlDoc.SelectSingleNode("plugins");
                                    if (pluginsNode.Attributes["cabinatetype"] != null)
                                    {
                                        pm.CabinateType = pluginsNode.Attributes["cabinatetype"].Value;
                                    }
                                    XmlNode lanNode = item.SelectSingleNode("lan_title/lan_" + language);
                                    if (lanNode != null)
                                    {
                                        pm.Text = lanNode.InnerText;
                                    }
                                    pm.LibPath = dllName;

                                    if (item.SelectSingleNode("init") != null)
                                    {
                                        XmlNode initNode = item.SelectSingleNode("init");
                                        PluginInitModel pmInit = new PluginInitModel();
                                        pmInit.CommType = (CommunicationWay)Enum.Parse(typeof(CommunicationWay), initNode.SelectSingleNode("usedcommunicate").Attributes["value"].Value);
                                        pm.Init = pmInit;
                                    }

                                    modes.Add(pm);
                                }
                            }
                        }
                    }
                }
                catch
                {

                }
            }
            return modes;
        }

        public IList<PluginModel> GetNotUsedItems(string language)
        {
            IList<PluginModel> modes = new List<PluginModel>();
            string[] pgs = GetPlugins();
            foreach (string str in pgs)
            {
                try
                {
                    if (File.Exists(str + @"\Plugin.xml"))
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(str + @"\Plugin.xml");

                        if (xmlDoc.SelectSingleNode("plugins").Attributes["version"] == null)
                        {//插件1.0
                            string dllName = str + @"\" + xmlDoc.SelectSingleNode("plugins/dll").Attributes["name"].Value;

                            XmlNodeList itemNodeList = xmlDoc.SelectNodes("plugins/plugin/item");
                            foreach (XmlNode item in itemNodeList)
                            {
                                string guid = item.Attributes["guid"].Value;
                                if (!CheckPluginHasUsed(guid))
                                {
                                    PluginModel pm = new PluginModel();
                                    pm.Version = "1.0";
                                    pm.Namesapce = item.Attributes["namespace"].Value;
                                    pm.GUID = item.Attributes["guid"].Value.Trim();
                                    pm.Name = item.SelectSingleNode("name").InnerText.Trim();

                                    pm.Text = item.SelectSingleNode("text").InnerText.Trim();
                                    XmlNode pluginsNode = xmlDoc.SelectSingleNode("plugins");
                                    if (pluginsNode.Attributes["cabinatetype"] != null)
                                    {
                                        pm.CabinateType = pluginsNode.Attributes["cabinatetype"].Value;
                                    }
                                    XmlNode lanNode = item.SelectSingleNode("title/lan_" + language);
                                    if (lanNode != null)
                                    {
                                        pm.Text = lanNode.InnerText;
                                    }
                                    pm.LibPath = dllName;
                                    modes.Add(pm);
                                }
                            }
                        }
                        else
                        {
                            //插件2.0
                            string dllName = str + @"\" + xmlDoc.SelectSingleNode("plugins/dll").Attributes["name"].Value;

                            XmlNodeList itemNodeList = xmlDoc.SelectNodes("plugins/item");
                            foreach (XmlNode item in itemNodeList)
                            {
                                string guid = item.Attributes["guid"].Value;
                                if (!CheckPluginHasUsed(guid))
                                {
                                    PluginModel pm = new PluginModel();
                                    pm.Version = xmlDoc.SelectSingleNode("plugins").Attributes["version"].Value;
                                    pm.Namesapce = item.Attributes["namespace"].Value;
                                    pm.GUID = item.Attributes["guid"].Value.Trim();
                                    pm.Name = item.Attributes["form"].Value;
                                    pm.Text = item.Attributes["defaultTitle"].Value;
                                    XmlNode pluginsNode = xmlDoc.SelectSingleNode("plugins");
                                    if (pluginsNode.Attributes["cabinatetype"] != null)
                                    {
                                        pm.CabinateType = pluginsNode.Attributes["cabinatetype"].Value;
                                    }
                                    XmlNode lanNode = item.SelectSingleNode("lan_title/lan_" + language);
                                    if (lanNode != null)
                                    {
                                        pm.Text = lanNode.InnerText;
                                    }
                                    pm.LibPath = dllName;
                                    modes.Add(pm);
                                }
                            }
                        }
                    }
                }
                catch
                {

                }
            }
            return modes;
        }

        public PluginModel GetPluginItem(string guid, string language)
        {
            string[] pgs = GetPlugins();
            foreach (string str in pgs)
            {
                try
                {
                    if (File.Exists(str + @"\Plugin.xml"))
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(str + @"\Plugin.xml");

                        if (xmlDoc.SelectSingleNode("plugins").Attributes["version"] == null)
                        {//插件1.0
                            string dllName = str + @"\" + xmlDoc.SelectSingleNode("plugins/dll").Attributes["name"].Value;

                            XmlNodeList itemNodeList = xmlDoc.SelectNodes("plugins/plugin/item");
                            foreach (XmlNode item in itemNodeList)
                            {
                                if (item.Attributes["guid"].Value == guid)
                                {
                                    PluginModel pm = new PluginModel();
                                    pm.Version = "1.0";
                                    pm.Namesapce = item.Attributes["namespace"].Value;
                                    pm.GUID = item.Attributes["guid"].Value.Trim();
                                    pm.Name = item.SelectSingleNode("name").InnerText.Trim();

                                    pm.Text = item.SelectSingleNode("text").InnerText.Trim();
                                    XmlNode pluginsNode = xmlDoc.SelectSingleNode("plugins");
                                    if (pluginsNode.Attributes["cabinatetype"] != null)
                                    {
                                        pm.CabinateType = pluginsNode.Attributes["cabinatetype"].Value;
                                    }
                                    XmlNode lanNode = item.SelectSingleNode("title/lan_" + language);
                                    if (lanNode != null)
                                    {
                                        pm.Text = lanNode.InnerText;
                                        XmlAttribute tipAtt = lanNode.Attributes["tips"];
                                        if (tipAtt != null)
                                        {
                                            pm.Tips = tipAtt.Value;
                                        }
                                        else
                                        {
                                            pm.Tips = "";
                                        }
                                    }
                                    pm.LibPath = dllName;


                                    if (item.SelectSingleNode("init") != null)
                                    {
                                        XmlNode initNode = item.SelectSingleNode("init");
                                        PluginInitModel pmInit = new PluginInitModel();
                                        pmInit.CommType = (CommunicationWay)Enum.Parse(typeof(CommunicationWay), initNode.SelectSingleNode("usedcommunicate").Attributes["value"].Value);
                                        pm.Init = pmInit;
                                    }
                                    pm.Protected = new PluginProtected() { Protected = false, Password = "" };
                                    XmlNode protectedNode = item.SelectSingleNode("protected");
                                    if (protectedNode != null)
                                    {

                                        pm.Protected.Protected = bool.Parse(protectedNode.Attributes["value"].Value);
                                        pm.Protected.Password = protectedNode.Attributes["password"].Value;
                                    }
                                    return pm;
                                }
                            }
                        }
                        else
                        {
                            //插件2.0
                            string dllName = str + @"\" + xmlDoc.SelectSingleNode("plugins/dll").Attributes["name"].Value;

                            XmlNodeList itemNodeList = xmlDoc.SelectNodes("plugins/item");
                            foreach (XmlNode item in itemNodeList)
                            {
                                if (item.Attributes["guid"].Value == guid)
                                {
                                    PluginModel pm = new PluginModel();
                                    pm.Options = new List<OptionModel>();
                                    pm.Version = xmlDoc.SelectSingleNode("plugins").Attributes["version"].Value;
                                    pm.Namesapce = item.Attributes["namespace"].Value;
                                    pm.GUID = item.Attributes["guid"].Value.Trim();
                                    pm.Name = item.Attributes["form"].Value;
                                    pm.Text = item.Attributes["defaultTitle"].Value;
                                    XmlNode pluginsNode = xmlDoc.SelectSingleNode("plugins");
                                    if (pluginsNode.Attributes["cabinatetype"] != null)
                                    {
                                        pm.CabinateType = pluginsNode.Attributes["cabinatetype"].Value;
                                    }
                                    XmlNode lanNode = item.SelectSingleNode("lan_title/lan_" + language);
                                    if (lanNode != null)
                                    {
                                        pm.Text = lanNode.InnerText;
                                        XmlAttribute tipAtt = lanNode.Attributes["tips"];
                                        if (tipAtt != null)
                                        {
                                            pm.Tips = tipAtt.Value;
                                        }
                                        else
                                        {
                                            pm.Tips = "";
                                        }
                                    }
                                    pm.LibPath = dllName;

                                    XmlNode optionNode = item.SelectSingleNode("options");
                                    if (optionNode != null)
                                    {
                                        XmlNodeList optionFormNodes = optionNode.SelectNodes("optionForm");
                                        if (optionFormNodes != null)
                                        {
                                            foreach (XmlNode nodeItem in optionFormNodes)
                                            {
                                                OptionModel optModel = new OptionModel();
                                                optModel.Namesapce = nodeItem.Attributes["namespace"].Value;
                                                optModel.Name = nodeItem.Attributes["form"].Value;

                                                optModel.Text = nodeItem.Attributes["defaultTitle"].Value;
                                                XmlAttribute optionlanNode = nodeItem.Attributes["lan_" + language];
                                                if (optionlanNode != null)
                                                {
                                                    optModel.Text = optionlanNode.Value;
                                                }
                                                pm.Options.Add(optModel);
                                            }
                                        }
                                    }

                                    if (item.SelectSingleNode("init") != null)
                                    {
                                        XmlNode initNode = item.SelectSingleNode("init");
                                        PluginInitModel pmInit = new PluginInitModel();
                                        pmInit.CommType = (CommunicationWay)Enum.Parse(typeof(CommunicationWay), initNode.SelectSingleNode("usedcommunicate").Attributes["value"].Value);
                                        pm.Init = pmInit;
                                    }

                                    pm.Protected = new PluginProtected() { Protected=false, Password="" };
                                    XmlNode protectedNode = item.SelectSingleNode("protected");
                                    if (protectedNode != null)
                                    {

                                        pm.Protected.Protected = bool.Parse(protectedNode.Attributes["value"].Value);
                                        pm.Protected.Password = protectedNode.Attributes["password"].Value;
                                    }
                                    return pm;
                                }
                            }
                        }
                    }
                }
                catch
                {

                }
            }
            return null;
        }
    }
}
