using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LYDTOPDP;
using LYDTOPDP.Service;
using LydTOPDP.Service;
using System.Xml;
using System.Collections;
using PluginLib;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using LanguageLib;
using System.Runtime.InteropServices;

namespace LydTOPDP
{
    class ArgHelper
    {
        string[] args;
        public ArgHelper(string[] args)
        {
            this.args = args;
        }

        #region 工程师模式
        public string getParameterValue(string parameter)
        {
            foreach (var arg in args)
            {
                string[] tmpArr = arg.Split(':');
                if (tmpArr.Length != 2) return string.Empty;
                if (tmpArr[0].ToLower() == parameter) return tmpArr[1];
            }
            return string.Empty;
        }

        #endregion
    }

    static class Program
    {
        private static IList[] m_lanDic = null;
        private static int m_lanIndex = 2;
        private static string m_region;//当前语言区域
        private static string m_split;//各个语言之间的分割符

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoadLanguage();
            StartForm startForm = new StartForm(null, false);
            startForm.SetLanDic(m_lanDic, m_lanIndex, m_region, m_split);
            Application.Run(startForm);
            return;
        }

        static void LoadLanguage()
        {
            String lang = LanguageLib.LanguageHelper.ReadLanCode().ToString();
            IList<LanguageConfig> lanList = LanguageHelper.GetLanList(AppDomain.CurrentDomain.BaseDirectory + Constant.LanguageConfig);

            int lanLength = lanList.Count;

            m_lanDic = LanguageHelper.LoadLanDic(AppDomain.CurrentDomain.BaseDirectory + Constant.LanText, lanLength, out m_region, out m_split);

            foreach (var item in lanList)
            {
                if (lang == item.Key.ToString())
                {
                    m_lanIndex = item.ID;
                    break;
                }
            }
        }
    }
}
