using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PluginLib;
using LYDTOPDP.Service;

namespace LYDTOPDP
{
    public partial class EnginerLoginForm : BaseFormV2
    {
        StartForm startForm;
        PermissionsData m_permissionsData = new PermissionsData();
        public EnginerLoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (startForm == null)
            {
                startForm = new StartForm(this, true);
            }
            if (UserService.CheckUser(txtName.Text, txtPassword.Text,1))
            {
                this.Hide();
                startForm.SetLanDic(m_remoteLanDic, m_lanIndex, m_region, m_split);
                startForm.Show();
            }
            else
            {
                MessageBox.Show(TranslateCodeText("用户名或密码错误"));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EnginerLoginForm_Load(object sender, EventArgs e)
        {
            TranslateControlText();
        }
    }
}
