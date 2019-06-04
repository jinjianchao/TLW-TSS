﻿namespace TLWController
{
    partial class MainForm
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
            this.tabCommonCommand = new System.Windows.Forms.TabPage();
            this.gbBrightness = new System.Windows.Forms.GroupBox();
            this.cbBrightnessColor = new System.Windows.Forms.ComboBox();
            this.btnApplyBrightness = new System.Windows.Forms.Button();
            this.numBrightness = new System.Windows.Forms.NumericUpDown();
            this.tbBrightness = new System.Windows.Forms.TrackBar();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabTest = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReadFlashData = new System.Windows.Forms.Button();
            this.btnCreateAndWriteFlashData = new System.Windows.Forms.Button();
            this.numFlashDataLen = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numRegAddr = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cbChipPos = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSDRAMWriteToFlash = new System.Windows.Forms.Button();
            this.btnCreateAndWriteSDRAM = new System.Windows.Forms.Button();
            this.numSDRAMDataLength = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numSDRAMAddr = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gpTest = new System.Windows.Forms.GroupBox();
            this.btnTest3 = new System.Windows.Forms.Button();
            this.btnReadWriteSend = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.numTestDataLen = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.numTimeDelay = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.tabCommonCommand.SuspendLayout();
            this.gbBrightness.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrightness)).BeginInit();
            this.tab.SuspendLayout();
            this.tabTest.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFlashDataLen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRegAddr)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSDRAMDataLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSDRAMAddr)).BeginInit();
            this.gpTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTestDataLen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCommonCommand
            // 
            this.tabCommonCommand.BackColor = System.Drawing.SystemColors.Control;
            this.tabCommonCommand.Controls.Add(this.gbBrightness);
            this.tabCommonCommand.Location = new System.Drawing.Point(4, 22);
            this.tabCommonCommand.Name = "tabCommonCommand";
            this.tabCommonCommand.Padding = new System.Windows.Forms.Padding(3);
            this.tabCommonCommand.Size = new System.Drawing.Size(1024, 583);
            this.tabCommonCommand.TabIndex = 0;
            this.tabCommonCommand.Text = "常用命令";
            // 
            // gbBrightness
            // 
            this.gbBrightness.Controls.Add(this.cbBrightnessColor);
            this.gbBrightness.Controls.Add(this.btnApplyBrightness);
            this.gbBrightness.Controls.Add(this.numBrightness);
            this.gbBrightness.Controls.Add(this.tbBrightness);
            this.gbBrightness.Location = new System.Drawing.Point(8, 6);
            this.gbBrightness.Name = "gbBrightness";
            this.gbBrightness.Size = new System.Drawing.Size(484, 63);
            this.gbBrightness.TabIndex = 2;
            this.gbBrightness.TabStop = false;
            this.gbBrightness.Text = "亮度命令";
            // 
            // cbBrightnessColor
            // 
            this.cbBrightnessColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBrightnessColor.FormattingEnabled = true;
            this.cbBrightnessColor.Location = new System.Drawing.Point(7, 21);
            this.cbBrightnessColor.Name = "cbBrightnessColor";
            this.cbBrightnessColor.Size = new System.Drawing.Size(76, 20);
            this.cbBrightnessColor.TabIndex = 3;
            // 
            // btnApplyBrightness
            // 
            this.btnApplyBrightness.Location = new System.Drawing.Point(408, 20);
            this.btnApplyBrightness.Name = "btnApplyBrightness";
            this.btnApplyBrightness.Size = new System.Drawing.Size(65, 23);
            this.btnApplyBrightness.TabIndex = 2;
            this.btnApplyBrightness.Text = "设置";
            this.btnApplyBrightness.UseVisualStyleBackColor = true;
            this.btnApplyBrightness.Click += new System.EventHandler(this.btnApplyBrightness_Click);
            // 
            // numBrightness
            // 
            this.numBrightness.Location = new System.Drawing.Point(350, 22);
            this.numBrightness.Name = "numBrightness";
            this.numBrightness.Size = new System.Drawing.Size(52, 21);
            this.numBrightness.TabIndex = 2;
            this.numBrightness.ValueChanged += new System.EventHandler(this.numBrightness_ValueChanged);
            // 
            // tbBrightness
            // 
            this.tbBrightness.AutoSize = false;
            this.tbBrightness.Location = new System.Drawing.Point(89, 20);
            this.tbBrightness.Maximum = 100;
            this.tbBrightness.Name = "tbBrightness";
            this.tbBrightness.Size = new System.Drawing.Size(259, 30);
            this.tbBrightness.TabIndex = 1;
            this.tbBrightness.TickFrequency = 10;
            this.tbBrightness.Scroll += new System.EventHandler(this.tbBrightness_Scroll);
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabCommonCommand);
            this.tab.Controls.Add(this.tabTest);
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Location = new System.Drawing.Point(0, 0);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(1032, 609);
            this.tab.TabIndex = 0;
            // 
            // tabTest
            // 
            this.tabTest.BackColor = System.Drawing.SystemColors.Control;
            this.tabTest.Controls.Add(this.groupBox3);
            this.tabTest.Location = new System.Drawing.Point(4, 22);
            this.tabTest.Name = "tabTest";
            this.tabTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabTest.Size = new System.Drawing.Size(1024, 583);
            this.tabTest.TabIndex = 1;
            this.tabTest.Text = "测试页";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.cbChipPos);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.gpTest);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1008, 148);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "FLASH操作";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReadFlashData);
            this.groupBox1.Controls.Add(this.btnCreateAndWriteFlashData);
            this.groupBox1.Controls.Add(this.numFlashDataLen);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numRegAddr);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "读写FLASH";
            // 
            // btnReadFlashData
            // 
            this.btnReadFlashData.Location = new System.Drawing.Point(156, 46);
            this.btnReadFlashData.Name = "btnReadFlashData";
            this.btnReadFlashData.Size = new System.Drawing.Size(88, 23);
            this.btnReadFlashData.TabIndex = 2;
            this.btnReadFlashData.Text = "读取";
            this.btnReadFlashData.UseVisualStyleBackColor = true;
            this.btnReadFlashData.Click += new System.EventHandler(this.btnReadFlashData_Click);
            // 
            // btnCreateAndWriteFlashData
            // 
            this.btnCreateAndWriteFlashData.Location = new System.Drawing.Point(156, 19);
            this.btnCreateAndWriteFlashData.Name = "btnCreateAndWriteFlashData";
            this.btnCreateAndWriteFlashData.Size = new System.Drawing.Size(88, 23);
            this.btnCreateAndWriteFlashData.TabIndex = 2;
            this.btnCreateAndWriteFlashData.Text = "构建并写入";
            this.btnCreateAndWriteFlashData.UseVisualStyleBackColor = true;
            this.btnCreateAndWriteFlashData.Click += new System.EventHandler(this.btnCreateAndWriteFlashData_Click);
            // 
            // numFlashDataLen
            // 
            this.numFlashDataLen.Location = new System.Drawing.Point(89, 46);
            this.numFlashDataLen.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numFlashDataLen.Name = "numFlashDataLen";
            this.numFlashDataLen.Size = new System.Drawing.Size(61, 21);
            this.numFlashDataLen.TabIndex = 1;
            this.numFlashDataLen.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "数据长度：";
            // 
            // numRegAddr
            // 
            this.numRegAddr.Location = new System.Drawing.Point(89, 20);
            this.numRegAddr.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numRegAddr.Name = "numRegAddr";
            this.numRegAddr.Size = new System.Drawing.Size(61, 21);
            this.numRegAddr.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "FLASH地址：";
            // 
            // cbChipPos
            // 
            this.cbChipPos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChipPos.FormattingEnabled = true;
            this.cbChipPos.Location = new System.Drawing.Point(77, 18);
            this.cbChipPos.Name = "cbChipPos";
            this.cbChipPos.Size = new System.Drawing.Size(112, 20);
            this.cbChipPos.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSDRAMWriteToFlash);
            this.groupBox2.Controls.Add(this.btnCreateAndWriteSDRAM);
            this.groupBox2.Controls.Add(this.numSDRAMDataLength);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.numSDRAMAddr);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(266, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 86);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "读写SDRAN";
            // 
            // btnSDRAMWriteToFlash
            // 
            this.btnSDRAMWriteToFlash.Location = new System.Drawing.Point(156, 46);
            this.btnSDRAMWriteToFlash.Name = "btnSDRAMWriteToFlash";
            this.btnSDRAMWriteToFlash.Size = new System.Drawing.Size(88, 23);
            this.btnSDRAMWriteToFlash.TabIndex = 2;
            this.btnSDRAMWriteToFlash.Text = "写入FLASH";
            this.btnSDRAMWriteToFlash.UseVisualStyleBackColor = true;
            this.btnSDRAMWriteToFlash.Click += new System.EventHandler(this.btnSDRAMWriteToFlash_Click);
            // 
            // btnCreateAndWriteSDRAM
            // 
            this.btnCreateAndWriteSDRAM.Location = new System.Drawing.Point(156, 19);
            this.btnCreateAndWriteSDRAM.Name = "btnCreateAndWriteSDRAM";
            this.btnCreateAndWriteSDRAM.Size = new System.Drawing.Size(88, 23);
            this.btnCreateAndWriteSDRAM.TabIndex = 2;
            this.btnCreateAndWriteSDRAM.Text = "构建并写入";
            this.btnCreateAndWriteSDRAM.UseVisualStyleBackColor = true;
            this.btnCreateAndWriteSDRAM.Click += new System.EventHandler(this.btnCreateAndWriteSDRAM_Click);
            // 
            // numSDRAMDataLength
            // 
            this.numSDRAMDataLength.Location = new System.Drawing.Point(89, 46);
            this.numSDRAMDataLength.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numSDRAMDataLength.Name = "numSDRAMDataLength";
            this.numSDRAMDataLength.Size = new System.Drawing.Size(61, 21);
            this.numSDRAMDataLength.TabIndex = 1;
            this.numSDRAMDataLength.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "数据长度：";
            // 
            // numSDRAMAddr
            // 
            this.numSDRAMAddr.Location = new System.Drawing.Point(89, 20);
            this.numSDRAMAddr.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numSDRAMAddr.Name = "numSDRAMAddr";
            this.numSDRAMAddr.Size = new System.Drawing.Size(61, 21);
            this.numSDRAMAddr.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "SDRAM地址：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "芯片位置:";
            // 
            // gpTest
            // 
            this.gpTest.Controls.Add(this.btnTest3);
            this.gpTest.Controls.Add(this.btnReadWriteSend);
            this.gpTest.Controls.Add(this.label5);
            this.gpTest.Controls.Add(this.numTestDataLen);
            this.gpTest.Controls.Add(this.label6);
            this.gpTest.Controls.Add(this.button1);
            this.gpTest.Controls.Add(this.numTimeDelay);
            this.gpTest.Controls.Add(this.button2);
            this.gpTest.Location = new System.Drawing.Point(526, 47);
            this.gpTest.Name = "gpTest";
            this.gpTest.Size = new System.Drawing.Size(451, 86);
            this.gpTest.TabIndex = 9;
            this.gpTest.TabStop = false;
            this.gpTest.Text = "稳定性测试";
            // 
            // btnTest3
            // 
            this.btnTest3.Location = new System.Drawing.Point(260, 43);
            this.btnTest3.Name = "btnTest3";
            this.btnTest3.Size = new System.Drawing.Size(181, 23);
            this.btnTest3.TabIndex = 7;
            this.btnTest3.Text = "写SDRAM->写FLASH->读FLASH";
            this.btnTest3.UseVisualStyleBackColor = true;
            this.btnTest3.Click += new System.EventHandler(this.btnTest3_Click);
            // 
            // btnReadWriteSend
            // 
            this.btnReadWriteSend.Location = new System.Drawing.Point(129, 43);
            this.btnReadWriteSend.Name = "btnReadWriteSend";
            this.btnReadWriteSend.Size = new System.Drawing.Size(130, 23);
            this.btnReadWriteSend.TabIndex = 4;
            this.btnReadWriteSend.Text = "写FLASH->读FLASH";
            this.btnReadWriteSend.UseVisualStyleBackColor = true;
            this.btnReadWriteSend.Click += new System.EventHandler(this.btnReadWriteSend_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(133, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "数据长度：";
            // 
            // numTestDataLen
            // 
            this.numTestDataLen.Location = new System.Drawing.Point(197, 21);
            this.numTestDataLen.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numTestDataLen.Name = "numTestDataLen";
            this.numTestDataLen.Size = new System.Drawing.Size(63, 21);
            this.numTestDataLen.TabIndex = 5;
            this.numTestDataLen.Value = new decimal(new int[] {
            1042,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "延时：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "读FLASH";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numTimeDelay
            // 
            this.numTimeDelay.Location = new System.Drawing.Point(68, 21);
            this.numTimeDelay.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numTimeDelay.Name = "numTimeDelay";
            this.numTimeDelay.Size = new System.Drawing.Size(55, 21);
            this.numTimeDelay.TabIndex = 5;
            this.numTimeDelay.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(268, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "停止";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 609);
            this.Controls.Add(this.tab);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.IsShowDataPackageChanged += new PluginLib.BaseFormV2.IsShowDataPackageChangedDelegate(this.MainForm_IsShowDataPackageChanged);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabCommonCommand.ResumeLayout(false);
            this.gbBrightness.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrightness)).EndInit();
            this.tab.ResumeLayout(false);
            this.tabTest.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFlashDataLen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRegAddr)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSDRAMDataLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSDRAMAddr)).EndInit();
            this.gpTest.ResumeLayout(false);
            this.gpTest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTestDataLen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeDelay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabCommonCommand;
        private System.Windows.Forms.GroupBox gbBrightness;
        private System.Windows.Forms.Button btnApplyBrightness;
        private System.Windows.Forms.NumericUpDown numBrightness;
        private System.Windows.Forms.TrackBar tbBrightness;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabTest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReadFlashData;
        private System.Windows.Forms.Button btnCreateAndWriteFlashData;
        private System.Windows.Forms.NumericUpDown numRegAddr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numFlashDataLen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbBrightnessColor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSDRAMWriteToFlash;
        private System.Windows.Forms.Button btnCreateAndWriteSDRAM;
        private System.Windows.Forms.NumericUpDown numSDRAMDataLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numSDRAMAddr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown numTimeDelay;
        private System.Windows.Forms.Button btnReadWriteSend;
        private System.Windows.Forms.GroupBox gpTest;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numTestDataLen;
        private System.Windows.Forms.Button btnTest3;
        private System.Windows.Forms.ComboBox cbChipPos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}
