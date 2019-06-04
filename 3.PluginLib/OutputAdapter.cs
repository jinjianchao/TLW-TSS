using System;
using System.Collections.Generic;
using System.Text;

namespace PluginLib
{
    /// <summary>
    /// 输出口适配器
    /// </summary>
    public class OutputAdapter
    {
        /// <summary>
        /// 得到输出口的实际值
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        public static int GetOutputValue(OutputType output)
        {
            int result = 255;
            switch (output)
            { 
                case OutputType.None:
                    result = 255;
                    break;
                case OutputType.Output1:
                    result = 0;
                    break;
                case OutputType.Output2:
                    result = 1;
                    break;
                case OutputType.Output3:
                    result = 2;
                    break;
                case OutputType.Output4:
                    result = 3;
                    break;
            }
            return result;
        }
    }
}
