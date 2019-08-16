using BatchSeamCalibration.Structs;
using EdgModel;
using LanguageLib;
using PluginLib;
using SFTHelper.Helper;
using SFTHelper.Structs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TLWComm;
using TLWCommunication;
using UnitInfo;

namespace BatchSeamCalibration
{
    public partial class frmMain : BaseFormV2
    {
        bool isDebugMode = true;//是否测试模式

        private string LocalCalFolder;
        private Dictionary<string, string> currentModuleFolder;

        public frmMain()
        {
            InitializeComponent();
        }

        #region 字段
        private string _cfgFileName = "cfg.xml";
        private InterfaceData _interfaceData;//界面数据
        private TLWCommand _baseCommunication;//通讯操作类
        private Dictionary<string, Thread> _threadList = new Dictionary<string, Thread>();//线程列表。控件名称->线程
        private Dictionary<int, string> _devIP = new Dictionary<int, string>();//设备号IP列表 DevNum->IP地址
        private readonly String lang = MultiLanguage.ReadDefaultLanguage(); //读取语言包信息
        private UnitTypeV2 _unitType;
        #endregion

        #region 属性
        //预览窗口
        frmPreview ViewForm { get; set; }

        #endregion

        #region 方法

        ushort GetMBAddr(int x, int y)
        {
            ushort cardAddr = (ushort)(x << 8 | y);
            return cardAddr;
        }

        private string GetModuleCalFolder(string name)
        {
            lock (this)
            {
                if (!currentModuleFolder.ContainsKey(name))
                {
                    string dir = System.IO.Path.Combine(LocalCalFolder, name);
                    if (System.IO.Directory.Exists(dir) == false) System.IO.Directory.CreateDirectory(dir);
                    currentModuleFolder.Add(name, dir);
                }
                return currentModuleFolder[name];

            }
        }

        private void ChangeUILanguage()
        {
            btnInitIpList.Text = MultiLanguage.GetNames(Name, "Initialization");
            lblComment.Text = MultiLanguage.GetNames(Name, "Comment");
            btnResetViewForm.Text = MultiLanguage.GetNames(Name, "ResetPreviewWindow");
            gpPreviewBackground.Text = MultiLanguage.GetNames(Name, "PreviewBackground");
            gpDataModify.Text = MultiLanguage.GetNames(Name, "DataModification");
            gpDataLocate.Text = MultiLanguage.GetNames(Name, "DataLocation");
            gpDisplaySet.Text = MultiLanguage.GetNames(Name, "DisplaySetting");
            ckReset.Text = MultiLanguage.GetNames(Name, "DataRestore");
            lblIPList.Text = MultiLanguage.GetNames(Name, "IPList");
            lblComment.Text = MultiLanguage.GetNames(Name, "Comment");
            cbdataPos.Items.Clear();
            cbdataPos.Items.Add(MultiLanguage.GetNames(Name, "Cabinet"));
            cbdataPos.Items.Add(MultiLanguage.GetNames(Name, "Folder"));
            cbDataType.Items.Clear();
            cbDataType.Items.Add(MultiLanguage.GetNames(Name, "Module"));
            //cbDataType.Items.Add(MultiLanguage.GetNames(Name, "Cabinet"));
        }

        //初始化亮暗线数据
        StructSeamItem[,] InitSeamData()
        {
            StructSeamItem[,] seamData;
            seamData = new StructSeamItem[_unitType.ModuleHeight, _unitType.ModuleWidth];
            int width = _unitType.ModulePixelWidth;
            int height = _unitType.ModulePixelHeight;
            int margin = 40;
            for (int i = 0; i < _unitType.ModuleHeight; i++)
            {
                int ltY = 0;
                if (i != 0)
                {
                    ltY = (i) * height;
                }
                for (int j = 0; j < _unitType.ModuleWidth; j++)
                {
                    int ltX = 0;
                    if (j != 0)
                    {
                        ltX = (j) * width;
                    }
                    Rectangle rect = new Rectangle(ltX, ltY, width - 1, height - 1);
                    seamData[i, j] = new StructSeamItem(100);
                    seamData[i, j].RectangleAll = rect;

                    //左
                    Rectangle rectLeft = new Rectangle();
                    rectLeft.X = seamData[i, j].RectangleAll.X;
                    rectLeft.Y = seamData[i, j].RectangleAll.Y + margin;
                    rectLeft.Width = 33;
                    rectLeft.Height = seamData[i, j].RectangleAll.Height - margin * 2;
                    seamData[i, j].RectangleLeft = rectLeft;
                    seamData[i, j].AreaLineLeft.Clear();
                    seamData[i, j].AreaLineLeft.Add(new Point(seamData[i, j].RectangleAll.X, seamData[i, j].RectangleAll.Y));
                    seamData[i, j].AreaLineLeft.Add(new Point(seamData[i, j].RectangleAll.X + 10, seamData[i, j].RectangleAll.Y + 10));
                    seamData[i, j].AreaLineLeft.Add(new Point(seamData[i, j].RectangleAll.X + 10, seamData[i, j].RectangleAll.Y + seamData[i, j].RectangleAll.Height - 10));
                    seamData[i, j].AreaLineLeft.Add(new Point(seamData[i, j].RectangleAll.X, seamData[i, j].RectangleAll.Y + seamData[i, j].RectangleAll.Height));

                    seamData[i, j].PreviewLineLeft.Clear();
                    seamData[i, j].PreviewLineLeft.Add(new Point(seamData[i, j].RectangleAll.X, seamData[i, j].RectangleAll.Y));
                    seamData[i, j].PreviewLineLeft.Add(new Point(seamData[i, j].RectangleAll.X, seamData[i, j].RectangleAll.Y + seamData[i, j].RectangleAll.Height));

                    Rectangle rectTop = new Rectangle();
                    //上
                    rectTop.X = seamData[i, j].RectangleAll.X + margin;
                    rectTop.Y = seamData[i, j].RectangleAll.Y;
                    rectTop.Width = seamData[i, j].RectangleAll.Width - margin * 2;
                    rectTop.Height = 33;
                    seamData[i, j].RectangleTop = rectTop;
                    seamData[i, j].AreaLineTop.Clear();
                    seamData[i, j].AreaLineTop.Add(new Point(seamData[i, j].RectangleAll.X, seamData[i, j].RectangleAll.Y));
                    seamData[i, j].AreaLineTop.Add(new Point(seamData[i, j].RectangleAll.X + 10, seamData[i, j].RectangleAll.Y + 10));
                    seamData[i, j].AreaLineTop.Add(new Point(seamData[i, j].RectangleAll.X + seamData[i, j].RectangleAll.Width - 10, seamData[i, j].RectangleAll.Y + 10));
                    seamData[i, j].AreaLineTop.Add(new Point(seamData[i, j].RectangleAll.X + seamData[i, j].RectangleAll.Width, seamData[i, j].RectangleAll.Y));

                    seamData[i, j].PreviewLineTop.Clear();
                    seamData[i, j].PreviewLineTop.Add(new Point(seamData[i, j].RectangleAll.X, seamData[i, j].RectangleAll.Y));
                    seamData[i, j].PreviewLineTop.Add(new Point(seamData[i, j].RectangleAll.X + seamData[i, j].RectangleAll.Width, seamData[i, j].RectangleAll.Y));

                    //右
                    Rectangle rectRight = new Rectangle();
                    rectRight.X = seamData[i, j].RectangleAll.X + seamData[i, j].RectangleAll.Width - 33;
                    rectRight.Y = seamData[i, j].RectangleAll.Y + margin;
                    rectRight.Width = 33;
                    rectRight.Height = seamData[i, j].RectangleAll.Height - margin * 2;
                    seamData[i, j].RectangleRight = rectRight;
                    seamData[i, j].AreaLineRight.Clear();
                    seamData[i, j].AreaLineRight.Add(new Point(seamData[i, j].RectangleAll.X + seamData[i, j].RectangleAll.Width, seamData[i, j].RectangleAll.Y));
                    seamData[i, j].AreaLineRight.Add(new Point(seamData[i, j].RectangleAll.X + seamData[i, j].RectangleAll.Width - 10, seamData[i, j].RectangleAll.Y + 10));
                    seamData[i, j].AreaLineRight.Add(new Point(seamData[i, j].RectangleAll.X + seamData[i, j].RectangleAll.Width - 10, seamData[i, j].RectangleAll.Y + seamData[i, j].RectangleAll.Height - 10));
                    seamData[i, j].AreaLineRight.Add(new Point(seamData[i, j].RectangleAll.X + seamData[i, j].RectangleAll.Width, seamData[i, j].RectangleAll.Y + seamData[i, j].RectangleAll.Height));

                    seamData[i, j].PreviewLineRight.Clear();
                    seamData[i, j].PreviewLineRight.Add(new Point(seamData[i, j].RectangleAll.X + seamData[i, j].RectangleAll.Width, seamData[i, j].RectangleAll.Y));
                    seamData[i, j].PreviewLineRight.Add(new Point(seamData[i, j].RectangleAll.X + seamData[i, j].RectangleAll.Width, seamData[i, j].RectangleAll.Y + seamData[i, j].RectangleAll.Height));

                    //下
                    Rectangle rectBottom = new Rectangle();
                    rectBottom.X = seamData[i, j].RectangleAll.X + margin;
                    rectBottom.Y = seamData[i, j].RectangleAll.Y + seamData[i, j].RectangleAll.Height - 33;
                    rectBottom.Width = seamData[i, j].RectangleAll.Width - margin * 2;
                    rectBottom.Height = 33;
                    seamData[i, j].RectangleBottom = rectBottom;
                    seamData[i, j].AreaLineBottom.Clear();
                    seamData[i, j].AreaLineBottom.Add(new Point(seamData[i, j].RectangleAll.X, seamData[i, j].RectangleAll.Y + seamData[i, j].RectangleAll.Height));
                    seamData[i, j].AreaLineBottom.Add(new Point(seamData[i, j].RectangleAll.X + 10, seamData[i, j].RectangleAll.Y + seamData[i, j].RectangleAll.Height - 10));
                    seamData[i, j].AreaLineBottom.Add(new Point(seamData[i, j].RectangleAll.X + seamData[i, j].RectangleAll.Width - 10, seamData[i, j].RectangleAll.Y + seamData[i, j].RectangleAll.Height - 10));
                    seamData[i, j].AreaLineBottom.Add(new Point(seamData[i, j].RectangleAll.X + seamData[i, j].RectangleAll.Width, seamData[i, j].RectangleAll.Y + seamData[i, j].RectangleAll.Height));

                    seamData[i, j].PreviewLineBottom.Clear();
                    seamData[i, j].PreviewLineBottom.Add(new Point(seamData[i, j].RectangleAll.X, seamData[i, j].RectangleAll.Y + seamData[i, j].RectangleAll.Height));
                    seamData[i, j].PreviewLineBottom.Add(new Point(seamData[i, j].RectangleAll.X + seamData[i, j].RectangleAll.Width, seamData[i, j].RectangleAll.Y + seamData[i, j].RectangleAll.Height));
                }
            }
            return seamData;
        }


        //初始化界面结构数据
        void InitInterfaceData()
        {
            _interfaceData = new InterfaceData();
            _interfaceData.Background = 255;
            _interfaceData.ShowBorder = false;
            _interfaceData.ShowPercentValue = false;

            string cfgFile = System.IO.Path.Combine(Path, _cfgFileName);
            if (File.Exists(cfgFile))
            {
                _interfaceData = SerializeHelper.DeserializeWithXml<InterfaceData>(cfgFile);
                tbGray.Value = _interfaceData.Background;
                numGray.ValueChanged -= numGray_ValueChanged;
                numGray.Value = _interfaceData.Background;
                numGray.ValueChanged += numGray_ValueChanged;
                ckShowBorder.CheckedChanged -= ckShowBorder_CheckedChanged;
                ckShowBorder.Checked = _interfaceData.ShowBorder;
                ckShowBorder.CheckedChanged += ckShowBorder_CheckedChanged;
                ckShowPercent.CheckedChanged -= ckShowPercent_CheckedChanged;
                ckShowPercent.Checked = _interfaceData.ShowPercentValue;
                ckShowPercent.CheckedChanged += ckShowPercent_CheckedChanged;
                ckLockViewForm.CheckedChanged -= ckLockViewForm_CheckedChanged;
                ckLockViewForm.Checked = _interfaceData.LockViewForm;
                ckLockViewForm.CheckedChanged += ckLockViewForm_CheckedChanged;
                cbdataPos.SelectedIndex = _interfaceData.DataLocation;
                cbDataType.SelectedIndex = _interfaceData.DataType;
                txtDataLocation.Text = _interfaceData.LocalDataPath;
            }
            else
            {
                cbdataPos.SelectedIndex = 0;
                cbDataType.SelectedIndex = 0;
            }
        }

        //界面初始化
        void InitViewForm()
        {
            if (ViewForm == null) ViewForm = new frmPreview(Path);
            ViewForm.ShowInTaskbar = false;
            ViewForm.SelectedBorderChanged += ViewForm_SelectedBorderChanged;
            ViewForm.CabinetType = _unitType;
            ViewForm.Width = ViewForm.CabinetType.GetSize().Width + 0;
            ViewForm.Height = ViewForm.CabinetType.GetSize().Height + 0;
            ViewForm.InterfaceData = _interfaceData;
            ViewForm.SeamData = InitSeamData();
            ViewForm.Lock = ckLockViewForm.Checked;
            //ViewForm.Show();
            ViewForm.Location = _interfaceData.ViewFormPosition;
            ViewForm.SelectedIPCommand = GetSelectedIPCommand();
            //frmMain_Move(null, null);
        }

        //选中指定IP命令项
        void SetIPCommandSelected(UserIPCommand ctr)
        {
            foreach (UserIPCommand item in flowIPList.Controls)
            {
                if (item.Equals(ctr))
                {
                    item.Checked = true;
                    ViewForm.SeamData = item.Tag1 as StructSeamItem[,];
                    ViewForm.SelectedBorder = (SelectedBorder)item.Tag2;
                    ViewForm.SelectedIPCommand = item;
                    if (item.Tag4 != null) ViewForm.Location = (Point)item.Tag4;
                    ViewForm.Refresh();

                }
                else
                {
                    item.Checked = false;
                }
            }
        }

        //获取选中的IP命令项
        UserIPCommand GetSelectedIPCommand()
        {
            foreach (UserIPCommand item in flowIPList.Controls)
            {
                if (item.Checked) return item;
            }
            return null;
        }

        //根据IP地址获取IP命令项
        UserIPCommand GetIPCommand(string ip)
        {
            foreach (UserIPCommand item in flowIPList.Controls)
            {
                if (item.IP == ip) return item;
            }
            return null;
        }

        //根据界面信息刷新预览窗口
        void RefreshViewForm()
        {
            _interfaceData.Background = (int)numGray.Value;

            _interfaceData.ShowBorder = ckShowBorder.Checked;
            //_interfaceData.ShowPercentValue = ckShowPercent.Checked;
            if (ViewForm != null)
                ViewForm.Draw();
        }

        //设置选中边框的百分比，并刷新预览窗口
        void SetSelectedBorderPercent(float percent)
        {
            UserIPCommand ipCommand = GetSelectedIPCommand();
            if (ipCommand == null) return;
            StructSeamItem[,] _seamData = ipCommand.Tag1 as StructSeamItem[,];
            SelectedBorder selectedBorder = ViewForm.SelectedBorder;
            for (int i = 0; i < _seamData.GetLength(0); i++)
            {
                for (int j = 0; j < _seamData.GetLength(1); j++)
                {

                    if (selectedBorder.Top[i, j] == 1)
                    {
                        _seamData[i, j].Top = percent;
                    }
                    if (selectedBorder.Left[i, j] == 1)
                    {
                        _seamData[i, j].Left = percent;
                    }
                    if (selectedBorder.Bottom[i, j] == 1)
                    {
                        _seamData[i, j].Bottom = percent;
                    }
                    if (selectedBorder.Right[i, j] == 1)
                    {
                        _seamData[i, j].Right = percent;
                    }
                }
            }
            ViewForm.Draw();
        }

        //创建通讯类
        TLWCommand CreateCommunication()
        {
            TLWCommand tlwCommand = new TLWCommand();
            if (!tlwCommand.Sys_Initial(Path))
            {
                return null;
            }
            tlwCommand.DataMonitorEvent += _baseCommunication_DataMonitorEvent;
            tlwCommand.ProgressChangedEvent += _baseCommunication_ProgressChangedMonitorEvent;
            tlwCommand.ProgressChangedEvent -= _baseCommunication_ProgressChangedMonitorEvent;

            //_operator.DataMonitorEvent += _baseCommunication_DataMonitorEvent;
            return tlwCommand;
        }

        //设置命令状态
        void SetCommandStatus(string ip, bool status)
        {
            try
            {
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(() => { SetCommandStatus(ip, status); }));
                }
                else
                {
                    UserIPCommand userIPCommand = GetIPCommand(ip);
                    if (status == false) userIPCommand.BackColor = Color.Gray;
                    userIPCommand.ButtonText = MultiLanguage.GetNames(Name, "Send");
                    userIPCommand.ButtonApplyEnable = true;
                    userIPCommand.ButtonViewFormEnable = true;
                    userIPCommand.ButtonWorkModeEnable = true;
                    userIPCommand.Tag3 = 0;
                    if (status)
                    {
                        userIPCommand.Tag1 = InitSeamData();
                        if (userIPCommand.Checked)
                        {
                            ViewForm.SeamData = userIPCommand.Tag1 as StructSeamItem[,];
                        }
                        ViewForm.Refresh();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        //停止执行命令
        void Stop(UserIPCommand iPCommand)
        {
            string ip = iPCommand.IP;
            foreach (var item in _devIP)
            {
                if (item.Value == ip)
                {
                    if (item.Key != -1)
                    {
                        _baseCommunication.Sys_Stop(item.Key);
                        Thread.Sleep(200);
                        break;
                    }
                }
            }
        }


        DialogResult MessageBoxEx(string text, MessageBoxButtons messageBoxButtons)
        {
            if (InvokeRequired)
            {
                //return MessageBoxEx(text, messageBoxButtons);
                DialogResult dlgResult = DialogResult.No;
                Invoke(new MethodInvoker(() => { dlgResult = MessageBoxEx(text, messageBoxButtons); }));
                return dlgResult;
            }
            else
            {
                DialogResult dlgResult = MessageBox.Show(this, text, "", messageBoxButtons);
                return dlgResult;
            }
        }

        //输出日志
        void Log(string ip, string msg)
        {

            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => { Log(ip, msg); }));
            }
            else
            {
                //rtLog.AppendText(DateTime.Now.ToString("HH:mm:ss") + " " + msg + "\r\n");
                //rtLog.ScrollToCaret();
                WriteLine("IP:" + ip + " " + msg, true);

            }

            //if (InvokeRequired)
            //{
            //    Invoke(new MethodInvoker(() => { Log(ip, msg); }));
            //}
            //else
            //{
            //    UserIPCommand userIPCommand = GetIPCommand(ip);
            //    if (userIPCommand != null)
            //    {
            //        userIPCommand.Description = msg;
            //    }
            //}

        }

        void ResetIPList()
        {
            currentModuleFolder = new Dictionary<string, string>();
            CommunicationType comm = GetCommunicationType();
            CloseAllDevice();
            InitViewForm();
            byte[] startIP = IPAddress.Parse(comm.StartIPAddress).GetAddressBytes();
            byte[] endIP = IPAddress.Parse(comm.EndIPAddress).GetAddressBytes();
            flowIPList.Controls.Clear();
            for (int i = startIP[3]; i <= endIP[3]; i++)
            {
                string ip = startIP[0] + "." + startIP[1] + "." + startIP[2] + "." + i;
                UserIPCommand userIPCommand = new UserIPCommand();
                userIPCommand.Name = "userIPCommand" + i;
                userIPCommand.IP = ip;
                userIPCommand.ButtonText = MultiLanguage.GetNames(Name, "Send");
                userIPCommand.WorkModeText = MultiLanguage.GetNames(Name, "DisplaySetting");
                userIPCommand.VideoText = MultiLanguage.GetNames(Name, "Video");
                userIPCommand.WhiteText = MultiLanguage.GetNames(Name, "White");
                userIPCommand.RedText = MultiLanguage.GetNames(Name, "Red");
                userIPCommand.GreenText = MultiLanguage.GetNames(Name, "Green");
                userIPCommand.BlueText = MultiLanguage.GetNames(Name, "Blue");
                userIPCommand.ViewButtonText = MultiLanguage.GetNames(Name, "View");
                userIPCommand.Progress = 0;
                userIPCommand.Tag = i;
                userIPCommand.Tag1 = InitSeamData();
                userIPCommand.Tag2 = ViewForm.SelectedBorder;
                userIPCommand.Tag3 = 0;
                userIPCommand.Description = "";
                userIPCommand.SendButtonClick += UserIPCommand_SendButtonClick;
                userIPCommand.SendWorkModeButtonClick += UserIPCommand_SendWorkModeButtonClick;
                userIPCommand.ViewFormButtonClick += UserIPCommand_ViewFormButtonClick;
                userIPCommand.Click += UserIPCommand_Click;
                flowIPList.Controls.Add(userIPCommand);
            }

            //if(flowIPList.Controls.Count!=0)
            //{
            //    UserIPCommand ctr = flowIPList.Controls[0] as UserIPCommand;
            //    SetIPCommandSelected(ctr);
            //}
        }


        Structs.OperationResult ReadCalibrationDataFromCabinet(int devNum, string ip, string outFile)
        {
            ////从箱体读取数据
            //Structs.OperationResult operationResult = new Structs.OperationResult();
            //byte[] sz = new byte[1024];
            //int isOK = _baseCommunication.tlw_ReadSerialNumber(devNum, GetMBAddr(1, 1), 0, 0, sz);
            //operationResult.Status = SNHelper.AnalayzeSN(sz, out string timeCode);
            //if (!operationResult.Status)
            //{
            //    //读取时间码失败
            //    Log(ip, MultiLanguage.GetNames(Name, "ReadTimeCodeFailed"));
            //    SetCommandStatus(ip, false);
            //    return new Structs.OperationResult() { Status = false };
            //}
            //Thread.Sleep(200);
            //operationResult = _baseCommunication.MainBoardReadCalibrationFile(operationResult.DeviceNumber, cmdAddr, cabinetSize.ModulePixelWidth, cabinetSize.ModulePixelHeight, outFile);
            //return operationResult;

            return new Structs.OperationResult();
        }

        Structs.OperationResult ReadModulesCalibrationDataFromFolder(int devNum, string sourceDataPath, int moduleWidth, int moduleHeight, int modulePixelWidth, int modulePixelHeight)
        {
            Structs.OperationResult operationResult = new Structs.OperationResult();
            operationResult.Status = true;
            string[,] sn = new string[moduleHeight, moduleWidth];
            string[,] calFiles = new string[moduleHeight, moduleWidth];
            string firstSn = "";
            for (int i = 0; i < moduleHeight; i++)
            {
                for (int j = 0; j < moduleWidth; j++)
                {
                    string timeCode = "";
                    byte[] sz = new byte[1024];
                    int x = j + 1;
                    int y = i / 2 + 1;
                    byte pos = (byte)((i + 1) % 2);
                    if (!isDebugMode)
                    {
                        int result = _baseCommunication.tlw_ReadSerialNumber(devNum, GetMBAddr(x, y), 0, pos, sz);
                        string modulePos = pos == 0 ? MultiLanguage.GetNames(Name, "upmodule") : MultiLanguage.GetNames(Name, "bottommodule");
                        if (result != 0)
                        {
                            operationResult.Status = false;
                            operationResult.Message = string.Format(MultiLanguage.GetNames(Name, "ReadTimeCodeFailed"), x, y, modulePos);
                            return operationResult;
                        }
                        operationResult = new Structs.OperationResult();
                        if (SNHelper.AnalayzeSN(sz, out timeCode) == false)
                        {
                            operationResult.Status = false;
                            operationResult.Message = string.Format(MultiLanguage.GetNames(Name, "ReadTimeCodeFailed"), x, y, modulePos);
                            return operationResult;
                        }
                    }
                    else
                    {
                        timeCode = $"{i}_{j}";
                    }
                    operationResult.strData = timeCode;

                    Thread.Sleep(200);
                    sn[i, j] = operationResult.strData;
                    if (i == 0 && j == 0) firstSn = sn[i, j];
                    string filter = string.Format("*{0}*.dat", sn[i, j]);
                    List<string> fileList = new List<string>();
                    FileHelper.GetFiles(sourceDataPath, filter, (modulePixelWidth * 18 + 10) * modulePixelHeight, false, ref fileList);
                    string[] files = fileList.ToArray();
                    if (files.Length == 0)
                    {
                        operationResult.Status = false;
                        operationResult.Message = string.Format(MultiLanguage.GetNames(Name, "FileForTimeCodeNotFound"), sn[i, j]);
                        return operationResult;
                    }
                    calFiles[i, j] = files[0];
                }
            }
            calFiles = ArrayHelper.Reverse(calFiles);
            string tmpPath = System.IO.Path.Combine(GetModuleCalFolder(firstSn), "ModuleDat_Source"/* + System.IO.Path.GetRandomFileName().Replace(".tmp", "")*/);
            if (!Directory.Exists(tmpPath))
            {
                Directory.CreateDirectory(tmpPath);
            }
            //int zdatLen = modulePixelWidth * modulePixelHeight * 16;
            CalibrationHelper calibrationHelper = new CalibrationHelper(moduleWidth, moduleHeight, modulePixelWidth, modulePixelHeight);
            for (int i = 0; i < calFiles.GetLength(0); i++)
            {
                for (int j = 0; j < calFiles.GetLength(1); j++)
                {
                    //if (fileInfo.Length != zdatLen)
                    //{
                    //    operationResult.Status = false;
                    //    operationResult.Message = string.Format(MultiLanguage.GetNames(Name, "FileForTimeCodeNotFound"), sn[i, j]);
                    //    return operationResult;
                    //}
                    if (calibrationHelper.GetType(calFiles[i, j], SFTHelper.Enums.EnumCALTarget.Module) == SFTHelper.Enums.EnumCALType.Unkown)
                    {
                        operationResult.Status = false;
                        operationResult.Message = string.Format(MultiLanguage.GetNames(Name, "FileForTimeCodeNotFound"), sn[i, j]);
                        return operationResult;
                    }
                    FileInfo fileInfo = new FileInfo(calFiles[i, j]);
                    //File.Copy(calFiles[i, j], tmpPath + "/" + fileInfo.Name, true);
                    //calFiles[i, j] = tmpPath + "/" + fileInfo.Name;
                    string fileNameNewWithExt = System.IO.Path.GetFileNameWithoutExtension(calFiles[i, j]) + fileInfo.Extension;
                    string newFile = System.IO.Path.Combine(tmpPath, fileNameNewWithExt);
                    if (calibrationHelper.ToDat(calFiles[i, j], newFile, SFTHelper.Enums.EnumCALTarget.Module) == false)
                    {
                        operationResult.Status = false;
                        operationResult.Message = MultiLanguage.GetNames(Name, "TranslateZdat2DatFailed");
                        return operationResult;
                    }
                }
            }

            string[,] datFiles = new string[calFiles.GetLength(0), calFiles.GetLength(1)];
            for (int i = 0; i < datFiles.GetLength(0); i++)
            {
                for (int j = 0; j < datFiles.GetLength(1); j++)
                {
                    datFiles[i, j] = System.IO.Path.Combine(tmpPath, System.IO.Path.GetFileNameWithoutExtension(calFiles[i, j]) + ".dat");
                }
            }
            string allSource = GetModuleCalFolder(firstSn) + "/All_Source";
            if (System.IO.Directory.Exists(allSource) == false) System.IO.Directory.CreateDirectory(allSource);
            string outFile = allSource + " /" + sn[0, 0] + ".sdat";
            //if (!calibrationProcess.MergeFile(moduleWidth, moduleHeight, modulePixelWidth, modulePixelHeight, datFiles, outFile))
            if (!calibrationHelper.Merge(datFiles, outFile))
            {
                operationResult.Status = false;
                operationResult.Message = MultiLanguage.GetNames(Name, "MergeCalibrationDataFailed");
                return operationResult;
            }

            operationResult.strData = outFile;
            return operationResult;
        }

        //nType:0模组数据，1箱体数据
        Structs.OperationResult ReadCalibrationDataFormFolder(int devNum, string ip, string path, string saveDataPath)
        {
            Structs.OperationResult operationResult = null;
            operationResult = ReadModulesCalibrationDataFromFolder(devNum, path, _unitType.ModuleWidth, _unitType.ModuleHeight, _unitType.ModulePixelWidth, _unitType.ModulePixelHeight);
            return operationResult;
        }

        Structs.OperationResult TranslateCalibrationDataToSdat(string fileIn, int width, int height, string fileOut)
        {
            Structs.OperationResult operationResult = new Structs.OperationResult();
            operationResult.Status = true;
            CalibrationHelper calibrationHelper = new CalibrationHelper(_unitType.ModuleWidth, _unitType.ModuleHeight, _unitType.ModulePixelWidth, _unitType.ModulePixelHeight);
            //if (calProcess.TranslateData2Sdat(fileIn, width, height, fileOut) == false)
            if (calibrationHelper.ToSDat(fileIn, fileOut, SFTHelper.Enums.EnumCALTarget.Cabinet) == false)
            {
                //读取校正数据失败
                operationResult.Status = false;
                operationResult.Message = MultiLanguage.GetNames(Name, "TranslateDat2SdatFailed");
            }
            return operationResult;
        }

        Structs.OperationResult ChangeCalibrationData(string fileIn, string fileOut, int startGray, StructSeamItem[,] seamItemDatas, SFTHelper.Enums.EnumCALType enumDataType)
        {
            Structs.OperationResult operationResult = new Structs.OperationResult();
            SeamCalibrationHelper seamCalibrationHelper = new SeamCalibrationHelper(startGray, _unitType.ModuleWidth, _unitType.ModuleHeight, _unitType.ModulePixelWidth, _unitType.ModulePixelHeight);
            operationResult.Status = seamCalibrationHelper.ModifyBorder(fileIn, fileOut, seamItemDatas);
            if (operationResult.Status == false)
            {
                //修改校正数据失败
                operationResult.Message = MultiLanguage.GetNames(Name, "ModifyCalibrationFailed");
                operationResult.Status = false;
                return operationResult;
            }
            return operationResult;
        }

        StructModule[] GetChangedModuleAddress(StructSeamItem[,] seamItemDatas, bool isReset)
        {
            List<StructModule> points = new List<StructModule>();
            for (int i = 0; i < seamItemDatas.GetLength(0); i++)
            {
                for (int j = 0; j < seamItemDatas.GetLength(1); j++)
                {
                    byte position = (byte)((i + 1) % 2);
                    StructSeamItem item = seamItemDatas[i, j];
                    if (isReset)
                    {
                        points.Add(new StructModule(j + 1, i + 1, position));
                    }
                    else
                    {
                        if (item.Left == 100 && item.Top == 100 && item.Right == 100 && item.Bottom == 100) continue;
                        points.Add(new StructModule(j + 1, i + 1, position));
                    }
                }
            }
            return points.ToArray();
        }

        Structs.OperationResult WriteModuleFiles(string ip, int devNum, string timeCode, string calFile, StructModule[] changedModuleAddress, string targetFolder)
        {
            string tmpSdataFileName = System.IO.Path.GetFileName("All.sdat");
            string tmpSdataFile = System.IO.Path.Combine(targetFolder, tmpSdataFileName);
            Structs.OperationResult operationResult = TranslateCalibrationDataToSdat(calFile, _unitType.GetSize().Width, _unitType.GetSize().Height, tmpSdataFile);
            if (!operationResult.Status)
            {
                operationResult.Message = MultiLanguage.GetNames(Name, "OutputSdatFileFailed");
                operationResult.Status = false;
                return operationResult;
            }

            CalibrationHelper calibrationHelper = new CalibrationHelper(_unitType.ModuleWidth, _unitType.ModuleHeight, _unitType.ModulePixelWidth, _unitType.ModulePixelHeight);
            if (calibrationHelper.Divide(tmpSdataFile, targetFolder) == false)
            {
                operationResult.Message = MultiLanguage.GetNames(Name, "DivideFileFailed");
                operationResult.Status = false;
                return operationResult;
            }
            for (int i = 0; i < _unitType.ModuleHeight; i++)
            {
                for (int j = 0; j < _unitType.ModuleWidth; j++)
                {

                    string outzFile = targetFolder + "/" + i + "_" + j + ".zdat";
                    bool isOk = calibrationHelper.ToZDat(targetFolder + "/" + i + "_" + j + ".dat", outzFile, SFTHelper.Enums.EnumCALTarget.Module);
                    if (!isOk)
                    {
                        operationResult.Message = MultiLanguage.GetNames(Name, "ModuleFileData2ZdatFailed");
                        operationResult.Status = false;
                        return operationResult;
                    }
                }
            }

            foreach (var item in changedModuleAddress)
            {
                string file = System.IO.Path.Combine(targetFolder, string.Format("{0}_{1}.zdat", item.Y - 1, item.X - 1));
                ushort addr = GetMBAddr(item.X, item.Y);
                string modulePos = item.Position == 0 ? MultiLanguage.GetNames(Name, "upmodule") : MultiLanguage.GetNames(Name, "bottommodule");
                Log(ip, String.Format(MultiLanguage.GetNames(Name, "WriteModuleData"), item.Y, item.X, modulePos));
                Thread.Sleep(200);
                int isOk = _baseCommunication.tlw_WriteCalibrationFile(devNum, addr, 0, item.Position, _unitType.ModulePixelWidth, _unitType.ModulePixelHeight, file);
                operationResult.Status = isOk == 0 ? true : false;
                if (!operationResult.Status)
                {
                    operationResult.Message = string.Format(MultiLanguage.GetNames(Name, "WriteModuleDataFailed"), item.Y, item.X, modulePos);
                    operationResult.Status = false;
                    return operationResult;
                }
                Log(ip, String.Format(MultiLanguage.GetNames(Name, "WriteModuleDataSuccess"), item.Y, item.X, modulePos));
            }
            //_baseCommunication.SetRegister(devNum, cmdAddr, 143, 1);
            operationResult.Status = true;
            return operationResult;
        }

        void ExecuteCommand(string ctrName, string ip, string exePath)
        {
            if (!_threadList.ContainsKey(ctrName))
            {
                Thread thread = new Thread(new ParameterizedThreadStart((object param) =>
                {
                    ThreadParam arg = param as ThreadParam;
                    Structs.OperationResult operationResult = new Structs.OperationResult();
                    int width = arg.UnitType.ModuleWidth * arg.UnitType.ModulePixelWidth;
                    int height = arg.UnitType.ModuleHeight * arg.UnitType.ModulePixelHeight;
                    int modulePixelWidth = arg.UnitType.ModulePixelWidth;
                    int modulePixelHeight = arg.UnitType.ModulePixelHeight;
                    bool isReset = arg.ResetData;
                    string fileRead = "";
                    string fileWrite = "";

                    int devNum = _baseCommunication.OpenUDP(arg.IP);
                    operationResult.DeviceNumber = devNum;
                    if (!_devIP.ContainsKey(devNum))
                    {
                        _devIP.Add(devNum, arg.IP);
                    }
                    string timeCode = "";
                    try
                    {
                        if (!isDebugMode)
                        {
                            byte[] sz = new byte[1024];
                            int result = _baseCommunication.tlw_ReadSerialNumber(devNum, GetMBAddr(1, 1), 0, 0, sz);
                            string modulePos = 0 == 0 ? MultiLanguage.GetNames(Name, "upmodule") : MultiLanguage.GetNames(Name, "bottommodule");
                            if (SNHelper.AnalayzeSN(sz, out timeCode) == false)
                            {
                                //读取时间码失败
                                Log(ip, string.Format(MultiLanguage.GetNames(Name, "ReadTimeCodeFailed"), 1, 1, modulePos));
                                operationResult.Status = false;
                                SetCommandStatus(arg.IP, false);
                                return;
                            }
                        }
                        else
                        {
                            timeCode = "0_0";
                        }

                        string readFolder = System.IO.Path.Combine(GetModuleCalFolder(timeCode), "Read");
                        if (System.IO.Directory.Exists(readFolder) == false) System.IO.Directory.CreateDirectory(readFolder);
                        string tmpRead = System.IO.Path.Combine(readFolder, "All.dat");
                        if (arg.ReadCalFrom == 0)
                        {
                            //从箱体读取数据
                            Log(ip, MultiLanguage.GetNames(Name, "ReadCalibrationDataFromCabinet"));
                            Thread.Sleep(200);
                            operationResult = ReadCalibrationDataFromCabinet(operationResult.DeviceNumber, arg.IP, tmpRead);
                        }
                        else
                        {
                            //从文件夹读取数据
                            Log(ip, MultiLanguage.GetNames(Name, "ReadCalibrationDataFromFolder"));
                            operationResult = ReadCalibrationDataFormFolder(devNum, arg.IP, arg.LocalCalDataPath, GetModuleCalFolder(timeCode));
                            if (!operationResult.Status)
                            {
                                //读取校正数据失败
                                Log(arg.IP, operationResult.Message);
                                SetCommandStatus(arg.IP, false);
                                return;
                            }
                            tmpRead = operationResult.strData;
                        }
                        if (!operationResult.Status)
                        {
                            //读取校正数据失败
                            Log(arg.IP, MultiLanguage.GetNames(Name, "ReadCalibrationFailed"));
                            SetCommandStatus(arg.IP, false);
                            return;
                        }
                        else
                        {
                            Log(arg.IP, MultiLanguage.GetNames(Name, "ReadCalibrationSuccess"));
                        }

                        string tmpSdatPath = System.IO.Path.GetDirectoryName(tmpRead);
                        string tmpSdat = System.IO.Path.Combine(tmpSdatPath, "All_Translate.sdat");

                        operationResult = TranslateCalibrationDataToSdat(tmpRead, width, height, tmpSdat);
                        if (!operationResult.Status)
                        {
                            Log(arg.IP, operationResult.Message);
                            SetCommandStatus(ip, false);
                            return;
                        }

                        //保存原始数据
                        CalibrationHelper calibrationHelper = new CalibrationHelper(arg.UnitType.ModuleWidth, arg.UnitType.ModuleHeight, arg.UnitType.ModulePixelWidth, arg.UnitType.ModulePixelHeight);
                        calibrationHelper.GetExtName(tmpRead, out string extName, SFTHelper.Enums.EnumCALTarget.Cabinet);
                        fileRead = System.IO.Path.Combine(LocalCalFolder, "read" + timeCode + extName);
                        File.Copy(tmpRead, fileRead, true);

                        //TODO:修改
                        SFTHelper.Enums.EnumCALType dataType = calibrationHelper.GetType(tmpRead, SFTHelper.Enums.EnumCALTarget.Cabinet);
                        fileWrite = System.IO.Path.Combine(LocalCalFolder, "write" + timeCode + "." + extName);
                        operationResult = ChangeCalibrationData(tmpSdat, fileWrite, arg.StartGray, arg.SeamData, dataType);
                        if (!operationResult.Status)
                        {
                            //读取时间码失败
                            Log(ip, operationResult.Message);
                            SetCommandStatus(ip, false);
                            return;
                        }

                        //TODO:写入

                        Log(ip, MultiLanguage.GetNames(Name, "WriteCalibrationData"));
                        //operationResult = _baseCommunication.MainBoardUploadCalibrationFile(devNum, cmdAddr, uType.ModulePixelWidth, uType.ModulePixelHeight, fileWrite);

                        StructModule[] changedModuleAddress = GetChangedModuleAddress(arg.SeamData, isReset);
                        string currentModuleFolderToWrite = GetModuleCalFolder(timeCode) + "/WriteFolder";
                        if (System.IO.Directory.Exists(currentModuleFolderToWrite) == false) System.IO.Directory.CreateDirectory(currentModuleFolderToWrite);
                        if (!isDebugMode)
                        {
                            operationResult = WriteModuleFiles(ip, devNum, timeCode, fileWrite, changedModuleAddress, currentModuleFolderToWrite);
                        }
                        else
                        {
                            operationResult.Status = true;
                        }
                        if (!operationResult.Status)
                        {
                            //写入校正数据失败
                            Log(arg.IP, operationResult.Message);
                            SetCommandStatus(arg.IP, false);
                            return;
                        }
                        else
                        {
                            Log(arg.IP, MultiLanguage.GetNames(Name, "WriteCalibrationDataSuccess"));
                            SetCommandStatus(arg.IP, true);

                            //File.Copy(fileWrite, fileRead, true);
                        }
                    }
                    finally
                    {
                        Thread.Sleep(200);
                        Directory.Delete(GetModuleCalFolder(timeCode), true);
                        _baseCommunication.Sys_CloseDev(devNum);
                        _devIP.Remove(devNum);
                        _threadList.Remove(ctrName);
                    }
                }));
                thread.IsBackground = true;
                _threadList.Add(ctrName, thread);
                ThreadParam threadParam = new ThreadParam()
                {
                    ControlName = ctrName,
                    IP = ip,
                    SeamData = ViewForm.SeamData.Clone() as StructSeamItem[,],
                    StartGray = (byte)_interfaceData.StarGray,
                    UnitType = _unitType,
                    WorkPath = exePath,
                    LocalCalDataPath = txtDataLocation.Text,
                    LocaCalFileType = cbDataType.SelectedIndex,
                    ReadCalFrom = cbdataPos.SelectedIndex,
                    ResetData = ckReset.Checked
                };
                _threadList[ctrName].Start(threadParam);
            }
        }

        void ExecuteDisplayMode(string ctrName, string ip, int mode)
        {
            if (!_threadList.ContainsKey(ctrName))
            {
                Thread thread = new Thread(new ParameterizedThreadStart((object param) =>
                {
                    if (_baseCommunication == null)
                    {
                        Log("", "basenull");
                        return;
                    }
                    if (ip == null)
                    {
                        Log("", "ip"); return;
                    }
                    int devNum = _baseCommunication.OpenUDP(ip);
                    Structs.OperationResult operationResult = new Structs.OperationResult();
                    operationResult.DeviceNumber = devNum;
                    operationResult.Status = true;
                    if (!operationResult.Status)
                    {
                        //设备打开失败
                        Log(ip, MultiLanguage.GetNames(Name, "OpenDeviceFailed"));
                        return;
                    }
                    else
                    {
                        Log(ip, MultiLanguage.GetNames(Name, "OpenDeviceSuccess"));
                    }
                    if (!_devIP.ContainsKey(devNum))
                    {
                        _devIP.Add(devNum, ip);
                    }
                    try
                    {
                        //operationResult = _baseCommunication.DisplaySwitchRunningMode(devNum, cmdAddr, enumRunningMode, enumColorTestMode);
                        //operationResult.Status = _baseCommunication.tlw_WriteRegister(devNum, GetMBAddr(241, 241), 0, 0, 0, (byte)enumColorTestMode, true) == 0 ? true : false;
                        operationResult.Status = _baseCommunication.tlw_SetDisplayMode(devNum, GetMBAddr(241, 241), 0, (byte)mode) == 0 ? true : false;
                        if (!operationResult.Status)
                        {
                            Log(ip, MultiLanguage.GetNames(Name, "SwitchDisplayModeFailed"));
                            operationResult.Status = false;
                            SetCommandStatus(ip, false);
                            return;
                        }
                        Log(ip, MultiLanguage.GetNames(Name, "SwitchDisplayModeSuccess"));
                        operationResult.Status = true;
                        SetCommandStatus(ip, true);
                    }
                    finally
                    {
                        _baseCommunication.Sys_CloseDev(devNum);
                        _devIP.Remove(devNum);
                        _threadList.Remove(ctrName);
                    }
                }));
                thread.IsBackground = true;
                _threadList.Add(ctrName, thread);
                _threadList[ctrName].Start(new object[] { });
            }
        }

        void CloseAllDevice()
        {
            //_devIP
            foreach (var item in _devIP)
            {
                _baseCommunication.Sys_CloseDev(item.Key);
            }
        }
        #endregion

        #region 事件
        private void tbGray_Scroll(object sender, EventArgs e)
        {
            numGray.Value = tbGray.Value;
            RefreshViewForm();
        }

        private void numGray_ValueChanged(object sender, EventArgs e)
        {
            tbGray.Value = (int)numGray.Value;
            RefreshViewForm();
        }

        private void ckShowBorder_CheckedChanged(object sender, EventArgs e)
        {
            RefreshViewForm();
        }

        private void ckShowPercent_CheckedChanged(object sender, EventArgs e)
        {
            RefreshViewForm();
        }

        private void tbAdjustPercent_Scroll(object sender, EventArgs e)
        {
            numAdjustPercent.Value = (decimal)(tbAdjustPercent.Value / 10 * 1.0f);
            SetSelectedBorderPercent((float)numAdjustPercent.Value);
            RefreshViewForm();
        }

        private void numAdjustPercent_ValueChanged(object sender, EventArgs e)
        {
            tbAdjustPercent.Value = (int)numAdjustPercent.Value * 10;
            SetSelectedBorderPercent((float)numAdjustPercent.Value);
            RefreshViewForm();
        }


        private void UserIPCommand_Click(object sender, EventArgs e)
        {
            SetIPCommandSelected(sender as UserIPCommand);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            UnitTypeV2 uType = GetSelectedPanelType();
            _unitType.ModuleWidth = uType.ModuleWidth;
            _unitType.ModuleHeight = uType.ModuleHeight * 2;
            _unitType.ModulePixelWidth = uType.ModulePixelWidth;
            _unitType.ModulePixelHeight = uType.ModulePixelHeight;
            _unitType.MainName = uType.MainName;
            _unitType.SubName = uType.SubName;
            _unitType.Title = uType.Title;
            _unitType.Serial = uType.Serial;
            _unitType.Bit = uType.Bit;
            LocalCalFolder = System.IO.Path.Combine(Path, "CAL");
            if (System.IO.Directory.Exists(LocalCalFolder) == false) System.IO.Directory.CreateDirectory(LocalCalFolder);

            MultiLanguage.GetNames(this, lang, Path + @"\Language");

            ChangeUILanguage();

            string exePath = BasePath;

            string readPath = System.IO.Path.Combine(Path, "CAL");
            if (!Directory.Exists(readPath))
            {
                Directory.CreateDirectory(readPath);
            }

            InitInterfaceData();

            _baseCommunication = CreateCommunication();

        }

        private void frmMain_Move(object sender, EventArgs e)
        {
            //if (ViewForm != null && !ViewForm.IsDisposed && ViewForm.Visible && !ckLockViewForm.Checked)
            //{
            //    ViewForm.Location = new Point(this.Location.X - ViewForm.Width, this.Location.Y);
            //}
        }

        private void UserIPCommand_SendButtonClick(object sender, EventArgs e)
        {
            string exePath = Path;
            string ctrName = (sender as UserIPCommand).Name;
            string ip = (sender as UserIPCommand).IP;
            if ((sender as UserIPCommand).Tag3.ToString() == "0")
            {
                (sender as UserIPCommand).ButtonText = MultiLanguage.GetNames(Name, "Stop");
                (sender as UserIPCommand).ButtonViewFormEnable = false;
                (sender as UserIPCommand).ButtonWorkModeEnable = false;
                (sender as UserIPCommand).Tag3 = 1;
                (sender as UserIPCommand).BackColor = SystemColors.Control;
            }
            else
            {
                Stop((sender as UserIPCommand));
                (sender as UserIPCommand).ButtonText = MultiLanguage.GetNames(Name, "Stoping");
                (sender as UserIPCommand).ButtonApplyEnable = false;
                (sender as UserIPCommand).ButtonViewFormEnable = false;
                (sender as UserIPCommand).ButtonWorkModeEnable = false;
                (sender as UserIPCommand).Tag3 = 0;
                (sender as UserIPCommand).BackColor = SystemColors.Control;
            }
            ExecuteCommand(ctrName, ip, exePath);
        }

        private void UserIPCommand_SendWorkModeButtonClick(object sender, UserIPCommand.EventArgsWorkMode argsWorkMode)
        {
            int mode = (int)argsWorkMode.Mode;
            UserIPCommand userIPCommand = sender as UserIPCommand;
            string ctrName = userIPCommand.Name;
            string ip = userIPCommand.IP;
            userIPCommand.ButtonText = MultiLanguage.GetNames(Name, "Stop");
            userIPCommand.Tag3 = 1;
            userIPCommand.BackColor = SystemColors.Control;
            ExecuteDisplayMode(ctrName, ip, argsWorkMode.Mode);

        }

        private void UserIPCommand_ViewFormButtonClick(object sender, EventArgs e)
        {
            //if (GetCommunicationType().StartIPAddress == "255.255")
            //{
            //    frmDataAnalize frmDataAnalize = new frmDataAnalize();
            //    frmDataAnalize.CabinetSize = GetCabinetSize();
            //    frmDataAnalize.exePath = BasePath;
            //    frmDataAnalize.CurrentPath = Path;
            //    frmDataAnalize.ShowDialog();
            //    return;
            //}
            if (ViewForm != null && !ViewForm.IsDisposed)
            {
                if (ViewForm.Visible == false) ViewForm.Visible = true;
                ViewForm.BringToFront();
            }
        }


        private void ViewForm_SelectedBorderChanged(object sender, frmPreview.EventArgEx e)
        {
            UserIPCommand iPCommand = GetSelectedIPCommand();
            if (iPCommand != null)
            {
                iPCommand.Tag2 = e.SelectedBorder;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.ShiftKey)
            {
            }
            if (keyData == Keys.ControlKey)
            {
            }

            if (keyData == Keys.Up)
            {
                if (ViewForm != null)
                {
                    ViewForm.Activate();
                }
            }
            if (keyData == Keys.Down)
            {
                if (ViewForm != null)
                {
                    ViewForm.Activate();
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ckLockViewForm_CheckedChanged(object sender, EventArgs e)
        {
            if (ViewForm != null) ViewForm.Lock = ckLockViewForm.Checked;
        }

        private void _baseCommunication_ProgressChangedMonitorEvent(object sender, TLWCommunication.Events.ProgressChangedMonitorEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => { _baseCommunication_ProgressChangedMonitorEvent(sender, e); }));
            }
            else
            {
                int devNum = e.DeviceNumber;
                if (_devIP.ContainsKey(devNum))
                {
                    string ip = _devIP[devNum];
                    UserIPCommand userIPCommand = GetIPCommand(ip);
                    if (userIPCommand != null)
                    {
                        userIPCommand.Progress = e.Percent;
                    }
                }
            }
        }

        private void _baseCommunication_DataMonitorEvent(object sender, TLWCommunication.Events.DataMonitorEventArgs e)
        {
            //if (!e.IsReceived)
            //{
            //    WriteLine("发送:" + BitConverter.ToString(e.Data).Replace("-", " "), true);
            //}
            //else
            //{
            //    WriteLine("收到:" + BitConverter.ToString(e.Data).Replace("-", " "), true);
            //}
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            ViewForm.Visible = true;
        }

        private void frmMain_Deactivate(object sender, EventArgs e)
        {
        }

        private void btnChoseDataLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog(this) == DialogResult.Cancel) return;
            txtDataLocation.Text = folderBrowser.SelectedPath;
        }

        #endregion


        private void btnResetViewForm_Click(object sender, EventArgs e)
        {
            //if (GetCommunicationType().StartIPAddress == "255.255")
            //{
            //    frmDataAnalize frmDataAnalize = new frmDataAnalize();
            //    frmDataAnalize.CabinetSize = GetCabinetSize();
            //    frmDataAnalize.exePath = BasePath;
            //    frmDataAnalize.CurrentPath = Path;
            //    frmDataAnalize.ShowDialog();
            //    return;
            //}
            if (ViewForm != null && !ViewForm.IsDisposed)
            {
                if (ViewForm.Visible == false) ViewForm.Visible = true;
                ViewForm.BringToFront();
            }
        }

        private void btnInitIpList_Click(object sender, EventArgs e)
        {
            if (_threadList.Count != 0)
            {
                MessageBox.Show(this, MultiLanguage.GetNames(Name, "WaitTaskComplete"));
                return;
            }
            ResetIPList();
            InitViewForm();
        }

        private void frmMain_UnitTypeChanged(UnitTypeV2 unitType)
        {
            _unitType.ModuleWidth = unitType.ModuleWidth;
            _unitType.ModuleHeight = unitType.ModuleHeight * 2;
            _unitType.ModulePixelWidth = unitType.ModulePixelWidth;
            _unitType.ModulePixelHeight = unitType.ModulePixelHeight;
            _unitType.MainName = unitType.MainName;
            _unitType.SubName = unitType.SubName;
            _unitType.Title = unitType.Title;
            _unitType.Serial = unitType.Serial;
            _unitType.Bit = unitType.Bit;
            _baseCommunication = CreateCommunication();
        }

        private DialogResult frmMain_FormClosing()
        {
            try
            {
                if (_threadList.Count != 0)
                {
                    MessageBox.Show(this, MultiLanguage.GetNames(Name, "WaitTaskComplete"));
                    return DialogResult.No;
                }

                _interfaceData.Background = tbGray.Value;
                _interfaceData.ShowBorder = ckShowBorder.Checked;
                _interfaceData.ShowPercentValue = ckShowPercent.Checked;
                _interfaceData.LockViewForm = ckLockViewForm.Checked;
                _interfaceData.DataLocation = cbdataPos.SelectedIndex;
                _interfaceData.DataType = cbDataType.SelectedIndex;
                _interfaceData.DataType = cbDataType.SelectedIndex;
                _interfaceData.LocalDataPath = txtDataLocation.Text;
                if (ViewForm == null)
                {
                    _interfaceData.ViewFormPosition = new Point(0, 0);
                }
                else
                {
                    _interfaceData.ViewFormPosition = ViewForm.Location;
                }
                string cfgFile = System.IO.Path.Combine(Path, _cfgFileName);
                SerializeHelper.SerializeToXml(_interfaceData, cfgFile);

                foreach (var item in _devIP)
                {
                    _baseCommunication.Sys_CloseDev(item.Key);
                }

                foreach (var item in _threadList)
                {
                    if (item.Value.IsAlive) item.Value.Abort();
                }
                _devIP.Clear();
                _threadList.Clear();
                //if (ViewForm != null && !ViewForm.IsDisposed)
                //{
                //    ViewForm.Close();
                //}
            }
            catch (Exception)
            {

            }
            return DialogResult.Yes;
        }

        private void btnVideo_Click(object sender, EventArgs e)
        {
            if (_threadList.Count != 0)
            {
                MessageBox.Show(this, MultiLanguage.GetNames(Name, "WaitTaskComplete"));
                return;
            }

            int mode = int.Parse((sender as Button).Tag.ToString());

            foreach (var item in flowIPList.Controls)
            {
                UserIPCommand userIPCommand = item as UserIPCommand;
                string ctrName = userIPCommand.Name;
                string ip = userIPCommand.IP;
                userIPCommand.ButtonText = MultiLanguage.GetNames(Name, "Stop");
                userIPCommand.ButtonViewFormEnable = false;
                userIPCommand.ButtonApplyEnable = false;
                userIPCommand.ButtonWorkModeEnable = false;
                userIPCommand.Tag3 = 1;
                userIPCommand.BackColor = SystemColors.Control;

                ExecuteDisplayMode(ctrName, ip, mode);
                Thread.Sleep(50);
            }
        }

        private void cbdataPos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbdataPos.SelectedIndex == 0)
            {
                ckReset.Enabled = false;
                ckReset.Checked = false;
            }
            else if (cbdataPos.SelectedIndex == 1)
            {
                ckReset.Enabled = true;
            }
        }
    }
}
