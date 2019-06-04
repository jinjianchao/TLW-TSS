using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace PluginLib
{
    /**
     * 
     * <?xml version="1.0" encoding="utf-8" ?>
        <plugins version="2.0">
          <dll name="PluginDemo.dll"/>
          <item namespace="PluginDemo" guid="{25A58A80-3435-40AE-96B5-A711B404824C}" form="Form1" defaultTitle="插件示例" position="0">
            <lan_title>
              <lan_2052>插件示例</lan_2052>
              <lan_0>Plugin Example</lan_0>
            </lan_title>
          </item>
        </plugins>
     * 
     * 
     **/
    public partial class BaseFormV2 : Form
    {
        string m_localLanPath;
        string m_localLanTxt = "lan.txt";

        [DefaultValue(true)]
        public bool IsCheckWordExist { get; set; }

        private string _uniqueID;
        public string UniqueID { get { return _uniqueID; } }

        public BaseFormV2()
        {
            InitializeComponent();
            _uniqueID = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 此方法不在使用
        /// </summary>
        /// <param name="color"></param>
        public virtual void SetBackColor(Color color)
        {
            this.BackColor = color;
        }

        #region 自定义事件

        #region 插件关闭事件
        /// <summary>
        /// 插件关闭事件委托定义
        /// </summary>
        /// <returns></returns>
        public delegate DialogResult FormCloseDelegate();
        /// <summary>
        /// 插件关闭事件，插件关闭时被调用
        /// </summary>
        [Description("窗体关闭事件,DialogResult.OK：允许关闭，DialogResult.Cancel：取消关闭")]
        public new event FormCloseDelegate FormClosing;
        #endregion

        #region 箱体类型改变事件
        /// <summary>
        /// 箱体关闭事件委托定义，箱体类别发生变化时被调用
        /// </summary>
        /// <param name="unitType">箱体类别</param>
        public delegate void UnitTypeChangedDelegate(UnitTypeV2 unitType);
        /// <summary>
        /// 箱体关闭事件
        /// </summary>
        [Description("箱体类别发生变化")]
        public event UnitTypeChangedDelegate UnitTypeChanged;
        #endregion

        #region 改用串口通讯方式事件
        /// <summary>
        /// 通讯方式改为串口委托定义，通讯方式改为串口通讯时被调用
        /// </summary>
        /// <param name="com">串口号(如：COM1)</param>
        /// <param name="boardrate">波特率</param>
        public delegate void CommunicationToSerialPortDelegate(string com, int boardrate);
        /// <summary>
        /// 通讯方式改为串口事件定义
        /// </summary>
        public event CommunicationToSerialPortDelegate CommunicationToSerialPort;
        #endregion

        #region 改用网络通讯方式事件
        /// <summary>
        /// 通讯方式改为网络委托定义，通讯方式改为网络通讯时被调用
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <param name="localport">本地端口</param>
        /// <param name="remoteport">远程端口</param>
        public delegate void CommunicationToNetworkDelegate(string startip, string endip, int localport, int remoteport);
        /// <summary>
        /// 通讯方式改为网络事件定义
        /// </summary>
        public event CommunicationToNetworkDelegate CommunicationToNetwork;

        #endregion

        #region 组地址发生变化
        /// <summary>
        /// 箱体地址发生变化委托定义
        /// </summary>
        /// <param name="x">箱体地址X</param>
        /// <param name="y">箱体地址Y</param>
        public delegate void GroupAddressChangedDelegate(int x, int y);
        /// <summary>
        /// 箱体地址发生变化事件定义
        /// </summary>
        public event GroupAddressChangedDelegate GroupAddressChanged;
        #endregion

        #region 箱体地址发生变化
        /// <summary>
        /// 箱体地址发生变化委托定义
        /// </summary>
        /// <param name="x">箱体地址X</param>
        /// <param name="y">箱体地址Y</param>
        public delegate void UnitAddressChangedDelegate(int x, int y);
        /// <summary>
        /// 箱体地址发生变化事件定义
        /// </summary>
        public event UnitAddressChangedDelegate UnitAddressChanged;
        #endregion

        #region 模块地址发生变化
        /// <summary>
        /// 箱体地址发生变化委托定义
        /// </summary>
        /// <param name="x">箱体地址X</param>
        /// <param name="y">箱体地址Y</param>
        public delegate void ModuleAddressChangedDelegate(int x, int y);
        /// <summary>
        /// 箱体地址发生变化事件定义
        /// </summary>
        public event ModuleAddressChangedDelegate ModuleAddressChanged;
        #endregion

        #region 命令发送等待时间事件
        /// <summary>
        /// 命令发送等待时间委托定义
        /// </summary>
        /// <param name="sendTime">命令发送等待事件</param>
        /// <param name="revTime">命令接收等待时间</param>
        public delegate void CommandTimeChangedDelegate(int sendTime, int revTime);
        /// <summary>
        /// 命令发送等待时间事件定义
        /// </summary>
        public event CommandTimeChangedDelegate CommandTimeChanged;
        #endregion

        #region TV Player类型发生变化
        /// <summary>
        /// TV PLAYER类别变化委托定义
        /// </summary>
        /// <param name="playerType">player类别</param>
        public delegate void TVPlayerTypeChangedDelegate(PlayerType playerType);
        /// <summary>
        /// TV PLAYER类别变化事件定义
        /// </summary>
        public event TVPlayerTypeChangedDelegate TVPlayerTypeChanged;
        #endregion

        #region 输出口发生变化
        /// <summary>
        /// 输出口类别变化委托定义
        /// </summary>
        /// <param name="outputType">输出口类别</param>
        public delegate void OutputTypeChangedDelegate(OutputType outputType);
        /// <summary>
        /// 输出口类别变化事件定义
        /// </summary>
        public event OutputTypeChangedDelegate OutputTypeChanged;
        #endregion

        #region 是否输出数据包发生变化
        /// <summary>
        /// 是否显示数据包监控委托定义
        /// </summary>
        /// <param name="isShowDataPackage">true:显示,false:不显示</param>
        public delegate void IsShowDataPackageChangedDelegate(bool isShowDataPackage);
        /// <summary>
        /// 是否显示数据包监视事件定义
        /// </summary>
        public event IsShowDataPackageChangedDelegate IsShowDataPackageChanged;
        #endregion

        #region 重新获得焦点事件
        /// <summary>
        /// 插件重新激活委托定义
        /// </summary>
        public delegate void ReActivedDelegate();
        /// <summary>
        /// 插件重新激活事件定义
        /// </summary>
        public event ReActivedDelegate reActived;
        #endregion

        #region 供其他窗口调用的事件
        public delegate void CallBackFormOtherFormDelegate(object arg);
        public event CallBackFormOtherFormDelegate callBack;
        #endregion

        #region 多语言相关
        protected static IList[] m_remoteLanDic;
        protected IList[] m_localLanDic;
        protected string m_region;
        static protected string m_split;
        protected int m_lanIndex;
        private bool m_loadLocalLanPackage = true;//是否加载本地语言包，如果存在并且为真则加载

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lanDic">所有语言包</param>
        /// <param name="lanIndex">当前语言的索引</param>
        public void SetLanDic(IList[] lanDic, int lanIndex, string region, string split)
        {
            BaseFormV2.m_remoteLanDic = lanDic;
            m_lanIndex = lanIndex;
            m_region = region;
            m_split = split;
            //m_localLanDic = new IList[lanDic.Length + 1];
            m_localLanPath = Path + "/Language";
        }

        public void Clone(BaseFormV2 form)
        {
            this.m_localLanDic = form.m_localLanDic;
            this.m_region = form.m_region;
            this.m_lanIndex = form.m_lanIndex;
            this.Path = form.Path;
        }

        public void Clone(IList[] remoteLan_Dic, string region, int lanIndex)
        {
            m_remoteLanDic = remoteLan_Dic;
            this.m_localLanDic = remoteLan_Dic;
            this.m_region = region;
            this.m_lanIndex = lanIndex;
        }

        protected void SetRegion(string region)
        {
            m_region = region;
        }

        public void TranslateControlText()
        {
            this.Text = FindDic(m_localLanDic, this.Text, m_region);
            EnumControls(this.Controls, m_region);
        }

        public void TranslateControlText(Control.ControlCollection controls)
        {
            EnumControls(controls, m_region);
        }

        public void TranslateControlText(Control.ControlCollection controls, string region)
        {
            EnumControls(controls, region);
        }

        public void TranslateControlText(string region)
        {
            this.Text = FindDic(m_localLanDic, this.Text, region);
            EnumControls(this.Controls, region);
        }

        public string TranslateCodeText(string text)
        {
            string result = text;
            result = FindDic(m_localLanDic, text, m_region);
            return result;
        }

        public string TranslateCodeText(string[] codes)
        {
            string result = "";
            if (codes == null) return "";
            foreach (var item in codes)
            {
                result += FindDic(m_localLanDic, item, m_region);
            }
            return result;
        }

        public string TranslateCodeText(string text, string region)
        {
            string result = text;
            result = FindDic(m_localLanDic, text, region);
            return result;
        }

        public string TranslateCodeText(string[] codes, string region)
        {
            string result = "";
            if (codes == null) return "";
            foreach (var item in codes)
            {
                result += FindDic(m_localLanDic, item, region);
            }
            return result;
        }

        //伪代码
        void EnumControls(Control.ControlCollection ctrlCollection, string region)
        {
            foreach (Control ctrl in ctrlCollection)
            {
                if (ctrl.GetType().Equals(typeof(MenuStrip)))
                {
                    EnumControls((ctrl as MenuStrip).Items, region);
                }
                else if (ctrl.GetType().Equals(typeof(DevComponents.DotNetBar.TabControl)))
                {
                    EnumControls((ctrl as DevComponents.DotNetBar.TabControl).Tabs, region);
                }
                else if (ctrl.GetType().Equals(typeof(DevComponents.DotNetBar.SuperTabControl)))
                {
                    EnumControls((ctrl as DevComponents.DotNetBar.SuperTabControl).Tabs, region);
                }
                else if (ctrl.GetType().Equals(typeof(CheckedListBox)))
                {
                    EnumCheckedListBox((ctrl as CheckedListBox).Items, region);
                }
                else if (ctrl.GetType().Equals(typeof(ComboBox)))
                {
                    EnumComboxBox((ctrl as ComboBox).Items, region);
                }
                else if (ctrl.GetType().Equals(typeof(DevComponents.DotNetBar.Controls.ComboBoxEx)))
                {
                    EnumComboxBox((ctrl as DevComponents.DotNetBar.Controls.ComboBoxEx).Items, region);
                }
                else if (ctrl.GetType().Equals(typeof(DevComponents.DotNetBar.Controls.SwitchButton)))
                {
                    DevComponents.DotNetBar.Controls.SwitchButton btn = (ctrl as DevComponents.DotNetBar.Controls.SwitchButton);
                    btn.OnText = FindDic(m_localLanDic, btn.OnText, region);
                    btn.OffText = FindDic(m_localLanDic, btn.OffText, region);
                }
                else if (ctrl.GetType().Equals(typeof(DevComponents.DotNetBar.RibbonBar)))
                {
                    EnumDevSubItemsCollection((ctrl as DevComponents.DotNetBar.RibbonBar).Items, region);
                    EnumControls(ctrl.Controls, region);
                }
                else if (ctrl.GetType().Equals(typeof(DevComponents.DotNetBar.ContextMenuBar)))
                {
                    EnumDevSubItemsCollection((ctrl as DevComponents.DotNetBar.ContextMenuBar).Items, region);
                }
                else
                {
                    EnumControls(ctrl.Controls, region);
                }

                try
                {
                    if (!ctrl.GetType().Equals(typeof(System.Windows.Forms.Panel)))
                    {
                        ctrl.Text = FindDic(m_localLanDic, ctrl.Text, region);
                    }
                    //if (ctrl.Controls.Count > 0)
                    //{
                    //    EnumControls(ctrl.Controls, region);
                    //}
                }
                catch
                {

                }
                //parent.Text = FindDic(m_localLanDic, parent.Text, region);
            }
        }

        //菜单子项
        void EnumControls(ToolStripItemCollection menuItems, string region)
        {
            if (menuItems == null) return;
            foreach (var item in menuItems)
            {
                if (item.GetType().Equals(typeof(System.Windows.Forms.ToolStripSeparator)))
                    continue;

                if (item.GetType().Equals(typeof(ToolStripComboBox)))
                {
                    EnumComboxBox((item as ToolStripComboBox).Items, region);
                    continue;
                }

                if (item.GetType().Equals(typeof(ToolStripTextBox)))
                {
                    (item as ToolStripTextBox).Text = FindDic(m_localLanDic, (item as ToolStripTextBox).Text, region);
                    continue;
                }

                if (item.GetType().Equals(typeof(ToolStripMenuItem)))
                {
                    EnumControls((item as ToolStripMenuItem).DropDownItems, region);
                    (item as ToolStripMenuItem).Text = FindDic(m_localLanDic, (item as ToolStripMenuItem).Text, region);
                    continue;
                }
                (item as ToolStripMenuItem).Text = FindDic(m_localLanDic, (item as ToolStripMenuItem).Text, region);
            }
        }

        void EnumComboxBox(ComboBox.ObjectCollection objectCollection, string region)
        {
            for (int i = 0; i < objectCollection.Count; i++)
            {
                if (objectCollection[i].GetType().Equals(typeof(string)))
                {
                    objectCollection[i] = FindDic(m_localLanDic, objectCollection[i].ToString(), region);
                }
                else if (objectCollection[i].GetType().Equals(typeof(DevComponents.Editors.ComboItem)))
                {
                    (objectCollection[i] as DevComponents.Editors.ComboItem).Text = FindDic(m_localLanDic, objectCollection[i].ToString(), region);
                }
            }
        }

        void EnumCheckedListBox(CheckedListBox.ObjectCollection objectCollection, string region)
        {
            for (int i = 0; i < objectCollection.Count; i++)
            {
                if (objectCollection[i].GetType().Equals(typeof(string)))
                {
                    objectCollection[i] = FindDic(m_localLanDic, objectCollection[i].ToString(), region);
                }
            }
        }

        void EnumControls(DevComponents.DotNetBar.TabsCollection tabCollection, string region)
        {
            foreach (var item in tabCollection)
            {
                if (item.GetType().Equals(typeof(DevComponents.DotNetBar.TabItem)))
                {
                    EnumControls((item as DevComponents.DotNetBar.TabItem).AttachedControl.Controls, region);
                    (item as DevComponents.DotNetBar.TabItem).Text = FindDic(m_localLanDic, (item as DevComponents.DotNetBar.TabItem).Text, region);
                }
            }
        }

        void EnumControls(DevComponents.DotNetBar.SubItemsCollection tabCollection, string region)
        {
            foreach (var item in tabCollection)
            {
                if (item.GetType().Equals(typeof(DevComponents.DotNetBar.SuperTabItem)))
                {
                    EnumControls((item as DevComponents.DotNetBar.SuperTabItem).AttachedControl.Controls, region);
                    (item as DevComponents.DotNetBar.SuperTabItem).Text = FindDic(m_localLanDic, (item as DevComponents.DotNetBar.SuperTabItem).Text, region);
                }
            }
        }

        void EnumDevSubItemsCollection(DevComponents.DotNetBar.SubItemsCollection subItemsCollection, string region)
        {
            foreach (var item in subItemsCollection)
            {
                try
                {
                    if (item.GetType().Equals(typeof(DevComponents.DotNetBar.CheckBoxItem)))
                    {
                        (item as DevComponents.DotNetBar.CheckBoxItem).Text = FindDic(m_localLanDic, (item as DevComponents.DotNetBar.CheckBoxItem).Text, region);
                    }
                    else if (item.GetType().Equals(typeof(DevComponents.DotNetBar.ButtonItem)))
                    {
                        (item as DevComponents.DotNetBar.ButtonItem).Text = FindDic(m_localLanDic, (item as DevComponents.DotNetBar.ButtonItem).Text, region);
                        EnumDevSubItemsCollection((item as DevComponents.DotNetBar.ButtonItem).SubItems, region);
                    }
                }
                catch { }
            }
        }

        string FindDic(IList[] landic, string text, string region)
        {
            string tmpRegion = region;
            string result = text + "_|_";
            int index = 0;
            bool exist = false;
            foreach (var item in landic[1])
            {
                if (text == item.ToString())
                {
                    if (region == landic[0][index].ToString())
                    {
                        result = landic[m_lanIndex][index].ToString();
                        if (result == "#EMPTY#")
                        {
                            result = text;
                            tmpRegion = region;
                        }
                        return result;
                    }
                    //else if (landic[0][index].ToString() == "default")
                    //{
                    //    result = landic[m_lanIndex][index].ToString();
                    //    tmpRegion = "default";
                    //}
                }
                index++;
            }

            tmpRegion = region;
            result = text + "_|_";
            index = 0;
            exist = false;
            foreach (var item in landic[2])
            {
                if (text == item.ToString())
                {
                    if (region == landic[0][index].ToString())
                    {
                        result = landic[m_lanIndex][index].ToString();
                        if (result == "#EMPTY#")
                        {
                            result = text;
                            tmpRegion = region;
                        }
                        return result;
                    }
                    //else if (landic[0][index].ToString() == "default")
                    //{
                    //    result = landic[m_lanIndex][index].ToString();
                    //    tmpRegion = "default";
                    //}
                }
                index++;
            }
            result = FindInRemoteDic(m_remoteLanDic, text, region);
            if (IsCheckWordExist) CheckIsExistDic(result);
            if (result.EndsWith("_|_"))
            {
                result = text.Replace("_|_", "");
            }
            return result;
        }

        string FindInRemoteDic(IList[] landic, string text, string region)
        {
            string tmpRegion = region;
            string result = text + "_|_";
            int index = 0;
            bool exist = false;
            foreach (var item in landic[1])
            {
                if (text == item.ToString())
                {
                    if (region == landic[0][index].ToString())
                    {
                        result = landic[m_lanIndex][index].ToString();
                        if (result == "#EMPTY#")
                        {
                            result = text;
                        }
                        tmpRegion = region;
                        for (int i = 0; i < landic.Length; i++)
                        {
                            m_localLanDic[i].Add(landic[i][index]);
                        }
                        exist = true;
                        break;
                    }
                    else if (landic[0][index].ToString() == "default")
                    {
                        result = landic[m_lanIndex][index].ToString();
                        tmpRegion = "default";
                    }
                    exist = true;
                }
                index++;
            }
            if (!exist)
            {
                tmpRegion = region;
                result = text + "_|_";
                index = 0;
                exist = false;
                foreach (var item in landic[2])
                {
                    if (text == item.ToString())
                    {
                        if (region == landic[0][index].ToString())
                        {
                            result = landic[m_lanIndex][index].ToString();
                            if (result == "#EMPTY#")
                            {
                                result = text;
                            }
                            tmpRegion = region;
                            for (int i = 0; i < landic.Length; i++)
                            {
                                m_localLanDic[i].Add(landic[i][index]);
                            }
                            exist = true;
                            break;
                        }
                        else if (landic[0][index].ToString() == "default")
                        {
                            result = landic[m_lanIndex][index].ToString();
                            tmpRegion = "default";
                        }
                        exist = true;
                    }
                    index++;
                }
            }
            if (exist)
            {
                AppendLocalLanToDic(text, tmpRegion);
            }
            if (IsCheckWordExist) CheckIsExistDic(result);
            if (result.EndsWith("_|_"))
            {
                result = text.Replace("_|_", "");
            }
            return result;
        }

        void AppendLocalLanToDic(string text, string region)
        {
            string tmpRegion = region;
            string result = "";//亮度#LEYARD#Brightness#LEYARD#亮度值#LEYARD#lang
            int index = 0;
            int tmpIndex = 0;
            bool exist = false;
            foreach (var item in m_remoteLanDic[1])
            {
                if (text == item.ToString() && region == m_remoteLanDic[0][index].ToString())
                {
                    tmpIndex = index;
                    exist = true;
                    break;
                }
                index++;
            }
            if (!exist)
            {
                tmpRegion = region;
                result = "";//亮度#LEYARD#Brightness#LEYARD#亮度值#LEYARD#lang
                index = 0;
                tmpIndex = 0;
                exist = false;
                foreach (var item in m_remoteLanDic[2])
                {
                    if (text == item.ToString() && region == m_remoteLanDic[0][index].ToString())
                    {
                        tmpIndex = index;
                        exist = true;
                        break;
                    }
                    index++;
                }
            }
            if (exist)
            {
                TextWriter writer = new StreamWriter(m_localLanPath + "/" + m_localLanTxt, true, Encoding.UTF8);
                string lanStr = "";
                for (int i = 0; i < m_remoteLanDic.Length - 1; i++)
                {
                    lanStr += m_remoteLanDic[i][index] + m_split;
                }
                lanStr += m_remoteLanDic[m_remoteLanDic.Length - 1][index];
                writer.WriteLine(lanStr);
                writer.Flush();
                writer.Close();
            }
        }

        public void SetIsLoadLocalLan(bool isLoadLocal)
        {
            m_loadLocalLanPackage = isLoadLocal;
            if (!Directory.Exists(m_localLanPath))
            {
                Directory.CreateDirectory(m_localLanPath);
            }
            if (!isLoadLocal)
            {
                if (File.Exists(m_localLanPath + "/" + m_localLanTxt))
                {
                    File.Delete(m_localLanPath + "/" + m_localLanTxt);
                }
                //File.CreateText(m_localLanPath + "/" + m_localLanTxt).Close();
                TextWriter writer = new StreamWriter(m_localLanPath + "/" + m_localLanTxt, false, Encoding.UTF8);
                writer.Close();
            }
            if (!File.Exists(m_localLanPath + "/" + m_localLanTxt))
            {
                //File.CreateText(m_localLanPath + "/" + m_localLanTxt).Close();
                TextWriter writer = new StreamWriter(m_localLanPath + "/" + m_localLanTxt, false, Encoding.UTF8);
                writer.Close();
            }
            LoadLocalLan();
        }

        void LoadLocalLan()
        {
            int lanLeng = m_remoteLanDic.Length;
            m_localLanDic = new ArrayList[lanLeng];

            for (int i = 0; i < lanLeng; i++)
            {
                m_localLanDic[i] = new ArrayList();
            }
            StreamReader reader = new StreamReader(m_localLanPath + "/" + m_localLanTxt, Encoding.UTF8);
            int index = 0;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] tmpStrArr = line.Split(new string[] { m_split }, StringSplitOptions.None);
                for (int i = 0; i < lanLeng; i++)
                {
                    if (i < tmpStrArr.Length)
                    {
                        m_localLanDic[i].Add(tmpStrArr[i]);
                    }
                    else
                    {
                        m_localLanDic[i].Add("#EMPTY#");
                    }
                }
            }
            reader.Close();
        }

        void CheckIsExistDic(string text)
        {
            if (text.EndsWith("_|_"))
            {
                MessageBox.Show("Translate error:\r\n\tWord:" + text.Replace("_|_", "") + " not found");
            }
        }
        #endregion
        #endregion

        #region 用于触发自定义事件的方法

        /// <summary>
        /// 出发插件的FormClosing事件
        /// </summary>
        /// <returns>DialogResult.Yes | DialogResult.No</returns>
        /// 
        private DialogResult FormClose()
        {
            if (FormClosing != null)
            {
                return FormClosing();
            }
            return DialogResult.Yes;
        }

        /// <summary>
        /// 箱体类型发生变化
        /// </summary>
        /// <param name="unitType">箱体类别</param>
        private void UnitTypeChangeTo(UnitTypeV2 unitType)
        {
            if (UnitTypeChanged != null)
            {
                UnitTypeChanged(unitType);
            }
        }

        /// <summary>
        /// 使用串口通讯
        /// </summary>
        /// <param name="com">串口号</param>
        /// <param name="bardrate">波特率</param>
        private void CommunicationToUseSerialPort(string com, int bardrate)
        {
            if (CommunicationToSerialPort != null)
            {
                CommunicationToSerialPort(com, bardrate);
            }
        }

        /// <summary>
        /// 使用网络通讯方式
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <param name="localport">本地端口</param>
        /// <param name="remoteport">TV盒端口</param>
        private void CommunicationToUseNetwork(string startip, string endIP, int localport, int remoteport)
        {
            if (CommunicationToNetwork != null)
            {
                CommunicationToNetwork(startip, endIP, localport, remoteport);
            }
        }
        /// <summary>
        /// 组地址发生变化
        /// </summary>
        /// <param name="x">组地址X</param>
        /// <param name="y">组地址Y</param>
        private void GroupAddressChangedTo(int x, int y)
        {
            if (GroupAddressChanged != null)
            {
                GroupAddressChanged(x, y);
            }
        }

        /// <summary>
        /// 箱体地址发生变化
        /// </summary>
        /// <param name="x">箱体地址X</param>
        /// <param name="y">箱体地址Y</param>
        private void UnitAddressChangedTo(int x, int y)
        {
            if (UnitAddressChanged != null)
            {
                UnitAddressChanged(x, y);
            }
        }

        private void ModuleAddressChangedTo(int x, int y)
        {
            if (ModuleAddressChanged != null)
            {
                ModuleAddressChanged(x, y);
            }
        }

        /// <summary>
        /// 命令发送等待时间发生变化
        /// </summary>
        /// <param name="sendTime">发送时间</param>
        /// <param name="revTime">接收时间</param>
        private void CommandTimeChangedTo(int sendTime, int revTime)
        {
            if (CommandTimeChanged != null) CommandTimeChanged(sendTime, revTime);
        }

        /// <summary>
        /// Player类型发生变化
        /// </summary>
        /// <param name="playerType">Player类别</param>
        private void TVPlayerTypeChangedTo(PlayerType playerType)
        {
            if (TVPlayerTypeChanged != null) TVPlayerTypeChanged(playerType);
        }

        /// <summary>
        /// 输出口类型发生变化
        /// </summary>
        /// <param name="outputType">输出口类别</param>
        private void OutputTypeChangedTo(OutputType outputType)
        {
            if (OutputTypeChanged != null) OutputTypeChanged(outputType);
        }

        /// <summary>
        /// 是否显示命令数据包
        /// </summary>
        /// <param name="isShowDataPackage">是否显示数据包</param>
        private void IsShowDataPackageChangedTo(bool isShowDataPackage)
        {
            if (IsShowDataPackageChanged != null) IsShowDataPackageChanged(isShowDataPackage);
        }

        private void ReActived()
        {
            if (reActived != null)
            {
                reActived();
            }
        }

        public virtual void CallBack(object arg)
        {
            if (callBack != null)
            {
                callBack(arg);
            }
        }

        #endregion

        #region 供插件调用的方法
        #region 消息处理事件定义

        #region 输出消息事件
        /// <summary>
        /// 输出消息到任务栏委托定义
        /// </summary>
        /// <param name="messag">消息</param>
        public delegate void WriteStatusMessageHandler(string messag);

        /// <summary>
        /// 输出消息到任务栏事件
        /// </summary>
        public static event WriteStatusMessageHandler statusMessage;

        public delegate void WriteMessageHandler(string messag);
        public static event WriteMessageHandler message;

        /// <summary>
        /// 输出信息到输出窗口
        /// </summary>
        /// <param name="msg"></param>
        public static void Write(string msg, bool showTime)
        {
            if (message != null)
            {
                if (showTime)
                {
                    message(DateTime.Now.ToString("HH:mm:ss") + "  \r\n" + msg);
                }
                else
                {
                    message(msg);
                }
            }
        }
        /// <summary>
        /// 输出消息到输出窗口，并带回车换行
        /// </summary>
        /// <param name="msg"></param>
        public static void WriteLine(string msg, bool showTime)
        {
            lock (typeof(BaseFormV2))
            {
                string strmsg = string.Empty;
                if (!string.IsNullOrEmpty(msg))
                {
                    strmsg = msg + "  \r\n";
                    Write(strmsg, showTime);
                }
            }
        }

        public static void WriteStatusMessage(string msg)
        {
            if (statusMessage != null)
            {
                statusMessage(msg);
            }
        }
        #endregion

        #region 清除文本框信息
        //清楚消息事件
        public delegate void ClearMessageHandler();
        public static event ClearMessageHandler clear;
        //清空输出窗口消息
        public static void Clear()
        {
            if (clear != null)
            {
                clear();
            }
        }
        #endregion

        #region 插件间共享数据
        //共享数据事件
        public delegate void PushDataHandler(object data);
        public static event PushDataHandler pushData;
        //提取共享数据事件
        public delegate Queue PopupDataHandler();
        public static event PopupDataHandler popupData;

        //共享数据
        public static void PushData(object data)
        {
            if (pushData != null)
            {
                pushData(data);
            }
        }
        //使用共享数据
        public static object[] PopupData()
        {
            if (popupData != null)
            {
                object[] obj = null;
                Queue queue = popupData().Count == 0 ? null : popupData();
                if (queue != null)
                {
                    obj = new object[queue.Count];
                    int i = 0;
                    while (queue.Count > 0)
                    {
                        obj[i] = queue.Dequeue();
                        i++;
                    }
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 进度条控制
        //执行进度事件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">下载类型</param>
        /// <param name="message">消息字符串</param>
        /// <param name="value">下载进度</param>
        public delegate void PrograssInfoHandler(String type, String message, int? value);
        public static event PrograssInfoHandler PrograssInfo;

        public delegate void ProgressMaxValueHandler(int max);
        public static event ProgressMaxValueHandler ProgressMaxValue;

        public delegate void ResetProgressMaxValueHandler();
        public static event ResetProgressMaxValueHandler resetProgressMaxValue;

        public delegate int GetProgressValueHandler();
        public static event GetProgressValueHandler getProgressValue;

        //进度条
        public static void SetPrograss(String type, String message, int? value)
        {
            if (PrograssInfo != null)
            {
                PrograssInfo(type, message, value);
            }
        }
        //操作日志
        public static void SetProgressMaxValue(int max)
        {
            if (ProgressMaxValue != null)
            {
                ProgressMaxValue(max);
            }
        }

        public static void ResetProgressMaxValue()
        {
            if (resetProgressMaxValue != null)
            {
                resetProgressMaxValue();
            }
        }

        /// <summary>
        /// 得到进图条信息
        /// </summary>
        /// <returns>-1表示没有进度信息</returns>
        public static int GetProgressValue()
        {
            if (getProgressValue != null)
            {
                return getProgressValue();
            }
            return -1;
        }
        #endregion

        #region 日志记录
        //写操作日志事件
        public delegate void LogOptHandler(string strCaoZuoLeiXing, string strZhiLingNeiRong, bool ifSuccess);
        public static event LogOptHandler LogOperatorInfo;

        //写系统日志
        public delegate void LogSystemHandler(string strCaoZuoLeingXing, string strZhiLingNeiRong, string strErrorContent);
        public static event LogSystemHandler LogSystemInfo;

        public static void OperatorLog(string strCaoZuoLeiXing, string strZhiLingNeiRong, bool ifSuccess)
        {
            if (LogOperatorInfo != null)
            {
                LogOperatorInfo(strCaoZuoLeiXing, strZhiLingNeiRong, ifSuccess);
            }
        }
        //系统日志
        public static void SystemLog(string strCaoZuoLeingXing, string strZhiLingNeiRong, string strErrorContent)
        {
            if (LogSystemInfo != null)
            {
                LogSystemInfo(strCaoZuoLeingXing, strZhiLingNeiRong, strErrorContent);
            }
        }
        #endregion

        #region 箱体类型
        //设置要显示的箱体类型
        public delegate void SetPanelMainTypeHandler(String[] mainTypes);
        public static event SetPanelMainTypeHandler setPanelMainType;
        public static void SetPanelMainType(String[] types)
        {
            if (setPanelMainType != null)
            {
                setPanelMainType(types);
            }
        }

        //得到选中的箱体类型
        public delegate UnitTypeV2 GetSelectedPanelTypeHandler();
        public static event GetSelectedPanelTypeHandler getSelectedPanelType;
        public static UnitTypeV2 GetSelectedPanelType()
        {
            UnitTypeV2 unitType = default(UnitTypeV2);
            if (getSelectedPanelType != null)
            {
                unitType = getSelectedPanelType();
            }
            return unitType;
        }

        //设置选中指定箱体类型
        public delegate void SetSelectedPanelTypeHandler(UnitType unitType);
        public static event SetSelectedPanelTypeHandler setSelectedPanelType;
        public static void SetSelectedPanelType(UnitType unitType)
        {
            if (setSelectedPanelType != null)
            {
                setSelectedPanelType(unitType);
            }
        }
        #endregion

        #region  通讯方式
        public delegate CommunicationType GetCommunicationTypeHandler();
        public static event GetCommunicationTypeHandler getCommunicationType;
        public static CommunicationType GetCommunicationType()
        {
            CommunicationType cbType = default(CommunicationType);
            if (getCommunicationType != null)
            {
                cbType = getCommunicationType();
            }
            return cbType;
        }

        //设置选中通讯方式
        public delegate void SetCommunicationTypeHandler(CommunicationType commType);
        public static event SetCommunicationTypeHandler setCommunicationType;
        public static void SetCommunicationType(CommunicationType commType)
        {
            if (setCommunicationType != null)
            {
                setCommunicationType(commType);
            }
        }
        #endregion

        #region 组地址
        public delegate Point GetGroupAddrHandler();
        public static event GetGroupAddrHandler getGroupAddr;
        public static Point GetGroupAddr()
        {
            Point addr = default(Point);
            if (getGroupAddr != null)
            {
                addr = getGroupAddr();
            }
            return addr;
        }
        #endregion
        #region 箱体地址
        public delegate Point GetUnitAddrHandler();
        public static event GetUnitAddrHandler getUnitAddr;
        public static Point GetUnitAddr()
        {
            Point addr = default(Point);
            if (getUnitAddr != null)
            {
                addr = getUnitAddr();
            }
            return addr;
        }

        public delegate void SetUnitAddrHandler(Point addr);
        public static event SetUnitAddrHandler setUnitAddr;
        public static void SetUnitAddr(Point point)
        {
            if (setUnitAddr != null)
            {
                setUnitAddr(point);
            }
        }
        #endregion

        #region 模块地址
        public delegate Point GetModuleAddrHandler();
        public static event GetModuleAddrHandler getModuleAddr;
        public static Point GetModuleAddr()
        {
            Point addr = default(Point);
            if (getModuleAddr != null)
            {
                addr = getModuleAddr();
            }
            return addr;
        }
        #endregion


        #region 发送和接收时间
        public delegate int GetSendDataTimeHandler();
        public static event GetSendDataTimeHandler getSendDataTime;
        public static int GetSendDataTime()
        {
            int time = 300;
            if (getSendDataTime != null)
            {
                time = getSendDataTime();
            }
            return time;
        }

        public delegate void SetSendDataTimeHandler(int time);
        public static event SetSendDataTimeHandler setSendDataTime;
        public static void SetSendDataTime(int time)
        {
            if (setSendDataTime != null)
            {
                setSendDataTime(time);
            }
        }

        public delegate int GetReceiveDataTimeHandler();
        public static event GetReceiveDataTimeHandler getReceiveDataTime;
        public static int GetReceiveDataTime()
        {
            int time = 300;
            if (getReceiveDataTime != null)
            {
                time = getReceiveDataTime();
            }
            return time;
        }

        public delegate void SetReceiveDataTimeHandler(int time);
        public static event SetReceiveDataTimeHandler setReceiveDataTime;
        public static void SetReceiveDataTime(int time)
        {
            if (setReceiveDataTime != null)
            {
                setReceiveDataTime(time);
            }
        }
        #endregion

        #region 是否显示数据包
        public delegate bool GetShowDataPackageHandler();
        public static event GetShowDataPackageHandler getShowDataPackage;
        public static bool GetShowDataPackage()
        {
            bool showDataPackage = false;
            if (getShowDataPackage != null)
            {
                showDataPackage = getShowDataPackage();
            }
            return showDataPackage;
        }

        public delegate void SetShowDataPackageHandler(bool showDataPackage);
        public static event SetShowDataPackageHandler setShowDataPackage;
        public static void SetShowDataPackage(bool showDataPackage)
        {
            if (setShowDataPackage != null)
            {
                setShowDataPackage(showDataPackage);
            }
        }
        #endregion

        #region Player类型和输出口类型
        public delegate PlayerType GetPlayerTypeHandler();
        public static event GetPlayerTypeHandler getPlayerType;
        public static PlayerType GetPlayerType()
        {
            PlayerType ptype = default(PlayerType);
            if (getPlayerType != null)
            {
                ptype = getPlayerType();
            }
            return ptype;
        }

        public delegate void SetPlayerTypeHandler(PlayerType pType);
        public static event SetPlayerTypeHandler setPlayerType;
        public static void SetPlayerType(PlayerType pType)
        {
            if (setPlayerType != null)
            {
                setPlayerType(pType);
            }
        }

        public delegate OutputType GetOutputTypeHandler();
        public static event GetOutputTypeHandler getOutputType;
        public static OutputType GetOutputType()
        {
            OutputType otype = default(OutputType);
            if (getOutputType != null)
            {
                otype = getOutputType();
            }
            return otype;
        }

        public delegate void SetOutputTypeHandler(OutputType oType);
        public static event SetOutputTypeHandler setOutputType;
        public static void SetOutputType(OutputType oType)
        {
            if (setOutputType != null)
            {
                setOutputType(oType);
            }
        }
        #endregion

        /// <summary>
        /// 当前动态库所在路径（不包含最后一个斜杠）
        /// </summary>
        public String Path
        {
            //get
            //{
            //    return Environment.CurrentDirectory;
            //    //return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            //}
            get;
            set;
        }

        /// <summary>
        ///  程序根目录（包含最后一个斜杠）
        /// </summary>
        public static String BasePath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }


        #region 色温数据
        public delegate int GetStartCTDelete();
        public static event GetStartCTDelete GetStartCTHandler;
        public static int GetStartCT()
        {
            int start = 3200;
            if (GetStartCTHandler != null)
            {
                start = GetStartCTHandler();
            }
            return start;
        }

        public delegate int GetEndCTDelete();
        public static event GetEndCTDelete GetEndCTHandler;
        public static int GetEndCT()
        {
            int start = 9300;
            if (GetEndCTHandler != null)
            {
                start = GetEndCTHandler();
            }
            return start;
        }
        #endregion

        #endregion

        #region 输出消息到框架中的状态栏
        #region 输出消息事件
        /// <summary>
        /// 输出消息到任务栏委托定义
        /// </summary>
        /// <param name="messag">消息</param>
        public delegate void WriteOtherInfoHandler(string message);
        public static event WriteOtherInfoHandler otherInfo;
        /// <summary>
        ///  写状态信息到框架
        /// </summary>
        /// <param name="message"></param>
        public static void WriteOtherInfo(string message)
        {
            if (otherInfo != null)
            {
                otherInfo(message);
            }
        }

        #endregion

        private void BaseFormV2_Load(object sender, EventArgs e)
        {
            //m_localLanPath = Path + "/Language";
            //if (!System.IO.Directory.Exists(m_localLanPath))
            //{
            //    System.IO.Directory.CreateDirectory(m_localLanPath);
            //}

            //if (!File.Exists(m_localLanPath + "/" + m_localLanTxt))
            //{
            //    StreamWriter writer = File.CreateText(m_localLanPath + "/" + m_localLanTxt);
            //    writer.Close();
            //}

            //if (!m_loadLocalLanPackage)
            //{
            //    //加载远程字典文件,清空本地文件
            //    TextWriter writer = new StreamWriter(m_localLanPath + "/" + m_localLanTxt, false);
            //    writer.Close();

            //}
            //else
            //{
            //    //加载本地字典文件
            //    ArrayList[] list = new ArrayList[m_localLanDic.Length];
            //    for (int i = 0; i < m_localLanDic.Length; i++)
            //    {
            //        list[i] = new ArrayList();
            //    }

            //    TextReader reader = new StreamReader(m_localLanPath + "/" + m_localLanTxt);
            //    string line = "";
            //    while ((line = reader.ReadLine()) != null)
            //    {
            //        string[] tmpArr = line.Split(new string[] { "#LEYARD#" }, StringSplitOptions.None);
            //        for (int i = 0; i < m_localLanDic.Length; i++)
            //        {
            //            if (i < tmpArr.Length)
            //            {
            //                list[i].Add(tmpArr[i]);
            //            }
            //            else
            //            {
            //                list[i].Add("#EMPTY#");
            //            }
            //        }
            //    }
            //}

            //ChangeLanguage();
        }
        #endregion

        #endregion

        #region 获取可用端口号
        /// <summary>
        /// 获取第一个可用的端口号
        /// </summary>
        /// <returns></returns>
        public static int GetFirstAvailablePort()
        {
            int MAX_PORT = 6000; //系统tcp/udp端口数最大是65535           
            int BEGIN_PORT = 5000;//从这个端口开始检测

            for (int i = BEGIN_PORT; i < MAX_PORT; i++)
            {
                if (PortIsAvailable(i)) return i;
            }

            return -1;
        }

        /// <summary>
        /// 检查指定端口是否已用
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public static bool PortIsAvailable(int port)
        {
            bool isAvailable = true;

            IList portUsed = PortIsUsed();

            foreach (int p in portUsed)
            {
                if (p == port)
                {
                    isAvailable = false; break;
                }
            }

            return isAvailable;
        }

        /// <summary>
        /// 获取操作系统已用的端口号
        /// </summary>
        /// <returns></returns>
        public static IList PortIsUsed()
        {
            //获取本地计算机的网络连接和通信统计数据的信息
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();

            //返回本地计算机上的所有Tcp监听程序
            IPEndPoint[] ipsTCP = ipGlobalProperties.GetActiveTcpListeners();

            //返回本地计算机上的所有UDP监听程序
            IPEndPoint[] ipsUDP = ipGlobalProperties.GetActiveUdpListeners();

            //返回本地计算机上的Internet协议版本4(IPV4 传输控制协议(TCP)连接的信息。
            TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();

            IList allPorts = new ArrayList();
            foreach (IPEndPoint ep in ipsTCP) allPorts.Add(ep.Port);
            foreach (IPEndPoint ep in ipsUDP) allPorts.Add(ep.Port);
            foreach (TcpConnectionInformation conn in tcpConnInfoArray) allPorts.Add(conn.LocalEndPoint.Port);

            return allPorts;
        }
        #endregion

        #region 工程师模式
        public delegate bool IsEnginerModeHandler();
        public static event IsEnginerModeHandler _isEnginerMode;
        public static bool IsEnginerMode
        {
            get
            {
                bool isEnginerMode = false;
                if (_isEnginerMode != null)
                {
                    isEnginerMode = _isEnginerMode();
                }
                return isEnginerMode;
            }
        }
        #endregion

        #region 选择IP地址
        public delegate string ShowSelectIPDialogHandler();
        public static event ShowSelectIPDialogHandler _showSelectIPDialog;
        public static string ShowSelectIPDialog()
        {
            string result = string.Empty;
            if (_showSelectIPDialog != null)
            {
                return _showSelectIPDialog();
            }
            return result;
        }
        #endregion
        #region 弹出箱体地址设置窗口
        public delegate DialogResult ShowUnitAddressDialogHandler(string title = "", string tipMsg = "");
        public static event ShowUnitAddressDialogHandler _showUnitAddressDialog;
        public static DialogResult ShowUnitAddressDialog(string title = "", string tipMsg = "")
        {
            if (_showUnitAddressDialog != null)
            {
                return _showUnitAddressDialog(title, tipMsg);
            }
            return DialogResult.Cancel;
        }
        public static DialogResult ShowUnitAddressDialog()
        {
            return ShowUnitAddressDialog("", "");
        }
        #endregion

        #region 弹出模块地址设置窗口
        public delegate DialogResult ShowModuleAddressDialogHandler(string title = "", string tipMsg = "");
        public static event ShowModuleAddressDialogHandler _showModuleAddressDialog;
        public static DialogResult ShowModuleAddressDialog(string title = "", string tipMsg = "")
        {
            if (_showModuleAddressDialog != null)
            {
                return _showModuleAddressDialog(title, tipMsg);
            }
            return DialogResult.Cancel;
        }
        public static DialogResult ShowModuleAddressDialog()
        {
            return ShowModuleAddressDialog("", "");
        }
        #endregion
    }
}
