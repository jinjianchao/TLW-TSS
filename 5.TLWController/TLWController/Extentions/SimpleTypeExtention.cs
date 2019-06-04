#region << 注释 >>
/************************************************************************
*文件名： SimpleTypeExtention
*创建人： JIN
*创建时间：2019/5/27 11:43:16
*描述：
*=======================================================================
*修改时间：2019/5/27 11:43:16
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLWController.Extentions
{
    public static class SimpleTypeExtention
    {
        #region 字符串扩展
        public static int ToInit32(this string source)
        {
            return int.Parse(source);
        }

        public static byte ToByte(this string source)
        {
            return byte.Parse(source);
        }

        public static byte[] ToBytes(this string source, char split = ' ')
        {
            string[] strArr = source.Split(split);
            byte[] byteArr = new byte[strArr.Length];
            for (int i = 0; i < strArr.Length; i++)
            {
                byteArr[i] = byte.Parse(strArr[i], System.Globalization.NumberStyles.HexNumber);
            }
            return byteArr;
        }
        #endregion

        #region 字节数组扩展
        public static string ToString(this byte[] source, string split = " ")
        {
            return BitConverter.ToString(source).Replace("-", split);
        }
        #endregion
    }
}
