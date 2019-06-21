#region << 注释 >>
/************************************************************************
*文件名： NetworkValidateHelper
*创建人： JIN
*创建时间：2019/6/21 13:31:45
*描述：
*=======================================================================
*修改时间：2019/6/21 13:31:45
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace TLWController.Helper
{
    public class NetworkValidateHelper
    {
        /// <summary>
        /// 根据掩码判断两个IP是否为同一个网络
        /// </summary>
        /// <param name="ip1">IP1</param>
        /// <param name="ip2">IP2</param>
        /// <param name="mask">掩码</param>
        /// <returns></returns>
        public static bool IsSameNetwork(string ip1, string ip2, string mask)
        {
            IPAddress ipAddress1 = null;
            IPAddress ipAddress2 = null;
            IPAddress netMask = null;
            if (IsIPAddress(ip1, out ipAddress1) &&
                IsIPAddress(ip2, out ipAddress2) &&
                IsIPAddress(mask, out netMask))
            {
                return NetworkId(ipAddress1, netMask).Equals(NetworkId(ipAddress2, netMask));
            }
            return false;
        }

        /// <summary>
        /// 根据掩码及IP获取网络号
        /// </summary>
        /// <param name="ipAddress">IP地址</param>
        /// <param name="netMask">子网掩码</param>
        /// <returns>子网号</returns>
        protected static IPAddress NetworkId(IPAddress ipAddress, IPAddress netMask)
        {
            byte[] networkId = new byte[4];
            byte[] ipBytes = ipAddress.GetAddressBytes();
            byte[] maskBytes = netMask.GetAddressBytes();
            for (byte i = 0; i < 4; i++)
            {
                networkId[i] = (byte)(ipBytes[i] & maskBytes[i]);
            }
            return new IPAddress(networkId);
        }

        /// <summary>
        /// 判断字符串是否为IP地址
        /// </summary>
        /// <param name="ipString">IP字符串</param>
        /// <returns></returns>
        public static bool IsIPAddress(string ipString, out IPAddress ipAddress)
        {
            IPAddress address = null;
            bool mark = IPAddress.TryParse(ipString, out address);
            ipAddress = address ?? IPAddress.Parse("0.0.0.0");
            return mark;
        }
    }
}
