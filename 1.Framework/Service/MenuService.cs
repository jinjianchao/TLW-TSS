using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;

namespace LydTOPDP.Service
{
    public class MenuService
    {
        string _menuConfigData = AppDomain.CurrentDomain.BaseDirectory + @"ConfigData\Menu.xml";

        /// <summary>
        /// 获取所有菜单项
        /// </summary>
        /// <param name="lang">语言</param>
        /// <returns></returns>
        public IList<ArrayList> GetMenus(string lang)
        {
            IList<ArrayList> menuItem = new List<ArrayList>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_menuConfigData);
            if (lang != "all")
            {
                XmlNodeList menuItemsNodes = xmlDoc.SelectNodes("menus/menu");
                foreach (XmlNode item in menuItemsNodes)
                {
                    ArrayList strItem = new ArrayList(); ;
                    strItem.Add(item.Attributes["id"].Value);
                    strItem.Add(item.Attributes["text"].Value);

                    if (item.Attributes["lan_" + lang] != null)
                    {
                        strItem[1] = item.Attributes["lan_" + lang].Value;
                    }

                    IList<string> subMenu = new List<string>();
                    XmlNodeList menuSubItemNodes = item.SelectNodes("menu");
                    foreach (XmlNode subItem in menuSubItemNodes)
                    {
                        subMenu.Add(subItem.Attributes["guid"].Value);
                    }
                    strItem.Add(subMenu);
                    menuItem.Add(strItem);
                }
            }
            else
            {
                XmlNodeList menuItemsNodes = xmlDoc.SelectNodes("menus/menu");
                foreach (XmlNode item in menuItemsNodes)
                {
                    ArrayList strItem = new ArrayList(); ;
                    strItem.Add(item.Attributes["id"].Value);
                    strItem.Add(item.Attributes["lan_2052"].Value + ";" + item.Attributes["lan_0"].Value);
                    IList<string> subMenu = new List<string>();
                    XmlNodeList menuSubItemNodes = item.SelectNodes("menu");
                    foreach (XmlNode subItem in menuSubItemNodes)
                    {
                        subMenu.Add(subItem.Attributes["guid"].Value);
                    }
                    strItem.Add(subMenu);
                    menuItem.Add(strItem);
                }
            }
            return menuItem;
        }

        public void SaveMenus(IList<ArrayList> pgs)
        {
            IList<ArrayList> menuItem = new List<ArrayList>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_menuConfigData);

            XmlNode rootNode = xmlDoc.SelectSingleNode("menus");
            rootNode.RemoveAll();

            for (int i = 0; i < pgs.Count; i++)
            {
                XmlNode newNode = xmlDoc.CreateNode(XmlNodeType.Element, "menu", "");

                XmlAttribute idAtt = xmlDoc.CreateAttribute("id");
                idAtt.Value = i.ToString();
                newNode.Attributes.Append(idAtt);

                XmlAttribute textAtt = xmlDoc.CreateAttribute("text");
                textAtt.Value = (pgs[i][1] as string).Split(';')[0];
                newNode.Attributes.Append(textAtt);

                XmlAttribute lan2052Att = xmlDoc.CreateAttribute("lan_2052");
                lan2052Att.Value = (pgs[i][1] as string).Split(';')[0];
                newNode.Attributes.Append(lan2052Att);

                XmlAttribute lan0Att = xmlDoc.CreateAttribute("lan_0");
                lan0Att.Value = (pgs[i][1] as string).Split(';')[1];
                newNode.Attributes.Append(lan0Att);

                IList<string> subGuid = pgs[i][2] as IList<string>;
                for (int j = 0; j < subGuid.Count; j++)
                {
                    XmlNode subNewNode = xmlDoc.CreateNode(XmlNodeType.Element, "menu", "");
                    XmlAttribute subIdAtt = xmlDoc.CreateAttribute("id");
                    subIdAtt.Value = j.ToString();
                    subNewNode.Attributes.Append(subIdAtt);

                    XmlAttribute subGuidAtt = xmlDoc.CreateAttribute("guid");
                    subGuidAtt.Value = subGuid[j];
                    subNewNode.Attributes.Append(subGuidAtt);
                    newNode.AppendChild(subNewNode);
                }
                rootNode.AppendChild(newNode);
            }
            xmlDoc.Save(_menuConfigData);
        }
    }
}
