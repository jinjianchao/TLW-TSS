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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabCommonCommand = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.numGamma = new System.Windows.Forms.NumericUpDown();
            this.cbGammaColor = new System.Windows.Forms.ComboBox();
            this.cbGammaBit = new System.Windows.Forms.ComboBox();
            this.btnGammaRead = new System.Windows.Forms.Button();
            this.btnGammaSet = new System.Windows.Forms.Button();
            this.gbBrightness = new System.Windows.Forms.GroupBox();
            this.cbBrightnessColor = new System.Windows.Forms.ComboBox();
            this.btnApplyBrightness = new System.Windows.Forms.Button();
            this.numBrightness = new System.Windows.Forms.NumericUpDown();
            this.tbBrightness = new System.Windows.Forms.TrackBar();
            this.tab2055Param = new System.Windows.Forms.TabControl();
            this.tabAdvance = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnSingleRegRead = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.btnSetRegister = new System.Windows.Forms.Button();
            this.numSingleRegValue = new System.Windows.Forms.NumericUpDown();
            this.numSingleRegAddr = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtMap = new System.Windows.Forms.TextBox();
            this.btnUpgradeMAP = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.btnChoseMAP = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnSetNetwork = new System.Windows.Forms.Button();
            this.txtGateway = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMask = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.gpFirmwareUpgrade = new System.Windows.Forms.GroupBox();
            this.cbDistributeAddress = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnReadFirmwareVersion = new System.Windows.Forms.Button();
            this.cbAdvChip = new System.Windows.Forms.ComboBox();
            this.btnReadbtnDistributeBoardFPGA = new System.Windows.Forms.Button();
            this.btnReadFPGA = new System.Windows.Forms.Button();
            this.btnReadMCU = new System.Windows.Forms.Button();
            this.btnUpdateDistributeBoardFPGA = new System.Windows.Forms.Button();
            this.btnUpgradeFPGA = new System.Windows.Forms.Button();
            this.btnUpgradeMCU = new System.Windows.Forms.Button();
            this.btnChoseDistributeBoardFPGA = new System.Windows.Forms.Button();
            this.btnChoseFPGA = new System.Windows.Forms.Button();
            this.btnChoseMCU = new System.Windows.Forms.Button();
            this.txtDistributeBoardFPGA = new System.Windows.Forms.TextBox();
            this.txtFPGA = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMcu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnRegSetDefault = new System.Windows.Forms.Button();
            this.tabRegister = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grid2055 = new System.Windows.Forms.DataGridView();
            this.CoCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColMinValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMaxValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCNDescription = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ColENDescription = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ColDescription = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ColOffset = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ColRegisterAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRedAddress = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ColGreenAddress = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ColBlueAddress = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ColStartBit = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ColStopBit = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ColRedValue = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ColGreenValue = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ColBlueValue = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ColSend = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.gridOtherReg = new System.Windows.Forms.DataGridView();
            this.ColOtherCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColOtherMinValue = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ColOtherMaxValue = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ColOtherCNDescription = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ColOtherENDescription = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ColOtherRegisterAddress = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ColOtherStartBit = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ColOtherStopBit = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ColOtherValue = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ColOtherSend = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnReadReg = new System.Windows.Forms.Button();
            this.btnSendAll = new System.Windows.Forms.Button();
            this.cbParam2055Color = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ckDebugMode = new System.Windows.Forms.CheckBox();
            this.cbRegChip = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnExport2055Param = new System.Windows.Forms.Button();
            this.btnLoad2055Param = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabTest = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.txtCompareFile2 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtCompareFile1 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.rtCompare = new System.Windows.Forms.RichTextBox();
            this.btnCompareChose2 = new System.Windows.Forms.Button();
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnCompareChose1 = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.txtBatchCalibrationFolder = new System.Windows.Forms.TextBox();
            this.btnBatchWriteCalibration = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.btnSelectBatchCalibrationFolder = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.cbCalibrationOnOff = new System.Windows.Forms.ComboBox();
            this.btnSendCalibrationOnOff = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.cbWorkMode = new System.Windows.Forms.ComboBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.btnSDRAMToFlash = new System.Windows.Forms.Button();
            this.btnSetB6B7 = new System.Windows.Forms.Button();
            this.btnOpenCalibration = new System.Windows.Forms.Button();
            this.btnUpgradeCalibration = new System.Windows.Forms.Button();
            this.txtCalibration = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnLoadVideoCardParam = new System.Windows.Forms.Button();
            this.cbVideocardLoadParam = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbChipPos = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReadFlashData = new System.Windows.Forms.Button();
            this.btnCreateAndWriteFlashData = new System.Windows.Forms.Button();
            this.numFlashDataLen = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numRegAddr = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnReadSDRAM = new System.Windows.Forms.Button();
            this.btnSDRAMWriteToFlash = new System.Windows.Forms.Button();
            this.btnCreateAndWriteSDRAM = new System.Windows.Forms.Button();
            this.numSDRAMDataLength = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numSDRAMAddr = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.gpTest = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnWriteSdramReadSdram = new System.Windows.Forms.Button();
            this.btnReadAndWriteFlash = new System.Windows.Forms.Button();
            this.btnTest3 = new System.Windows.Forms.Button();
            this.btnReadWriteSend = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.numTestDataLen = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.numTimeDelay = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.grid2072 = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewLabelXColumn1 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn2 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn3 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn4 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewLabelXColumn5 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn6 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn7 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn8 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn9 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn10 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn11 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn12 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.grid2072Other = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewLabelXColumn13 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn14 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn15 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn16 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn17 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn18 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn19 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewLabelXColumn20 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.btnExport2072 = new System.Windows.Forms.Button();
            this.btnImport2072 = new System.Windows.Forms.Button();
            this.tabCommonCommand.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGamma)).BeginInit();
            this.gbBrightness.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrightness)).BeginInit();
            this.tab2055Param.SuspendLayout();
            this.tabAdvance.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSingleRegValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSingleRegAddr)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.gpFirmwareUpgrade.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabRegister.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid2055)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOtherReg)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabTest.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFlashDataLen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRegAddr)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSDRAMDataLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSDRAMAddr)).BeginInit();
            this.gpTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTestDataLen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeDelay)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid2072)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid2072Other)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCommonCommand
            // 
            this.tabCommonCommand.BackColor = System.Drawing.SystemColors.Control;
            this.tabCommonCommand.Controls.Add(this.groupBox5);
            this.tabCommonCommand.Controls.Add(this.gbBrightness);
            this.tabCommonCommand.Location = new System.Drawing.Point(4, 22);
            this.tabCommonCommand.Name = "tabCommonCommand";
            this.tabCommonCommand.Padding = new System.Windows.Forms.Padding(3);
            this.tabCommonCommand.Size = new System.Drawing.Size(1392, 578);
            this.tabCommonCommand.TabIndex = 0;
            this.tabCommonCommand.Text = "常用命令";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.numGamma);
            this.groupBox5.Controls.Add(this.cbGammaColor);
            this.groupBox5.Controls.Add(this.cbGammaBit);
            this.groupBox5.Controls.Add(this.btnGammaRead);
            this.groupBox5.Controls.Add(this.btnGammaSet);
            this.groupBox5.Location = new System.Drawing.Point(498, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(484, 63);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "GAMMA设置";
            // 
            // numGamma
            // 
            this.numGamma.DecimalPlaces = 1;
            this.numGamma.Location = new System.Drawing.Point(171, 25);
            this.numGamma.Name = "numGamma";
            this.numGamma.Size = new System.Drawing.Size(52, 21);
            this.numGamma.TabIndex = 4;
            this.numGamma.Value = new decimal(new int[] {
            24,
            0,
            0,
            65536});
            // 
            // cbGammaColor
            // 
            this.cbGammaColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGammaColor.FormattingEnabled = true;
            this.cbGammaColor.Location = new System.Drawing.Point(89, 25);
            this.cbGammaColor.Name = "cbGammaColor";
            this.cbGammaColor.Size = new System.Drawing.Size(76, 20);
            this.cbGammaColor.TabIndex = 3;
            // 
            // cbGammaBit
            // 
            this.cbGammaBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGammaBit.FormattingEnabled = true;
            this.cbGammaBit.Location = new System.Drawing.Point(7, 25);
            this.cbGammaBit.Name = "cbGammaBit";
            this.cbGammaBit.Size = new System.Drawing.Size(76, 20);
            this.cbGammaBit.TabIndex = 3;
            // 
            // btnGammaRead
            // 
            this.btnGammaRead.Location = new System.Drawing.Point(300, 24);
            this.btnGammaRead.Name = "btnGammaRead";
            this.btnGammaRead.Size = new System.Drawing.Size(65, 23);
            this.btnGammaRead.TabIndex = 2;
            this.btnGammaRead.Text = "读取";
            this.btnGammaRead.UseVisualStyleBackColor = true;
            this.btnGammaRead.Click += new System.EventHandler(this.btnGammaRead_Click);
            // 
            // btnGammaSet
            // 
            this.btnGammaSet.Location = new System.Drawing.Point(229, 24);
            this.btnGammaSet.Name = "btnGammaSet";
            this.btnGammaSet.Size = new System.Drawing.Size(65, 23);
            this.btnGammaSet.TabIndex = 2;
            this.btnGammaSet.Text = "写入";
            this.btnGammaSet.UseVisualStyleBackColor = true;
            this.btnGammaSet.Click += new System.EventHandler(this.btnGammaSet_Click);
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
            // tab2055Param
            // 
            this.tab2055Param.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tab2055Param.Controls.Add(this.tabCommonCommand);
            this.tab2055Param.Controls.Add(this.tabAdvance);
            this.tab2055Param.Controls.Add(this.tabPage1);
            this.tab2055Param.Controls.Add(this.tabPage3);
            this.tab2055Param.Controls.Add(this.tabTest);
            this.tab2055Param.Location = new System.Drawing.Point(0, 5);
            this.tab2055Param.Name = "tab2055Param";
            this.tab2055Param.SelectedIndex = 0;
            this.tab2055Param.Size = new System.Drawing.Size(1400, 604);
            this.tab2055Param.TabIndex = 0;
            // 
            // tabAdvance
            // 
            this.tabAdvance.BackColor = System.Drawing.SystemColors.Control;
            this.tabAdvance.Controls.Add(this.groupBox9);
            this.tabAdvance.Controls.Add(this.groupBox7);
            this.tabAdvance.Controls.Add(this.groupBox6);
            this.tabAdvance.Controls.Add(this.gpFirmwareUpgrade);
            this.tabAdvance.Location = new System.Drawing.Point(4, 22);
            this.tabAdvance.Name = "tabAdvance";
            this.tabAdvance.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdvance.Size = new System.Drawing.Size(1392, 578);
            this.tabAdvance.TabIndex = 3;
            this.tabAdvance.Text = "高级";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btnSingleRegRead);
            this.groupBox9.Controls.Add(this.label19);
            this.groupBox9.Controls.Add(this.btnSetRegister);
            this.groupBox9.Controls.Add(this.numSingleRegValue);
            this.groupBox9.Controls.Add(this.numSingleRegAddr);
            this.groupBox9.Controls.Add(this.label18);
            this.groupBox9.Location = new System.Drawing.Point(434, 152);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(472, 67);
            this.groupBox9.TabIndex = 19;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "寄存器操作";
            // 
            // btnSingleRegRead
            // 
            this.btnSingleRegRead.Location = new System.Drawing.Point(385, 27);
            this.btnSingleRegRead.Name = "btnSingleRegRead";
            this.btnSingleRegRead.Size = new System.Drawing.Size(75, 23);
            this.btnSingleRegRead.TabIndex = 4;
            this.btnSingleRegRead.Text = "读取";
            this.btnSingleRegRead.UseVisualStyleBackColor = true;
            this.btnSingleRegRead.Click += new System.EventHandler(this.btnSingleRegRead_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(175, 31);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 12);
            this.label19.TabIndex = 3;
            this.label19.Text = "值：";
            // 
            // btnSetRegister
            // 
            this.btnSetRegister.Location = new System.Drawing.Point(303, 27);
            this.btnSetRegister.Name = "btnSetRegister";
            this.btnSetRegister.Size = new System.Drawing.Size(75, 23);
            this.btnSetRegister.TabIndex = 2;
            this.btnSetRegister.Text = "设置";
            this.btnSetRegister.UseVisualStyleBackColor = true;
            this.btnSetRegister.Click += new System.EventHandler(this.btnSetRegister_Click);
            // 
            // numSingleRegValue
            // 
            this.numSingleRegValue.Hexadecimal = true;
            this.numSingleRegValue.Location = new System.Drawing.Point(206, 29);
            this.numSingleRegValue.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numSingleRegValue.Name = "numSingleRegValue";
            this.numSingleRegValue.Size = new System.Drawing.Size(91, 21);
            this.numSingleRegValue.TabIndex = 1;
            // 
            // numSingleRegAddr
            // 
            this.numSingleRegAddr.Hexadecimal = true;
            this.numSingleRegAddr.Location = new System.Drawing.Point(65, 27);
            this.numSingleRegAddr.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numSingleRegAddr.Name = "numSingleRegAddr";
            this.numSingleRegAddr.Size = new System.Drawing.Size(91, 21);
            this.numSingleRegAddr.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(18, 31);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 12);
            this.label18.TabIndex = 0;
            this.label18.Text = "地址：";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtMap);
            this.groupBox7.Controls.Add(this.btnUpgradeMAP);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.btnChoseMAP);
            this.groupBox7.Location = new System.Drawing.Point(9, 152);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(419, 67);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "MAP下载";
            // 
            // txtMap
            // 
            this.txtMap.Location = new System.Drawing.Point(43, 23);
            this.txtMap.Name = "txtMap";
            this.txtMap.Size = new System.Drawing.Size(141, 21);
            this.txtMap.TabIndex = 5;
            // 
            // btnUpgradeMAP
            // 
            this.btnUpgradeMAP.Location = new System.Drawing.Point(233, 20);
            this.btnUpgradeMAP.Name = "btnUpgradeMAP";
            this.btnUpgradeMAP.Size = new System.Drawing.Size(75, 23);
            this.btnUpgradeMAP.TabIndex = 7;
            this.btnUpgradeMAP.Text = "更新";
            this.btnUpgradeMAP.UseVisualStyleBackColor = true;
            this.btnUpgradeMAP.Click += new System.EventHandler(this.btnUpgradeMAP_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 26);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 4;
            this.label16.Text = "MAP:";
            // 
            // btnChoseMAP
            // 
            this.btnChoseMAP.Location = new System.Drawing.Point(188, 22);
            this.btnChoseMAP.Name = "btnChoseMAP";
            this.btnChoseMAP.Size = new System.Drawing.Size(39, 23);
            this.btnChoseMAP.TabIndex = 6;
            this.btnChoseMAP.Text = "...";
            this.btnChoseMAP.UseVisualStyleBackColor = true;
            this.btnChoseMAP.Click += new System.EventHandler(this.btnChoseMAP_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnSetNetwork);
            this.groupBox6.Controls.Add(this.txtGateway);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.txtMask);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.txtIP);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Location = new System.Drawing.Point(9, 7);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(307, 139);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "网络参数";
            // 
            // btnSetNetwork
            // 
            this.btnSetNetwork.Location = new System.Drawing.Point(223, 75);
            this.btnSetNetwork.Name = "btnSetNetwork";
            this.btnSetNetwork.Size = new System.Drawing.Size(75, 23);
            this.btnSetNetwork.TabIndex = 2;
            this.btnSetNetwork.Text = "设置";
            this.btnSetNetwork.UseVisualStyleBackColor = true;
            this.btnSetNetwork.Click += new System.EventHandler(this.btnSetNetwork_Click);
            // 
            // txtGateway
            // 
            this.txtGateway.Location = new System.Drawing.Point(76, 75);
            this.txtGateway.Name = "txtGateway";
            this.txtGateway.Size = new System.Drawing.Size(140, 21);
            this.txtGateway.TabIndex = 1;
            this.txtGateway.Text = "192.168.0.1";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(33, 79);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 12);
            this.label15.TabIndex = 0;
            this.label15.Text = "网关:";
            // 
            // txtMask
            // 
            this.txtMask.Location = new System.Drawing.Point(76, 48);
            this.txtMask.Name = "txtMask";
            this.txtMask.Size = new System.Drawing.Size(140, 21);
            this.txtMask.TabIndex = 1;
            this.txtMask.Text = "255.255.255.0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "子网掩码:";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(76, 21);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(140, 21);
            this.txtIP.TabIndex = 1;
            this.txtIP.Text = "192.168.0.32";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(45, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "IP:";
            // 
            // gpFirmwareUpgrade
            // 
            this.gpFirmwareUpgrade.Controls.Add(this.cbDistributeAddress);
            this.gpFirmwareUpgrade.Controls.Add(this.label11);
            this.gpFirmwareUpgrade.Controls.Add(this.btnReadFirmwareVersion);
            this.gpFirmwareUpgrade.Controls.Add(this.cbAdvChip);
            this.gpFirmwareUpgrade.Controls.Add(this.btnReadbtnDistributeBoardFPGA);
            this.gpFirmwareUpgrade.Controls.Add(this.btnReadFPGA);
            this.gpFirmwareUpgrade.Controls.Add(this.btnReadMCU);
            this.gpFirmwareUpgrade.Controls.Add(this.btnUpdateDistributeBoardFPGA);
            this.gpFirmwareUpgrade.Controls.Add(this.btnUpgradeFPGA);
            this.gpFirmwareUpgrade.Controls.Add(this.btnUpgradeMCU);
            this.gpFirmwareUpgrade.Controls.Add(this.btnChoseDistributeBoardFPGA);
            this.gpFirmwareUpgrade.Controls.Add(this.btnChoseFPGA);
            this.gpFirmwareUpgrade.Controls.Add(this.btnChoseMCU);
            this.gpFirmwareUpgrade.Controls.Add(this.txtDistributeBoardFPGA);
            this.gpFirmwareUpgrade.Controls.Add(this.txtFPGA);
            this.gpFirmwareUpgrade.Controls.Add(this.label23);
            this.gpFirmwareUpgrade.Controls.Add(this.label10);
            this.gpFirmwareUpgrade.Controls.Add(this.txtMcu);
            this.gpFirmwareUpgrade.Controls.Add(this.label8);
            this.gpFirmwareUpgrade.Location = new System.Drawing.Point(322, 7);
            this.gpFirmwareUpgrade.Name = "gpFirmwareUpgrade";
            this.gpFirmwareUpgrade.Size = new System.Drawing.Size(584, 139);
            this.gpFirmwareUpgrade.TabIndex = 0;
            this.gpFirmwareUpgrade.TabStop = false;
            this.gpFirmwareUpgrade.Text = "固件升级";
            // 
            // cbDistributeAddress
            // 
            this.cbDistributeAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDistributeAddress.FormattingEnabled = true;
            this.cbDistributeAddress.Location = new System.Drawing.Point(315, 101);
            this.cbDistributeAddress.Name = "cbDistributeAddress";
            this.cbDistributeAddress.Size = new System.Drawing.Size(88, 20);
            this.cbDistributeAddress.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 18;
            this.label11.Text = "程序位置:";
            // 
            // btnReadFirmwareVersion
            // 
            this.btnReadFirmwareVersion.Location = new System.Drawing.Point(474, 47);
            this.btnReadFirmwareVersion.Name = "btnReadFirmwareVersion";
            this.btnReadFirmwareVersion.Size = new System.Drawing.Size(75, 23);
            this.btnReadFirmwareVersion.TabIndex = 5;
            this.btnReadFirmwareVersion.Text = "读取版本号";
            this.btnReadFirmwareVersion.UseVisualStyleBackColor = true;
            this.btnReadFirmwareVersion.Click += new System.EventHandler(this.btnReadFirmwareVersion_Click);
            // 
            // cbAdvChip
            // 
            this.cbAdvChip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAdvChip.FormattingEnabled = true;
            this.cbAdvChip.Location = new System.Drawing.Point(79, 20);
            this.cbAdvChip.Name = "cbAdvChip";
            this.cbAdvChip.Size = new System.Drawing.Size(121, 20);
            this.cbAdvChip.TabIndex = 17;
            // 
            // btnReadbtnDistributeBoardFPGA
            // 
            this.btnReadbtnDistributeBoardFPGA.Location = new System.Drawing.Point(489, 100);
            this.btnReadbtnDistributeBoardFPGA.Name = "btnReadbtnDistributeBoardFPGA";
            this.btnReadbtnDistributeBoardFPGA.Size = new System.Drawing.Size(75, 23);
            this.btnReadbtnDistributeBoardFPGA.TabIndex = 4;
            this.btnReadbtnDistributeBoardFPGA.Text = "读取";
            this.btnReadbtnDistributeBoardFPGA.UseVisualStyleBackColor = true;
            this.btnReadbtnDistributeBoardFPGA.Click += new System.EventHandler(this.btnReadbtnDistributeBoardFPGA_Click);
            // 
            // btnReadFPGA
            // 
            this.btnReadFPGA.Location = new System.Drawing.Point(393, 73);
            this.btnReadFPGA.Name = "btnReadFPGA";
            this.btnReadFPGA.Size = new System.Drawing.Size(75, 23);
            this.btnReadFPGA.TabIndex = 4;
            this.btnReadFPGA.Text = "读取";
            this.btnReadFPGA.UseVisualStyleBackColor = true;
            this.btnReadFPGA.Click += new System.EventHandler(this.btnReadFPGA_Click);
            // 
            // btnReadMCU
            // 
            this.btnReadMCU.Location = new System.Drawing.Point(393, 46);
            this.btnReadMCU.Name = "btnReadMCU";
            this.btnReadMCU.Size = new System.Drawing.Size(75, 23);
            this.btnReadMCU.TabIndex = 4;
            this.btnReadMCU.Text = "读取";
            this.btnReadMCU.UseVisualStyleBackColor = true;
            this.btnReadMCU.Click += new System.EventHandler(this.btnReadMCU_Click);
            // 
            // btnUpdateDistributeBoardFPGA
            // 
            this.btnUpdateDistributeBoardFPGA.Location = new System.Drawing.Point(409, 100);
            this.btnUpdateDistributeBoardFPGA.Name = "btnUpdateDistributeBoardFPGA";
            this.btnUpdateDistributeBoardFPGA.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateDistributeBoardFPGA.TabIndex = 3;
            this.btnUpdateDistributeBoardFPGA.Text = "更新";
            this.btnUpdateDistributeBoardFPGA.UseVisualStyleBackColor = true;
            this.btnUpdateDistributeBoardFPGA.Click += new System.EventHandler(this.btnUpdateDistributeBoardFPGA_Click);
            // 
            // btnUpgradeFPGA
            // 
            this.btnUpgradeFPGA.Location = new System.Drawing.Point(313, 73);
            this.btnUpgradeFPGA.Name = "btnUpgradeFPGA";
            this.btnUpgradeFPGA.Size = new System.Drawing.Size(75, 23);
            this.btnUpgradeFPGA.TabIndex = 3;
            this.btnUpgradeFPGA.Text = "更新";
            this.btnUpgradeFPGA.UseVisualStyleBackColor = true;
            this.btnUpgradeFPGA.Click += new System.EventHandler(this.btnUpgradeFPGA_Click);
            // 
            // btnUpgradeMCU
            // 
            this.btnUpgradeMCU.Location = new System.Drawing.Point(313, 46);
            this.btnUpgradeMCU.Name = "btnUpgradeMCU";
            this.btnUpgradeMCU.Size = new System.Drawing.Size(75, 23);
            this.btnUpgradeMCU.TabIndex = 3;
            this.btnUpgradeMCU.Text = "更新";
            this.btnUpgradeMCU.UseVisualStyleBackColor = true;
            this.btnUpgradeMCU.Click += new System.EventHandler(this.btnUpgradeMCU_Click);
            // 
            // btnChoseDistributeBoardFPGA
            // 
            this.btnChoseDistributeBoardFPGA.Location = new System.Drawing.Point(270, 100);
            this.btnChoseDistributeBoardFPGA.Name = "btnChoseDistributeBoardFPGA";
            this.btnChoseDistributeBoardFPGA.Size = new System.Drawing.Size(39, 23);
            this.btnChoseDistributeBoardFPGA.TabIndex = 2;
            this.btnChoseDistributeBoardFPGA.Text = "...";
            this.btnChoseDistributeBoardFPGA.UseVisualStyleBackColor = true;
            this.btnChoseDistributeBoardFPGA.Click += new System.EventHandler(this.btnChoseDistributeBoardFPGA_Click);
            // 
            // btnChoseFPGA
            // 
            this.btnChoseFPGA.Location = new System.Drawing.Point(270, 73);
            this.btnChoseFPGA.Name = "btnChoseFPGA";
            this.btnChoseFPGA.Size = new System.Drawing.Size(39, 23);
            this.btnChoseFPGA.TabIndex = 2;
            this.btnChoseFPGA.Text = "...";
            this.btnChoseFPGA.UseVisualStyleBackColor = true;
            this.btnChoseFPGA.Click += new System.EventHandler(this.btnChoseFPGA_Click);
            // 
            // btnChoseMCU
            // 
            this.btnChoseMCU.Location = new System.Drawing.Point(270, 46);
            this.btnChoseMCU.Name = "btnChoseMCU";
            this.btnChoseMCU.Size = new System.Drawing.Size(39, 23);
            this.btnChoseMCU.TabIndex = 2;
            this.btnChoseMCU.Text = "...";
            this.btnChoseMCU.UseVisualStyleBackColor = true;
            this.btnChoseMCU.Click += new System.EventHandler(this.btnChoseMCU_Click);
            // 
            // txtDistributeBoardFPGA
            // 
            this.txtDistributeBoardFPGA.Location = new System.Drawing.Point(79, 100);
            this.txtDistributeBoardFPGA.Name = "txtDistributeBoardFPGA";
            this.txtDistributeBoardFPGA.Size = new System.Drawing.Size(187, 21);
            this.txtDistributeBoardFPGA.TabIndex = 1;
            this.txtDistributeBoardFPGA.Text = "C:\\Users\\Jinjianchao\\Desktop\\更新连接版FPGA\\leyard_drt_top.bin";
            // 
            // txtFPGA
            // 
            this.txtFPGA.Location = new System.Drawing.Point(79, 73);
            this.txtFPGA.Name = "txtFPGA";
            this.txtFPGA.Size = new System.Drawing.Size(187, 21);
            this.txtFPGA.TabIndex = 1;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(7, 103);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(71, 12);
            this.label23.TabIndex = 0;
            this.label23.Text = "分配板FPGA:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "灯板FPGA:";
            // 
            // txtMcu
            // 
            this.txtMcu.Location = new System.Drawing.Point(79, 46);
            this.txtMcu.Name = "txtMcu";
            this.txtMcu.Size = new System.Drawing.Size(187, 21);
            this.txtMcu.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(44, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "MCU:";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.btnRegSetDefault);
            this.tabPage1.Controls.Add(this.tabRegister);
            this.tabPage1.Controls.Add(this.btnReadReg);
            this.tabPage1.Controls.Add(this.btnSendAll);
            this.tabPage1.Controls.Add(this.cbParam2055Color);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.ckDebugMode);
            this.tabPage1.Controls.Add(this.cbRegChip);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.btnExport2055Param);
            this.tabPage1.Controls.Add(this.btnLoad2055Param);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1392, 578);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "2055寄存器设置";
            // 
            // btnRegSetDefault
            // 
            this.btnRegSetDefault.Location = new System.Drawing.Point(748, 9);
            this.btnRegSetDefault.Name = "btnRegSetDefault";
            this.btnRegSetDefault.Size = new System.Drawing.Size(75, 23);
            this.btnRegSetDefault.TabIndex = 12;
            this.btnRegSetDefault.Text = "恢复默认值";
            this.btnRegSetDefault.UseVisualStyleBackColor = true;
            this.btnRegSetDefault.Click += new System.EventHandler(this.btnRegSetDefault_Click);
            // 
            // tabRegister
            // 
            this.tabRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabRegister.Controls.Add(this.tabPage2);
            this.tabRegister.Controls.Add(this.tabPage4);
            this.tabRegister.Location = new System.Drawing.Point(0, 42);
            this.tabRegister.Name = "tabRegister";
            this.tabRegister.SelectedIndex = 0;
            this.tabRegister.Size = new System.Drawing.Size(1392, 530);
            this.tabRegister.TabIndex = 11;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grid2055);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1384, 504);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "2055寄存器";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grid2055
            // 
            this.grid2055.AllowUserToAddRows = false;
            this.grid2055.AllowUserToDeleteRows = false;
            this.grid2055.AllowUserToOrderColumns = true;
            this.grid2055.AllowUserToResizeColumns = false;
            this.grid2055.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grid2055.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.grid2055.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid2055.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CoCheckBox,
            this.ColMinValue,
            this.ColMaxValue,
            this.ColCNDescription,
            this.ColENDescription,
            this.ColDescription,
            this.ColOffset,
            this.ColRegisterAddress,
            this.ColRedAddress,
            this.ColGreenAddress,
            this.ColBlueAddress,
            this.ColStartBit,
            this.ColStopBit,
            this.ColRedValue,
            this.ColGreenValue,
            this.ColBlueValue,
            this.ColSend});
            this.grid2055.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid2055.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid2055.EnableHeadersVisualStyles = false;
            this.grid2055.Location = new System.Drawing.Point(3, 3);
            this.grid2055.MultiSelect = false;
            this.grid2055.Name = "grid2055";
            this.grid2055.RowHeadersVisible = false;
            this.grid2055.RowTemplate.Height = 23;
            this.grid2055.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid2055.Size = new System.Drawing.Size(1378, 498);
            this.grid2055.TabIndex = 0;
            this.grid2055.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grid2055_CellBeginEdit);
            this.grid2055.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid2055_CellContentClick);
            this.grid2055.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid2055_CellEnter);
            this.grid2055.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid2055_CellLeave);
            this.grid2055.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grid2055_EditingControlShowing);
            this.grid2055.Scroll += new System.Windows.Forms.ScrollEventHandler(this.grid2055_Scroll);
            // 
            // CoCheckBox
            // 
            this.CoCheckBox.DataPropertyName = "IsSelected";
            this.CoCheckBox.Frozen = true;
            this.CoCheckBox.HeaderText = "";
            this.CoCheckBox.Name = "CoCheckBox";
            this.CoCheckBox.Width = 30;
            // 
            // ColMinValue
            // 
            this.ColMinValue.DataPropertyName = "MinValue";
            this.ColMinValue.Frozen = true;
            this.ColMinValue.HeaderText = "最小值";
            this.ColMinValue.Name = "ColMinValue";
            // 
            // ColMaxValue
            // 
            this.ColMaxValue.DataPropertyName = "MaxValue";
            this.ColMaxValue.Frozen = true;
            this.ColMaxValue.HeaderText = "最大值";
            this.ColMaxValue.Name = "ColMaxValue";
            // 
            // ColCNDescription
            // 
            this.ColCNDescription.DataPropertyName = "ChineseDescription";
            this.ColCNDescription.Frozen = true;
            this.ColCNDescription.HeaderText = "描述";
            this.ColCNDescription.Name = "ColCNDescription";
            this.ColCNDescription.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColCNDescription.Width = 150;
            // 
            // ColENDescription
            // 
            this.ColENDescription.DataPropertyName = "EnglishDescription";
            this.ColENDescription.Frozen = true;
            this.ColENDescription.HeaderText = "描述";
            this.ColENDescription.Name = "ColENDescription";
            // 
            // ColDescription
            // 
            this.ColDescription.DataPropertyName = "Description";
            this.ColDescription.Frozen = true;
            this.ColDescription.HeaderText = "描述";
            this.ColDescription.Name = "ColDescription";
            // 
            // ColOffset
            // 
            this.ColOffset.DataPropertyName = "Offset";
            this.ColOffset.Frozen = true;
            this.ColOffset.HeaderText = "偏移量";
            this.ColOffset.Name = "ColOffset";
            this.ColOffset.ReadOnly = true;
            this.ColOffset.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ColRegisterAddress
            // 
            this.ColRegisterAddress.DataPropertyName = "RegisterAddress";
            this.ColRegisterAddress.Frozen = true;
            this.ColRegisterAddress.HeaderText = "寄存器地址";
            this.ColRegisterAddress.Name = "ColRegisterAddress";
            this.ColRegisterAddress.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColRedAddress
            // 
            this.ColRedAddress.DataPropertyName = "RedAddress";
            this.ColRedAddress.Frozen = true;
            this.ColRedAddress.HeaderText = "红色地址";
            this.ColRedAddress.Name = "ColRedAddress";
            // 
            // ColGreenAddress
            // 
            this.ColGreenAddress.DataPropertyName = "GreenAddress";
            this.ColGreenAddress.Frozen = true;
            this.ColGreenAddress.HeaderText = "绿色地址";
            this.ColGreenAddress.Name = "ColGreenAddress";
            // 
            // ColBlueAddress
            // 
            this.ColBlueAddress.DataPropertyName = "BlueAddress";
            this.ColBlueAddress.Frozen = true;
            this.ColBlueAddress.HeaderText = "蓝色地址";
            this.ColBlueAddress.Name = "ColBlueAddress";
            // 
            // ColStartBit
            // 
            this.ColStartBit.DataPropertyName = "StartBit";
            this.ColStartBit.Frozen = true;
            this.ColStartBit.HeaderText = "起始位";
            this.ColStartBit.Name = "ColStartBit";
            // 
            // ColStopBit
            // 
            this.ColStopBit.DataPropertyName = "StopBit";
            this.ColStopBit.Frozen = true;
            this.ColStopBit.HeaderText = "终止位";
            this.ColStopBit.Name = "ColStopBit";
            // 
            // ColRedValue
            // 
            this.ColRedValue.DataPropertyName = "RedValue";
            this.ColRedValue.Frozen = true;
            this.ColRedValue.HeaderText = "红色值";
            this.ColRedValue.Name = "ColRedValue";
            this.ColRedValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColGreenValue
            // 
            this.ColGreenValue.DataPropertyName = "GreenValue";
            this.ColGreenValue.Frozen = true;
            this.ColGreenValue.HeaderText = "绿色值";
            this.ColGreenValue.Name = "ColGreenValue";
            this.ColGreenValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColGreenValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColBlueValue
            // 
            this.ColBlueValue.DataPropertyName = "BlueValue";
            this.ColBlueValue.Frozen = true;
            this.ColBlueValue.HeaderText = "蓝色值";
            this.ColBlueValue.Name = "ColBlueValue";
            this.ColBlueValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColBlueValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColSend
            // 
            this.ColSend.DataPropertyName = "Send";
            this.ColSend.Frozen = true;
            this.ColSend.HeaderText = "";
            this.ColSend.Name = "ColSend";
            this.ColSend.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColSend.Text = "发送";
            this.ColSend.UseColumnTextForButtonValue = true;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.gridOtherReg);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1384, 504);
            this.tabPage4.TabIndex = 2;
            this.tabPage4.Text = "其它寄存器";
            // 
            // gridOtherReg
            // 
            this.gridOtherReg.AllowUserToAddRows = false;
            this.gridOtherReg.AllowUserToDeleteRows = false;
            this.gridOtherReg.AllowUserToOrderColumns = true;
            this.gridOtherReg.AllowUserToResizeColumns = false;
            this.gridOtherReg.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridOtherReg.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.gridOtherReg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOtherReg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColOtherCheckBox,
            this.ColOtherMinValue,
            this.ColOtherMaxValue,
            this.ColOtherCNDescription,
            this.ColOtherENDescription,
            this.ColOtherRegisterAddress,
            this.ColOtherStartBit,
            this.ColOtherStopBit,
            this.ColOtherValue,
            this.ColOtherSend});
            this.gridOtherReg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridOtherReg.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridOtherReg.EnableHeadersVisualStyles = false;
            this.gridOtherReg.Location = new System.Drawing.Point(3, 3);
            this.gridOtherReg.MultiSelect = false;
            this.gridOtherReg.Name = "gridOtherReg";
            this.gridOtherReg.RowHeadersVisible = false;
            this.gridOtherReg.RowTemplate.Height = 23;
            this.gridOtherReg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridOtherReg.Size = new System.Drawing.Size(1378, 498);
            this.gridOtherReg.TabIndex = 1;
            this.gridOtherReg.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridOtherReg_CellBeginEdit);
            this.gridOtherReg.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOtherReg_CellContentClick);
            this.gridOtherReg.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOtherReg_CellEnter);
            this.gridOtherReg.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOtherReg_CellLeave);
            this.gridOtherReg.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gridOtherReg_Scroll);
            // 
            // ColOtherCheckBox
            // 
            this.ColOtherCheckBox.DataPropertyName = "IsSelected";
            this.ColOtherCheckBox.Frozen = true;
            this.ColOtherCheckBox.HeaderText = "";
            this.ColOtherCheckBox.Name = "ColOtherCheckBox";
            this.ColOtherCheckBox.Width = 30;
            // 
            // ColOtherMinValue
            // 
            this.ColOtherMinValue.DataPropertyName = "MinValue";
            this.ColOtherMinValue.Frozen = true;
            this.ColOtherMinValue.HeaderText = "最小值";
            this.ColOtherMinValue.Name = "ColOtherMinValue";
            this.ColOtherMinValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColOtherMinValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColOtherMaxValue
            // 
            this.ColOtherMaxValue.DataPropertyName = "MaxValue";
            this.ColOtherMaxValue.Frozen = true;
            this.ColOtherMaxValue.HeaderText = "最大值";
            this.ColOtherMaxValue.Name = "ColOtherMaxValue";
            this.ColOtherMaxValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColOtherMaxValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColOtherCNDescription
            // 
            this.ColOtherCNDescription.DataPropertyName = "ChineseDescription";
            this.ColOtherCNDescription.Frozen = true;
            this.ColOtherCNDescription.HeaderText = "描述";
            this.ColOtherCNDescription.Name = "ColOtherCNDescription";
            this.ColOtherCNDescription.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColOtherCNDescription.Width = 150;
            // 
            // ColOtherENDescription
            // 
            this.ColOtherENDescription.DataPropertyName = "EnglishDescription";
            this.ColOtherENDescription.Frozen = true;
            this.ColOtherENDescription.HeaderText = "描述";
            this.ColOtherENDescription.Name = "ColOtherENDescription";
            // 
            // ColOtherRegisterAddress
            // 
            this.ColOtherRegisterAddress.DataPropertyName = "Address";
            this.ColOtherRegisterAddress.Frozen = true;
            this.ColOtherRegisterAddress.HeaderText = "地址";
            this.ColOtherRegisterAddress.Name = "ColOtherRegisterAddress";
            // 
            // ColOtherStartBit
            // 
            this.ColOtherStartBit.DataPropertyName = "StartBit";
            this.ColOtherStartBit.Frozen = true;
            this.ColOtherStartBit.HeaderText = "起始位";
            this.ColOtherStartBit.Name = "ColOtherStartBit";
            // 
            // ColOtherStopBit
            // 
            this.ColOtherStopBit.DataPropertyName = "StopBit";
            this.ColOtherStopBit.Frozen = true;
            this.ColOtherStopBit.HeaderText = "终止位";
            this.ColOtherStopBit.Name = "ColOtherStopBit";
            // 
            // ColOtherValue
            // 
            this.ColOtherValue.DataPropertyName = "Value";
            this.ColOtherValue.Frozen = true;
            this.ColOtherValue.HeaderText = "值";
            this.ColOtherValue.Name = "ColOtherValue";
            this.ColOtherValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColOtherSend
            // 
            this.ColOtherSend.DataPropertyName = "Send";
            this.ColOtherSend.Frozen = true;
            this.ColOtherSend.HeaderText = "";
            this.ColOtherSend.Name = "ColOtherSend";
            this.ColOtherSend.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColOtherSend.Text = "发送";
            this.ColOtherSend.UseColumnTextForButtonValue = true;
            // 
            // btnReadReg
            // 
            this.btnReadReg.Location = new System.Drawing.Point(666, 8);
            this.btnReadReg.Name = "btnReadReg";
            this.btnReadReg.Size = new System.Drawing.Size(75, 23);
            this.btnReadReg.TabIndex = 10;
            this.btnReadReg.Text = "读取";
            this.btnReadReg.UseVisualStyleBackColor = true;
            this.btnReadReg.Click += new System.EventHandler(this.btnReadReg_Click);
            // 
            // btnSendAll
            // 
            this.btnSendAll.Location = new System.Drawing.Point(584, 7);
            this.btnSendAll.Name = "btnSendAll";
            this.btnSendAll.Size = new System.Drawing.Size(75, 23);
            this.btnSendAll.TabIndex = 8;
            this.btnSendAll.Text = "全部设置";
            this.btnSendAll.UseVisualStyleBackColor = true;
            this.btnSendAll.Click += new System.EventHandler(this.btnSendAll_Click);
            // 
            // cbParam2055Color
            // 
            this.cbParam2055Color.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParam2055Color.FormattingEnabled = true;
            this.cbParam2055Color.Location = new System.Drawing.Point(391, 9);
            this.cbParam2055Color.Name = "cbParam2055Color";
            this.cbParam2055Color.Size = new System.Drawing.Size(97, 20);
            this.cbParam2055Color.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(344, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "颜色：";
            // 
            // ckDebugMode
            // 
            this.ckDebugMode.AutoSize = true;
            this.ckDebugMode.Checked = true;
            this.ckDebugMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckDebugMode.Location = new System.Drawing.Point(506, 10);
            this.ckDebugMode.Name = "ckDebugMode";
            this.ckDebugMode.Size = new System.Drawing.Size(72, 16);
            this.ckDebugMode.TabIndex = 5;
            this.ckDebugMode.Text = "调试模式";
            this.ckDebugMode.UseVisualStyleBackColor = true;
            // 
            // cbRegChip
            // 
            this.cbRegChip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegChip.FormattingEnabled = true;
            this.cbRegChip.Items.AddRange(new object[] {
            "50Hz",
            "60Hz"});
            this.cbRegChip.Location = new System.Drawing.Point(230, 8);
            this.cbRegChip.Name = "cbRegChip";
            this.cbRegChip.Size = new System.Drawing.Size(97, 20);
            this.cbRegChip.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(184, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 3;
            this.label14.Text = "器件：";
            // 
            // btnExport2055Param
            // 
            this.btnExport2055Param.Location = new System.Drawing.Point(90, 6);
            this.btnExport2055Param.Name = "btnExport2055Param";
            this.btnExport2055Param.Size = new System.Drawing.Size(75, 23);
            this.btnExport2055Param.TabIndex = 2;
            this.btnExport2055Param.Text = "导出";
            this.btnExport2055Param.UseVisualStyleBackColor = true;
            this.btnExport2055Param.Click += new System.EventHandler(this.btnExport2055Param_Click);
            // 
            // btnLoad2055Param
            // 
            this.btnLoad2055Param.Location = new System.Drawing.Point(9, 6);
            this.btnLoad2055Param.Name = "btnLoad2055Param";
            this.btnLoad2055Param.Size = new System.Drawing.Size(75, 23);
            this.btnLoad2055Param.TabIndex = 1;
            this.btnLoad2055Param.Text = "导入";
            this.btnLoad2055Param.UseVisualStyleBackColor = true;
            this.btnLoad2055Param.Click += new System.EventHandler(this.btnLoad2055Param_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.button7);
            this.tabPage3.Controls.Add(this.tabControl1);
            this.tabPage3.Controls.Add(this.button8);
            this.tabPage3.Controls.Add(this.button9);
            this.tabPage3.Controls.Add(this.comboBox1);
            this.tabPage3.Controls.Add(this.label24);
            this.tabPage3.Controls.Add(this.checkBox1);
            this.tabPage3.Controls.Add(this.comboBox2);
            this.tabPage3.Controls.Add(this.label25);
            this.tabPage3.Controls.Add(this.btnExport2072);
            this.tabPage3.Controls.Add(this.btnImport2072);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1392, 578);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Text = "2072寄存器设置";
            // 
            // tabTest
            // 
            this.tabTest.BackColor = System.Drawing.SystemColors.Control;
            this.tabTest.Controls.Add(this.groupBox3);
            this.tabTest.Location = new System.Drawing.Point(4, 22);
            this.tabTest.Name = "tabTest";
            this.tabTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabTest.Size = new System.Drawing.Size(1392, 578);
            this.tabTest.TabIndex = 1;
            this.tabTest.Text = "测试页";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.groupBox14);
            this.groupBox3.Controls.Add(this.groupBox13);
            this.groupBox3.Controls.Add(this.groupBox12);
            this.groupBox3.Controls.Add(this.groupBox11);
            this.groupBox3.Controls.Add(this.groupBox10);
            this.groupBox3.Controls.Add(this.groupBox8);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cbChipPos);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.gpTest);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1376, 564);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "FLASH操作";
            // 
            // groupBox14
            // 
            this.groupBox14.Location = new System.Drawing.Point(859, 143);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(472, 121);
            this.groupBox14.TabIndex = 23;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "分配板测试";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.txtCompareFile2);
            this.groupBox13.Controls.Add(this.label22);
            this.groupBox13.Controls.Add(this.txtCompareFile1);
            this.groupBox13.Controls.Add(this.label21);
            this.groupBox13.Controls.Add(this.rtCompare);
            this.groupBox13.Controls.Add(this.btnCompareChose2);
            this.groupBox13.Controls.Add(this.btnCompare);
            this.groupBox13.Controls.Add(this.btnCompareChose1);
            this.groupBox13.Location = new System.Drawing.Point(6, 284);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(621, 274);
            this.groupBox13.TabIndex = 22;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "文件比较(空格分割的16进制字节数据)";
            // 
            // txtCompareFile2
            // 
            this.txtCompareFile2.Location = new System.Drawing.Point(322, 21);
            this.txtCompareFile2.Name = "txtCompareFile2";
            this.txtCompareFile2.Size = new System.Drawing.Size(168, 21);
            this.txtCompareFile2.TabIndex = 8;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(277, 25);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 12);
            this.label22.TabIndex = 7;
            this.label22.Text = "文件2:";
            // 
            // txtCompareFile1
            // 
            this.txtCompareFile1.Location = new System.Drawing.Point(52, 21);
            this.txtCompareFile1.Name = "txtCompareFile1";
            this.txtCompareFile1.Size = new System.Drawing.Size(168, 21);
            this.txtCompareFile1.TabIndex = 8;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 25);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 12);
            this.label21.TabIndex = 7;
            this.label21.Text = "文件1:";
            // 
            // rtCompare
            // 
            this.rtCompare.Location = new System.Drawing.Point(8, 50);
            this.rtCompare.Name = "rtCompare";
            this.rtCompare.Size = new System.Drawing.Size(607, 218);
            this.rtCompare.TabIndex = 1;
            this.rtCompare.Text = "";
            // 
            // btnCompareChose2
            // 
            this.btnCompareChose2.Location = new System.Drawing.Point(496, 20);
            this.btnCompareChose2.Name = "btnCompareChose2";
            this.btnCompareChose2.Size = new System.Drawing.Size(39, 23);
            this.btnCompareChose2.TabIndex = 7;
            this.btnCompareChose2.Text = "...";
            this.btnCompareChose2.UseVisualStyleBackColor = true;
            this.btnCompareChose2.Click += new System.EventHandler(this.btnCompareChose2_Click);
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(540, 20);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 23);
            this.btnCompare.TabIndex = 0;
            this.btnCompare.Text = "比较";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnCompareChose1
            // 
            this.btnCompareChose1.Location = new System.Drawing.Point(226, 20);
            this.btnCompareChose1.Name = "btnCompareChose1";
            this.btnCompareChose1.Size = new System.Drawing.Size(39, 23);
            this.btnCompareChose1.TabIndex = 7;
            this.btnCompareChose1.Text = "...";
            this.btnCompareChose1.UseVisualStyleBackColor = true;
            this.btnCompareChose1.Click += new System.EventHandler(this.btnCompareChose1_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.txtBatchCalibrationFolder);
            this.groupBox12.Controls.Add(this.btnBatchWriteCalibration);
            this.groupBox12.Controls.Add(this.label20);
            this.groupBox12.Controls.Add(this.btnSelectBatchCalibrationFolder);
            this.groupBox12.Location = new System.Drawing.Point(6, 201);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(351, 63);
            this.groupBox12.TabIndex = 21;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "校正数据批量写入";
            // 
            // txtBatchCalibrationFolder
            // 
            this.txtBatchCalibrationFolder.Location = new System.Drawing.Point(50, 20);
            this.txtBatchCalibrationFolder.Name = "txtBatchCalibrationFolder";
            this.txtBatchCalibrationFolder.Size = new System.Drawing.Size(168, 21);
            this.txtBatchCalibrationFolder.TabIndex = 15;
            this.txtBatchCalibrationFolder.Text = "D:\\tmp\\校正数据\\主色";
            // 
            // btnBatchWriteCalibration
            // 
            this.btnBatchWriteCalibration.Location = new System.Drawing.Point(266, 19);
            this.btnBatchWriteCalibration.Name = "btnBatchWriteCalibration";
            this.btnBatchWriteCalibration.Size = new System.Drawing.Size(75, 23);
            this.btnBatchWriteCalibration.TabIndex = 17;
            this.btnBatchWriteCalibration.Text = "写入";
            this.btnBatchWriteCalibration.UseVisualStyleBackColor = true;
            this.btnBatchWriteCalibration.Click += new System.EventHandler(this.btnBatchWriteCalibration_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 24);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 12);
            this.label20.TabIndex = 14;
            this.label20.Text = "文件夹:";
            // 
            // btnSelectBatchCalibrationFolder
            // 
            this.btnSelectBatchCalibrationFolder.Location = new System.Drawing.Point(221, 19);
            this.btnSelectBatchCalibrationFolder.Name = "btnSelectBatchCalibrationFolder";
            this.btnSelectBatchCalibrationFolder.Size = new System.Drawing.Size(39, 23);
            this.btnSelectBatchCalibrationFolder.TabIndex = 16;
            this.btnSelectBatchCalibrationFolder.Text = "...";
            this.btnSelectBatchCalibrationFolder.UseVisualStyleBackColor = true;
            this.btnSelectBatchCalibrationFolder.Click += new System.EventHandler(this.btnSelectBatchCalibrationFolder_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.cbCalibrationOnOff);
            this.groupBox11.Controls.Add(this.btnSendCalibrationOnOff);
            this.groupBox11.Location = new System.Drawing.Point(363, 201);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(232, 63);
            this.groupBox11.TabIndex = 20;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "校正开关";
            // 
            // cbCalibrationOnOff
            // 
            this.cbCalibrationOnOff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCalibrationOnOff.FormattingEnabled = true;
            this.cbCalibrationOnOff.Location = new System.Drawing.Point(12, 26);
            this.cbCalibrationOnOff.Name = "cbCalibrationOnOff";
            this.cbCalibrationOnOff.Size = new System.Drawing.Size(121, 20);
            this.cbCalibrationOnOff.TabIndex = 20;
            // 
            // btnSendCalibrationOnOff
            // 
            this.btnSendCalibrationOnOff.Location = new System.Drawing.Point(139, 23);
            this.btnSendCalibrationOnOff.Name = "btnSendCalibrationOnOff";
            this.btnSendCalibrationOnOff.Size = new System.Drawing.Size(75, 23);
            this.btnSendCalibrationOnOff.TabIndex = 1;
            this.btnSendCalibrationOnOff.Text = "发送";
            this.btnSendCalibrationOnOff.UseVisualStyleBackColor = true;
            this.btnSendCalibrationOnOff.Click += new System.EventHandler(this.btnSendCalibrationOnOff_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.button5);
            this.groupBox10.Controls.Add(this.cbWorkMode);
            this.groupBox10.Location = new System.Drawing.Point(601, 210);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(252, 54);
            this.groupBox10.TabIndex = 19;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "工装切换";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(152, 18);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 20;
            this.button5.Text = "加载";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // cbWorkMode
            // 
            this.cbWorkMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWorkMode.FormattingEnabled = true;
            this.cbWorkMode.Location = new System.Drawing.Point(24, 19);
            this.cbWorkMode.Name = "cbWorkMode";
            this.cbWorkMode.Size = new System.Drawing.Size(121, 20);
            this.cbWorkMode.TabIndex = 19;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.button6);
            this.groupBox8.Controls.Add(this.btnSDRAMToFlash);
            this.groupBox8.Controls.Add(this.btnSetB6B7);
            this.groupBox8.Controls.Add(this.btnOpenCalibration);
            this.groupBox8.Controls.Add(this.btnUpgradeCalibration);
            this.groupBox8.Controls.Add(this.txtCalibration);
            this.groupBox8.Controls.Add(this.label17);
            this.groupBox8.Location = new System.Drawing.Point(6, 139);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(621, 55);
            this.groupBox8.TabIndex = 18;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "校正数据读,写";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(226, 16);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(39, 23);
            this.button6.TabIndex = 17;
            this.button6.Text = "...";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnSDRAMToFlash
            // 
            this.btnSDRAMToFlash.Location = new System.Drawing.Point(514, 17);
            this.btnSDRAMToFlash.Name = "btnSDRAMToFlash";
            this.btnSDRAMToFlash.Size = new System.Drawing.Size(102, 23);
            this.btnSDRAMToFlash.TabIndex = 13;
            this.btnSDRAMToFlash.Text = "SDRAM->FLASH";
            this.btnSDRAMToFlash.UseVisualStyleBackColor = true;
            this.btnSDRAMToFlash.Click += new System.EventHandler(this.btnSDRAMToFlash_Click);
            // 
            // btnSetB6B7
            // 
            this.btnSetB6B7.Location = new System.Drawing.Point(426, 17);
            this.btnSetB6B7.Name = "btnSetB6B7";
            this.btnSetB6B7.Size = new System.Drawing.Size(87, 23);
            this.btnSetB6B7.TabIndex = 12;
            this.btnSetB6B7.Text = "设置数据长度";
            this.btnSetB6B7.UseVisualStyleBackColor = true;
            this.btnSetB6B7.Click += new System.EventHandler(this.btnSetB6B7_Click);
            // 
            // btnOpenCalibration
            // 
            this.btnOpenCalibration.Enabled = false;
            this.btnOpenCalibration.Location = new System.Drawing.Point(346, 17);
            this.btnOpenCalibration.Name = "btnOpenCalibration";
            this.btnOpenCalibration.Size = new System.Drawing.Size(75, 23);
            this.btnOpenCalibration.TabIndex = 11;
            this.btnOpenCalibration.Text = "开启校正";
            this.btnOpenCalibration.UseVisualStyleBackColor = true;
            this.btnOpenCalibration.Click += new System.EventHandler(this.btnOpenCalibration_Click);
            // 
            // btnUpgradeCalibration
            // 
            this.btnUpgradeCalibration.Location = new System.Drawing.Point(267, 17);
            this.btnUpgradeCalibration.Name = "btnUpgradeCalibration";
            this.btnUpgradeCalibration.Size = new System.Drawing.Size(75, 23);
            this.btnUpgradeCalibration.TabIndex = 8;
            this.btnUpgradeCalibration.Text = "写入";
            this.btnUpgradeCalibration.UseVisualStyleBackColor = true;
            this.btnUpgradeCalibration.Click += new System.EventHandler(this.btnUpgradeCalibration_Click);
            // 
            // txtCalibration
            // 
            this.txtCalibration.Location = new System.Drawing.Point(50, 18);
            this.txtCalibration.Name = "txtCalibration";
            this.txtCalibration.Size = new System.Drawing.Size(168, 21);
            this.txtCalibration.TabIndex = 6;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(15, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 12);
            this.label17.TabIndex = 5;
            this.label17.Text = "文件:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnLoadVideoCardParam);
            this.groupBox4.Controls.Add(this.cbVideocardLoadParam);
            this.groupBox4.Location = new System.Drawing.Point(633, 139);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(220, 55);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "视频卡加载参数";
            // 
            // btnLoadVideoCardParam
            // 
            this.btnLoadVideoCardParam.Location = new System.Drawing.Point(136, 20);
            this.btnLoadVideoCardParam.Name = "btnLoadVideoCardParam";
            this.btnLoadVideoCardParam.Size = new System.Drawing.Size(75, 23);
            this.btnLoadVideoCardParam.TabIndex = 18;
            this.btnLoadVideoCardParam.Text = "加载";
            this.btnLoadVideoCardParam.UseVisualStyleBackColor = true;
            this.btnLoadVideoCardParam.Click += new System.EventHandler(this.btnLoadVideoCardParam_Click);
            // 
            // cbVideocardLoadParam
            // 
            this.cbVideocardLoadParam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideocardLoadParam.FormattingEnabled = true;
            this.cbVideocardLoadParam.Location = new System.Drawing.Point(8, 20);
            this.cbVideocardLoadParam.Name = "cbVideocardLoadParam";
            this.cbVideocardLoadParam.Size = new System.Drawing.Size(121, 20);
            this.cbVideocardLoadParam.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "芯片位置:";
            // 
            // cbChipPos
            // 
            this.cbChipPos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChipPos.FormattingEnabled = true;
            this.cbChipPos.Location = new System.Drawing.Point(95, 20);
            this.cbChipPos.Name = "cbChipPos";
            this.cbChipPos.Size = new System.Drawing.Size(121, 20);
            this.cbChipPos.TabIndex = 15;
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
            99999999,
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
            this.numRegAddr.Hexadecimal = true;
            this.numRegAddr.Location = new System.Drawing.Point(89, 20);
            this.numRegAddr.Maximum = new decimal(new int[] {
            1215752191,
            23,
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnReadSDRAM);
            this.groupBox2.Controls.Add(this.btnSDRAMWriteToFlash);
            this.groupBox2.Controls.Add(this.btnCreateAndWriteSDRAM);
            this.groupBox2.Controls.Add(this.numSDRAMDataLength);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.numSDRAMAddr);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(266, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(361, 84);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "读写SDRAN";
            // 
            // btnReadSDRAM
            // 
            this.btnReadSDRAM.Location = new System.Drawing.Point(156, 48);
            this.btnReadSDRAM.Name = "btnReadSDRAM";
            this.btnReadSDRAM.Size = new System.Drawing.Size(88, 23);
            this.btnReadSDRAM.TabIndex = 3;
            this.btnReadSDRAM.Text = "读取SDRAM";
            this.btnReadSDRAM.UseVisualStyleBackColor = true;
            this.btnReadSDRAM.Click += new System.EventHandler(this.btnReadSDRAM_Click);
            // 
            // btnSDRAMWriteToFlash
            // 
            this.btnSDRAMWriteToFlash.Location = new System.Drawing.Point(250, 19);
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
            999999999,
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
            this.numSDRAMAddr.Hexadecimal = true;
            this.numSDRAMAddr.Location = new System.Drawing.Point(89, 20);
            this.numSDRAMAddr.Maximum = new decimal(new int[] {
            1215752191,
            23,
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
            // gpTest
            // 
            this.gpTest.Controls.Add(this.button4);
            this.gpTest.Controls.Add(this.button3);
            this.gpTest.Controls.Add(this.btnWriteSdramReadSdram);
            this.gpTest.Controls.Add(this.btnReadAndWriteFlash);
            this.gpTest.Controls.Add(this.btnTest3);
            this.gpTest.Controls.Add(this.btnReadWriteSend);
            this.gpTest.Controls.Add(this.label5);
            this.gpTest.Controls.Add(this.numTestDataLen);
            this.gpTest.Controls.Add(this.label6);
            this.gpTest.Controls.Add(this.button1);
            this.gpTest.Controls.Add(this.numTimeDelay);
            this.gpTest.Controls.Add(this.button2);
            this.gpTest.Location = new System.Drawing.Point(633, 49);
            this.gpTest.Name = "gpTest";
            this.gpTest.Size = new System.Drawing.Size(698, 84);
            this.gpTest.TabIndex = 9;
            this.gpTest.TabStop = false;
            this.gpTest.Text = "稳定性测试";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(448, 50);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "版本批量读取";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(589, 21);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "批量更新FPGA";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnWriteSdramReadSdram
            // 
            this.btnWriteSdramReadSdram.Location = new System.Drawing.Point(472, 21);
            this.btnWriteSdramReadSdram.Name = "btnWriteSdramReadSdram";
            this.btnWriteSdramReadSdram.Size = new System.Drawing.Size(110, 23);
            this.btnWriteSdramReadSdram.TabIndex = 9;
            this.btnWriteSdramReadSdram.Text = "写SDRAM->读SDRAM";
            this.btnWriteSdramReadSdram.UseVisualStyleBackColor = true;
            this.btnWriteSdramReadSdram.Click += new System.EventHandler(this.btnWriteSdramReadSdram_Click);
            // 
            // btnReadAndWriteFlash
            // 
            this.btnReadAndWriteFlash.Location = new System.Drawing.Point(349, 21);
            this.btnReadAndWriteFlash.Name = "btnReadAndWriteFlash";
            this.btnReadAndWriteFlash.Size = new System.Drawing.Size(113, 23);
            this.btnReadAndWriteFlash.TabIndex = 8;
            this.btnReadAndWriteFlash.Text = "写flash->读flash";
            this.btnReadAndWriteFlash.UseVisualStyleBackColor = true;
            this.btnReadAndWriteFlash.Click += new System.EventHandler(this.btnReadAndWriteFlash_Click);
            // 
            // btnTest3
            // 
            this.btnTest3.Location = new System.Drawing.Point(261, 50);
            this.btnTest3.Name = "btnTest3";
            this.btnTest3.Size = new System.Drawing.Size(181, 23);
            this.btnTest3.TabIndex = 7;
            this.btnTest3.Text = "写SDRAM->写FLASH->读FLASH";
            this.btnTest3.UseVisualStyleBackColor = true;
            this.btnTest3.Click += new System.EventHandler(this.btnTest3_Click);
            // 
            // btnReadWriteSend
            // 
            this.btnReadWriteSend.Location = new System.Drawing.Point(130, 50);
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
            this.button1.Location = new System.Drawing.Point(11, 50);
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
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(748, 9);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 23;
            this.button7.Text = "恢复默认值";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(0, 42);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1392, 530);
            this.tabControl1.TabIndex = 22;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.grid2072);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1384, 504);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "2072寄存器";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // grid2072
            // 
            this.grid2072.AllowUserToAddRows = false;
            this.grid2072.AllowUserToDeleteRows = false;
            this.grid2072.AllowUserToOrderColumns = true;
            this.grid2072.AllowUserToResizeColumns = false;
            this.grid2072.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grid2072.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.grid2072.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid2072.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewLabelXColumn1,
            this.dataGridViewLabelXColumn2,
            this.dataGridViewLabelXColumn3,
            this.dataGridViewLabelXColumn4,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewLabelXColumn5,
            this.dataGridViewLabelXColumn6,
            this.dataGridViewLabelXColumn7,
            this.dataGridViewLabelXColumn8,
            this.dataGridViewLabelXColumn9,
            this.dataGridViewLabelXColumn10,
            this.dataGridViewLabelXColumn11,
            this.dataGridViewLabelXColumn12,
            this.dataGridViewButtonColumn1});
            this.grid2072.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid2072.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid2072.EnableHeadersVisualStyles = false;
            this.grid2072.Location = new System.Drawing.Point(3, 3);
            this.grid2072.MultiSelect = false;
            this.grid2072.Name = "grid2072";
            this.grid2072.RowHeadersVisible = false;
            this.grid2072.RowTemplate.Height = 23;
            this.grid2072.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid2072.Size = new System.Drawing.Size(1378, 498);
            this.grid2072.TabIndex = 0;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "IsSelected";
            this.dataGridViewCheckBoxColumn1.Frozen = true;
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MinValue";
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "最小值";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MaxValue";
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "最大值";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewLabelXColumn1
            // 
            this.dataGridViewLabelXColumn1.DataPropertyName = "ChineseDescription";
            this.dataGridViewLabelXColumn1.Frozen = true;
            this.dataGridViewLabelXColumn1.HeaderText = "描述";
            this.dataGridViewLabelXColumn1.Name = "dataGridViewLabelXColumn1";
            this.dataGridViewLabelXColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLabelXColumn1.Width = 150;
            // 
            // dataGridViewLabelXColumn2
            // 
            this.dataGridViewLabelXColumn2.DataPropertyName = "EnglishDescription";
            this.dataGridViewLabelXColumn2.Frozen = true;
            this.dataGridViewLabelXColumn2.HeaderText = "描述";
            this.dataGridViewLabelXColumn2.Name = "dataGridViewLabelXColumn2";
            // 
            // dataGridViewLabelXColumn3
            // 
            this.dataGridViewLabelXColumn3.DataPropertyName = "Description";
            this.dataGridViewLabelXColumn3.Frozen = true;
            this.dataGridViewLabelXColumn3.HeaderText = "描述";
            this.dataGridViewLabelXColumn3.Name = "dataGridViewLabelXColumn3";
            // 
            // dataGridViewLabelXColumn4
            // 
            this.dataGridViewLabelXColumn4.DataPropertyName = "Offset";
            this.dataGridViewLabelXColumn4.Frozen = true;
            this.dataGridViewLabelXColumn4.HeaderText = "偏移量";
            this.dataGridViewLabelXColumn4.Name = "dataGridViewLabelXColumn4";
            this.dataGridViewLabelXColumn4.ReadOnly = true;
            this.dataGridViewLabelXColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "RegisterAddress";
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "寄存器地址";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewLabelXColumn5
            // 
            this.dataGridViewLabelXColumn5.DataPropertyName = "RedAddress";
            this.dataGridViewLabelXColumn5.Frozen = true;
            this.dataGridViewLabelXColumn5.HeaderText = "红色地址";
            this.dataGridViewLabelXColumn5.Name = "dataGridViewLabelXColumn5";
            // 
            // dataGridViewLabelXColumn6
            // 
            this.dataGridViewLabelXColumn6.DataPropertyName = "GreenAddress";
            this.dataGridViewLabelXColumn6.Frozen = true;
            this.dataGridViewLabelXColumn6.HeaderText = "绿色地址";
            this.dataGridViewLabelXColumn6.Name = "dataGridViewLabelXColumn6";
            // 
            // dataGridViewLabelXColumn7
            // 
            this.dataGridViewLabelXColumn7.DataPropertyName = "BlueAddress";
            this.dataGridViewLabelXColumn7.Frozen = true;
            this.dataGridViewLabelXColumn7.HeaderText = "蓝色地址";
            this.dataGridViewLabelXColumn7.Name = "dataGridViewLabelXColumn7";
            // 
            // dataGridViewLabelXColumn8
            // 
            this.dataGridViewLabelXColumn8.DataPropertyName = "StartBit";
            this.dataGridViewLabelXColumn8.Frozen = true;
            this.dataGridViewLabelXColumn8.HeaderText = "起始位";
            this.dataGridViewLabelXColumn8.Name = "dataGridViewLabelXColumn8";
            // 
            // dataGridViewLabelXColumn9
            // 
            this.dataGridViewLabelXColumn9.DataPropertyName = "StopBit";
            this.dataGridViewLabelXColumn9.Frozen = true;
            this.dataGridViewLabelXColumn9.HeaderText = "终止位";
            this.dataGridViewLabelXColumn9.Name = "dataGridViewLabelXColumn9";
            // 
            // dataGridViewLabelXColumn10
            // 
            this.dataGridViewLabelXColumn10.DataPropertyName = "RedValue";
            this.dataGridViewLabelXColumn10.Frozen = true;
            this.dataGridViewLabelXColumn10.HeaderText = "红色值";
            this.dataGridViewLabelXColumn10.Name = "dataGridViewLabelXColumn10";
            this.dataGridViewLabelXColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewLabelXColumn11
            // 
            this.dataGridViewLabelXColumn11.DataPropertyName = "GreenValue";
            this.dataGridViewLabelXColumn11.Frozen = true;
            this.dataGridViewLabelXColumn11.HeaderText = "绿色值";
            this.dataGridViewLabelXColumn11.Name = "dataGridViewLabelXColumn11";
            this.dataGridViewLabelXColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLabelXColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewLabelXColumn12
            // 
            this.dataGridViewLabelXColumn12.DataPropertyName = "BlueValue";
            this.dataGridViewLabelXColumn12.Frozen = true;
            this.dataGridViewLabelXColumn12.HeaderText = "蓝色值";
            this.dataGridViewLabelXColumn12.Name = "dataGridViewLabelXColumn12";
            this.dataGridViewLabelXColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLabelXColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.DataPropertyName = "Send";
            this.dataGridViewButtonColumn1.Frozen = true;
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn1.Text = "发送";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage6.Controls.Add(this.grid2072Other);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1384, 504);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "其它寄存器";
            // 
            // grid2072Other
            // 
            this.grid2072Other.AllowUserToAddRows = false;
            this.grid2072Other.AllowUserToDeleteRows = false;
            this.grid2072Other.AllowUserToOrderColumns = true;
            this.grid2072Other.AllowUserToResizeColumns = false;
            this.grid2072Other.AllowUserToResizeRows = false;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grid2072Other.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle12;
            this.grid2072Other.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid2072Other.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewLabelXColumn13,
            this.dataGridViewLabelXColumn14,
            this.dataGridViewLabelXColumn15,
            this.dataGridViewLabelXColumn16,
            this.dataGridViewLabelXColumn17,
            this.dataGridViewLabelXColumn18,
            this.dataGridViewLabelXColumn19,
            this.dataGridViewLabelXColumn20,
            this.dataGridViewButtonColumn2});
            this.grid2072Other.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid2072Other.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid2072Other.EnableHeadersVisualStyles = false;
            this.grid2072Other.Location = new System.Drawing.Point(3, 3);
            this.grid2072Other.MultiSelect = false;
            this.grid2072Other.Name = "grid2072Other";
            this.grid2072Other.RowHeadersVisible = false;
            this.grid2072Other.RowTemplate.Height = 23;
            this.grid2072Other.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid2072Other.Size = new System.Drawing.Size(1378, 498);
            this.grid2072Other.TabIndex = 1;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "IsSelected";
            this.dataGridViewCheckBoxColumn2.Frozen = true;
            this.dataGridViewCheckBoxColumn2.HeaderText = "";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Width = 30;
            // 
            // dataGridViewLabelXColumn13
            // 
            this.dataGridViewLabelXColumn13.DataPropertyName = "MinValue";
            this.dataGridViewLabelXColumn13.Frozen = true;
            this.dataGridViewLabelXColumn13.HeaderText = "最小值";
            this.dataGridViewLabelXColumn13.Name = "dataGridViewLabelXColumn13";
            this.dataGridViewLabelXColumn13.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLabelXColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewLabelXColumn14
            // 
            this.dataGridViewLabelXColumn14.DataPropertyName = "MaxValue";
            this.dataGridViewLabelXColumn14.Frozen = true;
            this.dataGridViewLabelXColumn14.HeaderText = "最大值";
            this.dataGridViewLabelXColumn14.Name = "dataGridViewLabelXColumn14";
            this.dataGridViewLabelXColumn14.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLabelXColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewLabelXColumn15
            // 
            this.dataGridViewLabelXColumn15.DataPropertyName = "ChineseDescription";
            this.dataGridViewLabelXColumn15.Frozen = true;
            this.dataGridViewLabelXColumn15.HeaderText = "描述";
            this.dataGridViewLabelXColumn15.Name = "dataGridViewLabelXColumn15";
            this.dataGridViewLabelXColumn15.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLabelXColumn15.Width = 150;
            // 
            // dataGridViewLabelXColumn16
            // 
            this.dataGridViewLabelXColumn16.DataPropertyName = "EnglishDescription";
            this.dataGridViewLabelXColumn16.Frozen = true;
            this.dataGridViewLabelXColumn16.HeaderText = "描述";
            this.dataGridViewLabelXColumn16.Name = "dataGridViewLabelXColumn16";
            // 
            // dataGridViewLabelXColumn17
            // 
            this.dataGridViewLabelXColumn17.DataPropertyName = "Address";
            this.dataGridViewLabelXColumn17.Frozen = true;
            this.dataGridViewLabelXColumn17.HeaderText = "地址";
            this.dataGridViewLabelXColumn17.Name = "dataGridViewLabelXColumn17";
            // 
            // dataGridViewLabelXColumn18
            // 
            this.dataGridViewLabelXColumn18.DataPropertyName = "StartBit";
            this.dataGridViewLabelXColumn18.Frozen = true;
            this.dataGridViewLabelXColumn18.HeaderText = "起始位";
            this.dataGridViewLabelXColumn18.Name = "dataGridViewLabelXColumn18";
            // 
            // dataGridViewLabelXColumn19
            // 
            this.dataGridViewLabelXColumn19.DataPropertyName = "StopBit";
            this.dataGridViewLabelXColumn19.Frozen = true;
            this.dataGridViewLabelXColumn19.HeaderText = "终止位";
            this.dataGridViewLabelXColumn19.Name = "dataGridViewLabelXColumn19";
            // 
            // dataGridViewLabelXColumn20
            // 
            this.dataGridViewLabelXColumn20.DataPropertyName = "Value";
            this.dataGridViewLabelXColumn20.Frozen = true;
            this.dataGridViewLabelXColumn20.HeaderText = "值";
            this.dataGridViewLabelXColumn20.Name = "dataGridViewLabelXColumn20";
            this.dataGridViewLabelXColumn20.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.DataPropertyName = "Send";
            this.dataGridViewButtonColumn2.Frozen = true;
            this.dataGridViewButtonColumn2.HeaderText = "";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn2.Text = "发送";
            this.dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(666, 8);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 21;
            this.button8.Text = "读取";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(584, 7);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "全部设置";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(391, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(97, 20);
            this.comboBox1.TabIndex = 19;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(344, 11);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 12);
            this.label24.TabIndex = 18;
            this.label24.Text = "颜色：";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(506, 10);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "调试模式";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "50Hz",
            "60Hz"});
            this.comboBox2.Location = new System.Drawing.Point(230, 8);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(97, 20);
            this.comboBox2.TabIndex = 16;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(184, 12);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 12);
            this.label25.TabIndex = 15;
            this.label25.Text = "器件：";
            // 
            // btnExport2072
            // 
            this.btnExport2072.Location = new System.Drawing.Point(90, 6);
            this.btnExport2072.Name = "btnExport2072";
            this.btnExport2072.Size = new System.Drawing.Size(75, 23);
            this.btnExport2072.TabIndex = 14;
            this.btnExport2072.Text = "导出";
            this.btnExport2072.UseVisualStyleBackColor = true;
            // 
            // btnImport2072
            // 
            this.btnImport2072.Location = new System.Drawing.Point(9, 6);
            this.btnImport2072.Name = "btnImport2072";
            this.btnImport2072.Size = new System.Drawing.Size(75, 23);
            this.btnImport2072.TabIndex = 13;
            this.btnImport2072.Text = "导入";
            this.btnImport2072.UseVisualStyleBackColor = true;
            this.btnImport2072.Click += new System.EventHandler(this.btnImport2072_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 609);
            this.Controls.Add(this.tab2055Param);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new PluginLib.BaseFormV2.FormCloseDelegate(this.MainForm_FormClosing);
            this.IsShowDataPackageChanged += new PluginLib.BaseFormV2.IsShowDataPackageChangedDelegate(this.MainForm_IsShowDataPackageChanged);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabCommonCommand.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numGamma)).EndInit();
            this.gbBrightness.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrightness)).EndInit();
            this.tab2055Param.ResumeLayout(false);
            this.tabAdvance.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSingleRegValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSingleRegAddr)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.gpFirmwareUpgrade.ResumeLayout(false);
            this.gpFirmwareUpgrade.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabRegister.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid2055)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridOtherReg)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabTest.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox4.ResumeLayout(false);
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid2072)).EndInit();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid2072Other)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabCommonCommand;
        private System.Windows.Forms.GroupBox gbBrightness;
        private System.Windows.Forms.Button btnApplyBrightness;
        private System.Windows.Forms.NumericUpDown numBrightness;
        private System.Windows.Forms.TrackBar tbBrightness;
        private System.Windows.Forms.TabControl tab2055Param;
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView grid2055;
        private System.Windows.Forms.Button btnLoad2055Param;
        private System.Windows.Forms.Button btnReadAndWriteFlash;
        private System.Windows.Forms.Button btnExport2055Param;
        private System.Windows.Forms.ComboBox cbParam2055Color;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox ckDebugMode;
        private System.Windows.Forms.Button btnSendAll;
        private System.Windows.Forms.Button btnWriteSdramReadSdram;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cbGammaBit;
        private System.Windows.Forms.Button btnGammaSet;
        private System.Windows.Forms.ComboBox cbGammaColor;
        private System.Windows.Forms.NumericUpDown numGamma;
        private System.Windows.Forms.Button btnGammaRead;
        private System.Windows.Forms.ComboBox cbRegChip;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnReadReg;
        private System.Windows.Forms.TabPage tabAdvance;
        private System.Windows.Forms.GroupBox gpFirmwareUpgrade;
        private System.Windows.Forms.Button btnUpgradeMCU;
        private System.Windows.Forms.Button btnChoseMCU;
        private System.Windows.Forms.TextBox txtMcu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CoCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMinValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMaxValue;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColCNDescription;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColENDescription;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColDescription;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColOffset;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRegisterAddress;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColRedAddress;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColGreenAddress;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColBlueAddress;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColStartBit;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColStopBit;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColRedValue;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColGreenValue;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColBlueValue;
        private System.Windows.Forms.DataGridViewButtonColumn ColSend;
        private System.Windows.Forms.Button btnUpgradeFPGA;
        private System.Windows.Forms.Button btnChoseFPGA;
        private System.Windows.Forms.TextBox txtFPGA;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnReadFPGA;
        private System.Windows.Forms.Button btnReadMCU;
        private System.Windows.Forms.Button btnReadFirmwareVersion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbChipPos;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbAdvChip;
        private System.Windows.Forms.TabControl tabRegister;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbVideocardLoadParam;
        private System.Windows.Forms.Button btnLoadVideoCardParam;
        private System.Windows.Forms.Button btnReadSDRAM;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnSetNetwork;
        private System.Windows.Forms.TextBox txtGateway;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtMask;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnUpgradeMAP;
        private System.Windows.Forms.Button btnChoseMAP;
        private System.Windows.Forms.TextBox txtMap;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DataGridView gridOtherReg;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnUpgradeCalibration;
        private System.Windows.Forms.Button btnCompareChose1;
        private System.Windows.Forms.TextBox txtCalibration;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnOpenCalibration;
        private System.Windows.Forms.Button btnSetB6B7;
        private System.Windows.Forms.Button btnSDRAMToFlash;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnSetRegister;
        private System.Windows.Forms.NumericUpDown numSingleRegValue;
        private System.Windows.Forms.NumericUpDown numSingleRegAddr;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnSingleRegRead;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox cbWorkMode;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button btnRegSetDefault;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.TextBox txtBatchCalibrationFolder;
        private System.Windows.Forms.Button btnBatchWriteCalibration;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnSelectBatchCalibrationFolder;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.RichTextBox rtCompare;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.TextBox txtCompareFile2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtCompareFile1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnCompareChose2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnSendCalibrationOnOff;
        private System.Windows.Forms.ComboBox cbCalibrationOnOff;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColOtherCheckBox;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColOtherMinValue;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColOtherMaxValue;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColOtherCNDescription;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColOtherENDescription;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColOtherRegisterAddress;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColOtherStartBit;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColOtherStopBit;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColOtherValue;
        private System.Windows.Forms.DataGridViewButtonColumn ColOtherSend;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Button btnReadbtnDistributeBoardFPGA;
        private System.Windows.Forms.Button btnUpdateDistributeBoardFPGA;
        private System.Windows.Forms.Button btnChoseDistributeBoardFPGA;
        private System.Windows.Forms.TextBox txtDistributeBoardFPGA;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cbDistributeAddress;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView grid2072;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn1;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn2;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn3;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn5;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn6;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn7;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn8;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn9;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn10;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn11;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn12;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGridView grid2072Other;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn13;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn14;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn15;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn16;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn17;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn18;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn19;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn dataGridViewLabelXColumn20;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnExport2072;
        private System.Windows.Forms.Button btnImport2072;
    }
}

