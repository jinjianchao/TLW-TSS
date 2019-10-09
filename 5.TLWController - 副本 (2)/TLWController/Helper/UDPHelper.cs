#region << 注释 >>
/************************************************************************
*文件名： UDPHelper
*创建人： JIN
*创建时间：2019/5/30 13:43:19
*描述：
*=======================================================================
*修改时间：2019/5/30 13:43:19
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TLWController.Helper
{
    public class UDPHelper
    {
        public static int Send(byte[] sendBytes, string remoteIP, out byte[] receiveBytes, int delay = 200)
        {
            UdpClient udpClient = new UdpClient(0);
            try
            {
                udpClient.Client.ReceiveTimeout = 2000;
                udpClient.Connect(remoteIP, 8001);
                udpClient.Send(sendBytes, sendBytes.Length);
                //System.Threading.Thread.Sleep(100);
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Parse(remoteIP), 8001);
                receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                udpClient.Close();
            }
            catch (Exception e)
            {
                receiveBytes = null;
                return 0;
            }
            return receiveBytes.Length;
        }
    }
}
