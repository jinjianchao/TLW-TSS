#region << 注释 >>
/************************************************************************
*文件名： RegisterHelper
*创建人： JIN
*创建时间：2019/6/4 17:35:44
*描述：
*=======================================================================
*修改时间：2019/6/4 17:35:44
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace TLWController.Helper
{
    public class RegisterSpectialItem
    {
        public string RegisterAddress { get; set; }
        public byte StartBit { get; set; }
        public byte StopBit { get; set; }
        public byte Value { get; set; }
    }
    /// <summary>
    /// 寄存器项
    /// </summary>
    public class RegisterItem
    {
        public string RegisterAddress { get; set; }
        public string RedAddress { get; set; }
        public string GreenAddress { get; set; }
        public string BlueAddress { get; set; }
        public byte RedValue { get; set; }
        public byte GreenValue { get; set; }
        public byte BlueValue { get; set; }
        public byte StartBit { get; set; }
        public byte StopBit { get; set; }
        public string Description { get; set; }
        public string ChineseDescription { get; set; }
        public string EnglishDescription { get; set; }
        public String Send { get; set; } = "Send";
    }

    public class Register
    {
        /// <summary>
        /// 是否调试模式 true：是,断电丢失，false:否，断电不丢失
        /// </summary>
        public bool IsDebug { get; set; }

        /// <summary>
        /// 刷新率
        /// </summary>
        public byte RefreshRate { get; set; }

        public List<RegisterItem> RegisterItemList { get; set; }

        public RegisterSpectialItem SpecialRegister { get; set; }

        public Register()
        {
            RegisterItemList = new List<RegisterItem>();
        }
    }

    public class RegisterHelper
    {
        #region 说明
        //说明：
        //regAddressFile：地址配置文件.格式如下：
        //第一行：序号 刷新率    是否调试模式(0:否，1：是)
        //第二行：//序号 起始位 结束位 特殊地址 特殊值
        //第三行开始往下：
        //序号    FPGA红色地址    FPGA绿色地址    FPGA蓝色地址    恒流源地址   起始位 结束位  红色值     绿色纸     蓝色值     说明     中文说明    英文说明
        #endregion

        public static Register LoadRegister(string file)
        {
            Register reg = new Register();

            if (!File.Exists(file))
            {
                return null;
            }

            using (TextReader reader = new StreamReader(file, Encoding.UTF8))
            {
                int lineIndex = 0;
                string lineData = string.Empty;
                List<RegisterItem> RegisterItemList = new List<RegisterItem>();
                while ((lineData = reader.ReadLine()) != null)
                {
                    string[] data = lineData.Split('\t');
                    if (lineIndex == 0)
                    {
                        if (data.Length != 3)
                        {
                            return null;
                        }

                        if (!byte.TryParse(data[1], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte refreshRate))
                        {
                            return null;
                        }
                        reg.RefreshRate = refreshRate;

                        if (!bool.TryParse(data[2], out bool isDebug))
                        {
                            return null;
                        }
                        reg.IsDebug = isDebug;
                    }
                    else if (lineIndex == 1)
                    {
                        if (data.Length != 5)
                        {
                            return null;
                        }
                        RegisterSpectialItem specialFPGA = new RegisterSpectialItem();

                        if (!byte.TryParse(data[1], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte startBit))
                        {
                            return null;
                        }
                        specialFPGA.StartBit = startBit;

                        if (!byte.TryParse(data[2], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte endBit))
                        {
                            return null;
                        }
                        specialFPGA.StopBit = endBit;
                        specialFPGA.RegisterAddress = data[3];
                        specialFPGA.Value = byte.Parse(data[4]);
                        reg.SpecialRegister = specialFPGA;
                    }
                    else
                    {
                        RegisterItem registerItem = new RegisterItem();
                        if (data.Length != 13)
                        {
                            return null;
                        }
                        UInt16 fpgaAddress = 0;
                        if (!UInt16.TryParse(data[1], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out fpgaAddress))
                        {
                            return null;
                        }
                        registerItem.RedAddress = data[1];

                        if (!UInt16.TryParse(data[2], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out fpgaAddress))
                        {
                            return null;
                        }
                        registerItem.GreenAddress = data[2];

                        if (!UInt16.TryParse(data[3], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out fpgaAddress))
                        {
                            return null;
                        }
                        registerItem.BlueAddress = data[3];

                        byte regAddress = 0;
                        if (!byte.TryParse(data[4], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out regAddress))
                        {
                            return null;
                        }
                        registerItem.RegisterAddress = data[4];

                        if (!byte.TryParse(data[5], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte startBit))
                        {
                            return null;
                        }
                        registerItem.StartBit = startBit;

                        if (!byte.TryParse(data[6], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte endBit))
                        {
                            return null;
                        }
                        registerItem.StopBit = endBit;

                        if (!byte.TryParse(data[7], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte redValue))
                        {
                            return null;
                        }
                        registerItem.RedValue = redValue;

                        if (!byte.TryParse(data[8], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte greenValue))
                        {
                            return null;
                        }
                        registerItem.GreenValue = greenValue;

                        if (!byte.TryParse(data[9], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte blueValue))
                        {
                            return null;
                        }
                        registerItem.BlueValue = blueValue;
                        registerItem.Description = data[10];
                        registerItem.ChineseDescription = data[11];
                        registerItem.EnglishDescription = data[12];
                        reg.RegisterItemList.Add(registerItem);
                    }
                    lineIndex++;
                }
            }
            return reg;
        }

        public static void SavevRegister(Register register, string file)
        {
            using (TextWriter writer = new StreamWriter(file))
            {
                int cx = 0;
                writer.WriteLine($"{cx}\t{register.RefreshRate}\t{register.IsDebug}");
                cx++;
                writer.WriteLine($"{cx}\t{register.SpecialRegister.StartBit}\t{register.SpecialRegister.StopBit}\t{register.SpecialRegister.RegisterAddress}\t{register.SpecialRegister.Value}");
                cx++;
                foreach (var item in register.RegisterItemList)
                {
                    //序号    FPGA红色地址    FPGA绿色地址    FPGA蓝色地址    恒流源地址   起始位 结束位  红色值     绿色纸     蓝色值     说明     中文说明    英文说明
                    writer.WriteLine($"{cx}\t{item.RedAddress}\t{item.GreenAddress}\t{item.BlueAddress}\t{item.RegisterAddress}\t{item.StartBit}\t{item.StopBit}\t{item.RedValue}\t{item.GreenValue}\t{item.BlueValue}\t{item.Description}\t{item.ChineseDescription}\t{item.EnglishDescription}");
                    cx++;
                }
            }

        }
    }
}
