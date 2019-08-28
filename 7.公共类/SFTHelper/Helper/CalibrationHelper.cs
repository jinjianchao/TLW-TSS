#region << 注释 >>
/************************************************************************
*文件名： CalibrationHelper
*创建人： JIN
*创建时间：2019/8/8 10:14:22
*描述：
*=======================================================================
*修改时间：2019/8/8 10:14:22
*修改人：
*描述：
************************************************************************/
#endregion

using SFTHelper.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SFTHelper.Extentions;


namespace SFTHelper.Helper
{
    public class CalibrationHelper
    {
        private int _modulePixelWidth;//单个模块像素宽度
        private int _modulePixelHeight;//单个模块像素高度
        private int _moduleWidth;//模块列数
        private int _moduleHeight;//模块行数

        public CalibrationHelper(int moduleWidth, int moduleHeight, int modulePixelWidth, int modulePixelHeight)
        {
            _moduleWidth = moduleWidth;
            _moduleHeight = moduleHeight;
            _modulePixelWidth = modulePixelWidth;
            _modulePixelHeight = modulePixelHeight;
        }

        private int _cabinetWidth { get { return _modulePixelWidth * _moduleWidth; } }//箱体宽度

        private int _cabinetHeight { get { return _modulePixelHeight * _moduleHeight; } }//箱体高度

        private bool ReadZDat(string file, out byte[] outData, EnumCALTarget style)
        {
            if (style == EnumCALTarget.Cabinet)
            {
                int len = _cabinetWidth * _cabinetHeight * 16;
                FileStream fsIn = new FileStream(file, FileMode.Open);
                if (fsIn.Length != len)
                {
                    outData = null;
                    fsIn.Close();
                    return false;
                }
                outData = new byte[len];
                //读取整个文件
                if (fsIn.Read(outData, 0, outData.Length) != outData.Length)
                {
                    fsIn.Close();
                    return false;
                }
                fsIn.Close();//关闭文件
                return true;
            }
            else if (style == EnumCALTarget.Module)
            {
                int len = _modulePixelWidth * _modulePixelHeight * 16;
                FileStream fsIn = new FileStream(file, FileMode.Open);
                if (fsIn.Length != len)
                {
                    outData = null;
                    fsIn.Close();
                    return false;
                }
                outData = new byte[len];
                //读取整个文件
                if (fsIn.Read(outData, 0, outData.Length) != outData.Length)
                {
                    fsIn.Close();
                    return false;
                }
                fsIn.Close();//关闭文件
                return true;
            }
            outData = null;
            return false;
        }

        private bool ReadSDat(string file, out byte[] outData, EnumCALTarget style)
        {
            if (style == EnumCALTarget.Cabinet)
            {
                int len = _cabinetWidth * _cabinetHeight * 18;
                outData = new byte[len];
                int readLen = 0;
                FileStream reader = null;
                try
                {
                    reader = new FileStream(file, FileMode.Open, FileAccess.Read);
                    if (reader.Length == len)
                    {
                        readLen = reader.Read(outData, 0, len);//读取整个纯校正文件
                    }
                    else
                    {
                        reader.Close();//关闭文件
                        outData = null;
                        return false;
                    }
                    return true;
                }
                catch
                {
                    outData = null;
                    return false;
                }
                reader.Close();
            }
            else if (style == EnumCALTarget.Module)
            {
                int len = _modulePixelWidth * _modulePixelHeight * 18;
                outData = new byte[len];
                int readLen = 0;
                FileStream reader = null;
                try
                {
                    reader = new FileStream(file, FileMode.Open, FileAccess.Read);
                    if (reader.Length == len)
                    {
                        readLen = reader.Read(outData, 0, len);//读取整个纯校正文件
                    }
                    else
                    {
                        reader.Close();//关闭文件
                        outData = null;
                        return false;
                    }
                    return true;
                }
                catch
                {
                    outData = null;
                    return false;
                }
                reader.Close();
            }
            outData = null;
            return false;
        }

        private bool ReadDat(string file, out byte[] outData, EnumCALTarget style)
        {
            outData = null;
            if (style == EnumCALTarget.Cabinet)
            {
                int len = (_cabinetWidth * 18 + 10) * _cabinetHeight;
                outData = new byte[len];
                int readLen = 0;
                FileStream reader = null;
                try
                {
                    reader = new FileStream(file, FileMode.Open, FileAccess.Read);
                    if (reader.Length == len)
                    {
                        readLen = reader.Read(outData, 0, len);//读取整个纯校正文件
                    }
                    else
                    {
                        reader.Close();//关闭文件
                        outData = null;
                        return false;
                    }
                }
                catch
                {
                    outData = null;
                    return false;
                }
                reader.Close();
            }
            else if (style == EnumCALTarget.Module)
            {
                int len = (_modulePixelWidth * 18 + 10) * _modulePixelHeight;
                outData = new byte[len];
                int readLen = 0;
                FileStream reader = null;
                try
                {
                    reader = new FileStream(file, FileMode.Open, FileAccess.Read);
                    if (reader.Length == len)
                    {
                        readLen = reader.Read(outData, 0, len);//读取整个纯校正文件
                    }
                    else
                    {
                        reader.Close();//关闭文件
                        outData = null;
                        return false;
                    }
                }
                catch
                {
                    outData = null;
                    return false;
                }
                reader.Close();
            }
            return true;
        }

        private bool SaveToFile(string path, byte[] src)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                if (fs == null) return false;//创建失败

                //输出纯校正数据
                fs.Write(src, 0, src.Length);
                fs.Flush();
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;

        }

        private bool ConvertDatToSDat(byte[] src, out byte[] target, EnumCALTarget style)
        {
            int width = 0;
            int height = 0;
            target = null;

            if (style == EnumCALTarget.Cabinet)
            {
                width = _cabinetWidth;
                height = _cabinetHeight;
            }
            else if (style == EnumCALTarget.Module)
            {
                width = _modulePixelWidth;
                height = _modulePixelHeight;
            }
            else
            {
                return false;
            }

            target = new byte[width * height * 18];

            int len = width * 18;
            int offset = 9;
            int offset1 = 0;
            for (int row = 0; row < height; row++)
            {
                Array.Copy(src, offset, target, offset1, len);
                if (row < height - 1)
                {
                    offset += len + 9 + 1;//9为前导数据，1为最后一位校验和
                }
                else
                {
                    //最后一行不需要再移动9字节
                    offset += 0;
                }
                offset1 += len;
            }

            return true;
        }

        private bool ConvertZDatToSDat(byte[] src, out byte[] target, EnumCALTarget style)
        {
            int width = 0;
            int height = 0;
            target = null;

            if (style == EnumCALTarget.Cabinet)
            {
                width = _cabinetWidth;
                height = _cabinetHeight;
            }
            else if (style == EnumCALTarget.Module)
            {
                width = _modulePixelWidth;
                height = _modulePixelHeight;
            }
            else
            {
                return false;
            }

            int nNewLen = width * height * 18;//sdat文件大小
            target = new byte[nNewLen];
            int points = width * height;//像素点数

            byte[] pt = new Byte[16];//zdat一个像素的数据
            ushort tmp = 0;

            int nLeftMove = 5;//左移的位数 2017-11-16
            nLeftMove = nLeftMove + 1;

            for (int i = 0; i < points; i++)
            {
                //获取一个像素的数据
                Array.Copy(src, i * 16, pt, 0, 16);

                target[i * 18] = pt[0];
                target[i * 18 + 1] = pt[1];//R1 主色

                tmp = (ushort)(pt[2] << nLeftMove);
                target[i * 18 + 2] = tmp.HByte();
                target[i * 18 + 3] = tmp.LByte();//R2

                tmp = (ushort)(pt[3] << nLeftMove);
                target[i * 18 + 4] = tmp.HByte();
                target[i * 18 + 5] = tmp.LByte();//R3

                tmp = (ushort)(pt[4] << nLeftMove);
                target[i * 18 + 6] = tmp.HByte();
                target[i * 18 + 7] = tmp.LByte();//G1

                target[i * 18 + 8] = pt[5];
                target[i * 18 + 9] = pt[6];//G2 主色

                tmp = (ushort)(pt[7] << nLeftMove);
                target[i * 18 + 10] = tmp.HByte();
                target[i * 18 + 11] = tmp.LByte();//G3

                tmp = (ushort)(pt[8] << nLeftMove);
                target[i * 18 + 12] = tmp.HByte();
                target[i * 18 + 13] = tmp.LByte();//B1

                tmp = (ushort)(pt[9] << nLeftMove);
                target[i * 18 + 14] = tmp.HByte();
                target[i * 18 + 15] = tmp.LByte();//B2

                target[i * 18 + 16] = pt[10];
                target[i * 18 + 17] = pt[11];//B3 主色                
            }
            return true;
        }

        private bool ConvertDatToZDat(byte[] src, out byte[] target, EnumCALTarget style)
        {
            int width = 0;
            int height = 0;
            target = null;

            if (style == EnumCALTarget.Cabinet)
            {
                width = _cabinetWidth;
                height = _cabinetHeight;
            }
            else if (style == EnumCALTarget.Module)
            {
                width = _modulePixelWidth;
                height = _modulePixelHeight;
            }
            else
            {
                return false;
            }

            if (ConvertDatToSDat(src, out byte[] sDat, style) == false)
            {
                return false;
            }

            if (ConvertSDatToZDat(sDat, out target, style) == false)
            {
                return false;
            }
            return true;
        }

        private bool ConvertSDatToZDat(byte[] src, out byte[] target, EnumCALTarget style)
        {
            int width = 0;
            int height = 0;
            target = null;

            if (style == EnumCALTarget.Cabinet)
            {
                width = _cabinetWidth;
                height = _cabinetHeight;
            }
            else if (style == EnumCALTarget.Module)
            {
                width = _modulePixelWidth;
                height = _modulePixelHeight;
            }
            else
            {
                return false;
            }


            target = new byte[width * height * 16];
            int pos = 0;
            byte[] oldPixelData = new byte[18];
            byte[] newPixelData = new byte[16];

            int nLeftMove = 5;//2017-11-16
            nLeftMove = nLeftMove + 1;

            ushort uMask = (ushort)(0xFF << nLeftMove);//构造掩码

            for (int pt = 0; pt < width * height; pt++)
            {
                pos = 0;

                //获取一个像素的数据
                Array.Copy(src, pt * 18, oldPixelData, 0, 18);

                //清空一个像素的新数据
                for (int k = 0; k < 16; k++)
                    newPixelData[k] = 0;

                //进行转换
                for (int i = 0; i < 9; i++)
                {
                    ushort old = (ushort)((oldPixelData[2 * i] << 8) | oldPixelData[2 * i + 1]);

                    //2017-11-16 modify
                    //byte newVal = (byte)((old & 0x1FE0) >> 5);//16->8 bit  
                    byte newVal = (byte)((old & uMask) >> nLeftMove);//16->8 bit

                    if (i == 0)
                    {
                        //红色主色
                        newPixelData[pos] = oldPixelData[2 * i];
                        newPixelData[pos + 1] = oldPixelData[2 * i + 1];
                        pos += 2;
                    }
                    else if (i == 4)
                    {
                        //绿色主色
                        newPixelData[pos] = oldPixelData[2 * i];
                        newPixelData[pos + 1] = oldPixelData[2 * i + 1];
                        pos += 2;
                    }
                    else if (i == 8)
                    {
                        //蓝色主色
                        newPixelData[pos] = oldPixelData[2 * i];
                        newPixelData[pos + 1] = oldPixelData[2 * i + 1];
                        pos += 2;
                    }
                    else
                    {
                        //普通点
                        newPixelData[pos] = newVal;
                        pos++;
                    }
                }
                Array.Copy(newPixelData, 0, target, pt * 16, 16);
            }
            return true;
        }

        private bool ConvertSDatToDat(byte[] src, out byte[] target, EnumCALTarget style)
        {
            int width = 0;
            int height = 0;
            target = null;

            if (style == EnumCALTarget.Cabinet)
            {
                width = _cabinetWidth;
                height = _cabinetHeight;
            }
            else if (style == EnumCALTarget.Module)
            {
                width = _modulePixelWidth;
                height = _modulePixelHeight;
            }
            else
            {
                return false;
            }

            int nOriginLen = width * 18;//一行纯校正数据长度
            int nLen = nOriginLen + 10;//一行校正数据长度

            int nTotal = nLen * height;
            target = new byte[nTotal];

            for (int i = 0; i < height; i++)
            {
                target[i * nLen] = 0x04;
                target[i * nLen + 1] = (byte)((nLen >> 8) & 0xFF);
                target[i * nLen + 2] = (byte)(nLen & 0xFF);
                target[i * nLen + 3] = (byte)width;//箱体像素宽
                target[i * nLen + 4] = (byte)height;//箱体像素高
                target[i * nLen + 5] = target[i * nLen + 3];//箱体像素宽
                target[i * nLen + 6] = (byte)i;//当前行编号
                target[i * nLen + 7] = target[i * nLen + 3];//箱体像素宽
                target[i * nLen + 8] = 1;//默认值
                Array.Copy(src, i * nOriginLen, target, i * nLen + 9, nOriginLen);//复制纯校正数据部分

                target[i * nLen + nLen - 1] = target.CheckSumForByte(i * nLen, nLen - 1);
            }
            return true;
        }

        private bool ConvertZDatToDat(byte[] src, out byte[] target, EnumCALTarget style)
        {
            int width = 0;
            int height = 0;
            target = null;

            if (style == EnumCALTarget.Cabinet)
            {
                width = _cabinetWidth;
                height = _cabinetHeight;
            }
            else if (style == EnumCALTarget.Module)
            {
                width = _modulePixelWidth;
                height = _modulePixelHeight;
            }
            else
            {
                return false;
            }

            if (ConvertZDatToSDat(src, out byte[] sdat, style) == false)
            {
                return false;
            }

            if (ConvertSDatToDat(sdat, out target, style) == false)
            {
                return false;
            }
            return true;
        }

        public bool ConvertToUshort(byte[] src, out ushort[] target, EnumCALTarget style)
        {
            int width = 0;
            int height = 0;
            target = null;

            if (style == EnumCALTarget.Cabinet)
            {
                width = _cabinetWidth;
                height = _cabinetHeight;
            }
            else if (style == EnumCALTarget.Module)
            {
                width = _modulePixelWidth;
                height = _modulePixelHeight;
            }
            else
            {
                return false;
            }

            //转换为ushort数组(每个像素9个数）
            int ptNum = width * height;//像素总数
            ushort[] uValue = new ushort[ptNum * 9];//每个像素的9个数值
            byte[] ptBytes = new byte[18];//每个像素的18字节数据

            int pos = 0;
            ushort val = 0;
            for (int i = 0; i < ptNum; i++)
            {
                for (int j = 0; j < 18; j++)
                {
                    pos = i * 18 + j;
                    ptBytes[j] = src[pos];
                }
                for (int k = 0; k < 9; k++)
                {
                    val = (ushort)((ptBytes[2 * k] << 8) | ptBytes[2 * k + 1]);
                    uValue[i * 9 + k] = val;
                }
            }
            target = uValue;
            return true;
        }

        public bool ConvertToByte(ushort[] src, out byte[] target, EnumCALTarget style)
        {
            int width = 0;
            int height = 0;
            target = null;

            if (style == EnumCALTarget.Cabinet)
            {
                width = _cabinetWidth;
                height = _cabinetHeight;
            }
            else if (style == EnumCALTarget.Module)
            {
                width = _modulePixelWidth;
                height = _modulePixelHeight;
            }
            else
            {
                return false;
            }

            byte[] lineData = new Byte[width * 18];//箱体一行的缓存
            byte[] pixelData = new Byte[18];//某个像素的数据
            int pos = 0;
            List<byte> data = new List<byte>();
            for (int row = 0; row < height; row++)
            {
                //逐行写入文件
                for (int col = 0; col < width; col++)
                {
                    //逐列转换数据
                    for (int i = 0; i < 9; i++)
                    {
                        pos = 9 * (row * width + col) + i;
                        pixelData[2 * i] = (byte)((src[pos] >> 8) & 0xFF);
                        pixelData[2 * i + 1] = (byte)(src[pos] & 0xFF);
                    }
                    //复制一个像素数据到行缓存中
                    for (int j = 0; j < 18; j++)
                    {
                        lineData[col * 18 + j] = pixelData[j];
                    }
                }
                //写入一行数据
                data.AddRange(lineData);
            }
            target = data.ToArray();
            return true;
        }

        private void MultiplayCoeff(ref byte[] dat, int offset, float val)
        {
            ushort a = (ushort)((dat[offset] << 8) | dat[offset + 1]);//获取数值
            float b = (float)a * val;
            if (b > 65535)
            {
                b = 65535;
            }
            else if (b < 0)
            {
                b = 0;
            }
            ushort d = (ushort)Math.Round(b);//四舍五入后再强制转换
            dat[offset] = (byte)(d >> 8);
            dat[offset + 1] = (byte)(d & 0xFF);
        }

        /// <summary>
        /// 获取模组文件内容类型
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public EnumCALType GetType(string file, EnumCALTarget style)
        {
            int width = 0;
            int height = 0;
            if (style == EnumCALTarget.Cabinet)
            {
                width = _cabinetWidth;
                height = _cabinetHeight;
            }
            else if (style == EnumCALTarget.Module)
            {
                width = _modulePixelWidth;
                height = _modulePixelHeight;
            }
            else
            {
                return EnumCALType.Unkown;
            }
            FileInfo fileInfo = new FileInfo(file);
            try
            {
                EnumCALType dtype = EnumCALType.Unkown;
                int dlen = (width * 18 + 10) * height;
                int zlen = width * height * 16;
                int slen = width * height * 18;
                if (fileInfo.Length == dlen) return EnumCALType.Dat;
                if (fileInfo.Length == zlen) return EnumCALType.Zdat;
                if (fileInfo.Length == slen) return EnumCALType.Sdat;
                return dtype;
            }
            finally
            {
                fileInfo = null;
            }
        }

        public EnumCALType GetType(byte[] data, EnumCALTarget style)
        {
            int width = 0;
            int height = 0;
            if (style == EnumCALTarget.Cabinet)
            {
                width = _cabinetWidth;
                height = _cabinetHeight;
            }
            else if (style == EnumCALTarget.Module)
            {
                width = _modulePixelWidth;
                height = _modulePixelHeight;
            }
            else
            {
                return EnumCALType.Unkown;
            }
            try
            {
                EnumCALType dtype = EnumCALType.Unkown;
                int dlen = (width * 18 + 10) * height;
                int zlen = width * height * 16;
                int slen = width * height * 18;
                if (data.Length == dlen) return EnumCALType.Dat;
                if (data.Length == zlen) return EnumCALType.Zdat;
                if (data.Length == slen) return EnumCALType.Sdat;
                return dtype;
            }
            finally
            {
            }
        }

        public EnumCALType GetType(ushort[] data, EnumCALTarget style)
        {
            int width = 0;
            int height = 0;
            if (style == EnumCALTarget.Cabinet)
            {
                width = _cabinetWidth;
                height = _cabinetHeight;
            }
            else if (style == EnumCALTarget.Module)
            {
                width = _modulePixelWidth;
                height = _modulePixelHeight;
            }
            else
            {
                return EnumCALType.Unkown;
            }
            try
            {
                EnumCALType dtype = EnumCALType.Unkown;
                int dlen = (width * 18 + 10) * height;
                int zlen = width * height * 16;
                int slen = width * height * 18;
                if (data.Length * 2 == dlen) return EnumCALType.Dat;
                if (data.Length * 2 == zlen) return EnumCALType.Zdat;
                if (data.Length * 2 == slen) return EnumCALType.Sdat;
                return dtype;
            }
            finally
            {
            }
        }

        /// <summary>
        /// 拆分校正数据(原数据类型SDat,目标数据类型Dat)
        /// </summary>
        /// <param name="szScr">整箱体数据(SDat)</param>
        /// <param name="szTargetFolder">拆分后数据存储位置(Dat格式)</param>
        /// <returns></returns>
        public bool Divide(string szScr, string szTargetFolder)
        {
            string[,] moduleNames = new string[_moduleHeight, _moduleWidth];
            for (int row = 0; row < _moduleHeight; row++)
            {
                for (int col = 0; col < _moduleWidth; col++)
                {
                    moduleNames[row, col] = $"{row}_{col}";
                }
            }
            return Divide(szScr, moduleNames, szTargetFolder);
        }

        /// <summary>
        /// 读取校正数据，支持Dat,SDat,ZDat数据格式.返回sdat数据格式
        /// </summary>
        /// <param name="szSrc"></param>
        /// <param name="sdat"></param>
        /// <returns></returns>
        public bool Read(string szSrc, out byte[] sdat, EnumCALTarget style)
        {
            EnumCALType enumCAL = GetType(szSrc, style);
            sdat = null;
            switch (enumCAL)
            {
                case EnumCALType.Unkown:
                    return false;
                case EnumCALType.Zdat:
                    if (ReadZDat(szSrc, out byte[] zdat, style) == false) return false;
                    return ConvertZDatToSDat(zdat, out sdat, style);
                case EnumCALType.Dat:
                    if (ReadDat(szSrc, out byte[] dat, style) == false) return false;
                    return ConvertDatToSDat(dat, out sdat, style);
                case EnumCALType.Sdat:
                    return ReadSDat(szSrc, out sdat, style);
            }
            return true;
        }

        /// <summary>
        /// 读取校正数据，支持Dat,SDat,ZDat数据格式.返回sdat数据格式
        /// </summary>
        /// <param name="szSrc"></param>
        /// <param name="sdat"></param>
        /// <returns></returns>
        public bool Read(string szSrc, out ushort[] sdat, EnumCALTarget style)
        {
            EnumCALType enumCAL = GetType(szSrc, style);
            sdat = null;
            byte[] data = null;
            switch (enumCAL)
            {
                case EnumCALType.Unkown:
                    return false;
                case EnumCALType.Zdat:
                    if (ReadZDat(szSrc, out byte[] zdat, style) == false) return false;
                    if (ConvertZDatToSDat(zdat, out data, style) == false) return false;
                    break;
                case EnumCALType.Dat:
                    if (ReadDat(szSrc, out byte[] dat, style) == false) return false;
                    if (ConvertDatToSDat(dat, out data, style) == false) return false;
                    break;
                case EnumCALType.Sdat:
                    if (ReadSDat(szSrc, out data, style) == false) return false;
                    break;
            }
            if (ConvertToUshort(data, out sdat, style) == false) return false;
            return true;
        }

        public bool ToSDat(byte[] src, string szTarget, EnumCALTarget style)
        {
            EnumCALType enumCAL = GetType(src, style);
            byte[] sdat = null;
            switch (enumCAL)
            {
                case EnumCALType.Unkown:
                    return false;
                case EnumCALType.Zdat:
                    if (ConvertZDatToSDat(src, out sdat, style) == false)
                    {
                        return false;
                    }
                    SaveToFile(szTarget, sdat);
                    break;
                case EnumCALType.Dat:
                    if (ConvertDatToSDat(src, out sdat, style) == false)
                    {
                        return false;
                    }
                    SaveToFile(szTarget, sdat);
                    break;
                case EnumCALType.Sdat:
                    SaveToFile(szTarget, src);
                    break;
            }
            return true;
        }

        public bool ToSDat(ushort[] src, string szTarget, EnumCALTarget style)
        {
            EnumCALType enumCAL = GetType(src, style);
            if (ConvertToByte(src, out byte[] bData, style) == false) return false;
            byte[] sdat = null;
            switch (enumCAL)
            {
                case EnumCALType.Unkown:
                    return false;
                case EnumCALType.Zdat:
                    if (ConvertZDatToSDat(bData, out sdat, style) == false)
                    {
                        return false;
                    }
                    SaveToFile(szTarget, sdat);
                    break;
                case EnumCALType.Dat:
                    if (ConvertDatToSDat(bData, out sdat, style) == false)
                    {
                        return false;
                    }
                    SaveToFile(szTarget, sdat);
                    break;
                case EnumCALType.Sdat:
                    SaveToFile(szTarget, bData);
                    break;
            }
            return true;
        }

        public bool ToSDat(string szSrc, string szTarget, EnumCALTarget style)
        {
            EnumCALType enumCAL = GetType(szSrc, style);
            byte[] sdat = null;
            byte[] dat = null;
            switch (enumCAL)
            {
                case EnumCALType.Unkown:
                    return false;
                case EnumCALType.Zdat:
                    if (ReadZDat(szSrc, out dat, style) == false)
                    {
                        return false;
                    }
                    if (ConvertZDatToSDat(dat, out sdat, style) == false)
                    {
                        return false;
                    }
                    SaveToFile(szTarget, sdat);
                    break;
                case EnumCALType.Dat:
                    if (ReadDat(szSrc, out dat, style) == false)
                    {
                        return false;
                    }
                    if (ConvertDatToSDat(dat, out sdat, style) == false)
                    {
                        return false;
                    }
                    SaveToFile(szTarget, sdat);
                    break;
                case EnumCALType.Sdat:
                    if (szSrc == szTarget) return true;
                    System.IO.File.Copy(szSrc, szTarget, true);
                    return true;
                    break;
            }
            return true;
        }

        public bool ToZDat(string szSrc, string szTarget, EnumCALTarget style)
        {
            EnumCALType enumCAL = GetType(szSrc, style);
            byte[] zdat = null;
            byte[] dat = null;
            switch (enumCAL)
            {
                case EnumCALType.Unkown:
                    return false;
                case EnumCALType.Zdat:
                    if (szSrc == szTarget) return true;
                    System.IO.File.Copy(szSrc, szTarget, true);
                    return true;
                    break;
                case EnumCALType.Dat:
                    if (ReadDat(szSrc, out dat, style) == false)
                    {
                        return false;
                    }
                    if (ConvertDatToZDat(dat, out zdat, style) == false)
                    {
                        return false;
                    }
                    SaveToFile(szTarget, zdat);
                    break;
                case EnumCALType.Sdat:
                    if (ReadSDat(szSrc, out dat, style) == false)
                    {
                        return false;
                    }
                    if (ConvertSDatToZDat(dat, out zdat, style) == false)
                    {
                        return false;
                    }
                    SaveToFile(szTarget, zdat);
                    break;
            }
            return true;
        }

        public bool ToZDat(byte[] szSrc, string szTarget, EnumCALTarget style)
        {
            EnumCALType enumCAL = GetType(szSrc, style);
            byte[] zdat = null;
            switch (enumCAL)
            {
                case EnumCALType.Unkown:
                    return false;
                case EnumCALType.Zdat:
                    SaveToFile(szTarget, szSrc);
                    break;
                case EnumCALType.Dat:
                    if (ConvertDatToZDat(szSrc, out zdat, style) == false)
                    {
                        return false;
                    }
                    SaveToFile(szTarget, zdat);
                    break;
                case EnumCALType.Sdat:
                    if (ConvertSDatToZDat(szSrc, out zdat, style) == false)
                    {
                        return false;
                    }
                    SaveToFile(szTarget, zdat);
                    break;
            }
            return true;
        }

        public bool ToZDat(ushort[] szSrc, string szTarget, EnumCALTarget style)
        {
            EnumCALType enumCAL = GetType(szSrc, style);
            byte[] zdat = null;
            if (ConvertToByte(szSrc, out byte[] bData, style) == false) return false;
            switch (enumCAL)
            {
                case EnumCALType.Unkown:
                    return false;
                case EnumCALType.Zdat:
                    SaveToFile(szTarget, bData);
                    break;
                case EnumCALType.Dat:
                    if (ConvertDatToZDat(bData, out zdat, style) == false)
                    {
                        return false;
                    }
                    SaveToFile(szTarget, zdat);
                    break;
                case EnumCALType.Sdat:
                    if (ConvertSDatToZDat(bData, out zdat, style) == false)
                    {
                        return false;
                    }
                    SaveToFile(szTarget, zdat);
                    break;
            }
            return true;
        }

        public bool ToDat(string szSrc, string szTarget, EnumCALTarget style)
        {
            EnumCALType enumCAL = GetType(szSrc, style);
            byte[] sdat = null;
            byte[] dat = null;
            switch (enumCAL)
            {
                case EnumCALType.Unkown:
                    return false;
                case EnumCALType.Zdat:
                    if (ReadZDat(szSrc, out byte[] zdat, style) == false)
                    {
                        return false;
                    }
                    if (ConvertZDatToDat(zdat, out dat, style) == false)
                    {
                        return false;
                    }
                    SaveToFile(szTarget, dat);
                    break;
                case EnumCALType.Dat:
                    if (szSrc == szTarget) return true;
                    System.IO.File.Copy(szSrc, szTarget, true);
                    return true;
                    break;
                case EnumCALType.Sdat:
                    if (ReadSDat(szSrc, out dat, style) == false)
                    {
                        return false;
                    }
                    if (ConvertSDatToDat(dat, out sdat, style) == false)
                    {
                        return false;
                    }
                    SaveToFile(szTarget, sdat);
                    break;
            }
            return true;
        }

        public bool ToDat(byte[] szSrc, string szTarget, EnumCALTarget style)
        {
            EnumCALType enumCAL = GetType(szSrc, style);
            byte[] dat = null;
            switch (enumCAL)
            {
                case EnumCALType.Unkown:
                    return false;
                case EnumCALType.Zdat:
                    if (ConvertZDatToDat(szSrc, out dat, style) == false)
                    {
                        return false;
                    }
                    SaveToFile(szTarget, dat);
                    break;
                case EnumCALType.Dat:
                    SaveToFile(szTarget, szSrc);
                    break;
                case EnumCALType.Sdat:
                    if (ConvertSDatToDat(szSrc, out dat, style) == false)
                    {
                        return false;
                    }
                    SaveToFile(szTarget, dat);
                    break;
            }
            return true;
        }

        public bool ToDat(ushort[] szSrc, string szTarget, EnumCALTarget style)
        {
            EnumCALType enumCAL = GetType(szSrc, style);
            byte[] dat = null;
            if (ConvertToByte(szSrc, out byte[] bData, style) == false) return false;
            switch (enumCAL)
            {
                case EnumCALType.Unkown:
                    return false;
                case EnumCALType.Zdat:
                    if (ConvertZDatToDat(bData, out dat, style) == false)
                    {
                        return false;
                    }
                    SaveToFile(szTarget, dat);
                    break;
                case EnumCALType.Dat:
                    SaveToFile(szTarget, bData);
                    break;
                case EnumCALType.Sdat:
                    if (ConvertSDatToDat(bData, out dat, style) == false)
                    {
                        return false;
                    }
                    SaveToFile(szTarget, dat);
                    break;
            }
            return true;
        }

        /// <summary>
        /// 合并校正为整箱体数据,输出SDat格式
        /// </summary>
        /// <param name="files">模组数据数组(同时支持dat,sdat,zdat数据格式),第一维为行，第二维为列</param>
        /// <param name="target">SDat</param>
        /// <returns></returns>
        public bool Merge(string[,] files, string target)
        {
            if (files.GetLength(0) != _moduleHeight || files.GetLength(1) != _moduleWidth)
            {
                return false;
            }
            byte[,] cabinetData = new byte[_cabinetHeight, _cabinetWidth * 18];
            for (int row = 0; row < files.GetLength(0); row++)
            {
                int rowPos = row * _modulePixelHeight;
                for (int col = 0; col < files.GetLength(1); col++)
                {
                    string file = files[row, col];
                    EnumCALType enumCAL = GetType(file, EnumCALTarget.Module);
                    byte[] sdat = null;
                    switch (enumCAL)
                    {
                        case EnumCALType.Unkown:
                            cabinetData = null;
                            return false;
                        case EnumCALType.Dat:
                            if (ReadDat(file, out byte[] dat, EnumCALTarget.Module) == false)
                            {
                                cabinetData = null;
                                return false;
                            }
                            if (ConvertDatToSDat(dat, out sdat, EnumCALTarget.Module) == false)
                            {
                                cabinetData = null;
                                return false;
                            }
                            break;
                        case EnumCALType.Sdat:
                            if (ReadSDat(file, out sdat, EnumCALTarget.Module) == false)
                            {
                                cabinetData = null;
                                return false;
                            }
                            break;
                        case EnumCALType.Zdat:
                            if (ReadZDat(file, out byte[] zdat, EnumCALTarget.Module) == false)
                            {
                                cabinetData = null;
                                return false;
                            }
                            if (ConvertZDatToSDat(zdat, out sdat, EnumCALTarget.Module) == false)
                            {
                                cabinetData = null;
                                return false;
                            }
                            break;
                    }

                    for (int i = 0; i < _modulePixelHeight; i++)
                    {
                        byte[] lineDate = new byte[_modulePixelWidth * 18];
                        Array.Copy(sdat, i * _modulePixelWidth * 18, lineDate, 0, lineDate.Length);
                        int tmpRowPos = rowPos + i;
                        int colPos = col * _modulePixelWidth * 18;
                        for (int j = 0; j < lineDate.Length; j++)
                        {
                            cabinetData[tmpRowPos, colPos] = lineDate[j];
                            colPos++;
                        }
                    }
                }
            }
            int offset = 0;
            byte[] newDate = new byte[_cabinetWidth * _cabinetHeight * 18];
            for (int i = 0; i < cabinetData.GetLength(0); i++)
            {
                for (int j = 0; j < cabinetData.GetLength(1); j++)
                {
                    newDate[offset++] = cabinetData[i, j];
                }
            }
            SaveToFile(target, newDate);
            return true;
        }

        /// <summary>
        /// 拆分校正数据，原文见必须是SDat格式
        /// </summary>
        /// <param name="szScr"></param>
        /// <param name="modulesNames"></param>
        /// <param name="szTargetFolder"></param>
        /// <returns></returns>
        public bool Divide(string szScr, string[,] modulesNames, string szTargetFolder)
        {
            if (File.Exists(szScr) == false)
            {
                return false;
            }
            if (Directory.Exists(szTargetFolder) == false)
            {
                return false;
            }
            if (ReadSDat(szScr, out byte[] cabinetData, EnumCALTarget.Cabinet) == false)
            {
                return false;
            }

            Dictionary<string, List<byte>> moduleData = new Dictionary<string, List<byte>>();
            for (int row = 0; row < _moduleHeight; row++)
            {
                for (int col = 0; col < _moduleWidth; col++)
                {
                    string key = $"{row}_{col}";
                    moduleData.Add(key, new List<byte>());
                }
            }

            int offset = 0;
            for (int i = 0; i < _cabinetHeight; i++)
            {
                int lineLen = _modulePixelWidth * _moduleWidth * 18;
                byte[] lineData = new byte[lineLen];
                Array.Copy(cabinetData, offset, lineData, 0, lineLen);
                offset += lineLen;

                int row = i / _modulePixelHeight;
                int mLineLen = _modulePixelWidth * 18;
                int mOffset = 0;
                for (int j = 0; j < _moduleWidth; j++)
                {
                    int col = j;
                    string key = $"{row}_{col}";
                    byte[] mLineData = new byte[mLineLen];
                    Array.Copy(lineData, mOffset, mLineData, 0, mLineLen);
                    mOffset += mLineLen;

                    moduleData[key].AddRange(mLineData);
                }
            }

            for (int row = 0; row < _moduleHeight; row++)
            {
                for (int col = 0; col < _moduleWidth; col++)
                {
                    string key = $"{row}_{col}";
                    string file = Path.Combine(szTargetFolder, $"{modulesNames[row, col]}.dat");
                    if (ConvertSDatToDat(moduleData[key].ToArray(), out byte[] dat, EnumCALTarget.Module) == false)
                    {
                        return false;
                    }
                    SaveToFile(file, dat);
                }
            }

            return true;
        }

        /// <summary>
        /// 校正数据进行系数运算
        /// </summary>
        /// <param name="src">校正数据</param>
        /// <param name="offset">偏移量</param>
        /// <param name="width">像素宽</param>
        /// <param name="height">像素高</param>
        /// <param name="coeff">9个系数值</param>
        public bool TakeCoeff(byte[] src, int offset, int width, int height, float[] coeff)
        {   //src表示某个矩形区域的校正数据（区域可以是模块，也可以是箱体，也可以是某一行)
            //如果width=height=1的话表示对某个像素进行系数修改

            if (src == null) return false;
            if ((width < 1) || (height < 1)) return false;
            if (coeff.Length != 9) return false;

            byte[] pixelData = new byte[18];
            int pos = 0;
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    //pos = (row * height + col) * 18;
                    pos = (row * width + col) * 18;//2016-1-11修改

                    Array.Copy(src, offset + pos, pixelData, 0, 18);//取出一个像素的数据

                    //逐个像素乘以系数
                    for (int i = 0; i < 9; i++)
                    {
                        //9个数逐个处理
                        MultiplayCoeff(ref pixelData, 2 * i, coeff[i]);
                    }

                    Array.Copy(pixelData, 0, src, offset + pos, 18);//写回一个像素的数据

                }
            }
            return true;
        }

        public bool GetExtName(string szSrc, out string ext, EnumCALTarget style)
        {
            ext = string.Empty;
            EnumCALType tp = GetType(szSrc, style);
            if (tp == EnumCALType.Unkown)
            {
                return false;
            }
            ext = tp.ToString();
            return true;
        }
    }
}
