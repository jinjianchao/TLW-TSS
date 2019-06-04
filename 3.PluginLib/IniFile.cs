using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace PluginLib
{
   public class IniFile
    {
        public string Path;
        public IniFile(string path)
        {
            this.Path = path;
        }
        
        //声明读写INI文件的API函数 
        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, Byte[] retVal, int size, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileSectionNames(string section, string key, string defVal, Byte[] retVal, int size, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileSectionNames(char[] Buffer, int size, string filePath);


        /**/
        /// <summary>
        /// 写INI文件
        /// </summary>
        /// <param name="section">段落</param>
        /// <param name="key">键</param>
        /// <param name="iValue">值</param>
        public bool IniWriteValue(string section, string key, string iValue)
        {
            return WritePrivateProfileString(section, key, iValue, this.Path);
        }

        /**/
        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="section">段落</param>
        /// <param name="key">键</param>
        /// <returns>返回的键值</returns>
        public string IniReadValue(string section, string key)
        {
            StringBuilder temp = new StringBuilder(255);

            int i = GetPrivateProfileString(section, key, "", temp, 255, this.Path);
            return temp.ToString();
        }

        /**/
        /// <summary>
        /// 读取/遍历INI文件
        /// </summary>
        /// <param name="Section">段，格式[]</param>
        /// <param name="Key">键</param>
        /// <returns>返回byte类型的section组或键值组</returns>
        public byte[] IniReadValues(string section, string key)
        {
            byte[] temp = new byte[2048];

            int i = GetPrivateProfileString(section, key, "", temp, 2048, this.Path);
            return temp;
        }
      

        /// <summary>
        /// 删除节点/键值信息
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="delType">0--删除所有节点；1--删除指定节点；2--删除指定节点的key</param>
        /// <returns></returns>
        public bool IniDelSection(string section, string key, int delType)
        {
            
            bool result=false;
            switch (delType)
            {
                case 0:result = WritePrivateProfileString(null,null,null,this.Path);break;
                case 1:result=WritePrivateProfileString(section,null,null,this.Path);break;
                case 2:result=WritePrivateProfileString(section,key,null,this.Path);break;
            }
            return result;

        }

        /// <summary>
        /// 统计节点个数
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="delType"></param>
        /// <returns></returns>
        public int IniSectionCount()
        {
            int sectionCount = 0;
            char[] temp=new char[2048];
            GetPrivateProfileSectionNames(temp, 2048, this.Path);
            if (temp[0] == '\0' && temp[1] == '\0')
            {
                sectionCount = 0;
            }
            else
            {
                for (int i = 0; i < 2048; i=+2)
                {
                    if (temp[i] == '\0' && temp[i+1] == '\0')
                    {

                    }
                    else if (temp[i] == '\0' && temp[i + 1] != '\0')
                    {
                        sectionCount++;
                    }
                }
            }
           
            return sectionCount;
        }

        /// <summary>
        /// 循环写入keys,values
        /// </summary>
        /// <param name="section">节点</param>
        /// <param name="keys">键的集合</param>
        /// <param name="values">值的集合</param>
        /// <returns></returns>
        public bool IniWriteValues(String section, StringBuilder keys, StringBuilder values)
        {
            int Count = 0;
            string[] key = keys.ToString().Split('|');
            string[] value = values.ToString().Split('|');
            Count = key.Length > value.Length ? key.Length : value.Length;
            //执行结果
            bool result = false;
            //是否继续循环
            bool bol = true;
            for (int i = 0; i < Count-1 && bol; i++)
            {
                bol = WritePrivateProfileString(section, key[i], value[i], this.Path);
                if (!bol)
                {
                    result = bol;
                }
            }

            return result;
        }
    }
}
