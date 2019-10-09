using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml;
using System.Collections;

namespace UnitInfo
{
    [Obsolete("已过时，请使用UnitTypeHelperV2进行操作")]
    public class UnitTypeHelper
    {
        static IList<UnitMainType> _unitType = new List<UnitMainType>();
        static IList<UnitSerialType> _unitSerialType = new List<UnitSerialType>();
        static UnitTypeHelper helper = null;

        private static string _xmlPath = AppDomain.CurrentDomain.BaseDirectory + @"\UnitInfo.xml";

        private UnitTypeHelper() { }

        public static UnitTypeHelper CreateInstance()
        {
            //if (helper == null)
            //{
            _unitType = new List<UnitMainType>();
            helper = new UnitTypeHelper();

            UnitMainType unitType = null;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_xmlPath);
            XmlNodeList unitNodeList = xmlDoc.SelectNodes("units/unit");
            if (unitNodeList != null)
            {
                foreach (XmlNode unitItem in unitNodeList)
                {
                    unitType = new UnitMainType();
                    unitType.Name = unitItem.Attributes["name"].Value;
                    unitType.Title = unitItem.Attributes["title"].Value;
                    unitType.Id = byte.Parse(unitItem.Attributes["id"].Value);
                    unitType.Serial = unitItem.Attributes["serial"].Value;

                    UnitSubType subType = null;
                    XmlNodeList subNodeList = unitItem.SelectNodes("subType/item");
                    foreach (XmlNode subTypeItem in subNodeList)
                    {
                        subType = new UnitSubType();
                        subType.Name = subTypeItem.Attributes["name"].Value;
                        subType.Title = subTypeItem.Attributes["title"].Value;
                        subType.Id = byte.Parse(subTypeItem.Attributes["id"].Value);

                        subType.UnitSizeH = int.Parse(subTypeItem.Attributes["modalXCount"].Value);
                        subType.UnitSizeV = int.Parse(subTypeItem.Attributes["modalYCount"].Value);

                        subType.BoardPixelH = int.Parse(subTypeItem.Attributes["modalXPixelCount"].Value);
                        subType.BoardPixelV = int.Parse(subTypeItem.Attributes["modalYPixelCount"].Value);

                        if (subTypeItem.Attributes["mCount"] != null)
                        {
                            subType.ConnectModuleCount = int.Parse(subTypeItem.Attributes["mCount"].Value);
                        }

                        unitType.SubType.Add(subType);
                    }
                    if (unitType.SubType.Count > 0)
                    {
                        _unitType.Add(unitType);
                    }
                    //}
                }
            }

            XmlNodeList unitSerialNodeList = xmlDoc.SelectNodes("units/serial/item");
            if (unitSerialNodeList != null)
            {
                foreach (XmlNode item in unitSerialNodeList)
                {
                    UnitSerialType serialItem = new UnitSerialType();
                    serialItem.Name = item.Attributes["name"].Value;
                    serialItem.Title = item.Attributes["title"].Value;
                    _unitSerialType.Add(serialItem);
                }
            }
            return helper;
        }

        public IList<UnitSerialType> GetAllSerialType()
        {
            return _unitSerialType;
        }

        public IList<UnitMainType> GetAllMainType(string serial)
        {
            IList<UnitMainType> list = new List<UnitMainType>();
            foreach (var item in _unitType)
            {
                if (item.Serial == serial) list.Add(item);
            }
            return list;
        }
        public UnitMainType GetMainType(string serial, string mainName)
        {
            UnitMainType resultType = null;
            if (_unitType != null)
            {
                foreach (UnitMainType item in _unitType)
                {
                    if (item.Name == mainName && item.Serial == serial)
                    {
                        resultType = item;
                        break;
                    }
                }
            }
            return resultType;
        }

        public IList<UnitSubType> GetAllSubType(string serial, string mainName, int bit = 8)
        {
            IList<UnitSubType> resultSubType = new List<UnitSubType>();
            if (_unitType != null)
            {
                foreach (UnitMainType mainItem in _unitType)
                {
                    if (mainItem.Name == mainName && mainItem.Serial == serial)
                    {
                        //resultSubType = mainItem.SubType;
                        IList<UnitSubType> subList = mainItem.SubType;
                        foreach (UnitSubType sub in subList)
                        {
                            if (sub.Bit == bit)
                            {
                                resultSubType.Add(sub);
                            }
                        }
                        break;
                    }
                }
            }
            return resultSubType;
        }

        public UnitSubType GetSubType(string mainName, string subName)
        {
            UnitSubType resultSubType = null;
            if (_unitType != null)
            {
                foreach (UnitMainType mainItem in _unitType)
                {
                    if (mainItem.Name == mainName)
                    {
                        foreach (UnitSubType subItem in mainItem.SubType)
                        {
                            if (subItem.Name == subName)
                            {
                                resultSubType = subItem;
                                break;
                            }
                        }
                    }
                }
            }
            return resultSubType;
        }

        public void AddCustomizeType(UnitSubType subType)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_xmlPath);
            XmlNode unitNode = xmlDoc.SelectSingleNode("units/unit[@name='Customize']");
            if (unitNode != null)
            {
                XmlNode subTypeNode = unitNode.SelectSingleNode("subType");
                if (subTypeNode != null)
                {
                    XmlNode newNode = xmlDoc.CreateNode(XmlNodeType.Element, "item", "");
                    XmlAttribute attID = xmlDoc.CreateAttribute("id");
                    attID.Value = "1000";

                    XmlAttribute attName = xmlDoc.CreateAttribute("name");
                    attName.Value = subType.Name;

                    XmlAttribute attTitle = xmlDoc.CreateAttribute("title");
                    attTitle.Value = subType.Title;
                    XmlAttribute attmodalXCount = xmlDoc.CreateAttribute("modalXCount");
                    attmodalXCount.Value = subType.UnitSizeH.ToString();

                    XmlAttribute attmodalYCount = xmlDoc.CreateAttribute("modalYCount");
                    attmodalYCount.Value = subType.UnitSizeV.ToString();

                    XmlAttribute attmodalXPixelCount = xmlDoc.CreateAttribute("modalXPixelCount");
                    attmodalXPixelCount.Value = subType.BoardPixelH.ToString();

                    XmlAttribute attmodalYPixelCount = xmlDoc.CreateAttribute("modalYPixelCount");
                    attmodalYPixelCount.Value = subType.BoardPixelV.ToString();

                    newNode.Attributes.Append(attID);
                    newNode.Attributes.Append(attName);
                    newNode.Attributes.Append(attTitle);
                    newNode.Attributes.Append(attmodalXCount);
                    newNode.Attributes.Append(attmodalYCount);
                    newNode.Attributes.Append(attmodalXPixelCount);
                    newNode.Attributes.Append(attmodalYPixelCount);
                    subTypeNode.AppendChild(newNode);
                }

                XmlNodeList subTypeNodeList = unitNode.SelectNodes("subType/item");
                int i = 0;
                foreach (XmlNode item in subTypeNodeList)
                {
                    item.Attributes["id"].Value = i.ToString();
                    i++;
                }
                xmlDoc.Save(_xmlPath);
            }
        }

        public IList<UnitSubType> GetCustomizeTypes()
        {
            IList<UnitSubType> subTypes = new List<UnitSubType>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_xmlPath);
            XmlNode unitNode = xmlDoc.SelectSingleNode("units/unit[@name='Customize']");
            if (unitNode != null)
            {
                XmlNodeList subTypeNodes = unitNode.SelectNodes("subType/item");
                if (subTypeNodes != null)
                {
                    foreach (XmlNode item in subTypeNodes)
                    {
                        UnitSubType type = new UnitSubType();
                        type.Id = int.Parse(item.Attributes["id"].Value);
                        type.Name = item.Attributes["name"].Value;
                        type.Title = item.Attributes["title"].Value;
                        type.BoardPixelH = int.Parse(item.Attributes["modalXPixelCount"].Value);
                        type.BoardPixelV = int.Parse(item.Attributes["modalYPixelCount"].Value);
                        type.UnitSizeH = int.Parse(item.Attributes["modalXCount"].Value);
                        type.UnitSizeV = int.Parse(item.Attributes["modalYCount"].Value);
                        subTypes.Add(type);
                    }
                }
            }
            return subTypes;
        }

        public UnitSubType GetCustomizeType(string name)
        {
            UnitSubType subType = null;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_xmlPath);
            XmlNode unitNode = xmlDoc.SelectSingleNode("units/unit[@name='Customize']");
            if (unitNode != null)
            {
                XmlNode subTypeNode = unitNode.SelectSingleNode("subType/item[@name='" + name + "']");
                if (subTypeNode != null)
                {
                    subType = new UnitSubType();
                    subType.Id = int.Parse(subTypeNode.Attributes["id"].Value);
                    subType.Name = subTypeNode.Attributes["name"].Value;
                    subType.Title = subTypeNode.Attributes["title"].Value;
                    subType.BoardPixelH = int.Parse(subTypeNode.Attributes["modalXPixelCount"].Value);
                    subType.BoardPixelV = int.Parse(subTypeNode.Attributes["modalYPixelCount"].Value);
                    subType.UnitSizeH = int.Parse(subTypeNode.Attributes["modalXCount"].Value);
                    subType.UnitSizeV = int.Parse(subTypeNode.Attributes["modalYCount"].Value);
                }
            }
            return subType;
        }

        public void ModifyCustomizeType(UnitSubType subType)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_xmlPath);
            XmlNode unitNode = xmlDoc.SelectSingleNode("units/unit[@name='Customize']");
            if (unitNode != null)
            {
                XmlNode subTypeNode = unitNode.SelectSingleNode("subType/item[@name='" + subType.Name + "']");
                if (subTypeNode != null)
                {
                    subTypeNode.Attributes["name"].Value = subType.Name;
                    subTypeNode.Attributes["title"].Value = subType.Title;
                    subTypeNode.Attributes["modalXPixelCount"].Value = subType.BoardPixelH.ToString();
                    subTypeNode.Attributes["modalYPixelCount"].Value = subType.BoardPixelV.ToString();
                    subTypeNode.Attributes["modalXCount"].Value = subType.UnitSizeH.ToString();
                    subTypeNode.Attributes["modalYCount"].Value = subType.UnitSizeV.ToString();
                    xmlDoc.Save(_xmlPath);
                }
            }
        }

        public void RemoveCustomizeType(string name)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_xmlPath);
            XmlNode unitNode = xmlDoc.SelectSingleNode("units/unit[@name='Customize']");
            if (unitNode != null)
            {
                XmlNode subTypeNode = unitNode.SelectSingleNode("subType/item[@name='" + name + "']");
                if (subTypeNode != null)
                    unitNode.SelectSingleNode("subType").RemoveChild(subTypeNode);
            }

            XmlNodeList newUnitNode = unitNode.SelectNodes("subType/item");
            int i = 0;
            foreach (XmlNode item in newUnitNode)
            {
                item.Attributes["id"].Value = i.ToString();
                i++;
            }
            xmlDoc.Save(_xmlPath);
        }
    }
}