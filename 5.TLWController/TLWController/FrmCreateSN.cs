using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TLWController.Extentions;

namespace TLWController
{
    public partial class FrmCreateSN : Form
    {
        /// <summary>
        /// 0:上下灯板 1:上灯板  1:下灯板
        /// </summary>
        /// 
        public int Position = 0;
        public FrmCreateSN()
        {
            InitializeComponent();
        }

        public string GetSN1()
        {
            return txtSN1.Text.Trim();
        }

        public string GetSN2()
        {
            return txtSN2.Text.Trim();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (Position == 0)
            {
                if (txtSN1.Text.Trim() == "" || txtSN2.Text == "")
                {
                    MessageBox.Show(this, "时间码不能为空");
                    return;
                }
                if (txtSN1.Text.IsNumber() == false || txtSN1.Text.Length != 17)
                {
                    MessageBox.Show(this, "时间码1格式错误");
                    return;
                }
                if (txtSN2.Text.IsNumber() == false || txtSN2.Text.Length != 17)
                {
                    MessageBox.Show(this, "时间码2格式错误");
                    return;
                }
            }
            else if (Position == 1)
            {
                if (txtSN1.Text.Trim() == "")
                {
                    MessageBox.Show(this, "时间码不能为空");
                    return;
                }
                if (txtSN1.Text.IsNumber() == false || txtSN1.Text.Length != 17)
                {
                    MessageBox.Show(this, "时间码1格式错误");
                    return;
                }
            }
            else if (Position == 2)
            {
                if (txtSN2.Text == "")
                {
                    MessageBox.Show(this, "时间码不能为空");
                    return;
                }

                if (txtSN2.Text.IsNumber() == false || txtSN2.Text.Length != 17)
                {
                    MessageBox.Show(this, "时间码2格式错误");
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
            //this.Close();
            return;
        }

        private void FrmCreateSN_Load(object sender, EventArgs e)
        {

        }

        private void FrmCreateSN_Shown(object sender, EventArgs e)
        {
            if (Position == 0)
            {

            }
            else if (Position == 1)
            {
                txtSN2.Enabled = false;
            }
            else if (Position == 2)
            {
                txtSN1.Enabled = false;
            }
        }
    }
}
