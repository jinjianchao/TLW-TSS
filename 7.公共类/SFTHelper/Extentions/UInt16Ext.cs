#region << 注释 >>
/************************************************************************
*文件名： UInt16Ext
*创建人： JIN
*创建时间：2019/8/8 13:52:22
*描述：
*=======================================================================
*修改时间：2019/8/8 13:52:22
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace SFTHelper.Extentions
{
    public static class UInt16Ext
    {
        /// <summary>
        /// 获取高字节数据
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static byte HByte(this ushort source)
        {
            return (byte)((source >> 8) & 0xFF);
        }

        /// <summary>
        /// 获取低字节数据
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static byte LByte(this ushort source)
        {
            return (byte)(source & 0xFF);
        }

        public static byte[] GetBytes(this ushort source, bool isHighFirst = true)
        {
            List<byte> value = new List<byte>();
            int btLen = 2;
            int maxLen = 16;

            List<byte> bytes = new List<byte>();
            if (isHighFirst)
            {
                for (int i = 0; i < btLen; i++)
                {
                    bytes.Add((byte)((source >> (maxLen - ((i + 1) << 3))) & 0xff));
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    bytes.Add((byte)((source >> (i << 3)) & 0xff));
                }
            }
            return bytes.ToArray();
        }

        /// <summary>
        /// 获取32位数值中的一部分
        /// </summary>
        /// <param name="src"></param>
        /// <param name="nBitLow"></param>
        /// <param name="nBitHigh"></param>
        /// <returns></returns>
        public static ushort GetPart(this ushort src, int nBitLow, int nBitHigh)
        {
            //取数
            ushort nResult = 0;
            ushort tmp = src;
            int nLen = nBitHigh - nBitLow + 1;

            ushort mask = 0;
            for (int i = 0; i < nLen; i++)
            {
                mask |= (ushort)(1 << (nBitLow + i));
            }

            //使用掩码
            tmp &= (ushort)(mask);

            nResult = (ushort)(tmp >> nBitLow);

            return nResult;
        }

        public static UInt16 ModifyPart(this UInt16 nSrc, int nBitLow, int nBitHigh, UInt16 nInput)
        {
            //取数并修改
            UInt16 tmp = nSrc;
            int nLen = nBitHigh - nBitLow + 1;

            UInt16 mask = 0;
            for (int i = 0; i < nLen; i++)
            {
                mask |= (UInt16)(1 << (nBitLow + i));
            }

            //输入值过滤
            UInt16 nData = (UInt16)(nInput & (mask >> nBitLow));

            //剔除原数据中的数据
            tmp &= (UInt16)(~mask);

            //将新数据放入指定位置
            tmp |= (UInt16)(nData << nBitLow);

            return tmp;
        }

        public static string GetBinaryString(this UInt16 source)
        {
            int len = 16;
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

    }
}
