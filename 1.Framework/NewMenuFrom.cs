using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LYDTOPDP
{
    public partial class NewMenuFrom : Form
    {
        public String CNName { get; set; }
        public String EnName { get; set; }

        public NewMenuFrom()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCnName.Text))
            {
                MessageBox.Show("Chinese name can not be empty");
                return;
            }
            if (string.IsNullOrEmpty(txtEnName.Text))
            {
                MessageBox.Show("English name can not be empty");
                return;
            }

            CNName = txtCnName.Text;
            EnName = txtEnName.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
