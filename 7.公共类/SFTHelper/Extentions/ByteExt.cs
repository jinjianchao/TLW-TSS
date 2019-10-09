#region << 注释 >>
/************************************************************************
*文件名： ByteExt
*创建人： JIN
*创建时间：2019/8/8 13:56:49
*描述：
*=======================================================================
*修改时间：2019/8/8 13:56:49
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace SFTHelper.Extentions
{
    public static class ByteExt
    {
        /// <summary>
        /// 和给定值合并为UInt16数据
        /// </summary>
        /// <param name="source"></param>
        /// <param name="withVal">需要被合并的数据</param>
        /// <param name="bHight">true:数据本身占高8位，被合并数据占低8位,false:数据本身占低8位，被合并数据占高8位</param>
        /// <returns></returns>
        public static ushort MakeUInt16With(this byte source, byte withVal, bool bHight)
        {
            ushort val = 0;
            if (bHight)
            {
                val = (ushort)((source << 8) | withVal);
            }
            else
            {
                val = (ushort)((withVal << 8) | source);
            }
            return val;
        }

        /// <summary>
        /// 获取8位数值中的一部分
        /// </summary>
        /// <param name="src"></param>
        /// <param name="nBitLow"></param>
        /// <param name="nBitHigh"></param>
        /// <returns></returns>
        public static byte GetPart(this byte src, byte nBitLow, byte nBitHigh)
        {
            //取数
            byte nResult = 0;
            byte tmp = src;
            int nLen = nBitHigh - nBitLow + 1;

            byte mask = 0;
            for (int i = 0; i < nLen; i++)
            {
                mask |= (byte)(1 << (nBitLow + i));
            }

            //使用掩码
            tmp &= (byte)(mask);

            nResult = (byte)(tmp >> nBitLow);

            return nResult;
        }
    }
}
