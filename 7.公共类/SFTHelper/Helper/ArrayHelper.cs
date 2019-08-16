#region << 注释 >>
/************************************************************************
*文件名： ArrayHelper
*创建人： JIN
*创建时间：2019/8/15 15:34:25
*描述：
*=======================================================================
*修改时间：2019/8/15 15:34:25
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFTHelper.Helper
{
    public class ArrayHelper
    {
        public static string[,] Reverse(string[,] data)
        {
            int i0 = data.GetLength(0);
            int i1 = data.GetLength(1);
            string[,] result = new string[i0, i1];
            for (int i = 0; i < i0; i++)
            {
                for (int j = 0; j < i1; j++)
                {
                    result[i0 - i - 1, i1 - j - 1] = data[i, j];
                }
            }
            return result;
        }
    }
}
