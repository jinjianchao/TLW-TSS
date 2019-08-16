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
    }
}
