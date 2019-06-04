#region << 注释 >>
/************************************************************************
*文件名： Extentions
*创建人： JIN
*创建时间：2019/5/15 11:26:56
*描述：
*=======================================================================
*修改时间：2019/5/15 11:26:56
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LYDTOPDP.Extention
{
    public static class Extentions
    {
        public static Boolean IsBoolean(this String source)
        {
            bool isBool = false;
            return bool.TryParse(source, out isBool);
        }

        /// <summary>
        /// 判断是否为null或者空字符串(空格除外)
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Boolean IsEmpty(this String source)
        {
            return String.IsNullOrEmpty(source);
        }

        /// <summary>
        /// 判断是否为null、空字符串或者空字符(空格)
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Boolean IsWhiteOrEmpty(this String source)
        {
            if (source.IsEmpty()) return true;
            return source.Trim().IsEmpty();
        }

        /// <summary>
        /// 判断是否为Int32数据类型
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Boolean IsInt32(this String source)
        {
            int result = -1;
            return Int32.TryParse(source, NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out result);
        }

        public static Boolean ToBoolean(this String source)
        {
            try { return bool.Parse(source); }
            catch (FormatException ex) { throw ex; }
        }
        /// <summary>
        /// 将字符串转换为Int32数据类型
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Int32 ToInt32(this String source)
        {
            try { return int.Parse(source.ToString(), NumberFormatInfo.InvariantInfo); }
            catch (FormatException ex) { throw ex; }
        }

        /// <summary>
        /// 移除所有空格，包括字符串内部空格
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static String TrimAllWhiteSpace(this string source)
        {
            source = source = source.Trim();
            string tmpStr = "";
            for (int i = 0; i < source.Length; i++)
            {
                string tmp = source.Substring(i, 1);
                if (tmp != " ")
                {
                    tmpStr += tmp;
                }
            }
            return tmpStr;
        }
    }
}
