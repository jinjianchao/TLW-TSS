#region << 注释 >>
/************************************************************************
*文件名： StringExt
*创建人： JIN
*创建时间：2019/8/26 11:05:15
*描述：
*=======================================================================
*修改时间：2019/8/26 11:05:15
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFTHelper.Extentions
{
    public static class StringExt
    {
        /// <summary>
        /// 字符串转换为Int16类型
        /// </summary>
        /// <param name="source"></param>
        /// <param name="styles">原始数据进制</param>
        /// <returns></returns>
        public static Int16 GetInt16(this string source, System.Globalization.NumberStyles styles)
        {
            try
            {
                return Int16.Parse(source, styles);
            }
            catch
            {
            }
            return 0;
        }

        /// <summary>
        /// 字符串转换为UInt16类型
        /// </summary>
        /// <param name="source"></param>
        /// <param name="styles">原始数据进制</param>
        /// <returns></returns>
        public static UInt16 GetUInt16(this string source, System.Globalization.NumberStyles styles)
        {
            try
            {
                return UInt16.Parse(source, styles);
            }
            catch
            {
            }
            return 0;
        }

        /// <summary>
        /// 字符串转换为Int32类型
        /// </summary>
        /// <param name="source"></param>
        /// <param name="styles">原始数据进制</param>
        /// <returns></returns>
        public static int GetInt32(this string source, System.Globalization.NumberStyles styles)
        {
            return int.Parse(source, styles);
        }

        /// <summary>
        /// 字符串转换为UInt32类型
        /// </summary>
        /// <param name="source"></param>
        /// <param name="styles">原始数据进制</param>
        /// <returns></returns>

        public static UInt32 GetUInt32(this string source, System.Globalization.NumberStyles styles)
        {
            return UInt32.Parse(source, styles);
        }

        /// <summary>
        /// 字符串转换为Byte类型
        /// </summary>
        /// <param name="source"></param>
        /// <param name="styles">原始数据进制</param>
        /// <returns></returns>
        public static byte GetByte(this string source, System.Globalization.NumberStyles styles)
        {
            return byte.Parse(source, styles);
        }

        /// <summary>
        /// 将使用指定分隔符分割的字节字符串转换为字节数组
        /// </summary>
        /// <param name="source"></param>
        /// <param name="split">分隔符</param>
        /// <param name="numberStyles">原始数据进制</param>
        /// <returns></returns>
        public static byte[] GetBytes(this string source, char split, System.Globalization.NumberStyles numberStyles)
        {
            string[] strArr = source.Split(split);
            byte[] byteArr = new byte[strArr.Length];
            for (int i = 0; i < strArr.Length; i++)
            {
                byteArr[i] = byte.Parse(strArr[i], numberStyles);
            }
            return byteArr;
        }

        /// <summary>
        /// 颠倒字符串
        /// </summary>
        /// <param name="soruce"></param>
        /// <returns></returns>
        public static string Reverse(this string soruce)
        {
            string newStr = "";
            for (int i = soruce.Length - 1; i >= 0; i--)
            {
                newStr += soruce.Substring(i, 1);
            }
            return newStr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="index"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static string Replace(this string source, int index, string newValue)
        {
            char[] charArr = source.ToCharArray();
            charArr[index] = (newValue.ToCharArray())[0];
            string str = new string(charArr);
            return str;
        }

        public static bool IsNumber(this string source)
        {
            for (int i = 0; i < source.Length; i++)
            {
                string str = source.Substring(i, 1);
                ushort val = str.GetUInt16(System.Globalization.NumberStyles.HexNumber);
                if (val < 0 || val > 9)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
