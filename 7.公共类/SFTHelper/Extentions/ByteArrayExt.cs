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
        /// <param name="offset">起始位置</param>
        /// <param name="len">数据长度</param>
        /// <returns></returns>
        public static byte CheckSum(this byte[] data, int offset, int len)
        {
            byte val = 0;
            for (int i = 0; i < len; i++)
            {
                val += data[offset + i];
            }
            return val;
        }
    }
}
