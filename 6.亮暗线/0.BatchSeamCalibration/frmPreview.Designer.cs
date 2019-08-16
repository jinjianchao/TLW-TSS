namespace BatchSeamCalibration
{
    partial class frmPreview
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxShowBorder = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxShowValue = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxClose = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxShowBorder,
            this.ctxShowValue,
            this.ctxClose});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(181, 92);
            // 
            // ctxShowBorder
            // 
            this.ctxShowBorder.Name = "ctxShowBorder";
            this.ctxShowBorder.Size = new System.Drawing.Size(180, 22);
            this.ctxShowBorder.Text = "显示边框";
            this.ctxShowBorder.Click += new System.EventHandler(this.ctxShowBorder_Click);
            // 
            // ctxShowValue
            // 
            this.ctxShowValue.Name = "ctxShowValue";
            this.ctxShowValue.Size = new System.Drawing.Size(180, 22);
            this.ctxShowValue.Text = "显示百分比数据";
            this.ctxShowValue.Click += new System.EventHandler(this.ctxShowValue_Click);
            // 
            // ctxClose
            // 
            this.ctxClose.Name = "ctxClose";
            this.ctxClose.Size = new System.Drawing.Size(180, 22);
            this.ctxClose.Text = "关闭";
            this.ctxClose.Click += new System.EventHandler(this.ctxClose_Click);
            // 
            // frmPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ContextMenuStrip = this.ctxMenu;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPreview";
            this.Text = "Form1";
            this.Deactivate += new System.EventHandler(this.frmPreview_Deactivate);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Move += new System.EventHandler(this.frmPreview_Move);
            this.ctxMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem ctxShowBorder;
        private System.Windows.Forms.ToolStripMenuItem ctxShowValue;
        private System.Windows.Forms.ToolStripMenuItem ctxClose;
    }
}

