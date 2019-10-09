#region << 注释 >>
/************************************************************************
*文件名： ColorTemp
*创建人： JIN
*创建时间：2019/7/31 11:36:38
*描述：
*=======================================================================
*修改时间：2019/7/31 11:36:38
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLWController.Structs
{
    public class colorTemp
    {
        public byte Red_Hi;
        public byte Red_Lo;
        public byte Green_Hi;
        public byte Green_Lo;
        public byte Blue_Hi;
        public byte Blue_Lo;
    }

    public class colorTempGroup
    {
        public colorTemp[] arrData = new colorTemp[10]; //10个色温,0 = 3200K , 1=6500K, 2=8500K,3=9300K,其他为自定义色温值
        public byte[] reserve = new byte[4]; //保留值
    }

    public class colorTempData
    {
        public colorTempGroup[] arrGroup = new colorTempGroup[4];//第一套为60Hz色温组，第二套为50Hz色温组，第三套为3D色温组，第四套预留用途
        public byte[] reserve = new byte[768];//保留值
    }

}
