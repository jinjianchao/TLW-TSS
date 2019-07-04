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
        public static int ToInit32(this string source, System.Globalization.NumberStyles styles = System.Globalization.NumberStyles.Number)
        {
            return int.Parse(source, styles);
        }

        public static UInt16 ToUInt16(this string source, System.Globalization.NumberStyles styles = System.Globalization.NumberStyles.HexNumber)
        {
            return UInt16.Parse(source, styles);
        }

        public static UInt32 ToUInt32(this string source, System.Globalization.NumberStyles styles = System.Globalization.NumberStyles.HexNumber)
        {
            return UInt32.Parse(source, styles);
        }

        public static byte ToByte(this string source)
        {
            return byte.Parse(source, System.Globalization.NumberStyles.HexNumber);
        }

        public static byte[] ToBytes(this string source, char split = ' ', System.Globalization.NumberStyles numberStyles = System.Globalization.NumberStyles.HexNumber)
        {
            string[] strArr = source.Split(split);
            byte[] byteArr = new byte[strArr.Length];
            for (int i = 0; i < strArr.Length; i++)
            {
                byteArr[i] = byte.Parse(strArr[i], numberStyles);
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

        public static byte[] ToBytes(this ushort[] source)
        {
            //ushort[] arrDefualt = {0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0001,0x0001,0x0001,0x0000,0x0000,0x0000,0x0000,0x0000, //0 
            //        0x0000,0x0000,0x021F,0x0310,0x0402,0x050F,0x0602,0x0720,0x0820,0x0908,0x0A08,0x0B80,0x0C01,0x0D01,0x0E04,0x0F01, //1
            //        0x1042,0x1121,0x1201,0x1308,0x1400,0x1500,0x1600,0x17F0,0x181F,0x1900,0x1A1F,0x1B10,0x1CD0,0x1D0C,0x1E42,0x1F04, //2
            //        0x2008,0x2101,0x221C,0x2300,0x021F,0x0310,0x0402,0x050F,0x0602,0x0720,0x0820,0x0908,0x0A08,0x0B00,0x0C20,0x0D01, //3
            //        0x0E04,0x0F01,0x1042,0x1121,0x1201,0x1308,0x1400,0x1500,0x1600,0x17F0,0x0602,0x1950,0x1A1F,0x1B10,0x1CD0,0x1D0A, //4
            //        0x1E46,0x1F20,0x2008,0x2101,0x221C,0x2300,0x021F,0x0310,0x0402,0x050F,0x0602,0x0720,0x0820,0x0908,0x0A08,0x0B00, //5
            //        0x0C20,0x0D01,0x0E04,0x0F01,0x1042,0x1121,0x1201,0x1308,0x1400,0x1500,0x1600,0x17F0,0x182F,0x1900,0x1A1F,0x1B10, //6
            //        0x1CD0,0x1D0A,0x1E48,0x1F20,0x2010,0x2101,0x221C,0x2300,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //7
            //        0x0080,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //8
            //        0x0000,0x0000,0x7FFF,0x7FFF,0x7FFF,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //9
            //        0x0020,0x000F,0x0030,0x000A,0x0000,0x0000,0x0000,0x0000,0xFFFF,0x3FFF,0x3FFF,0x3FFF,0xFFFF,0xFFFF,0x3FFF,0x3FFF, //a
            //        0x3FFF,0xFFFF,0x3FFF,0x3FFF,0x3FFF,0xFFFF,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //b
            //        0x3FFF,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //c
            //        0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //d
            //        0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //e 
            //        0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000}; //f

            byte[] data = new byte[source.Length * 2];
            int index = 0;
            for (int i = 0; i < source.Length; i++)
            {
                data[index] = (byte)(source[i] >> 8);
                index++;
                data[index] = (byte)(source[i] & (ushort)0x00ff);
                index++;
            }
            return data;
        }

        public static string Reverse(this string soruce)
        {
            string newStr = "";
            for (int i = soruce.Length - 1; i >= 0; i--)
            {
                newStr += soruce.Substring(i, 1);
            }
            return newStr;
        }

        public static string Replace(this string source, int index, string newValue)
        {
            //string str1 = source.Substring(0, index);
            //string str2 = source.Substring(index + 1);
            //string str3 = str1 + newValue + str2;
            //return str3;

            char[] charArr = source.ToCharArray();
            charArr[index] = (newValue.ToCharArray())[0];
            string str = new string(charArr);
            return str;
        }
    }
}
