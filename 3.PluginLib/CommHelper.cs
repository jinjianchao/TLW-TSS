using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PluginLib
{
    /// <summary>
    /// 常用方法类
    /// </summary>
    public class CommHelper
    {
        /// <summary>
        /// 计算箱体地址
        /// </summary>
        /// <param name="x">箱体行</param>
        /// <param name="y">箱体列</param>
        /// <returns></returns>
        public static UInt16 CombineAX(int x, int y)
        {
            UInt16 addr = (UInt16)((x << 8) + (y));
            return addr;
        }

        /// <summary>
        /// 把一个十进制的数拆分成高八位和低八位
        /// </summary>
        /// <param name="AX">十进制</param>
        /// <param name="AH">高8为</param>
        /// <param name="AL">低8为</param>
        public static void SplitAX(int AX, out UInt16 AH, out UInt16 AL)
        {
            AH = (byte)((AX >> 8) & 0xFF);
            AL = (byte)(AX & 0xFF);
        }

        /// <summary>
        /// 判断箱体地址是否合法
        /// </summary>
        /// <param name="bothOutput">输出口</param>
        /// <param name="unitX"></param>
        /// <param name="unitY"></param>
        /// <returns></returns>
        public static bool IsAlivdUnitAddr(bool bothOutput,int unitX, int unitY)
        {
            if (!bothOutput)
            {
                bool re1=(unitX.Equals(0) && unitY.Equals(0));
                bool re2=(unitX.Equals(255) && unitY.Equals(255));
                bool re3=(IsAlivdUnit(unitX)&&IsAlivdUnit(unitY));

                if (re1 || re2 || re3)
                {
                    return true;
                    //Tip tipForm = new Tip();
                    //tipForm.StartPosition = FormStartPosition.CenterScreen;
                    //tipForm.ShowDialog();
                   

                }
                else
                {
                    //MessageBox.Show("            'Address' is wrong !\r      eg:Full Scrren:(0,0)\r           single pannel:(10,10)~(17,17)", "Tips");
                    return false;
                }
            }
            else
            {
                if (!(unitX.Equals(0) && unitY.Equals(0)))
                {
                    //Tip tipForm = new Tip();
                    //tipForm.StartPosition = FormStartPosition.CenterScreen;
                    //tipForm.ShowDialog();
                    //MessageBox.Show("   'Address' is wrong !\r      eg:Full Scrren:(0,0)\r       single pannel:(10,10)~(17,17)", "Tips");
                    return false;

                }
                else return true;
            }
        }
        public static bool IsAlivdUnit(int unit)
        {

            if (unit <= 17 && unit >= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
