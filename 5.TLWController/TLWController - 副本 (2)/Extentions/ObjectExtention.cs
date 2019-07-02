#region << 注释 >>
/************************************************************************
*文件名： ClassExtention
*创建人： JIN
*创建时间：2019/6/4 15:29:42
*描述：
*=======================================================================
*修改时间：2019/6/4 15:29:42
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace TLWController.Extentions
{
    public static class ObjectExtention
    {
        public static void Serialize(this object source, string file)
        {
            string folder = System.IO.Path.GetDirectoryName(file);
            if (System.IO.Directory.Exists(folder) == false)
            {
                System.IO.Directory.CreateDirectory(folder);
            }
            Stream steam = File.Open(file, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(steam, source);
            steam.Close();
        }

        public static object Deserialize<T>(this object source) where T : class
        {
            Stream steam2 = File.Open(source as string, FileMode.Open);
            BinaryFormatter bf2 = new BinaryFormatter();
            T obj = bf2.Deserialize(steam2) as T;
            steam2.Close();
            return obj;
        }

        public static void SerializeXML<T>(this object source, string file)
        {
            string folder = System.IO.Path.GetDirectoryName(file);
            if (System.IO.Directory.Exists(folder) == false)
            {
                System.IO.Directory.CreateDirectory(folder);
            }

            FileStream fs = new FileStream(file, FileMode.Create);
            XmlSerializer xs = new XmlSerializer(typeof(T));
            xs.Serialize(fs, source);
            fs.Close();
        }

        public static T DeserializeXML<T>(this object source) where T : class
        {
            FileStream fs = new FileStream(source.ToString(), FileMode.Open);
            XmlSerializer xs = new XmlSerializer(typeof(T));
            T obj = xs.Deserialize(fs) as T;
            fs.Close();
            return obj;
        }

    }
}
