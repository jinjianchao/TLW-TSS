using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Microsoft.Win32;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using LanguageLib.DialogEx;

namespace LanguageLib
{
    [Obsolete("已过时,请使用LanguageHelper类代替", false)]
    public class MultiLanguage
    {

        public static void ValidateTranslateFile(string baseFile, IList<string> lanList)
        {
            StringBuilder sb = new StringBuilder();
            XmlDocument xmlDocBase = new XmlDocument();
            xmlDocBase.Load(baseFile);
            XmlNodeList baseFormNodeList = xmlDocBase.SelectNodes("Resource/Form");
            foreach (var lanItem in lanList)
            {
                XmlDocument xmlDoc = new XmlDocument();
                if (!File.Exists(lanItem)) continue;
                if (baseFile == lanItem) continue;
                xmlDoc.Load(lanItem);
                XmlNodeList formNodeList = xmlDoc.SelectNodes("Resource/Form");
                if (formNodeList == null) continue;
                foreach (var baseFormItem in baseFormNodeList)
                {
                    string formName = (baseFormItem as XmlNode).SelectSingleNode("Name").InnerText;
                    bool isExist = false;
                    foreach (var formItem in formNodeList)
                    {
                        if ((formItem as XmlNode).SelectSingleNode("Name").InnerText == formName)
                        {
                            isExist = true;
                            break;
                        }
                    }
                    if (!isExist)
                    {
                        sb.AppendFormat("在{0}中不存在窗体{1}对应的翻译文本\r\n", lanItem, formName);
                    }
                    else
                    {
                        XmlNodeList baseControlNodeList = (baseFormItem as XmlNode).SelectNodes("Controls/Control");
                        foreach (var baseCtrItem in baseControlNodeList)
                        {
                            foreach (var formItem in formNodeList)
                            {
                                if ((formItem as XmlNode).SelectSingleNode("Name").InnerText == formName)
                                {
                                    XmlNode ctrNode = (formItem as XmlNode).SelectSingleNode("Controls/Control[@name='" + (baseCtrItem as XmlNode).Attributes["name"].Value + "']");
                                    if (ctrNode == null)
                                    {
                                        sb.AppendFormat("在{0}不存在窗体{1}中控件名称为{2}对应的翻译文本\r\n", new object[] { lanItem, formName, (baseCtrItem as XmlNode).Attributes["name"].Value });
                                    }
                                }
                            }
                        }

                        XmlNodeList baseCodeNodeList = (baseFormItem as XmlNode).SelectNodes("Codes/Code");
                        foreach (var baseCodeItem in baseCodeNodeList)
                        {
                            foreach (var formItem in formNodeList)
                            {
                                if ((formItem as XmlNode).SelectSingleNode("Name").InnerText == formName)
                                {

                                    XmlNode ctrNode = (formItem as XmlNode).SelectSingleNode("Codes/Code[@name='" + (baseCodeItem as XmlNode).Attributes["name"].Value + "']");
                                    if (ctrNode == null)
                                    {
                                        sb.AppendFormat("在{0}不存在代码{1}中名称为{2}对应的翻译文本\r\n", new object[] { lanItem, formName, (baseCodeItem as XmlNode).Attributes["name"].Value });
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (sb.Length != 0)
            {
                MessageBoxEx.Show("", sb.ToString());
            }
        }

        //读取默认语言 
        public static string ReadDefaultLanguage()
        {
            //读取注册表
            string registData = string.Empty;
            RegistryKey hkUser = Registry.CurrentUser;
            RegistryKey software = hkUser.OpenSubKey("Software", false);
            RegistryKey leyard = software.OpenSubKey("Leyard", false);

            if (leyard == null)
            {
                registData = "0";
            }
            else
            {
                object obj = leyard.GetValue("Language");
                registData = obj == null ? "0" : obj.ToString();
            }
            //registData = "0";
            return registData;
        }      private static Hashtable codeTable = new Hashtable();   //存放代码中的语言文字

        /// <summary> 
        /// 获得子控件的显示名 
        /// </summary> 
        /// <param name="controls"></param> 
        /// <param name="table"></param> 
        private static void GetSubControls(Control.ControlCollection controls, Hashtable table)
        {
            foreach (Control control in controls)
            {
                Console.WriteLine(control.GetType().ToString());
                if (control.GetType() == typeof(System.Windows.Forms.Panel))
                    GetSubControls(control.Controls, table);

                if (control.GetType() == typeof(System.Windows.Forms.GroupBox))
                    GetSubControls(control.Controls, table);

                //if (control.GetType() == typeof(WinFormControlEx.GroupBoxEx))
                //    GetSubControls(control.Controls, table);

                if (control.GetType().BaseType == typeof(System.Windows.Forms.UserControl))
                    GetSubControls(control.Controls, table);

                if (control.GetType() == typeof(System.Windows.Forms.MenuStrip))
                    GetMenustripControls((control as MenuStrip).Items, table);

                if (control.GetType() == typeof(System.Windows.Forms.ContextMenuStrip))
                    GetMenustripControls((control as MenuStrip).Items, table);

                if (control.GetType() == typeof(System.Windows.Forms.FlowLayoutPanel))
                    GetSubControls(control.Controls, table);

                if (control.GetType() == typeof(DevComponents.DotNetBar.TabControl))
                    GetSubControls(control.Controls, table);

                if (control.GetType() == typeof(DevComponents.DotNetBar.TabControlPanel))
                    GetSubControls(control.Controls, table);

                if (control.GetType() == typeof(System.Windows.Forms.TabControl))
                    GetSubControls(control.Controls, table);

                if (control.GetType() == typeof(System.Windows.Forms.TabPage))
                    GetSubControls(control.Controls, table);

                if (control.GetType() == typeof(System.Windows.Forms.DataGridView))
                {
                    GetSubControls(control.Controls, table);
                    DataGridView gridView = control as DataGridView;
                    DataGridViewColumnCollection columnCollection = gridView.Columns;
                    foreach (DataGridViewColumn column in columnCollection)
                    {
                        if (table.Contains(gridView.Name.ToLower() + "_" + column.Name.ToLower()))
                            column.HeaderText = column.ToolTipText = (string)table[gridView.Name.ToLower() + "_" + column.Name.ToLower()];
                    }
                }

                if (control.GetType() == typeof(DevComponents.DotNetBar.SuperTabControl))
                {
                    GetSubControls(control.Controls, table);
                }

                if (control.GetType() == typeof(DevComponents.DotNetBar.SuperTabItem))
                {
                    GetSubControls(control.Controls, table);
                }

                if (control.GetType() == typeof(DevComponents.DotNetBar.SuperTabControlPanel))
                {
                    GetSubControls(control.Controls, table);
                }

                if (control.GetType() == typeof(DevComponents.DotNetBar.PanelEx))
                {
                    GetSubControls(control.Controls, table);
                }

                if (control.GetType() == typeof(DevComponents.DotNetBar.Controls.GroupPanel))
                {
                    GetSubControls(control.Controls, table);//2014-12-30
                }
                if (control.GetType() == typeof(DevComponents.DotNetBar.SuperTabControl))
                {
                    //2014-12-30
                    //GetSubControls(control.Controls, table);//2014-12-30

                    DevComponents.DotNetBar.SuperTabControl ctl = (DevComponents.DotNetBar.SuperTabControl)control;

                    foreach (DevComponents.DotNetBar.BaseItem item in ctl.Tabs)
                    {
                        string szName = item.Name.ToLower();
                        if (table.Contains(szName))
                        {
                            item.Text = (string)table[szName];
                        }
                    }

                }

                if (table.Contains(control.Name.ToLower()))
                    control.Text = (string)table[control.Name.ToLower()];
            }
        }

        //设置窗体控件的显示文本
        private static void SetControlText(Form form, Hashtable table, Control.ControlCollection controlNames)
        {
            foreach (Control control in controlNames)
            {
                Console.WriteLine(control.GetType().ToString());
                if (control.GetType() == typeof(System.Windows.Forms.Panel))
                    GetSubControls(control.Controls, table);

                if (control.GetType() == typeof(System.Windows.Forms.GroupBox) || control.GetType().BaseType == typeof(System.Windows.Forms.GroupBox))
                    GetSubControls(control.Controls, table);



                if (control.GetType().BaseType == typeof(System.Windows.Forms.UserControl))
                    GetSubControls(control.Controls, table);

                if (control.GetType() == typeof(System.Windows.Forms.MenuStrip))
                    GetMenustripControls((control as MenuStrip).Items, table);

                if (control.GetType() == typeof(System.Windows.Forms.ContextMenuStrip))
                    GetMenustripControls((control as MenuStrip).Items, table);

                if (control.GetType() == typeof(System.Windows.Forms.FlowLayoutPanel))
                    GetSubControls(control.Controls, table);

                if (control.GetType() == typeof(DevComponents.DotNetBar.TabControl))
                    GetSubControls(control.Controls, table);

                if (control.GetType() == typeof(System.Windows.Forms.TabControl))
                    GetSubControls(control.Controls, table);

                if (control.GetType() == typeof(System.Windows.Forms.TabPage))
                    GetSubControls(control.Controls, table);

                if (control.GetType() == typeof(System.Windows.Forms.DataGridView))
                {
                    GetSubControls(control.Controls, table);
                    DataGridView gridView = control as DataGridView;
                    DataGridViewColumnCollection columnCollection = gridView.Columns;
                    foreach (DataGridViewColumn column in columnCollection)
                    {
                        if (table.Contains(gridView.Name.ToLower() + "_" + column.Name.ToLower()))
                            column.HeaderText = column.ToolTipText = (string)table[gridView.Name.ToLower() + "_" + column.Name.ToLower()];
                    }
                }

                if (control.GetType() == typeof(DevComponents.DotNetBar.SuperTabControl))
                {
                    GetSubControls(control.Controls, table);
                }

                if (control.GetType() == typeof(DevComponents.DotNetBar.PanelEx))
                {
                    GetSubControls(control.Controls, table);
                }

                if (control.GetType() == typeof(DevComponents.DotNetBar.SuperTabItem))
                {
                    GetSubControls(control.Controls, table);
                }

                //if (control.GetType() == typeof(DevComponents.DotNetBar.Controls.GroupPanel))
                //{
                //    GetSubControls(control.Controls, table);//2014-12-30
                //}

                //if (control.GetType() == typeof(DevComponents.DotNetBar.SuperTabControl))
                //{
                //    //2014-12-30
                //    GetSubControls(control.Controls, table);//2014-12-30

                //    DevComponents.DotNetBar.SuperTabControl ctl = (DevComponents.DotNetBar.SuperTabControl)control;

                //    foreach (DevComponents.DotNetBar.BaseItem item in ctl.Tabs)
                //    {
                //        string szName = item.Name.ToLower();
                //        if (table.Contains(szName))
                //            item.Text = (string)table[szName];
                //    }                   
                //}

                if (table.Contains(control.Name.ToLower()))
                {
                    control.Text = (string)table[control.Name.ToLower()];
                }
            }
            if (table.Contains(form.Name.ToLower()))
                form.Text = (string)table[form.Name.ToLower()];
        }

        //设置窗体控件的显示文本
        private static void SetControlText(UserControl form, Hashtable table, Control.ControlCollection controlNames)
        {
            foreach (Control control in controlNames)
            {
                Console.WriteLine(control.GetType().ToString());
                if (control.GetType() == typeof(System.Windows.Forms.Panel))
                    GetSubControls(control.Controls, table);

                if (control.GetType() == typeof(System.Windows.Forms.GroupBox))
                    GetSubControls(control.Controls, table);

                if (control.GetType().BaseType == typeof(System.Windows.Forms.UserControl))
                    GetSubControls(control.Controls, table);

                if (control.GetType() == typeof(System.Windows.Forms.MenuStrip))
                    GetMenustripControls((control as MenuStrip).Items, table);

                if (control.GetType() == typeof(System.Windows.Forms.ContextMenuStrip))
                    GetMenustripControls((control as MenuStrip).Items, table);

                if (control.GetType() == typeof(System.Windows.Forms.FlowLayoutPanel))
                    GetSubControls(control.Controls, table);

                if (control.GetType() == typeof(System.Windows.Forms.DataGridView))
                {
                    GetSubControls(control.Controls, table);
                    DataGridView gridView = control as DataGridView;
                    DataGridViewColumnCollection columnCollection = gridView.Columns;
                    foreach (DataGridViewColumn column in columnCollection)
                    {
                        if (table.Contains(gridView.Name.ToLower() + "_" + column.Name.ToLower()))
                            column.HeaderText = column.ToolTipText = (string)table[gridView.Name.ToLower() + "_" + column.Name.ToLower()];
                    }
                }

                if (table.Contains(control.Name.ToLower()))
                {
                    control.Text = (string)table[control.Name.ToLower()];
                }
            }
            if (table.Contains(form.Name.ToLower()))
                form.Text = (string)table[form.Name.ToLower()];
        }

        //读取语言列表
        public static IList GetLanguageList(string lang, string LanguageConfigFile)
        {
            IList result = new ArrayList();
            XmlReader reader = new XmlTextReader(LanguageConfigFile);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode root = doc.DocumentElement;
            XmlNodeList nodelist = root.SelectNodes("Area[Language='" + lang + "']/List/Item");
            if (nodelist.Count == 0)
            {
                nodelist = root.SelectNodes("Area[Language=2052]/List/Item");
            }
            foreach (XmlNode node in nodelist)
            {
                result.Add(node.InnerText);
            }
            reader.Close();
            return result;
        }

        /// <summary> 
        /// 读取多语言的资源文件 
        /// </summary> 
        /// <param name="frmName">窗体的Name</param> 
        /// <param name="lang">要显示的语言(如ZH或EN)</param> 
        /// <returns></returns> 
        public static Hashtable ReadResource(string frmName, string lang, string languageResourcePath)
        {
            Hashtable result = new Hashtable();
            Hashtable codeTableTmp = new Hashtable();       //存放当前窗体的语言信息

            XmlReader reader = null;
            FileInfo fi = null;
            if (lang == "2052")
            {
                fi = new FileInfo(languageResourcePath + "/LanguageResource.xml");
            }
            else
            {
                fi = new FileInfo(languageResourcePath + "/LanguageResource_" + lang + ".xml");
            }

            if (!fi.Exists)
            {
                fi = new FileInfo(languageResourcePath + "/LanguageResource_0.xml");
                if (fi.Exists)
                {
                    reader = new XmlTextReader(languageResourcePath + "/LanguageResource_0.xml");
                }
                else
                {
                    reader = new XmlTextReader(languageResourcePath + "/LanguageResource.xml");
                }
            }
            else
            {
                //reader = new XmlTextReader(languageResourcePath + "/LanguageResource_" + lang + ".xml");

                if (lang == "2052")
                {
                    reader = new XmlTextReader(languageResourcePath + "/LanguageResource.xml");
                }
                else
                {
                    reader = new XmlTextReader(languageResourcePath + "/LanguageResource_" + lang + ".xml");
                }
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode root = doc.DocumentElement;
            XmlNodeList nodelist = root.SelectNodes("Form[Name='" + frmName + "']/Controls/Control");
            foreach (XmlNode node in nodelist)
            {
                try
                {
                    XmlNode node1 = node.SelectSingleNode("@name");
                    XmlNode node2 = node.SelectSingleNode("@text");
                    if (node1 != null)
                    {
                        if (!result.ContainsKey(node1.InnerText.ToLower()))
                        {
                            result.Add(node1.InnerText.ToLower(), node2.InnerText);
                        }
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.ToString());
                    MessageBox.Show(fe.InnerException.Message);
                }
            }

            //读取代码中所需要到语言文字
            nodelist = root.SelectNodes("Form[Name='" + frmName + "']/Codes/Code");
            foreach (XmlNode node in nodelist)
            {
                try
                {
                    XmlNode node1 = node.SelectSingleNode("@name");
                    XmlNode node2 = node.SelectSingleNode("@text");
                    if (node1 != null)
                    {
                        if (!codeTableTmp.ContainsKey(node1.InnerText.ToLower()))
                        {
                            codeTableTmp.Add(node1.InnerText.ToLower(), node2.InnerText);
                        }
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.ToString());
                    MessageBox.Show(fe.InnerException.Message);
                }
            }
            if (!codeTable.Contains(frmName.ToLower()))
            {
                codeTable.Add(frmName.ToLower(), codeTableTmp);
            }
            else
            {
                codeTable[frmName.ToLower()] = codeTableTmp;
            }
            reader.Close();

            return result;
        }

        /// <summary> 
        /// 读取费窗体多语言的资源文件 
        /// </summary> 
        /// <param name="frmName">窗体的Name</param> 
        /// <param name="lang">要显示的语言(如ZH或EN)</param> 
        /// <returns></returns> 
        public static Hashtable ReadResourceNotForm(string frmName, string lang, string languageResourcePath)
        {
            Hashtable result = new Hashtable();
            Hashtable codeTableTmp = new Hashtable();       //存放当前窗体的语言信息

            XmlReader reader = null;
            FileInfo fi = new FileInfo(languageResourcePath + "/LanguageResource_" + lang + ".xml");
            reader = !fi.Exists ? new XmlTextReader(languageResourcePath + "/LanguageResource.xml")
                                  : new XmlTextReader(languageResourcePath + "/LanguageResource_" + lang + ".xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode root = doc.DocumentElement;
            XmlNodeList nodelist = root.SelectNodes("Form[Name='" + frmName + "']/Controls/Control");
            foreach (XmlNode node in nodelist)
            {
                try
                {
                    XmlNode node1 = node.SelectSingleNode("@name");
                    XmlNode node2 = node.SelectSingleNode("@text");
                    if (node1 != null)
                    {
                        if (!result.ContainsKey(node1.InnerText.ToLower()))
                        {
                            result.Add(node1.InnerText.ToLower(), node2.InnerText);
                        }
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.ToString());
                    MessageBox.Show(fe.InnerException.Message);
                }
            }

            //读取代码中所需要到语言文字
            nodelist = root.SelectNodes("Form[Name='" + frmName + "']/Codes/Code");
            foreach (XmlNode node in nodelist)
            {
                try
                {
                    XmlNode node1 = node.SelectSingleNode("@name");
                    XmlNode node2 = node.SelectSingleNode("@text");
                    if (node1 != null)
                    {
                        if (!codeTableTmp.ContainsKey(node1.InnerText.ToLower()))
                        {
                            codeTableTmp.Add(node1.InnerText.ToLower(), node2.InnerText);
                        }
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.ToString());
                    MessageBox.Show(fe.InnerException.Message);
                }
            }
            if (!codeTable.Contains(frmName.ToLower()))
            {
                codeTable.Add(frmName.ToLower(), codeTableTmp);
            }
            else
            {
                codeTable[frmName.ToLower()] = codeTableTmp;
            }
            reader.Close();

            return result;
        }

        /// <summary> 
        /// 获取控件的名称(窗体包含菜单项等） 
        /// </summary> 
        /// <param name="form"></param> 
        public static void GetNames(System.ComponentModel.ComponentCollection component, Form form, String lang, string languageResourceFolder)
        {
            //根据用户选择的语言获得表的显示文字 
            Hashtable table = ReadResource(form.Name, lang, languageResourceFolder);
            Control.ControlCollection controlNames = form.Controls;
            //可以在这里设置窗体的一些统一的属性，这样所有的窗体都会应用该设置 
            // form.KeyPreview = true; 
            // form.MaximizeBox = false; 
            // form.MinimizeBox = false; 
            // form.ControlBox = false; 
            // form.FormBorderStyle = FormBorderStyle.FixedDialog; 
            // form.StartPosition = FormStartPosition.CenterScreen; 
            // form.TopMost = true; 
            // form.KeyDown += new KeyEventHandler(OnEnter); 
            try
            {
                if (component != null)//遍历非窗体上的控件（如：右键菜单)
                {
                    IEnumerator ie = component.GetEnumerator();
                    while (ie.MoveNext())
                    {
                        Console.WriteLine(ie.Current.GetType().ToString());
                        if ((ie.Current as Control) != null)
                        {
                            if (ie.Current.GetType() == typeof(System.Windows.Forms.ContextMenuStrip))
                                GetMenustripControls((ie.Current as ContextMenuStrip).Items, table);
                        }
                    }
                }

                //遍历窗体上的控件
                SetControlText(form, table, controlNames);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        /// <summary> 
        /// 获取控件的名称（窗体不包含菜单项等) 
        /// </summary> 
        /// <param name="form"></param> 
        public static void GetNames(Form form, String lang, string languageResourceFolder)
        {
            //根据用户选择的语言获得表的显示文字 
            Hashtable table = ReadResource(form.Name, lang, languageResourceFolder);
            Control.ControlCollection controlNames = form.Controls;
            form.Text = MultiLanguage.GetNames(form.Name, "title");
            try
            {
                //遍历窗体上的控件
                SetControlText(form, table, controlNames);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        /// <summary> 
        /// 获取控件的名称（窗体不包含菜单项等) 
        /// </summary> 
        /// <param name="form"></param> 
        public static void GetNames(UserControl form, String lang, string languageResourceFolder)
        {
            //根据用户选择的语言获得表的显示文字 
            Hashtable table = ReadResource(form.Name, lang, languageResourceFolder);
            Control.ControlCollection controlNames = form.Controls;
            form.Text = MultiLanguage.GetNames(form.Name, "title");
            try
            {
                //遍历窗体上的控件
                SetControlText(form, table, controlNames);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        /// <summary> 
        /// 获取控件的名称（窗体不包含菜单项等) 
        /// </summary> 
        /// <param name="form"></param> 
        public static void GetNames(String name, String lang, string languageResourceFolder)
        {
            //根据用户选择的语言获得表的显示文字 
            Hashtable table = ReadResourceNotForm(name, lang, languageResourceFolder);
        }

        /// <summary>
        /// 读取代码中的文字
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static String GetNames(String formName, String key)
        {
            String result = "";
            if (codeTable.Contains(formName.ToLower()))
            {
                Hashtable codeTableTmp = codeTable[formName.ToLower()] as Hashtable;
                result = codeTableTmp.Contains(key.ToLower()) ? codeTableTmp[key.ToLower()].ToString() : "";
            }
            return result;
        }

        /// <summary>
        /// 设置右键菜单国际化,国际化代码包含在<code></code>标签中
        /// </summary>
        /// <param name="formName"></param>
        /// <param name="ctxMenu"></param>
        public static void GetNames(String formName, ContextMenuStrip ctxMenu)
        {
            String result = "";
            //if (codeTable.Contains(formName))
            //{
            //    Hashtable codeTableTmp = codeTable[formName.ToLower()] as Hashtable;
            foreach (ToolStripItem item in ctxMenu.Items)
            {
                result = MultiLanguage.GetNames(formName, item.Name);
                item.Text = result;
            }
            //}
        }

        /// <summary>
        /// 多语言化菜单项，菜单项的Tag属性需要为空或者不等于“1”，多语言写在<Code></Code>里边
        /// </summary>
        /// <param name="formName"></param>
        /// <param name="menu"></param>
        public static void GetNames(String formName, MenuStrip menu)
        {
            for (int i = 0; i < menu.Items.Count; i++)
            {
                if (menu.Items[i].Tag == null || menu.Items[i].Tag.ToString() != "1")
                {
                    menu.Items[i].Text = MultiLanguage.GetNames(formName, menu.Items[i].Name);
                    ToolStripMenuItem menuTitle = menu.Items[i] as ToolStripMenuItem;

                    for (int j = 0; j < menuTitle.DropDownItems.Count; j++)
                    {
                        if (!menuTitle.DropDownItems[j].Name.Contains("Ext_"))
                            menuTitle.DropDownItems[j].Text = MultiLanguage.GetNames(formName, menuTitle.DropDownItems[j].Name);
                    }
                }
            }
        }

        /// <summary>
        /// 获取菜单控件的现实名称
        /// </summary>
        /// <param name="items"></param>
        /// <param name="table"></param>
        private static void GetMenustripControls(ToolStripItemCollection items, Hashtable table)
        {
            foreach (Object item in items)
            {
                if (item.GetType() == typeof(System.Windows.Forms.ToolStripSeparator))
                    continue;

                GetMenustripControls((item as ToolStripMenuItem).DropDown.Items, table);
                if (table.Contains((item as ToolStripMenuItem).Name.ToLower()))
                    (item as ToolStripMenuItem).Text = (string)table[(item as ToolStripMenuItem).Name.ToLower()];
            }
        }

        /// <summary>
        /// 读取相应语言的“语言”所对应的文字
        /// </summary>
        /// <param name="lang"></param>
        /// <param name="languageConfigFile"></param>
        /// <returns></returns>
        public static String GetLanguageTitle(String lang, string languageConfigFile)
        {
            string strValue = string.Empty;
            XmlReader reader = null;
            reader = new XmlTextReader(languageConfigFile);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode root = doc.DocumentElement;
            XmlNode node = root.SelectSingleNode("Area[Language=" + lang + "]/TitleName");
            strValue = node == null ? "语言" : node.InnerText;
            return strValue;
        }
    }

    public class LanguageConfig
    {
        public int ID { get; set; }
        public int Key { get; set; }
        public string Text { get; set; }
        public bool IsUse { get; set; }
        public IList<LanguageConfig> SubLanList { get; set; }
    }

    public class LanguageHelper
    {
        /// <summary>
        /// 获取所有语言信息,中文，英文....
        /// </summary>
        /// <param name="LanguageConfigFile"></param>
        /// <returns></returns>
        public static IList<LanguageConfig> GetLanList(string LanguageConfigFile)
        {
            IList<LanguageConfig> lanList = new List<LanguageConfig>();
            int lanCode = ReadLanCode();

            IList result = new ArrayList();
            XmlReader reader = new XmlTextReader(LanguageConfigFile);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode root = doc.DocumentElement;

            XmlNodeList areaNodeList = root.SelectNodes("Area");
            foreach (XmlNode aNode in areaNodeList)
            {
                LanguageConfig lanCfg = new LanguageConfig();
                lanCfg.ID = Convert.ToInt32(aNode.Attributes["id"].Value);
                int key = Convert.ToInt32(aNode.SelectSingleNode("Language").InnerText);
                lanCfg.Key = key;
                lanCfg.Text = aNode.SelectSingleNode("TitleName").InnerText;
                if (key == lanCode) lanCfg.IsUse = true;

                IList<LanguageConfig> subItems = new List<LanguageConfig>();
                foreach (XmlNode subNode in aNode.SelectNodes("List/Item"))
                {
                    LanguageConfig subitem = new LanguageConfig();
                    subitem.Key = Convert.ToInt32(subNode.Attributes["key"].Value);
                    subitem.Text = subNode.InnerText;
                    subItems.Add(subitem);
                }
                lanCfg.SubLanList = subItems;
                lanList.Add(lanCfg);
            }
            return lanList;
        }

        //读取当前使用的语言
        public static int ReadLanCode()
        {
            int lanCode = 0;
            //读取注册表
            string registData = string.Empty;
            RegistryKey hkUser = Registry.CurrentUser;
            RegistryKey software = hkUser.OpenSubKey("Software", false);
            RegistryKey leyard = software.OpenSubKey("Leyard", false);

            if (leyard == null)
            {
                lanCode = 0;
            }
            else
            {
                object obj = leyard.GetValue("Language");
                lanCode = obj == null ? 0 : int.Parse(obj.ToString());
            }
            return lanCode;
        }

        //修改默认语言 
        public static void WriteDefaultLanguage(LanguageConfig lanCfg)
        {
            //写 注册表
            RegistryKey hkUser = Registry.CurrentUser;
            RegistryKey software = hkUser.OpenSubKey("Software", true);
            RegistryKey leyard = software.CreateSubKey("Leyard");
            leyard.SetValue("Language", lanCfg.Key);
            leyard.Flush();
            leyard.Close();

        }

        public static void WriteDefaultLanguage(string key)
        {
            //写 注册表
            RegistryKey hkUser = Registry.CurrentUser;
            RegistryKey software = hkUser.OpenSubKey("Software", true);
            RegistryKey leyard = software.CreateSubKey("Leyard");
            leyard.SetValue("Language", key);
            leyard.Flush();
            leyard.Close();
        }

        /// <summary>
        /// 加载字典
        /// </summary>
        /// <param name="file"></param>
        /// <param name="lanCount"></param>
        /// <param name="region"></param>
        /// <param name="split"></param>
        /// <returns></returns>
        public static IList[] LoadLanDic(String file, int lanCount, out string region, out string split)
        {
            region = "default";
            split = "      ";
            ArrayList[] list = new ArrayList[lanCount + 1];
            for (int i = 0; i < lanCount + 1; i++)
            {
                list[i] = new ArrayList();
            }
            StreamReader reader = new StreamReader(file, Encoding.Default);
            int index = 0;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (index == 0)
                {
                    region = line.Split('=')[1];
                    index++;
                    continue;
                }
                else if (index == 1)
                {
                    split = line.Split('=')[1];
                    index++;
                    continue;
                }
                string[] tmpStrArr = line.Split(new string[] { split }, StringSplitOptions.None);
                for (int i = 0; i < lanCount + 1; i++)
                {
                    if (i < tmpStrArr.Length)
                    {
                        list[i].Add(tmpStrArr[i]);
                    }
                    else
                    {
                        list[i].Add("#EMPTY#");
                    }
                }
                index++;
            }
            return list;
        }

        public static string FindInDic(IList[] landic, int lanIndex, string text, string region)
        {
            //lanIndex++;//因格式修改导致区域标识由最后调整到最前边，所以对应的语言索引需要加1
            string tmpRegion = region;
            string result = text;
            int index = 0;
            bool exist = false;
            foreach (var item in landic[1])
            {
                if (text == item.ToString().Replace("\\r\\n", "\r\n"))
                {
                    if (region == landic[0][index].ToString())
                    {
                        result = landic[lanIndex][index].ToString();
                        if (result == "#EMPTY#")
                        {
                            result = text;
                        }
                        tmpRegion = region;
                        exist = true;
                        break;
                    }
                    else if (landic[0][index].ToString() == "default")
                    {
                        result = landic[lanIndex][index].ToString();
                        tmpRegion = "default";
                    }
                    exist = true;
                }
                index++;
            }
            return result.Replace("\\r\\n", "\r\n");
        }

        public static string FindInDic(IList[] landic, int lanIndex, string text, string region, out bool exist)
        {
            //lanIndex++;//因格式修改导致区域标识由最后调整到最前边，所以对应的语言索引需要加1
            string tmpRegion = region;
            string result = text;
            int index = 0;
            exist = false;
            foreach (var item in landic[1])
            {
                if (text == item.ToString())
                {
                    if (region == landic[0][index].ToString())
                    {
                        result = landic[lanIndex][index].ToString();
                        if (result == "#EMPTY#")
                        {
                            result = text;
                        }
                        tmpRegion = region;
                        exist = true;
                        break;
                    }
                    else if (landic[0][index].ToString() == "default")
                    {
                        result = landic[lanIndex][index].ToString();
                        tmpRegion = "default";
                    }
                    exist = true;
                }
                index++;
            }
            return result;
        }
    }
}
