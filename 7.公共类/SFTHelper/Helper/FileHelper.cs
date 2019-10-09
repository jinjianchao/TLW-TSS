#region << 注释 >>
/************************************************************************
*文件名： FileHelper
*创建人： JIN
*创建时间：2019/8/15 10:21:30
*描述：
*=======================================================================
*修改时间：2019/8/15 10:21:30
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SFTHelper.Helper
{
    public class FileHelper
    {
        /// <summary>
        /// 查找文件.支持使用通配符
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="pattern">文件名，可以包含通配符</param>
        /// <param name="searchSubDirectory">是否查找子文件夹</param>
        /// <param name="fileList">文件列表</param>
        public static void GetFiles(string directory, string pattern, bool searchSubDirectory, ref List<string> fileList)
        {
            DirectoryInfo dir = new DirectoryInfo(directory);
            if (dir.Exists || pattern.Trim() != string.Empty)
            {
                try
                {
                    foreach (FileInfo info in dir.GetFiles(pattern))
                    {
                        fileList.Add(info.FullName.ToString());
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                if (searchSubDirectory)
                {
                    foreach (DirectoryInfo info in dir.GetDirectories())//获取文件夹下的子文件夹
                    {
                        string dir1 = info.FullName;
                        GetFiles(dir1, pattern, searchSubDirectory, ref fileList);//递归调用该函数，获取子文件夹下的文件
                    }
                }
            }
        }

        /// <summary>
        /// 查找文件.支持使用通配符
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="pattern"文件名，可以包含通配符></param>
        /// <param name="fileSize"></param>
        /// <param name="searchSubDirectory"></param>
        /// <param name="fileList"></param>
        public static void GetFiles(string directory, string pattern, long fileSize, bool searchSubDirectory, ref List<string> fileList)
        {
            DirectoryInfo dir = new DirectoryInfo(directory);
            if (dir.Exists || pattern.Trim() != string.Empty)
            {
                try
                {
                    foreach (FileInfo info in dir.GetFiles(pattern))
                    {
                        if (info.Length == fileSize)
                            fileList.Add(info.FullName.ToString());
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                if (searchSubDirectory)
                {
                    foreach (DirectoryInfo info in dir.GetDirectories())//获取文件夹下的子文件夹
                    {
                        string dir1 = info.FullName;
                        GetFiles(dir1, pattern, fileSize, searchSubDirectory, ref fileList);//递归调用该函数，获取子文件夹下的文件
                    }
                }
            }
        }

        public static void WriteFile(byte[] data, string file, int lineDataCount)
        {
            FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write);
            TextWriter writer = new StreamWriter(fs);
            int cx = 0;
            for (int i = 0; i < data.Length; i++)
            {
                writer.Write(data[i].ToString("X2") + " ");
                cx++;
                if (cx % lineDataCount == 0)
                {
                    writer.WriteLine();
                }
            }
            writer.Flush();
            writer.Close();
            fs.Close();
        }
    }
}
