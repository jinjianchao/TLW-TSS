#region << 注释 >>
/************************************************************************
*文件名： UInt32Ext
*创建人： JIN
*创建时间：2019/8/16 10:45:47
*描述：
*=======================================================================
*修改时间：2019/8/16 10:45:47
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace SFTHelper.Extentions
{
    public static class UInt32Ext
    {
        public static byte[] GetBytes(this uint data, bool isHighFirst = true)
        {
            int btLen = 4;
            int maxLen = 32;
            List<byte> bytes = new List<byte>();
            if (isHighFirst)
            {
                for (int i = 0; i < btLen; i++)
                {
                    bytes.Add((byte)((data >> (maxLen - ((i + 1) << 3))) & 0xff));
                }
            }
            else
            {
                for (int i = 0; i < btLen; i++)
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
        public static int GetPart(this uint src, byte nBitLow, byte nBitHigh)
        {
            //取数
            int nResult = 0;
            UInt32 tmp = src;
            int nLen = nBitHigh - nBitLow + 1;

            UInt32 mask = 0;
            for (int i = 0; i < nLen; i++)
            {
                mask |= (UInt32)(1 << (nBitLow + i));
            }

            //使用掩码
            tmp &= (UInt32)(mask);

            nResult = (int)(tmp >> nBitLow);

            return nResult;
        }

        public static UInt32 ModifyPart(this UInt32 nSrc, byte nBitLow, byte nBitHigh, UInt32 nInput)
        {
            //取数并修改
            UInt32 tmp = nSrc;
            int nLen = nBitHigh - nBitLow + 1;

            UInt32 mask = 0;
            for (int i = 0; i < nLen; i++)
            {
                mask |= (UInt32)(1 << (nBitLow + i));
            }

            //输入值过滤
            UInt32 nData = (UInt32)(nInput & (mask >> nBitLow));

            //剔除原数据中的数据
            tmp &= (UInt32)(~mask);

            //将新数据放入指定位置
            tmp |= (UInt32)(nData << nBitLow);

            return tmp;
        }
    }
}
