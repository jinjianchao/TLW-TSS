using System;
using System.Collections.Generic;
using System.Text;

namespace PluginLib 
{
    public enum WinMsg
    {
        /// <summary>
        /// 下载校正数据
        /// </summary>
        WriteCorrectionData = 16385,
        /// <summary>
        /// 读取校正数据
        /// </summary>
        ReadCorrectionData = 16386,
        /// <summary>
        /// 下载FPGA
        /// </summary>
        FPGA = 16387,
        /// <summary>
        /// 下载Gamma
        /// </summary>
        WriteGamma = 16388,
        /// <summary>
        /// 写入GAMMA数据（为今后升级扩展）
        /// </summary>
        WriteGAMMAEx = 16389,
        /// <summary>
        /// 读取GAMMA数据
        /// </summary>
        ReadGamma = 16390,
        /// <summary>
        /// 写入MAP数据
        /// </summary>
        WriteMAP = 16391,
        /// <summary>
        /// 读取MAP数据
        /// </summary>
        ReadMAP = 16392,
        /// <summary>
        /// 写序列号到灯板
        /// </summary>
        WriteSerialNumber = 16393,
        /// <summary>
        /// 读取灯板序列号
        /// </summary>
        ReadSerialNumber = 16394,
        /// <summary>
        /// 设置FPGA缩放的尺寸及相关参数
        /// </summary>
        SetFPGAScaleValue = 16395,
        /// <summary>
        /// 设置整屏左上角起始点偏移
        /// </summary>
        SetLeftTop = 16396,
        /// <summary>
        /// 设置整屏右下角起始点偏移
        /// </summary>
        SetRightBottom = 16397,
        /// <summary>
        /// 设置缩放右下角显示坐标、发送给FPGA的缩放箱体尺寸、计算缩放地址的箱体尺寸命令
        /// </summary>
        SetRightBottomScale = 16398,
        /// <summary>
        /// FPGA下载测试
        /// </summary>
        FPGATest = 16399,
        /// <summary>
        /// FPGA回读测试
        /// </summary>
        FPGATestRead = 16400,
        /// <summary>
        /// 设置箱体尺寸、模块尺寸
        /// </summary>
        SetUnitSize = 16401,
        /// <summary>
        /// 亮度设置
        /// </summary>
        SetBrightness = 16402,
        /// <summary>
        /// 读取前端情景模式表数据
        /// </summary>
        ReadSceneTable = 16403,
        /// <summary>
        /// 格式化Flash
        /// </summary>
        FormatFLASH = 16404,
        /// <summary>
        ///  读取模块工作时间命令
        /// </summary>
        ReadTotalTime = 16405,
        /// <summary>
        /// 开启关闭工作计时功能
        /// </summary>
        SetTotalTimeEn = 16406,
        /// <summary>
        /// 调整多包发送时候的数据包之间延时
        /// </summary>
        PacketDelay = 16407,
        /// <summary>
        ///  终止正在执行的多包命令
        /// </summary>
        Stop = 16408,
        /// <summary>
        /// 读取TV当前的参数
        /// </summary>
        ReadParams = 16409,
        /// <summary>
        /// 写入TV出厂参数
        /// </summary>
        WriteFactoryParams = 16410,
        /// <summary>
        /// 恢复出厂设置
        /// </summary>
        FactoryReset = 16411,
        /// <summary>
        /// 切换FPGA区域
        /// </summary>
        SetFPGASection = 16412,
        /// <summary>
        /// 触发箱体读取灯板的校正数据
        /// </summary>
        SetReadFromBoard=16413,
        /// <summary>
        /// 触发箱体把校正数据写入灯板
        /// </summary>
        SetSavetoBoard=16414,
        /// <summary>
        /// 设置箱体的坐标
        /// </summary>
        SetPosition=16415,
        /// <summary>
        /// 设置显示屏当前的工作模式
        /// </summary>
        SetWorkMode=16416,
        /// <summary>
        /// 设置箱体电流√
        /// </summary>
        SetCurrent=16417,
        /// <summary>
        /// 调整多包发送时候的数据包之间延时(默认为300毫秒)
        /// </summary>
        Global_PacketDelay=16418,
        /// <summary>
        /// 发送数据包后等待时间
        /// </summary>
        Global_SendWait=16419,
        /// <summary>
        /// 设置某个箱体的亮度√
        /// </summary>
        SetUnitBrightness=16420,
        /// <summary>
        /// 设置箱体显示基色（校正箱体时用）
        /// </summary>
        SetUnitBaseColor=16421,
        /// <summary>
        /// 测试该位置是否存在箱体√
        /// </summary>
        SetUnitEcho=16422,
        /// <summary>
        /// 读取箱体的温度
        /// </summary>
        ReadTemperAndVersion=16423,
        /// <summary>
        /// 设置前端设备截取图像起始坐标
        /// </summary>
        SetOrigin=16424,
        /// <summary>
        /// 设置2D/3D切换及信号源选择命令
        /// </summary>
        Set2D3D=16425,
        /// <summary>
        /// 设置前端设备使能命令
        /// </summary>
        SetDeviceEnable=16426,
        /// <summary>
        /// 设置前端设备IP地址及子网掩码
        /// </summary>
        SetIP=16426,
        /// <summary>
        /// 设置前端设备MAC地址
        /// </summary>
        SetMACaddr=16427,
        /// <summary>
        /// 写入箱体FPGA数据
        /// </summary>
         WriteFPGA=16428,
        /// <summary>
        /// 写入前端情景模式表数据
        /// </summary>
        WriteSceneTable=16429,
        /// <summary>
        /// 一行一行的读取校正数据
        /// </summary>
        WriteRowData=16430,
        /// <summary>
        /// 从灯板中读取校正数据
        /// </summary>
        ReadBoard=16431,
         /// <summary>
        /// 写入MAP数据(升级用)
        /// </summary>
        WriteMAPEx = 16430,
        /// <summary>
        /// 单口全屏发送数据
        /// </summary>
        SetCorrectionDataAll=16431,
        /// <summary>
        /// 双口全屏发
        /// </summary>
        SetBothCorrectionDataAll=16432,
        /// <summary>
        /// 写入前端FPGA
        /// </summary>
        WriteFrontFPGA=16433,
        ///监视信息
        MonitorMsg=65535
    }
}
