#region << 注释 >>
/************************************************************************
*文件名： PackageEvent
*创建人： JIN
*创建时间：2019/8/27 10:30:53
*描述：
*=======================================================================
*修改时间：2019/8/27 10:30:53
*修改人：
*描述：
************************************************************************/
#endregion

using SFTHelper.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFTHelper.Events
{
    public class PackageEventArgs : EventArgs
    {
        public int Dev { get; set; }
        public byte[] Data { get; set; }
        public EnumPackageInOut PackageFlag { get; set; }
    }

    public class ProgressEventArgs : EventArgs
    {
        public int DeviceNumber { get; set; }
        public int Percent { get; set; }
        public string Message { get; set; }
    }


}
