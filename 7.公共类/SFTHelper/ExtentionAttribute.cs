#region << 注释 >>
/************************************************************************
*文件名： ExtentionAttribute
*创建人： JIN
*创建时间：2019/9/11 13:37:57
*描述：
*=======================================================================
*修改时间：2019/9/11 13:37:57
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly)]
    public sealed class ExtensionAttribute : Attribute { }
}