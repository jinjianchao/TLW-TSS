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
using System.Linq;
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

        /// <summary>
        /// 获取32位数值中的一部分
        /// </summary>
        /// <param name="src"></param>
        /// <param name="nBitLow"></param>
        /// <param name="nBitHigh"></param>
        /// <returns></returns>
        public static ushort GetPartOfUInt16(this ushort src, byte nBitLow, byte nBitHigh)
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

        public static UInt16 Modify(this UInt16 nSrc, byte nBitLow, byte nBitHigh, UInt16 nInput)
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
    }
}
