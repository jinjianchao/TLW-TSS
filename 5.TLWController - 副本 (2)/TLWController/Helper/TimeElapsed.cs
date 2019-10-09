#region << 注释 >>
/************************************************************************
*文件名： TimeElapsed
*创建人： JIN
*创建时间：2019/7/3 10:43:02
*描述：
*=======================================================================
*修改时间：2019/7/3 10:43:02
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
    /// <summary>
    /// 耗时计算类
    /// </summary>
    public class TimeElapsed
    {
        public static TimeSpan m_start;
        public static TimeSpan m_end;
        public static void Start()
        {
            m_start = new TimeSpan(DateTime.Now.Ticks);
        }
        public static void Stop()
        {
            m_end = new TimeSpan(DateTime.Now.Ticks);
        }

        public static string GetTimes()
        {
            TimeSpan tp = m_end.Subtract(m_start).Duration();

            if (tp.Minutes == 0)
            {
                if (tp.Seconds == 0)
                {
                    return string.Format("耗时:{0}毫秒", tp.Milliseconds);
                }
                else
                {
                    return string.Format("耗时:{0}秒{1}毫秒", tp.Seconds, tp.Milliseconds);
                }
            }
            else
            {
                return string.Format("耗时:{0}分{1}秒{2}毫秒", tp.Minutes, tp.Seconds, tp.Milliseconds);
            }
        }
    }
}
