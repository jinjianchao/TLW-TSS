#region << 注释 >>
/************************************************************************
*文件名： UInt16ArrayExt
*创建人： JIN
*创建时间：2019/8/26 10:44:25
*描述：
*=======================================================================
*修改时间：2019/8/26 10:44:25
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
    public static class UInt16ArrayExt
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="lineLen">一行数据长度</param>
        /// <returns></returns>
        public static string GetHexString(this UInt16[] source, int lineLen)
        {
            StringBuilder sb = new StringBuilder();
            int cx = 1;
            foreach (var item in source)
            {
                sb.Append("0x" + item.ToString("X4"));
                sb.Append(",");
                if (cx % lineLen == 0) sb.AppendLine();
                cx++;
            }
            return sb.ToString();
        }

        public static byte[] GetBytes(this ushort[] source)
        {
            byte[] data = new byte[source.Length * 2];
            int index = 0;
            for (int i = 0; i < source.Length; i++)
            {
                data[index] = (byte)(source[i] >> 8);
                index++;
                data[index] = (byte)(source[i] & (ushort)0x00ff);
                index++;
            }
            return data;
        }
    }
}
