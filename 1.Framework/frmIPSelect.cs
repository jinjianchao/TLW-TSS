using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PluginLib;

namespace LYDTOPDP
{
    public partial class frmIPSelect : BaseFormV2
    {
        public string SelectedIP { get; set; }
        public string StartIP { get; set; }
        public string EndIP { get; set; }

        public frmIPSelect()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmIPSelect_Load(object sender, EventArgs e)
        {
            listIP.Items.Clear();
            int start = int.Parse(StartIP.Substring(StartIP.LastIndexOf('.') + 1));
            int end = int.Parse(EndIP.Substring(EndIP.LastIndexOf('.') + 1));
            int max = Math.Max(start, end);
            int min = Math.Min(start, end);
            for (int i = min; i <= max; i++)
            {
                string ip = StartIP.Substring(0, StartIP.LastIndexOf('.')) + "." + i;
                listIP.Items.Add(ip);
            }
            listIP.SelectedIndex = 0;
            TranslateControlText();
        }

        private void listIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIP = listIP.SelectedItem.ToString();
        }
    }
}
