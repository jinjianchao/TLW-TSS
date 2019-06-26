#region << 注释 >>
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


        public void tlw_WriteMAP(ushort addrMB, ushort id, byte chipPos, byte[] pData, uint sectorSize, Dictionary<string, int> ips, Action<ReturnParam[]> action)
        {
            UInt32 addr = 0x3E8000;
            tlw_FLASH_Write(addrMB, id, chipPos, addr, pData, sectorSize, ips, action);
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
        public void tlw_WriteGAMMA(ushort addr, ushort id, byte mode, byte color, byte[] src, Dictionary<string, int> ips, Action<ReturnParam[]> action)
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
                        if (color == 0)
                        {
                            returnParam[param.Index].ResultCode = _Command.tlw_WriteGAMMA(param.Dev, addr, id, mode, 1, src, 0, src.Length);
                            if (returnParam[param.Index].ResultCode == 0) returnParam[param.Index].ResultCode = _Command.tlw_WriteGAMMA(param.Dev, addr, id, mode, 2, src, 0, src.Length);
                            if (returnParam[param.Index].ResultCode == 0) returnParam[param.Index].ResultCode = _Command.tlw_WriteGAMMA(param.Dev, addr, id, mode, 3, src, 0, src.Length);
                        }
                        else
                        {
                            returnParam[param.Index].ResultCode = _Command.tlw_WriteGAMMA(param.Dev, addr, id, mode, color, src, 0, src.Length);
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
        public void tlw_VideoCardLoadParam(ushort addr, ushort id, byte mode, Dictionary<string, int> ips, Action<ReturnParam[]> action)
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
                        returnParam[param.Index].ResultCode = _Command.tlw_VideoCardLoadParam(param.Dev, addr, id, mode);
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
            int result = 0;
            if (pData.Length <= 1024)
            {
                result = _Command.tlw_FLASH_Read(device, addrMB, id, chipPos, startAddr, pData, 0, pData.Length);
            }
            else
            {
                result = _Command.tlw_FLASH_BatchRead(device, addrMB, id, chipPos, startAddr, pData, 0, pData.Length, ProgressCallBackFunc);
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
        #endregion

        #endregion
    }
}
