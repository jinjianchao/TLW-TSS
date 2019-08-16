using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BatchSeamCalibration.Structs;

namespace BatchSeamCalibration
{
    public partial class UserIPCommand : UserControl
    {
        public class EventArgsWorkMode : EventArgs
        {
            /// <summary>
            /// 显示模式0 = 视频，0x80=工装白，0x81=工装黑，0x82=工装蓝，0x83=工装绿，0x84=工装红，0x85=灰度渐变，0x86=低灰度渐变，0x87=斜线
            /// </summary>
            public int Mode { get; set; }
        }

        public delegate void SendWorkModeButtonClicHandler(object sender, EventArgsWorkMode argsWorkMode);

        public event EventHandler SendButtonClick;

        public event EventHandler ViewFormButtonClick;

        public event SendWorkModeButtonClicHandler SendWorkModeButtonClick;

        public UserIPCommand()
        {
            InitializeComponent();
        }

        public string IP
        {
            get
            {
                return lblIP.Text;
            }
            set
            {
                lblIP.Text = value;
            }
        }

        public string ButtonText
        {
            get
            {
                return btnApply.Text;
            }
            set
            {
                btnApply.Text = value;
            }
        }

        public string WorkModeText
        {
            get { return btnWorkMode.Text; }
            set { btnWorkMode.Text = value; }
        }

        public string VideoText
        {
            get { return menuVideo.Text; }
            set { menuVideo.Text = value; }
        }

        public string WhiteText
        {
            get { return menuWhite.Text; }
            set { menuWhite.Text = value; }
        }

        public string RedText
        {
            get { return menuRed.Text; }
            set { menuRed.Text = value; }
        }

        public string GreenText
        {
            get { return menuGreen.Text; }
            set { menuGreen.Text = value; }
        }

        public string BlueText
        {
            get { return menuBlue.Text; }
            set { menuBlue.Text = value; }
        }

        public string ViewButtonText
        {
            get
            {
                return btnViewForm.Text;
            }
            set
            {
                btnViewForm.Text = value;
            }
        }

        public bool ButtonApplyEnable
        {
            get { return btnApply.Enabled; }
            set
            {
                btnApply.Enabled = value;
            }
        }

        public bool ButtonViewFormEnable
        {
            get { return btnViewForm.Enabled; }
            set { btnViewForm.Enabled = value; }
        }

        public bool ButtonWorkModeEnable
        {
            get { return btnWorkMode.Enabled; }
            set
            {
                btnWorkMode.Enabled = value;
            }
        }

        public int Progress
        {
            get
            {
                return progress.Value;
            }
            set
            {
                progress.Value = value;
            }
        }

        public string Description { get { return lblContent.Text; } set { lblContent.Text = value; } }

        public bool Checked
        {
            get { return rbCk.Checked; }
            set { rbCk.Checked = value; }
        }

        public object Tag1 { get; set; }

        public object Tag2 { get; set; }

        public object Tag3 { get; set; }

        public object Tag4 { get; set; }

        private void btnApply_Click(object sender, EventArgs e)
        {
            OnClick(e);
            if (SendButtonClick != null)
            {
                SendButtonClick(this, e);
            }

        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            rbCk.Checked = true;
        }

        private void progress_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void lblIP_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void rbCk_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbCk_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void btnWorkMode_Click(object sender, EventArgs e)
        {
            OnClick(e);

            ctxWorkMode.Show(btnWorkMode, 0, 0);
        }

        private void 视频ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SendWorkModeButtonClick != null)
            {
                btnWorkMode.Enabled = false;
                btnViewForm.Enabled = false;
                SendWorkModeButtonClick(this, new EventArgsWorkMode() { Mode = int.Parse((sender as ToolStripMenuItem).Tag.ToString()) });
            }
        }

        private void btnViewForm_Click(object sender, EventArgs e)
        {
            OnClick(e);
            if (ViewFormButtonClick != null)
            {
                ViewFormButtonClick(sender, e);
            }
        }
    }
}
