using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml;
using System.Collections;

namespace UnitInfo
{
    public class UnitTypeHelperV2
    {
        static IList<UnitMainType> _unitType = new List<UnitMainType>();
        static UnitTypeHelperV2 helper = null;

        private static string _xmlPath = AppDomain.CurrentDomain.BaseDirectory + @"\UnitInfo.xml";

        private UnitTypeHelperV2() { }

        public static UnitTypeHelperV2 CreateInstance()
        {
            //if (helper == null)
            //{
            _unitType = new List<UnitMainType>();
            helper = new UnitTypeHelperV2();

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

                        unitType.SubType.Add(subType);
                    }
                    if (unitType.SubType.Count > 0)
                    {
                        _unitType.Add(unitType);
                    }
                    //}
                }
            }

            return helper;
        }

        public static UnitTypeHelperV2 CreateInstance(string file)
        {
            //if (helper == null)
            //{
            _unitType = new List<UnitMainType>();
            helper = new UnitTypeHelperV2();

            UnitMainType unitType = null;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(file);
            XmlNodeList unitNodeList = xmlDoc.SelectNodes("units/unit");
            if (unitNodeList != null)
            {
                foreach (XmlNode unitItem in unitNodeList)
                {
                    unitType = new UnitMainType();
                    unitType.Name = unitItem.Attributes["name"].Value;
                    unitType.Id = byte.Parse(unitItem.Attributes["id"].Value);

                    UnitSubType subType = null;
                    XmlNodeList subNodeList = unitItem.SelectNodes("subType/item");
                    foreach (XmlNode subTypeItem in subNodeList)
                    {
                        subType = new UnitSubType();
                        subType.Name = subTypeItem.Attributes["name"].Value;
                        subType.Id = byte.Parse(subTypeItem.Attributes["id"].Value);

                        subType.UnitSizeH = int.Parse(subTypeItem.Attributes["modalXCount"].Value);
                        subType.UnitSizeV = int.Parse(subTypeItem.Attributes["modalYCount"].Value);

                        subType.BoardPixelH = int.Parse(subTypeItem.Attributes["modalXPixelCount"].Value);
                        subType.BoardPixelV = int.Parse(subTypeItem.Attributes["modalYPixelCount"].Value);

                        ////////////
                        UnitSubType secondSubType = null;
                        XmlNodeList secondSubNodeList = subTypeItem.SelectNodes("subType/item");
                        if (secondSubNodeList != null)
                        {
                            foreach (XmlNode secondSubTypeItem in secondSubNodeList)
                            {
                                secondSubType = new UnitSubType();
                                secondSubType.Name = secondSubTypeItem.Attributes["name"].Value;
                                secondSubType.Id = byte.Parse(secondSubTypeItem.Attributes["id"].Value);

                                secondSubType.UnitSizeH = int.Parse(secondSubTypeItem.Attributes["modalXCount"].Value);
                                secondSubType.UnitSizeV = int.Parse(secondSubTypeItem.Attributes["modalYCount"].Value);

                                secondSubType.BoardPixelH = int.Parse(secondSubTypeItem.Attributes["modalXPixelCount"].Value);
                                secondSubType.BoardPixelV = int.Parse(secondSubTypeItem.Attributes["modalYPixelCount"].Value);

                                //if (secondSubType.SubType.Count > 0)
                                //{
                                    subType.SubType.Add(secondSubType);
                                //}
                            }
                        }
                        //if (unitType.SubType.Count > 0)
                        //{
                        //    _unitType.Add(unitType);
                        //}

                        /////////////


                        unitType.SubType.Add(subType);
                    }
                    if (unitType.SubType.Count > 0)
                    {
                        _unitType.Add(unitType);
                    }
                    //}
                }
            }

            return helper;
        }

        public IList<UnitMainType> GetAllType()
        {
            return _unitType;
        }

        public UnitMainType GetMainType(string mainName)
        {
            UnitMainType resultType = null;
            if (_unitType != null)
            {
                foreach (UnitMainType item in _unitType)
                {
                    if (item.Name == mainName)
                    {
                        resultType = item;
                        break;
                    }
                }
            }
            return resultType;
        }

        public IList<UnitSubType> GetAllSubType(string mainName)
        {
            IList<UnitSubType> resultSubType = null;
            if (_unitType != null)
            {
                foreach (UnitMainType mainItem in _unitType)
                {
                    if (mainItem.Name == mainName)
                    {
                        resultSubType = mainItem.SubType;
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