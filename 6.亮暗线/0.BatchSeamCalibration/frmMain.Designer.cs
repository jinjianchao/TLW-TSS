namespace BatchSeamCalibration
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbGray = new System.Windows.Forms.TrackBar();
            this.numGray = new System.Windows.Forms.NumericUpDown();
            this.ckShowBorder = new System.Windows.Forms.CheckBox();
            this.ckShowPercent = new System.Windows.Forms.CheckBox();
            this.gpDataModify = new System.Windows.Forms.GroupBox();
            this.numAdjustPercent = new System.Windows.Forms.NumericUpDown();
            this.tbAdjustPercent = new System.Windows.Forms.TrackBar();
            this.lblIPList = new System.Windows.Forms.Label();
            this.flowIPList = new System.Windows.Forms.FlowLayoutPanel();
            this.gpDataLocate = new System.Windows.Forms.GroupBox();
            this.btnChoseDataLocation = new System.Windows.Forms.Button();
            this.txtDataLocation = new System.Windows.Forms.TextBox();
            this.cbDataType = new System.Windows.Forms.ComboBox();
            this.cbdataPos = new System.Windows.Forms.ComboBox();
            this.ckLockViewForm = new System.Windows.Forms.CheckBox();
            this.btnResetViewForm = new System.Windows.Forms.Button();
            this.gpPreviewBackground = new System.Windows.Forms.GroupBox();
            this.btnInitIpList = new System.Windows.Forms.Button();
            this.ckReset = new System.Windows.Forms.CheckBox();
            this.btnBlue = new System.Windows.Forms.Button();
            this.btnGreen = new System.Windows.Forms.Button();
            this.btnRed = new System.Windows.Forms.Button();
            this.btnVideo = new System.Windows.Forms.Button();
            this.btnWhite = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.gpDisplaySet = new System.Windows.Forms.GroupBox();
            this.lblComment = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGray)).BeginInit();
            this.gpDataModify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAdjustPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAdjustPercent)).BeginInit();
            this.gpDataLocate.SuspendLayout();
            this.gpPreviewBackground.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gpDisplaySet.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbGray
            // 
            this.tbGray.AutoSize = false;
            this.tbGray.Location = new System.Drawing.Point(12, 22);
            this.tbGray.Maximum = 255;
            this.tbGray.Name = "tbGray";
            this.tbGray.Size = new System.Drawing.Size(213, 21);
            this.tbGray.TabIndex = 1;
            this.tbGray.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbGray.Value = 255;
            this.tbGray.Scroll += new System.EventHandler(this.tbGray_Scroll);
            // 
            // numGray
            // 
            this.numGray.Location = new System.Drawing.Point(231, 22);
            this.numGray.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numGray.Name = "numGray";
            this.numGray.Size = new System.Drawing.Size(52, 21);
            this.numGray.TabIndex = 2;
            this.numGray.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numGray.ValueChanged += new System.EventHandler(this.numGray_ValueChanged);
            // 
            // ckShowBorder
            // 
            this.ckShowBorder.AutoSize = true;
            this.ckShowBorder.Location = new System.Drawing.Point(12, 25);
            this.ckShowBorder.Name = "ckShowBorder";
            this.ckShowBorder.Size = new System.Drawing.Size(72, 16);
            this.ckShowBorder.TabIndex = 3;
            this.ckShowBorder.Text = "显示边框";
            this.ckShowBorder.UseVisualStyleBackColor = true;
            this.ckShowBorder.CheckedChanged += new System.EventHandler(this.ckShowBorder_CheckedChanged);
            // 
            // ckShowPercent
            // 
            this.ckShowPercent.AutoSize = true;
            this.ckShowPercent.Location = new System.Drawing.Point(101, 25);
            this.ckShowPercent.Name = "ckShowPercent";
            this.ckShowPercent.Size = new System.Drawing.Size(108, 16);
            this.ckShowPercent.TabIndex = 3;
            this.ckShowPercent.Text = "显示百分比数据";
            this.ckShowPercent.UseVisualStyleBackColor = true;
            this.ckShowPercent.CheckedChanged += new System.EventHandler(this.ckShowPercent_CheckedChanged);
            // 
            // gpDataModify
            // 
            this.gpDataModify.Controls.Add(this.numAdjustPercent);
            this.gpDataModify.Controls.Add(this.tbAdjustPercent);
            this.gpDataModify.Location = new System.Drawing.Point(316, 74);
            this.gpDataModify.Name = "gpDataModify";
            this.gpDataModify.Size = new System.Drawing.Size(301, 54);
            this.gpDataModify.TabIndex = 4;
            this.gpDataModify.TabStop = false;
            this.gpDataModify.Text = "数据调整";
            // 
            // numAdjustPercent
            // 
            this.numAdjustPercent.DecimalPlaces = 1;
            this.numAdjustPercent.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numAdjustPercent.Location = new System.Drawing.Point(231, 20);
            this.numAdjustPercent.Name = "numAdjustPercent";
            this.numAdjustPercent.Size = new System.Drawing.Size(52, 21);
            this.numAdjustPercent.TabIndex = 3;
            this.numAdjustPercent.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numAdjustPercent.ValueChanged += new System.EventHandler(this.numAdjustPercent_ValueChanged);
            // 
            // tbAdjustPercent
            // 
            this.tbAdjustPercent.AutoSize = false;
            this.tbAdjustPercent.Location = new System.Drawing.Point(12, 22);
            this.tbAdjustPercent.Maximum = 1000;
            this.tbAdjustPercent.Name = "tbAdjustPercent";
            this.tbAdjustPercent.Size = new System.Drawing.Size(213, 21);
            this.tbAdjustPercent.TabIndex = 2;
            this.tbAdjustPercent.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAdjustPercent.Value = 1000;
            this.tbAdjustPercent.Scroll += new System.EventHandler(this.tbAdjustPercent_Scroll);
            // 
            // lblIPList
            // 
            this.lblIPList.AutoSize = true;
            this.lblIPList.Location = new System.Drawing.Point(12, 237);
            this.lblIPList.Name = "lblIPList";
            this.lblIPList.Size = new System.Drawing.Size(41, 12);
            this.lblIPList.TabIndex = 9;
            this.lblIPList.Text = "IP列表";
            // 
            // flowIPList
            // 
            this.flowIPList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowIPList.AutoScroll = true;
            this.flowIPList.Location = new System.Drawing.Point(9, 252);
            this.flowIPList.Name = "flowIPList";
            this.flowIPList.Size = new System.Drawing.Size(1244, 439);
            this.flowIPList.TabIndex = 10;
            // 
            // gpDataLocate
            // 
            this.gpDataLocate.Controls.Add(this.btnChoseDataLocation);
            this.gpDataLocate.Controls.Add(this.txtDataLocation);
            this.gpDataLocate.Controls.Add(this.cbDataType);
            this.gpDataLocate.Controls.Add(this.cbdataPos);
            this.gpDataLocate.Location = new System.Drawing.Point(6, 134);
            this.gpDataLocate.Name = "gpDataLocate";
            this.gpDataLocate.Size = new System.Drawing.Size(304, 68);
            this.gpDataLocate.TabIndex = 17;
            this.gpDataLocate.TabStop = false;
            this.gpDataLocate.Text = "数据位置";
            // 
            // btnChoseDataLocation
            // 
            this.btnChoseDataLocation.Location = new System.Drawing.Point(260, 27);
            this.btnChoseDataLocation.Name = "btnChoseDataLocation";
            this.btnChoseDataLocation.Size = new System.Drawing.Size(38, 23);
            this.btnChoseDataLocation.TabIndex = 2;
            this.btnChoseDataLocation.Text = "...";
            this.btnChoseDataLocation.UseVisualStyleBackColor = true;
            this.btnChoseDataLocation.Click += new System.EventHandler(this.btnChoseDataLocation_Click);
            // 
            // txtDataLocation
            // 
            this.txtDataLocation.Location = new System.Drawing.Point(84, 28);
            this.txtDataLocation.Name = "txtDataLocation";
            this.txtDataLocation.Size = new System.Drawing.Size(170, 21);
            this.txtDataLocation.TabIndex = 1;
            this.txtDataLocation.Text = "D:\\Read";
            // 
            // cbDataType
            // 
            this.cbDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataType.FormattingEnabled = true;
            this.cbDataType.Items.AddRange(new object[] {
            "模组",
            "箱体"});
            this.cbDataType.Location = new System.Drawing.Point(150, 48);
            this.cbDataType.Name = "cbDataType";
            this.cbDataType.Size = new System.Drawing.Size(71, 20);
            this.cbDataType.TabIndex = 0;
            this.cbDataType.Visible = false;
            // 
            // cbdataPos
            // 
            this.cbdataPos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbdataPos.FormattingEnabled = true;
            this.cbdataPos.Items.AddRange(new object[] {
            "箱体",
            "文件夹"});
            this.cbdataPos.Location = new System.Drawing.Point(7, 30);
            this.cbdataPos.Name = "cbdataPos";
            this.cbdataPos.Size = new System.Drawing.Size(71, 20);
            this.cbdataPos.TabIndex = 0;
            this.cbdataPos.SelectedIndexChanged += new System.EventHandler(this.cbdataPos_SelectedIndexChanged);
            // 
            // ckLockViewForm
            // 
            this.ckLockViewForm.AutoSize = true;
            this.ckLockViewForm.Location = new System.Drawing.Point(220, 25);
            this.ckLockViewForm.Name = "ckLockViewForm";
            this.ckLockViewForm.Size = new System.Drawing.Size(72, 16);
            this.ckLockViewForm.TabIndex = 18;
            this.ckLockViewForm.Text = "锁定窗体";
            this.ckLockViewForm.UseVisualStyleBackColor = true;
            this.ckLockViewForm.CheckedChanged += new System.EventHandler(this.ckLockViewForm_CheckedChanged);
            // 
            // btnResetViewForm
            // 
            this.btnResetViewForm.Location = new System.Drawing.Point(147, 18);
            this.btnResetViewForm.Name = "btnResetViewForm";
            this.btnResetViewForm.Size = new System.Drawing.Size(111, 23);
            this.btnResetViewForm.TabIndex = 20;
            this.btnResetViewForm.Text = "复位预览窗口";
            this.btnResetViewForm.UseVisualStyleBackColor = true;
            this.btnResetViewForm.Visible = false;
            this.btnResetViewForm.Click += new System.EventHandler(this.btnResetViewForm_Click);
            // 
            // gpPreviewBackground
            // 
            this.gpPreviewBackground.Controls.Add(this.tbGray);
            this.gpPreviewBackground.Controls.Add(this.numGray);
            this.gpPreviewBackground.Location = new System.Drawing.Point(9, 74);
            this.gpPreviewBackground.Name = "gpPreviewBackground";
            this.gpPreviewBackground.Size = new System.Drawing.Size(301, 54);
            this.gpPreviewBackground.TabIndex = 21;
            this.gpPreviewBackground.TabStop = false;
            this.gpPreviewBackground.Text = "预览背景";
            // 
            // btnInitIpList
            // 
            this.btnInitIpList.Location = new System.Drawing.Point(29, 18);
            this.btnInitIpList.Name = "btnInitIpList";
            this.btnInitIpList.Size = new System.Drawing.Size(112, 23);
            this.btnInitIpList.TabIndex = 22;
            this.btnInitIpList.Text = "初始化";
            this.btnInitIpList.UseVisualStyleBackColor = true;
            this.btnInitIpList.Click += new System.EventHandler(this.btnInitIpList_Click);
            // 
            // ckReset
            // 
            this.ckReset.AutoSize = true;
            this.ckReset.Location = new System.Drawing.Point(9, 208);
            this.ckReset.Name = "ckReset";
            this.ckReset.Size = new System.Drawing.Size(264, 16);
            this.ckReset.TabIndex = 24;
            this.ckReset.Text = "数据还原(仅在从文件夹读取校正数据时有效)";
            this.ckReset.UseVisualStyleBackColor = true;
            // 
            // btnBlue
            // 
            this.btnBlue.BackColor = System.Drawing.Color.Blue;
            this.btnBlue.Location = new System.Drawing.Point(231, 17);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Size = new System.Drawing.Size(47, 40);
            this.btnBlue.TabIndex = 38;
            this.btnBlue.Tag = "130";
            this.btnBlue.UseVisualStyleBackColor = false;
            this.btnBlue.Click += new System.EventHandler(this.btnVideo_Click);
            // 
            // btnGreen
            // 
            this.btnGreen.BackColor = System.Drawing.Color.Green;
            this.btnGreen.Location = new System.Drawing.Point(178, 17);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.Size = new System.Drawing.Size(47, 40);
            this.btnGreen.TabIndex = 37;
            this.btnGreen.Tag = "131";
            this.btnGreen.UseVisualStyleBackColor = false;
            this.btnGreen.Click += new System.EventHandler(this.btnVideo_Click);
            // 
            // btnRed
            // 
            this.btnRed.BackColor = System.Drawing.Color.Red;
            this.btnRed.Location = new System.Drawing.Point(125, 17);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(47, 40);
            this.btnRed.TabIndex = 36;
            this.btnRed.Tag = "132";
            this.btnRed.UseVisualStyleBackColor = false;
            this.btnRed.Click += new System.EventHandler(this.btnVideo_Click);
            // 
            // btnVideo
            // 
            this.btnVideo.BackColor = System.Drawing.Color.LightGray;
            this.btnVideo.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnVideo.ForeColor = System.Drawing.Color.Black;
            this.btnVideo.Location = new System.Drawing.Point(19, 17);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(47, 40);
            this.btnVideo.TabIndex = 34;
            this.btnVideo.Tag = "0";
            this.btnVideo.Text = "Video";
            this.btnVideo.UseVisualStyleBackColor = false;
            this.btnVideo.Click += new System.EventHandler(this.btnVideo_Click);
            // 
            // btnWhite
            // 
            this.btnWhite.BackColor = System.Drawing.Color.White;
            this.btnWhite.Location = new System.Drawing.Point(72, 17);
            this.btnWhite.Name = "btnWhite";
            this.btnWhite.Size = new System.Drawing.Size(47, 40);
            this.btnWhite.TabIndex = 35;
            this.btnWhite.Tag = "128";
            this.btnWhite.UseVisualStyleBackColor = false;
            this.btnWhite.Click += new System.EventHandler(this.btnVideo_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnInitIpList);
            this.groupBox4.Controls.Add(this.btnResetViewForm);
            this.groupBox4.Location = new System.Drawing.Point(9, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(608, 54);
            this.groupBox4.TabIndex = 39;
            this.groupBox4.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ckShowBorder);
            this.groupBox5.Controls.Add(this.ckShowPercent);
            this.groupBox5.Controls.Add(this.ckLockViewForm);
            this.groupBox5.Location = new System.Drawing.Point(1161, 192);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(301, 54);
            this.groupBox5.TabIndex = 40;
            this.groupBox5.TabStop = false;
            this.groupBox5.Visible = false;
            // 
            // gpDisplaySet
            // 
            this.gpDisplaySet.Controls.Add(this.btnRed);
            this.gpDisplaySet.Controls.Add(this.btnWhite);
            this.gpDisplaySet.Controls.Add(this.btnVideo);
            this.gpDisplaySet.Controls.Add(this.btnBlue);
            this.gpDisplaySet.Controls.Add(this.btnGreen);
            this.gpDisplaySet.Location = new System.Drawing.Point(316, 137);
            this.gpDisplaySet.Name = "gpDisplaySet";
            this.gpDisplaySet.Size = new System.Drawing.Size(301, 65);
            this.gpDisplaySet.TabIndex = 41;
            this.gpDisplaySet.TabStop = false;
            this.gpDisplaySet.Text = "显示设置";
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(632, 21);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(287, 60);
            this.lblComment.TabIndex = 42;
            this.lblComment.Text = "说明：\r\n按住鼠标左键拖动选中边缘\r\n按住Ctrl键，同时按住鼠标左键拖动可实现多选\r\n按住Shift键，同时按住鼠标左键拖动可移动预览窗口\r\n按住”A、W、S、" +
    "D\"键不放可实现预览窗口位置的微调";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 695);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.gpDisplaySet);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.ckReset);
            this.Controls.Add(this.gpPreviewBackground);
            this.Controls.Add(this.gpDataLocate);
            this.Controls.Add(this.flowIPList);
            this.Controls.Add(this.lblIPList);
            this.Controls.Add(this.gpDataModify);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.Text = "亮暗线批量调节";
            this.FormClosing += new PluginLib.BaseFormV2.FormCloseDelegate(this.frmMain_FormClosing);
            this.UnitTypeChanged += new PluginLib.BaseFormV2.UnitTypeChangedDelegate(this.frmMain_UnitTypeChanged);
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.Deactivate += new System.EventHandler(this.frmMain_Deactivate);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Move += new System.EventHandler(this.frmMain_Move);
            ((System.ComponentModel.ISupportInitialize)(this.tbGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGray)).EndInit();
            this.gpDataModify.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numAdjustPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAdjustPercent)).EndInit();
            this.gpDataLocate.ResumeLayout(false);
            this.gpDataLocate.PerformLayout();
            this.gpPreviewBackground.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gpDisplaySet.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar tbGray;
        private System.Windows.Forms.NumericUpDown numGray;
        private System.Windows.Forms.CheckBox ckShowBorder;
        private System.Windows.Forms.CheckBox ckShowPercent;
        private System.Windows.Forms.GroupBox gpDataModify;
        private System.Windows.Forms.NumericUpDown numAdjustPercent;
        private System.Windows.Forms.TrackBar tbAdjustPercent;
        private System.Windows.Forms.Label lblIPList;
        private System.Windows.Forms.FlowLayoutPanel flowIPList;
        private System.Windows.Forms.GroupBox gpDataLocate;
        private System.Windows.Forms.ComboBox cbdataPos;
        private System.Windows.Forms.Button btnChoseDataLocation;
        private System.Windows.Forms.TextBox txtDataLocation;
        private System.Windows.Forms.ComboBox cbDataType;
        private System.Windows.Forms.CheckBox ckLockViewForm;
        private System.Windows.Forms.Button btnResetViewForm;
        private System.Windows.Forms.GroupBox gpPreviewBackground;
        private System.Windows.Forms.Button btnInitIpList;
        private System.Windows.Forms.CheckBox ckReset;
        private System.Windows.Forms.Button btnBlue;
        private System.Windows.Forms.Button btnGreen;
        private System.Windows.Forms.Button btnRed;
        private System.Windows.Forms.Button btnVideo;
        private System.Windows.Forms.Button btnWhite;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox gpDisplaySet;
        private System.Windows.Forms.Label lblComment;
    }
}