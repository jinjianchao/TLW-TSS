using System;
using System.Collections.Generic;
using System.Text;

namespace PluginLib
{
    /// <summary>
    /// PLAYER类别
    /// </summary>
    public enum PlayerType
    {
        /// <summary>
        /// Player 1(30版)
        /// </summary>
        PlayerV1,//30版
        /// <summary>
        /// Player 1(50版)
        /// </summary>
        PlayerV3,//50版
        /// <summary>
        /// Player二代
        /// </summary>
        PlayerV2,

        TV60,
        PlayeSW,
        PlayerTW,
        D102C,
        NONE
    }

    /// <summary>
    /// 输出口类别
    /// </summary>
    public enum OutputType
    {
        /// <summary>
        /// 输出口1
        /// </summary>
        Output1,
        /// <summary>
        /// 输出口2
        /// </summary>
        Output2,
        /// <summary>
        /// 输出口3
        /// </summary>
        Output3,
        /// <summary>
        /// 输出口4
        /// </summary>
        Output4,
        /// <summary>
        /// 双输出口
        /// </summary>
        Both,
        /// <summary>
        /// 没有输出口
        /// </summary>
        None,
        /// <summary>
        /// 所有输出口
        /// </summary>
        All = 65535
    }

    #region 自定义类型
    /// <summary>
    /// 下拉列表框绑定类
    /// </summary>
    public class ComboxList
    {
        /// <summary>
        /// 显示文本
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public object Value { get; set; }
    }

    #endregion
}
