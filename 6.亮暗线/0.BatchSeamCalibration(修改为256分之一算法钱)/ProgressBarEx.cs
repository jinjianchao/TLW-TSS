using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BatchSeamCalibration
{
    public partial class ProgressBarEx : ProgressBar
    {
        [Browsable(true),
            Category("Appearance"),
            Description("需要在进度条上显示的文字")]
        public new string Text { get; set; }
        [Browsable(true), Category("Appearance"), Description("是否在进度条上显示文字")]
        public bool ShowText { get; set; }
        [Browsable(true), Category("Appearance"), Description("进度条上的文字的字体")]
        public new Font Font { get; set; }
        [Browsable(true), Category("Appearance"), Description("进度条上的文字的颜色")]
        protected Color fontColor;
        protected Brush brush;
        public Color FontColor
        {
            get { return fontColor; }
            set
            {
                fontColor = value;
                brush = new SolidBrush(value);
            }
        }
        public ProgressBarEx() : base()
        {
            ShowText = false; Font = new Font("宋体", 9, FontStyle.Regular);
            FontColor = Color.Black;
        }
        protected void DrawText()
        {
            string temp = Text;
            if (string.IsNullOrEmpty(temp))
                if (Value != 0) temp = Value + "%";
            SizeF size = TextRenderer.MeasureText(temp, Font);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            this.CreateGraphics().DrawString(temp, Font, brush, this.Size.Width / 2, (this.Size.Height - size.Height) / 2, sf);
        }

        
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            base.WndProc(ref m);
            if (ShowText)
            {
                DrawText();
            }
        }
    }

}
