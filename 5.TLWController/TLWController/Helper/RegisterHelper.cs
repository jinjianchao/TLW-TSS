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
    /// <summary>
    /// 寄存器颜色
    /// </summary>
    public enum EnumRegColor
    {
        Red,
        Green,
        Blue
    }

    public class RegisterSpectialItem
    {
        public int RegisterAddress { get; set; }
        public byte StartBit { get; set; }
        public byte StopBit { get; set; }
        public byte Value { get; set; }
        /// <summary>
        /// 辅助属性，标识当前寄存器地址代表的颜色
        /// </summary>
        public EnumRegColor Color { get; set; }
        /// <summary>
        /// 辅助属性，标识当前寄存器详细描述信息
        /// </summary>
        public RegisterItem Register { get; set; }
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

        /// <summary>
        /// 2055寄存器
        /// </summary>
        public List<RegisterItem> Register2055ItemList { get; set; }

        /// <summary>
        /// 其他寄存器
        /// </summary>
        public IList<RegisterItem> RegisterOtherItemList { get; set; }

        public RegisterSpectialItem SpecialRegister { get; set; }

        public Register()
        {
            Register2055ItemList = new List<RegisterItem>();
            RegisterOtherItemList = new List<RegisterItem>();
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
            //ushort[] arrDefualt = {0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0001,0x0001,0x0001,0x0000,0x0000,0x0000,0x0000,0x0000, //0 
            //        0x0000,0x0000,0x021F,0x0310,0x0402,0x050F,0x0602,0x0720,0x0820,0x0908,0x0A08,0x0B80,0x0C01,0x0D01,0x0E04,0x0F01, //1
            //        0x1042,0x1121,0x1201,0x1308,0x1400,0x1500,0x1600,0x17F0,0x181F,0x1900,0x1A1F,0x1B10,0x1CD0,0x1D0C,0x1E42,0x1F04, //2
            //        0x2008,0x2101,0x221C,0x2300,0x021F,0x0310,0x0402,0x050F,0x0602,0x0720,0x0820,0x0908,0x0A08,0x0B00,0x0C20,0x0D01, //3
            //        0x0E04,0x0F01,0x1042,0x1121,0x1201,0x1308,0x1400,0x1500,0x1600,0x17F0,0x0602,0x1950,0x1A1F,0x1B10,0x1CD0,0x1D0A, //4
            //        0x1E46,0x1F20,0x2008,0x2101,0x221C,0x2300,0x021F,0x0310,0x0402,0x050F,0x0602,0x0720,0x0820,0x0908,0x0A08,0x0B00, //5
            //        0x0C20,0x0D01,0x0E04,0x0F01,0x1042,0x1121,0x1201,0x1308,0x1400,0x1500,0x1600,0x17F0,0x182F,0x1900,0x1A1F,0x1B10, //6
            //        0x1CD0,0x1D0A,0x1E48,0x1F20,0x2010,0x2101,0x221C,0x2300,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //7
            //        0x0080,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //8
            //        0x0000,0x0000,0x7FFF,0x7FFF,0x7FFF,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //9
            //        0x0020,0x000F,0x0030,0x000A,0x0000,0x0000,0x0000,0x0000,0xFFFF,0x3FFF,0x3FFF,0x3FFF,0xFFFF,0xFFFF,0x3FFF,0x3FFF, //a
            //        0x3FFF,0xFFFF,0x3FFF,0x3FFF,0x3FFF,0xFFFF,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //b
            //        0x3FFF,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //c
            //        0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //d
            //        0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //e 
            //        0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000}; //f

            ushort[] arrDefualt = {
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0001,0x0001,0x0001,0x0000,0x0000,0x0000,0x0000,0x0000, //0 
                    0x0000,0x0000,0x021F,0x0310,0x0402,0x050A,0x0601,0x0780,0x0880,0x0980,0x0A80,0x0B80,0x0C10,0x0D01,0x0E01,0x0F11, //1
                    0x1001,0x110F,0x120F,0x1300,0x1400,0x1500,0x1600,0x17F0,0x182F,0x1900,0x1A0F,0x1B80,0x1C40,0x1D0A,0x1E5F,0x1F1F, //2
                    0x201F,0x2102,0x22FC,0x2300,0x021F,0x0310,0x0402,0x050A,0x0601,0x0780,0x0880,0x0980,0x0A80,0x0B80,0x0C10,0x0D01, //3
                    0x0E01,0x0F11,0x1001,0x110F,0x120F,0x1300,0x1400,0x1500,0x1600,0x17F0,0x182F,0x1900,0x1A0F,0x1B80,0x1C40,0x1D0A, //4
                    0x1E5F,0x1F1F,0x201F,0x2102,0x22FC,0x2300,0x021F,0x0310,0x0402,0x050A,0x0601,0x0780,0x0880,0x0980,0x0A80,0x0B80, //5
                    0x0C10,0x0D01,0x0E01,0x0F11,0x1001,0x110F,0x120F,0x1300,0x1400,0x1500,0x1600,0x17F0,0x182F,0x1900,0x1A0F,0x1B80, //6
                    0x1C40,0x1D0A,0x1E5F,0x1F1F,0x201F,0x2102,0x22FC,0x2300,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //7
                    0x00FA,0x0000,0x0000,0x0000,0x0001,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //8
                    0x0000,0x0000,0x7FFF,0x7FFF,0x7FFF,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //9
                    0x0020,0x000F,0x0030,0x000A,0xFFFF,0x3FFF,0x3FFF,0x3FFF,0xFFFF,0x3FFF,0x3FFF,0x03FF,0xFFFF, 0xFFFF,0xFFFF,0xFFFF,//a
                    0xFFFF,0xFFFF,0xFFFF,0xFFFF,0xFFFF,0xFFFF,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //b
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //c
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //d
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //e 
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000}; //f

            byte[] bytesData = arrDefualt.ToBytes();
            Array.Copy(bytesData, 0, Data, 0, bytesData.Length);
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
                bool isFind = false;
                while ((lineData = reader.ReadLine()) != null)
                {
                    if (lineData == "******************************************************************* Start 2055 *************************************************************************")
                    {
                        isFind = true;
                        continue;
                    }
                    if (lineData == "******************************************************************* End 2055 *************************************************************************") break;
                    if (isFind)
                    {
                        string[] data = lineData.Split('\t');
                        if (lineIndex == 0)
                        {
                            //标题
                            lineIndex++;
                            continue;
                        }
                        if (lineIndex == 1)
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
                        else if (lineIndex == 2)
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
                            registerItem.RedValue = data[9];
                            registerItem.GreenValue = data[10];
                            registerItem.BlueValue = data[11];
                            registerItem.Offset = data[12];
                            registerItem.Description = data[13];
                            registerItem.ChineseDescription = data[14];
                            registerItem.EnglishDescription = data[15];
                            reg.Register2055ItemList.Add(registerItem);
                        }
                        lineIndex++;
                    }
                }
            }
            return reg;
        }

        private static void ReadRegister2055(TextReader reader)
        {

        }

        public static void Save2055Register(Register register, string file)
        {
            using (TextWriter writer = new StreamWriter(file))
            {
                writer.WriteLine("******************************************************************* Start 2055 *************************************************************************");
                writer.WriteLine("序号    FPGA红色地址    FPGA绿色地址    FPGA蓝色地址    恒流源地址   起始位 结束位  最小值   最大值  红色值     绿色纸     蓝色值  偏移量   说明     中文说明    英文说明");
                int cx = 0;
                writer.WriteLine($"{cx}\t{0}\t{register.IsDebug}");
                cx++;
                writer.WriteLine($"{cx}\t{register.SpecialRegister.StartBit}\t{register.SpecialRegister.StopBit}\t{register.SpecialRegister.RegisterAddress}\t{register.SpecialRegister.Value}");
                cx++;
                foreach (var item in register.Register2055ItemList)
                {
                    //序号    FPGA红色地址    FPGA绿色地址    FPGA蓝色地址    恒流源地址   起始位 结束位  最小值   最大值  红色值     绿色纸     蓝色值  偏移量   说明     中文说明    英文说明
                    writer.WriteLine($"{cx}\t{item.RedAddress}\t{item.GreenAddress}\t{item.BlueAddress}\t{item.RegisterAddress}\t{item.StartBit}\t{item.StopBit}\t{item.MinValue.ToString("X2")}\t{item.MaxValue.ToString("X2")}\t{item.RedValue}\t{item.GreenValue}\t{item.BlueValue}\t{item.Offset}\t{item.Description}\t{item.ChineseDescription}\t{item.EnglishDescription}");
                    cx++;
                }
                writer.WriteLine("******************************************************************* End 2055 *************************************************************************");
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
        /// <summary>
        /// 将字节数组数据解析成类对象
        /// </summary>
        /// <param name="reg2055List"></param>
        public static void SplitReg2055(List<RegisterItem> reg2055List)
        {
            int position = Reg2055StartAddr;
            for (byte i = 0x12; i < 0x77; i++)
            {
                List<RegisterSpectialItem> reg = GetRegisterItem(reg2055List, i);
                foreach (var item in reg)
                {
                    //CombinData(position, item.Value, item.StartBit, item.StopBit);
                    if (item.Color == EnumRegColor.Red)
                    {
                        byte val = RegisterHelper.Data[position + 1].GetBitRangeValue(item.StartBit, item.StopBit);
                        item.Register.RedValue = val.ToString("X2");

                    }
                    else if (item.Color == EnumRegColor.Green)
                    {
                        byte val = RegisterHelper.Data[position + 1].GetBitRangeValue(item.StartBit, item.StopBit);
                        item.Register.GreenValue = val.ToString("X2");
                    }
                    else if (item.Color == EnumRegColor.Blue)
                    {
                        byte val = RegisterHelper.Data[position + 1].GetBitRangeValue(item.StartBit, item.StopBit);
                        item.Register.BlueValue = val.ToString("X2");
                    }
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
                        Value = item.RedValue.ToByte(),
                        Color = EnumRegColor.Red,
                        Register = item
                    });
                }
                if (item.GreenAddress.ToUpper() == strAddr)
                {
                    result.Add(new RegisterSpectialItem()
                    {
                        RegisterAddress = byte.Parse(item.GreenAddress, System.Globalization.NumberStyles.HexNumber),
                        StartBit = item.StartBit,
                        StopBit = item.StopBit,
                        Value = item.GreenValue.ToByte(),
                        Color = EnumRegColor.Green,
                        Register = item
                    });
                }
                if (item.BlueAddress.ToUpper() == strAddr)
                {
                    result.Add(new RegisterSpectialItem()
                    {
                        RegisterAddress = byte.Parse(item.BlueAddress, System.Globalization.NumberStyles.HexNumber),
                        StartBit = item.StartBit,
                        StopBit = item.StopBit,
                        Value = item.BlueValue.ToByte(),
                        Color = EnumRegColor.Blue,
                        Register = item
                    });
                }
            }
            return result;
        }

    }
}
