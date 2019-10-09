#region << 注释 >>
/************************************************************************
*文件名： ThreadParam
*创建人： JIN
*创建时间：2019/1/15 15:07:20
*描述：
*=======================================================================
*修改时间：2019/1/15 15:07:20
*修改人：
*描述：
************************************************************************/
#endregion

using PluginLib;
using SFTHelper.Structs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BatchSeamCalibration.Structs
{
    public class ThreadParam
    {
        //string threadIP = arg[1].ToString();//IP地址
        //SeamItemData[,] seamData = arg[2] as SeamItemData[,];//亮暗线数据
        //byte startGray = byte.Parse(arg[3].ToString());//起始灰度
        //UnitTypeV2 uType = (UnitTypeV2)arg[4];//箱体类型
        //string workPath = arg[5].ToString();//工作目录
        //string localDataPath = arg[6].ToString();//本地校正数据文件路径
        //int readFrom = (int)arg[7];//从哪里读取
        //int localFileType = (int)arg[8];//本地文件类型，模组文件 箱体文件

        //int width = uType.ModuleWidth * uType.ModulePixelWidth;
        //int height = uType.ModuleHeight * uType.ModulePixelHeight;
        //int modulePixelWidth = uType.ModulePixelWidth;
        //int modulePixelHeight = uType.ModulePixelHeight;
        //string fileRead = "";
        //string fileWrite = "";

        public string ControlName { get; set; }
        public string IP { get; set; }
        public StructSeamItem[,] SeamData { get; set; }
        public byte StartGray { get; set; }
        public UnitTypeV2 UnitType { get; set; }
        public string WorkPath { get; set; }
        public string LocalCalDataPath { get; set; }

        /// <summary>
        /// 0:模组，1箱体
        /// </summary>
        public int LocaCalFileType { get; set; }

        /// <summary>
        /// 0箱体，1：文件夹
        /// </summary>
        public int ReadCalFrom { get; set; }

        public bool ResetData { get; set; }
    }
}
