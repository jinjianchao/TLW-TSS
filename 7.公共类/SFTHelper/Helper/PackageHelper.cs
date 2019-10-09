#region << 注释 >>
/************************************************************************
*文件名： UDPHelper
*创建人： JIN
*创建时间：2019/8/26 15:01:01
*描述：
*=======================================================================
*修改时间：2019/8/26 15:01:01
*修改人：
*描述：
************************************************************************/
#endregion

using SFTHelper.Enums;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using SFTHelper.Extentions;

namespace SFTHelper.Helper
{
    abstract class BasePackageHelper
    {
        public virtual bool Open(string remote, int remotePort)
        {
            return false;
        }

        public virtual void Close(int dev)
        {

        }

        public virtual bool Send(byte[] datas, out byte[] receive)
        {
            receive = null;
            return false;
        }
    }

    class UDPPackageHelper : BasePackageHelper
    {
        private UdpClient udpClient = new UdpClient(0);
        private IPEndPoint RemoteIpEndPoint = null;

        public override bool Open(string remote, int remotePort)
        {
            udpClient.Client.ReceiveTimeout = 5000;
            udpClient.Connect(remote, remotePort);
            RemoteIpEndPoint = new IPEndPoint(IPAddress.Parse(remote), remotePort);
            return true;
        }

        public override void Close(int dev)
        {
            RemoteIpEndPoint = null;
            udpClient.Close();
            udpClient = null;
        }

        public override bool Send(byte[] data, out byte[] receive)
        {
            receive = null;
            try
            {
                udpClient.Send(data, data.Length);
                System.Threading.Thread.Sleep(100);
                receive = udpClient.Receive(ref RemoteIpEndPoint);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }

    public abstract class PackageBase
    {

        private Dictionary<int, BasePackageHelper> _items;

        public void Sys_Initial()
        {
            _items = new Dictionary<int, BasePackageHelper>();
        }

        public int Sys_Open(EnumCommType commType, string target, int port)
        {
            int dev = 0;
            if (commType == EnumCommType.UDP)
            {
                UDPPackageHelper packageHelper = new UDPPackageHelper();
                dev = FreePortHelper.GetFirstAvailablePort();
                if (_items.ContainsKey(dev) == true)
                {
                    return -1;
                }
                if (packageHelper.Open(target, port) == false) return -1;
                _items.Add(dev, packageHelper);
            }
            else
            {
                return -1;
            }
            return dev;
        }

        public void Sys_Close(int dev)
        {
            if (_items.ContainsKey(dev) == false)
            {
                return;
            }
            _items[dev].Close(dev);
            _items.Remove(dev);
        }

        protected virtual int Send(int dev, byte[] data, out byte[] rev)
        {
            rev = null;
            if (!_items.ContainsKey(dev)) return -1;
            if (_items[dev].Send(data, out rev) == false) return -1;
            return 0;
        }

    }
}
