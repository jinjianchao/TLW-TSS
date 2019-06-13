namespace TLWController
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.tab = new System.Windows.Forms.TabControl();
            this.tabTest = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
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
            this.gpTest = new System.Windows.Forms.GroupBox();
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.numSpectionValue = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSpecialSet = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.numSpecialStopBit = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.numSpecialAddr = new System.Windows.Forms.NumericUpDown();
            this.numSpecialStartBit = new System.Windows.Forms.NumericUpDown();
            this.ckParamAll = new System.Windows.Forms.CheckBox();
            this.btnSendAll = new System.Windows.Forms.Button();
            this.cbParam2055Color = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ckDebugMode = new System.Windows.Forms.CheckBox();
            this.cbRegChip = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbParam2055Refreshrate = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnExport2055Param = new System.Windows.Forms.Button();
            this.btnLoad2055Param = new System.Windows.Forms.Button();
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
            this.ColRedValue = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.ColGreenValue = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.ColBlueValue = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.ColSend = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnRegReadSpecial = new System.Windows.Forms.Button();
            this.tabCommonCommand.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGamma)).BeginInit();
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
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpectionValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecialStopBit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecialAddr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecialStartBit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid2055)).BeginInit();
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
            this.tabCommonCommand.Size = new System.Drawing.Size(1392, 571);
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
            // tab
            // 
            this.tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tab.Controls.Add(this.tabCommonCommand);
            this.tab.Controls.Add(this.tabTest);
            this.tab.Controls.Add(this.tabPage1);
            this.tab.Location = new System.Drawing.Point(0, 12);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(1400, 597);
            this.tab.TabIndex = 0;
            // 
            // tabTest
            // 
            this.tabTest.BackColor = System.Drawing.SystemColors.Control;
            this.tabTest.Controls.Add(this.groupBox3);
            this.tabTest.Location = new System.Drawing.Point(4, 22);
            this.tabTest.Name = "tabTest";
            this.tabTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabTest.Size = new System.Drawing.Size(1392, 571);
            this.tabTest.TabIndex = 1;
            this.tabTest.Text = "测试页";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.cbChipPos);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.gpTest);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1376, 320);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "FLASH操作";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "芯片位置:";
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
            // cbChipPos
            // 
            this.cbChipPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbChipPos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChipPos.FormattingEnabled = true;
            this.cbChipPos.Location = new System.Drawing.Point(82, 20);
            this.cbChipPos.Name = "cbChipPos";
            this.cbChipPos.Size = new System.Drawing.Size(121, 20);
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
            this.gpTest.Location = new System.Drawing.Point(526, 47);
            this.gpTest.Name = "gpTest";
            this.gpTest.Size = new System.Drawing.Size(451, 190);
            this.gpTest.TabIndex = 9;
            this.gpTest.TabStop = false;
            this.gpTest.Text = "稳定性测试";
            // 
            // btnWriteSdramReadSdram
            // 
            this.btnWriteSdramReadSdram.Location = new System.Drawing.Point(129, 82);
            this.btnWriteSdramReadSdram.Name = "btnWriteSdramReadSdram";
            this.btnWriteSdramReadSdram.Size = new System.Drawing.Size(110, 23);
            this.btnWriteSdramReadSdram.TabIndex = 9;
            this.btnWriteSdramReadSdram.Text = "写SDRAM->读SDRAM";
            this.btnWriteSdramReadSdram.UseVisualStyleBackColor = true;
            this.btnWriteSdramReadSdram.Click += new System.EventHandler(this.btnWriteSdramReadSdram_Click);
            // 
            // btnReadAndWriteFlash
            // 
            this.btnReadAndWriteFlash.Location = new System.Drawing.Point(6, 82);
            this.btnReadAndWriteFlash.Name = "btnReadAndWriteFlash";
            this.btnReadAndWriteFlash.Size = new System.Drawing.Size(113, 23);
            this.btnReadAndWriteFlash.TabIndex = 8;
            this.btnReadAndWriteFlash.Text = "写flash->读flash";
            this.btnReadAndWriteFlash.UseVisualStyleBackColor = true;
            this.btnReadAndWriteFlash.Click += new System.EventHandler(this.btnReadAndWriteFlash_Click);
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
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.ckParamAll);
            this.tabPage1.Controls.Add(this.btnSendAll);
            this.tabPage1.Controls.Add(this.cbParam2055Color);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.ckDebugMode);
            this.tabPage1.Controls.Add(this.cbRegChip);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.cbParam2055Refreshrate);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.btnExport2055Param);
            this.tabPage1.Controls.Add(this.btnLoad2055Param);
            this.tabPage1.Controls.Add(this.grid2055);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1392, 571);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "2055参数下载";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnRegReadSpecial);
            this.groupBox4.Controls.Add(this.numSpectionValue);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.btnSpecialSet);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.numSpecialStopBit);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.numSpecialAddr);
            this.groupBox4.Controls.Add(this.numSpecialStartBit);
            this.groupBox4.Location = new System.Drawing.Point(418, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(703, 54);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "特殊寄存器";
            // 
            // numSpectionValue
            // 
            this.numSpectionValue.Location = new System.Drawing.Point(454, 22);
            this.numSpectionValue.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numSpectionValue.Name = "numSpectionValue";
            this.numSpectionValue.Size = new System.Drawing.Size(73, 21);
            this.numSpectionValue.TabIndex = 18;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(418, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 12);
            this.label13.TabIndex = 17;
            this.label13.Text = "值:";
            // 
            // btnSpecialSet
            // 
            this.btnSpecialSet.Location = new System.Drawing.Point(540, 21);
            this.btnSpecialSet.Name = "btnSpecialSet";
            this.btnSpecialSet.Size = new System.Drawing.Size(75, 23);
            this.btnSpecialSet.TabIndex = 16;
            this.btnSpecialSet.Text = "设置";
            this.btnSpecialSet.UseVisualStyleBackColor = true;
            this.btnSpecialSet.Click += new System.EventHandler(this.btnSpecialSet_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(148, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 12;
            this.label11.Text = "起始位：";
            // 
            // numSpecialStopBit
            // 
            this.numSpecialStopBit.Enabled = false;
            this.numSpecialStopBit.Location = new System.Drawing.Point(340, 22);
            this.numSpecialStopBit.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numSpecialStopBit.Name = "numSpecialStopBit";
            this.numSpecialStopBit.Size = new System.Drawing.Size(73, 21);
            this.numSpecialStopBit.TabIndex = 15;
            this.numSpecialStopBit.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "地址：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(286, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 14;
            this.label12.Text = "终止位：";
            // 
            // numSpecialAddr
            // 
            this.numSpecialAddr.Location = new System.Drawing.Point(69, 22);
            this.numSpecialAddr.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numSpecialAddr.Name = "numSpecialAddr";
            this.numSpecialAddr.Size = new System.Drawing.Size(73, 21);
            this.numSpecialAddr.TabIndex = 11;
            // 
            // numSpecialStartBit
            // 
            this.numSpecialStartBit.Enabled = false;
            this.numSpecialStartBit.Location = new System.Drawing.Point(201, 22);
            this.numSpecialStartBit.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numSpecialStartBit.Name = "numSpecialStartBit";
            this.numSpecialStartBit.Size = new System.Drawing.Size(73, 21);
            this.numSpecialStartBit.TabIndex = 13;
            // 
            // ckParamAll
            // 
            this.ckParamAll.AutoSize = true;
            this.ckParamAll.Location = new System.Drawing.Point(16, 69);
            this.ckParamAll.Name = "ckParamAll";
            this.ckParamAll.Size = new System.Drawing.Size(15, 14);
            this.ckParamAll.TabIndex = 9;
            this.ckParamAll.UseVisualStyleBackColor = true;
            this.ckParamAll.CheckedChanged += new System.EventHandler(this.ckParamAll_CheckedChanged);
            // 
            // btnSendAll
            // 
            this.btnSendAll.Location = new System.Drawing.Point(1127, 29);
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
            this.cbParam2055Color.Location = new System.Drawing.Point(161, 34);
            this.cbParam2055Color.Name = "cbParam2055Color";
            this.cbParam2055Color.Size = new System.Drawing.Size(97, 20);
            this.cbParam2055Color.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(93, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "颜色：";
            // 
            // ckDebugMode
            // 
            this.ckDebugMode.AutoSize = true;
            this.ckDebugMode.Location = new System.Drawing.Point(309, 36);
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
            this.cbRegChip.Location = new System.Drawing.Point(309, 8);
            this.cbRegChip.Name = "cbRegChip";
            this.cbRegChip.Size = new System.Drawing.Size(97, 20);
            this.cbRegChip.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(263, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 3;
            this.label14.Text = "器件：";
            // 
            // cbParam2055Refreshrate
            // 
            this.cbParam2055Refreshrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParam2055Refreshrate.Enabled = false;
            this.cbParam2055Refreshrate.FormattingEnabled = true;
            this.cbParam2055Refreshrate.Items.AddRange(new object[] {
            "50Hz",
            "60Hz"});
            this.cbParam2055Refreshrate.Location = new System.Drawing.Point(161, 7);
            this.cbParam2055Refreshrate.Name = "cbParam2055Refreshrate";
            this.cbParam2055Refreshrate.Size = new System.Drawing.Size(97, 20);
            this.cbParam2055Refreshrate.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Location = new System.Drawing.Point(93, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "刷新率：";
            // 
            // btnExport2055Param
            // 
            this.btnExport2055Param.Location = new System.Drawing.Point(9, 33);
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
            // grid2055
            // 
            this.grid2055.AllowUserToAddRows = false;
            this.grid2055.AllowUserToDeleteRows = false;
            this.grid2055.AllowUserToOrderColumns = true;
            this.grid2055.AllowUserToResizeColumns = false;
            this.grid2055.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grid2055.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grid2055.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.grid2055.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid2055.EnableHeadersVisualStyles = false;
            this.grid2055.Location = new System.Drawing.Point(6, 66);
            this.grid2055.MultiSelect = false;
            this.grid2055.Name = "grid2055";
            this.grid2055.RowHeadersVisible = false;
            this.grid2055.RowTemplate.Height = 23;
            this.grid2055.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid2055.Size = new System.Drawing.Size(1378, 497);
            this.grid2055.TabIndex = 0;
            this.grid2055.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grid2055_CellBeginEdit);
            this.grid2055.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid2055_CellContentClick);
            this.grid2055.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grid2055_EditingControlShowing);
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
            // 
            // 
            // 
            this.ColRedValue.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.ColRedValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ColRedValue.DataPropertyName = "RedValue";
            this.ColRedValue.Frozen = true;
            this.ColRedValue.HeaderText = "红色值";
            this.ColRedValue.Name = "ColRedValue";
            this.ColRedValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColRedValue.ShowUpDown = true;
            this.ColRedValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColGreenValue
            // 
            // 
            // 
            // 
            this.ColGreenValue.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.ColGreenValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ColGreenValue.DataPropertyName = "GreenValue";
            this.ColGreenValue.Frozen = true;
            this.ColGreenValue.HeaderText = "绿色值";
            this.ColGreenValue.Name = "ColGreenValue";
            this.ColGreenValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColGreenValue.ShowUpDown = true;
            // 
            // ColBlueValue
            // 
            // 
            // 
            // 
            this.ColBlueValue.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.ColBlueValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ColBlueValue.DataPropertyName = "BlueValue";
            this.ColBlueValue.Frozen = true;
            this.ColBlueValue.HeaderText = "蓝色值";
            this.ColBlueValue.Name = "ColBlueValue";
            this.ColBlueValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColBlueValue.ShowUpDown = true;
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
            // btnRegReadSpecial
            // 
            this.btnRegReadSpecial.Location = new System.Drawing.Point(621, 21);
            this.btnRegReadSpecial.Name = "btnRegReadSpecial";
            this.btnRegReadSpecial.Size = new System.Drawing.Size(75, 23);
            this.btnRegReadSpecial.TabIndex = 19;
            this.btnRegReadSpecial.Text = "读取";
            this.btnRegReadSpecial.UseVisualStyleBackColor = true;
            this.btnRegReadSpecial.Click += new System.EventHandler(this.btnRegReadSpecial_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 609);
            this.Controls.Add(this.tab);
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
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpectionValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecialStopBit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecialAddr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecialStartBit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid2055)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView grid2055;
        private System.Windows.Forms.Button btnLoad2055Param;
        private System.Windows.Forms.Button btnReadAndWriteFlash;
        private System.Windows.Forms.Button btnExport2055Param;
        private System.Windows.Forms.ComboBox cbParam2055Refreshrate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbParam2055Color;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox ckDebugMode;
        private System.Windows.Forms.Button btnSendAll;
        private System.Windows.Forms.CheckBox ckParamAll;
        private System.Windows.Forms.Button btnWriteSdramReadSdram;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numSpecialStopBit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numSpecialAddr;
        private System.Windows.Forms.NumericUpDown numSpecialStartBit;
        private System.Windows.Forms.Button btnSpecialSet;
        private System.Windows.Forms.NumericUpDown numSpectionValue;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cbGammaBit;
        private System.Windows.Forms.Button btnGammaSet;
        private System.Windows.Forms.ComboBox cbGammaColor;
        private System.Windows.Forms.NumericUpDown numGamma;
        private System.Windows.Forms.Button btnGammaRead;
        private System.Windows.Forms.ComboBox cbChipPos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbRegChip;
        private System.Windows.Forms.Label label14;
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
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn ColRedValue;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn ColGreenValue;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn ColBlueValue;
        private System.Windows.Forms.DataGridViewButtonColumn ColSend;
        private System.Windows.Forms.Button btnRegReadSpecial;
    }
}

