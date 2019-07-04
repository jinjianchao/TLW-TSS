﻿#region << 注释 >>
/************************************************************************
*文件名： CalibrationHelper
*创建人： JIN
*创建时间：2019/6/25 9:38:02
*描述：
*=======================================================================
*修改时间：2019/6/25 9:38:02
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
    public static class CalibrationHelper
    {
        public static byte[] Read(int row, int column, string file)
        {
            byte[] data = new byte[row * 4096].Fill(0xFF);
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(fs);
            //写SDRAM。1.56  M:192*108  文件大小:192*216  每次读取1行：192*16字节 . 放入4096（放前边），后边默认FF.
            int position = 0;
            byte[] lineData;
            int cx = 0;
            while ((lineData = reader.ReadBytes(column * 16)).Length != 0)
            {
                //if (cx == 0)
                //{
                //    lineData.Fill(0x00);
                //    //lineData[0] = 0xff;
                //    //lineData[1] = 0xff;
                //    //for (int i = 0; i < 16; i++)
                //    //{
                //    //    lineData[i] = 0xff;
                //    //}
                //    lineData[0] = 0xff;
                //    lineData[1] = 0xff;
                //    lineData[5] = 0xff;
                //    lineData[6] = 0xff;
                //    lineData[10] = 0xff;
                //    lineData[11] = 0xff;
                //    //for (int i = 0; i < 16; i++)
                //    //{
                //    //    lineData[i + 1] = (byte)(0x11 + i);

                //    //}
                //}
                //else
                //{
                //    lineData.Fill(0x00);
                //}
                Array.Copy(lineData, 0, data, position, lineData.Length);
                position += 4096;
                cx++;
            }
            reader.Close();
            return data;
        }

        public static void Write(byte[] data, string file)
        {
            FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(fs);
            //int position = 0;
            //int count = data.Length / 4096;
            //for (int i = 0; i < count; i++)
            //{
            //    //192*16
            //    byte[] lineData = new byte[192 * 16];
            //    Array.Copy(data, position, lineData, 0, lineData.Length);
            //    writer.Write(lineData);

            //    position += 4096;
            //}
            writer.Write(data);
            writer.Flush();
            writer.Close();
        }

        public static void Split(string file)
        {
            //FileInfo fileInfo = new FileInfo(file);
            //long fileLen = fileInfo.Length;
            //FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            //BinaryReader reader = new BinaryReader(fs);
            //int position = 0;
            //byte[] lineData;
            //while ((lineData = reader.ReadBytes(column * 16)).Length != 0)
            //{
            //    Array.Copy(lineData, 0, data, position, lineData.Length);
            //    position += 4096;
            //}
            //reader.Close();
            //return data;
        }
    }
}
