#region << 注释 >>
/************************************************************************
*文件名： UInt32Ext
*创建人： JIN
*创建时间：2019/8/26 9:43:27
*描述：
*=======================================================================
*修改时间：2019/8/26 9:43:27
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
    public static class UInt64Ext
    {
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

        /// <summary>
        /// 获取32位数值中的一部分
        /// </summary>
        /// <param name="src"></param>
        /// <param name="nBitLow"></param>
        /// <param name="nBitHigh"></param>
        /// <returns></returns>
        public static long GetPart(this UInt64 src, byte nBitLow, byte nBitHigh)
        {
            //取数
            long nResult = 0;
            UInt64 tmp = src;
            int nLen = nBitHigh - nBitLow + 1;

            UInt64 mask = 0;
            for (int i = 0; i < nLen; i++)
            {
                mask |= (UInt64)((long)1 << (nBitLow + i));
            }

            //使用掩码
            tmp &= (UInt64)(mask);

            nResult = (long)(tmp >> nBitLow);

            return nResult;
        }

        public static UInt64 ModifyPart(this UInt64 nSrc, byte nBitLow, byte nBitHigh, UInt64 nInput)
        {
            //取数并修改
            UInt64 tmp = nSrc;
            int nLen = nBitHigh - nBitLow + 1;

            UInt64 mask = 0;
            for (int i = 0; i < nLen; i++)
            {
                mask |= (UInt64)((long)1 << (nBitLow + i));
            }

            //输入值过滤
            UInt64 nData = (UInt64)(nInput & (mask >> nBitLow));

            //剔除原数据中的数据
            tmp &= (UInt64)(~mask);

            //将新数据放入指定位置
            tmp |= (UInt64)(nData << nBitLow);

            return tmp;
        }
    }
}
