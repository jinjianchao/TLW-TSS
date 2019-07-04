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
    }
}
