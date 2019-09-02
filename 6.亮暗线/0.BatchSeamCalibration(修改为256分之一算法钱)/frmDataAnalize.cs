using BatchSeamCalibration.Structs;
using PluginLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TLWComm;

namespace BatchSeamCalibration
{
    public partial class frmDataAnalize : Form
    {
        #region 字段
        byte[] _calData = null;
        int _width;
        int _height;
        private TLWCommOper _oper;
        #endregion

        #region 属性
        public UnitTypeV2 CabinetSize { get; set; }

        public string exePath { get; set; }

        public string CurrentPath { get; set; }

        #endregion

        #region 方法

        private int GetLineNoVscroll(RichTextBox rtb)
        {
            //获得当前坐标信息
            Point p = rtb.Location;
            int crntFirstIndex = rtb.GetCharIndexFromPosition(p);
            int crntFirstLine = rtb.GetLineFromCharIndex(crntFirstIndex);
            return crntFirstLine;
        }

        private void TrunRowsId(int iCodeRowsID, RichTextBox rtb)
        {
            try
            {
                rtb.SelectionStart = rtb.GetFirstCharIndexFromLine(iCodeRowsID);
                rtb.SelectionLength = 0;
                rtb.ScrollToCaret();
            }
            catch
            {

            }
        }

        private byte HiByte(ushort val)
        {
            return (byte)((val >> 8) & 0xFF);
        }
        private byte LoByte(ushort val)
        {
            return (byte)(val & 0xFF);
        }

        bool GetRData(int width, byte[] data, out ushort[] r1, out ushort[] r2, out ushort[] r3, out ushort[] g1, out ushort[] g2, out ushort[] g3, out ushort[] b1, out ushort[] b2, out ushort[] b3)
        {
            r1 = new ushort[width];
            r2 = new ushort[width];
            r3 = new ushort[width];

            g1 = new ushort[width];
            g2 = new ushort[width];
            g3 = new ushort[width];

            b1 = new ushort[width];
            b2 = new ushort[width];
            b3 = new ushort[width];

            int pos = 0;
            for (int i = 0; i < width; i++)
            {
                byte[] onePixelData = new byte[18];
                Array.Copy(data, i * 18, onePixelData, 0, onePixelData.Length);
                for (int j = 0; j < 9; j++)
                {
                    r1[pos] = (ushort)(onePixelData[0] << 8 | onePixelData[1]);
                    r2[pos] = (ushort)(onePixelData[2] << 8 | onePixelData[3]);
                    r3[pos] = (ushort)(onePixelData[4] << 8 | onePixelData[5]);

                    g1[pos] = (ushort)(onePixelData[6] << 8 | onePixelData[7]);
                    g2[pos] = (ushort)(onePixelData[8] << 8 | onePixelData[9]);
                    g3[pos] = (ushort)(onePixelData[10] << 8 | onePixelData[11]);

                    b1[pos] = (ushort)(onePixelData[12] << 8 | onePixelData[13]);
                    b2[pos] = (ushort)(onePixelData[14] << 8 | onePixelData[15]);
                    b3[pos] = (ushort)(onePixelData[16] << 8 | onePixelData[17]);
                }
                pos++;
            }
            return true;
        }

        private void InitDataType()
        {
            cbDataType.SelectedIndexChanged -= cbDataType_SelectedIndexChanged;
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem() { Text = string.Format("箱体文件"), Value = 0 });
            items.Add(new ListItem() { Text = string.Format("模块文件"), Value = 1 });
            cbDataType.DisplayMember = "Text";
            cbDataType.ValueMember = "Value";
            cbDataType.DataSource = items;
            cbDataType.SelectedIndex = 0;
            cbDataType.SelectedIndexChanged += cbDataType_SelectedIndexChanged;
        }

        private void InitRowList(int rows)
        {
            cbRowList.SelectedIndexChanged -= cbRowList_SelectedIndexChanged;
            List<ListItem> items = new List<ListItem>();
            for (int i = -1; i < rows; i++)
            {
                if (i == -1)
                {
                    items.Add(new ListItem() { Text = "所有数据", Value = -1 });
                }
                else
                {
                    items.Add(new ListItem() { Text = string.Format("行{0}", (i + 1)), Value = i });
                }
            }
            cbRowList.DisplayMember = "Text";
            cbRowList.ValueMember = "Value";
            cbRowList.DataSource = items;
            cbRowList.SelectedIndex = 0;
            cbRowList.SelectedIndexChanged += cbRowList_SelectedIndexChanged;
        }

        private void InitSinglePixelList(int width)
        {
            cbSinglePixel.SelectedIndexChanged -= cbSinglePixel_SelectedIndexChanged;
            List<ListItem> items = new List<ListItem>();
            for (int i = 0; i < width; i++)
            {
                items.Add(new ListItem() { Text = string.Format("列{0}", (i + 1)), Value = i });
            }
            cbSinglePixel.DisplayMember = "Text";
            cbSinglePixel.ValueMember = "Value";
            cbSinglePixel.DataSource = items;
            cbSinglePixel.SelectedIndex = 0;
            cbSinglePixel.SelectedIndexChanged += cbSinglePixel_SelectedIndexChanged;
        }

        private void InitDecimalOrHexDisplay()
        {
            cbHexOrDecimal.SelectedIndexChanged -= cbHexOrDecimal_SelectedIndexChanged;
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem() { Text = "十六进制", Value = 0 });
            items.Add(new ListItem() { Text = "十进制", Value = 1 });
            cbHexOrDecimal.DisplayMember = "Text";
            cbHexOrDecimal.ValueMember = "Value";
            cbHexOrDecimal.DataSource = items;
            cbHexOrDecimal.SelectedIndex = 0;
            cbHexOrDecimal.SelectedIndexChanged += cbHexOrDecimal_SelectedIndexChanged;
        }

        private EnumDataType GetCalibrationDataType(string file)
        {
            CalibrationProcess process = new CalibrationProcess();
            CalibrationProcessLib.CalibrationProcess calProcess = new CalibrationProcessLib.CalibrationProcess();
            EnumDataType dataType = process.GetDataType(_width, _height, file);
            return dataType;
        }

        private byte[] GetDataFromZdataFile(int width, int height, string file)
        {
            byte[] srcData = new byte[width * height * 16];
            FileStream reader = null;
            using (reader = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                if (reader.Length != srcData.Length) return null;
                reader.Read(srcData, 0, srcData.Length);
            }

            byte[] newData = new byte[width * height * 18];
            byte[] zOnePixelData = new byte[16];

            int nLeftMove = 5;//左移的位数 2017-11-16
            nLeftMove = nLeftMove + 1;//0 旧格式 1 所有辅色左移1位

            ushort tmp;
            int pixelCount = width * height;
            for (int i = 0; i < pixelCount; i++)
            {
                Array.Copy(srcData, i * 16, zOnePixelData, 0, 16);//读取Zdata一个像素数据
                newData[i * 18] = zOnePixelData[0];
                newData[i * 18 + 1] = zOnePixelData[1];//R1主色

                tmp = (ushort)(zOnePixelData[2] << nLeftMove);
                newData[i * 18 + 2] = HiByte(tmp);
                newData[i * 18 + 3] = LoByte(tmp);//R2红色辅色

                tmp = (ushort)(zOnePixelData[3] << nLeftMove);
                newData[i * 18 + 4] = HiByte(tmp);
                newData[i * 18 + 5] = LoByte(tmp);//R3红色辅色

                tmp = (ushort)(zOnePixelData[4] << nLeftMove);
                newData[i * 18 + 6] = HiByte(tmp);
                newData[i * 18 + 7] = LoByte(tmp);//G1绿色辅色

                newData[i * 18 + 8] = zOnePixelData[5];
                newData[i * 18 + 9] = zOnePixelData[6];//G2绿色主色

                tmp = (ushort)(zOnePixelData[7] << nLeftMove);
                newData[i * 18 + 10] = HiByte(tmp);
                newData[i * 18 + 11] = LoByte(tmp);//G3绿色辅色

                tmp = (ushort)(zOnePixelData[8] << nLeftMove);
                newData[i * 18 + 12] = HiByte(tmp);
                newData[i * 18 + 13] = LoByte(tmp);//B1蓝色辅色

                tmp = (ushort)(zOnePixelData[9] << nLeftMove);
                newData[i * 18 + 14] = HiByte(tmp);
                newData[i * 18 + 15] = LoByte(tmp);//B2蓝色辅色

                newData[i * 18 + 16] = zOnePixelData[10];
                newData[i * 18 + 17] = zOnePixelData[11];//B3蓝色主色
            }
            return newData;
        }

        private byte[] GetDataFromSdataFile(int width, int height, string file)
        {
            byte[] srcData = new byte[width * height * 18];
            FileStream reader = null;
            using (reader = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                if (reader.Length != srcData.Length) return null;
                reader.Read(srcData, 0, srcData.Length);
            }
            return srcData;
        }

        private byte[] GetCalibrationData(int width, int height, EnumDataType enumDataType, string file)
        {
            byte[] data = null;
            if (!CalibrationProcessLib.CalibrationReader.Read(file, width, height, out data)) return null;
            return data;
        }

        private byte[] GetRowData(int row, int width, byte[] allData)
        {
            byte[] data = new byte[width * 18];
            Array.Copy(allData, row * width * 18, data, 0, data.Length);
            return data;
        }

        private string ConverUshortToString(ushort[] data, int hexOrDecimal)
        {
            string tmp = "";
            string format = "X4";
            if (hexOrDecimal == 1)
            {
                format = "D5";
            }
            for (int i = 0; i < data.Length; i++)
            {
                tmp += data[i].ToString(format) + " ";
            }
            return tmp;
        }

        void ShowData(byte[] calData, int row, int hexOrDecimal, RichTextBox richText)
        {
            ushort[] r1;
            ushort[] r2;
            ushort[] r3;
            ushort[] g1;
            ushort[] g2;
            ushort[] g3;
            ushort[] b1;
            ushort[] b2;
            ushort[] b3;

            if (row == -1)
            {
                richText.Clear();
                string txt = "";
                for (int i = 0; i < _height; i++)
                {
                    txt += "行:" + (i + 1).ToString("D8") + "\r\n";
                    byte[] data = GetRowData(i, _width, calData);
                    GetRData(_width, data, out r1, out r2, out r3, out g1, out g2, out g3, out b1, out b2, out b3);

                    string r1Str = "\tR1:" + ConverUshortToString(r1, hexOrDecimal);
                    string r2Str = "\tR2:" + ConverUshortToString(r2, hexOrDecimal);
                    string r3Str = "\tR3:" + ConverUshortToString(r3, hexOrDecimal);

                    string g1Str = "\tG1:" + ConverUshortToString(g1, hexOrDecimal);
                    string g2Str = "\tG2:" + ConverUshortToString(g2, hexOrDecimal);
                    string g3Str = "\tG3:" + ConverUshortToString(g3, hexOrDecimal);

                    string b1Str = "\tB1:" + ConverUshortToString(b1, hexOrDecimal);
                    string b2Str = "\tB2:" + ConverUshortToString(b2, hexOrDecimal);
                    string b3Str = "\tB3:" + ConverUshortToString(b3, hexOrDecimal);

                    string splitRowData = "";
                    for (int j = 0; j < data.Length / 18; j++)
                    {
                        byte[] tmpData = new byte[18];
                        Array.Copy(data, j * 18, tmpData, 0, tmpData.Length);
                        splitRowData += BitConverter.ToString(tmpData).Replace("-", " ") + "\r\n";
                    }
                    splitRowData = "";
                    txt += splitRowData + r1Str + "\r\n" + r2Str + "\r\n" + r3Str + "\r\n" + g1Str + "\r\n" + g2Str + "\r\n" + g3Str + "\r\n" + b1Str + "\r\n" + b2Str + "\r\n" + b3Str + "\r\n";
                }
                richText.Text = txt;
            }
            else
            {
                byte[] data = GetRowData(row, _width, calData);
                GetRData(_width, data, out r1, out r2, out r3, out g1, out g2, out g3, out b1, out b2, out b3);

                string r1Str = "\tR1:" + ConverUshortToString(r1, hexOrDecimal);
                string r2Str = "\tR2:" + ConverUshortToString(r2, hexOrDecimal);
                string r3Str = "\tR3:" + ConverUshortToString(r3, hexOrDecimal);

                string g1Str = "\tG1:" + ConverUshortToString(g1, hexOrDecimal);
                string g2Str = "\tG2:" + ConverUshortToString(g2, hexOrDecimal);
                string g3Str = "\tG3:" + ConverUshortToString(g3, hexOrDecimal);

                string b1Str = "\tB1:" + ConverUshortToString(b1, hexOrDecimal);
                string b2Str = "\tB2:" + ConverUshortToString(b2, hexOrDecimal);
                string b3Str = "\tB3:" + ConverUshortToString(b3, hexOrDecimal);

                string splitRowData = "";
                for (int i = 0; i < data.Length / 18; i++)
                {
                    byte[] tmpData = new byte[18];
                    Array.Copy(data, i * 18, tmpData, 0, tmpData.Length);
                    splitRowData += BitConverter.ToString(tmpData).Replace("-", " ") + "\r\n";
                }
                splitRowData = "";
                richText.Text = "行:" + (row + 1).ToString("D8") + "\r\n" + splitRowData + r1Str + "\r\n" + r2Str + "\r\n" + r3Str + "\r\n" + g1Str + "\r\n" + g2Str + "\r\n" + g3Str + "\r\n" + b1Str + "\r\n" + b2Str + "\r\n" + b3Str + "\r\n";

                int singlePixelIndex = int.Parse(cbSinglePixel.SelectedValue.ToString());

                string format = "X4";
                if (hexOrDecimal == 1)
                {
                    format = "D";
                }
                txtR1.Text = r1[singlePixelIndex].ToString(format);
                txtR2.Text = r2[singlePixelIndex].ToString(format);
                txtR3.Text = r3[singlePixelIndex].ToString(format);

                txtG1.Text = g1[singlePixelIndex].ToString(format);
                txtG2.Text = g2[singlePixelIndex].ToString(format);
                txtG3.Text = g3[singlePixelIndex].ToString(format);

                txtB1.Text = b1[singlePixelIndex].ToString(format);
                txtB2.Text = b2[singlePixelIndex].ToString(format);
                txtB3.Text = b3[singlePixelIndex].ToString(format);
            }
        }

        private void CompareData(byte[] data1, byte[] data2)
        {
            if (data1.Length != data2.Length)
            {
                MessageBox.Show(this, "数据长度不一样");
                return;
            }
            for (int i = 0; i < data1.Length; i++)
            {
                if (data1[i] != data2[i])
                {
                    MessageBox.Show(this, "数据内容不一样");
                    return;
                }
            }
            MessageBox.Show(this, "文件内容一致");
            //int hexOrDecimal = int.Parse(cbHexOrDecimal.SelectedValue.ToString());
            ////ShowData(data1, -1, hexOrDecimal, rtCompare1Content);
            ////ShowData(data2, -1, hexOrDecimal, rtCompare2Content);

            //ushort[] r1_1;
            //ushort[] r1_2;
            //ushort[] r1_3;
            //ushort[] g1_1;
            //ushort[] g1_2;
            //ushort[] g1_3;
            //ushort[] b1_1;
            //ushort[] b1_2;
            //ushort[] b1_3;
            //ushort[] r2_1;
            //ushort[] r2_2;
            //ushort[] r2_3;
            //ushort[] g2_1;
            //ushort[] g2_2;
            //ushort[] g2_3;
            //ushort[] b2_1;
            //ushort[] b2_2;
            //ushort[] b2_3;

            ////string msg = "";
            ////for (int i = 0; i < _height; i++)
            ////{
            ////    byte[] data1_1 = GetRowData(i, _width, data1);
            ////    GetRData(_width, data1_1, out r1_1, out r1_2, out r1_3, out g1_1, out g1_2, out g1_3, out b1_1, out b1_2, out b1_3);
            ////    byte[] data2_1 = GetRowData(i, _width, data2);
            ////    GetRData(_width, data2_1, out r2_1, out r2_2, out r2_3, out g2_1, out g2_2, out g2_3, out b2_1, out b2_2, out b2_3);
            ////    //string rowStr = "行:" + (i + 1).ToString() + "\r\n";
            ////    //string compare1 = "";
            ////    //string compare2 = "";

            ////    //for (int j = 0; j < r1_1.Length; j++)
            ////    //{
            ////    //    string str1 = "";
            ////    //    string str2 = "";
            ////    //    if (r1_1[j] != r2_1[j])
            ////    //    {
            ////    //        str1 = "\tR1:" + ConverUshortToString(r1_1, hexOrDecimal) + "\r\n";
            ////    //        str2 = "\tR1:" + ConverUshortToString(r2_1, hexOrDecimal) + "\r\n";

            ////    //        compare1 += rowStr + str1;
            ////    //        compare2 += rowStr + str2;
            ////    //        break;
            ////    //    }

            ////    //}
            ////    rtCompare1Content.AppendText(compare1);
            ////    rtCompare2Content.AppendText(compare2);
            ////}

            //rtCompare1Content.Clear();
            //string txt = "";
            //for (int i = 0; i < _height; i++)
            //{
            //    txt += "行:" + (i + 1).ToString("D8") + "\r\n";
            //    byte[] data = GetRowData(i, _width, data1);
            //    GetRData(_width, data, out r1_1, out r1_2, out r1_3, out g1_1, out g1_2, out g1_3, out b1_1, out b1_2, out b1_3);

            //    string r1Str = "\tR1:" + ConverUshortToString(r1_1, hexOrDecimal);
            //    string r2Str = "\tR2:" + ConverUshortToString(r1_2, hexOrDecimal);
            //    string r3Str = "\tR3:" + ConverUshortToString(r1_3, hexOrDecimal);

            //    string g1Str = "\tG1:" + ConverUshortToString(g1_1, hexOrDecimal);
            //    string g2Str = "\tG2:" + ConverUshortToString(g1_2, hexOrDecimal);
            //    string g3Str = "\tG3:" + ConverUshortToString(g1_3, hexOrDecimal);

            //    string b1Str = "\tB1:" + ConverUshortToString(b1_1, hexOrDecimal);
            //    string b2Str = "\tB2:" + ConverUshortToString(b1_2, hexOrDecimal);
            //    string b3Str = "\tB3:" + ConverUshortToString(b1_3, hexOrDecimal);

            //    string splitRowData = "";
            //    for (int j = 0; j < data.Length / 18; j++)
            //    {
            //        byte[] tmpData = new byte[18];
            //        Array.Copy(data, j * 18, tmpData, 0, tmpData.Length);
            //        splitRowData += BitConverter.ToString(tmpData).Replace("-", " ") + "\r\n";
            //    }
            //    splitRowData = "";
            //    txt += splitRowData + r1Str + "\r\n" + r2Str + "\r\n" + r3Str + "\r\n" + g1Str + "\r\n" + g2Str + "\r\n" + g3Str + "\r\n" + b1Str + "\r\n" + b2Str + "\r\n" + b3Str + "\r\n";
            //}
            //rtCompare1Content.Text = txt;

            //rtCompare2Content.Clear();
            //txt = "";
            //for (int i = 0; i < _height; i++)
            //{
            //    txt += "行:" + (i + 1).ToString("D8") + "\r\n";
            //    byte[] data = GetRowData(i, _width, data2);
            //    GetRData(_width, data, out r2_1, out r2_2, out r2_3, out g2_1, out g2_2, out g2_3, out b2_1, out b2_2, out b2_3);

            //    string r1Str = "\tR1:" + ConverUshortToString(r2_1, hexOrDecimal);
            //    string r2Str = "\tR2:" + ConverUshortToString(r2_2, hexOrDecimal);
            //    string r3Str = "\tR3:" + ConverUshortToString(r2_3, hexOrDecimal);

            //    string g1Str = "\tG1:" + ConverUshortToString(g2_1, hexOrDecimal);
            //    string g2Str = "\tG2:" + ConverUshortToString(g2_2, hexOrDecimal);
            //    string g3Str = "\tG3:" + ConverUshortToString(g2_3, hexOrDecimal);

            //    string b1Str = "\tB1:" + ConverUshortToString(b2_1, hexOrDecimal);
            //    string b2Str = "\tB2:" + ConverUshortToString(b2_2, hexOrDecimal);
            //    string b3Str = "\tB3:" + ConverUshortToString(b2_3, hexOrDecimal);

            //    string splitRowData = "";
            //    for (int j = 0; j < data.Length / 18; j++)
            //    {
            //        byte[] tmpData = new byte[18];
            //        Array.Copy(data, j * 18, tmpData, 0, tmpData.Length);
            //        splitRowData += BitConverter.ToString(tmpData).Replace("-", " ") + "\r\n";
            //    }
            //    splitRowData = "";
            //    txt += splitRowData + r1Str + "\r\n" + r2Str + "\r\n" + r3Str + "\r\n" + g1Str + "\r\n" + g2Str + "\r\n" + g3Str + "\r\n" + b1Str + "\r\n" + b2Str + "\r\n" + b3Str + "\r\n";
            //}
            //rtCompare2Content.Text = txt;
        }

        #endregion

        public frmDataAnalize()
        {
            InitializeComponent();
        }

        private void frmDataAnalize_Load(object sender, EventArgs e)
        {
            _oper = new TLWCommOper(System.IO.Path.Combine(CurrentPath, "tlw.dll"));

            InitDataType();
            _width = CabinetSize.GetSize().Width;
            _height = CabinetSize.GetSize().Height;
            InitRowList(_height);
            InitDecimalOrHexDisplay();
            InitSinglePixelList(_width);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.*|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;
            //txtFile.Text = openFileDialog.FileName;

            txtFile.Text = openFileDialog.FileName;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtFile.Text))
            {
                MessageBox.Show(this, "文件不存在");
                return;
            }
            EnumDataType enumDataType = GetCalibrationDataType(txtFile.Text);
            if (enumDataType == EnumDataType.Unkown)
            {
                MessageBox.Show(this, "校正数据格式错误");
                return;
            }
            _calData = GetCalibrationData(_width, _height, enumDataType, txtFile.Text);
            if (_calData == null)
            {
                MessageBox.Show(this, "校正数据格式错误");
                return;
            }
            cbRowList_SelectedIndexChanged(sender, e);
        }



        private void cbRowList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_calData == null)
            {
                MessageBox.Show(this, "请先读取数据");
                return;
            }

            int row = int.Parse(cbRowList.SelectedValue.ToString());
            int hexOrDecimal = int.Parse(cbHexOrDecimal.SelectedValue.ToString());
            ShowData(_calData, row, hexOrDecimal, rtShow);

        }

        private void cbHexOrDecimal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_calData == null)
            {
                MessageBox.Show(this, "请先读取数据");
                return;
            }
            cbRowList_SelectedIndexChanged(sender, e);
        }

        private void cbSinglePixel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_calData == null)
            {
                MessageBox.Show(this, "请先读取数据");
                return;
            }
            cbRowList_SelectedIndexChanged(sender, e);
        }

        private void cbDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDataType.SelectedIndex == 0)
            {
                //箱体
                _width = CabinetSize.GetSize().Width;
                _height = CabinetSize.GetSize().Height;
            }
            else
            {
                //模组
                _width = CabinetSize.ModulePixelWidth;
                _height = CabinetSize.ModulePixelHeight;
            }
            InitRowList(_height);
            InitDecimalOrHexDisplay();
            InitSinglePixelList(_width);
        }

        private void btnSelectFileCompare1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.*|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;
            txtFileCompare1.Text = openFileDialog.FileName;
        }

        private void btnSelectFileCompare2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.*|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;
            txtFileCompare2.Text = openFileDialog.FileName;
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            byte[] file1Content;
            byte[] file2Content;

            if (!File.Exists(txtFileCompare1.Text))
            {
                MessageBox.Show(this, "文件1不存在");
                return;
            }
            if (!File.Exists(txtFileCompare2.Text))
            {
                MessageBox.Show(this, "文件2不存在");
                return;
            }

            EnumDataType enumDataType = GetCalibrationDataType(txtFileCompare1.Text);
            if (enumDataType == EnumDataType.Unkown)
            {
                MessageBox.Show(this, "文件1格式错误");
                return;
            }

            enumDataType = GetCalibrationDataType(txtFileCompare2.Text);
            if (enumDataType == EnumDataType.Unkown)
            {
                MessageBox.Show(this, "文件2格式错误");
                return;
            }

            file1Content = GetCalibrationData(_width, _height, enumDataType, txtFileCompare1.Text);
            file2Content = GetCalibrationData(_width, _height, enumDataType, txtFileCompare2.Text);

            CompareData(file1Content, file2Content);

        }

        private void rtCompare1Content_VScroll(object sender, EventArgs e)
        {
            int crntLastLine = GetLineNoVscroll(rtCompare1Content);
            TrunRowsId(crntLastLine, rtCompare2Content);
        }

        private void tabCompare_SizeChanged(object sender, EventArgs e)
        {
            int width = tabCompare.Width;
            rtCompare1Content.Width = width / 2 - 5;
            rtCompare2Content.Left = width / 2 + 5;
            rtCompare2Content.Width = width / 2 - 10;
            label15.Left = width / 2 + 5;
        }

        private void rtCompare1Content_SelectionChanged(object sender, EventArgs e)
        {
            rtCompare2Content.SelectionColor = Color.Black;
            rtCompare2Content.Select(0, rtCompare1Content.TextLength);
            int SelectionStart = rtCompare1Content.SelectionStart;
            int SelectionLen = rtCompare1Content.SelectionLength;
            rtCompare2Content.Select(SelectionStart, SelectionLen);
            rtCompare2Content.SelectionColor = Color.Blue;
        }

        private void btnCreateCal_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.zdat|*.zdat";
            if (saveFileDialog.ShowDialog(this) == DialogResult.Cancel) return;
            byte[] srcData = new byte[_width * _height * 18];
            if (ckRandom.Checked)
            {
                Random rnd = new Random();
                rnd.NextBytes(srcData);
            }
            else
            {
                for (int i = 0; i < srcData.Length; i++)
                {
                    srcData[i] = (byte)numCalInitData.Value;
                }
            }

            byte specData = (byte)numSpecData.Value;
            string[] specRow = txtSpeRow.Text.Split(';');
            if (specRow.Length != 0)
            {
                for (int i = 0; i < specRow.Length; i++)
                {
                    int row = 0;
                    if (int.TryParse(specRow[i], out row))
                    {
                        int rowStartPos = row * _width * 18;
                        for (int j = 0; j < _width; j++)
                        {
                            for (int k = 0; k < 9; k++)
                            {
                                int colPos = rowStartPos + j * 18 + 2 * k;
                                srcData[colPos] = HiByte(specData);
                                colPos = rowStartPos + j * 18 + 2 * k + 1;
                                srcData[colPos] = LoByte(specData);
                            }
                        }
                    }
                }
            }

            specData = (byte)numSpecCol.Value;
            string[] specCol = txtSpecCol.Text.Split(';');
            if (specCol.Length != 0)
            {
                for (int i = 0; i < specCol.Length; i++)
                {
                    int col = 0;
                    if (int.TryParse(specCol[i], out col))
                    {
                        for (int j = 0; j < _height; j++)
                        {
                            int rowStartPos = j * _width * 18;
                            for (int k = 0; k < 9; k++)
                            {
                                int colPos = rowStartPos + col * 18 + 2 * k;
                                srcData[colPos] = HiByte(specData);
                                colPos = rowStartPos + col * 18 + 2 * k + 1;
                                srcData[colPos] = LoByte(specData);
                            }
                        }
                    }
                }
            }

            byte[] newData = new byte[_width * _height * 16];

            int pos = 0;
            byte[] oldPixelData = new byte[18];
            byte[] newPixelData = new byte[16];

            int nLeftMove = 5;//2017-11-16
            nLeftMove = nLeftMove + 1;

            ushort uMask = (ushort)(0xFF << nLeftMove);//构造掩码

            for (int pt = 0; pt < _width * _height; pt++)
            {
                pos = 0;

                //获取一个像素的数据
                Array.Copy(srcData, pt * 18, oldPixelData, 0, 18);

                //清空一个像素的新数据
                for (int k = 0; k < 16; k++)
                    newPixelData[k] = 0;

                //进行转换
                for (int i = 0; i < 9; i++)
                {
                    ushort old = (ushort)((oldPixelData[2 * i] << 8) | oldPixelData[2 * i + 1]);

                    //2017-11-16 modify
                    //byte newVal = (byte)((old & 0x1FE0) >> 5);//16->8 bit  
                    byte newVal = (byte)((old & uMask) >> nLeftMove);//16->8 bit

                    if (i == 0)
                    {
                        //红色主色
                        newPixelData[pos] = oldPixelData[2 * i];
                        newPixelData[pos + 1] = oldPixelData[2 * i + 1];
                        pos += 2;
                    }
                    else if (i == 4)
                    {
                        //绿色主色
                        newPixelData[pos] = oldPixelData[2 * i];
                        newPixelData[pos + 1] = oldPixelData[2 * i + 1];
                        pos += 2;
                    }
                    else if (i == 8)
                    {
                        //蓝色主色
                        newPixelData[pos] = oldPixelData[2 * i];
                        newPixelData[pos + 1] = oldPixelData[2 * i + 1];
                        pos += 2;
                    }
                    else
                    {
                        //普通点
                        newPixelData[pos] = newVal;
                        pos++;
                    }
                }
                Array.Copy(newPixelData, 0, newData, pt * 16, 16);
            }

            string dirName = System.IO.Path.GetDirectoryName(saveFileDialog.FileName);
            string fileNameWithoutExt = "All";
            string zdat = System.IO.Path.Combine(dirName, fileNameWithoutExt + ".zdat");
            string sdat = System.IO.Path.Combine(dirName, fileNameWithoutExt + ".sdat");
            string dat = System.IO.Path.Combine(dirName, fileNameWithoutExt + ".dat");

            FileStream writer = null;
            try
            {
                //ZDAT
                writer = new FileStream(zdat, FileMode.Create, FileAccess.Write);
                writer.Write(newData, 0, newData.Length);
            }
            catch
            {
            }
            finally
            {
                newData = null;
            }
            writer.Flush();
            writer.Close();

            string divideFolder = System.IO.Path.Combine(dirName, "Divide");
            if (!Directory.Exists(divideFolder))
            {
                Directory.CreateDirectory(divideFolder);
            }

            CalibrationProcessLib.CalibrationProcess calibrationProcess = new CalibrationProcessLib.CalibrationProcess();
            calibrationProcess.TranslateZdatToSdat(zdat, CabinetSize.GetPixelWidth(), CabinetSize.GetPixelHeight(), sdat, 1);
            calibrationProcess.TranslatezData2dat(zdat, CabinetSize.GetPixelWidth(), CabinetSize.GetPixelHeight(), dat, 1);

            //TVComm.TV71.TW30Oper _caliDivideOper = TVComm.TV71.TW30Oper.LoadLibrary(System.IO.Path.Combine(exePath, @"Libs\LeyardTW30forCalibration.dll")); ;//仅用于校正数据拆分
            //_caliDivideOper.SysCorrectionFileDivide(CabinetSize.ModuleHeight, CabinetSize.ModuleWidth, CabinetSize.GetPixelWidth(), CabinetSize.GetPixelHeight(), sdat, divideFolder);
            calibrationProcess.DivideCalibrationFile(sdat, CabinetSize.ModuleWidth, CabinetSize.ModuleHeight, CabinetSize.ModulePixelWidth, CabinetSize.ModulePixelHeight, divideFolder, CalibrationProcessLib.EnumCalibrationType.Dat);

            for (int i = 0; i < CabinetSize.ModuleHeight; i++)
            {
                for (int j = 0; j < CabinetSize.ModuleWidth; j++)
                {
                    string datFile = System.IO.Path.Combine(divideFolder, i + "_" + j + ".dat");
                    string zdatFile = System.IO.Path.Combine(divideFolder, i + "_" + j + ".zdat");
                    calibrationProcess.TranslateDat2zdat(datFile, CabinetSize.ModulePixelWidth, CabinetSize.ModulePixelHeight, zdatFile, 1);
                }
            }
        }

        private void btnTranslateSdatToDat_Click(object sender, EventArgs e)
        {
            CalibrationProcessLib.CalibrationProcess calibrationProcess = new CalibrationProcessLib.CalibrationProcess();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "*.sdat|*.sdat";
            if (openFileDialog.ShowDialog(this) == DialogResult.Cancel) return;
            string[] srcFile = openFileDialog.FileNames;

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.Cancel) return;

            string targetPath = folderBrowserDialog.SelectedPath;
            string error = "文件:";
            bool hasError = false;
            foreach (var item in srcFile)
            {
                string fileName = System.IO.Path.Combine(targetPath, System.IO.Path.GetFileNameWithoutExtension(item) + ".dat");
                if (!calibrationProcess.TranslateSdatToDat(item, CabinetSize.GetPixelWidth(), CabinetSize.GetPixelHeight(), fileName))
                {
                    error += item + ";";
                    hasError = true;
                }
                error += "转换失败";
            }
            if (hasError)
            {
                MessageBox.Show(this, error);
            }

        }

        private void btnTranslateDat2Sdat_Click(object sender, EventArgs e)
        {
            CalibrationProcessLib.CalibrationProcess calibrationProcess = new CalibrationProcessLib.CalibrationProcess();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "*.dat|*.dat";
            if (openFileDialog.ShowDialog(this) == DialogResult.Cancel) return;
            string[] srcFile = openFileDialog.FileNames;

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.Cancel) return;

            string targetPath = folderBrowserDialog.SelectedPath;
            string error = "文件:";
            bool hasError = false;
            foreach (var item in srcFile)
            {
                string fileName = System.IO.Path.Combine(targetPath, System.IO.Path.GetFileNameWithoutExtension(item) + ".sdat");
                if (!calibrationProcess.TranslateData2Sdat(item, CabinetSize.GetPixelWidth(), CabinetSize.GetPixelHeight(), fileName))
                {
                    error += item + ";";
                    hasError = true;
                }
                error += "转换失败";
            }
            if (hasError)
            {
                MessageBox.Show(this, error);
            }
        }

        private void btnDat2Zdat_Click(object sender, EventArgs e)
        {
            CalibrationProcessLib.CalibrationProcess calibrationProcess = new CalibrationProcessLib.CalibrationProcess();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "*.dat|*.dat";
            if (openFileDialog.ShowDialog(this) == DialogResult.Cancel) return;
            string[] srcFile = openFileDialog.FileNames;

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.Cancel) return;

            string targetPath = folderBrowserDialog.SelectedPath;
            string error = "文件:";
            bool hasError = false;
            foreach (var item in srcFile)
            {
                string fileName = System.IO.Path.Combine(targetPath, System.IO.Path.GetFileNameWithoutExtension(item) + ".zdat");
                if (!calibrationProcess.TranslateDat2zdat(item, CabinetSize.GetPixelWidth(), CabinetSize.GetPixelHeight(), fileName, 1))
                {
                    error += item + ";";
                    hasError = true;
                }
                error += "转换失败";
            }
            if (hasError)
            {
                MessageBox.Show(this, error);
            }
        }

        private void btnSdat2Zdat_Click(object sender, EventArgs e)
        {
            CalibrationProcessLib.CalibrationProcess calibrationProcess = new CalibrationProcessLib.CalibrationProcess();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "*.sdat|*.sdat";
            if (openFileDialog.ShowDialog(this) == DialogResult.Cancel) return;
            string[] srcFile = openFileDialog.FileNames;

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.Cancel) return;

            string targetPath = folderBrowserDialog.SelectedPath;
            string error = "文件:";
            bool hasError = false;
            foreach (var item in srcFile)
            {
                string fileName = System.IO.Path.Combine(targetPath, System.IO.Path.GetFileNameWithoutExtension(item) + ".zdat");
                if (!calibrationProcess.TranslateSdatToZDat(item, CabinetSize.GetPixelWidth(), CabinetSize.GetPixelHeight(), fileName, 1))
                {
                    error += item + ";";
                    hasError = true;
                }
                error += "转换失败";
            }
            if (hasError)
            {
                MessageBox.Show(this, error);
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            CalibrationProcessLib.CalibrationProcess calibrationProcess = new CalibrationProcessLib.CalibrationProcess();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "*.sdat|*.sdat|*.dat|*.dat";
            if (openFileDialog.ShowDialog(this) == DialogResult.Cancel) return;
            string[] srcFile = openFileDialog.FileNames;

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.Cancel) return;

            string targetPath = folderBrowserDialog.SelectedPath;
            string error = "文件:";
            bool hasError = false;
            foreach (var item in srcFile)
            {
                //if (!calibrationProcess.DivideCalibrationFile(item, CabinetSize.ModuleWidth, CabinetSize.ModuleHeight, CabinetSize.ModulePixelWidth, CabinetSize.ModulePixelHeight, targetPath, CalibrationProcessLib.EnumCalibrationType.Sdat))
                if (!(_oper.sys_CorrectionFile_divide(CabinetSize.ModuleHeight, CabinetSize.ModuleWidth, CabinetSize.GetPixelWidth(), CabinetSize.GetPixelHeight(), item, targetPath) == 0 ? true : false))
                {
                    error += "转换失败";
                    hasError = true;
                }
                for (int i = 0; i < CabinetSize.ModuleHeight; i++)
                {
                    for (int j = 0; j < CabinetSize.ModuleWidth; j++)
                    {
                        string datFile = System.IO.Path.Combine(targetPath, i + "_" + j + ".dat");
                        string zdatFile = System.IO.Path.Combine(targetPath, i + "_" + j + ".zdat");
                        calibrationProcess.TranslateDat2zdat(datFile, CabinetSize.ModulePixelWidth, CabinetSize.ModulePixelHeight, zdatFile, 1);
                    }
                }

            }
            if (hasError)
            {
                MessageBox.Show(this, error);
            }
        }

        private void btnMerger_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.Cancel) return;

            string targetPath = folderBrowserDialog.SelectedPath;


            string[,] datFiles = new string[CabinetSize.ModuleHeight, CabinetSize.ModuleWidth];
            for (int i = 0; i < datFiles.GetLength(0); i++)
            {
                for (int j = 0; j < datFiles.GetLength(1); j++)
                {
                    datFiles[i, j] = System.IO.Path.Combine(targetPath, i + "_" + j + ".dat");
                }
            }
            string outFile = "d:\\tmp.dat";
            CalibrationProcessLib.CalibrationProcess calibrationProcess = new CalibrationProcessLib.CalibrationProcess();
            if (!calibrationProcess.MergeFile(CabinetSize.ModuleWidth, CabinetSize.ModuleHeight, CabinetSize.ModulePixelWidth, CabinetSize.ModulePixelHeight, datFiles, outFile))
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalibrationProcessLib.CalibrationProcess calibrationProcess = new CalibrationProcessLib.CalibrationProcess();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "*.zdat|*.zdat";
            if (openFileDialog.ShowDialog(this) == DialogResult.Cancel) return;
            string[] srcFile = openFileDialog.FileNames;

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.Cancel) return;

            string targetPath = folderBrowserDialog.SelectedPath;
            string error = "文件:";
            bool hasError = false;
            foreach (var item in srcFile)
            {
                string fileName = System.IO.Path.Combine(targetPath, System.IO.Path.GetFileNameWithoutExtension(item) + ".dat");

                if (!calibrationProcess.TranslateZdatToDat(item, CabinetSize.GetPixelWidth(), CabinetSize.GetPixelHeight(), fileName, 1))
                {
                    error += item + ";";
                    hasError = true;
                }
                error += "转换失败";
            }
            if (hasError)
            {
                MessageBox.Show(this, error);
            }
        }

        private void btnzdat2sdat_Click(object sender, EventArgs e)
        {
            CalibrationProcessLib.CalibrationProcess calibrationProcess = new CalibrationProcessLib.CalibrationProcess();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "*.zdat|*.zdat";
            if (openFileDialog.ShowDialog(this) == DialogResult.Cancel) return;
            string[] srcFile = openFileDialog.FileNames;

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.Cancel) return;

            string targetPath = folderBrowserDialog.SelectedPath;
            string error = "文件:";
            bool hasError = false;
            foreach (var item in srcFile)
            {
                string fileName = System.IO.Path.Combine(targetPath, System.IO.Path.GetFileNameWithoutExtension(item) + ".sdat");
                if (!calibrationProcess.TranslateZdatToSdat(item, CabinetSize.GetPixelWidth(), CabinetSize.GetPixelHeight(), fileName, 1))
                {
                    error += item + ";";
                    hasError = true;
                }
                error += "转换失败";
            }
            if (hasError)
            {
                MessageBox.Show(this, error);
            }
        }
    }
}
