#region << 注释 >>
/************************************************************************
*文件名： ByteArrayExt
*创建人： JIN
*创建时间：2019/8/8 14:35:54
*描述：
*=======================================================================
*修改时间：2019/8/8 14:35:54
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
    public static class ByteArrayExt
    {
        /// <summary>
        /// 校验
        /// </summary>
        /// <param name="data"></param>
        /// <param name="offset">起始位置(offset从0开始)</param>
        /// <param name="len">数据长度</param>
        /// <returns></returns>
        public static byte CheckSumForByte(this byte[] data, int offset, int len)
        {
            byte val = 0;
            for (int i = 0; i < len; i++)
            {
                val += data[offset + i];
            }
            return val;
        }

        /// <summary>
        /// 校验
        /// </summary>
        /// <param name="data"></param>
        /// <param name="offset">起始位置(offset从0开始)</param>
        /// <param name="len">数据长度</param>
        /// <returns></returns>
        public static ushort CheckSumForUInt16(this byte[] data, int offset, int len)
        {
            ushort val = 0;
            for (int i = 0; i < len; i++)
            {
                val += data[offset + i];
            }
            return val;
        }


        /// <summary>
        /// 校验
        /// </summary>
        /// <param name="data"></param>
        /// <param name="offset">起始位置(offset从0开始)</param>
        /// <param name="len">数据长度</param>
        /// <returns></returns>
        public static UInt32 CheckSumForUInt32(this byte[] data, int offset, int len)
        {
            UInt32 val = 0;
            for (int i = 0; i < len; i++)
            {
                val += data[offset + i];
            }
            return val;
        }

        /// <summary>
        /// 校验
        /// </summary>
        /// <param name="data"></param>
        /// <param name="offset">起始位置(offset从0开始)</param>
        /// <param name="len">数据长度</param>
        /// <returns></returns>
        public static UInt64 CheckSumForUInt64(this byte[] data, int offset, int len)
        {
            UInt64 val = 0;
            for (int i = 0; i < len; i++)
            {
                val += data[offset + i];
            }
            return val;
        }

        /// <summary>
        /// 从数组中获取UInt16数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="offset">在数组中的偏移</param>
        /// <param name="isHighFirst"></param>
        /// <returns></returns>
        public static ushort GetUInt16(this byte[] data, int offset, bool isHighFirst = true)
        {
            byte[] tmp = new byte[2];
            tmp[0] = data[offset];
            tmp[1] = data[offset + 1];

            ushort value = 0;
            if (isHighFirst)
            {
                for (int i = 0; i < 2; i++)
                {
                    value |= tmp[i];
                    if (i < 1)
                        value <<= 8;
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    value |= tmp[1 - i];
                    if (i < 1)
                        value <<= 8;
                }
            }
            return value;
        }

        public static ushort GetUInt16(this byte[] data, int offset, int len, bool isHighFirst = true)
        {
            //byte[] tmp = new byte[2];
            //tmp[0] = data[offset];
            //tmp[1] = data[offset + 1];

            byte[] tmp = new byte[2];
            for (int i = 0; i < len; i++)
            {
                tmp[2 - i - 1] = data[offset + len - i - 1];
            }

            ushort value = 0;
            if (isHighFirst)
            {
                for (int i = 0; i < 2; i++)
                {
                    value |= tmp[i];
                    if (i < 1)
                        value <<= 8;
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    value |= tmp[1 - i];
                    if (i < 1)
                        value <<= 8;
                }
            }
            return value;
        }

        /// <summary>
        /// 字节数组转UInt32
        /// </summary>
        /// <param name="data"></param>
        /// <param name="isHighFirst">高位在前</param>
        /// <returns></returns>
        public static uint GetUInt32(this byte[] data, int offset, bool isHighFirst = true)
        {
            byte[] tmp = new byte[4];
            tmp[0] = data[offset];
            tmp[1] = data[offset + 1];
            tmp[2] = data[offset + 2];
            tmp[3] = data[offset + 3];

            uint value = 0;
            if (isHighFirst)
            {
                for (int i = 0; i < 4; i++)
                {
                    value |= tmp[i];
                    if (i < 3)
                        value <<= 8;
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    value |= tmp[3 - i];
                    if (i < 3)
                        value <<= 8;
                }
            }
            return value;
        }

        public static uint GetUInt32(this byte[] data, int offset, int len, bool isHighFirst = true)
        {
            byte[] tmp = new byte[4];
            for (int i = 0; i < len; i++)
            {
                tmp[4 - i - 1] = data[offset + len - i - 1];
            }

            uint value = 0;
            if (isHighFirst)
            {
                for (int i = 0; i < 4; i++)
                {
                    value |= tmp[i];
                    if (i < 3)
                        value <<= 8;
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    value |= tmp[3 - i];
                    if (i < 3)
                        value <<= 8;
                }
            }
            return value;
        }

        /// <summary>
        /// 字节数组转UInt64
        /// </summary>
        /// <param name="data"></param>
        /// <param name="isHighFirst">高位在前</param>
        /// <returns></returns>
        public static ulong GetUInt64(this byte[] data, int offset, bool isHighFirst = true)
        {
            byte[] tmp = new byte[8];
            tmp[0] = data[offset];
            tmp[1] = data[offset + 1];
            tmp[2] = data[offset + 2];
            tmp[3] = data[offset + 3];
            tmp[4] = data[offset + 4];
            tmp[5] = data[offset + 5];
            tmp[6] = data[offset + 6];
            tmp[7] = data[offset + 7];

            ulong value = 0;
            if (isHighFirst)
            {
                for (int i = 0; i < 8; i++)
                {
                    value |= tmp[i];
                    if (i < 7)
                        value <<= 8;
                }
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    value |= tmp[7 - i];
                    if (i < 7)
                        value <<= 8;
                }
            }
            return value;
        }

        public static ulong GetUInt64(this byte[] data, int offset, int len, bool isHighFirst = true)
        {
            //byte[] tmp = new byte[8];
            //tmp[0] = data[offset];
            //tmp[1] = data[offset + 1];
            //tmp[2] = data[offset + 2];
            //tmp[3] = data[offset + 3];
            //tmp[4] = data[offset + 4];
            //tmp[5] = data[offset + 5];
            //tmp[6] = data[offset + 6];
            //tmp[7] = data[offset + 7];

            byte[] tmp = new byte[8];
            for (int i = 0; i < len; i++)
            {
                tmp[8 - i - 1] = data[offset + len - i - 1];
            }

            ulong value = 0;
            if (isHighFirst)
            {
                for (int i = 0; i < 8; i++)
                {
                    value |= tmp[i];
                    if (i < 7)
                        value <<= 8;
                }
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    value |= tmp[7 - i];
                    if (i < 7)
                        value <<= 8;
                }
            }
            return value;
        }

        /// <summary>
        /// 用给定数值填充字节数组
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value">用于填充数组</param>
        /// <returns></returns>
        public static byte[] Fill(this byte[] source, byte value)
        {
            for (int i = 0; i < source.Length; i++)
            {
                source[i] = value;
            }
            return source;
        }

        /// <summary>
        /// 比较字节数组是否相同
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool CompareWith(this byte[] source, byte[] target)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] != target[i]) return false;
            }
            return true;
        }

        /// <summary>
        /// 字节数组转换成UInt16数组
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static UInt16[] GetUInt16Array(this byte[] source, bool isHighFirst = true)
        {
            if (source.Length % 2 != 0) return null;
            UInt16[] uintData = new UInt16[source.Length / 2];
            int position = 0;
            for (int i = 0; i < uintData.Length; i++)
            {
                byte[] byteData = new byte[2];
                byteData[0] = source[position];
                byteData[1] = source[position + 1];
                uintData[i] = byteData.GetUInt16(0, isHighFirst);
                position += 2;
            }
            return uintData;
        }

        /// <summary>
        /// 字节数组转换成字符串类型
        /// </summary>
        /// <param name="source"></param>
        /// <param name="split">分隔符</param>
        /// <returns></returns>
        public static string GetString(this byte[] source, string split)
        {
            return BitConverter.ToString(source).Replace("-", split);
        }

        /// <summary>
        /// 将字节数组拆分成多个数组
        /// </summary>
        /// <param name="source"></param>
        /// <param name="singleLength">单个数组的长度</param>
        /// <param name="isFill">如果单个数组长度不足指定长度时，是否使用给定值进行填充</param>
        /// <param name="fill">用于填充不足指定长度部分内容</param>
        /// <returns></returns>
        public static List<byte[]> Split(this byte[] source, int singleLength, bool isFill, byte fill)
        {
            List<byte[]> items = new List<byte[]>();
            int sourceLen = source.Length;
            int itemCount = sourceLen % singleLength == 0 ? sourceLen / singleLength : sourceLen / singleLength + 1;
            int position = 0;
            for (int i = 0; i < itemCount; i++)
            {
                if (i < itemCount - 1)
                {
                    byte[] bt = new byte[singleLength];
                    Array.Copy(source, position, bt, 0, singleLength);
                    items.Add(bt);
                }
                else
                {
                    if (isFill)
                    {
                        byte[] bt = new byte[singleLength];
                        Array.Copy(source, position, bt, 0, source.Length % singleLength);
                        for (int j = source.Length % singleLength; j < singleLength; j++)
                        {
                            bt[j] = fill;
                        }
                        items.Add(bt);
                    }
                    else
                    {
                        byte[] bt = new byte[source.Length % singleLength];
                        Array.Copy(source, position, bt, 0, source.Length % singleLength);
                        items.Add(bt);
                    }
                }
                position += singleLength;
            }

            return items;
        }
    }
}
