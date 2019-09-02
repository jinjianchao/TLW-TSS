#region << 注释 >>
/************************************************************************
*文件名： NetworkHelper
*创建人： JIN
*创建时间：2019/8/30 9:39:36
*描述：
*=======================================================================
*修改时间：2019/8/30 9:39:36
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFTHelper.Helper
{
    public class NetworkHelper
    {
        public static bool Ping(string ip)
        {
            System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply reply = pingSender.Send(ip, 120);
            if(reply.Status==System.Net.NetworkInformation.IPStatus.Success)
            {
                return true;
            }
            return false;
        }
    }
}
