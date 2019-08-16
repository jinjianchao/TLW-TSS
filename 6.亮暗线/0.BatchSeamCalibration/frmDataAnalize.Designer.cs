namespace BatchSeamCalibration
{
    partial class frmDataAnalize
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
            this.tab = new System.Windows.Forms.TabControl();
            this.tabCalAnalize = new System.Windows.Forms.TabPage();
            this.cbDataType = new System.Windows.Forms.ComboBox();
            this.txtB3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtB2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtB1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtG3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtG2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtG1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtR3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtR2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtR1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSinglePixel = new System.Windows.Forms.ComboBox();
            this.cbRowList = new System.Windows.Forms.ComboBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.rtShow = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabCompare = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.rtCompare2Content = new System.Windows.Forms.RichTextBox();
            this.rtCompare1Content = new System.Windows.Forms.RichTextBox();
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnSelectFileCompare2 = new System.Windows.Forms.Button();
            this.txtFileCompare2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSelectFileCompare1 = new System.Windows.Forms.Button();
            this.txtFileCompare1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ckRandom = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtSpecCol = new System.Windows.Forms.TextBox();
            this.numSpecCol = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtSpeRow = new System.Windows.Forms.TextBox();
            this.numSpecData = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btnCreateCal = new System.Windows.Forms.Button();
            this.numCalInitData = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnzdat2sdat = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMerger = new System.Windows.Forms.Button();
            this.btnDivide = new System.Windows.Forms.Button();
            this.btnSdat2Zdat = new System.Windows.Forms.Button();
            this.btnDat2Zdat = new System.Windows.Forms.Button();
            this.btnTranslateDat2Sdat = new System.Windows.Forms.Button();
            this.btnTranslateSdatToDat = new System.Windows.Forms.Button();
            this.cbHexOrDecimal = new System.Windows.Forms.ComboBox();
            this.tab.SuspendLayout();
            this.tabCalAnalize.SuspendLayout();
            this.tabCompare.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCalInitData)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tab.Controls.Add(this.tabCalAnalize);
            this.tab.Controls.Add(this.tabCompare);
            this.tab.Controls.Add(this.tabPage1);
            this.tab.Controls.Add(this.tabPage2);
            this.tab.Location = new System.Drawing.Point(2, 32);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(1035, 776);
            this.tab.TabIndex = 0;
            // 
            // tabCalAnalize
            // 
            this.tabCalAnalize.Controls.Add(this.cbDataType);
            this.tabCalAnalize.Controls.Add(this.txtB3);
            this.tabCalAnalize.Controls.Add(this.label9);
            this.tabCalAnalize.Controls.Add(this.txtB2);
            this.tabCalAnalize.Controls.Add(this.label10);
            this.tabCalAnalize.Controls.Add(this.txtB1);
            this.tabCalAnalize.Controls.Add(this.label11);
            this.tabCalAnalize.Controls.Add(this.txtG3);
            this.tabCalAnalize.Controls.Add(this.label6);
            this.tabCalAnalize.Controls.Add(this.txtG2);
            this.tabCalAnalize.Controls.Add(this.label7);
            this.tabCalAnalize.Controls.Add(this.txtG1);
            this.tabCalAnalize.Controls.Add(this.label8);
            this.tabCalAnalize.Controls.Add(this.txtR3);
            this.tabCalAnalize.Controls.Add(this.label5);
            this.tabCalAnalize.Controls.Add(this.txtR2);
            this.tabCalAnalize.Controls.Add(this.label4);
            this.tabCalAnalize.Controls.Add(this.txtR1);
            this.tabCalAnalize.Controls.Add(this.label3);
            this.tabCalAnalize.Controls.Add(this.cbSinglePixel);
            this.tabCalAnalize.Controls.Add(this.cbRowList);
            this.tabCalAnalize.Controls.Add(this.btnRead);
            this.tabCalAnalize.Controls.Add(this.rtShow);
            this.tabCalAnalize.Controls.Add(this.label2);
            this.tabCalAnalize.Controls.Add(this.btnSelect);
            this.tabCalAnalize.Controls.Add(this.txtFile);
            this.tabCalAnalize.Controls.Add(this.label1);
            this.tabCalAnalize.Location = new System.Drawing.Point(4, 22);
            this.tabCalAnalize.Name = "tabCalAnalize";
            this.tabCalAnalize.Padding = new System.Windows.Forms.Padding(3);
            this.tabCalAnalize.Size = new System.Drawing.Size(1027, 750);
            this.tabCalAnalize.TabIndex = 0;
            this.tabCalAnalize.Text = "数据查看";
            this.tabCalAnalize.UseVisualStyleBackColor = true;
            // 
            // cbDataType
            // 
            this.cbDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataType.FormattingEnabled = true;
            this.cbDataType.Location = new System.Drawing.Point(57, 10);
            this.cbDataType.Name = "cbDataType";
            this.cbDataType.Size = new System.Drawing.Size(121, 20);
            this.cbDataType.TabIndex = 28;
            this.cbDataType.SelectedIndexChanged += new System.EventHandler(this.cbDataType_SelectedIndexChanged);
            // 
            // txtB3
            // 
            this.txtB3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtB3.Location = new System.Drawing.Point(943, 205);
            this.txtB3.Name = "txtB3";
            this.txtB3.Size = new System.Drawing.Size(75, 21);
            this.txtB3.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(943, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 26;
            this.label9.Text = "B3";
            // 
            // txtB2
            // 
            this.txtB2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtB2.Location = new System.Drawing.Point(863, 205);
            this.txtB2.Name = "txtB2";
            this.txtB2.Size = new System.Drawing.Size(75, 21);
            this.txtB2.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(863, 189);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 24;
            this.label10.Text = "B2";
            // 
            // txtB1
            // 
            this.txtB1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtB1.Location = new System.Drawing.Point(783, 205);
            this.txtB1.Name = "txtB1";
            this.txtB1.Size = new System.Drawing.Size(75, 21);
            this.txtB1.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(783, 189);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 22;
            this.label11.Text = "B1";
            // 
            // txtG3
            // 
            this.txtG3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtG3.Location = new System.Drawing.Point(944, 161);
            this.txtG3.Name = "txtG3";
            this.txtG3.Size = new System.Drawing.Size(75, 21);
            this.txtG3.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(944, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "G3";
            // 
            // txtG2
            // 
            this.txtG2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtG2.Location = new System.Drawing.Point(864, 161);
            this.txtG2.Name = "txtG2";
            this.txtG2.Size = new System.Drawing.Size(75, 21);
            this.txtG2.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(864, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "G2";
            // 
            // txtG1
            // 
            this.txtG1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtG1.Location = new System.Drawing.Point(784, 161);
            this.txtG1.Name = "txtG1";
            this.txtG1.Size = new System.Drawing.Size(75, 21);
            this.txtG1.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(784, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "G1";
            // 
            // txtR3
            // 
            this.txtR3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtR3.Location = new System.Drawing.Point(944, 115);
            this.txtR3.Name = "txtR3";
            this.txtR3.Size = new System.Drawing.Size(75, 21);
            this.txtR3.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(944, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "R3";
            // 
            // txtR2
            // 
            this.txtR2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtR2.Location = new System.Drawing.Point(864, 115);
            this.txtR2.Name = "txtR2";
            this.txtR2.Size = new System.Drawing.Size(75, 21);
            this.txtR2.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(864, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "R2";
            // 
            // txtR1
            // 
            this.txtR1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtR1.Location = new System.Drawing.Point(784, 115);
            this.txtR1.Name = "txtR1";
            this.txtR1.Size = new System.Drawing.Size(75, 21);
            this.txtR1.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(784, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "R1";
            // 
            // cbSinglePixel
            // 
            this.cbSinglePixel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSinglePixel.FormattingEnabled = true;
            this.cbSinglePixel.Location = new System.Drawing.Point(258, 70);
            this.cbSinglePixel.Name = "cbSinglePixel";
            this.cbSinglePixel.Size = new System.Drawing.Size(121, 20);
            this.cbSinglePixel.TabIndex = 9;
            this.cbSinglePixel.SelectedIndexChanged += new System.EventHandler(this.cbSinglePixel_SelectedIndexChanged);
            // 
            // cbRowList
            // 
            this.cbRowList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRowList.FormattingEnabled = true;
            this.cbRowList.Location = new System.Drawing.Point(57, 70);
            this.cbRowList.Name = "cbRowList";
            this.cbRowList.Size = new System.Drawing.Size(195, 20);
            this.cbRowList.TabIndex = 7;
            this.cbRowList.SelectedIndexChanged += new System.EventHandler(this.cbRowList_SelectedIndexChanged);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(703, 43);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 6;
            this.btnRead.Text = "读取";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // rtShow
            // 
            this.rtShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtShow.Location = new System.Drawing.Point(3, 98);
            this.rtShow.Name = "rtShow";
            this.rtShow.Size = new System.Drawing.Size(775, 645);
            this.rtShow.TabIndex = 5;
            this.rtShow.Text = "";
            this.rtShow.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "位置：";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(619, 43);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "选择";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(57, 44);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(557, 21);
            this.txtFile.TabIndex = 1;
            this.txtFile.Text = "D:\\亮暗线错误数据\\2\\0_1_4_20181229183526243.zdat";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件：";
            // 
            // tabCompare
            // 
            this.tabCompare.Controls.Add(this.label15);
            this.tabCompare.Controls.Add(this.label14);
            this.tabCompare.Controls.Add(this.rtCompare2Content);
            this.tabCompare.Controls.Add(this.rtCompare1Content);
            this.tabCompare.Controls.Add(this.btnCompare);
            this.tabCompare.Controls.Add(this.btnSelectFileCompare2);
            this.tabCompare.Controls.Add(this.txtFileCompare2);
            this.tabCompare.Controls.Add(this.label13);
            this.tabCompare.Controls.Add(this.btnSelectFileCompare1);
            this.tabCompare.Controls.Add(this.txtFileCompare1);
            this.tabCompare.Controls.Add(this.label12);
            this.tabCompare.Location = new System.Drawing.Point(4, 22);
            this.tabCompare.Name = "tabCompare";
            this.tabCompare.Padding = new System.Windows.Forms.Padding(3);
            this.tabCompare.Size = new System.Drawing.Size(1027, 750);
            this.tabCompare.TabIndex = 1;
            this.tabCompare.Text = "文件比较";
            this.tabCompare.UseVisualStyleBackColor = true;
            this.tabCompare.SizeChanged += new System.EventHandler(this.tabCompare_SizeChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(550, 113);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 12);
            this.label15.TabIndex = 12;
            this.label15.Text = "文件2内容：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 111);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 12);
            this.label14.TabIndex = 11;
            this.label14.Text = "文件1内容：";
            // 
            // rtCompare2Content
            // 
            this.rtCompare2Content.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rtCompare2Content.Location = new System.Drawing.Point(552, 128);
            this.rtCompare2Content.Name = "rtCompare2Content";
            this.rtCompare2Content.Size = new System.Drawing.Size(469, 620);
            this.rtCompare2Content.TabIndex = 10;
            this.rtCompare2Content.Text = "";
            this.rtCompare2Content.WordWrap = false;
            // 
            // rtCompare1Content
            // 
            this.rtCompare1Content.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rtCompare1Content.Location = new System.Drawing.Point(6, 128);
            this.rtCompare1Content.Name = "rtCompare1Content";
            this.rtCompare1Content.Size = new System.Drawing.Size(540, 619);
            this.rtCompare1Content.TabIndex = 9;
            this.rtCompare1Content.Text = "";
            this.rtCompare1Content.WordWrap = false;
            this.rtCompare1Content.SelectionChanged += new System.EventHandler(this.rtCompare1Content_SelectionChanged);
            this.rtCompare1Content.VScroll += new System.EventHandler(this.rtCompare1Content_VScroll);
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(701, 40);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 23);
            this.btnCompare.TabIndex = 8;
            this.btnCompare.Text = "比较";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnSelectFileCompare2
            // 
            this.btnSelectFileCompare2.Location = new System.Drawing.Point(620, 41);
            this.btnSelectFileCompare2.Name = "btnSelectFileCompare2";
            this.btnSelectFileCompare2.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFileCompare2.TabIndex = 8;
            this.btnSelectFileCompare2.Text = "选择";
            this.btnSelectFileCompare2.UseVisualStyleBackColor = true;
            this.btnSelectFileCompare2.Click += new System.EventHandler(this.btnSelectFileCompare2_Click);
            // 
            // txtFileCompare2
            // 
            this.txtFileCompare2.Location = new System.Drawing.Point(58, 42);
            this.txtFileCompare2.Name = "txtFileCompare2";
            this.txtFileCompare2.Size = new System.Drawing.Size(557, 21);
            this.txtFileCompare2.TabIndex = 7;
            this.txtFileCompare2.Text = "D:\\亮暗线错误数据\\20181229183535477.zdat";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 46);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 12);
            this.label13.TabIndex = 6;
            this.label13.Text = "文件2：";
            // 
            // btnSelectFileCompare1
            // 
            this.btnSelectFileCompare1.Location = new System.Drawing.Point(620, 14);
            this.btnSelectFileCompare1.Name = "btnSelectFileCompare1";
            this.btnSelectFileCompare1.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFileCompare1.TabIndex = 5;
            this.btnSelectFileCompare1.Text = "选择";
            this.btnSelectFileCompare1.UseVisualStyleBackColor = true;
            this.btnSelectFileCompare1.Click += new System.EventHandler(this.btnSelectFileCompare1_Click);
            // 
            // txtFileCompare1
            // 
            this.txtFileCompare1.Location = new System.Drawing.Point(58, 15);
            this.txtFileCompare1.Name = "txtFileCompare1";
            this.txtFileCompare1.Size = new System.Drawing.Size(557, 21);
            this.txtFileCompare1.TabIndex = 4;
            this.txtFileCompare1.Text = "D:\\亮暗线错误数据\\0_2_2_20181229183535477.zdat";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 12);
            this.label12.TabIndex = 3;
            this.label12.Text = "文件1：";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ckRandom);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnCreateCal);
            this.tabPage1.Controls.Add(this.numCalInitData);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1027, 750);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "构造数据";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ckRandom
            // 
            this.ckRandom.AutoSize = true;
            this.ckRandom.Location = new System.Drawing.Point(140, 15);
            this.ckRandom.Name = "ckRandom";
            this.ckRandom.Size = new System.Drawing.Size(60, 16);
            this.ckRandom.TabIndex = 9;
            this.ckRandom.Text = "随机数";
            this.ckRandom.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.txtSpecCol);
            this.groupBox1.Controls.Add(this.numSpecCol);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.txtSpeRow);
            this.groupBox1.Controls.Add(this.numSpecData);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Location = new System.Drawing.Point(8, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(658, 150);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "特殊数据";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(436, 85);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(179, 12);
            this.label22.TabIndex = 12;
            this.label22.Text = "多列使用分号分割。例如：1;2;3";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(436, 23);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(179, 12);
            this.label21.TabIndex = 12;
            this.label21.Text = "多行使用分号分割。例如：1;2;3";
            // 
            // txtSpecCol
            // 
            this.txtSpecCol.Location = new System.Drawing.Point(45, 77);
            this.txtSpecCol.Name = "txtSpecCol";
            this.txtSpecCol.Size = new System.Drawing.Size(385, 21);
            this.txtSpecCol.TabIndex = 8;
            // 
            // numSpecCol
            // 
            this.numSpecCol.Location = new System.Drawing.Point(45, 107);
            this.numSpecCol.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numSpecCol.Name = "numSpecCol";
            this.numSpecCol.Size = new System.Drawing.Size(80, 21);
            this.numSpecCol.TabIndex = 11;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 80);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 9;
            this.label17.Text = "列";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(4, 109);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 12);
            this.label20.TabIndex = 10;
            this.label20.Text = "数据:";
            // 
            // txtSpeRow
            // 
            this.txtSpeRow.Location = new System.Drawing.Point(45, 20);
            this.txtSpeRow.Name = "txtSpeRow";
            this.txtSpeRow.Size = new System.Drawing.Size(385, 21);
            this.txtSpeRow.TabIndex = 3;
            // 
            // numSpecData
            // 
            this.numSpecData.Location = new System.Drawing.Point(45, 50);
            this.numSpecData.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numSpecData.Name = "numSpecData";
            this.numSpecData.Size = new System.Drawing.Size(80, 21);
            this.numSpecData.TabIndex = 7;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 23);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(23, 12);
            this.label18.TabIndex = 5;
            this.label18.Text = "行:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(4, 52);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 12);
            this.label19.TabIndex = 6;
            this.label19.Text = "数据:";
            // 
            // btnCreateCal
            // 
            this.btnCreateCal.Location = new System.Drawing.Point(8, 195);
            this.btnCreateCal.Name = "btnCreateCal";
            this.btnCreateCal.Size = new System.Drawing.Size(75, 23);
            this.btnCreateCal.TabIndex = 2;
            this.btnCreateCal.Text = "创建";
            this.btnCreateCal.UseVisualStyleBackColor = true;
            this.btnCreateCal.Click += new System.EventHandler(this.btnCreateCal_Click);
            // 
            // numCalInitData
            // 
            this.numCalInitData.Location = new System.Drawing.Point(53, 12);
            this.numCalInitData.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numCalInitData.Name = "numCalInitData";
            this.numCalInitData.Size = new System.Drawing.Size(80, 21);
            this.numCalInitData.TabIndex = 1;
            this.numCalInitData.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 12);
            this.label16.TabIndex = 0;
            this.label16.Text = "初始值:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnzdat2sdat);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.btnMerger);
            this.tabPage2.Controls.Add(this.btnDivide);
            this.tabPage2.Controls.Add(this.btnSdat2Zdat);
            this.tabPage2.Controls.Add(this.btnDat2Zdat);
            this.tabPage2.Controls.Add(this.btnTranslateDat2Sdat);
            this.tabPage2.Controls.Add(this.btnTranslateSdatToDat);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1027, 750);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "数据转换";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnzdat2sdat
            // 
            this.btnzdat2sdat.Location = new System.Drawing.Point(518, 17);
            this.btnzdat2sdat.Name = "btnzdat2sdat";
            this.btnzdat2sdat.Size = new System.Drawing.Size(97, 23);
            this.btnzdat2sdat.TabIndex = 50;
            this.btnzdat2sdat.Text = "zdat->sdat";
            this.btnzdat2sdat.UseVisualStyleBackColor = true;
            this.btnzdat2sdat.Click += new System.EventHandler(this.btnzdat2sdat_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(326, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 49;
            this.button1.Text = "zdat->dat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMerger
            // 
            this.btnMerger.Location = new System.Drawing.Point(120, 46);
            this.btnMerger.Name = "btnMerger";
            this.btnMerger.Size = new System.Drawing.Size(75, 23);
            this.btnMerger.TabIndex = 48;
            this.btnMerger.Text = "数据合并";
            this.btnMerger.UseVisualStyleBackColor = true;
            this.btnMerger.Click += new System.EventHandler(this.btnMerger_Click);
            // 
            // btnDivide
            // 
            this.btnDivide.Location = new System.Drawing.Point(16, 46);
            this.btnDivide.Name = "btnDivide";
            this.btnDivide.Size = new System.Drawing.Size(97, 23);
            this.btnDivide.TabIndex = 47;
            this.btnDivide.Text = "数据拆分";
            this.btnDivide.UseVisualStyleBackColor = true;
            this.btnDivide.Click += new System.EventHandler(this.btnDivide_Click);
            // 
            // btnSdat2Zdat
            // 
            this.btnSdat2Zdat.Location = new System.Drawing.Point(415, 17);
            this.btnSdat2Zdat.Name = "btnSdat2Zdat";
            this.btnSdat2Zdat.Size = new System.Drawing.Size(97, 23);
            this.btnSdat2Zdat.TabIndex = 45;
            this.btnSdat2Zdat.Text = "sdat->zdat";
            this.btnSdat2Zdat.UseVisualStyleBackColor = true;
            this.btnSdat2Zdat.Click += new System.EventHandler(this.btnSdat2Zdat_Click);
            // 
            // btnDat2Zdat
            // 
            this.btnDat2Zdat.Location = new System.Drawing.Point(222, 17);
            this.btnDat2Zdat.Name = "btnDat2Zdat";
            this.btnDat2Zdat.Size = new System.Drawing.Size(97, 23);
            this.btnDat2Zdat.TabIndex = 46;
            this.btnDat2Zdat.Text = "dat->zdat";
            this.btnDat2Zdat.UseVisualStyleBackColor = true;
            this.btnDat2Zdat.Click += new System.EventHandler(this.btnDat2Zdat_Click);
            // 
            // btnTranslateDat2Sdat
            // 
            this.btnTranslateDat2Sdat.Location = new System.Drawing.Point(119, 17);
            this.btnTranslateDat2Sdat.Name = "btnTranslateDat2Sdat";
            this.btnTranslateDat2Sdat.Size = new System.Drawing.Size(97, 23);
            this.btnTranslateDat2Sdat.TabIndex = 43;
            this.btnTranslateDat2Sdat.Text = "dat->sdat";
            this.btnTranslateDat2Sdat.UseVisualStyleBackColor = true;
            this.btnTranslateDat2Sdat.Click += new System.EventHandler(this.btnTranslateDat2Sdat_Click);
            // 
            // btnTranslateSdatToDat
            // 
            this.btnTranslateSdatToDat.Location = new System.Drawing.Point(16, 17);
            this.btnTranslateSdatToDat.Name = "btnTranslateSdatToDat";
            this.btnTranslateSdatToDat.Size = new System.Drawing.Size(97, 23);
            this.btnTranslateSdatToDat.TabIndex = 44;
            this.btnTranslateSdatToDat.Text = "sdat->dat";
            this.btnTranslateSdatToDat.UseVisualStyleBackColor = true;
            this.btnTranslateSdatToDat.Click += new System.EventHandler(this.btnTranslateSdatToDat_Click);
            // 
            // cbHexOrDecimal
            // 
            this.cbHexOrDecimal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHexOrDecimal.FormattingEnabled = true;
            this.cbHexOrDecimal.Location = new System.Drawing.Point(923, 6);
            this.cbHexOrDecimal.Name = "cbHexOrDecimal";
            this.cbHexOrDecimal.Size = new System.Drawing.Size(105, 20);
            this.cbHexOrDecimal.TabIndex = 8;
            this.cbHexOrDecimal.SelectedIndexChanged += new System.EventHandler(this.cbHexOrDecimal_SelectedIndexChanged);
            // 
            // frmDataAnalize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 806);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.cbHexOrDecimal);
            this.Name = "frmDataAnalize";
            this.Text = "数据分析";
            this.Load += new System.EventHandler(this.frmDataAnalize_Load);
            this.tab.ResumeLayout(false);
            this.tabCalAnalize.ResumeLayout(false);
            this.tabCalAnalize.PerformLayout();
            this.tabCompare.ResumeLayout(false);
            this.tabCompare.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCalInitData)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabCalAnalize;
        private System.Windows.Forms.TabPage tabCompare;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtShow;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.ComboBox cbRowList;
        private System.Windows.Forms.ComboBox cbHexOrDecimal;
        private System.Windows.Forms.ComboBox cbSinglePixel;
        private System.Windows.Forms.TextBox txtB3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtB2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtB1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtG3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtG2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtG1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtR3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtR2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtR1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbDataType;
        private System.Windows.Forms.Button btnSelectFileCompare2;
        private System.Windows.Forms.TextBox txtFileCompare2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSelectFileCompare1;
        private System.Windows.Forms.TextBox txtFileCompare1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.RichTextBox rtCompare1Content;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RichTextBox rtCompare2Content;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnCreateCal;
        private System.Windows.Forms.NumericUpDown numCalInitData;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSpeRow;
        private System.Windows.Forms.NumericUpDown numSpecData;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtSpecCol;
        private System.Windows.Forms.NumericUpDown numSpecCol;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox ckRandom;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSdat2Zdat;
        private System.Windows.Forms.Button btnDat2Zdat;
        private System.Windows.Forms.Button btnTranslateDat2Sdat;
        private System.Windows.Forms.Button btnTranslateSdatToDat;
        private System.Windows.Forms.Button btnDivide;
        private System.Windows.Forms.Button btnMerger;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnzdat2sdat;
    }
}