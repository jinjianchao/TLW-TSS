﻿#region << 注释 >>
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
    }
}
