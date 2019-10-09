using SFTHelper.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFTHelper.Extentions;
using SFTHelper.Events;
using SFTHelper.Enums;
using System.IO;

namespace TLWCommunicationSharp
{
    public class TLWCommandSharp : PackageBase
    {
        private const int SINGLE_PACKAGE_LENGTH = 1024;
        private bool _logOn = false;
        private bool _showPackage = false;
        private int _packageDelay;
        private int _sendWait;


        public event EventHandler<PackageEventArgs> PackageEvent;

        public event EventHandler<ProgressEventArgs> ProgressEvent;

        public void Sys_LogOn(bool isOn)
        {
            _logOn = isOn;
        }

        public void Sys_ShowPackage(bool isShow)
        {
            _showPackage = isShow;
        }

        public void Sys_PackageDelay(int delay)
        {
            _packageDelay = delay;
        }

        public void Sys_SendWait(int wait)
        {
            _sendWait = wait;
        }

        private List<byte[]> CreatePackage(UInt16 addr, UInt32 header, UInt32 footer, UInt16 id, UInt16 commandId, byte[] data)
        {
            List<byte[]> packageItems = new List<byte[]>();
            if (data != null)
            {
                List<byte[]> dataItems = data.Split(SINGLE_PACKAGE_LENGTH, false, 0x00);
                UInt16 packageNum = 1;
                foreach (var item in dataItems)
                {
                    byte[] packageItem = new byte[25 + item.Length];
                    int position = 0;
                    // 数据包头[0 - 2]    0xAA8E42    3字节，高字节在前
                    Array.Copy(header.GetBytes(), 1, packageItem, 0, 3);
                    position += 3;
                    //数据包总长度(LEN)[3-4] 2字节，高字节在前
                    Array.Copy(((UInt16)packageItem.Length).GetBytes(), 0, packageItem, position, 2);
                    position += 2;
                    //设备地址[5 - 6] 2字节	高字节为地址X,低字节为地址Y
                    Array.Copy(addr.GetBytes(), 0, packageItem, position, 2);
                    position += 2;
                    //数据包识别号[7-8] 2字节,用于识别是哪个设备发出的数据包
                    Array.Copy(id.GetBytes(), 0, packageItem, position, 2);
                    position += 2;
                    //命令号[9 - 10] 2字节 高字节在前   区分不同的命令
                    Array.Copy(commandId.GetBytes(), 0, packageItem, position, 2);
                    position += 2;
                    //预留字段[11 - 14] 4字节 默认为0
                    Array.Copy(((UInt32)0).GetBytes(), 0, packageItem, position, 4);
                    position += 4;
                    //总包数[15-16]	2字节 取值范围1到65535	单包命令默认为1
                    Array.Copy(((UInt16)dataItems.Count).GetBytes(), 0, packageItem, position, 2);
                    position += 2;
                    //当前包序号[17-18] 2字节	取值范围1到65535	单包命令默认为1，序号从1开始计数。
                    Array.Copy(packageNum.GetBytes(), 0, packageItem, position, 2);
                    position += 2;
                    //命令执行结果[19]   1字节
                    //1 =成功
                    //2 = 忙碌中
                    //3 = 未知命令
                    //4 = 校验错误
                    //5 = 长度错误
                    //6 = 地址错误  MCU反馈命令执行情况
                    packageItem[position] = 0;
                    position += 1;
                    //数据段[20到LEN - 6] 
                    //数据段以外的长度为25字节。
                    //可用来保存上位机发给下位机的参数，也可以用来保存下位机返回给上位机的数据。当数据段长度为0时，表示该命令不需要传输数据
                    Array.Copy(item, 0, packageItem, position, item.Length);
                    position += item.Length;
                    //校验码[LEN-5 到LEN-4]	0-65535，高字节在前	采用累加和校验法，将字节序号3到序号(LEN-6)的所有数据相加，取低16位，高8位在前
                    UInt16 checkSum = (UInt16)(packageItem.CheckSumForUInt32(3, packageItem.Length - 6) & 0xFFFF);
                    Array.Copy(checkSum.GetBytes(), 0, packageItem, position, 2);
                    position += 2;
                    //数据包尾[LEN-3到LEN-1]	0x5571BD	3字节，高字节在前
                    Array.Copy(footer.GetBytes(), 1, packageItem, position, 3);
                    position += 2;
                    packageItems.Add(packageItem);
                    packageNum++;
                }
            }
            else
            {
                byte[] packageItem = new byte[25];
                int position = 0;
                // 数据包头[0 - 2]    0xAA8E42    3字节，高字节在前
                Array.Copy(header.GetBytes(), 1, packageItem, 0, 3);
                position += 3;
                //数据包总长度(LEN)[3-4] 2字节，高字节在前
                Array.Copy(((UInt16)packageItem.Length).GetBytes(), 0, packageItem, position, 2);
                position += 2;
                //设备地址[5 - 6] 2字节	高字节为地址X,低字节为地址Y
                Array.Copy(addr.GetBytes(), 0, packageItem, position, 2);
                position += 2;
                //数据包识别号[7-8] 2字节,用于识别是哪个设备发出的数据包
                Array.Copy(id.GetBytes(), 0, packageItem, position, 2);
                position += 2;
                //命令号[9 - 10] 2字节 高字节在前   区分不同的命令
                Array.Copy(commandId.GetBytes(), 0, packageItem, position, 2);
                position += 2;
                //预留字段[11 - 14] 4字节 默认为0
                Array.Copy(((UInt32)0).GetBytes(), 0, packageItem, position, 4);
                position += 4;
                //总包数[15-16]	2字节 取值范围1到65535	单包命令默认为1
                Array.Copy(((UInt16)1).GetBytes(), 0, packageItem, position, 2);
                position += 2;
                //当前包序号[17-18] 2字节	取值范围1到65535	单包命令默认为1，序号从1开始计数。
                Array.Copy(((UInt16)(1)).GetBytes(), 0, packageItem, position, 2);
                position += 2;
                //命令执行结果[19]   1字节
                //1 =成功
                //2 = 忙碌中
                //3 = 未知命令
                //4 = 校验错误
                //5 = 长度错误
                //6 = 地址错误  MCU反馈命令执行情况
                packageItem[position] = 1;
                position += 1;
                //校验码[LEN-5 到LEN-4]	0-65535，高字节在前	采用累加和校验法，将字节序号3到序号(LEN-6)的所有数据相加，取低16位，高8位在前
                UInt16 checkSum = packageItem.CheckSumForUInt16(3, packageItem.Length - 6);
                Array.Copy(checkSum.GetBytes(), 0, packageItem, position, 2);
                position += 2;
                //数据包尾[LEN-3到LEN-1]	0x5571BD	3字节，高字节在前
                Array.Copy(footer.GetBytes(), 1, packageItem, position, 3);
                position += 2;
                packageItems.Add(packageItem);
            }
            return packageItems;
        }

        private bool CheckRevPackage(UInt16 addr, UInt32 header, UInt32 footer, UInt16 id, UInt16 commandId, UInt16 packageCount, UInt16 packageNum, byte[] data)
        {
            bool isPass = true;
            if (data == null) return false;
            if (data.Length != 25) return false;

            UInt32 revHeader = data.GetUInt32(0, 3);
            if (revHeader != header) return false;

            UInt16 revAddr = data.GetUInt16(5);
            if (revAddr != addr) return false;

            UInt16 revId = data.GetUInt16(7);
            if (revId != id) return false;

            UInt16 revcommandId = data.GetUInt16(9);
            if (revcommandId != commandId) return false;

            UInt16 revpackageCount = data.GetUInt16(15);
            if (revpackageCount != packageCount) return false;

            UInt16 revpackageNum = data.GetUInt16(17);
            if (revpackageNum != packageNum) return false;

            UInt16 sum = data.CheckSumForUInt16(3, 17);
            UInt16 sum1 = data.GetUInt16(20);
            if (sum != sum1) return false;

            UInt32 revFooter = data.GetUInt32(22, 3);
            if (revFooter != footer) return false;

            return isPass;
        }

        public int TLW_SetVolumn1(int dev, UInt16 addr, UInt16 id, byte volumn)
        {
            byte[] vol1 = new byte[1];
            vol1[0] = (byte)volumn;
            List<byte[]> sendData = CreatePackage(addr, 0xAA8E42, 0x5571BD, id, 0x0022, vol1);

            int packageCount = sendData.Count;
            int packageNum = 1;
            foreach (var item in sendData)
            {
                if (_showPackage && PackageEvent != null)
                {
                    PackageEvent(this, new PackageEventArgs { Data = item, Dev = dev, PackageFlag = EnumPackageInOut.Input });
                }
                int result = base.Send(dev, item, out byte[] rev);
                if (result == 0 && _showPackage && PackageEvent != null)
                {
                    PackageEvent(this, new PackageEventArgs { Data = rev, Dev = dev, PackageFlag = EnumPackageInOut.Output });
                }
                if (result == 0 && CheckRevPackage(addr, 0xAA8E42, 0x5571BD, id, 0x0022, (ushort)sendData.Count, (ushort)packageNum, item) == false)
                {
                    return -1;
                }
                if (result != 0) return -1;
                if (packageCount > 1 && packageNum != packageCount)
                {
                    System.Threading.Thread.Sleep(_packageDelay);
                }
                packageNum++;
            }
            System.Threading.Thread.Sleep(_sendWait);
            return 0;
        }

        public int TLW_SetVolumn2(int dev, UInt16 addr, UInt16 id, byte volumn)
        {
            byte[] vol1 = new byte[1];
            vol1[0] = (byte)volumn;
            List<byte[]> sendData = CreatePackage(addr, 0xAA8E42, 0x5571BD, id, 0x0023, vol1);

            int packageCount = sendData.Count;
            int packageNum = 1;
            foreach (var item in sendData)
            {
                if (_showPackage && PackageEvent != null)
                {
                    PackageEvent(this, new PackageEventArgs { Data = item, Dev = dev, PackageFlag = EnumPackageInOut.Input });
                }
                int result = base.Send(dev, item, out byte[] rev);
                if (result == 0 && _showPackage && PackageEvent != null)
                {
                    PackageEvent(this, new PackageEventArgs { Data = rev, Dev = dev, PackageFlag = EnumPackageInOut.Output });
                }
                if (result == 0 && CheckRevPackage(addr, 0xAA8E42, 0x5571BD, id, 0x0023, (ushort)sendData.Count, (ushort)packageNum, item) == false)
                {
                    return -1;
                }
                if (result != 0) return -1;
                if (packageCount > 1 && packageNum != packageCount)
                {
                    System.Threading.Thread.Sleep(_packageDelay);
                }
                packageNum++;
            }
            System.Threading.Thread.Sleep(_sendWait);
            return 0;
        }

        public int TLW_SetBrightness(int dev, UInt16 addr, UInt16 id, byte color, ushort red, ushort green, ushort blue)
        {
            ushort commandId = 0x0002;
            byte[] data = new byte[7];
            int offset = 0;
            data[0] = color;
            offset += 1;
            Array.Copy(red.GetBytes(), 0, data, offset, 2);
            offset += 2;
            Array.Copy(green.GetBytes(), 0, data, offset, 2);
            offset += 2;
            Array.Copy(blue.GetBytes(), 0, data, offset, 2);

            List<byte[]> sendData = CreatePackage(addr, 0xAA8E42, 0x5571BD, id, commandId, data);

            int packageCount = sendData.Count;
            int packageNum = 1;
            foreach (var item in sendData)
            {
                if (_showPackage && PackageEvent != null)
                {
                    PackageEvent(this, new PackageEventArgs { Data = item, Dev = dev, PackageFlag = EnumPackageInOut.Input });
                }
                int result = base.Send(dev, item, out byte[] rev);
                if (result == 0 && _showPackage && PackageEvent != null)
                {
                    PackageEvent(this, new PackageEventArgs { Data = rev, Dev = dev, PackageFlag = EnumPackageInOut.Output });
                }
                if (result == 0 && CheckRevPackage(addr, 0xAA8E42, 0x5571BD, id, 0x0022, (ushort)sendData.Count, (ushort)packageNum, item) == false)
                {
                    return -1;
                }
                if (result != 0) return -1;
                if (packageCount > 1 && packageNum != packageCount)
                {
                    System.Threading.Thread.Sleep(_packageDelay);
                }
                packageNum++;
            }
            System.Threading.Thread.Sleep(_sendWait);
            return 0;
        }

        public int TLW_WriteCalibrationFileToSDRAM(int dev, UInt16 addr, UInt16 id, byte chipPos, int mPixelWidth, int mPixelHeight, string file)
        {
            ushort commandId = 0x0006;
            byte[] data = ReadCalibrationData(file, mPixelWidth, mPixelHeight);
            List<byte[]> sendData = CreatePackage(addr, 0xAA8E42, 0x5571BD, id, commandId, data);

            int packageCount = sendData.Count;
            int packageNum = 1;
            foreach (var item in sendData)
            {
                if (_showPackage && PackageEvent != null)
                {
                    PackageEvent(this, new PackageEventArgs { Data = item, Dev = dev, PackageFlag = EnumPackageInOut.Input });
                }
                int result = base.Send(dev, item, out byte[] rev);
                if (result == 0 && _showPackage && PackageEvent != null)
                {
                    PackageEvent(this, new PackageEventArgs { Data = rev, Dev = dev, PackageFlag = EnumPackageInOut.Output });
                }
                if (result == 0 && CheckRevPackage(addr, 0xAA8E42, 0x5571BD, id, 0x0022, (ushort)sendData.Count, (ushort)packageNum, item) == false)
                {
                    return -1;
                }
                if (result != 0) return -1;
                if (packageCount > 1 && packageNum != packageCount)
                {
                    System.Threading.Thread.Sleep(_packageDelay);
                }
                packageNum++;
            }
            System.Threading.Thread.Sleep(_sendWait);
            return 0;
        }

        #region 辅助方法

        private byte[] ReadCalibrationData(string file, int mPixelWidth, int mPixelHeight)
        {
            int len = mPixelWidth * mPixelHeight * 16;
            FileStream fsIn = new FileStream(file, FileMode.Open);
            if (fsIn.Length != len)
            {
                return null;
            }
            byte[] outData = new byte[len];
            //读取整个文件
            if (fsIn.Read(outData, 0, outData.Length) != outData.Length)
            {
                fsIn.Close();
                return null;
            }
            fsIn.Close();//关闭文件
            return outData;
        }

        #endregion
    }
}
