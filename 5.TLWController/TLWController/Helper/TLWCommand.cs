﻿#region << 注释 >>
/************************************************************************
*文件名： TLWCommandHelper
*创建人： JIN
*创建时间：2019/5/27 9:30:51
*描述：TLW箱体控制命令
*=======================================================================
*修改时间：2019/5/27 9:30:51
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLWComm;
using TLWController.Events;

namespace TLWController.Helper
{
    public class ReturnParam
    {
        public string IP { get; set; }
        public int Dev { get; set; }
        public int ResultCode { get; set; }
        public byte[] Data { get; set; }
    }

    public class InParam
    {
        public int Dev { get; set; }
        public string IP { get; set; }
        public int Index { get; set; }
        public object[] Params { get; set; }
    }

    public class TLWCommand
    {
        #region 私有属性

        private TLWCommOper _Command = null;

        private string _Path = string.Empty;

        public bool IsOpenDataMonitor = false;

        public int PackageDelay { get; set; }

        public int SendWait { get; set; }

        MonitorCallBackByDevice MonitorDataFunc = null;

        ProgressCallBackByDevice ProgressCallBackFunc = null;

        #endregion

        #region 构造方法
        public TLWCommand()
        {
            MonitorDataFunc = new MonitorCallBackByDevice((int device, int mode, IntPtr data, int len) =>
            {
                if (DataMonitorEvent != null && IsOpenDataMonitor)
                {
                    byte[] bytes = new byte[len];
                    System.Runtime.InteropServices.Marshal.Copy(data, bytes, 0, len);
                    bool IsReceived = mode == 0 ? true : false;
                    DataMonitorEvent(null, new DataMonitorEventArgs() { DeviceNumber = device, IsReceived = IsReceived, Data = bytes });
                }
            });


            ProgressCallBackFunc = new ProgressCallBackByDevice((int device, int percent, string info) =>
           {
               if (ProgressChangedEvent != null)
               {
                   ProgressChangedEvent(null, new ProgressChangedMonitorEventArgs() { DeviceNumber = device, Percent = percent, Message = info });
               }
           });
        }

        #endregion

        #region 事件

        /// <summary>
        /// 数据包监控事件
        /// </summary>
        public event EventHandler<DataMonitorEventArgs> DataMonitorEvent;

        public event EventHandler<ProgressChangedMonitorEventArgs> ProgressChangedEvent;

        #endregion

        #region 辅助方法

        /// <summary>
        /// 触发数据回调事件
        /// </summary>
        /// <param name="deviceNumber">设备号</param>
        /// <param name="isReceived">是否为接收数据</param>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        protected void OnDataSendOrReceived(int deviceNumber, bool isReceived, byte[] data, string message = null)
        {
            if (DataMonitorEvent != null)
            {
                //Delegate[] delegates = DataMonitorEvent.GetInvocationList();
                //if (delegates.Length > 1)
                //{
                //    int hashCode = delegates[0].GetHashCode();
                //    for (int i = 0; i < delegates.Length; i++)
                //    {
                //        if (i != 0 && delegates[i].GetHashCode() == hashCode)
                //            DataMonitorEvent -= (delegates[i] as EventHandler<DataMonitorEventArgs>);
                //    }
                //}
                DataMonitorEvent(this, new DataMonitorEventArgs()
                {
                    DeviceNumber = deviceNumber,
                    Data = data,
                    IsReceived = isReceived
                });
            }
        }

        #endregion

        #region 系统命令初始化

        /// <summary>
        /// 通讯库初始化
        /// </summary>
        /// <param name="path">插件所在路径</param>
        /// <returns></returns>
        public bool Sys_Initial(string path)
        {
            string dllPath = System.IO.Path.Combine(path, "tlw.dll");
            if (System.IO.File.Exists(dllPath) == false)
            {
                return false;
            }
            if (_Command == null)
            {
                _Command = new TLWCommOper(dllPath);
            }
            return _Command.sys_Initial();
        }

        /// <summary>
        /// 通讯库释放资源
        /// </summary>
        public void Sys_Release()
        {
            _Command.sys_Release();
        }

        /// <summary>
        /// 开启&关闭数据监控
        /// </summary>
        /// <param name="device"></param>
        /// <param name="isOpen"></param>
        public void OpenDataMonitor(int device, bool isOpen)
        {
            IsOpenDataMonitor = isOpen;
            _Command.sys_Monitor(device, isOpen ? MonitorDataFunc : null);
        }

        /// <summary>
        /// 多包命令时的包间隔时间
        /// </summary>
        /// <param name="device"></param>
        /// <param name="delay">延时时间(单位:ms)</param>
        public void Sys_PacketDelay(int device, int delay)
        {
            _Command.sys_PacketDelay(device, delay);
        }

        /// <summary>
        /// 多包命令时的发送等待时间
        /// </summary>
        /// <param name="device"></param>
        /// <param name="delay">延时时间(单位:ms)</param>
        public void Sys_SendWait(int device, int delay)
        {
            _Command.sys_SendWait(device, delay);
        }

        /// <summary>
        /// 打开UDP通信
        /// </summary>
        /// <param name="remoteIP">设备IP</param>
        /// <returns></returns>
        public int OpenUDP(string remoteIP)
        {
            int dev = _Command.sys_OpenDev(1, 0, 8001, remoteIP, 115200);
            OpenDataMonitor(dev, IsOpenDataMonitor);
            _Command.sys_SendWait(dev, SendWait);
            _Command.sys_PacketDelay(dev, PackageDelay);

            return dev;
        }

        /// <summary>
        /// 关闭设备
        /// </summary>
        /// <param name="device">设备句柄</param>
        public void Sys_CloseDev(int device)
        {
            _Command.sys_CloseDev(device);
        }

        /// <summary>
        /// 中断当前进行的多包命令操作
        /// </summary>
        /// <param name="device">设备句柄</param>
        public void Sys_Stop(int device)
        {
            _Command.sys_Stop(device);
        }

        public void Sys_WriteLog(bool isWrite)
        {
            _Command.sys_WriteLog(isWrite);
        }

        #endregion

        #region 控制命令

        public void tlw_SetBrightness(ushort addrMB, ushort id, ushort mode, ushort r, ushort g, ushort b, Dictionary<string, int> ips, Action<ReturnParam[]> action)
        {
            Task<ReturnParam[]> task = new Task<ReturnParam[]>(obj =>
            {
                ReturnParam[] returnParam = new ReturnParam[ips.Count];
                int i = 0;
                foreach (var item in ips)
                {
                    new Task((inParam) =>
                    {
                        InParam param = (inParam as InParam);
                        returnParam[param.Index] = new ReturnParam();
                        returnParam[param.Index].IP = param.IP;
                        returnParam[param.Index].Dev = param.Dev;
                        returnParam[param.Index].ResultCode = _Command.tlw_SetBrightness(param.Dev, addrMB, id, mode, r, g, b);
                    },
                    new InParam()
                    {
                        Index = i,
                        IP = item.Key,
                        Dev = item.Value
                    },
                    TaskCreationOptions.AttachedToParent).Start();
                    i++;
                }
                return returnParam;
            }, null);
            task.ContinueWith(t =>
            {
                action(t.Result);
            });
            task.Start();
        }

        /// <summary>
        /// 擦除FLASH
        /// </summary>
        /// <param name="hDevice"></param>
        /// <param name="addrMB"></param>
        /// <param name="id"></param>
        /// <param name="startAddr"></param>
        /// <returns>0 成功 ,其他值 失败</returns>
        private int tlw_FLASH_EraseSector(int hDevice, ushort addrMB, ushort id, byte chipPos, UInt32 startAddr, UInt32 SectorSize, int dataLen)
        {
            int sectorCount = 0;
            if (dataLen % SectorSize == 0)
            {
                sectorCount = (int)(dataLen / SectorSize);
            }
            else
            {
                sectorCount = (int)(dataLen / SectorSize) + 1;
            }
            for (int i = 0; i < sectorCount; i++)
            {
                startAddr += (uint)(i * SectorSize);
                int result = _Command.tlw_FLASH_EraseSector(hDevice, addrMB, id, 0, startAddr);
                if (result != 0)
                {
                    return 1;
                }
            }
            return 0;
        }

        /// <summary>
        /// 写入FLASH
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addrMB">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="startAddr">FLASH地址</param>
        /// <param name="pData">数组指针</param>
        /// <returns>0 成功 ,其他值 失败</returns>
        public void tlw_FLASH_Write(ushort addrMB, ushort id, byte chipPos, UInt32 startAddr, byte[] pData, uint sectorSize, Dictionary<string, int> ips, Action<ReturnParam[]> action)
        {
            Task<ReturnParam[]> task = new Task<ReturnParam[]>(obj =>
            {
                ReturnParam[] returnParam = new ReturnParam[ips.Count];
                int i = 0;
                foreach (var item in ips)
                {
                    new Task((inParam) =>
                    {
                        InParam param = (inParam as InParam);
                        returnParam[param.Index] = new ReturnParam();
                        returnParam[param.Index].IP = param.IP;
                        returnParam[param.Index].Dev = param.Dev;

                        //TODO:暂时不擦出
                        //returnParam[param.Index].ResultCode = tlw_FLASH_EraseSector(param.Dev, addrMB, 0, chipPos, startAddr, sectorSize, pData.Length);
                        returnParam[param.Index].ResultCode = 0;
                        if (returnParam[param.Index].ResultCode == 0)
                        {
                            if (pData.Length <= 1024)
                            {
                                returnParam[param.Index].ResultCode = _Command.tlw_FLASH_Write(param.Dev, addrMB, 0, chipPos, startAddr, pData, 0, pData.Length);
                            }
                            else
                            {
                                returnParam[param.Index].ResultCode = _Command.tlw_FLASH_BatchWrite(param.Dev, addrMB, 0, chipPos, startAddr, pData, 0, pData.Length, ProgressCallBackFunc);
                            }
                        }
                    },
                    new InParam()
                    {
                        Index = i,
                        IP = item.Key,
                        Dev = item.Value
                    },
                    TaskCreationOptions.AttachedToParent).Start();
                    i++;
                }
                return returnParam;
            }, null);
            task.ContinueWith(t =>
            {
                action(t.Result);
            });
            task.Start();
        }

        public void tlw_FLASH_Read(ushort addr, ushort id, byte chipPos, UInt32 startAddr, int dataLen, Dictionary<string, int> ips, Action<ReturnParam[]> action)
        {
            Task<ReturnParam[]> task = new Task<ReturnParam[]>(obj =>
            {
                ReturnParam[] returnParam = new ReturnParam[ips.Count];
                int i = 0;
                foreach (var item in ips)
                {
                    new Task((inParam) =>
                    {
                        InParam param = (inParam as InParam);
                        returnParam[param.Index] = new ReturnParam();
                        returnParam[param.Index].IP = param.IP;
                        returnParam[param.Index].Dev = param.Dev;
                        byte[] pData = new byte[dataLen];
                        if (pData.Length <= 1024)
                        {
                            returnParam[param.Index].ResultCode = _Command.tlw_FLASH_Read(param.Dev, addr, id, chipPos, startAddr, pData, 0, pData.Length);
                        }
                        else
                        {
                            returnParam[param.Index].ResultCode = _Command.tlw_FLASH_BatchRead(param.Dev, addr, id, chipPos, startAddr, pData, 0, pData.Length, ProgressCallBackFunc);
                        }
                        if (returnParam[param.Index].ResultCode == 0)
                        {
                            returnParam[param.Index].Data = pData;
                        }
                    },
                    new InParam()
                    {
                        Index = i,
                        IP = item.Key,
                        Dev = item.Value
                    },
                    TaskCreationOptions.AttachedToParent).Start();
                    i++;
                }
                return returnParam;
            }, null);
            task.ContinueWith(t =>
            {
                action(t.Result);
            });
            task.Start();
        }

        /// <summary>
        /// 数据写入SDRAM
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="startAddr">SDRAM地址</param>
        /// <param name="pData">数组指针</param>
        /// <returns></returns>        
        public void tlw_SDRAM_Write(int hDevice, ushort addr, ushort id, UInt32 startAddr, byte[] pData, Dictionary<string, int> ips, Action<ReturnParam[]> action)
        {
            //return _Command.tlw_SDRAM_Write(hDevice, addr, id, startAddr, pData, offset, pData.Length);

            Task<ReturnParam[]> task = new Task<ReturnParam[]>(obj =>
            {
                ReturnParam[] returnParam = new ReturnParam[ips.Count];
                int i = 0;
                foreach (var item in ips)
                {
                    new Task((inParam) =>
                    {
                        InParam param = (inParam as InParam);
                        returnParam[param.Index] = new ReturnParam();
                        returnParam[param.Index].IP = param.IP;
                        returnParam[param.Index].Dev = param.Dev;

                        if (pData.Length <= 1024)
                        {
                            returnParam[param.Index].ResultCode = _Command.tlw_SDRAM_Write(param.Dev, addr, id, startAddr, pData, 0, pData.Length);
                        }
                        else
                        {
                            returnParam[param.Index].ResultCode = _Command.tlw_SDRAM_BatchWrite(param.Dev, addr, 0, startAddr, pData, 0, pData.Length, ProgressCallBackFunc);
                        }
                    },
                    new InParam()
                    {
                        Index = i,
                        IP = item.Key,
                        Dev = item.Value
                    },
                    TaskCreationOptions.AttachedToParent).Start();
                    i++;
                }
                return returnParam;
            }, null);
            task.ContinueWith(t =>
            {
                action(t.Result);
            });
            task.Start();
        }

        /// <summary>
        /// 将SDRAM数据写入FLASH
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <returns></returns>
        public void tlw_SDRAM_WriteToFLASH(ushort addr, ushort id, Dictionary<string, int> ips, Action<ReturnParam[]> action)
        {
            //return _Command.tlw_SDRAM_WriteToFLASH(hDevice, addr, id);

            Task<ReturnParam[]> task = new Task<ReturnParam[]>(obj =>
            {
                ReturnParam[] returnParam = new ReturnParam[ips.Count];
                int i = 0;
                foreach (var item in ips)
                {
                    new Task((inParam) =>
                    {
                        InParam param = (inParam as InParam);
                        returnParam[param.Index] = new ReturnParam();
                        returnParam[param.Index].IP = param.IP;
                        returnParam[param.Index].Dev = param.Dev;

                        returnParam[param.Index].ResultCode = _Command.tlw_SDRAM_WriteToFLASH(param.Dev, addr, id);

                    },
                    new InParam()
                    {
                        Index = i,
                        IP = item.Key,
                        Dev = item.Value
                    },
                    TaskCreationOptions.AttachedToParent).Start();
                    i++;
                }
                return returnParam;
            }, null);
            task.ContinueWith(t =>
            {
                action(t.Result);
            });
            task.Start();
        }
        #endregion
    }
}