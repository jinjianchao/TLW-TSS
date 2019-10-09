#region << 注释 >>
/************************************************************************
*文件名： StructModule
*创建人： JIN
*创建时间：2019/8/14 15:02:29
*描述：
*=======================================================================
*修改时间：2019/8/14 15:02:29
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
    public struct StructModule
    {
        public StructModule(int x,int y,byte position)
        {
            X = x;
            Y = y;
            Position = position;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public byte Position { get; set; }
    }
}
