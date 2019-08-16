#region << 注释 >>
/************************************************************************
*文件名： SNHelper
*创建人： JIN
*创建时间：2019/7/12 16:29:35
*描述：
*=======================================================================
*修改时间：2019/7/12 16:29:35
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLWController.Helper
{
    public class SNHelper
    {
        public static byte[] CreateSN(out string str)
        {
            byte[] data = new byte[1024];
            int nSerialLen = data.Length;
            for (int k = 0; k < nSerialLen; k++)
                data[k] = 0xff;

            DateTime dt = DateTime.Now;
            string szSerial = string.Format("{0:yyyyMMddHHmmssfff}", dt);

            byte[] t = System.Text.Encoding.Default.GetBytes(szSerial);

            for (int i = 0; i < 17; i++)
            {
                data[i] = t[i];
            }
            data[17] = 0;
            str = szSerial;
            return data;
        }

        public static byte[] CreateSN(string sn, out string str)
        {
            byte[] data = new byte[1024];
            int nSerialLen = data.Length;
            for (int k = 0; k < nSerialLen; k++)
                data[k] = 0xff;


            byte[] t = System.Text.Encoding.Default.GetBytes(sn);

            for (int i = 0; i < t.Length; i++)
            {
                data[i] = t[i];
            }
            str = sn;
            return data;
        }

        public static bool AnalayzeSN(byte[] data, out string str)
        {
            string szSerial;
            //分析处理接收的字符串                
            byte[] t = new byte[17];

            int ffCount = 0;
            int errorCount = 0;
            for (int i = 0; i < 17; i++)
            {
                if (data[i] == 0xFF) ffCount++;
                if ((data[i] < 0x30) || (data[i] > 0x39)) errorCount++;
            }
            if (ffCount == 17)//该模块没有写时间码
            {
                szSerial = "00000000000000000";
            }
            else if (errorCount > 0)
            {
                szSerial = "时间码错误";
            }
            else
            {
                for (int i = 0; i < 17; i++)
                {
                    t[i] = data[i];
                }
                szSerial = System.Text.Encoding.Default.GetString(t);
            }
            str = szSerial;
            return true;
        }
    }
}
