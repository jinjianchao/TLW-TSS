#region << 注释 >>
/************************************************************************
*文件名： frmMain_ExecuteADCommand
*创建人： JIN
*创建时间：2019/2/27 11:35:06
*描述：
*=======================================================================
*修改时间：2019/2/27 11:35:06
*修改人：
*描述：
************************************************************************/
#endregion

using BaseComm;
using BatchSeamCalibration.Structs;
using Common.Structs;
using LanguageLib;
using PluginLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BatchSeamCalibration
{
    public partial class frmMain
    {
        //nType:0模组数据，1箱体数据
        OperationResult ReadADCalibrationDataFormFolder(UnitTypeV2 cabinetSize, int nType, int devNum, string ip, string path)
        {
            OperationResult operationResult = null;
            if (nType == 0)
            {
                operationResult = ReadModulesCalibrationDataFromFolder(devNum, path, cabinetSize.ModuleWidth, cabinetSize.ModuleHeight, cabinetSize.ModulePixelWidth, cabinetSize.ModulePixelHeight);
            }
            else
            {
                operationResult = ReadCabinetCalibrationDataFromFolder(cabinetSize, devNum, path);
            }
            return operationResult;
        }

        void ExecuteADCommand(string ctrName, string ip, string exePath)
        {
            if (!_threadList.ContainsKey(ctrName))
            {
                Thread thread = new Thread(new ParameterizedThreadStart((object param) =>
                {
                    ThreadParam arg = param as ThreadParam;

                    int width = arg.UnitType.ModuleWidth * arg.UnitType.ModulePixelWidth;
                    int height = arg.UnitType.ModuleHeight * arg.UnitType.ModulePixelHeight;
                    int modulePixelWidth = arg.UnitType.ModulePixelWidth;
                    int modulePixelHeight = arg.UnitType.ModulePixelHeight;
                    bool isReset = arg.ResetData;
                    string fileRead = "";
                    string fileWrite = "";

                    OperationResult operationResult = _baseCommunication.OpenDevice(arg.IP, 0, 8001);
                    if (!operationResult.Status)
                    {
                        //设备打开失败
                        Log(arg.IP, MultiLanguage.GetNames(Name, "OpenDeviceFailed"));
                        return;
                    }
                    else
                    {
                        Log(arg.IP, MultiLanguage.GetNames(Name, "OpenDeviceSuccess"));
                    }
                    int devNum = operationResult.DeviceNumber;
                    if (!_devIP.ContainsKey(devNum))
                    {
                        _devIP.Add(devNum, arg.IP);
                    }
                    try
                    {
                        LEDCmdCordination cmdAddr = new LEDCmdCordination() { groupPortX = 1, groupPortY = 1, cabinetAddressX = 255, cabinetAddressY = 255, moduleAddressX = 1, moduleAddressY = 1 };
                        operationResult = _baseCommunication.LampBoardReadTimecode(devNum, cmdAddr);
                        if (!operationResult.Status)
                        {
                            //读取时间码失败
                            Log(ip, MultiLanguage.GetNames(Name, "ReadTimeCodeFailed"));
                            operationResult.Status = false;
                            SetCommandStatus(arg.IP, false);
                            return;
                        }
                        string timeCode = operationResult.strData;
                        string tmpPath = System.IO.Path.GetTempPath();
                        tmpPath = System.IO.Path.Combine(tmpPath, timeCode);

                        if (Directory.Exists(tmpPath)) Directory.Delete(tmpPath, true);
                        Thread.Sleep(500);
                        Directory.CreateDirectory(tmpPath);
                        while (!Directory.Exists(tmpPath))
                        {
                            Directory.CreateDirectory(tmpPath);
                        }
                        DialogResult dlgResult = DialogResult.Yes;
                        string outFile = "";
                        if (arg.ReadCalFrom == 0 && CheckIsExistLocalCalibrationData(arg.UnitType, operationResult.DeviceNumber, timeCode, System.IO.Path.Combine(arg.WorkPath, "Read"), out outFile))
                        {
                            //从箱体读取数据
                            //本地已经存在时间码对应的校正数据
                            dlgResult = MessageBoxEx(MultiLanguage.GetNames(Name, "IsLoadLocalCalibrationDataFile"), MessageBoxButtons.YesNoCancel);
                            if (dlgResult == DialogResult.Cancel)
                            {
                                Log(ip, MultiLanguage.GetNames(Name, "CanceledByUser"));
                                operationResult.Status = false;
                                SetCommandStatus(arg.IP, false);
                                return;
                            }
                            if (dlgResult == DialogResult.Yes)
                            {
                                arg.LocalCalDataPath = tmpPath;

                                string fileName = System.IO.Path.GetFileName(outFile);
                                string tmpFile = System.IO.Path.Combine(tmpPath, fileName);
                                File.Copy(outFile, tmpFile, true);
                                arg.ReadCalFrom = 1;
                            }
                        }

                        string tmpRead = System.IO.Path.Combine(tmpPath, "read1");
                        if (arg.ReadCalFrom == 0)
                        {
                            //从箱体读取数据
                            Log(ip, MultiLanguage.GetNames(Name, "ReadCalibrationDataFromCabinet"));
                            Thread.Sleep(200);
                            operationResult = ReadCalibrationDataFromCabinet(operationResult.DeviceNumber, arg.IP, arg.UnitType, tmpRead);
                        }
                        else
                        {
                            //从文件夹读取数据
                            Log(ip, MultiLanguage.GetNames(Name, "ReadCalibrationDataFromFolder"));
                            operationResult = ReadADCalibrationDataFormFolder(arg.UnitType, arg.LocaCalFileType, devNum, arg.IP, arg.LocalCalDataPath);
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

                        string tmpSdat = System.IO.Path.Combine(tmpPath, "read1_translate_sdat.sdat");
                        operationResult = TranslateCalibrationDataToSdat(tmpRead, width, height, tmpSdat);
                        if (!operationResult.Status)
                        {
                            Log(arg.IP, operationResult.Message);
                            SetCommandStatus(ip, false);
                            return;
                        }

                        //保存原始数据
                        string extName = GetCalibrationTrueExt(tmpRead, width, height);
                        fileRead = System.IO.Path.Combine(arg.WorkPath, "Read/read" + timeCode + extName);
                        File.Copy(tmpRead, fileRead, true);

                        //TODO:修改
                        CalibrationProcess process = new CalibrationProcess();
                        EnumDataType dataType = process.GetDataType(width, height, tmpRead);
                        fileWrite = System.IO.Path.Combine(arg.WorkPath, "Read/write" + timeCode + "." + extName);
                        operationResult = ChangeCalibrationData(tmpSdat, fileWrite, width, height, modulePixelWidth, modulePixelHeight, arg.StartGray, arg.SeamData, dataType);
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

                        Point[] changedModuleAddress = GetChangedModuleAddress(arg.SeamData, isReset);
                        operationResult = WriteModuleFiles(ip, devNum, timeCode, arg.UnitType, fileWrite, changedModuleAddress, tmpPath);

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

                            File.Copy(fileWrite, fileRead, true);
                        }
                    }
                    finally
                    {
                        _baseCommunication.CloseDevice(devNum);
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
                    SeamData = ViewForm.SeamData.Clone() as SeamItemData[,],
                    StartGray = (byte)_interfaceData.StarGray,
                    UnitType = GetCabinetType(),
                    WorkPath = exePath,
                    LocalCalDataPath = txtDataLocation.Text,
                    LocaCalFileType = cbDataType.SelectedIndex,
                    ReadCalFrom = cbdataPos.SelectedIndex,
                    ResetData = ckReset.Checked
                };
                //_threadList[ctrName].Start(new object[] { ctrName, ip, ViewForm.SeamData.Clone(), _interfaceData.Background, GetCabinetType(), exePath, txtDataLocation.Text, cbdataPos.SelectedIndex, cbDataType.SelectedIndex });
                _threadList[ctrName].Start(threadParam);
            }
        }
    }
}
