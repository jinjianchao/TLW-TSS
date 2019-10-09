using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SFTHelper.Extentions;
using TLWController.UserCtr;

namespace TLWController
{
    public partial class FrmCreateSN : Form
    {
        private string ctr_Prefix = "userCtrSN_";
        /// <summary>
        /// 0:所有灯板 1:灯板1  2:灯板2  3:灯板3.....
        /// </summary>
        /// 
        public int Position = 0;

        public int MoudleCount;

        public FrmCreateSN()
        {
            InitializeComponent();
        }

        public string GetSN(int position)
        {
            return (panelSN.Controls[$"{ctr_Prefix}{position}"] as UserModuleSN).GetText();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in panelSN.Controls)
            {
                if (ctr.Enabled == true)
                {
                    UserModuleSN moduleSN = ctr as UserModuleSN;
                    if (moduleSN.GetText().Trim() == "")
                    {
                        MessageBox.Show(this, $"灯板{moduleSN.Tag.ToString()}时间码不能为空");
                        return;
                    }
                    if (moduleSN.GetText().Trim().IsNumber() == false || moduleSN.GetText().Trim().Length != 17)
                    {
                        MessageBox.Show(this, $"灯板{moduleSN.Tag.ToString()}时间码格式错误");
                        return;
                    }
                }
            }

            this.DialogResult = DialogResult.OK;
            //this.Close();
            return;
        }

        private void FrmCreateSN_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < MoudleCount; i++)
            {
                UserModuleSN moduleSN = new UserModuleSN();
                moduleSN.SetLabelText($"灯板{i + 1}:");
                moduleSN.Tag = i;
                moduleSN.Name = ctr_Prefix + i;
                panelSN.Controls.Add(moduleSN);
            }
        }

        private void FrmCreateSN_Shown(object sender, EventArgs e)
        {
            if (Position != -1)
            {
                foreach (Control ctr in panelSN.Controls)
                {
                    ctr.Enabled = false;
                }
                panelSN.Controls[$"{ctr_Prefix}{Position}"].Enabled = true;
            }
        }
    }
}
