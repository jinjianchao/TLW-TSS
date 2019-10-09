#region << 注释 >>
/************************************************************************
*文件名： EnumCALTarget
*创建人： JIN
*创建时间：2019/8/9 14:49:23
*描述：
*=======================================================================
*修改时间：2019/8/9 14:49:23
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace SFTHelper.Enums
{
    /// <summary>
    /// 校正数据类别（箱体数据，灯板数据）
    /// </summary>
    public enum EnumCALTarget
    {
        /// <summary>
        /// 箱体
        /// </summary>
        Cabinet = 0,
        /// <summary>
        /// 模组
        /// </summary>
        Module = 1
    }
}
