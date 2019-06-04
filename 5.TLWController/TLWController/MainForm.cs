using LanguageLib;
using PluginLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TLWController.Helper;
using TLWController.Extentions;
using System.IO;
using System.Threading.Tasks;

namespace TLWController
{
    public partial class MainForm : BaseFormV2
    {
        #region 私有变量

        Dictionary<string, int> _DevIP = new Dictionary<string, int>();
        TLWCommand _TLWCommand = null;
        bool _isBusy = false;

        #endregion

        #region 内部结构
        class ListItem
        {
            public int Value { get; set; }
            public string Text { get; set; }
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            MultiLanguage.GetNames(this, lang, Path + @"\Language");
            BindBrightnessColor();
            BindChipPos();
            TransForm();
            _TLWCommand = new TLWCommand();
            if (!_TLWCommand.Sys_Initial(Path))
            {
                MessageBox.Show(this, Trans("initsyslibfailed"));
                tab.Enabled = false;
                return;
            }
            _TLWCommand.Sys_WriteLog(true);
            _TLWCommand.DataMonitorEvent += _TLWCommand_DataMonitorEvent;
            _TLWCommand.ProgressChangedEvent += _TLWCommand_ProgressChangedEvent;
        }

        #region 构造函数
        private readonly String lang = MultiLanguage.ReadDefaultLanguage(); //读取语言包信息

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region 界面翻译

        private void Trans(Control ctr)
        {
            ctr.Text = MultiLanguage.GetNames(this.Name, ctr.Name);
        }

        private string Trans(string key)
        {
            return MultiLanguage.GetNames(this.Name, key);
        }

        private void TransForm()
        {
            //界面控件
            List<Control> controls = new List<Control>()
            {
                tabCommonCommand,
                gbBrightness,
                btnApplyBrightness
            };
            foreach (var item in controls)
            {
                Trans(item);
            }
        }

        #endregion

        #region 数据绑定

        void BindBrightnessColor()
        {
            List<ListItem> items = new List<ListItem>()
            {
                new ListItem(){ Value=0, Text="所有颜色" },
                new ListItem(){ Value=1, Text="红色" },
                new ListItem(){ Value=2, Text="绿色" },
                new ListItem(){ Value=3, Text="蓝色" }
            };
            cbBrightnessColor.ValueMember = "Value";
            cbBrightnessColor.DisplayMember = "Text";
            cbBrightnessColor.DataSource = items;
        }

        void BindChipPos()
        {
            List<ListItem> items = new List<ListItem>()
            {
                new ListItem(){ Value=0, Text="默认位置" },
                new ListItem(){ Value=1, Text="连接卡" },
                new ListItem(){ Value=2, Text="上方灯板" },
                new ListItem(){ Value=3, Text="下方灯板" }
            };
            cbChipPos.ValueMember = "Value";
            cbChipPos.DisplayMember = "Text";
            cbChipPos.DataSource = items;
        }

        #endregion

        #region 辅助方法

        bool CheckIsBusy()
        {
            if (_isBusy)
            {
                MessageBox.Show(this, "队列中有命令正在执行，请稍后再试");
                return true;
            }
            return false;
        }

        void EnableControl(Control ctr, bool isEnable, string ip = null)
        {
            _isBusy = !isEnable;
            if (_isBusy == true)
            {
                if (ip == null)
                {
                    OpenUDPDevice();
                }
                else
                {
                    OpenUDPDevice(ip);
                }
            }
            else
            {
                CloseUDPDevice();
            }
            Invoke(new MethodInvoker(() =>
            {
                ctr.Enabled = isEnable;
            }));
        }

        /// <summary>
        /// 异步调用委托
        /// </summary>
        /// <param name="method"></param>
        /// <param name="callBack"></param>
        private void InvokeAsync(Action method)
        {
            if (method.GetInvocationList().Length == 0)
                return;
            method.BeginInvoke(new AsyncCallback(result =>
            {
                try
                {
                    Action action = result.AsyncState as Action;
                    action.EndInvoke(result);
                }
                catch { }
            }), method);
        }


        void WriteTestMessage(string message)
        {
            Invoke(new MethodInvoker(() =>
            {
                gpTest.Text = message;
            }));
        }

        void WriteTextFile(string file, string text)
        {
            byte[] bytes = text.ToBytes();
            string str = "";
            for (int i=0;i<bytes.Length;i++)
            {
                str += " " + bytes[i].ToString("X2");
                if((i+1)%1024==0)
                {
                    str += "\r\n";
                }
            }
            TextWriter textWriter = new StreamWriter(file, false);
            textWriter.Write(str);
            textWriter.Flush();
            textWriter.Close();
        }

        void WriteMessage(string message)
        {
            WriteLine(message, true);
        }

        void WriteOutput(ReturnParam param, string message)
        {
            if (param.ResultCode == 0)
            {
                WriteMessage($"IP:{param.IP} {message}成功");
            }
            else
            {
                WriteMessage($"IP:{param.IP} {message}失败.Code:{param.ResultCode}");
            }
        }

        ushort GetId()
        {
            return 0;
        }

        ushort GetCardAddress()
        {
            Point addr = GetUnitAddr();

            if (addr.X == 0x00 && addr.Y == 0x00)
            {
                //连接卡广播地址
                //WriteMessage("当前控制卡为:所有连接卡");
            }
            else if (addr.X == 0x01 && addr.Y == 0x01)
            {
                //连接卡广播地址
                //WriteMessage("当前控制卡为:第一级连接卡");
            }
            else if (addr.X == 0x60 && addr.Y == 0x60)
            {
                //连接卡广播地址
                //WriteMessage("当前控制卡为:所有数据转接卡");
            }
            else if (addr.X == 0x61 && addr.Y == 0x61)
            {
                //连接卡广播地址
                //WriteMessage("当前控制卡为:第一级数据转接卡");
            }
            else if (addr.X == 0XF1 && addr.Y == 0XF1)
            {
                //连接卡广播地址
                //WriteMessage("当前控制卡为:视频转接卡");
            }
            else if ((addr.X > 0x00 && addr.Y > 0x00) && (addr.X < 0x60 && addr.Y < 0x60))
            {
                //WriteMessage($"当前控制卡为:第{addr.Y}行,{addr.X}列连接卡");
            }
            else
            {
                //WriteMessage($"设备地址错误");
            }

            ushort cardAddr = (ushort)(addr.X << 8 | addr.Y);
            return cardAddr;
        }

        bool CheckDeviceAddr()
        {
            Point addr = GetUnitAddr();
            if (addr.X == 255 && addr.Y == 255)
            {
            }
            else if (addr.X == 127 && addr.Y == 0)
            {
            }
            else if (addr.X == 64 && (addr.Y >= 1 && addr.Y <= 64))
            {
            }
            else if (addr.X == 63 && addr.Y == 63)
            {
            }
            else if ((addr.X >= 1 && addr.X < 64) && (addr.Y >= 1 && addr.Y < 64))
            {
            }
            else if (addr.X == 0 && addr.Y == 0)
            {
            }
            else
            {
                return false;
            }
            return true;
        }

        void OpenUDPDevice()
        {
            _TLWCommand.PackageDelay = GetSendDataTime();
            _TLWCommand.SendWait = GetReceiveDataTime();

            string startIP = GetCommunicationType().StartIPAddress;
            string endIP = GetCommunicationType().EndIPAddress;
            string ipHeader = startIP.Substring(0, startIP.LastIndexOf('.'));
            int numStart = startIP.Substring(startIP.LastIndexOf('.') + 1).ToInit32();
            int numEnd = endIP.Substring(endIP.LastIndexOf('.') + 1).ToInit32();
            _DevIP.Clear();
            for (int i = numStart; i <= numEnd; i++)
            {
                string ip = $"{ipHeader}.{i}";
                int dev = _TLWCommand.OpenUDP(ip);
                _DevIP.Add(ip, dev);
            }
        }

        void OpenUDPDevice(string ip)
        {
            _TLWCommand.PackageDelay = GetSendDataTime();
            _TLWCommand.SendWait = GetReceiveDataTime();

            _DevIP.Clear();
            int dev = _TLWCommand.OpenUDP(ip);
            _DevIP.Add(ip, dev);
        }

        void CloseUDPDevice(int deviceNumber)
        {
            _TLWCommand.Sys_CloseDev(deviceNumber);
        }

        void CloseUDPDevice()
        {
            foreach (var item in _DevIP)
            {
                CloseUDPDevice(item.Value);
            }

        }

        #endregion

        #region 回调事件

        private void MainForm_IsShowDataPackageChanged(bool isShowDataPackage)
        {
            if (_TLWCommand != null)
            {
                _TLWCommand.IsOpenDataMonitor = isShowDataPackage;
                foreach (var item in _DevIP)
                {
                    _TLWCommand.OpenDataMonitor(item.Value, isShowDataPackage);
                }
            }
        }

        private void _TLWCommand_DataMonitorEvent(object sender, Events.DataMonitorEventArgs e)
        {
            if (_DevIP.Count == 1)
            {
                if (e.IsReceived)
                {
                    WriteMessage($"{Trans("Send")}:{e.Data.ToString(" ")}");
                }
                else
                {
                    WriteMessage($"{Trans("Read")}:{e.Data.ToString(" ")}");
                }
            }
        }

        private void _TLWCommand_ProgressChangedEvent(object sender, Events.ProgressChangedMonitorEventArgs e)
        {
            SetPrograss("", "", e.Percent);
        }

        #endregion

        #region 按钮事件

        //亮度滑块
        private void tbBrightness_Scroll(object sender, EventArgs e)
        {
            numBrightness.ValueChanged -= numBrightness_ValueChanged;
            numBrightness.Value = tbBrightness.Value;
            numBrightness.ValueChanged += numBrightness_ValueChanged;
        }

        //亮度输入框
        private void numBrightness_ValueChanged(object sender, EventArgs e)
        {
            tbBrightness.ValueChanged -= tbBrightness_Scroll;
            tbBrightness.Value = (int)numBrightness.Value;
            tbBrightness.ValueChanged -= tbBrightness_Scroll;
        }

        //亮度设置
        private  void btnApplyBrightness_Click(object sender, EventArgs e)
        {
            if (CheckIsBusy()) return;
            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }
            ushort r, g, b;
            r = g = b = (ushort)(65535 * (tbBrightness.Value / 100f));
            ushort color = (ushort)(cbBrightnessColor.SelectedItem as ListItem).Value;

            EnableControl(sender as Control, false);
            _TLWCommand.tlw_SetBrightness(GetCardAddress(), GetId(), color, r, g, b, _DevIP, (param) =>
           {
               Array.ForEach(param, t => WriteOutput(t, "亮度发送"));
               EnableControl(sender as Control, true);
           });
        }

        #endregion

        #region 测试页相关内容

        private void btnCreateAndWriteFlashData_Click(object sender, EventArgs e)
        {
            if (CheckIsBusy()) return;
            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }
            Random rnd = new Random();
            byte[] data = new byte[(int)numFlashDataLen.Value];
            rnd.NextBytes(data);
            //byte val = 1;
            //for (int i = 1; i <= 1024; i++)
            //{
            //    if (val > 255 || val == 0) val = 1;
            //    data[i - 1] = val;
            //    val++;
            //}
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.txt|*.txt";
            saveFileDialog.Title = "保存测试数据";
            saveFileDialog.FileName = "FLASH_Write";
            if (saveFileDialog.ShowDialog(this) == DialogResult.Cancel) return;
            WriteTextFile(saveFileDialog.FileName, data.ToString(" "));

            FrmSectionSet frmSectionSet = new FrmSectionSet();
            frmSectionSet.StartPosition = FormStartPosition.CenterParent;
            if (frmSectionSet.ShowDialog(this) == DialogResult.Cancel) return;
            uint sectorSize = (uint)frmSectionSet.SectionSize;
            uint regAddr = (uint)numRegAddr.Value;
            byte chipPos = (byte)cbChipPos.SelectedValue.ToString().ToByte();
            EnableControl(sender as Control, false);

            _TLWCommand.tlw_FLASH_Write(GetCardAddress(), GetId(), chipPos, regAddr, data, sectorSize, _DevIP, (param) =>
              {
                  Array.ForEach(param, t => WriteOutput(t, "写入FLASH"));
                  EnableControl(sender as Control, true);
              });
        }

        private void btnReadFlashData_Click(object sender, EventArgs e)
        {
            if (CheckIsBusy()) return;
            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.txt|*.txt";
            saveFileDialog.Title = "保存测试数据";
            saveFileDialog.FileName = "FLASH_Read.txt";
            if (saveFileDialog.ShowDialog(this) == DialogResult.Cancel) return;

            string ip = ShowSelectIPDialog();
            uint regAddr = (uint)numRegAddr.Value;
            byte chipPos = (byte)cbChipPos.SelectedValue.ToString().ToByte();

            EnableControl(sender as Control, false, ip);
            _TLWCommand.tlw_FLASH_Read(GetCardAddress(), GetId(), chipPos, regAddr, (int)numFlashDataLen.Value, _DevIP, (param) =>
              {
                  Array.ForEach(param, t =>
                  {
                      WriteOutput(t, "读取FLASH");
                      if (t.ResultCode == 0)
                      {
                          WriteTextFile(saveFileDialog.FileName, t.Data.ToString(" "));
                      }
                  });
                  EnableControl(sender as Control, true);
              });
        }

        private void btnCreateAndWriteSDRAM_Click(object sender, EventArgs e)
        {
            if (CheckIsBusy()) return;
            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }
            Random rnd = new Random();
            byte[] data = new byte[(int)numFlashDataLen.Value];
            rnd.NextBytes(data);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.txt|*.txt";
            saveFileDialog.Title = "保存测试数据";
            saveFileDialog.FileName = "SDRAM_Write";
            if (saveFileDialog.ShowDialog(this) == DialogResult.Cancel) return;
            WriteTextFile(saveFileDialog.FileName, data.ToString(" "));

            byte chipPos = (byte)cbChipPos.SelectedValue.ToString().ToByte();
            EnableControl(sender as Control, false);
            _TLWCommand.tlw_SDRAM_Write(GetCardAddress(), GetId(), chipPos, (uint)numSDRAMAddr.Value, data, _DevIP, (param) =>
            {
                Array.ForEach(param, t => WriteOutput(t, "写入SDRAM"));
                EnableControl(sender as Control, true);
            });
        }


        private void btnSDRAMWriteToFlash_Click(object sender, EventArgs e)
        {
            if (CheckIsBusy()) return;
            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }
            EnableControl(sender as Control, false);
            _TLWCommand.tlw_SDRAM_WriteToFLASH(GetCardAddress(), GetId(), _DevIP, (param) =>
           {
               Array.ForEach(param, t => WriteOutput(t, "写入SDRAM"));
               EnableControl(sender as Control, true);
           });

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ip = GetCommunicationType().StartIPAddress;
            string folder = @"D:\测试文件夹\TSS\error_Read_Flash";
            if (System.IO.Directory.Exists(folder)) System.IO.Directory.Delete(folder, true);
            System.IO.Directory.CreateDirectory(folder);
            string compare = "";
            //读取525字节数据 每行50个数据
            //compare += "aa 8e 41 51 04 00 00 00 20 00 1e 00 00 00 00 00 01 00 02 00 03 00 04 00 05 00 06 00 07 00 08 00 09 00 0a 00 0b 00 0c 00 0d 00 0e 00 0f 00 10 00 11 00";
            //compare += "12 00 13 00 14 00 15 00 16 00 17 00 18 00 19 00 1a 00 1b 00 1c 00 1d 00 1e 00 1f 00 20 00 21 00 22 00 23 00 24 00 25 00 26 00 27 00 28 00 29 00 2a 00";
            //compare += "2b 00 2c 00 2d 00 2e 00 2f 00 30 00 31 00 32 00 33 00 34 00 35 00 36 00 37 00 38 00 39 00 3a 00 3b 00 3c 00 3d 00 3e 00 3f 00 40 00 41 00 42 00 43 00";
            //compare += "44 00 45 00 46 00 47 00 48 00 49 00 4a 00 4b 00 4c 00 4d 00 4e 00 4f 00 50 00 51 00 52 00 53 00 54 00 55 00 56 00 57 00 58 00 59 00 5a 00 5b 00 5c 00";
            //compare += "5d 00 5e 00 5f 00 60 00 61 00 62 00 63 00 64 00 65 00 66 00 67 00 68 00 69 00 6a 00 6b 00 6c 00 6d 00 6e 00 6f 00 70 00 71 00 72 00 73 00 74 00 75 00";
            //compare += "76 00 77 00 78 00 79 00 7a 00 7b 00 7c 00 7d 00 7e 00 7f 00 80 00 81 00 82 00 83 00 84 00 85 00 86 00 87 00 88 00 89 00 8a 00 8b 00 8c 00 8d 00 8e 00";
            //compare += "8f 00 90 00 91 00 72 00 93 00 94 00 95 00 96 00 97 00 98 00 99 00 9a 00 9b 00 9c 00 9d 00 9e 00 9f 00 a0 00 a1 00 a2 00 a3 00 a4 00 a5 00 a6 00 a7 00";
            //compare += "a8 00 a9 00 aa 00 ab 00 ac 00 ad 00 ae 00 af 00 b0 00 b1 00 b2 00 b3 00 b4 00 b5 00 b6 00 b7 00 b8 00 b9 00 ba 00 bb 00 bc 00 bd 00 be 00 bf 00 c0 00";
            //compare += "c1 00 c2 00 c3 00 c4 00 c5 00 c6 00 c7 00 c8 00 c9 00 ca 00 cb 00 cc 00 cd 00 ce 00 cf 00 d0 00 d1 00 d2 00 d3 00 d4 00 d5 00 d6 00 d7 00 d8 00 d9 00";
            //compare += "da 00 db 00 dc 00 dd 00 de 00 df 00 e0 00 e1 00 e2 00 e3 00 e4 00 e5 00 e6 00 e7 00 e8 00 e9 00 ea 00 eb 00 ec 00 ed 00 ee 00 ef 00 f0 00 f1 00 f2 00";
            //compare += "f3 00 f4 00 f5 00 f6 00 f7 00 f8 00 f9 00 fa 00 fb 00 fc 00 fd 00 fe 00 ff";
            //aa 8e 41 51 04 00 00 00 20 00 00 00 00 0e 0f 10 11 12  --- 0d  4轮  FE 75 55 71 BE

            compare = "aa 8e 41 51 04 00 00 00 20 00 00 00 00 ";
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0x00; i <= 0xff; i++)
                {
                    compare += i.ToString("x2") + " ";
                }
            }
            compare += "FE 75 55 71 BE";

            //compare += "aa 8e 41 51 04 00 00 00 20 00 1e 00 00 00 00 00 01 00 02 00 03 00 04 00 05 00 06 00 07 00 08 00 09 00 0a 00 0b 00 0c 00 0d 00 0e 00 0f 00 10 00 11 00";
            //compare += "12 00 13 00 14 00 15 00 16 00 17 00 18 00 19 00 1a 00 1b 00 1c 00 1d 00 1e 00 1f 00 20 00 21 00 22 00 23 00 24 00 25 00 26 00 27 00 28 00 29 00 2a 00";
            //compare += "2b 00 2c 00 2d 00 2e 00 2f 00 30 00 31 00 32 00 33 00 34 00 35 00 36 00 37 00 38 00 39 00 3a 00 3b 00 3c 00 3d 00 3e 00 3f 00 40 00 41 00 42 00 43 00";
            //compare += "44 00 45 00 46 00 47 00 48 00 49 00 4a 00 4b 00 4c 00 4d 00 4e 00 4f 00 50 00 51 00 52 00 53 00 54 00 55 00 56 00 57 00 58 00 59 00 5a 00 5b 00 5c 00";
            //compare += "5d 00 5e 00 5f 00 60 00 61 00 62 00 63 00 64 00 65 00 66 00 67 00 68 00 69 00 6a 00 6b 00 6c 00 6d 00 6e 00 6f 00 70 00 71 00 72 00 73 00 74 00 75 00";
            //compare += "76 00 77 00 78 00 79 00 7a 00 7b 00 7c 00 7d 00 7e 00 7f 00 80 00 81 00 82 00 83 00 84 00 85 00 86 00 87 00 88 00 89 00 8a 00 8b 00 8c 00 8d 00 8e 00";
            //compare += "8f 00 90 00 91 00 72 00 93 00 94 00 95 00 96 00 97 00 98 00 99 00 9a 00 9b 00 9c 00 9d 00 9e 00 9f 00 a0 00 a1 00 a2 00 a3 00 a4 00 a5 00 a6 00 a7 00";
            //compare += "a8 00 a9 00 aa 00 ab 00 ac 00 ad 00 ae 00 af 00 b0 00 b1 00 b2 00 b3 00 b4 00 b5 00 b6 00 b7 00 b8 00 b9 00 ba 00 bb 00 bc 00 bd 00 be 00 bf 00 c0 00";
            //compare += "c1 00 c2 00 c3 00 c4 00 c5 00 c6 00 c7 00 c8 00 c9 00 ca 00 cb 00 cc 00 cd 00 ce 00 cf 00 d0 00 d1 00 d2 00 d3 00 d4 00 d5 00 d6 00 d7 00 d8 00 d9 00";
            //compare += "da 00 db 00 dc 00 dd 00 de 00 df 00 e0 00 e1 00 e2 00 e3 00 e4 00 e5 00 e6 00 e7 00 e8 00 e9 00 ea 00 eb 00 ec 00 ed 00 ee 00 ef 00 f0 00 f1 00 f2 00";
            //compare += "f3 00 f4 00 f5 00 f6 00 f7 00 f8 00 f9 00 fa 00 fb 00 fc 00 fd 00 fe 00 ff";

            byte[] readFlash = "65 00 2D 00 01 01 01 00 00 00 00 00 00 00 55 00 1D 00 00 04 10 00 00 00 00 FF FF FF FF FF FF 00 00 00 00 00 00 00 00 00 00 2B AA 85 F8".ToBytes();
            int errCount = 0;
            int currentCount = 0;
            isStop = false;
            int delay = (int)numTimeDelay.Value;
            int readDataLen = (int)numTestDataLen.Value;

            InvokeAsync(() =>
            {
                EnableControl(sender as Control, false);
                while (!isStop)
                {
                    int revLen = UDPHelper.Send(readFlash, ip, out byte[] revReadFlash, 100);
                    if (revLen == 0)
                    {
                        errCount++;
                        currentCount++;
                        WriteMessage("没有收到返回数据");
                        WriteTestMessage($"稳定性测试:当前次数:{currentCount},错误次数:{errCount}");
                        WriteTextFile($@"{folder}\error_{errCount}.txt", "没有收到返回数据");
                        continue;
                    }

                    byte[] newData = new byte[readDataLen];
                    for (int i = 0; i < readDataLen; i++)
                    {
                        if (revReadFlash[i] == 0xaa && revReadFlash[i + 1] == 0x8e && revReadFlash[i + 2] == 0x41)
                        {
                            Array.Copy(revReadFlash, i, newData, 0, readDataLen);
                            break;
                        }
                    }

                    string revData = newData.ToString(" ").ToLower();
                    if (revData != compare)
                    {
                        errCount++;
                        WriteMessage("错误:" + errCount.ToString());
                        string writeData = $"{compare.ToUpper()}\r\n{revData.ToUpper()}";
                        WriteTextFile($@"{folder}\error_{errCount}.txt", writeData);
                    }
                    currentCount++;
                    WriteTestMessage($"稳定性测试:当前次数:{currentCount},错误次数:{errCount}");
                    System.Threading.Thread.Sleep(delay);
                }
                EnableControl(sender as Control, true);
            });
        }

        bool isStop = false;
        private void button2_Click(object sender, EventArgs e)
        {
            isStop = true;
        }

        private void btnReadWriteSend_Click(object sender, EventArgs e)
        {
            string ip = GetCommunicationType().StartIPAddress;
            string folder = @"D:\测试文件夹\TSS\error_Write_Flash_Read_Flash";
            if (System.IO.Directory.Exists(folder)) System.IO.Directory.Delete(folder, true);
            System.IO.Directory.CreateDirectory(folder);
            string compare = "";
            compare += "aa 8e 41 51 04 00 00 00 20 00 1e 00 00 00 00 00 01 00 02 00 03 00 04 00 05 00 06 00 07 00 08 00 09 00 0a 00 0b 00 0c 00 0d 00 0e 00 0f 00 10 00 11 00 12 00 13 00 14 00 15 00 16 00 17 00 18 00 19 00 1a 00 1b 00 1c 00 1d 00 1e 00 1f 00 20 00 21 00 22 00 23 00 24 00 25 00 26 00 27 00 28 00 29 00 2a 00";
            compare += "2b 00 2c 00 2d 00 2e 00 2f 00 30 00 31 00 32 00 33 00 34 00 35 00 36 00 37 00 38 00 39 00 3a 00 3b 00 3c 00 3d 00 3e 00 3f 00 40 00 41 00 42 00 43 00 44 00 45 00 46 00 47 00 48 00 49 00 4a 00 4b 00 4c 00 4d 00 4e 00 4f 00 50 00 51 00 52 00 53 00 54 00 55 00 56 00 57 00 58 00 59 00 5a 00 5b 00 5c 00";
            compare += "5d 00 5e 00 5f 00 60 00 61 00 62 00 63 00 64 00 65 00 66 00 67 00 68 00 69 00 6a 00 6b 00 6c 00 6d 00 6e 00 6f 00 70 00 71 00 72 00 73 00 74 00 75 00 76 00 77 00 78 00 79 00 7a 00 7b 00 7c 00 7d 00 7e 00 7f 00 80 00 81 00 82 00 83 00 84 00 85 00 86 00 87 00 88 00 89 00 8a 00 8b 00 8c 00 8d 00 8e 00";
            compare += "8f 00 90 00 91 00 72 00 93 00 94 00 95 00 96 00 97 00 98 00 99 00 9a 00 9b 00 9c 00 9d 00 9e 00 9f 00 a0 00 a1 00 a2 00 a3 00 a4 00 a5 00 a6 00 a7 00 a8 00 a9 00 aa 00 ab 00 ac 00 ad 00 ae 00 af 00 b0 00 b1 00 b2 00 b3 00 b4 00 b5 00 b6 00 b7 00 b8 00 b9 00 ba 00 bb 00 bc 00 bd 00 be 00 bf 00 c0 00";
            compare += "c1 00 c2 00 c3 00 c4 00 c5 00 c6 00 c7 00 c8 00 c9 00 ca 00 cb 00 cc 00 cd 00 ce 00 cf 00 d0 00 d1 00 d2 00 d3 00 d4 00 d5 00 d6 00 d7 00 d8 00 d9 00 da 00 db 00 dc 00 dd 00 de 00 df 00 e0 00 e1 00 e2 00 e3 00 e4 00 e5 00 e6 00 e7 00 e8 00 e9 00 ea 00 eb 00 ec 00 ed 00 ee 00 ef 00 f0 00 f1 00 f2 00";
            compare += "f3 00 f4 00 f5 00 f6 00 f7 00 f8 00 f9 00 fa 00 fb 00 fc 00 fd 00 fe 00 ff";

            byte[] writeFlash = "65 00 2D 00 01 FF FF 00 00 00 00 00 00 00 55 00 1D 00 00 02 05 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 24 AA 73 F8".ToBytes();
            byte[] readFlash = "65 00 2D 00 01 01 01 00 00 00 00 00 00 00 55 00 1D 00 00 04 10 00 00 00 00 FF FF FF FF FF FF 00 00 00 00 00 00 00 00 00 00 2B AA 85 F8".ToBytes();
            int errCount = 0;
            int currentCount = 0;
            isStop = false;
            int delay = (int)numTimeDelay.Value;
            int readDataLen = (int)numTestDataLen.Value;
            InvokeAsync(() =>
            {
                EnableControl(sender as Control, false);
                while (!isStop)
                {
                    int revLen = UDPHelper.Send(writeFlash, ip, out byte[] revWriteFlash);
                    if (revLen == 0)
                    {
                        errCount++;
                        currentCount++;
                        WriteMessage("没有收到返回数据");
                        WriteTestMessage($"稳定性测试:当前次数:{currentCount},错误次数:{errCount}");
                        WriteTextFile($@"{folder}\error_{errCount}.txt", "写FLASH没有收到返回数据");
                        continue;
                    }
                    System.Threading.Thread.Sleep(1000);

                    revLen = UDPHelper.Send(readFlash, ip, out byte[] revReadFlash);
                    if (revLen == 0)
                    {
                        errCount++;
                        currentCount++;
                        WriteMessage("没有收到返回数据");
                        WriteTestMessage($"稳定性测试:当前次数:{currentCount},错误次数:{errCount}");
                        WriteTextFile($@"{folder}\error_{errCount}.txt", "读FLASH没有收到返回数据");
                        continue;
                    }
                    byte[] newData = new byte[readDataLen];
                    for (int i = 0; i < readDataLen; i++)
                    {
                        if (revReadFlash[i] == 0xaa && revReadFlash[i + 1] == 0x8e && revReadFlash[i + 2] == 0x41)
                        {
                            Array.Copy(revReadFlash, i, newData, 0, readDataLen);
                            break;
                        }
                    }

                    string revData = newData.ToString(" ").ToLower();
                    if (revData != compare)
                    {
                        errCount++;
                        WriteMessage("错误:" + errCount.ToString());
                        string writeData = $"{compare.ToUpper()}\r\n{revData.ToUpper()}";
                        WriteTextFile($@"{folder}\error_{errCount}.txt", writeData);
                    }
                    currentCount++;
                    WriteTestMessage($"稳定性测试:当前次数:{currentCount},错误次数:{errCount}");
                    System.Threading.Thread.Sleep(delay);
                }
                EnableControl(sender as Control, true);
            });
        }

        private void btnTest3_Click(object sender, EventArgs e)
        {
            string ip = GetCommunicationType().StartIPAddress;
            string folder = @"D:\测试文件夹\TSS\error_WRITE_SDRAM_WRITE_FLASH_READ_FLASH";
            if (System.IO.Directory.Exists(folder)) System.IO.Directory.Delete(folder, true);
            System.IO.Directory.CreateDirectory(folder);

            //写SDRAM
            byte[] WriteSDRAM = "65 00 2D 00 01 FF FF 00 00 00 00 00 00 00 55 00 1D 00 00 04 25 00 00 00 00 03 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 49 AA BD F8".ToBytes();
            //SDRAM搬移到FLASH
            byte[] writeFlash = "65 00 2D 00 01 FF FF 00 00 00 00 00 00 00 55 00 1D 00 00 04 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 25 AA 75 F8".ToBytes();
            //读FLASH
            byte[] readFlash = "65 00 2D 00 01 FF FF 00 00 00 00 00 00 00 55 00 1D 00 00 04 10 00 00 00 00 0F 5C 0F 5C 0F 5C 00 00 00 00 00 00 00 00 00 00 72 AA 0F F8".ToBytes();
            string compare = "aa 8e 41 51 04 00 00 00 20 00 1e 00 00 00 00 00 01 00 02 00 03 00 04 00 05 00 06 00 07 00 08 00 09 00 0a 00 0b 00 0c 00 0d 00 0e 00 0f 00 10 00 11 00 12 00 13 00 14 00 15 00 16 00 17 00 18 00 19 00 1a 00 1b 00 1c 00 1d 00 1e 00 1f 00 20 00 21 00 22 00 23 00 24 00 25 00 26 00 27 00 28 00 29 00 2a 00 ";
            compare += "2b 00 2c 00 2d 00 2e 00 2f 00 30 00 31 00 32 00 33 00 34 00 35 00 36 00 37 00 38 00 39 00 3a 00 3b 00 3c 00 3d 00 3e 00 3f 00 40 00 41 00 42 00 43 00 44 00 45 00 46 00 47 00 48 00 49 00 4a 00 4b 00 4c 00 4d 00 4e 00 4f 00 50 00 51 00 52 00 53 00 54 00 55 00 56 00 57 00 58 00 59 00 5a 00 5b 00 5c 00 ";
            compare += "5d 00 5e 00 5f 00 60 00 61 00 62 00 63 00 64 00 65 00 66 00 67 00 68 00 69 00 6a 00 6b 00 6c 00 6d 00 6e 00 6f 00 70 00 71 00 72 00 73 00 74 00 75 00 76 00 77 00 78 00 79 00 7a 00 7b 00 7c 00 7d 00 7e 00 7f 00 80 00 81 00 82 00 83 00 84 00 85 00 86 00 87 00 88 00 89 00 8a 00 8b 00 8c 00 8d 00 8e 00 ";
            compare += "8f 00 90 00 91 00 72 00 93 00 94 00 95 00 96 00 97 00 98 00 99 00 9a 00 9b 00 9c 00 9d 00 9e 00 9f 00 a0 00 a1 00 a2 00 a3 00 a4 00 a5 00 a6 00 a7 00 a8 00 a9 00 aa 00 ab 00 ac 00 ad 00 ae 00 af 00 b0 00 b1 00 b2 00 b3 00 b4 00 b5 00 b6 00 b7 00 b8 00 b9 00 ba 00 bb 00 bc 00 bd 00 be 00 bf 00 c0 00 ";
            compare += "c1 00 c2 00 c3 00 c4 00 c5 00 c6 00 c7 00 c8 00 c9 00 ca 00 cb 00 cc 00 cd 00 ce 00 cf 00 d0 00 d1 00 d2 00 d3 00 d4 00 d5 00 d6 00 d7 00 d8 00 d9 00 da 00 db 00 dc 00 dd 00 de 00 df 00 e0 00 e1 00 e2 00 e3 00 e4 00 e5 00 e6 00 e7 00 e8 00 e9 00 ea 00 eb 00 ec 00 ed 00 ee 00 ef 00 f0 00 f1 00 f2 00 ";
            compare += "f3 00 f4 00 f5 00 f6 00 f7 00 f8 00 f9 00 fa 00 fb 00 fc 00 fd 00 fe 00 ff 00 00 00 01 00 02 00 03 00 04 00 05 00 06 00 07 00 08 00 09 00 0a 00 0b 00 0c 00 0d 00 0e 00 0f 00 10 00 11 00 12 00 13 00 14 00 15 00 16 00 17 00 18 00 19 00 1a 00 1b 00 1c 00 1d 00 1e 00 1f 00 20 00 21 00 22 00 23 00 24 00 ";
            compare += "25 00 26 00 27 00 28 00 29 00 2a 00 2b 00 2c 00 2d 00 2e 00 2f 00 30 00 31 00 32 00 33 00 34 00 35 00 36 00 37 00 38 00 39 00 3a 00 3b 00 3c 00 3d 00 3e 00 3f 00 40 00 41 00 42 00 43 00 44 00 45 00 46 00 47 00 48 00 49 00 4a 00 4b 00 4c 00 4d 00 4e 00 4f 00 50 00 51 00 52 00 53 00 54 00 55 00 56 00 ";
            compare += "57 00 58 00 59 00 5a 00 5b 00 5c 00 5d 00 5e 00 5f 00 60 00 61 00 62 00 63 00 64 00 65 00 66 00 67 00 68 00 69 00 6a 00 6b 00 6c 00 6d 00 6e 00 6f 00 70 00 71 00 72 00 73 00 74 00 75 00 76 00 77 00 78 00 79 00 7a 00 7b 00 7c 00 7d 00 7e 00 7f 00 80 00 81 00 82 00 83 00 84 00 85 00 86 00 87 00 88 00 ";
            compare += "89 00 8a 00 8b 00 8c 00 8d 00 8e 00 8f 00 90 00 91 00 72 00 93 00 94 00 95 00 96 00 97 00 98 00 99 00 9a 00 9b 00 9c 00 9d 00 9e 00 9f 00 a0 00 a1 00 a2 00 a3 00 a4 00 a5 00 a6 00 a7 00 a8 00 a9 00 aa 00 ab 00 ac 00 ad 00 ae 00 af 00 b0 00 b1 00 b2 00 b3 00 b4 00 b5 00 b6 00 b7 00 b8 00 b9 00 ba 00 ";
            compare += "bb 00 bc 00 bd 00 be 00 bf 00 c0 00 c1 00 c2 00 c3 00 c4 00 c5 00 c6 00 c7 00 c8 00 c9 00 ca 00 cb 00 cc 00 cd 00 ce 00 cf 00 d0 00 d1 00 d2 00 d3 00 d4 00 d5 00 d6 00 d7 00 d8 00 d9 00 da 00 db 00 dc 00 dd 00 de 00 df 00 e0 00 e1 00 e2 00 e3 00 e4 00 e5 00 e6 00 e7 00 e8 00 e9 00 ea 00 eb 00 ec 00 ";
            compare += "ed 00 ee 00 ef 00 f0 00 f1 00 f2 00 f3 00 f4 00 f5 00 f6 00 f7 00 f8 00 f9 00 fa 00 fb 00 fc 00 fd 00 fe 00 ff";
            int errCount = 0;
            int currentCount = 0;
            isStop = false;
            int delay = (int)numTimeDelay.Value;
            int readDataLen = (int)numTestDataLen.Value;
            InvokeAsync(() =>
            {
                EnableControl(sender as Control, false);
                while (!isStop)
                {
                    int revLen = UDPHelper.Send(WriteSDRAM, ip, out byte[] revWriteSDRAM, 200);
                    if (revLen == 0)
                    {
                        errCount++;
                        currentCount++;
                        WriteMessage("没有收到返回数据");
                        WriteTestMessage($"稳定性测试:当前次数:{currentCount},错误次数:{errCount}");
                        WriteTextFile($@"{folder}\error_{errCount}.txt", "写SDRAM没有收到返回数据");
                        continue;
                    }
                    System.Threading.Thread.Sleep(5);

                    revLen = UDPHelper.Send(writeFlash, ip, out byte[] revWriteFlash, 2000);
                    if (revLen == 0)
                    {
                        errCount++;
                        currentCount++;
                        WriteMessage("没有收到返回数据");
                        WriteTestMessage($"稳定性测试:当前次数:{currentCount},错误次数:{errCount}");
                        WriteTextFile($@"{folder}\error_{errCount}.txt", "SDRAM搬移到FLASH没有收到返回数据");
                        continue;
                    }
                    System.Threading.Thread.Sleep(5);

                    revLen = UDPHelper.Send(readFlash, ip, out byte[] revReadFlash, 200);
                    if (revLen == 0)
                    {
                        errCount++;
                        currentCount++;
                        WriteMessage("没有收到返回数据");
                        WriteTestMessage($"稳定性测试:当前次数:{currentCount},错误次数:{errCount}");
                        WriteTextFile($@"{folder}\error_{errCount}.txt", "读FLASH没有收到返回数据");
                        continue;
                    }
                    System.Threading.Thread.Sleep(5);

                    byte[] newData = new byte[readDataLen];
                    for (int i = 0; i < readDataLen; i++)
                    {
                        if (revReadFlash[i] == 0xaa && revReadFlash[i + 1] == 0x8e && revReadFlash[i + 2] == 0x41)
                        {
                            Array.Copy(revReadFlash, i, newData, 0, readDataLen);
                            break;
                        }
                    }

                    string revData = newData.ToString(" ").ToUpper();
                    if (revData != compare.ToUpper())
                    {
                        errCount++;
                        WriteMessage("错误:" + errCount.ToString());
                        string writeData = $"原数据:{compare.ToUpper()}\r\n读数据:{revData.ToUpper()}";
                        WriteTextFile($@"{folder}\error_{errCount}.txt", writeData);
                        while (true)
                        {
                            ReRead(readFlash, ip, folder, readDataLen, compare);
                        }
                    }
                    currentCount++;
                    WriteTestMessage($"稳定性测试:当前次数:{currentCount},错误次数:{errCount}");
                    System.Threading.Thread.Sleep(delay);
                }
                EnableControl(sender as Control, true);
            });
        }


        void ReRead(byte[] readFlash, string ip, string folder, int readDataLen, string compare)
        {
            int revLen = UDPHelper.Send(readFlash, ip, out byte[] revReadFlash, 200);
            if (revLen == 0)
            {
                WriteTextFile($@"{folder}\error_{5000}.txt", "读FLASH没有收到返回数据");
                return;
            }
            System.Threading.Thread.Sleep(5);

            byte[] newData = new byte[readDataLen];
            for (int i = 0; i < readDataLen; i++)
            {
                if (revReadFlash[i] == 0xaa && revReadFlash[i + 1] == 0x8e && revReadFlash[i + 2] == 0x41)
                {
                    Array.Copy(revReadFlash, i, newData, 0, readDataLen);
                    break;
                }
            }

            string revData = newData.ToString(" ").ToUpper();
            if (revData != compare.ToUpper())
            {
                string writeData = $"原数据:{compare.ToUpper()}\r\n读数据:{revData.ToUpper()}";
                WriteTextFile($@"{folder}\error_{5000}.txt", writeData);

            }
            System.Threading.Thread.Sleep(1);
        }

        #endregion
    }
}
