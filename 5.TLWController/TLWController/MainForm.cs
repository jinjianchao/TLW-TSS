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
using TLWComm;
using System.Collections;
using System.Threading;
using GAMMAProcessLib;

namespace TLWController
{
    public partial class MainForm : BaseFormV2
    {
        #region 私有变量
        private int _CurrentGridRowIndex = 0;
        private int _CurrentGridColumnIndex = 0;
        private int _CurrentOtherGridRowIndex = 0;
        private int _CurrentOtherGridColumnIndex = 0;

        private Dictionary<string, int> _DevIP = new Dictionary<string, int>();
        private TLWCommand _TLWCommand = null;
        private bool _isBusy = false;
        private InterfaceData _InterfaceData = null;
        private string registerAddressFile = string.Empty;

        #region 2072

        //2072
        private Control[][] m_arrControl = new Control[17][];//17个寄存器
        private int[][] m_arrBitWidth = new int[17][];//记录位宽
        private int[][] m_arrStartBit = new int[17][];//记录起始位置(低位)
        private byte[] m_arrRegAddr = null;//每个地址需要两个16bit寄存器地址
        private string[] m_arrTitle = { "0x01", "0x02", "0x03", "0x04", "0x05", "0x06", "0x07", "0x08", "0x09", "0x0a", "0x0b", "0x0c", "0x0d", "0xf0", "0xf1", "0xf2", "0xf3" };


        //----------2072 simple -------------
        private class2072Oper m_2072SimpleParam;//0 = 60Hz  1=50Hz  2=3D
        private int m_n2072SimpleIndex = 0;

        //2017-3-21 最大GAMMA值
        const float MAX_Gamma = 6f;

        //--------2072 Factory-----------
        private int m_n2072FactoryIndex = 0;//0 = 60Hz  1=50Hz  2=3D
        private class2072Oper m_2072FactoryParam;

        private classMBParam m_MBParamObj = null;

        #endregion

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
            CheckForIllegalCrossThreadCalls = false;
            NumericUpDown numericUpDownForGrid = new NumericUpDown();
            numericUpDownForGrid.Name = "numValue";
            grid2055.Controls.Add(numericUpDownForGrid);
            NumericUpDown numericUpDownForOtherGrid = new NumericUpDown();
            numericUpDownForOtherGrid.Name = "numOtherValue";
            gridOtherReg.Controls.Add(numericUpDownForOtherGrid);
            numericUpDownForOtherGrid.Hexadecimal = true;
            numericUpDownForOtherGrid.Visible = false;

            ComboBox comboBoxForGrid = new ComboBox();
            comboBoxForGrid.Name = "cbValue";
            comboBoxForGrid.DropDownStyle = ComboBoxStyle.DropDownList;
            grid2055.Controls.Add(comboBoxForGrid);

            ComboBox comboBoxForOtherGrid = new ComboBox();
            comboBoxForOtherGrid.Name = "cbOtherValue";
            comboBoxForOtherGrid.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxForOtherGrid.Visible = false;
            gridOtherReg.Controls.Add(comboBoxForOtherGrid);

            registerAddressFile = System.IO.Path.Combine(Path, @"Config\Param2055.txt");
            MultiLanguage.GetNames(this, lang, Path + @"\Language");
            BindBrightnessColor();
            BindChipPos();
            BindParam2055Color();
            BindGammaBit();
            BindGammaColor();
            BindRegisterChip();
            BindAdvChip();
            BindVideoCardParamType();
            BindWorkMode();
            BindCalibrationOnOff();
            WriteOrReadInterfaceData(false);



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
                tab2055Param.Enabled = false;
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
            string txt = MultiLanguage.GetNames(this.Name, key);
            if (string.IsNullOrEmpty(txt))
            {
                return key;
            }
            else
            {
                return txt;
            }
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
            //cbMapPos.ValueMember = "Value";
            //cbMapPos.DisplayMember = "Text";
            //cbMapPos.DataSource = items;

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

        private void BindGammaBit()
        {
            //0 = 10bit GAMMA, 1024个16bit数据,1 = 13bit GAMMA, 4096个16bit数据,2=16bit GAMMA, 32768个16bit数据,3 = HDR, 1024个16bit数据
            List<ListItem> items = new List<ListItem>()
            {
                new ListItem(){ Value=0, Text="10bit" },
                new ListItem(){ Value=1, Text="13bit" },
                new ListItem(){ Value=2, Text="16bit" },
                new ListItem(){ Value=3, Text="HDR" }
            };
            cbGammaBit.ValueMember = "Value";
            cbGammaBit.DisplayMember = "Text";
            cbGammaBit.DataSource = items;
        }

        private void BindGammaColor()
        {
            //1 = 红色,2 = 绿色,3 = 蓝色
            List<ListItem> items = new List<ListItem>()
            {
                new ListItem(){ Value=0, Text="全部" },
                new ListItem(){ Value=1, Text="红色" },
                new ListItem(){ Value=2, Text="绿色" },
                new ListItem(){ Value=3, Text="蓝色" }
            };
            cbGammaColor.ValueMember = "Value";
            cbGammaColor.DisplayMember = "Text";
            cbGammaColor.DataSource = items;
        }

        private void BindRegisterChip()
        {
            //1 = 红色,2 = 绿色,3 = 蓝色
            List<ListItem> items = new List<ListItem>()
            {
                new ListItem(){ Value=0, Text="FPGA" },
                new ListItem(){ Value=1, Text="4K视频芯片" }
            };
            cbRegChip.ValueMember = "Value";
            cbRegChip.DisplayMember = "Text";
            cbRegChip.DataSource = items;
        }

        private void BindAdvChip()
        {
            //1 = 红色,2 = 绿色,3 = 蓝色
            List<ListItem> items = new List<ListItem>()
            {
                new ListItem(){ Value=0, Text="区域1" },
                new ListItem(){ Value=1, Text="区域2" },
                new ListItem(){ Value=2, Text="区域3" }
            };
            cbAdvChip.ValueMember = "Value";
            cbAdvChip.DisplayMember = "Text";
            cbAdvChip.DataSource = items;
        }

        private void BindVideoCardParamType()
        {
            //0 全部加载 1校正数据 2 红色GAMMA 3绿色GAMMA 4蓝色GAMMA 5 MAP  6 寄存器数组1  7 寄存器数组2
            List<ListItem> items = new List<ListItem>()
            {
                new ListItem(){ Value=0, Text="全部加载" },
                new ListItem(){ Value=1, Text="校正数据" },
                new ListItem(){ Value=2, Text="红色GAMMA" },
                new ListItem(){ Value=3, Text="绿色GAMMA" },
                new ListItem(){ Value=4, Text="蓝色GAMMA" },
                new ListItem(){ Value=5, Text="MAP" },
                new ListItem(){ Value=6, Text="寄存器数组1" },
                new ListItem(){ Value=7, Text="寄存器数组2" }
            };
            cbVideocardLoadParam.ValueMember = "Value";
            cbVideocardLoadParam.DisplayMember = "Text";
            cbVideocardLoadParam.DataSource = items;
        }

        private void BindWorkMode()
        {
            //0 全部加载 1校正数据 2 红色GAMMA 3绿色GAMMA 4蓝色GAMMA 5 MAP  6 寄存器数组1  7 寄存器数组2
            //            十六进制
            //00 视频
            //80 白
            //81 黑
            //82 蓝色
            //83 绿色
            //84 红色
            //85 灰度渐变
            //86 低灰度渐变
            //87 斜线

            List<ListItem> items = new List<ListItem>()
            {
                new ListItem(){ Value=0x00, Text="视频" },
                new ListItem(){ Value=0x80, Text="白" },
                new ListItem(){ Value=0x81, Text="黑" },
                new ListItem(){ Value=0x82, Text="蓝色" },
                new ListItem(){ Value=0x83, Text="绿色" },
                new ListItem(){ Value=0x84, Text="红色" },
                new ListItem(){ Value=0x85, Text="灰度渐变" },
                new ListItem(){ Value=0x86, Text="低灰度渐变" },
                new ListItem(){ Value=0x87, Text="斜线" }
            };
            cbWorkMode.ValueMember = "Value";
            cbWorkMode.DisplayMember = "Text";
            cbWorkMode.DataSource = items;
        }

        private void BindCalibrationOnOff()
        {
            //0 全部加载 1校正数据 2 红色GAMMA 3绿色GAMMA 4蓝色GAMMA 5 MAP  6 寄存器数组1  7 寄存器数组2
            //            十六进制
            //00 视频
            //80 白
            //81 黑
            //82 蓝色
            //83 绿色
            //84 红色
            //85 灰度渐变
            //86 低灰度渐变
            //87 斜线

            List<ListItem> items = new List<ListItem>()
            {
                new ListItem(){ Value=0x00, Text="关" },
                new ListItem(){ Value=0x01, Text="开" }
            };
            cbCalibrationOnOff.ValueMember = "Value";
            cbCalibrationOnOff.DisplayMember = "Text";
            cbCalibrationOnOff.DataSource = items;
        }



        private void Bind2072Param()
        {
            //2072初始化
            Initial2072();

            //-------------2072Simple界面--------------
            cb2072FuncTest2.SelectedIndex = 0;
            cb2072FuncTest3.SelectedIndex = cb2072FuncTest3.Items.Count - 1;

            cb2072Simple1.Items.Clear();
            cb2072Simple1.Items.Add(Trans("帧同步"));
            cb2072Simple1.Items.Add(Trans("帧间隔"));
            cb2072Simple1.SelectedIndex = 0;

            //处理类对象初始化
            m_2072SimpleParam = new class2072Oper();
            m_2072SimpleParam.FindCtrls(panel3);
            m_2072SimpleParam.AddCtrl_2019(new Control[] { input2019Simple_160, input2019Simple_161, input2019Simple_162, input2019Simple_163 });
            m_2072SimpleParam.AddCtrl_Register128(new Control[] { input2072FuncRegAddr, cb2072FuncTest2, cb2072FuncTest3, input2072FuncVal });//2019-03-25 新增寄存器128地址的控制

            //50/60Hz模式切换
            cb2072Simple5060Hz.Items.Clear();
            cb2072Simple5060Hz.Items.Add("60Hz");
            cb2072Simple5060Hz.Items.Add("50Hz");
            cb2072Simple5060Hz.Items.Add("3D");
            cb2072Simple5060Hz.SelectedIndex = 0;//默认60Hz

            //GAMMA
            cb2072SimpleGAMMA.Items.Clear();
            cb2072SimpleGAMMA.Items.Add(Trans("全部"));
            cb2072SimpleGAMMA.Items.Add(Trans("红色"));
            cb2072SimpleGAMMA.Items.Add(Trans("绿色"));
            cb2072SimpleGAMMA.Items.Add(Trans("蓝色"));
            cb2072SimpleGAMMA.SelectedIndex = 0;

            //-------------2072Simple界面 End ----------------


            //------------------2072 Factory模式 ---------------------

            //2018-09-26 2200操作类

            //处理类对象初始化
            m_2072FactoryParam = new class2072Oper();
            m_2072FactoryParam.FindCtrls(panel4);
            //m_2072FactoryParam.AddCtrl_2019(new Control[] { input2019Simple_160, input2019Simple_161, input2019Simple_162, input2019Simple_163 });
            m_2072FactoryParam.AddCtrl_Register128(new Control[] { input2072FactoryRegisterAddr, cb2072FactoryRegister_StartBit, cb2072FactoryRegister_EndBit, input2072FactoryRegisterVal });//2019-03-25 新增寄存器128地址的控制

            //选中某个模式 60Hz、50Hz、3D
            cb2072Factory5060Hz.Items.Clear();
            cb2072Factory5060Hz.Items.Add("60Hz");
            cb2072Factory5060Hz.Items.Add("50Hz");
            cb2072Factory5060Hz.Items.Add("3D");
            cb2072Factory5060Hz.SelectedIndex = 0;

            cb2072FactoryRegister_StartBit.Items.Clear();
            cb2072FactoryRegister_EndBit.Items.Clear();
            for (int i = 0; i < 16; i++)
            {
                cb2072FactoryRegister_StartBit.Items.Add(i.ToString());
                cb2072FactoryRegister_EndBit.Items.Add(i.ToString());
            }
            cb2072FactoryRegister_StartBit.SelectedIndex = 0;
            cb2072FactoryRegister_EndBit.SelectedIndex = 15;

            input2072FactoryRegisterAddr.Text = "128";
            input2072FactoryRegisterVal.Text = "128";

            //------------------2072 Factory模式  End------------------
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
                _InterfaceData.VideocardLoadParam = (int)cbVideocardLoadParam.SelectedIndex;
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
                cbVideocardLoadParam.SelectedIndex = _InterfaceData.VideocardLoadParam;
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

        string ReadTextFile(string file)
        {
            TextReader textReader = new StreamReader(file);
            string str = textReader.ReadToEnd();
            textReader.Close();
            return str;
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

        ushort GetMBAddr()
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

        ushort GetCardAddress(int x, int y)
        {
            ushort cardAddr = (ushort)(x << 8 | y);
            return cardAddr;
        }

        bool CheckDeviceAddr()
        {
            return true;
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

        bool CheckDeviceAddrIsZero()
        {
            Point addr = GetUnitAddr();
            if (addr.X == 0 && addr.Y == 0)
            {
                return true;
            }

            return false;
        }

        void OpenUDPDevice()
        {
            _TLWCommand.PackageDelay = GetSendDataTime();
            _TLWCommand.SendWait = GetReceiveDataTime();

            _TLWCommand.PackageDelay = 1;
            _TLWCommand.SendWait = 1;

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
            Register register = Register2055Helper.Load2055Register(file);
            if (register == null) return false;
            grid2055.Columns["CoCheckBox"].DisplayIndex = 0;
            grid2055.Columns["ColOffset"].DisplayIndex = 1;
            grid2055.Columns["ColENDescription"].DisplayIndex = 2;
            grid2055.Columns["ColCNDescription"].DisplayIndex = 3;
            grid2055.Columns["ColDescription"].DisplayIndex = 4;
            grid2055.Columns["ColRegisterAddress"].DisplayIndex = 5;
            grid2055.Columns["ColRedAddress"].DisplayIndex = 6;
            grid2055.Columns["ColGreenAddress"].DisplayIndex = 7;
            grid2055.Columns["ColBlueAddress"].DisplayIndex = 8;
            grid2055.Columns["ColStartBit"].DisplayIndex = 9;
            grid2055.Columns["ColStopBit"].DisplayIndex = 10;
            grid2055.Columns["ColMinValue"].DisplayIndex = 11;
            grid2055.Columns["ColMaxValue"].DisplayIndex = 12;

            if (lang == "2052")
            {
                grid2055.Columns["ColENDescription"].Visible = false;
                grid2055.Columns["ColCNDescription"].Width = 300;
            }
            else
            {
                grid2055.Columns["ColCNDescription"].Visible = false;
                grid2055.Columns["ColENDescription"].Width = 300;
            }
            grid2055.Columns["ColOffset"].Width = 200;
            grid2055.Columns["CoCheckBox"].Visible = false;
            grid2055.Columns["ColDescription"].Visible = false;
            grid2055.Columns["ColRegisterAddress"].Visible = false;
            grid2055.Columns["ColRedAddress"].Visible = false;
            grid2055.Columns["ColGreenAddress"].Visible = false;
            grid2055.Columns["ColBlueAddress"].Visible = false;
            grid2055.Columns["ColStartBit"].Visible = false;
            grid2055.Columns["ColStopBit"].Visible = false;
            grid2055.Columns["ColMinValue"].Visible = false;
            grid2055.Columns["ColMaxValue"].Visible = false;
            //grid2055.Columns["ColSend"].Visible = false;
            grid2055.DataSource = register.Register2055ItemList;
            grid2055.AllowUserToOrderColumns = false;
            ckDebugMode.Checked = register.Is2055Debug;

            gridOtherReg.DataSource = register.Register2055OtherItemList;
            gridOtherReg.Columns["ColOtherCheckBox"].DisplayIndex = 0;
            gridOtherReg.Columns["ColOtherENDescription"].DisplayIndex = 1;
            gridOtherReg.Columns["ColOtherCNDescription"].DisplayIndex = 1;
            gridOtherReg.Columns["ColOtherRegisterAddress"].DisplayIndex = 2;
            gridOtherReg.Columns["ColOtherStartBit"].DisplayIndex = 4;
            gridOtherReg.Columns["ColOtherStopBit"].DisplayIndex = 5;
            gridOtherReg.Columns["ColOtherMinValue"].DisplayIndex = 6;
            gridOtherReg.Columns["ColOtherMaxValue"].DisplayIndex = 7;

            if (lang == "2052")
            {
                gridOtherReg.Columns["ColOtherENDescription"].Visible = false;
                gridOtherReg.Columns["ColOtherCNDescription"].Width = 500;
            }
            else
            {
                gridOtherReg.Columns["ColOtherCNDescription"].Visible = false;
                gridOtherReg.Columns["ColOtherENDescription"].Width = 500;
            }
            gridOtherReg.Columns["ColOtherCheckBox"].Visible = false;
            gridOtherReg.Columns["ColOtherRegisterAddress"].Visible = true;
            gridOtherReg.Columns["ColOtherStartBit"].Visible = false;
            gridOtherReg.Columns["ColOtherStopBit"].Visible = false;
            gridOtherReg.Columns["ColOtherMinValue"].Visible = false;
            gridOtherReg.Columns["ColOtherMaxValue"].Visible = false;
            gridOtherReg.AllowUserToOrderColumns = false;
            return true;
        }

        private bool Import2072Param(string file)
        {
            Register register = Register2055Helper.Load2055Register(file);
            if (register == null) return false;
            grid2055.Columns["CoCheckBox"].DisplayIndex = 0;
            grid2055.Columns["ColOffset"].DisplayIndex = 1;
            grid2055.Columns["ColENDescription"].DisplayIndex = 2;
            grid2055.Columns["ColCNDescription"].DisplayIndex = 3;
            grid2055.Columns["ColDescription"].DisplayIndex = 4;
            grid2055.Columns["ColRegisterAddress"].DisplayIndex = 5;
            grid2055.Columns["ColRedAddress"].DisplayIndex = 6;
            grid2055.Columns["ColGreenAddress"].DisplayIndex = 7;
            grid2055.Columns["ColBlueAddress"].DisplayIndex = 8;
            grid2055.Columns["ColStartBit"].DisplayIndex = 9;
            grid2055.Columns["ColStopBit"].DisplayIndex = 10;
            grid2055.Columns["ColMinValue"].DisplayIndex = 11;
            grid2055.Columns["ColMaxValue"].DisplayIndex = 12;

            if (lang == "2052")
            {
                grid2055.Columns["ColENDescription"].Visible = false;
                grid2055.Columns["ColCNDescription"].Width = 300;
            }
            else
            {
                grid2055.Columns["ColCNDescription"].Visible = false;
                grid2055.Columns["ColENDescription"].Width = 300;
            }
            grid2055.Columns["ColOffset"].Width = 200;
            grid2055.Columns["CoCheckBox"].Visible = false;
            grid2055.Columns["ColDescription"].Visible = false;
            grid2055.Columns["ColRegisterAddress"].Visible = false;
            grid2055.Columns["ColRedAddress"].Visible = false;
            grid2055.Columns["ColGreenAddress"].Visible = false;
            grid2055.Columns["ColBlueAddress"].Visible = false;
            grid2055.Columns["ColStartBit"].Visible = false;
            grid2055.Columns["ColStopBit"].Visible = false;
            grid2055.Columns["ColMinValue"].Visible = false;
            grid2055.Columns["ColMaxValue"].Visible = false;
            //grid2055.Columns["ColSend"].Visible = false;
            grid2055.DataSource = register.Register2055ItemList;
            grid2055.AllowUserToOrderColumns = false;
            ckDebugMode.Checked = register.Is2055Debug;

            gridOtherReg.DataSource = register.Register2055OtherItemList;
            gridOtherReg.Columns["ColOtherCheckBox"].DisplayIndex = 0;
            gridOtherReg.Columns["ColOtherENDescription"].DisplayIndex = 1;
            gridOtherReg.Columns["ColOtherCNDescription"].DisplayIndex = 1;
            gridOtherReg.Columns["ColOtherRegisterAddress"].DisplayIndex = 2;
            gridOtherReg.Columns["ColOtherStartBit"].DisplayIndex = 4;
            gridOtherReg.Columns["ColOtherStopBit"].DisplayIndex = 5;
            gridOtherReg.Columns["ColOtherMinValue"].DisplayIndex = 6;
            gridOtherReg.Columns["ColOtherMaxValue"].DisplayIndex = 7;

            if (lang == "2052")
            {
                gridOtherReg.Columns["ColOtherENDescription"].Visible = false;
                gridOtherReg.Columns["ColOtherCNDescription"].Width = 500;
            }
            else
            {
                gridOtherReg.Columns["ColOtherCNDescription"].Visible = false;
                gridOtherReg.Columns["ColOtherENDescription"].Width = 500;
            }
            gridOtherReg.Columns["ColOtherCheckBox"].Visible = false;
            gridOtherReg.Columns["ColOtherRegisterAddress"].Visible = true;
            gridOtherReg.Columns["ColOtherStartBit"].Visible = false;
            gridOtherReg.Columns["ColOtherStopBit"].Visible = false;
            gridOtherReg.Columns["ColOtherMinValue"].Visible = false;
            gridOtherReg.Columns["ColOtherMaxValue"].Visible = false;
            gridOtherReg.AllowUserToOrderColumns = false;
            return true;
        }

        /// <summary>
        /// 读取主板信息到对象m_MBParamObj
        /// </summary>
        /// <returns></returns>
        private bool ReadMBParamToObj(string ip)
        {
            //2018-1-15读取主板参数 获取当前是高刷还是低刷，3D/2D,60/50Hz情况
            byte[] arrData = new byte[512];
#if DEBUG

#else
            if (ReadParameters(ip, 0xFFFF, arrData, 512) == false)
            {
                string info = Trans("主板参数读取失败");
                WriteOutputWithTime(info);
                return false;//读取失败
            }
#endif

            m_MBParamObj = null;

            m_MBParamObj = new classMBParam(arrData, 0, arrData.Length);

            return true;
        }

        private void HideSomeCtrlsBeforeImportFile(bool bHide = true)
        {
            //
            List<Control> arrCtrl = new List<Control>{btn2072Simple_ExportFile,btn2072Simple_ResetValues,btn2072Simple_SendAll,
                                    gP2072Simple1,gP2072Simple2,gP2072Simple3,gP2072Simple4,gP2072Simple5,
                                    gP2072Simple6,gP2072Simple7,gP2072Simple8,gP2072Simple9,gP2072Simple10,
                                    gP2072Simple11,gP2072Simple12,gP2072Simple13,gpSimple2072GAMMA,gpSimple2019,gp2072FuncTest,btn2072Simple2_TryCalc
                                };
            if (bHide)
            {//应该隐藏
                foreach (Control item in arrCtrl)
                {
                    item.Enabled = false;
                }
            }
            else
            {//应该显示
                foreach (Control item in arrCtrl)
                {
                    item.Enabled = true;
                }

                //if (IsUsingNewFPGA() == false)
                //{//移植版 使用Altera或Xilinx
                //    gpSimple2019.Visible = false;
                //}
                //else
                {//安路FPGA的时候才显示
                    gpSimple2019.Visible = true;
                }
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
            SetPrograss(e.Message, e.Message, e.Percent);
        }

        private DialogResult MainForm_FormClosing()
        {
            if (CheckIsBusy())
            {
                return DialogResult.No;
            }
            WriteOrReadInterfaceData(true);
            Register reg = new Register();
            reg.Register2055OtherItemList = gridOtherReg.DataSource as List<RegisterOtherItem>;
            reg.Register2055ItemList = grid2055.DataSource as List<RegisterItem>;
            reg.Is2055Debug = ckDebugMode.Checked;
            reg.Special2055Register = new RegisterSpectialItem();

            Register2055Helper.Save2055Register(reg, registerAddressFile);
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
            _TLWCommand.tlw_SetBrightness(GetMBAddr(), GetId(), color, r, g, b, _DevIP, (param) =>
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
            openFileDlg.FileName = "Register.txt";
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
            saveFileDialog.FileName = "Register.txt";
            if (saveFileDialog.ShowDialog(this) == DialogResult.Cancel) return;
            Register reg = new Register();
            reg.Register2055OtherItemList = gridOtherReg.DataSource as List<RegisterOtherItem>;
            reg.Register2055ItemList = grid2055.DataSource as List<RegisterItem>;
            reg.Is2055Debug = ckDebugMode.Checked;
            reg.Special2055Register = new RegisterSpectialItem();

            Register2055Helper.Save2055Register(reg, saveFileDialog.FileName);

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
            byte[] data = new byte[(int)numFlashDataLen.Value].Fill(0x55);

            rnd.NextBytes(data);

            //byte val = 1;
            //for (int j = 0; j < data.Length / 4; j++)
            //{
            //    data[j * 4] = val;
            //    data[j * 4 + 1] = val;
            //    data[j * 4 + 2] = val;
            //    data[j * 4 + 3] = val;
            //    val++;
            //    //if (val >= 255) val = 1;
            //}

            //UInt32 val = 0x1;
            //for (int j = 0; j < data.Length / 4; j++)
            //{
            //    byte[] btData = val.GetBytes();
            //    data[j * 4] = btData[0];
            //    data[j * 4 + 1] = btData[1];
            //    data[j * 4 + 2] = btData[2];
            //    data[j * 4 + 3] = btData[3];
            //    val++;
            //    //if (val >= 255) val = 1;
            //}
            //for (int i = 2048; i < data.Length; i++)
            //{
            //    data[i] = 0xff;
            //}
            //byte val = 1;
            //for (int i = 1; i <= data.Length; i++)
            //{
            //    //if (val > 255 || val == 0) val = 1;
            //    //data[i - 1] = val;
            //    //val++;
            //    data[i - 1] = val;
            //    if (i % 1024 == 0)
            //    {
            //        val++;
            //    }
            //}

            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "*.txt|*.txt";
            //saveFileDialog.Title = "保存测试数据";
            //saveFileDialog.FileName = "FLASH_Write";
            //if (saveFileDialog.ShowDialog(this) == DialogResult.Cancel) return;
            //WriteTextFile(saveFileDialog.FileName, data.ToString(" "));

            CalibrationHelper.Write(data, @"D:\tmp\Write_Flash.zdat");
            //string path = System.IO.Path.GetDirectoryName(saveFileDialog.FileName);
            //FrmSectionSet frmSectionSet = new FrmSectionSet();
            //frmSectionSet.StartPosition = FormStartPosition.CenterParent;
            //if (frmSectionSet.ShowDialog(this) == DialogResult.Cancel) return;
            uint sectorSize = 1024;
            uint regAddr = (uint)numRegAddr.Value;
            byte chipPos = (byte)cbChipPos.SelectedValue.ToString().ToByte();
            //EnableControl(sender as Control, false);

            //_TLWCommand.tlw_FLASH_Write(GetCardAddress(), GetId(), chipPos, regAddr, data, sectorSize, _DevIP, (param) =>
            //  {
            //      Array.ForEach(param, t => WriteOutput(t, "写入FLASH"));
            //      EnableControl(sender as Control, true);
            //  });


            InvokeAsync(() =>
            {
                EnableControl(sender as Control, false);
                foreach (var item in _DevIP)
                {
                    int result = 0;
                    UInt32 sdramAddr = (UInt32)numRegAddr.Value;
                    int cx = 0;
                    int count = (int)(data.Length / 1024);
                    for (int i = 0; i < count; i++)
                    {
                        byte[] writeData = new byte[1024];

                        Array.Copy(data, cx, writeData, 0, 1024);

                        result = _TLWCommand.tlw_FLASH_Write(item.Value, GetMBAddr(), 0, chipPos, sdramAddr, writeData, 1024);
                        if ((sdramAddr & 0xffff) == 0)
                        {
                            System.Threading.Thread.Sleep(1000);
                        }
                        if (result != 0)
                        {
                            WriteMessage($"IP:{item.Key}写入SDRAM失败");
                            EnableControl(sender as Control, true);
                            return;
                        }
                        //System.Threading.Thread.Sleep(50);
                        //byte[] readByte = new byte[1024];
                        //_TLWCommand.tlw_FLASH_Read(item.Value, GetCardAddress(), 0, chipPos, sdramAddr, readByte, 1024);
                        //if (writeData.IsEqual(readByte) == false)
                        //{
                        //    WriteTextFile($@"{path}\Write_{i + 1}.txt", writeData.ToString(" "));
                        //    WriteTextFile($@"{path}\Read_{i + 1}.txt", readByte.ToString(" "));
                        //}
                        sdramAddr += 1024;
                        cx += 1024;
                        SetPrograss($"{i + 1}/{count}", $"{i + 1}/{count}", (int)(((float)(i + 1) / count) * 100));
                    }
                }
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
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "*.txt|*.txt";
            //saveFileDialog.Title = "保存测试数据";
            //saveFileDialog.FileName = "FLASH_Read.txt";
            //if (saveFileDialog.ShowDialog(this) == DialogResult.Cancel) return;

            string ip = ShowSelectIPDialog();
            uint regAddr = (uint)numRegAddr.Value;
            byte chipPos = (byte)cbChipPos.SelectedValue.ToString().ToByte();

            EnableControl(sender as Control, false, ip);
            _TLWCommand.tlw_FLASH_Read(GetMBAddr(), GetId(), chipPos, regAddr, (int)numFlashDataLen.Value, _DevIP, (param) =>
              {
                  Array.ForEach(param, t =>
                  {
                      WriteOutput(t, "读取FLASH");
                      if (t.ResultCode == 0)
                      {
                          //WriteTextFile(saveFileDialog.FileName, (t.Data as byte[]).ToString(" "));
                          //CalibrationHelper.Write(t.Data as byte[], saveFileDialog.FileName);
                          CalibrationHelper.Write(t.Data as byte[], @"D:\tmp\Read_Flash.zdat");
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
            byte[] data = new byte[(int)numSDRAMDataLength.Value];
            rnd.NextBytes(data);

            //byte val = 1;
            //for (int i = 1; i <= numSDRAMDataLength.Value; i++)
            //{
            //    if (val > 255 || val == 0) val = 1;
            //    data[i - 1] = val;
            //    val++;
            //}

            //byte val = 1;
            //for (int i = 1; i <= data.Length; i++)
            //{
            //    //if (val > 255 || val == 0) val = 1;
            //    //data[i - 1] = val;
            //    //val++;
            //    data[i - 1] = val;
            //    if (i % 1024 == 0)
            //    {
            //        val++;
            //    }
            //}

            //for (int i = 1; i <= numFlashDataLen.Value; i++)
            //{
            //    data[i - 1] = 0xff;
            //}
            //for (int i = 0; i < data.Length / 4096; i++)
            //{
            //    if (i == 0 || i == 54 || i == 107)
            //    {
            //        for (int j = 0; j < 3072; j++)
            //        {
            //            data[i * 4096 + j] = 0xff;
            //        }
            //    }
            //    else
            //    {
            //        for (int j = 0; j < 3072; j++)
            //        {
            //            data[i * 4096 + j] = 0x0;
            //        }
            //    }
            //}

            //byte val = 1;
            //for (int j = 0; j < data.Length / 4; j++)
            //{
            //    data[j * 4] = val;
            //    data[j * 4 + 1] = val;
            //    data[j * 4 + 2] = val;
            //    data[j * 4 + 3] = val;
            //    val++;
            //}
            UInt32 val = 0x1;
            for (int j = 0; j < data.Length / 4; j++)
            {
                byte[] btData = val.GetBytes();
                data[j * 4] = btData[0];
                data[j * 4 + 1] = btData[1];
                data[j * 4 + 2] = btData[2];
                data[j * 4 + 3] = btData[3];
                val++;
                //if (val >= 255) val = 1;
            }
            CalibrationHelper.Write(data, @"D:\tmp\Write_SDRAM.zdat");
            byte chipPos = (byte)cbChipPos.SelectedValue.ToString().ToByte();
            EnableControl(sender as Control, false);
            _TLWCommand.tlw_SDRAM_Write(GetMBAddr(), GetId(), (uint)numSDRAMAddr.Value, data, _DevIP, (param) =>
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
            _TLWCommand.tlw_SDRAM_WriteToFLASH(GetMBAddr(), GetId(), _DevIP, (param) =>
           {
               System.Threading.Thread.Sleep(12 * 1000);
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

        #region 2072

        private void Initial2072()
        {

            m_arrControl[0] = new Control[12] {cb2072_1_1, cb2072_1_2, cb2072_1_3, cb2072_1_4, cb2072_1_5, cb2072_1_6, cb2072_1_7,
            cb2072_1_8,cb2072_1_9,cb2072_1_10,cb2072_1_11,cb2072_1_12};
            m_arrBitWidth[0] = new int[12] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 7, 2, 6 };
            m_arrStartBit[0] = new int[12] { 24, 23, 22, 21, 20, 19, 18, 17, 16, 8, 6, 0 };

            m_arrControl[1] = new Control[4] { input2072_2_1, input2072_2_2, input2072_2_3, input2072_2_4 };
            m_arrBitWidth[1] = new int[4] { 8, 8, 8, 8 };
            m_arrStartBit[1] = new int[4] { 24, 16, 8, 0 };

            m_arrControl[2] = new Control[6] { input2072_3_1, cb2072_3_2, cb2072_3_3, cb2072_3_4, cb2072_3_5, input2072_3_6 };
            m_arrBitWidth[2] = new int[6] { 8, 2, 2, 2, 2, 16 };
            m_arrStartBit[2] = new int[6] { 24, 22, 20, 18, 16, 0 };

            m_arrControl[3] = new Control[6] { cb2072_4_1, cb2072_4_2, cb2072_4_3, cb2072_4_4, cb2072_4_5, cb2072_4_6 };
            m_arrBitWidth[3] = new int[6] { 1, 1, 1, 2, 5, 5 };
            m_arrStartBit[3] = new int[6] { 26, 25, 24, 16, 8, 0 };

            m_arrControl[4] = new Control[4] { cb2072_5_1, cb2072_5_2, cb2072_5_3, cb2072_5_4 };
            m_arrBitWidth[4] = new int[4] { 5, 5, 5, 5 };
            m_arrStartBit[4] = new int[4] { 24, 16, 8, 0 };

            m_arrControl[5] = new Control[6] { cb2072_6_1, cb2072_6_2, cb2072_6_3, cb2072_6_4, cb2072_6_5, cb2072_6_6 };
            m_arrBitWidth[5] = new int[6] { 5, 5, 4, 4, 4, 4 };
            m_arrStartBit[5] = new int[6] { 24, 16, 12, 8, 4, 0 };

            m_arrControl[6] = new Control[14] { input2072_7_1, cb2072_7_2, cb2072_7_3, cb2072_7_4, cb2072_7_5, cb2072_7_6,
            cb2072_7_7, cb2072_7_8, cb2072_7_9, cb2072_7_10, cb2072_7_11, cb2072_7_12,cb2072_7_13, cb2072_7_14};
            m_arrBitWidth[6] = new int[14] { 8, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 4, 4 };
            m_arrStartBit[6] = new int[14] { 24, 23, 22, 21, 19, 18, 17, 16, 14, 13, 12, 8, 4, 0 };

            m_arrControl[7] = new Control[4] { cb2072_8_1, cb2072_8_2, cb2072_8_3, cb2072_8_4 };
            m_arrBitWidth[7] = new int[4] { 4, 5, 4, 4 };
            m_arrStartBit[7] = new int[4] { 28, 8, 4, 0 };

            m_arrControl[8] = new Control[6] { cb2072_9_1, cb2072_9_2, cb2072_9_3, input2072_9_4, input2072_9_5, input2072_9_6 };
            m_arrBitWidth[8] = new int[6] { 2, 2, 2, 8, 8, 8 };
            m_arrStartBit[8] = new int[6] { 28, 26, 24, 16, 8, 0 };

            m_arrControl[9] = new Control[7] { cb2072_10_1, cb2072_10_2, cb2072_10_3, cb2072_10_4, cb2072_10_5, cb2072_10_6, cb2072_10_7 };
            m_arrBitWidth[9] = new int[7] { 8, 2, 5, 2, 5, 2, 5 };
            m_arrStartBit[9] = new int[7] { 24, 22, 16, 14, 8, 6, 0 };

            m_arrControl[10] = new Control[7] { cb2072_11_1, cb2072_11_2, cb2072_11_3, cb2072_11_4, cb2072_11_5, cb2072_11_6, cb2072_11_7 };
            m_arrBitWidth[10] = new int[7] { 8, 2, 5, 2, 5, 2, 5 };
            m_arrStartBit[10] = new int[7] { 24, 22, 16, 14, 8, 6, 0 };

            m_arrControl[11] = new Control[7] { cb2072_12_1, cb2072_12_2, cb2072_12_3, cb2072_12_4, cb2072_12_5, cb2072_12_6, cb2072_12_7 };
            m_arrBitWidth[11] = new int[7] { 8, 2, 5, 2, 5, 2, 5 };
            m_arrStartBit[11] = new int[7] { 24, 22, 16, 14, 8, 6, 0 };

            m_arrControl[12] = new Control[12] { cb2072_13_1, cb2072_13_2, cb2072_13_3, cb2072_13_4, cb2072_13_5, cb2072_13_6, cb2072_13_7,
            cb2072_13_8, cb2072_13_9, cb2072_13_10, cb2072_13_11, cb2072_13_12};
            m_arrBitWidth[12] = new int[12] { 2, 3, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2 };
            m_arrStartBit[12] = new int[12] { 30, 24, 12, 11, 10, 9, 8, 6, 4, 3, 2, 0 };

            m_arrControl[13] = new Control[7] { cb2072_14_1, cb2072_14_2, cb2072_14_3, cb2072_14_4, input2072_14_5, input2072_14_6, input2072_14_7 };
            m_arrBitWidth[13] = new int[7] { 1, 1, 2, 3, 8, 8, 8 };
            m_arrStartBit[13] = new int[7] { 31, 30, 28, 24, 16, 8, 0 };

            m_arrControl[14] = new Control[6] { cb2072_15_1, cb2072_15_2, cb2072_15_3, cb2072_15_4, cb2072_15_5, cb2072_15_6 };
            m_arrBitWidth[14] = new int[6] { 1, 1, 2, 4, 1, 1 };
            m_arrStartBit[14] = new int[6] { 15, 14, 12, 8, 1, 0 };

            m_arrControl[15] = new Control[8] { cb2072_16_1, cb2072_16_2, cb2072_16_3, cb2072_16_4, cb2072_16_5, cb2072_16_6, input2072_16_7, input2072_16_8 };
            m_arrBitWidth[15] = new int[8] { 1, 1, 1, 3, 1, 3, 8, 8 };
            m_arrStartBit[15] = new int[8] { 25, 24, 23, 20, 19, 16, 8, 0 };

            m_arrControl[16] = new Control[2] { cb2072_17_1, input2072_17_2 };
            m_arrBitWidth[16] = new int[2] { 2, 8 };
            m_arrStartBit[16] = new int[2] { 8, 0 };

            m_arrRegAddr = new byte[34];//寄存器地址
            for (int i = 0; i < 17; i++)
            {
                m_arrRegAddr[2 * i] = (byte)(0x5E + i);
                m_arrRegAddr[2 * i + 1] = (byte)(0x6F + i);
            }



            //Tag赋值

            Dictionary<string, string[]> dict = new Dictionary<string, string[]>();

            for (int i = 0; i < 17; i++)
            {
                for (int j = 0; j < m_arrControl[i].Length; j++)
                {
                    int nbitWidth = m_arrBitWidth[i][j];//位宽
                    int nMax = (1 << nbitWidth) - 1;

                    string szType = m_arrControl[i][j].GetType().ToString();
                    if (szType == "System.Windows.Forms.ComboBox")
                    {

                        ComboBox subitem = (ComboBox)m_arrControl[i][j];
                        subitem.Items.Clear();
                        if (dict.ContainsKey(nbitWidth.ToString()) == false)
                        {
                            string[] tmp = new string[nMax + 1];
                            for (int k = 0; k <= nMax; k++)
                            {
                                //subitem.Items.Add(i.ToString());
                                tmp[k] = k.ToString();
                            }
                            dict[nbitWidth.ToString()] = tmp;
                        }
                        subitem.Items.AddRange(dict[nbitWidth.ToString()]);
                        subitem.SelectedIndex = 0;
                    }
                    else if (szType == "System.Windows.Forms.NumericUpDown")
                    {
                        NumericUpDown ctrl = (NumericUpDown)m_arrControl[i][j];
                        ctrl.Maximum = nMax;
                        ctrl.Minimum = 0;
                        ctrl.Value = 0;
                    }
                }
            }

        }

        private UInt32 Get2072Data(int nIndex)
        {
            UInt32 val = 0;
            Invoke(new MethodInvoker(() =>
            {
                Control[] ctrls = m_arrControl[nIndex];

                for (int i = 0; i < ctrls.Length; i++)
                {
                    UInt32 tmp = 0;
                    string szType = ctrls[i].GetType().ToString();
                    if (szType == "System.Windows.Forms.ComboBox")
                    {
                        ComboBox cb = (ComboBox)(ctrls[i]);
                        tmp = (UInt32)cb.SelectedIndex;
                    }
                    else if (szType == "System.Windows.Forms.NumericUpDown")
                    {
                        NumericUpDown input = (NumericUpDown)(ctrls[i]);
                        tmp = (UInt32)input.Value;
                    }
                    if (m_arrStartBit[nIndex][i] == 0)
                    {
                        val |= tmp;
                    }
                    else
                    {
                        val |= (tmp << m_arrStartBit[nIndex][i]);
                    }
                }
            }));
            return val;
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

                        int result = _TLWCommand.tlw_FLASH_Write(item.Value, GetMBAddr(), GetId(), chipPos, regAddr, bytesWrite, sectorSize);
                        System.Threading.Thread.Sleep(1000);
                        if (result == 0)
                        {
                            result = _TLWCommand.tlw_FLASH_Read(item.Value, GetMBAddr(), GetId(), chipPos, regAddr, bytesRead, sectorSize);
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
            if (grid2055.SelectedRows.Count == 1)
            {
                RegisterItem regItemData = grid2055.Rows[grid2055.SelectedRows[0].Index].DataBoundItem as TLWController.Helper.RegisterItem;
                //grid2055.selected
                DevComponents.DotNetBar.Controls.DataGridViewIntegerInputEditingControl ctr = (e.Control as DevComponents.DotNetBar.Controls.DataGridViewIntegerInputEditingControl);
                if (ctr != null)
                {
                    object obj = grid2055.Rows[_CurrentGridRowIndex].Cells[_CurrentGridColumnIndex].Value;
                    ctr.MinValue = regItemData.MinValue;
                    ctr.MaxValue = regItemData.MaxValue;

                    ctr.Value = (byte)obj;
                }
            }
        }

        private void grid2055_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            _CurrentGridRowIndex = e.RowIndex;
            _CurrentGridColumnIndex = e.ColumnIndex;

            if (grid2055.SelectedRows.Count == 1)
            {
                RegisterItem regItemData = grid2055.Rows[grid2055.SelectedRows[0].Index].DataBoundItem as TLWController.Helper.RegisterItem;
                //DevComponents.DotNetBar.Controls.DataGridViewIntegerInputEditingControl ctr = (e.Control as DevComponents.DotNetBar.Controls.DataGridViewIntegerInputEditingControl);
                //if (ctr != null)
                //{
                //    object obj = grid2055.Rows[_CurrentGridRowIndex].Cells[_CurrentGridColumnIndex].Value;
                //    ctr.MinValue = regItemData.MinValue;
                //    ctr.MaxValue = regItemData.MaxValue;

                //    ctr.Value = (byte)obj;
                //}

                //if (grid2055.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "ColRedValue")
                //{
                //    int cellX = grid2055.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).X;
                //    int cellY = grid2055.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Y;

                //    Rectangle rect = grid2055.Rows[e.RowIndex].Cells[e.ColumnIndex].ContentBounds;
                //    //numValue
                //    grid2055.Controls["numValue"].Bounds = rect;
                //    grid2055.Controls["numValue"].Location = new Point(cellX, cellY);
                //    (grid2055.Controls["numValue"] as NumericUpDown).Minimum = regItemData.MinValue;
                //    (grid2055.Controls["numValue"] as NumericUpDown).Maximum = regItemData.MaxValue;
                //    object obj = grid2055.Rows[_CurrentGridRowIndex].Cells[_CurrentGridColumnIndex].Value;
                //    (grid2055.Controls["numValue"] as NumericUpDown).Value = (byte)obj;
                //    grid2055.Controls["numValue"].Visible = true;
                //}
            }


        }

        ushort CheckSum16(byte[] dat, int offset, int len)
        {
            ushort tmp = 0;
            for (int i = 0; i < len; i++)
            {
                tmp += dat[offset + i];
            }
            return tmp;
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

            byte[] arrCompare = compare.ToBytes();
            //前面20字节是附加内容
            //数据部分data[20] - data[1043]
            //校验是data[len - 5] data[len - 4]
            //尾data[len - 3] data[len - 2] data[len - 1]   

            byte[] arrSendDataSection = new byte[1024];

            int errCount = 0;
            int currentCount = 0;
            isStop = false;
            int delay = (int)numTimeDelay.Value;
            int readDataLen = (int)numTestDataLen.Value;
            InvokeAsync(() =>
            {
                EnableControl(sender as Control, false);

                int nPacketLen = writeSDRAM.Length;
                byte[] arrRandomWriteSDRAM = new byte[nPacketLen];

                int nRecvLen = arrCompare.Length;
                byte[] arrRandomCompareSDRAM = new byte[nRecvLen];

                while (!isStop)
                {
                    Random r1 = new Random((int)DateTime.Now.Ticks);
                    //随机填充数据区
                    r1.NextBytes(arrSendDataSection);

                    //-------------构造发送数据包
                    Array.Copy(writeSDRAM, arrRandomWriteSDRAM, writeSDRAM.Length);

                    //复制数据区
                    Array.Copy(arrSendDataSection, 0, arrRandomWriteSDRAM, 23, 1024);

                    //计算校验值
                    ushort ck = CheckSum16(arrRandomWriteSDRAM, 3, 1044);

                    arrRandomWriteSDRAM[nPacketLen - 5] = (byte)((ck >> 8) & 0xFF);
                    arrRandomWriteSDRAM[nPacketLen - 4] = (byte)(ck & 0xFF);

                    //--------------构造接收数据包
                    Array.Copy(arrCompare, arrRandomCompareSDRAM, nRecvLen);

                    //复制数据区
                    Array.Copy(arrSendDataSection, 0, arrRandomCompareSDRAM, 20, 1024);

                    //替换校验值
                    ushort ck1 = CheckSum16(arrRandomCompareSDRAM, 3, 1041);

                    arrRandomCompareSDRAM[nRecvLen - 5] = (byte)((ck1 >> 8) & 0xFF);
                    arrRandomCompareSDRAM[nRecvLen - 4] = (byte)(ck1 & 0xFF);

                    //compare = arrRandomCompareSDRAM.ToString(" ").ToUpper();

                    int revLen = UDPHelper.Send(arrRandomWriteSDRAM, ip, out byte[] revWriteSDRAM);
                    if (revLen == 0)
                    {
                        errCount++;
                        currentCount++;
                        WriteMessage(string.Format("当前测试次数{0} 发送写入数据包后，没有收到返回数据", currentCount));
                        WriteTestMessage($"稳定性测试:当前次数:{currentCount},错误次数:{errCount}");
                        WriteTextFile($@"{folder}\error_{errCount}.txt", "写FLASH没有收到返回数据");
                        continue;
                    }
                    if (delay > 0)
                        System.Threading.Thread.Sleep(delay);

                    revLen = UDPHelper.Send(readSDRAM, ip, out byte[] revReadSDRAM);
                    if (revLen == 0)
                    {
                        errCount++;
                        currentCount++;
                        WriteMessage(string.Format("当前测试次数{0} 发送读取包后，没有收到返回数据", currentCount));
                        WriteTestMessage($"稳定性测试:当前次数:{currentCount},错误次数:{errCount}");
                        WriteTextFile($@"{folder}\error_{errCount}.txt", "读FLASH没有收到返回数据");
                        continue;
                    }
                    //string revStr = revReadSDRAM.ToString(" ").ToUpper();
                    //if (revStr != compare)
                    //{
                    //errCount++;
                    //WriteMessage("错误:" + errCount.ToString());
                    //string writeData = $"{compare.ToUpper()}\r\n{revStr.ToUpper()}";
                    //WriteTextFile($@"{folder}\error_{errCount}.txt", writeData);


                    //errCount++;
                    //WriteMessage("错误:" + errCount.ToString());
                    //string writeData = $"{compare.ToUpper()}\r\n{revReadSDRAM.ToString(" ").ToUpper()}";

                    //比较数据内容
                    byte[] b1 = arrRandomCompareSDRAM;// compare.ToBytes();
                    byte[] b2 = revReadSDRAM;
                    string msg = "";
                    if (b1.Length != b2.Length)
                    {
                        msg = "数据包长度不同";
                        WriteMessage(msg);

                        errCount++;
                        WriteMessage("错误:" + errCount.ToString());
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
                                errCount++;
                                WriteMessage("错误:" + errCount.ToString());

                                WriteMessage(string.Format("diff pos={0}/{1} (src,recv)(0x{2:X2},0x{3:X2})", i, b1.Length, b1[i], b2[i]));
                                szLine = string.Format("======>>[{0}]\t{1:X2}\t{2:X2}<<==================\r\n", i, b1[i], b2[i]);

                                bFindERROR = true;
                            }
                            msg += szLine;

                        }
                        if (bFindERROR)
                            isStop = true;

                        WriteTextFile($@"{folder}\error_{errCount}_.txt", msg);
                    }
                    currentCount++;
                    WriteTestMessage($"稳定性测试:当前次数:{currentCount},错误次数:{errCount}");

                    if (delay > 0)
                        System.Threading.Thread.Sleep(delay);
                }
                EnableControl(sender as Control, true);
            });
        }

        private void btnGammaSet_Click(object sender, EventArgs e)
        {
            if (CheckIsBusy()) return;
            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }
            //0 = 10bit GAMMA, 1024个16bit数据,1 = 13bit GAMMA, 4096个16bit数据,2=16bit GAMMA, 32768个16bit数据,3 = HDR, 1024个16bit数据
            byte mode = byte.Parse(cbGammaBit.SelectedValue.ToString());
            byte[] data = null;
            if (mode == 0)
            {
                GAMMAProcessLib.GAMMAProcessClass gAMMAProcess = new GAMMAProcessLib.GAMMAProcessClass(10, (double)numGamma.Value, 65535, true);
                data = gAMMAProcess.GetData;
                //byte val = 1;
                //for (int i = 1; i <= data.Length; i++)
                //{
                //    if (val > 255 || val == 0) val = 1;
                //    data[i - 1] = val;
                //    val++;
                //}

            }
            else if (mode == 1)
            {
                GAMMAProcessLib.GAMMAProcessClass gAMMAProcess = new GAMMAProcessLib.GAMMAProcessClass(13, (double)numGamma.Value, 65535, true);
                data = gAMMAProcess.GetData;
            }
            else if (mode == 2)
            {
                GAMMAProcessLib.GAMMAProcessClass gAMMAProcess = new GAMMAProcessLib.GAMMAProcessClass(16, (double)numGamma.Value, 65535, true);
                data = gAMMAProcess.GetData;
            }
            else if (mode == 3)
            {
                GAMMAProcessLib.GAMMAProcessClass gAMMAProcess = new GAMMAProcessLib.GAMMAProcessClass(10, 65535, true);
                data = gAMMAProcess.GetData;
            }

            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "*.txt|*.txt";
            //saveFileDialog.Title = "保存测试数据";
            //saveFileDialog.FileName = "Gamma_Write";
            //if (saveFileDialog.ShowDialog(this) == DialogResult.Cancel) return;
            //WriteTextFile(saveFileDialog.FileName, data.ToString(" "));
            byte color = byte.Parse(cbGammaColor.SelectedValue.ToString());
            EnableControl(sender as Control, false);
            WriteTextFile(@"D:\tmp\GammaWrite.txt", data.ToString(" "));
            _TLWCommand.tlw_WriteGAMMA(GetMBAddr(), GetId(), mode, color, data, _DevIP, (param) =>
               {
                   Array.ForEach(param, t => WriteOutput(t, "GAMMA发送"));
                   EnableControl(sender as Control, true);
               });
        }

        private void btnGammaRead_Click(object sender, EventArgs e)
        {
            if (CheckIsBusy()) return;
            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "*.txt|*.txt";
            //saveFileDialog.Title = "保存测试数据";
            //saveFileDialog.FileName = "GAMMA_READ.txt";
            //if (saveFileDialog.ShowDialog(this) == DialogResult.Cancel) return;

            string ip = ShowSelectIPDialog();
            uint regAddr = (uint)numRegAddr.Value;
            byte chipPos = (byte)cbChipPos.SelectedValue.ToString().ToByte();

            byte mode = byte.Parse(cbGammaBit.SelectedValue.ToString());
            int dateLen = 0;
            //0 = 10bit GAMMA, 1024个16bit数据,1 = 13bit GAMMA, 4096个16bit数据,2=16bit GAMMA, 32768个16bit数据,3 = HDR, 1024个16bit数据
            if (mode == 0)
            {
                dateLen = 1024 * 2;
            }
            else if (mode == 1)
            {
                dateLen = 4096 * 2;
            }
            else if (mode == 2)
            {
                dateLen = 32768 * 2;
            }
            else if (mode == 3)
            {
                dateLen = 1024 * 2;
            }

            EnableControl(sender as Control, false, ip);
            byte color = byte.Parse(cbGammaColor.SelectedValue.ToString());
            _TLWCommand.tlw_ReadGAMMA(GetMBAddr(), GetId(), mode, color, dateLen, _DevIP, (param) =>
             {
                 Array.ForEach(param, t =>
                 {
                     WriteOutput(t, "读取GAMMA");
                     if (t.ResultCode == 0)
                     {
                         WriteTextFile(@"D:\tmp\GammaRead.txt", (t.Data as byte[]).ToString(" "));
                     }
                 });
                 EnableControl(sender as Control, true);
             });
        }

        private void btnSendAll_Click(object sender, EventArgs e)
        {
            if (CheckIsBusy()) return;
            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }

            byte chipPos = (byte)cbRegChip.SelectedValue.ToString().ToByte();
            bool bSave = !ckDebugMode.Checked;
            int color = (int)cbParam2055Color.SelectedValue;
            List<RegisterItem> regList = grid2055.DataSource as List<RegisterItem>;
            List<RegisterOtherItem> regOtherList = gridOtherReg.DataSource as List<RegisterOtherItem>;
            byte[] data = new byte[1024].Fill(0xff);

            //string[] regOtherValue = rtOtherReg.Text.Replace("\n", "").ToUpper().Replace("0X", "").Split(',');
            //ushort[] ushortReg = new ushort[regOtherValue.Length];
            //for (int i = 0; i < regOtherValue.Length; i++)
            //{
            //    ushortReg[i] = ushort.Parse(regOtherValue[i], System.Globalization.NumberStyles.HexNumber);
            //}

            //RegisterHelper.Data = ushortReg.ToBytes();
            //byte[] tmp = ushortReg.ToBytes();
            //Array.Copy(tmp, 0, data, 0, tmp.Length);
            //RegisterHelper.Data = data;

            Register2055Helper.CombinOtherReg(regOtherList);
            Register2055Helper.CombinReg2055(regList);

            data = Register2055Helper.Data;
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "*.txt|*.txt";
            //saveFileDialog.Title = "保存Register数据";
            //saveFileDialog.FileName = "Register_Write";
            //if (saveFileDialog.ShowDialog(this) == DialogResult.Cancel) return;
            WriteTextFile(@"d:\tmp\register_Write.txt", Register2055Helper.Data.ToString(" "));

            byte[] tmp = new byte[510];
            Array.Copy(data, 0, tmp, 0, 510);
            ushort sum = tmp.Sum();
            MessageBox.Show($"校验和:{sum.ToString("X4")}");
            EnableControl(sender as Control, false);
            _TLWCommand.tlw_WriteRegisterGroup(GetMBAddr(), GetId(), chipPos, data, bSave, _DevIP, (param) =>
            {
                Array.ForEach(param, t => WriteOutput(t, "批量写入寄存器"));
                EnableControl(sender as Control, true);
            });

            //_TLWCommand.tlw_ReadRegisterGroup(GetCardAddress(), GetId(), chipPos, 1024, _DevIP, (param) =>
            //  {
            //      Array.ForEach(param, t =>
            //      {
            //          WriteOutput(t, "批量读取寄存器");
            //          if (t.ResultCode == 0)
            //          {
            //              byte[] data = new byte[1024];
            //              RegisterHelper.Data = t.Data as byte[];
            //              RegisterHelper.CombinReg2055(regList);
            //              data = RegisterHelper.Data;
            //              _TLWCommand.tlw_WriteRegisterGroup(GetCardAddress(), GetId(), chipPos, data, bSave, _DevIP, (param1) =>
            //              {
            //                  Array.ForEach(param1, t1 => WriteOutput(t, "批量写入寄存器"));
            //                  EnableControl(sender as Control, true);
            //              });
            //          }
            //          else
            //          {
            //              EnableControl(sender as Control, true);
            //          }
            //      });
            //  });
        }

        private void btnReadReg_Click(object sender, EventArgs e)
        {
            if (CheckIsBusy()) return;
            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }

            byte chipPos = (byte)cbRegChip.SelectedValue.ToString().ToByte();
            bool bSave = !ckDebugMode.Checked;
            int color = (int)cbParam2055Color.SelectedValue;
            List<RegisterItem> regList = grid2055.DataSource as List<RegisterItem>;
            List<RegisterOtherItem> regOtherList = gridOtherReg.DataSource as List<RegisterOtherItem>;
            EnableControl(sender as Control, false);
            _TLWCommand.tlw_ReadRegisterGroup(GetMBAddr(), GetId(), chipPos, 1024, _DevIP, (param) =>
            {
                Array.ForEach(param, t =>
                {
                    WriteOutput(t, "批量读取寄存器");
                    if (t.ResultCode == 0)
                    {
                        WriteTextFile(@"d:\tmp\register_reader.txt", (t.Data as byte[]).ToString(" "));
                        Register2055Helper.Data = t.Data as byte[];
                        byte[] tmp = new byte[2];
                        tmp[0] = Register2055Helper.Data[510];
                        tmp[1] = Register2055Helper.Data[511];
                        UInt32 val = tmp.GetUInt16();
                        string str = val.ToString("X4");
                        MessageBox.Show(str);
                        Invoke(new MethodInvoker(() =>
                        {
                            //SaveFileDialog saveFileDialog = new SaveFileDialog();
                            //saveFileDialog.Filter = "*.txt|*.txt";
                            //saveFileDialog.Title = "保存Register数据";
                            //saveFileDialog.FileName = "Register_Read";
                            //if (saveFileDialog.ShowDialog(this) == DialogResult.Cancel) return;
                            //WriteTextFile(saveFileDialog.FileName, RegisterHelper.Data.ToString(" "));
                            //RegisterHelper.SplitReg2055(regList);
                            //RegisterHelper.SplitRegOther(regOtherList);
                            //grid2055.DataSource = regList;
                            //grid2055.Refresh();
                            //gridOtherReg.DataSource = regOtherList;
                            //gridOtherReg.Refresh();



                            Register2055Helper.SplitReg2055(regList);
                            Register2055Helper.SplitRegOther(regOtherList);
                            grid2055.DataSource = regList;
                            grid2055.Refresh();
                            gridOtherReg.DataSource = regOtherList;
                            gridOtherReg.Refresh();
                        }));

                    }
                    EnableControl(sender as Control, true);
                });
            });

            //RegisterHelper.Data = FileHelper.ReadTextFile(@"C:\Users\Jinjianchao\Desktop\更新连接版FPGA\Register_Read.txt").ToBytes();
            //RegisterHelper.SplitReg2055(regList);
            //RegisterHelper.SplitRegOther(regOtherList);
            //grid2055.DataSource = regList;
            //grid2055.Refresh();
            //gridOtherReg.DataSource = regOtherList;
            //gridOtherReg.Refresh();
            //EnableControl(sender as Control, true);
        }

        private void btnChoseMCU_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.bin|*.bin";
            if (openFileDialog.ShowDialog(this) == DialogResult.Cancel) return;
            txtMcu.Text = openFileDialog.FileName;
        }

        private void btnUpgradeMCU_Click(object sender, EventArgs e)
        {
            if (CheckIsBusy()) return;
            string fileName = txtMcu.Text;
            if (File.Exists(fileName) == false)
            {
                MessageBox.Show(this, "MCU文件不存在");
                return;
            }

            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }
            byte chip = byte.Parse(cbAdvChip.SelectedValue.ToString());
            EnableControl(sender as Control, false);
            _TLWCommand.tlw_Firmware_Write(GetMBAddr(), GetId(), chip, 0, fileName, _DevIP, (param) =>
               {
                   Array.ForEach(param, t => WriteOutput(t, "更新MCU"));
                   EnableControl(sender as Control, true);
               });
        }

        private void grid2055_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //grid2055.Controls["numValue"].Visible = false;
            //if (grid2055.SelectedRows.Count == 1)
            //{
            //    RegisterItem regItemData = grid2055.Rows[grid2055.SelectedRows[0].Index].DataBoundItem as TLWController.Helper.RegisterItem;
            //    //DevComponents.DotNetBar.Controls.DataGridViewIntegerInputEditingControl ctr = (e.Control as DevComponents.DotNetBar.Controls.DataGridViewIntegerInputEditingControl);
            //    //if (ctr != null)
            //    //{
            //    //    object obj = grid2055.Rows[_CurrentGridRowIndex].Cells[_CurrentGridColumnIndex].Value;
            //    //    ctr.MinValue = regItemData.MinValue;
            //    //    ctr.MaxValue = regItemData.MaxValue;

            //    //    ctr.Value = (byte)obj;
            //    //}

            //    if (grid2055.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "ColRedValue")
            //    {
            //        int cellX = grid2055.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).X;
            //        int cellY = grid2055.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Y;

            //        Rectangle rect = grid2055.Rows[e.RowIndex].Cells[e.ColumnIndex].ContentBounds;
            //        //numValue
            //        grid2055.Controls["numValue"].Bounds = rect;
            //        grid2055.Controls["numValue"].Location = new Point(cellX, cellY);
            //        (grid2055.Controls["numValue"] as NumericUpDown).Minimum = regItemData.MinValue;
            //        (grid2055.Controls["numValue"] as NumericUpDown).Maximum = regItemData.MaxValue;
            //        object obj = grid2055.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            //        (grid2055.Controls["numValue"] as NumericUpDown).Hexadecimal = true;
            //        (grid2055.Controls["numValue"] as NumericUpDown).Value = (byte)obj;
            //        grid2055.Controls["numValue"].Visible = true;
            //    }
            //}
            if (grid2055.SelectedRows.Count == 1)
            {

                if (grid2055.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "ColSend")
                {
                    RegisterItem regItemData = grid2055.Rows[grid2055.SelectedRows[0].Index].DataBoundItem as TLWController.Helper.RegisterItem;

                    byte chipPos = (byte)cbRegChip.SelectedValue.ToString().ToByte();
                    bool bSave = !ckDebugMode.Checked;
                    byte color = byte.Parse(cbParam2055Color.SelectedValue.ToString());
                    //int color = (int)cbParam2055Color.SelectedValue;
                    //List<RegisterItem> regList = grid2055.DataSource as List<RegisterItem>;
                    //byte[] data = new byte[1024];
                    //RegisterHelper.CombinReg2055(regList);

                    EnableControl(sender as Control, false);
                    if (color == 0)
                    {
                        _TLWCommand.tlw_WriteRegister(GetMBAddr(), GetId(), chipPos, regItemData.RedAddress.ToByte(), regItemData.RedValue.ToByte(), bSave, _DevIP, (param) =>
                         {
                             Array.ForEach(param, t =>
                             {

                                 if (t.ResultCode == 0)
                                 {
                                     _TLWCommand.tlw_WriteRegister(GetMBAddr(), GetId(), chipPos, regItemData.GreenAddress.ToByte(), regItemData.GreenValue.ToByte(), bSave, _DevIP, (param1) =>
                                     {
                                         Array.ForEach(param1, t1 =>
                                         {

                                             if (t1.ResultCode == 0)
                                             {
                                                 _TLWCommand.tlw_WriteRegister(GetMBAddr(), GetId(), chipPos, regItemData.GreenAddress.ToByte(), regItemData.GreenValue.ToByte(), bSave, _DevIP, (param2) =>
                                                 {
                                                     Array.ForEach(param2, t2 =>
                                                     {

                                                         if (t2.ResultCode == 0)
                                                         {
                                                             WriteOutput(t2, "写入寄存器");
                                                             EnableControl(sender as Control, true);
                                                         }
                                                         else
                                                         {
                                                             WriteOutput(t2, "写入寄存器");
                                                             EnableControl(sender as Control, true);
                                                         }
                                                     });
                                                 });
                                             }
                                             else
                                             {
                                                 WriteOutput(t1, "写入寄存器");
                                                 EnableControl(sender as Control, true);
                                             }
                                         });
                                     });
                                 }
                                 else
                                 {
                                     WriteOutput(t, "写入寄存器");
                                     EnableControl(sender as Control, true);
                                 }
                             });
                         });
                    }
                    else if (color == 1)
                    {
                        _TLWCommand.tlw_WriteRegister(GetMBAddr(), GetId(), chipPos, regItemData.RedAddress.ToByte(), regItemData.RedValue.ToByte(), bSave, _DevIP, (param) =>
                        {
                            Array.ForEach(param, t =>
                            {
                                WriteOutput(t, "写入寄存器");
                                EnableControl(sender as Control, true);
                            });
                        });
                    }
                    else if (color == 2)
                    {
                        _TLWCommand.tlw_WriteRegister(GetMBAddr(), GetId(), chipPos, regItemData.GreenAddress.ToByte(), regItemData.GreenValue.ToByte(), bSave, _DevIP, (param) =>
                        {
                            Array.ForEach(param, t =>
                            {
                                WriteOutput(t, "写入寄存器");
                                EnableControl(sender as Control, true);
                            });
                        });
                    }
                    else if (color == 3)
                    {
                        _TLWCommand.tlw_WriteRegister(GetMBAddr(), GetId(), chipPos, regItemData.BlueAddress.ToByte(), regItemData.BlueValue.ToByte(), bSave, _DevIP, (param) =>
                        {
                            Array.ForEach(param, t =>
                            {
                                WriteOutput(t, "写入寄存器");
                                EnableControl(sender as Control, true);
                            });
                        });
                    }
                }
            }
        }

        private void grid2055_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            grid2055.Controls["numValue"].Visible = false;
            grid2055.Controls["cbValue"].Visible = false;
            if (grid2055.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "ColRedValue" ||
                    grid2055.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "ColGreenValue" ||
                    grid2055.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "ColBlueValue"
                    )
            {
                RegisterItem regItemData = grid2055.Rows[grid2055.SelectedRows[0].Index].DataBoundItem as TLWController.Helper.RegisterItem;
                if (regItemData.MaxValue - regItemData.MinValue <= 10)
                {
                    grid2055.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ((int)(grid2055.Controls["cbValue"] as ComboBox).SelectedValue).ToString("X2");
                }
                else
                {
                    grid2055.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ((byte)(grid2055.Controls["numValue"] as NumericUpDown).Value).ToString("X2");
                }
            }
        }

        private void grid2055_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (grid2055.SelectedRows.Count == 1)
            {
                _CurrentGridRowIndex = e.RowIndex;
                _CurrentGridColumnIndex = e.ColumnIndex;

                RegisterItem regItemData = grid2055.Rows[grid2055.SelectedRows[0].Index].DataBoundItem as TLWController.Helper.RegisterItem;
                if (grid2055.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "ColRedValue" ||
                    grid2055.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "ColGreenValue" ||
                    grid2055.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "ColBlueValue"
                    )
                {
                    int cellX = grid2055.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).X;
                    int cellY = grid2055.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Y;

                    Rectangle rect = grid2055.Rows[e.RowIndex].Cells[e.ColumnIndex].ContentBounds;

                    if (regItemData.MaxValue - regItemData.MinValue <= 10)
                    {
                        //combobox
                        grid2055.Controls["cbValue"].Bounds = rect;
                        grid2055.Controls["cbValue"].Location = new Point(cellX, cellY);

                        List<ListItem> items = new List<ListItem>();
                        for (int i = regItemData.MinValue; i <= regItemData.MaxValue; i++)
                        {
                            items.Add(new ListItem() { Value = i, Text = i.ToString("X2") });
                        }
                        (grid2055.Controls["cbValue"] as ComboBox).ValueMember = "Value";
                        (grid2055.Controls["cbValue"] as ComboBox).DisplayMember = "Text";
                        (grid2055.Controls["cbValue"] as ComboBox).DataSource = items;

                        object obj = grid2055.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        string str1 = (string)obj;
                        int byteVal = int.Parse(str1, System.Globalization.NumberStyles.HexNumber);

                        (grid2055.Controls["cbValue"] as ComboBox).SelectedValue = byteVal;
                        grid2055.Controls["cbValue"].Visible = true;
                    }
                    else
                    {
                        //numValue
                        grid2055.Controls["numValue"].Bounds = rect;
                        grid2055.Controls["numValue"].Location = new Point(cellX, cellY);
                        (grid2055.Controls["numValue"] as NumericUpDown).Minimum = regItemData.MinValue;
                        (grid2055.Controls["numValue"] as NumericUpDown).Maximum = regItemData.MaxValue;
                        object obj = grid2055.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        (grid2055.Controls["numValue"] as NumericUpDown).Hexadecimal = true;
                        string str1 = (string)obj;
                        byte byteVal = byte.Parse(str1, System.Globalization.NumberStyles.HexNumber);
                        (grid2055.Controls["numValue"] as NumericUpDown).Value = byteVal;
                        grid2055.Controls["numValue"].Visible = true;
                    }
                }
            }
        }

        private void btnChoseFPGA_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.*|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.Cancel) return;
            txtFPGA.Text = openFileDialog.FileName;
        }

        private void btnUpgradeFPGA_Click(object sender, EventArgs e)
        {
            if (CheckIsBusy()) return;
            string fileName = txtFPGA.Text;
            if (File.Exists(fileName) == false)
            {
                MessageBox.Show(this, "FPGA文件不存在");
                return;
            }

            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }
            byte chip = byte.Parse(cbAdvChip.SelectedValue.ToString());
            EnableControl(sender as Control, false);
            _TLWCommand.tlw_Firmware_Write(GetMBAddr(), GetId(), chip, 1, fileName, _DevIP, (param) =>
            {
                Array.ForEach(param, t => WriteOutput(t, "更新FPGA"));
                EnableControl(sender as Control, true);
            });
        }

        private void btnReadFirmwareVersion_Click(object sender, EventArgs e)
        {
            if (CheckIsBusy()) return;
            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }
            string ip = ShowSelectIPDialog();
            byte chipPos = (byte)cbAdvChip.SelectedValue.ToString().ToByte();

            EnableControl(sender as Control, false, ip);
            _TLWCommand.tlw_GetVersion(GetMBAddr(), GetId(), chipPos, 0, _DevIP, (param) =>
             {
                 Array.ForEach(param, t =>
                 {
                     //WriteOutput(t, "读取MCU版本");
                     if (t.ResultCode == 0)
                     {
                         //WriteTextFile(saveFileDialog.FileName, (t.Data as byte[]).ToString(" "));
                         byte[] mcuVersion = t.Data as byte[];
                         WriteMessage($"MCU版本:{mcuVersion[0]}.{mcuVersion[1]}.{mcuVersion[2]}.{mcuVersion[3]}");
                         _TLWCommand.tlw_GetVersion(GetMBAddr(), GetId(), chipPos, 1, _DevIP, (param1) =>
                         {
                             Array.ForEach(param1, t1 =>
                             {
                                 if (t.ResultCode == 0)
                                 {
                                     //WriteTextFile(saveFileDialog.FileName, (t.Data as byte[]).ToString(" "));
                                     byte[] fpgaVersion = t1.Data as byte[];
                                     WriteMessage($"灯板FPGA版本:{fpgaVersion[0]}.{fpgaVersion[1]}.{fpgaVersion[2]}.{fpgaVersion[3]}");
                                 }
                                 else
                                 {
                                     WriteMessage($"读取FPGA失败");
                                 }
                             });
                             EnableControl(sender as Control, true);
                         });
                     }
                     else
                     {
                         WriteMessage($"读取MCU失败");
                         EnableControl(sender as Control, true);
                     }
                 });
             });
        }

        private void btnReadMCU_Click(object sender, EventArgs e)
        {
            if (CheckDeviceAddrIsZero())
            {
                MessageBox.Show(this, "读取程序不能使用广播地址");
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.bin|*.bin";

            string ip = ShowSelectIPDialog();
            byte chipPos = (byte)cbAdvChip.SelectedValue.ToString().ToByte();

            EnableControl(sender as Control, false, ip);
            _TLWCommand.tlw_GetVersion(GetMBAddr(), GetId(), chipPos, 0, _DevIP, (param) =>
            {
                //读取MCU版本
                Array.ForEach(param, t =>
                {
                    if (t.ResultCode == 0)
                    {
                        byte[] mcuVersion = t.Data as byte[];
                        string fileName = $"MCU_{mcuVersion[0]}.{mcuVersion[1]}.{mcuVersion[2]}.{mcuVersion[3]}.bin";
                        saveFileDialog.FileName = fileName;
                        Invoke(new MethodInvoker(() =>
                        {
                            if (saveFileDialog.ShowDialog(this) == DialogResult.Cancel)
                            {
                                WriteMessage($"用户取消读取MCU文件");
                                EnableControl(sender as Control, true);
                                return;
                            }
                            fileName = saveFileDialog.FileName;
                        }));

                        _TLWCommand.tlw_Firmware_Read(GetMBAddr(), GetId(), chipPos, 0, 63636, fileName, _DevIP, (param1) =>
                         {
                             //读取MCU版本
                             Array.ForEach(param1, t1 =>
                              {
                                  if (t1.ResultCode == 0)
                                  {
                                      WriteMessage($"读取MCU文件完成");
                                  }
                                  else
                                  {
                                      WriteMessage($"读取MCU文件失败");
                                  }
                                  EnableControl(sender as Control, true);
                              });
                         });
                    }
                    else
                    {
                        WriteMessage($"读取MCU失败");
                        EnableControl(sender as Control, true);
                    }
                });
            });
        }

        private void btnReadFPGA_Click(object sender, EventArgs e)
        {
            if (CheckDeviceAddrIsZero())
            {
                MessageBox.Show(this, "读取程序不能使用广播地址");
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.bin|*.bin";

            string ip = ShowSelectIPDialog();
            byte chipPos = (byte)cbAdvChip.SelectedValue.ToString().ToByte();

            EnableControl(sender as Control, false, ip);
            _TLWCommand.tlw_GetVersion(GetMBAddr(), GetId(), chipPos, 1, _DevIP, (param) =>
            {
                //读取MCU版本
                Array.ForEach(param, t =>
                {
                    if (t.ResultCode == 0)
                    {
                        byte[] mcuVersion = t.Data as byte[];
                        string fileName = $"FPGA_{mcuVersion[0]}.{mcuVersion[1]}.{mcuVersion[2]}.{mcuVersion[3]}.bin";
                        saveFileDialog.FileName = fileName;
                        Invoke(new MethodInvoker(() =>
                        {
                            if (saveFileDialog.ShowDialog(this) == DialogResult.Cancel)
                            {
                                WriteMessage($"用户取消读取FPGA文件");
                                EnableControl(sender as Control, true);
                                return;
                            }
                            fileName = saveFileDialog.FileName;
                        }));

                        _TLWCommand.tlw_Firmware_Read(GetMBAddr(), GetId(), chipPos, 1, 648488, fileName, _DevIP, (param1) =>
                        {
                            //读取MCU版本
                            Array.ForEach(param1, t1 =>
                            {
                                if (t1.ResultCode == 0)
                                {
                                    WriteMessage($"读取FPGA文件完成");
                                }
                                else
                                {
                                    WriteMessage($"读取FPGA文件失败");
                                }
                                EnableControl(sender as Control, true);
                            });
                        });
                    }
                    else
                    {
                        WriteMessage($"读取FPGA失败");
                        EnableControl(sender as Control, true);
                    }
                });
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ip = GetCommunicationType().StartIPAddress;
            int delay = (int)numTimeDelay.Value;

            if (CheckIsBusy()) return;
            string fileName = txtFPGA.Text;
            if (File.Exists(fileName) == false)
            {
                MessageBox.Show(this, "FPGA文件不存在");
                return;
            }

            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }

            byte chip = byte.Parse(cbAdvChip.SelectedValue.ToString());
            EnableControl(sender as Control, false);


            InvokeAsync(() =>
            {

                for (int x = 10; x >= 1; x--)
                {
                    for (int y = 5; y >= 1; y--)
                    {
                        foreach (var item in _DevIP)
                        {
                            ushort cardAddr = (ushort)(x << 8 | y);
                            int result = _TLWCommand.tlw_Firmware_Write(item.Value, cardAddr, GetId(), chip, 1, fileName);
                            string state = result == 0 ? "成功" : "失败";
                            WriteMessage($"更新 行{y}列{x}{state}");
                            System.Threading.Thread.Sleep(100);
                        }
                    }
                }

                EnableControl(sender as Control, true);

            });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string ip = GetCommunicationType().StartIPAddress;
            int delay = (int)numTimeDelay.Value;

            if (CheckIsBusy()) return;


            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }

            byte chip = byte.Parse(cbAdvChip.SelectedValue.ToString());
            EnableControl(sender as Control, false);


            InvokeAsync(() =>
            {
                while (!isStop)
                {
                    for (int x = 10; x >= 1; x--)
                    {
                        for (int y = 5; y >= 1; y--)
                        {
                            foreach (var item in _DevIP)
                            {
                                ushort cardAddr = (ushort)(x << 8 | y);
                                byte[] ver = new byte[4];
                                int result = _TLWCommand.tlw_GetVersion(item.Value, cardAddr, 0, chip, 0, ver, 0, 4);
                                if (result == 0)
                                {
                                    WriteMessage($"行{y}列{x}MCU版本：{ver[0]}.{ver[1]}.{ver[2]}.{ver[3]}");
                                    result = _TLWCommand.tlw_GetVersion(item.Value, cardAddr, 0, chip, 1, ver, 0, 4);
                                    if (result == 0)
                                    {
                                        WriteMessage($"行{y}列{x}FPGA版本：{ver[0]}.{ver[1]}.{ver[2]}.{ver[3]}");
                                    }
                                    else
                                    {
                                        WriteMessage($"行{y}列{x}FPGA版本：失败");
                                    }
                                }
                                else
                                {
                                    WriteMessage($"行{y}列{x}mcu版本：失败");
                                }

                                System.Threading.Thread.Sleep(100);
                            }
                        }
                    }
                    break;
                }
                EnableControl(sender as Control, true);

            });
        }

        private void btnLoadVideoCardParam_Click(object sender, EventArgs e)
        {
            if (CheckIsBusy()) return;
            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }
            byte mode = byte.Parse((cbVideocardLoadParam.SelectedItem as ListItem).Value.ToString());

            EnableControl(sender as Control, false);
            _TLWCommand.tlw_ConnectCardLoadParam(GetMBAddr(), GetId(), mode, _DevIP, (param) =>
            {
                Array.ForEach(param, t => WriteOutput(t, "加载视频卡参数"));
                EnableControl(sender as Control, true);
            });
        }

        private void btnReadSDRAM_Click(object sender, EventArgs e)
        {
            if (CheckIsBusy()) return;
            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }

            string ip = ShowSelectIPDialog();
            uint regAddr = (uint)numSDRAMAddr.Value;

            EnableControl(sender as Control, false, ip);
            _TLWCommand.tlw_SDRAM_Read(GetMBAddr(), GetId(), regAddr, (int)numSDRAMDataLength.Value, _DevIP, (param) =>
            {
                Array.ForEach(param, t =>
                {
                    WriteOutput(t, "读取SDRAM");
                    if (t.ResultCode == 0)
                    {
                        //WriteTextFile(saveFileDialog.FileName, (t.Data as byte[]).ToString(" "));
                        CalibrationHelper.Write((t.Data as byte[]), @"D:\tmp\Read_SDRAM.zdat");
                    }
                });
                EnableControl(sender as Control, true);
            });
        }

        private void btnSetNetwork_Click(object sender, EventArgs e)
        {
            if (CheckIsBusy()) return;
            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtIP.Text))
            {
                MessageBox.Show(this, "IP地址不能为空");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMask.Text))
            {
                MessageBox.Show(this, "子网掩码不能为空");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtGateway.Text))
            {
                MessageBox.Show(this, "网关不能为空");
                return;
            }

            if (!NetworkValidateHelper.IsSameNetwork(txtIP.Text, txtMask.Text, txtGateway.Text))
            {
                MessageBox.Show(this, "IP地址,网关,子网掩码必须在同一个网段");
                return;
            }

            //长度为12，分别是IP地址，子网掩码，网关地址各占4字节
            byte[] data = new byte[12];
            byte[] ipData = txtIP.Text.Replace(".", " ").ToBytes(' ', System.Globalization.NumberStyles.Integer);
            Array.Copy(ipData, 0, data, 0, ipData.Length);
            byte[] maskData = txtMask.Text.Replace(".", " ").ToBytes(' ', System.Globalization.NumberStyles.Integer);
            Array.Copy(maskData, 0, data, 4, ipData.Length);
            byte[] gatewayData = txtGateway.Text.Replace(".", " ").ToBytes(' ', System.Globalization.NumberStyles.Integer);
            Array.Copy(gatewayData, 0, data, 8, ipData.Length);

            EnableControl(sender as Control, false);
            _TLWCommand.tlw_SetNetworkParam(GetMBAddr(), GetId(), data, _DevIP, (param) =>
            {
                Array.ForEach(param, t => WriteOutput(t, "设置网络参数"));
                EnableControl(sender as Control, true);
            });
        }

        private void btnUpgradeMAP_Click(object sender, EventArgs e)
        {
            if (CheckIsBusy()) return;
            string fileName = txtMap.Text;
            if (File.Exists(fileName) == false)
            {
                MessageBox.Show(this, "MAP文件不存在");
                return;
            }

            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }

            EnableControl(sender as Control, false);
            MapHelper.LoadMap(fileName);
            //byte chip = byte.Parse(cbMapPos.SelectedValue.ToString());
            //byte chip = 1;//map只下载到连接卡
            byte[] data = MapHelper.Data;
            //MapHelper.SaveMap(@"C:\Users\Jinjianchao\Desktop\更新连接版FPGA\最终程序\map\readmap.mif", data);
            //EnableControl(sender as Control, true);
            //return;
            _TLWCommand.tlw_WriteMAP(GetMBAddr(), GetId(), data, _DevIP, (param) =>
               {
                   Array.ForEach(param, t => WriteOutput(t, "更新MAP"));
                   EnableControl(sender as Control, true);
               });
        }

        private void btnChoseMAP_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.mif|*.mif";
            if (openFileDialog.ShowDialog(this) == DialogResult.Cancel) return;
            txtMap.Text = openFileDialog.FileName;
        }

        private void btnChoseCalibrationFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.zdat|*.zdat";
            if (openFileDialog.ShowDialog(this) == DialogResult.Cancel) return;
            txtCalibration.Text = openFileDialog.FileName;
        }

        private void btnUpgradeCalibration_Click(object sender, EventArgs e)
        {
            if (CheckIsBusy()) return;
            string fileName = txtCalibration.Text;
            if (File.Exists(fileName) == false)
            {
                MessageBox.Show(this, "校正数据文件不存在");
                return;
            }

            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }
            byte[] data = CalibrationHelper.Read(216, 192, fileName);
            //byte val = 1;
            //for (int j = 0; j < data.Length / 4; j++)
            //{
            //    data[j * 4] = val;
            //    data[j * 4 + 1] = val;
            //    data[j * 4 + 2] = val;
            //    data[j * 4 + 3] = val;
            //    val++;
            //}
            //byte[] newData = new byte[216 * 4096].Fill(0x0);
            //for (int i = 0; i < 216; i++)
            //{
            //    Array.Copy(data, i * 192 * 16, newData, i * 4096, 192 * 16);
            //}

            //byte val = 1;
            //for (int i = 1; i <= data.Length; i++)
            //{
            //    //if (val > 255 || val == 0) val = 1;
            //    //data[i - 1] = val;
            //    //val++;
            //    data[i - 1] = val;
            //    if (i % 1024 == 0)
            //    {
            //        val++;
            //    }
            //}

            byte[] saveData = new byte[data.Length / 2];

            Array.Copy(data, 0, saveData, 0, data.Length / 2);
            CalibrationHelper.Write(saveData, @"D:\tmp\上.zdat");
            Array.Copy(data, data.Length / 2, saveData, 0, data.Length / 2);
            CalibrationHelper.Write(saveData, @"D:\tmp\下.zdat");

            //byte[] saveData = new byte[newData.Length / 2];
            //for (int i = 0; i < newData.Length / 2; i++)
            //{
            //    newData[i] = 0x01;
            //}
            //for (int i = 0; i < newData.Length / 2; i++)
            //{
            //    newData[i + newData.Length / 2] = 0x02;
            //}
            //Array.Copy(newData, newData.Length / 2, saveData, 0, newData.Length / 2);
            //CalibrationHelper.Write(saveData, saveFileDialog.FileName);


            InvokeAsync(() =>
            {
                int errCount = 0;
                EnableControl(sender as Control, false);
                foreach (var item in _DevIP)
                {
                    int result = 0;
                    UInt32 sdramAddr = 0x0000;
                    int count = (int)(data.Length / 1024);
                    for (int i = 0; i < count; i++)
                    {
                        byte[] writeData = new byte[1024];
                        Array.Copy(data, i * 1024, writeData, 0, 1024);

                        result = _TLWCommand.tlw_SDRAM_Write(item.Value, GetMBAddr(), 0, sdramAddr, writeData);
                        System.Threading.Thread.Sleep(1);
                        if (result != 0)
                        {
                            WriteMessage($"IP:{item.Key}写入SDRAM失败");
                            EnableControl(sender as Control, true);
                            return;
                        }
                        SetPrograss($"{i + 1}/{count}", $"{i + 1}/{count}", (int)(((float)(i + 1) / count) * 100));
                        //byte[] readData = new byte[1024];
                        //result = _TLWCommand.tlw_SDRAM_Read(item.Value, GetCardAddress(), 0, sdramAddr, readData);
                        //if (writeData.IsEqual(readData, out int diffIndex, out byte sourceData, out byte targetData) == false)
                        //{
                        //    i--;
                        //    WriteMessage($"第{i + 1}包错误。位置:{diffIndex},写入:{sourceData.ToString("X2")},读取:{targetData.ToString("X2")}");
                        //    errCount++;
                        //    continue;
                        //}
                        //else
                        //{
                        //    WriteMessage($"第{i + 1}包");
                        //}
                        sdramAddr += 1024;
                    }
                    WriteMessage($"写入SDRAM完成，错误次数：{errCount}");
                    byte chipPos = 0;//FPGA
                    bool bSave = true;
                    result = _TLWCommand.tlw_WriteRegister(item.Value, GetMBAddr(), 0, chipPos, 0x91, 1, bSave);//开启校正
                    if (result != 0)
                    {
                        WriteMessage($"IP:{item.Key}开启校正失败");
                        EnableControl(sender as Control, true);
                        return;
                    }

                    UInt32 regLength = 108 * 4096;
                    UInt16 c0 = (UInt16)(regLength & 0x00ffff);
                    UInt16 c1 = (UInt16)(regLength >> 16);
                    result = _TLWCommand.tlw_WriteRegister(item.Value, GetMBAddr(), 0, chipPos, 0xc0, c0, bSave);
                    if (result != 0)
                    {
                        WriteMessage($"IP:{item.Key}设置寄存器C0失败");
                        EnableControl(sender as Control, true);
                        return;
                    }
                    result = _TLWCommand.tlw_WriteRegister(item.Value, GetMBAddr(), 0, chipPos, 0xc1, c1, bSave);
                    if (result != 0)
                    {
                        WriteMessage($"IP:{item.Key}设置寄存器C1失败");
                        EnableControl(sender as Control, true);
                        return;
                    }

                    //result = _TLWCommand.tlw_SDRAM_WriteToFLASH(item.Value, GetCardAddress(), 0);
                    //if (result != 0)
                    //{
                    //    WriteMessage($"IP:{item.Key}SDRAM->FLASH失败");
                    //    EnableControl(sender as Control, true);
                    //    return;
                    //}
                    //System.Threading.Thread.Sleep(30 * 1000);

                }
                EnableControl(sender as Control, true);
            });
        }

        private void btnOpenCalibration_Click(object sender, EventArgs e)
        {
            if (CheckIsBusy()) return;


            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }
            InvokeAsync(() =>
            {
                EnableControl(sender as Control, false);
                foreach (var item in _DevIP)
                {
                    int result = 0;
                    byte chipPos = (byte)cbRegChip.SelectedValue.ToString().ToByte();
                    bool bSave = !ckDebugMode.Checked;
                    result = _TLWCommand.tlw_WriteRegister(item.Value, GetMBAddr(), 0, chipPos, 0x91, 1, bSave);
                    if (result != 0)
                    {
                        WriteMessage($"IP:{item.Key}开启校正失败");
                        EnableControl(sender as Control, true);
                        return;
                    }
                }
                EnableControl(sender as Control, true);
            });
        }

        private void btnSetB6B7_Click(object sender, EventArgs e)
        {
            if (CheckIsBusy()) return;

            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }
            byte chipPos = (byte)cbRegChip.SelectedValue.ToString().ToByte();
            bool bSave = !ckDebugMode.Checked;

            InvokeAsync(() =>
            {
                EnableControl(sender as Control, false);
                foreach (var item in _DevIP)
                {
                    int result = 0;
                    UInt32 regLength = 108 * 4096;
                    UInt16 c0 = (UInt16)(regLength & 0x00ffff);
                    UInt16 c1 = (UInt16)(regLength >> 16);
                    result = _TLWCommand.tlw_WriteRegister(item.Value, GetMBAddr(), 0, chipPos, 0xc0, c0, bSave);
                    if (result != 0)
                    {
                        WriteMessage($"IP:{item.Key}设置寄存器C0失败");
                        EnableControl(sender as Control, true);
                        return;
                    }
                    result = _TLWCommand.tlw_WriteRegister(item.Value, GetMBAddr(), 0, chipPos, 0xc1, c1, bSave);
                    if (result != 0)
                    {
                        WriteMessage($"IP:{item.Key}设置寄存器C1失败");
                        EnableControl(sender as Control, true);
                        return;
                    }
                }
                EnableControl(sender as Control, true);
            });
        }

        private void btnSDRAMToFlash_Click(object sender, EventArgs e)
        {
            if (CheckIsBusy()) return;

            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }
            InvokeAsync(() =>
            {
                EnableControl(sender as Control, false);
                foreach (var item in _DevIP)
                {
                    int result = 0;
                    result = _TLWCommand.tlw_SDRAM_WriteToFLASH(item.Value, GetMBAddr(), 0);
                    if (result != 0)
                    {
                        WriteMessage($"IP:{item.Key}SDRAM->FLASH失败");
                        EnableControl(sender as Control, true);
                        return;
                    }
                    System.Threading.Thread.Sleep(12 * 1000);
                }
                EnableControl(sender as Control, true);
            });
        }

        private void btnSetRegister_Click(object sender, EventArgs e)
        {
            EnableControl(sender as Control, false);
            byte chipPos = (byte)cbRegChip.SelectedValue.ToString().ToByte();
            uint addr = (uint)numSingleRegAddr.Value;
            _TLWCommand.tlw_WriteRegister(GetMBAddr(), GetId(), chipPos, addr, (uint)numSingleRegValue.Value, true, _DevIP, (param2) =>
             {
                 Array.ForEach(param2, t2 =>
                 {

                     if (t2.ResultCode == 0)
                     {
                         WriteOutput(t2, "写入寄存器");
                         EnableControl(sender as Control, true);
                     }
                     else
                     {
                         WriteOutput(t2, "写入寄存器");
                         EnableControl(sender as Control, true);
                     }
                 });
             });
        }

        private void btnSingleRegRead_Click(object sender, EventArgs e)
        {
            EnableControl(sender as Control, false);
            byte chipPos = (byte)cbRegChip.SelectedValue.ToString().ToByte();
            uint addr = (uint)numSingleRegAddr.Value;
            _TLWCommand.tlw_ReadRegister(GetMBAddr(), GetId(), chipPos, addr, _DevIP, (param2) =>
             {
                 Array.ForEach(param2, t2 =>
                 {

                     if (t2.ResultCode == 0)
                     {
                         WriteOutput(t2, "读取寄存器");
                         Invoke(new MethodInvoker(() =>
                         {
                             numSingleRegValue.Value = (t2.Data as uint[])[0];
                         }));
                         EnableControl(sender as Control, true);
                     }
                     else
                     {
                         WriteOutput(t2, "读取寄存器");
                         EnableControl(sender as Control, true);
                     }
                 });
             });
        }

        private void gridOtherReg_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            _CurrentOtherGridRowIndex = e.RowIndex;
            _CurrentOtherGridColumnIndex = e.ColumnIndex;
        }

        private void gridOtherReg_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridOtherReg.SelectedRows.Count == 1)
            {
                _CurrentOtherGridRowIndex = e.RowIndex;
                _CurrentOtherGridColumnIndex = e.ColumnIndex;

                RegisterOtherItem regItemData = gridOtherReg.Rows[gridOtherReg.SelectedRows[0].Index].DataBoundItem as TLWController.Helper.RegisterOtherItem;
                if (gridOtherReg.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "ColOtherValue")
                {
                    int cellX = gridOtherReg.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).X;
                    int cellY = gridOtherReg.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Y;

                    Rectangle rect = gridOtherReg.Rows[e.RowIndex].Cells[e.ColumnIndex].ContentBounds;

                    if (regItemData.MaxValue.ToInit32(System.Globalization.NumberStyles.HexNumber) - regItemData.MinValue.ToInit32(System.Globalization.NumberStyles.HexNumber) <= 10)
                    {
                        //combobox
                        gridOtherReg.Controls["cbOtherValue"].Bounds = rect;
                        gridOtherReg.Controls["cbOtherValue"].Location = new Point(cellX, cellY);

                        List<ListItem> items = new List<ListItem>();
                        for (int i = regItemData.MinValue.ToInit32(System.Globalization.NumberStyles.HexNumber); i <= regItemData.MaxValue.ToInit32(System.Globalization.NumberStyles.HexNumber); i++)
                        {
                            items.Add(new ListItem() { Value = i, Text = i.ToString("X2") });
                        }
                        (gridOtherReg.Controls["cbOtherValue"] as ComboBox).ValueMember = "Value";
                        (gridOtherReg.Controls["cbOtherValue"] as ComboBox).DisplayMember = "Text";
                        (gridOtherReg.Controls["cbOtherValue"] as ComboBox).DataSource = items;

                        object obj = gridOtherReg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        string str1 = (string)obj;
                        int byteVal = int.Parse(str1, System.Globalization.NumberStyles.HexNumber);

                        (gridOtherReg.Controls["cbOtherValue"] as ComboBox).SelectedValue = byteVal;
                        gridOtherReg.Controls["cbOtherValue"].Visible = true;
                    }
                    else
                    {
                        //numValue
                        gridOtherReg.Controls["numOtherValue"].Bounds = rect;
                        gridOtherReg.Controls["numOtherValue"].Location = new Point(cellX, cellY);
                        (gridOtherReg.Controls["numOtherValue"] as NumericUpDown).Minimum = regItemData.MinValue.ToInit32(System.Globalization.NumberStyles.HexNumber);
                        (gridOtherReg.Controls["numOtherValue"] as NumericUpDown).Maximum = regItemData.MaxValue.ToInit32(System.Globalization.NumberStyles.HexNumber);
                        object obj = gridOtherReg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        (gridOtherReg.Controls["numOtherValue"] as NumericUpDown).Hexadecimal = true;
                        string str1 = (string)obj;
                        Int32 byteVal = Int32.Parse(str1, System.Globalization.NumberStyles.HexNumber);
                        (gridOtherReg.Controls["numOtherValue"] as NumericUpDown).Value = byteVal;
                        gridOtherReg.Controls["numOtherValue"].Visible = true;
                    }
                }
            }
        }

        private void gridOtherReg_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridOtherReg.Controls["numOtherValue"].Visible = false;
            gridOtherReg.Controls["cbOtherValue"].Visible = false;
            if (gridOtherReg.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "ColOtherValue" && gridOtherReg.SelectedRows.Count != 0)
            {
                RegisterOtherItem regItemData = gridOtherReg.Rows[gridOtherReg.SelectedRows[0].Index].DataBoundItem as TLWController.Helper.RegisterOtherItem;
                if (regItemData.MaxValue.ToInit32(System.Globalization.NumberStyles.HexNumber) - regItemData.MinValue.ToInit32(System.Globalization.NumberStyles.HexNumber) <= 10)
                {
                    gridOtherReg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ((int)(gridOtherReg.Controls["cbOtherValue"] as ComboBox).SelectedValue).ToString("X2");
                }
                else
                {
                    gridOtherReg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ((int)(gridOtherReg.Controls["numOtherValue"] as NumericUpDown).Value).ToString("X2");
                }
            }
        }

        private void gridOtherReg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CheckIsBusy()) return;
            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }

            if (gridOtherReg.SelectedRows.Count == 1)
            {

                if (gridOtherReg.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "ColOtherSend")
                {
                    RegisterOtherItem regItemData = gridOtherReg.Rows[gridOtherReg.SelectedRows[0].Index].DataBoundItem as TLWController.Helper.RegisterOtherItem;

                    byte chipPos = (byte)cbRegChip.SelectedValue.ToString().ToByte();
                    bool bSave = !ckDebugMode.Checked;
                    byte color = byte.Parse(cbParam2055Color.SelectedValue.ToString());

                    EnableControl(gridOtherReg as Control, false);

                    _TLWCommand.tlw_WriteRegister(GetMBAddr(), GetId(), chipPos, regItemData.Address.ToUInt32(), regItemData.Value.ToUInt32(), bSave, _DevIP, (param) =>
                    {
                        Array.ForEach(param, t =>
                        {
                            WriteOutput(t, "写入寄存器");
                            EnableControl(gridOtherReg as Control, true);
                        });
                    });

                }
            }
        }

        private void gridOtherReg_Scroll(object sender, ScrollEventArgs e)
        {
            gridOtherReg.Controls["numOtherValue"].Visible = false;
            gridOtherReg.Controls["cbOtherValue"].Visible = false;
            if (gridOtherReg.Rows[_CurrentOtherGridRowIndex].Cells[_CurrentOtherGridColumnIndex].OwningColumn.Name == "ColOtherValue")
            {
                RegisterOtherItem regItemData = gridOtherReg.Rows[gridOtherReg.SelectedRows[0].Index].DataBoundItem as TLWController.Helper.RegisterOtherItem;
                if (regItemData.MaxValue.ToInit32(System.Globalization.NumberStyles.HexNumber) - regItemData.MinValue.ToInit32(System.Globalization.NumberStyles.HexNumber) <= 10)
                {
                    gridOtherReg.Rows[_CurrentOtherGridRowIndex].Cells[_CurrentOtherGridColumnIndex].Value = ((int)(gridOtherReg.Controls["cbOtherValue"] as ComboBox).SelectedValue).ToString("X2");
                }
                else
                {
                    gridOtherReg.Rows[_CurrentOtherGridRowIndex].Cells[_CurrentOtherGridColumnIndex].Value = ((int)(gridOtherReg.Controls["numOtherValue"] as NumericUpDown).Value).ToString("X2");
                }
            }
        }

        private void grid2055_Scroll(object sender, ScrollEventArgs e)
        {
            grid2055.Controls["numValue"].Visible = false;
            grid2055.Controls["cbValue"].Visible = false;
            if (grid2055.Rows[_CurrentGridRowIndex].Cells[_CurrentGridColumnIndex].OwningColumn.Name == "ColRedValue" ||
                    grid2055.Rows[_CurrentGridRowIndex].Cells[_CurrentGridColumnIndex].OwningColumn.Name == "ColGreenValue" ||
                    grid2055.Rows[_CurrentGridRowIndex].Cells[_CurrentGridColumnIndex].OwningColumn.Name == "ColBlueValue"
                    )
            {
                RegisterItem regItemData = grid2055.Rows[grid2055.SelectedRows[0].Index].DataBoundItem as TLWController.Helper.RegisterItem;
                if (regItemData.MaxValue - regItemData.MinValue <= 10)
                {
                    grid2055.Rows[_CurrentGridRowIndex].Cells[_CurrentGridColumnIndex].Value = ((int)(grid2055.Controls["cbValue"] as ComboBox).SelectedValue).ToString("X2");
                }
                else
                {
                    grid2055.Rows[_CurrentGridRowIndex].Cells[_CurrentGridColumnIndex].Value = ((byte)(grid2055.Controls["numValue"] as NumericUpDown).Value).ToString("X2");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EnableControl(sender as Control, false);
            byte chipPos = (byte)cbRegChip.SelectedValue.ToString().ToByte();
            uint addr = (uint)numSingleRegAddr.Value;
            ushort cardAddr = (ushort)(241 << 8 | 241);
            byte val = byte.Parse(cbWorkMode.SelectedValue.ToString());
            _TLWCommand.tlw_SetDisplayMode(cardAddr, GetId(), val,  _DevIP, (param2) =>
            {
                Array.ForEach(param2, t2 =>
                {

                    if (t2.ResultCode == 0)
                    {
                        WriteOutput(t2, "切换工装");
                        EnableControl(sender as Control, true);
                    }
                    else
                    {
                        WriteOutput(t2, "切换工装");
                        EnableControl(sender as Control, true);
                    }
                });
            });
        }

        private void rbCalOn_Click(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked == false) return;
            uint val = uint.Parse(rb.Tag.ToString());
            EnableControl(groupBox11 as Control, false);
            InvokeAsync(() =>
            {
                int errCount = 0;
                foreach (var item in _DevIP)
                {
                    int result = 0;
                    byte chipPos = 0;//FPGA
                    bool bSave = true;
                    result = _TLWCommand.tlw_WriteRegister(item.Value, GetCardAddress(0, 0), 0, chipPos, 0x91, val, bSave);//开启校正
                    if (result != 0)
                    {
                        WriteMessage($"IP:{item.Key}开启校正失败");
                        EnableControl(sender as Control, true);
                        return;
                    }
                }
                EnableControl(groupBox11 as Control, true);
            });

        }

        private void rbCalOff_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnRegSetDefault_Click(object sender, EventArgs e)
        {
            string file = System.IO.Path.Combine(Path, @"Config\Param2055_Default.txt");
            if (!Import2055Param(file))
            {
                MessageBox.Show(this, "导入2055参数失败");
                return;
            }
        }

        private void btnSelectBatchCalibrationFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog(this) == DialogResult.Cancel) return;
            txtBatchCalibrationFolder.Text = folderBrowser.SelectedPath;
        }

        private void btnBatchWriteCalibration_Click(object sender, EventArgs e)
        {
            if (CheckIsBusy()) return;
            string folder = txtBatchCalibrationFolder.Text;
            if (Directory.Exists(folder) == false)
            {
                MessageBox.Show(this, "校正数据文件夹不存在");
                return;
            }

            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }
            InvokeAsync(() =>
            {
                int errCount = 0;
                EnableControl(sender as Control, false);
                for (int row = 0; row < 5; row++)
                {
                    for (int column = 0; column < 10; column++)
                    {
                        string fileName = $@"{folder}\{row}.zdat";
                        byte[] data = CalibrationHelper.Read(216, 192, fileName);

                        foreach (var item in _DevIP)
                        {
                            int result = 0;
                            UInt32 sdramAddr = 0x0000;
                            int count = (int)(data.Length / 1024);
                            for (int i = 0; i < count; i++)
                            {
                                byte[] writeData = new byte[1024];
                                Array.Copy(data, i * 1024, writeData, 0, 1024);

                                result = _TLWCommand.tlw_SDRAM_Write(item.Value, GetCardAddress(column + 1, row + 1), 0, sdramAddr, writeData);
                                System.Threading.Thread.Sleep(1);
                                if (result != 0)
                                {
                                    WriteMessage($"IP:{item.Key}写入SDRAM失败");
                                    EnableControl(sender as Control, true);
                                    return;
                                }
                                SetPrograss($"行:{row + 1},列{column + 1} {i + 1}/{count}", $"行:{row + 1},列{column + 1} {i + 1}/{count}", (int)(((float)(i + 1) / count) * 100));
                                sdramAddr += 1024;
                            }
                        }
                    }
                }

                //byte chipPos = (byte)cbRegChip.SelectedValue.ToString().ToByte();
                //bool bSave = !ckDebugMode.Checked;
                //foreach (var item in _DevIP)
                //{
                //    int result = 0;
                //    UInt32 regLength = 108 * 4096;
                //    UInt16 c0 = (UInt16)(regLength & 0x00ffff);
                //    UInt16 c1 = (UInt16)(regLength >> 16);
                //    result = _TLWCommand.tlw_WriteRegister(item.Value, GetCardAddress(0, 0), 0, chipPos, 0xc0, c0, bSave);
                //    if (result != 0)
                //    {
                //        WriteMessage($"IP:{item.Key}设置寄存器C0失败");
                //        EnableControl(sender as Control, true);
                //        return;
                //    }
                //    result = _TLWCommand.tlw_WriteRegister(item.Value, GetCardAddress(0, 0), 0, chipPos, 0xc1, c1, bSave);
                //    if (result != 0)
                //    {
                //        WriteMessage($"IP:{item.Key}设置寄存器C1失败");
                //        EnableControl(sender as Control, true);
                //        return;
                //    }
                //}

                foreach (var item in _DevIP)
                {
                    int result = 0;
                    result = _TLWCommand.tlw_SDRAM_WriteToFLASH(item.Value, GetCardAddress(0, 0), 0);
                    if (result != 0)
                    {
                        WriteMessage($"IP:{item.Key}SDRAM->FLASH失败");
                        EnableControl(sender as Control, true);
                        return;
                    }
                    System.Threading.Thread.Sleep(12 * 1000);
                }
                EnableControl(sender as Control, true);
            });
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            string str1 = ReadTextFile(txtCompareFile1.Text).Trim();
            string str2 = ReadTextFile(txtCompareFile2.Text).Trim();
            byte[] bt1 = str1.ToBytes(' ');
            byte[] bt2 = str2.ToBytes(' ');
            string compareStr = "";
            for (int i = 0; i < bt1.Length; i++)
            {
                if (bt1[i] != bt2[i])
                {
                    compareStr += $"Pos:{i} 值1：{bt1[i].ToString("X2")} 值2：{bt2[i].ToString("X2")}\r\n";
                }
            }
            rtCompare.Text = compareStr;
        }

        private void btnCompareChose1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.txt|*.txt";
            if (openFileDialog.ShowDialog(this) == DialogResult.Cancel) return;
            txtCompareFile1.Text = openFileDialog.FileName;
        }

        private void btnCompareChose2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.txt|*.txt";
            if (openFileDialog.ShowDialog(this) == DialogResult.Cancel) return;
            txtCompareFile2.Text = openFileDialog.FileName;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.zdat|*.zdat";
            if (openFileDialog.ShowDialog(this) == DialogResult.Cancel) return;
            txtCalibration.Text = openFileDialog.FileName;
        }

        private void btnSendCalibrationOnOff_Click(object sender, EventArgs e)
        {
            EnableControl(sender as Control, false);
            ushort cardAddr = GetMBAddr();
            byte val = byte.Parse(cbCalibrationOnOff.SelectedValue.ToString());
            _TLWCommand.tlw_SetDisplayMode(cardAddr, GetId(), val, _DevIP, (param2) =>
            {
                Array.ForEach(param2, t2 =>
                {

                    if (t2.ResultCode == 0)
                    {
                        WriteOutput(t2, "切换校正");
                        EnableControl(sender as Control, true);
                    }
                    else
                    {
                        WriteOutput(t2, "切换校正");
                        EnableControl(sender as Control, true);
                    }
                });
            });
        }

        private void btnChoseDistributeBoardFPGA_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.bin|*.bin";
            if (openFileDialog.ShowDialog(this) == DialogResult.Cancel) return;
            txtDistributeBoardFPGA.Text = openFileDialog.FileName;
        }

        private void btnUpdateDistributeBoardFPGA_Click(object sender, EventArgs e)
        {
            //if (CheckIsBusy()) return;
            //if (!CheckDeviceAddr())
            //{
            //    MessageBox.Show(this, "设备地址错误");
            //    return;
            //}
            //byte[] data = FileHelper.ReadBinaryFile(txtDistributeBoardFPGA.Text);
            //if (data == null)
            //{
            //    MessageBox.Show(this, "文件读取失败");
            //    return;
            //}
            //byte[] newData = null;
            //if (data.Length % 1024 != 0)
            //{
            //    int yushu = data.Length % 1024;
            //    int externalCount = 1024 - yushu;
            //    newData = new byte[data.Length + externalCount].Fill(0xff);
            //    Array.Copy(data, 0, newData, 0, data.Length);
            //}
            //else
            //{
            //    newData = data;
            //}

            //byte chip = byte.Parse(cbAdvChip.SelectedValue.ToString());
            //UInt32 flashAddr = UInt32.Parse(cbDistributeAddress.SelectedValue.ToString());

            //InvokeAsync(() =>
            //{
            //    EnableControl(sender as Control, false);
            //    foreach (var item in _DevIP)
            //    {
            //        int result = 0;
            //        int cx = 0;
            //        int count = (int)(data.Length / 1024);
            //        for (int i = 0; i < count; i++)
            //        {
            //            byte[] writeData = new byte[1024];
            //            Array.Copy(data, cx, writeData, 0, 1024);

            //            result = _TLWCommand.tlw_FLASH_Write(item.Value, GetCardAddress(), 0, chip, flashAddr, writeData, 1024);
            //            if ((flashAddr & 0xffff) == 0)
            //            {
            //                System.Threading.Thread.Sleep(1000);
            //            }
            //            if (result != 0)
            //            {
            //                WriteMessage($"IP:{item.Key}写入失败");
            //                EnableControl(sender as Control, true);
            //                return;
            //            }
            //            flashAddr += 1024;
            //            cx += 1024;
            //            SetPrograss($"{i + 1}/{count}", $"{i + 1}/{count}", (int)(((float)(i + 1) / count) * 100));
            //        }
            //    }
            //    EnableControl(sender as Control, true);
            //});

            Point addr = GetUnitAddr();
            if (addr.X < 0x60 || addr.Y < 0x60)
            {
                MessageBox.Show(this, "地址错误,分配板地址:广播地址(x=60,y=60)，单个地址(x=61,y=61,62...)");
                return;
            }
            if (CheckIsBusy()) return;
            string fileName = txtDistributeBoardFPGA.Text;
            if (File.Exists(fileName) == false)
            {
                MessageBox.Show(this, "FPGA文件不存在");
                return;
            }

            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }
            byte chip = byte.Parse(cbAdvChip.SelectedValue.ToString());
            EnableControl(sender as Control, false);
            _TLWCommand.tlw_Firmware_Write(GetMBAddr(), GetId(), chip, 1, fileName, _DevIP, (param) =>
             {
                 Array.ForEach(param, t => WriteOutput(t, "更新FPGA"));
                 EnableControl(sender as Control, true);
             });
        }

        private void btnReadbtnDistributeBoardFPGA_Click(object sender, EventArgs e)
        {

        }

        private void btnImport2072_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "*.txt|*.txt";
            openFileDlg.FileName = "Register2072.txt";
            if (openFileDlg.ShowDialog(this) == DialogResult.Cancel) return;
            if (!Import2055Param(openFileDlg.FileName))
            {
                MessageBox.Show(this, "导入2055参数失败");
                return;
            }
        }

        private void btnLoadFPGA_Click(object sender, EventArgs e)
        {
            Byte[] data = new byte[26];
            byte[] header = ((UInt32)0xAA8E42).GetBytes();

            List<byte> list = new List<byte>();
            list.Add(header[1]);
            list.Add(header[2]);
            list.Add(header[3]);

            byte[] len = ((UInt16)0x001A).GetBytes();
            list.Add(len[0]);
            list.Add(len[1]);

            byte[] addr = GetMBAddr().GetBytes();
            list.Add(addr[0]);
            list.Add(addr[0]);

            //数据包识别号
            list.Add(0);
            list.Add(0);

            byte[] cmd = ((UInt16)0x001A).GetBytes();
            list.Add(cmd[0]);
            list.Add(cmd[1]);

            list.AddRange(new byte[4]);

            list.Add(0x00);
            list.Add(0x01);

            list.Add(0x00);
            list.Add(0x01);

            list.Add(0);

            byte pos = byte.Parse(cbAdvChip.SelectedValue.ToString());
            list.Add(pos);

            byte[] tmpData = list.ToArray();
            Array.Copy(tmpData, 0, data, 0, tmpData.Length);

            byte[] sum = data.Sum(3, 20).GetBytes();
            data[21] = sum[0];
            data[22] = sum[1];

            byte[] footer = ((UInt32)0x5571BD).GetBytes();
            Array.Copy(footer, 1, data, 23, 3);

            //Array.Copy(header, 1, data, 0, header.Length - 1);
            //data[3] = 0x13;
            //byte[] addr = GetCardAddress().GetBytes();
            //data[6] = addr[0];
            //data[7] = addr[1];
            //data[8] = 0x50;
            //byte[] flashAddr = UInt32.Parse(cbDistributeAddress.SelectedValue.ToString()).GetBytes();
            //data[10] = flashAddr[1];
            //data[11] = flashAddr[2];
            //data[12] = flashAddr[3];
            //byte[] sum = data.Sum(3, 1036).GetBytes();
            //data[1037] = sum[0];
            //data[1038] = sum[1];

            //byte[] footer = ((UInt32)0x5571BE).GetBytes();
            //Array.Copy(footer, 1, data, 1039, 3);

            string ip = GetCommunicationType().StartIPAddress;
            InvokeAsync(() =>
            {
                EnableControl(sender as Control, false);
                WriteMessage("发送数据:" + data.ToString(" "));
                int revLen = UDPHelper.Send(data, ip, out byte[] revWriteFlash);
                if (revLen == 0)
                {
                    WriteMessage("没有收到返回数据");
                }
                else
                {
                    WriteMessage("收到数据:" + revWriteFlash.ToString(" "));
                }
                EnableControl(sender as Control, true);
            });

        }

        private void btn2072Simple_ImportFile_Click(object sender, EventArgs e)
        {
            //导入文件

            string ip = ShowSelectIPDialog();
            if (string.IsNullOrEmpty(ip)) return;

            if (ReadMBParamToObj(ip) == false)
            {
                MessageBox.Show(btn2072Simple_ImportFile.Text, Trans("错误"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int nMode = m_n2072SimpleIndex;

            bool bInRightMode = true;

            switch (nMode)
            {
                case 0://60Hz
                    if (m_MBParamObj.Is3D)
                    {
                        bInRightMode = false;
                    }
                    else if (m_MBParamObj.Is60Hz == false)
                    {
                        bInRightMode = false;
                    }
                    break;
                case 1://50Hz
                    if (m_MBParamObj.Is3D)
                    {
                        bInRightMode = false;
                    }
                    else if (m_MBParamObj.Is60Hz == true)
                    {
                        bInRightMode = false;
                    }
                    break;
                case 2://3D
                    bInRightMode = m_MBParamObj.Is3D;
                    break;
            }

            string info = "";
            DialogResult dlgResult = DialogResult.OK;

            class2072Oper objOper = m_2072SimpleParam;


            info = tabPage3.Text + " " + btn2072Simple_ImportFile.Text + " " + cb2072Simple5060Hz.Text + " " + Trans("参数");

            dlgResult = MessageBox.Show(info, Trans("注意"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlgResult == DialogResult.No) return;


            //2018-11-07 当前主板状态与选项不一致 是否继续
            if (bInRightMode == false)
            {
                string szStatusNoRight = string.Format(Trans("箱体显示状态不是:{0} 是否继续?"), cb2072Simple5060Hz.Text);
                dlgResult = MessageBox.Show(szStatusNoRight, Trans("错误"), MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dlgResult == DialogResult.No) return;
            }

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = Trans("2072配置文件") + "(*.txt)|*.txt";
            if (dlg.ShowDialog(this) == DialogResult.Cancel) return;
            string path = dlg.FileName;

            bool bResult = objOper.ImportFile(nMode, path);

            if (!bResult)
            {
                info += " " + Trans("失败") + "!";
                MessageBox.Show(info, Trans("错误"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteMessage(info + "\r\n" + path);
            }

            bResult = objOper.Is2072Ready(nMode);
            HideSomeCtrlsBeforeImportFile(!bResult);

            //刷新界面

            if (bResult)
            {    //Refresh2072SimpleData(true);
                objOper.UpdateData(nMode, false);
                objOper.UpdateData2019(nMode, false);
                objOper.UpdateDataRegister128(nMode, false);//2019-03-25 新增对寄存器128地址的操作

            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            //2072初始化
            Initial2072();

            //-------------2072Simple界面--------------
            cb2072FuncTest2.SelectedIndex = 0;
            cb2072FuncTest3.SelectedIndex = cb2072FuncTest3.Items.Count - 1;

            cb2072Simple1.Items.Clear();
            cb2072Simple1.Items.Add(Trans("帧同步"));
            cb2072Simple1.Items.Add(Trans("帧间隔"));
            cb2072Simple1.SelectedIndex = 0;

            //处理类对象初始化
            m_2072SimpleParam = new class2072Oper();
            m_2072SimpleParam.FindCtrls(panel3);
            m_2072SimpleParam.AddCtrl_2019(new Control[] { input2019Simple_160, input2019Simple_161, input2019Simple_162, input2019Simple_163 });
            m_2072SimpleParam.AddCtrl_Register128(new Control[] { input2072FuncRegAddr, cb2072FuncTest2, cb2072FuncTest3, input2072FuncVal });//2019-03-25 新增寄存器128地址的控制

            //50/60Hz模式切换
            cb2072Simple5060Hz.Items.Clear();
            cb2072Simple5060Hz.Items.Add("60Hz");
            cb2072Simple5060Hz.Items.Add("50Hz");
            cb2072Simple5060Hz.Items.Add("3D");
            cb2072Simple5060Hz.SelectedIndex = 0;//默认60Hz

            //GAMMA
            cb2072SimpleGAMMA.Items.Clear();
            cb2072SimpleGAMMA.Items.Add(Trans("全部"));
            cb2072SimpleGAMMA.Items.Add(Trans("红色"));
            cb2072SimpleGAMMA.Items.Add(Trans("绿色"));
            cb2072SimpleGAMMA.Items.Add(Trans("蓝色"));
            cb2072SimpleGAMMA.SelectedIndex = 0;

            //-------------2072Simple界面 End ----------------


            //------------------2072 Factory模式 ---------------------

            //2018-09-26 2200操作类

            //处理类对象初始化
            m_2072FactoryParam = new class2072Oper();
            m_2072FactoryParam.FindCtrls(panel4);
            //m_2072FactoryParam.AddCtrl_2019(new Control[] { input2019Simple_160, input2019Simple_161, input2019Simple_162, input2019Simple_163 });
            m_2072FactoryParam.AddCtrl_Register128(new Control[] { input2072FactoryRegisterAddr, cb2072FactoryRegister_StartBit, cb2072FactoryRegister_EndBit, input2072FactoryRegisterVal });//2019-03-25 新增寄存器128地址的控制

            //选中某个模式 60Hz、50Hz、3D
            cb2072Factory5060Hz.Items.Clear();
            cb2072Factory5060Hz.Items.Add("60Hz");
            cb2072Factory5060Hz.Items.Add("50Hz");
            cb2072Factory5060Hz.Items.Add("3D");
            cb2072Factory5060Hz.SelectedIndex = 0;

            cb2072FactoryRegister_StartBit.Items.Clear();
            cb2072FactoryRegister_EndBit.Items.Clear();
            for (int i = 0; i < 16; i++)
            {
                cb2072FactoryRegister_StartBit.Items.Add(i.ToString());
                cb2072FactoryRegister_EndBit.Items.Add(i.ToString());
            }
            cb2072FactoryRegister_StartBit.SelectedIndex = 0;
            cb2072FactoryRegister_EndBit.SelectedIndex = 15;

            input2072FactoryRegisterAddr.Text = "128";
            input2072FactoryRegisterVal.Text = "128";

            //------------------2072 Factory模式  End------------------

            //OnTypeChangeGUINeedChange();//2017-12-15 统一一个方法，箱体类型变化的时候就变化
        }

        private void cb2072Simple5060Hz_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_n2072SimpleIndex = cb2072Simple5060Hz.SelectedIndex;//2018-09-10

            //bool[] arrHide = { !m_bImported60Hz, !m_bImported50Hz };

            //bool bHide = arrHide[m_n2072SimpleIndex];//判断某种类型是否ready,未ready就要隐藏

            if (m_2072SimpleParam == null)
            {
                HideSomeCtrlsBeforeImportFile(true);
                return;
            }

            bool bHide = !m_2072SimpleParam.Is2072Ready(m_n2072SimpleIndex);

            HideSomeCtrlsBeforeImportFile(bHide);

            //刷新界面
            if (bHide == false)
                //Refresh2072SimpleData(true);
                m_2072SimpleParam.UpdateData(m_n2072SimpleIndex, false);
        }

        private void btn2072Simple_ExportFile_Click(object sender, EventArgs e)
        {
            //导出文件

            string info = "";
            DialogResult dlgResult = DialogResult.OK;

            info = tabPage3.Text + " " + btn2072Simple_ExportFile.Text + " " + cb2072Simple5060Hz.Text + " " + Trans("参数");

            dlgResult = MessageBox.Show(info, Trans("注意"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlgResult == DialogResult.No) return;

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = Trans("2072配置文件") + "(*.txt)|*.txt";

            if (dlg.ShowDialog(this) == DialogResult.Cancel) return;

            string path = dlg.FileName;

            //更新界面参数
            m_2072SimpleParam.UpdateData(m_n2072SimpleIndex);

            //2019-03-25 add
            m_2072SimpleParam.UpdateData2019(m_n2072SimpleIndex);//以前漏掉了

            //2019-03-25 增加128寄存器的操作
            m_2072SimpleParam.UpdateDataRegister128(m_n2072SimpleIndex);


            if (m_2072SimpleParam.ExportFile(m_n2072SimpleIndex, path))
            {
                WriteMessage(info + " :" + path + Trans("成功") + "!");
            }
            else
                WriteMessage(info + " :" + path + Trans("失败") + "!");
        }

        private void btn2072Simple_ResetValues_Click(object sender, EventArgs e)
        {
            //将内存数据恢复到默认值

            if (MessageBox.Show("将要修改寄存器数值数组到默认值，并刷新当前界面显示，是否继续?", "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;

            UInt32[] arrDefalut = {
                                      0x00003f00,
                                      0x80800000,
                                      0x80000000,
                                      0x00000a02,
                                      0x03060606,
                                      0x04044111,
                                      0x02004FFF,
                                      0xF0001FE0,
                                      0x16E0E040,
                                      0x64100050,
                                      0x640F004B,
                                      0x6412004C,
                                      0x81000058,
                                      0,0,0,0,
                                      32,15,48,10/*2019默认值*/
                                  };

            m_2072SimpleParam.ImportDefaultValue(m_n2072SimpleIndex, arrDefalut, 0, 21);


            //刷新界面
            //Refresh2072SimpleData(true);
            m_2072SimpleParam.UpdateData(m_n2072SimpleIndex, false);
        }

        /// <summary>
        /// 从最大值位数转换为最大灰阶值
        /// </summary>
        /// <param name="nBit"></param>
        /// <returns></returns>
        private int GetGAMMAMaxValueFromBit(int nBit)
        {
            return ((1 << nBit) - 1);
        }

        /// <summary>
        /// 批量写入多个寄存器值
        /// </summary>
        /// <returns></returns>
        private bool Write2072RegisterMulti(int hDevice, ushort addrMB, byte id, byte chip, int nParamIndex, List<ushort> listRegAddr, List<byte> listBitLow, List<byte> listBitHigh, List<ushort> listVals, int nPercentMax = 100)
        {
            if (listRegAddr == null) return false;
            if (listBitLow == null) return false;
            if (listBitHigh == null) return false;
            if (listVals == null) return false;

            int nLen = listRegAddr.Count;

            if ((nLen != listBitHigh.Count) || (nLen != listBitLow.Count) || (nLen != listVals.Count)) return false;

            string info = "";

            ushort[] arrRegAddr = new ushort[nLen];
            byte[] arrBitLow = new byte[nLen];
            byte[] arrBitHigh = new byte[nLen];
            ushort[] arrVals = new ushort[nLen];

            for (int i = 0; i < nLen; i++)
            {
                arrRegAddr[i] = listRegAddr[i];
                arrBitLow[i] = listBitLow[i];
                arrBitHigh[i] = listBitHigh[i];
                arrVals[i] = listVals[i];

                info = string.Format("{0}:0x{1:X2} {2}:{3} {4}:{5} Value:{6}",
                    Trans("寄存器地址"), arrRegAddr[i],
                    Trans("起始位"), arrBitLow[i],
                    Trans("终止位"), arrBitHigh[i],
                    arrVals[i]);

                //byte result = twsOper.tws_Write2072RegisterMulti(m_hDevice, addrMB, (byte)nParamIndex, arrRegAddr, arrBitLow, arrBitHigh, arrVals, nLen);

                //byte result = _TLWCommand.tlw_WriteRegister(hDevice, addrMB, (byte)nParamIndex, arrRegAddr[i], arrBitLow[i], arrBitHigh[i], arrVals[i]);
                int result = _TLWCommand.tlw_WriteRegister(hDevice, addrMB, id, chip, arrRegAddr[i], arrVals[i], true);
                if (result == 0)
                {
                    info = info + " " + Trans("成功") + "!";
                    WriteMessage(info);
                }
                else
                {
                    info = info + " " + Trans("失败") + "!";
                    //WriteStatusMessage(info);
                    WriteMessage(info);
                    break;
                }

                SetPrograss(string.Format("{0}/{1}", i + 1, nLen), "", nPercentMax * (i + 1) / nLen);//百分比
            }

            return true;
        }

        private void btn2072Simple_SendAll_Click(object sender, EventArgs e)
        {
            //全部发送
            string txt = "2200 " + cb2072Simple5060Hz.Text + " " + Trans("参数") + " " + btn2072Simple_SendAll.Text;

            ushort addrMB = GetMBAddr();

            int nMode = m_n2072SimpleIndex;

            //更新界面参数
            m_2072SimpleParam.UpdateData(nMode);

            //2019-03-25 发现原来遗漏了2019的参数
            m_2072SimpleParam.UpdateData2019(nMode);

            //2019-03-25 新增128寄存器值，直接从界面获取
            m_2072SimpleParam.UpdateDataRegister128(nMode);


            List<ushort> listRegAddr = new List<ushort>();
            List<byte> listBitLow = new List<byte>();
            List<byte> listBitHigh = new List<byte>();
            List<ushort> listVals = new List<ushort>();


            //发送17个2200寄存器值            

            //发送2019的值
            bool bWith2019 = true;

            bool bResult = m_2072SimpleParam.GetMultiRegAndValues(nMode, bWith2019, listRegAddr, listBitLow, listBitHigh, listVals);

            if (bResult == false)
            {
                txt += " " + Trans("失败");
                WriteMessage(txt);
            }

            //发送128寄存器值
            UnitTypeV2 objType = GetSelectedPanelType();
            ArrayList calcResult = m_2072SimpleParam.RunCalc(nMode, objType.SubName);
            if (calcResult == null)
            {
                txt += " " + Trans("失败");
                WriteMessage(txt);
                return;
            }

            //计算出最大灰度级数
            int nMaxGrayLevel = (int)calcResult[6];

            //计算出GAMMA最大值位数
            int nMaxGAMMAValueBit = (int)calcResult[7];

            //计算出128寄存器的值
            //int nReg128 = (int)calcResult[5]; //2019-03-25 禁用自动计算的128寄存器值

            //合规性检查
            bool bCheckOK = (bool)calcResult[10];

            //等式左侧
            int nLeft = (int)calcResult[8];

            //等式右侧
            int nRight = (int)calcResult[9];

            if (bCheckOK == false)
            {
                string tmp = string.Format("{0}: {1}<={2} {3}",
                   Trans("参数合规性检查"),
                   nLeft, nRight,
                   (bCheckOK ? Trans("成功") : Trans("失败")));

                WriteMessage(tmp);

                txt += " " + Trans("失败");
                WriteMessage(txt);
                return;
            }
            else
            {
                //输出额外信息
                label201.Text = string.Format("{0}:{1} {2}:{3}",
                    Trans("最大灰度级数"), nMaxGrayLevel,
               Trans("最大值位数"), nMaxGAMMAValueBit);//2019-02-20恢复

                ////2019-01-22 modify
                //label201.Text = string.Format("{0}:{1}",
                //Trans("最大灰度级数"), nMaxGrayLevel);

            }

            //放到类库中操作了 2019-03-25
            //listRegAddr.Add(128);
            //listBitLow.Add(0);
            //listBitHigh.Add(15);
            //listVals.Add((ushort)nReg128);


            //输出额外信息
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine(string.Format("Register 128 Value={0}", nReg128));
            sb.AppendLine(string.Format("Register 128 Value={0}", input2072FuncVal.Text));
            sb.AppendLine(string.Format("{0}:{1}", Trans("最大灰度级数"), nMaxGrayLevel));
            sb.AppendLine(string.Format("{0}:{1}", Trans("最大值位数"), nMaxGAMMAValueBit));//2019-01-22 modify
            sb.Append(string.Format("{0}: {1}<={2} {3}",
                Trans("参数合规性检查"),
                nLeft, nRight,
                (bCheckOK ? Trans("成功") : Trans("失败"))));

            WriteMessage(sb.ToString());

            //input2072FuncRegAddr 寄存器地址
            //cb2072FuncTest2 起始
            //cb2072FuncTest3 终止
            //input2072FuncVal 数值

            //128寄存器值 
            //2019-03-25 禁用自动计算的128寄存器值
            //input2072FuncRegAddr.Text = "128";
            //cb2072FuncTest2.SelectedIndex = 0;
            //cb2072FuncTest3.SelectedIndex = 15;
            //input2072FuncVal.Text = nReg128.ToString();


            new Thread(new ThreadStart(delegate ()
            {

                EnableControl(sender as Control, false);


                tabControl1.Enabled = false;


                //构造GAMMA数据 2019-01-22
                double fGAMMA = 2.4f;
                byte[] arrData = new byte[2048];//10bit GAMMA
                //GAMMAProcessClass optGAMMA = new GAMMAProcessClass(10, fGAMMA, nMaxGrayLevel);
                GAMMAProcessClass optGAMMA = new GAMMAProcessClass(10, fGAMMA, GetGAMMAMaxValueFromBit(nMaxGAMMAValueBit));//2019-02-20  改回使用最大值位数方式
                Array.Copy(optGAMMA.GetData, arrData, 2048);

                ushort nColorValueExt = 0;
                //if (GetSelectedPanelType().Bit == 8)
                //{
                //    //8bit GAMMA 需要特殊处理
                //    GAMMATrans10bitTo8bit(arrData);//2019-03-01 LANG项目特殊处理

                //    nColorValueExt = 3;//颜色序号附加值
                //}

                byte chip = (byte)cbRegChip.SelectedValue.ToString().ToByte();
                foreach (var item in _DevIP)
                {
                    int hDevice = item.Value;
                    string szDeviceName = item.Key;

                    bResult = Write2072RegisterMulti(hDevice, addrMB, (byte)GetId(), chip, nMode, listRegAddr, listBitLow, listBitHigh, listVals, 70);//2018-11-09发送完2072参数仅完成70%任务

                    if (bResult == false)
                    {
                        txt += " " + Trans("失败");
                        WriteMessage(txt);

                        //tabControl1.Enabled = true;
                        //CloseCommunication();
                        //return;
                        continue;
                    }

                    ////输出额外信息
                    //StringBuilder sb = new StringBuilder();
                    //sb.AppendLine(string.Format("Register 128 Value={0}", nReg128));
                    //sb.AppendLine(string.Format("{0}:{1}", Trans("最大灰度级数"), nMaxGrayLevel));
                    //sb.AppendLine(string.Format("{0}:{1}", Trans("最大值位数"), nMaxGAMMAValueBit));
                    //sb.Append(string.Format("{0}: {1}<={2} {3}",
                    //    Trans("参数合规性检查"),
                    //    nLeft, nRight,
                    //    (bCheckOK ? Trans("成功") : Trans("失败"))));

                    //WriteOutputWithoutTime(sb.ToString());

                    //-----------------发送GAMMA数据 默认为2.4---------------

                    //byte color = 0;//全部颜色

                    string szGAMMA = Trans("发送Gamma");
                    WriteStatusMessage(szGAMMA);
                    WriteMessage(szGAMMA);
                    SetPrograss(szGAMMA, "", 70);


                    //2019-01-22 modify
                    //byte nResult = twsOper.tws_WriteGAMMA2072(hDevice, addrMB, color, (byte)nMaxGAMMAValueBit, 2.4f);


                    //写入全部颜色GAMMA
                    bool bWriteGAMMA = true;//写入GAMMA
                    int nResult = 0;

                    //红色GAMMA
                    //nResult += _TLWCommand.tlw_WriteGAMMA(hDevice, addrMB, bWriteGAMMA, (ushort)(0 + nColorValueExt), (byte)nMode, arrData, 0, 2048);
                    nResult += _TLWCommand.tlw_WriteGAMMA(item.Value, addrMB, GetId(), 0, (byte)(0 + nColorValueExt), arrData);

                    //绿色GAMMA
                    nResult += _TLWCommand.tlw_WriteGAMMA(item.Value, addrMB, GetId(), 0, (byte)(0 + nColorValueExt), arrData);

                    //蓝色GAMMA
                    nResult += _TLWCommand.tlw_WriteGAMMA(item.Value, addrMB, GetId(), 0, (byte)(0 + nColorValueExt), arrData);

                    if (nResult == 0)
                    {
                        txt += " " + Trans("成功");
                        SetPrograss("", "", 100);
                    }
                    else
                    {
                        txt += " " + Trans("失败");
                    }

                    //WriteStatusMessage(txt);
                    WriteMessage(txt);
                }

                //关闭设备
                EnableControl(sender as Control, true);
                tabControl1.Enabled = true;

            })).Start();

        }

        private void btnRead2072_Click(object sender, EventArgs e)
        {
            if (CheckIsBusy()) return;
            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }

            byte chipPos = (byte)cbRegChip.SelectedValue.ToString().ToByte();
            bool bSave = !ckDebugMode.Checked;
            int color = (int)cbParam2055Color.SelectedValue;
            List<RegisterItem> regList = grid2055.DataSource as List<RegisterItem>;
            List<RegisterOtherItem> regOtherList = gridOtherReg.DataSource as List<RegisterOtherItem>;
            EnableControl(sender as Control, false);
            _TLWCommand.tlw_ReadRegisterGroup(GetMBAddr(), GetId(), chipPos, 1024, _DevIP, (param) =>
            {
                Array.ForEach(param, t =>
                {
                    WriteOutput(t, "批量读取寄存器");
                    if (t.ResultCode == 0)
                    {
                        WriteTextFile(@"d:\tmp\register_reader.txt", (t.Data as byte[]).ToString(" "));
                        byte[] data = t.Data as byte[];
                        byte[] tmp = new byte[2];
                        tmp[0] = data[510];
                        tmp[1] = data[511];
                        UInt32 val = tmp.GetUInt16();
                        string str = val.ToString("X4");
                        MessageBox.Show(str);
                        Invoke(new MethodInvoker(() =>
                        {

                        }));

                    }
                    EnableControl(sender as Control, true);
                });
            });
        }

        private void btn2072_all_Click(object sender, EventArgs e)
        {
            ////设置2072寄存器

            //ushort addrMB = GetMBAddr();

            //int row, col;
            //UnitTypeV2 obj = GetSelectedPanelType();//从框架获取箱体类型                        

            ////从框架获取模块地址
            //Point pt = GetModuleAddr();

            //row = pt.Y;//行号
            //col = pt.X;//列号

            //if ((row > obj.ModuleHeight) || (col > obj.ModuleWidth))
            //{
            //    MessageBox.Show(Trans("模块地址错误"), Trans("错误"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //if ((row == 0) && (col != 0))
            //{
            //    MessageBox.Show(Trans("模块地址错误"), Trans("错误"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //else if ((row != 0) && (col == 0))
            //{
            //    MessageBox.Show(Trans("模块地址错误"), Trans("错误"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //ushort addrModule = TWSTools.GetModuleAddress(obj.SubName, row, col);

            //new Thread(new ThreadStart(delegate ()//2018-11-15改成线程方式
            //{
            //    OperationResult optResult = null;
            //    if (!(optResult = OpenCommunication()).Status)
            //    {
            //        WriteStatusMessage(optResult.Message);
            //        WriteOutputWithTime(optResult.Message);
            //        return;
            //    }

            //    int result = 0;
            //    string info = "";

            //    tabControl1.Enabled = false;

            //    foreach (DictionaryEntry item in m_hDevice)
            //    {
            //        int hDevice = item.Value.ToString().ToInt32();
            //        string szDeviceName = GetDeviceName(hDevice);

            //        int nIndex = int.Parse((sender as Button).Tag.ToString());
            //        nIndex--;

            //        info = "[" + szDeviceName + "]:" + (sender as Button).Text;

            //        if (nIndex == 17)
            //        {
            //            //发送所有
            //            UInt16[] arrRegAddr = new UInt16[34];
            //            UInt16[] arrRegVal = new UInt16[34];

            //            StringBuilder sb = new StringBuilder();
            //            for (int i = 0; i < 17; i++)
            //            {
            //                UInt32 data = Get2072Data(i);

            //                //寄存器地址 高16bit 
            //                arrRegAddr[2 * i] = m_arrRegAddr[2 * i];

            //                //寄存器地址 低16bit
            //                arrRegAddr[2 * i + 1] = m_arrRegAddr[2 * i + 1];

            //                //数值 高16bit
            //                arrRegVal[2 * i] = (UInt16)((data >> 16) & 0xFFFF);

            //                //数值 低16bit
            //                arrRegVal[2 * i + 1] = (UInt16)(data & 0xFFFF);

            //                sb.Append(string.Format("Set Offset {0} val=0x{1:X8} \r\n", m_arrTitle[i], data));

            //            }

            //            int result4 = twsOper.tws_Module_BatchWriteRegister2(hDevice, addrMB, addrModule, arrRegAddr, arrRegVal, 34);
            //            int result5 = twsOper.tws_Module_WriteRegister(hDevice, addrMB, addrModule, 0x84, 1, true);

            //            if ((result4 == 0) && (result5 == 0))
            //            {
            //                info = info + " " + Trans("成功") + "!";
            //            }
            //            else
            //                info = info + " " + Trans("失败") + "!";

            //            WriteStatusMessage(info);
            //            WriteOutputWithTime(info);

            //            if (result == 0)
            //            {
            //                WriteOutputWithoutTime(sb.ToString());
            //            }

            //            //发送2019寄存器的值 2018-09-10
            //            //OnSet2019Register(btnSet2019All, null);

            //            //发送2019寄存器的值2018-11-16
            //            OnSet2019RegisterAll_NoSave(hDevice, addrMB, addrModule);

            //        }
            //        else
            //        {   //发送当前行
            //            UInt32 data = Get2072Data(nIndex);

            //            //高16bit 
            //            UInt16 regAddrHi = m_arrRegAddr[2 * nIndex];
            //            //低16bit
            //            UInt16 regAddrLo = m_arrRegAddr[2 * nIndex + 1];

            //            UInt16[] valHi = { (UInt16)((data >> 16) & 0xFFFF) };
            //            UInt16[] valLo = { (UInt16)(data & 0xFFFF) };

            //            int result1 = twsOper.tws_Module_ReadWriteRegister(hDevice, addrMB, addrModule, true, regAddrHi, valHi, true);//寄存器地址16bit,值也是16bit
            //            int result2 = twsOper.tws_Module_ReadWriteRegister(hDevice, addrMB, addrModule, true, regAddrLo, valLo, true);

            //            int result3 = twsOper.tws_Module_WriteRegister(hDevice, addrMB, addrModule, 0x84, 1, true);//寄存器地址8bit,值是16bit
            //            if ((result1 == 0) && (result2 == 0) && (result3 == 0))
            //            {
            //                info = info + " " + string.Format("val=0x{0:X8} ", data) + Trans("成功") + "!";
            //            }
            //            else
            //                info = info + " " + Trans("失败") + "!";
            //            WriteStatusMessage(info);
            //            WriteOutputWithTime(info);
            //        }
            //    }

            //    tabControl1.Enabled = true;
            //    CloseCommunication();
            //})).Start();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            #region 测试代码

            if (CheckIsBusy()) return;
            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }

            byte chipPos = (byte)cbRegChip.SelectedValue.ToString().ToByte();
            bool bSave = !ckDebugMode.Checked;
            int color = (int)cbParam2055Color.SelectedValue;
            List<RegisterItem> regList = grid2055.DataSource as List<RegisterItem>;
            List<RegisterOtherItem> regOtherList = gridOtherReg.DataSource as List<RegisterOtherItem>;
            byte[] data = new byte[1024].Fill(0xff);
            ushort[] arrDefualt = {
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0001,0x0001,0x0001,0x0001,0x0000,0x0000,0x0000, //0 
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //1
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //2
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //3
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //4
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0xB6B6, //5
                    0xB6C0,0x0000,0x0306,0x0004,0x0200,0xF000,0x16E0,0x7F00,0x6F00,0x6B00,0x8100,0x0000,0x0000,0x0000,0x0000,0x101B, //6
                    0x0000,0x0000,0x0802,0x0606,0x4111,0x4FFF,0x1FE0,0xE03D,0x0057,0x0050,0x0059,0x0010,0x0000,0x0000,0x0000,0x0000, //7
                    0x00FA,0x0000,0x0000,0x0000,0x0001,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //8
                    0x0000,0x0000,0x7FFF,0x7FFF,0x7FFF,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //9
                    0x0020,0x000F,0x0030,0x000A,0xFFFF,0x3FFF,0x3FFF,0x3FFF,0xFFFF,0x3FFF,0x3FFF,0x03FF,0xFFFF,0xFFFF,0xFFFF,0xFFFF, //a
                    0xFFFF,0xFFFF,0xFFFF,0xFFFF,0xFFFF,0xFFFF,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //b
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //c
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //d
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //e 
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000}; //f

            string txt = rt2072.Text;
            txt = txt.Replace("\n", "");
            txt = txt.Replace(",", " ").Replace("0x", "");
            string[] tmp1 = txt.Split(' ');
            byte[] tmp2 = new byte[tmp1.Length * 2];
            for (int i = 0; i < tmp1.Length; i++)
            {
                byte[] tmp3 = tmp1[i].ToUInt16().GetBytes();
                Array.Copy(tmp3, 0, data, i * 2, 2);
            }

            //byte[] bytesData = arrDefualt.ToBytes();
            //Array.Copy(bytesData, 0, data, 0, bytesData.Length);
            //WriteTextFile(@"d:\tmp\register_Write.txt", data.ToString(" "));
            WriteTextFile(@"d:\tmp\write2072Param1.txt", data.ToString(" "));
            byte[] tmp = new byte[510];
            Array.Copy(data, 0, tmp, 0, 510);
            ushort sum = tmp.Sum();
            MessageBox.Show($"校验和:{sum.ToString("X4")}");
            EnableControl(sender as Control, false);
            _TLWCommand.tlw_WriteRegisterGroup(GetMBAddr(), GetId(), chipPos, data, bSave, _DevIP, (param) =>
            {
                Array.ForEach(param, t => WriteOutput(t, "批量写入寄存器"));
                EnableControl(sender as Control, true);
            });

            #endregion
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (CheckIsBusy()) return;
            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }

            byte chipPos = (byte)cbRegChip.SelectedValue.ToString().ToByte();
            bool bSave = !ckDebugMode.Checked;
            int color = (int)cbParam2055Color.SelectedValue;
            List<RegisterItem> regList = grid2055.DataSource as List<RegisterItem>;
            List<RegisterOtherItem> regOtherList = gridOtherReg.DataSource as List<RegisterOtherItem>;
            EnableControl(sender as Control, false);
            _TLWCommand.tlw_ReadRegisterGroup(GetMBAddr(), GetId(), chipPos, 1024, _DevIP, (param) =>
            {
                Array.ForEach(param, t =>
                {
                    WriteOutput(t, "批量读取寄存器");
                    if (t.ResultCode == 0)
                    {
                        WriteTextFile(@"d:\tmp\register_reader.txt", (t.Data as byte[]).ToString(" "));
                        byte[] data = t.Data as byte[];
                        byte[] tmp = new byte[2];
                        tmp[0] = data[510];
                        tmp[1] = data[511];
                        UInt32 val = tmp.GetUInt16();
                        string str = val.ToString("X4");
                        MessageBox.Show(str);
                        Invoke(new MethodInvoker(() =>
                        {

                        }));

                    }
                    EnableControl(sender as Control, true);
                });
            });
        }

        private void OnSet2019RegisterAll_NoSave(int hDevice, ushort addrMB, byte chip)
        {
            //设置2019寄存器 4个寄存器都设置  2018-11-16

            //寄存器地址
            byte[] arrRegAddr = { 160, 161, 162, 163 };

            //寄存器值
            ushort[] arrInputValue = { (ushort)input2019_160.Value,
                                         (ushort)input2019_161.Value,
                                         (ushort)input2019_162.Value,
                                         (ushort)input2019_163.Value };

            int result = 0;

            string info = "";

            StringBuilder sb = new StringBuilder();
            sb.Append("Set 2019 Register \r\n");

            //发送所有                     
            for (int i = 0; i < 4; i++)
            {
                info = string.Format("addr={0} val={1} \r\n", arrRegAddr[i], arrInputValue[i]);
                //result = twsOper.tws_Module_WriteRegister(hDevice, addrMB, addrModule, arrRegAddr[i], arrInputValue[i], true);
                result = _TLWCommand.tlw_WriteRegister(hDevice, GetMBAddr(), GetId(), chip, arrRegAddr[i], arrInputValue[i], true);
                if (result == 0)
                {
                    info += " " + Trans("成功") + "!";
                }
                else
                    info += " " + Trans("失败") + "!";

                sb.Append(info + "\r\n");
            }

            WriteMessage(sb.ToString());
        }

        private void btn2072_1_Click(object sender, EventArgs e)
        {
            //设置2072寄存器
            if (CheckIsBusy()) return;
            if (!CheckDeviceAddr())
            {
                MessageBox.Show(this, "设备地址错误");
                return;
            }

            ushort addrMB = GetMBAddr();

            ////////////////////////////////////////////////////////////////////////////////////////////////////////
            EnableControl(sender as Control, false);
            byte chipPos = (byte)cbRegChip.SelectedValue.ToString().ToByte();
            //uint addr = (uint)numSingleRegAddr.Value;

            int nIndex = int.Parse((sender as Button).Tag.ToString());
            nIndex--;

            if (nIndex == 17)
            {
                //发送所有
                UInt16[] arrRegAddr = new UInt16[34];
                UInt16[] arrRegVal = new UInt16[34];

                StringBuilder sb = new StringBuilder();

                InvokeAsync(() =>
                {
                    EnableControl(sender as Control, false);
                    foreach (var item in _DevIP)
                    {
                        byte[] defaultData = Register2072Helper.Data.Clone() as byte[];
                        for (int i = 0; i < 17; i++)
                        {
                            UInt32 data = Get2072Data(i);

                            //寄存器地址 高16bit 
                            arrRegAddr[2 * i] = m_arrRegAddr[2 * i];

                            //寄存器地址 低16bit
                            arrRegAddr[2 * i + 1] = m_arrRegAddr[2 * i + 1];

                            //数值 高16bit
                            arrRegVal[2 * i] = (UInt16)((data >> 16) & 0xFFFF);

                            //数值 低16bit
                            arrRegVal[2 * i + 1] = (UInt16)(data & 0xFFFF);

                            sb.Append(string.Format("Set Offset {0} val=0x{1:X8} \r\n", m_arrTitle[i], data));

                            byte[] tmpAddrH = arrRegAddr[2 * i].GetBytes();
                            byte[] tmpValH = arrRegVal[2 * i].GetBytes();
                            byte[] tmpAddrL = arrRegAddr[2 * i + 1].GetBytes();
                            byte[] tmpValL = arrRegVal[2 * i + 1].GetBytes();

                            defaultData[tmpAddrH[0]] = tmpValH[0];
                            defaultData[tmpAddrH[1]] = tmpValH[1];

                            defaultData[tmpAddrL[0]] = tmpValL[0];
                            defaultData[tmpAddrL[1]] = tmpValL[1];
                        }
                        //int result = _TLWCommand.tlw_WriteRegister(item.Value, GetMBAddr(), GetId(), chipPos, arrRegAddr[i], arrRegVal[i], true);
                        //WriteTextFile(@"d:\tmp\write2072Param.txt", defaultData.ToString(" "));
                        //CalibrationHelper.Write(defaultData, @"d:\tmp\write2072Param.zdat");
                        //EnableControl(sender as Control, true);
                        //return;
                        int result = _TLWCommand.tlw_WriteRegisterGroup(item.Value, GetMBAddr(), GetId(), chipPos, defaultData, false);
                        if (result == 0)
                        {

                        }
                        else
                        {
                            WriteMessage("批量写入寄存器失败");
                            EnableControl(sender as Control, true);
                            return;
                        }
                        result = _TLWCommand.tlw_WriteRegister(item.Value, GetMBAddr(), GetId(), chipPos, 0x84, 1, false);
                        if (result == 0)
                        {

                        }
                        else
                        {
                            WriteMessage("批量写入寄存器失败");
                            EnableControl(sender as Control, true);
                            return;
                        }

                        OnSet2019RegisterAll_NoSave(item.Value, addrMB, chipPos);

                        WriteMessage("批量写入寄存器成功");
                        EnableControl(sender as Control, true);
                    }
                });
            }
            else
            {   //发送当前行
                UInt32 data = Get2072Data(nIndex);

                //高16bit 
                UInt16 regAddrHi = m_arrRegAddr[2 * nIndex];
                //低16bit
                UInt16 regAddrLo = m_arrRegAddr[2 * nIndex + 1];

                UInt16[] valHi = { (UInt16)((data >> 16) & 0xFFFF) };
                UInt16[] valLo = { (UInt16)(data & 0xFFFF) };

                string info = "";
                foreach (var item in _DevIP)
                {
                    int result1 = _TLWCommand.tlw_WriteRegister(item.Value, GetMBAddr(), GetId(), chipPos, regAddrHi, valHi[0], false);
                    int result2 = _TLWCommand.tlw_WriteRegister(item.Value, GetMBAddr(), GetId(), chipPos, regAddrLo, valLo[0], false);
                    int result3 = _TLWCommand.tlw_WriteRegister(item.Value, GetMBAddr(), GetId(), chipPos, 0x84, 1, false);//寄存器地址8bit,值是16bit
                    if ((result1 == 0) && (result2 == 0) && (result3 == 0))
                    {
                        info = info + " " + string.Format("val=0x{0:X8} ", data) + Trans("成功") + "!";
                    }
                    else
                        info = info + " " + Trans("失败") + "!";
                }
                WriteMessage(info);
                EnableControl(sender as Control, true);

            }
        }

        private void btn2072_import_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "ICN2072(*.txt)|*.txt";
            if (dlg.ShowDialog(this) == DialogResult.Cancel) return;
            string path = dlg.FileName;
            string info = btn2072_import.Text + " " + "\r\n" + path;


            const int nMaxLine = 18;//2018-09-10

            StringBuilder sb = new StringBuilder();
            try
            {
                using (TextReader reader = new StreamReader(path))
                {
                    string line = null;

                    int i = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line == "") continue;//2019-03-26 空行判断放在最前面

                        //if (i > 17)
                        if (i > nMaxLine - 1)//增加一行表示160，161,162,163这三个寄存器值
                        {
                            //行数错误
                            //string tmp = Trans("文件打开失败!");
                            //MessageBox.Show(tmp);
                            //WriteOutputWithTime(tmp);

                            //超出的行数不读取
                            WriteMessage(btn2072_import.Text + " " + "\r\n" + path + " " + Trans("成功") + "!");
                            return;
                        }

                        string[] arr = line.Split('\t');

                        if (i == nMaxLine - 1)//最后一行
                        {
                            //2019寄存器的参数

                            if (arr.Length != 5) continue; //信息错误

                            input2019_160.Value = int.Parse(arr[1]);
                            input2019_161.Value = int.Parse(arr[2]);
                            input2019_162.Value = int.Parse(arr[3]);
                            input2019_163.Value = int.Parse(arr[4]);
                        }
                        else
                        {
                            //2072的参数

                            Control[] ctrls = m_arrControl[i];
                            int nColum = ctrls.Length;

                            if (arr.Length != nColum + 1) continue;

                            //赋值
                            for (int col = 0; col < nColum; col++)
                            {
                                UInt32 tmp = UInt32.Parse(arr[col + 1]);
                                string szType = ctrls[col].GetType().ToString();
                                if (szType == "System.Windows.Forms.ComboBox")
                                {
                                    ComboBox cb = (ComboBox)(ctrls[col]);
                                    cb.SelectedIndex = (int)tmp;
                                }
                                else if (szType == "System.Windows.Forms.NumericUpDown")
                                {
                                    NumericUpDown input = (NumericUpDown)(ctrls[col]);
                                    input.Value = tmp;
                                }
                            }
                        }

                        i++;//计数
                    }
                }
            }
            catch
            {
                string txt1 = "";
                txt1 = Trans("文件打开失败!");
                MessageBox.Show(txt1);
                WriteMessage(txt1);
                return;
            }

            WriteMessage(btn2072_import.Text + " " + "\r\n" + path + " " + Trans("成功") + "!");
        }

        private void btn2072_export_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "ICN2072(*.txt)|*.txt";

            if (dlg.ShowDialog(this) == DialogResult.Cancel) return;

            string path = dlg.FileName;

            string szExt = System.IO.Path.GetExtension(path).ToLower();

            string info = "";

            info = btn2072_export.Text + " " + "\r\n" + path;

            if (MessageBox.Show(info, Trans("注意"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            //输出文本文件
            System.IO.StreamWriter sw = new System.IO.StreamWriter(path, false);

            int nColum = 0;

            StringBuilder sb = new StringBuilder();

            string szLine = "";
            for (int i = 0; i < 17; i++)
            {
                UInt32 data = Get2072Data(i);

                szLine = string.Format("OFFSET={0} val=0x{1:X8} \t", m_arrTitle[i], data);////行首

                Control[] ctrls = m_arrControl[i];
                nColum = ctrls.Length;

                for (int col = 0; col < nColum; col++)
                {
                    UInt32 tmp = 0;
                    string szType = ctrls[col].GetType().ToString();
                    if (szType == "System.Windows.Forms.ComboBox")
                    {
                        ComboBox cb = (ComboBox)(ctrls[col]);
                        tmp = (UInt32)cb.SelectedIndex;
                    }
                    else if (szType == "System.Windows.Forms.NumericUpDown")
                    {
                        NumericUpDown input = (NumericUpDown)(ctrls[col]);
                        tmp = (UInt32)input.Value;
                    }

                    if (col != nColum - 1)
                        szLine += tmp.ToString() + "\t";
                    else
                        szLine += tmp.ToString();

                }
                sb.AppendLine(szLine + "\r\n");
            }

            //新增一个2019寄存器值得输出
            string sz2019 = string.Format("2019 Register:\t{0}\t{1}\t{2}\t{3}\r\n", input2019_160.Value, input2019_161.Value, input2019_162.Value, input2019_163.Value);
            sb.AppendLine(sz2019);


            try
            {
                sw.Write(sb.ToString());
                WriteMessage(btn2072_export.Text + " " + "\r\n" + path);
            }
            catch
            {
                return;
            }
            finally
            {
                sw.Close();
            }
        }

        private void btn2072_saveValueList_Click(object sender, EventArgs e)
        {
            //保存成 寄存器值 数值列表 都是十进制

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Register Value List(*.txt)|*.txt";

            if (dlg.ShowDialog(this) == DialogResult.Cancel) return;

            string path = dlg.FileName;

            string szExt = System.IO.Path.GetExtension(path).ToLower();

            string info = "";

            info = btn2072_saveValueList.Text + " " + "\r\n" + path;

            if (MessageBox.Show(info, Trans("注意"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            //输出文本文件
            System.IO.StreamWriter sw = new System.IO.StreamWriter(path, false);

            StringBuilder sb = new StringBuilder();

            string szLine = "";
            for (int i = 0; i < 17; i++)
            {

                UInt32 data = Get2072Data(i);
                ushort data_high = (ushort)((data >> 16) & 0xFFFF);
                ushort data_low = (ushort)(data & 0xFFFF);

                szLine = string.Format("{0}\t{1}", m_arrRegAddr[2 * i], data_high);//高16bit
                sb.AppendLine(szLine);

                szLine = string.Format("{0}\t{1}", m_arrRegAddr[2 * i + 1], data_low);//低16bit
                sb.AppendLine(szLine);
            }

            //2018-09-10 添加2019寄存器的参数
            szLine = string.Format("{0}\t{1}", 160, input2019_160.Value);
            sb.AppendLine(szLine);

            szLine = string.Format("{0}\t{1}", 161, input2019_161.Value);
            sb.AppendLine(szLine);

            szLine = string.Format("{0}\t{1}", 162, input2019_162.Value);
            sb.AppendLine(szLine);

            szLine = string.Format("{0}\t{1}", 163, input2019_163.Value);
            sb.AppendLine(szLine);

            try
            {
                sw.Write(sb.ToString());
                WriteMessage(btn2072_saveValueList.Text + " " + "\r\n" + path);
            }
            catch
            {
                return;
            }
            finally
            {
                sw.Close();
            }
        }

        private void btnSet2019All_Click(object sender, EventArgs e)
        {
            //2019芯片涉及的几个寄存器设置

            Button btn = (Button)sender;

            int nIndex = int.Parse(btn.Tag.ToString());


            //寄存器地址
            byte[] arrRegAddr = { 160, 161, 162, 163 };

            //寄存器值
            ushort[] arrInputValue = { (ushort)input2019_160.Value,
                                         (ushort)input2019_161.Value,
                                         (ushort)input2019_162.Value,
                                         (ushort)input2019_163.Value };

            ushort addrMB = GetMBAddr();

            new Thread(new ThreadStart(delegate ()//2018-11-15改成线程方式
            {
                tabControl1.Enabled = false;
                EnableControl(sender as Control, false);
                byte chipPos = (byte)cbRegChip.SelectedValue.ToString().ToByte();
                foreach (var item in _DevIP)
                {
                    int hDevice = item.Value;
                    string szDeviceName = item.Key;

                    int result = 0;

                    string info = "";

                    StringBuilder sb = new StringBuilder();
                    sb.Append("[" + szDeviceName + "]:" + "Set 2019 Register \r\n");

                    if (nIndex == 4)
                    {
                        //发送所有                     
                        for (int i = 0; i < 4; i++)
                        {
                            info = string.Format("addr={0} val={1} \r\n", arrRegAddr[i], arrInputValue[i]);
                            result = _TLWCommand.tlw_WriteRegister(item.Value, GetMBAddr(), GetId(), chipPos, arrRegAddr[i], arrInputValue[i], false);
                            if (result == 0)
                            {
                                info += " " + Trans("成功") + "!";
                            }
                            else
                                info += " " + Trans("失败") + "!";

                            sb.Append(info + "\r\n");
                        }
                    }
                    else
                    {   //发送当前寄存器

                        info = string.Format("addr={0} val={1} \r\n", arrRegAddr[nIndex], arrInputValue[nIndex]);
                        //result = twsOper.tws_Module_WriteRegister(hDevice, addrMB, addrModule, arrRegAddr[nIndex], arrInputValue[nIndex], true);
                        result = _TLWCommand.tlw_WriteRegister(item.Value, GetMBAddr(), GetId(), chipPos, arrRegAddr[nIndex], arrInputValue[nIndex], false);
                        if (result == 0)
                        {
                            info += " " + Trans("成功") + "!";

                        }
                        else
                            info += " " + Trans("失败") + "!";

                        sb.Append(info + "\r\n");
                    }

                    //WriteStatusMessage(info);
                    WriteMessage(sb.ToString());
                }

                tabControl1.Enabled = true;
                EnableControl(sender as Control, true);
            })).Start();
        }

        private void btn2072Simple7_Click(object sender, EventArgs e)
        {
            if (m_2072SimpleParam.Is2072Ready(m_n2072SimpleIndex))
            {
                //界面数据保存到内存
                m_2072SimpleParam.UpdateData(m_n2072FactoryIndex);

                classCtrlBindData obj = m_2072SimpleParam.FindCtrlAndData((sender as Control).Tag.ToString());
                if (obj != null)
                {

                    ushort addrMB = GetMBAddr();

                    tabControl1.Enabled = false;
                    EnableControl(sender as Control, false);
                    byte chipPos = (byte)cbRegChip.SelectedValue.ToString().ToByte();

                    string info = "";

                    int nMode = m_n2072SimpleIndex;

                    foreach (var dev in _DevIP)
                    {
                        int hDevice = dev.Value;
                        string szDeviceName = dev.Key;

                        int result = 0;
                        foreach (classPartOfReg item in obj.m_listPart)
                        {
                            info = "[" + szDeviceName + "]:";

                            //数值
                            ushort val = (ushort)m_2072SimpleParam.GetPartOfUInt32(nMode, item.nRegAddr, item.nBitLow, item.nBitHigh);

                            classPartOfReg newItem = m_2072SimpleParam.TransformAddr(item);

                            info += string.Format("{0} 2200 {1}:0x{2:X} {3}:{4} {5}:{6}\r\n",
                                cb2072Simple5060Hz.Text,
                                Trans("寄存器地址"), item.nRegAddr,
                                Trans("起始位"), item.nBitLow,
                                Trans("终止位"), item.nBitHigh);

                            info += string.Format("FPGA {0}:0x{1:X} {2}:{3} {4}:{5} Value:{6}",
                                Trans("寄存器地址"), newItem.nRegAddr,
                                Trans("起始位"), newItem.nBitLow,
                                Trans("终止位"), newItem.nBitHigh,
                                val);

                            //result = twsOper.tws_Write2072Register(hDevice, addrMB, (byte)nMode, newItem.nRegAddr, newItem.nBitLow, newItem.nBitHigh, val);
                            result = _TLWCommand.tlw_WriteRegister(dev.Value, GetMBAddr(), GetId(), chipPos, newItem.nRegAddr, val, true);
                            if (result == 0)
                            {
                                info += " " + Trans("成功") + "!";
                            }
                            else
                            {
                                info += " " + Trans("失败") + "!";
                            }

                            WriteMessage(info);
                        }

                    }
                    EnableControl(sender as Control, true);
                    tabControl1.Enabled = true;
                }
            }
        }

        private void btn2072Simple2_TryCalc_Click(object sender, EventArgs e)
        {
            if (m_2072SimpleParam.Is2072Ready(m_n2072SimpleIndex))
            {
                //保存界面参数
                m_2072SimpleParam.UpdateData(m_n2072SimpleIndex);
                //保存2019参数
                m_2072SimpleParam.UpdateData2019(m_n2072SimpleIndex);

                UnitTypeV2 obj = GetSelectedPanelType();
                ArrayList calcResult = m_2072SimpleParam.RunCalc(m_n2072SimpleIndex, obj.SubName);

                if (calcResult != null)
                {
                    //计算出最大灰度级数
                    int nMaxGrayLevel = (int)calcResult[6];

                    //计算出GAMMA最大值位数
                    int nMaxGAMMAValueBit = (int)calcResult[7];

                    //计算出128寄存器的值
                    int nReg128 = (int)calcResult[5];

                    //合规性检查
                    bool bCheckOK = (bool)calcResult[10];

                    //等式左侧
                    int nLeft = (int)calcResult[8];

                    //等式右侧
                    int nRight = (int)calcResult[9];

                    string txt = "";
                    if (bCheckOK == false)
                    {
                        string tmp = string.Format("{0}: {1}<={2} {3}",
                           Trans("参数合规性检查"),
                           nLeft, nRight,
                           (bCheckOK ? Trans("成功") : Trans("失败")));

                        WriteMessage(tmp);

                        txt += " " + Trans("失败");
                        WriteMessage(txt);
                        return;
                    }
                    else
                    {
                        //输出额外信息
                        label201.Text = string.Format("{0}:{1} {2}:{3}", Trans("最大灰度级数"), nMaxGrayLevel, Trans("最大值位数"), nMaxGAMMAValueBit);//2019-02-20恢复
                                                                                                                                            //label201.Text = string.Format("{0}:{1}", Trans("最大灰度级数"), nMaxGrayLevel);//2019-01-22 修改


                        //输出到特殊寄存器设置

                        //2019-03-25 禁用128寄存器值算法,仅输出到output供参考，不影响界面
                        //input2072FuncRegAddr.Text = "128";
                        //input2072FuncVal.Text = nReg128.ToString();

                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine(string.Format("Reference  Register 128 Value={0}", nReg128)); //2019-03-25 禁用128寄存器值算法
                        sb.AppendLine(string.Format("{0}:{1}", Trans("最大灰度级数"), nMaxGrayLevel));
                        sb.AppendLine(string.Format("{0}:{1}", Trans("最大值位数"), nMaxGAMMAValueBit));//2019-02-20恢复
                        sb.AppendLine(string.Format("{0}: {1}<={2} {3}",
                            Trans("参数合规性检查"),
                            nLeft, nRight,
                            (bCheckOK ? Trans("成功") : Trans("失败"))));

                        //WriteOutputWithoutTime(sb.ToString());
                        MessageBox.Show(sb.ToString(), btn2072Simple2_TryCalc.Text, MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void btnSimple2072CreateGAMMAFile_Click(object sender, EventArgs e)
        {
            string info = gpSimple2072GAMMA.Text + " " + btnSimple2072CreateGAMMAFile.Text;

            float fGAMMA = 0;
            try
            {
                fGAMMA = float.Parse(tbSimple2072GAMMAVal.Text);
            }
            catch
            {
                MessageBox.Show("GAMMA" + Trans("输入值有误") + "!", Trans("错误"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((fGAMMA < 0) || (fGAMMA > MAX_Gamma))
            {
                MessageBox.Show("GAMMA" + Trans("输入值有误") + "!", Trans("错误"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                fGAMMA = 2.4f;
                tbSimple2072GAMMAVal.Text = fGAMMA.ToString();
                return;
            }
            info += string.Format(" GAMMA={0}", fGAMMA.ToString());

            //计算GAMMA最大值位数
            //int nMaxBitLen = 0;//(byte)CalcGAMMABit();
            int nMaxGrayLevel = 0;//2019-01-22
            int nMaxBitLen = 0;

            if (m_2072SimpleParam.Is2072Ready(m_n2072SimpleIndex))
            {
                UnitTypeV2 obj = GetSelectedPanelType();
                ArrayList calcResult = m_2072SimpleParam.RunCalc(m_n2072SimpleIndex, obj.SubName);

                if (calcResult == null)
                {
                    info += Trans("失败") + "!";
                    WriteMessage(info);
                    return;
                }
                //计算出最大灰度级数
                nMaxGrayLevel = (int)calcResult[6];

                //计算出GAMMA最大值位数
                nMaxBitLen = (int)calcResult[7];

                //计算出128寄存器的值
                int nReg128 = (int)calcResult[5];

                //合规性检查
                bool bCheckOK = (bool)calcResult[10];

                //等式左侧
                int nLeft = (int)calcResult[8];

                //等式右侧
                int nRight = (int)calcResult[9];

                if (bCheckOK == false)
                {
                    string tmp = string.Format("{0}: {1}<={2} {3}",
                       Trans("参数合规性检查"),
                       nLeft, nRight, Trans("失败"));

                    WriteMessage(tmp);

                    info += " " + Trans("失败");
                    WriteMessage(info);
                    return;
                }

                //输出额外信息
                label201.Text = string.Format("{0}:{1} {2}:{3}",
                    Trans("最大灰度级数"), nMaxGrayLevel,
                Trans("最大值位数"), nMaxBitLen);//2019-02-20 恢复

                //nMaxBitLen = nMaxGAMMAValueBit;

                //2019-01-22 modify
                //label201.Text = string.Format("{0}:{1}",
                //    Trans("最大灰度级数"), nMaxGrayLevel);

            }

            SaveFileDialog dlg = new SaveFileDialog();

            //bool bIs8bit = false;
            //if ((m_szType == "TWA0.9") || (m_szType == "TWA1.2n") || (m_szType == "TWA0.9n"))
            //string szGAMMA = Trans("GAMMA文件");
            //if (b10bit == false)
            //    dlg.Filter =  szGAMMA + "(*.gamma8)|*.gamma8|" + szGAMMA + "(*.txt8)|*.txt8";
            //else

            string szGAMMA = Trans("GAMMA文件");
            dlg.Filter = szGAMMA + "(*.txt10)|*.txt10|" + szGAMMA + "(*.gamma10)|*.gamma10";

            if (dlg.ShowDialog(this) == DialogResult.Cancel) return;

            GAMMAProcessClass gp = null;//2016-10-19 创建GAMMA文件

            //if ((m_szType == "TWA0.9") || (m_szType == "TWA1.2n") || (m_szType == "TWA0.9n"))
            //if (bIs8bit)
            //{
            //    gp = new GAMMAProcessClass(8, fGAMMA, nMaxBitLen, false);
            //}
            //else
            //{//其他TWA箱体
            //    gp = new GAMMAProcessClass(10, fGAMMA, nMaxBitLen, false);
            //}

            gp = new GAMMAProcessClass(10, fGAMMA, GetGAMMAMaxValueFromBit(nMaxBitLen));//2019-01-22 add

            string file = dlg.FileName;
            string ext = System.IO.Path.GetExtension(file).ToLower();
            bool bSuccess = false;

            int nOutputMode = 0;//2019-01-28  0 二进制文件,  1 文本文件
            if ((ext == ".txt8") || (ext == ".txt10"))
            {
                nOutputMode = 1;//文本文件
            }
            else if ((ext == ".gamma8") || (ext == ".gamma10"))
            {
                nOutputMode = 0;//二进制文件
            }


            int nBit = GetSelectedPanelType().Bit;//8 = 8bit, 10=10bit

            if (nBit == 8)
            {
                byte[] arrData = new byte[2048];
                //ushort[] arrTemp = new ushort[1024];
                //Array.Copy(gp.GetGAMMAData16bit(), arrTemp, 1024);

                Array.Copy(gp.GetData, arrData, 2048);

                //对原始数据做一些处理
                GAMMATrans10bitTo8bit(arrData);

                //创建一个新的对象
                GAMMAProcessClass optNew = new GAMMAProcessClass(10, arrData, 0, 2048, false);

                bSuccess = optNew.WriteToFile(file, nOutputMode);//0 二进制文件,  1 文本文件
            }
            else
            {
                bSuccess = gp.WriteToFile(file, nOutputMode);//0 二进制文件,  1 文本文件
            }

            if (bSuccess)
            {
                WriteMessage(string.Format(Trans("创建文件:{0} 最大值位数:{1}"), file, nMaxBitLen));
            }
        }

        /// <summary>
        /// 将10bit GAMMA数据转换为8bit 数据,直接修改数据
        /// </summary>
        /// <param name="arr"></param>
        private void GAMMATrans10bitTo8bit(byte[] arrSRC)
        {
            byte[] arrData = new byte[2048];
            ushort[] arrTemp = new ushort[1024];

            for (int i = 0; i < 1024; i++)
            {
                arrTemp[i] = (ushort)((arrSRC[2 * i + 1] << 8) | arrSRC[2 * i]);
            }

            //对原始数据做一些处理
            ushort tmp = 0;
            for (int i = 0; i < 1024; i++)
            {
                if (i % 4 == 0)
                {
                    tmp = arrTemp[i + 3];
                }
                arrTemp[i] = tmp;

                arrData[2 * i + 1] = (byte)((arrTemp[i] >> 8) & 0xFF);
                arrData[2 * i] = (byte)(arrTemp[i] & 0xFF);
            }
            Array.Copy(arrData, arrSRC, 2048);
        }

        private void btn2072SimpleCalcGAMMASend_Click(object sender, EventArgs e)
        {
            ushort addrMB = GetMBAddr();

            //if (addrMB == 0)
            //{
            //    if (ShowUnitAddressDialog() != DialogResult.OK) return false;
            //    addrMB = GetUnitAddr16bit();
            //}
            //if (addrMB == 0)
            //{
            //    MessageBox.Show(Lang.GetTxt("res607", "该命令的箱体地址不能是(0,0)广播地址") + "!", Lang.GetTxt("res253", "错误"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}

            string info = gpSimple2072GAMMA.Text + " " + cb2072SimpleGAMMA.Text + " " + tbSimple2072GAMMAVal.Text + " " + btn2072SimpleCalcGAMMASend.Text;

            byte color = (byte)cb2072SimpleGAMMA.SelectedIndex;

            float val = 0;
            try
            {
                val = float.Parse(tbSimple2072GAMMAVal.Text);
            }
            catch
            {
                MessageBox.Show(Trans("输入值有误") + "!", Trans("错误"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((val < 0) || (val > MAX_Gamma))
            {
                MessageBox.Show(Trans("输入值有误") + "!", Trans("错误"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                val = 2.4f;
                tbSimple2072GAMMAVal.Text = val.ToString();//使用默认值            
                return;
            }

            class2072Oper objOper = m_2072SimpleParam;
            int nMode = m_n2072SimpleIndex;
            if (objOper.Is2072Ready(nMode) == false) return;
            //从界面获取最新参数
            objOper.UpdateData(nMode);

            UnitTypeV2 objType = GetSelectedPanelType();
            ArrayList calcResult = objOper.RunCalc(nMode, objType.SubName);
            if (calcResult == null)
            {
                info += " " + Trans("失败");
                WriteMessage(info);
                return;
            }

            //计算出最大灰度级数
            int nMaxGrayLevel = (int)calcResult[6];

            //计算出GAMMA最大值位数
            int nMaxGAMMAValueBit = (int)calcResult[7];

            //计算出128寄存器的值
            int nReg128 = (int)calcResult[5];

            //合规性检查
            bool bCheckOK = (bool)calcResult[10];

            //等式左侧
            int nLeft = (int)calcResult[8];

            //等式右侧
            int nRight = (int)calcResult[9];

            if (bCheckOK == false)
            {
                string tmp = string.Format("{0}: {1}<={2} {3}",
                   Trans("参数合规性检查"),
                   nLeft, nRight, Trans("失败"));
                WriteMessage(tmp);

                info += " " + Trans("失败");
                WriteMessage(info);
                return;
            }

            //输出额外信息
            label201.Text = string.Format("{0}:{1}\r\n{2}:{3}",
                Trans("最大灰度级数"), nMaxGrayLevel,
            Trans("最大值位数"), nMaxGAMMAValueBit);//2019-02-20恢复

            //2019-01-22
            //label201.Text = string.Format("{0}:{1}",Trans("最大灰度级数"), nMaxGrayLevel);

            //构造GAMMA数据 2019-01-22
            //double fGAMMA = 2.4f;
            double fGAMMA = val;//2019-03-04 修改问题
            byte[] arrData = new byte[2048];//10bit GAMMA

            //GAMMAProcessClass optGAMMA = new GAMMAProcessClass(10, fGAMMA, nMaxGrayLevel);
            GAMMAProcessClass optGAMMA = new GAMMAProcessClass(10, fGAMMA, GetGAMMAMaxValueFromBit(nMaxGAMMAValueBit));//2019-02-20 恢复最大值位数

            Array.Copy(optGAMMA.GetData, arrData, 2048);

            ushort nColorValueExt = 0;
            if (GetSelectedPanelType().Bit == 8)
            {
                //8bit GAMMA 需要特殊处理
                GAMMATrans10bitTo8bit(arrData);//2019-03-01 LANG项目特殊处理

                nColorValueExt = 3;//颜色序号附加值
            }

            new Thread(new ThreadStart(delegate ()//2018-11-15改成线程方式
            {
                EnableControl(sender as Control, false);
                tabControl1.Enabled = false;

                foreach (var item in _DevIP)
                {
                    int hDevice = item.Value;
                    string szDeviceName = item.Key;

                    byte result = 0;
                    //2019-03-04 取消10bit显示
                    string txt = "[" + szDeviceName + "]:" + gpSimple2072GAMMA.Text + " " +
    btn2072SimpleCalcGAMMASend.Text + string.Format("\r\n{0}:{1}\r\nGAMMA={2:f2}\r\n", Trans("颜色"), cb2072SimpleGAMMA.Text, val) +
    string.Format("\r\n{0}:{1}bit", Trans("最大值位数"), nMaxGAMMAValueBit);

                    bool bWriteGAMMA = true;//写入GAMMA
                    int nResult = 0;

                    if (color == 0)
                    {
                        //全部颜色

                        //写入全部颜色GAMMA

                        //红色GAMMA
                        //nResult += twsOper.tws_WriteReadGAMMA(hDevice, addrMB, bWriteGAMMA, (ushort)(0 + nColorValueExt), (byte)nMode, arrData, 0, 2048);

                        nResult += _TLWCommand.tlw_WriteGAMMA(item.Value, addrMB, GetId(), 0, (byte)(0 + nColorValueExt), arrData);


                        //绿色GAMMA
                        //nResult += twsOper.tws_WriteReadGAMMA(hDevice, addrMB, bWriteGAMMA, (ushort)(1 + nColorValueExt), (byte)nMode, arrData, 0, 2048);
                        nResult += _TLWCommand.tlw_WriteGAMMA(item.Value, addrMB, GetId(), 0, (byte)(1 + nColorValueExt), arrData);

                        //蓝色GAMMA
                        //nResult += twsOper.tws_WriteReadGAMMA(hDevice, addrMB, bWriteGAMMA, (ushort)(2 + nColorValueExt), (byte)nMode, arrData, 0, 2048);
                        nResult += _TLWCommand.tlw_WriteGAMMA(item.Value, addrMB, GetId(), 0, (byte)(2 + nColorValueExt), arrData);
                    }
                    else
                    {
                        //某种颜色
                        //nResult = twsOper.tws_WriteReadGAMMA(hDevice, addrMB, bWriteGAMMA, (ushort)(color - 1 + nColorValueExt), (byte)nMode, arrData, 0, 2048);
                        nResult += _TLWCommand.tlw_WriteGAMMA(item.Value, addrMB, GetId(), 0, (byte)(color - 1 + nColorValueExt), arrData);
                    }


                    if (result == 0)
                    {
                        txt += " " + Trans("成功") + "!";
                    }
                    else
                    {
                        txt += " " + Trans("失败") + "!";
                    }

                    //WriteStatusMessage(txt);
                    WriteMessage(txt);
                }
                tabControl1.Enabled = true;
                EnableControl(sender as Control, true);
            })).Start();
        }

        private void btn2072SimpleSendGAMMAFile_Click(object sender, EventArgs e)
        {
            //下载GAMMA文件

            OpenFileDialog dlg = new OpenFileDialog();
            string szGAMMA = Trans("GAMMA文件");
            //if (b10bit == false)
            //    dlg.Filter =  szGAMMA + "(*.gamma8)|*.gamma8|" + szGAMMA + "(*.txt8)|*.txt8";
            //else
            dlg.Filter = szGAMMA + "(*.txt10)|*.txt10|" + szGAMMA + "(*.gamma10)|*.gamma10";
            string szPath = "";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                szPath = dlg.FileName;
            }
            else
            {
                return;
            }

            ushort addrMB = GetMBAddr();

            //判断是否选择文件
            byte[] gamma = null;

            GAMMAProcessClass gp = null;//2016-10-19 使用GAMMA处理类


            //判断选择的文件是否是txt文本文件
            string ext = System.IO.Path.GetExtension(szPath).ToLower();
            //if (ext == ".txt8")
            //{
            //    gamma = ReadTxtGammaFile(szPath);
            //}
            //else if (ext == ".gamma8")
            //{
            //    gamma = ReadBinaryGammaFile(szPath);
            //}
            //else 
            if (ext == ".gamma10")
            {
                //gamma = ReadBinaryGamma10bitFile(szPath);//2016-3-24 add

                gp = new GAMMAProcessClass(10, szPath, 0, false);
            }
            else if (ext == ".txt10")
            {
                //gamma = ReadTxtGamma10bitFile(szPath);//2016-3-24 add

                gp = new GAMMAProcessClass(10, szPath, 1, false);
            }

            //创建GAMMA数据数组
            int nGAMMALen = gp.GetData.Length;
            gamma = new byte[nGAMMALen];
            Array.Copy(gp.GetData, gamma, nGAMMALen);//2019-01-19 数据备份


            ushort nColorValueExt = 0;
            if (GetSelectedPanelType().Bit == 8)
            {
                //8bit GAMMA 需要特殊处理
                GAMMATrans10bitTo8bit(gamma);//2019-03-01 LANG项目特殊处理

                nColorValueExt = 3;//颜色序号附加值
            }


            if (gamma == null)
            {
                MessageBox.Show(Trans("GAMMA文件错误") + "!", Trans("错误"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int result = 0;

            byte color = (byte)cb2072SimpleGAMMA.SelectedIndex;


            //List<string> arrIP = new List<string>();
            //if (IsGroupSending(arrIP) == false)
            //{

            new Thread(new ThreadStart(delegate ()//2018-11-15改成线程方式
            {
                EnableControl(sender as Control, false);
                tabControl1.Enabled = false;
                int nMode = m_n2072SimpleIndex;//2019-01-23 modify
                bool bWriteGAMMA = true;//写入GAMMA 2019-01-23 



                foreach (var item in _DevIP)
                {
                    int hDevice = item.Value;
                    string szDeviceName = item.Key;

                    //result = twsOper.tws_WriteGAMMA10bitEx(hDevice, addrMB, color, gamma, gamma.Length);

                    string txt = "[" + szDeviceName + "]:";

                    result = 0;

                    if (color == 0)
                    {

                        //写入全部颜色GAMMA

                        //红色GAMMA
                        //result += twsOper.tws_WriteReadGAMMA(hDevice, addrMB, bWriteGAMMA, (ushort)(0 + nColorValueExt), (byte)nMode, gamma, 0, 2048);
                        result += _TLWCommand.tlw_WriteGAMMA(item.Value, addrMB, GetId(), 0, (byte)(0 + nColorValueExt), gamma);

                        //绿色GAMMA
                        //result += twsOper.tws_WriteReadGAMMA(hDevice, addrMB, bWriteGAMMA, (ushort)(1 + nColorValueExt), (byte)nMode, gamma, 0, 2048);
                        result += _TLWCommand.tlw_WriteGAMMA(item.Value, addrMB, GetId(), 0, (byte)(1 + nColorValueExt), gamma);

                        //蓝色GAMMA
                        //result += twsOper.tws_WriteReadGAMMA(hDevice, addrMB, bWriteGAMMA, (ushort)(2 + nColorValueExt), (byte)nMode, gamma, 0, 2048);
                        result += _TLWCommand.tlw_WriteGAMMA(item.Value, addrMB, GetId(), 0, (byte)(2 + nColorValueExt), gamma);

                        if (result == 0)
                            txt = Trans("写入") + " GAMMA " + Trans("成功") + "!";
                        else
                            txt = Trans("写入") + " GAMMA " + Trans("失败") + "!";
                    }
                    else
                    {
                        string word = Trans("红色");
                        switch (color)
                        {
                            case 1:
                                word = Trans("红色");
                                break;
                            case 2:
                                word = Trans("绿色");
                                break;
                            case 3:
                                word = Trans("蓝色");
                                break;
                        }

                        //result = twsOper.tws_WriteReadGAMMA(hDevice, addrMB, bWriteGAMMA, (byte)(color - 1 + nColorValueExt), (byte)nMode, gamma, 0, 2048);//2019-01-22
                        result += _TLWCommand.tlw_WriteGAMMA(item.Value, addrMB, GetId(), 0, (byte)(color - 1 + nColorValueExt), gamma);
                        if (result == 0)
                            txt = Trans("写入") + " GAMMA " + word + " " + Trans("成功") + "!";
                        else
                            txt = Trans("写入") + " GAMMA " + word + " " + Trans("失败") + "!";
                    }

                    WriteStatusMessage(txt);
                    WriteMessage(txt);
                }

                tabControl1.Enabled = true;
                EnableControl(sender as Control, true);
            })).Start();
        }

        private void btn2072FuncTest_Click(object sender, EventArgs e)
        {
            ushort addrMB = GetMBAddr();

            byte nBitLow, nBitHigh;
            nBitLow = (byte)cb2072FuncTest2.SelectedIndex;
            nBitHigh = (byte)cb2072FuncTest3.SelectedIndex;

            if (nBitLow > nBitHigh)
            {
                MessageBox.Show(label152.Text + "," + label153.Text + "," + Trans("输入值有误") + "!", Trans("错误"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ushort val = 0;
            ushort regAddr = 0;
            try
            {
                regAddr = ushort.Parse(input2072FuncRegAddr.Text);
            }
            catch
            {
                MessageBox.Show(Trans("输入值有误") + "!", Trans("错误"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                input2072FuncRegAddr.Focus();
                return;
            }

            try
            {
                val = ushort.Parse(input2072FuncVal.Text);
            }
            catch
            {
                MessageBox.Show(Trans("输入值有误") + "!", Trans("错误"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                input2072FuncVal.Focus();
                return;
            }

            byte chip = (byte)cbRegChip.SelectedValue.ToString().ToByte();
            new Thread(new ThreadStart(delegate ()//2018-11-15改成线程方式
            {
                EnableControl(sender as Control, false);
                tabControl1.Enabled = false;
                foreach (var item in _DevIP)
                {
                    int hDevice = item.Value;
                    string szDeviceName = item.Key;

                    string info = "[" + szDeviceName + "]:";

                    info += string.Format("{0} {1}:0x{2:X} {3}:{4} {5}:{6} Value={7}",
                    cb2072Simple5060Hz.Text,
                    Trans("寄存器地址"), regAddr,
                    Trans("起始位"), nBitLow,
                    Trans("终止位"), nBitHigh,
                    val);

                    //byte result = twsOper.tws_Write2072Register(hDevice, addrMB, (byte)m_n2072SimpleIndex, regAddr, nBitLow, nBitHigh, val);
                    int result = _TLWCommand.tlw_WriteRegister(item.Value, GetMBAddr(), GetId(), chip, regAddr, val, true);
                    if (result == 0)
                    {
                        info = info + " " + Trans("成功") + "!";
                    }
                    else
                        info = info + " " + Trans("失败") + "!";
                    //WriteStatusMessage(info);
                    WriteMessage(info);
                }

                tabControl1.Enabled = true;
                EnableControl(sender as Control, true);
            })).Start();
        }

        private void btn2072Simple8_All_Click(object sender, EventArgs e)
        {
            btn2072Simple7_Click(btn2072Simple8_R, null);
            btn2072Simple7_Click(btn2072Simple8_G, null);
            btn2072Simple7_Click(btn2072Simple8_B, null);
        }

        private void btn2072Simple9_All_Click(object sender, EventArgs e)
        {
            btn2072Simple7_Click(btn2072Simple9_R, null);
            btn2072Simple7_Click(btn2072Simple9_G, null);
            btn2072Simple7_Click(btn2072Simple9_B, null);
        }

        private void btn2072Simple10_All_Click(object sender, EventArgs e)
        {
            btn2072Simple7_Click(btn2072Simple10_R, null);
            btn2072Simple7_Click(btn2072Simple10_G, null);
            btn2072Simple7_Click(btn2072Simple10_B, null);
        }

        private void btn2072Simple12_All_Click(object sender, EventArgs e)
        {
            btn2072Simple7_Click(btn2072Simple12_R, null);
            btn2072Simple7_Click(btn2072Simple12_G, null);
            btn2072Simple7_Click(btn2072Simple12_B, null);
        }

        private void btn2072Simple13_All_Click(object sender, EventArgs e)
        {
            btn2072Simple7_Click(btn2072Simple13_R, null);
            btn2072Simple7_Click(btn2072Simple13_G, null);
            btn2072Simple7_Click(btn2072Simple13_B, null);
        }

        private void btn2072Simple11_All_Click(object sender, EventArgs e)
        {
            btn2072Simple7_Click(btn2072Simple11_R, null);
            btn2072Simple7_Click(btn2072Simple11_G, null);
            btn2072Simple7_Click(btn2072Simple11_B, null);
        }

        private void btn2072FactoryImport_Click(object sender, EventArgs e)
        {
            //导入文件

            string ip = ShowSelectIPDialog();
            if (string.IsNullOrEmpty(ip)) return;

            if (ReadMBParamToObj(ip) == false)
            {
                MessageBox.Show(btn2072FactoryImport.Text, Trans("错误"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int nMode = m_n2072FactoryIndex;

            bool bInRightMode = true;

            switch (nMode)
            {
                case 0://60Hz
                    if (m_MBParamObj.Is3D)
                    {
                        bInRightMode = false;
                    }
                    else if (m_MBParamObj.Is60Hz == false)
                    {
                        bInRightMode = false;
                    }
                    break;
                case 1://50Hz
                    if (m_MBParamObj.Is3D)
                    {
                        bInRightMode = false;
                    }
                    else if (m_MBParamObj.Is60Hz == true)
                    {
                        bInRightMode = false;
                    }
                    break;
                case 2://3D
                    bInRightMode = m_MBParamObj.Is3D;
                    break;
            }


            string info = "";
            DialogResult dlgResult = DialogResult.OK;

            info = tabPage4.Text + " " + btn2072FactoryImport.Text + " " + cb2072Factory5060Hz.Text + " " + Trans("参数");

            dlgResult = MessageBox.Show(info, Trans("注意"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlgResult == DialogResult.No) return;

            //2018-11-07 当前主板状态与选项不一致 是否继续
            if (bInRightMode == false)
            {
                string szStatusNoRight = string.Format(Trans("箱体显示状态不是:{0} 是否继续?"), cb2072Factory5060Hz.Text);
                dlgResult = MessageBox.Show(szStatusNoRight, Trans("错误"), MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dlgResult == DialogResult.No) return;
            }

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = Trans("2072配置文件") + "(*.txt)|*.txt";
            if (dlg.ShowDialog(this) == DialogResult.Cancel) return;
            string path = dlg.FileName;

            bool bResult = m_2072FactoryParam.ImportFile(m_n2072FactoryIndex, path);

            if (!bResult)
            {
                info += " " + Trans("失败") + "!";
                MessageBox.Show(info, Trans("错误"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteMessage(info + "\r\n" + path);
            }

            bResult = m_2072FactoryParam.Is2072Ready(m_n2072FactoryIndex);
            //Hide2072FactoryCtrlsBeforeImportFile(bResult == false);

            //显示到界面
            if (bResult)
            {
                m_2072FactoryParam.UpdateData(m_n2072FactoryIndex, false);

                //2019-03-25新增128寄存器值操作
                m_2072FactoryParam.UpdateDataRegister128(m_n2072FactoryIndex, false);
            }
        }

        private void btn2072Factory_SendAll_Click(object sender, EventArgs e)
        {
            //全部发送
            string txt = "2200 " + cb2072Factory5060Hz.Text + " " + Trans("参数") + " " + btn2072Factory_SendAll.Text;

            ushort addrMB = GetMBAddr();

            //更新界面参数
            m_2072FactoryParam.UpdateData(m_n2072FactoryIndex);

            m_2072FactoryParam.UpdateDataRegister128(m_n2072FactoryIndex);//2019-03-25 增加128寄存器的操作

            List<ushort> listRegAddr = new List<ushort>();
            List<byte> listBitLow = new List<byte>();
            List<byte> listBitHigh = new List<byte>();
            List<ushort> listVals = new List<ushort>();


            //发送17个2200寄存器值            

            //发送2019的值
            bool bWith2019 = true;

            bool bResult = m_2072FactoryParam.GetMultiRegAndValues(m_n2072FactoryIndex, bWith2019, listRegAddr, listBitLow, listBitHigh, listVals);

            if (bResult == false)
            {
                txt += " " + Trans("失败") + "!";
                WriteMessage(txt);
            }

            //发送128寄存器值
            UnitTypeV2 objType = GetSelectedPanelType();
            ArrayList calcResult = m_2072FactoryParam.RunCalc(m_n2072FactoryIndex, objType.SubName);
            if (calcResult == null)
            {
                txt += " " + Trans("失败") + "!";
                WriteMessage(txt);
                return;
            }

            //计算出最大灰度级数
            int nMaxGrayLevel = (int)calcResult[6];

            //计算出GAMMA最大值位数
            int nMaxGAMMAValueBit = (int)calcResult[7];

            //计算出128寄存器的值
            //int nReg128 = (int)calcResult[5];//2019-03-25禁用自动计算

            //合规性检查
            bool bCheckOK = (bool)calcResult[10];

            //等式左侧
            int nLeft = (int)calcResult[8];

            //等式右侧
            int nRight = (int)calcResult[9];

            if (bCheckOK == false)
            {
                string tmp = string.Format("{0}: {1}<={2} {3}",
                   Trans("参数合规性检查"),
                   nLeft, nRight,
                   (bCheckOK ? Trans("成功") : Trans("失败")));

                WriteMessage(tmp);

                txt += " " + Trans("失败");
                WriteMessage(txt);
                return;
            }

            //输出额外信息
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine(string.Format("Register 128 Value={0}", nReg128));
            sb.AppendLine(string.Format("Register 128 Value={0}", input2072FactoryRegisterVal.Text));//2019-03-25禁用自动计算
            sb.AppendLine(string.Format("{0}:{1}", Trans("最大灰度级数"), nMaxGrayLevel));

            //2019-01-22 修改GAMMA值算法，不按照最大值位数计算最大值，而是直接给定最大值
            sb.AppendLine(string.Format("{0}:{1}", Trans("最大值位数"), nMaxGAMMAValueBit));//2019-02-20 恢复

            sb.Append(string.Format("{0}: {1}<={2} {3}",
                Trans("参数合规性检查"),
                nLeft, nRight,
                (bCheckOK ? Trans("成功") : Trans("失败"))));

            WriteMessage(sb.ToString());

            //128寄存器值

            //input2072FactoryRegisterAddr 寄存器地址
            //cb2072FactoryRegister_StartBit 起始
            //cb2072FactoryRegister_EndBit 终止
            //input2072FactoryRegisterVal  数值

            ////2019-03-25禁用自动计算
            //input2072FactoryRegisterAddr.Text = "128";
            //cb2072FactoryRegister_StartBit.SelectedIndex = 0;
            //cb2072FactoryRegister_EndBit.SelectedIndex = 15;
            //input2072FactoryRegisterVal.Text = nReg128.ToString();


            //listRegAddr.Add(128);
            //listBitLow.Add(0);
            //listBitHigh.Add(15);
            //listVals.Add((ushort)nReg128);

            //-------------------------在线程中发送数据------------------2018-11-15

            //构造GAMMA数据 2019-01-22
            double fGAMMA = 2.4f;
            byte[] arrData = new byte[2048];//10bit GAMMA
            GAMMAProcessClass optGAMMA = new GAMMAProcessClass(10, fGAMMA, GetGAMMAMaxValueFromBit(nMaxGAMMAValueBit));//2019-02-20 恢复使用最大值位数
            Array.Copy(optGAMMA.GetData, arrData, 2048);

            ushort nColorValueExt = 0;
            if (GetSelectedPanelType().Bit == 8)
            {
                //8bit GAMMA 需要特殊处理
                GAMMATrans10bitTo8bit(arrData);//2019-03-01 LANG项目特殊处理

                nColorValueExt = 3;//颜色序号附加值
            }

            EnableControl(sender as Control, false);
            byte chipPos = (byte)cbRegChip.SelectedValue.ToString().ToByte();
            new Thread(new ThreadStart(delegate ()
            {
                string info = "";

                int nMode = m_n2072SimpleIndex;



                tabControl1.Enabled = false;

                foreach (var item in _DevIP)
                {
                    int hDevice = item.Value;
                    string szDeviceName = item.Key;

                    bResult = Write2072RegisterMulti(hDevice, addrMB, (byte)GetId(), chipPos, m_n2072FactoryIndex, listRegAddr, listBitLow, listBitHigh, listVals, 70);

                    if (bResult == false)
                    {
                        txt += " " + Trans("失败");
                        WriteMessage(txt);

                        //tabControl1.Enabled = true;
                        //CloseCommunication();
                        continue;
                    }
                    //-----------------发送GAMMA数据 默认为2.4---------------

                    string szGAMMA = Trans("发送Gamma");
                    WriteMessage(szGAMMA);

                    WriteStatusMessage(szGAMMA);
                    SetPrograss("", szGAMMA, 70);


                    //byte color = 0;//全部颜色
                    //byte nResult = twsOper.tws_WriteGAMMA2072(hDevice, addrMB, color, (byte)nMaxGAMMAValueBit, 2.4f);

                    //写入全部颜色GAMMA 2019-01-22

                    bool bWriteGAMMA = true;//写入GAMMA
                    int nResult = 0;

                    //nResult += _TLWCommand.tlw_WriteGAMMA(hDevice, addrMB, bWriteGAMMA, (ushort)(0 + nColorValueExt), (byte)nMode, arrData, 0, 2048);
                    nResult += _TLWCommand.tlw_WriteGAMMA(item.Value, addrMB, GetId(), 0, (byte)(0 + nColorValueExt), arrData);

                    //绿色GAMMA
                    nResult += _TLWCommand.tlw_WriteGAMMA(item.Value, addrMB, GetId(), 0, (byte)(0 + nColorValueExt), arrData);

                    //蓝色GAMMA
                    nResult += _TLWCommand.tlw_WriteGAMMA(item.Value, addrMB, GetId(), 0, (byte)(0 + nColorValueExt), arrData);

                    if (bResult)
                    {
                        txt += " " + Trans("成功");
                        SetPrograss("", "", 100);
                    }
                    else
                    {
                        txt += " " + Trans("失败");
                    }

                    //WriteStatusMessage(txt);
                    WriteMessage(txt);


                    ////输出额外信息
                    //StringBuilder sb = new StringBuilder();
                    //sb.AppendLine(string.Format("Register 128 Value={0}", nReg128));
                    //sb.AppendLine(string.Format("{0}:{1}", Trans("最大灰度级数"), nMaxGrayLevel));
                    //sb.AppendLine(string.Format("{0}:{1}", Trans("最大值位数"), nMaxGAMMAValueBit));
                    //sb.AppendLine(string.Format("{0}: {1}<={2} {3}",
                    //    Trans("参数合规性检查"),
                    //    nLeft, nRight,
                    //    (bCheckOK ? Trans("成功") : Trans("失败"))));

                    //WriteOutputWithoutTime(sb.ToString());

                    ////128寄存器值
                    //input2072FactoryRegisterAddr.Text = "128";
                    //input2072FactoryRegisterVal.Text = nReg128.ToString();
                }

                //关闭设备，恢复界面
                tabControl1.Enabled = true;
                EnableControl(sender as Control, true);

            })).Start();
        }

        private void btnSet2072FactoryCurrentGain_All_Click(object sender, EventArgs e)
        {
            btnSet2072FactoryCurrentGain_R_Click(btnSet2072FactoryCurrentGain_R, null);
            btnSet2072FactoryCurrentGain_R_Click(btnSet2072FactoryCurrentGain_G, null);
            btnSet2072FactoryCurrentGain_R_Click(btnSet2072FactoryCurrentGain_B, null);
        }

        private void btnSet2072FactoryCurrentGain_R_Click(object sender, EventArgs e)
        {
            //2072工厂模式 单条命令设置            

            if (m_2072FactoryParam.Is2072Ready(m_n2072FactoryIndex))
            {
                //界面数据保存到内存
                m_2072FactoryParam.UpdateData(m_n2072FactoryIndex);

                classCtrlBindData obj = m_2072FactoryParam.FindCtrlAndData((sender as Control).Tag.ToString());
                if (obj != null)
                {
                    byte chipPos = (byte)cbRegChip.SelectedValue.ToString().ToByte();

                    new Thread(new ThreadStart(delegate ()//2018-11-15改成线程方式
                    {

                        ushort addrMB = GetMBAddr();


                        tabControl1.Enabled = false;
                        EnableControl(sender as Control, false);

                        foreach (var dev in _DevIP)
                        {
                            int hDevice = dev.Value;
                            string szDeviceName = dev.Key;

                            string info = "[" + szDeviceName + "]:";

                            byte nMode = (byte)m_n2072FactoryIndex;

                            int result = 0;
                            foreach (classPartOfReg item in obj.m_listPart)
                            {
                                info = "";

                                //数值
                                ushort val = (ushort)m_2072FactoryParam.GetPartOfUInt32(m_n2072FactoryIndex, item.nRegAddr, item.nBitLow, item.nBitHigh);

                                classPartOfReg newItem = m_2072FactoryParam.TransformAddr(item);

                                info += string.Format("{0} 2200 {1}:0x{2:X} {3}:{4} {5}:{6}\r\n",
                                    cb2072Factory5060Hz.Text,
                                    Trans("寄存器地址"), item.nRegAddr,
                                    Trans("起始位"), item.nBitLow,
                                    Trans("终止位"), item.nBitHigh);

                                info += string.Format("FPGA {0}:0x{1:X} {2}:{3} {4}:{5} Value:{6}",
                                    Trans("寄存器地址"), newItem.nRegAddr,
                                    Trans("起始位"), newItem.nBitLow,
                                    Trans("终止位"), newItem.nBitHigh,
                                    val);

                                //result = twsOper.tws_Write2072Register(hDevice, addrMB, nMode, newItem.nRegAddr, newItem.nBitLow, newItem.nBitHigh, val);
                                result = _TLWCommand.tlw_WriteRegister(hDevice, addrMB, (byte)GetId(), chipPos, newItem.nRegAddr, val, true);
                                if (result == 0)
                                {
                                    info += " " + Trans("成功") + "!";
                                }
                                else
                                {
                                    info += " " + Trans("失败") + "!";
                                }

                                WriteMessage(info);
                            }
                        }

                        EnableControl(sender as Control, true);
                        tabControl1.Enabled = true;
                    })).Start();
                }
            }
        }

        private void btn2072FactoryRegisterSet_Click(object sender, EventArgs e)
        {
            //2072 Factory界面 发送特殊寄存器值
            ushort addrMB = GetMBAddr();

            byte nBitLow, nBitHigh;
            nBitLow = (byte)cb2072FactoryRegister_StartBit.SelectedIndex;
            nBitHigh = (byte)cb2072FactoryRegister_EndBit.SelectedIndex;

            if (nBitLow > nBitHigh)
            {
                MessageBox.Show(lb2072FactoryRegister2.Text + "," + lb2072FactoryRegister3.Text + "," + Trans("输入值有误") + "!", Trans("错误"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ushort val = 0;
            ushort regAddr = 0;

            try
            {
                regAddr = ushort.Parse(input2072FactoryRegisterAddr.Text);
            }
            catch
            {
                MessageBox.Show(Trans("输入值有误") + "!", Trans("错误"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                input2072FactoryRegisterAddr.Focus();
                return;
            }

            try
            {
                val = ushort.Parse(input2072FactoryRegisterVal.Text);
            }
            catch
            {
                MessageBox.Show(Trans("输入值有误") + "!", Trans("错误"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                input2072FactoryRegisterVal.Focus();
                return;
            }

            byte chipPos = (byte)cbRegChip.SelectedValue.ToString().ToByte();
            new Thread(new ThreadStart(delegate ()//2018-11-15改成线程方式
            {
                EnableControl(sender as Control, false);
                tabControl1.Enabled = false;
                foreach (var dev in _DevIP)
                {
                    int hDevice = dev.Value;
                    string szDeviceName = dev.Key;

                    string info = "[" + szDeviceName + "]:";

                    info += string.Format("{0} {1}:0x{2:X} {3}:{4} {5}:{6} Value={7}",
                        cb2072Factory5060Hz.Text,
                        Trans("寄存器地址"), regAddr,
                        Trans("起始位"), nBitLow,
                        Trans("终止位"), nBitHigh,
                        val);

                    //byte result = twsOper.tws_Write2072Register(hDevice, addrMB, (byte)m_n2072FactoryIndex, regAddr, nBitLow, nBitHigh, val);
                    int result = _TLWCommand.tlw_WriteRegister(hDevice, addrMB, (byte)GetId(), chipPos, regAddr, val, true);
                    if (result == 0)
                    {
                        info = info + " " + Trans("成功") + "!";
                    }
                    else
                        info = info + " " + Trans("失败") + "!";
                    //WriteStatusMessage(info);
                    WriteMessage(info);
                }

                EnableControl(sender as Control, true);
                tabControl1.Enabled = true;

            })).Start();
        }

        private void btnReadMap_Click(object sender, EventArgs e)
        {
            if (CheckDeviceAddrIsZero())
            {
                MessageBox.Show(this, "读取程序不能使用广播地址");
                return;
            }
            string ip = ShowSelectIPDialog();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.mif|*.mif";
            if (saveFileDialog.ShowDialog(this) == DialogResult.Cancel)
            {
                WriteMessage($"用户取消读取MCU文件");
                EnableControl(sender as Control, true);
                return;
            }
            string fileName = saveFileDialog.FileName;
            EnableControl(sender as Control, false, ip);
            _TLWCommand.tlw_ReadMAP(GetMBAddr(), GetId(), 0, _DevIP, (param) =>
            {
                //读取MCU版本
                Array.ForEach(param, t =>
                {
                    if (t.ResultCode == 0)
                    {
                        MapHelper.SaveMap(fileName, t.Data as byte[]);

                    }
                    else
                    {
                        WriteMessage($"读取MAP失败");
                        EnableControl(sender as Control, true);
                    }
                });
            });
        }
    }
}
