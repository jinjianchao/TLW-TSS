#region << 注释 >>
/************************************************************************
*文件名： OperationResult
*创建人： JIN
*创建时间：2019/8/13 17:01:14
*描述：
*=======================================================================
*修改时间：2019/8/13 17:01:14
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchSeamCalibration.Structs
{
    public class OperationResult
    {
        //public OperationResult();

        public int DeviceNumber { get; set; }
        public bool Status { get; set; }
        public EnumResult Result { get; set; }
        public string Message { get; set; }
        public byte[] Data { get; set; }
        public string strData { get; set; }
    }

    public enum EnumResult
    {
        Success = 0,
        IOError = 1,
        ContentError = 2,
        DataLengthError = 3,
        FileNotFoundError = 4,
        FileFormatError = 5,
        ParameterError = 6,
        EraseFlashSectionError = 7,
        Failed = 8,
        ReadFlashSectionError = 9,
        TimecodeNotExistError = 10,
        DataFormatError = 11
    }
}
