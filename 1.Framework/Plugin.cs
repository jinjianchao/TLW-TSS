using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace LydTOPDP
{
    public class Plugin
    {
        #region 插件必备，请勿乱动
        

        #region 消息处理事件定义
        public delegate void WriteMessageHandler(string messag);
        public static event WriteMessageHandler message;

        public delegate void ClearMessageHandler();
        public static event ClearMessageHandler clear;

        public delegate void PushDataHandler(object data);
        public static event PushDataHandler pushData;

        public delegate Queue PopupDataHandler();
        public static event PopupDataHandler popupData;
        #endregion

        #region 如果使用串口通讯则加入此代码
        public static string COM;
        public static string Baudrate;
        public static void SetSerialPort(string com, string baudRate)
        {
            COM = com;
            Baudrate = baudRate;
        }
        #endregion

        #region 如果使用网络通讯方式则加入此代码
        public static string IP;
        public static string Localport;
        public static string Remoteport;
        public static void SetNetwork(string ip, string localport, string remoteport)
        {
            IP = ip;
            Localport = localport;
            Remoteport = remoteport;
        }
        #endregion

        public static void Write(string msg)
        {
            if (message != null)
            {
                message(msg);
            }
        }

        public static void WriteLine(string msg)
        {
            Write(msg + "\r\n");
        }

        public static void Clear()
        {
            if (clear != null)
            {
                clear();
            }
        }

        public static void PushData(object data)
        {
            if (pushData != null)
            {
                pushData(data);
            }
        }

        public static object[] PopupData()
        {
            return null;
        }

        public static String Path
        {
            get
            {
                return Environment.CurrentDirectory;
            }
        }
        #endregion

        //内容由插件开发者修改
        public static Hashtable GetPluginsItems()
        {
            //每个DLL可以提供多个插件（多个功能）
            //请指定每一个插件的窗口名称和标题信息,并添加到Hashtable中
            //以下为示例代码
            Hashtable hs = new Hashtable();
            hs.Add("Form1", "测试窗体1");
            hs.Add("Form2", "测试窗体2");
            hs.Add("Form3", "测试窗体3");
            return hs;
        }
    }
}
