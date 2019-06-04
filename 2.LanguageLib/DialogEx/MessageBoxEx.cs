using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LanguageLib.DialogEx
{
    public partial class MessageBoxEx : Form
    {
        private MessageBoxEx()
        {
            InitializeComponent();
        }

        private void MessageBoxEx_Load(object sender, EventArgs e)
        {

        }

        public static void Show(string title,string text)
        {
            MessageBoxEx msg = new MessageBoxEx();
            msg.StartPosition = FormStartPosition.CenterScreen;
            msg.ShowInTaskbar = false;
            msg.Text = title;
            msg.txtMsg.Text = text;
            msg.ShowDialog();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
