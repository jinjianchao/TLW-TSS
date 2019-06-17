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
using TLWController.Extentions;

namespace TLWController.Helper
{
    public class RegisterSpectialItem
    {
        public int RegisterAddress { get; set; }
        public byte StartBit { get; set; }
        public byte StopBit { get; set; }
        public byte Value { get; set; }
    }
    /// <summary>
    /// 寄存器项
    /// </summary>
    public class RegisterItem
    {
        public bool IsSelected { get; set; }
        public string RegisterAddress { get; set; }
        public string RedAddress { get; set; }
        public string GreenAddress { get; set; }
        public string BlueAddress { get; set; }
        public string RedValue { get; set; }
        public string GreenValue { get; set; }
        public string BlueValue { get; set; }
        public byte StartBit { get; set; }
        public byte StopBit { get; set; }
        public string Description { get; set; }
        public string Offset { get; set; }
        public string ChineseDescription { get; set; }
        public string EnglishDescription { get; set; }
        public String Send { get; set; } = "Send";
        public byte MinValue { get; set; }
        public byte MaxValue { get; set; }
    }

    public class Register
    {
        /// <summary>
        /// 是否调试模式 true：是,断电丢失，false:否，断电不丢失
        /// </summary>
        public bool IsDebug { get; set; }

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
        //序号    FPGA红色地址    FPGA绿色地址    FPGA蓝色地址    恒流源地址   起始位 结束位    最小值   最大值   红色值     绿色纸     蓝色值  偏移量   说明     中文说明    英文说明
        #endregion

        private static int Reg2055StartAddr = 0x12 * 2;

        public static byte[] Data { get; set; }

        static RegisterHelper()
        {
            Data = new byte[1024];
        }

        public static Register Load2055Register(string file)
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
                        if (!int.TryParse(data[3], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int addr))
                        {
                            return null;
                        }
                        specialFPGA.RegisterAddress = addr;
                        specialFPGA.Value = byte.Parse(data[4]);
                        reg.SpecialRegister = specialFPGA;
                    }
                    else
                    {
                        RegisterItem registerItem = new RegisterItem();
                        if (data.Length != 16)
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

                        if (!byte.TryParse(data[7], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte minValue))
                        {
                            return null;
                        }
                        registerItem.MinValue = minValue;

                        if (!byte.TryParse(data[8], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte maxValue))
                        {
                            return null;
                        }
                        registerItem.MaxValue = maxValue;

                        //if (!byte.TryParse(data[9], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte redValue))
                        //{
                        //    return null;
                        //}
                        //registerItem.RedValue = redValue;
                        registerItem.RedValue = data[9];

                        //if (!byte.TryParse(data[10], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte greenValue))
                        //{
                        //    return null;
                        //}
                        //registerItem.GreenValue = greenValue;
                        registerItem.GreenValue = data[10];

                        //if (!byte.TryParse(data[11], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte blueValue))
                        //{
                        //    return null;
                        //}
                        //registerItem.BlueValue = blueValue;
                        registerItem.BlueValue = data[11];

                        registerItem.Offset = data[12];
                        registerItem.Description = data[13];
                        registerItem.ChineseDescription = data[14];
                        registerItem.EnglishDescription = data[15];
                        reg.RegisterItemList.Add(registerItem);
                    }
                    lineIndex++;
                }
            }
            return reg;
        }

        public static void Savev2055Register(Register register, string file)
        {
            using (TextWriter writer = new StreamWriter(file))
            {
                int cx = 0;
                writer.WriteLine($"{cx}\t{0}\t{register.IsDebug}");
                cx++;
                writer.WriteLine($"{cx}\t{register.SpecialRegister.StartBit}\t{register.SpecialRegister.StopBit}\t{register.SpecialRegister.RegisterAddress}\t{register.SpecialRegister.Value}");
                cx++;
                foreach (var item in register.RegisterItemList)
                {
                    //序号    FPGA红色地址    FPGA绿色地址    FPGA蓝色地址    恒流源地址   起始位 结束位  最小值   最大值  红色值     绿色纸     蓝色值  偏移量   说明     中文说明    英文说明
                    writer.WriteLine($"{cx}\t{item.RedAddress}\t{item.GreenAddress}\t{item.BlueAddress}\t{item.RegisterAddress}\t{item.StartBit}\t{item.StopBit}\t{item.MinValue}\t{item.MaxValue}\t{item.RedValue}\t{item.GreenValue}\t{item.BlueValue}\t{item.Offset}\t{item.Description}\t{item.ChineseDescription}\t{item.EnglishDescription}");
                    cx++;
                }
            }

        }

        public static void CombinReg2055(List<RegisterItem> reg2055List)
        {
            int position = Reg2055StartAddr;
            for (byte i = 0x12; i < 0x77; i++)
            {
                List<RegisterSpectialItem> reg = GetRegisterItem(reg2055List, i);
                foreach (var item in reg)
                {
                    CombinData(position, item.Value, item.StartBit, item.StopBit);
                }
                position += 2;
            }
        }

        private static void CombinData(int position, byte newData, int startBit, int stopBit)
        {
            string binaryVal = newData.ToBinaryString(stopBit - startBit + 1).Reverse();

            byte[] data1 = new byte[2];
            data1[0] = Data[position];
            data1[1] = Data[position + 1];
            UInt16 uData1 = data1.GetUInt16();
            string binaryVal1 = uData1.ToBinaryString(16).Reverse();
            int index = 0;
            for (int i = startBit; i <= stopBit; i++)
            {
                string str1 = binaryVal.Substring(index++, 1);
                binaryVal1 = binaryVal1.Replace(i, str1);
            }
            binaryVal1 = binaryVal1.Reverse();
            UInt16 data2 = Convert.ToUInt16(binaryVal1, 2);
            byte[] data3 = data2.GetBytes();
            Data[position] = data3[0];
            Data[position + 1] = data3[1];
        }

        private static List<RegisterSpectialItem> GetRegisterItem(List<RegisterItem> reg2055List, byte regAddr)
        {
            List<RegisterSpectialItem> result = new List<RegisterSpectialItem>();
            foreach (var item in reg2055List)
            {
                string strAddr = regAddr.ToString("X2");
                if (item.RedAddress.ToUpper() == strAddr)
                {
                    result.Add(new RegisterSpectialItem()
                    {
                        RegisterAddress = byte.Parse(item.RedAddress, System.Globalization.NumberStyles.HexNumber),
                        StartBit = item.StartBit,
                        StopBit = item.StopBit,
                        Value = item.RedValue.ToByte()
                    });
                }
                if (item.GreenAddress.ToUpper() == strAddr)
                {
                    result.Add(new RegisterSpectialItem()
                    {
                        RegisterAddress = byte.Parse(item.GreenAddress, System.Globalization.NumberStyles.HexNumber),
                        StartBit = item.StartBit,
                        StopBit = item.StopBit,
                        Value = item.GreenValue.ToByte()
                    });
                }
                if (item.BlueAddress.ToUpper() == strAddr)
                {
                    result.Add(new RegisterSpectialItem()
                    {
                        RegisterAddress = byte.Parse(item.BlueAddress, System.Globalization.NumberStyles.HexNumber),
                        StartBit = item.StartBit,
                        StopBit = item.StopBit,
                        Value = item.BlueValue.ToByte()
                    });
                }
            }
            return result;
        }
    }
}
