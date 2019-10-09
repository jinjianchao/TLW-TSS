#region << 注释 >>
/************************************************************************
*文件名： ColorTempHelper
*创建人： JIN
*创建时间：2019/7/31 12:20:57
*描述：
*=======================================================================
*修改时间：2019/7/31 12:20:57
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TLWController.Structs;
using SFTHelper.Extentions;

namespace TLWController.Helper
{
    public class ColorTempHelper
    {
        public static colorTempData GetColorTempData(byte[] data)
        {
            int offset = 0;
            colorTempData colorTempData = new colorTempData();
            for (int i = 0; i < 4; i++)
            {
                //第一套为60Hz色温组，第二套为50Hz色温组，第三套为3D色温组，第四套预留用途
                colorTempData.arrGroup[i] = new colorTempGroup();
                colorTempGroup group = colorTempData.arrGroup[i];
                for (int j = 0; j < 10; j++)
                {
                    //10个色温,0 = 3200K , 1=6500K, 2=8500K,3=9300K,其他为自定义色温值
                    group.arrData[j] = new colorTemp();
                    colorTemp colorTemp = group.arrData[j];
                    colorTemp.Red_Hi = data[0 + offset];
                    colorTemp.Red_Lo = data[1 + offset];
                    colorTemp.Green_Hi = data[2 + offset];
                    colorTemp.Green_Lo = data[3 + offset];
                    colorTemp.Blue_Hi = data[4 + offset];
                    colorTemp.Blue_Lo = data[5 + offset];
                    offset += 6;
                }
            }
            return colorTempData;
        }

        public static byte[] GetData(colorTempData ct)
        {
            int offset = 0;
            byte[] data = new byte[1024].Fill(0xff);
            for (int i = 0; i < 4; i++)
            {
                //第一套为60Hz色温组，第二套为50Hz色温组，第三套为3D色温组，第四套预留用途
                colorTempGroup group = ct.arrGroup[i];
                for (int j = 0; j < 10; j++)
                {
                    //10个色温,0 = 3200K , 1=6500K, 2=8500K,3=9300K,其他为自定义色温值
                    colorTemp colorTemp = group.arrData[j];
                    data[0 + offset] = colorTemp.Red_Hi;
                    data[1 + offset] = colorTemp.Red_Lo;
                    data[2 + offset] = colorTemp.Green_Hi;
                    data[3 + offset] = colorTemp.Green_Lo;
                    data[4 + offset] = colorTemp.Blue_Hi;
                    data[5 + offset] = colorTemp.Blue_Lo;
                    offset += 6;
                }
            }
            return data;
        }
    }
}
