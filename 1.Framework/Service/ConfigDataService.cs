using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;
using PluginLib;
using LYDTOPDP.Extention;

namespace LydTOPDP.Service
{
    class CommunicationData
    {
        public int CommunicationType { get; set; }
        public string StartIP { get; set; }
        public string EndIP { get; set; }
        public string Localport { get; set; }
        public string Remoteport { get; set; }
        public string Serialport { get; set; }
        public string Baudrate { get; set; }
    }

    class PanelTypeData
    {
        public string Serial { get; set; }
        public string MainType { get; set; }
        public String SubType { get; set; }
        public int ModalH { get; set; }
        public int ModalV { get; set; }
        public int ModalPixelH { get; set; }
        public int ModalPixelV { get; set; }
    }

    class PreSelectPlugin
    {
        public String MainFunName { get; set; }
        public string SubFunName { get; set; }
    }

    class UnitCmdTime
    {
        public int Send { get; set; }
        public int Receive { get; set; }
    }

    class ConfigDataService
    {
        static string ConfigXML = AppDomain.CurrentDomain.BaseDirectory + @"ConfigData\Config.xml";

        public static CommunicationData GetCommunicationData()
        {
            CommunicationData cfgData = new CommunicationData();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigXML);
            cfgData.StartIP = xmlDoc.SelectSingleNode("config/system/communication/network/ip").InnerText;
            cfgData.EndIP = xmlDoc.SelectSingleNode("config/system/communication/network/endip").InnerText;
            cfgData.Localport = xmlDoc.SelectSingleNode("config/system/communication/network/localport").InnerText;
            cfgData.Remoteport = xmlDoc.SelectSingleNode("config/system/communication/network/remoteport").InnerText;
            cfgData.Serialport = xmlDoc.SelectSingleNode("config/system/communication/serialport/port").InnerText;
            cfgData.Baudrate = xmlDoc.SelectSingleNode("config/system/communication/serialport/baudrate").InnerText;
            try
            {
                cfgData.CommunicationType = int.Parse(xmlDoc.SelectSingleNode("config/system/communication").Attributes["type"].Value);
            }
            catch { }
            xmlDoc = null;
            return cfgData;
        }

        public static void SetCommunnicationData(CommunicationData cfgData)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigXML);
            xmlDoc.SelectSingleNode("config/system/communication/network/ip").InnerText = cfgData.StartIP;
            xmlDoc.SelectSingleNode("config/system/communication/network/endip").InnerText = cfgData.EndIP;
            xmlDoc.SelectSingleNode("config/system/communication/network/localport").InnerText = cfgData.Localport;
            xmlDoc.SelectSingleNode("config/system/communication/network/remoteport").InnerText = cfgData.Remoteport;
            xmlDoc.SelectSingleNode("config/system/communication/serialport/port").InnerText = cfgData.Serialport;
            xmlDoc.SelectSingleNode("config/system/communication/serialport/baudrate").InnerText = cfgData.Baudrate;
            xmlDoc.SelectSingleNode("config/system/communication").Attributes["type"].Value = cfgData.CommunicationType.ToString();
            xmlDoc.Save(ConfigXML);
            xmlDoc = null;
        }


        public static CommunicationData GetCommunicationData(String guid)
        {
            CommunicationData cfgData = new CommunicationData();

            String pluginNodeStr = $"config/plugins/plugin[@guid='{guid}']";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigXML);

            cfgData.StartIP = xmlDoc.SelectSingleNode("config/system/communication/network/ip").InnerText;
            cfgData.EndIP = xmlDoc.SelectSingleNode("config/system/communication/network/endip").InnerText;
            cfgData.Localport = xmlDoc.SelectSingleNode("config/system/communication/network/localport").InnerText;
            cfgData.Remoteport = xmlDoc.SelectSingleNode("config/system/communication/network/remoteport").InnerText;
            cfgData.Serialport = xmlDoc.SelectSingleNode("config/system/communication/serialport/port").InnerText;
            cfgData.Baudrate = xmlDoc.SelectSingleNode("config/system/communication/serialport/baudrate").InnerText;
            try
            {
                cfgData.CommunicationType = int.Parse(xmlDoc.SelectSingleNode("config/system/communication").Attributes["type"].Value);
            }
            catch { }
            xmlDoc = null;
            return cfgData;
        }

        public static void SetPanelTypeData(PanelTypeData panelTypeData)
        {
            PanelTypeData cfgData = panelTypeData;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigXML);
            xmlDoc.SelectSingleNode("config/system/paneltype/serial").InnerText = cfgData.Serial;
            xmlDoc.SelectSingleNode("config/system/paneltype/main").InnerText = cfgData.MainType;
            xmlDoc.SelectSingleNode("config/system/paneltype/sub").InnerText = cfgData.SubType;
            xmlDoc.SelectSingleNode("config/system/paneltype/modal/h").InnerText = cfgData.ModalH.ToString();
            xmlDoc.SelectSingleNode("config/system/paneltype/modal/v").InnerText = cfgData.ModalV.ToString();
            xmlDoc.SelectSingleNode("config/system/paneltype/modalpixel/h").InnerText = cfgData.ModalPixelH.ToString();
            xmlDoc.SelectSingleNode("config/system/paneltype/modalpixel/v").InnerText = cfgData.ModalPixelV.ToString();

            xmlDoc.Save(ConfigXML);
            xmlDoc = null;
        }

        public static PanelTypeData GetPanelTypeData()
        {
            PanelTypeData cfgData = new PanelTypeData();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigXML);
            cfgData.Serial = xmlDoc.SelectSingleNode("config/system/paneltype/serial").InnerText;
            cfgData.MainType = xmlDoc.SelectSingleNode("config/system/paneltype/main").InnerText;
            cfgData.SubType = xmlDoc.SelectSingleNode("config/system/paneltype/sub").InnerText;
            cfgData.ModalH = xmlDoc.SelectSingleNode("config/system/paneltype/modal/h").InnerText.ToInt32();
            cfgData.ModalV = xmlDoc.SelectSingleNode("config/system/paneltype/modal/v").InnerText.ToInt32();
            cfgData.ModalPixelH = xmlDoc.SelectSingleNode("config/system/paneltype/modalpixel/h").InnerText.ToInt32();
            cfgData.ModalPixelV = xmlDoc.SelectSingleNode("config/system/paneltype/modalpixel/v").InnerText.ToInt32();
            xmlDoc = null;
            return cfgData;
        }

        public static void SetPreSelectedPlugin(PreSelectPlugin pluginInfo)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigXML);

            XmlNode node = xmlDoc.SelectSingleNode("config/system/preplugin");
            if (node != null)
            {
                node.Attributes["funname"].Value = pluginInfo.MainFunName;
                node.Attributes["subfunguid"].Value = pluginInfo.SubFunName;
            }
            xmlDoc.Save(ConfigXML);
            xmlDoc = null;
        }

        public static PreSelectPlugin GetPreSelectedPlugin()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigXML);
            PreSelectPlugin pluginInfo = new PreSelectPlugin();
            XmlNode node = xmlDoc.SelectSingleNode("config/system/preplugin");
            if (node != null)
            {
                pluginInfo.MainFunName = node.Attributes["funname"].Value;
                pluginInfo.SubFunName = node.Attributes["subfunguid"].Value;
            }
            xmlDoc.Save(ConfigXML);
            xmlDoc = null;
            return pluginInfo;
        }

        public static void SetUnitAddress(Point addr)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigXML);
            xmlDoc.SelectSingleNode("config/system/unitAddr").Attributes["x"].Value = addr.X.ToString();
            xmlDoc.SelectSingleNode("config/system/unitAddr").Attributes["y"].Value = addr.Y.ToString();
            xmlDoc.Save(ConfigXML);
            xmlDoc = null;
        }

        public static void SetModuleAddress(Point addr)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigXML);
            xmlDoc.SelectSingleNode("config/system/moduleAddr").Attributes["x"].Value = addr.X.ToString();
            xmlDoc.SelectSingleNode("config/system/moduleAddr").Attributes["y"].Value = addr.Y.ToString();
            xmlDoc.Save(ConfigXML);
            xmlDoc = null;
        }
        public static Point GetModuleAddress()
        {
            Point addr = new Point();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigXML);
            addr.X = xmlDoc.SelectSingleNode("config/system/moduleAddr").Attributes["x"].Value.ToInt32();
            addr.Y = xmlDoc.SelectSingleNode("config/system/moduleAddr").Attributes["y"].Value.ToInt32();
            xmlDoc = null;
            return addr;
        }

        public static Point getUnitAddress()
        {
            Point addr = new Point();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigXML);
            addr.X = xmlDoc.SelectSingleNode("config/system/unitAddr").Attributes["x"].Value.ToInt32();
            addr.Y = xmlDoc.SelectSingleNode("config/system/unitAddr").Attributes["y"].Value.ToInt32();
            xmlDoc = null;
            return addr;
        }

        public static void SetUnitTime(int send, int receive)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigXML);
            xmlDoc.SelectSingleNode("config/system/unitTime").Attributes["send"].Value = send.ToString();
            xmlDoc.SelectSingleNode("config/system/unitTime").Attributes["receive"].Value = receive.ToString();
            xmlDoc.Save(ConfigXML);
            xmlDoc = null;
        }

        public static UnitCmdTime GetUnitTime()
        {
            UnitCmdTime time = new UnitCmdTime();
            Point addr = new Point();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigXML);
            string send = xmlDoc.SelectSingleNode("config/system/unitTime").Attributes["send"].Value;
            string recive = xmlDoc.SelectSingleNode("config/system/unitTime").Attributes["receive"].Value;
            xmlDoc = null;
            time.Send = send.IsInt32() ? send.ToInt32() : 300;
            time.Receive = recive.IsInt32() ? recive.ToInt32() : 300;
            return time;
        }

        public static void SetShowDataPackage(bool isShow)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigXML);
            xmlDoc.SelectSingleNode("config/system/showDataPackage").Attributes["value"].Value = isShow.ToString();
            xmlDoc.Save(ConfigXML);
            xmlDoc = null;
        }

        public static bool getShowDataPackage()
        {
            Point addr = new Point();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigXML);
            bool isShow = xmlDoc.SelectSingleNode("config/system/showDataPackage").Attributes["value"].Value.IsBoolean() ? xmlDoc.SelectSingleNode("config/system/showDataPackage").Attributes["value"].Value.ToBoolean() : false;
            xmlDoc = null;
            return isShow;
        }

        public static void SetBit(int bit)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigXML);
            xmlDoc.SelectSingleNode("config/system/bit").Attributes["value"].Value = bit.ToString();
            xmlDoc.Save(ConfigXML);
            xmlDoc = null;
        }

        public static int GetBit()
        {
            int bit = 10;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigXML);
            bit = xmlDoc.SelectSingleNode("config/system/bit").Attributes["value"].Value.ToInt32();
            xmlDoc = null;
            return bit;

        }


        public static bool IsBetaVersion(out string text1, out string text2, out string author, out string telphone)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigXML);
            XmlNode betaVerNode = xmlDoc.SelectSingleNode("config/system/BetaVersion");
            if (betaVerNode == null)
            {
                text1 = "";
                text2 = "";
                author = "";
                telphone = "";
                return false;
            }
            bool visible = bool.Parse(betaVerNode.Attributes["visible"].Value);
            text1 = betaVerNode.Attributes["text1"].Value;
            text2 = betaVerNode.Attributes["text2"].Value;
            author = betaVerNode.Attributes["author"].Value;
            telphone = betaVerNode.Attributes["telphone"].Value;
            xmlDoc = null;
            return visible;

        }
    }
}
