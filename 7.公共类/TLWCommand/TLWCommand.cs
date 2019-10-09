using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLWComm;
using TLWCommunication.Events;

namespace TLWCommunication
{
    public class ReturnParam
    {
        public string IP { get; set; }
        public int Dev { get; set; }
        public int ResultCode { get; set; }
        public object Data { get; set; }
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

        #region 异步执行

        //public void tlw_SetBrightness(ushort addrMB, ushort id, ushort mode, ushort r, ushort g, ushort b, Dictionary<string, int> ips, Action<ReturnParam[]> action)
        //{
        //    Task<ReturnParam[]> task = new Task<ReturnParam[]>(obj =>
        //    {
        //        ReturnParam[] returnParam = new ReturnParam[ips.Count];
        //        int i = 0;
        //        foreach (var item in ips)
        //        {
        //            new Task((inParam) =>
        //            {
        //                InParam param = (inParam as InParam);
        //                returnParam[param.Index] = new ReturnParam();
        //                returnParam[param.Index].IP = param.IP;
        //                returnParam[param.Index].Dev = param.Dev;
        //                returnParam[param.Index].ResultCode = _Command.tlw_SetBrightness(param.Dev, addrMB, id, mode, r, g, b);
        //            },
        //            new InParam()
        //            {
        //                Index = i,
        //                IP = item.Key,
        //                Dev = item.Value
        //            },
        //            TaskCreationOptions.AttachedToParent).Start();
        //            i++;
        //        }
        //        return returnParam;
        //    }, null);
        //    task.ContinueWith(t =>
        //    {
        //        action(t.Result);
        //    });
        //    task.Start();
        //}

        /// <summary>
        /// 写入FLASH
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addrMB">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="startAddr">FLASH地址</param>
        /// <param name="pData">数组指针</param>
        /// <returns>0 成功 ,其他值 失败</returns>
        //public void tlw_FLASH_Write(ushort addrMB, ushort id, byte chipPos, UInt32 startAddr, byte[] pData, uint sectorSize, Dictionary<string, int> ips, Action<ReturnParam[]> action)
        //{
        //    Task<ReturnParam[]> task = new Task<ReturnParam[]>(obj =>
        //    {
        //        ReturnParam[] returnParam = new ReturnParam[ips.Count];
        //        int i = 0;
        //        foreach (var item in ips)
        //        {
        //            new Task((inParam) =>
        //            {
        //                InParam param = (inParam as InParam);
        //                returnParam[param.Index] = new ReturnParam();
        //                returnParam[param.Index].IP = param.IP;
        //                returnParam[param.Index].Dev = param.Dev;

        //                //TODO:暂时不擦出
        //                //returnParam[param.Index].ResultCode = tlw_FLASH_EraseSector(param.Dev, addrMB, 0, chipPos, startAddr, sectorSize, pData.Length);
        //                returnParam[param.Index].ResultCode = 0;
        //                if (returnParam[param.Index].ResultCode == 0)
        //                {
        //                    if (pData.Length <= 1024)
        //                    {
        //                        returnParam[param.Index].ResultCode = _Command.tlw_FLASH_Write(param.Dev, addrMB, 0, chipPos, startAddr, pData, 0, pData.Length);
        //                    }
        //                    else
        //                    {
        //                        returnParam[param.Index].ResultCode = _Command.tlw_FLASH_BatchWrite(param.Dev, addrMB, 0, chipPos, startAddr, pData, 0, pData.Length, ProgressCallBackFunc);

        //                        int count = pData.Length / 1024;
        //                        for (int j = 0; j < count; j++)
        //                        {
        //                            byte[] tmpData = new byte[1024];
        //                            Array.Copy(pData, j * 1024, tmpData, 0, 1024);
        //                            returnParam[param.Index].ResultCode = _Command.tlw_FLASH_Write(param.Dev, addrMB, 0, chipPos, (uint)(startAddr + j * 1024), tmpData, 0, tmpData.Length);
        //                            int percent = (j + 1) / count * 100;
        //                            ProgressCallBackFunc(param.Dev, percent, $"{j + 1}/{count}");
        //                            System.Threading.Thread.Sleep(100);
        //                        }
        //                    }
        //                }
        //            },
        //            new InParam()
        //            {
        //                Index = i,
        //                IP = item.Key,
        //                Dev = item.Value
        //            },
        //            TaskCreationOptions.AttachedToParent).Start();
        //            i++;
        //        }
        //        return returnParam;
        //    }, null);
        //    task.ContinueWith(t =>
        //    {
        //        action(t.Result);
        //    });
        //    task.Start();
        //}

        //public void tlw_FLASH_Read(ushort addr, ushort id, byte chipPos, UInt32 startAddr, int dataLen, Dictionary<string, int> ips, Action<ReturnParam[]> action)
        //{
        //    Task<ReturnParam[]> task = new Task<ReturnParam[]>(obj =>
        //    {
        //        ReturnParam[] returnParam = new ReturnParam[ips.Count];
        //        int i = 0;
        //        foreach (var item in ips)
        //        {
        //            new Task((inParam) =>
        //            {
        //                InParam param = (inParam as InParam);
        //                returnParam[param.Index] = new ReturnParam();
        //                returnParam[param.Index].IP = param.IP;
        //                returnParam[param.Index].Dev = param.Dev;
        //                byte[] pData = new byte[dataLen];
        //                if (pData.Length <= 1024)
        //                {
        //                    returnParam[param.Index].ResultCode = _Command.tlw_FLASH_Read(param.Dev, addr, id, chipPos, startAddr, pData, 0, pData.Length);
        //                }
        //                else
        //                {
        //                    returnParam[param.Index].ResultCode = _Command.tlw_FLASH_BatchRead(param.Dev, addr, id, chipPos, startAddr, pData, 0, pData.Length, ProgressCallBackFunc);
        //                }
        //                if (returnParam[param.Index].ResultCode == 0)
        //                {
        //                    returnParam[param.Index].Data = pData;
        //                }
        //            },
        //            new InParam()
        //            {
        //                Index = i,
        //                IP = item.Key,
        //                Dev = item.Value
        //            },
        //            TaskCreationOptions.AttachedToParent).Start();
        //            i++;
        //        }
        //        return returnParam;
        //    }, null);
        //    task.ContinueWith(t =>
        //    {
        //        action(t.Result);
        //    });
        //    task.Start();
        //}

        /// <summary>
        /// 写入MAP数据
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="src">MAP数据数组</param>
        /// <param name="offset">数据偏移量</param>
        /// <param name="nLen">数据长度,默认为4096</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        //public void tlw_WriteMAP(ushort addr, ushort id, byte[] src, Dictionary<string, int> ips, Action<ReturnParam[]> action)
        //{
        //    Task<ReturnParam[]> task = new Task<ReturnParam[]>(obj =>
        //    {
        //        ReturnParam[] returnParam = new ReturnParam[ips.Count];
        //        int i = 0;
        //        foreach (var item in ips)
        //        {
        //            new Task((inParam) =>
        //            {
        //                InParam param = (inParam as InParam);
        //                returnParam[param.Index] = new ReturnParam();
        //                returnParam[param.Index].IP = param.IP;
        //                returnParam[param.Index].Dev = param.Dev;
        //                returnParam[param.Index].ResultCode = _Command.tlw_WriteMAP(param.Dev, addr, id, src, 0, src.Length);
        //                _Command.sys_PacketDelay(param.Dev, 1);
        //            },
        //            new InParam()
        //            {
        //                Index = i,
        //                IP = item.Key,
        //                Dev = item.Value
        //            },
        //            TaskCreationOptions.AttachedToParent).Start();
        //            i++;
        //        }
        //        return returnParam;
        //    }, null);
        //    task.ContinueWith(t =>
        //    {
        //        action(t.Result);
        //    });
        //    task.Start();
        //}

        /// <summary>
        /// 读取MAP数据
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="src">MAP数据数组</param>
        /// <param name="offset">数据偏移量</param>
        /// <param name="nLen">数据长度,默认为4096</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        //public void tlw_ReadMAP(ushort addr, ushort id, Dictionary<string, int> ips, Action<ReturnParam[]> action)
        //{
        //    Task<ReturnParam[]> task = new Task<ReturnParam[]>(obj =>
        //    {
        //        ReturnParam[] returnParam = new ReturnParam[ips.Count];
        //        int i = 0;
        //        foreach (var item in ips)
        //        {
        //            new Task((inParam) =>
        //            {
        //                InParam param = (inParam as InParam);
        //                returnParam[param.Index] = new ReturnParam();
        //                returnParam[param.Index].IP = param.IP;
        //                returnParam[param.Index].Dev = param.Dev;
        //                byte[] pData = new byte[4096];
        //                returnParam[param.Index].ResultCode = _Command.tlw_ReadMAP(param.Dev, addr, id, pData, 0, pData.Length);
        //                if (returnParam[param.Index].ResultCode == 0)
        //                {
        //                    returnParam[param.Index].Data = pData;
        //                }
        //            },
        //            new InParam()
        //            {
        //                Index = i,
        //                IP = item.Key,
        //                Dev = item.Value
        //            },
        //            TaskCreationOptions.AttachedToParent).Start();
        //            i++;
        //        }
        //        return returnParam;
        //    }, null);
        //    task.ContinueWith(t =>
        //    {
        //        action(t.Result);
        //    });
        //    task.Start();
        //}

        /// <summary>
        /// 数据写入SDRAM
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="startAddr">SDRAM地址</param>
        /// <param name="pData">数组指针</param>
        /// <returns></returns>        
        public void tlw_SDRAM_Write(ushort addr, ushort id, UInt32 startAddr, byte[] pData, Dictionary<string, int> ips, Action<ReturnParam[]> action)
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

                            //startAddr = 0x1e0000;
                            //for (int j = 0; j < 216; j++)
                            //{
                            //    returnParam[param.Index].ResultCode = _Command.tlw_SDRAM_BatchWrite(param.Dev, addr, 0, startAddr, pData, 0, pData.Length, ProgressCallBackFunc);
                            //    startAddr += 4096;
                            //}


                            //for (int j = 0; j < pData.Length / 1024; i++)
                            //{
                            //    byte[] data = new byte[1024];
                            //    Array.Copy(pData, i * 1024, data, 0, 1024);
                            //    returnParam[param.Index].ResultCode = _Command.tlw_SDRAM_Read(param.Dev, addr, id, startAddr, data, 0, pData.Length);
                            //    addr += 1024;
                            //}
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
        /// 读取SDRAM数据
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="startAddr">SDRAM地址</param>
        /// <param name="pData">数据指针，指向数据保存的地方</param>
        /// <param name="offset">数组内偏移量</param>
        /// <param name="len">待读取的数据长度,必须为1024</param>
        /// <returns></returns>

        public void tlw_SDRAM_Read(ushort addr, ushort id, UInt32 startAddr, int len, Dictionary<string, int> ips, Action<ReturnParam[]> action)
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
                        byte[] pData = new byte[len];
                        if (pData.Length <= 1024)
                        {
                            returnParam[param.Index].ResultCode = _Command.tlw_SDRAM_Read(param.Dev, addr, id, startAddr, pData, 0, pData.Length);
                        }
                        else
                        {
                            returnParam[param.Index].ResultCode = _Command.tlw_SDRAM_BatchRead(param.Dev, addr, id, startAddr, pData, 0, pData.Length, ProgressCallBackFunc);

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

        /// <summary>
        /// 写入GAMMA数据
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="mode">0 = 10bit GAMMA, 1024个16bit数据,1 = 13bit GAMMA, 4096个16bit数据,2=16bit GAMMA, 32768个16bit数据,3 = HDR, 1024个16bit数据</param>
        /// <param name="color">0 = 全部颜色,1 = 红色,2 = 绿色,3 = 蓝色</param>
        /// <param name="src">GAMMA数据数组</param>
        /// <param name="offset">偏移量</param>
        /// <param name="len">需要保存到数组的长度</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        //public void tlw_WriteGAMMA(ushort addr, ushort id, byte mode, byte color, byte[] src, Dictionary<string, int> ips, Action<ReturnParam[]> action)
        //{
        //    //return _Command.tlw_SDRAM_WriteToFLASH(hDevice, addr, id);

        //    Task<ReturnParam[]> task = new Task<ReturnParam[]>(obj =>
        //    {
        //        ReturnParam[] returnParam = new ReturnParam[ips.Count];
        //        int i = 0;
        //        foreach (var item in ips)
        //        {
        //            new Task((inParam) =>
        //            {
        //                InParam param = (inParam as InParam);
        //                returnParam[param.Index] = new ReturnParam();
        //                returnParam[param.Index].IP = param.IP;
        //                returnParam[param.Index].Dev = param.Dev;
        //                if (color == 0)
        //                {
        //                    returnParam[param.Index].ResultCode = _Command.tlw_WriteGAMMA(param.Dev, addr, id, mode, 1, src, 0, src.Length);
        //                    if (returnParam[param.Index].ResultCode == 0) returnParam[param.Index].ResultCode = _Command.tlw_WriteGAMMA(param.Dev, addr, id, mode, 2, src, 0, src.Length);
        //                    if (returnParam[param.Index].ResultCode == 0) returnParam[param.Index].ResultCode = _Command.tlw_WriteGAMMA(param.Dev, addr, id, mode, 3, src, 0, src.Length);
        //                }
        //                else
        //                {
        //                    returnParam[param.Index].ResultCode = _Command.tlw_WriteGAMMA(param.Dev, addr, id, mode, color, src, 0, src.Length);
        //                }
        //            },
        //            new InParam()
        //            {
        //                Index = i,
        //                IP = item.Key,
        //                Dev = item.Value
        //            },
        //            TaskCreationOptions.AttachedToParent).Start();
        //            i++;
        //        }
        //        return returnParam;
        //    }, null);
        //    task.ContinueWith(t =>
        //    {
        //        action(t.Result);
        //    });
        //    task.Start();
        //}

        /// <summary>
        /// 读取GAMMA数据
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="mode">0 = 10bit GAMMA, 1024个16bit数据,1 = 13bit GAMMA, 4096个16bit数据,2=16bit GAMMA, 32768个16bit数据,3 = HDR, 1024个16bit数据</param>
        /// <param name="color">1 = 红色,2 = 绿色,3 = 蓝色</param>
        /// <param name="src">GAMMA数据数组</param>
        /// <param name="offset">偏移量</param>
        /// <param name="len">需要保存到数组的长度</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public void tlw_ReadGAMMA(ushort addr, ushort id, byte mode, byte color, int readLen, Dictionary<string, int> ips, Action<ReturnParam[]> action)
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

                        byte[] pData = new byte[readLen];
                        returnParam[param.Index].ResultCode = _Command.tlw_ReadGAMMA(param.Dev, addr, id, mode, color, pData, 0, pData.Length);
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
        /// 写入寄存器数组
        /// </summary>
        /// <param name="hDevice">hDevice 设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="chip"> 0 FPGA  1 4K视频芯片</param>
        /// <param name="src">数据数组指针</param>
        /// <param name="offset">偏移量</param>
        /// <param name="len">数据长度</param>
        /// <param name="bSave">是否保存 TRUE 保存  FALSE 不保存</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public void tlw_WriteRegisterGroup(ushort addr, ushort id, byte chip, byte[] src, bool bSave, Dictionary<string, int> ips, Action<ReturnParam[]> action)
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
                        returnParam[param.Index].ResultCode = _Command.tlw_WriteRegisterGroup(param.Dev, addr, id, chip, src, 0, src.Length, bSave);
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
        /// 读取寄存器数组
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="chip">0 FPGA  1 4K视频芯片</param>
        /// <param name="src">数据数组指针</param>
        /// <param name="offset">偏移量</param>
        /// <param name="len">数据长度</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public void tlw_ReadRegisterGroup(ushort addr, ushort id, byte chip, int readLen, Dictionary<string, int> ips, Action<ReturnParam[]> action)
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

                        byte[] pData = new byte[readLen];
                        returnParam[param.Index].ResultCode = _Command.tlw_ReadRegisterGroup(param.Dev, addr, id, chip, pData, 0, pData.Length);
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
        /// 写入单个寄存器值
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="chip">0 FPGA  1 4K视频芯片</param>
        /// <param name="regAddr">寄存器地址</param>
        /// <param name="regVal">寄存器数值</param>
        /// <param name="bSave">是否保存 TRUE 保存  FALSE 不保存</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public void tlw_WriteRegister(ushort addr, ushort id, byte chip, UInt32 regAddr, UInt32 regVal, bool bSave, Dictionary<string, int> ips, Action<ReturnParam[]> action)
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
                        returnParam[param.Index].ResultCode = _Command.tlw_WriteRegister(param.Dev, addr, id, chip, regAddr, regVal, bSave);
                        _Command.tlw_WriteRegister(param.Dev, addr, id, chip, 0x84, 1, true);
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
        /// 读取单个寄存器值
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="chip">0 FPGA  1 4K视频芯片</param>
        /// <param name="regAddr">寄存器地址</param>
        /// <param name="regVal">返回寄存器数值</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public void tlw_ReadRegister(ushort addr, ushort id, byte chip, UInt32 regAddr, Dictionary<string, int> ips, Action<ReturnParam[]> action)
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

                        UInt32[] pData = new UInt32[1];
                        returnParam[param.Index].ResultCode = _Command.tlw_ReadRegister(param.Dev, addr, id, chip, regAddr, pData);
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
        /// 写入韧件程序
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="chip">哪个芯片 默认为0   1为从芯片</param>
        /// <param name="mode"> 0 MCU韧件程序 , 1 FPGA韧件程序</param>
        /// <param name="path">文件路径</param>
        /// <param name="func">进度回调函数</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public void tlw_Firmware_Write(ushort addr, ushort id, byte chip, byte mode, string path, Dictionary<string, int> ips, Action<ReturnParam[]> action)
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
                        returnParam[param.Index].ResultCode = _Command.tlw_Firmware_Write(param.Dev, addr, id, chip, mode, path, ProgressCallBackFunc);
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
        /// 读取韧件程序
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="chip">哪个芯片 默认为0   1为从芯片</param>
        /// <param name="mode">0 MCU韧件程序 , 1 FPGA韧件程序</param>
        /// <param name="dataLen">韧件程序的大小，一般为1024的倍数</param>
        /// <param name="path">保存文件路径</param>
        /// <param name="func">进度回调函数</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public void tlw_Firmware_Read(ushort addr, ushort id, byte chip, byte mode, int dataLen, string path, Dictionary<string, int> ips, Action<ReturnParam[]> action)
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
                        returnParam[param.Index].ResultCode = _Command.tlw_Firmware_Read(param.Dev, addr, id, chip, mode, dataLen, path, ProgressCallBackFunc);
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
        /// 读取韧件程序版本号
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="chip">哪个芯片 默认为0   1为从芯片</param>
        /// <param name="mode">0 MCU韧件程序版本 , 1 FPGA韧件程序版本</param>
        /// <param name="dst">获取版本信息保存的数组指针</param>
        /// <param name="offset">数组内偏移量</param>
        /// <param name="nLen">数据长度,默认为4</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public void tlw_GetVersion(ushort addr, ushort id, byte chip, byte mode, Dictionary<string, int> ips, Action<ReturnParam[]> action)
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

                        byte[] pData = new byte[4];
                        returnParam[param.Index].ResultCode = _Command.tlw_GetVersion(param.Dev, addr, id, chip, mode, pData, 0, pData.Length);
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
        /// 视频卡加载参数
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="mode">表示加载的内容 0 全部加载 1校正数据 2 红色GAMMA 3绿色GAMMA 4蓝色GAMMA 5 MAP  6 寄存器数组1  7 寄存器数组2</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public void tlw_ConnectCardLoadParam(ushort addr, ushort id, byte mode, Dictionary<string, int> ips, Action<ReturnParam[]> action)
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
                        returnParam[param.Index].ResultCode = _Command.tlw_ConnectCardLoadParam(param.Dev, addr, id, mode);
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
        /// 设置网络参数
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="dat">数据数组</param>
        /// <param name="offset">偏移量</param>
        /// <param name="nLen">长度为12，分别是IP地址，子网掩码，网关地址各占4字节</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public void tlw_SetNetworkParam(ushort addr, ushort id, byte[] dat, Dictionary<string, int> ips, Action<ReturnParam[]> action)
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
                        returnParam[param.Index].ResultCode = _Command.tlw_SetNetworkParam(param.Dev, addr, id, dat, 0, dat.Length);
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
        /// 设置灯板校正数据长度
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="dwLen">灯板校正数据长度</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public void tlw_WriteCalibrationFileLength(ushort addr, ushort id, UInt32 dwLen, Dictionary<string, int> ips, Action<ReturnParam[]> action)
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
                        returnParam[param.Index].ResultCode = _Command.tlw_WriteCalibrationFileLength(param.Dev, addr, id, dwLen);
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
        /// 设置显示工装模式
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="mode">显示模式0 = 视频，0x80=工装白，0x81=工装黑，0x82=工装蓝，0x83=工装绿，0x84=工装红，0x85=灰度渐变，0x86=低灰度渐变，0x87=斜线</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public void tlw_SetDisplayMode(ushort addr, ushort id, byte mode, Dictionary<string, int> ips, Action<ReturnParam[]> action)
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
                        returnParam[param.Index].ResultCode = _Command.tlw_SetDisplayMode(param.Dev, addr, id, mode);
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
        /// 设置校正开关
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="mode">0=校正关闭  1=校正打开</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public void tlw_SetCalibrationONOFF(ushort addr, ushort id, byte mode, Dictionary<string, int> ips, Action<ReturnParam[]> action)
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
                        returnParam[param.Index].ResultCode = _Command.tlw_SetCalibrationONOFF(param.Dev, addr, id, mode);
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

        #region 同步执行

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
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="chipPos">芯片位置 0默认位置  1连接卡FLASH  2上方灯板FLASH  3下方灯板FLASH</param>
        /// <param name="startAddr">FLASH地址</param>
        /// <param name="pData">数组指针</param>
        /// <param name="offset">数组内偏移</param>
        /// <param name="len">写入的数据量,默认1024</param>
        /// <returns>0 成功 ,其他值 失败</returns>
        public int tlw_FLASH_Write(int device, ushort addrMB, ushort id, byte chipPos, UInt32 startAddr, byte[] pData, uint sectorSize)
        {
            int result = 0;
            if (pData.Length <= 1024)
            {
                result = _Command.tlw_FLASH_Write(device, addrMB, 0, chipPos, startAddr, pData, 0, pData.Length);
            }
            else
            {
                result = _Command.tlw_FLASH_BatchWrite(device, addrMB, 0, chipPos, startAddr, pData, 0, pData.Length, ProgressCallBackFunc);
            }
            return result;
        }

        public int tlw_FLASH_Read(int device, ushort addrMB, ushort id, byte chipPos, UInt32 startAddr, byte[] pData, uint sectorSize)
        {
            //int result = 0;
            //if (pData.Length <= 1024)
            //{
            //    result = _Command.tlw_FLASH_Read(device, addrMB, id, chipPos, startAddr, pData, 0, pData.Length);
            //}
            //else
            //{
            //    result = _Command.tlw_FLASH_BatchRead(device, addrMB, id, chipPos, startAddr, pData, 0, pData.Length, ProgressCallBackFunc);
            //}
            //return result;

            int result = 0;
            //if (pData.Length <= 1024)
            //{
            //    result = _Command.tlw_FLASH_Read(device, addrMB, id, chipPos, startAddr, pData, 0, pData.Length);
            //}
            //else
            //{
            //    result = _Command.tlw_FLASH_BatchRead(device, addrMB, id, chipPos, startAddr, pData, 0, pData.Length, ProgressCallBackFunc);
            //}
            int count = pData.Length / 1024;
            uint offset = 0;
            for (int i = 0; i < count; i++)
            {
                byte[] tmpData = new byte[1024];
                result = _Command.tlw_FLASH_Read(device, addrMB, id, chipPos, startAddr + offset, tmpData, 0, 1024);
                Array.Copy(tmpData, 0, pData, offset, 1024);
                offset += 1024;
                int percent = (int)((i + 1) * 1.0 / count * 100);
                ProgressCallBackFunc(device, percent, $"{i}/{count}");
            }
            return result;
        }

        /// <summary>
        /// 写入韧件程序
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="chip">哪个芯片 默认为0   1为从芯片</param>
        /// <param name="mode"> 0 MCU韧件程序 , 1 FPGA韧件程序</param>
        /// <param name="path">文件路径</param>
        /// <param name="func">进度回调函数</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public int tlw_Firmware_Write(int hDevice, ushort addr, ushort id, byte chip, byte mode, string path)
        {
            int result = 0;
            result = _Command.tlw_Firmware_Write(hDevice, addr, id, chip, mode, path, ProgressCallBackFunc);
            return result;
        }

        /// <summary>
        /// 读取韧件程序版本号
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="chip">哪个芯片 默认为0   1为从芯片</param>
        /// <param name="mode">0 MCU韧件程序版本 , 1 FPGA韧件程序版本</param>
        /// <param name="dst">获取版本信息保存的数组指针</param>
        /// <param name="offset">数组内偏移量</param>
        /// <param name="nLen">数据长度,默认为4</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public int tlw_GetVersion(int hDevice, ushort addr, ushort id, byte chip, byte mode, byte[] dst, int offset, int nLen)
        {

            int result = _Command.tlw_GetVersion(hDevice, addr, id, chip, mode, dst, 0, nLen);
            return result;
        }

        public int tlw_SDRAM_Write(int device, ushort addrMB, ushort id, UInt32 startAddr, byte[] pData)
        {
            int result = 0;
            if (pData.Length <= 1024)
            {
                result = _Command.tlw_SDRAM_Write(device, addrMB, id, startAddr, pData, 0, pData.Length);
            }
            else
            {
                result = _Command.tlw_SDRAM_BatchWrite(device, addrMB, id, startAddr, pData, 0, pData.Length, ProgressCallBackFunc);
            }
            return result;
        }

        public int tlw_SDRAM_Read(int device, ushort addrMB, ushort id, UInt32 startAddr, byte[] pData)
        {
            int result = 0;
            if (pData.Length <= 1024)
            {
                result = _Command.tlw_SDRAM_Read(device, addrMB, id, startAddr, pData, 0, pData.Length);
            }
            else
            {
                result = _Command.tlw_SDRAM_BatchRead(device, addrMB, id, startAddr, pData, 0, pData.Length, ProgressCallBackFunc);
            }
            return result;
        }

        public int tlw_WriteRegister(int device, ushort addrMB, ushort id, byte chip, UInt32 regAddr, uint regVal, bool bSave)
        {
            int result = 0;
            result = _Command.tlw_WriteRegister(device, addrMB, id, chip, regAddr, regVal, bSave);

            if (result == 0)
            {
                System.Threading.Thread.Sleep(200);
                result = _Command.tlw_WriteRegister(device, addrMB, id, chip, 0x84, 1, true);
            }
            System.Threading.Thread.Sleep(10);
            return result;
        }

        private UInt32 ModifyUInt32Bits(UInt32 nSrc, byte nBitLow, byte nBitHigh, UInt32 nInput)
        {
            //取数并修改
            UInt32 tmp = nSrc;
            int nLen = nBitHigh - nBitLow + 1;

            UInt32 mask = 0;
            for (int i = 0; i < nLen; i++)
            {
                mask |= (UInt32)(1 << (nBitLow + i));
            }

            //输入值过滤
            UInt32 nData = (UInt32)(nInput & (mask >> nBitLow));

            //剔除原数据中的数据
            tmp &= (UInt32)(~mask);

            //将新数据放入指定位置
            tmp |= (UInt32)(nData << nBitLow);

            return tmp;
        }

        public int tlw_WriteRegister2072(int device, ushort addrMB, ushort id, byte chip, UInt32 regAddr, uint regVal, bool bSave)
        {
            int result = 0;
            //byte[] read = new byte[1024];
            //result = _Command.tlw_ReadRegisterGroup(device, addrMB, id, chip, read, 0, read.Length);
            //UInt32[] regVal1 = new UInt32[1];
            //_Command.tlw_ReadRegister(device, addrMB, id, chip, regAddr, regVal1);
            //byte[] btVal = new byte[4];
            //byte[] btWriteVal = regVal.GetBytes();

            //uint newRegAddr = regAddr;
            //btVal[0] = read[newRegAddr * 2 + 2];
            //btVal[1] = read[newRegAddr * 2 + 3];
            //btVal[2] = btWriteVal[3];
            //btVal[3] = btWriteVal[2];
            //UInt32 newVal = btVal.GetUInt32();
            //result = _Command.tlw_WriteRegister(device, addrMB, id, chip, regAddr, newVal, bSave);
            result = _Command.tlw_WriteRegister(device, addrMB, id, chip, regAddr, regVal, bSave);
            //if (result == 0)
            //{
            //    System.Threading.Thread.Sleep(100);
            //    result = _Command.tlw_WriteRegister(device, addrMB, id, chip, 0x84, 1, true);
            //}
            System.Threading.Thread.Sleep(10);
            return result;
        }

        public int tlw_SDRAM_WriteToFLASH(int device, ushort addrMB, ushort id)
        {
            int result = 0;

            result = _Command.tlw_SDRAM_WriteToFLASH(device, addrMB, id);
            return result;
        }

        /// <summary>
        /// 写入寄存器数组
        /// </summary>
        /// <param name="hDevice">hDevice 设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="chip"> 0 FPGA  1 4K视频芯片</param>
        /// <param name="src">数据数组指针</param>
        /// <param name="offset">偏移量</param>
        /// <param name="len">数据长度</param>
        /// <param name="bSave">是否保存 TRUE 保存  FALSE 不保存</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public int tlw_WriteRegisterGroup(int hDevice, ushort addr, ushort id, byte chip, byte[] src, bool bSave)
        {
            int result = 0;
            result = _Command.tlw_WriteRegisterGroup(hDevice, addr, id, chip, src, 0, src.Length, bSave);
            System.Threading.Thread.Sleep(200);
            result = _Command.tlw_WriteRegister(hDevice, addr, id, chip, 0x84, 1, true);
            return result;
        }

        /// <summary>
        /// 读取寄存器数组
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="chip">0 FPGA  1 4K视频芯片</param>
        /// <param name="src">数据数组指针</param>
        /// <param name="offset">偏移量</param>
        /// <param name="len">数据长度</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public int tlw_ReadRegisterGroup(int hDevice, ushort addr, ushort id, byte chip, byte[] src)
        {
            int result = 0;
            result = _Command.tlw_ReadRegisterGroup(hDevice, addr, id, chip, src, 0, src.Length);
            return result;
        }

        public int tlw_WriteGAMMA(int hDevice, ushort addr, ushort id, byte mode, byte color, byte[] src)
        {
            int result = 0;
            result = _Command.tlw_WriteGAMMA(hDevice, addr, id, mode, color, src, 0, src.Length);
            return result;
        }

        public int tlw_ReadGAMMA(int hDevice, ushort addr, ushort id, byte mode, byte color, byte[] src, int len)
        {
            int result = 0;
            result = _Command.tlw_ReadGAMMA(hDevice, addr, id, mode, color, src, 0, src.Length);
            return result;
        }

        /// <summary>
        /// 写入校正数据文件
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="chipPos">对TSS来说:0表示上灯板 1表示下灯板;对TLW来说,表示从左到右的序号:2、 3、 4 、5 四个位置</param>
        /// <param name="width">像素宽度</param>
        /// <param name="height">像素高度</param>
        /// <param name="path">文件路径</param>
        /// <param name="func">进度回调函数</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public int tlw_WriteCalibrationFile(int hDevice, ushort addr, ushort id, byte chipPos, int width, int height, string path)
        {
            int result = 0;
            result = _Command.tlw_WriteCalibrationFile(hDevice, addr, id, chipPos, width, height, path, ProgressCallBackFunc);
            return result;
        }

        /// <summary>
        /// 读取校正数据文件
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="chipPos">对TSS来说:0表示上灯板 1表示下灯板;对TLW来说,表示从左到右的序号:2、 3、 4 、5 四个位置</param>
        /// <param name="width">像素宽度</param>
        /// <param name="height">像素高度</param>
        /// <param name="path">文件路径</param>
        /// <param name="func">进度回调函数</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public int tlw_ReadCalibrationFile(int hDevice, ushort addr, ushort id, byte chipPos, int width, int height, string path)
        {
            int result = 0; 
             result = _Command.tlw_ReadCalibrationFile(hDevice, addr, id, chipPos, width, height, path, ProgressCallBackFunc);
            return result;
        }

        /// <summary>
        /// 写入校正数据文件到SDRAM
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="chipPos">对TSS来说:0表示上灯板 1表示下灯板;对TLW来说,表示从左到右的序号:2、 3、 4 、5 四个位置</param>
        /// <param name="width">像素宽度</param>
        /// <param name="height">像素高度</param>
        /// <param name="path">文件路径</param>
        /// <param name="func">进度回调函数</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public int tlw_WriteCalibrationFileToSDRAM(int hDevice, ushort addr, ushort id, byte chipPos, int width, int height, string path)
        {
            int result = 0;
            result = _Command.tlw_WriteCalibrationFileToSDRAM(hDevice, addr, id, chipPos, width, height, path, ProgressCallBackFunc);
            return result;
        }

        /// <summary>
        /// 写入灯板序列号
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="chipPos">对TSS来说:0表示上灯板 1表示下灯板;对TLW来说,表示从左到右的序号:2、 3、 4 、5 四个位置</param>
        /// <param name="data">序列号数据数组</param>
        /// <param name="offset">偏移量</param>
        /// <param name="nLen">数组长度,默认为1024</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public int tlw_WriteSerialNumber(int hDevice, ushort addr, ushort id, byte chipPos, byte[] data)
        {
            int result = 0;
            result = _Command.tlw_WriteSerialNumber(hDevice, addr, id, chipPos, data, 0, data.Length);
            return result;
        }

        /// <summary>
        /// 读取灯板序列号
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="chipPos">对TSS来说:0表示上灯板 1表示下灯板;对TLW来说,表示从左到右的序号:2、 3、 4 、5 四个位置</param>
        /// <param name="data">序列号数据数组</param>
        /// <param name="offset">偏移量</param>
        /// <param name="nLen">数组长度,默认为1024</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public int tlw_ReadSerialNumber(int hDevice, ushort addr, ushort id, byte chipPos, byte[] data)
        {
            int result = 0;
            result = _Command.tlw_ReadSerialNumber(hDevice, addr, id, chipPos, data, 0, data.Length);
            return result;
        }

        /// <summary>
        /// 连接卡加载参数
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="mode">表示加载的内容 0 全部加载 1校正数据 2 红色GAMMA 3绿色GAMMA 4蓝色GAMMA 5 MAP  6 寄存器数组1  7 寄存器数组2</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public int tlw_ConnectCardLoadParam(int hDevice, ushort addr, ushort id, byte mode)
        {
            int result = 0;
            result = _Command.tlw_ConnectCardLoadParam(hDevice, addr, id, mode);
            return result;
        }

        public int tlw_ReadRegister(int hDevice, ushort addr, ushort id, byte chip, UInt32 regAddr, UInt32[] pData)
        {
            int result = 0;
            result = _Command.tlw_ReadRegister(hDevice, addr, id, chip, regAddr, pData);
            return result;
        }

        /// <summary>
        /// 切换FPGA程序区域
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="val">程序区域编号 0=区域1, 1=区域2 , 2=区域3</param>
        /// <returns></returns>
        public int tlw_SwitchFPGAProgram(int hDevice, ushort addr, ushort id, byte val)
        {
            int result = 0;
            result = _Command.tlw_SwitchFPGAProgram(hDevice, addr, id, val);
            return result;
        }

        /// <summary>
        /// 写入电流增益值
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="chip">0=2055  1=2072</param>
        /// <param name="data">数组，data[0]红色电流增益,data[1]绿色电流增益,data[2]蓝色电流增益</param>
        /// <param name="nLen">数组长度，默认为3</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public int tlw_WriteCurrentGain(int hDevice, ushort addr, ushort id, byte chip, ushort[] data)
        {
            int result = 0;
            result = _Command.tlw_WriteCurrentGain(hDevice, addr, id, chip, data, data.Length);
            return result;
        }

        /// <summary>
        /// 读取电流增益值
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="chip">0=2055  1=2072</param>
        /// <param name="data">数组，data[0]红色电流增益,data[1]绿色电流增益,data[2]蓝色电流增益</param>
        /// <param name="nLen">数组长度，默认为3</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public int tlw_ReadCurrentGain(int hDevice, ushort addr, ushort id, byte chip, out ushort[] data)
        {
            int result = 0;
            data = new ushort[3];
            result = _Command.tlw_ReadCurrentGain(hDevice, addr, id, chip, data, data.Length);
            return result;
        }

        /// <summary>
        /// 写入色温数据
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="data">色温数据数组，长度为1024字节，占用前面256字节，后面768字节预留</param>
        /// <param name="offset">偏移量</param>
        /// <param name="nLen">数组长度，默认为1024</param>
        /// <returns></returns>
        public int tlw_WriteColorTempData(int hDevice, ushort addr, ushort id, byte[] data)
        {
            int result = 0;
            result = _Command.tlw_WriteColorTempData(hDevice, addr, id, data, 0, data.Length);
            return result;
        }

        /// <summary>
        /// 读取色温数据
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="data">色温数据数组，长度为1024字节，占用前面256字节，后面768字节预留</param>
        /// <param name="offset">偏移量</param>
        /// <param name="nLen">数组长度，默认为1024</param>
        /// <returns></returns>
        public int tlw_ReadColorTempData(int hDevice, ushort addr, ushort id, out byte[] data)
        {
            int result = 0;
            data = new byte[1024];
            result = _Command.tlw_ReadColorTempData(hDevice, addr, id, data, 0, data.Length);
            return result;
        }

        /// <summary>
        /// 选择色温
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="chip"> 0=2055  1=2072</param>
        /// <param name="group">数组指针，长度为1。group[0],选择的色温所在的方案，取值范围0-3</param>
        /// <param name="pos">数组指针，长度为1。pos[0].选择的色温组内序号，取值范围0-9， 0=3200K，1=6500K，2=8500K，3=9300K ,其他值为自定义色温值。</param>
        /// <returns></returns>
        public int tlw_SelectColorTemp(int hDevice, ushort addr, ushort id, byte chip, byte[] group, byte[] pos)
        {
            int result = 0;
            result = _Command.tlw_SelectColorTemp(hDevice, addr, id, chip, group, pos);
            return result;
        }

        /// <summary>
        /// 获取当前选择的色温
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id"> 0=2055  1=2072</param>
        /// <param name="chip">数组指针，长度为1。group[0],选择的色温所在的方案，取值范围0-3</param>
        /// <param name="group">数组指针，长度为1。group[0],选择的色温所在的方案，取值范围0-3</param>
        /// <param name="pos">数组指针，长度为1。pos[0].选择的色温组内序号，取值范围0-9， 0=3200K，1=6500K，2=8500K，3=9300K ,其他值为自定义色温值</param>
        /// <returns></returns>
        public int tlw_GetCurrentColorTemp(int hDevice, ushort addr, ushort id, byte chip, out byte[] group, out byte[] pos)
        {
            int result = 0;
            group = new byte[1];
            pos = new byte[1];
            result = _Command.tlw_GetCurrentColorTemp(hDevice, addr, id, chip, group, pos);
            return result;
        }

        /// <summary>
        /// 设置灯板校正数据长度
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="dwLen">灯板校正数据长度</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public int tlw_WriteCalibrationFileLength(int hDevice, ushort addr, ushort id, UInt32 dwLen)
        {
            int result = 0;
            result = _Command.tlw_WriteCalibrationFileLength(hDevice, addr, id, dwLen);
            return result;
        }

        /// <summary>
        /// 设置显示工装模式
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="mode">显示模式0 = 视频，0x80=工装白，0x81=工装黑，0x82=工装蓝，0x83=工装绿，0x84=工装红，0x85=灰度渐变，0x86=低灰度渐变，0x87=斜线</param>
        /// <returns>0 —— 成功，其他值失败</returns>
        public int tlw_SetDisplayMode(int hDevice, ushort addr, ushort id, byte mode)
        {
            int result = 0;
            result = _Command.tlw_SetDisplayMode(hDevice, addr, id, mode);
            return result;
        }

        public int tlw_SetBrightness(int hDevice, ushort addrMB, ushort id, ushort mode, ushort r, ushort g, ushort b)
        {
            int result = 0;
            result = _Command.tlw_SetBrightness(hDevice, addrMB, id, mode, r, g, b);
            return result;
        }

        public int tlw_WriteMAP(int hDevice, ushort addr, ushort id, byte[] src)
        {
            int result = 0;
            result = _Command.tlw_WriteMAP(hDevice, addr, id, src, 0, src.Length);
            return result;
        }

        public int tlw_ReadMAP(int hDevice, ushort addr, ushort id, byte[] src, int nLen)
        {
            int result = 0;
            result = _Command.tlw_ReadMAP(hDevice, addr, id, src, 0, src.Length);
            return result;
        }

        public int tlw_SetNetworkParam(int hDevice, ushort addr, ushort id, byte[] dat, int nLen)
        {
            int result = 0;
            result = _Command.tlw_SetNetworkParam(hDevice, addr, id, dat, 0, nLen);
            return result;
        }

        public int tlw_Firmware_Read(int hDevice, ushort addr, ushort id, byte chip, byte mode, int dataLen, string path)
        {
            int result = 0;
            result = _Command.tlw_Firmware_Read(hDevice, addr, id, chip, mode, dataLen, path, ProgressCallBackFunc);
            return result;
        }

        /// <summary>
        /// 写入校正数据文件(整个连接板驱动的区域)
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="width">连接板区域的像素宽度</param>
        /// <param name="height">连接板区域的像素高度</param>
        /// <param name="path">输入的zdat格式文件的路径</param>
        /// <returns></returns>
        public int tlw_WriteWholeCalibrationFileToSDRAM(int hDevice, ushort addr, ushort id, int width, int height, string path)
        {
            int result = 0;
            result = _Command.tlw_WriteWholeCalibrationFileToSDRAM(hDevice, addr, id, width, height, path, ProgressCallBackFunc);
            return result;
        }

        /// <summary>
        /// 读取校正数据文件(整个连接板驱动的区域)
        /// </summary>
        /// <param name="hDevice">设备句柄</param>
        /// <param name="addr">设备地址</param>
        /// <param name="id">数据包识别号</param>
        /// <param name="width">连接板区域的像素宽度</param>
        /// <param name="height">连接板区域的像素高度</param>
        /// <param name="path">输出的zdat格式文件的路径</param>
        /// <param name="func">进度回调函数</param>
        /// <returns></returns>
        public int tlw_ReadWholeCalibrationFileFromSDRAM(int hDevice, ushort addr, ushort id, int width, int height, string path)
        {
            int result = 0;
            result = _Command.tlw_ReadWholeCalibrationFileFromSDRAM(hDevice, addr, id, width, height, path, ProgressCallBackFunc);
            return result;
        }
        #endregion

        #endregion
    }
}
