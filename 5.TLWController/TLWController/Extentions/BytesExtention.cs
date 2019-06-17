#region << 注释 >>
/************************************************************************
*文件名： BytesExtention
*创建人： JIN
*创建时间：2019/6/6 16:32:19
*描述：
*=======================================================================
*修改时间：2019/6/6 16:32:19
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
    public static class BytesExtention
    {
        public static byte[] GetBytes(this byte data)
        {
            return new byte[1] { data };
        }

        public static byte[] GetBytes(this ushort data, bool isHighFirst = true)
        {
            List<byte> bytes = new List<byte>();
            if (isHighFirst)
            {
                for (int i = 0; i < 2; i++)
                {
                    bytes.Add((byte)((data >> (16 - ((i + 1) << 3))) & 0xff));
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    bytes.Add((byte)((data >> (i << 3)) & 0xff));
                }
            }
            return bytes.ToArray();
        }

        public static byte[] GetBytes(this uint data, bool isHighFirst = true)
        {
            List<byte> bytes = new List<byte>();
            if (isHighFirst)
            {
                for (int i = 0; i < 4; i++)
                {
                    bytes.Add((byte)((data >> (32 - ((i + 1) << 3))) & 0xff));
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    bytes.Add((byte)((data >> (i << 3)) & 0xff));
                }
            }
            return bytes.ToArray();
        }

        public static byte[] GetBytes(this UInt64 data, bool isHighFirst = true)
        {
            List<byte> bytes = new List<byte>();
            if (isHighFirst)
            {
                for (int i = 0; i < 8; i++)
                {
                    bytes.Add((byte)((data >> (64 - ((i + 1) << 3))) & 0xff));
                }
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    bytes.Add((byte)((data >> (i << 3)) & 0xff));
                }
            }
            return bytes.ToArray();
        }

        public static ushort GetUInt16(this byte[] data, bool isHighFirst = true)
        {
            ushort value = 0;
            if (isHighFirst)
            {
                for (int i = 0; i < 2; i++)
                {
                    value |= data[i];
                    if (i < 1)
                        value <<= 8;
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    value |= data[1 - i];
                    if (i < 1)
                        value <<= 8;
                }
            }
            return value;
        }

        public static uint GetUInt32(this byte[] data, bool isHighFirst = true)
        {
            uint value = 0;
            if (isHighFirst)
            {
                for (int i = 0; i < 4; i++)
                {
                    value |= data[i];
                    if (i < 3)
                        value <<= 8;
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    value |= data[3 - i];
                    if (i < 3)
                        value <<= 8;
                }
            }
            return value;
        }

        public static ulong GetUInt64(this byte[] data, bool isHighFirst = true)
        {
            ulong value = 0;
            if (isHighFirst)
            {
                for (int i = 0; i < 8; i++)
                {
                    value |= data[i];
                    if (i < 7)
                        value <<= 8;
                }
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    value |= data[7 - i];
                    if (i < 7)
                        value <<= 8;
                }
            }
            return value;
        }

        public static ushort Sum(this byte[] data)
        {
            ushort val = 0;
            for (int i = 0; i < data.Length; i++)
            {
                val += data[i];
            }
            return val;
        }

        public static string ToBinaryString(this byte source, int len)
        {
            string str1 = Convert.ToString(source, 2);
            if (str1.Length < len)
            {
                int length = len - str1.Length;
                for (int i = 0; i < length; i++)
                {
                    str1 = "0" + str1;
                }
            }
            return str1;
        }

        public static string ToBinaryString(this UInt16 source, int len)
        {
            string str1 = Convert.ToString(source, 2);
            if (str1.Length < len)
            {
                int length = len - str1.Length;
                for (int i = 0; i < length; i++)
                {
                    str1 = "0" + str1;
                }
            }
            return str1;
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
