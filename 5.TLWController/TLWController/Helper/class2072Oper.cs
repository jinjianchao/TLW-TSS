using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace TLWController.Helper
{
    public class classPartOfReg
    {
        /// <summary>
        /// 2072寄存器地址
        /// </summary>
        public ushort nRegAddr;

        /// <summary>
        /// 起始位
        /// </summary>
        public byte nBitLow;

        /// <summary>
        /// 终止位
        /// </summary>
        public byte nBitHigh;
    }
    public class classCtrlBindData
    {
        /// <summary>
        /// 绑定的控件
        /// </summary>
        public Control ctrl;

        public int Count
        {
            get
            {
                return m_listPart.Count;
            }
        }

        public List<classPartOfReg> m_listPart;

        public classCtrlBindData(Control control)
        {
            ctrl = control;
            m_listPart = new List<classPartOfReg>();
        }
        public void AddPart(ushort nRegAddr, byte nBitLow, byte nBitHigh)
        {
            classPartOfReg item = new classPartOfReg();
            item.nRegAddr = nRegAddr;
            item.nBitLow = nBitLow;
            item.nBitHigh = nBitHigh;

            m_listPart.Add(item);
        }

    }
    public class class2072Oper
    {
        public UInt16[] DefaultData { get; set; }

        /// <summary>
        /// 保存多组参数值
        /// </summary>
        private Dictionary<int, UInt32[]> m_dict2072;


        /// <summary>
        /// 控件和参数
        /// </summary>
        //private List<classCtrlBindData> m_listCtrl;
        public Dictionary<Control, classCtrlBindData> m_dictCtrl;


        /// <summary>
        /// 2019控件输入列表
        /// </summary>
        private Control[] m_listCtrl2019;

        /// <summary>
        /// 128寄存器的值对应的控件
        /// </summary>
        private Control[] m_listCtrlRegister128;//2019-03-25


        /// <summary>
        /// 添加2019芯片的控件
        /// </summary>
        /// <param name="arrCtrl"></param>
        public void AddCtrl_2019(Control[] arrCtrl)
        {
            if (arrCtrl.Length != 4) return;

            m_listCtrl2019 = new Control[4];

            for (int i = 0; i < 4; i++)
            {
                m_listCtrl2019[i] = arrCtrl[i];
            }
        }

        /// <summary>
        /// 添加128寄存器值对应的控件
        /// </summary>
        /// <param name="arrCtrl"></param>
        public void AddCtrl_Register128(Control[] arrCtrl)
        {
            if (arrCtrl.Length != 4) return;

            m_listCtrlRegister128 = new Control[4];

            for (int i = 0; i < 4; i++)
            {
                m_listCtrlRegister128[i] = arrCtrl[i];
            }
        }

        private List<string> parseCmdLine(string txt)
        {
            if (txt == "") return null;
            if (txt.Contains("|") == false) return null;

            List<string> list = new List<string>();

            //关联的输入控件名|寄存器地址1,起始位1,终止位1;寄存器地址2,起始位2,终止位2;

            //获取控件名
            string[] arr1 = txt.Split('|');
            list.Add(arr1[0]);//控件名

            string[] arr2 = arr1[1].Split(';');
            for (int i = 0; i < arr2.Length; i++)
            {
                string tmp = arr2[i].Trim();
                if (tmp == "") continue;
                string[] arr3 = tmp.Split(',');
                foreach (string item in arr3)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// 从一个指定的控件自动选择符合调节的按钮，并添加控件和寄存器的部分的关系
        /// </summary>
        /// <param name="parent"></param>
        public void FindCtrls(Control parent)
        {
            if (parent == null) return;

            //遍历寻找符合要求的按钮
            Control.ControlCollection sonControls = parent.Controls;

            foreach (Control level1 in sonControls)
            {
                if (level1.Controls.Count > 1)
                {
                    Control.ControlCollection level2 = level1.Controls;
                    foreach (Control item in level2)
                    {
                        if (item.GetType().ToString() == "System.Windows.Forms.Button")
                        {
                            //if (item.Name == "btn2072Simple13_All")
                            //{
                            //    Thread.Sleep(1);
                            //}
                            if (item.Tag == null) continue;

                            string szCmdLine = (string)item.Tag.ToString();
                            if (szCmdLine.Trim() == "")
                            {
                                continue;
                            }

                            //找到需要的button
                            List<string> list = parseCmdLine(szCmdLine);
                            if (list == null) continue;

                            //找到附加信息中指出的需要绑定的控件
                            Control[] arrCtrl = parent.Controls.Find(list[0], true);
                            if (arrCtrl.Length == 1)
                            {
                                AddCtrl(arrCtrl[0], szCmdLine);
                            }
                            else
                                continue;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 添加一个控件和相关的寄存器部分
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="szCmdLine"></param>
        public void AddCtrl(Control ctrl, string szCmdLine)
        {
            if (m_dictCtrl == null)
                m_dictCtrl = new Dictionary<Control, classCtrlBindData>();
            List<string> list = parseCmdLine(szCmdLine);
            if (list == null) return;
            if (list.Count < 3) return;
            classCtrlBindData item = new classCtrlBindData(ctrl);
            int nCount = (list.Count - 1) / 3;//看看有多少组寄存器部分

            for (int i = 0; i < nCount; i++)
            {
                //添加一个寄存器的部分内容
                try
                {
                    ushort nRegAddr = ushort.Parse(list[1 + 3 * i], System.Globalization.NumberStyles.HexNumber);
                    byte nBitLow = byte.Parse(list[1 + 3 * i + 1]);
                    byte nBitHigh = byte.Parse(list[1 + 3 * i + 2]);

                    item.AddPart(nRegAddr, nBitLow, nBitHigh);
                }
                catch
                {
                    return;
                }
            }

            //添加一个控件
            if (m_dictCtrl == null)
            {
                m_dictCtrl = new Dictionary<Control, classCtrlBindData>();
            }
            m_dictCtrl[ctrl] = item;

        }

        /// <summary>
        /// 判断某组参数是否存在
        /// </summary>
        /// <param name="nMode">0-60Hz 1-50Hz 2-3D</param>
        /// <returns></returns>
        public bool Is2072Ready(int nMode)
        {
            if (m_dict2072 == null) return false;
            return m_dict2072.ContainsKey(nMode);
        }

        /// <summary>
        /// 导入配置文件
        /// </summary>
        /// <param name="nMode">0-60Hz 1-50Hz 2-3D</param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool ImportFile(int nMode, string path)
        {
            //根据规则文件导入到内存

            //UInt32[] dat = new UInt32[21];//2018-09-26 前17个数是2072寄存器值，后4个数是2019寄存器值
            UInt32[] dat = new UInt32[22];//2019-03-25 前17个数是2072寄存器值，紧接着4个数是2019寄存器值,最后一个是单独拎出来的128寄存器值 

            List<UInt32> listData = new List<UInt32>();

            //const int nMaxLine = 18;
            const int nMaxLine = 19;//2019-03-25 增加一行用于保存128寄存器值
            try
            {
                using (TextReader reader = new StreamReader(path))
                {
                    string line = null;

                    int i = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        //if (i > 17)
                        if (i > nMaxLine)
                        {
                            //行数错误
                            //string tmp = "文件打开失败!";
                            //MessageBox.Show(tmp);
                            //WriteOutputWithTime(tmp);
                            return false;
                        }
                        if (line == "") continue;
                        string[] arr = line.Split('\t');

                        //Control[] ctrls = m_arrControl[i];
                        //int nColum = ctrls.Length;

                        //if (arr.Length != nColum + 1) continue;
                        if (arr.Length == 2) return false;//错误输入寄存器地址-数值 文件

                        //if (i == nMaxLine - 1)
                        if (i == nMaxLine - 1)
                        {
                            //2019-03-25 新增一行用于表示128寄存器的值
                            //Register Address 128  \t Value=\t 123
                            if (arr.Length != 3) continue;//信息错误，通过tab值分为3段
                            dat[21] = (UInt32)int.Parse(arr[2]);//2018-09-26
                        }
                        else if (i == nMaxLine - 2)
                        {
                            //读取2019寄存器的参数  2018-09-10

                            if (arr.Length != 5) continue; //信息错误

                            //m_arr2019Simple[m_n2072ParamIndex] = new int[4];

                            //NumericUpDown[] arrInput = { input2019Simple_160, input2019Simple_161, input2019Simple_162, input2019Simple_163};

                            for (int k = 0; k < 4; k++)
                            {
                                //m_arr2019Simple[m_n2072ParamIndex][k] = int.Parse(arr[k + 1]);
                                dat[17 + k] = (UInt32)int.Parse(arr[k + 1]);//2018-09-26
                            }
                        }
                        else
                        {
                            //赋值
                            //arr第一个元素是数据
                            string szVal = arr[0];
                            int pos = szVal.LastIndexOf("0x");
                            szVal = szVal.Remove(0, pos + 2);

                            //WriteOutputWithoutTime(szVal);

                            listData.Add(UInt32.Parse(szVal, System.Globalization.NumberStyles.HexNumber));
                        }
                        i++;
                    }

                    ////if (i != 17)
                    //if (i != nMaxLine)
                    //{
                    //    //行数错误
                    //    string tmp = Trans("文件打开失败!");
                    //    MessageBox.Show(tmp);
                    //    WriteOutputWithTime(tmp);
                    //    return false;
                    //}
                }
            }
            catch (Exception ex)
            {
                //string txt1 = "";
                //txt1 = "文件打开失败!";
                //MessageBox.Show(txt1);
                //WriteOutputWithTime(txt1);
                return false;
            }

            //寄存器值
            for (int i = 0; i < 17; i++)
            {
                dat[i] = listData[i];
            }

            if (m_dict2072 == null)
                m_dict2072 = new Dictionary<int, uint[]>();

            m_dict2072[nMode] = dat;

            return true;
        }

        /// <summary>
        /// 导出配置文件
        /// </summary>
        /// <param name="nMode">0-60Hz 1-50Hz 2-3D</param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool ExportFile(int nMode, string path)
        {
            //输出文本文件

            //是否准备好参数
            if (Is2072Ready(nMode) == false) return false;

            UInt32[] src = m_dict2072[nMode];

            System.IO.StreamWriter sw = new System.IO.StreamWriter(path, false);

            StringBuilder sb = new StringBuilder();

            string szLine = "";
            for (int i = 0; i < 17; i++)
            {
                UInt32 data = src[i];

                byte addr2072 = (byte)(i + 1);
                if (addr2072 >= 0x0E)
                {
                    addr2072 -= 0x0E;
                    addr2072 += 0xF0;
                }
                szLine = string.Format("OFFSET=0x{0:x2} val=0x{1:X8} \t", addr2072, data);////行首

                switch (i)
                {
                    case 0:
                        //0x01
                        szLine += GetPartOfUInt32(data, 24, 24).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 23, 23).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 22, 22).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 21, 21).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 20, 20).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 19, 19).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 18, 18).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 17, 17).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 16, 16).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 8, 14).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 6, 7).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 0, 5).ToString() + "\r\n";
                        break;
                    case 1:
                        //0x02
                        szLine += GetPartOfUInt32(data, 24, 31).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 16, 23).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 8, 15).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 0, 7).ToString() + "\r\n";
                        break;
                    case 2:
                        //0x03
                        szLine += GetPartOfUInt32(data, 24, 31).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 22, 23).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 20, 21).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 18, 19).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 16, 17).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 0, 15).ToString() + "\r\n";
                        break;
                    case 3:
                        //0x04
                        szLine += GetPartOfUInt32(data, 26, 26).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 25, 25).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 24, 24).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 16, 17).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 8, 12).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 0, 4).ToString() + "\r\n";
                        break;
                    case 4:
                        //0x05
                        szLine += GetPartOfUInt32(data, 24, 28).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 16, 20).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 8, 12).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 0, 4).ToString() + "\r\n";
                        break;
                    case 5:
                        //0x06
                        szLine += GetPartOfUInt32(data, 24, 28).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 16, 20).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 12, 15).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 8, 11).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 4, 7).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 0, 3).ToString() + "\r\n";
                        break;
                    case 6:
                        //0x07
                        szLine += GetPartOfUInt32(data, 24, 31).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 23, 23).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 22, 22).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 21, 21).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 19, 19).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 18, 18).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 17, 17).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 16, 16).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 14, 14).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 13, 13).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 12, 12).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 8, 11).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 4, 7).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 0, 3).ToString() + "\r\n";
                        break;
                    case 7:
                        //0x08
                        szLine += GetPartOfUInt32(data, 28, 31).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 8, 12).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 4, 7).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 0, 3).ToString() + "\r\n";
                        break;
                    case 8:
                        //0x09
                        szLine += GetPartOfUInt32(data, 28, 29).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 26, 27).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 24, 25).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 16, 23).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 8, 15).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 0, 7).ToString() + "\r\n";
                        break;
                    case 9:
                    case 10:
                    case 11:
                        //0x0a
                        //0x0b
                        //0x0c
                        szLine += GetPartOfUInt32(data, 24, 31).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 22, 23).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 16, 20).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 14, 15).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 8, 12).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 6, 7).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 0, 4).ToString() + "\r\n";
                        break;
                    case 12:
                        //0x0d
                        szLine += GetPartOfUInt32(data, 30, 31).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 24, 26).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 12, 12).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 11, 11).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 10, 10).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 9, 9).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 8, 8).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 6, 6).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 4, 5).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 3, 3).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 2, 2).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 0, 1).ToString() + "\r\n";
                        break;
                    case 13:
                        //0xf0
                        szLine += GetPartOfUInt32(data, 31, 31).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 30, 30).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 28, 29).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 24, 26).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 16, 23).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 8, 15).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 0, 7).ToString() + "\r\n";
                        break;
                    case 14:
                        //0xf1                        
                        szLine += GetPartOfUInt32(data, 15, 15).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 14, 14).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 12, 13).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 8, 11).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 1, 1).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 0, 0).ToString() + "\r\n";
                        break;
                    case 15:
                        //0xf2
                        szLine += GetPartOfUInt32(data, 25, 25).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 24, 24).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 23, 23).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 20, 22).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 19, 19).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 16, 18).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 8, 15).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 0, 7).ToString() + "\r\n";
                        break;
                    case 16:
                        //0xf3
                        szLine += GetPartOfUInt32(data, 8, 9).ToString() + "\t";
                        szLine += GetPartOfUInt32(data, 0, 7).ToString() + "\r\n";
                        break;
                }
                sb.AppendLine(szLine);
            }

            //2018-09-10 新增2019参数的输出
            string sz2019 = string.Format("2019 Register:\t{0}\t{1}\t{2}\t{3}\r\n", src[17], src[18], src[19], src[20]);
            sb.AppendLine(sz2019);

            //2019-03-25 新增128寄存器值的输出
            string sz128Register = string.Format("Register Address 128\tValue=\t{0}\r\n", src[21]);
            sb.Append(sz128Register);

            try
            {
                sw.Write(sb.ToString());
                //WriteOutputWithTime(btn2072_export.Text + " " + "\r\n" + path);
            }
            catch
            {
                return false;
            }
            finally
            {
                sw.Close();
            }

            return true;
        }

        /// <summary>
        /// 获取32位数值中的一部分
        /// </summary>
        /// <param name="src"></param>
        /// <param name="nBitLow"></param>
        /// <param name="nBitHigh"></param>
        /// <returns></returns>
        private int GetPartOfUInt32(uint src, byte nBitLow, byte nBitHigh)
        {
            //取数
            int nResult = 0;
            UInt32 tmp = src;
            int nLen = nBitHigh - nBitLow + 1;

            UInt32 mask = 0;
            for (int i = 0; i < nLen; i++)
            {
                mask |= (UInt32)(1 << (nBitLow + i));
            }

            //使用掩码
            tmp &= (UInt32)(mask);

            nResult = (int)(tmp >> nBitLow);

            return nResult;
        }

        /// <summary>
        /// 获取2200寄存器中某几位的值
        /// </summary>
        /// <param name="nMode"></param>
        /// <param name="regAddr"></param>
        /// <param name="nBitLow"></param>
        /// <param name="nBitHigh"></param>
        /// <returns></returns>
        public int GetPartOfUInt32(int nMode, ushort regAddr, byte nBitLow, byte nBitHigh)
        {
            int nResult = -1;

            //取数并修改
            if (m_dict2072.ContainsKey(nMode) == false) return nResult;

            UInt32[] arrSrc = m_dict2072[nMode];

            //定位内存数组中的位置
            int nIndex = regAddr;
            if (nIndex >= 0xF0)
            {
                nIndex -= 0xF0;
                nIndex += 0x0E;
            }
            nIndex--;

            UInt32 tmp = arrSrc[nIndex];

            nResult = GetPartOfUInt32(tmp, nBitLow, nBitHigh);//2018-07-20

            return nResult;
        }


        private UInt32 ModifyUInt32Bits(UInt32 nSrc, byte nBitLow, byte nBitHigh, UInt32 nInput)
        {
            //取数并修改
            UInt32 tmp = nSrc;
            int nLen = nBitHigh - nBitLow + 1;

            UInt32 mask = 0;
            for (int i = 0; i < nLen; i++)
            {
                mask |= (UInt32)(1 << (nBitLow + i));
            }

            //输入值过滤
            UInt32 nData = (UInt32)(nInput & (mask >> nBitLow));

            //剔除原数据中的数据
            tmp &= (UInt32)(~mask);

            //将新数据放入指定位置
            tmp |= (UInt32)(nData << nBitLow);

            return tmp;
        }

        private UInt16 ModifyUInt16Bits(UInt16 nSrc, byte nBitLow, byte nBitHigh, UInt16 nInput)
        {
            //取数并修改
            UInt16 tmp = nSrc;
            int nLen = nBitHigh - nBitLow + 1;

            UInt16 mask = 0;
            for (int i = 0; i < nLen; i++)
            {
                mask |= (UInt16)(1 << (nBitLow + i));
            }

            //输入值过滤
            UInt16 nData = (UInt16)(nInput & (mask >> nBitLow));

            //剔除原数据中的数据
            tmp &= (UInt16)(~mask);

            //将新数据放入指定位置
            tmp |= (UInt16)(nData << nBitLow);

            return tmp;
        }

        public void Change2072RegiseterVal(int nMode, int regAddr, int nBitLow, int nBitHigh, ushort val)
        {//修改内存中的数据

            //取数并修改
            if (m_dict2072.ContainsKey(nMode) == false) return;

            UInt32[] arrSrc = m_dict2072[nMode];

            //定位内存数组中的位置
            int nIndex = regAddr;
            if (nIndex >= 0xF0)
            {
                nIndex -= 0xF0;
                nIndex += 0x0E;
            }
            nIndex--;

            //1.取出原始值
            UInt32 nSrc = arrSrc[nIndex];

            //2.计算修改后的值
            UInt32 nResult = ModifyUInt32Bits(nSrc, (byte)nBitLow, (byte)nBitHigh, (UInt32)val);

            //3.将计算结果替换原有数据
            arrSrc[nIndex] = nResult;

        }

        /// <summary>
        /// 显示数据到控件或者将控件数据保存起来
        /// </summary>
        /// <param name="nMode"></param>
        /// <param name="bUpdate"></param>
        public void UpdateData(int nMode, bool bUpdate = true)
        {
            if (bUpdate)
            {
                //从控件上获取值
                //foreach (classCtrlBindData item in m_listCtrl)
                foreach (KeyValuePair<Control, classCtrlBindData> item in m_dictCtrl)
                {
                    Control ctrl = item.Key;

                    string szType = ctrl.GetType().ToString();
                    ushort val = 0;
                    if (szType == "System.Windows.Forms.ComboBox")
                    {
                        val = (ushort)((ctrl as ComboBox).SelectedIndex);
                    }
                    else if (szType == "System.Windows.Forms.NumericUpDown")
                    {
                        val = (ushort)((ctrl as NumericUpDown).Value);
                    }

                    //将数值保存到内存数组
                    foreach (classPartOfReg subItem in item.Value.m_listPart)
                    {
                        //修改内存中的数据
                        Change2072RegiseterVal(nMode, subItem.nRegAddr, subItem.nBitLow, subItem.nBitHigh, val);
                    }
                }
            }
            else
            {
                //将数值显示到控件
                //foreach (classCtrlBindData item in m_listCtrl)
                foreach (KeyValuePair<Control, classCtrlBindData> item in m_dictCtrl)
                {
                    Control ctrl = item.Key;
                    classPartOfReg subItem = item.Value.m_listPart[0];//只取第一个

                    //取出数值
                    int val = GetPartOfUInt32(nMode, (ushort)subItem.nRegAddr, (byte)subItem.nBitLow, (byte)subItem.nBitHigh);
                    if (val != -1)
                    {
                        string szType = ctrl.GetType().ToString();

                        if (szType == "System.Windows.Forms.ComboBox")
                        {
                            //(arrCtrl[0] as ComboBox).SelectedIndex = val;
                            //2018-08-28 防止输入值超出范围的报错

                            ComboBox cb = (ComboBox)(ctrl);

                            if (cb.Items.Count > 0)
                            {
                                if ((val >= 0) && (val <= cb.Items.Count - 1))
                                {
                                    cb.SelectedIndex = val;
                                }
                                else
                                {
                                    cb.SelectedIndex = 0;
                                }
                            }
                        }
                        else if (szType == "System.Windows.Forms.NumericUpDown")
                        {
                            //(arrCtrl[0] as NumericUpDown).Value = val;
                            //2018-08-28 防止输入值超出范围的报错
                            NumericUpDown input = (NumericUpDown)ctrl;
                            if ((val >= input.Minimum) && (val <= input.Maximum))
                            {
                                input.Value = val;
                            }
                            else
                                input.Value = input.Minimum;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 显示和保存2019控件数据
        /// </summary>
        /// <param name="nMode"></param>
        /// <param name="bUpdate"></param>
        public void UpdateData2019(int nMode, bool bUpdate = true)
        {
            if (m_listCtrl2019 == null) return;
            if (m_dict2072.ContainsKey(nMode) == false) return;

            UInt32[] arrData = m_dict2072[nMode];

            for (int i = 0; i < 4; i++)
            {
                NumericUpDown ctrl = (NumericUpDown)m_listCtrl2019[i];

                if (bUpdate)
                {
                    //从控件保存到内存数据
                    arrData[17 + i] = (UInt32)ctrl.Value;
                }
                else
                {
                    //显示到2019控件
                    UInt32 val = arrData[17 + i];

                    if ((val > ctrl.Maximum) || (val < ctrl.Minimum))
                    {
                        val = (UInt32)ctrl.Minimum;
                    }
                    ctrl.Value = val;
                }
            }
        }

        public void UpdateGain(int nMode, ushort r, ushort g, ushort b)
        {
            ushort r1 = ModifyUInt16Bits(DefaultData[103], 8, 16, r);
            ushort g1 = ModifyUInt16Bits(DefaultData[104], 8, 16, g);
            ushort b1 = ModifyUInt16Bits(DefaultData[105], 8, 16, b);
            DefaultData[103] = r1;
            DefaultData[104] = g1;
            DefaultData[105] = b1;
        }

        /// <summary>
        /// 显示和保存128寄存器设置值
        /// </summary>
        /// <param name="nMode"></param>
        /// <param name="bUpdate"></param>
        public void UpdateDataRegister128(int nMode, bool bUpdate = true)
        {
            if (m_listCtrlRegister128 == null) return;
            if (m_dict2072.ContainsKey(nMode) == false) return;

            UInt32[] arrData = m_dict2072[nMode];

            if (bUpdate)
            {
                //寄存器地址，起始位，终止位，数值
                TextBox ctrl = (TextBox)m_listCtrlRegister128[3];

                //从控件保存到内存数据
                arrData[21] = (UInt32.Parse(ctrl.Text.Trim()));//128寄存器的值
            }
            else
            {
                //显示到128寄存器控件

                //寄存器地址
                TextBox ctrl1 = (TextBox)m_listCtrlRegister128[0];
                ctrl1.Text = "128";


                //起始位
                ComboBox ctrl2 = (ComboBox)m_listCtrlRegister128[1];
                ctrl2.SelectedIndex = 0;


                //终止位
                ComboBox ctrl3 = (ComboBox)m_listCtrlRegister128[2];
                ctrl3.SelectedIndex = 15;


                //128寄存器数值
                TextBox ctrl4 = (TextBox)m_listCtrlRegister128[3];
                ctrl4.Text = arrData[21].ToString();

            }

        }

        /// <summary>
        /// 从2200的寄存器地址和起始终止位转换为FPGA寄存器的地址和起始位终止位
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public classPartOfReg TransformAddr(classPartOfReg src)
        {
            //------------寄存器地址和位的转换------------
            classPartOfReg objNew = new classPartOfReg();

            byte nBitLow, nBitHigh;
            nBitLow = nBitHigh = 0;
            nBitLow = (byte)src.nBitLow;
            nBitHigh = (byte)src.nBitHigh;

            ushort regAddr = 0;
            regAddr = (ushort)src.nRegAddr;

            if (regAddr >= 0xF0)//针对F0,F1,F2,F3这三个地址
            {
                regAddr -= 0xF0;
                regAddr += 0x0E;
            }
            //针对寄存器地址0x01到0x0D
            if (nBitLow > 15)//起始位高于15的话就是高16位
            {
                regAddr += 0x5E;//高16bit的地址

                //起始位需要减去16
                nBitLow -= 16;
                nBitHigh -= 16;
            }
            else
            {
                regAddr += 0x6F;//低16bit的地址
            }
            regAddr--;//减去1

            objNew.nRegAddr = regAddr;
            objNew.nBitLow = nBitLow;
            objNew.nBitHigh = nBitHigh;

            return objNew;
        }

        public classCtrlBindData FindCtrlAndData(string szCmdLine)
        {
            //从szCmdLine中获取控件名
            List<string> list = parseCmdLine(szCmdLine);

            //遍历m_dictCtrl找

            foreach (KeyValuePair<Control, classCtrlBindData> item in m_dictCtrl)
            {
                Control ctrl = item.Key;
                string szCtrlName = ctrl.Name;
                if (list[0] == szCtrlName)
                {
                    //找到了
                    return item.Value;
                }
            }
            return null;//没找到
        }

        /// <summary>
        /// 从几个参数算出一些东西
        /// </summary>
        /// <param name="nMode">//0 = 60Hz  1=50Hz  2=3D</param>
        /// <param name="szUnitType">箱体名称</param>
        /// <returns></returns>
        public ArrayList RunCalc(int nMode, string szUnitType)
        {
            ArrayList list = new ArrayList();

            //--------------取出数值 -------------

            //行扫 input2072Simple3|1,0,5
            int nScan = GetPartOfUInt32(nMode, 0x01, 0, 5);

            //刷新组数 input2072Simple2|1,8,14 
            int nGroup = GetPartOfUInt32(nMode, 0x01, 8, 14);

            //每行每组寄存器值(reg0x02[31:24],PWM显示时间) input2072Simple7|2,24,31;2,16,23;3,24,31
            int nPWMTime = GetPartOfUInt32(nMode, 0x02, 24, 31);

            //input2072Simple5|4,8,12
            int nPLL_LOOP_DIV = GetPartOfUInt32(nMode, 0x04, 8, 12);

            //input2072Simple6|4,0,4
            int nPLL_PRE_DIV = GetPartOfUInt32(nMode, 0x04, 0, 4);

            //根据60Hz ，50Hz ，3D的状态来选择
            double C = 0;
            switch (nMode)//0 = 60Hz  1=50Hz  2=3D
            {
                case 0:
                    C = 16.67f;
                    break;
                case 1:
                    C = 20f;
                    break;
                case 2:
                    C = 5.33f;
                    break;
            }

            //
            double D = 62.5f;//单位：ns

            if (szUnitType == "TWA0.9(A)")
            {
                D = 50f;
            }

            //计算出N 128寄存器的值
            int N = (int)Math.Floor((double)(1000000 * C) / (double)(D * (nScan + 1) * (nGroup + 1))) - 2;//2018-10-8 结果上减2

            //计算出最大灰度级数
            int nMaxGrayLevel = nPWMTime * 4 * (nGroup + 1);

            //计算出GAMMA最大值位数
            int nMaxGAMMAValueBit = GetGAMMAbit((ushort)nMaxGrayLevel);

            //------------合规性判断-----------
            ////A * 4 * PLL_LOOP_DIV/PLL_PRE_DIV <= (N - 16)

            ////左侧计算
            //int nLeft = 0;

            //if (nPLL_PRE_DIV == 0)
            //{
            //    return null;//分母不能为0
            //}

            //nLeft = (int)Math.Floor((double)nPWMTime * 4 * nPLL_LOOP_DIV / nPLL_PRE_DIV);

            //右侧计算
            //int nRight = N - 16;

            //A * 4 * GCLK + 16 * DCLK <=  N * DCLK

            int nLeft = (int)Math.Floor(4 * nPWMTime * 1000 / ((1000 / D) * nPLL_LOOP_DIV / nPLL_PRE_DIV));
            int nRight = (int)Math.Floor((N - 16) * D);

            //检验合规性结果
            bool bCheckOK = (nLeft <= nRight);


            //--------------------------输出结果:--------------------------

            //0:行扫 input2072Simple3|1,0,5
            list.Add(nScan);

            //1:刷新组数 input2072Simple2|1,8,14 
            list.Add(nGroup);

            //2:每行每组寄存器值(reg0x02[31:24],PWM显示时间) input2072Simple7|2,24,31;2,16,23;3,24,31
            list.Add(nPWMTime);

            //3.
            list.Add(nPLL_LOOP_DIV);

            //4.
            list.Add(nPLL_PRE_DIV);

            //5:128寄存器的值
            list.Add(N);

            //6:计算出最大灰度级数
            list.Add(nMaxGrayLevel);

            //7:计算出GAMMA最大值位数
            list.Add(nMaxGAMMAValueBit);

            //8:左侧计算
            list.Add(nLeft);

            //9:右侧计算
            list.Add(nRight);

            //10:合规性判断
            list.Add(bCheckOK);

            return list;
        }

        private int GetGAMMAbit(ushort nMaxGrayLevel)
        {
            nMaxGrayLevel = (ushort)(nMaxGrayLevel - 1);//2018-09-18
            int nBit = 0;
            for (int i = 15; i > 0; i--)
            {
                //if ((nMaxGrayLevel >> i) > 0)
                //{
                //    //
                //    ushort tmp = (ushort)((UInt32)(1 << (i + 1)) - 1);
                //    if (nMaxGrayLevel < tmp)
                //    {
                //        nBit = i - 1;
                //    }
                //    else
                //    {
                //        nBit = i;
                //    }
                //    break;
                //}

                if (((nMaxGrayLevel >> i) & 0x01) == 1)
                {
                    nBit = i + 1;
                    break;
                }
            }
            return nBit;
        }

        /// <summary>
        /// 获取数值
        /// </summary>
        /// <param name="nMode"></param>
        /// <param name="bWith2019"></param>
        /// <param name="listRegAddr"></param>
        /// <param name="listBitLow"></param>
        /// <param name="listBitHigh"></param>
        /// <param name="listVals"></param>
        /// <returns></returns>
        public bool GetMultiRegAndValues(int nMode, bool bWith2019, List<ushort> listRegAddr, List<byte> listBitLow, List<byte> listBitHigh, List<ushort> listVals)
        {
            if (Is2072Ready(nMode) == false) return false;

            UInt32[] src = m_dict2072[nMode];

            for (int i = 0; i < 17; i++)
            {
                UInt32 data = src[i];
                ushort regAddr_Hi = (ushort)(0x5E + i);
                ushort regAddr_Low = (ushort)(0x6F + i);
                ushort nHigh16 = (ushort)((src[i] >> 16) & 0xFFFF);
                ushort nLow16 = (ushort)(src[i] & 0xFFFF);

                //高16bit
                listRegAddr.Add(regAddr_Hi);
                listBitLow.Add(0);
                listBitHigh.Add(15);
                listVals.Add(nHigh16);

                //低16bit
                listRegAddr.Add(regAddr_Low);
                listBitLow.Add(0);
                listBitHigh.Add(15);
                listVals.Add(nLow16);
            }

            //2018-09-10 新增2019参数的输出
            if (bWith2019)
            {
                for (int j = 0; j < 4; j++)
                {
                    listRegAddr.Add((ushort)(0xA0 + j));
                    listBitLow.Add(0);
                    listBitHigh.Add(15);
                    listVals.Add((ushort)src[17 + j]);
                }
            }


            //2019-03-25 新增128寄存器的值
            listRegAddr.Add((ushort)128);
            listBitLow.Add(0);
            listBitHigh.Add(15);
            listVals.Add((ushort)src[21]);

            return true;
        }

        public void ImportDefaultValue(int nMode, UInt32[] src, int nOffset, int nLen)
        {
            if (nLen > 21) return;
            if (m_dict2072.ContainsKey(nMode) == false)
            {
                m_dict2072[nMode] = new UInt32[21];
                m_dict2072[nMode][17] = 32;
                m_dict2072[nMode][18] = 15;
                m_dict2072[nMode][19] = 48;
                m_dict2072[nMode][20] = 10;
            }
            UInt32[] arr = m_dict2072[nMode];


            for (int i = 0; i < nLen; i++)
            {
                arr[i] = src[nOffset + i];
            }
        }

        /// <summary>
        /// 获取2019数据
        /// </summary>
        /// <param name="nMode"></param>
        /// <param name="dst"></param>
        /// <param name="nOffset"></param>
        /// <param name="nLen"></param>
        public void Get2019Data(int nMode, UInt32[] dst, int nOffset, int nLen)
        {
            if (nLen > 4) return;
            if (m_dict2072.ContainsKey(nMode) == false)
            {
                m_dict2072[nMode] = new UInt32[21];
                m_dict2072[nMode][17] = 32;
                m_dict2072[nMode][18] = 15;
                m_dict2072[nMode][19] = 48;
                m_dict2072[nMode][20] = 10;
            }
            UInt32[] arr = m_dict2072[nMode];
            for (int i = 0; i < nLen; i++)
            {
                dst[nOffset + i] = arr[17 + i];
            }
        }

    }
}
