using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TLWController.UserCtr
{
    public partial class UserModuleSN : UserControl
    {
        public UserModuleSN()
        {
            InitializeComponent();
        }

        public void SetLabelText(string text)
        {
            lblName.Text = text;
        }

        public void SetText(string text)
        {
            txtName.Text = text;
        }

        public string GetText()
        {
            return txtName.Text;
        }
    }
}
