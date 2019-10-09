#region << 注释 >>
/************************************************************************
*文件名： InterfaceData
*创建人： JIN
*创建时间：2018/12/19 13:25:59
*描述：
*=======================================================================
*修改时间：2018/12/19 13:25:59
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Drawing;

namespace BatchSeamCalibration
{
    [Serializable]
    public class InterfaceData
    {
        public int Background { get; set; }
        public int StarGray { get { return 255; } }
        public bool ShowBorder { get; set; }
        public bool ShowPercentValue { get; set; }
        public string CabinetSerial { get; set; }
        public string CabinetCategory { get; set; }
        public string CabinetType { get; set; }
        public int StartGray { get; set; }
        public bool LockViewForm { get; set; }
        public int DataLocation { get; set; }
        public int DataType { get; set; }
        public string LocalDataPath { get; set; }
        public Point ViewFormPosition { get; set; }
    }
}
