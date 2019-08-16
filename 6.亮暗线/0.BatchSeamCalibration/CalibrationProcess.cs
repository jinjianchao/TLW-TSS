#region << 注释 >>
/************************************************************************
*文件名： CalibrationProcess
*创建人： JIN
*创建时间：2018/12/21 13:18:55
*描述：
*=======================================================================
*修改时间：2018/12/21 13:18:55
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BatchSeamCalibration
{
    public enum EnumDataType
    {
        Unkown = 0,
        Dat = 1,
        Sdat = 2,
        Zdat = 3
    }

    public class CalibrationProcess
    {

        /// <summary>
        /// 模块内某个区域乘以校正系数
        /// </summary>
        /// <param name="target"></param>
        /// <param name="posList"></param>
        /// <param name="gamma">GAMMA对象</param>
        /// <param name="factor"></param>       
        private static void MultiPlayFactor2(ushort[] target, List<int> posList, double factor)
        {
            //原来算法                                                
            double val = 0;
            foreach (int pos in posList)
            {
                //每个像素9个ushort
                int offset = 9 * pos;
                for (int i = 0; i < 9; i++)
                {
                    val = target[offset + i] * factor;
                    target[offset + i] = (ushort)((val + 0.5) > 65535 ? 65535 : (val + 0.5));//四舍五入
                }
            }
        }

        private static void ChangeModuleValue2(byte startGray, StructSeamItem seamItemData, int rowID, int colID, int moduleW, int moduleH, int NumW, int NumH, ushort[] data)
        {
            //模块的9个位置的系数
            double[] arrFactor = { seamItemData.Top, seamItemData.Top, seamItemData.Top,
                                  seamItemData.Left,startGray/(255*1.0f)*100,seamItemData.Right,
                                  seamItemData.Bottom,seamItemData.Bottom,seamItemData.Bottom
                              };
            //系数处理(将 0.0到100.0转换到0.0到1.0)
            for (int f = 0; f < arrFactor.Length; f++)
            {
                double val = arrFactor[f];
                //if (val < 100) val -= 1.5;
                //if (val > 100) val += 2.6;
                arrFactor[f] = val / 100;
            }


            int pos = 0;//像素在箱体中的位置
            int linePt = moduleW * NumW;//一行的点数
            List<int>[] arrPt = new List<int>[9];
            for (int i = 0; i < 9; i++)
                arrPt[i] = new List<int>();


            //寻址9个区域的位置信息
            #region 新算法
            //采用扫描方式，并行的获取几个区域位置
            for (int row = 0; row < moduleH; row++)
            {
                pos = (rowID * moduleH + row) * linePt + colID * moduleW; //该行起始点位置  
                for (int col = 0; col < moduleW; col++)
                {
                    if (row == 0)
                    {
                        //扫描第一行
                        if (col == 0)
                        {
                            arrPt[0].Add(pos);//LT
                        }
                        else if (col == moduleW - 1)
                        {
                            arrPt[2].Add(pos + col);//RT
                        }
                        else
                        {
                            arrPt[1].Add(pos + col);//TC
                        }
                    }
                    else if (row == moduleH - 1)
                    {   //扫描最后一行
                        if (col == 0)
                        {
                            arrPt[6].Add(pos);//BL
                        }
                        else if (col == moduleW - 1)
                        {
                            arrPt[8].Add(pos + col);//RL
                        }
                        else
                        {
                            arrPt[7].Add(pos + col);//BC
                        }

                    }
                    else
                    {
                        //扫描中间的这些行
                        if (col == 0)
                        {//第一个点
                            arrPt[3].Add(pos);//L
                        }
                        else if (col == moduleW - 1)
                        {//最后一个点
                            arrPt[5].Add(pos + col);//R
                        }
                        else
                        {//中间的点
                            arrPt[4].Add(pos + col);//C
                        }
                    }
                }
            }
            #endregion

            //原始数据乘以系数
            for (int i = 0; i < 9; i++)
                MultiPlayFactor2(data, arrPt[i], arrFactor[i]);


            for (int i = 0; i < 9; i++)
                arrPt[i].Clear();//释放数据

        }

        //输入文件sdat
        public static bool ChangCalibrationFile(int moduleW, int moduleH, int numW, int numH, byte startGray, SeamItemData[,] seamItemData, string fileIn, string fileOut)
        {
            if (seamItemData == null) return false;
            if (File.Exists(fileIn) == false) return false;
            if ((fileOut == null) || (fileOut == "")) return false;

            if ((moduleW <= 0) || (moduleH <= 0) || (numW <= 0) || (numH <= 0)) return false;


            int width, height;//箱体像素宽、高
            width = height = 0;

            width = moduleW * numW;
            height = moduleH * numH;

            //读取文件到内存
            FileStream fsIn = null;
            try
            {
                fsIn = new FileStream(fileIn, FileMode.Open, FileAccess.Read);
            }
            catch
            {
                return false;
            }
            int fileInLen = width * height * 18;//文件长度 sdat

            if (fsIn.Length != fileInLen)
            {
                fsIn.Close();
                return false;//长度有问题
            }

            //创建输出文件
            FileStream fsOut = null;
            try
            {
                fsOut = new FileStream(fileOut, FileMode.Create, FileAccess.Write);
            }
            catch
            {
                fsIn.Close();
                return false;
            }

            //--------处理数据-----------
            byte[] allData = new byte[fileInLen];//创建内存
            if (allData == null)
            {
                fsIn.Close();
                fsOut.Close();
                return false;
            }

            //读取整个文件
            if (fsIn.Read(allData, 0, fileInLen) != fileInLen)
            {
                fsIn.Close();
                fsOut.Close();
                File.Delete(fileOut);//删除输出文件
                return false;
            }
            fsIn.Close();//关闭文件

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
                    ptBytes[j] = allData[pos];
                }
                for (int k = 0; k < 9; k++)
                {
                    val = (ushort)((ptBytes[2 * k] << 8) | ptBytes[2 * k + 1]);
                    uValue[i * 9 + k] = val;
                }

            }

            //每个模块都处理系数
            for (int row = 0; row < numH; row++)
            {
                for (int col = 0; col < numW; col++)
                {
                    SeamItemData itemData = seamItemData[row, col];
                    if (itemData == null)
                    {
                        fsOut.Close();
                        File.Delete(fileOut);
                        return false;
                    }
                    ChangeModuleValue2(startGray, itemData, row, col, moduleW, moduleH, numW, numH, uValue);
                }
            }


            //------------输出文件----------
            byte[] lineData = new Byte[width * 18];//箱体一行的缓存
            byte[] pixelData = new Byte[18];//某个像素的数据
            pos = 0;
            for (int row = 0; row < height; row++)
            {
                //逐行写入文件
                for (int col = 0; col < width; col++)
                {
                    //逐列转换数据
                    for (int i = 0; i < 9; i++)
                    {
                        pos = 9 * (row * width + col) + i;
                        pixelData[2 * i] = (byte)((uValue[pos] >> 8) & 0xFF);
                        pixelData[2 * i + 1] = (byte)(uValue[pos] & 0xFF);
                    }
                    //复制一个像素数据到行缓存中
                    for (int j = 0; j < 18; j++)
                    {
                        lineData[col * 18 + j] = pixelData[j];
                    }
                }
                //写入一行数据
                fsOut.Write(lineData, 0, lineData.Length);
            }
            fsOut.Flush();//缓冲区也要完全写入文件
            fsOut.Close();//关闭文件

            return true;
        }

        public EnumDataType GetDataType(int width, int height, string file)
        {
            FileInfo fileInfo = new FileInfo(file);
            try
            {
                EnumDataType dtype = EnumDataType.Unkown;
                int dlen = (width * 18 + 10) * height;
                int zlen = width * height * 16;
                int slen = width * height * 18;
                if (fileInfo.Length == dlen) return EnumDataType.Dat;
                if (fileInfo.Length == zlen) return EnumDataType.Zdat;
                if (fileInfo.Length == slen) return EnumDataType.Sdat;
                return dtype;
            }
            finally
            {
                fileInfo = null;
            }
        }
    }
}
