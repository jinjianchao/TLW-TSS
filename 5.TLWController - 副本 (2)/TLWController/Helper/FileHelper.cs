#region << 注释 >>
/************************************************************************
*文件名： FileHelper
*创建人： JIN
*创建时间：2019/6/26 13:34:08
*描述：
*=======================================================================
*修改时间：2019/6/26 13:34:08
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TLWController.Extentions;

namespace TLWController.Helper
{
    public class FileHelper
    {
        public static bool WriteTextFile(string text, string file)
        {
            TextWriter textWriter = new StreamWriter(file, false);
            textWriter.Write(text);
            textWriter.Flush();
            textWriter.Close();
            return true;
        }

        public static bool WriteTextFile(ushort[] data, string file, int lineLen)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append("0x" + data[i].ToString("X4"));
                sb.Append(",");
                if ((i + 1) % lineLen == 0)
                {
                    sb.AppendLine();
                }
            }
            string str = sb.ToString();
            str = str.Remove(str.LastIndexOf('\n')).Remove(str.LastIndexOf(','));
            TextWriter textWriter = new StreamWriter(file, false);
            textWriter.Write(str);
            textWriter.Flush();
            textWriter.Close();
            return true;
        }

        public static string ReadTextFile(string file)
        {
            using (TextReader textReader = new StreamReader(file))
            {
                return textReader.ReadToEnd();
            }
        }

        public static byte[] ReadBinaryFile(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(fs);
            long len = fs.Length;
            byte[] data = new byte[len].Fill(0xFF);
            try
            {
                byte btData;
                long cx = 0;
                while (true)
                {
                    btData = reader.ReadByte();
                    data[cx] = btData;
                    cx++;
                }
            }
            catch (EndOfStreamException exEnd)
            {

            }
            catch (Exception ex)
            {
                return null;
            }
            return data;
        }

        public static bool Find(string sourcePath, string filename, bool bFindSubDir, out string outFile)
        {
            outFile = "";
            //在指定目录及子目录下查找文件
            DirectoryInfo Dir = new DirectoryInfo(sourcePath);
            DirectoryInfo[] DirSub = Dir.GetDirectories();
            if (DirSub.Length <= 0)
            {
                foreach (FileInfo f in Dir.GetFiles($"{filename}", SearchOption.TopDirectoryOnly)) //查找文件
                {
                    outFile = Dir + @"\" + f.ToString();
                    return true;
                }
            }
            int t = 1;
            foreach (DirectoryInfo d in DirSub)//查找子目录 
            {
                Find(Dir + @"\" + d.ToString(), filename, bFindSubDir, out outFile);
                if (t == 1)
                {
                    foreach (FileInfo f in Dir.GetFiles($"{filename}", SearchOption.TopDirectoryOnly)) //查找文件
                    {
                        outFile = Dir + @"\" + f.ToString();
                        return true;
                    }
                    t = t + 1;
                }
            }
            return false;
        }
    }
}
