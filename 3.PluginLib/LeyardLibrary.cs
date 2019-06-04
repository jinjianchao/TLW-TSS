using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace PluginLib
{
    public abstract class LeyardLibrary
    {
      

        private int _type = 0;
        /// <summary>
        /// 通讯类型，默认值为0
        /// </summary>
        public int Type { set { _type = value; } }

        private int _localPort = 1;
        /// <summary>
        /// 本地端口（串口通讯时为串口, 网络通讯时为本地端口）
        /// </summary>
        public int LocalPort
        {
            set { _localPort = value; }
        }

        private int _remotePort = 8001;
        /// <summary>
        /// 
        /// </summary>
        public int RemotePort
        {
            set { _remotePort = value; }
        }

        private StringBuilder _Ip = new StringBuilder("192.168.0.32");
        /// <summary>
        /// IP，默认值为new StringBuilder("192.168.0.32")
        /// </summary>
        public StringBuilder IP
        {
            set { _Ip = value; }
        }

        private int _baudRate = 115200;
        /// <summary>
        /// 波特率，默认值为115200
        /// </summary>
        public int BaudRate { set { _baudRate = value; } }
        private ArrayList nport;
        public ArrayList NporList
        {
            set { nport = value; }
        }
        public int type = 0;
      
        public abstract void MonitorON(IntPtr hwnd, UInt32 msg);
        
    }
}
