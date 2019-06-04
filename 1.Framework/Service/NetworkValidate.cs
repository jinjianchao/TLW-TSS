using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace LYDTOPDP
{
    /// <summary>
    /// 子网验证
    /// </summary>
    public class NetworkValidate
    {
        /// <summary>
        /// 根据掩码判断两个IP是否为同一个网络
        /// </summary>
        /// <param name="ip1">IP1</param>
        /// <param name="ip2">IP2</param>
        /// <param name="mask">掩码</param>
        /// <returns></returns>
        public bool IsSameNetwork(string ip1, string ip2, string mask)
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
        protected IPAddress NetworkId(IPAddress ipAddress, IPAddress netMask)
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
        public bool IsIPAddress(string ipString, out IPAddress ipAddress)
        {
            IPAddress address = null;
            bool mark = IPAddress.TryParse(ipString, out address);
            ipAddress = address ?? IPAddress.Parse("0.0.0.0");
            return mark;
        }

        public bool ValidateIPAddress(string ipAddress)
        {
            Regex validipregex = new Regex(@"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$");
            return (ipAddress != "" && validipregex.IsMatch(ipAddress.Trim())) ? true : false;
        }

        public bool IsSameNetwork(string ip1, string ip2)
        {
            if (!ValidateIPAddress(ip1)) return false;
            if (!ValidateIPAddress(ip2)) return false;
            string sub1 = ip1.Substring(0, ip1.LastIndexOf('.'));
            string sub2 = ip2.Substring(0, ip2.LastIndexOf('.'));
            if (sub1 != sub2) return false;
            return true;
        }
    }
}
