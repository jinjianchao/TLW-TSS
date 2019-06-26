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
using TLWController.Extentions;

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

        private static bool GetMapData(string file)
        {
            try
            {
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
                                Int32 startaddr = addrRange[0].ToInit32(System.Globalization.NumberStyles.HexNumber);
                                Int32 endaddr = addrRange[1].ToInit32(System.Globalization.NumberStyles.HexNumber);
                                for (int i = startaddr; i <= endaddr; i++)
                                {
                                    MapData.Add(i.ToString("X4"), addrAndValueArr[1].Trim().ToInit32(System.Globalization.NumberStyles.HexNumber).ToString("X4"));
                                }
                            }
                            else
                            {
                                //单个寄存器数据
                                MapData.Add(addrAndValueArr[0].Trim().ToInit32(System.Globalization.NumberStyles.HexNumber).ToString("X4"), addrAndValueArr[1].Replace(";", "").Trim().ToInit32(System.Globalization.NumberStyles.HexNumber).ToString("X4"));
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
                byte[] byteData = item.Value.ToUInt16(System.Globalization.NumberStyles.HexNumber).GetBytes();
                data.Add(byteData[0]);
                data.Add(byteData[1]);
            }
            MapHelper.Data = data.ToArray();
        }
    }
}
