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
    }

}
