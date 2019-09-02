using SFTHelper.Helper;
using SFTHelper.Structs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CalibrationTools
{
    public partial class FrmMain : Form
    {
        private int _moduleWidth = 4;
        private int _moduleHeight = 3;
        private int _modulePixelWith = 192;
        private int _modulePixelHeight = 108;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnConvertDatToSdat_Click(object sender, EventArgs e)
        {
            string fileIn = @"C:\Users\Jinjianchao\Desktop\0808\0_0.dat";
            string fileOut = @"C:\Users\Jinjianchao\Desktop\0808\dtos.sdat";
            CalibrationHelper calibrationHelper = new CalibrationHelper(_moduleWidth, _moduleHeight, _modulePixelWith, _modulePixelHeight);
            bool isOk = calibrationHelper.ToSDat(fileIn, fileOut, SFTHelper.Enums.EnumCALTarget.Module);
            if (isOk == false)
            {
                MessageBox.Show("error");
            }
        }

        private void btnConverZDatToSDat_Click(object sender, EventArgs e)
        {
            string fileIn = @"C:\Users\Jinjianchao\Desktop\0808\0_0.zdat";
            string fileOut = @"C:\Users\Jinjianchao\Desktop\0808\ztos.sdat";
            CalibrationHelper calibrationHelper = new CalibrationHelper(_moduleWidth, _moduleHeight, _modulePixelWith, _modulePixelHeight);
            bool isOk = calibrationHelper.ToSDat(fileIn, fileOut, SFTHelper.Enums.EnumCALTarget.Module);
            if (isOk == false)
            {
                MessageBox.Show("error");
            }
        }

        private void btnDatToZDat_Click(object sender, EventArgs e)
        {
            string fileIn = @"C:\Users\Jinjianchao\Desktop\0808\0_0.dat";
            string fileOut = @"C:\Users\Jinjianchao\Desktop\0808\dtoz.zdat";
            CalibrationHelper calibrationHelper = new CalibrationHelper(_moduleWidth, _moduleHeight, _modulePixelWith, _modulePixelHeight);
            bool isOk = calibrationHelper.ToZDat(fileIn, fileOut, SFTHelper.Enums.EnumCALTarget.Module);
            if (isOk == false)
            {
                MessageBox.Show("error");
            }
        }

        private void btnSDatToZDat_Click(object sender, EventArgs e)
        {
            string fileIn = @"C:\Users\Jinjianchao\Desktop\0808\0_0.dat";
            string fileOut = @"C:\Users\Jinjianchao\Desktop\0808\stoz.zdat";
            CalibrationHelper calibrationHelper = new CalibrationHelper(_moduleWidth, _moduleHeight, _modulePixelWith, _modulePixelHeight);
            bool isOk = calibrationHelper.ToZDat(fileIn, fileOut, SFTHelper.Enums.EnumCALTarget.Module);
            if (isOk == false)
            {
                MessageBox.Show("error");
            }
        }

        private void btnSDatToDat_Click(object sender, EventArgs e)
        {
            string fileIn = @"C:\Users\Jinjianchao\Desktop\0808\0_0.sdat";
            string fileOut = @"C:\Users\Jinjianchao\Desktop\0808\stod.dat";
            CalibrationHelper calibrationHelper = new CalibrationHelper(_moduleWidth, _moduleHeight, _modulePixelWith, _modulePixelHeight);
            bool isOk = calibrationHelper.ToDat(fileIn, fileOut, SFTHelper.Enums.EnumCALTarget.Module);
            if (isOk == false)
            {
                MessageBox.Show("error");
            }
        }

        private void btnZdatToDat_Click(object sender, EventArgs e)
        {
            string fileIn = @"C:\Users\Jinjianchao\Desktop\0808\0_0.zdat";
            string fileOut = @"C:\Users\Jinjianchao\Desktop\0808\ztod.dat";
            CalibrationHelper calibrationHelper = new CalibrationHelper(_moduleWidth, _moduleHeight, _modulePixelWith, _modulePixelHeight);
            bool isOk = calibrationHelper.ToDat(fileIn, fileOut, SFTHelper.Enums.EnumCALTarget.Module);
            if (isOk == false)
            {
                MessageBox.Show("error");
            }
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            CalibrationHelper calibrationHelper = new CalibrationHelper(_moduleWidth, _moduleHeight, _modulePixelWith, _modulePixelHeight);
            string[,] files = new string[_moduleHeight, _moduleWidth];
            files[0, 0] = @"C:\Users\Jinjianchao\Desktop\0808\0_0.dat";
            files[0, 1] = @"C:\Users\Jinjianchao\Desktop\0808\0_1.dat";
            files[0, 2] = @"C:\Users\Jinjianchao\Desktop\0808\0_2.dat";
            files[0, 3] = @"C:\Users\Jinjianchao\Desktop\0808\0_3.dat";

            files[1, 0] = @"C:\Users\Jinjianchao\Desktop\0808\1_0.dat";
            files[1, 1] = @"C:\Users\Jinjianchao\Desktop\0808\1_1.dat";
            files[1, 2] = @"C:\Users\Jinjianchao\Desktop\0808\1_2.dat";
            files[1, 3] = @"C:\Users\Jinjianchao\Desktop\0808\1_3.dat";

            files[2, 0] = @"C:\Users\Jinjianchao\Desktop\0808\2_0.dat";
            files[2, 1] = @"C:\Users\Jinjianchao\Desktop\0808\2_1.dat";
            files[2, 2] = @"C:\Users\Jinjianchao\Desktop\0808\2_2.dat";
            files[2, 3] = @"C:\Users\Jinjianchao\Desktop\0808\2_3.dat";

            bool isOk = calibrationHelper.Merge(files, @"C:\Users\Jinjianchao\Desktop\0808\merge.sdat");
            if (isOk == false)
            {
                MessageBox.Show("error");
            }
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            CalibrationHelper calibrationHelper = new CalibrationHelper(_moduleWidth, _moduleHeight, _modulePixelWith, _modulePixelHeight);

            string sz = @"C:\Users\Jinjianchao\Desktop\0808\merge.sdat";
            string target = @"C:\Users\Jinjianchao\Desktop\0808\split";
            bool isOk = calibrationHelper.Divide(sz, target);
            if (isOk == false)
            {
                MessageBox.Show("error");
            }
        }

        private void btnSeamCorrection_Click(object sender, EventArgs e)
        {
            //SeamCalibrationHelper seamCalibrationHelper = new SeamCalibrationHelper(255, _moduleWidth, _moduleHeight, _modulePixelWith, _modulePixelHeight);
            //StructSeamItem[,] seamItems = new StructSeamItem[_moduleHeight, _moduleWidth];
            //for (int row = 0; row < _moduleHeight; row++)
            //{
            //    for (int col = 0; col < _moduleWidth; col++)
            //    {
            //        seamItems[row, col] = new StructSeamItem()
            //        {
            //            Left = 0,
            //            Top = 0,
            //            Right = 0,
            //            Bottom = 0,
            //            Center = 100
            //        };
            //    }
            //}

            //string sz = @"C:\Users\Jinjianchao\Desktop\0808\0_0.sdat";
            //string target = @"C:\Users\Jinjianchao\Desktop\0808\modify.sdat";
            //bool isOk = seamCalibrationHelper.Modify(sz, target, seamItems, SFTHelper.Enums.EnumCALTarget.Module);
            //if (isOk == false)
            //{
            //    MessageBox.Show("error");
            //}

            //CalibrationHelper calibrationHelper = new CalibrationHelper(_moduleWidth, _moduleHeight, _modulePixelWith, _modulePixelHeight);

            //sz = @"C:\Users\Jinjianchao\Desktop\0808\modify.sdat";
            //target = @"C:\Users\Jinjianchao\Desktop\0808\split";
            //isOk = calibrationHelper.Divide(sz, target);
            //if (isOk == false)
            //{
            //    MessageBox.Show("error");
            //}
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            string folder = @"C:\Users\Jinjianchao\Desktop\0808";
            string zdatfolder = @"C:\Users\Jinjianchao\Desktop\0808\zdat";
            string datfolder = @"C:\Users\Jinjianchao\Desktop\0808\dat";

            List<string> fileList = new List<string>();
            FileHelper.GetFiles(folder, "*.dat", false, ref fileList);

            int row = 0;
            int col = 0;
            fileList.ForEach((item) =>
            {
                string datFile = Path.Combine(datfolder, $"{row}_{col}.dat");
                File.Copy(item, datFile);

                CalibrationHelper calibrationHelper = new CalibrationHelper(1, 1, 192, 108);
                string zdatFile = Path.Combine(zdatfolder, $"{row}_{col}.zdat");
                calibrationHelper.ToZDat(item, zdatFile, SFTHelper.Enums.EnumCALTarget.Module);

                col++;
                if ((col + 1) % 11 == 0)
                {
                    col = 0;
                    row++;
                }
            });
        }

        private void btnBatchConvert_Click(object sender, EventArgs e)
        {
            string folder = @"C:\Users\Jinjianchao\Desktop\0808";
            string zdatfolder = @"C:\Users\Jinjianchao\Desktop\0808\zdat";
            string datfolder = @"C:\Users\Jinjianchao\Desktop\0808\dat";
            string sdatfolder = @"C:\Users\Jinjianchao\Desktop\0808\sdat";

            List<string> fileList = new List<string>();
            FileHelper.GetFiles(folder, "*.dat", false, ref fileList);

            fileList.ForEach((item) =>
            {
                CalibrationHelper calibrationHelper = new CalibrationHelper(1, 1, 192, 108);
                string fileName = Path.GetFileNameWithoutExtension(item);
                string zname = $"{fileName}.zdat";
                string sname = $"{fileName}.sdat";
                string dname = $"{fileName}.dat";
                string zfile = Path.Combine(zdatfolder, zname);
                string dfile = Path.Combine(datfolder, dname);
                string sfile = Path.Combine(sdatfolder, sname);

                calibrationHelper.ToZDat(item, zfile, SFTHelper.Enums.EnumCALTarget.Module);
                calibrationHelper.ToSDat(item, sfile, SFTHelper.Enums.EnumCALTarget.Module);
                calibrationHelper.ToDat(item, dfile, SFTHelper.Enums.EnumCALTarget.Module);
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(SFTHelper.Helper.NetworkHelper.Ping("192.168.0.32"))
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("false");
            }
        }
    }
}
