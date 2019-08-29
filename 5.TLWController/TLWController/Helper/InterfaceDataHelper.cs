#region << 注释 >>
/************************************************************************
*文件名： InterfaceDataHelper
*创建人： JIN
*创建时间：2019/6/4 15:11:18
*描述：
*=======================================================================
*修改时间：2019/6/4 15:11:18
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLWController.Helper
{
    [Serializable]
    public class InterfaceData
    {
        /// <summary>
        /// 亮度颜色
        /// </summary>
        public int BrightnessColor { get; set; }

        /// <summary>
        /// 亮度值
        /// </summary>
        public int BrightnessValue { get; set; }

        /// <summary>
        /// 芯片位置
        /// </summary>
        public int ChipPosition { get; set; }

        /// <summary>
        /// FLASH地址
        /// </summary>
        public int FLASHAddress { get; set; }

        /// <summary>
        /// FLASH数据长度
        /// </summary>
        public int FLASHDataLength { get; set; }

        /// <summary>
        /// SDRAM地址
        /// </summary>
        public int SDRAMAddress { get; set; }

        /// <summary>
        /// SDRAM数据长度
        /// </summary>
        public int SDRAMDataLength { get; set; }

        /// <summary>
        /// 视频卡加载
        /// </summary>
        public int VideocardLoadParam { get; set; }

        /// <summary>
        /// GAMMA bit
        /// </summary>
        public int GammaBit { get; set; }

        /// <summary>
        /// Gamma颜色
        /// </summary>
        public int GammaColor { get; set; }

        /// <summary>
        /// Gamma值
        /// </summary>
        public double GammaValue { get; set; }

        /// <summary>
        /// GAMMA文件颜色
        /// </summary>
        public int GammaFileColor { get; set; }

        /// <summary>
        /// Gamma文件
        /// </summary>
        public string GammaFile { get; set; }

        /// <summary>
        /// 工装
        /// </summary>
        public int WorkMode { get; set; }

        /// <summary>
        /// 校正开关
        /// </summary>
        public int CalibrationOnOff { get; set; }

        /// <summary>
        /// IP
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Mask
        /// </summary>
        public string Mask { get; set; }

        /// <summary>
        /// Gateway
        /// </summary>
        public string Gateway { get; set; }

        /// <summary>
        /// 写入时间码位置
        /// </summary>
        public int SNPosition { get; set; }

        /// <summary>
        /// 时间码生成方式
        /// </summary>
        public int SNCreateWay { get; set; }

        /// <summary>
        /// MCU文件
        /// </summary>
        public string MCUFile { get; set; }

        /// <summary>
        /// 主板FPGA文件
        /// </summary>
        public string MBFPGAFile { get; set; }

        /// <summary>
        /// 灯板FPGA文件
        /// </summary>
        public string ModuleFPGAFile { get; set; }

        /// <summary>
        /// 分配板FPGA
        /// </summary>
        public string DistributeBoardFPGAFile { get; set; }

        /// <summary>
        /// MAP文件
        /// </summary>
        public string MapFile { get; set; }

        /// <summary>
        /// 校正数据文件
        /// </summary>
        public string CalibrationFile { get; set; }

        /// <summary>
        /// 校正数据写入灯板位置
        /// </summary>
        public int CalibrationFilePosition { get; set; }

        /// <summary>
        /// 批量校正数据文件
        /// </summary>
        public string BatchCalibrationFile { get; set; }

        /// <summary>
        /// 寄存器地址
        /// </summary>
        public int RegisterAddr { get; set; }

        /// <summary>
        /// 寄存器值
        /// </summary>
        public int RegisterValue { get; set; }

        /// <summary>
        /// 色温2055还是2072
        /// </summary>
        public int ColorTempChip { get; set; }

        /// <summary>
        /// 色温50，60Hz，
        /// </summary>
        public int ColorTempHz { get; set; }

        /// <summary>
        /// 色温类别
        /// </summary>
        public int ColorTempType { get; set; }

        /// <summary>
        /// 电流增益类别
        /// </summary>
        public int GainChipType { get; set; }

        /// <summary>
        /// 红色电流增益
        /// </summary>
        public int GainRedColor { get; set; }

        /// <summary>
        /// 绿色电流增益
        /// </summary>
        public int GainGreenColor { get; set; }

        /// <summary>
        /// 绿色电流增益
        /// </summary>
        public int GainBlueColor { get; set; }
    }

}
