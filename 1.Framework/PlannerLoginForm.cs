/*********************************************************************************
        File:                                                                             
        Description:                                                                    
            Planner定制登录窗体
        Author:                                                                          
            
        Finish DateTime:                                                                  
            
        History:                                                                        

 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LYDTOPDP.Service;
using PluginLib;
using System.Threading;
using System.Runtime.InteropServices;
using LanguageLib;
using System.IO;


namespace LYDTOPDP
{
    public partial class PlannerLoginForm : BaseFormV2
    {
        StartForm startForm;
        public int Level { protected get; set; }
        public bool IsUsePluginPassword { get; set; }
        public string Password { get; set; }
        public PlannerLoginForm()
        {
            Level = 1;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsUsePluginPassword)
            {
                if (txtPassword.Text == Password)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.No;
                }
            }
            else
            {
                if (UserService.CheckUser(txtPassword.Text, txtPassword.Text, Level))
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.No;
                }
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void PlannerLoginForm_Load(object sender, EventArgs e)
        {
            TranslateControlText();
            switch (Level)
            {
                case 1:
                    userLevelSelect.SelectedIndex = 0;
                    break;
                case 2:
                    userLevelSelect.SelectedIndex = 1;
                    break;
                case 3:
                    userLevelSelect.SelectedIndex = 2;
                    break;
                default:
                    userLevelSelect.SelectedIndex = 2;
                    break;
            }
            if (IsUsePluginPassword)
            {
                txtPassword.Enabled = true;
            }
        }

        private void PlannerLoginForm_Shown(object sender, EventArgs e)
        {

        }

        private void PlannerLoginForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void userLevelSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsUsePluginPassword)
            {
                txtPassword.Enabled = true;
            }
            else
            {
                if (userLevelSelect.SelectedIndex == 2)
                {
                    txtPassword.Enabled = false;
                }
                else
                {
                    txtPassword.Enabled = true;
                }
            }
        }
    }
}
