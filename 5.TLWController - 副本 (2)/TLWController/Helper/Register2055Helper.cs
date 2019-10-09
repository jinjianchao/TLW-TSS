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
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using SFTHelper.Extentions;

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

    public class RegisterOtherItem
    {
        public bool IsSelected { get; set; }
        public string Address { get; set; }
        public String Value { get; set; }
        public byte StartBit { get; set; }
        public byte StopBit { get; set; }
        public string ChineseDescription { get; set; }
        public string EnglishDescription { get; set; }
        public String Send { get; set; } = "Send";
        public string MinValue { get; set; }
        public string MaxValue { get; set; }
    }

    public class Register
    {
        #region 2055寄存器

        /// <summary>
        /// 是否调试模式 true：是,断电丢失，false:否，断电不丢失
        /// </summary>
        public bool Is2055Debug { get; set; }

        /// <summary>
        /// 2055寄存器
        /// </summary>
        public List<RegisterItem> Register2055ItemList { get; set; }

        /// <summary>
        /// 其他寄存器
        /// </summary>
        public IList<RegisterOtherItem> Register2055OtherItemList { get; set; }

        public RegisterSpectialItem Special2055Register { get; set; }

        #endregion

        #region 2072寄存器

        /// <summary>
        /// 是否调试模式 true：是,断电丢失，false:否，断电不丢失
        /// </summary>
        public bool Is2072Debug { get; set; }

        /// <summary>
        /// 2055寄存器
        /// </summary>
        public List<RegisterItem> Register2072ItemList { get; set; }

        /// <summary>
        /// 其他寄存器
        /// </summary>
        public IList<RegisterOtherItem> Register2072OtherItemList { get; set; }

        public RegisterSpectialItem Special2072Register { get; set; }

        #endregion

        public Register()
        {
            Register2055ItemList = new List<RegisterItem>();
            Register2055OtherItemList = new List<RegisterOtherItem>();

            Register2072ItemList = new List<RegisterItem>();
            Register2072OtherItemList = new List<RegisterOtherItem>();
        }
    }

    public class Register2055Helper
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

        static Register2055Helper()
        {
            Reload2055DefaultData();
        }

        public static void Reload2055DefaultData()
        {
            Data = new byte[1024].Fill(0xFF);
            //ushort[] arrDefualt = {
            //        0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0001,0x0001,0x0001,0x0000,0x0000,0x0000,0x0000,0x0000, //0 
            //        0x0000,0x0000,0x021F,0x0310,0x0402,0x050A,0x0601,0x0780,0x0880,0x0980,0x0A80,0x0B80,0x0C10,0x0D01,0x0E01,0x0F11, //1
            //        0x1001,0x110F,0x120F,0x1300,0x1400,0x1500,0x1600,0x17F0,0x182F,0x1900,0x1A0F,0x1B80,0x1C40,0x1D0A,0x1E5F,0x1F1F, //2
            //        0x201F,0x2102,0x22FC,0x2300,0x021F,0x0310,0x0402,0x050A,0x0601,0x0780,0x0880,0x0980,0x0A80,0x0B80,0x0C10,0x0D01, //3
            //        0x0E01,0x0F11,0x1001,0x110F,0x120F,0x1300,0x1400,0x1500,0x1600,0x17F0,0x182F,0x1900,0x1A0F,0x1B80,0x1C40,0x1D0A, //4
            //        0x1E5F,0x1F1F,0x201F,0x2102,0x22FC,0x2300,0x021F,0x0310,0x0402,0x050A,0x0601,0x0780,0x0880,0x0980,0x0A80,0x0B80, //5
            //        0x0C10,0x0D01,0x0E01,0x0F11,0x1001,0x110F,0x120F,0x1300,0x1400,0x1500,0x1600,0x17F0,0x182F,0x1900,0x1A0F,0x1B80, //6
            //        0x1C40,0x1D0A,0x1E5F,0x1F1F,0x201F,0x2102,0x22FC,0x2300,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //7
            //        0x00FA,0x0000,0x0000,0x0000,0x0001,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //8
            //        0x0000,0x0000,0x7FFF,0x7FFF,0x7FFF,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //9
            //        0x0020,0x000F,0x0030,0x000A,0xFFFF,0x3FFF,0x3FFF,0x3FFF,0xFFFF,0x3FFF,0x3FFF,0x03FF,0xFFFF, 0xFFFF,0xFFFF,0xFFFF,//a
            //        0xFFFF,0xFFFF,0xFFFF,0xFFFF,0xFFFF,0xFFFF,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //b
            //        0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //c
            //        0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //d
            //        0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //e 
            //        0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000}; //f

            ushort[] arrDefualt = {
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0001,0x0001,0x0000,0x0000,0x0002,0x0000,0x0000,0x0000, //0 
                    0x0000,0x0000,0x021F,0x033F,0x0402,0x0504,0x0601,0x0720,0x0820,0x0908,0x0A08,0x0B00,0x0C20,0x0D01,0x0E04,0x0F81, //1
                    0x1042,0x1121,0x1201,0x1300,0x1400,0x1500,0x1600,0x17F0,0x181F,0x1900,0x1A1F,0x1B10,0x1C97,0x1D0A,0x1E42,0x1F04, //2
                    0x2054,0x2101,0x221C,0x2300,0x021F,0x033F,0x0402,0x0504,0x0601,0x0720,0x0820,0x0908,0x0A08,0x0B00,0x0C20,0x0D01, //3
                    0x0E04,0x0F81,0x1042,0x1121,0x1201,0x1300,0x1400,0x1500,0x1600,0x17F0,0x18EF,0x1950,0x1A1F,0x1B10,0x1CAC,0x1D0A, //4
                    0x1E46,0x1F20,0x2054,0x2101,0x221C,0x2300,0x021F,0x033F,0x0402,0x0504,0x0601,0x0720,0x0820,0x0908,0x0A08,0x0B00, //5
                    0x0C20,0x0D01,0x0E04,0x0F81,0x1042,0x1121,0x1201,0x1300,0x1400,0x1500,0x1600,0x17F0,0x182F,0x1900,0x1A1F,0x1B10, //6
                    0x1CB3,0x1D0A,0x1E48,0x1F20,0x2054,0x2101,0x221C,0x2300,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //7
                    0x0080,0x0000,0x0000,0x0000,0x0001,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //8
                    0x0000,0x0000,0x7FFF,0x7FFF,0x7FFF,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //9
                    0x0026,0x000A,0x002D,0x0023,0xFFFF,0x3FFF,0x3FFF,0x3FFF,0xFFFF,0x3FFF,0x3FFF,0x03FF,0xFFFF,0xFFFF,0xFFFF,0xFFFF,//a
                    0xFFFF,0xFFFF,0xFFFF,0xFFFF,0xFFFF,0xFFFF,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //b
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //c
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //d
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000, //e 
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000 //f
        };

            byte[] bytesData = arrDefualt.GetBytes();
            Array.Copy(bytesData, 0, Data, 0, bytesData.Length);
        }

        public static Register Load2055Register(string file, bool bImport)
        {
            //Reload2055DefaultData();
            Register reg = new Register();

            if (!File.Exists(file))
            {
                return null;
            }

            using (TextReader reader = new StreamReader(file, Encoding.UTF8))
            {
                if (ReadSpectialRegisterData(ref reg, reader) == false)
                {
                    return null;
                }
            }
            using (TextReader reader = new StreamReader(file, Encoding.UTF8))
            {
                if (ReadRegister2055(ref reg, reader) == false)
                {
                    return null;
                }
            }

            using (TextReader reader = new StreamReader(file, Encoding.UTF8))
            {
                if (ReadOtherRegister(ref reg, reader, bImport) == false)
                {
                    return null;
                }
            }

            return reg;
        }

        private static bool ReadSpectialRegisterData(ref Register reg, TextReader reader)
        {
            int lineIndex1 = 0;//用于查找特殊航
            string lineData = string.Empty;
            List<RegisterItem> RegisterItemList = new List<RegisterItem>();
            while ((lineData = reader.ReadLine()) != null)
            {
                string[] data = lineData.Split('\t');

                if (lineIndex1 == 0)
                {
                    if (data.Length != 3)
                    {
                        return false;
                    }

                    if (!byte.TryParse(data[1], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte refreshRate))
                    {
                        return false;
                    }

                    if (!bool.TryParse(data[2], out bool isDebug))
                    {
                        return false;
                    }
                    reg.Is2055Debug = isDebug;
                    lineIndex1++;
                }
                else if (lineIndex1 == 1)
                {
                    if (data.Length != 5)
                    {
                        return false;
                    }
                    RegisterSpectialItem specialFPGA = new RegisterSpectialItem();

                    if (!byte.TryParse(data[1], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte startBit))
                    {
                        return false;
                    }
                    specialFPGA.StartBit = startBit;

                    if (!byte.TryParse(data[2], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte endBit))
                    {
                        return false;
                    }
                    specialFPGA.StopBit = endBit;
                    if (!int.TryParse(data[3], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int addr))
                    {
                        return false;
                    }
                    specialFPGA.RegisterAddress = addr;
                    specialFPGA.Value = byte.Parse(data[4]);
                    reg.Special2055Register = specialFPGA;
                    lineIndex1++;
                    break;
                }
            }
            return true;
        }

        private static bool ReadRegister2055(ref Register reg, TextReader reader)
        {
            int lineIndex = 0;
            string lineData = string.Empty;
            List<RegisterItem> RegisterItemList = new List<RegisterItem>();
            bool isFind = false;
            while ((lineData = reader.ReadLine()) != null)
            {
                string[] data = lineData.Split('\t');
                if (lineData == "******************************************************************* Start 2055 *************************************************************************")
                {
                    isFind = true;
                    lineIndex = 0;
                    continue;
                }
                if (lineData == "******************************************************************* End 2055 *************************************************************************") break;
                if (isFind)
                {
                    if (lineIndex == 0)
                    {
                        //标题
                        lineIndex++;
                        continue;
                    }
                    RegisterItem registerItem = new RegisterItem();
                    if (data.Length != 16)
                    {
                        return false;
                    }
                    UInt16 fpgaAddress = 0;
                    if (!UInt16.TryParse(data[1], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out fpgaAddress))
                    {
                        return false;
                    }
                    registerItem.RedAddress = data[1];

                    if (!UInt16.TryParse(data[2], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out fpgaAddress))
                    {
                        return false;
                    }
                    registerItem.GreenAddress = data[2];

                    if (!UInt16.TryParse(data[3], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out fpgaAddress))
                    {
                        return false;
                    }
                    registerItem.BlueAddress = data[3];

                    byte regAddress = 0;
                    if (!byte.TryParse(data[4], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out regAddress))
                    {
                        return false;
                    }
                    registerItem.RegisterAddress = data[4];

                    if (!byte.TryParse(data[5], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte startBit))
                    {
                        return false;
                    }
                    registerItem.StartBit = startBit;

                    if (!byte.TryParse(data[6], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte endBit))
                    {
                        return false;
                    }
                    registerItem.StopBit = endBit;

                    if (!byte.TryParse(data[7], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte minValue))
                    {
                        return false;
                    }
                    registerItem.MinValue = minValue;

                    if (!byte.TryParse(data[8], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte maxValue))
                    {
                        return false;
                    }
                    registerItem.MaxValue = maxValue;
                    registerItem.RedValue = data[9].GetUInt16(System.Globalization.NumberStyles.HexNumber).ToString();
                    registerItem.GreenValue = data[10].GetUInt16(System.Globalization.NumberStyles.HexNumber).ToString();
                    registerItem.BlueValue = data[11].GetUInt16(System.Globalization.NumberStyles.HexNumber).ToString();
                    registerItem.Offset = data[12];
                    registerItem.Description = data[13];
                    registerItem.ChineseDescription = data[14];
                    registerItem.EnglishDescription = data[15];
                    reg.Register2055ItemList.Add(registerItem);
                    lineIndex++;
                }
            }
            return true;
        }

        private static bool ReadOtherRegister(ref Register reg, TextReader reader, bool bImport)
        {
            int lineIndex = 0;
            string lineData = string.Empty;
            List<RegisterOtherItem> RegisterItemList = new List<RegisterOtherItem>();
            bool isFind = false;
            while ((lineData = reader.ReadLine()) != null)
            {
                string[] data = lineData.Split('\t');
                if (lineData == "******************************************************************* Start Other *************************************************************************")
                {
                    isFind = true;
                    lineIndex = 0;
                    continue;
                }
                if (lineData == "******************************************************************* End Other *************************************************************************") break;
                if (isFind)
                {
                    if (lineIndex == 0)
                    {
                        //标题
                        lineIndex++;
                        continue;
                    }
                    RegisterOtherItem registerItem = new RegisterOtherItem();
                    if (data.Length != 9)
                    {
                        return false;
                    }
                    UInt16 fpgaAddress = 0;
                    if (!UInt16.TryParse(data[1], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out fpgaAddress))
                    {
                        return false;
                    }
                    registerItem.Address = data[1];

                    //registerItem.RegisterAddress = data[4];

                    if (!byte.TryParse(data[2], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte startBit))
                    {
                        return false;
                    }
                    registerItem.StartBit = startBit;

                    if (!byte.TryParse(data[3], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte endBit))
                    {
                        return false;
                    }
                    registerItem.StopBit = endBit;

                    if (!UInt16.TryParse(data[4], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out UInt16 minValue))
                    {
                        return false;
                    }
                    registerItem.MinValue = minValue.ToString("X4");

                    if (!UInt16.TryParse(data[5], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out UInt16 maxValue))
                    {
                        return false;
                    }
                    registerItem.MaxValue = maxValue.ToString("X4");
                    //if (registerItem.Address != "92")
                    //{
                    //    registerItem.Value = data[6].ToUInt32(NumberStyles.HexNumber).ToString();
                    //}
                    //else
                    //{
                    //    if (bImport == false)
                    //        registerItem.Value = data[6].ToUInt32(NumberStyles.HexNumber).ToString();
                    //    else
                    //    {
                    //        registerItem.Value = data[6].ToUInt32(NumberStyles.HexNumber).ToString();
                    //    }
                    //}
                    registerItem.Value = data[6].GetUInt32(NumberStyles.HexNumber).ToString();
                    registerItem.ChineseDescription = data[7];
                    registerItem.EnglishDescription = data[8];
                    reg.Register2055OtherItemList.Add(registerItem);
                    lineIndex++;
                }
            }
            return true;
        }

        public static void Save2055Register(Register register, string file)
        {
            using (TextWriter writer = new StreamWriter(file))
            {
                int cx = 0;
                writer.WriteLine($"{cx}\t{0}\t{register.Is2055Debug}");
                cx++;
                writer.WriteLine($"{cx}\t{register.Special2055Register.StartBit}\t{register.Special2055Register.StopBit}\t{register.Special2055Register.RegisterAddress}\t{register.Special2055Register.Value}");
                cx++;
                writer.WriteLine("******************************************************************* Start 2055 *************************************************************************");
                writer.WriteLine("序号    FPGA红色地址    FPGA绿色地址    FPGA蓝色地址    恒流源地址   起始位 结束位  最小值   最大值  红色值     绿色纸     蓝色值  偏移量   说明     中文说明    英文说明");
                cx = 0;
                foreach (var item in register.Register2055ItemList)
                {
                    //序号    FPGA红色地址    FPGA绿色地址    FPGA蓝色地址    恒流源地址   起始位 结束位  最小值   最大值  红色值     绿色纸     蓝色值  偏移量   说明     中文说明    英文说明
                    writer.WriteLine($"{cx}\t{item.RedAddress}\t{item.GreenAddress}\t{item.BlueAddress}\t{item.RegisterAddress}\t{item.StartBit}\t{item.StopBit}\t{item.MinValue.ToString("X2")}\t{item.MaxValue.ToString("X2")}\t{item.RedValue.GetUInt16(NumberStyles.Number).ToString("X2")}\t{item.GreenValue.GetUInt16(NumberStyles.Number).ToString("X2")}\t{item.BlueValue.GetUInt16(NumberStyles.Number).ToString("X2")}\t{item.Offset}\t{item.Description}\t{item.ChineseDescription}\t{item.EnglishDescription}");
                    cx++;
                }
                writer.WriteLine("******************************************************************* End 2055 *************************************************************************");
                writer.WriteLine("******************************************************************* Start Other *************************************************************************");
                writer.WriteLine("序号	地址	起始位	终止位	最小值	最大值	默认值	中文描述	英文描述");
                cx = 0;
                foreach (var item in register.Register2055OtherItemList)
                {
                    writer.WriteLine($"{cx}\t{item.Address}\t{item.StartBit.ToString("X2")}\t{item.StopBit.ToString("X2")}\t{item.MinValue}\t{item.MaxValue}\t{item.Value.GetUInt32(NumberStyles.Number).ToString("X4")}\t{item.ChineseDescription}\t{item.EnglishDescription}");
                    cx++;
                }
                writer.WriteLine("******************************************************************* End Other *************************************************************************");
            }

        }

        public static void CombinReg2055(List<RegisterItem> reg2055List)
        {
            int position = Reg2055StartAddr;
            for (byte i = 0x12; i <= 0x77; i++)
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
                        byte val = Register2055Helper.Data[position + 1].GetPart(item.StartBit, item.StopBit);
                        //item.Register.RedValue = val.ToString("X2");
                        item.Register.RedValue = val.ToString();

                    }
                    else if (item.Color == EnumRegColor.Green)
                    {
                        byte val = Register2055Helper.Data[position + 1].GetPart(item.StartBit, item.StopBit);
                        //item.Register.GreenValue = val.ToString("X2");
                        item.Register.GreenValue = val.ToString();
                    }
                    else if (item.Color == EnumRegColor.Blue)
                    {
                        byte val = Register2055Helper.Data[position + 1].GetPart(item.StartBit, item.StopBit);
                        //item.Register.BlueValue = val.ToString("X2");
                        item.Register.BlueValue = val.ToString();
                    }
                }
                position += 2;
            }
        }

        /// <summary>
        /// 将字节数组数据解析成类对象
        /// </summary>
        /// <param name="reg2055List"></param>
        public static void SplitRegOther(List<RegisterOtherItem> regList)
        {
            //int position = Reg2055StartAddr;
            //for (byte i = 0x12; i < 0x77; i++)
            //{
            //    List<RegisterSpectialItem> reg = GetRegisterItem(reg2055List, i);
            //    foreach (var item in reg)
            //    {
            //        //CombinData(position, item.Value, item.StartBit, item.StopBit);
            //        if (item.Color == EnumRegColor.Red)
            //        {
            //            byte val = RegisterHelper.Data[position + 1].GetBitRangeValue(item.StartBit, item.StopBit);
            //            item.Register.RedValue = val.ToString("X2");

            //        }
            //        else if (item.Color == EnumRegColor.Green)
            //        {
            //            byte val = RegisterHelper.Data[position + 1].GetBitRangeValue(item.StartBit, item.StopBit);
            //            item.Register.GreenValue = val.ToString("X2");
            //        }
            //        else if (item.Color == EnumRegColor.Blue)
            //        {
            //            byte val = RegisterHelper.Data[position + 1].GetBitRangeValue(item.StartBit, item.StopBit);
            //            item.Register.BlueValue = val.ToString("X2");
            //        }
            //    }
            //    position += 2;
            //}

            //int position = 0 * 2;
            //for (byte i = 0x00; i <= 0x2; i++)
            //{
            //    List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
            //    foreach (var item in reg)
            //    {
            //        byte[] vals = new byte[2];
            //        vals[0] = RegisterHelper.Data[position].GetBitRangeValue(item.StartBit, item.StopBit);
            //        vals[1] = RegisterHelper.Data[position + 1].GetBitRangeValue(item.StartBit, item.StopBit);
            //        item.Value = vals.GetUInt16();
            //    }
            //    position += 2;
            //}

            int position = 0 * 2;
            for (byte i = 0x00; i <= 0x2; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    byte[] vals = new byte[2];
                    //vals[0] = RegisterHelper.Data[position].GetBitRangeValueFromUInt16(item.StartBit, item.StopBit);
                    //vals[1] = RegisterHelper.Data[position + 1].GetBitRangeValueFromUInt16(item.StartBit, item.StopBit);
                    vals[0] = Register2055Helper.Data[position];
                    vals[1] = Register2055Helper.Data[position + 1];
                    ushort data = vals.GetUInt16(0).GetPart(item.StartBit, item.StopBit);
                    //item.Value = data.ToString("X4");
                    item.Value = data.ToString();
                }
                position += 2;
            }

            position = 0x06 * 2;
            for (byte i = 0x06; i <= 0x0F; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    byte[] vals = new byte[2];
                    //vals[0] = RegisterHelper.Data[position].GetBitRangeValueFromUInt16(item.StartBit, item.StopBit);
                    //vals[1] = RegisterHelper.Data[position + 1].GetBitRangeValueFromUInt16(item.StartBit, item.StopBit);
                    vals[0] = Register2055Helper.Data[position];
                    vals[1] = Register2055Helper.Data[position + 1];
                    ushort data = vals.GetUInt16(0).GetPart(item.StartBit, item.StopBit);
                    //item.Value = data.ToString("X4");
                    item.Value = data.ToString();
                }
                position += 2;
            }
            position = 0x80 * 2;
            for (byte i = 0x80; i <= 0x80; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    byte[] vals = new byte[2];
                    //vals[0] = RegisterHelper.Data[position].GetBitRangeValueFromUInt16(item.StartBit, item.StopBit);
                    //vals[1] = RegisterHelper.Data[position + 1].GetBitRangeValueFromUInt16(item.StartBit, item.StopBit);
                    vals[0] = Register2055Helper.Data[position];
                    vals[1] = Register2055Helper.Data[position + 1];
                    ushort data = vals.GetUInt16(0).GetPart(item.StartBit, item.StopBit);
                    //item.Value = data.ToString("X4");
                    item.Value = data.ToString();
                }
                position += 2;
            }
            position = 0x83 * 2;
            for (byte i = 0x83; i <= 0x98; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    byte[] vals = new byte[2];
                    //vals[0] = RegisterHelper.Data[position].GetBitRangeValueFromUInt16(item.StartBit, item.StopBit);
                    //vals[1] = RegisterHelper.Data[position + 1].GetBitRangeValueFromUInt16(item.StartBit, item.StopBit);
                    vals[0] = Register2055Helper.Data[position];
                    vals[1] = Register2055Helper.Data[position + 1];
                    ushort data = vals.GetUInt16(0).GetPart(item.StartBit, item.StopBit);
                    //item.Value = data.ToString("X4");
                    item.Value = data.ToString();
                }
                position += 2;
            }
            position = 0xA0 * 2;
            for (byte i = 0xA0; i <= 0xB5; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    byte[] vals = new byte[2];
                    //vals[0] = RegisterHelper.Data[position].GetBitRangeValueFromUInt16(item.StartBit, item.StopBit);
                    //vals[1] = RegisterHelper.Data[position + 1].GetBitRangeValueFromUInt16(item.StartBit, item.StopBit);
                    vals[0] = Register2055Helper.Data[position];
                    vals[1] = Register2055Helper.Data[position + 1];
                    ushort data = vals.GetUInt16(0).GetPart(item.StartBit, item.StopBit);
                    //item.Value = data.ToString("X4");
                    item.Value = data.ToString();
                }
                position += 2;
            }

            position = 0xC0 * 2;
            for (byte i = 0xC0; i <= 0xC0; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    byte[] vals = new byte[2];
                    vals[0] = Register2055Helper.Data[position];
                    vals[1] = Register2055Helper.Data[position + 1];
                    ushort data = vals.GetUInt16(0).GetPart(item.StartBit, item.StopBit);
                    //item.Value = data.ToString("X4");
                    item.Value = data.ToString();
                }
                position += 2;
            }


            position = 0xC1 * 2;
            for (byte i = 0xC1; i <= 0xC1; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    byte[] vals = new byte[2];
                    vals[0] = Register2055Helper.Data[position];
                    vals[1] = Register2055Helper.Data[position + 1];
                    ushort data = vals.GetUInt16(0).GetPart(item.StartBit, item.StopBit);
                    //item.Value = data.ToString("X4");
                    item.Value = data.ToString();
                }
                position += 2;
            }
        }

        public static void CombinOtherReg(List<RegisterOtherItem> regList)
        {
            //int position = 0;
            //for (byte i = 0x00; i < 0x11; i++)
            //{
            //    List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
            //    foreach (var item in reg)
            //    {
            //        CombinData(position, item.Value, item.StartBit, item.StopBit);
            //    }
            //    position += 2;
            //}
            int position = 0 * 2;
            for (byte i = 0x00; i <= 0x2; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    CombinData(position, item.Value.GetUInt16(NumberStyles.Number), item.StartBit, item.StopBit);
                }
                position += 2;
            }
            position = 0x06 * 2;
            for (byte i = 0x06; i <= 0x0F; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    CombinData(position, item.Value.GetUInt16(NumberStyles.Number), item.StartBit, item.StopBit);
                }
                position += 2;
            }
            position = 0x80 * 2;
            for (byte i = 0x80; i <= 0x80; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    CombinData(position, item.Value.GetUInt16(NumberStyles.Number), item.StartBit, item.StopBit);
                }
                position += 2;
            }
            position = 0x83 * 2;
            for (byte i = 0x83; i <= 0x98; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    CombinData(position, item.Value.GetUInt16(NumberStyles.Number), item.StartBit, item.StopBit);
                }
                position += 2;
            }
            //position = 0xA4 * 2;
            //for (byte i = 0xA4; i <= 0xB5; i++)
            //2019-07-16 新增A0--A3寄存器
            position = 0xA0 * 2;
            for (byte i = 0xA0; i <= 0xB5; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    CombinData(position, item.Value.GetUInt16(NumberStyles.Number), item.StartBit, item.StopBit);
                }
                position += 2;
            }
            position = 0xC0 * 2;
            for (byte i = 0xC0; i <= 0xC0; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    CombinData(position, item.Value.GetUInt16(NumberStyles.Number), item.StartBit, item.StopBit);
                }
                position += 2;
            }
            position = 0xC1 * 2;
            for (byte i = 0xC1; i <= 0xC1; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    CombinData(position, item.Value.GetUInt16(NumberStyles.Number), item.StartBit, item.StopBit);
                }
                position += 2;
            }
        }

        private static void CombinData(int position, UInt16 newData, int startBit, int stopBit)
        {
            //string binaryVal = newData.GetBinaryString(stopBit - startBit + 1).Reverse();

            //byte[] data1 = new byte[2];
            //data1[0] = Data[position];
            //data1[1] = Data[position + 1];
            //UInt16 uData1 = data1.GetUInt16();
            //string binaryVal1 = uData1.GetBinaryString(16).Reverse();
            //int index = 0;
            //for (int i = startBit; i <= stopBit; i++)
            //{
            //    string str1 = binaryVal.Substring(index++, 1);
            //    binaryVal1 = binaryVal1.Replace(i, str1);
            //}
            //binaryVal1 = binaryVal1.Reverse();
            //UInt16 data2 = Convert.ToUInt16(binaryVal1, 2);
            //byte[] data3 = data2.GetBytes();
            //Data[position] = data3[0];
            //Data[position + 1] = data3[1];

            //byte[] data1 = new byte[2];
            //data1[0] = Data[position];
            //data1[1] = Data[position + 1];
            //UInt16 uData1 = data1.GetUInt16();
            //ushort data2 = uData1.ModifyPart(startBit, stopBit, newData);
            //byte[] data3 = data2.GetBytes();
            //Data[position] = data3[0];
            //Data[position + 1] = data3[1];

            UInt16 tmp = Data.GetUInt16(position).ModifyPart(startBit, stopBit, newData);
            byte[] tmp1 = tmp.GetBytes();
            Data[position] = tmp1[0];
            Data[position + 1] = tmp1[1];
        }

        private static List<RegisterSpectialItem> GetRegisterItem(List<RegisterItem> reg2055List, byte regAddr)
        {
            List<RegisterSpectialItem> result = new List<RegisterSpectialItem>();
            foreach (var item in reg2055List)
            {
                string strAddr = regAddr.ToString("X2");
                if (item.RedAddress.ToUpper() == strAddr)
                {
                    try
                    {
                        result.Add(new RegisterSpectialItem()
                        {
                            RegisterAddress = byte.Parse(item.RedAddress, System.Globalization.NumberStyles.HexNumber),
                            StartBit = item.StartBit,
                            StopBit = item.StopBit,
                            Value = item.RedValue.GetByte(NumberStyles.Number),
                            Color = EnumRegColor.Red,
                            Register = item
                        });
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (item.GreenAddress.ToUpper() == strAddr)
                {
                    result.Add(new RegisterSpectialItem()
                    {
                        RegisterAddress = byte.Parse(item.GreenAddress, System.Globalization.NumberStyles.HexNumber),
                        StartBit = item.StartBit,
                        StopBit = item.StopBit,
                        Value = item.GreenValue.GetByte(NumberStyles.Number),
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
                        Value = item.BlueValue.GetByte(NumberStyles.Number),
                        Color = EnumRegColor.Blue,
                        Register = item
                    });
                }
            }
            return result;
        }

        private static List<RegisterOtherItem> GetOtherRegisterItem(List<RegisterOtherItem> regItemList, byte regAddr)
        {
            //List<RegisterOtherItem> result = new List<RegisterOtherItem>();
            //foreach (var item in regItemList)
            //{
            //    string strAddr = regAddr.ToString("X2");
            //    if (item.Address.ToUInt16().ToString("X2") == strAddr)
            //    {
            //        result.Add(item);
            //    }
            //}
            //return result;

            List<RegisterOtherItem> result = new List<RegisterOtherItem>();
            foreach (var item in regItemList)
            {
                //string strAddr = regAddr.ToString("X2");
                if (item.Address.GetByte(NumberStyles.HexNumber) == regAddr)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        private static ushort GetRegVal(List<RegisterItem> reg2055List, int regAddr)
        {
            ushort val = 0;
            //reg2055List.ForEach((item) => {
            //    if(item.RegisterAddress.ToUInt32(NumberStyles.HexNumber)==regAddr)
            //    {
            //        val = item.RedValue.ToUInt16(NumberStyles.HexNumber);
            //        return;
            //    }
            //});
            ushort result = 0;
            foreach (var item in reg2055List)
            {
                if (item.RegisterAddress.GetUInt32(NumberStyles.HexNumber) == regAddr)
                {
                    val = item.RedValue.GetUInt16(NumberStyles.Number);
                    result = result.ModifyPart(item.StartBit, item.StopBit, val);
                    //break;
                }
            }
            return result;
        }

        private static int GetGAMMAbit(ushort nMaxGrayLevel)
        {
            nMaxGrayLevel = (ushort)(nMaxGrayLevel - 1);//2018-09-18
            int nBit = 0;
            for (int i = 15; i > 0; i--)
            {
                //if ((nMaxGrayLevel >> i) > 0)
                //{
                //    //
                //    ushort tmp = (ushort)((UInt32)(1 << (i + 1)) - 1);
                //    if (nMaxGrayLevel < tmp)
                //    {
                //        nBit = i - 1;
                //    }
                //    else
                //    {
                //        nBit = i;
                //    }
                //    break;
                //}

                if (((nMaxGrayLevel >> i) & 0x01) == 1)
                {
                    nBit = i + 1;
                    break;
                }
            }
            return nBit;
        }

        /// <summary>
        /// 从几个参数算出一些东西
        /// </summary>
        /// <param name="nMode">//0 = 60Hz  1=50Hz  2=3D</param>
        /// <param name="szUnitType">箱体名称</param>
        /// <returns></returns>
        public static ArrayList RunCalc(int nMode, List<RegisterItem> reg2055List)
        {
            nMode = 0;//固定写死，目前只有60hz
            ArrayList list = new ArrayList();

            //--------------取出数值 -------------

            //行扫 input2072Simple3|1,0,5
            //int nScan = GetPartOfUInt32(nMode, 0x01, 0, 5);
            int nScan = GetRegVal(reg2055List, 0x02).GetPart(0, 5);

            //刷新组数 input2072Simple2|1,8,14 
            //int nGroup = GetPartOfUInt32(nMode, 0x01, 8, 14);
            int nGroup = GetRegVal(reg2055List, 0x03).GetPart(0, 6);

            //每行每组寄存器值(reg0x02[31:24],PWM显示时间) input2072Simple7|2,24,31;2,16,23;3,24,31
            //int nPWMTime = GetPartOfUInt32(nMode, 0x02, 24, 31);
            int nPWMTime = GetRegVal(reg2055List, 0x07).GetPart(0, 7);

            //input2072Simple5|4,8,12
            //int nPLL_LOOP_DIV = GetPartOfUInt32(nMode, 0x04, 8, 12);
            int nPLL_LOOP_DIV = GetRegVal(reg2055List, 0x05).GetPart(0, 4);

            //input2072Simple6|4,0,4
            //int nPLL_PRE_DIV = GetPartOfUInt32(nMode, 0x04, 0, 4);
            int nPLL_PRE_DIV = GetRegVal(reg2055List, 0x04).GetPart(0, 4);

            //根据60Hz ，50Hz ，3D的状态来选择
            double C = 0;
            switch (nMode)//0 = 60Hz  1=50Hz  2=3D
            {
                case 0:
                    C = 16.67f;
                    break;
                case 1:
                    C = 20f;
                    break;
                case 2:
                    C = 5.33f;
                    break;
            }

            //
            double D = 62.5f;//单位：ns

            //if (szUnitType == "TWA0.9(A)")
            //{
            //    D = 50f;
            //}

            //计算出N 128寄存器的值
            //int N = (int)Math.Floor((double)(1000000 * C) / (double)(D * (nScan + 1) * (nGroup + 1))) - 2;//2018-10-8 结果上减2
            int N = (int)Math.Floor((double)(1000000 * C) / (double)(D * (nScan + 1) * (nGroup + 1))) - 2;//2018-10-8 结果上减2
            //60hz分之一, * 10的9次方，除以NGROUP + 1 除以行扫 + 1  除以62.5(16M 跟DLOCK有关，界面输入) 减去2
            //int N = (int)(1 / 60f * Math.Pow(10, 9) / (nGroup + 1) / (nScan + 1) / 62.5) - 2;

            //计算出最大灰度级数
            int nMaxGrayLevel = nPWMTime * 4 * (nGroup + 1);

            //计算出GAMMA最大值位数
            int nMaxGAMMAValueBit = GetGAMMAbit((ushort)nMaxGrayLevel);


            int nLeft = (int)Math.Floor(4 * nPWMTime * 1000 / ((1000 / D) * nPLL_LOOP_DIV / nPLL_PRE_DIV));
            int nRight = (int)Math.Floor((N - 16) * D);

            //检验合规性结果
            bool bCheckOK = (nLeft <= nRight);


            //--------------------------输出结果:--------------------------

            //0:行扫 input2072Simple3|1,0,5
            list.Add(nScan);

            //1:刷新组数 input2072Simple2|1,8,14 
            list.Add(nGroup);

            //2:每行每组寄存器值(reg0x02[31:24],PWM显示时间) input2072Simple7|2,24,31;2,16,23;3,24,31
            list.Add(nPWMTime);

            //3.
            list.Add(nPLL_LOOP_DIV);

            //4.
            list.Add(nPLL_PRE_DIV);

            //5:128寄存器的值
            list.Add(N);

            //6:计算出最大灰度级数
            list.Add(nMaxGrayLevel);

            //7:计算出GAMMA最大值位数
            list.Add(nMaxGAMMAValueBit);

            //8:左侧计算
            list.Add(nLeft);

            //9:右侧计算
            list.Add(nRight);

            //10:合规性判断
            //list.Add(bCheckOK);
            list.Add(true);

            return list;
        }
    }

    public static class Register2072Helper
    {
        private static int Reg2072StartAddr = 0x5E * 2;

        public static byte[] Data { get; set; }

        static Register2072Helper()
        {
            Reload2072DefaultData();
        }

        public static void Reload2072DefaultData()
        {
            Data = new byte[1024].Fill(0xFF);
            ushort[] arrDefualt = {
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0001,0x0001,0x0000,0x0002,0x0000,0x0000,0x0000,
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0xB6B6,
                    0xB6C0,0x0000,0x0306,0x0004,0x0200,0xF000,0x16E0,0x7F00,0x6F00,0x6B00,0x8100,0x0000,0x0000,0x0000,0x0000,0x101B,
                    0x0000,0x0000,0x0802,0x0606,0x4111,0x4FFF,0x1FE0,0xE03D,0x0057,0x0050,0x0059,0x0010,0x0000,0x0000,0x0000,0x0000,
                    0x00FA,0x0000,0x0000,0x0000,0x0001,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,
                    0x0000,0x0000,0x7FFF,0x7FFF,0x7FFF,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,
                    0x0020,0x000F,0x0030,0x000A,0xFFFF,0x3FFF,0x3FFF,0x3FFF,0xFFFF,0x3FFF,0x3FFF,0x03FF,0xFFFF,0xFFFF,0xFFFF,0xFFFF,
                    0xFFFF,0xFFFF,0xFFFF,0xFFFF,0xFFFF,0xFFFF,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,
                    0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000 };




































            byte[] bytesData = arrDefualt.GetBytes();
            Array.Copy(bytesData, 0, Data, 0, bytesData.Length);
        }

        public static Register Load2072Register(string file)
        {
            Reload2072DefaultData();
            Register reg = new Register();

            if (!File.Exists(file))
            {
                return null;
            }

            using (TextReader reader = new StreamReader(file, Encoding.UTF8))
            {
                if (ReadSpectialRegisterData(ref reg, reader) == false)
                {
                    return null;
                }
            }
            using (TextReader reader = new StreamReader(file, Encoding.UTF8))
            {
                if (ReadRegister2072(ref reg, reader) == false)
                {
                    return null;
                }
            }

            using (TextReader reader = new StreamReader(file, Encoding.UTF8))
            {
                if (ReadOtherRegister(ref reg, reader) == false)
                {
                    return null;
                }
            }

            return reg;
        }

        private static bool ReadSpectialRegisterData(ref Register reg, TextReader reader)
        {
            int lineIndex1 = 0;//用于查找特殊航
            string lineData = string.Empty;
            List<RegisterItem> RegisterItemList = new List<RegisterItem>();
            while ((lineData = reader.ReadLine()) != null)
            {
                string[] data = lineData.Split('\t');

                if (lineIndex1 == 0)
                {
                    if (data.Length != 3)
                    {
                        return false;
                    }

                    if (!byte.TryParse(data[1], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte refreshRate))
                    {
                        return false;
                    }

                    if (!bool.TryParse(data[2], out bool isDebug))
                    {
                        return false;
                    }
                    reg.Is2055Debug = isDebug;
                    lineIndex1++;
                }
                else if (lineIndex1 == 1)
                {
                    if (data.Length != 5)
                    {
                        return false;
                    }
                    RegisterSpectialItem specialFPGA = new RegisterSpectialItem();

                    if (!byte.TryParse(data[1], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte startBit))
                    {
                        return false;
                    }
                    specialFPGA.StartBit = startBit;

                    if (!byte.TryParse(data[2], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte endBit))
                    {
                        return false;
                    }
                    specialFPGA.StopBit = endBit;
                    if (!int.TryParse(data[3], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int addr))
                    {
                        return false;
                    }
                    specialFPGA.RegisterAddress = addr;
                    specialFPGA.Value = byte.Parse(data[4]);
                    reg.Special2055Register = specialFPGA;
                    lineIndex1++;
                    break;
                }
            }
            return true;
        }

        private static bool ReadRegister2072(ref Register reg, TextReader reader)
        {
            int lineIndex = 0;
            string lineData = string.Empty;
            List<RegisterItem> RegisterItemList = new List<RegisterItem>();
            bool isFind = false;
            while ((lineData = reader.ReadLine()) != null)
            {
                string[] data = lineData.Split('\t');
                if (lineData == "******************************************************************* Start 2055 *************************************************************************")
                {
                    isFind = true;
                    lineIndex = 0;
                    continue;
                }
                if (lineData == "******************************************************************* End 2055 *************************************************************************") break;
                if (isFind)
                {
                    if (lineIndex == 0)
                    {
                        //标题
                        lineIndex++;
                        continue;
                    }
                    RegisterItem registerItem = new RegisterItem();
                    if (data.Length != 16)
                    {
                        return false;
                    }
                    UInt16 fpgaAddress = 0;
                    if (!UInt16.TryParse(data[1], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out fpgaAddress))
                    {
                        return false;
                    }
                    registerItem.RedAddress = data[1];

                    if (!UInt16.TryParse(data[2], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out fpgaAddress))
                    {
                        return false;
                    }
                    registerItem.GreenAddress = data[2];

                    if (!UInt16.TryParse(data[3], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out fpgaAddress))
                    {
                        return false;
                    }
                    registerItem.BlueAddress = data[3];

                    byte regAddress = 0;
                    if (!byte.TryParse(data[4], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out regAddress))
                    {
                        return false;
                    }
                    registerItem.RegisterAddress = data[4];

                    if (!byte.TryParse(data[5], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte startBit))
                    {
                        return false;
                    }
                    registerItem.StartBit = startBit;

                    if (!byte.TryParse(data[6], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte endBit))
                    {
                        return false;
                    }
                    registerItem.StopBit = endBit;

                    if (!byte.TryParse(data[7], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte minValue))
                    {
                        return false;
                    }
                    registerItem.MinValue = minValue;

                    if (!byte.TryParse(data[8], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte maxValue))
                    {
                        return false;
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
                    lineIndex++;
                }
            }
            return true;
        }

        private static bool ReadOtherRegister(ref Register reg, TextReader reader)
        {
            int lineIndex = 0;
            string lineData = string.Empty;
            List<RegisterOtherItem> RegisterItemList = new List<RegisterOtherItem>();
            bool isFind = false;
            while ((lineData = reader.ReadLine()) != null)
            {
                string[] data = lineData.Split('\t');
                if (lineData == "******************************************************************* Start Other *************************************************************************")
                {
                    isFind = true;
                    lineIndex = 0;
                    continue;
                }
                if (lineData == "******************************************************************* End Other *************************************************************************") break;
                if (isFind)
                {
                    if (lineIndex == 0)
                    {
                        //标题
                        lineIndex++;
                        continue;
                    }
                    RegisterOtherItem registerItem = new RegisterOtherItem();
                    if (data.Length != 9)
                    {
                        return false;
                    }
                    UInt16 fpgaAddress = 0;
                    if (!UInt16.TryParse(data[1], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out fpgaAddress))
                    {
                        return false;
                    }
                    registerItem.Address = data[1];

                    //registerItem.RegisterAddress = data[4];

                    if (!byte.TryParse(data[2], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte startBit))
                    {
                        return false;
                    }
                    registerItem.StartBit = startBit;

                    if (!byte.TryParse(data[3], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte endBit))
                    {
                        return false;
                    }
                    registerItem.StopBit = endBit;

                    if (!UInt16.TryParse(data[4], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out UInt16 minValue))
                    {
                        return false;
                    }
                    registerItem.MinValue = minValue.ToString("X4");

                    if (!UInt16.TryParse(data[5], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out UInt16 maxValue))
                    {
                        return false;
                    }
                    registerItem.MaxValue = maxValue.ToString("X4");

                    registerItem.Value = data[6];
                    registerItem.ChineseDescription = data[7];
                    registerItem.EnglishDescription = data[8];
                    reg.Register2055OtherItemList.Add(registerItem);
                    lineIndex++;
                }
            }
            return true;
        }

        public static void Save2072Register(Register register, string file)
        {
            using (TextWriter writer = new StreamWriter(file))
            {
                int cx = 0;
                writer.WriteLine($"{cx}\t{0}\t{register.Is2055Debug}");
                cx++;
                writer.WriteLine($"{cx}\t{register.Special2055Register.StartBit}\t{register.Special2055Register.StopBit}\t{register.Special2055Register.RegisterAddress}\t{register.Special2055Register.Value}");
                cx++;
                writer.WriteLine("******************************************************************* Start 2055 *************************************************************************");
                writer.WriteLine("序号    FPGA红色地址    FPGA绿色地址    FPGA蓝色地址    恒流源地址   起始位 结束位  最小值   最大值  红色值     绿色纸     蓝色值  偏移量   说明     中文说明    英文说明");
                cx = 0;
                foreach (var item in register.Register2055ItemList)
                {
                    //序号    FPGA红色地址    FPGA绿色地址    FPGA蓝色地址    恒流源地址   起始位 结束位  最小值   最大值  红色值     绿色纸     蓝色值  偏移量   说明     中文说明    英文说明
                    writer.WriteLine($"{cx}\t{item.RedAddress}\t{item.GreenAddress}\t{item.BlueAddress}\t{item.RegisterAddress}\t{item.StartBit}\t{item.StopBit}\t{item.MinValue.ToString("X2")}\t{item.MaxValue.ToString("X2")}\t{item.RedValue}\t{item.GreenValue}\t{item.BlueValue}\t{item.Offset}\t{item.Description}\t{item.ChineseDescription}\t{item.EnglishDescription}");
                    cx++;
                }
                writer.WriteLine("******************************************************************* End 2055 *************************************************************************");
                writer.WriteLine("******************************************************************* Start Other *************************************************************************");
                writer.WriteLine("序号	地址	起始位	终止位	最小值	最大值	默认值	中文描述	英文描述");
                cx = 0;
                foreach (var item in register.Register2055OtherItemList)
                {
                    writer.WriteLine($"{cx}\t{item.Address}\t{item.StartBit.ToString("X2")}\t{item.StopBit.ToString("X2")}\t{item.MinValue}\t{item.MaxValue}\t{item.Value}\t{item.ChineseDescription}\t{item.EnglishDescription}");
                    cx++;
                }
                writer.WriteLine("******************************************************************* End Other *************************************************************************");
            }

        }

        public static void CombinReg2072(List<RegisterItem> reg2055List)
        {
            int position = Reg2072StartAddr;
            for (byte i = 0x12; i <= 0x77; i++)
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
        public static void SplitReg2072(List<RegisterItem> reg2055List)
        {
            int position = Reg2072StartAddr;
            for (byte i = 0x12; i < 0x77; i++)
            {
                List<RegisterSpectialItem> reg = GetRegisterItem(reg2055List, i);
                foreach (var item in reg)
                {
                    //CombinData(position, item.Value, item.StartBit, item.StopBit);
                    if (item.Color == EnumRegColor.Red)
                    {
                        byte val = Register2055Helper.Data[position + 1].GetPart(item.StartBit, item.StopBit);
                        item.Register.RedValue = val.ToString("X2");

                    }
                    else if (item.Color == EnumRegColor.Green)
                    {
                        byte val = Register2055Helper.Data[position + 1].GetPart(item.StartBit, item.StopBit);
                        item.Register.GreenValue = val.ToString("X2");
                    }
                    else if (item.Color == EnumRegColor.Blue)
                    {
                        byte val = Register2055Helper.Data[position + 1].GetPart(item.StartBit, item.StopBit);
                        item.Register.BlueValue = val.ToString("X2");
                    }
                }
                position += 2;
            }
        }

        /// <summary>
        /// 将字节数组数据解析成类对象
        /// </summary>
        /// <param name="reg2055List"></param>
        public static void SplitRegOther(List<RegisterOtherItem> regList)
        {
            //int position = Reg2055StartAddr;
            //for (byte i = 0x12; i < 0x77; i++)
            //{
            //    List<RegisterSpectialItem> reg = GetRegisterItem(reg2055List, i);
            //    foreach (var item in reg)
            //    {
            //        //CombinData(position, item.Value, item.StartBit, item.StopBit);
            //        if (item.Color == EnumRegColor.Red)
            //        {
            //            byte val = RegisterHelper.Data[position + 1].GetBitRangeValue(item.StartBit, item.StopBit);
            //            item.Register.RedValue = val.ToString("X2");

            //        }
            //        else if (item.Color == EnumRegColor.Green)
            //        {
            //            byte val = RegisterHelper.Data[position + 1].GetBitRangeValue(item.StartBit, item.StopBit);
            //            item.Register.GreenValue = val.ToString("X2");
            //        }
            //        else if (item.Color == EnumRegColor.Blue)
            //        {
            //            byte val = RegisterHelper.Data[position + 1].GetBitRangeValue(item.StartBit, item.StopBit);
            //            item.Register.BlueValue = val.ToString("X2");
            //        }
            //    }
            //    position += 2;
            //}

            //int position = 0 * 2;
            //for (byte i = 0x00; i <= 0x2; i++)
            //{
            //    List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
            //    foreach (var item in reg)
            //    {
            //        byte[] vals = new byte[2];
            //        vals[0] = RegisterHelper.Data[position].GetBitRangeValue(item.StartBit, item.StopBit);
            //        vals[1] = RegisterHelper.Data[position + 1].GetBitRangeValue(item.StartBit, item.StopBit);
            //        item.Value = vals.GetUInt16();
            //    }
            //    position += 2;
            //}

            int position = 0 * 2;
            for (byte i = 0x00; i <= 0x2; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    byte[] vals = new byte[2];
                    //vals[0] = RegisterHelper.Data[position].GetBitRangeValueFromUInt16(item.StartBit, item.StopBit);
                    //vals[1] = RegisterHelper.Data[position + 1].GetBitRangeValueFromUInt16(item.StartBit, item.StopBit);
                    vals[0] = Register2055Helper.Data[position];
                    vals[1] = Register2055Helper.Data[position + 1];
                    ushort data = vals.GetUInt16(0).GetPart(item.StartBit, item.StopBit);
                    item.Value = data.ToString("X4");
                }
                position += 2;
            }

            position = 0x06 * 2;
            for (byte i = 0x06; i <= 0x0F; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    byte[] vals = new byte[2];
                    //vals[0] = RegisterHelper.Data[position].GetBitRangeValueFromUInt16(item.StartBit, item.StopBit);
                    //vals[1] = RegisterHelper.Data[position + 1].GetBitRangeValueFromUInt16(item.StartBit, item.StopBit);
                    vals[0] = Register2055Helper.Data[position];
                    vals[1] = Register2055Helper.Data[position + 1];
                    ushort data = vals.GetUInt16(0).GetPart(item.StartBit, item.StopBit);
                    item.Value = data.ToString("X4");
                }
                position += 2;
            }
            position = 0x80 * 2;
            for (byte i = 0x80; i <= 0x80; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    byte[] vals = new byte[2];
                    //vals[0] = RegisterHelper.Data[position].GetBitRangeValueFromUInt16(item.StartBit, item.StopBit);
                    //vals[1] = RegisterHelper.Data[position + 1].GetBitRangeValueFromUInt16(item.StartBit, item.StopBit);
                    vals[0] = Register2055Helper.Data[position];
                    vals[1] = Register2055Helper.Data[position + 1];
                    ushort data = vals.GetUInt16(0).GetPart(item.StartBit, item.StopBit);
                    item.Value = data.ToString("X4");
                }
                position += 2;
            }
            position = 0x83 * 2;
            for (byte i = 0x83; i <= 0x98; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    byte[] vals = new byte[2];
                    //vals[0] = RegisterHelper.Data[position].GetBitRangeValueFromUInt16(item.StartBit, item.StopBit);
                    //vals[1] = RegisterHelper.Data[position + 1].GetBitRangeValueFromUInt16(item.StartBit, item.StopBit);
                    vals[0] = Register2055Helper.Data[position];
                    vals[1] = Register2055Helper.Data[position + 1];
                    ushort data = vals.GetUInt16(0).GetPart(item.StartBit, item.StopBit);
                    item.Value = data.ToString("X4");
                }
                position += 2;
            }
            position = 0xA4 * 2;
            for (byte i = 0xA4; i <= 0xB5; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    byte[] vals = new byte[2];
                    //vals[0] = RegisterHelper.Data[position].GetBitRangeValueFromUInt16(item.StartBit, item.StopBit);
                    //vals[1] = RegisterHelper.Data[position + 1].GetBitRangeValueFromUInt16(item.StartBit, item.StopBit);
                    vals[0] = Register2055Helper.Data[position];
                    vals[1] = Register2055Helper.Data[position + 1];
                    ushort data = vals.GetUInt16(0).GetPart(item.StartBit, item.StopBit);
                    item.Value = data.ToString("X4");
                }
                position += 2;
            }

            position = 0xC0 * 2;
            for (byte i = 0xC0; i <= 0xC0; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    byte[] vals = new byte[2];
                    vals[0] = Register2055Helper.Data[position];
                    vals[1] = Register2055Helper.Data[position + 1];
                    ushort data = vals.GetUInt16(0).GetPart(item.StartBit, item.StopBit);
                    item.Value = data.ToString("X4");
                }
                position += 2;
            }


            position = 0xC1 * 2;
            for (byte i = 0xC1; i <= 0xC1; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    byte[] vals = new byte[2];
                    vals[0] = Register2055Helper.Data[position];
                    vals[1] = Register2055Helper.Data[position + 1];
                    ushort data = vals.GetUInt16(0).GetPart(item.StartBit, item.StopBit);
                    item.Value = data.ToString("X4");
                }
                position += 2;
            }
        }

        public static void CombinOtherReg(List<RegisterOtherItem> regList)
        {
            //int position = 0;
            //for (byte i = 0x00; i < 0x11; i++)
            //{
            //    List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
            //    foreach (var item in reg)
            //    {
            //        CombinData(position, item.Value, item.StartBit, item.StopBit);
            //    }
            //    position += 2;
            //}
            int position = 0 * 2;
            for (byte i = 0x00; i <= 0x2; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    CombinData(position, item.Value.GetUInt16(NumberStyles.HexNumber), item.StartBit, item.StopBit);
                }
                position += 2;
            }
            position = 0x06 * 2;
            for (byte i = 0x06; i <= 0x0F; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    CombinData(position, item.Value.GetUInt16(NumberStyles.HexNumber), item.StartBit, item.StopBit);
                }
                position += 2;
            }
            position = 0x80 * 2;
            for (byte i = 0x80; i <= 0x80; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    CombinData(position, item.Value.GetUInt16(NumberStyles.HexNumber), item.StartBit, item.StopBit);
                }
                position += 2;
            }
            position = 0x83 * 2;
            for (byte i = 0x83; i <= 0x98; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    CombinData(position, item.Value.GetUInt16(NumberStyles.HexNumber), item.StartBit, item.StopBit);
                }
                position += 2;
            }
            position = 0xA4 * 2;
            for (byte i = 0xA4; i <= 0xB5; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    CombinData(position, item.Value.GetUInt16(NumberStyles.HexNumber), item.StartBit, item.StopBit);
                }
                position += 2;
            }
            position = 0xC0 * 2;
            for (byte i = 0xC0; i <= 0xC0; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    CombinData(position, item.Value.GetUInt16(NumberStyles.HexNumber), item.StartBit, item.StopBit);
                }
                position += 2;
            }
            position = 0xC1 * 2;
            for (byte i = 0xC1; i <= 0xC1; i++)
            {
                List<RegisterOtherItem> reg = GetOtherRegisterItem(regList, i);
                foreach (var item in reg)
                {
                    CombinData(position, item.Value.GetUInt16(NumberStyles.HexNumber), item.StartBit, item.StopBit);
                }
                position += 2;
            }
        }

        private static void CombinData(int position, UInt16 newData, int startBit, int stopBit)
        {
            //string binaryVal = newData.GetBinaryString(stopBit - startBit + 1).Reverse();

            //byte[] data1 = new byte[2];
            //data1[0] = Data[position];
            //data1[1] = Data[position + 1];
            //UInt16 uData1 = data1.GetUInt16(0);
            //string binaryVal1 = uData1.GetBinaryString(16).Reverse();
            //int index = 0;
            //for (int i = startBit; i <= stopBit; i++)
            //{
            //    string str1 = binaryVal.Substring(index++, 1);
            //    binaryVal1 = binaryVal1.Replace(i, str1);
            //}
            //binaryVal1 = binaryVal1.Reverse();
            //UInt16 data2 = Convert.ToUInt16(binaryVal1, 2);
            //byte[] data3 = data2.GetBytes();
            //Data[position] = data3[0];
            //Data[position + 1] = data3[1];

            UInt16 tmp = Data.GetUInt16(position).ModifyPart(startBit, stopBit, newData);
            byte[] tmp1 = tmp.GetBytes();
            Data[position] = tmp1[0];
            Data[position + 1] = tmp1[1];
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
                        Value = item.RedValue.GetByte(NumberStyles.HexNumber),
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
                        Value = item.GreenValue.GetByte(NumberStyles.HexNumber),
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
                        Value = item.BlueValue.GetByte(NumberStyles.HexNumber),
                        Color = EnumRegColor.Blue,
                        Register = item
                    });
                }
            }
            return result;
        }

        private static List<RegisterOtherItem> GetOtherRegisterItem(List<RegisterOtherItem> regItemList, byte regAddr)
        {
            //List<RegisterOtherItem> result = new List<RegisterOtherItem>();
            //foreach (var item in regItemList)
            //{
            //    string strAddr = regAddr.ToString("X2");
            //    if (item.Address.ToUInt16().ToString("X2") == strAddr)
            //    {
            //        result.Add(item);
            //    }
            //}
            //return result;

            List<RegisterOtherItem> result = new List<RegisterOtherItem>();
            foreach (var item in regItemList)
            {
                //string strAddr = regAddr.ToString("X2");
                if (item.Address.GetByte(NumberStyles.HexNumber) == regAddr)
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
