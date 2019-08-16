#region << 注释 >>
/************************************************************************
*文件名： EnumCALType
*创建人： JIN
*创建时间：2019/8/8 10:15:47
*描述：
*=======================================================================
*修改时间：2019/8/8 10:15:47
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFTHelper.Enums
{
    /// <summary>
    /// 校正数据文件类型
    /// </summary>
    public enum EnumCALType
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unkown = 0,
        /// <summary>
        /// 带头数据
        /// </summary>
        Dat = 1,
        /// <summary>
        /// 原始数据
        /// </summary>
        Sdat = 2,
        /// <summary>
        /// 压缩数据
        /// </summary>
        Zdat = 3
    }
}
