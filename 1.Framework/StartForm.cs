using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LydTOPDP.Service;
using DevComponents.DotNetBar;
using System.Xml;
using System.Reflection;
using System.Collections;
using PluginLib;
using LydTOPDP;
using UnitInfo;
using LanguageLib;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.IO;
using LYDTOPDP.Service;
using System.Threading;
using DevComponents.DotNetBar.Controls;
using System.Net;
using LYDTOPDP.Extention;

namespace LYDTOPDP
{
    public partial class StartForm : Form
    {
        //class PlayerTypeObj
        //{
        //    public PlayerType PType { get; set; }
        //    public string Text { get; set; }
        //}

        public enum FormState
        {
            NONE,
            Loading,
            Complete
        }

        private IList[] m_lanDic = null;
        private int m_lanIndex = 2;
        private string m_region;//当前语言区域
        private string m_split;//各个语言之间的分割符

        bool isRestart = false;
        string pluginLoadLanCfg = Plugin.BasePath + "Plugin\\List.txt";
        string licenceFile = Plugin.BasePath + "PermissionLevel.PerLX";
        public String lang = LanguageLib.LanguageHelper.ReadLanCode().ToString();
        Queue ShareDateQueue = new Queue();
        IDictionary<string, Form> currentPlugin = null;
        PluginModel currentPluginModel = null;
        String[] types = null;//用户设置要读取的箱体类型 
        bool isEnableKey = false;
        FormState frmState = FormState.NONE;
        bool isFormLoad = true;//是否为页面加载是触发
        bool isEnginer = false;
        Form parentForm = null;
        bool isResetThread = false;//阻塞命令执行，false阻塞，true：不阻塞

        //public PermissionsData PermissionsData { get; set; }

        public StartForm()
        {
            frmState = FormState.Loading;
            InitializeComponent();


        }

        public StartForm(Form form, bool isEnginer)
        {
            frmState = FormState.Loading;
            InitializeComponent();
            InitLanguageMenu();
            expandModule.TitleText = LanguageHelper.FindInDic(m_lanDic, m_lanIndex, "模块地址", m_region);
            expandModule_copy.TitleText = LanguageHelper.FindInDic(m_lanDic, m_lanIndex, "选择模块地址", m_region);
            btnAllModule.Text = LanguageHelper.FindInDic(m_lanDic, m_lanIndex, "所有模块", m_region);
            btnAllModule_copy.Text = LanguageHelper.FindInDic(m_lanDic, m_lanIndex, "所有模块", m_region);

            //label7.Text = LanguageHelper.FindInDic(m_lanDic, m_lanIndex, "行", m_region);
            //label3.Text = LanguageHelper.FindInDic(m_lanDic, m_lanIndex, "列", m_region);

            label3.Text = MultiLanguage.GetNames(this.Name, "unitX");
            label7.Text = MultiLanguage.GetNames(this.Name, "unitY");
            label3_copy.Text = MultiLanguage.GetNames(this.Name, "unitX");
            label7_copy.Text = MultiLanguage.GetNames(this.Name, "unitY");

            this.isEnginer = isEnginer;
            parentForm = form;
        }

        public void SetLanDic(IList[] lanDic, int lanIndex, string region, string split)
        {
            m_lanDic = lanDic;
            m_lanIndex = lanIndex;
            m_region = region;
            m_split = split;
        }

        bool GetIsShowControl(string menuID, string pluginID, string id)
        {
            return true;
        }

        Point GetControlLocation(IList<PluginPermissionsDataItem> permissionDataItems, string id)
        {
            Point location = new Point(-1, -1);
            foreach (var ctr in permissionDataItems)
            {
                if (ctr.ID == id)
                {
                    return ctr.Location;
                }
                else
                {
                    location = GetControlLocation(ctr.SubItemsPermissions, id);
                    if (location.X != -1 && location.Y != -1) break;
                }
            }
            return location;
        }


        /// <summary>
        /// 初始化菜单
        /// </summary>
        void InitOptMenu()
        {
            for (int i = bar3.Items.Count - 2; i >= 0; i--)//与bar3.Items.Insert(bar3.Items.Count - 4, btnMenuItem);有关联
            {
                bar3.Items.RemoveAt(i);
            }

            #region 初始化左侧导航菜单
            MenuService leftMenuService = new MenuService();
            PluginService pgService = new PluginService();

            string menuXml = AppDomain.CurrentDomain.BaseDirectory + @"/ConfigData/Menu.xml";
            XmlDocument xmlMenuDoc = new XmlDocument();
            xmlMenuDoc.Load(menuXml);

            IList<ArrayList> leftMenus = leftMenuService.GetMenus(lang);


            for (int i = 0; i < leftMenus.Count; i++)
            {
                ButtonItem btnMenuItem = new ButtonItem
                {
                    Name = $"btnItem{i}",
                    Text = (leftMenus[i][1] as string),
                    Tag = (leftMenus[i][0]),
                    ThemeAware = true
                };
                bar3.Items.Insert(bar3.Items.Count - 1, btnMenuItem);

                #region 子功能项查找
                foreach (string item in (leftMenus[i][2] as IList<String>))
                {
                    PluginModel pm = pgService.GetPluginItem(item, lang);
                    if (pm != null)
                    {
                        pm.FunID = leftMenus[i][0].ToString();
                        ButtonItem btnItem = new ButtonItem
                        {
                            Name = pm.GUID,
                            Text = pm.Text,
                            Tooltip = pm.Tips,
                            Tag = pm,
                            ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText,
                            ImagePaddingHorizontal = 8,
                            ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
                        };
                        btnItem.Click += new EventHandler(btnItem_Click);
                        btnMenuItem.SubItems.Add(btnItem);
                    }
                }
                #endregion
            }
            bar3.Refresh();
            #endregion
        }

        #region 界面初始化
        void InitForm()
        {
            cbControlMode.SelectedIndexChanged -= cbControlMode_SelectedIndexChanged;
            txtStartIpAddress.TextChanged -= txtStartIpAddress_TextChanged;
            txtEndIpAddress.TextChanged -= txtEndIpAddress_TextChanged;

            sideBarMenu.Panels.Clear();
            cbCom.SelectedIndexChanged -= cbCom_SelectedIndexChanged;
            cbCom.DataSource = GlobalFun.GetCommKeys();
            if (cbCom.Items.Count > 0) cbCom.SelectedIndex = 0;
            cbCom.SelectedIndexChanged += cbCom_SelectedIndexChanged;
            InitOptMenu();

            #region 绑定下来列表

            //cbControlMode
            IList<ComboxList> controlModeList = new List<ComboxList>();
            controlModeList.Add(new ComboxList { Value = "1", Text = MultiLanguage.GetNames(this.Name, "rbNet") });
            controlModeList.Add(new ComboxList { Value = "0", Text = MultiLanguage.GetNames(this.Name, "rs232") });
            cbControlMode.ValueMember = "Value";
            cbControlMode.DisplayMember = "Text";
            cbControlMode.DataSource = controlModeList;

            #endregion

            #region 初始化箱体类型
            add_typename(this.types);
            #endregion

            #region 初始化通讯方式
            try
            {
                CommunicationData data = ConfigDataService.GetCommunicationData();
                cbCom.Text = data.Serialport;
                //numBaudrate.Value = int.Parse(data.Baudrate);
                //txtIP.Text = data.IP;
                numPort.Value = int.Parse(data.Remoteport);
                if (data.CommunicationType == 0)
                {
                    //rbCom.Checked = true;
                    cbControlMode.SelectedValue = data.CommunicationType.ToString();
                    txtStartIpAddress.Enabled = txtEndIpAddress.Enabled = txtPingIp.Enabled = numPort.Enabled = buttonX7.Enabled = false;
                    cbCom.Enabled = true;
                }
                else
                {
                    //rbNet.Checked = true;
                    cbControlMode.SelectedValue = data.CommunicationType.ToString();
                    txtStartIpAddress.Enabled = txtEndIpAddress.Enabled = txtPingIp.Enabled = numPort.Enabled = buttonX7.Enabled = true;
                    cbCom.Enabled = false;
                }

                txtStartIpAddress.Text = data.StartIP;
                txtEndIpAddress.Text = data.EndIP;
                cbCom.Text = data.Serialport;
            }
            catch (Exception)
            {
                MessageBox.Show(MultiLanguage.GetNames(this.Name, "commuFailed"));
            }

            try
            {
                btnTypeApply.Click -= btnTypeApply_Click;
                PanelTypeData panelData = ConfigDataService.GetPanelTypeData();
                cbSerial.Text = panelData.Serial;
                cbMainType.Text = panelData.MainType;
                cbSubType.Text = panelData.SubType;
                if (string.IsNullOrEmpty(cbSubType.Text))
                {
                    numModuleX.Value = GetSelectedUnitType().ModuleH;
                    numModuleY.Value = GetSelectedUnitType().ModuleV;
                    numModuleX_copy.Value = GetSelectedUnitType().ModuleH == 0 ? 0 : GetSelectedUnitType().ModuleH;
                    numModuleY_copy.Value = GetSelectedUnitType().ModuleV == 0 ? 0 : GetSelectedUnitType().ModuleV;
                }
            }
            catch
            {
                MessageBox.Show(MultiLanguage.GetNames(this.Name, "panelTypeFailed"));
            }
            finally
            {
                btnTypeApply.Click += btnTypeApply_Click;
            }
            #endregion

            #region 初始化上次打开的窗口
            PreSelectPlugin preSelected = ConfigDataService.GetPreSelectedPlugin();
            foreach (var item in bar3.Items)
            {
                ButtonItem menuItem = item as ButtonItem;
                if (menuItem.Tag.ToString() == preSelected.MainFunName)
                {
                    foreach (ButtonItem subMenuItem in menuItem.SubItems)
                    {
                        if (subMenuItem.Name == preSelected.SubFunName)
                        {
                            subMenuItem.RaiseClick();
                            break;
                        }
                    }
                }
            }
            #endregion

            #region 初始化bit

            int bit = ConfigDataService.GetBit();
            if (bit == 10)
            {
                ck10bit.Checked = true;
            }
            else
            {
                ck8bit.Checked = true;
            }

            #endregion

            if (currentPluginModel == null)
            {
                ckCommuSinglSave.Enabled = ckTypeSinglSave.Enabled = false;
            }

            cbControlMode.SelectedIndexChanged += cbControlMode_SelectedIndexChanged;
            txtStartIpAddress.TextChanged += txtStartIpAddress_TextChanged;
            txtEndIpAddress.TextChanged += txtEndIpAddress_TextChanged;
        }
        #endregion 插件操作

        #region 打开子插件

        IList<string> m_pluginLoadLanGuid = new List<String>();

        void LoadPluginGuid()
        {
            TextReader reader = new StreamReader(pluginLoadLanCfg);
            string line = "";
            int lineIndex = 0;
            while ((line = reader.ReadLine()) != null)
            {
                if (lineIndex++ == 0) continue;
                m_pluginLoadLanGuid.Add(line);
            }
            reader.Close();
        }

        void ChangeCabinateType(string type)
        {
            if (string.IsNullOrEmpty(type)) return;
            if (type == "") return;
            type = type.Trim();
            cbMainType.Text = type;
        }

        Form OpenPlugin(PluginModel pm)
        {
            ChangeCabinateType(pm.CabinateType);

            Assembly ass = Assembly.LoadFrom(pm.LibPath);
            Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(pm.LibPath);
            Plugin.Path = System.IO.Path.GetDirectoryName(pm.LibPath);
            string pluginClassName = pm.Namesapce + "." + pm.Name;
            Type tp = ass.GetType(pluginClassName);
            if (tp == null)
            {
                return null;
            }

            Form pluginClass = Activator.CreateInstance(tp) as Form;

            if (pm.Version == "1.0")
            {
                pluginClassName = pm.Namesapce + ".Plugin";
                tp = ass.GetType(pluginClassName);
                tp = tp.BaseType;
            }
            else if (pm.Version == "2.0")
            {
                tp = tp.BaseType;
            }

            #region 为plugin.cs文件中的消息处理事件添加委托方法
            if (pm.Version == "1.0")
            {
                EventInfo eiMessage = tp.GetEvent("message");
                eiMessage.RemoveEventHandler(this, Delegate.CreateDelegate(eiMessage.EventHandlerType, this, "WriteMessage"));
                eiMessage.AddEventHandler(this, Delegate.CreateDelegate(eiMessage.EventHandlerType, this, "WriteMessage"));

                EventInfo eiClear = tp.GetEvent("clear");
                eiClear.RemoveEventHandler(this, Delegate.CreateDelegate(eiClear.EventHandlerType, this, "ClearMessage"));
                eiClear.AddEventHandler(this, Delegate.CreateDelegate(eiClear.EventHandlerType, this, "ClearMessage"));

                //EventInfo eiPushData = tp.GetEvent("pushData");
                //eiPushData.RemoveEventHandler(this, Delegate.CreateDelegate(eiPushData.EventHandlerType, this, "PushData"));
                //eiPushData.AddEventHandler(this, Delegate.CreateDelegate(eiPushData.EventHandlerType, this, "PushData"));

                //EventInfo eiPopupData = tp.GetEvent("popupData");
                //eiPopupData.RemoveEventHandler(this, Delegate.CreateDelegate(eiPopupData.EventHandlerType, this, "PopupData"));
                //eiPopupData.AddEventHandler(this, Delegate.CreateDelegate(eiPopupData.EventHandlerType, this, "PopupData"));

                EventInfo eiPrograss = tp.GetEvent("PrograssInfo");
                eiPrograss.RemoveEventHandler(this, Delegate.CreateDelegate(eiPrograss.EventHandlerType, this, "SetPrograss"));
                eiPrograss.AddEventHandler(this, Delegate.CreateDelegate(eiPrograss.EventHandlerType, this, "SetPrograss"));

                EventInfo eiPrograssMaxValue = tp.GetEvent("ProgressMaxValue");
                eiPrograssMaxValue.RemoveEventHandler(this, Delegate.CreateDelegate(eiPrograssMaxValue.EventHandlerType, this, "SetProgressMaxValue"));
                eiPrograssMaxValue.AddEventHandler(this, Delegate.CreateDelegate(eiPrograssMaxValue.EventHandlerType, this, "SetProgressMaxValue"));

                EventInfo resetProgressMaxValue = tp.GetEvent("resetProgressMaxValue");
                resetProgressMaxValue.RemoveEventHandler(this, Delegate.CreateDelegate(resetProgressMaxValue.EventHandlerType, this, "ResetProgressMaxValue"));
                resetProgressMaxValue.AddEventHandler(this, Delegate.CreateDelegate(resetProgressMaxValue.EventHandlerType, this, "ResetProgressMaxValue"));

                EventInfo getProgressValueValue = tp.GetEvent("getProgressValue");
                getProgressValueValue.RemoveEventHandler(this, Delegate.CreateDelegate(getProgressValueValue.EventHandlerType, this, "GetProgressValue"));
                getProgressValueValue.AddEventHandler(this, Delegate.CreateDelegate(getProgressValueValue.EventHandlerType, this, "GetProgressValue"));

                EventInfo eiLogOpt = tp.GetEvent("LogOperatorInfo");
                eiLogOpt.RemoveEventHandler(this, Delegate.CreateDelegate(eiLogOpt.EventHandlerType, this, "LogOperatorInfo"));
                eiLogOpt.AddEventHandler(this, Delegate.CreateDelegate(eiLogOpt.EventHandlerType, this, "LogOperatorInfo"));

                EventInfo eiLogSystem = tp.GetEvent("LogSystemInfo");
                eiLogSystem.RemoveEventHandler(this, Delegate.CreateDelegate(eiLogSystem.EventHandlerType, this, "LogSystemInfo"));
                eiLogSystem.AddEventHandler(this, Delegate.CreateDelegate(eiLogSystem.EventHandlerType, this, "LogSystemInfo"));

                EventInfo eiSetPanelMainType = tp.GetEvent("setPanelMainType");
                eiSetPanelMainType.RemoveEventHandler(this, Delegate.CreateDelegate(eiSetPanelMainType.EventHandlerType, this, "SetPanelMainType"));
                eiSetPanelMainType.AddEventHandler(this, Delegate.CreateDelegate(eiSetPanelMainType.EventHandlerType, this, "SetPanelMainType"));

                EventInfo eiGeteSelectedPanelType = tp.GetEvent("getSelectedPanelType");
                eiGeteSelectedPanelType.RemoveEventHandler(this, Delegate.CreateDelegate(eiGeteSelectedPanelType.EventHandlerType, this, "GetSelectedUnitType"));
                eiGeteSelectedPanelType.AddEventHandler(this, Delegate.CreateDelegate(eiGeteSelectedPanelType.EventHandlerType, this, "GetSelectedUnitType"));

                EventInfo eiGetCommunicationType = tp.GetEvent("getCommunicationType");
                eiGetCommunicationType.RemoveEventHandler(this, Delegate.CreateDelegate(eiGetCommunicationType.EventHandlerType, this, "GetCommunicationType"));
                eiGetCommunicationType.AddEventHandler(this, Delegate.CreateDelegate(eiGetCommunicationType.EventHandlerType, this, "GetCommunicationType"));

                EventInfo eiSetSelectedPanelType = tp.GetEvent("setSelectedPanelType");
                eiSetSelectedPanelType.RemoveEventHandler(this, Delegate.CreateDelegate(eiSetSelectedPanelType.EventHandlerType, this, "SetSelectedPanelType"));
                eiSetSelectedPanelType.AddEventHandler(this, Delegate.CreateDelegate(eiSetSelectedPanelType.EventHandlerType, this, "SetSelectedPanelType"));

                EventInfo eisetCommunicationType = tp.GetEvent("setCommunicationType");
                eisetCommunicationType.RemoveEventHandler(this, Delegate.CreateDelegate(eisetCommunicationType.EventHandlerType, this, "SetCommunication"));
                eisetCommunicationType.AddEventHandler(this, Delegate.CreateDelegate(eisetCommunicationType.EventHandlerType, this, "SetCommunication"));

                EventInfo eiGetUnitAddr = tp.GetEvent("getUnitAddr");
                eiGetUnitAddr.RemoveEventHandler(this, Delegate.CreateDelegate(eiGetUnitAddr.EventHandlerType, this, "GetUnitAddr"));
                eiGetUnitAddr.AddEventHandler(this, Delegate.CreateDelegate(eiGetUnitAddr.EventHandlerType, this, "GetUnitAddr"));

                EventInfo eigetModuleAddr = tp.GetEvent("getModuleAddr");
                eigetModuleAddr.RemoveEventHandler(this, Delegate.CreateDelegate(eigetModuleAddr.EventHandlerType, this, "GetModuleAddr"));
                eigetModuleAddr.AddEventHandler(this, Delegate.CreateDelegate(eigetModuleAddr.EventHandlerType, this, "GetModuleAddr"));

                EventInfo eiSetUnitAddr = tp.GetEvent("setUnitAddr");
                eiSetUnitAddr.RemoveEventHandler(this, Delegate.CreateDelegate(eiSetUnitAddr.EventHandlerType, this, "SetUnitAddr"));
                eiSetUnitAddr.AddEventHandler(this, Delegate.CreateDelegate(eiSetUnitAddr.EventHandlerType, this, "SetUnitAddr"));

                EventInfo eiGetSendDataTime = tp.GetEvent("getSendDataTime");
                eiGetSendDataTime.RemoveEventHandler(this, Delegate.CreateDelegate(eiGetSendDataTime.EventHandlerType, this, "GetSendDataTime"));
                eiGetSendDataTime.AddEventHandler(this, Delegate.CreateDelegate(eiGetSendDataTime.EventHandlerType, this, "GetSendDataTime"));

                EventInfo eiSetSendDataTime = tp.GetEvent("setSendDataTime");
                eiSetSendDataTime.RemoveEventHandler(this, Delegate.CreateDelegate(eiSetSendDataTime.EventHandlerType, this, "SetSendDataTime"));
                eiSetSendDataTime.AddEventHandler(this, Delegate.CreateDelegate(eiSetSendDataTime.EventHandlerType, this, "SetSendDataTime"));

                EventInfo eiGetReceiveDataTime = tp.GetEvent("getReceiveDataTime");
                eiGetReceiveDataTime.RemoveEventHandler(this, Delegate.CreateDelegate(eiGetReceiveDataTime.EventHandlerType, this, "GetReceiveDataTime"));
                eiGetReceiveDataTime.AddEventHandler(this, Delegate.CreateDelegate(eiGetReceiveDataTime.EventHandlerType, this, "GetReceiveDataTime"));

                EventInfo eiSetReceiveDataTime = tp.GetEvent("setReceiveDataTime");
                eiSetReceiveDataTime.RemoveEventHandler(this, Delegate.CreateDelegate(eiSetReceiveDataTime.EventHandlerType, this, "SetReceiveDataTime"));
                eiSetReceiveDataTime.AddEventHandler(this, Delegate.CreateDelegate(eiSetReceiveDataTime.EventHandlerType, this, "SetReceiveDataTime"));

                EventInfo eiGetShowDataPackage = tp.GetEvent("getShowDataPackage");
                eiGetShowDataPackage.RemoveEventHandler(this, Delegate.CreateDelegate(eiGetShowDataPackage.EventHandlerType, this, "GetShowDataPackage"));
                eiGetShowDataPackage.AddEventHandler(this, Delegate.CreateDelegate(eiGetShowDataPackage.EventHandlerType, this, "GetShowDataPackage"));

                EventInfo eiSetShowDataPackage = tp.GetEvent("setShowDataPackage");
                eiSetShowDataPackage.RemoveEventHandler(this, Delegate.CreateDelegate(eiSetShowDataPackage.EventHandlerType, this, "SetShowDataPackage"));
                eiSetShowDataPackage.AddEventHandler(this, Delegate.CreateDelegate(eiSetShowDataPackage.EventHandlerType, this, "SetShowDataPackage"));

                EventInfo eiGetPlayerType = tp.GetEvent("getPlayerType");
                eiGetPlayerType.RemoveEventHandler(this, Delegate.CreateDelegate(eiGetPlayerType.EventHandlerType, this, "GetPlayerType"));
                eiGetPlayerType.AddEventHandler(this, Delegate.CreateDelegate(eiGetPlayerType.EventHandlerType, this, "GetPlayerType"));

                EventInfo eiSetPlayerType = tp.GetEvent("setPlayerType");
                eiSetPlayerType.RemoveEventHandler(this, Delegate.CreateDelegate(eiSetPlayerType.EventHandlerType, this, "SetPlayerType"));
                eiSetPlayerType.AddEventHandler(this, Delegate.CreateDelegate(eiSetPlayerType.EventHandlerType, this, "SetPlayerType"));

                EventInfo eiGetOutputType = tp.GetEvent("getOutputType");
                eiGetOutputType.RemoveEventHandler(this, Delegate.CreateDelegate(eiGetOutputType.EventHandlerType, this, "GetOutputType"));
                eiGetOutputType.AddEventHandler(this, Delegate.CreateDelegate(eiGetOutputType.EventHandlerType, this, "GetOutputType"));

                EventInfo eiSetOutputType = tp.GetEvent("setOutputType");
                eiSetOutputType.RemoveEventHandler(this, Delegate.CreateDelegate(eiSetOutputType.EventHandlerType, this, "SetOutputType"));
                eiSetOutputType.AddEventHandler(this, Delegate.CreateDelegate(eiSetOutputType.EventHandlerType, this, "SetOutputType"));

                EventInfo eiGetStartCT = tp.GetEvent("GetStartCTHandler");
                eiGetStartCT.RemoveEventHandler(this, Delegate.CreateDelegate(eiGetStartCT.EventHandlerType, this, "GetStartCT"));
                eiGetStartCT.AddEventHandler(this, Delegate.CreateDelegate(eiGetStartCT.EventHandlerType, this, "GetStartCT"));

                EventInfo eiGetEndCT = tp.GetEvent("GetEndCTHandler");
                eiGetEndCT.RemoveEventHandler(this, Delegate.CreateDelegate(eiGetEndCT.EventHandlerType, this, "GetEndCT"));
                eiGetEndCT.AddEventHandler(this, Delegate.CreateDelegate(eiGetEndCT.EventHandlerType, this, "GetEndCT"));

                EventInfo eiGetIsEnginerMode = tp.GetEvent("GetIsEnginerModeHandler");
                eiGetIsEnginerMode.RemoveEventHandler(this, Delegate.CreateDelegate(eiGetIsEnginerMode.EventHandlerType, this, "GetIsEnginerMode"));
                eiGetIsEnginerMode.AddEventHandler(this, Delegate.CreateDelegate(eiGetIsEnginerMode.EventHandlerType, this, "GetIsEnginerMode"));

                EventInfo eiGetGroupAddr = tp.GetEvent("getGroupAddr");
                eiGetGroupAddr.RemoveEventHandler(this, Delegate.CreateDelegate(eiGetGroupAddr.EventHandlerType, this, "GetGroupAddr"));
                eiGetGroupAddr.AddEventHandler(this, Delegate.CreateDelegate(eiGetGroupAddr.EventHandlerType, this, "GetGroupAddr"));
            }
            else if (pm.Version == "2.0")
            {
                EventInfo eiMessage = tp.GetEvent("message");
                eiMessage.RemoveEventHandler(this, Delegate.CreateDelegate(eiMessage.EventHandlerType, this, "WriteMessage"));
                eiMessage.AddEventHandler(this, Delegate.CreateDelegate(eiMessage.EventHandlerType, this, "WriteMessage"));

                EventInfo eistatusMessage = tp.GetEvent("statusMessage");
                eistatusMessage.RemoveEventHandler(this, Delegate.CreateDelegate(eistatusMessage.EventHandlerType, this, "WriteStatusMessage"));
                eistatusMessage.AddEventHandler(this, Delegate.CreateDelegate(eistatusMessage.EventHandlerType, this, "WriteStatusMessage"));

                EventInfo eiClear = tp.GetEvent("clear");
                eiClear.RemoveEventHandler(this, Delegate.CreateDelegate(eiClear.EventHandlerType, this, "ClearMessage"));
                eiClear.AddEventHandler(this, Delegate.CreateDelegate(eiClear.EventHandlerType, this, "ClearMessage"));

                EventInfo eiPushData = tp.GetEvent("pushData");
                eiPushData.RemoveEventHandler(this, Delegate.CreateDelegate(eiPushData.EventHandlerType, this, "PushData"));
                eiPushData.AddEventHandler(this, Delegate.CreateDelegate(eiPushData.EventHandlerType, this, "PushData"));

                EventInfo eiPopupData = tp.GetEvent("popupData");
                eiPopupData.RemoveEventHandler(this, Delegate.CreateDelegate(eiPopupData.EventHandlerType, this, "PopupData"));
                eiPopupData.AddEventHandler(this, Delegate.CreateDelegate(eiPopupData.EventHandlerType, this, "PopupData"));

                EventInfo eiPrograss = tp.GetEvent("PrograssInfo");
                eiPrograss.RemoveEventHandler(this, Delegate.CreateDelegate(eiPrograss.EventHandlerType, this, "SetPrograss"));
                eiPrograss.AddEventHandler(this, Delegate.CreateDelegate(eiPrograss.EventHandlerType, this, "SetPrograss"));

                EventInfo eiPrograssMaxValue = tp.GetEvent("ProgressMaxValue");
                eiPrograssMaxValue.RemoveEventHandler(this, Delegate.CreateDelegate(eiPrograssMaxValue.EventHandlerType, this, "SetProgressMaxValue"));
                eiPrograssMaxValue.AddEventHandler(this, Delegate.CreateDelegate(eiPrograssMaxValue.EventHandlerType, this, "SetProgressMaxValue"));

                EventInfo resetProgressMaxValue = tp.GetEvent("resetProgressMaxValue");
                resetProgressMaxValue.RemoveEventHandler(this, Delegate.CreateDelegate(resetProgressMaxValue.EventHandlerType, this, "ResetProgressMaxValue"));
                resetProgressMaxValue.AddEventHandler(this, Delegate.CreateDelegate(resetProgressMaxValue.EventHandlerType, this, "ResetProgressMaxValue"));

                EventInfo getProgressValueValue = tp.GetEvent("getProgressValue");
                getProgressValueValue.RemoveEventHandler(this, Delegate.CreateDelegate(getProgressValueValue.EventHandlerType, this, "GetProgressValue"));
                getProgressValueValue.AddEventHandler(this, Delegate.CreateDelegate(getProgressValueValue.EventHandlerType, this, "GetProgressValue"));


                EventInfo eiGeteSelectedPanelType = tp.GetEvent("getSelectedPanelType");
                eiGeteSelectedPanelType.RemoveEventHandler(this, Delegate.CreateDelegate(eiGeteSelectedPanelType.EventHandlerType, this, "GetSelectedUnitTypeV2"));
                eiGeteSelectedPanelType.AddEventHandler(this, Delegate.CreateDelegate(eiGeteSelectedPanelType.EventHandlerType, this, "GetSelectedUnitTypeV2"));

                EventInfo eiGetCommunicationType = tp.GetEvent("getCommunicationType");
                eiGetCommunicationType.RemoveEventHandler(this, Delegate.CreateDelegate(eiGetCommunicationType.EventHandlerType, this, "GetCommunicationType"));
                eiGetCommunicationType.AddEventHandler(this, Delegate.CreateDelegate(eiGetCommunicationType.EventHandlerType, this, "GetCommunicationType"));

                EventInfo eiSetSelectedPanelType = tp.GetEvent("setSelectedPanelType");
                eiSetSelectedPanelType.RemoveEventHandler(this, Delegate.CreateDelegate(eiSetSelectedPanelType.EventHandlerType, this, "SetSelectedPanelType"));
                eiSetSelectedPanelType.AddEventHandler(this, Delegate.CreateDelegate(eiSetSelectedPanelType.EventHandlerType, this, "SetSelectedPanelType"));


                EventInfo eiGetUnitAddr = tp.GetEvent("getUnitAddr");
                eiGetUnitAddr.RemoveEventHandler(this, Delegate.CreateDelegate(eiGetUnitAddr.EventHandlerType, this, "GetUnitAddr"));
                eiGetUnitAddr.AddEventHandler(this, Delegate.CreateDelegate(eiGetUnitAddr.EventHandlerType, this, "GetUnitAddr"));


                EventInfo eigetModuleAddr = tp.GetEvent("getModuleAddr");
                eigetModuleAddr.RemoveEventHandler(this, Delegate.CreateDelegate(eigetModuleAddr.EventHandlerType, this, "GetModuleAddr"));
                eigetModuleAddr.AddEventHandler(this, Delegate.CreateDelegate(eigetModuleAddr.EventHandlerType, this, "GetModuleAddr"));

                EventInfo eiGetSendDataTime = tp.GetEvent("getSendDataTime");
                eiGetSendDataTime.RemoveEventHandler(this, Delegate.CreateDelegate(eiGetSendDataTime.EventHandlerType, this, "GetSendDataTime"));
                eiGetSendDataTime.AddEventHandler(this, Delegate.CreateDelegate(eiGetSendDataTime.EventHandlerType, this, "GetSendDataTime"));

                EventInfo eiGetReceiveDataTime = tp.GetEvent("getReceiveDataTime");
                eiGetReceiveDataTime.RemoveEventHandler(this, Delegate.CreateDelegate(eiGetReceiveDataTime.EventHandlerType, this, "GetReceiveDataTime"));
                eiGetReceiveDataTime.AddEventHandler(this, Delegate.CreateDelegate(eiGetReceiveDataTime.EventHandlerType, this, "GetReceiveDataTime"));

                EventInfo eiGetShowDataPackage = tp.GetEvent("getShowDataPackage");
                eiGetShowDataPackage.RemoveEventHandler(this, Delegate.CreateDelegate(eiGetShowDataPackage.EventHandlerType, this, "GetShowDataPackage"));
                eiGetShowDataPackage.AddEventHandler(this, Delegate.CreateDelegate(eiGetShowDataPackage.EventHandlerType, this, "GetShowDataPackage"));

                EventInfo eiSetShowDataPackage = tp.GetEvent("setShowDataPackage");
                eiSetShowDataPackage.RemoveEventHandler(this, Delegate.CreateDelegate(eiSetShowDataPackage.EventHandlerType, this, "SetShowDataPackage"));
                eiSetShowDataPackage.AddEventHandler(this, Delegate.CreateDelegate(eiSetShowDataPackage.EventHandlerType, this, "SetShowDataPackage"));

                PropertyInfo fdInfo = tp.GetProperty("Path");
                fdInfo.SetValue(pluginClass, System.IO.Path.GetDirectoryName(pm.LibPath), null);

                EventInfo eiotherInfo = tp.GetEvent("otherInfo");
                eiotherInfo.RemoveEventHandler(this, Delegate.CreateDelegate(eiotherInfo.EventHandlerType, this, "WriteOtherInfo"));
                eiotherInfo.AddEventHandler(this, Delegate.CreateDelegate(eiotherInfo.EventHandlerType, this, "WriteOtherInfo"));

                EventInfo eiShowSelectIPDialog = tp.GetEvent("_showSelectIPDialog");
                if (eiShowSelectIPDialog != null)
                {
                    eiShowSelectIPDialog.RemoveEventHandler(this, Delegate.CreateDelegate(eiShowSelectIPDialog.EventHandlerType, this, "ShowSelectIPDialog"));
                    eiShowSelectIPDialog.AddEventHandler(this, Delegate.CreateDelegate(eiShowSelectIPDialog.EventHandlerType, this, "ShowSelectIPDialog"));
                }

                EventInfo eishowUnitAddressDialog = tp.GetEvent("_showUnitAddressDialog");
                if (eishowUnitAddressDialog != null)
                {
                    eishowUnitAddressDialog.RemoveEventHandler(this, Delegate.CreateDelegate(eishowUnitAddressDialog.EventHandlerType, this, "ShowUnitAddressDialog"));
                    eishowUnitAddressDialog.AddEventHandler(this, Delegate.CreateDelegate(eishowUnitAddressDialog.EventHandlerType, this, "ShowUnitAddressDialog"));
                }

                EventInfo eishowModuleAddressDialog = tp.GetEvent("_showModuleAddressDialog");
                if (eishowModuleAddressDialog != null)
                {
                    eishowModuleAddressDialog.RemoveEventHandler(this, Delegate.CreateDelegate(eishowModuleAddressDialog.EventHandlerType, this, "ShowModuleAddressDialog"));
                    eishowModuleAddressDialog.AddEventHandler(this, Delegate.CreateDelegate(eishowModuleAddressDialog.EventHandlerType, this, "ShowModuleAddressDialog"));
                }

                if (pm.Options != null)
                {
                    foreach (OptionModel optModel in pm.Options)
                    {
                        ButtonItem optionButton = new ButtonItem(optModel.Text);
                        optionButton.Name = "BtnOption";
                        optionButton.Tag = optModel;
                        optionButton.Text = optModel.Text;
                        optionButton.Click += new EventHandler(delegate (object sender, EventArgs e)
                        {
                            OptionModel nowOptModel = (sender as ButtonItem).Tag as OptionModel;
                            Assembly assOption = Assembly.LoadFrom(pm.LibPath);
                            Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(pm.LibPath);
                            //BaseFormV2.Path = System.IO.Path.GetDirectoryName(pm.LibPath);
                            Plugin.Path = System.IO.Path.GetDirectoryName(pm.LibPath);
                            string pluginOptionClassName = nowOptModel.Namesapce + "." + nowOptModel.Name;
                            Type tpOption = assOption.GetType(pluginOptionClassName);
                            if (tpOption == null)
                            {
                                return;
                            }

                            //add_typename(null);

                            BaseFormV2 pluginOptionClass = Activator.CreateInstance(tpOption) as BaseFormV2;
                            pluginOptionClass.Path = System.IO.Path.GetDirectoryName(pm.LibPath);
                            pluginOptionClass.callBack += new BaseFormV2.CallBackFormOtherFormDelegate(
                            delegate (object arg)
                            {
                                (pluginClass as BaseFormV2).CallBack(arg);
                            });
                            pluginOptionClass.StartPosition = FormStartPosition.CenterParent;
                            pluginOptionClass.ShowDialog(this);
                        });
                    }
                }

                #region 方法

                MethodInfo method = tp.GetMethod("SetLanDic");
                if (method != null)
                {
                    method.Invoke(pluginClass, new object[] { m_lanDic, m_lanIndex, m_region, m_split });
                }

                method = tp.GetMethod("SetIsLoadLocalLan");
                if (method != null)
                {
                    bool isContains = m_pluginLoadLanGuid.Contains(pm.GUID);
                    method.Invoke(pluginClass, new object[] { isContains });
                    if (!isContains)
                    {
                        TextWriter writer = new StreamWriter(pluginLoadLanCfg, true);
                        writer.WriteLine(pm.GUID);
                        writer.Flush();
                        writer.Close();
                        m_pluginLoadLanGuid.Add(pm.GUID);
                    }
                }
                #endregion
            }
            #endregion


            pluginClass.TopLevel = false;
            pluginClass.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            pluginClass.Dock = DockStyle.Fill;
            pluginClass.Location = new Point(0, 0);
            pluginClass.FormBorderStyle = FormBorderStyle.None;
            pluginClass.Visible = true;
            panelContentContainer.Controls.Add(pluginClass);
            return pluginClass;

        }
        #endregion

        #region 回调事件

        //插件通过事件回调此方法，输出信息到文本控件
        public delegate void DelegateWriteMessage(string message);
        private void WriteMonitorDataMessage(string message)
        {
            try
            {
                //Form.CheckForIllegalCrossThreadCalls = false;
                richTextBox1.Text += message;
                this.richTextBox1.Select(this.richTextBox1.TextLength, 0);
                this.richTextBox1.ScrollToCaret();
            }
            catch { }
        }

        private void WriteMessage(string message)
        {
            try
            {
                lock (this)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new DelegateWriteMessage(WriteMonitorDataMessage), new object[] { message });
                    }
                    else
                    {
                        try
                        {
                            WriteMonitorDataMessage(message);
                        }
                        catch { }
                    }
                }
            }
            catch { }
        }


        private void WriteStatusMessage(string message)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new DelegateWriteMessage(WriteStatusMessage), new object[] { message });
                }
                else
                {
                    labelItem1.Text = message;
                }
            }
            catch { }
        }

        /// <summary>
        /// 写状态信息
        /// </summary>
        /// <param name="message"></param>
        private void WriteOtherInfo(string message)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new DelegateWriteMessage(WriteOtherInfo), new object[] { message });
                }
                else
                {
                    lblOtherInfo.Text = message;
                }
            }
            catch { }
        }

        //插件通过事件回调此方法，输出信息到文本控件
        public delegate void DelegateClearMessage();
        private void ClearMessage()
        {
            lock (this)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new DelegateClearMessage(ClearMessage));
                }
                else
                {
                    richTextBox1.Text = "";
                }
            }
        }


        //插件通过事件毁掉方法，将数据写入内存
        public delegate void DelegatePushDataHandler(object data);
        private void PushData(object data)
        {
            lock (this)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new DelegatePushDataHandler(PushData), new object[] { data });
                }
                else
                {
                    ShareDateQueue.Enqueue(data);
                }
            }
        }

        public delegate Queue PopupDataHandler();
        private Queue PopupData()
        {
            lock (this)
            {
                if (this.InvokeRequired)
                {
                    return this.Invoke(new PopupDataHandler(PopupData)) as Queue;
                }
                else
                {
                    return ShareDateQueue;
                }

            }
        }

        public delegate void SetPrograssHandler(String type, String message, int? percent);
        private void SetPrograss(String type, String message, int? percent)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new SetPrograssHandler(SetPrograss), new object[] { type, message, percent });
            }
            else
            {
                if (percent != null && percent >= 0 && percent <= 100)
                {
                    progressBarInfo.Value = (int)percent;
                }

                labelItem2.Text = type;
                lblProcess.Text = percent + "%".ToString();
            }
        }

        public delegate void SetProgressMaxValueHandler(int value);
        private void SetProgressMaxValue(int value)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new SetProgressMaxValueHandler(SetProgressMaxValue), new object[] { value });
            }
            else
            {
                progressBarInfo.Maximum = value;
            }
        }

        public delegate void ResetProgressMaxValueHandler();
        private void ResetProgressMaxValue()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ResetProgressMaxValueHandler(ResetProgressMaxValue));
            }
            else
            {
                progressBarInfo.Maximum = 100;
            }
        }

        public delegate int GetProgressValueHandler();
        private int GetProgressValue()
        {
            if (this.InvokeRequired)
            {
                return (int)this.Invoke(new GetProgressValueHandler(GetProgressValue));
            }
            else
            {
                return progressBarInfo.Value;
            }
        }

        private delegate UnitTypeV2 GetSelectedUnitTypeV2Handler();
        private UnitTypeV2 GetSelectedUnitTypeV2()
        {
            if (this.InvokeRequired)
            {
                return (UnitTypeV2)this.Invoke(new GetSelectedUnitTypeV2Handler(GetSelectedUnitTypeV2));
            }
            else
            {
                UnitTypeV2 unitType = default(UnitTypeV2);
                unitType.Bit = ck8bit.Checked ? 8 : 10;
                unitType.Serial = (cbSerial.SelectedItem as UnitSerialType).Name;
                unitType.MainName = cbMainType.SelectedIndex != -1 ? (cbMainType.SelectedItem as UnitMainType).Name : "";
                unitType.Title = cbMainType.SelectedIndex != -1 ? (cbMainType.SelectedItem as UnitMainType).Title : "";
                unitType.SubName = cbSubType.SelectedIndex != -1 ? (cbSubType.SelectedItem as UnitSubType).Name : "";
                unitType.ModuleWidth = cbSubType.SelectedIndex != -1 ? (cbSubType.SelectedItem as UnitSubType).UnitSizeH : 0;
                unitType.ModuleHeight = cbSubType.SelectedIndex != -1 ? (cbSubType.SelectedItem as UnitSubType).UnitSizeV : 0;
                unitType.ModulePixelWidth = cbSubType.SelectedIndex != -1 ? (cbSubType.SelectedItem as UnitSubType).BoardPixelH : 0;
                unitType.ModulePixelHeight = cbSubType.SelectedIndex != -1 ? (cbSubType.SelectedItem as UnitSubType).BoardPixelV : 0;
                return unitType;
            }
        }

        private delegate UnitType UnitTypeHandler();
        private UnitType GetSelectedUnitType()
        {

            if (this.InvokeRequired)
            {
                return (UnitType)this.Invoke(new UnitTypeHandler(GetSelectedUnitType));
            }
            else
            {
                UnitType unitType = default(UnitType);
                unitType.Bit = ck8bit.Checked ? 8 : 10;
                unitType.Serial = (cbMainType.SelectedItem as UnitMainType).Name;
                unitType.MainName = cbMainType.SelectedIndex != -1 ? (cbMainType.SelectedItem as UnitMainType).Name : "";
                unitType.Title = cbMainType.SelectedIndex != -1 ? (cbMainType.SelectedItem as UnitMainType).Title : "";
                unitType.SubName = cbSubType.SelectedIndex != -1 ? (cbSubType.SelectedItem as UnitSubType).Name : "";
                unitType.ModuleH = cbSubType.SelectedIndex != -1 ? (cbSubType.SelectedItem as UnitSubType).UnitSizeV : 0;
                unitType.ModuleV = cbSubType.SelectedIndex != -1 ? (cbSubType.SelectedItem as UnitSubType).UnitSizeH : 0;
                unitType.ModulePixelH = cbSubType.SelectedIndex != -1 ? (cbSubType.SelectedItem as UnitSubType).BoardPixelV : 0;
                unitType.ModulePixelV = cbSubType.SelectedIndex != -1 ? (cbSubType.SelectedItem as UnitSubType).BoardPixelH : 0;
                return unitType;
            }
        }

        private delegate CommunicationType GetCommunicationTypeHandler();
        private CommunicationType GetCommunicationType()
        {
            if (this.InvokeRequired)
            {
                return (CommunicationType)this.Invoke(new GetCommunicationTypeHandler(GetCommunicationType));
            }
            else
            {
                CommunicationType cbType = default(CommunicationType);
                cbType.CommunicationWay = cbControlMode.SelectedValue.ToString().ToInt32();
                cbType.COM = cbCom.Text;
                cbType.Baudrate = 115200;
                cbType.StartIPAddress = txtStartIpAddress.Text;
                cbType.EndIPAddress = txtEndIpAddress.Text;
                cbType.Localport = 0;
                try
                {
                    cbType.Localport = cbType.CommunicationWay == 0 ? Convert.ToInt32(cbCom.Text.ToUpper().Replace("COM", "")) : GlobalFun.GetAvaliablePort();
                }
                catch { }
                cbType.RemotePort = (int)numPort.Value;
                return cbType;
            }
        }

        private delegate Point GetUnitAddrHandler();
        private Point GetUnitAddr()
        {
            if (this.InvokeRequired)
            {
                return (Point)this.Invoke(new GetUnitAddrHandler(GetUnitAddr));
            }
            else
            {
                Point point = default(Point);
                point.X = (int)addr_X.Value;
                point.Y = (int)addr_Y.Value;
                return point;
            }
        }

        private delegate Point GetModuleAddrHandler();
        private Point GetModuleAddr()
        {
            if (this.InvokeRequired)
            {
                return (Point)this.Invoke(new GetModuleAddrHandler(GetModuleAddr));
            }
            else
            {
                Point point = default(Point);
                point.X = (int)numModuleX.Value;
                point.Y = (int)numModuleY.Value;
                return point;
            }
        }

        private delegate int GetSendDataTimeHandler();
        private int GetSendDataTime()
        {
            if (this.InvokeRequired)
            {
                return (int)this.Invoke(new GetSendDataTimeHandler(GetSendDataTime));
            }
            else
            {
                int time = 1;
                time = (int)time_S.Value;
                return time;
            }
        }

        private delegate int GetReceiveDataTimeHandler();
        private int GetReceiveDataTime()
        {
            if (this.InvokeRequired)
            {
                return (int)this.Invoke(new GetReceiveDataTimeHandler(GetReceiveDataTime));
            }
            else
            {
                int time = 1;
                time = (int)time_R.Value;
                return time;
            }

        }

        private delegate Boolean GetShowDataPackageHandler();
        private Boolean GetShowDataPackage()
        {
            if (this.InvokeRequired)
            {
                return (Boolean)this.Invoke(new GetShowDataPackageHandler(GetShowDataPackage));

            }
            else
            {
                return checkBoxX1.Checked;
            }
        }

        private delegate void SetShowDataPackageHandler(Boolean showDataPackage);
        private void SetShowDataPackage(Boolean showDataPackage)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new SetShowDataPackageHandler(SetShowDataPackage), new object[] { showDataPackage });
            }
            else
            {
                checkBoxX1.Checked = showDataPackage;
            }
        }

        private delegate void SetSelectedPanelTypeHandler(UnitType unitType);
        private void SetSelectedPanelType(UnitType unitType)
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new SetSelectedPanelTypeHandler(SetSelectedPanelType), new object[] { unitType });
            }
            else
            {
                if (unitType.MainName.IsWhiteOrEmpty()) return;
                cbMainType.Text = unitType.MainName;
                if (unitType.SubName.IsWhiteOrEmpty()) return;
                cbSubType.Text = unitType.SubName;
            }
        }

        private string ShowSelectIPDialog()
        {
            if (txtStartIpAddress.Text == txtEndIpAddress.Text) return txtStartIpAddress.Text;
            frmIPSelect frm = new frmIPSelect();
            frm.ShowInTaskbar = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.StartIP = txtStartIpAddress.Text;
            frm.EndIP = txtEndIpAddress.Text;
            frm.Clone(this.m_lanDic, "default", this.m_lanIndex);
            DialogResult dlg = frm.ShowDialog(this);
            if (dlg == DialogResult.Cancel) return string.Empty;
            return frm.SelectedIP;
        }

        DialogResult unitAddressDlgResult = DialogResult.Cancel;
        private DialogResult ShowUnitAddressDialog(string title, string tipMsg)
        {
            isResetThread = false;
            IList<Control> ctrs = new List<Control>
            {
                bar3,panelDockContainer3,panelContentContainer,dockSite2
            };
            if (!string.IsNullOrEmpty(title))
            {
                expandablePanel3_copy.TitleText = title;
            }
            else
            {
                expandablePanel3_copy.TitleText = LanguageHelper.FindInDic(m_lanDic, m_lanIndex, expandablePanel3_copy.TitleText, m_region);
            }
            if (!string.IsNullOrEmpty(tipMsg))
            {
                lblUnitAddressTips.Text = tipMsg;
            }
            expandablePanel3_copy.Visible = true;
            expandablePanel3_copy.BringToFront();
            expandablePanel3_copy.Location = new Point(-2, 339);
            EnableControl(false, ctrs);

            Size formSize = this.Size;

            Size panelSize = expandablePanel3_copy.Size;
            MoveCabinetPanel(expandablePanel3_copy);
            return unitAddressDlgResult;
        }

        DialogResult moduleAddressDlg = DialogResult.Cancel;
        private DialogResult ShowModuleAddressDialog(string title, string tipMsg)
        {
            isResetThread = false;
            IList<Control> ctrs = new List<Control>
            {
                bar3,panelDockContainer3,panelContentContainer,dockSite2
            };
            if (!string.IsNullOrEmpty(title))
            {
                expandModule_copy.TitleText = title;
            }
            if (!string.IsNullOrEmpty(tipMsg))
            {
                lblModuleAddr.Text = tipMsg;
            }
            expandModule_copy.Visible = true;
            expandModule_copy.BringToFront();
            expandModule_copy.Location = new Point(-1, 428);
            EnableControl(false, ctrs);

            MoveCabinetPanel(expandModule_copy);
            while (!isResetThread) { Thread.Sleep(200); Application.DoEvents(); }
            return moduleAddressDlg;
        }

        #endregion

        #region 设置箱体类型
        //分类
        private void add_typename(String[] selectedTypes)
        {
            UnitType uType = Plugin.GetSelectedPanelType();
            this.frmState = FormState.Loading;
            UnitTypeHelper unitTHelper = UnitTypeHelper.CreateInstance();

            {
                cbSerial.DisplayMember = "Title";
                cbSerial.ValueMember = "Name";
                cbSerial.DataSource = unitTHelper.GetAllSerialType();

                IList<UnitMainType> types = unitTHelper.GetAllMainType((cbSerial.SelectedItem as UnitSerialType).Name);

                cbMainType.DisplayMember = "Title";
                cbMainType.ValueMember = "Name";
                cbMainType.DataSource = types;
            }
            if (cbMainType.Items.Count > 0) cbMainType.SelectedIndex = 0;
            this.frmState = FormState.Complete;
            cbMainType.SelectedText = uType.MainName;
            cbSubType.SelectedText = uType.SubName;

            if (!string.IsNullOrEmpty(cbSubType.Text))
            {
                UnitTypeV2 subType = GetSelectedUnitTypeV2();
                numModuleY.Maximum = subType.ModuleHeight;
                numModuleX.Maximum = subType.ModuleWidth;
                numModuleY_copy.Maximum = subType.ModuleHeight;
                numModuleX_copy.Maximum = subType.ModuleWidth;
            }
        }

        private void add_subtypename(string serial, string name, int bit = 8)
        {
            UnitTypeHelper unitTHelper = UnitTypeHelper.CreateInstance();
            IList<UnitSubType> subTypes = unitTHelper.GetAllSubType(serial, name, bit);
            cbSubType.DisplayMember = "Title";
            cbSubType.ValueMember = "Name";
            cbSubType.DataSource = subTypes;
            if (cbSubType.Items.Count > 0) cbSubType.SelectedIndex = 0;
        }

        private void add_Maintypename(string serial)
        {
            UnitTypeHelper unitTHelper = UnitTypeHelper.CreateInstance();
            IList<UnitMainType> subTypes = unitTHelper.GetAllMainType((cbSerial.SelectedItem as UnitSerialType).Name);
            cbMainType.DisplayMember = "Title";
            cbMainType.ValueMember = "Name";
            cbMainType.DataSource = subTypes;
            if (cbMainType.Items.Count > 0) cbMainType.SelectedIndex = 0;
        }

        #endregion

        /// <summary>
        /// 初始化语言菜单
        /// </summary>
        void InitLanguageMenu()
        {
            IList<LanguageConfig> lanLists = LanguageLib.LanguageHelper.GetLanList(AppDomain.CurrentDomain.BaseDirectory + Constant.LanguageConfig);
            foreach (var lan in lanLists)
            {
                if (lan.IsUse)
                {
                    MenuLanguage.Text = lan.Text;
                    MenuLanguage.SubItems.Clear();
                    foreach (var subItem in lan.SubLanList)
                    {
                        ButtonItem btnMenuItem = new ButtonItem();
                        btnMenuItem.Text = subItem.Text;
                        btnMenuItem.Click += new EventHandler(btnMenuItem_Click);
                        btnMenuItem.Tag = subItem;
                        MenuLanguage.SubItems.Add(btnMenuItem);


                        if (lang == (btnMenuItem.Tag as LanguageConfig).Key.ToString())
                        {
                            btnMenuItem.Checked = true;
                        }
                    }
                    break;
                }
            }
            this.ChangeControlLang();
        }

        void btnMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(MultiLanguage.GetNames(this.Name, "restart"), "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            { return; }
            else
            {
                this.ChangeControlLang();
                isRestart = true;
                Application.Restart();
            }
            try
            {
                ButtonItem menuItem = sender as ButtonItem;
                LanguageLib.LanguageHelper.WriteDefaultLanguage(menuItem.Tag as LanguageConfig);
                this.lang = (menuItem.Tag as LanguageConfig).Key.ToString();
                IList<LanguageConfig> lanLists = LanguageLib.LanguageHelper.GetLanList(AppDomain.CurrentDomain.BaseDirectory + Constant.LanguageConfig);
                foreach (var lan in lanLists)
                {
                    if (lan.IsUse)
                    {
                        MenuLanguage.Text = lan.Text;
                        MenuLanguage.SubItems.Clear();
                        foreach (var subItem in lan.SubLanList)
                        {
                            ButtonItem btnMenuItem = new ButtonItem();
                            btnMenuItem.Text = subItem.Text;
                            btnMenuItem.Click += new EventHandler(btnMenuItem_Click);
                            btnMenuItem.Tag = subItem;
                            MenuLanguage.SubItems.Add(btnMenuItem);

                            if (lang == (btnMenuItem.Tag as LanguageConfig).Key.ToString())
                            {
                                btnMenuItem.Checked = true;
                            }
                        }
                        break;
                    }
                }

                this.ChangeControlLang();
            }
            catch (Exception ex)
            {

            }
        }

        //改变部分控件的显示文字信息
        private void ChangeControlLang()
        {
            IList<LanguageConfig> lanList = LanguageHelper.GetLanList(AppDomain.CurrentDomain.BaseDirectory + Constant.LanguageConfig);

            int lanLength = lanList.Count;

            m_lanDic = LanguageHelper.LoadLanDic(AppDomain.CurrentDomain.BaseDirectory + Constant.LanText, lanLength, out m_region, out m_split);

            foreach (var item in lanList)
            {
                if (lang == item.Key.ToString())
                {
                    m_lanIndex = item.ID;
                    break;
                }
            }

            //InitForm();
            LanguageLib.MultiLanguage.GetNames(this, lang, AppDomain.CurrentDomain.BaseDirectory + Constant.LanguageResourcePath);

            expandablePanel1.TitleText = MultiLanguage.GetNames(this.Name, "expandablePanel1");
            ckCommuSinglSave.Text = MultiLanguage.GetNames(this.Name, "ckCommuSinglSave");
            btbComDetect.Text = MultiLanguage.GetNames(this.Name, "btbComDetect");
            btnCommApply.Text = MultiLanguage.GetNames(this.Name, "btnCommApply");

            expandablePanel2.TitleText = MultiLanguage.GetNames(this.Name, "expandablePanel2");
            label4.Text = MultiLanguage.GetNames(this.Name, "label4");
            label5.Text = MultiLanguage.GetNames(this.Name, "label5");
            label6.Text = MultiLanguage.GetNames(this.Name, "label6");
            label9.Text = MultiLanguage.GetNames(this.Name, "label9");
            ckTypeSinglSave.Text = MultiLanguage.GetNames(this.Name, "ckTypeSinglSave");
            btnTypeApply.Text = MultiLanguage.GetNames(this.Name, "btnTypeApply");

            dockContainerItem2.Text = MultiLanguage.GetNames(this.Name, "dockContainerItem2");
            dockContainerItem5.Text = MultiLanguage.GetNames(this.Name, "dockContainerItem5");
            labelItem1.Text = MultiLanguage.GetNames(this.Name, "labelItem1");
            lblProcess.Text = MultiLanguage.GetNames(this.Name, "lblProcess");
            btnClear.Text = MultiLanguage.GetNames(this.Name, "btnClear");
            bar4.Text = MultiLanguage.GetNames(this.Name, "bar4");
            dockContainerItem4.Text = MultiLanguage.GetNames(this.Name, "dockContainerItem4");

            expandablePanel4.TitleText = MultiLanguage.GetNames(this.Name, "expandablePanel4");
            expandablePanel3.TitleText = MultiLanguage.GetNames(this.Name, "expandablePanel3");
            expandablePanel3_copy.TitleText = MultiLanguage.GetNames(this.Name, "expandablePanel3");
            expandablePanel3_copy.TitleText = LanguageHelper.FindInDic(m_lanDic, m_lanIndex, "选择箱体地址", m_region);
            btn_addr.Text = MultiLanguage.GetNames(this.Name, "btn_addr");
            label8.Text = MultiLanguage.GetNames(this.Name, "label8");
            label10.Text = MultiLanguage.GetNames(this.Name, "label10");
            btn_time.Text = MultiLanguage.GetNames(this.Name, "btn_time");
            label11.Text = MultiLanguage.GetNames(this.Name, "unitX");
            label11_copy.Text = MultiLanguage.GetNames(this.Name, "unitX");
            label12.Text = MultiLanguage.GetNames(this.Name, "unitY");
            label12_copy.Text = MultiLanguage.GetNames(this.Name, "unitY");
            checkBoxX1.Text = MultiLanguage.GetNames(this.Name, "checkBoxX1");
            dockContainerItem3.Text = MultiLanguage.GetNames(this.Name, "dockContainerItem3");
            buttonX2.Text = MultiLanguage.GetNames(this.Name, "buttonX2");
            buttonX3.Text = MultiLanguage.GetNames(this.Name, "buttonX3");
            buttonX2_copy.Text = MultiLanguage.GetNames(this.Name, "buttonX2");
            buttonX3_copy.Text = MultiLanguage.GetNames(this.Name, "buttonX3");

            lblControlMode.Text = MultiLanguage.GetNames(this.Name, "lblControlMode");
            lblrs232.Text = MultiLanguage.GetNames(this.Name, "lblrs232");
            lblPort.Text = MultiLanguage.GetNames(this.Name, "lblPort");
            btnRereshCom.Text = MultiLanguage.GetNames(this.Name, "buttonX4");

            label1.Text = LanguageHelper.FindInDic(m_lanDic, m_lanIndex, "起始IP", m_region);
            label15.Text = LanguageHelper.FindInDic(m_lanDic, m_lanIndex, "结束IP", m_region);
            label2.Text = LanguageHelper.FindInDic(m_lanDic, m_lanIndex, "箱体地址", m_region);

            lblUnitAddressTips.Text = LanguageHelper.FindInDic(m_lanDic, m_lanIndex, "提示：\r\n1.(255,255)表示调节网线连接的单个箱体\r\n2.(x,y)表示调节指定地址的单个箱体", m_region);
            lblModuleAddr.Text = LanguageHelper.FindInDic(m_lanDic, m_lanIndex, "提示：\r\n1.(x,y)表示调节指定地址的单个模块", m_region);
            btnOKUnitAddress.Text = LanguageHelper.FindInDic(m_lanDic, m_lanIndex, "确定", m_region);
            btnCancelUnitAddress.Text = LanguageHelper.FindInDic(m_lanDic, m_lanIndex, "取消", m_region);

            btnOkModuleAddress.Text = LanguageHelper.FindInDic(m_lanDic, m_lanIndex, "确定", m_region);
            btnModuleCancel.Text = LanguageHelper.FindInDic(m_lanDic, m_lanIndex, "取消", m_region);

            expandablePanel6.TitleText = MultiLanguage.GetNames(this.Name, "groupAddress");
            label19.Text = MultiLanguage.GetNames(this.Name, "unitX");
            label20.Text = MultiLanguage.GetNames(this.Name, "unitY");
            buttonX14.Text = MultiLanguage.GetNames(this.Name, "buttonX3");
            buttonX16.Text = MultiLanguage.GetNames(this.Name, "buttonX2");

            label21.Text = MultiLanguage.GetNames(this.Name, "serial");
        }

        /// <summary>
        /// 初始化管理员权限数据（拥有所有权限）
        /// </summary>
        /// <param name="menus"></param>
        void InitProductorPermissionData(IList<ArrayList> menus)
        {

        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            tabControl1.Tabs.Clear();
            currentPlugin = new Dictionary<string, Form>();

            Point addr = ConfigDataService.getUnitAddress();
            addr_X.Value = addr.X;
            addr_Y.Value = addr.Y;
            addr_X_copy.Value = addr.X == 0 ? 0 : addr.X;
            addr_Y_copy.Value = addr.Y == 0 ? 0 : addr.Y;

            addr = ConfigDataService.GetModuleAddress();
            numModuleX.Value = addr.X;
            numModuleY.Value = addr.Y;

            UnitCmdTime time = ConfigDataService.GetUnitTime();
            time_S.Value = time.Send < 1 ? 1 : time.Send;
            time_R.Value = time.Receive < 1 ? 1 : time.Receive;
            frmState = FormState.Complete;
            InitForm();
            this.Size = new Size(1152, 720);
            this.CenterToScreen();
            LoadPluginGuid();

            string tip1 = "";
            string tip2 = "";
            string author = "";
            string telphone = "";
            if (ConfigDataService.IsBetaVersion(out tip1, out tip2, out author, out telphone))
            {
                BetaVersionTipForm frm = new BetaVersionTipForm();
                frm.lblTip1.Text = tip1;
                frm.richTextTip.Text = tip2;
                frm.lblAuthor.Text = author;
                frm.lblTelphone.Text = telphone;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            PluginModel pm = (sender as ButtonItem).Tag as PluginModel;
            DialogResult dlg = DialogResult.OK;
            if (pm.Protected.Protected)
            {
                PlannerLoginForm loginForm = new PlannerLoginForm();
                loginForm.Level = 1;
                loginForm.Password = pm.Protected.Password;
                loginForm.IsUsePluginPassword = pm.Protected.Protected;
                loginForm.Clone(m_lanDic, m_region, m_lanIndex);
                loginForm.TopMost = true;
                loginForm.BringToFront();
                loginForm.StartPosition = FormStartPosition.CenterScreen;
                dlg = loginForm.ShowDialog();
                if (dlg == DialogResult.Cancel) return;
            }
            if (dlg == DialogResult.OK)
            {
                ChangeCabinateType(pm.CabinateType);
                if (pm.Init != null)
                {
                }

                if (!currentPlugin.ContainsKey(pm.GUID))
                {
                    Form pForm = OpenPlugin(pm);
                    currentPluginModel = pm;
                    if (pForm != null)//暂时不能退出当前界面
                    {
                        currentPlugin.Add(pm.GUID, pForm);

                        // 
                        // tabControlPanel1
                        // 
                        TabControlPanel tabPanel = new TabControlPanel();
                        tabPanel.AutoScroll = true;
                        tabPanel.Tag = pForm;
                        tabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                        tabPanel.Location = new System.Drawing.Point(0, 26);
                        tabPanel.Name = "tabPanel_" + pm.GUID;
                        tabPanel.Padding = new System.Windows.Forms.Padding(1);
                        tabPanel.Size = new System.Drawing.Size(482, 607);
                        tabPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
                        tabPanel.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
                        tabPanel.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
                        tabPanel.Style.GradientAngle = 90;
                        tabPanel.Controls.Add(pForm);

                        TabItem tabItem = new TabItem();
                        tabControl1.Tabs.Add(tabItem);
                        // 
                        // tabItem1
                        // 
                        tabItem.AttachedControl = tabPanel;
                        tabItem.Name = "tabItem_" + pm.GUID;
                        tabItem.Text = LanguageHelper.FindInDic(m_lanDic, m_lanIndex, pm.Text, m_region);
                        tabItem.Tag = pm;
                        tabPanel.TabItem = tabItem;
                        tabItem.CloseButtonVisible = true;
                        tabControl1.Controls.Add(tabPanel);
                        tabControl1.SelectedTab = tabItem;

                    }

                }
                else
                {
                    int itemIndex = 0;
                    for (int i = 0; i < tabControl1.Tabs.Count; i++)
                    {
                        if (tabControl1.Tabs[i].Name == "tabItem_" + pm.GUID)
                        {
                            itemIndex = i;
                            break;
                        }
                    }
                    tabControl1.SelectedTabIndex = itemIndex;
                }
            }
            else
            {
                MessageBox.Show(LanguageHelper.FindInDic(m_lanDic, m_lanIndex, "密码错误", m_region));
            }
        }

        private void btnCommApply_Click(object sender, EventArgs e)
        {
            CommunicationData cfgData = new CommunicationData();
            cfgData.Serialport = cbCom.Text;
            cfgData.Baudrate = "115200";
            cfgData.StartIP = txtStartIpAddress.Text;
            cfgData.EndIP = txtEndIpAddress.Text;
            cfgData.Localport = GlobalFun.GetAvaliablePort().ToString();
            cfgData.Remoteport = numPort.Value.ToString();
            cfgData.CommunicationType = cbControlMode.SelectedValue.ToString().ToInt32();

            ConfigDataService.SetCommunnicationData(cfgData);

            if (currentPlugin != null)
            {
                foreach (KeyValuePair<string, Form> item in currentPlugin)
                {
                    if (item.Value is BaseForm)
                    {
                        (item.Value as BaseForm).CommunicationTypeChanged();
                    }
                    else if (item.Value is BaseFormV2)
                    {
                        Type tp = item.Value.GetType().BaseType;
                        if (cbControlMode.SelectedValue.ToString().ToInt32() == 0)
                        {
                            //(item.Value as BaseFormV2).CommunicationToUseSerialPort(cbCom.Text, (int)numBaudrate.Value);
                            MethodInfo mth = tp.GetMethod("CommunicationToUseSerialPort", BindingFlags.NonPublic | BindingFlags.Instance);
                            mth.Invoke(item.Value, new object[] { cbCom.Text, 115200 });
                        }
                        else
                        {
                            //(item.Value as BaseFormV2).CommunicationToUseNetwork(txtIP.Text, GlobalFun.GetAvaliablePort(), (int)numPort.Value);
                            MethodInfo mth = tp.GetMethod("CommunicationToUseNetwork", BindingFlags.NonPublic | BindingFlags.Instance);
                            mth.Invoke(item.Value, new object[] { txtStartIpAddress.Text, txtEndIpAddress.Text, GlobalFun.GetAvaliablePort(), (int)numPort.Value });
                        }
                    }
                }
            }
        }

        private void btnTypeApply_Click(object sender, EventArgs e)
        {
            PanelTypeData typeData = new PanelTypeData();
            typeData.Serial = cbSerial.Text;
            typeData.MainType = cbMainType.Text;
            typeData.SubType = cbSubType.Text;
            typeData.ModalH = lblModalCount.Text.Split('×')[0].ToInt32();
            typeData.ModalV = lblModalCount.Text.Split('×')[1].ToInt32();
            typeData.ModalPixelH = lblModalPixel.Text.Split('×')[0].ToInt32();
            typeData.ModalPixelV = lblModalPixel.Text.Split('×')[1].ToInt32();
            ConfigDataService.SetPanelTypeData(typeData);

            if (currentPlugin != null)//暂时不能退出当前界面
            {
                foreach (KeyValuePair<string, Form> item in currentPlugin)
                {
                    if (item.Value is BaseForm)
                    {
                        (item.Value as BaseForm).PanelTypeChanged();
                    }
                    else if (item.Value is BaseFormV2)
                    {
                        Type tp = item.Value.GetType().BaseType;
                        MethodInfo mth = tp.GetMethod("UnitTypeChangeTo", BindingFlags.NonPublic | BindingFlags.Instance);
                        mth.Invoke(item.Value, new object[] { GetSelectedUnitTypeV2() });
                    }
                }
            }
        }

        private void cbMainType_SelectedIndexChanged(object sender, EventArgs e)
        {
            add_subtypename((cbMainType.SelectedItem as UnitMainType).Serial, (cbMainType.SelectedItem as UnitMainType).Name);
        }

        private void cbSubType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSubType.SelectedIndex == -1)
            {
                lblModalCount.Text = "";
                lblModalPixel.Text = "";
                return;
            }

            UnitSubType subType = cbSubType.SelectedItem as UnitSubType;
            lblModalCount.Text = subType.UnitSizeH + "×" + subType.UnitSizeV;
            lblModalPixel.Text = subType.BoardPixelH + "×" + subType.BoardPixelV;
            if (currentPlugin != null)//暂时不能退出当前界面
            {
                foreach (KeyValuePair<string, Form> item in currentPlugin)
                {
                    if (item.Value is BaseForm)
                    {
                        (item.Value as BaseForm).PanelTypeChanged();
                    }
                    else if (item.Value is BaseFormV2)
                    {
                        Type tp = item.Value.GetType().BaseType;
                        MethodInfo mth = tp.GetMethod("UnitTypeChangeTo", BindingFlags.NonPublic | BindingFlags.Instance);
                    }
                }
            }
            if (frmState == FormState.Complete)
            {
                numModuleY.Maximum = subType.UnitSizeV;
                numModuleX.Maximum = subType.UnitSizeH;
                numModuleY_copy.Maximum = subType.UnitSizeV;
                numModuleX_copy.Maximum = subType.UnitSizeH;
                btnTypeApply_Click(null, null);
            }
        }

        private void sideBarMenu_ExpandedChange(object sender, EventArgs e)
        {
            sideBarMenu.Controls.Clear();
            SideBarPanelItem panelItem = sender as SideBarPanelItem;


        }

        private void expandablePanel1_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void btbComDetect_Click(object sender, EventArgs e)
        {
            cbCom.SelectedIndexChanged -= cbCom_SelectedIndexChanged;
            cbCom.DataSource = GlobalFun.GetCommKeys();
            cbCom.SelectedIndexChanged += cbCom_SelectedIndexChanged;
        }
        private void btn_addr_Click(object sender, EventArgs e)
        {
            if (currentPlugin != null)//暂时不能退出当前界面
            {
                foreach (KeyValuePair<string, Form> item in currentPlugin)
                {
                    if (item.Value is BaseForm)
                    {
                        (item.Value as BaseForm).UnitAddrChanged((int)addr_X.Value, (int)addr_Y.Value);
                    }
                    else if (item.Value is BaseFormV2)
                    {
                        Type tp = item.Value.GetType().BaseType;
                        MethodInfo mth = tp.GetMethod("UnitAddressChangedTo", BindingFlags.NonPublic | BindingFlags.Instance);
                        mth.Invoke(item.Value, new object[] { (int)addr_X.Value, (int)addr_Y.Value });
                    }
                }
            }
            ConfigDataService.SetUnitAddress(new Point((int)addr_X.Value, (int)addr_Y.Value));
        }

        private void btn_time_Click(object sender, EventArgs e)
        {

            if (currentPlugin != null)//暂时不能退出当前界面
            {
                foreach (KeyValuePair<string, Form> item in currentPlugin)
                {
                    if (item.Value is BaseForm)
                    {
                        (item.Value as BaseForm).WaitTimeChanged((int)time_S.Value, (int)time_R.Value);
                    }
                    else if (item.Value is BaseFormV2)
                    {
                        Type tp = item.Value.GetType().BaseType;
                        MethodInfo mth = tp.GetMethod("CommandTimeChangedTo", BindingFlags.NonPublic | BindingFlags.Instance);
                        mth.Invoke(item.Value, new object[] { (int)time_S.Value, (int)time_R.Value });
                    }
                }
            }

            ConfigDataService.SetUnitTime((int)time_S.Value, (int)time_R.Value);
        }

        private void addr_X_ValueChanged(object sender, EventArgs e)
        {
            addr_X_copy.Value = 0;
            addr_Y_copy.Value = 0;
            if (frmState == FormState.Complete)
                btn_addr_Click(null, null);
        }

        private void time_S_ValueChanged(object sender, EventArgs e)
        {
            if (frmState == FormState.Complete)
                btn_time_Click(null, null);
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            if (currentPlugin != null)//暂时不能退出当前界面
            {
                foreach (KeyValuePair<string, Form> item in currentPlugin)
                {
                    if (item.Value is BaseForm)
                    {
                        (item.Value as BaseForm).ShowDataPackageChanged(checkBoxX1.Checked);
                    }
                    else if (item.Value is BaseFormV2)
                    {
                        Type tp = item.Value.GetType().BaseType;
                        MethodInfo mth = tp.GetMethod("IsShowDataPackageChangedTo", BindingFlags.NonPublic | BindingFlags.Instance);
                        mth.Invoke(item.Value, new object[] { checkBoxX1.Checked });
                    }
                }
            }
            ConfigDataService.SetShowDataPackage(checkBoxX1.Checked);
        }

        public class ComboBoxList
        {
            public string Text { get; set; }
            public object Value { get; set; }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            addr_X.Value = 0;
            addr_Y.Value = 0;
            addr_X_copy.Value = 0;
            addr_Y_copy.Value = 0;
            if (frmState == FormState.Complete)
                btn_addr_Click(null, null);
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            addr_X.Value = 255;
            addr_Y.Value = 255;
        }

        private void tabControl1_TabItemClose(object sender, TabStripActionEventArgs e)
        {
            Form frm = currentPlugin[tabControl1.SelectedTab.Name.Replace("tabItem_", "")];
            if (frm is BaseForm)
            {
                if ((frm as BaseForm).CloseForm() == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }
            else if (frm is BaseFormV2)
            {
                Type tp = frm.GetType().BaseType;
                MethodInfo mth = tp.GetMethod("FormClose", BindingFlags.NonPublic | BindingFlags.Instance);
                DialogResult dlgResult = (DialogResult)mth.Invoke(frm, new object[] { });
                if (dlgResult == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            (currentPlugin[tabControl1.SelectedTab.Name.Replace("tabItem_", "")] as Form).Close();
            currentPlugin.Remove(tabControl1.SelectedTab.Name.Replace("tabItem_", ""));
            tabControl1.Tabs.RemoveAt(tabControl1.SelectedTabIndex);
        }

        private void tabControl1_SelectedTabChanged(object sender, TabStripTabChangedEventArgs e)
        {
            if (e.NewTab != null && e.NewTab.Tag != null && e.NewTab.Tag is PluginModel)
            {
                PluginModel pm = e.NewTab.Tag as PluginModel;
                ChangeCabinateType(pm.CabinateType);
                if (pm.Init != null)
                {

                }

                Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(pm.LibPath);
                Plugin.Path = System.IO.Path.GetDirectoryName(pm.LibPath);
                if (e.NewTab.AttachedControl.Tag != null)
                {
                    Form form = e.NewTab.AttachedControl.Tag as Form;
                    if (form is BaseForm)
                    {
                        (form as BaseForm).ReActived();
                    }
                    else
                    {
                        //(form as BaseFormV2).ReActived();
                        Type tp = form.GetType().BaseType;
                        MethodInfo mth = tp.GetMethod("ReActived", BindingFlags.NonPublic | BindingFlags.Instance);
                        mth.Invoke(form, new object[] { });

                        PropertyInfo fdInfo = tp.GetProperty("Path");
                        fdInfo.SetValue(form, System.IO.Path.GetDirectoryName(pm.LibPath), null);

                        if (pm.Options != null)
                        {
                            foreach (OptionModel optModel in pm.Options)
                            {
                                ButtonItem optionButton = new ButtonItem(optModel.Text);
                                optionButton.Name = "BtnOption";
                                optionButton.Tag = optModel;
                                optionButton.Text = optModel.Text;
                                optionButton.Click += new EventHandler(delegate (object sender1, EventArgs ea)
                                {
                                    OptionModel nowOptModel = (sender1 as ButtonItem).Tag as OptionModel;
                                    Assembly assOption = Assembly.LoadFrom(pm.LibPath);
                                    Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(pm.LibPath);
                                    Plugin.Path = System.IO.Path.GetDirectoryName(pm.LibPath);
                                    string pluginOptionClassName = nowOptModel.Namesapce + "." + nowOptModel.Name;
                                    Type tpOption = assOption.GetType(pluginOptionClassName);
                                    if (tpOption == null)
                                    {
                                        return;
                                    }

                                    BaseFormV2 pluginOptionClass = Activator.CreateInstance(tpOption) as BaseFormV2;
                                    pluginOptionClass.Path = System.IO.Path.GetDirectoryName(pm.LibPath);
                                    pluginOptionClass.callBack += new BaseFormV2.CallBackFormOtherFormDelegate(
                                    delegate (object arg)
                                    {
                                        (form as BaseFormV2).CallBack(arg);
                                    });
                                    pluginOptionClass.StartPosition = FormStartPosition.CenterParent;
                                    pluginOptionClass.ShowDialog(this);
                                });
                            }
                        }
                    }
                }
            }
        }

        private void txtIP_ButtonCustomClick(object sender, EventArgs e)
        {
            using (Process cmd = new Process())
            {
                cmd.StartInfo.FileName = "ping";
                cmd.StartInfo.Arguments = txtPingIp.Text + " -t";
                cmd.StartInfo.UseShellExecute = false;
                cmd.StartInfo.RedirectStandardOutput = false;
                cmd.Start();
            }
        }

        private void buttonX6_MouseEnter(object sender, EventArgs e)
        {
            balloonTip1.SetBalloonText(buttonX6, MultiLanguage.GetNames(this.Name, "unitAddrTips"));
            balloonTip1.ShowBalloon(buttonX6);
        }

        private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (parentForm != null)
            {
                parentForm.Close();
            }
            Application.Exit();
        }

        private void StartForm_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            if (parentForm != null)
            {
                parentForm.Close();
            }
            Application.Exit();
        }

        private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isRestart)
            {
                DialogResult dlg = MessageBoxEx.Show(MultiLanguage.GetNames(this.Name, "quit"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (dlg == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            if (currentPlugin != null)
            {
                foreach (KeyValuePair<string, Form> item in currentPlugin)
                {
                    if (item.Value is BaseForm)
                    {
                        if ((item.Value as BaseForm).CloseForm() == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                    else if (item.Value is BaseFormV2)
                    {
                        Type tp = item.Value.GetType().BaseType;
                        MethodInfo mth = tp.GetMethod("FormClose", BindingFlags.NonPublic | BindingFlags.Instance);
                        DialogResult dlgResult = (DialogResult)mth.Invoke(item.Value, new object[] { });
                        if (dlgResult == DialogResult.No)
                        {
                            MessageBoxEx.Show(MultiLanguage.GetNames(this.Name, "commandRunning"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            e.Cancel = true;
                            return;
                        }
                    }
                }
            }
        }
        private void cbControlMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbControlMode.SelectedValue == null) return;
            if (cbControlMode.SelectedValue.ToString().ToInt32() == 0)
            {
                cbCom.Enabled = btnRereshCom.Enabled = true;
                txtStartIpAddress.Enabled = txtEndIpAddress.Enabled = txtPingIp.Enabled = numPort.Enabled = buttonX7.Enabled = false;
                if (currentPlugin != null)//暂时不能退出当前界面
                {
                    foreach (KeyValuePair<string, Form> item in currentPlugin)
                    {
                        if (item.Value is BaseForm)
                        {
                            (item.Value as BaseForm).CommunicationTypeChanged();
                        }
                        else if (item.Value is BaseFormV2)
                        {
                            Type tp = item.Value.GetType().BaseType;
                            MethodInfo mth = tp.GetMethod("CommunicationToUseSerialPort", BindingFlags.NonPublic | BindingFlags.Instance);
                            if (mth != null)
                            {
                                mth.Invoke(item.Value, new object[] { cbCom.Text, 115200 });
                            }
                        }
                    }
                }
            }
            else if (cbControlMode.SelectedValue.ToString().ToInt32() == 1)
            {
                cbCom.Enabled = btnRereshCom.Enabled = false;
                txtStartIpAddress.Enabled = txtEndIpAddress.Enabled = txtPingIp.Enabled = numPort.Enabled = buttonX7.Enabled = true;
                if (currentPlugin != null)//暂时不能退出当前界面
                {
                    foreach (KeyValuePair<string, Form> item in currentPlugin)
                    {
                        if (item.Value is BaseForm)
                        {
                            (item.Value as BaseForm).CommunicationTypeChanged();
                        }
                        else if (item.Value is BaseFormV2)
                        {
                            Type tp = item.Value.GetType().BaseType;
                            MethodInfo mth = tp.GetMethod("CommunicationToUseNetwork", BindingFlags.NonPublic | BindingFlags.Instance);
                            if (mth != null)
                            {
                                mth.Invoke(item.Value, new object[] { txtStartIpAddress.Text, txtEndIpAddress.Text, GlobalFun.GetAvaliablePort(), (int)numPort.Value });
                            }
                        }
                    }
                }
            }
            if (frmState == FormState.Complete)
                btnCommApply_Click(null, null);
        }

        private void btnRereshCom_Click(object sender, EventArgs e)
        {
            if (txtStartIpAddress.Text == "255.255.255.255")
            {

                PluginManagerForm pluginManagerForm = new PluginManagerForm();
                pluginManagerForm.StartPosition = FormStartPosition.CenterParent;
                pluginManagerForm.ShowDialog(this);
                InitOptMenu();

                return;
            }
            cbCom.SelectedIndexChanged -= cbCom_SelectedIndexChanged;
            cbCom.DataSource = GlobalFun.GetCommKeys();
            cbCom.SelectedIndexChanged += cbCom_SelectedIndexChanged;
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            using (Process cmd = new Process())
            {
                cmd.StartInfo.FileName = "ping";
                cmd.StartInfo.Arguments = txtPingIp.Text + " -t";
                cmd.StartInfo.UseShellExecute = false;
                cmd.StartInfo.RedirectStandardOutput = false;
                cmd.Start();
            }
        }

        private void txtStartIpAddress_Leave(object sender, EventArgs e)
        {
            TextBoxX text = sender as TextBoxX;
            text.Text = text.Text.TrimAllWhiteSpace();
            try
            {
                //验证合法性
                NetworkValidate networkValid = new NetworkValidate();
                IPAddress ipAddr = null;
                if (!networkValid.ValidateIPAddress(text.Text.TrimAllWhiteSpace()))
                {
                    balloonTip1.SetBalloonText(text, LanguageHelper.FindInDic(m_lanDic, m_lanIndex, "IP地址格式错误", m_region));
                    balloonTip1.ShowBalloon(text);
                    text.Focus();
                    return;
                }

                if (text.Name == "txtEndIpAddress")
                {
                    if (!networkValid.IsSameNetwork(txtStartIpAddress.Text, txtEndIpAddress.Text))
                    {
                        balloonTip1.SetBalloonText(text, LanguageHelper.FindInDic(m_lanDic, m_lanIndex, "起始IP和结束IP必须在同一地址段", m_region));
                        balloonTip1.ShowBalloon(text);
                        text.Focus();
                        text.Focus();
                        return;
                    }
                }
            }
            finally
            {

            }
            btnCommApply_Click(sender, e);
        }

        private void txtEndIpAddress_Leave(object sender, EventArgs e)
        {
            TextBoxX text = sender as TextBoxX;
            text.Text = text.Text.TrimAllWhiteSpace();
            try
            {
                //验证合法性
                NetworkValidate networkValid = new NetworkValidate();
                IPAddress ipAddr = null;
                if (!networkValid.ValidateIPAddress(text.Text.TrimAllWhiteSpace()))
                {
                    balloonTip1.SetBalloonText(text, LanguageHelper.FindInDic(m_lanDic, m_lanIndex, "IP地址格式错误", m_region));
                    balloonTip1.ShowBalloon(text);
                    text.Focus();
                    return;
                }

                if (text.Name == "txtEndIpAddress")
                {
                    if (!networkValid.IsSameNetwork(txtStartIpAddress.Text, txtEndIpAddress.Text))
                    {
                        balloonTip1.SetBalloonText(text, LanguageHelper.FindInDic(m_lanDic, m_lanIndex, "起始IP和结束IP必须在同一地址段", m_region));
                        balloonTip1.ShowBalloon(text);
                        text.Focus();
                        return;
                    }
                }
            }
            finally
            {

            }
            btnCommApply_Click(sender, e);
        }

        private void txtStartIpAddress_TextChanged(object sender, EventArgs e)
        {
            txtEndIpAddress.Text = txtStartIpAddress.Text;
            txtPingIp.Text = txtStartIpAddress.Text;
            TextBoxX text = sender as TextBoxX;
            try
            {
                //验证合法性
                NetworkValidate networkValid = new NetworkValidate();
                IPAddress ipAddr = null;
                if (!networkValid.ValidateIPAddress(text.Text.TrimAllWhiteSpace()))
                {
                    balloonTip1.SetBalloonText(text, LanguageHelper.FindInDic(m_lanDic, m_lanIndex, "IP地址格式错误", m_region));
                    balloonTip1.ShowBalloon(text);
                    //text.Focus();
                    return;
                }
                else
                {
                    balloonTip1.SetBalloonText(text, "");
                    balloonTip1.CloseBalloon();
                    balloonTip1.RemoveAll();
                }

                if (text.Name == "txtEndIpAddress")
                {
                    if (!networkValid.IsSameNetwork(txtStartIpAddress.Text, txtEndIpAddress.Text))
                    {
                        balloonTip1.SetBalloonText(text, LanguageHelper.FindInDic(m_lanDic, m_lanIndex, "起始IP和结束IP必须在同一地址段", m_region));
                        balloonTip1.ShowBalloon(text);
                        text.Focus();
                        return;
                    }
                }
                else
                {
                    balloonTip1.SetBalloonText(text, "");
                    balloonTip1.CloseBalloon();
                    balloonTip1.RemoveAll();
                }
            }
            finally
            {

            }

            btnCommApply_Click(sender, e);
        }

        void SetModuleAddr()
        {
            if (currentPlugin != null)//暂时不能退出当前界面
            {
                foreach (KeyValuePair<string, Form> item in currentPlugin)
                {
                    if (item.Value is BaseForm)
                    {
                        //(item.Value as BaseForm).UnitAddrChanged((int)addr_X.Value, (int)addr_Y.Value);
                    }
                    else if (item.Value is BaseFormV2)
                    {
                        Type tp = item.Value.GetType().BaseType;
                        MethodInfo mth = tp.GetMethod("ModuleAddressChangedTo", BindingFlags.NonPublic | BindingFlags.Instance);
                        mth.Invoke(item.Value, new object[] { (int)numModuleX.Value, (int)numModuleY.Value });
                    }
                }
            }
            ConfigDataService.SetModuleAddress(new Point((int)numModuleX.Value, (int)numModuleY.Value));
        }

        private void numModuleX_ValueChanged(object sender, EventArgs e)
        {
            numModuleX_copy.Value = numModuleX.Value == 0 ? 1 : numModuleX.Value;
            SetModuleAddr();
        }

        private void numModuleY_ValueChanged(object sender, EventArgs e)
        {
            numModuleY_copy.Value = numModuleY.Value == 0 ? 1 : numModuleY.Value;
            SetModuleAddr();
        }

        private void btnAllModule_Click(object sender, EventArgs e)
        {
            numModuleX.ValueChanged -= numModuleX_ValueChanged;
            numModuleY.ValueChanged -= numModuleY_ValueChanged;

            numModuleX.Value = numModuleY.Value = 0;
            numModuleX_copy.Value = numModuleY_copy.Value = 1;

            numModuleX.ValueChanged += numModuleX_ValueChanged;
            numModuleY.ValueChanged += numModuleY_ValueChanged;
            SetModuleAddr();
        }

        private void numPort_ValueChanged(object sender, EventArgs e)
        {
            cbControlMode_SelectedIndexChanged(sender, e);
        }

        private void txtEndIpAddress_TextChanged(object sender, EventArgs e)
        {

            TextBoxX text = sender as TextBoxX;
            try
            {
                //验证合法性
                NetworkValidate networkValid = new NetworkValidate();
                IPAddress ipAddr = null;
                if (!networkValid.ValidateIPAddress(text.Text.TrimAllWhiteSpace()))
                {
                    balloonTip1.SetBalloonText(text, LanguageHelper.FindInDic(m_lanDic, m_lanIndex, "IP地址格式错误", m_region));
                    balloonTip1.ShowBalloon(text);
                    //text.Focus();
                    return;
                }
                else
                {
                    balloonTip1.SetBalloonText(text, "");
                    balloonTip1.CloseBalloon();
                    balloonTip1.RemoveAll();
                }

                if (text.Name == "txtEndIpAddress")
                {
                    if (!networkValid.IsSameNetwork(txtStartIpAddress.Text, txtEndIpAddress.Text))
                    {
                        balloonTip1.SetBalloonText(text, LanguageHelper.FindInDic(m_lanDic, m_lanIndex, "起始IP和结束IP必须在同一地址段", m_region));
                        balloonTip1.ShowBalloon(text);
                        balloonTip1.RemoveAll();
                        text.Focus();
                        return;
                    }
                }
                else
                {
                    balloonTip1.SetBalloonText(text, "");
                    balloonTip1.CloseBalloon();
                }
            }
            finally
            {

            }

            btnCommApply_Click(sender, e);
        }

        private void cbCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCommApply_Click(sender, e);
        }

        void MoveCabinetPanel(Control ctr)
        {
            Size formSize = this.Size;
            Point leftTopPoint = new Point(formSize.Width / 2 - ctr.Width / 2, formSize.Height / 2 - ctr.Height / 2);
            ctr.Location = leftTopPoint;
        }

        void EnableControl(bool enable, IList<Control> ctrs)
        {
            foreach (Control ctr in ctrs)
            {
                ctr.Enabled = enable;
            }
        }

        private void btnCloseCabinetAddressPanel_Click(object sender, EventArgs e)
        {
            unitAddressDlgResult = DialogResult.Cancel;

            addr_X_copy.Value = 0;
            addr_Y_copy.Value = 0;
            IList<Control> ctrs = new List<Control>
            {
                bar3,panelDockContainer3,panelContentContainer,dockSite2
            };;
            MoveCabinetPanel(expandablePanel3_copy);
            EnableControl(true, ctrs);
            expandablePanel3_copy.Visible = false;
            isResetThread = true;

        }

        private void btnAllModule_copy_Click(object sender, EventArgs e)
        {
            numModuleX.ValueChanged -= numModuleX_ValueChanged;
            numModuleY.ValueChanged -= numModuleY_ValueChanged;

            numModuleX.Value = numModuleY.Value = 0;
            numModuleX_copy.Value = numModuleY_copy.Value = 1;

            numModuleX.ValueChanged += numModuleX_ValueChanged;
            numModuleY.ValueChanged += numModuleY_ValueChanged;
            SetModuleAddr();
        }


        private void buttonX9_Click(object sender, EventArgs e)
        {
            numModuleX_copy.Value = 0;
            numModuleY_copy.Value = 0;
            IList<Control> ctrs = new List<Control>
            {
                bar3,panelDockContainer3,panelContentContainer,dockSite2
            };
            MoveCabinetPanel(expandModule_copy);
            EnableControl(true, ctrs);
            expandModule_copy.Visible = false;
            isResetThread = true;
            moduleAddressDlg = DialogResult.Cancel;
        }

        private void txtStartIpAddress_ButtonCustomClick(object sender, EventArgs e)
        {
            Ping(txtStartIpAddress.Text);
        }

        void Ping(String ip)
        {
            using (Process cmd = new Process())
            {
                cmd.StartInfo.FileName = "ping";
                cmd.StartInfo.Arguments = ip + " -t";
                cmd.StartInfo.UseShellExecute = false;
                cmd.StartInfo.RedirectStandardOutput = false;
                cmd.Start();
            }
        }

        private void txtEndIpAddress_ButtonCustomClick(object sender, EventArgs e)
        {
            Ping(txtEndIpAddress.Text);
        }

        private void checkBoxX2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxX ck = sender as CheckBoxX;
            //if (ck.Checked)
            //{
            //    add_subtypename(cbMainType.Text, 8);
            //}
            if (ck.Checked)
            {
                cbSubType_SelectedIndexChanged(sender, e);
                ConfigDataService.SetBit(8);
            }
        }

        private void checkBoxX3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxX ck = sender as CheckBoxX;
            //if (ck.Checked)
            //{
            //    add_subtypename(cbMainType.Text, 10);
            //}
            if (ck.Checked)
            {
                cbSubType_SelectedIndexChanged(sender, e);
                ConfigDataService.SetBit(10);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            unitAddressDlgResult = DialogResult.OK;

            addr_X.ValueChanged -= addr_X_ValueChanged;
            addr_Y.ValueChanged -= addr_X_ValueChanged;
            addr_X.Value = addr_X_copy.Value;
            addr_Y.Value = addr_Y_copy.Value;
            addr_X.ValueChanged += addr_X_ValueChanged;
            addr_Y.ValueChanged += addr_X_ValueChanged;
            if (frmState == FormState.Complete)
                btn_addr_Click(null, null);

            IList<Control> ctrs = new List<Control>
            {
                bar3,panelDockContainer3,panelContentContainer,dockSite2
            };
            MoveCabinetPanel(expandablePanel3_copy);
            EnableControl(true, ctrs);
            expandablePanel3_copy.Visible = false;
            isResetThread = true;
        }

        private void btnCancelUnitAddress_Click(object sender, EventArgs e)
        {
            unitAddressDlgResult = DialogResult.Cancel;
            addr_X_copy.Value = 0;
            addr_Y_copy.Value = 0;
            IList<Control> ctrs = new List<Control>
            {
                bar3,panelDockContainer3,panelContentContainer,dockSite2
            };

            MoveCabinetPanel(expandablePanel3_copy);
            EnableControl(true, ctrs);
            expandablePanel3_copy.Visible = false;
            isResetThread = true;
        }

        private void btnOkModuleAddress_Click(object sender, EventArgs e)
        {
            numModuleX.ValueChanged -= numModuleX_ValueChanged;
            numModuleX.Value = numModuleX_copy.Value;
            numModuleX.ValueChanged += numModuleX_ValueChanged;

            numModuleY.ValueChanged -= numModuleY_ValueChanged;
            numModuleY.Value = numModuleY_copy.Value;
            numModuleY.ValueChanged += numModuleY_ValueChanged;
            SetModuleAddr();

            IList<Control> ctrs = new List<Control>
            {
                bar3,panelDockContainer3,panelContentContainer,dockSite2
            };

            MoveCabinetPanel(expandModule_copy);
            EnableControl(true, ctrs);
            expandModule_copy.Visible = false;
            isResetThread = true;
            moduleAddressDlg = DialogResult.OK;
        }

        private void btnModuleCancel_Click(object sender, EventArgs e)
        {
            numModuleX_copy.Value = 0;
            numModuleY_copy.Value = 0;
            IList<Control> ctrs = new List<Control>
            {
                bar3,panelDockContainer3,panelContentContainer,dockSite2
            };
            MoveCabinetPanel(expandModule_copy);
            EnableControl(true, ctrs);
            expandModule_copy.Visible = false;
            isResetThread = true;
            moduleAddressDlg = DialogResult.Cancel;
        }

        private void buttonX3_copy_Click(object sender, EventArgs e)
        {
            addr_X_copy.Value = 255;
            addr_Y_copy.Value = 255;
        }

        private void cbSerial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSerial.SelectedItem == null) return;
            add_Maintypename((cbSerial.SelectedItem as UnitSerialType).Name);
        }
    }
}
