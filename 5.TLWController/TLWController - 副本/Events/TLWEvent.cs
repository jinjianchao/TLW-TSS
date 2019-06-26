#region << 注释 >>
/************************************************************************
*文件名： TLWEvent
*创建人： JIN
*创建时间：2019/5/27 9:53:34
*描述：
*=======================================================================
*修改时间：2019/5/27 9:53:34
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TLWComm;

namespace TLWController.Events
{
    public class DataMonitorEventArgs : EventArgs
    {
        public int DeviceNumber { get; set; }
        public byte[] Data { get; set; }
        public bool IsReceived { get; set; }
    }

    public class ProgressChangedMonitorEventArgs : EventArgs
    {
        public int DeviceNumber { get; set; }
        public int Percent { get; set; }
        public string Message { get; set; }
    }
}
