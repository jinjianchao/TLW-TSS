#region << 注释 >>
/************************************************************************
*文件名： ObjectExt
*创建人： JIN
*创建时间：2019/8/26 13:19:00
*描述：
*=======================================================================
*修改时间：2019/8/26 13:19:00
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

namespace SFTHelper.Extentions
{
    public static class ObjectExt
    {
        /// <summary>
        /// 对象序列化
        /// </summary>
        /// <param name="source"></param>
        /// <param name="file"></param>
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
        
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static object Deserialize<T>(this object source) where T : class
        {
            Stream steam2 = File.Open(source as string, FileMode.Open);
            BinaryFormatter bf2 = new BinaryFormatter();
            T obj = bf2.Deserialize(steam2) as T;
            steam2.Close();
            return obj;
        }

        /// <summary>
        /// 序列化成xml文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="file"></param>
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

        /// <summary>
        /// xml文件反序列化为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
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
