﻿#region << 注释 >>
/************************************************************************
*文件名： SeamCalibrationHelper
*创建人： JIN
*创建时间：2019/8/8 10:24:04
*描述：
*=======================================================================
*修改时间：2019/8/8 10:24:04
*修改人：
*描述：
************************************************************************/
#endregion

using SFTHelper.Enums;
using SFTHelper.Structs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SFTHelper.Helper
{
    public class SeamCalibrationHelper
    {
        private int _modulePixelWidth;//单个模块像素宽度
        private int _modulePixelHeight;//单个模块像素高度
        private int _moduleWidth;//模块列数
        private int _moduleHeight;//模块行数
        private int _startGray;//起始灰度

        public SeamCalibrationHelper(int startGray, int moduleWidth, int moduleHeight, int modulePixelWidth, int modulePixelHeight)
        {
            _startGray = startGray;
            _moduleWidth = moduleWidth;
            _moduleHeight = moduleHeight;
            _modulePixelWidth = modulePixelWidth;
            _modulePixelHeight = modulePixelHeight;
        }

        private int _cabinetWidth { get { return _modulePixelWidth * _moduleWidth; } }//箱体宽度

        private int _cabinetHeight { get { return _modulePixelHeight * _moduleHeight; } }//箱体高度

        /// <summary>
        /// 单个模块内某个区域乘以校正系数
        /// </summary>
        /// <param name="target"></param>
        /// <param name="posList"></param>
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

        /// <summary>
        /// 采用256分之一进行调节
        /// </summary>
        /// <param name="adjustRange">调整幅度</param>
        /// <param name="startGray"></param>
        /// <param name="seamItemData"></param>
        /// <param name="rowID"></param>
        /// <param name="colID"></param>
        /// <param name="moduleW"></param>
        /// <param name="moduleH"></param>
        /// <param name="NumW"></param>
        /// <param name="NumH"></param>
        /// <param name="data"></param>
        private static void ChangeModuleValue3(int adjustRange, byte startGray, StructSeamItem seamItemData, int rowID, int colID, int moduleW, int moduleH, int NumW, int NumH, ushort[] data)
        {
            //模块的9个位置的系数
            double[] arrFactor = { seamItemData.Top, seamItemData.Top, seamItemData.Top,
                                  seamItemData.Left,startGray/(255*1.0f)*adjustRange,seamItemData.Right,
                                  seamItemData.Bottom,seamItemData.Bottom,seamItemData.Bottom
                              };

            //系数处理(将 0.0到100.0转换到0.0到1.0)
            for (int f = 0; f < arrFactor.Length; f++)
            {
                if (f != 4)
                {
                    if (arrFactor[f] > 256)
                        arrFactor[f] *=1.01;
                    else if (arrFactor[f] < 256)
                        arrFactor[f] *= 0.99;
                }
                double val = arrFactor[f];

                arrFactor[f] = val / 256;

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

        private bool ChangCalibrationFile(int adjustrange, StructSeamItem[,] seamItemData, ushort[] dataIn, out ushort[] dataOut)
        {
            dataOut = null;
            if (seamItemData == null) return false;

            int width, height, moduleColCount, moduleRowCount;//箱体像素宽、高
            width = height = 0;

            width = _cabinetWidth;
            height = _cabinetHeight;
            moduleColCount = _moduleWidth;
            moduleRowCount = _moduleHeight;

            //--------处理数据-----------
            ushort[] uValue = dataIn.Clone() as ushort[];

            //每个模块都处理系数
            for (int row = 0; row < moduleRowCount; row++)
            {
                for (int col = 0; col < moduleColCount; col++)
                {
                    StructSeamItem itemData = seamItemData[row, col];
                    ChangeModuleValue3(adjustrange, (byte)_startGray, itemData, row, col, _modulePixelWidth, _modulePixelHeight, moduleColCount, moduleRowCount, uValue);
                }
            }
            dataOut = uValue.Clone() as ushort[];
            return true;
        }

        private bool ChangCalibrationFile(int adjustRange, StructSeamItem seamItemData, ushort[] dataIn, out ushort[] dataOut)
        {
            dataOut = null;

            int width, height, moduleColCount, moduleRowCount;//箱体像素宽、高
            width = height = 0;
            moduleColCount = moduleRowCount = 0;

            width = _modulePixelWidth;
            height = _modulePixelHeight;
            moduleColCount = 1;
            moduleRowCount = 1;
            //--------处理数据-----------
            ushort[] uValue = dataIn.Clone() as ushort[];

            //每个模块都处理系数
            StructSeamItem itemData = seamItemData;
            ChangeModuleValue3(adjustRange, (byte)_startGray, itemData, 0, 0, _modulePixelWidth, _modulePixelHeight, moduleColCount, moduleRowCount, uValue);

            dataOut = uValue.Clone() as ushort[];
            return true;
        }

        /// <summary>
        /// 修改整箱体校正数据边缘，输出SDat
        /// </summary>
        /// <param name="fileIn">要被修改的数据(支持SDat,Dat,ZDat)</param>
        /// <param name="fileOut">输出SDat</param>
        /// <param name="seamItemDatas"></param>
        /// <returns></returns>
        public bool Modify(string fileIn, string fileOut, int adjustRange, StructSeamItem[,] seamItemDatas)
        {
            CalibrationHelper calibrationHelper = new CalibrationHelper(_moduleWidth, _moduleHeight, _modulePixelWidth, _modulePixelHeight);

            byte[] data = null;
            int width = 0;
            int height = 0;

            width = _cabinetWidth;
            height = _cabinetHeight;

            bool isOK = calibrationHelper.Read(fileIn, out data, EnumCALTarget.Cabinet);//读取纯校正数据
            if (!isOK)
            {
                return false;
            }
            float[] coeff = new float[9];
            for (int i = 0; i < coeff.Length; i++)
            {
                coeff[i] = (float)(_startGray / (255 * 1.0f));
            }

            isOK = calibrationHelper.TakeCoeff(data, 0, width, height, coeff);//修改校正系数，整体调整幅度
            if (!isOK)
            {
                //整体调整校正数据系数失败
                return false;
            }

            if (calibrationHelper.ConvertToUshort(data, out ushort[] uDataIn, EnumCALTarget.Cabinet) == false) return false;
            ushort[] uDataOut = null;
            isOK = ChangCalibrationFile(adjustRange, seamItemDatas, uDataIn, out uDataOut);
            if (!isOK)
            {
                //修改校正数据失败
                return false;
            }
            if (calibrationHelper.ConvertToByte(uDataOut, out byte[] bDataOut, Enums.EnumCALTarget.Cabinet) == false) return false;
            if (calibrationHelper.ToSDat(bDataOut, fileOut, Enums.EnumCALTarget.Cabinet) == false) return false;
            return true;
        }

        /// <summary>
        /// 修改单个模组边缘，输出SDat
        /// </summary>
        /// <param name="fileIn">要被修改的数据(支持SDat,Dat,ZDat)</param>
        /// <param name="fileOut">输出SDat</param>
        /// <param name="seamItemDatas"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public bool Modify(string fileIn, string fileOut, int adjustRange, StructSeamItem seamItemData)
        {
            CalibrationHelper calibrationHelper = new CalibrationHelper(_moduleWidth, _moduleHeight, _modulePixelWidth, _modulePixelHeight);

            byte[] data = null;
            int width = 0;
            int height = 0;

            width = _modulePixelWidth;
            height = _modulePixelHeight;
            bool isOK = calibrationHelper.Read(fileIn, out data, EnumCALTarget.Module);//读取纯校正数据
            if (!isOK)
            {
                return false;
            }
            float[] coeff = new float[9];
            for (int i = 0; i < coeff.Length; i++)
            {
                coeff[i] = (float)(_startGray / (255 * 1.0f));
            }

            isOK = calibrationHelper.TakeCoeff(data, 0, width, height, coeff);//修改校正系数，整体调整幅度
            if (!isOK)
            {
                //整体调整校正数据系数失败
                return false;
            }

            if (calibrationHelper.ConvertToUshort(data, out ushort[] uDataIn, EnumCALTarget.Module) == false) return false;
            ushort[] uDataOut = null;

            isOK = ChangCalibrationFile(adjustRange, seamItemData, uDataIn, out uDataOut);

            if (!isOK)
            {
                //修改校正数据失败
                return false;
            }
            if (calibrationHelper.ConvertToByte(uDataOut, out byte[] bDataOut, EnumCALTarget.Module) == false) return false;
            if (calibrationHelper.ToSDat(bDataOut, fileOut, EnumCALTarget.Module) == false) return false;
            return true;
        }
    }
}
