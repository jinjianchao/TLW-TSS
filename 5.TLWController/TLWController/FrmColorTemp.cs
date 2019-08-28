using PluginLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TLWController.Helper;
using TLWController.Structs;
using TLWCommunication;
using SFTHelper.Extentions;

namespace TLWController
{
    public partial class FrmColorTemp : BaseFormV2
    {
        private class ListItem
        {
            public int Value { get; set; }
            public string Text { get; set; }
        }

        public TLWCommand _TLWCommand = null;
        public Dictionary<string, int> DevIP = new Dictionary<string, int>();
        public ushort MBAddr;
        public ushort Id;
        public colorTempData colorTempData = new colorTempData();


        public FrmColorTemp()
        {
            InitializeComponent();
        }

        private void BindChipType()
        {
            List<ListItem> items = new List<ListItem>()
            {
                new ListItem(){ Value=0, Text="2055" },
                new ListItem(){ Value=1, Text="2072" }
            };
            cbChipType.ValueMember = "Value";
            cbChipType.DisplayMember = "Text";
            cbChipType.DataSource = items;
        }

        private void BindHz()
        {
            //List<ListItem> items = new List<ListItem>()
            //{
            //    new ListItem(){ Value=0, Text="60Hz" },
            //    new ListItem(){ Value=1, Text="50Hz" },
            //    new ListItem(){ Value=2, Text="3D" }
            //};
            //cbHz.ValueMember = "Value";
            //cbHz.DisplayMember = "Text";
            //cbHz.DataSource = items;

            System.Threading.Thread.Sleep(200);
            List<ListItem> items1 = new List<ListItem>()
            {
                new ListItem(){ Value=0, Text="60Hz" },
                new ListItem(){ Value=1, Text="50Hz" },
                new ListItem(){ Value=2, Text="3D" }
            };
            cbHz1.ValueMember = "Value";
            cbHz1.DisplayMember = "Text";
            cbHz1.DataSource = items1;

            cbHz1.SelectedValueChanged += cbHz1_SelectedIndexChanged;
        }

        private void BindColorTempType()
        {
            //List<ListItem> items = new List<ListItem>()
            //{
            //    new ListItem(){ Value=0, Text="3200K" },
            //    new ListItem(){ Value=1, Text="6500K" },
            //    new ListItem(){ Value=2, Text="8500K" },
            //    new ListItem(){ Value=3, Text="9300K" },
            //    new ListItem(){ Value=4, Text="自定义1" },
            //    new ListItem(){ Value=5, Text="自定义2" },
            //    new ListItem(){ Value=6, Text="自定义3" },
            //    new ListItem(){ Value=7, Text="自定义4" },
            //    new ListItem(){ Value=8, Text="自定义5" },
            //    new ListItem(){ Value=9, Text="自定义6" }
            //};
            //cbColorTempType.ValueMember = "Value";
            //cbColorTempType.DisplayMember = "Text";
            //cbColorTempType.DataSource = items;

            List<ListItem> items1 = new List<ListItem>()
            {
                new ListItem(){ Value=0, Text="3200K" },
                new ListItem(){ Value=1, Text="6500K" },
                new ListItem(){ Value=2, Text="8500K" },
                new ListItem(){ Value=3, Text="9300K" },
                new ListItem(){ Value=4, Text="自定义1" },
                new ListItem(){ Value=5, Text="自定义2" },
                new ListItem(){ Value=6, Text="自定义3" },
                new ListItem(){ Value=7, Text="自定义4" },
                new ListItem(){ Value=8, Text="自定义5" },
                new ListItem(){ Value=9, Text="自定义6" }
            };
            cbColorTempType1.ValueMember = "Value";
            cbColorTempType1.DisplayMember = "Text";
            cbColorTempType1.DataSource = items1;
            cbColorTempType1.SelectedValueChanged += cbColorTempType1_SelectedIndexChanged;
        }


        private bool ReadColorTemp()
        {
            foreach (var item in DevIP)
            {
                int result = 0;
                result = _TLWCommand.tlw_ReadColorTempData(item.Value, MBAddr, Id, out byte[] data);
                if (result != 0)
                {
                    MessageBox.Show(this, "读取寄存器参数失败");
                    return false;
                }
                else
                {
                    colorTempData = ColorTempHelper.GetColorTempData(data);
                }
                break;
            }
            return true;
        }

        private void SetColorTemp()
        {
            byte[] data = ColorTempHelper.GetData(colorTempData); ;
            foreach (var item in DevIP)
            {
                int result = 0;

                result = _TLWCommand.tlw_WriteColorTempData(item.Value, 0, Id, data);
                if (result != 0)
                {
                    MessageBox.Show(this, $"IP:{item.Key} 写入寄存器参数失败");
                }
                else
                {
                    MessageBox.Show(this, $"IP:{item.Key} 写入寄存器参数成功");
                }
            }
        }

        private void InitColorTempValue()
        {
            numRed.ValueChanged -= numRed_ValueChanged;
            numGreen.ValueChanged -= numGreen_ValueChanged;
            numBlue.ValueChanged -= numBlue_ValueChanged;

            int hz = cbHz1.SelectedValue.ToString().GetInt32(System.Globalization.NumberStyles.Number);
            colorTempGroup group = this.colorTempData.arrGroup[hz];
            int colorTmp = cbColorTempType1.SelectedValue.ToString().GetInt32(System.Globalization.NumberStyles.Number);
            colorTemp colorTempData = group.arrData[colorTmp];

            byte[] tmp = new byte[2];
            //Red
            tmp[0] = colorTempData.Red_Hi;
            tmp[1] = colorTempData.Red_Lo;
            ushort val = tmp.GetUInt16(0);
            numRed.Value = val;

            //Green
            tmp[0] = colorTempData.Green_Hi;
            tmp[1] = colorTempData.Green_Lo;
            val = tmp.GetUInt16(0);
            numGreen.Value = val;

            //Blue
            tmp[0] = colorTempData.Blue_Hi;
            tmp[1] = colorTempData.Blue_Lo;
            val = tmp.GetUInt16(0);
            numBlue.Value = val;

            numRed.ValueChanged += numRed_ValueChanged;
            numGreen.ValueChanged += numGreen_ValueChanged;
            numBlue.ValueChanged += numBlue_ValueChanged;
        }

        private void SetColorTempValue()
        {

            int hz = cbHz1.SelectedValue.ToString().GetInt32(System.Globalization.NumberStyles.Number);
            colorTempGroup group = this.colorTempData.arrGroup[hz];
            int colorTmp = cbColorTempType1.SelectedValue.ToString().GetInt32(System.Globalization.NumberStyles.Number);
            colorTemp colorTempData = group.arrData[colorTmp];

            UInt16 redVal = (UInt16)numRed.Value;
            UInt16 greenVal = (UInt16)numGreen.Value;
            UInt16 blueVal = (UInt16)numBlue.Value;

            byte[] redBtValue = redVal.GetBytes();
            byte[] greenBtValue = greenVal.GetBytes();
            byte[] blueBtValue = blueVal.GetBytes();

            //Red
            colorTempData.Red_Hi = redBtValue[0];
            colorTempData.Red_Lo = redBtValue[1];

            //Green
            colorTempData.Green_Hi = greenBtValue[0];
            colorTempData.Green_Lo = greenBtValue[1];

            //Blue
            colorTempData.Blue_Hi = blueBtValue[0];
            colorTempData.Blue_Lo = blueBtValue[1];


        }

        private void FrmColorTemp_Load(object sender, EventArgs e)
        {
            BindChipType();
            BindColorTempType();
            BindHz();
            if (ReadColorTemp() == false)
            {
                this.Close();
                return;
            }
            InitColorTempValue();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            SetColorTemp();
        }

        private void cbColorTempType_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitColorTempValue();
        }

        private void cbHz_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitColorTempValue();
        }

        private void numRed_ValueChanged(object sender, EventArgs e)
        {
            numGreen.ValueChanged -= numGreen_ValueChanged;
            numBlue.ValueChanged -= numBlue_ValueChanged;
            SetColorTempValue();
            numGreen.ValueChanged += numGreen_ValueChanged;
            numBlue.ValueChanged += numBlue_ValueChanged;
        }

        private void numGreen_ValueChanged(object sender, EventArgs e)
        {
            numRed.ValueChanged -= numRed_ValueChanged;
            numBlue.ValueChanged -= numBlue_ValueChanged;
            SetColorTempValue();
            numBlue.ValueChanged += numBlue_ValueChanged;
            numRed.ValueChanged += numRed_ValueChanged;
        }

        private void numBlue_ValueChanged(object sender, EventArgs e)
        {
            numRed.ValueChanged -= numRed_ValueChanged;
            numGreen.ValueChanged -= numGreen_ValueChanged;
            SetColorTempValue();
            numRed.ValueChanged += numRed_ValueChanged;
            numGreen.ValueChanged += numGreen_ValueChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbHz_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            InitColorTempValue();
        }

        private void cbHz1_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitColorTempValue();
        }

        private void cbColorTempType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitColorTempValue();
        }
    }
}
