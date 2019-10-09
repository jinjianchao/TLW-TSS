using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;

namespace PluginLib
{
    #region 附加结构信息
    #region 箱体类型
    [Obsolete("请使用UnitTypeV2，此类存在BUG，将不再被支持")]
    public struct UnitType
    {
        public String Title { get; set; }

        public string Serial { get; set; }

        public String MainName { get; set; }
        public String SubName { get; set; }
        /// <summary>
        /// 模块行
        /// </summary>
        public int ModuleH { get; set; }
        /// <summary>
        /// 模块列
        /// </summary>
        public int ModuleV { get; set; }
        /// <summary>
        /// 模块像素行
        /// </summary>
        public int ModulePixelH { get; set; }
        /// <summary>
        /// 模块像素列
        /// </summary>
        public int ModulePixelV { get; set; }

        public int Bit { get; set; }
    }

    public enum HalfUnitType
    {
        Normal = 0,
        Half2_2 = 1,
        Half3_2 = 2
    }

    public class HalfUnit
    {
        /// <summary>
        /// 模块宽
        /// </summary>
        public int ModuleWidth { get; set; }
        /// <summary>
        /// 模块高
        /// </summary>
        public int ModuleHeight { get; set; }
        /// <summary>
        /// 模块像素宽
        /// </summary>
        public int ModulePixelWidth { get; set; }
        /// <summary>
        /// 模块像素高
        /// </summary>
        public int ModulePixelHeight { get; set; }

        /// <summary>
        /// 箱体类型，0：标准箱体，1:2*2,2:3*2
        /// </summary>
        public HalfUnitType HalfUnitType { get; set; }

        public Size GetSize()
        {
            Size s = new Size();
            s.Width = ModuleWidth * ModulePixelWidth;
            s.Height = ModuleHeight * ModulePixelHeight;
            return s;
        }
    }

    public struct UnitTypeV2
    {
        public String Title { get; set; }

        public string Serial { get; set; }

        public String MainName { get; set; }
        public String SubName { get; set; }
        /// <summary>
        /// 模块宽
        /// </summary>
        public int ModuleWidth { get; set; }
        /// <summary>
        /// 模块高
        /// </summary>
        public int ModuleHeight { get; set; }
        /// <summary>
        /// 模块像素宽
        /// </summary>
        public int ModulePixelWidth { get; set; }
        /// <summary>
        /// 模块像素高
        /// </summary>
        public int ModulePixelHeight { get; set; }

        public int Bit { get; set; }

        public Size GetSize()
        {
            Size s = new Size();
            s.Width = ModuleWidth * ModulePixelWidth;
            s.Height = ModuleHeight * ModulePixelHeight;
            return s;
        }

        /// <summary>
        /// 箱体类型，0：标准箱体，1:2*2,2:3*2
        /// </summary>
        public HalfUnitType HalfUnitType { get; set; }

        public HalfUnit HalfUnit { get; set; }

        /// <summary>
        /// 每个连接板连接的灯板数量
        /// </summary>
        public int ConnectModuleCount { get; set; }
    }

    public struct CommunicationType
    {
        public int CommunicationWay { get; set; }
        public String COM { get; set; }
        public int Baudrate { get; set; }
        public int Localport { get; set; }
        public int RemotePort { get; set; }
        public String IPAddress { get; set; }

        public string StartIPAddress { get; set; }

        public string EndIPAddress { get; set; }
    }

    #endregion
    #endregion

    /// <summary>
    /// 插件父类，插件必须继承此类
    /// </summary>
    public class Plugin
    {
        #region 插件必备，请勿乱动
        static Assembly _ass = null;//当前加载的程序集信息

        /// <summary>
        /// 设置当前加载的程序集
        /// </summary>
        /// <param name="ass"></param>
        public static void SetAssembly(Assembly ass)
        {
            _ass = ass;
        }

        /// <summary>
        /// 加载程序集所引用程序集信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private static Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly MyAssembly;
            try
            {
                string strTempAssmbPath = "";

                AssemblyName[] arrReferencedAssmbNames = _ass.GetReferencedAssemblies();//得到当前程序集所引用的外部程序集信息

                //循环所引用的外部程序集信息
                foreach (AssemblyName strAssmbName in arrReferencedAssmbNames)
                {
                    if (strAssmbName.FullName.Substring(0, strAssmbName.FullName.IndexOf(",")) == args.Name.Substring(0, args.Name.IndexOf(",")))
                    {
                        strTempAssmbPath = Path + @"\" + args.Name.Substring(0, args.Name.IndexOf(",")) + ".dll";
                        break;
                    }
                }
                if (!string.IsNullOrEmpty(strTempAssmbPath))
                    MyAssembly = Assembly.LoadFrom(strTempAssmbPath);
                else
                    MyAssembly = null;
            }
            catch (Exception ex)
            {

                throw new Exception("插件错误:" + ex.Message);
            }
            return MyAssembly;
        }

        #region 消息处理事件定义

        #region 输出消息事件
        public delegate void WriteMessageHandler(string messag);
        public static event WriteMessageHandler message;
        public static object obj = new object();
        /// <summary>
        /// 输出信息到输出窗口
        /// </summary>
        /// <param name="msg"></param>
        public static void Write(string msg)
        {
            if (message != null)
            {
                StreamWriter writer = new StreamWriter("c:\\log.txt", true);
                lock (obj)
                {
                    try
                    {
                        writer.WriteLine("Start:" + msg);
                        message(msg);
                        writer.WriteLine("End");
                    }
                    catch (Exception ex)
                    {
                        writer.WriteLine(ex.InnerException);
                    }
                    finally
                    {
                        writer.Flush();
                        writer.Close();
                    }
                }
            }
        }
        /// <summary>
        /// 输出消息到输出窗口，并带回车换行
        /// </summary>
        /// <param name="msg"></param>
        public static void WriteLine(string msg)
        {
            DateTime dt = DateTime.Now;
            string strmsg = string.Empty;
            if (!string.IsNullOrEmpty(msg))
            {
                strmsg = dt.ToLongTimeString() + " " + dt.Millisecond.ToString() + "ms" + "\r\n" + msg + "\r\n";
                Write(strmsg);
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

        /// <summary>
        /// 得到进图条信息
        /// </summary>
        /// <returns></returns>
        public static int GetProgressValue()
        {
            if (getProgressValue != null)
            {
                return getProgressValue();
            }
            return -1;
        }

        public static void ResetProgressMaxValue()
        {
            if (resetProgressMaxValue != null)
            {
                resetProgressMaxValue();
            }
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
        public delegate UnitType GetSelectedPanelTypeHandler();
        public static event GetSelectedPanelTypeHandler getSelectedPanelType;
        public static UnitType GetSelectedPanelType()
        {
            UnitType unitType = default(UnitType);
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

        #region 工程师模式
        public delegate bool IsEnginerModeDelegate();
        public static event IsEnginerModeDelegate GetIsEnginerModeHandler;
        public static bool GetIsEnginerMode()
        {
            bool isEnginnerMode = false;
            if (GetIsEnginerModeHandler != null)
            {
                isEnginnerMode = GetIsEnginerModeHandler();
            }
            return isEnginnerMode;
        }
        #endregion

        #endregion



        /// <summary>
        /// 当前动态库所在路径（不包含最后一个斜杠）
        /// </summary>
        [Obsolete("此属性不在被支持，并且存在BUG，建议使用BaseFormV2.Path")]
        public static String Path
        {
            //get
            //{
            //    return Environment.CurrentDirectory;
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


        /// <summary>
        /// 更当前程序与注册加载程序集信息失败事件
        /// </summary>
        /// <param name="CurrentDomain"></param>
        public static void InitLib(AppDomain CurrentDomain)
        {
            CurrentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);
        }
        #endregion

        /// <summary>
        /// 插件排序
        /// </summary>
        /// <returns></returns>
        public virtual SortedList GetPluginsItems()
        {
            return null;
        }
        ///// <summary>
        ///// 获取tv的版本号
        ///// </summary>
        ///// <returns>TVPalyer1.0，TVPalyer2.0</returns>
        //public static string GetTVPlayerVersion()
        //{
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(BasePath + "ConfigData\\TVPlayerSet.xml");
        //    return doc.SelectSingleNode("//interfaces/item[@value='true']").Attributes["text"].Value;
        //}

    }



}
