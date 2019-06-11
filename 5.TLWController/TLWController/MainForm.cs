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
using System.Runtime.InteropServices;

namespace TLWController
{
    public partial class MainForm : BaseFormV2
    {
        #region 私有变量
        private int _CurrentGridRowIndex = 0;
        private int _CurrentGridColumnIndex = 0;
        private Dictionary<string, int> _DevIP = new Dictionary<string, int>();
        private TLWCommand _TLWCommand = null;
        private bool _isBusy = false;
        private InterfaceData _InterfaceData = null;
        private string registerAddressFile = string.Empty;


        #endregion

        #region 内部结构
        private class ListItem
        {
            public int Value { get; set; }
            public string Text { get; set; }
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            registerAddressFile = System.IO.Path.Combine(Path, @"Config\Param2055.txt");
            MultiLanguage.GetNames(this, lang, Path + @"\Language");
            BindBrightnessColor();
            BindChipPos();
            BindParam2055Color();
            BindParam2055Hz();
            WriteOrReadInterfaceData(false); ;
            if (!Import2055Param(registerAddressFile))
            {
                MessageBox.Show(this, "导入2055参数失败");
                return;
            }
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

        private void BindBrightnessColor()
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

        private void BindChipPos()
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

        private void BindParam2055Color()
        {
            List<ListItem> items = new List<ListItem>()
            {
                new ListItem(){ Value=0, Text="全部" },
                new ListItem(){ Value=1, Text="红色" },
                new ListItem(){ Value=2, Text="绿色" },
                new ListItem(){ Value=3, Text="蓝色" }
            };
            cbParam2055Color.ValueMember = "Value";
            cbParam2055Color.DisplayMember = "Text";
            cbParam2055Color.DataSource = items;
        }

        private void BindParam2055Hz()
        {
            List<ListItem> items = new List<ListItem>()
            {
                new ListItem(){ Value=0, Text="50Hz" },
                new ListItem(){ Value=1, Text="60Hz" }
            };
            cbParam2055Refreshrate.ValueMember = "Value";
            cbParam2055Refreshrate.DisplayMember = "Text";
            cbParam2055Refreshrate.DataSource = items;
        }

        #endregion

        #region 辅助方法

        private void WriteOrReadInterfaceData(bool isWrite)
        {
            string file = $@"{Path}\Config\data.dat";
            if (isWrite)
            {
                _InterfaceData.BrightnessColor = cbBrightnessColor.SelectedIndex;
                _InterfaceData.BrightnessValue = (int)numBrightness.Value;
                _InterfaceData.ChipPosition = cbChipPos.SelectedIndex;
                _InterfaceData.FLASHAddress = (int)numRegAddr.Value;
                _InterfaceData.FLASHDataLength = (int)numFlashDataLen.Value;
                _InterfaceData.SDRAMAddress = (int)numSDRAMAddr.Value;
                _InterfaceData.SDRAMDataLength = (int)numSDRAMDataLength.Value;

                _InterfaceData.SerializeXML<InterfaceData>(file);
            }
            else
            {
                if (File.Exists(file))
                    _InterfaceData = file.DeserializeXML<InterfaceData>();
                else
                    _InterfaceData = new InterfaceData();

                cbBrightnessColor.SelectedIndex = _InterfaceData.BrightnessColor;
                numBrightness.Value = tbBrightness.Value = _InterfaceData.BrightnessValue;
                cbChipPos.SelectedIndex = _InterfaceData.ChipPosition;
                numRegAddr.Value = _InterfaceData.FLASHAddress;
                numFlashDataLen.Value = _InterfaceData.FLASHDataLength;
                numSDRAMAddr.Value = _InterfaceData.SDRAMAddress;
                numSDRAMDataLength.Value = _InterfaceData.SDRAMDataLength;
            }
        }

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
            string str = "";
            try
            {
                byte[] bytes = text.ToBytes();
                for (int i = 0; i < bytes.Length; i++)
                {
                    str += " " + bytes[i].ToString("X2");
                    if ((i + 1) % 1024 == 0)
                    {
                        str += "\r\n";
                    }
                }
            }
            catch
            {
                str = text;
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

        private bool Import2055Param(string file)
        {
            Register register = RegisterHelper.LoadRegister(file);
            if (register == null) return false;
            if (lang == "2052")
            {
                grid2055.Columns["ColENDescription"].Visible = false;
                grid2055.Columns["ColCNDescription"].Width = 500;
            }
            else
            {
                grid2055.Columns["ColCNDescription"].Visible = false;
                grid2055.Columns["ColENDescription"].Width = 500;
            }
            grid2055.Columns["ColDescription"].Visible = false;
            grid2055.Columns["ColRegisterAddress"].Visible = false;
            grid2055.Columns["ColRedAddress"].Visible = false;
            grid2055.Columns["ColGreenAddress"].Visible = false;
            grid2055.Columns["ColBlueAddress"].Visible = false;
            grid2055.Columns["ColStartBit"].Visible = false;
            grid2055.Columns["ColStopBit"].Visible = false;
            grid2055.Columns["ColMinValue"].Visible = false;
            grid2055.Columns["ColMaxValue"].Visible = false;
            grid2055.DataSource = register.RegisterItemList;

            cbParam2055Refreshrate.SelectedIndex = register.RefreshRate;
            ckDebugMode.Checked = register.IsDebug;
            numSpecialAddr.Value = register.SpecialRegister.RegisterAddress;

            return true;
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

        private DialogResult MainForm_FormClosing()
        {
            if (CheckIsBusy())
            {
                return DialogResult.No;
            }
            WriteOrReadInterfaceData(true);
            return DialogResult.Yes;
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
        private void btnApplyBrightness_Click(object sender, EventArgs e)
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

        //导入2055参数
        private void btnLoad2055Param_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "*.txt|*.txt";
            if (openFileDlg.ShowDialog(this) == DialogResult.Cancel) return;
            if (!Import2055Param(openFileDlg.FileName))
            {
                MessageBox.Show(this, "导入2055参数失败");
                return;
            }
        }

        private void btnExport2055Param_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.txt|*.txt";
            if (saveFileDialog.ShowDialog(this) == DialogResult.Cancel) return;
            Register reg = new Register();
            reg.RegisterItemList = grid2055.DataSource as List<RegisterItem>;
            reg.RefreshRate = (byte)cbParam2055Refreshrate.SelectedIndex;
            reg.IsDebug = ckDebugMode.Checked;
            reg.SpecialRegister = new RegisterSpectialItem();
            reg.SpecialRegister.StartBit = (byte)numSpecialStartBit.Value;
            reg.SpecialRegister.StopBit = (byte)numSpecialStopBit.Value;
            reg.SpecialRegister.RegisterAddress = (int)numSpecialAddr.Value;
            reg.SpecialRegister.Value = (byte)numSpectionValue.Value;

            RegisterHelper.SavevRegister(reg, saveFileDialog.FileName);

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

            byte val = 1;
            for (int i = 1; i <= numFlashDataLen.Value; i++)
            {
                if (val > 255 || val == 0) val = 1;
                data[i - 1] = val;
                val++;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.txt|*.txt";
            saveFileDialog.Title = "保存测试数据";
            saveFileDialog.FileName = "SDRAM_Write";
            if (saveFileDialog.ShowDialog(this) == DialogResult.Cancel) return;
            WriteTextFile(saveFileDialog.FileName, data.ToString(" "));

            byte chipPos = (byte)cbChipPos.SelectedValue.ToString().ToByte();
            EnableControl(sender as Control, false);
            _TLWCommand.tlw_SDRAM_Write(GetCardAddress(), GetId(), (uint)numSDRAMAddr.Value, data, _DevIP, (param) =>
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
               Array.ForEach(param, t => WriteOutput(t, "SDRAM写入FLASH"));
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

            //            compare = "aa 8e 42 04 19 01 01 00 00 00 03 00 00 00 00 00 01 00 01 01 00 01 02 03 04 05 06 07 08 09 0a 0b 0c 0d 0e 0f 10 11 12 13 14 15 16 17 18 19 1a 1b 1c 1d 1e 1f 20 21 22 23 24 25 26 27 28 29 2a 2b 2c 2d 2e 2f 30 31 32 33 ";
            //            compare += "34 35 36 37 38 39 3a 3b 3c 3d 3e 3f 40 41 42 43 44 45 46 47 48 49 4a 4b 4c 4d 4e 4f 50 51 52 53 54 55 56 57 58 59 5a 5b 5c 5d 5e 5f 60 61 62 63 64 65 66 67 68 69 6a 6b 6c 6d 6e 6f 70 71 72 73 74 75 76 77 78 79 7a 7b ";
            //            compare += "7c 7d 7e 7f 80 81 82 83 84 85 86 87 88 89 8a 8b 8c 8d 8e 8f 90 91 92 93 94 95 96 97 98 99 9a 9b 9c 9d 9e 9f a0 a1 a2 a3 a4 a5 a6 a7 a8 a9 aa ab ac ad ae af b0 b1 b2 b3 b4 b5 b6 b7 b8 b9 ba bb bc bd be bf c0 c1 c2 c3 ";
            //            compare += "c4 c5 c6 c7 c8 c9 ca cb cc cd ce cf d0 d1 d2 d3 d4 d5 d6 d7 d8 d9 da db dc dd de df e0 e1 e2 e3 e4 e5 e6 e7 e8 e9 ea eb ec ed ee ef f0 f1 f2 f3 f4 f5 f6 f7 f8 f9 fa fb fc fd fe ff 00 01 02 03 04 05 06 07 08 09 0a 0b ";
            //            compare += "0c 0d 0e 0f 10 11 12 13 14 15 16 17 18 19 1a 1b 1c 1d 1e 1f 20 21 22 23 24 25 26 27 28 29 2a 2b 2c 2d 2e 2f 30 31 32 33 34 35 36 37 38 39 3a 3b 3c 3d 3e 3f 40 41 42 43 44 45 46 47 48 49 4a 4b 4c 4d 4e 4f 50 51 52 53 54 ";
            //            compare += "55 56 57 58 59 5a 5b 5c 5d 5e 5f 60 61 62 63 64 65 66 67 68 69 6a 6b 6c 6d 6e 6f 70 71 72 73 74 75 76 77 78 79 7a 7b 7c 7d 7e 7f 80 81 82 83 84 85 86 87 88 89 8a 8b 8c 8d 8e 8f 90 91 92 93 94 95 96 97 98 99 9a 9b 9c 9d ";
            //            compare += "9e 9f a0 a1 a2 a3 a4 a5 a6 a7 a8 a9 aa ab ac ad ae af b0 b1 b2 b3 b4 b5 b6 b7 b8 b9 ba bb bc bd be bf c0 c1 c2 c3 c4 c5 c6 c7 c8 c9 ca cb cc cd ce cf d0 d1 d2 d3 d4 d5 d6 d7 d8 d9 da db dc dd de df e0 e1 e2 e3 e4 e5 e6 ";
            //            compare += "e7 e8 e9 ea eb ec ed ee ef f0 f1 f2 f3 f4 f5 f6 f7 f8 f9 fa fb fc fd fe ff 00 01 02 03 04 05 06 07 08 09 0a 0b 0c 0d 0e 0f 10 11 12 13 14 15 16 17 18 19 1a 1b 1c 1d 1e 1f 20 21 22 23 24 25 26 27 28 29 2a 2b 2c 2d 2e 2f ";
            //            compare += "30 31 32 33 34 35 36 37 38 39 3a 3b 3c 3d 3e 3f 40 41 42 43 44 45 46 47 48 49 4a 4b 4c 4d 4e 4f 50 51 52 53 54 55 56 57 58 59 5a 5b 5c 5d 5e 5f 60 61 62 63 64 65 66 67 68 69 6a 6b 6c 6d 6e 6f 70 71 72 73 74 75 76 77 78 ";
            //            compare += "79 7a 7b 7c 7d 7e 7f 80 81 82 83 84 85 86 87 88 89 8a 8b 8c 8d 8e 8f 90 91 92 93 94 95 96
            //97 98 99 9a 9b 9c 9d 9e 9f a0 a1 a2 a3 a4 a5 a6 a7 a8 a9 aa ab ac ad ae af b0 b1 b2 b3 b4 b5 b6 b7 b8 b9 ba bb bc bd be bf c0 c1 c2 c3 c4 c5 c6 c7 c8 c9 ca cb cc cd ce cf d0 d1 d2 d3 d4 d5 d6 d7 d8 d9 da db dc dd de df e0 e1 e2 e3 e4 e5 e6 e7 e8 e9 ea eb ec ed ee ef f0 f1 f2 f3 f4 f5 f6 f7 f8 f9 fa fb fc fd fe ff 00 01 02 03 04 05 06 07 08 09 0a 0b 0c 0d 0e 0f 10 11 12 13 14 15 16 17 18 19 1a 1b 1c 1d 1e 1f 20 21 22 23 24 25 26 27 28 29 2a 2b 2c 2d 2e 2f 30 31 32 33 34 35 36 37 38 39 3a 3b 3c 3d 3e 3f 40 41 42 43 44 45 46 47 48 49 4a 4b 4c 4d 4e 4f 50 51 52 53 54 55 56 57 58 59 5a 5b 5c 5d 5e 5f 60 61 62 63 64 65 66 67 68 69 6a 6b 6c 6d 6e 6f 70 71 72 73 74 75 76 77 78 79 7a 7b 7c 7d 7e 7f 80 81 82 83 84 85 86 87 88 89 8a 8b 8c 8d 8e 8f 90 91 92 93 94 95 96 97 98 99 9a 9b 9c 9d 9e 9f a0 a1 a2 a3 a4 a5 a6 a7 a8 a9 aa ab ac ad ae af b0 b1 b2 b3 b4 b5 b6 b7 b8 b9 ba bb bc bd be bf c0 c1 c2 c3 c4 c5 c6 c7 c8 c9 ca cb cc cd ce cf d0 d1 d2 d3 d4 d5 d6 d7 d8 d9 da db dc dd de df e0 e1 e2 e3 e4 e5 e6 e7 e8 e9 ea eb ec
            // ed ee ef f0 f1 f2 f3 f4 f5 f6 f7 f8 f9 fa fb fc fd";

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

            byte[] readFlash = "AA 8E 42 00 1D 01 01 00 00 00 03 00 00 00 00 00 01 00 01 00 02 3E 80 00 00 E4 55 71 BD".ToBytes();
            int errCount = 0;
            int currentCount = 0;
            isStop = false;
            int delay = (int)numTimeDelay.Value;
            int readDataLen = (int)numTestDataLen.Value;

            InvokeAsync(() =>
            {
                int index = 0;
                EnableControl(sender as Control, false);
                while (!isStop)
                {
                    byte[] revReadFlash = null;
                    int revLen = UDPHelper.Send(readFlash, ip, out revReadFlash, 100);
                    if (revLen == 0)
                    {
                        errCount++;
                        currentCount++;
                        WriteMessage("没有收到返回数据");
                        WriteTestMessage($"稳定性测试:当前次数:{currentCount},错误次数:{errCount}");
                        WriteTextFile($@"{folder}\error_{errCount}.txt", "没有收到返回数据");
                        continue;
                    }
                    if (index == 0)
                    {
                        compare = revReadFlash.ToString(" ").ToUpper();
                        index++;
                        continue;
                    }

                    string newStr = revReadFlash.ToString(" ").ToUpper();
                    if (newStr != compare)
                    {
                        errCount++;
                        WriteMessage("错误:" + errCount.ToString());
                        string writeData = $"{compare.ToUpper()}\r\n{newStr.ToUpper()}";
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

        private void btnReadAndWriteFlash_Click(object sender, EventArgs e)
        {
            string ip = GetCommunicationType().StartIPAddress;
            string folder = @"D:\测试文件夹\TSS\error_Write_Flash_Read_Flash";
            if (System.IO.Directory.Exists(folder)) System.IO.Directory.Delete(folder, true);
            System.IO.Directory.CreateDirectory(folder);


            int errCount = 0;
            int currentCount = 0;
            isStop = false;
            int delay = (int)numTimeDelay.Value;

            uint sectorSize = (uint)numFlashDataLen.Value;
            uint regAddr = (uint)numRegAddr.Value;
            byte chipPos = (byte)cbChipPos.SelectedValue.ToString().ToByte();

            EnableControl(sender as Control, false);
            InvokeAsync(() =>
            {

                while (!isStop)
                {
                    foreach (var item in _DevIP)
                    {
                        byte[] bytesWrite = new byte[(int)numFlashDataLen.Value];
                        byte[] bytesRead = new byte[(int)numFlashDataLen.Value];

                        Random rnd = new Random();
                        rnd.NextBytes(bytesWrite);
                        string compare = bytesWrite.ToString(" ");

                        int result = _TLWCommand.tlw_FLASH_Write(item.Value, GetCardAddress(), GetId(), chipPos, regAddr, bytesWrite, sectorSize);
                        System.Threading.Thread.Sleep(1000);
                        if (result == 0)
                        {
                            result = _TLWCommand.tlw_FLASH_Read(item.Value, GetCardAddress(), GetId(), chipPos, regAddr, bytesRead, sectorSize);
                            if (result == 0)
                            {
                                if (compare.ToUpper() != bytesRead.ToString(" ").ToUpper())
                                {
                                    errCount++;
                                    WriteMessage("错误:" + errCount.ToString());
                                    string writeData = $"{compare.ToUpper()}\r\n{bytesRead.ToString(" ").ToUpper()}";

                                    byte[] b1 = compare.ToBytes();
                                    byte[] b2 = bytesRead;
                                    string msg = "";
                                    if (b1.Length != b2.Length)
                                    {
                                        msg = "长度不同";
                                        WriteTestMessage(msg);
                                    }
                                    else
                                    {
                                        for (int i = 0; i < b1.Length; i++)
                                        {
                                            if (b1[i] != b2[i])
                                            {
                                                msg += $"index:{i} write1:{b1[i]} read:{b2[i]}";
                                            }
                                        }
                                    }
                                    WriteTextFile($@"{folder}\error_{errCount}_.txt", msg);
                                    WriteTestMessage(msg);
                                    isStop = true;//2019-06-11 错误立刻停止
                                }
                            }
                            else
                            {
                                errCount++;
                                WriteMessage("读取失败");
                                WriteTestMessage($"稳定性测试:当前次数:{currentCount},错误次数:{errCount}");
                                WriteTextFile($@"{folder}\error_{errCount}.txt", "读取失败");
                                continue;
                            }
                            currentCount++;
                            WriteTestMessage($"稳定性测试:当前次数:{currentCount},错误次数:{errCount}");
                            System.Threading.Thread.Sleep(delay);
                        }
                        else
                        {
                            errCount++;
                            currentCount++;
                            WriteTestMessage($"稳定性测试:当前次数:{currentCount},错误次数:{errCount}");
                            continue;
                        }
                    }
                }
                EnableControl(sender as Control, true);

            });

        }

        private void grid2055_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //(e.Control as DevComponents.DotNetBar.Controls.DataGridViewIntegerInputEditingControl).MinValue
            //grid2055.Rows[grid2055.SelectedRows[0].Index].DataBoundItem as TLWController.Helper.RegisterItem
            if (grid2055.SelectedRows.Count == 1)
            {
                RegisterItem regItemData = grid2055.Rows[grid2055.SelectedRows[0].Index].DataBoundItem as TLWController.Helper.RegisterItem;
                //grid2055.selected
                DevComponents.DotNetBar.Controls.DataGridViewIntegerInputEditingControl ctr = (e.Control as DevComponents.DotNetBar.Controls.DataGridViewIntegerInputEditingControl);
                ctr.MinValue = regItemData.MinValue;
                ctr.MaxValue = regItemData.MaxValue;
            }
        }

        private void grid2055_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            _CurrentGridRowIndex = e.RowIndex;
            _CurrentGridColumnIndex = e.ColumnIndex;
        }

        private void btnWriteSdramReadSdram_Click(object sender, EventArgs e)
        {
            string ip = GetCommunicationType().StartIPAddress;
            string folder = @"D:\测试文件夹\TSS\error_Write_SDRAM_Read_SDRAM";
            try
            { 
                if (System.IO.Directory.Exists(folder)) System.IO.Directory.Delete(folder, true);
                System.IO.Directory.CreateDirectory(folder);
            }
            catch  
            {
                MessageBox.Show("请关闭文件再试！");
                return;
            }

            string compare = "AA 8E 42 04 19 00 00 00 00 00 03 00 00 00 00 00 01 00 01 01 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F 10 11 12 13 14 15 16 17 18 19 1A 1B 1C 1D 1E 1F 20 21 22 23 24 25 26 27 28 29 2A 2B 2C 2D 2E 2F 30 31 32 33 34 35 36 37 38 39 3A 3B 3C 3D 3E 3F 40 41 42 43 44 45 46 47 48 49 4A 4B 4C 4D 4E 4F 50 51 52 53 54 55 56 57 58 59 5A 5B 5C 5D 5E 5F 60 61 62 63 64 65 66 67 68 69 6A 6B 6C 6D 6E 6F 70 71 72 73 74 75 76 77 78 79 7A 7B 7C 7D 7E 7F 80 81 82 83 84 85 86 87 88 89 8A 8B 8C 8D 8E 8F 90 91 92 93 94 95 96 97 98 99 9A 9B 9C 9D 9E 9F A0 A1 A2 A3 A4 A5 A6 A7 A8 A9 AA AB AC AD AE AF B0 B1 B2 B3 B4 B5 B6 B7 B8 B9 BA BB BC BD BE BF C0 C1 C2 C3 C4 C5 C6 C7 C8 C9 CA CB CC CD CE CF D0 D1 D2 D3 D4 D5 D6 D7 D8 D9 DA DB DC DD DE DF E0 E1 E2 E3 E4 E5 E6 E7 E8 E9 EA EB EC ED EE EF F0 F1 F2 F3 F4 F5 F6 F7 F8 F9 FA FB FC FD FE FF 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F 10 11 12 13 14 15 16 17 18 19 1A 1B 1C 1D 1E 1F 20 21 22 23 24 25 26 27 28 29 2A 2B 2C 2D 2E 2F 30 31 32 33 34 35 36 37 38 39 3A 3B 3C 3D 3E 3F 40 41 42 43 44 45 46 47 48 49 4A 4B 4C 4D 4E 4F 50 51 52 53 54 55 56 57 58 59 5A 5B 5C 5D 5E 5F 60 61 62 63 64 65 66 67 68 69 6A 6B 6C 6D 6E 6F 70 71 72 73 74 75 76 77 78 79 7A 7B 7C 7D 7E 7F 80 81 82 83 84 85 86 87 88 89 8A 8B 8C 8D 8E 8F 90 91 92 93 94 95 96 97 98 99 9A 9B 9C 9D 9E 9F A0 A1 A2 A3 A4 A5 A6 A7 A8 A9 AA AB AC AD AE AF B0 B1 B2 B3 B4 B5 B6 B7 B8 B9 BA BB BC BD BE BF C0 C1 C2 C3 C4 C5 C6 C7 C8 C9 CA CB CC CD CE CF D0 D1 D2 D3 D4 D5 D6 D7 D8 D9 DA DB DC DD DE DF E0 E1 E2 E3 E4 E5 E6 E7 E8 E9 EA EB EC ED EE EF F0 F1 F2 F3 F4 F5 F6 F7 F8 F9 FA FB FC FD FE FF 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F 10 11 12 13 14 15 16 17 18 19 1A 1B 1C 1D 1E 1F 20 21 22 23 24 25 26 27 28 29 2A 2B 2C 2D 2E 2F 30 31 32 33 34 35 36 37 38 39 3A 3B 3C 3D 3E 3F 40 41 42 43 44 45 46 47 48 49 4A 4B 4C 4D 4E 4F 50 51 52 53 54 55 56 57 58 59 5A 5B 5C 5D 5E 5F 60 61 62 63 64 65 66 67 68 69 6A 6B 6C 6D 6E 6F 70 71 72 73 74 75 76 77 78 79 7A 7B 7C 7D 7E 7F 80 81 82 83 84 85 86 87 88 89 8A 8B 8C 8D 8E 8F 90 91 92 93 94 95 96 97 98 99 9A 9B 9C 9D 9E 9F A0 A1 A2 A3 A4 A5 A6 A7 A8 A9 AA AB AC AD AE AF B0 B1 B2 B3 B4 B5 B6 B7 B8 B9 BA BB BC BD BE BF C0 C1 C2 C3 C4 C5 C6 C7 C8 C9 CA CB CC CD CE CF D0 D1 D2 D3 D4 D5 D6 D7 D8 D9 DA DB DC DD DE DF E0 E1 E2 E3 E4 E5 E6 E7 E8 E9 EA EB EC ED EE EF F0 F1 F2 F3 F4 F5 F6 F7 F8 F9 FA FB FC FD FE FF 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F 10 11 12 13 14 15 16 17 18 19 1A 1B 1C 1D 1E 1F 20 21 22 23 24 25 26 27 28 29 2A 2B 2C 2D 2E 2F 30 31 32 33 34 35 36 37 38 39 3A 3B 3C 3D 3E 3F 40 41 42 43 44 45 46 47 48 49 4A 4B 4C 4D 4E 4F 50 51 52 53 54 55 56 57 58 59 5A 5B 5C 5D 5E 5F 60 61 62 63 64 65 66 67 68 69 6A 6B 6C 6D 6E 6F 70 71 72 73 74 75 76 77 78 79 7A 7B 7C 7D 7E 7F 80 81 82 83 84 85 86 87 88 89 8A 8B 8C 8D 8E 8F 90 91 92 93 94 95 96 97 98 99 9A 9B 9C 9D 9E 9F A0 A1 A2 A3 A4 A5 A6 A7 A8 A9 AA AB AC AD AE AF B0 B1 B2 B3 B4 B5 B6 B7 B8 B9 BA BB BC BD BE BF C0 C1 C2 C3 C4 C5 C6 C7 C8 C9 CA CB CC CD CE CF D0 D1 D2 D3 D4 D5 D6 D7 D8 D9 DA DB DC DD DE DF E0 E1 E2 E3 E4 E5 E6 E7 E8 E9 EA EB EC ED EE EF F0 F1 F2 F3 F4 F5 F6 F7 F8 F9 FA FB FC FD FE FF 01 02 03 04 FE 2D 55 71 BD";

            byte[] writeSDRAM = "AA 8E 42 04 1C 00 00 00 00 00 06 00 00 00 00 00 01 00 01 00 00 00 00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F 10 11 12 13 14 15 16 17 18 19 1A 1B 1C 1D 1E 1F 20 21 22 23 24 25 26 27 28 29 2A 2B 2C 2D 2E 2F 30 31 32 33 34 35 36 37 38 39 3A 3B 3C 3D 3E 3F 40 41 42 43 44 45 46 47 48 49 4A 4B 4C 4D 4E 4F 50 51 52 53 54 55 56 57 58 59 5A 5B 5C 5D 5E 5F 60 61 62 63 64 65 66 67 68 69 6A 6B 6C 6D 6E 6F 70 71 72 73 74 75 76 77 78 79 7A 7B 7C 7D 7E 7F 80 81 82 83 84 85 86 87 88 89 8A 8B 8C 8D 8E 8F 90 91 92 93 94 95 96 97 98 99 9A 9B 9C 9D 9E 9F A0 A1 A2 A3 A4 A5 A6 A7 A8 A9 AA AB AC AD AE AF B0 B1 B2 B3 B4 B5 B6 B7 B8 B9 BA BB BC BD BE BF C0 C1 C2 C3 C4 C5 C6 C7 C8 C9 CA CB CC CD CE CF D0 D1 D2 D3 D4 D5 D6 D7 D8 D9 DA DB DC DD DE DF E0 E1 E2 E3 E4 E5 E6 E7 E8 E9 EA EB EC ED EE EF F0 F1 F2 F3 F4 F5 F6 F7 F8 F9 FA FB FC FD FE FF 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F 10 11 12 13 14 15 16 17 18 19 1A 1B 1C 1D 1E 1F 20 21 22 23 24 25 26 27 28 29 2A 2B 2C 2D 2E 2F 30 31 32 33 34 35 36 37 38 39 3A 3B 3C 3D 3E 3F 40 41 42 43 44 45 46 47 48 49 4A 4B 4C 4D 4E 4F 50 51 52 53 54 55 56 57 58 59 5A 5B 5C 5D 5E 5F 60 61 62 63 64 65 66 67 68 69 6A 6B 6C 6D 6E 6F 70 71 72 73 74 75 76 77 78 79 7A 7B 7C 7D 7E 7F 80 81 82 83 84 85 86 87 88 89 8A 8B 8C 8D 8E 8F 90 91 92 93 94 95 96 97 98 99 9A 9B 9C 9D 9E 9F A0 A1 A2 A3 A4 A5 A6 A7 A8 A9 AA AB AC AD AE AF B0 B1 B2 B3 B4 B5 B6 B7 B8 B9 BA BB BC BD BE BF C0 C1 C2 C3 C4 C5 C6 C7 C8 C9 CA CB CC CD CE CF D0 D1 D2 D3 D4 D5 D6 D7 D8 D9 DA DB DC DD DE DF E0 E1 E2 E3 E4 E5 E6 E7 E8 E9 EA EB EC ED EE EF F0 F1 F2 F3 F4 F5 F6 F7 F8 F9 FA FB FC FD FE FF 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F 10 11 12 13 14 15 16 17 18 19 1A 1B 1C 1D 1E 1F 20 21 22 23 24 25 26 27 28 29 2A 2B 2C 2D 2E 2F 30 31 32 33 34 35 36 37 38 39 3A 3B 3C 3D 3E 3F 40 41 42 43 44 45 46 47 48 49 4A 4B 4C 4D 4E 4F 50 51 52 53 54 55 56 57 58 59 5A 5B 5C 5D 5E 5F 60 61 62 63 64 65 66 67 68 69 6A 6B 6C 6D 6E 6F 70 71 72 73 74 75 76 77 78 79 7A 7B 7C 7D 7E 7F 80 81 82 83 84 85 86 87 88 89 8A 8B 8C 8D 8E 8F 90 91 92 93 94 95 96 97 98 99 9A 9B 9C 9D 9E 9F A0 A1 A2 A3 A4 A5 A6 A7 A8 A9 AA AB AC AD AE AF B0 B1 B2 B3 B4 B5 B6 B7 B8 B9 BA BB BC BD BE BF C0 C1 C2 C3 C4 C5 C6 C7 C8 C9 CA CB CC CD CE CF D0 D1 D2 D3 D4 D5 D6 D7 D8 D9 DA DB DC DD DE DF E0 E1 E2 E3 E4 E5 E6 E7 E8 E9 EA EB EC ED EE EF F0 F1 F2 F3 F4 F5 F6 F7 F8 F9 FA FB FC FD FE FF 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F 10 11 12 13 14 15 16 17 18 19 1A 1B 1C 1D 1E 1F 20 21 22 23 24 25 26 27 28 29 2A 2B 2C 2D 2E 2F 30 31 32 33 34 35 36 37 38 39 3A 3B 3C 3D 3E 3F 40 41 42 43 44 45 46 47 48 49 4A 4B 4C 4D 4E 4F 50 51 52 53 54 55 56 57 58 59 5A 5B 5C 5D 5E 5F 60 61 62 63 64 65 66 67 68 69 6A 6B 6C 6D 6E 6F 70 71 72 73 74 75 76 77 78 79 7A 7B 7C 7D 7E 7F 80 81 82 83 84 85 86 87 88 89 8A 8B 8C 8D 8E 8F 90 91 92 93 94 95 96 97 98 99 9A 9B 9C 9D 9E 9F A0 A1 A2 A3 A4 A5 A6 A7 A8 A9 AA AB AC AD AE AF B0 B1 B2 B3 B4 B5 B6 B7 B8 B9 BA BB BC BD BE BF C0 C1 C2 C3 C4 C5 C6 C7 C8 C9 CA CB CC CD CE CF D0 D1 D2 D3 D4 D5 D6 D7 D8 D9 DA DB DC DD DE DF E0 E1 E2 E3 E4 E5 E6 E7 E8 E9 EA EB EC ED EE EF F0 F1 F2 F3 F4 F5 F6 F7 F8 F9 FA FB FC FD FE FF 01 02 03 04 FE 32 55 71 BD".ToBytes();
            byte[] readSDRAM = "AA 8E 42 00 1D 00 00 00 00 00 03 00 00 00 00 00 01 00 01 00 00 00 00 00 00 22 55 71 BD".ToBytes();

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
                    int revLen = UDPHelper.Send(writeSDRAM, ip, out byte[] revWriteSDRAM);
                    if (revLen == 0)
                    {
                        errCount++;
                        currentCount++;
                        WriteMessage("没有收到返回数据");
                        WriteTestMessage($"稳定性测试:当前次数:{currentCount},错误次数:{errCount}");
                        WriteTextFile($@"{folder}\error_{errCount}.txt", "写FLASH没有收到返回数据");
                        continue;
                    }
                    System.Threading.Thread.Sleep(100);

                    revLen = UDPHelper.Send(readSDRAM, ip, out byte[] revReadSDRAM);
                    if (revLen == 0)
                    {
                        errCount++;
                        currentCount++;
                        WriteMessage("没有收到返回数据");
                        WriteTestMessage($"稳定性测试:当前次数:{currentCount},错误次数:{errCount}");
                        WriteTextFile($@"{folder}\error_{errCount}.txt", "读FLASH没有收到返回数据");
                        continue;
                    }
                    string revStr = revReadSDRAM.ToString(" ").ToUpper();
                    if (revStr != compare)
                    {
                        //errCount++;
                        //WriteMessage("错误:" + errCount.ToString());
                        //string writeData = $"{compare.ToUpper()}\r\n{revStr.ToUpper()}";
                        //WriteTextFile($@"{folder}\error_{errCount}.txt", writeData);


                        errCount++;
                        WriteMessage("错误:" + errCount.ToString());
                        string writeData = $"{compare.ToUpper()}\r\n{revReadSDRAM.ToString(" ").ToUpper()}";

                        byte[] b1 = compare.ToBytes();
                        byte[] b2 = revReadSDRAM;
                        string msg = "";
                        if (b1.Length != b2.Length)
                        {
                            msg = "数据包长度不同";
                            WriteMessage(msg);
                        }
                        else
                        {
                            msg += "\tLeft Side:(send)\t Right Side:(recieve)\r\n";

                            bool bFindERROR = false;
                            for (int i = 0; i < b1.Length; i++)
                            {
                                string szLine = string.Format("\t[{0}]\t{1:X2}\t{2:X2}\r\n", i, b1[i], b2[i]);
                                
                                if ((bFindERROR == false) && (b1[i] != b2[i]))
                                {
                                    //msg += $"index:{i} write1:{b1[i]} read:{b2[i]}";
                                    WriteMessage(string.Format("diff pos={0}/{1} (src,recv)(0x{2:X2},0x{3:X2})", i, b1.Length,b1[i], b2[i]));
                                    szLine = string.Format("======>>[{0}]\t{1:X2}\t{2:X2}<<==================\r\n", i, b1[i], b2[i]);
                                    //break;
                                    bFindERROR = true;
                                }
                                msg += szLine;
                       
                            }
                            if (bFindERROR)
                                isStop = true;

                            //msg += "\r\n";
                            //msg += b1.ToString(" ") + "\r\n";
                            //msg += b2.ToString(" ") + "\r\n";

                            WriteTextFile($@"{folder}\error_{errCount}_.txt", msg);
                        }
                    }
                    currentCount++;
                    WriteTestMessage($"稳定性测试:当前次数:{currentCount},错误次数:{errCount}");
                    System.Threading.Thread.Sleep(delay);
                }
                EnableControl(sender as Control, true);
            });
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        byte[] CreateHeader()
        {
            return new byte[20];
        }

        byte[] CreaterFooter()
        {
            return new byte[5];
        }

        void SetCmdHeader(byte[] header, uint cmdNum)
        {
            byte[] bytes = cmdNum.GetBytes();
            Array.Copy(bytes, 0, header, 0, bytes.Length - 1);
        }

        void SetDevAddr(byte[] header, ushort devAddr)
        {
            byte[] bytes = devAddr.GetBytes();
            Array.Copy(bytes, 5, header, 0, bytes.Length);
        }

        void SetId(byte[] header, ushort id)
        {
            byte[] bytes = id.GetBytes();
            Array.Copy(bytes, 7, header, 0, bytes.Length);
        }

        void SetCmdNum(byte[] header, ushort cmdNum)
        {
            byte[] bytes = cmdNum.GetBytes();
            Array.Copy(bytes, 9, header, 0, bytes.Length);
        }

        void SetPackageCount(byte[] header, ushort count)
        {
            byte[] bytes = count.GetBytes();
            Array.Copy(bytes, 15, header, 0, bytes.Length);
        }

        void SetPackageIndex(byte[] header, ushort index)
        {
            byte[] bytes = index.GetBytes();
            Array.Copy(bytes, 17, header, 0, bytes.Length);
        }

        void SetCommandState(byte[] header, byte state)
        {
            byte[] bytes = state.GetBytes();
            Array.Copy(bytes, 17, header, 0, bytes.Length);
        }

        void SetDataLength(byte allData,ushort dataLength)
        {
        }

        byte[] CombinData(byte[] header, byte[] data, byte[] footer)
        {
            int pos = 0;
            byte[] result = new byte[header.Length + data.Length + footer.Length];
            Array.Copy(header, 0, result, pos, header.Length);
            pos += header.Length;
            Array.Copy(data, 0, result, pos, data.Length);
            pos += data.Length;
            Array.Copy(footer, 0, result, pos, footer.Length);
            return result;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            List<byte> content = new List<byte>();
            byte[] sdramAddr = new byte[3];
            Array.Copy(((uint)numSDRAMAddr.Value).GetBytes(), 0, sdramAddr, 0, 3);
            content.AddRange(sdramAddr);
            byte val = 0;
            for (int i = 1; i <= 1024; i++)
            {
                if (val > 255 || val == 0) val = 1;
                content.Add(val);
                val++;
            }

            byte[] header = CreateHeader();
            byte[] footer = CreaterFooter();
            SetCmdHeader(header, 0xAA8E42);
            SetDevAddr(header, GetCardAddress());
            SetId(header, GetId());
            SetCmdNum(header, 0x0006);
            SetPackageCount(header, 1);
            SetPackageIndex(header, 1);
            SetCommandState(header, 1);


            byte[] allData = CombinData(header, content.ToArray(), footer);


        }
    }
}
