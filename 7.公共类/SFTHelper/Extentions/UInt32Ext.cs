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
using System.Linq;
using System.Text;

namespace SFTHelper.Extentions
{
    public static class UInt32Ext
    {
        /// <summary>
        /// 获取32位数值中的一部分
        /// </summary>
        /// <param name="src"></param>
        /// <param name="nBitLow"></param>
        /// <param name="nBitHigh"></param>
        /// <returns></returns>
        public static int GetPartOfUInt32(this uint src, byte nBitLow, byte nBitHigh)
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
    }
}
