#region << 注释 >>
/************************************************************************
*文件名： MapHelper
*创建人： JIN
*创建时间：2019/6/24 11:06:47
*描述：
*=======================================================================
*修改时间：2019/6/24 11:06:47
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SFTHelper.Extentions;

namespace TLWController.Helper
{
    public class MapHelper
    {
        public static byte[] Data;

        private static Dictionary<string, string> MapData { get; set; }

        static MapHelper()
        {
            MapData = new Dictionary<string, string>();
        }

        public static bool LoadMap(string file)
        {
            if (System.IO.File.Exists(file) == false) return false;
            if (System.IO.Path.GetExtension(file) != ".mif") return false;
            if (!GetMapData(file)) return false;
            ToBytesArray();
            return true;
        }

        public static bool SaveMap(string file, byte[] data)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-- Copyright (C) 1991-2013 Altera Corporation");
            sb.AppendLine("-- Your use of Altera Corporation's design tools, logic functions ");
            sb.AppendLine("-- and other software and tools, and its AMPP partner logic ");
            sb.AppendLine("-- functions, and any output files from any of the foregoing ");
            sb.AppendLine("-- (including device programming or simulation files), and any ");
            sb.AppendLine("-- associated documentation or information are expressly subject ");
            sb.AppendLine("-- to the terms and conditions of the Altera Program License ");
            sb.AppendLine("-- Subscription Agreement, Altera MegaCore Function License ");
            sb.AppendLine("-- Agreement, or other applicable license agreement, including,");
            sb.AppendLine("-- without limitation, that your use is for the sole purpose of");
            sb.AppendLine("-- programming logic devices manufactured by Altera and sold by");
            sb.AppendLine("-- Altera or its authorized distributors.  Please refer to the ");
            sb.AppendLine("-- applicable agreement for further details.");
            sb.AppendLine("");
            sb.AppendLine("-- Quartus II generated Memory Initialization File (.mif)");
            sb.AppendLine("");
            sb.AppendLine("WIDTH=16;");
            sb.AppendLine("DEPTH=2048;");
            sb.AppendLine("");
            sb.AppendLine("ADDRESS_RADIX=HEX;");
            sb.AppendLine("DATA_RADIX=HEX;");
            sb.AppendLine("CONTENT BEGIN");
            UInt16 addr = 0x0000;
            for (int i = 0; i < data.Length / 2; i++)
            {
                byte[] tmp = new byte[2];
                tmp[0] = data[i * 2];
                tmp[1] = data[i * 2 + 1];
                UInt16 val = tmp.GetUInt16(0);
                sb.AppendLine($"\t{addr.ToString("X4")}:{tmp.GetUInt16(0).ToString("X4")};");
                addr++;
            }
            sb.AppendLine("END;");
            File.WriteAllText(file, sb.ToString());
            return true;
        }

        private static bool GetMapData(string file)
        {
            try
            {
                MapData.Clear();
                using (TextReader reader = new StreamReader(file))
                {
                    bool isFindStart = false;
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line == "CONTENT BEGIN")
                        {
                            isFindStart = true;//找到数据开始位置
                            continue;
                        }
                        if (line == "END;") return true;//数据结尾
                        if (isFindStart)
                        {
                            //[000..04F]  :   FFFF;
                            //050  :   F06C;
                            string[] addrAndValueArr = line.Replace("\t", "").Replace(";", "").Split(':');
                            addrAndValueArr[0] = addrAndValueArr[0].Trim();
                            if (addrAndValueArr[0].StartsWith("[") && addrAndValueArr[0].EndsWith("]"))
                            {
                                //多个连续寄存器数据
                                addrAndValueArr[0] = addrAndValueArr[0].Replace("[", "").Replace("]", "");
                                string[] addrRange = addrAndValueArr[0].Split(new[] { ".." }, StringSplitOptions.None);
                                Int32 startaddr = addrRange[0].GetInt32(System.Globalization.NumberStyles.HexNumber);
                                Int32 endaddr = addrRange[1].GetInt32(System.Globalization.NumberStyles.HexNumber);
                                for (int i = startaddr; i <= endaddr; i++)
                                {
                                    MapData.Add(i.ToString("X4"), addrAndValueArr[1].Trim().GetInt32(System.Globalization.NumberStyles.HexNumber).ToString("X4"));
                                }
                            }
                            else
                            {
                                //单个寄存器数据
                                MapData.Add(addrAndValueArr[0].Trim().GetInt32(System.Globalization.NumberStyles.HexNumber).ToString("X4"), addrAndValueArr[1].Replace(";", "").Trim().GetInt32(System.Globalization.NumberStyles.HexNumber).ToString("X4"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        private static void ToBytesArray()
        {
            List<byte> data = new List<byte>();
            foreach (var item in MapData)
            {
                byte[] byteData = item.Value.GetUInt16(System.Globalization.NumberStyles.HexNumber).GetBytes();
                data.Add(byteData[0]);
                data.Add(byteData[1]);
            }
            MapHelper.Data = data.ToArray();
        }
    }
}
