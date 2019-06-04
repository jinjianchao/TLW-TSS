using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using PluginLib;
using System.Xml;

namespace LYDTOPDP.Service
{
    public static class UserService
    {
        static string configFile = AppDomain.CurrentDomain.BaseDirectory + "/ConfigData/Config.xml";
        public static User CurrentUser { get; set; }
        static IList<User> m_users = new List<User>();

        static void LoadUsers()
        {
            string dataPath = AppDomain.CurrentDomain.BaseDirectory + "/ConfigData/UData.dat";
            TextReader reader = new StreamReader(dataPath, Encoding.Default);
            string line = null;
            while ((line = reader.ReadLine()) != null)
            {
                string[] tmp = line.Split('#');//数据格式:UserName#Password#Level
                m_users.Add(new User
                {
                    Name = tmp[0],
                    Password = tmp[1],
                    Level = Convert.ToInt32(tmp[2])
                });
            }
        }

        static UserService()
        {
            LoadUsers();
        }

        public static bool CheckUser(string name, string password,int level)
        {
            foreach (var item in m_users)
            {
                if (item.Name == name && item.Password == password && item.Level == level)
                {
                    CurrentUser = item;
                    return true;
                }
            }
            return false;
        }

        public static void SetStartUserLevel(int level)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(configFile);
            XmlNode node = xmlDoc.SelectSingleNode("config/system/user");
            node.Attributes["level"].Value = level.ToString();
            xmlDoc.Save(configFile);
            xmlDoc = null;
        }

        public static int GetStartUserLevel()
        {
            int level = 3;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(configFile);
            XmlNode node = xmlDoc.SelectSingleNode("config/system/user");
            level = int.Parse(node.Attributes["level"].Value);
            xmlDoc = null;
            return level;
        }
    }
}
