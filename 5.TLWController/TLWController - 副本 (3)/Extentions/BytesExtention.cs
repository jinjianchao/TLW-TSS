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

        /// <summary>
        /// 从字节中截取指定位中的数据
        /// </summary>
        /// <param name="source"></param>
        /// <param name="startBit"></param>
        /// <param name="stopBit"></param>
        /// <returns></returns>
        public static byte GetBitRangeValueFromByte(this byte source, int startBit, int stopBit)
        {
            //11111111
            //11000000 start = 2 stop =4
            byte val1 = (byte)(source << (8 - stopBit - 1));
            byte val2 = (byte)(val1 >> (8 - (stopBit - startBit + 1)));
            return val2;
        }

        /// <summary>
        /// 从Uint16中截取指定位中的数据
        /// </summary>
        /// <param name="source"></param>
        /// <param name="startBit"></param>
        /// <param name="stopBit"></param>
        /// <returns></returns>
        public static UInt16 GetBitRangeValueFromUInt16(this UInt16 source, int startBit, int stopBit)
        {
            //11111111
            //11000000 start = 2 stop =4
            UInt16 val1 = (UInt16)(source << (16 - stopBit - 1));
            UInt16 val2 = (UInt16)(val1 >> (16 - (stopBit - startBit + 1)));
            return val2;
        }

        public static byte[] Fill(this byte[] source, byte value)
        {
            for (int i = 0; i < source.Length; i++)
            {
                source[i] = value;
            }
            return source;
        }

        public static byte[,] Fill(this byte[,] source, byte value)
        {
            for (int i = 0; i < source.GetLength(0); i++)
            {
                for (int j = 0; j < source.GetLength(1); j++)
                {
                    source[i, j] = value;
                }
            }
            return source;
        }

        public static byte[] FillWithRandomData(this byte[] source)
        {
            Random rnd = new Random();
            rnd.NextBytes(source);
            return source;
        }

        public static bool IsEqual(this byte[] source, byte[] target)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] != target[i]) return false;
            }
            return true;
        }

        public static bool IsEqual(this byte[] source, byte[] target, out int diffIndex, out byte sourceData, out byte targetData)
        {
            diffIndex = 0;
            sourceData = 0;
            targetData = 0;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] != target[i])
                {
                    diffIndex = i;
                    sourceData = source[i];
                    targetData = target[i];
                    return false;
                }
            }
            return true;
        }

        public static UInt16[] ToUInt16(this byte[] source)
        {
            UInt16[] uintData = new UInt16[source.Length / 2];
            int position = 0;
            for (int i = 0; i < uintData.Length; i++)
            {
                byte[] byteData = new byte[2];
                byteData[0] = source[position];
                byteData[1] = source[position + 1];
                uintData[i] = byteData.GetUInt16();
                position += 2;
            }
            return uintData;
        }
    }
}
