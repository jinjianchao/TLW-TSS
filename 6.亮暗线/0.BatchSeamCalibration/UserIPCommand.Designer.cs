namespace BatchSeamCalibration
{
    partial class UserIPCommand
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblIP = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.rbCk = new System.Windows.Forms.RadioButton();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.ctxWorkMode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuVideo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWhite = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRed = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGreen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBlue = new System.Windows.Forms.ToolStripMenuItem();
            this.btnWorkMode = new System.Windows.Forms.Button();
            this.btnViewForm = new System.Windows.Forms.Button();
            this.progress = new BatchSeamCalibration.ProgressBarEx();
            this.btnWriteToFlash = new System.Windows.Forms.Button();
            this.ctxWorkMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(21, 6);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(77, 12);
            this.lblIP.TabIndex = 0;
            this.lblIP.Text = "192.168.0.32";
            this.lblIP.Click += new System.EventHandler(this.lblIP_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(362, 2);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(91, 21);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "发送";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // rbCk
            // 
            this.rbCk.AutoSize = true;
            this.rbCk.Location = new System.Drawing.Point(3, 4);
            this.rbCk.Name = "rbCk";
            this.rbCk.Size = new System.Drawing.Size(14, 13);
            this.rbCk.TabIndex = 3;
            this.rbCk.TabStop = true;
            this.rbCk.UseVisualStyleBackColor = true;
            this.rbCk.CheckedChanged += new System.EventHandler(this.rbCk_CheckedChanged);
            this.rbCk.Click += new System.EventHandler(this.rbCk_Click);
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(6, 47);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(41, 12);
            this.lblDesc.TabIndex = 4;
            this.lblDesc.Text = "描述：";
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(54, 47);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(53, 12);
            this.lblContent.TabIndex = 5;
            this.lblContent.Text = "描述内容";
            // 
            // ctxWorkMode
            // 
            this.ctxWorkMode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuVideo,
            this.menuWhite,
            this.menuRed,
            this.menuGreen,
            this.menuBlue});
            this.ctxWorkMode.Name = "contextMenuStrip1";
            this.ctxWorkMode.Size = new System.Drawing.Size(101, 114);
            // 
            // menuVideo
            // 
            this.menuVideo.Name = "menuVideo";
            this.menuVideo.Size = new System.Drawing.Size(100, 22);
            this.menuVideo.Tag = "0";
            this.menuVideo.Text = "视频";
            this.menuVideo.Click += new System.EventHandler(this.视频ToolStripMenuItem_Click);
            // 
            // menuWhite
            // 
            this.menuWhite.Name = "menuWhite";
            this.menuWhite.Size = new System.Drawing.Size(100, 22);
            this.menuWhite.Tag = "128";
            this.menuWhite.Text = "白";
            this.menuWhite.Click += new System.EventHandler(this.视频ToolStripMenuItem_Click);
            // 
            // menuRed
            // 
            this.menuRed.Name = "menuRed";
            this.menuRed.Size = new System.Drawing.Size(100, 22);
            this.menuRed.Tag = "132";
            this.menuRed.Text = "红";
            this.menuRed.Click += new System.EventHandler(this.视频ToolStripMenuItem_Click);
            // 
            // menuGreen
            // 
            this.menuGreen.Name = "menuGreen";
            this.menuGreen.Size = new System.Drawing.Size(100, 22);
            this.menuGreen.Tag = "131";
            this.menuGreen.Text = "绿";
            this.menuGreen.Click += new System.EventHandler(this.视频ToolStripMenuItem_Click);
            // 
            // menuBlue
            // 
            this.menuBlue.Name = "menuBlue";
            this.menuBlue.Size = new System.Drawing.Size(100, 22);
            this.menuBlue.Tag = "130";
            this.menuBlue.Text = "蓝";
            this.menuBlue.Click += new System.EventHandler(this.视频ToolStripMenuItem_Click);
            // 
            // btnWorkMode
            // 
            this.btnWorkMode.Location = new System.Drawing.Point(457, 2);
            this.btnWorkMode.Name = "btnWorkMode";
            this.btnWorkMode.Size = new System.Drawing.Size(91, 21);
            this.btnWorkMode.TabIndex = 7;
            this.btnWorkMode.Text = "工作模式";
            this.btnWorkMode.UseVisualStyleBackColor = true;
            this.btnWorkMode.Click += new System.EventHandler(this.btnWorkMode_Click);
            // 
            // btnViewForm
            // 
            this.btnViewForm.Location = new System.Drawing.Point(282, 2);
            this.btnViewForm.Name = "btnViewForm";
            this.btnViewForm.Size = new System.Drawing.Size(75, 21);
            this.btnViewForm.TabIndex = 8;
            this.btnViewForm.Text = "预览";
            this.btnViewForm.UseVisualStyleBackColor = true;
            this.btnViewForm.Click += new System.EventHandler(this.btnViewForm_Click);
            // 
            // progress
            // 
            this.progress.FontColor = System.Drawing.Color.Black;
            this.progress.Location = new System.Drawing.Point(123, 2);
            this.progress.Name = "progress";
            this.progress.ShowText = true;
            this.progress.Size = new System.Drawing.Size(153, 21);
            this.progress.Step = 1;
            this.progress.TabIndex = 1;
            this.progress.Click += new System.EventHandler(this.progress_Click);
            // 
            // btnWriteToFlash
            // 
            this.btnWriteToFlash.Location = new System.Drawing.Point(555, 1);
            this.btnWriteToFlash.Name = "btnWriteToFlash";
            this.btnWriteToFlash.Size = new System.Drawing.Size(75, 23);
            this.btnWriteToFlash.TabIndex = 9;
            this.btnWriteToFlash.Text = "保存";
            this.btnWriteToFlash.UseVisualStyleBackColor = true;
            this.btnWriteToFlash.Click += new System.EventHandler(this.btnWriteToFlash_Click);
            // 
            // UserIPCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnWriteToFlash);
            this.Controls.Add(this.btnViewForm);
            this.Controls.Add(this.btnWorkMode);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.rbCk);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.lblIP);
            this.Name = "UserIPCommand";
            this.Size = new System.Drawing.Size(641, 31);
            this.ctxWorkMode.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Button btnApply;
        private ProgressBarEx progress;
        private System.Windows.Forms.RadioButton rbCk;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.ContextMenuStrip ctxWorkMode;
        private System.Windows.Forms.Button btnWorkMode;
        private System.Windows.Forms.ToolStripMenuItem menuVideo;
        private System.Windows.Forms.ToolStripMenuItem menuWhite;
        private System.Windows.Forms.ToolStripMenuItem menuRed;
        private System.Windows.Forms.ToolStripMenuItem menuGreen;
        private System.Windows.Forms.ToolStripMenuItem menuBlue;
        private System.Windows.Forms.Button btnViewForm;
        private System.Windows.Forms.Button btnWriteToFlash;
    }
}
