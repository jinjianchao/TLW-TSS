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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabCommonCommand = new System.Windows.Forms.TabPage();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.btnChoseGammaFile = new System.Windows.Forms.Button();
            this.txtGammaFile = new System.Windows.Forms.TextBox();
            this.cbGammFileColor = new System.Windows.Forms.ComboBox();
            this.btnWriteGammaFile = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numGammaBit = new System.Windows.Forms.NumericUpDown();
            this.btnCreateGammaFile = new System.Windows.Forms.Button();
            this.numGamma = new System.Windows.Forms.NumericUpDown();
            this.cbGammaColor = new System.Windows.Forms.ComboBox();
            this.cbGammaBit = new System.Windows.Forms.ComboBox();
            this.btnGammaRead = new System.Windows.Forms.Button();
            this.btnGammaSet = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.cbCalibrationOnOff = new System.Windows.Forms.ComboBox();
            this.btnSendCalibrationOnOff = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.cbWorkMode = new System.Windows.Forms.ComboBox();
            this.gbBrightness = new System.Windows.Forms.GroupBox();
            this.cbBrightnessColor = new System.Windows.Forms.ComboBox();
            this.btnApplyBrightness = new System.Windows.Forms.Button();
            this.numBrightness = new System.Windows.Forms.NumericUpDown();
            this.tbBrightness = new System.Windows.Forms.TrackBar();
            this.tab2055Param = new System.Windows.Forms.TabControl();
            this.tabAdvance = new System.Windows.Forms.TabPage();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.label39 = new System.Windows.Forms.Label();
            this.cbChipType = new System.Windows.Forms.ComboBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.numBlue = new System.Windows.Forms.NumericUpDown();
            this.numGreen = new System.Windows.Forms.NumericUpDown();
            this.numRed = new System.Windows.Forms.NumericUpDown();
            this.btnReadGain = new System.Windows.Forms.Button();
            this.btnSetGain = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnStopWriteCal = new System.Windows.Forms.Button();
            this.txtBatchWriteCalibrationFolder = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.btnBatchWriteCal = new System.Windows.Forms.Button();
            this.btnChoseBatchCalibrationFolder = new System.Windows.Forms.Button();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.cbSNCreate = new System.Windows.Forms.ComboBox();
            this.cbSNPos = new System.Windows.Forms.ComboBox();
            this.btnReadSN = new System.Windows.Forms.Button();
            this.btnCreateSN = new System.Windows.Forms.Button();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.cbBoardPos = new System.Windows.Forms.ComboBox();
            this.btnReadCalibration = new System.Windows.Forms.Button();
            this.txtCalibrationFile = new System.Windows.Forms.TextBox();
            this.btnUpdateCalibration = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.btnChoseCalibration = new System.Windows.Forms.Button();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.btnReadColorTemp = new System.Windows.Forms.Button();
            this.cbChip = new System.Windows.Forms.ComboBox();
            this.btnSetColorTemp = new System.Windows.Forms.Button();
            this.cbHz = new System.Windows.Forms.ComboBox();
            this.cbColorTempType = new System.Windows.Forms.ComboBox();
            this.btnColorTempConfig = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnSingleRegRead = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.btnSetRegister = new System.Windows.Forms.Button();
            this.numSingleRegValue = new System.Windows.Forms.NumericUpDown();
            this.numSingleRegAddr = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnLoadVideoCardParam = new System.Windows.Forms.Button();
            this.cbVideocardLoadParam = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnSetNetwork = new System.Windows.Forms.Button();
            this.txtGateway = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMask = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.gpFirmwareUpgrade = new System.Windows.Forms.GroupBox();
            this.btnReadMap = new System.Windows.Forms.Button();
            this.btnLoadModuleSection = new System.Windows.Forms.Button();
            this.btnLoadFPGA = new System.Windows.Forms.Button();
            this.txtMap = new System.Windows.Forms.TextBox();
            this.btnReadDivideVersion = new System.Windows.Forms.Button();
            this.btnUpgradeMAP = new System.Windows.Forms.Button();
            this.btnReadBoardVersion = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.btnReadMbVersion = new System.Windows.Forms.Button();
            this.btnChoseMAP = new System.Windows.Forms.Button();
            this.btnReadMCUVersion = new System.Windows.Forms.Button();
            this.cbDistributeChip = new System.Windows.Forms.ComboBox();
            this.cbModuleChip = new System.Windows.Forms.ComboBox();
            this.cbMBFPGAChip = new System.Windows.Forms.ComboBox();
            this.cbMCUChip = new System.Windows.Forms.ComboBox();
            this.btnReadbtnDistributeBoardFPGA = new System.Windows.Forms.Button();
            this.btnReadMbFPGA = new System.Windows.Forms.Button();
            this.btnReadFPGA = new System.Windows.Forms.Button();
            this.btnReadMCU = new System.Windows.Forms.Button();
            this.btnUpdateDistributeBoardFPGA = new System.Windows.Forms.Button();
            this.btnUpgradeMbFPGA = new System.Windows.Forms.Button();
            this.btnUpgradeFPGA = new System.Windows.Forms.Button();
            this.btnUpgradeMCU = new System.Windows.Forms.Button();
            this.btnChoseDistributeBoardFPGA = new System.Windows.Forms.Button();
            this.btnChoseMbFPGA = new System.Windows.Forms.Button();
            this.btnChoseFPGA = new System.Windows.Forms.Button();
            this.btnChoseMCU = new System.Windows.Forms.Button();
            this.txtDistributeBoardFPGA = new System.Windows.Forms.TextBox();
            this.txtMbFPGA = new System.Windows.Forms.TextBox();
            this.txtFPGA = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMcu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tab2055 = new System.Windows.Forms.TabPage();
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
            this.ColRegisterAddress = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn2055Read1 = new System.Windows.Forms.Button();
            this.label78 = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.btn2055Send2 = new System.Windows.Forms.Button();
            this.rt2055Send2 = new System.Windows.Forms.RichTextBox();
            this.btn2055Read2 = new System.Windows.Forms.Button();
            this.btn2055Send1 = new System.Windows.Forms.Button();
            this.rt2055Send1 = new System.Windows.Forms.RichTextBox();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.numPreview128Reg = new System.Windows.Forms.NumericUpDown();
            this.btnPreview128Reg = new System.Windows.Forms.Button();
            this.gp2019Config = new System.Windows.Forms.GroupBox();
            this.label214 = new System.Windows.Forms.Label();
            this.btnSet2019All = new System.Windows.Forms.Button();
            this.label213 = new System.Windows.Forms.Label();
            this.label212 = new System.Windows.Forms.Label();
            this.label211 = new System.Windows.Forms.Label();
            this.btnSet2019_163 = new System.Windows.Forms.Button();
            this.input2019_163 = new System.Windows.Forms.NumericUpDown();
            this.label206 = new System.Windows.Forms.Label();
            this.btnSet2019_162 = new System.Windows.Forms.Button();
            this.input2019_162 = new System.Windows.Forms.NumericUpDown();
            this.label204 = new System.Windows.Forms.Label();
            this.btnSet2019_161 = new System.Windows.Forms.Button();
            this.input2019_161 = new System.Windows.Forms.NumericUpDown();
            this.label203 = new System.Windows.Forms.Label();
            this.btnSet2019_160 = new System.Windows.Forms.Button();
            this.input2019_160 = new System.Windows.Forms.NumericUpDown();
            this.label202 = new System.Windows.Forms.Label();
            this.btn2072_saveValueList = new System.Windows.Forms.Button();
            this.ck2072CycleTest = new System.Windows.Forms.CheckBox();
            this.btn2072_all = new System.Windows.Forms.Button();
            this.btn2072_export = new System.Windows.Forms.Button();
            this.btn2072_import = new System.Windows.Forms.Button();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.input2072_7_1 = new System.Windows.Forms.NumericUpDown();
            this.input2072_3_1 = new System.Windows.Forms.NumericUpDown();
            this.input2072_17_2 = new System.Windows.Forms.NumericUpDown();
            this.input2072_16_8 = new System.Windows.Forms.NumericUpDown();
            this.input2072_16_7 = new System.Windows.Forms.NumericUpDown();
            this.input2072_14_7 = new System.Windows.Forms.NumericUpDown();
            this.input2072_14_6 = new System.Windows.Forms.NumericUpDown();
            this.input2072_14_5 = new System.Windows.Forms.NumericUpDown();
            this.input2072_9_6 = new System.Windows.Forms.NumericUpDown();
            this.input2072_9_5 = new System.Windows.Forms.NumericUpDown();
            this.input2072_9_4 = new System.Windows.Forms.NumericUpDown();
            this.input2072_2_4 = new System.Windows.Forms.NumericUpDown();
            this.input2072_2_3 = new System.Windows.Forms.NumericUpDown();
            this.input2072_2_2 = new System.Windows.Forms.NumericUpDown();
            this.input2072_2_1 = new System.Windows.Forms.NumericUpDown();
            this.input2072_3_6 = new System.Windows.Forms.NumericUpDown();
            this.btn2072_f3 = new System.Windows.Forms.Button();
            this.btn2072_f2 = new System.Windows.Forms.Button();
            this.btn2072_f1 = new System.Windows.Forms.Button();
            this.btn2072_c = new System.Windows.Forms.Button();
            this.btn2072_b = new System.Windows.Forms.Button();
            this.btn2072_f0 = new System.Windows.Forms.Button();
            this.btn2072_d = new System.Windows.Forms.Button();
            this.btn2072_9 = new System.Windows.Forms.Button();
            this.btn2072_8 = new System.Windows.Forms.Button();
            this.cb2072_17_1 = new System.Windows.Forms.ComboBox();
            this.label154 = new System.Windows.Forms.Label();
            this.label155 = new System.Windows.Forms.Label();
            this.label156 = new System.Windows.Forms.Label();
            this.label147 = new System.Windows.Forms.Label();
            this.label136 = new System.Windows.Forms.Label();
            this.cb2072_16_6 = new System.Windows.Forms.ComboBox();
            this.label138 = new System.Windows.Forms.Label();
            this.cb2072_16_5 = new System.Windows.Forms.ComboBox();
            this.label139 = new System.Windows.Forms.Label();
            this.cb2072_16_4 = new System.Windows.Forms.ComboBox();
            this.label141 = new System.Windows.Forms.Label();
            this.cb2072_16_2 = new System.Windows.Forms.ComboBox();
            this.cb2072_16_3 = new System.Windows.Forms.ComboBox();
            this.cb2072_16_1 = new System.Windows.Forms.ComboBox();
            this.label142 = new System.Windows.Forms.Label();
            this.label144 = new System.Windows.Forms.Label();
            this.label145 = new System.Windows.Forms.Label();
            this.label146 = new System.Windows.Forms.Label();
            this.cb2072_15_6 = new System.Windows.Forms.ComboBox();
            this.label175 = new System.Windows.Forms.Label();
            this.cb2072_15_5 = new System.Windows.Forms.ComboBox();
            this.label178 = new System.Windows.Forms.Label();
            this.cb2072_15_4 = new System.Windows.Forms.ComboBox();
            this.label181 = new System.Windows.Forms.Label();
            this.cb2072_15_2 = new System.Windows.Forms.ComboBox();
            this.cb2072_15_3 = new System.Windows.Forms.ComboBox();
            this.cb2072_15_1 = new System.Windows.Forms.ComboBox();
            this.label207 = new System.Windows.Forms.Label();
            this.label208 = new System.Windows.Forms.Label();
            this.label209 = new System.Windows.Forms.Label();
            this.label210 = new System.Windows.Forms.Label();
            this.cb2072_12_7 = new System.Windows.Forms.ComboBox();
            this.label126 = new System.Windows.Forms.Label();
            this.cb2072_12_6 = new System.Windows.Forms.ComboBox();
            this.label129 = new System.Windows.Forms.Label();
            this.cb2072_12_5 = new System.Windows.Forms.ComboBox();
            this.label134 = new System.Windows.Forms.Label();
            this.cb2072_12_4 = new System.Windows.Forms.ComboBox();
            this.label137 = new System.Windows.Forms.Label();
            this.cb2072_12_2 = new System.Windows.Forms.ComboBox();
            this.cb2072_12_3 = new System.Windows.Forms.ComboBox();
            this.cb2072_12_1 = new System.Windows.Forms.ComboBox();
            this.label140 = new System.Windows.Forms.Label();
            this.label143 = new System.Windows.Forms.Label();
            this.label148 = new System.Windows.Forms.Label();
            this.label151 = new System.Windows.Forms.Label();
            this.cb2072_11_7 = new System.Windows.Forms.ComboBox();
            this.label55 = new System.Windows.Forms.Label();
            this.cb2072_11_6 = new System.Windows.Forms.ComboBox();
            this.label57 = new System.Windows.Forms.Label();
            this.cb2072_11_5 = new System.Windows.Forms.ComboBox();
            this.label86 = new System.Windows.Forms.Label();
            this.cb2072_11_4 = new System.Windows.Forms.ComboBox();
            this.label88 = new System.Windows.Forms.Label();
            this.cb2072_11_2 = new System.Windows.Forms.ComboBox();
            this.cb2072_11_3 = new System.Windows.Forms.ComboBox();
            this.cb2072_11_1 = new System.Windows.Forms.ComboBox();
            this.label90 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.label117 = new System.Windows.Forms.Label();
            this.label121 = new System.Windows.Forms.Label();
            this.label158 = new System.Windows.Forms.Label();
            this.label176 = new System.Windows.Forms.Label();
            this.label177 = new System.Windows.Forms.Label();
            this.cb2072_14_4 = new System.Windows.Forms.ComboBox();
            this.label179 = new System.Windows.Forms.Label();
            this.cb2072_14_2 = new System.Windows.Forms.ComboBox();
            this.cb2072_14_3 = new System.Windows.Forms.ComboBox();
            this.cb2072_14_1 = new System.Windows.Forms.ComboBox();
            this.label180 = new System.Windows.Forms.Label();
            this.label182 = new System.Windows.Forms.Label();
            this.label183 = new System.Windows.Forms.Label();
            this.label184 = new System.Windows.Forms.Label();
            this.cb2072_13_1 = new System.Windows.Forms.ComboBox();
            this.cb2072_13_10 = new System.Windows.Forms.ComboBox();
            this.cb2072_13_9 = new System.Windows.Forms.ComboBox();
            this.cb2072_13_8 = new System.Windows.Forms.ComboBox();
            this.label159 = new System.Windows.Forms.Label();
            this.label160 = new System.Windows.Forms.Label();
            this.label161 = new System.Windows.Forms.Label();
            this.btn2072_a = new System.Windows.Forms.Button();
            this.cb2072_13_12 = new System.Windows.Forms.ComboBox();
            this.cb2072_13_11 = new System.Windows.Forms.ComboBox();
            this.cb2072_13_7 = new System.Windows.Forms.ComboBox();
            this.cb2072_13_6 = new System.Windows.Forms.ComboBox();
            this.cb2072_13_5 = new System.Windows.Forms.ComboBox();
            this.cb2072_13_4 = new System.Windows.Forms.ComboBox();
            this.cb2072_13_3 = new System.Windows.Forms.ComboBox();
            this.cb2072_13_2 = new System.Windows.Forms.ComboBox();
            this.label162 = new System.Windows.Forms.Label();
            this.label163 = new System.Windows.Forms.Label();
            this.label165 = new System.Windows.Forms.Label();
            this.label166 = new System.Windows.Forms.Label();
            this.label167 = new System.Windows.Forms.Label();
            this.label168 = new System.Windows.Forms.Label();
            this.label169 = new System.Windows.Forms.Label();
            this.label171 = new System.Windows.Forms.Label();
            this.label173 = new System.Windows.Forms.Label();
            this.label174 = new System.Windows.Forms.Label();
            this.cb2072_10_7 = new System.Windows.Forms.ComboBox();
            this.label133 = new System.Windows.Forms.Label();
            this.cb2072_10_6 = new System.Windows.Forms.ComboBox();
            this.label135 = new System.Windows.Forms.Label();
            this.cb2072_10_5 = new System.Windows.Forms.ComboBox();
            this.label125 = new System.Windows.Forms.Label();
            this.cb2072_10_4 = new System.Windows.Forms.ComboBox();
            this.label127 = new System.Windows.Forms.Label();
            this.cb2072_10_2 = new System.Windows.Forms.ComboBox();
            this.cb2072_10_3 = new System.Windows.Forms.ComboBox();
            this.cb2072_10_1 = new System.Windows.Forms.ComboBox();
            this.label128 = new System.Windows.Forms.Label();
            this.label130 = new System.Windows.Forms.Label();
            this.label131 = new System.Windows.Forms.Label();
            this.label132 = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.label124 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.cb2072_9_1 = new System.Windows.Forms.ComboBox();
            this.cb2072_9_3 = new System.Windows.Forms.ComboBox();
            this.cb2072_9_2 = new System.Windows.Forms.ComboBox();
            this.label112 = new System.Windows.Forms.Label();
            this.label113 = new System.Windows.Forms.Label();
            this.label120 = new System.Windows.Forms.Label();
            this.label122 = new System.Windows.Forms.Label();
            this.cb2072_8_4 = new System.Windows.Forms.ComboBox();
            this.label114 = new System.Windows.Forms.Label();
            this.cb2072_8_1 = new System.Windows.Forms.ComboBox();
            this.cb2072_8_3 = new System.Windows.Forms.ComboBox();
            this.cb2072_8_2 = new System.Windows.Forms.ComboBox();
            this.label115 = new System.Windows.Forms.Label();
            this.label116 = new System.Windows.Forms.Label();
            this.label118 = new System.Windows.Forms.Label();
            this.label119 = new System.Windows.Forms.Label();
            this.cb2072_7_14 = new System.Windows.Forms.ComboBox();
            this.label110 = new System.Windows.Forms.Label();
            this.cb2072_7_11 = new System.Windows.Forms.ComboBox();
            this.cb2072_7_10 = new System.Windows.Forms.ComboBox();
            this.cb2072_7_9 = new System.Windows.Forms.ComboBox();
            this.label96 = new System.Windows.Forms.Label();
            this.label99 = new System.Windows.Forms.Label();
            this.label109 = new System.Windows.Forms.Label();
            this.btn2072_7 = new System.Windows.Forms.Button();
            this.cb2072_7_13 = new System.Windows.Forms.ComboBox();
            this.cb2072_7_12 = new System.Windows.Forms.ComboBox();
            this.cb2072_7_8 = new System.Windows.Forms.ComboBox();
            this.cb2072_7_7 = new System.Windows.Forms.ComboBox();
            this.cb2072_7_6 = new System.Windows.Forms.ComboBox();
            this.cb2072_7_5 = new System.Windows.Forms.ComboBox();
            this.cb2072_7_4 = new System.Windows.Forms.ComboBox();
            this.cb2072_7_3 = new System.Windows.Forms.ComboBox();
            this.cb2072_7_2 = new System.Windows.Forms.ComboBox();
            this.label94 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.label102 = new System.Windows.Forms.Label();
            this.label104 = new System.Windows.Forms.Label();
            this.label105 = new System.Windows.Forms.Label();
            this.label106 = new System.Windows.Forms.Label();
            this.label107 = new System.Windows.Forms.Label();
            this.label108 = new System.Windows.Forms.Label();
            this.cb2072_5_4 = new System.Windows.Forms.ComboBox();
            this.label85 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.cb2072_5_1 = new System.Windows.Forms.ComboBox();
            this.btn2072_5 = new System.Windows.Forms.Button();
            this.cb2072_5_3 = new System.Windows.Forms.ComboBox();
            this.cb2072_5_2 = new System.Windows.Forms.ComboBox();
            this.label89 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.cb2072_6_6 = new System.Windows.Forms.ComboBox();
            this.cb2072_6_5 = new System.Windows.Forms.ComboBox();
            this.label82 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.cb2072_6_1 = new System.Windows.Forms.ComboBox();
            this.btn2072_6 = new System.Windows.Forms.Button();
            this.cb2072_6_4 = new System.Windows.Forms.ComboBox();
            this.cb2072_6_3 = new System.Windows.Forms.ComboBox();
            this.cb2072_6_2 = new System.Windows.Forms.ComboBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.btn2072_4 = new System.Windows.Forms.Button();
            this.cb2072_4_6 = new System.Windows.Forms.ComboBox();
            this.cb2072_4_5 = new System.Windows.Forms.ComboBox();
            this.cb2072_4_4 = new System.Windows.Forms.ComboBox();
            this.cb2072_4_3 = new System.Windows.Forms.ComboBox();
            this.cb2072_4_2 = new System.Windows.Forms.ComboBox();
            this.cb2072_4_1 = new System.Windows.Forms.ComboBox();
            this.label58 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.cb2072_3_5 = new System.Windows.Forms.ComboBox();
            this.label64 = new System.Windows.Forms.Label();
            this.cb2072_3_4 = new System.Windows.Forms.ComboBox();
            this.label65 = new System.Windows.Forms.Label();
            this.cb2072_3_3 = new System.Windows.Forms.ComboBox();
            this.label60 = new System.Windows.Forms.Label();
            this.btn2072_3 = new System.Windows.Forms.Button();
            this.cb2072_3_2 = new System.Windows.Forms.ComboBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.btn2072_2 = new System.Windows.Forms.Button();
            this.label61 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.btn2072_1 = new System.Windows.Forms.Button();
            this.cb2072_1_12 = new System.Windows.Forms.ComboBox();
            this.cb2072_1_11 = new System.Windows.Forms.ComboBox();
            this.cb2072_1_10 = new System.Windows.Forms.ComboBox();
            this.cb2072_1_9 = new System.Windows.Forms.ComboBox();
            this.cb2072_1_8 = new System.Windows.Forms.ComboBox();
            this.cb2072_1_7 = new System.Windows.Forms.ComboBox();
            this.cb2072_1_6 = new System.Windows.Forms.ComboBox();
            this.cb2072_1_5 = new System.Windows.Forms.ComboBox();
            this.cb2072_1_4 = new System.Windows.Forms.ComboBox();
            this.cb2072_1_3 = new System.Windows.Forms.ComboBox();
            this.cb2072_1_2 = new System.Windows.Forms.ComboBox();
            this.cb2072_1_1 = new System.Windows.Forms.ComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRead2072 = new System.Windows.Forms.Button();
            this.btn2072Simple2_TryCalc = new System.Windows.Forms.Button();
            this.gpSimple2019 = new System.Windows.Forms.GroupBox();
            this.label215 = new System.Windows.Forms.Label();
            this.btnSet2019Simple_All = new System.Windows.Forms.Button();
            this.label216 = new System.Windows.Forms.Label();
            this.label217 = new System.Windows.Forms.Label();
            this.label218 = new System.Windows.Forms.Label();
            this.btnSet2019Simple_163 = new System.Windows.Forms.Button();
            this.input2019Simple_163 = new System.Windows.Forms.NumericUpDown();
            this.label219 = new System.Windows.Forms.Label();
            this.btnSet2019Simple_162 = new System.Windows.Forms.Button();
            this.input2019Simple_162 = new System.Windows.Forms.NumericUpDown();
            this.label220 = new System.Windows.Forms.Label();
            this.btnSet2019Simple_161 = new System.Windows.Forms.Button();
            this.input2019Simple_161 = new System.Windows.Forms.NumericUpDown();
            this.label221 = new System.Windows.Forms.Label();
            this.btnSet2019Simple_160 = new System.Windows.Forms.Button();
            this.input2019Simple_160 = new System.Windows.Forms.NumericUpDown();
            this.label222 = new System.Windows.Forms.Label();
            this.gpSimple2072GAMMA = new System.Windows.Forms.GroupBox();
            this.label201 = new System.Windows.Forms.Label();
            this.btn2072SimpleSendGAMMAFile = new System.Windows.Forms.Button();
            this.btnSimple2072CreateGAMMAFile = new System.Windows.Forms.Button();
            this.tbSimple2072GAMMAVal = new System.Windows.Forms.TextBox();
            this.btn2072SimpleCalcGAMMASend = new System.Windows.Forms.Button();
            this.label205 = new System.Windows.Forms.Label();
            this.cb2072SimpleGAMMA = new System.Windows.Forms.ComboBox();
            this.cb2072Simple5060Hz = new System.Windows.Forms.ComboBox();
            this.btn2072Simple_SendAll = new System.Windows.Forms.Button();
            this.btn2072Simple_ExportFile = new System.Windows.Forms.Button();
            this.btn2072Simple_ImportFile = new System.Windows.Forms.Button();
            this.btn2072Simple_ResetValues = new System.Windows.Forms.Button();
            this.gP2072Simple13 = new System.Windows.Forms.GroupBox();
            this.btn2072Simple13_All = new System.Windows.Forms.Button();
            this.label198 = new System.Windows.Forms.Label();
            this.input2072Simple13_B = new System.Windows.Forms.NumericUpDown();
            this.btn2072Simple13_B = new System.Windows.Forms.Button();
            this.label199 = new System.Windows.Forms.Label();
            this.input2072Simple13_G = new System.Windows.Forms.NumericUpDown();
            this.btn2072Simple13_G = new System.Windows.Forms.Button();
            this.label200 = new System.Windows.Forms.Label();
            this.input2072Simple13_R = new System.Windows.Forms.NumericUpDown();
            this.btn2072Simple13_R = new System.Windows.Forms.Button();
            this.gP2072Simple12 = new System.Windows.Forms.GroupBox();
            this.btn2072Simple12_All = new System.Windows.Forms.Button();
            this.label195 = new System.Windows.Forms.Label();
            this.input2072Simple12_B = new System.Windows.Forms.NumericUpDown();
            this.btn2072Simple12_B = new System.Windows.Forms.Button();
            this.label196 = new System.Windows.Forms.Label();
            this.input2072Simple12_G = new System.Windows.Forms.NumericUpDown();
            this.btn2072Simple12_G = new System.Windows.Forms.Button();
            this.label197 = new System.Windows.Forms.Label();
            this.input2072Simple12_R = new System.Windows.Forms.NumericUpDown();
            this.btn2072Simple12_R = new System.Windows.Forms.Button();
            this.gP2072Simple11 = new System.Windows.Forms.GroupBox();
            this.btn2072Simple11_All = new System.Windows.Forms.Button();
            this.label192 = new System.Windows.Forms.Label();
            this.input2072Simple11_B = new System.Windows.Forms.NumericUpDown();
            this.btn2072Simple11_B = new System.Windows.Forms.Button();
            this.label193 = new System.Windows.Forms.Label();
            this.input2072Simple11_G = new System.Windows.Forms.NumericUpDown();
            this.btn2072Simple11_G = new System.Windows.Forms.Button();
            this.label194 = new System.Windows.Forms.Label();
            this.input2072Simple11_R = new System.Windows.Forms.NumericUpDown();
            this.btn2072Simple11_R = new System.Windows.Forms.Button();
            this.gP2072Simple10 = new System.Windows.Forms.GroupBox();
            this.btn2072Simple10_All = new System.Windows.Forms.Button();
            this.label189 = new System.Windows.Forms.Label();
            this.input2072Simple10_B = new System.Windows.Forms.NumericUpDown();
            this.btn2072Simple10_B = new System.Windows.Forms.Button();
            this.label190 = new System.Windows.Forms.Label();
            this.input2072Simple10_G = new System.Windows.Forms.NumericUpDown();
            this.btn2072Simple10_G = new System.Windows.Forms.Button();
            this.label191 = new System.Windows.Forms.Label();
            this.input2072Simple10_R = new System.Windows.Forms.NumericUpDown();
            this.btn2072Simple10_R = new System.Windows.Forms.Button();
            this.gP2072Simple9 = new System.Windows.Forms.GroupBox();
            this.btn2072Simple9_All = new System.Windows.Forms.Button();
            this.label186 = new System.Windows.Forms.Label();
            this.input2072Simple9_B = new System.Windows.Forms.NumericUpDown();
            this.btn2072Simple9_B = new System.Windows.Forms.Button();
            this.label187 = new System.Windows.Forms.Label();
            this.input2072Simple9_G = new System.Windows.Forms.NumericUpDown();
            this.btn2072Simple9_G = new System.Windows.Forms.Button();
            this.label188 = new System.Windows.Forms.Label();
            this.input2072Simple9_R = new System.Windows.Forms.NumericUpDown();
            this.btn2072Simple9_R = new System.Windows.Forms.Button();
            this.gP2072Simple8 = new System.Windows.Forms.GroupBox();
            this.btn2072Simple8_All = new System.Windows.Forms.Button();
            this.label185 = new System.Windows.Forms.Label();
            this.input2072Simple8_B = new System.Windows.Forms.NumericUpDown();
            this.btn2072Simple8_B = new System.Windows.Forms.Button();
            this.label172 = new System.Windows.Forms.Label();
            this.input2072Simple8_G = new System.Windows.Forms.NumericUpDown();
            this.btn2072Simple8_G = new System.Windows.Forms.Button();
            this.label170 = new System.Windows.Forms.Label();
            this.input2072Simple8_R = new System.Windows.Forms.NumericUpDown();
            this.btn2072Simple8_R = new System.Windows.Forms.Button();
            this.gP2072Simple6 = new System.Windows.Forms.GroupBox();
            this.input2072Simple6 = new System.Windows.Forms.NumericUpDown();
            this.btn2072Simple6 = new System.Windows.Forms.Button();
            this.gP2072Simple5 = new System.Windows.Forms.GroupBox();
            this.input2072Simple5 = new System.Windows.Forms.NumericUpDown();
            this.btn2072Simple5 = new System.Windows.Forms.Button();
            this.gP2072Simple4 = new System.Windows.Forms.GroupBox();
            this.input2072Simple4 = new System.Windows.Forms.NumericUpDown();
            this.btn2072Simple4 = new System.Windows.Forms.Button();
            this.gP2072Simple7 = new System.Windows.Forms.GroupBox();
            this.btn2072Simple7_Calc = new System.Windows.Forms.Button();
            this.input2072Simple7 = new System.Windows.Forms.NumericUpDown();
            this.btn2072Simple7 = new System.Windows.Forms.Button();
            this.gP2072Simple3 = new System.Windows.Forms.GroupBox();
            this.input2072Simple3 = new System.Windows.Forms.NumericUpDown();
            this.btn2072Simple3 = new System.Windows.Forms.Button();
            this.gP2072Simple2 = new System.Windows.Forms.GroupBox();
            this.btn2072Simple2_Calc = new System.Windows.Forms.Button();
            this.input2072Simple2 = new System.Windows.Forms.NumericUpDown();
            this.btn2072Simple2 = new System.Windows.Forms.Button();
            this.gP2072Simple1 = new System.Windows.Forms.GroupBox();
            this.cb2072Simple1 = new System.Windows.Forms.ComboBox();
            this.btn2072Simple1 = new System.Windows.Forms.Button();
            this.gp2072FuncTest = new System.Windows.Forms.GroupBox();
            this.input2072FuncRegAddr = new System.Windows.Forms.TextBox();
            this.input2072FuncVal = new System.Windows.Forms.TextBox();
            this.btn2072FuncTest = new System.Windows.Forms.Button();
            this.label157 = new System.Windows.Forms.Label();
            this.label153 = new System.Windows.Forms.Label();
            this.cb2072FuncTest3 = new System.Windows.Forms.ComboBox();
            this.label152 = new System.Windows.Forms.Label();
            this.label150 = new System.Windows.Forms.Label();
            this.cb2072FuncTest2 = new System.Windows.Forms.ComboBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.gp2072FactoryRegister = new System.Windows.Forms.GroupBox();
            this.input2072FactoryRegisterAddr = new System.Windows.Forms.TextBox();
            this.input2072FactoryRegisterVal = new System.Windows.Forms.TextBox();
            this.btn2072FactoryRegisterSet = new System.Windows.Forms.Button();
            this.lb2072FactoryRegister4 = new System.Windows.Forms.Label();
            this.lb2072FactoryRegister3 = new System.Windows.Forms.Label();
            this.cb2072FactoryRegister_EndBit = new System.Windows.Forms.ComboBox();
            this.lb2072FactoryRegister2 = new System.Windows.Forms.Label();
            this.lb2072FactoryRegister1 = new System.Windows.Forms.Label();
            this.cb2072FactoryRegister_StartBit = new System.Windows.Forms.ComboBox();
            this.cb2072Factory5060Hz = new System.Windows.Forms.ComboBox();
            this.btn2072Factory_SendAll = new System.Windows.Forms.Button();
            this.btn2072FactoryExport = new System.Windows.Forms.Button();
            this.btn2072FactoryImport = new System.Windows.Forms.Button();
            this.gp2072Factory_CurrentGain = new System.Windows.Forms.GroupBox();
            this.btnSet2072FactoryCurrentGain_All = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.input2072Factory_CurrentGain_B = new System.Windows.Forms.NumericUpDown();
            this.btnSet2072FactoryCurrentGain_B = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.input2072Factory_CurrentGain_G = new System.Windows.Forms.NumericUpDown();
            this.btnSet2072FactoryCurrentGain_G = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.input2072Factory_CurrentGain_R = new System.Windows.Forms.NumericUpDown();
            this.btnSet2072FactoryCurrentGain_R = new System.Windows.Forms.Button();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.button17 = new System.Windows.Forms.Button();
            this.label74 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.btnGainAll = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.numGainB = new System.Windows.Forms.NumericUpDown();
            this.btnGainB = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.numGainG = new System.Windows.Forms.NumericUpDown();
            this.btnGainG = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.numGainR = new System.Windows.Forms.NumericUpDown();
            this.btnGainR = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.rtRead = new System.Windows.Forms.RichTextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.rt2072 = new System.Windows.Forms.RichTextBox();
            this.tabTest = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label103 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.tbVol2 = new System.Windows.Forms.TrackBar();
            this.btnSetVol = new System.Windows.Forms.Button();
            this.tbVol = new System.Windows.Forms.TrackBar();
            this.button16 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.btnStopBatchWriteCal = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.numStopRow = new System.Windows.Forms.NumericUpDown();
            this.numStartRow = new System.Windows.Forms.NumericUpDown();
            this.txtBatchFolder = new System.Windows.Forms.TextBox();
            this.txtBatchCalibrationFolder = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.btnBatchWriteCalibration = new System.Windows.Forms.Button();
            this.btnChoseBatchFolder = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.btnSelectBatchCalibrationFolder = new System.Windows.Forms.Button();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.btnSelectLableNameFile = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.txtPathLabelNameFile = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.txtCompareFile2 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtCompareFile1 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.rtCompare = new System.Windows.Forms.RichTextBox();
            this.btnCompareChose2 = new System.Windows.Forms.Button();
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnCompareChose1 = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.btnSDRAMToFlash = new System.Windows.Forms.Button();
            this.btnSetB6B7 = new System.Windows.Forms.Button();
            this.btnOpenCalibration = new System.Windows.Forms.Button();
            this.btnUpgradeCalibration = new System.Windows.Forms.Button();
            this.txtCalibration = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
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
            this.btnOnekeyDownSDRAM = new System.Windows.Forms.Button();
            this.btnReadSDRAM = new System.Windows.Forms.Button();
            this.btnSDRAMWriteToFlash = new System.Windows.Forms.Button();
            this.btnCreateAndWriteSDRAM = new System.Windows.Forms.Button();
            this.numSDRAMDataLength = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numSDRAMAddr = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.gpTest = new System.Windows.Forms.GroupBox();
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
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
            this.gpVolumn = new System.Windows.Forms.GroupBox();
            this.tbVolumn1 = new System.Windows.Forms.TrackBar();
            this.tbVolumn2 = new System.Windows.Forms.TrackBar();
            this.lblVolumn2 = new System.Windows.Forms.Label();
            this.lblVolumn1 = new System.Windows.Forms.Label();
            this.tabCommonCommand.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGammaBit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGamma)).BeginInit();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.gbBrightness.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrightness)).BeginInit();
            this.tab2055Param.SuspendLayout();
            this.tabAdvance.SuspendLayout();
            this.groupBox20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRed)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSingleRegValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSingleRegAddr)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.gpFirmwareUpgrade.SuspendLayout();
            this.tab2055.SuspendLayout();
            this.tabRegister.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid2055)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOtherReg)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPreview128Reg)).BeginInit();
            this.gp2019Config.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input2019_163)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2019_162)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2019_161)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2019_160)).BeginInit();
            this.groupBox15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_7_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_3_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_17_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_16_8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_16_7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_14_7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_14_6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_14_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_9_6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_9_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_9_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_2_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_2_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_2_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_2_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_3_6)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gpSimple2019.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input2019Simple_163)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2019Simple_162)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2019Simple_161)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2019Simple_160)).BeginInit();
            this.gpSimple2072GAMMA.SuspendLayout();
            this.gP2072Simple13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple13_B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple13_G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple13_R)).BeginInit();
            this.gP2072Simple12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple12_B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple12_G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple12_R)).BeginInit();
            this.gP2072Simple11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple11_B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple11_G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple11_R)).BeginInit();
            this.gP2072Simple10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple10_B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple10_G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple10_R)).BeginInit();
            this.gP2072Simple9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple9_B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple9_G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple9_R)).BeginInit();
            this.gP2072Simple8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple8_B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple8_G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple8_R)).BeginInit();
            this.gP2072Simple6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple6)).BeginInit();
            this.gP2072Simple5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple5)).BeginInit();
            this.gP2072Simple4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple4)).BeginInit();
            this.gP2072Simple7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple7)).BeginInit();
            this.gP2072Simple3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple3)).BeginInit();
            this.gP2072Simple2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple2)).BeginInit();
            this.gP2072Simple1.SuspendLayout();
            this.gp2072FuncTest.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.gp2072FactoryRegister.SuspendLayout();
            this.gp2072Factory_CurrentGain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Factory_CurrentGain_B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Factory_CurrentGain_G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Factory_CurrentGain_R)).BeginInit();
            this.tabPage8.SuspendLayout();
            this.groupBox16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGainB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGainG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGainR)).BeginInit();
            this.tabTest.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVol2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVol)).BeginInit();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStopRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartRow)).BeginInit();
            this.groupBox14.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFlashDataLen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRegAddr)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSDRAMDataLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSDRAMAddr)).BeginInit();
            this.gpTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTestDataLen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeDelay)).BeginInit();
            this.gpVolumn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolumn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolumn2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCommonCommand
            // 
            this.tabCommonCommand.BackColor = System.Drawing.SystemColors.Control;
            this.tabCommonCommand.Controls.Add(this.gpVolumn);
            this.tabCommonCommand.Controls.Add(this.groupBox21);
            this.tabCommonCommand.Controls.Add(this.groupBox5);
            this.tabCommonCommand.Controls.Add(this.groupBox11);
            this.tabCommonCommand.Controls.Add(this.groupBox10);
            this.tabCommonCommand.Controls.Add(this.gbBrightness);
            this.tabCommonCommand.Location = new System.Drawing.Point(4, 22);
            this.tabCommonCommand.Name = "tabCommonCommand";
            this.tabCommonCommand.Padding = new System.Windows.Forms.Padding(3);
            this.tabCommonCommand.Size = new System.Drawing.Size(1513, 804);
            this.tabCommonCommand.TabIndex = 0;
            this.tabCommonCommand.Text = "常用命令";
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.btnChoseGammaFile);
            this.groupBox21.Controls.Add(this.txtGammaFile);
            this.groupBox21.Controls.Add(this.cbGammFileColor);
            this.groupBox21.Controls.Add(this.btnWriteGammaFile);
            this.groupBox21.Location = new System.Drawing.Point(498, 75);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(489, 54);
            this.groupBox21.TabIndex = 21;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "GAMMA文件下载";
            // 
            // btnChoseGammaFile
            // 
            this.btnChoseGammaFile.Location = new System.Drawing.Point(368, 19);
            this.btnChoseGammaFile.Name = "btnChoseGammaFile";
            this.btnChoseGammaFile.Size = new System.Drawing.Size(39, 23);
            this.btnChoseGammaFile.TabIndex = 5;
            this.btnChoseGammaFile.Text = "...";
            this.btnChoseGammaFile.UseVisualStyleBackColor = true;
            this.btnChoseGammaFile.Click += new System.EventHandler(this.btnChoseGammaFile_Click);
            // 
            // txtGammaFile
            // 
            this.txtGammaFile.Location = new System.Drawing.Point(89, 20);
            this.txtGammaFile.Name = "txtGammaFile";
            this.txtGammaFile.Size = new System.Drawing.Size(273, 21);
            this.txtGammaFile.TabIndex = 4;
            // 
            // cbGammFileColor
            // 
            this.cbGammFileColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGammFileColor.FormattingEnabled = true;
            this.cbGammFileColor.Location = new System.Drawing.Point(7, 20);
            this.cbGammFileColor.Name = "cbGammFileColor";
            this.cbGammFileColor.Size = new System.Drawing.Size(76, 20);
            this.cbGammFileColor.TabIndex = 3;
            // 
            // btnWriteGammaFile
            // 
            this.btnWriteGammaFile.Location = new System.Drawing.Point(411, 19);
            this.btnWriteGammaFile.Name = "btnWriteGammaFile";
            this.btnWriteGammaFile.Size = new System.Drawing.Size(65, 23);
            this.btnWriteGammaFile.TabIndex = 2;
            this.btnWriteGammaFile.Text = "写入";
            this.btnWriteGammaFile.UseVisualStyleBackColor = true;
            this.btnWriteGammaFile.Click += new System.EventHandler(this.btnWriteGammaFile_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.numGammaBit);
            this.groupBox5.Controls.Add(this.btnCreateGammaFile);
            this.groupBox5.Controls.Add(this.numGamma);
            this.groupBox5.Controls.Add(this.cbGammaColor);
            this.groupBox5.Controls.Add(this.cbGammaBit);
            this.groupBox5.Controls.Add(this.btnGammaRead);
            this.groupBox5.Controls.Add(this.btnGammaSet);
            this.groupBox5.Location = new System.Drawing.Point(498, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(489, 63);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "GAMMA设置";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 12);
            this.label11.TabIndex = 7;
            this.label11.Text = "Bit";
            // 
            // numGammaBit
            // 
            this.numGammaBit.Location = new System.Drawing.Point(42, 24);
            this.numGammaBit.Name = "numGammaBit";
            this.numGammaBit.Size = new System.Drawing.Size(56, 21);
            this.numGammaBit.TabIndex = 6;
            this.numGammaBit.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            // 
            // btnCreateGammaFile
            // 
            this.btnCreateGammaFile.Location = new System.Drawing.Point(413, 23);
            this.btnCreateGammaFile.Name = "btnCreateGammaFile";
            this.btnCreateGammaFile.Size = new System.Drawing.Size(65, 23);
            this.btnCreateGammaFile.TabIndex = 5;
            this.btnCreateGammaFile.Text = "生成文件";
            this.btnCreateGammaFile.UseVisualStyleBackColor = true;
            this.btnCreateGammaFile.Click += new System.EventHandler(this.btnCreateGammaFile_Click);
            // 
            // numGamma
            // 
            this.numGamma.DecimalPlaces = 1;
            this.numGamma.Location = new System.Drawing.Point(188, 25);
            this.numGamma.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numGamma.Name = "numGamma";
            this.numGamma.Size = new System.Drawing.Size(77, 21);
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
            this.cbGammaColor.Location = new System.Drawing.Point(106, 25);
            this.cbGammaColor.Name = "cbGammaColor";
            this.cbGammaColor.Size = new System.Drawing.Size(76, 20);
            this.cbGammaColor.TabIndex = 3;
            // 
            // cbGammaBit
            // 
            this.cbGammaBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGammaBit.FormattingEnabled = true;
            this.cbGammaBit.Location = new System.Drawing.Point(89, 51);
            this.cbGammaBit.Name = "cbGammaBit";
            this.cbGammaBit.Size = new System.Drawing.Size(76, 20);
            this.cbGammaBit.TabIndex = 3;
            this.cbGammaBit.Visible = false;
            // 
            // btnGammaRead
            // 
            this.btnGammaRead.Location = new System.Drawing.Point(342, 23);
            this.btnGammaRead.Name = "btnGammaRead";
            this.btnGammaRead.Size = new System.Drawing.Size(65, 23);
            this.btnGammaRead.TabIndex = 2;
            this.btnGammaRead.Text = "读取";
            this.btnGammaRead.UseVisualStyleBackColor = true;
            this.btnGammaRead.Click += new System.EventHandler(this.btnGammaRead_Click);
            // 
            // btnGammaSet
            // 
            this.btnGammaSet.Location = new System.Drawing.Point(271, 23);
            this.btnGammaSet.Name = "btnGammaSet";
            this.btnGammaSet.Size = new System.Drawing.Size(65, 23);
            this.btnGammaSet.TabIndex = 2;
            this.btnGammaSet.Text = "写入";
            this.btnGammaSet.UseVisualStyleBackColor = true;
            this.btnGammaSet.Click += new System.EventHandler(this.btnGammaSet_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.cbCalibrationOnOff);
            this.groupBox11.Controls.Add(this.btnSendCalibrationOnOff);
            this.groupBox11.Location = new System.Drawing.Point(266, 75);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(226, 54);
            this.groupBox11.TabIndex = 20;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "校正开关";
            // 
            // cbCalibrationOnOff
            // 
            this.cbCalibrationOnOff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCalibrationOnOff.FormattingEnabled = true;
            this.cbCalibrationOnOff.Location = new System.Drawing.Point(12, 20);
            this.cbCalibrationOnOff.Name = "cbCalibrationOnOff";
            this.cbCalibrationOnOff.Size = new System.Drawing.Size(121, 20);
            this.cbCalibrationOnOff.TabIndex = 20;
            // 
            // btnSendCalibrationOnOff
            // 
            this.btnSendCalibrationOnOff.Location = new System.Drawing.Point(139, 17);
            this.btnSendCalibrationOnOff.Name = "btnSendCalibrationOnOff";
            this.btnSendCalibrationOnOff.Size = new System.Drawing.Size(75, 23);
            this.btnSendCalibrationOnOff.TabIndex = 1;
            this.btnSendCalibrationOnOff.Text = "设置";
            this.btnSendCalibrationOnOff.UseVisualStyleBackColor = true;
            this.btnSendCalibrationOnOff.Click += new System.EventHandler(this.btnSendCalibrationOnOff_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.button5);
            this.groupBox10.Controls.Add(this.cbWorkMode);
            this.groupBox10.Location = new System.Drawing.Point(8, 75);
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
            this.button5.Text = "设置";
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
            this.tab2055Param.Controls.Add(this.tab2055);
            this.tab2055Param.Controls.Add(this.tabPage3);
            this.tab2055Param.Controls.Add(this.tabTest);
            this.tab2055Param.Location = new System.Drawing.Point(0, 3);
            this.tab2055Param.Name = "tab2055Param";
            this.tab2055Param.SelectedIndex = 0;
            this.tab2055Param.Size = new System.Drawing.Size(1521, 830);
            this.tab2055Param.TabIndex = 0;
            this.tab2055Param.SelectedIndexChanged += new System.EventHandler(this.tab2055Param_SelectedIndexChanged);
            // 
            // tabAdvance
            // 
            this.tabAdvance.BackColor = System.Drawing.SystemColors.Control;
            this.tabAdvance.Controls.Add(this.groupBox20);
            this.tabAdvance.Controls.Add(this.groupBox7);
            this.tabAdvance.Controls.Add(this.groupBox18);
            this.tabAdvance.Controls.Add(this.groupBox17);
            this.tabAdvance.Controls.Add(this.groupBox19);
            this.tabAdvance.Controls.Add(this.groupBox9);
            this.tabAdvance.Controls.Add(this.groupBox4);
            this.tabAdvance.Controls.Add(this.groupBox6);
            this.tabAdvance.Controls.Add(this.gpFirmwareUpgrade);
            this.tabAdvance.Location = new System.Drawing.Point(4, 22);
            this.tabAdvance.Name = "tabAdvance";
            this.tabAdvance.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdvance.Size = new System.Drawing.Size(1513, 804);
            this.tabAdvance.TabIndex = 3;
            this.tabAdvance.Text = "高级";
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.label39);
            this.groupBox20.Controls.Add(this.cbChipType);
            this.groupBox20.Controls.Add(this.label50);
            this.groupBox20.Controls.Add(this.label59);
            this.groupBox20.Controls.Add(this.numBlue);
            this.groupBox20.Controls.Add(this.numGreen);
            this.groupBox20.Controls.Add(this.numRed);
            this.groupBox20.Controls.Add(this.btnReadGain);
            this.groupBox20.Controls.Add(this.btnSetGain);
            this.groupBox20.Location = new System.Drawing.Point(775, 261);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(294, 170);
            this.groupBox20.TabIndex = 22;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "电流增益设置";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(24, 110);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(41, 12);
            this.label39.TabIndex = 14;
            this.label39.Text = "蓝色：";
            // 
            // cbChipType
            // 
            this.cbChipType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChipType.FormattingEnabled = true;
            this.cbChipType.Location = new System.Drawing.Point(26, 26);
            this.cbChipType.Name = "cbChipType";
            this.cbChipType.Size = new System.Drawing.Size(170, 20);
            this.cbChipType.TabIndex = 17;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(24, 83);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(41, 12);
            this.label50.TabIndex = 15;
            this.label50.Text = "绿色：";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(24, 56);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(41, 12);
            this.label59.TabIndex = 16;
            this.label59.Text = "红色：";
            // 
            // numBlue
            // 
            this.numBlue.Location = new System.Drawing.Point(71, 106);
            this.numBlue.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numBlue.Name = "numBlue";
            this.numBlue.Size = new System.Drawing.Size(125, 21);
            this.numBlue.TabIndex = 11;
            // 
            // numGreen
            // 
            this.numGreen.Location = new System.Drawing.Point(71, 79);
            this.numGreen.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numGreen.Name = "numGreen";
            this.numGreen.Size = new System.Drawing.Size(125, 21);
            this.numGreen.TabIndex = 12;
            // 
            // numRed
            // 
            this.numRed.Location = new System.Drawing.Point(71, 52);
            this.numRed.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numRed.Name = "numRed";
            this.numRed.Size = new System.Drawing.Size(125, 21);
            this.numRed.TabIndex = 13;
            // 
            // btnReadGain
            // 
            this.btnReadGain.Location = new System.Drawing.Point(211, 53);
            this.btnReadGain.Name = "btnReadGain";
            this.btnReadGain.Size = new System.Drawing.Size(75, 23);
            this.btnReadGain.TabIndex = 10;
            this.btnReadGain.Text = "读取";
            this.btnReadGain.UseVisualStyleBackColor = true;
            this.btnReadGain.Click += new System.EventHandler(this.btnReadGain_Click);
            // 
            // btnSetGain
            // 
            this.btnSetGain.Location = new System.Drawing.Point(211, 26);
            this.btnSetGain.Name = "btnSetGain";
            this.btnSetGain.Size = new System.Drawing.Size(75, 23);
            this.btnSetGain.TabIndex = 8;
            this.btnSetGain.Text = "设置";
            this.btnSetGain.UseVisualStyleBackColor = true;
            this.btnSetGain.Click += new System.EventHandler(this.btnSetGain_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnStopWriteCal);
            this.groupBox7.Controls.Add(this.txtBatchWriteCalibrationFolder);
            this.groupBox7.Controls.Add(this.label38);
            this.groupBox7.Controls.Add(this.btnBatchWriteCal);
            this.groupBox7.Controls.Add(this.btnChoseBatchCalibrationFolder);
            this.groupBox7.Location = new System.Drawing.Point(9, 367);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(760, 64);
            this.groupBox7.TabIndex = 21;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "校正数据批量写入";
            // 
            // btnStopWriteCal
            // 
            this.btnStopWriteCal.Location = new System.Drawing.Point(673, 23);
            this.btnStopWriteCal.Name = "btnStopWriteCal";
            this.btnStopWriteCal.Size = new System.Drawing.Size(75, 23);
            this.btnStopWriteCal.TabIndex = 28;
            this.btnStopWriteCal.Text = "停止";
            this.btnStopWriteCal.UseVisualStyleBackColor = true;
            this.btnStopWriteCal.Click += new System.EventHandler(this.btnStopWriteCal_Click);
            // 
            // txtBatchWriteCalibrationFolder
            // 
            this.txtBatchWriteCalibrationFolder.Location = new System.Drawing.Point(76, 24);
            this.txtBatchWriteCalibrationFolder.Name = "txtBatchWriteCalibrationFolder";
            this.txtBatchWriteCalibrationFolder.Size = new System.Drawing.Size(467, 21);
            this.txtBatchWriteCalibrationFolder.TabIndex = 21;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(21, 28);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(47, 12);
            this.label38.TabIndex = 20;
            this.label38.Text = "文件夹:";
            // 
            // btnBatchWriteCal
            // 
            this.btnBatchWriteCal.Location = new System.Drawing.Point(594, 23);
            this.btnBatchWriteCal.Name = "btnBatchWriteCal";
            this.btnBatchWriteCal.Size = new System.Drawing.Size(73, 23);
            this.btnBatchWriteCal.TabIndex = 23;
            this.btnBatchWriteCal.Text = "写入";
            this.btnBatchWriteCal.UseVisualStyleBackColor = true;
            this.btnBatchWriteCal.Click += new System.EventHandler(this.btnBatchWriteCal_Click);
            // 
            // btnChoseBatchCalibrationFolder
            // 
            this.btnChoseBatchCalibrationFolder.Location = new System.Drawing.Point(549, 22);
            this.btnChoseBatchCalibrationFolder.Name = "btnChoseBatchCalibrationFolder";
            this.btnChoseBatchCalibrationFolder.Size = new System.Drawing.Size(39, 23);
            this.btnChoseBatchCalibrationFolder.TabIndex = 22;
            this.btnChoseBatchCalibrationFolder.Text = "...";
            this.btnChoseBatchCalibrationFolder.UseVisualStyleBackColor = true;
            this.btnChoseBatchCalibrationFolder.Click += new System.EventHandler(this.btnChoseBatchCalibrationFolder_Click);
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.cbSNCreate);
            this.groupBox18.Controls.Add(this.cbSNPos);
            this.groupBox18.Controls.Add(this.btnReadSN);
            this.groupBox18.Controls.Add(this.btnCreateSN);
            this.groupBox18.Location = new System.Drawing.Point(322, 9);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(447, 51);
            this.groupBox18.TabIndex = 8;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "时间码写入、读取";
            // 
            // cbSNCreate
            // 
            this.cbSNCreate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSNCreate.FormattingEnabled = true;
            this.cbSNCreate.Location = new System.Drawing.Point(167, 19);
            this.cbSNCreate.Name = "cbSNCreate";
            this.cbSNCreate.Size = new System.Drawing.Size(108, 20);
            this.cbSNCreate.TabIndex = 18;
            // 
            // cbSNPos
            // 
            this.cbSNPos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSNPos.FormattingEnabled = true;
            this.cbSNPos.Location = new System.Drawing.Point(19, 19);
            this.cbSNPos.Name = "cbSNPos";
            this.cbSNPos.Size = new System.Drawing.Size(142, 20);
            this.cbSNPos.TabIndex = 17;
            // 
            // btnReadSN
            // 
            this.btnReadSN.Location = new System.Drawing.Point(360, 18);
            this.btnReadSN.Name = "btnReadSN";
            this.btnReadSN.Size = new System.Drawing.Size(75, 23);
            this.btnReadSN.TabIndex = 7;
            this.btnReadSN.Text = "读取";
            this.btnReadSN.UseVisualStyleBackColor = true;
            this.btnReadSN.Click += new System.EventHandler(this.btnReadSN_Click);
            // 
            // btnCreateSN
            // 
            this.btnCreateSN.Location = new System.Drawing.Point(279, 17);
            this.btnCreateSN.Name = "btnCreateSN";
            this.btnCreateSN.Size = new System.Drawing.Size(75, 23);
            this.btnCreateSN.TabIndex = 7;
            this.btnCreateSN.Text = "写入";
            this.btnCreateSN.UseVisualStyleBackColor = true;
            this.btnCreateSN.Click += new System.EventHandler(this.btnCreateSN_Click);
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.cbBoardPos);
            this.groupBox17.Controls.Add(this.btnReadCalibration);
            this.groupBox17.Controls.Add(this.txtCalibrationFile);
            this.groupBox17.Controls.Add(this.btnUpdateCalibration);
            this.groupBox17.Controls.Add(this.label31);
            this.groupBox17.Controls.Add(this.btnChoseCalibration);
            this.groupBox17.Location = new System.Drawing.Point(8, 309);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(761, 51);
            this.groupBox17.TabIndex = 20;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "校正数据下载";
            // 
            // cbBoardPos
            // 
            this.cbBoardPos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoardPos.FormattingEnabled = true;
            this.cbBoardPos.Location = new System.Drawing.Point(481, 18);
            this.cbBoardPos.Name = "cbBoardPos";
            this.cbBoardPos.Size = new System.Drawing.Size(110, 20);
            this.cbBoardPos.TabIndex = 16;
            // 
            // btnReadCalibration
            // 
            this.btnReadCalibration.Location = new System.Drawing.Point(676, 17);
            this.btnReadCalibration.Name = "btnReadCalibration";
            this.btnReadCalibration.Size = new System.Drawing.Size(75, 23);
            this.btnReadCalibration.TabIndex = 4;
            this.btnReadCalibration.Text = "读取";
            this.btnReadCalibration.UseVisualStyleBackColor = true;
            this.btnReadCalibration.Click += new System.EventHandler(this.btnReadCalibration_Click);
            // 
            // txtCalibrationFile
            // 
            this.txtCalibrationFile.Location = new System.Drawing.Point(77, 17);
            this.txtCalibrationFile.Name = "txtCalibrationFile";
            this.txtCalibrationFile.Size = new System.Drawing.Size(345, 21);
            this.txtCalibrationFile.TabIndex = 5;
            // 
            // btnUpdateCalibration
            // 
            this.btnUpdateCalibration.Location = new System.Drawing.Point(597, 17);
            this.btnUpdateCalibration.Name = "btnUpdateCalibration";
            this.btnUpdateCalibration.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateCalibration.TabIndex = 7;
            this.btnUpdateCalibration.Text = "更新";
            this.btnUpdateCalibration.UseVisualStyleBackColor = true;
            this.btnUpdateCalibration.Click += new System.EventHandler(this.btnUpdateCalibration_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(34, 21);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(35, 12);
            this.label31.TabIndex = 4;
            this.label31.Text = "文件:";
            // 
            // btnChoseCalibration
            // 
            this.btnChoseCalibration.Location = new System.Drawing.Point(436, 17);
            this.btnChoseCalibration.Name = "btnChoseCalibration";
            this.btnChoseCalibration.Size = new System.Drawing.Size(39, 23);
            this.btnChoseCalibration.TabIndex = 6;
            this.btnChoseCalibration.Text = "...";
            this.btnChoseCalibration.UseVisualStyleBackColor = true;
            this.btnChoseCalibration.Click += new System.EventHandler(this.btnChoseCalibration_Click);
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.btnReadColorTemp);
            this.groupBox19.Controls.Add(this.cbChip);
            this.groupBox19.Controls.Add(this.btnSetColorTemp);
            this.groupBox19.Controls.Add(this.cbHz);
            this.groupBox19.Controls.Add(this.cbColorTempType);
            this.groupBox19.Controls.Add(this.btnColorTempConfig);
            this.groupBox19.Location = new System.Drawing.Point(775, 129);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(294, 126);
            this.groupBox19.TabIndex = 19;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "色温设置";
            // 
            // btnReadColorTemp
            // 
            this.btnReadColorTemp.Location = new System.Drawing.Point(213, 82);
            this.btnReadColorTemp.Name = "btnReadColorTemp";
            this.btnReadColorTemp.Size = new System.Drawing.Size(75, 23);
            this.btnReadColorTemp.TabIndex = 10;
            this.btnReadColorTemp.Text = "读取";
            this.btnReadColorTemp.UseVisualStyleBackColor = true;
            this.btnReadColorTemp.Click += new System.EventHandler(this.btnReadColorTemp_Click);
            // 
            // cbChip
            // 
            this.cbChip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChip.FormattingEnabled = true;
            this.cbChip.Location = new System.Drawing.Point(6, 57);
            this.cbChip.Name = "cbChip";
            this.cbChip.Size = new System.Drawing.Size(86, 20);
            this.cbChip.TabIndex = 17;
            // 
            // btnSetColorTemp
            // 
            this.btnSetColorTemp.Location = new System.Drawing.Point(132, 82);
            this.btnSetColorTemp.Name = "btnSetColorTemp";
            this.btnSetColorTemp.Size = new System.Drawing.Size(75, 23);
            this.btnSetColorTemp.TabIndex = 8;
            this.btnSetColorTemp.Text = "设置";
            this.btnSetColorTemp.UseVisualStyleBackColor = true;
            this.btnSetColorTemp.Click += new System.EventHandler(this.btnSetColorTemp_Click);
            // 
            // cbHz
            // 
            this.cbHz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHz.FormattingEnabled = true;
            this.cbHz.Location = new System.Drawing.Point(98, 57);
            this.cbHz.Name = "cbHz";
            this.cbHz.Size = new System.Drawing.Size(92, 20);
            this.cbHz.TabIndex = 7;
            // 
            // cbColorTempType
            // 
            this.cbColorTempType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColorTempType.FormattingEnabled = true;
            this.cbColorTempType.Location = new System.Drawing.Point(196, 57);
            this.cbColorTempType.Name = "cbColorTempType";
            this.cbColorTempType.Size = new System.Drawing.Size(92, 20);
            this.cbColorTempType.TabIndex = 6;
            // 
            // btnColorTempConfig
            // 
            this.btnColorTempConfig.Location = new System.Drawing.Point(17, 21);
            this.btnColorTempConfig.Name = "btnColorTempConfig";
            this.btnColorTempConfig.Size = new System.Drawing.Size(75, 23);
            this.btnColorTempConfig.TabIndex = 3;
            this.btnColorTempConfig.Text = "配置色温";
            this.btnColorTempConfig.UseVisualStyleBackColor = true;
            this.btnColorTempConfig.Click += new System.EventHandler(this.btnColorTempConfig_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btnSingleRegRead);
            this.groupBox9.Controls.Add(this.label19);
            this.groupBox9.Controls.Add(this.btnSetRegister);
            this.groupBox9.Controls.Add(this.numSingleRegValue);
            this.groupBox9.Controls.Add(this.numSingleRegAddr);
            this.groupBox9.Controls.Add(this.label18);
            this.groupBox9.Location = new System.Drawing.Point(775, 16);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(294, 105);
            this.groupBox9.TabIndex = 19;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "寄存器操作";
            // 
            // btnSingleRegRead
            // 
            this.btnSingleRegRead.Location = new System.Drawing.Point(194, 56);
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
            this.label19.Location = new System.Drawing.Point(34, 61);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 12);
            this.label19.TabIndex = 3;
            this.label19.Text = "值：";
            // 
            // btnSetRegister
            // 
            this.btnSetRegister.Location = new System.Drawing.Point(194, 23);
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
            this.numSingleRegValue.Location = new System.Drawing.Point(65, 57);
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
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnLoadVideoCardParam);
            this.groupBox4.Controls.Add(this.cbVideocardLoadParam);
            this.groupBox4.Location = new System.Drawing.Point(322, 66);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(447, 55);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "视频卡加载参数";
            // 
            // btnLoadVideoCardParam
            // 
            this.btnLoadVideoCardParam.Location = new System.Drawing.Point(200, 19);
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
            this.cbVideocardLoadParam.Location = new System.Drawing.Point(19, 20);
            this.cbVideocardLoadParam.Name = "cbVideocardLoadParam";
            this.cbVideocardLoadParam.Size = new System.Drawing.Size(175, 20);
            this.cbVideocardLoadParam.TabIndex = 17;
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
            this.groupBox6.Size = new System.Drawing.Size(307, 112);
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
            this.txtIP.TextChanged += new System.EventHandler(this.txtIP_TextChanged);
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
            this.gpFirmwareUpgrade.Controls.Add(this.btnReadMap);
            this.gpFirmwareUpgrade.Controls.Add(this.btnLoadModuleSection);
            this.gpFirmwareUpgrade.Controls.Add(this.btnLoadFPGA);
            this.gpFirmwareUpgrade.Controls.Add(this.txtMap);
            this.gpFirmwareUpgrade.Controls.Add(this.btnReadDivideVersion);
            this.gpFirmwareUpgrade.Controls.Add(this.btnUpgradeMAP);
            this.gpFirmwareUpgrade.Controls.Add(this.btnReadBoardVersion);
            this.gpFirmwareUpgrade.Controls.Add(this.label16);
            this.gpFirmwareUpgrade.Controls.Add(this.btnReadMbVersion);
            this.gpFirmwareUpgrade.Controls.Add(this.btnChoseMAP);
            this.gpFirmwareUpgrade.Controls.Add(this.btnReadMCUVersion);
            this.gpFirmwareUpgrade.Controls.Add(this.cbDistributeChip);
            this.gpFirmwareUpgrade.Controls.Add(this.cbModuleChip);
            this.gpFirmwareUpgrade.Controls.Add(this.cbMBFPGAChip);
            this.gpFirmwareUpgrade.Controls.Add(this.cbMCUChip);
            this.gpFirmwareUpgrade.Controls.Add(this.btnReadbtnDistributeBoardFPGA);
            this.gpFirmwareUpgrade.Controls.Add(this.btnReadMbFPGA);
            this.gpFirmwareUpgrade.Controls.Add(this.btnReadFPGA);
            this.gpFirmwareUpgrade.Controls.Add(this.btnReadMCU);
            this.gpFirmwareUpgrade.Controls.Add(this.btnUpdateDistributeBoardFPGA);
            this.gpFirmwareUpgrade.Controls.Add(this.btnUpgradeMbFPGA);
            this.gpFirmwareUpgrade.Controls.Add(this.btnUpgradeFPGA);
            this.gpFirmwareUpgrade.Controls.Add(this.btnUpgradeMCU);
            this.gpFirmwareUpgrade.Controls.Add(this.btnChoseDistributeBoardFPGA);
            this.gpFirmwareUpgrade.Controls.Add(this.btnChoseMbFPGA);
            this.gpFirmwareUpgrade.Controls.Add(this.btnChoseFPGA);
            this.gpFirmwareUpgrade.Controls.Add(this.btnChoseMCU);
            this.gpFirmwareUpgrade.Controls.Add(this.txtDistributeBoardFPGA);
            this.gpFirmwareUpgrade.Controls.Add(this.txtMbFPGA);
            this.gpFirmwareUpgrade.Controls.Add(this.txtFPGA);
            this.gpFirmwareUpgrade.Controls.Add(this.label27);
            this.gpFirmwareUpgrade.Controls.Add(this.label23);
            this.gpFirmwareUpgrade.Controls.Add(this.label10);
            this.gpFirmwareUpgrade.Controls.Add(this.txtMcu);
            this.gpFirmwareUpgrade.Controls.Add(this.label8);
            this.gpFirmwareUpgrade.Location = new System.Drawing.Point(8, 125);
            this.gpFirmwareUpgrade.Name = "gpFirmwareUpgrade";
            this.gpFirmwareUpgrade.Size = new System.Drawing.Size(761, 178);
            this.gpFirmwareUpgrade.TabIndex = 0;
            this.gpFirmwareUpgrade.TabStop = false;
            this.gpFirmwareUpgrade.Text = "固件升级";
            // 
            // btnReadMap
            // 
            this.btnReadMap.Location = new System.Drawing.Point(595, 145);
            this.btnReadMap.Name = "btnReadMap";
            this.btnReadMap.Size = new System.Drawing.Size(75, 23);
            this.btnReadMap.TabIndex = 4;
            this.btnReadMap.Text = "读取";
            this.btnReadMap.UseVisualStyleBackColor = true;
            this.btnReadMap.Click += new System.EventHandler(this.btnReadMap_Click);
            // 
            // btnLoadModuleSection
            // 
            this.btnLoadModuleSection.Enabled = false;
            this.btnLoadModuleSection.Location = new System.Drawing.Point(1036, 93);
            this.btnLoadModuleSection.Name = "btnLoadModuleSection";
            this.btnLoadModuleSection.Size = new System.Drawing.Size(75, 23);
            this.btnLoadModuleSection.TabIndex = 20;
            this.btnLoadModuleSection.Text = "加载";
            this.btnLoadModuleSection.UseVisualStyleBackColor = true;
            this.btnLoadModuleSection.Visible = false;
            this.btnLoadModuleSection.Click += new System.EventHandler(this.btnLoadModuleSection_Click);
            // 
            // btnLoadFPGA
            // 
            this.btnLoadFPGA.Enabled = false;
            this.btnLoadFPGA.Location = new System.Drawing.Point(1036, 120);
            this.btnLoadFPGA.Name = "btnLoadFPGA";
            this.btnLoadFPGA.Size = new System.Drawing.Size(75, 23);
            this.btnLoadFPGA.TabIndex = 20;
            this.btnLoadFPGA.Text = "加载";
            this.btnLoadFPGA.UseVisualStyleBackColor = true;
            this.btnLoadFPGA.Visible = false;
            this.btnLoadFPGA.Click += new System.EventHandler(this.btnLoadFPGA_Click);
            // 
            // txtMap
            // 
            this.txtMap.Location = new System.Drawing.Point(79, 146);
            this.txtMap.Name = "txtMap";
            this.txtMap.Size = new System.Drawing.Size(385, 21);
            this.txtMap.TabIndex = 5;
            // 
            // btnReadDivideVersion
            // 
            this.btnReadDivideVersion.Enabled = false;
            this.btnReadDivideVersion.Location = new System.Drawing.Point(955, 120);
            this.btnReadDivideVersion.Name = "btnReadDivideVersion";
            this.btnReadDivideVersion.Size = new System.Drawing.Size(75, 23);
            this.btnReadDivideVersion.TabIndex = 5;
            this.btnReadDivideVersion.Text = "读取版本号";
            this.btnReadDivideVersion.UseVisualStyleBackColor = true;
            this.btnReadDivideVersion.Visible = false;
            this.btnReadDivideVersion.Click += new System.EventHandler(this.btnReadDivideVersion_Click);
            // 
            // btnUpgradeMAP
            // 
            this.btnUpgradeMAP.Location = new System.Drawing.Point(515, 145);
            this.btnUpgradeMAP.Name = "btnUpgradeMAP";
            this.btnUpgradeMAP.Size = new System.Drawing.Size(75, 23);
            this.btnUpgradeMAP.TabIndex = 7;
            this.btnUpgradeMAP.Text = "更新";
            this.btnUpgradeMAP.UseVisualStyleBackColor = true;
            this.btnUpgradeMAP.Click += new System.EventHandler(this.btnUpgradeMAP_Click);
            // 
            // btnReadBoardVersion
            // 
            this.btnReadBoardVersion.Location = new System.Drawing.Point(675, 87);
            this.btnReadBoardVersion.Name = "btnReadBoardVersion";
            this.btnReadBoardVersion.Size = new System.Drawing.Size(75, 23);
            this.btnReadBoardVersion.TabIndex = 5;
            this.btnReadBoardVersion.Text = "读取版本号";
            this.btnReadBoardVersion.UseVisualStyleBackColor = true;
            this.btnReadBoardVersion.Click += new System.EventHandler(this.btnReadBoardVersion_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(44, 150);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 4;
            this.label16.Text = "MAP:";
            // 
            // btnReadMbVersion
            // 
            this.btnReadMbVersion.Location = new System.Drawing.Point(675, 58);
            this.btnReadMbVersion.Name = "btnReadMbVersion";
            this.btnReadMbVersion.Size = new System.Drawing.Size(75, 23);
            this.btnReadMbVersion.TabIndex = 5;
            this.btnReadMbVersion.Text = "读取版本号";
            this.btnReadMbVersion.UseVisualStyleBackColor = true;
            this.btnReadMbVersion.Click += new System.EventHandler(this.btnReadMbVersion_Click);
            // 
            // btnChoseMAP
            // 
            this.btnChoseMAP.Location = new System.Drawing.Point(470, 145);
            this.btnChoseMAP.Name = "btnChoseMAP";
            this.btnChoseMAP.Size = new System.Drawing.Size(39, 23);
            this.btnChoseMAP.TabIndex = 6;
            this.btnChoseMAP.Text = "...";
            this.btnChoseMAP.UseVisualStyleBackColor = true;
            this.btnChoseMAP.Click += new System.EventHandler(this.btnChoseMAP_Click);
            // 
            // btnReadMCUVersion
            // 
            this.btnReadMCUVersion.Location = new System.Drawing.Point(675, 28);
            this.btnReadMCUVersion.Name = "btnReadMCUVersion";
            this.btnReadMCUVersion.Size = new System.Drawing.Size(75, 23);
            this.btnReadMCUVersion.TabIndex = 5;
            this.btnReadMCUVersion.Text = "读取版本号";
            this.btnReadMCUVersion.UseVisualStyleBackColor = true;
            this.btnReadMCUVersion.Click += new System.EventHandler(this.btnReadFirmwareVersion_Click);
            // 
            // cbDistributeChip
            // 
            this.cbDistributeChip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDistributeChip.Enabled = false;
            this.cbDistributeChip.FormattingEnabled = true;
            this.cbDistributeChip.Location = new System.Drawing.Point(676, 121);
            this.cbDistributeChip.Name = "cbDistributeChip";
            this.cbDistributeChip.Size = new System.Drawing.Size(108, 20);
            this.cbDistributeChip.TabIndex = 17;
            this.cbDistributeChip.Visible = false;
            // 
            // cbModuleChip
            // 
            this.cbModuleChip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModuleChip.Enabled = false;
            this.cbModuleChip.FormattingEnabled = true;
            this.cbModuleChip.Location = new System.Drawing.Point(676, 93);
            this.cbModuleChip.Name = "cbModuleChip";
            this.cbModuleChip.Size = new System.Drawing.Size(108, 20);
            this.cbModuleChip.TabIndex = 17;
            this.cbModuleChip.Visible = false;
            // 
            // cbMBFPGAChip
            // 
            this.cbMBFPGAChip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMBFPGAChip.Enabled = false;
            this.cbMBFPGAChip.FormattingEnabled = true;
            this.cbMBFPGAChip.Location = new System.Drawing.Point(676, 59);
            this.cbMBFPGAChip.Name = "cbMBFPGAChip";
            this.cbMBFPGAChip.Size = new System.Drawing.Size(108, 20);
            this.cbMBFPGAChip.TabIndex = 17;
            this.cbMBFPGAChip.Visible = false;
            // 
            // cbMCUChip
            // 
            this.cbMCUChip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMCUChip.Enabled = false;
            this.cbMCUChip.FormattingEnabled = true;
            this.cbMCUChip.Location = new System.Drawing.Point(676, 35);
            this.cbMCUChip.Name = "cbMCUChip";
            this.cbMCUChip.Size = new System.Drawing.Size(108, 20);
            this.cbMCUChip.TabIndex = 17;
            this.cbMCUChip.Visible = false;
            // 
            // btnReadbtnDistributeBoardFPGA
            // 
            this.btnReadbtnDistributeBoardFPGA.Location = new System.Drawing.Point(595, 115);
            this.btnReadbtnDistributeBoardFPGA.Name = "btnReadbtnDistributeBoardFPGA";
            this.btnReadbtnDistributeBoardFPGA.Size = new System.Drawing.Size(75, 23);
            this.btnReadbtnDistributeBoardFPGA.TabIndex = 4;
            this.btnReadbtnDistributeBoardFPGA.Text = "读取";
            this.btnReadbtnDistributeBoardFPGA.UseVisualStyleBackColor = true;
            this.btnReadbtnDistributeBoardFPGA.Visible = false;
            this.btnReadbtnDistributeBoardFPGA.Click += new System.EventHandler(this.btnReadbtnDistributeBoardFPGA_Click);
            // 
            // btnReadMbFPGA
            // 
            this.btnReadMbFPGA.Location = new System.Drawing.Point(595, 58);
            this.btnReadMbFPGA.Name = "btnReadMbFPGA";
            this.btnReadMbFPGA.Size = new System.Drawing.Size(75, 23);
            this.btnReadMbFPGA.TabIndex = 4;
            this.btnReadMbFPGA.Text = "读取";
            this.btnReadMbFPGA.UseVisualStyleBackColor = true;
            this.btnReadMbFPGA.Click += new System.EventHandler(this.btnReadMbFPGA_Click);
            // 
            // btnReadFPGA
            // 
            this.btnReadFPGA.Location = new System.Drawing.Point(595, 87);
            this.btnReadFPGA.Name = "btnReadFPGA";
            this.btnReadFPGA.Size = new System.Drawing.Size(75, 23);
            this.btnReadFPGA.TabIndex = 4;
            this.btnReadFPGA.Text = "读取";
            this.btnReadFPGA.UseVisualStyleBackColor = true;
            this.btnReadFPGA.Click += new System.EventHandler(this.btnReadFPGA_Click);
            // 
            // btnReadMCU
            // 
            this.btnReadMCU.Location = new System.Drawing.Point(595, 28);
            this.btnReadMCU.Name = "btnReadMCU";
            this.btnReadMCU.Size = new System.Drawing.Size(75, 23);
            this.btnReadMCU.TabIndex = 4;
            this.btnReadMCU.Text = "读取";
            this.btnReadMCU.UseVisualStyleBackColor = true;
            this.btnReadMCU.Click += new System.EventHandler(this.btnReadMCU_Click);
            // 
            // btnUpdateDistributeBoardFPGA
            // 
            this.btnUpdateDistributeBoardFPGA.Location = new System.Drawing.Point(515, 115);
            this.btnUpdateDistributeBoardFPGA.Name = "btnUpdateDistributeBoardFPGA";
            this.btnUpdateDistributeBoardFPGA.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateDistributeBoardFPGA.TabIndex = 3;
            this.btnUpdateDistributeBoardFPGA.Text = "更新";
            this.btnUpdateDistributeBoardFPGA.UseVisualStyleBackColor = true;
            this.btnUpdateDistributeBoardFPGA.Click += new System.EventHandler(this.btnUpdateDistributeBoardFPGA_Click);
            // 
            // btnUpgradeMbFPGA
            // 
            this.btnUpgradeMbFPGA.Location = new System.Drawing.Point(515, 58);
            this.btnUpgradeMbFPGA.Name = "btnUpgradeMbFPGA";
            this.btnUpgradeMbFPGA.Size = new System.Drawing.Size(75, 23);
            this.btnUpgradeMbFPGA.TabIndex = 3;
            this.btnUpgradeMbFPGA.Text = "更新";
            this.btnUpgradeMbFPGA.UseVisualStyleBackColor = true;
            this.btnUpgradeMbFPGA.Click += new System.EventHandler(this.btnUpgradeMbFPGA_Click);
            // 
            // btnUpgradeFPGA
            // 
            this.btnUpgradeFPGA.Location = new System.Drawing.Point(515, 87);
            this.btnUpgradeFPGA.Name = "btnUpgradeFPGA";
            this.btnUpgradeFPGA.Size = new System.Drawing.Size(75, 23);
            this.btnUpgradeFPGA.TabIndex = 3;
            this.btnUpgradeFPGA.Text = "更新";
            this.btnUpgradeFPGA.UseVisualStyleBackColor = true;
            this.btnUpgradeFPGA.Click += new System.EventHandler(this.btnUpgradeFPGA_Click);
            // 
            // btnUpgradeMCU
            // 
            this.btnUpgradeMCU.Location = new System.Drawing.Point(515, 28);
            this.btnUpgradeMCU.Name = "btnUpgradeMCU";
            this.btnUpgradeMCU.Size = new System.Drawing.Size(75, 23);
            this.btnUpgradeMCU.TabIndex = 3;
            this.btnUpgradeMCU.Text = "更新";
            this.btnUpgradeMCU.UseVisualStyleBackColor = true;
            this.btnUpgradeMCU.Click += new System.EventHandler(this.btnUpgradeMCU_Click);
            // 
            // btnChoseDistributeBoardFPGA
            // 
            this.btnChoseDistributeBoardFPGA.Location = new System.Drawing.Point(470, 115);
            this.btnChoseDistributeBoardFPGA.Name = "btnChoseDistributeBoardFPGA";
            this.btnChoseDistributeBoardFPGA.Size = new System.Drawing.Size(39, 23);
            this.btnChoseDistributeBoardFPGA.TabIndex = 2;
            this.btnChoseDistributeBoardFPGA.Text = "...";
            this.btnChoseDistributeBoardFPGA.UseVisualStyleBackColor = true;
            this.btnChoseDistributeBoardFPGA.Click += new System.EventHandler(this.btnChoseDistributeBoardFPGA_Click);
            // 
            // btnChoseMbFPGA
            // 
            this.btnChoseMbFPGA.Location = new System.Drawing.Point(470, 58);
            this.btnChoseMbFPGA.Name = "btnChoseMbFPGA";
            this.btnChoseMbFPGA.Size = new System.Drawing.Size(39, 23);
            this.btnChoseMbFPGA.TabIndex = 2;
            this.btnChoseMbFPGA.Text = "...";
            this.btnChoseMbFPGA.UseVisualStyleBackColor = true;
            this.btnChoseMbFPGA.Click += new System.EventHandler(this.btnChoseMbFPGA_Click);
            // 
            // btnChoseFPGA
            // 
            this.btnChoseFPGA.Location = new System.Drawing.Point(470, 87);
            this.btnChoseFPGA.Name = "btnChoseFPGA";
            this.btnChoseFPGA.Size = new System.Drawing.Size(39, 23);
            this.btnChoseFPGA.TabIndex = 2;
            this.btnChoseFPGA.Text = "...";
            this.btnChoseFPGA.UseVisualStyleBackColor = true;
            this.btnChoseFPGA.Click += new System.EventHandler(this.btnChoseFPGA_Click);
            // 
            // btnChoseMCU
            // 
            this.btnChoseMCU.Location = new System.Drawing.Point(470, 28);
            this.btnChoseMCU.Name = "btnChoseMCU";
            this.btnChoseMCU.Size = new System.Drawing.Size(39, 23);
            this.btnChoseMCU.TabIndex = 2;
            this.btnChoseMCU.Text = "...";
            this.btnChoseMCU.UseVisualStyleBackColor = true;
            this.btnChoseMCU.Click += new System.EventHandler(this.btnChoseMCU_Click);
            // 
            // txtDistributeBoardFPGA
            // 
            this.txtDistributeBoardFPGA.Location = new System.Drawing.Point(79, 116);
            this.txtDistributeBoardFPGA.Name = "txtDistributeBoardFPGA";
            this.txtDistributeBoardFPGA.Size = new System.Drawing.Size(385, 21);
            this.txtDistributeBoardFPGA.TabIndex = 1;
            // 
            // txtMbFPGA
            // 
            this.txtMbFPGA.Location = new System.Drawing.Point(79, 59);
            this.txtMbFPGA.Name = "txtMbFPGA";
            this.txtMbFPGA.Size = new System.Drawing.Size(385, 21);
            this.txtMbFPGA.TabIndex = 1;
            // 
            // txtFPGA
            // 
            this.txtFPGA.Location = new System.Drawing.Point(79, 88);
            this.txtFPGA.Name = "txtFPGA";
            this.txtFPGA.Size = new System.Drawing.Size(385, 21);
            this.txtFPGA.TabIndex = 1;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(16, 63);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(59, 12);
            this.label27.TabIndex = 0;
            this.label27.Text = "主板FPGA:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(7, 120);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(71, 12);
            this.label23.TabIndex = 0;
            this.label23.Text = "分配板FPGA:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "灯板FPGA:";
            // 
            // txtMcu
            // 
            this.txtMcu.Location = new System.Drawing.Point(79, 29);
            this.txtMcu.Name = "txtMcu";
            this.txtMcu.Size = new System.Drawing.Size(385, 21);
            this.txtMcu.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(44, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "MCU:";
            // 
            // tab2055
            // 
            this.tab2055.BackColor = System.Drawing.SystemColors.Control;
            this.tab2055.Controls.Add(this.btnRegSetDefault);
            this.tab2055.Controls.Add(this.tabRegister);
            this.tab2055.Controls.Add(this.btnReadReg);
            this.tab2055.Controls.Add(this.btnSendAll);
            this.tab2055.Controls.Add(this.cbParam2055Color);
            this.tab2055.Controls.Add(this.label9);
            this.tab2055.Controls.Add(this.ckDebugMode);
            this.tab2055.Controls.Add(this.cbRegChip);
            this.tab2055.Controls.Add(this.label14);
            this.tab2055.Controls.Add(this.btnExport2055Param);
            this.tab2055.Controls.Add(this.btnLoad2055Param);
            this.tab2055.Location = new System.Drawing.Point(4, 22);
            this.tab2055.Name = "tab2055";
            this.tab2055.Padding = new System.Windows.Forms.Padding(3);
            this.tab2055.Size = new System.Drawing.Size(1513, 804);
            this.tab2055.TabIndex = 2;
            this.tab2055.Text = "2055寄存器设置";
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
            this.tabRegister.Controls.Add(this.tabPage1);
            this.tabRegister.Location = new System.Drawing.Point(0, 42);
            this.tabRegister.Name = "tabRegister";
            this.tabRegister.SelectedIndex = 0;
            this.tabRegister.Size = new System.Drawing.Size(1587, 752);
            this.tabRegister.TabIndex = 11;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grid2055);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1579, 726);
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grid2055.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            this.grid2055.Size = new System.Drawing.Size(1573, 720);
            this.grid2055.TabIndex = 0;
            this.grid2055.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grid2055_CellBeginEdit);
            this.grid2055.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid2055_CellContentClick);
            this.grid2055.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid2055_CellEnter);
            this.grid2055.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grid2055_CellFormatting);
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
            this.ColRegisterAddress.HeaderText = "寄存器地址(十六进制)";
            this.ColRegisterAddress.Name = "ColRegisterAddress";
            this.ColRegisterAddress.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColRegisterAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColRegisterAddress.Width = 220;
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
            this.ColRedValue.HeaderText = "红色值(十进制)";
            this.ColRedValue.Name = "ColRedValue";
            this.ColRedValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColRedValue.Width = 140;
            // 
            // ColGreenValue
            // 
            this.ColGreenValue.DataPropertyName = "GreenValue";
            this.ColGreenValue.Frozen = true;
            this.ColGreenValue.HeaderText = "绿色值(十进制)";
            this.ColGreenValue.Name = "ColGreenValue";
            this.ColGreenValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColGreenValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColGreenValue.Width = 140;
            // 
            // ColBlueValue
            // 
            this.ColBlueValue.DataPropertyName = "BlueValue";
            this.ColBlueValue.Frozen = true;
            this.ColBlueValue.HeaderText = "蓝色值(十进制)";
            this.ColBlueValue.Name = "ColBlueValue";
            this.ColBlueValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColBlueValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColBlueValue.Width = 140;
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
            this.tabPage4.Size = new System.Drawing.Size(1579, 726);
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
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridOtherReg.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
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
            this.gridOtherReg.Size = new System.Drawing.Size(1573, 720);
            this.gridOtherReg.TabIndex = 1;
            this.gridOtherReg.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridOtherReg_CellBeginEdit);
            this.gridOtherReg.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOtherReg_CellContentClick);
            this.gridOtherReg.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOtherReg_CellEnter);
            this.gridOtherReg.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridOtherReg_CellFormatting);
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
            this.ColOtherRegisterAddress.HeaderText = "地址(十六进制)";
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
            this.ColOtherValue.HeaderText = "值(十进制)";
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
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn2055Read1);
            this.tabPage1.Controls.Add(this.label78);
            this.tabPage1.Controls.Add(this.label97);
            this.tabPage1.Controls.Add(this.btn2055Send2);
            this.tabPage1.Controls.Add(this.rt2055Send2);
            this.tabPage1.Controls.Add(this.btn2055Read2);
            this.tabPage1.Controls.Add(this.btn2055Send1);
            this.tabPage1.Controls.Add(this.rt2055Send1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1537, 726);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "工程师界面";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn2055Read1
            // 
            this.btn2055Read1.Location = new System.Drawing.Point(759, 23);
            this.btn2055Read1.Name = "btn2055Read1";
            this.btn2055Read1.Size = new System.Drawing.Size(75, 23);
            this.btn2055Read1.TabIndex = 462;
            this.btn2055Read1.Text = "读取";
            this.btn2055Read1.UseVisualStyleBackColor = true;
            this.btn2055Read1.Click += new System.EventHandler(this.btn2055Read1_Click);
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(6, 317);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(47, 12);
            this.label78.TabIndex = 461;
            this.label78.Text = "发送区2";
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Location = new System.Drawing.Point(6, 8);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(47, 12);
            this.label97.TabIndex = 460;
            this.label97.Text = "发送区1";
            // 
            // btn2055Send2
            // 
            this.btn2055Send2.Location = new System.Drawing.Point(759, 361);
            this.btn2055Send2.Name = "btn2055Send2";
            this.btn2055Send2.Size = new System.Drawing.Size(75, 23);
            this.btn2055Send2.TabIndex = 459;
            this.btn2055Send2.Text = "发送";
            this.btn2055Send2.UseVisualStyleBackColor = true;
            this.btn2055Send2.Click += new System.EventHandler(this.btn2055Send2_Click);
            // 
            // rt2055Send2
            // 
            this.rt2055Send2.Location = new System.Drawing.Point(6, 332);
            this.rt2055Send2.Name = "rt2055Send2";
            this.rt2055Send2.Size = new System.Drawing.Size(747, 229);
            this.rt2055Send2.TabIndex = 458;
            this.rt2055Send2.Text = "";
            // 
            // btn2055Read2
            // 
            this.btn2055Read2.Location = new System.Drawing.Point(759, 332);
            this.btn2055Read2.Name = "btn2055Read2";
            this.btn2055Read2.Size = new System.Drawing.Size(75, 23);
            this.btn2055Read2.TabIndex = 457;
            this.btn2055Read2.Text = "读取";
            this.btn2055Read2.UseVisualStyleBackColor = true;
            this.btn2055Read2.Click += new System.EventHandler(this.btn2055Read2_Click);
            // 
            // btn2055Send1
            // 
            this.btn2055Send1.ForeColor = System.Drawing.Color.Black;
            this.btn2055Send1.Location = new System.Drawing.Point(759, 52);
            this.btn2055Send1.Name = "btn2055Send1";
            this.btn2055Send1.Size = new System.Drawing.Size(75, 23);
            this.btn2055Send1.TabIndex = 456;
            this.btn2055Send1.Tag = "3,22,23";
            this.btn2055Send1.Text = "发送";
            this.btn2055Send1.UseVisualStyleBackColor = true;
            this.btn2055Send1.Click += new System.EventHandler(this.btn2055Send1_Click);
            // 
            // rt2055Send1
            // 
            this.rt2055Send1.Location = new System.Drawing.Point(6, 23);
            this.rt2055Send1.Name = "rt2055Send1";
            this.rt2055Send1.Size = new System.Drawing.Size(747, 275);
            this.rt2055Send1.TabIndex = 455;
            this.rt2055Send1.Text = resources.GetString("rt2055Send1.Text");
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
            this.tabPage3.Controls.Add(this.tabControl1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1513, 804);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Text = "2072寄存器设置";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Location = new System.Drawing.Point(0, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1360, 790);
            this.tabControl1.TabIndex = 22;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage5.Controls.Add(this.panel2);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1352, 764);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "预览用，断电丢失";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.groupBox22);
            this.panel2.Controls.Add(this.gp2019Config);
            this.panel2.Controls.Add(this.btn2072_saveValueList);
            this.panel2.Controls.Add(this.ck2072CycleTest);
            this.panel2.Controls.Add(this.btn2072_all);
            this.panel2.Controls.Add(this.btn2072_export);
            this.panel2.Controls.Add(this.btn2072_import);
            this.panel2.Controls.Add(this.groupBox15);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1346, 758);
            this.panel2.TabIndex = 2;
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.numPreview128Reg);
            this.groupBox22.Controls.Add(this.btnPreview128Reg);
            this.groupBox22.Location = new System.Drawing.Point(9, 549);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(1000, 59);
            this.groupBox22.TabIndex = 442;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "128 Register Config";
            // 
            // numPreview128Reg
            // 
            this.numPreview128Reg.Location = new System.Drawing.Point(26, 22);
            this.numPreview128Reg.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPreview128Reg.Name = "numPreview128Reg";
            this.numPreview128Reg.Size = new System.Drawing.Size(95, 21);
            this.numPreview128Reg.TabIndex = 450;
            // 
            // btnPreview128Reg
            // 
            this.btnPreview128Reg.Location = new System.Drawing.Point(127, 21);
            this.btnPreview128Reg.Name = "btnPreview128Reg";
            this.btnPreview128Reg.Size = new System.Drawing.Size(64, 23);
            this.btnPreview128Reg.TabIndex = 8;
            this.btnPreview128Reg.Text = "Set";
            this.btnPreview128Reg.UseVisualStyleBackColor = true;
            this.btnPreview128Reg.Click += new System.EventHandler(this.btnPreview128Reg_Click);
            // 
            // gp2019Config
            // 
            this.gp2019Config.Controls.Add(this.label214);
            this.gp2019Config.Controls.Add(this.btnSet2019All);
            this.gp2019Config.Controls.Add(this.label213);
            this.gp2019Config.Controls.Add(this.label212);
            this.gp2019Config.Controls.Add(this.label211);
            this.gp2019Config.Controls.Add(this.btnSet2019_163);
            this.gp2019Config.Controls.Add(this.input2019_163);
            this.gp2019Config.Controls.Add(this.label206);
            this.gp2019Config.Controls.Add(this.btnSet2019_162);
            this.gp2019Config.Controls.Add(this.input2019_162);
            this.gp2019Config.Controls.Add(this.label204);
            this.gp2019Config.Controls.Add(this.btnSet2019_161);
            this.gp2019Config.Controls.Add(this.input2019_161);
            this.gp2019Config.Controls.Add(this.label203);
            this.gp2019Config.Controls.Add(this.btnSet2019_160);
            this.gp2019Config.Controls.Add(this.input2019_160);
            this.gp2019Config.Controls.Add(this.label202);
            this.gp2019Config.Location = new System.Drawing.Point(3, 480);
            this.gp2019Config.Name = "gp2019Config";
            this.gp2019Config.Size = new System.Drawing.Size(1008, 68);
            this.gp2019Config.TabIndex = 441;
            this.gp2019Config.TabStop = false;
            this.gp2019Config.Text = "2019 Register Config";
            // 
            // label214
            // 
            this.label214.AutoSize = true;
            this.label214.Location = new System.Drawing.Point(617, 26);
            this.label214.Name = "label214";
            this.label214.Size = new System.Drawing.Size(173, 12);
            this.label214.TabIndex = 464;
            this.label214.Text = "Data Rising Edge Start Point";
            // 
            // btnSet2019All
            // 
            this.btnSet2019All.Location = new System.Drawing.Point(924, 39);
            this.btnSet2019All.Name = "btnSet2019All";
            this.btnSet2019All.Size = new System.Drawing.Size(75, 21);
            this.btnSet2019All.TabIndex = 463;
            this.btnSet2019All.Tag = "4";
            this.btnSet2019All.Text = "Set All";
            this.btnSet2019All.UseVisualStyleBackColor = true;
            this.btnSet2019All.Click += new System.EventHandler(this.btnSet2019All_Click);
            // 
            // label213
            // 
            this.label213.AutoSize = true;
            this.label213.Location = new System.Drawing.Point(409, 26);
            this.label213.Name = "label213";
            this.label213.Size = new System.Drawing.Size(161, 12);
            this.label213.TabIndex = 462;
            this.label213.Text = "Signal Fall Edge End Point";
            // 
            // label212
            // 
            this.label212.AutoSize = true;
            this.label212.Location = new System.Drawing.Point(226, 26);
            this.label212.Name = "label212";
            this.label212.Size = new System.Drawing.Size(113, 12);
            this.label212.TabIndex = 461;
            this.label212.Text = "Blanking Intensity";
            // 
            // label211
            // 
            this.label211.AutoSize = true;
            this.label211.Location = new System.Drawing.Point(6, 26);
            this.label211.Name = "label211";
            this.label211.Size = new System.Drawing.Size(179, 12);
            this.label211.TabIndex = 460;
            this.label211.Text = "Clock Rising Edge Start Point";
            // 
            // btnSet2019_163
            // 
            this.btnSet2019_163.Location = new System.Drawing.Point(725, 41);
            this.btnSet2019_163.Name = "btnSet2019_163";
            this.btnSet2019_163.Size = new System.Drawing.Size(42, 21);
            this.btnSet2019_163.TabIndex = 459;
            this.btnSet2019_163.Tag = "3";
            this.btnSet2019_163.Text = "Set";
            this.btnSet2019_163.UseVisualStyleBackColor = true;
            this.btnSet2019_163.Click += new System.EventHandler(this.btnSet2019All_Click);
            // 
            // input2019_163
            // 
            this.input2019_163.Location = new System.Drawing.Point(679, 41);
            this.input2019_163.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.input2019_163.Name = "input2019_163";
            this.input2019_163.Size = new System.Drawing.Size(40, 21);
            this.input2019_163.TabIndex = 458;
            this.input2019_163.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label206
            // 
            this.label206.AutoSize = true;
            this.label206.Location = new System.Drawing.Point(617, 43);
            this.label206.Name = "label206";
            this.label206.Size = new System.Drawing.Size(53, 12);
            this.label206.TabIndex = 457;
            this.label206.Text = "Addr=163";
            // 
            // btnSet2019_162
            // 
            this.btnSet2019_162.Location = new System.Drawing.Point(508, 41);
            this.btnSet2019_162.Name = "btnSet2019_162";
            this.btnSet2019_162.Size = new System.Drawing.Size(42, 21);
            this.btnSet2019_162.TabIndex = 456;
            this.btnSet2019_162.Tag = "2";
            this.btnSet2019_162.Text = "Set";
            this.btnSet2019_162.UseVisualStyleBackColor = true;
            this.btnSet2019_162.Click += new System.EventHandler(this.btnSet2019All_Click);
            // 
            // input2019_162
            // 
            this.input2019_162.Location = new System.Drawing.Point(462, 41);
            this.input2019_162.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.input2019_162.Name = "input2019_162";
            this.input2019_162.Size = new System.Drawing.Size(40, 21);
            this.input2019_162.TabIndex = 455;
            this.input2019_162.Value = new decimal(new int[] {
            48,
            0,
            0,
            0});
            // 
            // label204
            // 
            this.label204.AutoSize = true;
            this.label204.Location = new System.Drawing.Point(407, 43);
            this.label204.Name = "label204";
            this.label204.Size = new System.Drawing.Size(53, 12);
            this.label204.TabIndex = 454;
            this.label204.Text = "Addr=162";
            // 
            // btnSet2019_161
            // 
            this.btnSet2019_161.Location = new System.Drawing.Point(326, 41);
            this.btnSet2019_161.Name = "btnSet2019_161";
            this.btnSet2019_161.Size = new System.Drawing.Size(42, 21);
            this.btnSet2019_161.TabIndex = 453;
            this.btnSet2019_161.Tag = "1";
            this.btnSet2019_161.Text = "Set";
            this.btnSet2019_161.UseVisualStyleBackColor = true;
            this.btnSet2019_161.Click += new System.EventHandler(this.btnSet2019All_Click);
            // 
            // input2019_161
            // 
            this.input2019_161.Location = new System.Drawing.Point(280, 41);
            this.input2019_161.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.input2019_161.Name = "input2019_161";
            this.input2019_161.Size = new System.Drawing.Size(40, 21);
            this.input2019_161.TabIndex = 452;
            this.input2019_161.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label203
            // 
            this.label203.AutoSize = true;
            this.label203.Location = new System.Drawing.Point(226, 43);
            this.label203.Name = "label203";
            this.label203.Size = new System.Drawing.Size(53, 12);
            this.label203.TabIndex = 451;
            this.label203.Text = "Addr=161";
            // 
            // btnSet2019_160
            // 
            this.btnSet2019_160.Location = new System.Drawing.Point(105, 41);
            this.btnSet2019_160.Name = "btnSet2019_160";
            this.btnSet2019_160.Size = new System.Drawing.Size(42, 21);
            this.btnSet2019_160.TabIndex = 450;
            this.btnSet2019_160.Tag = "0";
            this.btnSet2019_160.Text = "Set";
            this.btnSet2019_160.UseVisualStyleBackColor = true;
            this.btnSet2019_160.Click += new System.EventHandler(this.btnSet2019All_Click);
            // 
            // input2019_160
            // 
            this.input2019_160.Location = new System.Drawing.Point(59, 41);
            this.input2019_160.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.input2019_160.Name = "input2019_160";
            this.input2019_160.Size = new System.Drawing.Size(40, 21);
            this.input2019_160.TabIndex = 449;
            this.input2019_160.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // label202
            // 
            this.label202.AutoSize = true;
            this.label202.Location = new System.Drawing.Point(3, 43);
            this.label202.Name = "label202";
            this.label202.Size = new System.Drawing.Size(53, 12);
            this.label202.TabIndex = 448;
            this.label202.Text = "Addr=160";
            // 
            // btn2072_saveValueList
            // 
            this.btn2072_saveValueList.Location = new System.Drawing.Point(400, 621);
            this.btn2072_saveValueList.Name = "btn2072_saveValueList";
            this.btn2072_saveValueList.Size = new System.Drawing.Size(112, 23);
            this.btn2072_saveValueList.TabIndex = 440;
            this.btn2072_saveValueList.Text = "Save Value List";
            this.btn2072_saveValueList.UseVisualStyleBackColor = true;
            this.btn2072_saveValueList.Click += new System.EventHandler(this.btn2072_saveValueList_Click);
            // 
            // ck2072CycleTest
            // 
            this.ck2072CycleTest.AutoSize = true;
            this.ck2072CycleTest.Location = new System.Drawing.Point(293, 625);
            this.ck2072CycleTest.Name = "ck2072CycleTest";
            this.ck2072CycleTest.Size = new System.Drawing.Size(78, 16);
            this.ck2072CycleTest.TabIndex = 439;
            this.ck2072CycleTest.Text = "CycleTest";
            this.ck2072CycleTest.UseVisualStyleBackColor = true;
            // 
            // btn2072_all
            // 
            this.btn2072_all.Location = new System.Drawing.Point(197, 621);
            this.btn2072_all.Name = "btn2072_all";
            this.btn2072_all.Size = new System.Drawing.Size(75, 23);
            this.btn2072_all.TabIndex = 438;
            this.btn2072_all.Tag = "18";
            this.btn2072_all.Text = "Send All";
            this.btn2072_all.UseVisualStyleBackColor = true;
            this.btn2072_all.Click += new System.EventHandler(this.btn2072_1_Click);
            // 
            // btn2072_export
            // 
            this.btn2072_export.Location = new System.Drawing.Point(89, 621);
            this.btn2072_export.Name = "btn2072_export";
            this.btn2072_export.Size = new System.Drawing.Size(75, 23);
            this.btn2072_export.TabIndex = 437;
            this.btn2072_export.Text = "Export";
            this.btn2072_export.UseVisualStyleBackColor = true;
            this.btn2072_export.Click += new System.EventHandler(this.btn2072_export_Click);
            // 
            // btn2072_import
            // 
            this.btn2072_import.Location = new System.Drawing.Point(3, 621);
            this.btn2072_import.Name = "btn2072_import";
            this.btn2072_import.Size = new System.Drawing.Size(75, 23);
            this.btn2072_import.TabIndex = 436;
            this.btn2072_import.Text = "Import";
            this.btn2072_import.UseVisualStyleBackColor = true;
            this.btn2072_import.Click += new System.EventHandler(this.btn2072_import_Click);
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.input2072_7_1);
            this.groupBox15.Controls.Add(this.input2072_3_1);
            this.groupBox15.Controls.Add(this.input2072_17_2);
            this.groupBox15.Controls.Add(this.input2072_16_8);
            this.groupBox15.Controls.Add(this.input2072_16_7);
            this.groupBox15.Controls.Add(this.input2072_14_7);
            this.groupBox15.Controls.Add(this.input2072_14_6);
            this.groupBox15.Controls.Add(this.input2072_14_5);
            this.groupBox15.Controls.Add(this.input2072_9_6);
            this.groupBox15.Controls.Add(this.input2072_9_5);
            this.groupBox15.Controls.Add(this.input2072_9_4);
            this.groupBox15.Controls.Add(this.input2072_2_4);
            this.groupBox15.Controls.Add(this.input2072_2_3);
            this.groupBox15.Controls.Add(this.input2072_2_2);
            this.groupBox15.Controls.Add(this.input2072_2_1);
            this.groupBox15.Controls.Add(this.input2072_3_6);
            this.groupBox15.Controls.Add(this.btn2072_f3);
            this.groupBox15.Controls.Add(this.btn2072_f2);
            this.groupBox15.Controls.Add(this.btn2072_f1);
            this.groupBox15.Controls.Add(this.btn2072_c);
            this.groupBox15.Controls.Add(this.btn2072_b);
            this.groupBox15.Controls.Add(this.btn2072_f0);
            this.groupBox15.Controls.Add(this.btn2072_d);
            this.groupBox15.Controls.Add(this.btn2072_9);
            this.groupBox15.Controls.Add(this.btn2072_8);
            this.groupBox15.Controls.Add(this.cb2072_17_1);
            this.groupBox15.Controls.Add(this.label154);
            this.groupBox15.Controls.Add(this.label155);
            this.groupBox15.Controls.Add(this.label156);
            this.groupBox15.Controls.Add(this.label147);
            this.groupBox15.Controls.Add(this.label136);
            this.groupBox15.Controls.Add(this.cb2072_16_6);
            this.groupBox15.Controls.Add(this.label138);
            this.groupBox15.Controls.Add(this.cb2072_16_5);
            this.groupBox15.Controls.Add(this.label139);
            this.groupBox15.Controls.Add(this.cb2072_16_4);
            this.groupBox15.Controls.Add(this.label141);
            this.groupBox15.Controls.Add(this.cb2072_16_2);
            this.groupBox15.Controls.Add(this.cb2072_16_3);
            this.groupBox15.Controls.Add(this.cb2072_16_1);
            this.groupBox15.Controls.Add(this.label142);
            this.groupBox15.Controls.Add(this.label144);
            this.groupBox15.Controls.Add(this.label145);
            this.groupBox15.Controls.Add(this.label146);
            this.groupBox15.Controls.Add(this.cb2072_15_6);
            this.groupBox15.Controls.Add(this.label175);
            this.groupBox15.Controls.Add(this.cb2072_15_5);
            this.groupBox15.Controls.Add(this.label178);
            this.groupBox15.Controls.Add(this.cb2072_15_4);
            this.groupBox15.Controls.Add(this.label181);
            this.groupBox15.Controls.Add(this.cb2072_15_2);
            this.groupBox15.Controls.Add(this.cb2072_15_3);
            this.groupBox15.Controls.Add(this.cb2072_15_1);
            this.groupBox15.Controls.Add(this.label207);
            this.groupBox15.Controls.Add(this.label208);
            this.groupBox15.Controls.Add(this.label209);
            this.groupBox15.Controls.Add(this.label210);
            this.groupBox15.Controls.Add(this.cb2072_12_7);
            this.groupBox15.Controls.Add(this.label126);
            this.groupBox15.Controls.Add(this.cb2072_12_6);
            this.groupBox15.Controls.Add(this.label129);
            this.groupBox15.Controls.Add(this.cb2072_12_5);
            this.groupBox15.Controls.Add(this.label134);
            this.groupBox15.Controls.Add(this.cb2072_12_4);
            this.groupBox15.Controls.Add(this.label137);
            this.groupBox15.Controls.Add(this.cb2072_12_2);
            this.groupBox15.Controls.Add(this.cb2072_12_3);
            this.groupBox15.Controls.Add(this.cb2072_12_1);
            this.groupBox15.Controls.Add(this.label140);
            this.groupBox15.Controls.Add(this.label143);
            this.groupBox15.Controls.Add(this.label148);
            this.groupBox15.Controls.Add(this.label151);
            this.groupBox15.Controls.Add(this.cb2072_11_7);
            this.groupBox15.Controls.Add(this.label55);
            this.groupBox15.Controls.Add(this.cb2072_11_6);
            this.groupBox15.Controls.Add(this.label57);
            this.groupBox15.Controls.Add(this.cb2072_11_5);
            this.groupBox15.Controls.Add(this.label86);
            this.groupBox15.Controls.Add(this.cb2072_11_4);
            this.groupBox15.Controls.Add(this.label88);
            this.groupBox15.Controls.Add(this.cb2072_11_2);
            this.groupBox15.Controls.Add(this.cb2072_11_3);
            this.groupBox15.Controls.Add(this.cb2072_11_1);
            this.groupBox15.Controls.Add(this.label90);
            this.groupBox15.Controls.Add(this.label92);
            this.groupBox15.Controls.Add(this.label117);
            this.groupBox15.Controls.Add(this.label121);
            this.groupBox15.Controls.Add(this.label158);
            this.groupBox15.Controls.Add(this.label176);
            this.groupBox15.Controls.Add(this.label177);
            this.groupBox15.Controls.Add(this.cb2072_14_4);
            this.groupBox15.Controls.Add(this.label179);
            this.groupBox15.Controls.Add(this.cb2072_14_2);
            this.groupBox15.Controls.Add(this.cb2072_14_3);
            this.groupBox15.Controls.Add(this.cb2072_14_1);
            this.groupBox15.Controls.Add(this.label180);
            this.groupBox15.Controls.Add(this.label182);
            this.groupBox15.Controls.Add(this.label183);
            this.groupBox15.Controls.Add(this.label184);
            this.groupBox15.Controls.Add(this.cb2072_13_1);
            this.groupBox15.Controls.Add(this.cb2072_13_10);
            this.groupBox15.Controls.Add(this.cb2072_13_9);
            this.groupBox15.Controls.Add(this.cb2072_13_8);
            this.groupBox15.Controls.Add(this.label159);
            this.groupBox15.Controls.Add(this.label160);
            this.groupBox15.Controls.Add(this.label161);
            this.groupBox15.Controls.Add(this.btn2072_a);
            this.groupBox15.Controls.Add(this.cb2072_13_12);
            this.groupBox15.Controls.Add(this.cb2072_13_11);
            this.groupBox15.Controls.Add(this.cb2072_13_7);
            this.groupBox15.Controls.Add(this.cb2072_13_6);
            this.groupBox15.Controls.Add(this.cb2072_13_5);
            this.groupBox15.Controls.Add(this.cb2072_13_4);
            this.groupBox15.Controls.Add(this.cb2072_13_3);
            this.groupBox15.Controls.Add(this.cb2072_13_2);
            this.groupBox15.Controls.Add(this.label162);
            this.groupBox15.Controls.Add(this.label163);
            this.groupBox15.Controls.Add(this.label165);
            this.groupBox15.Controls.Add(this.label166);
            this.groupBox15.Controls.Add(this.label167);
            this.groupBox15.Controls.Add(this.label168);
            this.groupBox15.Controls.Add(this.label169);
            this.groupBox15.Controls.Add(this.label171);
            this.groupBox15.Controls.Add(this.label173);
            this.groupBox15.Controls.Add(this.label174);
            this.groupBox15.Controls.Add(this.cb2072_10_7);
            this.groupBox15.Controls.Add(this.label133);
            this.groupBox15.Controls.Add(this.cb2072_10_6);
            this.groupBox15.Controls.Add(this.label135);
            this.groupBox15.Controls.Add(this.cb2072_10_5);
            this.groupBox15.Controls.Add(this.label125);
            this.groupBox15.Controls.Add(this.cb2072_10_4);
            this.groupBox15.Controls.Add(this.label127);
            this.groupBox15.Controls.Add(this.cb2072_10_2);
            this.groupBox15.Controls.Add(this.cb2072_10_3);
            this.groupBox15.Controls.Add(this.cb2072_10_1);
            this.groupBox15.Controls.Add(this.label128);
            this.groupBox15.Controls.Add(this.label130);
            this.groupBox15.Controls.Add(this.label131);
            this.groupBox15.Controls.Add(this.label132);
            this.groupBox15.Controls.Add(this.label123);
            this.groupBox15.Controls.Add(this.label124);
            this.groupBox15.Controls.Add(this.label111);
            this.groupBox15.Controls.Add(this.cb2072_9_1);
            this.groupBox15.Controls.Add(this.cb2072_9_3);
            this.groupBox15.Controls.Add(this.cb2072_9_2);
            this.groupBox15.Controls.Add(this.label112);
            this.groupBox15.Controls.Add(this.label113);
            this.groupBox15.Controls.Add(this.label120);
            this.groupBox15.Controls.Add(this.label122);
            this.groupBox15.Controls.Add(this.cb2072_8_4);
            this.groupBox15.Controls.Add(this.label114);
            this.groupBox15.Controls.Add(this.cb2072_8_1);
            this.groupBox15.Controls.Add(this.cb2072_8_3);
            this.groupBox15.Controls.Add(this.cb2072_8_2);
            this.groupBox15.Controls.Add(this.label115);
            this.groupBox15.Controls.Add(this.label116);
            this.groupBox15.Controls.Add(this.label118);
            this.groupBox15.Controls.Add(this.label119);
            this.groupBox15.Controls.Add(this.cb2072_7_14);
            this.groupBox15.Controls.Add(this.label110);
            this.groupBox15.Controls.Add(this.cb2072_7_11);
            this.groupBox15.Controls.Add(this.cb2072_7_10);
            this.groupBox15.Controls.Add(this.cb2072_7_9);
            this.groupBox15.Controls.Add(this.label96);
            this.groupBox15.Controls.Add(this.label99);
            this.groupBox15.Controls.Add(this.label109);
            this.groupBox15.Controls.Add(this.btn2072_7);
            this.groupBox15.Controls.Add(this.cb2072_7_13);
            this.groupBox15.Controls.Add(this.cb2072_7_12);
            this.groupBox15.Controls.Add(this.cb2072_7_8);
            this.groupBox15.Controls.Add(this.cb2072_7_7);
            this.groupBox15.Controls.Add(this.cb2072_7_6);
            this.groupBox15.Controls.Add(this.cb2072_7_5);
            this.groupBox15.Controls.Add(this.cb2072_7_4);
            this.groupBox15.Controls.Add(this.cb2072_7_3);
            this.groupBox15.Controls.Add(this.cb2072_7_2);
            this.groupBox15.Controls.Add(this.label94);
            this.groupBox15.Controls.Add(this.label95);
            this.groupBox15.Controls.Add(this.label98);
            this.groupBox15.Controls.Add(this.label100);
            this.groupBox15.Controls.Add(this.label101);
            this.groupBox15.Controls.Add(this.label102);
            this.groupBox15.Controls.Add(this.label104);
            this.groupBox15.Controls.Add(this.label105);
            this.groupBox15.Controls.Add(this.label106);
            this.groupBox15.Controls.Add(this.label107);
            this.groupBox15.Controls.Add(this.label108);
            this.groupBox15.Controls.Add(this.cb2072_5_4);
            this.groupBox15.Controls.Add(this.label85);
            this.groupBox15.Controls.Add(this.label87);
            this.groupBox15.Controls.Add(this.cb2072_5_1);
            this.groupBox15.Controls.Add(this.btn2072_5);
            this.groupBox15.Controls.Add(this.cb2072_5_3);
            this.groupBox15.Controls.Add(this.cb2072_5_2);
            this.groupBox15.Controls.Add(this.label89);
            this.groupBox15.Controls.Add(this.label91);
            this.groupBox15.Controls.Add(this.label93);
            this.groupBox15.Controls.Add(this.cb2072_6_6);
            this.groupBox15.Controls.Add(this.cb2072_6_5);
            this.groupBox15.Controls.Add(this.label82);
            this.groupBox15.Controls.Add(this.label83);
            this.groupBox15.Controls.Add(this.label84);
            this.groupBox15.Controls.Add(this.label81);
            this.groupBox15.Controls.Add(this.cb2072_6_1);
            this.groupBox15.Controls.Add(this.btn2072_6);
            this.groupBox15.Controls.Add(this.cb2072_6_4);
            this.groupBox15.Controls.Add(this.cb2072_6_3);
            this.groupBox15.Controls.Add(this.cb2072_6_2);
            this.groupBox15.Controls.Add(this.label54);
            this.groupBox15.Controls.Add(this.label56);
            this.groupBox15.Controls.Add(this.label80);
            this.groupBox15.Controls.Add(this.btn2072_4);
            this.groupBox15.Controls.Add(this.cb2072_4_6);
            this.groupBox15.Controls.Add(this.cb2072_4_5);
            this.groupBox15.Controls.Add(this.cb2072_4_4);
            this.groupBox15.Controls.Add(this.cb2072_4_3);
            this.groupBox15.Controls.Add(this.cb2072_4_2);
            this.groupBox15.Controls.Add(this.cb2072_4_1);
            this.groupBox15.Controls.Add(this.label58);
            this.groupBox15.Controls.Add(this.label68);
            this.groupBox15.Controls.Add(this.label73);
            this.groupBox15.Controls.Add(this.label75);
            this.groupBox15.Controls.Add(this.label76);
            this.groupBox15.Controls.Add(this.label77);
            this.groupBox15.Controls.Add(this.label79);
            this.groupBox15.Controls.Add(this.cb2072_3_5);
            this.groupBox15.Controls.Add(this.label64);
            this.groupBox15.Controls.Add(this.cb2072_3_4);
            this.groupBox15.Controls.Add(this.label65);
            this.groupBox15.Controls.Add(this.cb2072_3_3);
            this.groupBox15.Controls.Add(this.label60);
            this.groupBox15.Controls.Add(this.btn2072_3);
            this.groupBox15.Controls.Add(this.cb2072_3_2);
            this.groupBox15.Controls.Add(this.label53);
            this.groupBox15.Controls.Add(this.label70);
            this.groupBox15.Controls.Add(this.label71);
            this.groupBox15.Controls.Add(this.label72);
            this.groupBox15.Controls.Add(this.btn2072_2);
            this.groupBox15.Controls.Add(this.label61);
            this.groupBox15.Controls.Add(this.label62);
            this.groupBox15.Controls.Add(this.label63);
            this.groupBox15.Controls.Add(this.label66);
            this.groupBox15.Controls.Add(this.label67);
            this.groupBox15.Controls.Add(this.btn2072_1);
            this.groupBox15.Controls.Add(this.cb2072_1_12);
            this.groupBox15.Controls.Add(this.cb2072_1_11);
            this.groupBox15.Controls.Add(this.cb2072_1_10);
            this.groupBox15.Controls.Add(this.cb2072_1_9);
            this.groupBox15.Controls.Add(this.cb2072_1_8);
            this.groupBox15.Controls.Add(this.cb2072_1_7);
            this.groupBox15.Controls.Add(this.cb2072_1_6);
            this.groupBox15.Controls.Add(this.cb2072_1_5);
            this.groupBox15.Controls.Add(this.cb2072_1_4);
            this.groupBox15.Controls.Add(this.cb2072_1_3);
            this.groupBox15.Controls.Add(this.cb2072_1_2);
            this.groupBox15.Controls.Add(this.cb2072_1_1);
            this.groupBox15.Controls.Add(this.label47);
            this.groupBox15.Controls.Add(this.label48);
            this.groupBox15.Controls.Add(this.label49);
            this.groupBox15.Controls.Add(this.label51);
            this.groupBox15.Controls.Add(this.label52);
            this.groupBox15.Controls.Add(this.label43);
            this.groupBox15.Controls.Add(this.label44);
            this.groupBox15.Controls.Add(this.label45);
            this.groupBox15.Controls.Add(this.label46);
            this.groupBox15.Controls.Add(this.label42);
            this.groupBox15.Controls.Add(this.label41);
            this.groupBox15.Controls.Add(this.label40);
            this.groupBox15.Controls.Add(this.label37);
            this.groupBox15.Location = new System.Drawing.Point(3, -3);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(1006, 483);
            this.groupBox15.TabIndex = 0;
            this.groupBox15.TabStop = false;
            this.groupBox15.Tag = "3";
            // 
            // input2072_7_1
            // 
            this.input2072_7_1.Location = new System.Drawing.Point(88, 190);
            this.input2072_7_1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.input2072_7_1.Name = "input2072_7_1";
            this.input2072_7_1.Size = new System.Drawing.Size(39, 21);
            this.input2072_7_1.TabIndex = 451;
            this.input2072_7_1.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // input2072_3_1
            // 
            this.input2072_3_1.Location = new System.Drawing.Point(106, 73);
            this.input2072_3_1.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.input2072_3_1.Name = "input2072_3_1";
            this.input2072_3_1.Size = new System.Drawing.Size(52, 21);
            this.input2072_3_1.TabIndex = 450;
            this.input2072_3_1.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            // 
            // input2072_17_2
            // 
            this.input2072_17_2.Location = new System.Drawing.Point(241, 454);
            this.input2072_17_2.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.input2072_17_2.Name = "input2072_17_2";
            this.input2072_17_2.Size = new System.Drawing.Size(52, 21);
            this.input2072_17_2.TabIndex = 449;
            this.input2072_17_2.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            // 
            // input2072_16_8
            // 
            this.input2072_16_8.Location = new System.Drawing.Point(834, 432);
            this.input2072_16_8.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.input2072_16_8.Name = "input2072_16_8";
            this.input2072_16_8.Size = new System.Drawing.Size(52, 21);
            this.input2072_16_8.TabIndex = 448;
            this.input2072_16_8.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            // 
            // input2072_16_7
            // 
            this.input2072_16_7.Location = new System.Drawing.Point(726, 431);
            this.input2072_16_7.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.input2072_16_7.Name = "input2072_16_7";
            this.input2072_16_7.Size = new System.Drawing.Size(52, 21);
            this.input2072_16_7.TabIndex = 447;
            this.input2072_16_7.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            // 
            // input2072_14_7
            // 
            this.input2072_14_7.Location = new System.Drawing.Point(845, 381);
            this.input2072_14_7.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.input2072_14_7.Name = "input2072_14_7";
            this.input2072_14_7.Size = new System.Drawing.Size(52, 21);
            this.input2072_14_7.TabIndex = 446;
            this.input2072_14_7.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            // 
            // input2072_14_6
            // 
            this.input2072_14_6.Location = new System.Drawing.Point(742, 381);
            this.input2072_14_6.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.input2072_14_6.Name = "input2072_14_6";
            this.input2072_14_6.Size = new System.Drawing.Size(52, 21);
            this.input2072_14_6.TabIndex = 445;
            this.input2072_14_6.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            // 
            // input2072_14_5
            // 
            this.input2072_14_5.Location = new System.Drawing.Point(638, 381);
            this.input2072_14_5.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.input2072_14_5.Name = "input2072_14_5";
            this.input2072_14_5.Size = new System.Drawing.Size(52, 21);
            this.input2072_14_5.TabIndex = 444;
            this.input2072_14_5.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            // 
            // input2072_9_6
            // 
            this.input2072_9_6.Location = new System.Drawing.Point(741, 243);
            this.input2072_9_6.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.input2072_9_6.Name = "input2072_9_6";
            this.input2072_9_6.Size = new System.Drawing.Size(52, 21);
            this.input2072_9_6.TabIndex = 443;
            this.input2072_9_6.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            // 
            // input2072_9_5
            // 
            this.input2072_9_5.Location = new System.Drawing.Point(638, 243);
            this.input2072_9_5.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.input2072_9_5.Name = "input2072_9_5";
            this.input2072_9_5.Size = new System.Drawing.Size(52, 21);
            this.input2072_9_5.TabIndex = 442;
            this.input2072_9_5.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            // 
            // input2072_9_4
            // 
            this.input2072_9_4.Location = new System.Drawing.Point(515, 245);
            this.input2072_9_4.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.input2072_9_4.Name = "input2072_9_4";
            this.input2072_9_4.Size = new System.Drawing.Size(52, 21);
            this.input2072_9_4.TabIndex = 441;
            this.input2072_9_4.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            // 
            // input2072_2_4
            // 
            this.input2072_2_4.Location = new System.Drawing.Point(515, 42);
            this.input2072_2_4.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.input2072_2_4.Name = "input2072_2_4";
            this.input2072_2_4.Size = new System.Drawing.Size(52, 21);
            this.input2072_2_4.TabIndex = 440;
            this.input2072_2_4.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            // 
            // input2072_2_3
            // 
            this.input2072_2_3.Location = new System.Drawing.Point(380, 42);
            this.input2072_2_3.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.input2072_2_3.Name = "input2072_2_3";
            this.input2072_2_3.Size = new System.Drawing.Size(52, 21);
            this.input2072_2_3.TabIndex = 439;
            this.input2072_2_3.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            // 
            // input2072_2_2
            // 
            this.input2072_2_2.Location = new System.Drawing.Point(241, 42);
            this.input2072_2_2.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.input2072_2_2.Name = "input2072_2_2";
            this.input2072_2_2.Size = new System.Drawing.Size(52, 21);
            this.input2072_2_2.TabIndex = 438;
            this.input2072_2_2.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            // 
            // input2072_2_1
            // 
            this.input2072_2_1.Location = new System.Drawing.Point(106, 42);
            this.input2072_2_1.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.input2072_2_1.Name = "input2072_2_1";
            this.input2072_2_1.Size = new System.Drawing.Size(52, 21);
            this.input2072_2_1.TabIndex = 437;
            this.input2072_2_1.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            // 
            // input2072_3_6
            // 
            this.input2072_3_6.Location = new System.Drawing.Point(743, 72);
            this.input2072_3_6.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.input2072_3_6.Name = "input2072_3_6";
            this.input2072_3_6.Size = new System.Drawing.Size(52, 21);
            this.input2072_3_6.TabIndex = 436;
            this.input2072_3_6.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            // 
            // btn2072_f3
            // 
            this.btn2072_f3.Location = new System.Drawing.Point(924, 456);
            this.btn2072_f3.Name = "btn2072_f3";
            this.btn2072_f3.Size = new System.Drawing.Size(75, 23);
            this.btn2072_f3.TabIndex = 435;
            this.btn2072_f3.Tag = "17";
            this.btn2072_f3.Text = "Set 0xf3";
            this.btn2072_f3.UseVisualStyleBackColor = true;
            this.btn2072_f3.Click += new System.EventHandler(this.btn2072_1_Click);
            // 
            // btn2072_f2
            // 
            this.btn2072_f2.Location = new System.Drawing.Point(924, 432);
            this.btn2072_f2.Name = "btn2072_f2";
            this.btn2072_f2.Size = new System.Drawing.Size(75, 23);
            this.btn2072_f2.TabIndex = 434;
            this.btn2072_f2.Tag = "16";
            this.btn2072_f2.Text = "Set 0xf2";
            this.btn2072_f2.UseVisualStyleBackColor = true;
            this.btn2072_f2.Click += new System.EventHandler(this.btn2072_1_Click);
            // 
            // btn2072_f1
            // 
            this.btn2072_f1.Location = new System.Drawing.Point(924, 407);
            this.btn2072_f1.Name = "btn2072_f1";
            this.btn2072_f1.Size = new System.Drawing.Size(75, 23);
            this.btn2072_f1.TabIndex = 433;
            this.btn2072_f1.Tag = "15";
            this.btn2072_f1.Text = "Set 0xf1";
            this.btn2072_f1.UseVisualStyleBackColor = true;
            this.btn2072_f1.Click += new System.EventHandler(this.btn2072_1_Click);
            // 
            // btn2072_c
            // 
            this.btn2072_c.Location = new System.Drawing.Point(924, 325);
            this.btn2072_c.Name = "btn2072_c";
            this.btn2072_c.Size = new System.Drawing.Size(75, 23);
            this.btn2072_c.TabIndex = 432;
            this.btn2072_c.Tag = "12";
            this.btn2072_c.Text = "Set 0x0c";
            this.btn2072_c.UseVisualStyleBackColor = true;
            this.btn2072_c.Click += new System.EventHandler(this.btn2072_1_Click);
            // 
            // btn2072_b
            // 
            this.btn2072_b.Location = new System.Drawing.Point(924, 296);
            this.btn2072_b.Name = "btn2072_b";
            this.btn2072_b.Size = new System.Drawing.Size(75, 23);
            this.btn2072_b.TabIndex = 431;
            this.btn2072_b.Tag = "11";
            this.btn2072_b.Text = "Set 0x0b";
            this.btn2072_b.UseVisualStyleBackColor = true;
            this.btn2072_b.Click += new System.EventHandler(this.btn2072_1_Click);
            // 
            // btn2072_f0
            // 
            this.btn2072_f0.Location = new System.Drawing.Point(924, 382);
            this.btn2072_f0.Name = "btn2072_f0";
            this.btn2072_f0.Size = new System.Drawing.Size(75, 23);
            this.btn2072_f0.TabIndex = 430;
            this.btn2072_f0.Tag = "14";
            this.btn2072_f0.Text = "Set 0xf0";
            this.btn2072_f0.UseVisualStyleBackColor = true;
            this.btn2072_f0.Click += new System.EventHandler(this.btn2072_1_Click);
            // 
            // btn2072_d
            // 
            this.btn2072_d.Location = new System.Drawing.Point(924, 353);
            this.btn2072_d.Name = "btn2072_d";
            this.btn2072_d.Size = new System.Drawing.Size(75, 23);
            this.btn2072_d.TabIndex = 429;
            this.btn2072_d.Tag = "13";
            this.btn2072_d.Text = "Set 0x0d";
            this.btn2072_d.UseVisualStyleBackColor = true;
            this.btn2072_d.Click += new System.EventHandler(this.btn2072_1_Click);
            // 
            // btn2072_9
            // 
            this.btn2072_9.Location = new System.Drawing.Point(924, 244);
            this.btn2072_9.Name = "btn2072_9";
            this.btn2072_9.Size = new System.Drawing.Size(75, 23);
            this.btn2072_9.TabIndex = 428;
            this.btn2072_9.Tag = "9";
            this.btn2072_9.Text = "Set 0x09";
            this.btn2072_9.UseVisualStyleBackColor = true;
            this.btn2072_9.Click += new System.EventHandler(this.btn2072_1_Click);
            // 
            // btn2072_8
            // 
            this.btn2072_8.Location = new System.Drawing.Point(924, 218);
            this.btn2072_8.Name = "btn2072_8";
            this.btn2072_8.Size = new System.Drawing.Size(75, 23);
            this.btn2072_8.TabIndex = 427;
            this.btn2072_8.Tag = "8";
            this.btn2072_8.Text = "Set 0x08";
            this.btn2072_8.UseVisualStyleBackColor = true;
            this.btn2072_8.Click += new System.EventHandler(this.btn2072_1_Click);
            // 
            // cb2072_17_1
            // 
            this.cb2072_17_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_17_1.FormattingEnabled = true;
            this.cb2072_17_1.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_17_1.Location = new System.Drawing.Point(106, 456);
            this.cb2072_17_1.Name = "cb2072_17_1";
            this.cb2072_17_1.Size = new System.Drawing.Size(52, 20);
            this.cb2072_17_1.TabIndex = 425;
            this.cb2072_17_1.Tag = "2";
            // 
            // label154
            // 
            this.label154.AutoSize = true;
            this.label154.Location = new System.Drawing.Point(176, 456);
            this.label154.Name = "label154";
            this.label154.Size = new System.Drawing.Size(47, 12);
            this.label154.TabIndex = 423;
            this.label154.Text = "[7 - 0]";
            // 
            // label155
            // 
            this.label155.AutoSize = true;
            this.label155.Location = new System.Drawing.Point(45, 456);
            this.label155.Name = "label155";
            this.label155.Size = new System.Drawing.Size(47, 12);
            this.label155.TabIndex = 422;
            this.label155.Text = "[9 - 8]";
            // 
            // label156
            // 
            this.label156.AutoSize = true;
            this.label156.Location = new System.Drawing.Point(4, 456);
            this.label156.Name = "label156";
            this.label156.Size = new System.Drawing.Size(41, 12);
            this.label156.TabIndex = 421;
            this.label156.Text = "0xf3=>";
            // 
            // label147
            // 
            this.label147.AutoSize = true;
            this.label147.Location = new System.Drawing.Point(786, 435);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(35, 12);
            this.label147.TabIndex = 419;
            this.label147.Text = "[7-0]";
            // 
            // label136
            // 
            this.label136.AutoSize = true;
            this.label136.Location = new System.Drawing.Point(673, 435);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(41, 12);
            this.label136.TabIndex = 417;
            this.label136.Text = "[15-8]";
            // 
            // cb2072_16_6
            // 
            this.cb2072_16_6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_16_6.FormattingEnabled = true;
            this.cb2072_16_6.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_16_6.Location = new System.Drawing.Point(611, 432);
            this.cb2072_16_6.Name = "cb2072_16_6";
            this.cb2072_16_6.Size = new System.Drawing.Size(52, 20);
            this.cb2072_16_6.TabIndex = 416;
            this.cb2072_16_6.Tag = "8";
            // 
            // label138
            // 
            this.label138.AutoSize = true;
            this.label138.Location = new System.Drawing.Point(560, 435);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(47, 12);
            this.label138.TabIndex = 415;
            this.label138.Text = "[18-16]";
            // 
            // cb2072_16_5
            // 
            this.cb2072_16_5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_16_5.FormattingEnabled = true;
            this.cb2072_16_5.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_16_5.Location = new System.Drawing.Point(525, 432);
            this.cb2072_16_5.Name = "cb2072_16_5";
            this.cb2072_16_5.Size = new System.Drawing.Size(32, 20);
            this.cb2072_16_5.TabIndex = 414;
            this.cb2072_16_5.Tag = "8";
            // 
            // label139
            // 
            this.label139.AutoSize = true;
            this.label139.Location = new System.Drawing.Point(489, 435);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(29, 12);
            this.label139.TabIndex = 413;
            this.label139.Text = "[19]";
            // 
            // cb2072_16_4
            // 
            this.cb2072_16_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_16_4.FormattingEnabled = true;
            this.cb2072_16_4.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_16_4.Location = new System.Drawing.Point(417, 432);
            this.cb2072_16_4.Name = "cb2072_16_4";
            this.cb2072_16_4.Size = new System.Drawing.Size(52, 20);
            this.cb2072_16_4.TabIndex = 412;
            this.cb2072_16_4.Tag = "8";
            // 
            // label141
            // 
            this.label141.AutoSize = true;
            this.label141.Location = new System.Drawing.Point(354, 435);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(47, 12);
            this.label141.TabIndex = 411;
            this.label141.Text = "[22-20]";
            // 
            // cb2072_16_2
            // 
            this.cb2072_16_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_16_2.FormattingEnabled = true;
            this.cb2072_16_2.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_16_2.Location = new System.Drawing.Point(241, 432);
            this.cb2072_16_2.Name = "cb2072_16_2";
            this.cb2072_16_2.Size = new System.Drawing.Size(32, 20);
            this.cb2072_16_2.TabIndex = 410;
            this.cb2072_16_2.Tag = "2";
            // 
            // cb2072_16_3
            // 
            this.cb2072_16_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_16_3.FormattingEnabled = true;
            this.cb2072_16_3.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_16_3.Location = new System.Drawing.Point(311, 432);
            this.cb2072_16_3.Name = "cb2072_16_3";
            this.cb2072_16_3.Size = new System.Drawing.Size(32, 20);
            this.cb2072_16_3.TabIndex = 409;
            this.cb2072_16_3.Tag = "2";
            // 
            // cb2072_16_1
            // 
            this.cb2072_16_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_16_1.FormattingEnabled = true;
            this.cb2072_16_1.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_16_1.Location = new System.Drawing.Point(106, 432);
            this.cb2072_16_1.Name = "cb2072_16_1";
            this.cb2072_16_1.Size = new System.Drawing.Size(52, 20);
            this.cb2072_16_1.TabIndex = 408;
            this.cb2072_16_1.Tag = "2";
            // 
            // label142
            // 
            this.label142.AutoSize = true;
            this.label142.Location = new System.Drawing.Point(278, 435);
            this.label142.Name = "label142";
            this.label142.Size = new System.Drawing.Size(29, 12);
            this.label142.TabIndex = 407;
            this.label142.Text = "[23]";
            // 
            // label144
            // 
            this.label144.AutoSize = true;
            this.label144.Location = new System.Drawing.Point(176, 435);
            this.label144.Name = "label144";
            this.label144.Size = new System.Drawing.Size(41, 12);
            this.label144.TabIndex = 406;
            this.label144.Text = "[ 24 ]";
            // 
            // label145
            // 
            this.label145.AutoSize = true;
            this.label145.Location = new System.Drawing.Point(45, 435);
            this.label145.Name = "label145";
            this.label145.Size = new System.Drawing.Size(41, 12);
            this.label145.TabIndex = 405;
            this.label145.Text = "[ 25 ]";
            // 
            // label146
            // 
            this.label146.AutoSize = true;
            this.label146.Location = new System.Drawing.Point(4, 435);
            this.label146.Name = "label146";
            this.label146.Size = new System.Drawing.Size(41, 12);
            this.label146.TabIndex = 404;
            this.label146.Text = "0xf2=>";
            // 
            // cb2072_15_6
            // 
            this.cb2072_15_6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_15_6.FormattingEnabled = true;
            this.cb2072_15_6.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_15_6.Location = new System.Drawing.Point(741, 407);
            this.cb2072_15_6.Name = "cb2072_15_6";
            this.cb2072_15_6.Size = new System.Drawing.Size(52, 20);
            this.cb2072_15_6.TabIndex = 401;
            this.cb2072_15_6.Tag = "8";
            // 
            // label175
            // 
            this.label175.AutoSize = true;
            this.label175.Location = new System.Drawing.Point(696, 412);
            this.label175.Name = "label175";
            this.label175.Size = new System.Drawing.Size(35, 12);
            this.label175.TabIndex = 400;
            this.label175.Text = "[ 0 ]";
            // 
            // cb2072_15_5
            // 
            this.cb2072_15_5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_15_5.FormattingEnabled = true;
            this.cb2072_15_5.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_15_5.Location = new System.Drawing.Point(638, 407);
            this.cb2072_15_5.Name = "cb2072_15_5";
            this.cb2072_15_5.Size = new System.Drawing.Size(52, 20);
            this.cb2072_15_5.TabIndex = 399;
            this.cb2072_15_5.Tag = "8";
            // 
            // label178
            // 
            this.label178.AutoSize = true;
            this.label178.Location = new System.Drawing.Point(587, 412);
            this.label178.Name = "label178";
            this.label178.Size = new System.Drawing.Size(35, 12);
            this.label178.TabIndex = 398;
            this.label178.Text = "[ 1 ]";
            // 
            // cb2072_15_4
            // 
            this.cb2072_15_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_15_4.FormattingEnabled = true;
            this.cb2072_15_4.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_15_4.Location = new System.Drawing.Point(515, 407);
            this.cb2072_15_4.Name = "cb2072_15_4";
            this.cb2072_15_4.Size = new System.Drawing.Size(52, 20);
            this.cb2072_15_4.TabIndex = 397;
            this.cb2072_15_4.Tag = "8";
            // 
            // label181
            // 
            this.label181.AutoSize = true;
            this.label181.Location = new System.Drawing.Point(459, 412);
            this.label181.Name = "label181";
            this.label181.Size = new System.Drawing.Size(41, 12);
            this.label181.TabIndex = 396;
            this.label181.Text = "[11-8]";
            // 
            // cb2072_15_2
            // 
            this.cb2072_15_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_15_2.FormattingEnabled = true;
            this.cb2072_15_2.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_15_2.Location = new System.Drawing.Point(241, 407);
            this.cb2072_15_2.Name = "cb2072_15_2";
            this.cb2072_15_2.Size = new System.Drawing.Size(52, 20);
            this.cb2072_15_2.TabIndex = 395;
            this.cb2072_15_2.Tag = "2";
            // 
            // cb2072_15_3
            // 
            this.cb2072_15_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_15_3.FormattingEnabled = true;
            this.cb2072_15_3.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_15_3.Location = new System.Drawing.Point(380, 407);
            this.cb2072_15_3.Name = "cb2072_15_3";
            this.cb2072_15_3.Size = new System.Drawing.Size(52, 20);
            this.cb2072_15_3.TabIndex = 394;
            this.cb2072_15_3.Tag = "2";
            // 
            // cb2072_15_1
            // 
            this.cb2072_15_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_15_1.FormattingEnabled = true;
            this.cb2072_15_1.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_15_1.Location = new System.Drawing.Point(106, 407);
            this.cb2072_15_1.Name = "cb2072_15_1";
            this.cb2072_15_1.Size = new System.Drawing.Size(52, 20);
            this.cb2072_15_1.TabIndex = 393;
            this.cb2072_15_1.Tag = "2";
            // 
            // label207
            // 
            this.label207.AutoSize = true;
            this.label207.Location = new System.Drawing.Point(317, 412);
            this.label207.Name = "label207";
            this.label207.Size = new System.Drawing.Size(47, 12);
            this.label207.TabIndex = 392;
            this.label207.Text = "[13-12]";
            // 
            // label208
            // 
            this.label208.AutoSize = true;
            this.label208.Location = new System.Drawing.Point(176, 412);
            this.label208.Name = "label208";
            this.label208.Size = new System.Drawing.Size(41, 12);
            this.label208.TabIndex = 391;
            this.label208.Text = "[ 14 ]";
            // 
            // label209
            // 
            this.label209.AutoSize = true;
            this.label209.Location = new System.Drawing.Point(45, 412);
            this.label209.Name = "label209";
            this.label209.Size = new System.Drawing.Size(41, 12);
            this.label209.TabIndex = 390;
            this.label209.Text = "[ 15 ]";
            // 
            // label210
            // 
            this.label210.AutoSize = true;
            this.label210.Location = new System.Drawing.Point(2, 411);
            this.label210.Name = "label210";
            this.label210.Size = new System.Drawing.Size(41, 12);
            this.label210.TabIndex = 389;
            this.label210.Text = "0xf1=>";
            // 
            // cb2072_12_7
            // 
            this.cb2072_12_7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_12_7.FormattingEnabled = true;
            this.cb2072_12_7.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_12_7.Location = new System.Drawing.Point(845, 325);
            this.cb2072_12_7.Name = "cb2072_12_7";
            this.cb2072_12_7.Size = new System.Drawing.Size(52, 20);
            this.cb2072_12_7.TabIndex = 388;
            this.cb2072_12_7.Tag = "8";
            // 
            // label126
            // 
            this.label126.AutoSize = true;
            this.label126.Location = new System.Drawing.Point(804, 328);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(35, 12);
            this.label126.TabIndex = 387;
            this.label126.Text = "[4-0]";
            // 
            // cb2072_12_6
            // 
            this.cb2072_12_6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_12_6.FormattingEnabled = true;
            this.cb2072_12_6.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_12_6.Location = new System.Drawing.Point(741, 325);
            this.cb2072_12_6.Name = "cb2072_12_6";
            this.cb2072_12_6.Size = new System.Drawing.Size(52, 20);
            this.cb2072_12_6.TabIndex = 386;
            this.cb2072_12_6.Tag = "8";
            // 
            // label129
            // 
            this.label129.AutoSize = true;
            this.label129.Location = new System.Drawing.Point(696, 328);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(35, 12);
            this.label129.TabIndex = 385;
            this.label129.Text = "[7-6]";
            // 
            // cb2072_12_5
            // 
            this.cb2072_12_5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_12_5.FormattingEnabled = true;
            this.cb2072_12_5.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_12_5.Location = new System.Drawing.Point(638, 325);
            this.cb2072_12_5.Name = "cb2072_12_5";
            this.cb2072_12_5.Size = new System.Drawing.Size(52, 20);
            this.cb2072_12_5.TabIndex = 384;
            this.cb2072_12_5.Tag = "8";
            // 
            // label134
            // 
            this.label134.AutoSize = true;
            this.label134.Location = new System.Drawing.Point(585, 328);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(41, 12);
            this.label134.TabIndex = 383;
            this.label134.Text = "[12-8]";
            // 
            // cb2072_12_4
            // 
            this.cb2072_12_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_12_4.FormattingEnabled = true;
            this.cb2072_12_4.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_12_4.Location = new System.Drawing.Point(515, 325);
            this.cb2072_12_4.Name = "cb2072_12_4";
            this.cb2072_12_4.Size = new System.Drawing.Size(52, 20);
            this.cb2072_12_4.TabIndex = 382;
            this.cb2072_12_4.Tag = "8";
            // 
            // label137
            // 
            this.label137.AutoSize = true;
            this.label137.Location = new System.Drawing.Point(458, 328);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(47, 12);
            this.label137.TabIndex = 381;
            this.label137.Text = "[15-14]";
            // 
            // cb2072_12_2
            // 
            this.cb2072_12_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_12_2.FormattingEnabled = true;
            this.cb2072_12_2.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_12_2.Location = new System.Drawing.Point(241, 325);
            this.cb2072_12_2.Name = "cb2072_12_2";
            this.cb2072_12_2.Size = new System.Drawing.Size(52, 20);
            this.cb2072_12_2.TabIndex = 380;
            this.cb2072_12_2.Tag = "2";
            // 
            // cb2072_12_3
            // 
            this.cb2072_12_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_12_3.FormattingEnabled = true;
            this.cb2072_12_3.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_12_3.Location = new System.Drawing.Point(380, 325);
            this.cb2072_12_3.Name = "cb2072_12_3";
            this.cb2072_12_3.Size = new System.Drawing.Size(52, 20);
            this.cb2072_12_3.TabIndex = 379;
            this.cb2072_12_3.Tag = "2";
            // 
            // cb2072_12_1
            // 
            this.cb2072_12_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_12_1.FormattingEnabled = true;
            this.cb2072_12_1.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_12_1.Location = new System.Drawing.Point(106, 325);
            this.cb2072_12_1.Name = "cb2072_12_1";
            this.cb2072_12_1.Size = new System.Drawing.Size(52, 20);
            this.cb2072_12_1.TabIndex = 378;
            this.cb2072_12_1.Tag = "2";
            // 
            // label140
            // 
            this.label140.AutoSize = true;
            this.label140.Location = new System.Drawing.Point(317, 328);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(47, 12);
            this.label140.TabIndex = 377;
            this.label140.Text = "[20-16]";
            // 
            // label143
            // 
            this.label143.AutoSize = true;
            this.label143.Location = new System.Drawing.Point(176, 328);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(47, 12);
            this.label143.TabIndex = 376;
            this.label143.Text = "[23-22]";
            // 
            // label148
            // 
            this.label148.AutoSize = true;
            this.label148.Location = new System.Drawing.Point(45, 328);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(47, 12);
            this.label148.TabIndex = 375;
            this.label148.Text = "[31-24]";
            // 
            // label151
            // 
            this.label151.AutoSize = true;
            this.label151.Location = new System.Drawing.Point(3, 328);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(41, 12);
            this.label151.TabIndex = 374;
            this.label151.Text = "0x0c=>";
            // 
            // cb2072_11_7
            // 
            this.cb2072_11_7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_11_7.FormattingEnabled = true;
            this.cb2072_11_7.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_11_7.Location = new System.Drawing.Point(845, 296);
            this.cb2072_11_7.Name = "cb2072_11_7";
            this.cb2072_11_7.Size = new System.Drawing.Size(52, 20);
            this.cb2072_11_7.TabIndex = 373;
            this.cb2072_11_7.Tag = "8";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(804, 301);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(35, 12);
            this.label55.TabIndex = 372;
            this.label55.Text = "[4-0]";
            // 
            // cb2072_11_6
            // 
            this.cb2072_11_6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_11_6.FormattingEnabled = true;
            this.cb2072_11_6.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_11_6.Location = new System.Drawing.Point(741, 296);
            this.cb2072_11_6.Name = "cb2072_11_6";
            this.cb2072_11_6.Size = new System.Drawing.Size(52, 20);
            this.cb2072_11_6.TabIndex = 371;
            this.cb2072_11_6.Tag = "8";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(696, 301);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(35, 12);
            this.label57.TabIndex = 370;
            this.label57.Text = "[7-6]";
            // 
            // cb2072_11_5
            // 
            this.cb2072_11_5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_11_5.FormattingEnabled = true;
            this.cb2072_11_5.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_11_5.Location = new System.Drawing.Point(638, 296);
            this.cb2072_11_5.Name = "cb2072_11_5";
            this.cb2072_11_5.Size = new System.Drawing.Size(52, 20);
            this.cb2072_11_5.TabIndex = 369;
            this.cb2072_11_5.Tag = "8";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(585, 301);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(41, 12);
            this.label86.TabIndex = 368;
            this.label86.Text = "[12-8]";
            // 
            // cb2072_11_4
            // 
            this.cb2072_11_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_11_4.FormattingEnabled = true;
            this.cb2072_11_4.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_11_4.Location = new System.Drawing.Point(515, 296);
            this.cb2072_11_4.Name = "cb2072_11_4";
            this.cb2072_11_4.Size = new System.Drawing.Size(52, 20);
            this.cb2072_11_4.TabIndex = 367;
            this.cb2072_11_4.Tag = "8";
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(458, 301);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(47, 12);
            this.label88.TabIndex = 366;
            this.label88.Text = "[15-14]";
            // 
            // cb2072_11_2
            // 
            this.cb2072_11_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_11_2.FormattingEnabled = true;
            this.cb2072_11_2.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_11_2.Location = new System.Drawing.Point(241, 296);
            this.cb2072_11_2.Name = "cb2072_11_2";
            this.cb2072_11_2.Size = new System.Drawing.Size(52, 20);
            this.cb2072_11_2.TabIndex = 365;
            this.cb2072_11_2.Tag = "2";
            // 
            // cb2072_11_3
            // 
            this.cb2072_11_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_11_3.FormattingEnabled = true;
            this.cb2072_11_3.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_11_3.Location = new System.Drawing.Point(380, 296);
            this.cb2072_11_3.Name = "cb2072_11_3";
            this.cb2072_11_3.Size = new System.Drawing.Size(52, 20);
            this.cb2072_11_3.TabIndex = 364;
            this.cb2072_11_3.Tag = "2";
            // 
            // cb2072_11_1
            // 
            this.cb2072_11_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_11_1.FormattingEnabled = true;
            this.cb2072_11_1.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_11_1.Location = new System.Drawing.Point(106, 296);
            this.cb2072_11_1.Name = "cb2072_11_1";
            this.cb2072_11_1.Size = new System.Drawing.Size(52, 20);
            this.cb2072_11_1.TabIndex = 363;
            this.cb2072_11_1.Tag = "2";
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(317, 301);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(47, 12);
            this.label90.TabIndex = 362;
            this.label90.Text = "[20-16]";
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(176, 301);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(47, 12);
            this.label92.TabIndex = 361;
            this.label92.Text = "[23-22]";
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.Location = new System.Drawing.Point(45, 301);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(47, 12);
            this.label117.TabIndex = 360;
            this.label117.Text = "[31-24]";
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.Location = new System.Drawing.Point(3, 301);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(41, 12);
            this.label121.TabIndex = 359;
            this.label121.Text = "0x0b=>";
            // 
            // label158
            // 
            this.label158.AutoSize = true;
            this.label158.Location = new System.Drawing.Point(804, 386);
            this.label158.Name = "label158";
            this.label158.Size = new System.Drawing.Size(35, 12);
            this.label158.TabIndex = 321;
            this.label158.Text = "[7-0]";
            // 
            // label176
            // 
            this.label176.AutoSize = true;
            this.label176.Location = new System.Drawing.Point(696, 386);
            this.label176.Name = "label176";
            this.label176.Size = new System.Drawing.Size(41, 12);
            this.label176.TabIndex = 318;
            this.label176.Text = "[15-8]";
            // 
            // label177
            // 
            this.label177.AutoSize = true;
            this.label177.Location = new System.Drawing.Point(585, 386);
            this.label177.Name = "label177";
            this.label177.Size = new System.Drawing.Size(47, 12);
            this.label177.TabIndex = 316;
            this.label177.Text = "[23-16]";
            // 
            // cb2072_14_4
            // 
            this.cb2072_14_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_14_4.FormattingEnabled = true;
            this.cb2072_14_4.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_14_4.Location = new System.Drawing.Point(515, 382);
            this.cb2072_14_4.Name = "cb2072_14_4";
            this.cb2072_14_4.Size = new System.Drawing.Size(52, 20);
            this.cb2072_14_4.TabIndex = 314;
            this.cb2072_14_4.Tag = "3";
            // 
            // label179
            // 
            this.label179.AutoSize = true;
            this.label179.Location = new System.Drawing.Point(458, 386);
            this.label179.Name = "label179";
            this.label179.Size = new System.Drawing.Size(47, 12);
            this.label179.TabIndex = 313;
            this.label179.Text = "[26-24]";
            // 
            // cb2072_14_2
            // 
            this.cb2072_14_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_14_2.FormattingEnabled = true;
            this.cb2072_14_2.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_14_2.Location = new System.Drawing.Point(241, 382);
            this.cb2072_14_2.Name = "cb2072_14_2";
            this.cb2072_14_2.Size = new System.Drawing.Size(52, 20);
            this.cb2072_14_2.TabIndex = 312;
            this.cb2072_14_2.Tag = "1";
            // 
            // cb2072_14_3
            // 
            this.cb2072_14_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_14_3.FormattingEnabled = true;
            this.cb2072_14_3.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_14_3.Location = new System.Drawing.Point(380, 382);
            this.cb2072_14_3.Name = "cb2072_14_3";
            this.cb2072_14_3.Size = new System.Drawing.Size(52, 20);
            this.cb2072_14_3.TabIndex = 311;
            this.cb2072_14_3.Tag = "2";
            // 
            // cb2072_14_1
            // 
            this.cb2072_14_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_14_1.FormattingEnabled = true;
            this.cb2072_14_1.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_14_1.Location = new System.Drawing.Point(106, 382);
            this.cb2072_14_1.Name = "cb2072_14_1";
            this.cb2072_14_1.Size = new System.Drawing.Size(52, 20);
            this.cb2072_14_1.TabIndex = 310;
            this.cb2072_14_1.Tag = "1";
            // 
            // label180
            // 
            this.label180.AutoSize = true;
            this.label180.Location = new System.Drawing.Point(317, 386);
            this.label180.Name = "label180";
            this.label180.Size = new System.Drawing.Size(47, 12);
            this.label180.TabIndex = 309;
            this.label180.Text = "[29-28]";
            // 
            // label182
            // 
            this.label182.AutoSize = true;
            this.label182.Location = new System.Drawing.Point(176, 386);
            this.label182.Name = "label182";
            this.label182.Size = new System.Drawing.Size(47, 12);
            this.label182.TabIndex = 307;
            this.label182.Text = "[ 30  ]";
            // 
            // label183
            // 
            this.label183.AutoSize = true;
            this.label183.Location = new System.Drawing.Point(45, 386);
            this.label183.Name = "label183";
            this.label183.Size = new System.Drawing.Size(47, 12);
            this.label183.TabIndex = 306;
            this.label183.Text = "[ 31  ]";
            // 
            // label184
            // 
            this.label184.AutoSize = true;
            this.label184.Location = new System.Drawing.Point(3, 386);
            this.label184.Name = "label184";
            this.label184.Size = new System.Drawing.Size(41, 12);
            this.label184.TabIndex = 305;
            this.label184.Text = "0xf0=>";
            // 
            // cb2072_13_1
            // 
            this.cb2072_13_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_13_1.FormattingEnabled = true;
            this.cb2072_13_1.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_13_1.Location = new System.Drawing.Point(106, 353);
            this.cb2072_13_1.Name = "cb2072_13_1";
            this.cb2072_13_1.Size = new System.Drawing.Size(52, 20);
            this.cb2072_13_1.TabIndex = 304;
            this.cb2072_13_1.Tag = "8";
            // 
            // cb2072_13_10
            // 
            this.cb2072_13_10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_13_10.FormattingEnabled = true;
            this.cb2072_13_10.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_13_10.Location = new System.Drawing.Point(727, 353);
            this.cb2072_13_10.Name = "cb2072_13_10";
            this.cb2072_13_10.Size = new System.Drawing.Size(32, 20);
            this.cb2072_13_10.TabIndex = 301;
            this.cb2072_13_10.Tag = "1";
            // 
            // cb2072_13_9
            // 
            this.cb2072_13_9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_13_9.FormattingEnabled = true;
            this.cb2072_13_9.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_13_9.Location = new System.Drawing.Point(656, 353);
            this.cb2072_13_9.Name = "cb2072_13_9";
            this.cb2072_13_9.Size = new System.Drawing.Size(40, 20);
            this.cb2072_13_9.TabIndex = 300;
            this.cb2072_13_9.Tag = "1";
            // 
            // cb2072_13_8
            // 
            this.cb2072_13_8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_13_8.FormattingEnabled = true;
            this.cb2072_13_8.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_13_8.Location = new System.Drawing.Point(583, 353);
            this.cb2072_13_8.Name = "cb2072_13_8";
            this.cb2072_13_8.Size = new System.Drawing.Size(32, 20);
            this.cb2072_13_8.TabIndex = 299;
            this.cb2072_13_8.Tag = "1";
            // 
            // label159
            // 
            this.label159.AutoSize = true;
            this.label159.Location = new System.Drawing.Point(701, 357);
            this.label159.Name = "label159";
            this.label159.Size = new System.Drawing.Size(23, 12);
            this.label159.TabIndex = 298;
            this.label159.Text = "[3]";
            // 
            // label160
            // 
            this.label160.AutoSize = true;
            this.label160.Location = new System.Drawing.Point(619, 357);
            this.label160.Name = "label160";
            this.label160.Size = new System.Drawing.Size(35, 12);
            this.label160.TabIndex = 297;
            this.label160.Text = "[5-4]";
            // 
            // label161
            // 
            this.label161.AutoSize = true;
            this.label161.Location = new System.Drawing.Point(561, 357);
            this.label161.Name = "label161";
            this.label161.Size = new System.Drawing.Size(23, 12);
            this.label161.TabIndex = 296;
            this.label161.Text = "[6]";
            // 
            // btn2072_a
            // 
            this.btn2072_a.Location = new System.Drawing.Point(924, 271);
            this.btn2072_a.Name = "btn2072_a";
            this.btn2072_a.Size = new System.Drawing.Size(75, 23);
            this.btn2072_a.TabIndex = 295;
            this.btn2072_a.Tag = "10";
            this.btn2072_a.Text = "Set 0x0a";
            this.btn2072_a.UseVisualStyleBackColor = true;
            this.btn2072_a.Click += new System.EventHandler(this.btn2072_1_Click);
            // 
            // cb2072_13_12
            // 
            this.cb2072_13_12.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_13_12.FormattingEnabled = true;
            this.cb2072_13_12.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_13_12.Location = new System.Drawing.Point(845, 353);
            this.cb2072_13_12.Name = "cb2072_13_12";
            this.cb2072_13_12.Size = new System.Drawing.Size(40, 20);
            this.cb2072_13_12.TabIndex = 294;
            this.cb2072_13_12.Tag = "4";
            // 
            // cb2072_13_11
            // 
            this.cb2072_13_11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_13_11.FormattingEnabled = true;
            this.cb2072_13_11.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_13_11.Location = new System.Drawing.Point(784, 353);
            this.cb2072_13_11.Name = "cb2072_13_11";
            this.cb2072_13_11.Size = new System.Drawing.Size(32, 20);
            this.cb2072_13_11.TabIndex = 293;
            this.cb2072_13_11.Tag = "4";
            // 
            // cb2072_13_7
            // 
            this.cb2072_13_7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_13_7.FormattingEnabled = true;
            this.cb2072_13_7.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_13_7.Location = new System.Drawing.Point(527, 353);
            this.cb2072_13_7.Name = "cb2072_13_7";
            this.cb2072_13_7.Size = new System.Drawing.Size(32, 20);
            this.cb2072_13_7.TabIndex = 292;
            this.cb2072_13_7.Tag = "1";
            // 
            // cb2072_13_6
            // 
            this.cb2072_13_6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_13_6.FormattingEnabled = true;
            this.cb2072_13_6.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_13_6.Location = new System.Drawing.Point(469, 353);
            this.cb2072_13_6.Name = "cb2072_13_6";
            this.cb2072_13_6.Size = new System.Drawing.Size(32, 20);
            this.cb2072_13_6.TabIndex = 291;
            this.cb2072_13_6.Tag = "1";
            // 
            // cb2072_13_5
            // 
            this.cb2072_13_5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_13_5.FormattingEnabled = true;
            this.cb2072_13_5.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_13_5.Location = new System.Drawing.Point(408, 353);
            this.cb2072_13_5.Name = "cb2072_13_5";
            this.cb2072_13_5.Size = new System.Drawing.Size(32, 20);
            this.cb2072_13_5.TabIndex = 290;
            this.cb2072_13_5.Tag = "1";
            // 
            // cb2072_13_4
            // 
            this.cb2072_13_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_13_4.FormattingEnabled = true;
            this.cb2072_13_4.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_13_4.Location = new System.Drawing.Point(343, 353);
            this.cb2072_13_4.Name = "cb2072_13_4";
            this.cb2072_13_4.Size = new System.Drawing.Size(32, 20);
            this.cb2072_13_4.TabIndex = 289;
            this.cb2072_13_4.Tag = "1";
            // 
            // cb2072_13_3
            // 
            this.cb2072_13_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_13_3.FormattingEnabled = true;
            this.cb2072_13_3.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_13_3.Location = new System.Drawing.Point(274, 353);
            this.cb2072_13_3.Name = "cb2072_13_3";
            this.cb2072_13_3.Size = new System.Drawing.Size(32, 20);
            this.cb2072_13_3.TabIndex = 288;
            this.cb2072_13_3.Tag = "1";
            // 
            // cb2072_13_2
            // 
            this.cb2072_13_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_13_2.FormattingEnabled = true;
            this.cb2072_13_2.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_13_2.Location = new System.Drawing.Point(204, 353);
            this.cb2072_13_2.Name = "cb2072_13_2";
            this.cb2072_13_2.Size = new System.Drawing.Size(40, 20);
            this.cb2072_13_2.TabIndex = 287;
            this.cb2072_13_2.Tag = "1";
            // 
            // label162
            // 
            this.label162.AutoSize = true;
            this.label162.Location = new System.Drawing.Point(812, 357);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(35, 12);
            this.label162.TabIndex = 285;
            this.label162.Text = "[1-0]";
            // 
            // label163
            // 
            this.label163.AutoSize = true;
            this.label163.Location = new System.Drawing.Point(761, 357);
            this.label163.Name = "label163";
            this.label163.Size = new System.Drawing.Size(23, 12);
            this.label163.TabIndex = 284;
            this.label163.Tag = "7-6";
            this.label163.Text = "[2]";
            // 
            // label165
            // 
            this.label165.AutoSize = true;
            this.label165.Location = new System.Drawing.Point(504, 357);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(23, 12);
            this.label165.TabIndex = 282;
            this.label165.Text = "[8]";
            // 
            // label166
            // 
            this.label166.AutoSize = true;
            this.label166.Location = new System.Drawing.Point(444, 357);
            this.label166.Name = "label166";
            this.label166.Size = new System.Drawing.Size(23, 12);
            this.label166.TabIndex = 281;
            this.label166.Text = "[9]";
            // 
            // label167
            // 
            this.label167.AutoSize = true;
            this.label167.Location = new System.Drawing.Point(378, 357);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(29, 12);
            this.label167.TabIndex = 280;
            this.label167.Text = "[10]";
            // 
            // label168
            // 
            this.label168.AutoSize = true;
            this.label168.Location = new System.Drawing.Point(308, 357);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(29, 12);
            this.label168.TabIndex = 279;
            this.label168.Text = "[11]";
            // 
            // label169
            // 
            this.label169.AutoSize = true;
            this.label169.Location = new System.Drawing.Point(248, 357);
            this.label169.Name = "label169";
            this.label169.Size = new System.Drawing.Size(29, 12);
            this.label169.TabIndex = 278;
            this.label169.Text = "[12]";
            // 
            // label171
            // 
            this.label171.AutoSize = true;
            this.label171.Location = new System.Drawing.Point(159, 357);
            this.label171.Name = "label171";
            this.label171.Size = new System.Drawing.Size(47, 12);
            this.label171.TabIndex = 276;
            this.label171.Text = "[26-24]";
            // 
            // label173
            // 
            this.label173.AutoSize = true;
            this.label173.Location = new System.Drawing.Point(45, 357);
            this.label173.Name = "label173";
            this.label173.Size = new System.Drawing.Size(47, 12);
            this.label173.TabIndex = 274;
            this.label173.Text = "[31-30]";
            // 
            // label174
            // 
            this.label174.AutoSize = true;
            this.label174.Location = new System.Drawing.Point(3, 358);
            this.label174.Name = "label174";
            this.label174.Size = new System.Drawing.Size(41, 12);
            this.label174.TabIndex = 273;
            this.label174.Text = "0x0d=>";
            // 
            // cb2072_10_7
            // 
            this.cb2072_10_7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_10_7.FormattingEnabled = true;
            this.cb2072_10_7.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_10_7.Location = new System.Drawing.Point(845, 271);
            this.cb2072_10_7.Name = "cb2072_10_7";
            this.cb2072_10_7.Size = new System.Drawing.Size(52, 20);
            this.cb2072_10_7.TabIndex = 236;
            this.cb2072_10_7.Tag = "8";
            // 
            // label133
            // 
            this.label133.AutoSize = true;
            this.label133.Location = new System.Drawing.Point(804, 276);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(35, 12);
            this.label133.TabIndex = 235;
            this.label133.Text = "[4-0]";
            // 
            // cb2072_10_6
            // 
            this.cb2072_10_6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_10_6.FormattingEnabled = true;
            this.cb2072_10_6.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_10_6.Location = new System.Drawing.Point(741, 271);
            this.cb2072_10_6.Name = "cb2072_10_6";
            this.cb2072_10_6.Size = new System.Drawing.Size(52, 20);
            this.cb2072_10_6.TabIndex = 232;
            this.cb2072_10_6.Tag = "8";
            // 
            // label135
            // 
            this.label135.AutoSize = true;
            this.label135.Location = new System.Drawing.Point(696, 276);
            this.label135.Name = "label135";
            this.label135.Size = new System.Drawing.Size(35, 12);
            this.label135.TabIndex = 231;
            this.label135.Text = "[7-6]";
            // 
            // cb2072_10_5
            // 
            this.cb2072_10_5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_10_5.FormattingEnabled = true;
            this.cb2072_10_5.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_10_5.Location = new System.Drawing.Point(638, 271);
            this.cb2072_10_5.Name = "cb2072_10_5";
            this.cb2072_10_5.Size = new System.Drawing.Size(52, 20);
            this.cb2072_10_5.TabIndex = 230;
            this.cb2072_10_5.Tag = "8";
            // 
            // label125
            // 
            this.label125.AutoSize = true;
            this.label125.Location = new System.Drawing.Point(585, 276);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(41, 12);
            this.label125.TabIndex = 229;
            this.label125.Text = "[12-8]";
            // 
            // cb2072_10_4
            // 
            this.cb2072_10_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_10_4.FormattingEnabled = true;
            this.cb2072_10_4.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_10_4.Location = new System.Drawing.Point(515, 271);
            this.cb2072_10_4.Name = "cb2072_10_4";
            this.cb2072_10_4.Size = new System.Drawing.Size(52, 20);
            this.cb2072_10_4.TabIndex = 226;
            this.cb2072_10_4.Tag = "8";
            // 
            // label127
            // 
            this.label127.AutoSize = true;
            this.label127.Location = new System.Drawing.Point(458, 276);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(47, 12);
            this.label127.TabIndex = 225;
            this.label127.Text = "[15-14]";
            // 
            // cb2072_10_2
            // 
            this.cb2072_10_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_10_2.FormattingEnabled = true;
            this.cb2072_10_2.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_10_2.Location = new System.Drawing.Point(241, 271);
            this.cb2072_10_2.Name = "cb2072_10_2";
            this.cb2072_10_2.Size = new System.Drawing.Size(52, 20);
            this.cb2072_10_2.TabIndex = 224;
            this.cb2072_10_2.Tag = "2";
            // 
            // cb2072_10_3
            // 
            this.cb2072_10_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_10_3.FormattingEnabled = true;
            this.cb2072_10_3.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_10_3.Location = new System.Drawing.Point(380, 271);
            this.cb2072_10_3.Name = "cb2072_10_3";
            this.cb2072_10_3.Size = new System.Drawing.Size(52, 20);
            this.cb2072_10_3.TabIndex = 223;
            this.cb2072_10_3.Tag = "2";
            // 
            // cb2072_10_1
            // 
            this.cb2072_10_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_10_1.FormattingEnabled = true;
            this.cb2072_10_1.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_10_1.Location = new System.Drawing.Point(106, 271);
            this.cb2072_10_1.Name = "cb2072_10_1";
            this.cb2072_10_1.Size = new System.Drawing.Size(52, 20);
            this.cb2072_10_1.TabIndex = 222;
            this.cb2072_10_1.Tag = "2";
            // 
            // label128
            // 
            this.label128.AutoSize = true;
            this.label128.Location = new System.Drawing.Point(317, 276);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(47, 12);
            this.label128.TabIndex = 221;
            this.label128.Text = "[20-16]";
            // 
            // label130
            // 
            this.label130.AutoSize = true;
            this.label130.Location = new System.Drawing.Point(176, 276);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(47, 12);
            this.label130.TabIndex = 219;
            this.label130.Text = "[23-22]";
            // 
            // label131
            // 
            this.label131.AutoSize = true;
            this.label131.Location = new System.Drawing.Point(45, 276);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(47, 12);
            this.label131.TabIndex = 218;
            this.label131.Text = "[31-24]";
            // 
            // label132
            // 
            this.label132.AutoSize = true;
            this.label132.Location = new System.Drawing.Point(3, 276);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(41, 12);
            this.label132.TabIndex = 217;
            this.label132.Text = "0x0a=>";
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.Location = new System.Drawing.Point(696, 247);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(35, 12);
            this.label123.TabIndex = 215;
            this.label123.Text = "[7-0]";
            // 
            // label124
            // 
            this.label124.AutoSize = true;
            this.label124.Location = new System.Drawing.Point(587, 247);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(41, 12);
            this.label124.TabIndex = 213;
            this.label124.Text = "[15-8]";
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Location = new System.Drawing.Point(459, 247);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(47, 12);
            this.label111.TabIndex = 211;
            this.label111.Text = "[23-16]";
            // 
            // cb2072_9_1
            // 
            this.cb2072_9_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_9_1.FormattingEnabled = true;
            this.cb2072_9_1.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_9_1.Location = new System.Drawing.Point(106, 244);
            this.cb2072_9_1.Name = "cb2072_9_1";
            this.cb2072_9_1.Size = new System.Drawing.Size(52, 20);
            this.cb2072_9_1.TabIndex = 210;
            this.cb2072_9_1.Tag = "2";
            // 
            // cb2072_9_3
            // 
            this.cb2072_9_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_9_3.FormattingEnabled = true;
            this.cb2072_9_3.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_9_3.Location = new System.Drawing.Point(380, 244);
            this.cb2072_9_3.Name = "cb2072_9_3";
            this.cb2072_9_3.Size = new System.Drawing.Size(52, 20);
            this.cb2072_9_3.TabIndex = 209;
            this.cb2072_9_3.Tag = "2";
            // 
            // cb2072_9_2
            // 
            this.cb2072_9_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_9_2.FormattingEnabled = true;
            this.cb2072_9_2.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_9_2.Location = new System.Drawing.Point(241, 244);
            this.cb2072_9_2.Name = "cb2072_9_2";
            this.cb2072_9_2.Size = new System.Drawing.Size(52, 20);
            this.cb2072_9_2.TabIndex = 208;
            this.cb2072_9_2.Tag = "2";
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.Location = new System.Drawing.Point(317, 247);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(47, 12);
            this.label112.TabIndex = 207;
            this.label112.Text = "[25-24]";
            // 
            // label113
            // 
            this.label113.AutoSize = true;
            this.label113.Location = new System.Drawing.Point(177, 247);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(47, 12);
            this.label113.TabIndex = 206;
            this.label113.Text = "[27-26]";
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.Location = new System.Drawing.Point(45, 247);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(47, 12);
            this.label120.TabIndex = 205;
            this.label120.Text = "[29-28]";
            // 
            // label122
            // 
            this.label122.AutoSize = true;
            this.label122.Location = new System.Drawing.Point(3, 247);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(41, 12);
            this.label122.TabIndex = 203;
            this.label122.Text = "0x09=>";
            // 
            // cb2072_8_4
            // 
            this.cb2072_8_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_8_4.FormattingEnabled = true;
            this.cb2072_8_4.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_8_4.Location = new System.Drawing.Point(515, 218);
            this.cb2072_8_4.Name = "cb2072_8_4";
            this.cb2072_8_4.Size = new System.Drawing.Size(52, 20);
            this.cb2072_8_4.TabIndex = 202;
            this.cb2072_8_4.Tag = "4";
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.Location = new System.Drawing.Point(459, 221);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(47, 12);
            this.label114.TabIndex = 198;
            this.label114.Text = "[3 - 0]";
            // 
            // cb2072_8_1
            // 
            this.cb2072_8_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_8_1.FormattingEnabled = true;
            this.cb2072_8_1.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_8_1.Location = new System.Drawing.Point(106, 218);
            this.cb2072_8_1.Name = "cb2072_8_1";
            this.cb2072_8_1.Size = new System.Drawing.Size(52, 20);
            this.cb2072_8_1.TabIndex = 197;
            this.cb2072_8_1.Tag = "4";
            // 
            // cb2072_8_3
            // 
            this.cb2072_8_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_8_3.FormattingEnabled = true;
            this.cb2072_8_3.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_8_3.Location = new System.Drawing.Point(380, 218);
            this.cb2072_8_3.Name = "cb2072_8_3";
            this.cb2072_8_3.Size = new System.Drawing.Size(52, 20);
            this.cb2072_8_3.TabIndex = 196;
            this.cb2072_8_3.Tag = "4";
            // 
            // cb2072_8_2
            // 
            this.cb2072_8_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_8_2.FormattingEnabled = true;
            this.cb2072_8_2.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_8_2.Location = new System.Drawing.Point(241, 218);
            this.cb2072_8_2.Name = "cb2072_8_2";
            this.cb2072_8_2.Size = new System.Drawing.Size(52, 20);
            this.cb2072_8_2.TabIndex = 195;
            this.cb2072_8_2.Tag = "5";
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.Location = new System.Drawing.Point(317, 221);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(47, 12);
            this.label115.TabIndex = 194;
            this.label115.Text = "[7 - 4]";
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.Location = new System.Drawing.Point(177, 221);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(41, 12);
            this.label116.TabIndex = 193;
            this.label116.Text = "[12-8]";
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.Location = new System.Drawing.Point(45, 221);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(47, 12);
            this.label118.TabIndex = 191;
            this.label118.Text = "[31-28]";
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.Location = new System.Drawing.Point(3, 221);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(41, 12);
            this.label119.TabIndex = 190;
            this.label119.Text = "0x08=>";
            // 
            // cb2072_7_14
            // 
            this.cb2072_7_14.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_7_14.FormattingEnabled = true;
            this.cb2072_7_14.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_7_14.Location = new System.Drawing.Point(878, 191);
            this.cb2072_7_14.Name = "cb2072_7_14";
            this.cb2072_7_14.Size = new System.Drawing.Size(40, 20);
            this.cb2072_7_14.TabIndex = 188;
            this.cb2072_7_14.Tag = "4";
            // 
            // label110
            // 
            this.label110.AutoSize = true;
            this.label110.Location = new System.Drawing.Point(844, 194);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(35, 12);
            this.label110.TabIndex = 187;
            this.label110.Text = "[3-0]";
            // 
            // cb2072_7_11
            // 
            this.cb2072_7_11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_7_11.FormattingEnabled = true;
            this.cb2072_7_11.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_7_11.Location = new System.Drawing.Point(664, 191);
            this.cb2072_7_11.Name = "cb2072_7_11";
            this.cb2072_7_11.Size = new System.Drawing.Size(32, 20);
            this.cb2072_7_11.TabIndex = 186;
            this.cb2072_7_11.Tag = "1";
            // 
            // cb2072_7_10
            // 
            this.cb2072_7_10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_7_10.FormattingEnabled = true;
            this.cb2072_7_10.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_7_10.Location = new System.Drawing.Point(606, 191);
            this.cb2072_7_10.Name = "cb2072_7_10";
            this.cb2072_7_10.Size = new System.Drawing.Size(32, 20);
            this.cb2072_7_10.TabIndex = 185;
            this.cb2072_7_10.Tag = "1";
            // 
            // cb2072_7_9
            // 
            this.cb2072_7_9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_7_9.FormattingEnabled = true;
            this.cb2072_7_9.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_7_9.Location = new System.Drawing.Point(549, 191);
            this.cb2072_7_9.Name = "cb2072_7_9";
            this.cb2072_7_9.Size = new System.Drawing.Size(32, 20);
            this.cb2072_7_9.TabIndex = 184;
            this.cb2072_7_9.Tag = "1";
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Location = new System.Drawing.Point(636, 194);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(29, 12);
            this.label96.TabIndex = 183;
            this.label96.Text = "[12]";
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Location = new System.Drawing.Point(579, 194);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(29, 12);
            this.label99.TabIndex = 182;
            this.label99.Text = "[13]";
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.Location = new System.Drawing.Point(521, 194);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(29, 12);
            this.label109.TabIndex = 181;
            this.label109.Text = "[14]";
            // 
            // btn2072_7
            // 
            this.btn2072_7.Location = new System.Drawing.Point(925, 189);
            this.btn2072_7.Name = "btn2072_7";
            this.btn2072_7.Size = new System.Drawing.Size(75, 23);
            this.btn2072_7.TabIndex = 180;
            this.btn2072_7.Tag = "7";
            this.btn2072_7.Text = "Set 0x07";
            this.btn2072_7.UseVisualStyleBackColor = true;
            this.btn2072_7.Click += new System.EventHandler(this.btn2072_1_Click);
            // 
            // cb2072_7_13
            // 
            this.cb2072_7_13.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_7_13.FormattingEnabled = true;
            this.cb2072_7_13.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_7_13.Location = new System.Drawing.Point(804, 191);
            this.cb2072_7_13.Name = "cb2072_7_13";
            this.cb2072_7_13.Size = new System.Drawing.Size(40, 20);
            this.cb2072_7_13.TabIndex = 179;
            this.cb2072_7_13.Tag = "4";
            // 
            // cb2072_7_12
            // 
            this.cb2072_7_12.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_7_12.FormattingEnabled = true;
            this.cb2072_7_12.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_7_12.Location = new System.Drawing.Point(733, 191);
            this.cb2072_7_12.Name = "cb2072_7_12";
            this.cb2072_7_12.Size = new System.Drawing.Size(40, 20);
            this.cb2072_7_12.TabIndex = 178;
            this.cb2072_7_12.Tag = "4";
            // 
            // cb2072_7_8
            // 
            this.cb2072_7_8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_7_8.FormattingEnabled = true;
            this.cb2072_7_8.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_7_8.Location = new System.Drawing.Point(488, 191);
            this.cb2072_7_8.Name = "cb2072_7_8";
            this.cb2072_7_8.Size = new System.Drawing.Size(32, 20);
            this.cb2072_7_8.TabIndex = 175;
            this.cb2072_7_8.Tag = "1";
            // 
            // cb2072_7_7
            // 
            this.cb2072_7_7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_7_7.FormattingEnabled = true;
            this.cb2072_7_7.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_7_7.Location = new System.Drawing.Point(433, 191);
            this.cb2072_7_7.Name = "cb2072_7_7";
            this.cb2072_7_7.Size = new System.Drawing.Size(32, 20);
            this.cb2072_7_7.TabIndex = 174;
            this.cb2072_7_7.Tag = "1";
            // 
            // cb2072_7_6
            // 
            this.cb2072_7_6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_7_6.FormattingEnabled = true;
            this.cb2072_7_6.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_7_6.Location = new System.Drawing.Point(377, 191);
            this.cb2072_7_6.Name = "cb2072_7_6";
            this.cb2072_7_6.Size = new System.Drawing.Size(32, 20);
            this.cb2072_7_6.TabIndex = 173;
            this.cb2072_7_6.Tag = "1";
            // 
            // cb2072_7_5
            // 
            this.cb2072_7_5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_7_5.FormattingEnabled = true;
            this.cb2072_7_5.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_7_5.Location = new System.Drawing.Point(320, 191);
            this.cb2072_7_5.Name = "cb2072_7_5";
            this.cb2072_7_5.Size = new System.Drawing.Size(32, 20);
            this.cb2072_7_5.TabIndex = 172;
            this.cb2072_7_5.Tag = "1";
            // 
            // cb2072_7_4
            // 
            this.cb2072_7_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_7_4.FormattingEnabled = true;
            this.cb2072_7_4.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_7_4.Location = new System.Drawing.Point(263, 191);
            this.cb2072_7_4.Name = "cb2072_7_4";
            this.cb2072_7_4.Size = new System.Drawing.Size(32, 20);
            this.cb2072_7_4.TabIndex = 170;
            this.cb2072_7_4.Tag = "1";
            // 
            // cb2072_7_3
            // 
            this.cb2072_7_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_7_3.FormattingEnabled = true;
            this.cb2072_7_3.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_7_3.Location = new System.Drawing.Point(207, 191);
            this.cb2072_7_3.Name = "cb2072_7_3";
            this.cb2072_7_3.Size = new System.Drawing.Size(32, 20);
            this.cb2072_7_3.TabIndex = 169;
            this.cb2072_7_3.Tag = "1";
            // 
            // cb2072_7_2
            // 
            this.cb2072_7_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_7_2.FormattingEnabled = true;
            this.cb2072_7_2.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_7_2.Location = new System.Drawing.Point(151, 191);
            this.cb2072_7_2.Name = "cb2072_7_2";
            this.cb2072_7_2.Size = new System.Drawing.Size(32, 20);
            this.cb2072_7_2.TabIndex = 168;
            this.cb2072_7_2.Tag = "1";
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Location = new System.Drawing.Point(772, 194);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(35, 12);
            this.label94.TabIndex = 167;
            this.label94.Text = "[7-4]";
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(694, 194);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(41, 12);
            this.label95.TabIndex = 166;
            this.label95.Tag = "7-6";
            this.label95.Text = "[11-8]";
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.Location = new System.Drawing.Point(462, 194);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(29, 12);
            this.label98.TabIndex = 163;
            this.label98.Text = "[16]";
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Location = new System.Drawing.Point(407, 194);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(29, 12);
            this.label100.TabIndex = 161;
            this.label100.Text = "[17]";
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Location = new System.Drawing.Point(350, 194);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(29, 12);
            this.label101.TabIndex = 160;
            this.label101.Text = "[18]";
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Location = new System.Drawing.Point(294, 194);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(29, 12);
            this.label102.TabIndex = 159;
            this.label102.Text = "[19]";
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.Location = new System.Drawing.Point(237, 194);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(29, 12);
            this.label104.TabIndex = 157;
            this.label104.Text = "[21]";
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.Location = new System.Drawing.Point(181, 194);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(29, 12);
            this.label105.TabIndex = 156;
            this.label105.Text = "[22]";
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.Location = new System.Drawing.Point(125, 194);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(29, 12);
            this.label106.TabIndex = 155;
            this.label106.Text = "[23]";
            // 
            // label107
            // 
            this.label107.AutoSize = true;
            this.label107.Location = new System.Drawing.Point(42, 194);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(47, 12);
            this.label107.TabIndex = 154;
            this.label107.Text = "[31-24]";
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.Location = new System.Drawing.Point(3, 194);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(41, 12);
            this.label108.TabIndex = 153;
            this.label108.Text = "0x07=>";
            // 
            // cb2072_5_4
            // 
            this.cb2072_5_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_5_4.FormattingEnabled = true;
            this.cb2072_5_4.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_5_4.Location = new System.Drawing.Point(515, 131);
            this.cb2072_5_4.Name = "cb2072_5_4";
            this.cb2072_5_4.Size = new System.Drawing.Size(52, 20);
            this.cb2072_5_4.TabIndex = 152;
            this.cb2072_5_4.Tag = "5";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(459, 136);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(47, 12);
            this.label85.TabIndex = 150;
            this.label85.Text = "[4 - 0]";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(317, 136);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(47, 12);
            this.label87.TabIndex = 148;
            this.label87.Text = "[12-8 ]";
            // 
            // cb2072_5_1
            // 
            this.cb2072_5_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_5_1.FormattingEnabled = true;
            this.cb2072_5_1.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_5_1.Location = new System.Drawing.Point(106, 131);
            this.cb2072_5_1.Name = "cb2072_5_1";
            this.cb2072_5_1.Size = new System.Drawing.Size(52, 20);
            this.cb2072_5_1.TabIndex = 146;
            this.cb2072_5_1.Tag = "5";
            // 
            // btn2072_5
            // 
            this.btn2072_5.Location = new System.Drawing.Point(924, 131);
            this.btn2072_5.Name = "btn2072_5";
            this.btn2072_5.Size = new System.Drawing.Size(75, 23);
            this.btn2072_5.TabIndex = 145;
            this.btn2072_5.Tag = "5";
            this.btn2072_5.Text = "Set 0x05";
            this.btn2072_5.UseVisualStyleBackColor = true;
            this.btn2072_5.Click += new System.EventHandler(this.btn2072_1_Click);
            // 
            // cb2072_5_3
            // 
            this.cb2072_5_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_5_3.FormattingEnabled = true;
            this.cb2072_5_3.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_5_3.Location = new System.Drawing.Point(380, 131);
            this.cb2072_5_3.Name = "cb2072_5_3";
            this.cb2072_5_3.Size = new System.Drawing.Size(52, 20);
            this.cb2072_5_3.TabIndex = 144;
            this.cb2072_5_3.Tag = "5";
            // 
            // cb2072_5_2
            // 
            this.cb2072_5_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_5_2.FormattingEnabled = true;
            this.cb2072_5_2.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_5_2.Location = new System.Drawing.Point(241, 131);
            this.cb2072_5_2.Name = "cb2072_5_2";
            this.cb2072_5_2.Size = new System.Drawing.Size(52, 20);
            this.cb2072_5_2.TabIndex = 142;
            this.cb2072_5_2.Tag = "5";
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(177, 136);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(47, 12);
            this.label89.TabIndex = 141;
            this.label89.Text = "[20-16]";
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(45, 136);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(47, 12);
            this.label91.TabIndex = 139;
            this.label91.Text = "[28-24]";
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(3, 136);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(41, 12);
            this.label93.TabIndex = 137;
            this.label93.Text = "0x05=>";
            // 
            // cb2072_6_6
            // 
            this.cb2072_6_6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_6_6.FormattingEnabled = true;
            this.cb2072_6_6.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_6_6.Location = new System.Drawing.Point(742, 160);
            this.cb2072_6_6.Name = "cb2072_6_6";
            this.cb2072_6_6.Size = new System.Drawing.Size(52, 20);
            this.cb2072_6_6.TabIndex = 136;
            this.cb2072_6_6.Tag = "4";
            // 
            // cb2072_6_5
            // 
            this.cb2072_6_5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_6_5.FormattingEnabled = true;
            this.cb2072_6_5.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_6_5.Location = new System.Drawing.Point(638, 160);
            this.cb2072_6_5.Name = "cb2072_6_5";
            this.cb2072_6_5.Size = new System.Drawing.Size(52, 20);
            this.cb2072_6_5.TabIndex = 135;
            this.cb2072_6_5.Tag = "4";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(696, 164);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(35, 12);
            this.label82.TabIndex = 134;
            this.label82.Text = "[3-0]";
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(587, 164);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(47, 12);
            this.label83.TabIndex = 133;
            this.label83.Text = "[7 - 4]";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(459, 164);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(41, 12);
            this.label84.TabIndex = 132;
            this.label84.Text = "[11-8]";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(317, 164);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(47, 12);
            this.label81.TabIndex = 131;
            this.label81.Text = "[15-12]";
            // 
            // cb2072_6_1
            // 
            this.cb2072_6_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_6_1.FormattingEnabled = true;
            this.cb2072_6_1.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_6_1.Location = new System.Drawing.Point(106, 160);
            this.cb2072_6_1.Name = "cb2072_6_1";
            this.cb2072_6_1.Size = new System.Drawing.Size(52, 20);
            this.cb2072_6_1.TabIndex = 130;
            this.cb2072_6_1.Tag = "5";
            // 
            // btn2072_6
            // 
            this.btn2072_6.Location = new System.Drawing.Point(924, 160);
            this.btn2072_6.Name = "btn2072_6";
            this.btn2072_6.Size = new System.Drawing.Size(75, 23);
            this.btn2072_6.TabIndex = 129;
            this.btn2072_6.Tag = "6";
            this.btn2072_6.Text = "Set 0x06";
            this.btn2072_6.UseVisualStyleBackColor = true;
            this.btn2072_6.Click += new System.EventHandler(this.btn2072_1_Click);
            // 
            // cb2072_6_4
            // 
            this.cb2072_6_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_6_4.FormattingEnabled = true;
            this.cb2072_6_4.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_6_4.Location = new System.Drawing.Point(515, 160);
            this.cb2072_6_4.Name = "cb2072_6_4";
            this.cb2072_6_4.Size = new System.Drawing.Size(52, 20);
            this.cb2072_6_4.TabIndex = 128;
            this.cb2072_6_4.Tag = "4";
            // 
            // cb2072_6_3
            // 
            this.cb2072_6_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_6_3.FormattingEnabled = true;
            this.cb2072_6_3.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_6_3.Location = new System.Drawing.Point(380, 160);
            this.cb2072_6_3.Name = "cb2072_6_3";
            this.cb2072_6_3.Size = new System.Drawing.Size(52, 20);
            this.cb2072_6_3.TabIndex = 127;
            this.cb2072_6_3.Tag = "4";
            // 
            // cb2072_6_2
            // 
            this.cb2072_6_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_6_2.FormattingEnabled = true;
            this.cb2072_6_2.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_6_2.Location = new System.Drawing.Point(241, 160);
            this.cb2072_6_2.Name = "cb2072_6_2";
            this.cb2072_6_2.Size = new System.Drawing.Size(52, 20);
            this.cb2072_6_2.TabIndex = 126;
            this.cb2072_6_2.Tag = "5";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(177, 164);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(47, 12);
            this.label54.TabIndex = 125;
            this.label54.Text = "[20-16]";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(45, 164);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(47, 12);
            this.label56.TabIndex = 123;
            this.label56.Text = "[28-24]";
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(3, 164);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(41, 12);
            this.label80.TabIndex = 121;
            this.label80.Text = "0x06=>";
            // 
            // btn2072_4
            // 
            this.btn2072_4.Location = new System.Drawing.Point(924, 102);
            this.btn2072_4.Name = "btn2072_4";
            this.btn2072_4.Size = new System.Drawing.Size(75, 23);
            this.btn2072_4.TabIndex = 120;
            this.btn2072_4.Tag = "4";
            this.btn2072_4.Text = "Set 0x04";
            this.btn2072_4.UseVisualStyleBackColor = true;
            this.btn2072_4.Click += new System.EventHandler(this.btn2072_1_Click);
            // 
            // cb2072_4_6
            // 
            this.cb2072_4_6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_4_6.FormattingEnabled = true;
            this.cb2072_4_6.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_4_6.Location = new System.Drawing.Point(743, 102);
            this.cb2072_4_6.Name = "cb2072_4_6";
            this.cb2072_4_6.Size = new System.Drawing.Size(52, 20);
            this.cb2072_4_6.TabIndex = 116;
            this.cb2072_4_6.Tag = "5";
            // 
            // cb2072_4_5
            // 
            this.cb2072_4_5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_4_5.FormattingEnabled = true;
            this.cb2072_4_5.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_4_5.Location = new System.Drawing.Point(638, 102);
            this.cb2072_4_5.Name = "cb2072_4_5";
            this.cb2072_4_5.Size = new System.Drawing.Size(52, 20);
            this.cb2072_4_5.TabIndex = 114;
            this.cb2072_4_5.Tag = "5";
            // 
            // cb2072_4_4
            // 
            this.cb2072_4_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_4_4.FormattingEnabled = true;
            this.cb2072_4_4.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_4_4.Location = new System.Drawing.Point(515, 102);
            this.cb2072_4_4.Name = "cb2072_4_4";
            this.cb2072_4_4.Size = new System.Drawing.Size(52, 20);
            this.cb2072_4_4.TabIndex = 112;
            this.cb2072_4_4.Tag = "2";
            // 
            // cb2072_4_3
            // 
            this.cb2072_4_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_4_3.FormattingEnabled = true;
            this.cb2072_4_3.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_4_3.Location = new System.Drawing.Point(380, 102);
            this.cb2072_4_3.Name = "cb2072_4_3";
            this.cb2072_4_3.Size = new System.Drawing.Size(52, 20);
            this.cb2072_4_3.TabIndex = 110;
            this.cb2072_4_3.Tag = "1";
            // 
            // cb2072_4_2
            // 
            this.cb2072_4_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_4_2.FormattingEnabled = true;
            this.cb2072_4_2.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_4_2.Location = new System.Drawing.Point(241, 102);
            this.cb2072_4_2.Name = "cb2072_4_2";
            this.cb2072_4_2.Size = new System.Drawing.Size(52, 20);
            this.cb2072_4_2.TabIndex = 109;
            this.cb2072_4_2.Tag = "1";
            // 
            // cb2072_4_1
            // 
            this.cb2072_4_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_4_1.FormattingEnabled = true;
            this.cb2072_4_1.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_4_1.Location = new System.Drawing.Point(106, 102);
            this.cb2072_4_1.Name = "cb2072_4_1";
            this.cb2072_4_1.Size = new System.Drawing.Size(52, 20);
            this.cb2072_4_1.TabIndex = 108;
            this.cb2072_4_1.Tag = "1";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(696, 107);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(47, 12);
            this.label58.TabIndex = 103;
            this.label58.Text = "[4 - 0]";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(585, 107);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(47, 12);
            this.label68.TabIndex = 101;
            this.label68.Text = "[12-8 ]";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(459, 107);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(47, 12);
            this.label73.TabIndex = 99;
            this.label73.Text = "[17-16]";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(317, 107);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(47, 12);
            this.label75.TabIndex = 97;
            this.label75.Text = "[ 24  ]";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(177, 107);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(47, 12);
            this.label76.TabIndex = 96;
            this.label76.Text = "[ 25  ]";
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(45, 107);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(47, 12);
            this.label77.TabIndex = 95;
            this.label77.Text = "[ 26  ]";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(3, 107);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(41, 12);
            this.label79.TabIndex = 93;
            this.label79.Text = "0x04=>";
            // 
            // cb2072_3_5
            // 
            this.cb2072_3_5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_3_5.FormattingEnabled = true;
            this.cb2072_3_5.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_3_5.Location = new System.Drawing.Point(638, 72);
            this.cb2072_3_5.Name = "cb2072_3_5";
            this.cb2072_3_5.Size = new System.Drawing.Size(52, 20);
            this.cb2072_3_5.TabIndex = 92;
            this.cb2072_3_5.Tag = "2";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(585, 76);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(47, 12);
            this.label64.TabIndex = 91;
            this.label64.Text = "[17-16]";
            // 
            // cb2072_3_4
            // 
            this.cb2072_3_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_3_4.FormattingEnabled = true;
            this.cb2072_3_4.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_3_4.Location = new System.Drawing.Point(516, 72);
            this.cb2072_3_4.Name = "cb2072_3_4";
            this.cb2072_3_4.Size = new System.Drawing.Size(52, 20);
            this.cb2072_3_4.TabIndex = 90;
            this.cb2072_3_4.Tag = "2";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(458, 76);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(47, 12);
            this.label65.TabIndex = 89;
            this.label65.Text = "[19-18]";
            // 
            // cb2072_3_3
            // 
            this.cb2072_3_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_3_3.FormattingEnabled = true;
            this.cb2072_3_3.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_3_3.Location = new System.Drawing.Point(380, 72);
            this.cb2072_3_3.Name = "cb2072_3_3";
            this.cb2072_3_3.Size = new System.Drawing.Size(52, 20);
            this.cb2072_3_3.TabIndex = 88;
            this.cb2072_3_3.Tag = "2";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(317, 76);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(47, 12);
            this.label60.TabIndex = 87;
            this.label60.Text = "[21-20]";
            // 
            // btn2072_3
            // 
            this.btn2072_3.Location = new System.Drawing.Point(924, 72);
            this.btn2072_3.Name = "btn2072_3";
            this.btn2072_3.Size = new System.Drawing.Size(75, 23);
            this.btn2072_3.TabIndex = 85;
            this.btn2072_3.Tag = "3";
            this.btn2072_3.Text = "Set 0x03";
            this.btn2072_3.UseVisualStyleBackColor = true;
            this.btn2072_3.Click += new System.EventHandler(this.btn2072_1_Click);
            // 
            // cb2072_3_2
            // 
            this.cb2072_3_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_3_2.FormattingEnabled = true;
            this.cb2072_3_2.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_3_2.Location = new System.Drawing.Point(241, 72);
            this.cb2072_3_2.Name = "cb2072_3_2";
            this.cb2072_3_2.Size = new System.Drawing.Size(52, 20);
            this.cb2072_3_2.TabIndex = 73;
            this.cb2072_3_2.Tag = "2";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(695, 76);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(47, 12);
            this.label53.TabIndex = 72;
            this.label53.Text = "[15-0 ]";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(177, 76);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(47, 12);
            this.label70.TabIndex = 60;
            this.label70.Text = "[23-22]";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(45, 76);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(47, 12);
            this.label71.TabIndex = 59;
            this.label71.Text = "[31-24]";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(3, 76);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(41, 12);
            this.label72.TabIndex = 58;
            this.label72.Text = "0x03=>";
            // 
            // btn2072_2
            // 
            this.btn2072_2.Location = new System.Drawing.Point(924, 43);
            this.btn2072_2.Name = "btn2072_2";
            this.btn2072_2.Size = new System.Drawing.Size(75, 23);
            this.btn2072_2.TabIndex = 56;
            this.btn2072_2.Tag = "2";
            this.btn2072_2.Text = "Set 0x02";
            this.btn2072_2.UseVisualStyleBackColor = true;
            this.btn2072_2.Click += new System.EventHandler(this.btn2072_1_Click);
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(458, 45);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(35, 12);
            this.label61.TabIndex = 35;
            this.label61.Text = "[7-0]";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(317, 45);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(41, 12);
            this.label62.TabIndex = 34;
            this.label62.Text = "[15-8]";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(178, 45);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(47, 12);
            this.label63.TabIndex = 33;
            this.label63.Text = "[23-16]";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(45, 45);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(47, 12);
            this.label66.TabIndex = 30;
            this.label66.Text = "[31-24]";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(3, 44);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(41, 12);
            this.label67.TabIndex = 29;
            this.label67.Text = "0x02=>";
            // 
            // btn2072_1
            // 
            this.btn2072_1.Location = new System.Drawing.Point(924, 14);
            this.btn2072_1.Name = "btn2072_1";
            this.btn2072_1.Size = new System.Drawing.Size(75, 23);
            this.btn2072_1.TabIndex = 28;
            this.btn2072_1.Tag = "1";
            this.btn2072_1.Text = "Set 0x01";
            this.btn2072_1.UseVisualStyleBackColor = true;
            this.btn2072_1.Click += new System.EventHandler(this.btn2072_1_Click);
            // 
            // cb2072_1_12
            // 
            this.cb2072_1_12.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_1_12.FormattingEnabled = true;
            this.cb2072_1_12.Location = new System.Drawing.Point(834, 12);
            this.cb2072_1_12.Name = "cb2072_1_12";
            this.cb2072_1_12.Size = new System.Drawing.Size(40, 20);
            this.cb2072_1_12.TabIndex = 27;
            this.cb2072_1_12.Tag = "6";
            // 
            // cb2072_1_11
            // 
            this.cb2072_1_11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_1_11.FormattingEnabled = true;
            this.cb2072_1_11.Location = new System.Drawing.Point(754, 12);
            this.cb2072_1_11.Name = "cb2072_1_11";
            this.cb2072_1_11.Size = new System.Drawing.Size(40, 20);
            this.cb2072_1_11.TabIndex = 26;
            this.cb2072_1_11.Tag = "2";
            // 
            // cb2072_1_10
            // 
            this.cb2072_1_10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_1_10.FormattingEnabled = true;
            this.cb2072_1_10.Location = new System.Drawing.Point(671, 12);
            this.cb2072_1_10.Name = "cb2072_1_10";
            this.cb2072_1_10.Size = new System.Drawing.Size(40, 20);
            this.cb2072_1_10.TabIndex = 25;
            this.cb2072_1_10.Tag = "7";
            // 
            // cb2072_1_9
            // 
            this.cb2072_1_9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_1_9.FormattingEnabled = true;
            this.cb2072_1_9.Location = new System.Drawing.Point(598, 12);
            this.cb2072_1_9.Name = "cb2072_1_9";
            this.cb2072_1_9.Size = new System.Drawing.Size(32, 20);
            this.cb2072_1_9.TabIndex = 23;
            this.cb2072_1_9.Tag = "1";
            // 
            // cb2072_1_8
            // 
            this.cb2072_1_8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_1_8.FormattingEnabled = true;
            this.cb2072_1_8.Location = new System.Drawing.Point(536, 12);
            this.cb2072_1_8.Name = "cb2072_1_8";
            this.cb2072_1_8.Size = new System.Drawing.Size(32, 20);
            this.cb2072_1_8.TabIndex = 22;
            this.cb2072_1_8.Tag = "1";
            // 
            // cb2072_1_7
            // 
            this.cb2072_1_7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_1_7.FormattingEnabled = true;
            this.cb2072_1_7.Location = new System.Drawing.Point(466, 12);
            this.cb2072_1_7.Name = "cb2072_1_7";
            this.cb2072_1_7.Size = new System.Drawing.Size(32, 20);
            this.cb2072_1_7.TabIndex = 21;
            this.cb2072_1_7.Tag = "1";
            // 
            // cb2072_1_6
            // 
            this.cb2072_1_6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_1_6.FormattingEnabled = true;
            this.cb2072_1_6.Location = new System.Drawing.Point(398, 12);
            this.cb2072_1_6.Name = "cb2072_1_6";
            this.cb2072_1_6.Size = new System.Drawing.Size(32, 20);
            this.cb2072_1_6.TabIndex = 20;
            this.cb2072_1_6.Tag = "1";
            // 
            // cb2072_1_5
            // 
            this.cb2072_1_5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_1_5.FormattingEnabled = true;
            this.cb2072_1_5.Location = new System.Drawing.Point(333, 12);
            this.cb2072_1_5.Name = "cb2072_1_5";
            this.cb2072_1_5.Size = new System.Drawing.Size(32, 20);
            this.cb2072_1_5.TabIndex = 19;
            this.cb2072_1_5.Tag = "1";
            // 
            // cb2072_1_4
            // 
            this.cb2072_1_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_1_4.FormattingEnabled = true;
            this.cb2072_1_4.Location = new System.Drawing.Point(268, 12);
            this.cb2072_1_4.Name = "cb2072_1_4";
            this.cb2072_1_4.Size = new System.Drawing.Size(32, 20);
            this.cb2072_1_4.TabIndex = 18;
            this.cb2072_1_4.Tag = "1";
            // 
            // cb2072_1_3
            // 
            this.cb2072_1_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_1_3.FormattingEnabled = true;
            this.cb2072_1_3.Location = new System.Drawing.Point(209, 12);
            this.cb2072_1_3.Name = "cb2072_1_3";
            this.cb2072_1_3.Size = new System.Drawing.Size(32, 20);
            this.cb2072_1_3.TabIndex = 17;
            this.cb2072_1_3.Tag = "1";
            // 
            // cb2072_1_2
            // 
            this.cb2072_1_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_1_2.FormattingEnabled = true;
            this.cb2072_1_2.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cb2072_1_2.Location = new System.Drawing.Point(142, 12);
            this.cb2072_1_2.Name = "cb2072_1_2";
            this.cb2072_1_2.Size = new System.Drawing.Size(32, 20);
            this.cb2072_1_2.TabIndex = 16;
            this.cb2072_1_2.Tag = "1";
            // 
            // cb2072_1_1
            // 
            this.cb2072_1_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072_1_1.FormattingEnabled = true;
            this.cb2072_1_1.Location = new System.Drawing.Point(77, 12);
            this.cb2072_1_1.Name = "cb2072_1_1";
            this.cb2072_1_1.Size = new System.Drawing.Size(32, 20);
            this.cb2072_1_1.TabIndex = 15;
            this.cb2072_1_1.Tag = "1";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(802, 16);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(35, 12);
            this.label47.TabIndex = 14;
            this.label47.Text = "[5-0]";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(713, 16);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(35, 12);
            this.label48.TabIndex = 13;
            this.label48.Tag = "7-6";
            this.label48.Text = "[7-6]";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(632, 16);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(41, 12);
            this.label49.TabIndex = 12;
            this.label49.Text = "[14-8]";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(568, 16);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(29, 12);
            this.label51.TabIndex = 10;
            this.label51.Text = "[16]";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(503, 16);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(29, 12);
            this.label52.TabIndex = 9;
            this.label52.Text = "[17]";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(434, 16);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(29, 12);
            this.label43.TabIndex = 8;
            this.label43.Text = "[18]";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(364, 16);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(29, 12);
            this.label44.TabIndex = 7;
            this.label44.Text = "[19]";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(302, 16);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(29, 12);
            this.label45.TabIndex = 6;
            this.label45.Text = "[20]";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(241, 16);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(29, 12);
            this.label46.TabIndex = 5;
            this.label46.Text = "[21]";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(177, 16);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(29, 12);
            this.label42.TabIndex = 4;
            this.label42.Text = "[22]";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(114, 16);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(29, 12);
            this.label41.TabIndex = 3;
            this.label41.Text = "[23]";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(45, 16);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(29, 12);
            this.label40.TabIndex = 2;
            this.label40.Text = "[24]";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(3, 14);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(41, 12);
            this.label37.TabIndex = 0;
            this.label37.Text = "0x01=>";
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage6.Controls.Add(this.panel3);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1352, 764);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "简化界面";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.btnRead2072);
            this.panel3.Controls.Add(this.btn2072Simple2_TryCalc);
            this.panel3.Controls.Add(this.gpSimple2019);
            this.panel3.Controls.Add(this.gpSimple2072GAMMA);
            this.panel3.Controls.Add(this.cb2072Simple5060Hz);
            this.panel3.Controls.Add(this.btn2072Simple_SendAll);
            this.panel3.Controls.Add(this.btn2072Simple_ExportFile);
            this.panel3.Controls.Add(this.btn2072Simple_ImportFile);
            this.panel3.Controls.Add(this.btn2072Simple_ResetValues);
            this.panel3.Controls.Add(this.gP2072Simple13);
            this.panel3.Controls.Add(this.gP2072Simple12);
            this.panel3.Controls.Add(this.gP2072Simple11);
            this.panel3.Controls.Add(this.gP2072Simple10);
            this.panel3.Controls.Add(this.gP2072Simple9);
            this.panel3.Controls.Add(this.gP2072Simple8);
            this.panel3.Controls.Add(this.gP2072Simple6);
            this.panel3.Controls.Add(this.gP2072Simple5);
            this.panel3.Controls.Add(this.gP2072Simple4);
            this.panel3.Controls.Add(this.gP2072Simple7);
            this.panel3.Controls.Add(this.gP2072Simple3);
            this.panel3.Controls.Add(this.gP2072Simple2);
            this.panel3.Controls.Add(this.gP2072Simple1);
            this.panel3.Controls.Add(this.gp2072FuncTest);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1346, 758);
            this.panel3.TabIndex = 2;
            // 
            // btnRead2072
            // 
            this.btnRead2072.Enabled = false;
            this.btnRead2072.Location = new System.Drawing.Point(619, 6);
            this.btnRead2072.Name = "btnRead2072";
            this.btnRead2072.Size = new System.Drawing.Size(96, 29);
            this.btnRead2072.TabIndex = 444;
            this.btnRead2072.Text = "读取";
            this.btnRead2072.UseVisualStyleBackColor = true;
            this.btnRead2072.Click += new System.EventHandler(this.btnRead2072_Click);
            // 
            // btn2072Simple2_TryCalc
            // 
            this.btn2072Simple2_TryCalc.ForeColor = System.Drawing.Color.Red;
            this.btn2072Simple2_TryCalc.Location = new System.Drawing.Point(379, 105);
            this.btn2072Simple2_TryCalc.Name = "btn2072Simple2_TryCalc";
            this.btn2072Simple2_TryCalc.Size = new System.Drawing.Size(143, 37);
            this.btn2072Simple2_TryCalc.TabIndex = 443;
            this.btn2072Simple2_TryCalc.Tag = "";
            this.btn2072Simple2_TryCalc.Text = "验证输入参数";
            this.btn2072Simple2_TryCalc.UseVisualStyleBackColor = true;
            this.btn2072Simple2_TryCalc.Click += new System.EventHandler(this.btn2072Simple2_TryCalc_Click);
            // 
            // gpSimple2019
            // 
            this.gpSimple2019.Controls.Add(this.label215);
            this.gpSimple2019.Controls.Add(this.btnSet2019Simple_All);
            this.gpSimple2019.Controls.Add(this.label216);
            this.gpSimple2019.Controls.Add(this.label217);
            this.gpSimple2019.Controls.Add(this.label218);
            this.gpSimple2019.Controls.Add(this.btnSet2019Simple_163);
            this.gpSimple2019.Controls.Add(this.input2019Simple_163);
            this.gpSimple2019.Controls.Add(this.label219);
            this.gpSimple2019.Controls.Add(this.btnSet2019Simple_162);
            this.gpSimple2019.Controls.Add(this.input2019Simple_162);
            this.gpSimple2019.Controls.Add(this.label220);
            this.gpSimple2019.Controls.Add(this.btnSet2019Simple_161);
            this.gpSimple2019.Controls.Add(this.input2019Simple_161);
            this.gpSimple2019.Controls.Add(this.label221);
            this.gpSimple2019.Controls.Add(this.btnSet2019Simple_160);
            this.gpSimple2019.Controls.Add(this.input2019Simple_160);
            this.gpSimple2019.Controls.Add(this.label222);
            this.gpSimple2019.Location = new System.Drawing.Point(2, 481);
            this.gpSimple2019.Name = "gpSimple2019";
            this.gpSimple2019.Size = new System.Drawing.Size(770, 72);
            this.gpSimple2019.TabIndex = 442;
            this.gpSimple2019.TabStop = false;
            this.gpSimple2019.Text = "2019寄存器设置";
            this.gpSimple2019.Visible = false;
            // 
            // label215
            // 
            this.label215.AutoSize = true;
            this.label215.Location = new System.Drawing.Point(515, 26);
            this.label215.Name = "label215";
            this.label215.Size = new System.Drawing.Size(77, 12);
            this.label215.TabIndex = 464;
            this.label215.Text = "数据上沿起点";
            // 
            // btnSet2019Simple_All
            // 
            this.btnSet2019Simple_All.Location = new System.Drawing.Point(690, 40);
            this.btnSet2019Simple_All.Name = "btnSet2019Simple_All";
            this.btnSet2019Simple_All.Size = new System.Drawing.Size(75, 21);
            this.btnSet2019Simple_All.TabIndex = 463;
            this.btnSet2019Simple_All.Tag = "4";
            this.btnSet2019Simple_All.Text = "全部设置";
            this.btnSet2019Simple_All.UseVisualStyleBackColor = true;
            this.btnSet2019Simple_All.Click += new System.EventHandler(this.btnSet2019All_Click);
            // 
            // label216
            // 
            this.label216.AutoSize = true;
            this.label216.Location = new System.Drawing.Point(348, 26);
            this.label216.Name = "label216";
            this.label216.Size = new System.Drawing.Size(77, 12);
            this.label216.TabIndex = 462;
            this.label216.Text = "信号下沿终点";
            // 
            // label217
            // 
            this.label217.AutoSize = true;
            this.label217.Location = new System.Drawing.Point(194, 26);
            this.label217.Name = "label217";
            this.label217.Size = new System.Drawing.Size(53, 12);
            this.label217.TabIndex = 461;
            this.label217.Text = "消隐强度";
            // 
            // label218
            // 
            this.label218.AutoSize = true;
            this.label218.Location = new System.Drawing.Point(6, 26);
            this.label218.Name = "label218";
            this.label218.Size = new System.Drawing.Size(77, 12);
            this.label218.TabIndex = 460;
            this.label218.Text = "时钟上沿起点";
            // 
            // btnSet2019Simple_163
            // 
            this.btnSet2019Simple_163.Location = new System.Drawing.Point(623, 41);
            this.btnSet2019Simple_163.Name = "btnSet2019Simple_163";
            this.btnSet2019Simple_163.Size = new System.Drawing.Size(42, 21);
            this.btnSet2019Simple_163.TabIndex = 459;
            this.btnSet2019Simple_163.Tag = "3";
            this.btnSet2019Simple_163.Text = "设置";
            this.btnSet2019Simple_163.UseVisualStyleBackColor = true;
            this.btnSet2019Simple_163.Click += new System.EventHandler(this.btnSet2019All_Click);
            // 
            // input2019Simple_163
            // 
            this.input2019Simple_163.Location = new System.Drawing.Point(577, 41);
            this.input2019Simple_163.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.input2019Simple_163.Name = "input2019Simple_163";
            this.input2019Simple_163.Size = new System.Drawing.Size(40, 21);
            this.input2019Simple_163.TabIndex = 458;
            this.input2019Simple_163.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label219
            // 
            this.label219.AutoSize = true;
            this.label219.Location = new System.Drawing.Point(515, 43);
            this.label219.Name = "label219";
            this.label219.Size = new System.Drawing.Size(53, 12);
            this.label219.TabIndex = 457;
            this.label219.Text = "Addr=163";
            // 
            // btnSet2019Simple_162
            // 
            this.btnSet2019Simple_162.Location = new System.Drawing.Point(447, 41);
            this.btnSet2019Simple_162.Name = "btnSet2019Simple_162";
            this.btnSet2019Simple_162.Size = new System.Drawing.Size(42, 21);
            this.btnSet2019Simple_162.TabIndex = 456;
            this.btnSet2019Simple_162.Tag = "2";
            this.btnSet2019Simple_162.Text = "设置";
            this.btnSet2019Simple_162.UseVisualStyleBackColor = true;
            this.btnSet2019Simple_162.Click += new System.EventHandler(this.btnSet2019All_Click);
            // 
            // input2019Simple_162
            // 
            this.input2019Simple_162.Location = new System.Drawing.Point(401, 41);
            this.input2019Simple_162.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.input2019Simple_162.Name = "input2019Simple_162";
            this.input2019Simple_162.Size = new System.Drawing.Size(40, 21);
            this.input2019Simple_162.TabIndex = 455;
            this.input2019Simple_162.Value = new decimal(new int[] {
            48,
            0,
            0,
            0});
            // 
            // label220
            // 
            this.label220.AutoSize = true;
            this.label220.Location = new System.Drawing.Point(346, 43);
            this.label220.Name = "label220";
            this.label220.Size = new System.Drawing.Size(53, 12);
            this.label220.TabIndex = 454;
            this.label220.Text = "Addr=162";
            // 
            // btnSet2019Simple_161
            // 
            this.btnSet2019Simple_161.Location = new System.Drawing.Point(294, 41);
            this.btnSet2019Simple_161.Name = "btnSet2019Simple_161";
            this.btnSet2019Simple_161.Size = new System.Drawing.Size(42, 21);
            this.btnSet2019Simple_161.TabIndex = 453;
            this.btnSet2019Simple_161.Tag = "1";
            this.btnSet2019Simple_161.Text = "设置";
            this.btnSet2019Simple_161.UseVisualStyleBackColor = true;
            this.btnSet2019Simple_161.Click += new System.EventHandler(this.btnSet2019All_Click);
            // 
            // input2019Simple_161
            // 
            this.input2019Simple_161.Location = new System.Drawing.Point(248, 41);
            this.input2019Simple_161.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.input2019Simple_161.Name = "input2019Simple_161";
            this.input2019Simple_161.Size = new System.Drawing.Size(40, 21);
            this.input2019Simple_161.TabIndex = 452;
            this.input2019Simple_161.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label221
            // 
            this.label221.AutoSize = true;
            this.label221.Location = new System.Drawing.Point(194, 43);
            this.label221.Name = "label221";
            this.label221.Size = new System.Drawing.Size(53, 12);
            this.label221.TabIndex = 451;
            this.label221.Text = "Addr=161";
            // 
            // btnSet2019Simple_160
            // 
            this.btnSet2019Simple_160.Location = new System.Drawing.Point(105, 41);
            this.btnSet2019Simple_160.Name = "btnSet2019Simple_160";
            this.btnSet2019Simple_160.Size = new System.Drawing.Size(42, 21);
            this.btnSet2019Simple_160.TabIndex = 450;
            this.btnSet2019Simple_160.Tag = "0";
            this.btnSet2019Simple_160.Text = "设置";
            this.btnSet2019Simple_160.UseVisualStyleBackColor = true;
            this.btnSet2019Simple_160.Click += new System.EventHandler(this.btnSet2019All_Click);
            // 
            // input2019Simple_160
            // 
            this.input2019Simple_160.Location = new System.Drawing.Point(59, 41);
            this.input2019Simple_160.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.input2019Simple_160.Name = "input2019Simple_160";
            this.input2019Simple_160.Size = new System.Drawing.Size(40, 21);
            this.input2019Simple_160.TabIndex = 449;
            this.input2019Simple_160.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // label222
            // 
            this.label222.AutoSize = true;
            this.label222.Location = new System.Drawing.Point(3, 43);
            this.label222.Name = "label222";
            this.label222.Size = new System.Drawing.Size(53, 12);
            this.label222.TabIndex = 448;
            this.label222.Text = "Addr=160";
            // 
            // gpSimple2072GAMMA
            // 
            this.gpSimple2072GAMMA.Controls.Add(this.label201);
            this.gpSimple2072GAMMA.Controls.Add(this.btn2072SimpleSendGAMMAFile);
            this.gpSimple2072GAMMA.Controls.Add(this.btnSimple2072CreateGAMMAFile);
            this.gpSimple2072GAMMA.Controls.Add(this.tbSimple2072GAMMAVal);
            this.gpSimple2072GAMMA.Controls.Add(this.btn2072SimpleCalcGAMMASend);
            this.gpSimple2072GAMMA.Controls.Add(this.label205);
            this.gpSimple2072GAMMA.Controls.Add(this.cb2072SimpleGAMMA);
            this.gpSimple2072GAMMA.Location = new System.Drawing.Point(540, 41);
            this.gpSimple2072GAMMA.Name = "gpSimple2072GAMMA";
            this.gpSimple2072GAMMA.Size = new System.Drawing.Size(369, 103);
            this.gpSimple2072GAMMA.TabIndex = 21;
            this.gpSimple2072GAMMA.TabStop = false;
            this.gpSimple2072GAMMA.Text = "GAMMA数据操作";
            // 
            // label201
            // 
            this.label201.AutoSize = true;
            this.label201.Location = new System.Drawing.Point(6, 20);
            this.label201.Name = "label201";
            this.label201.Size = new System.Drawing.Size(11, 12);
            this.label201.TabIndex = 11;
            this.label201.Text = "-";
            // 
            // btn2072SimpleSendGAMMAFile
            // 
            this.btn2072SimpleSendGAMMAFile.Location = new System.Drawing.Point(147, 77);
            this.btn2072SimpleSendGAMMAFile.Name = "btn2072SimpleSendGAMMAFile";
            this.btn2072SimpleSendGAMMAFile.Size = new System.Drawing.Size(100, 23);
            this.btn2072SimpleSendGAMMAFile.TabIndex = 13;
            this.btn2072SimpleSendGAMMAFile.Text = "写入文件";
            this.btn2072SimpleSendGAMMAFile.UseVisualStyleBackColor = true;
            this.btn2072SimpleSendGAMMAFile.Click += new System.EventHandler(this.btn2072SimpleSendGAMMAFile_Click);
            // 
            // btnSimple2072CreateGAMMAFile
            // 
            this.btnSimple2072CreateGAMMAFile.Enabled = false;
            this.btnSimple2072CreateGAMMAFile.Location = new System.Drawing.Point(4, 75);
            this.btnSimple2072CreateGAMMAFile.Name = "btnSimple2072CreateGAMMAFile";
            this.btnSimple2072CreateGAMMAFile.Size = new System.Drawing.Size(64, 23);
            this.btnSimple2072CreateGAMMAFile.TabIndex = 12;
            this.btnSimple2072CreateGAMMAFile.Text = "创建文件";
            this.btnSimple2072CreateGAMMAFile.UseVisualStyleBackColor = true;
            this.btnSimple2072CreateGAMMAFile.Click += new System.EventHandler(this.btnSimple2072CreateGAMMAFile_Click);
            // 
            // tbSimple2072GAMMAVal
            // 
            this.tbSimple2072GAMMAVal.Location = new System.Drawing.Point(128, 50);
            this.tbSimple2072GAMMAVal.Name = "tbSimple2072GAMMAVal";
            this.tbSimple2072GAMMAVal.Size = new System.Drawing.Size(47, 21);
            this.tbSimple2072GAMMAVal.TabIndex = 11;
            this.tbSimple2072GAMMAVal.Text = "2.4";
            // 
            // btn2072SimpleCalcGAMMASend
            // 
            this.btn2072SimpleCalcGAMMASend.Location = new System.Drawing.Point(183, 50);
            this.btn2072SimpleCalcGAMMASend.Name = "btn2072SimpleCalcGAMMASend";
            this.btn2072SimpleCalcGAMMASend.Size = new System.Drawing.Size(64, 23);
            this.btn2072SimpleCalcGAMMASend.TabIndex = 8;
            this.btn2072SimpleCalcGAMMASend.Text = "写入";
            this.btn2072SimpleCalcGAMMASend.UseVisualStyleBackColor = true;
            this.btn2072SimpleCalcGAMMASend.Click += new System.EventHandler(this.btn2072SimpleCalcGAMMASend_Click);
            // 
            // label205
            // 
            this.label205.AutoSize = true;
            this.label205.Location = new System.Drawing.Point(6, 54);
            this.label205.Name = "label205";
            this.label205.Size = new System.Drawing.Size(29, 12);
            this.label205.TabIndex = 3;
            this.label205.Text = "颜色";
            // 
            // cb2072SimpleGAMMA
            // 
            this.cb2072SimpleGAMMA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072SimpleGAMMA.FormattingEnabled = true;
            this.cb2072SimpleGAMMA.Items.AddRange(new object[] {
            "全部",
            "红",
            "绿",
            "蓝"});
            this.cb2072SimpleGAMMA.Location = new System.Drawing.Point(43, 50);
            this.cb2072SimpleGAMMA.Name = "cb2072SimpleGAMMA";
            this.cb2072SimpleGAMMA.Size = new System.Drawing.Size(70, 20);
            this.cb2072SimpleGAMMA.TabIndex = 1;
            // 
            // cb2072Simple5060Hz
            // 
            this.cb2072Simple5060Hz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072Simple5060Hz.FormattingEnabled = true;
            this.cb2072Simple5060Hz.Items.AddRange(new object[] {
            "60Hz",
            "50Hz",
            "3D"});
            this.cb2072Simple5060Hz.Location = new System.Drawing.Point(5, 8);
            this.cb2072Simple5060Hz.Name = "cb2072Simple5060Hz";
            this.cb2072Simple5060Hz.Size = new System.Drawing.Size(65, 20);
            this.cb2072Simple5060Hz.TabIndex = 20;
            this.cb2072Simple5060Hz.SelectedIndexChanged += new System.EventHandler(this.cb2072Simple5060Hz_SelectedIndexChanged);
            // 
            // btn2072Simple_SendAll
            // 
            this.btn2072Simple_SendAll.ForeColor = System.Drawing.Color.Red;
            this.btn2072Simple_SendAll.Location = new System.Drawing.Point(534, 4);
            this.btn2072Simple_SendAll.Name = "btn2072Simple_SendAll";
            this.btn2072Simple_SendAll.Size = new System.Drawing.Size(79, 31);
            this.btn2072Simple_SendAll.TabIndex = 18;
            this.btn2072Simple_SendAll.Tag = "3,22,23";
            this.btn2072Simple_SendAll.Text = "全部发送";
            this.btn2072Simple_SendAll.UseVisualStyleBackColor = true;
            this.btn2072Simple_SendAll.Click += new System.EventHandler(this.btn2072Simple_SendAll_Click);
            // 
            // btn2072Simple_ExportFile
            // 
            this.btn2072Simple_ExportFile.Location = new System.Drawing.Point(309, 4);
            this.btn2072Simple_ExportFile.Name = "btn2072Simple_ExportFile";
            this.btn2072Simple_ExportFile.Size = new System.Drawing.Size(79, 31);
            this.btn2072Simple_ExportFile.TabIndex = 17;
            this.btn2072Simple_ExportFile.Tag = "3,22,23";
            this.btn2072Simple_ExportFile.Text = "导出文件";
            this.btn2072Simple_ExportFile.UseVisualStyleBackColor = true;
            this.btn2072Simple_ExportFile.Click += new System.EventHandler(this.btn2072Simple_ExportFile_Click);
            // 
            // btn2072Simple_ImportFile
            // 
            this.btn2072Simple_ImportFile.ForeColor = System.Drawing.Color.Red;
            this.btn2072Simple_ImportFile.Location = new System.Drawing.Point(98, 4);
            this.btn2072Simple_ImportFile.Name = "btn2072Simple_ImportFile";
            this.btn2072Simple_ImportFile.Size = new System.Drawing.Size(79, 31);
            this.btn2072Simple_ImportFile.TabIndex = 16;
            this.btn2072Simple_ImportFile.Tag = "3,22,23";
            this.btn2072Simple_ImportFile.Text = "导入文件";
            this.btn2072Simple_ImportFile.UseVisualStyleBackColor = true;
            this.btn2072Simple_ImportFile.Click += new System.EventHandler(this.btn2072Simple_ImportFile_Click);
            // 
            // btn2072Simple_ResetValues
            // 
            this.btn2072Simple_ResetValues.Location = new System.Drawing.Point(390, 4);
            this.btn2072Simple_ResetValues.Name = "btn2072Simple_ResetValues";
            this.btn2072Simple_ResetValues.Size = new System.Drawing.Size(141, 31);
            this.btn2072Simple_ResetValues.TabIndex = 14;
            this.btn2072Simple_ResetValues.Tag = "3,22,23";
            this.btn2072Simple_ResetValues.Text = "恢复默认值";
            this.btn2072Simple_ResetValues.UseVisualStyleBackColor = true;
            this.btn2072Simple_ResetValues.Click += new System.EventHandler(this.btn2072Simple_ResetValues_Click);
            // 
            // gP2072Simple13
            // 
            this.gP2072Simple13.Controls.Add(this.btn2072Simple13_All);
            this.gP2072Simple13.Controls.Add(this.label198);
            this.gP2072Simple13.Controls.Add(this.input2072Simple13_B);
            this.gP2072Simple13.Controls.Add(this.btn2072Simple13_B);
            this.gP2072Simple13.Controls.Add(this.label199);
            this.gP2072Simple13.Controls.Add(this.input2072Simple13_G);
            this.gP2072Simple13.Controls.Add(this.btn2072Simple13_G);
            this.gP2072Simple13.Controls.Add(this.label200);
            this.gP2072Simple13.Controls.Add(this.input2072Simple13_R);
            this.gP2072Simple13.Controls.Add(this.btn2072Simple13_R);
            this.gP2072Simple13.Location = new System.Drawing.Point(193, 346);
            this.gP2072Simple13.Name = "gP2072Simple13";
            this.gP2072Simple13.Size = new System.Drawing.Size(189, 132);
            this.gP2072Simple13.TabIndex = 13;
            this.gP2072Simple13.TabStop = false;
            this.gP2072Simple13.Text = "高低灰耦合和跨板色差";
            // 
            // btn2072Simple13_All
            // 
            this.btn2072Simple13_All.Location = new System.Drawing.Point(119, 106);
            this.btn2072Simple13_All.Name = "btn2072Simple13_All";
            this.btn2072Simple13_All.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple13_All.TabIndex = 17;
            this.btn2072Simple13_All.Tag = "";
            this.btn2072Simple13_All.Text = "全部设置";
            this.btn2072Simple13_All.UseVisualStyleBackColor = true;
            this.btn2072Simple13_All.Click += new System.EventHandler(this.btn2072Simple13_All_Click);
            // 
            // label198
            // 
            this.label198.AutoSize = true;
            this.label198.Location = new System.Drawing.Point(15, 85);
            this.label198.Name = "label198";
            this.label198.Size = new System.Drawing.Size(29, 12);
            this.label198.TabIndex = 16;
            this.label198.Text = "蓝色";
            // 
            // input2072Simple13_B
            // 
            this.input2072Simple13_B.Location = new System.Drawing.Point(56, 83);
            this.input2072Simple13_B.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.input2072Simple13_B.Name = "input2072Simple13_B";
            this.input2072Simple13_B.Size = new System.Drawing.Size(57, 21);
            this.input2072Simple13_B.TabIndex = 15;
            // 
            // btn2072Simple13_B
            // 
            this.btn2072Simple13_B.Location = new System.Drawing.Point(119, 80);
            this.btn2072Simple13_B.Name = "btn2072Simple13_B";
            this.btn2072Simple13_B.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple13_B.TabIndex = 14;
            this.btn2072Simple13_B.Tag = "input2072Simple13_B|0C,0,4";
            this.btn2072Simple13_B.Text = "设置";
            this.btn2072Simple13_B.UseVisualStyleBackColor = true;
            this.btn2072Simple13_B.Click += new System.EventHandler(this.btn2072Simple7_Click);
            // 
            // label199
            // 
            this.label199.AutoSize = true;
            this.label199.Location = new System.Drawing.Point(15, 60);
            this.label199.Name = "label199";
            this.label199.Size = new System.Drawing.Size(29, 12);
            this.label199.TabIndex = 13;
            this.label199.Text = "绿色";
            // 
            // input2072Simple13_G
            // 
            this.input2072Simple13_G.Location = new System.Drawing.Point(56, 58);
            this.input2072Simple13_G.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.input2072Simple13_G.Name = "input2072Simple13_G";
            this.input2072Simple13_G.Size = new System.Drawing.Size(57, 21);
            this.input2072Simple13_G.TabIndex = 12;
            // 
            // btn2072Simple13_G
            // 
            this.btn2072Simple13_G.Location = new System.Drawing.Point(119, 56);
            this.btn2072Simple13_G.Name = "btn2072Simple13_G";
            this.btn2072Simple13_G.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple13_G.TabIndex = 11;
            this.btn2072Simple13_G.Tag = "input2072Simple13_G|0B,0,4";
            this.btn2072Simple13_G.Text = "设置";
            this.btn2072Simple13_G.UseVisualStyleBackColor = true;
            this.btn2072Simple13_G.Click += new System.EventHandler(this.btn2072Simple7_Click);
            // 
            // label200
            // 
            this.label200.AutoSize = true;
            this.label200.Location = new System.Drawing.Point(15, 35);
            this.label200.Name = "label200";
            this.label200.Size = new System.Drawing.Size(29, 12);
            this.label200.TabIndex = 10;
            this.label200.Text = "红色";
            // 
            // input2072Simple13_R
            // 
            this.input2072Simple13_R.Location = new System.Drawing.Point(56, 33);
            this.input2072Simple13_R.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.input2072Simple13_R.Name = "input2072Simple13_R";
            this.input2072Simple13_R.Size = new System.Drawing.Size(57, 21);
            this.input2072Simple13_R.TabIndex = 9;
            // 
            // btn2072Simple13_R
            // 
            this.btn2072Simple13_R.Location = new System.Drawing.Point(119, 32);
            this.btn2072Simple13_R.Name = "btn2072Simple13_R";
            this.btn2072Simple13_R.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple13_R.TabIndex = 8;
            this.btn2072Simple13_R.Tag = "input2072Simple13_R|0A,0,4";
            this.btn2072Simple13_R.Text = "设置";
            this.btn2072Simple13_R.UseVisualStyleBackColor = true;
            this.btn2072Simple13_R.Click += new System.EventHandler(this.btn2072Simple7_Click);
            // 
            // gP2072Simple12
            // 
            this.gP2072Simple12.Controls.Add(this.btn2072Simple12_All);
            this.gP2072Simple12.Controls.Add(this.label195);
            this.gP2072Simple12.Controls.Add(this.input2072Simple12_B);
            this.gP2072Simple12.Controls.Add(this.btn2072Simple12_B);
            this.gP2072Simple12.Controls.Add(this.label196);
            this.gP2072Simple12.Controls.Add(this.input2072Simple12_G);
            this.gP2072Simple12.Controls.Add(this.btn2072Simple12_G);
            this.gP2072Simple12.Controls.Add(this.label197);
            this.gP2072Simple12.Controls.Add(this.input2072Simple12_R);
            this.gP2072Simple12.Controls.Add(this.btn2072Simple12_R);
            this.gP2072Simple12.Location = new System.Drawing.Point(2, 346);
            this.gP2072Simple12.Name = "gP2072Simple12";
            this.gP2072Simple12.Size = new System.Drawing.Size(189, 132);
            this.gP2072Simple12.TabIndex = 12;
            this.gP2072Simple12.TabStop = false;
            this.gP2072Simple12.Text = "电流增益调节";
            // 
            // btn2072Simple12_All
            // 
            this.btn2072Simple12_All.Location = new System.Drawing.Point(119, 106);
            this.btn2072Simple12_All.Name = "btn2072Simple12_All";
            this.btn2072Simple12_All.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple12_All.TabIndex = 17;
            this.btn2072Simple12_All.Tag = "";
            this.btn2072Simple12_All.Text = "全部设置";
            this.btn2072Simple12_All.UseVisualStyleBackColor = true;
            this.btn2072Simple12_All.Click += new System.EventHandler(this.btn2072Simple12_All_Click);
            // 
            // label195
            // 
            this.label195.AutoSize = true;
            this.label195.Location = new System.Drawing.Point(15, 85);
            this.label195.Name = "label195";
            this.label195.Size = new System.Drawing.Size(29, 12);
            this.label195.TabIndex = 16;
            this.label195.Text = "蓝色";
            // 
            // input2072Simple12_B
            // 
            this.input2072Simple12_B.Location = new System.Drawing.Point(56, 83);
            this.input2072Simple12_B.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.input2072Simple12_B.Name = "input2072Simple12_B";
            this.input2072Simple12_B.Size = new System.Drawing.Size(57, 21);
            this.input2072Simple12_B.TabIndex = 15;
            // 
            // btn2072Simple12_B
            // 
            this.btn2072Simple12_B.Location = new System.Drawing.Point(119, 80);
            this.btn2072Simple12_B.Name = "btn2072Simple12_B";
            this.btn2072Simple12_B.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple12_B.TabIndex = 14;
            this.btn2072Simple12_B.Tag = "input2072Simple12_B|0C,24,31";
            this.btn2072Simple12_B.Text = "设置";
            this.btn2072Simple12_B.UseVisualStyleBackColor = true;
            this.btn2072Simple12_B.Click += new System.EventHandler(this.btn2072Simple7_Click);
            // 
            // label196
            // 
            this.label196.AutoSize = true;
            this.label196.Location = new System.Drawing.Point(15, 60);
            this.label196.Name = "label196";
            this.label196.Size = new System.Drawing.Size(29, 12);
            this.label196.TabIndex = 13;
            this.label196.Text = "绿色";
            // 
            // input2072Simple12_G
            // 
            this.input2072Simple12_G.Location = new System.Drawing.Point(56, 58);
            this.input2072Simple12_G.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.input2072Simple12_G.Name = "input2072Simple12_G";
            this.input2072Simple12_G.Size = new System.Drawing.Size(57, 21);
            this.input2072Simple12_G.TabIndex = 12;
            // 
            // btn2072Simple12_G
            // 
            this.btn2072Simple12_G.Location = new System.Drawing.Point(119, 56);
            this.btn2072Simple12_G.Name = "btn2072Simple12_G";
            this.btn2072Simple12_G.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple12_G.TabIndex = 11;
            this.btn2072Simple12_G.Tag = "input2072Simple12_G|0B,24,31";
            this.btn2072Simple12_G.Text = "设置";
            this.btn2072Simple12_G.UseVisualStyleBackColor = true;
            this.btn2072Simple12_G.Click += new System.EventHandler(this.btn2072Simple7_Click);
            // 
            // label197
            // 
            this.label197.AutoSize = true;
            this.label197.Location = new System.Drawing.Point(15, 35);
            this.label197.Name = "label197";
            this.label197.Size = new System.Drawing.Size(29, 12);
            this.label197.TabIndex = 10;
            this.label197.Text = "红色";
            // 
            // input2072Simple12_R
            // 
            this.input2072Simple12_R.Location = new System.Drawing.Point(56, 33);
            this.input2072Simple12_R.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.input2072Simple12_R.Name = "input2072Simple12_R";
            this.input2072Simple12_R.Size = new System.Drawing.Size(57, 21);
            this.input2072Simple12_R.TabIndex = 9;
            // 
            // btn2072Simple12_R
            // 
            this.btn2072Simple12_R.Location = new System.Drawing.Point(119, 32);
            this.btn2072Simple12_R.Name = "btn2072Simple12_R";
            this.btn2072Simple12_R.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple12_R.TabIndex = 8;
            this.btn2072Simple12_R.Tag = "input2072Simple12_R|0A,24,31";
            this.btn2072Simple12_R.Text = "设置";
            this.btn2072Simple12_R.UseVisualStyleBackColor = true;
            this.btn2072Simple12_R.Click += new System.EventHandler(this.btn2072Simple7_Click);
            // 
            // gP2072Simple11
            // 
            this.gP2072Simple11.Controls.Add(this.btn2072Simple11_All);
            this.gP2072Simple11.Controls.Add(this.label192);
            this.gP2072Simple11.Controls.Add(this.input2072Simple11_B);
            this.gP2072Simple11.Controls.Add(this.btn2072Simple11_B);
            this.gP2072Simple11.Controls.Add(this.label193);
            this.gP2072Simple11.Controls.Add(this.input2072Simple11_G);
            this.gP2072Simple11.Controls.Add(this.btn2072Simple11_G);
            this.gP2072Simple11.Controls.Add(this.label194);
            this.gP2072Simple11.Controls.Add(this.input2072Simple11_R);
            this.gP2072Simple11.Controls.Add(this.btn2072Simple11_R);
            this.gP2072Simple11.Location = new System.Drawing.Point(391, 346);
            this.gP2072Simple11.Name = "gP2072Simple11";
            this.gP2072Simple11.Size = new System.Drawing.Size(189, 132);
            this.gP2072Simple11.TabIndex = 11;
            this.gP2072Simple11.TabStop = false;
            this.gP2072Simple11.Text = "灰度和白平衡调节3";
            // 
            // btn2072Simple11_All
            // 
            this.btn2072Simple11_All.Location = new System.Drawing.Point(119, 106);
            this.btn2072Simple11_All.Name = "btn2072Simple11_All";
            this.btn2072Simple11_All.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple11_All.TabIndex = 17;
            this.btn2072Simple11_All.Tag = "";
            this.btn2072Simple11_All.Text = "全部设置";
            this.btn2072Simple11_All.UseVisualStyleBackColor = true;
            this.btn2072Simple11_All.Click += new System.EventHandler(this.btn2072Simple11_All_Click);
            // 
            // label192
            // 
            this.label192.AutoSize = true;
            this.label192.Location = new System.Drawing.Point(15, 85);
            this.label192.Name = "label192";
            this.label192.Size = new System.Drawing.Size(29, 12);
            this.label192.TabIndex = 16;
            this.label192.Text = "蓝色";
            // 
            // input2072Simple11_B
            // 
            this.input2072Simple11_B.Location = new System.Drawing.Point(56, 83);
            this.input2072Simple11_B.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.input2072Simple11_B.Name = "input2072Simple11_B";
            this.input2072Simple11_B.Size = new System.Drawing.Size(57, 21);
            this.input2072Simple11_B.TabIndex = 15;
            // 
            // btn2072Simple11_B
            // 
            this.btn2072Simple11_B.Location = new System.Drawing.Point(119, 80);
            this.btn2072Simple11_B.Name = "btn2072Simple11_B";
            this.btn2072Simple11_B.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple11_B.TabIndex = 14;
            this.btn2072Simple11_B.Tag = "input2072Simple11_B|0C,16,20";
            this.btn2072Simple11_B.Text = "设置";
            this.btn2072Simple11_B.UseVisualStyleBackColor = true;
            this.btn2072Simple11_B.Click += new System.EventHandler(this.btn2072Simple7_Click);
            // 
            // label193
            // 
            this.label193.AutoSize = true;
            this.label193.Location = new System.Drawing.Point(15, 60);
            this.label193.Name = "label193";
            this.label193.Size = new System.Drawing.Size(29, 12);
            this.label193.TabIndex = 13;
            this.label193.Text = "绿色";
            // 
            // input2072Simple11_G
            // 
            this.input2072Simple11_G.Location = new System.Drawing.Point(56, 58);
            this.input2072Simple11_G.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.input2072Simple11_G.Name = "input2072Simple11_G";
            this.input2072Simple11_G.Size = new System.Drawing.Size(57, 21);
            this.input2072Simple11_G.TabIndex = 12;
            // 
            // btn2072Simple11_G
            // 
            this.btn2072Simple11_G.Location = new System.Drawing.Point(119, 56);
            this.btn2072Simple11_G.Name = "btn2072Simple11_G";
            this.btn2072Simple11_G.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple11_G.TabIndex = 11;
            this.btn2072Simple11_G.Tag = "input2072Simple11_G|0B,16,20";
            this.btn2072Simple11_G.Text = "设置";
            this.btn2072Simple11_G.UseVisualStyleBackColor = true;
            this.btn2072Simple11_G.Click += new System.EventHandler(this.btn2072Simple7_Click);
            // 
            // label194
            // 
            this.label194.AutoSize = true;
            this.label194.Location = new System.Drawing.Point(15, 35);
            this.label194.Name = "label194";
            this.label194.Size = new System.Drawing.Size(29, 12);
            this.label194.TabIndex = 10;
            this.label194.Text = "红色";
            // 
            // input2072Simple11_R
            // 
            this.input2072Simple11_R.Location = new System.Drawing.Point(56, 33);
            this.input2072Simple11_R.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.input2072Simple11_R.Name = "input2072Simple11_R";
            this.input2072Simple11_R.Size = new System.Drawing.Size(57, 21);
            this.input2072Simple11_R.TabIndex = 9;
            // 
            // btn2072Simple11_R
            // 
            this.btn2072Simple11_R.Location = new System.Drawing.Point(119, 32);
            this.btn2072Simple11_R.Name = "btn2072Simple11_R";
            this.btn2072Simple11_R.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple11_R.TabIndex = 8;
            this.btn2072Simple11_R.Tag = "input2072Simple11_R|0A,16,20";
            this.btn2072Simple11_R.Text = "设置";
            this.btn2072Simple11_R.UseVisualStyleBackColor = true;
            this.btn2072Simple11_R.Click += new System.EventHandler(this.btn2072Simple7_Click);
            // 
            // gP2072Simple10
            // 
            this.gP2072Simple10.Controls.Add(this.btn2072Simple10_All);
            this.gP2072Simple10.Controls.Add(this.label189);
            this.gP2072Simple10.Controls.Add(this.input2072Simple10_B);
            this.gP2072Simple10.Controls.Add(this.btn2072Simple10_B);
            this.gP2072Simple10.Controls.Add(this.label190);
            this.gP2072Simple10.Controls.Add(this.input2072Simple10_G);
            this.gP2072Simple10.Controls.Add(this.btn2072Simple10_G);
            this.gP2072Simple10.Controls.Add(this.label191);
            this.gP2072Simple10.Controls.Add(this.input2072Simple10_R);
            this.gP2072Simple10.Controls.Add(this.btn2072Simple10_R);
            this.gP2072Simple10.Location = new System.Drawing.Point(391, 209);
            this.gP2072Simple10.Name = "gP2072Simple10";
            this.gP2072Simple10.Size = new System.Drawing.Size(189, 132);
            this.gP2072Simple10.TabIndex = 10;
            this.gP2072Simple10.TabStop = false;
            this.gP2072Simple10.Text = "灰度和白平衡调节2";
            // 
            // btn2072Simple10_All
            // 
            this.btn2072Simple10_All.Location = new System.Drawing.Point(119, 105);
            this.btn2072Simple10_All.Name = "btn2072Simple10_All";
            this.btn2072Simple10_All.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple10_All.TabIndex = 17;
            this.btn2072Simple10_All.Tag = "";
            this.btn2072Simple10_All.Text = "全部设置";
            this.btn2072Simple10_All.UseVisualStyleBackColor = true;
            this.btn2072Simple10_All.Click += new System.EventHandler(this.btn2072Simple10_All_Click);
            // 
            // label189
            // 
            this.label189.AutoSize = true;
            this.label189.Location = new System.Drawing.Point(15, 81);
            this.label189.Name = "label189";
            this.label189.Size = new System.Drawing.Size(29, 12);
            this.label189.TabIndex = 16;
            this.label189.Text = "蓝色";
            // 
            // input2072Simple10_B
            // 
            this.input2072Simple10_B.Location = new System.Drawing.Point(56, 77);
            this.input2072Simple10_B.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.input2072Simple10_B.Name = "input2072Simple10_B";
            this.input2072Simple10_B.Size = new System.Drawing.Size(57, 21);
            this.input2072Simple10_B.TabIndex = 15;
            // 
            // btn2072Simple10_B
            // 
            this.btn2072Simple10_B.Location = new System.Drawing.Point(119, 76);
            this.btn2072Simple10_B.Name = "btn2072Simple10_B";
            this.btn2072Simple10_B.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple10_B.TabIndex = 14;
            this.btn2072Simple10_B.Tag = "input2072Simple10_B|9,0,7";
            this.btn2072Simple10_B.Text = "设置";
            this.btn2072Simple10_B.UseVisualStyleBackColor = true;
            this.btn2072Simple10_B.Click += new System.EventHandler(this.btn2072Simple7_Click);
            // 
            // label190
            // 
            this.label190.AutoSize = true;
            this.label190.Location = new System.Drawing.Point(15, 52);
            this.label190.Name = "label190";
            this.label190.Size = new System.Drawing.Size(29, 12);
            this.label190.TabIndex = 13;
            this.label190.Text = "绿色";
            // 
            // input2072Simple10_G
            // 
            this.input2072Simple10_G.Location = new System.Drawing.Point(56, 48);
            this.input2072Simple10_G.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.input2072Simple10_G.Name = "input2072Simple10_G";
            this.input2072Simple10_G.Size = new System.Drawing.Size(57, 21);
            this.input2072Simple10_G.TabIndex = 12;
            // 
            // btn2072Simple10_G
            // 
            this.btn2072Simple10_G.Location = new System.Drawing.Point(119, 47);
            this.btn2072Simple10_G.Name = "btn2072Simple10_G";
            this.btn2072Simple10_G.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple10_G.TabIndex = 11;
            this.btn2072Simple10_G.Tag = "input2072Simple10_G|9,8,15";
            this.btn2072Simple10_G.Text = "设置";
            this.btn2072Simple10_G.UseVisualStyleBackColor = true;
            this.btn2072Simple10_G.Click += new System.EventHandler(this.btn2072Simple7_Click);
            // 
            // label191
            // 
            this.label191.AutoSize = true;
            this.label191.Location = new System.Drawing.Point(15, 23);
            this.label191.Name = "label191";
            this.label191.Size = new System.Drawing.Size(29, 12);
            this.label191.TabIndex = 10;
            this.label191.Text = "红色";
            // 
            // input2072Simple10_R
            // 
            this.input2072Simple10_R.Location = new System.Drawing.Point(56, 19);
            this.input2072Simple10_R.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.input2072Simple10_R.Name = "input2072Simple10_R";
            this.input2072Simple10_R.Size = new System.Drawing.Size(57, 21);
            this.input2072Simple10_R.TabIndex = 9;
            // 
            // btn2072Simple10_R
            // 
            this.btn2072Simple10_R.Location = new System.Drawing.Point(119, 18);
            this.btn2072Simple10_R.Name = "btn2072Simple10_R";
            this.btn2072Simple10_R.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple10_R.TabIndex = 8;
            this.btn2072Simple10_R.Tag = "input2072Simple10_R|9,16,23";
            this.btn2072Simple10_R.Text = "设置";
            this.btn2072Simple10_R.UseVisualStyleBackColor = true;
            this.btn2072Simple10_R.Click += new System.EventHandler(this.btn2072Simple7_Click);
            // 
            // gP2072Simple9
            // 
            this.gP2072Simple9.Controls.Add(this.btn2072Simple9_All);
            this.gP2072Simple9.Controls.Add(this.label186);
            this.gP2072Simple9.Controls.Add(this.input2072Simple9_B);
            this.gP2072Simple9.Controls.Add(this.btn2072Simple9_B);
            this.gP2072Simple9.Controls.Add(this.label187);
            this.gP2072Simple9.Controls.Add(this.input2072Simple9_G);
            this.gP2072Simple9.Controls.Add(this.btn2072Simple9_G);
            this.gP2072Simple9.Controls.Add(this.label188);
            this.gP2072Simple9.Controls.Add(this.input2072Simple9_R);
            this.gP2072Simple9.Controls.Add(this.btn2072Simple9_R);
            this.gP2072Simple9.Location = new System.Drawing.Point(193, 209);
            this.gP2072Simple9.Name = "gP2072Simple9";
            this.gP2072Simple9.Size = new System.Drawing.Size(189, 132);
            this.gP2072Simple9.TabIndex = 9;
            this.gP2072Simple9.TabStop = false;
            this.gP2072Simple9.Text = "灰度和白平衡调节1";
            // 
            // btn2072Simple9_All
            // 
            this.btn2072Simple9_All.Location = new System.Drawing.Point(119, 105);
            this.btn2072Simple9_All.Name = "btn2072Simple9_All";
            this.btn2072Simple9_All.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple9_All.TabIndex = 17;
            this.btn2072Simple9_All.Tag = "";
            this.btn2072Simple9_All.Text = "全部设置";
            this.btn2072Simple9_All.UseVisualStyleBackColor = true;
            this.btn2072Simple9_All.Click += new System.EventHandler(this.btn2072Simple9_All_Click);
            // 
            // label186
            // 
            this.label186.AutoSize = true;
            this.label186.Location = new System.Drawing.Point(15, 81);
            this.label186.Name = "label186";
            this.label186.Size = new System.Drawing.Size(29, 12);
            this.label186.TabIndex = 16;
            this.label186.Text = "蓝色";
            // 
            // input2072Simple9_B
            // 
            this.input2072Simple9_B.Location = new System.Drawing.Point(56, 77);
            this.input2072Simple9_B.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.input2072Simple9_B.Name = "input2072Simple9_B";
            this.input2072Simple9_B.Size = new System.Drawing.Size(57, 21);
            this.input2072Simple9_B.TabIndex = 15;
            // 
            // btn2072Simple9_B
            // 
            this.btn2072Simple9_B.Location = new System.Drawing.Point(119, 76);
            this.btn2072Simple9_B.Name = "btn2072Simple9_B";
            this.btn2072Simple9_B.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple9_B.TabIndex = 14;
            this.btn2072Simple9_B.Tag = "input2072Simple9_B|9,24,25";
            this.btn2072Simple9_B.Text = "设置";
            this.btn2072Simple9_B.UseVisualStyleBackColor = true;
            this.btn2072Simple9_B.Click += new System.EventHandler(this.btn2072Simple7_Click);
            // 
            // label187
            // 
            this.label187.AutoSize = true;
            this.label187.Location = new System.Drawing.Point(15, 52);
            this.label187.Name = "label187";
            this.label187.Size = new System.Drawing.Size(29, 12);
            this.label187.TabIndex = 13;
            this.label187.Text = "绿色";
            // 
            // input2072Simple9_G
            // 
            this.input2072Simple9_G.Location = new System.Drawing.Point(56, 48);
            this.input2072Simple9_G.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.input2072Simple9_G.Name = "input2072Simple9_G";
            this.input2072Simple9_G.Size = new System.Drawing.Size(57, 21);
            this.input2072Simple9_G.TabIndex = 12;
            // 
            // btn2072Simple9_G
            // 
            this.btn2072Simple9_G.Location = new System.Drawing.Point(119, 47);
            this.btn2072Simple9_G.Name = "btn2072Simple9_G";
            this.btn2072Simple9_G.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple9_G.TabIndex = 11;
            this.btn2072Simple9_G.Tag = "input2072Simple9_G|9,26,27";
            this.btn2072Simple9_G.Text = "设置";
            this.btn2072Simple9_G.UseVisualStyleBackColor = true;
            this.btn2072Simple9_G.Click += new System.EventHandler(this.btn2072Simple7_Click);
            // 
            // label188
            // 
            this.label188.AutoSize = true;
            this.label188.Location = new System.Drawing.Point(15, 23);
            this.label188.Name = "label188";
            this.label188.Size = new System.Drawing.Size(29, 12);
            this.label188.TabIndex = 10;
            this.label188.Text = "红色";
            // 
            // input2072Simple9_R
            // 
            this.input2072Simple9_R.Location = new System.Drawing.Point(56, 19);
            this.input2072Simple9_R.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.input2072Simple9_R.Name = "input2072Simple9_R";
            this.input2072Simple9_R.Size = new System.Drawing.Size(57, 21);
            this.input2072Simple9_R.TabIndex = 9;
            // 
            // btn2072Simple9_R
            // 
            this.btn2072Simple9_R.Location = new System.Drawing.Point(119, 18);
            this.btn2072Simple9_R.Name = "btn2072Simple9_R";
            this.btn2072Simple9_R.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple9_R.TabIndex = 8;
            this.btn2072Simple9_R.Tag = "input2072Simple9_R|9,28,29";
            this.btn2072Simple9_R.Text = "设置";
            this.btn2072Simple9_R.UseVisualStyleBackColor = true;
            this.btn2072Simple9_R.Click += new System.EventHandler(this.btn2072Simple7_Click);
            // 
            // gP2072Simple8
            // 
            this.gP2072Simple8.Controls.Add(this.btn2072Simple8_All);
            this.gP2072Simple8.Controls.Add(this.label185);
            this.gP2072Simple8.Controls.Add(this.input2072Simple8_B);
            this.gP2072Simple8.Controls.Add(this.btn2072Simple8_B);
            this.gP2072Simple8.Controls.Add(this.label172);
            this.gP2072Simple8.Controls.Add(this.input2072Simple8_G);
            this.gP2072Simple8.Controls.Add(this.btn2072Simple8_G);
            this.gP2072Simple8.Controls.Add(this.label170);
            this.gP2072Simple8.Controls.Add(this.input2072Simple8_R);
            this.gP2072Simple8.Controls.Add(this.btn2072Simple8_R);
            this.gP2072Simple8.Location = new System.Drawing.Point(3, 209);
            this.gP2072Simple8.Name = "gP2072Simple8";
            this.gP2072Simple8.Size = new System.Drawing.Size(189, 132);
            this.gP2072Simple8.TabIndex = 8;
            this.gP2072Simple8.TabStop = false;
            this.gP2072Simple8.Text = "PWM展宽调节";
            // 
            // btn2072Simple8_All
            // 
            this.btn2072Simple8_All.Location = new System.Drawing.Point(118, 105);
            this.btn2072Simple8_All.Name = "btn2072Simple8_All";
            this.btn2072Simple8_All.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple8_All.TabIndex = 17;
            this.btn2072Simple8_All.Tag = "";
            this.btn2072Simple8_All.Text = "全部设置";
            this.btn2072Simple8_All.UseVisualStyleBackColor = true;
            this.btn2072Simple8_All.Click += new System.EventHandler(this.btn2072Simple8_All_Click);
            // 
            // label185
            // 
            this.label185.AutoSize = true;
            this.label185.Location = new System.Drawing.Point(15, 81);
            this.label185.Name = "label185";
            this.label185.Size = new System.Drawing.Size(29, 12);
            this.label185.TabIndex = 16;
            this.label185.Text = "蓝色";
            // 
            // input2072Simple8_B
            // 
            this.input2072Simple8_B.Location = new System.Drawing.Point(56, 77);
            this.input2072Simple8_B.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.input2072Simple8_B.Name = "input2072Simple8_B";
            this.input2072Simple8_B.Size = new System.Drawing.Size(57, 21);
            this.input2072Simple8_B.TabIndex = 15;
            // 
            // btn2072Simple8_B
            // 
            this.btn2072Simple8_B.Location = new System.Drawing.Point(119, 76);
            this.btn2072Simple8_B.Name = "btn2072Simple8_B";
            this.btn2072Simple8_B.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple8_B.TabIndex = 14;
            this.btn2072Simple8_B.Tag = "input2072Simple8_B|6,8,11";
            this.btn2072Simple8_B.Text = "设置";
            this.btn2072Simple8_B.UseVisualStyleBackColor = true;
            this.btn2072Simple8_B.Click += new System.EventHandler(this.btn2072Simple7_Click);
            // 
            // label172
            // 
            this.label172.AutoSize = true;
            this.label172.Location = new System.Drawing.Point(15, 52);
            this.label172.Name = "label172";
            this.label172.Size = new System.Drawing.Size(29, 12);
            this.label172.TabIndex = 13;
            this.label172.Text = "绿色";
            // 
            // input2072Simple8_G
            // 
            this.input2072Simple8_G.Location = new System.Drawing.Point(56, 48);
            this.input2072Simple8_G.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.input2072Simple8_G.Name = "input2072Simple8_G";
            this.input2072Simple8_G.Size = new System.Drawing.Size(57, 21);
            this.input2072Simple8_G.TabIndex = 12;
            // 
            // btn2072Simple8_G
            // 
            this.btn2072Simple8_G.Location = new System.Drawing.Point(119, 47);
            this.btn2072Simple8_G.Name = "btn2072Simple8_G";
            this.btn2072Simple8_G.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple8_G.TabIndex = 11;
            this.btn2072Simple8_G.Tag = "input2072Simple8_G|6,4,7";
            this.btn2072Simple8_G.Text = "设置";
            this.btn2072Simple8_G.UseVisualStyleBackColor = true;
            this.btn2072Simple8_G.Click += new System.EventHandler(this.btn2072Simple7_Click);
            // 
            // label170
            // 
            this.label170.AutoSize = true;
            this.label170.Location = new System.Drawing.Point(15, 23);
            this.label170.Name = "label170";
            this.label170.Size = new System.Drawing.Size(29, 12);
            this.label170.TabIndex = 10;
            this.label170.Text = "红色";
            // 
            // input2072Simple8_R
            // 
            this.input2072Simple8_R.Location = new System.Drawing.Point(56, 19);
            this.input2072Simple8_R.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.input2072Simple8_R.Name = "input2072Simple8_R";
            this.input2072Simple8_R.Size = new System.Drawing.Size(57, 21);
            this.input2072Simple8_R.TabIndex = 9;
            // 
            // btn2072Simple8_R
            // 
            this.btn2072Simple8_R.Location = new System.Drawing.Point(119, 18);
            this.btn2072Simple8_R.Name = "btn2072Simple8_R";
            this.btn2072Simple8_R.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple8_R.TabIndex = 8;
            this.btn2072Simple8_R.Tag = "input2072Simple8_R|6,0,3";
            this.btn2072Simple8_R.Text = "设置";
            this.btn2072Simple8_R.UseVisualStyleBackColor = true;
            this.btn2072Simple8_R.Click += new System.EventHandler(this.btn2072Simple7_Click);
            // 
            // gP2072Simple6
            // 
            this.gP2072Simple6.Controls.Add(this.input2072Simple6);
            this.gP2072Simple6.Controls.Add(this.btn2072Simple6);
            this.gP2072Simple6.Location = new System.Drawing.Point(204, 95);
            this.gP2072Simple6.Name = "gP2072Simple6";
            this.gP2072Simple6.Size = new System.Drawing.Size(170, 49);
            this.gP2072Simple6.TabIndex = 7;
            this.gP2072Simple6.TabStop = false;
            this.gP2072Simple6.Text = "PLL_PRE_DIV";
            // 
            // input2072Simple6
            // 
            this.input2072Simple6.Location = new System.Drawing.Point(6, 18);
            this.input2072Simple6.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.input2072Simple6.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.input2072Simple6.Name = "input2072Simple6";
            this.input2072Simple6.Size = new System.Drawing.Size(75, 21);
            this.input2072Simple6.TabIndex = 9;
            this.input2072Simple6.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btn2072Simple6
            // 
            this.btn2072Simple6.Location = new System.Drawing.Point(87, 17);
            this.btn2072Simple6.Name = "btn2072Simple6";
            this.btn2072Simple6.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple6.TabIndex = 8;
            this.btn2072Simple6.Tag = "input2072Simple6|4,0,4";
            this.btn2072Simple6.Text = "设置";
            this.btn2072Simple6.UseVisualStyleBackColor = true;
            this.btn2072Simple6.Click += new System.EventHandler(this.btn2072Simple7_Click);
            // 
            // gP2072Simple5
            // 
            this.gP2072Simple5.Controls.Add(this.input2072Simple5);
            this.gP2072Simple5.Controls.Add(this.btn2072Simple5);
            this.gP2072Simple5.Location = new System.Drawing.Point(5, 95);
            this.gP2072Simple5.Name = "gP2072Simple5";
            this.gP2072Simple5.Size = new System.Drawing.Size(190, 49);
            this.gP2072Simple5.TabIndex = 6;
            this.gP2072Simple5.TabStop = false;
            this.gP2072Simple5.Text = "PLL_LOOP_DIV";
            // 
            // input2072Simple5
            // 
            this.input2072Simple5.Location = new System.Drawing.Point(6, 18);
            this.input2072Simple5.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.input2072Simple5.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.input2072Simple5.Name = "input2072Simple5";
            this.input2072Simple5.Size = new System.Drawing.Size(75, 21);
            this.input2072Simple5.TabIndex = 9;
            this.input2072Simple5.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn2072Simple5
            // 
            this.btn2072Simple5.Location = new System.Drawing.Point(87, 17);
            this.btn2072Simple5.Name = "btn2072Simple5";
            this.btn2072Simple5.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple5.TabIndex = 8;
            this.btn2072Simple5.Tag = "input2072Simple5|4,8,12";
            this.btn2072Simple5.Text = "设置";
            this.btn2072Simple5.UseVisualStyleBackColor = true;
            this.btn2072Simple5.Click += new System.EventHandler(this.btn2072Simple7_Click);
            // 
            // gP2072Simple4
            // 
            this.gP2072Simple4.Controls.Add(this.input2072Simple4);
            this.gP2072Simple4.Controls.Add(this.btn2072Simple4);
            this.gP2072Simple4.Location = new System.Drawing.Point(198, 147);
            this.gP2072Simple4.Name = "gP2072Simple4";
            this.gP2072Simple4.Size = new System.Drawing.Size(200, 49);
            this.gP2072Simple4.TabIndex = 5;
            this.gP2072Simple4.TabStop = false;
            this.gP2072Simple4.Text = "低灰麻点优化";
            // 
            // input2072Simple4
            // 
            this.input2072Simple4.Location = new System.Drawing.Point(6, 18);
            this.input2072Simple4.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.input2072Simple4.Name = "input2072Simple4";
            this.input2072Simple4.Size = new System.Drawing.Size(75, 21);
            this.input2072Simple4.TabIndex = 9;
            // 
            // btn2072Simple4
            // 
            this.btn2072Simple4.Location = new System.Drawing.Point(87, 17);
            this.btn2072Simple4.Name = "btn2072Simple4";
            this.btn2072Simple4.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple4.TabIndex = 8;
            this.btn2072Simple4.Tag = "input2072Simple4|3,22,23";
            this.btn2072Simple4.Text = "设置";
            this.btn2072Simple4.UseVisualStyleBackColor = true;
            this.btn2072Simple4.Click += new System.EventHandler(this.btn2072Simple7_Click);
            // 
            // gP2072Simple7
            // 
            this.gP2072Simple7.Controls.Add(this.btn2072Simple7_Calc);
            this.gP2072Simple7.Controls.Add(this.input2072Simple7);
            this.gP2072Simple7.Controls.Add(this.btn2072Simple7);
            this.gP2072Simple7.Location = new System.Drawing.Point(3, 41);
            this.gP2072Simple7.Name = "gP2072Simple7";
            this.gP2072Simple7.Size = new System.Drawing.Size(170, 49);
            this.gP2072Simple7.TabIndex = 4;
            this.gP2072Simple7.TabStop = false;
            this.gP2072Simple7.Text = "PWM显示时间";
            // 
            // btn2072Simple7_Calc
            // 
            this.btn2072Simple7_Calc.Location = new System.Drawing.Point(158, 18);
            this.btn2072Simple7_Calc.Name = "btn2072Simple7_Calc";
            this.btn2072Simple7_Calc.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple7_Calc.TabIndex = 10;
            this.btn2072Simple7_Calc.Tag = "";
            this.btn2072Simple7_Calc.Text = "计算";
            this.btn2072Simple7_Calc.UseVisualStyleBackColor = true;
            this.btn2072Simple7_Calc.Visible = false;
            // 
            // input2072Simple7
            // 
            this.input2072Simple7.Location = new System.Drawing.Point(6, 18);
            this.input2072Simple7.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.input2072Simple7.Name = "input2072Simple7";
            this.input2072Simple7.Size = new System.Drawing.Size(75, 21);
            this.input2072Simple7.TabIndex = 9;
            // 
            // btn2072Simple7
            // 
            this.btn2072Simple7.Location = new System.Drawing.Point(89, 18);
            this.btn2072Simple7.Name = "btn2072Simple7";
            this.btn2072Simple7.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple7.TabIndex = 8;
            this.btn2072Simple7.Tag = "input2072Simple7|2,24,31;2,16,23;3,24,31";
            this.btn2072Simple7.Text = "设置";
            this.btn2072Simple7.UseVisualStyleBackColor = true;
            this.btn2072Simple7.Click += new System.EventHandler(this.btn2072Simple7_Click);
            // 
            // gP2072Simple3
            // 
            this.gP2072Simple3.Controls.Add(this.input2072Simple3);
            this.gP2072Simple3.Controls.Add(this.btn2072Simple3);
            this.gP2072Simple3.Location = new System.Drawing.Point(178, 41);
            this.gP2072Simple3.Name = "gP2072Simple3";
            this.gP2072Simple3.Size = new System.Drawing.Size(200, 49);
            this.gP2072Simple3.TabIndex = 3;
            this.gP2072Simple3.TabStop = false;
            this.gP2072Simple3.Text = "行扫";
            // 
            // input2072Simple3
            // 
            this.input2072Simple3.Location = new System.Drawing.Point(6, 18);
            this.input2072Simple3.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.input2072Simple3.Name = "input2072Simple3";
            this.input2072Simple3.Size = new System.Drawing.Size(75, 21);
            this.input2072Simple3.TabIndex = 9;
            // 
            // btn2072Simple3
            // 
            this.btn2072Simple3.Location = new System.Drawing.Point(87, 17);
            this.btn2072Simple3.Name = "btn2072Simple3";
            this.btn2072Simple3.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple3.TabIndex = 8;
            this.btn2072Simple3.Tag = "input2072Simple3|1,0,5";
            this.btn2072Simple3.Text = "设置";
            this.btn2072Simple3.UseVisualStyleBackColor = true;
            this.btn2072Simple3.Click += new System.EventHandler(this.btn2072Simple7_Click);
            // 
            // gP2072Simple2
            // 
            this.gP2072Simple2.BackColor = System.Drawing.Color.LightGray;
            this.gP2072Simple2.Controls.Add(this.btn2072Simple2_Calc);
            this.gP2072Simple2.Controls.Add(this.input2072Simple2);
            this.gP2072Simple2.Controls.Add(this.btn2072Simple2);
            this.gP2072Simple2.Location = new System.Drawing.Point(383, 41);
            this.gP2072Simple2.Name = "gP2072Simple2";
            this.gP2072Simple2.Size = new System.Drawing.Size(152, 49);
            this.gP2072Simple2.TabIndex = 2;
            this.gP2072Simple2.TabStop = false;
            this.gP2072Simple2.Text = "刷新组数";
            // 
            // btn2072Simple2_Calc
            // 
            this.btn2072Simple2_Calc.ForeColor = System.Drawing.Color.Red;
            this.btn2072Simple2_Calc.Location = new System.Drawing.Point(151, 17);
            this.btn2072Simple2_Calc.Name = "btn2072Simple2_Calc";
            this.btn2072Simple2_Calc.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple2_Calc.TabIndex = 10;
            this.btn2072Simple2_Calc.Tag = "";
            this.btn2072Simple2_Calc.Text = "计算";
            this.btn2072Simple2_Calc.UseVisualStyleBackColor = true;
            // 
            // input2072Simple2
            // 
            this.input2072Simple2.Location = new System.Drawing.Point(6, 18);
            this.input2072Simple2.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.input2072Simple2.Name = "input2072Simple2";
            this.input2072Simple2.Size = new System.Drawing.Size(75, 21);
            this.input2072Simple2.TabIndex = 9;
            // 
            // btn2072Simple2
            // 
            this.btn2072Simple2.Location = new System.Drawing.Point(87, 17);
            this.btn2072Simple2.Name = "btn2072Simple2";
            this.btn2072Simple2.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple2.TabIndex = 8;
            this.btn2072Simple2.Tag = "input2072Simple2|1,8,14";
            this.btn2072Simple2.Text = "设置";
            this.btn2072Simple2.UseVisualStyleBackColor = true;
            this.btn2072Simple2.Click += new System.EventHandler(this.btn2072Simple7_Click);
            // 
            // gP2072Simple1
            // 
            this.gP2072Simple1.Controls.Add(this.cb2072Simple1);
            this.gP2072Simple1.Controls.Add(this.btn2072Simple1);
            this.gP2072Simple1.Location = new System.Drawing.Point(3, 147);
            this.gP2072Simple1.Name = "gP2072Simple1";
            this.gP2072Simple1.Size = new System.Drawing.Size(189, 49);
            this.gP2072Simple1.TabIndex = 1;
            this.gP2072Simple1.TabStop = false;
            this.gP2072Simple1.Text = "帧同步/帧间隔";
            // 
            // cb2072Simple1
            // 
            this.cb2072Simple1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072Simple1.FormattingEnabled = true;
            this.cb2072Simple1.Items.AddRange(new object[] {
            "帧同步",
            "帧间隔"});
            this.cb2072Simple1.Location = new System.Drawing.Point(6, 20);
            this.cb2072Simple1.Name = "cb2072Simple1";
            this.cb2072Simple1.Size = new System.Drawing.Size(99, 20);
            this.cb2072Simple1.TabIndex = 9;
            // 
            // btn2072Simple1
            // 
            this.btn2072Simple1.Location = new System.Drawing.Point(111, 18);
            this.btn2072Simple1.Name = "btn2072Simple1";
            this.btn2072Simple1.Size = new System.Drawing.Size(64, 23);
            this.btn2072Simple1.TabIndex = 8;
            this.btn2072Simple1.Tag = "cb2072Simple1|1,19,19";
            this.btn2072Simple1.Text = "设置";
            this.btn2072Simple1.UseVisualStyleBackColor = true;
            this.btn2072Simple1.Click += new System.EventHandler(this.btn2072Simple7_Click);
            // 
            // gp2072FuncTest
            // 
            this.gp2072FuncTest.Controls.Add(this.input2072FuncRegAddr);
            this.gp2072FuncTest.Controls.Add(this.input2072FuncVal);
            this.gp2072FuncTest.Controls.Add(this.btn2072FuncTest);
            this.gp2072FuncTest.Controls.Add(this.label157);
            this.gp2072FuncTest.Controls.Add(this.label153);
            this.gp2072FuncTest.Controls.Add(this.cb2072FuncTest3);
            this.gp2072FuncTest.Controls.Add(this.label152);
            this.gp2072FuncTest.Controls.Add(this.label150);
            this.gp2072FuncTest.Controls.Add(this.cb2072FuncTest2);
            this.gp2072FuncTest.Location = new System.Drawing.Point(408, 144);
            this.gp2072FuncTest.Name = "gp2072FuncTest";
            this.gp2072FuncTest.Size = new System.Drawing.Size(369, 59);
            this.gp2072FuncTest.TabIndex = 0;
            this.gp2072FuncTest.TabStop = false;
            this.gp2072FuncTest.Text = "特殊寄存器设置";
            // 
            // input2072FuncRegAddr
            // 
            this.input2072FuncRegAddr.Location = new System.Drawing.Point(13, 34);
            this.input2072FuncRegAddr.Name = "input2072FuncRegAddr";
            this.input2072FuncRegAddr.Size = new System.Drawing.Size(47, 21);
            this.input2072FuncRegAddr.TabIndex = 12;
            this.input2072FuncRegAddr.Text = "128";
            // 
            // input2072FuncVal
            // 
            this.input2072FuncVal.Location = new System.Drawing.Point(243, 34);
            this.input2072FuncVal.Name = "input2072FuncVal";
            this.input2072FuncVal.Size = new System.Drawing.Size(47, 21);
            this.input2072FuncVal.TabIndex = 11;
            this.input2072FuncVal.Text = "0";
            // 
            // btn2072FuncTest
            // 
            this.btn2072FuncTest.Location = new System.Drawing.Point(296, 32);
            this.btn2072FuncTest.Name = "btn2072FuncTest";
            this.btn2072FuncTest.Size = new System.Drawing.Size(64, 23);
            this.btn2072FuncTest.TabIndex = 8;
            this.btn2072FuncTest.Text = "设置";
            this.btn2072FuncTest.UseVisualStyleBackColor = true;
            this.btn2072FuncTest.Click += new System.EventHandler(this.btn2072FuncTest_Click);
            // 
            // label157
            // 
            this.label157.AutoSize = true;
            this.label157.Location = new System.Drawing.Point(250, 17);
            this.label157.Name = "label157";
            this.label157.Size = new System.Drawing.Size(29, 12);
            this.label157.TabIndex = 7;
            this.label157.Text = "数值";
            // 
            // label153
            // 
            this.label153.AutoSize = true;
            this.label153.Location = new System.Drawing.Point(182, 18);
            this.label153.Name = "label153";
            this.label153.Size = new System.Drawing.Size(41, 12);
            this.label153.TabIndex = 5;
            this.label153.Text = "终止位";
            // 
            // cb2072FuncTest3
            // 
            this.cb2072FuncTest3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072FuncTest3.FormattingEnabled = true;
            this.cb2072FuncTest3.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cb2072FuncTest3.Location = new System.Drawing.Point(181, 34);
            this.cb2072FuncTest3.Name = "cb2072FuncTest3";
            this.cb2072FuncTest3.Size = new System.Drawing.Size(48, 20);
            this.cb2072FuncTest3.TabIndex = 4;
            // 
            // label152
            // 
            this.label152.AutoSize = true;
            this.label152.Location = new System.Drawing.Point(116, 18);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(41, 12);
            this.label152.TabIndex = 3;
            this.label152.Text = "起始位";
            // 
            // label150
            // 
            this.label150.AutoSize = true;
            this.label150.Location = new System.Drawing.Point(6, 18);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(65, 12);
            this.label150.TabIndex = 2;
            this.label150.Text = "寄存器地址";
            // 
            // cb2072FuncTest2
            // 
            this.cb2072FuncTest2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072FuncTest2.FormattingEnabled = true;
            this.cb2072FuncTest2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cb2072FuncTest2.Location = new System.Drawing.Point(118, 34);
            this.cb2072FuncTest2.Name = "cb2072FuncTest2";
            this.cb2072FuncTest2.Size = new System.Drawing.Size(48, 20);
            this.cb2072FuncTest2.TabIndex = 1;
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage7.Controls.Add(this.panel4);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1352, 764);
            this.tabPage7.TabIndex = 3;
            this.tabPage7.Text = "工厂界面";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGray;
            this.panel4.Controls.Add(this.gp2072FactoryRegister);
            this.panel4.Controls.Add(this.cb2072Factory5060Hz);
            this.panel4.Controls.Add(this.btn2072Factory_SendAll);
            this.panel4.Controls.Add(this.btn2072FactoryExport);
            this.panel4.Controls.Add(this.btn2072FactoryImport);
            this.panel4.Controls.Add(this.gp2072Factory_CurrentGain);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1346, 758);
            this.panel4.TabIndex = 1;
            // 
            // gp2072FactoryRegister
            // 
            this.gp2072FactoryRegister.Controls.Add(this.input2072FactoryRegisterAddr);
            this.gp2072FactoryRegister.Controls.Add(this.input2072FactoryRegisterVal);
            this.gp2072FactoryRegister.Controls.Add(this.btn2072FactoryRegisterSet);
            this.gp2072FactoryRegister.Controls.Add(this.lb2072FactoryRegister4);
            this.gp2072FactoryRegister.Controls.Add(this.lb2072FactoryRegister3);
            this.gp2072FactoryRegister.Controls.Add(this.cb2072FactoryRegister_EndBit);
            this.gp2072FactoryRegister.Controls.Add(this.lb2072FactoryRegister2);
            this.gp2072FactoryRegister.Controls.Add(this.lb2072FactoryRegister1);
            this.gp2072FactoryRegister.Controls.Add(this.cb2072FactoryRegister_StartBit);
            this.gp2072FactoryRegister.Location = new System.Drawing.Point(135, 52);
            this.gp2072FactoryRegister.Name = "gp2072FactoryRegister";
            this.gp2072FactoryRegister.Size = new System.Drawing.Size(374, 73);
            this.gp2072FactoryRegister.TabIndex = 465;
            this.gp2072FactoryRegister.TabStop = false;
            this.gp2072FactoryRegister.Text = "特殊寄存器设置";
            // 
            // input2072FactoryRegisterAddr
            // 
            this.input2072FactoryRegisterAddr.Location = new System.Drawing.Point(4, 37);
            this.input2072FactoryRegisterAddr.Name = "input2072FactoryRegisterAddr";
            this.input2072FactoryRegisterAddr.Size = new System.Drawing.Size(61, 21);
            this.input2072FactoryRegisterAddr.TabIndex = 12;
            this.input2072FactoryRegisterAddr.Text = "128";
            // 
            // input2072FactoryRegisterVal
            // 
            this.input2072FactoryRegisterVal.Location = new System.Drawing.Point(245, 35);
            this.input2072FactoryRegisterVal.Name = "input2072FactoryRegisterVal";
            this.input2072FactoryRegisterVal.Size = new System.Drawing.Size(47, 21);
            this.input2072FactoryRegisterVal.TabIndex = 11;
            this.input2072FactoryRegisterVal.Text = "0";
            // 
            // btn2072FactoryRegisterSet
            // 
            this.btn2072FactoryRegisterSet.Location = new System.Drawing.Point(304, 33);
            this.btn2072FactoryRegisterSet.Name = "btn2072FactoryRegisterSet";
            this.btn2072FactoryRegisterSet.Size = new System.Drawing.Size(54, 23);
            this.btn2072FactoryRegisterSet.TabIndex = 8;
            this.btn2072FactoryRegisterSet.Text = "设置";
            this.btn2072FactoryRegisterSet.UseVisualStyleBackColor = true;
            this.btn2072FactoryRegisterSet.Click += new System.EventHandler(this.btn2072FactoryRegisterSet_Click);
            // 
            // lb2072FactoryRegister4
            // 
            this.lb2072FactoryRegister4.AutoSize = true;
            this.lb2072FactoryRegister4.Location = new System.Drawing.Point(245, 21);
            this.lb2072FactoryRegister4.Name = "lb2072FactoryRegister4";
            this.lb2072FactoryRegister4.Size = new System.Drawing.Size(29, 12);
            this.lb2072FactoryRegister4.TabIndex = 7;
            this.lb2072FactoryRegister4.Text = "数据";
            // 
            // lb2072FactoryRegister3
            // 
            this.lb2072FactoryRegister3.AutoSize = true;
            this.lb2072FactoryRegister3.Location = new System.Drawing.Point(180, 21);
            this.lb2072FactoryRegister3.Name = "lb2072FactoryRegister3";
            this.lb2072FactoryRegister3.Size = new System.Drawing.Size(41, 12);
            this.lb2072FactoryRegister3.TabIndex = 5;
            this.lb2072FactoryRegister3.Text = "终止位";
            // 
            // cb2072FactoryRegister_EndBit
            // 
            this.cb2072FactoryRegister_EndBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072FactoryRegister_EndBit.FormattingEnabled = true;
            this.cb2072FactoryRegister_EndBit.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cb2072FactoryRegister_EndBit.Location = new System.Drawing.Point(180, 36);
            this.cb2072FactoryRegister_EndBit.Name = "cb2072FactoryRegister_EndBit";
            this.cb2072FactoryRegister_EndBit.Size = new System.Drawing.Size(48, 20);
            this.cb2072FactoryRegister_EndBit.TabIndex = 4;
            // 
            // lb2072FactoryRegister2
            // 
            this.lb2072FactoryRegister2.AutoSize = true;
            this.lb2072FactoryRegister2.Location = new System.Drawing.Point(109, 21);
            this.lb2072FactoryRegister2.Name = "lb2072FactoryRegister2";
            this.lb2072FactoryRegister2.Size = new System.Drawing.Size(41, 12);
            this.lb2072FactoryRegister2.TabIndex = 3;
            this.lb2072FactoryRegister2.Text = "起始位";
            // 
            // lb2072FactoryRegister1
            // 
            this.lb2072FactoryRegister1.AutoSize = true;
            this.lb2072FactoryRegister1.Location = new System.Drawing.Point(4, 21);
            this.lb2072FactoryRegister1.Name = "lb2072FactoryRegister1";
            this.lb2072FactoryRegister1.Size = new System.Drawing.Size(65, 12);
            this.lb2072FactoryRegister1.TabIndex = 2;
            this.lb2072FactoryRegister1.Text = "寄存器地址";
            // 
            // cb2072FactoryRegister_StartBit
            // 
            this.cb2072FactoryRegister_StartBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072FactoryRegister_StartBit.FormattingEnabled = true;
            this.cb2072FactoryRegister_StartBit.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cb2072FactoryRegister_StartBit.Location = new System.Drawing.Point(108, 36);
            this.cb2072FactoryRegister_StartBit.Name = "cb2072FactoryRegister_StartBit";
            this.cb2072FactoryRegister_StartBit.Size = new System.Drawing.Size(48, 20);
            this.cb2072FactoryRegister_StartBit.TabIndex = 1;
            // 
            // cb2072Factory5060Hz
            // 
            this.cb2072Factory5060Hz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb2072Factory5060Hz.FormattingEnabled = true;
            this.cb2072Factory5060Hz.Items.AddRange(new object[] {
            "60Hz",
            "50Hz",
            "3D"});
            this.cb2072Factory5060Hz.Location = new System.Drawing.Point(5, 8);
            this.cb2072Factory5060Hz.Name = "cb2072Factory5060Hz";
            this.cb2072Factory5060Hz.Size = new System.Drawing.Size(65, 20);
            this.cb2072Factory5060Hz.TabIndex = 464;
            // 
            // btn2072Factory_SendAll
            // 
            this.btn2072Factory_SendAll.ForeColor = System.Drawing.Color.Red;
            this.btn2072Factory_SendAll.Location = new System.Drawing.Point(202, 4);
            this.btn2072Factory_SendAll.Name = "btn2072Factory_SendAll";
            this.btn2072Factory_SendAll.Size = new System.Drawing.Size(79, 31);
            this.btn2072Factory_SendAll.TabIndex = 463;
            this.btn2072Factory_SendAll.Tag = "";
            this.btn2072Factory_SendAll.Text = "全部发送";
            this.btn2072Factory_SendAll.UseVisualStyleBackColor = true;
            this.btn2072Factory_SendAll.Click += new System.EventHandler(this.btn2072Factory_SendAll_Click);
            // 
            // btn2072FactoryExport
            // 
            this.btn2072FactoryExport.Location = new System.Drawing.Point(7, 184);
            this.btn2072FactoryExport.Name = "btn2072FactoryExport";
            this.btn2072FactoryExport.Size = new System.Drawing.Size(79, 31);
            this.btn2072FactoryExport.TabIndex = 462;
            this.btn2072FactoryExport.Tag = "";
            this.btn2072FactoryExport.Text = "导出文件";
            this.btn2072FactoryExport.UseVisualStyleBackColor = true;
            // 
            // btn2072FactoryImport
            // 
            this.btn2072FactoryImport.ForeColor = System.Drawing.Color.Red;
            this.btn2072FactoryImport.Location = new System.Drawing.Point(98, 4);
            this.btn2072FactoryImport.Name = "btn2072FactoryImport";
            this.btn2072FactoryImport.Size = new System.Drawing.Size(79, 31);
            this.btn2072FactoryImport.TabIndex = 461;
            this.btn2072FactoryImport.Tag = "";
            this.btn2072FactoryImport.Text = "导入文件";
            this.btn2072FactoryImport.UseVisualStyleBackColor = true;
            this.btn2072FactoryImport.Click += new System.EventHandler(this.btn2072FactoryImport_Click);
            // 
            // gp2072Factory_CurrentGain
            // 
            this.gp2072Factory_CurrentGain.Controls.Add(this.btnSet2072FactoryCurrentGain_All);
            this.gp2072Factory_CurrentGain.Controls.Add(this.label24);
            this.gp2072Factory_CurrentGain.Controls.Add(this.input2072Factory_CurrentGain_B);
            this.gp2072Factory_CurrentGain.Controls.Add(this.btnSet2072FactoryCurrentGain_B);
            this.gp2072Factory_CurrentGain.Controls.Add(this.label25);
            this.gp2072Factory_CurrentGain.Controls.Add(this.input2072Factory_CurrentGain_G);
            this.gp2072Factory_CurrentGain.Controls.Add(this.btnSet2072FactoryCurrentGain_G);
            this.gp2072Factory_CurrentGain.Controls.Add(this.label26);
            this.gp2072Factory_CurrentGain.Controls.Add(this.input2072Factory_CurrentGain_R);
            this.gp2072Factory_CurrentGain.Controls.Add(this.btnSet2072FactoryCurrentGain_R);
            this.gp2072Factory_CurrentGain.Location = new System.Drawing.Point(7, 43);
            this.gp2072Factory_CurrentGain.Name = "gp2072Factory_CurrentGain";
            this.gp2072Factory_CurrentGain.Size = new System.Drawing.Size(122, 132);
            this.gp2072Factory_CurrentGain.TabIndex = 460;
            this.gp2072Factory_CurrentGain.TabStop = false;
            this.gp2072Factory_CurrentGain.Text = "电流增益调节";
            // 
            // btnSet2072FactoryCurrentGain_All
            // 
            this.btnSet2072FactoryCurrentGain_All.Location = new System.Drawing.Point(49, 104);
            this.btnSet2072FactoryCurrentGain_All.Name = "btnSet2072FactoryCurrentGain_All";
            this.btnSet2072FactoryCurrentGain_All.Size = new System.Drawing.Size(64, 23);
            this.btnSet2072FactoryCurrentGain_All.TabIndex = 17;
            this.btnSet2072FactoryCurrentGain_All.Tag = "";
            this.btnSet2072FactoryCurrentGain_All.Text = "全部设置";
            this.btnSet2072FactoryCurrentGain_All.UseVisualStyleBackColor = true;
            this.btnSet2072FactoryCurrentGain_All.Click += new System.EventHandler(this.btnSet2072FactoryCurrentGain_All_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(15, 81);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(29, 12);
            this.label24.TabIndex = 16;
            this.label24.Text = "蓝色";
            // 
            // input2072Factory_CurrentGain_B
            // 
            this.input2072Factory_CurrentGain_B.Location = new System.Drawing.Point(56, 77);
            this.input2072Factory_CurrentGain_B.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.input2072Factory_CurrentGain_B.Name = "input2072Factory_CurrentGain_B";
            this.input2072Factory_CurrentGain_B.Size = new System.Drawing.Size(57, 21);
            this.input2072Factory_CurrentGain_B.TabIndex = 15;
            // 
            // btnSet2072FactoryCurrentGain_B
            // 
            this.btnSet2072FactoryCurrentGain_B.Location = new System.Drawing.Point(119, 76);
            this.btnSet2072FactoryCurrentGain_B.Name = "btnSet2072FactoryCurrentGain_B";
            this.btnSet2072FactoryCurrentGain_B.Size = new System.Drawing.Size(64, 23);
            this.btnSet2072FactoryCurrentGain_B.TabIndex = 14;
            this.btnSet2072FactoryCurrentGain_B.Tag = "input2072Factory_CurrentGain_B|0C,24,31";
            this.btnSet2072FactoryCurrentGain_B.Text = "设置";
            this.btnSet2072FactoryCurrentGain_B.UseVisualStyleBackColor = true;
            this.btnSet2072FactoryCurrentGain_B.Visible = false;
            this.btnSet2072FactoryCurrentGain_B.Click += new System.EventHandler(this.btnSet2072FactoryCurrentGain_R_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(15, 52);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(29, 12);
            this.label25.TabIndex = 13;
            this.label25.Text = "绿色";
            // 
            // input2072Factory_CurrentGain_G
            // 
            this.input2072Factory_CurrentGain_G.Location = new System.Drawing.Point(56, 48);
            this.input2072Factory_CurrentGain_G.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.input2072Factory_CurrentGain_G.Name = "input2072Factory_CurrentGain_G";
            this.input2072Factory_CurrentGain_G.Size = new System.Drawing.Size(57, 21);
            this.input2072Factory_CurrentGain_G.TabIndex = 12;
            // 
            // btnSet2072FactoryCurrentGain_G
            // 
            this.btnSet2072FactoryCurrentGain_G.Location = new System.Drawing.Point(119, 47);
            this.btnSet2072FactoryCurrentGain_G.Name = "btnSet2072FactoryCurrentGain_G";
            this.btnSet2072FactoryCurrentGain_G.Size = new System.Drawing.Size(64, 23);
            this.btnSet2072FactoryCurrentGain_G.TabIndex = 11;
            this.btnSet2072FactoryCurrentGain_G.Tag = "input2072Factory_CurrentGain_G|0B,24,31";
            this.btnSet2072FactoryCurrentGain_G.Text = "设置";
            this.btnSet2072FactoryCurrentGain_G.UseVisualStyleBackColor = true;
            this.btnSet2072FactoryCurrentGain_G.Visible = false;
            this.btnSet2072FactoryCurrentGain_G.Click += new System.EventHandler(this.btnSet2072FactoryCurrentGain_R_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(15, 23);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(29, 12);
            this.label26.TabIndex = 10;
            this.label26.Text = "红色";
            // 
            // input2072Factory_CurrentGain_R
            // 
            this.input2072Factory_CurrentGain_R.Location = new System.Drawing.Point(56, 19);
            this.input2072Factory_CurrentGain_R.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.input2072Factory_CurrentGain_R.Name = "input2072Factory_CurrentGain_R";
            this.input2072Factory_CurrentGain_R.Size = new System.Drawing.Size(57, 21);
            this.input2072Factory_CurrentGain_R.TabIndex = 9;
            // 
            // btnSet2072FactoryCurrentGain_R
            // 
            this.btnSet2072FactoryCurrentGain_R.Location = new System.Drawing.Point(119, 18);
            this.btnSet2072FactoryCurrentGain_R.Name = "btnSet2072FactoryCurrentGain_R";
            this.btnSet2072FactoryCurrentGain_R.Size = new System.Drawing.Size(64, 23);
            this.btnSet2072FactoryCurrentGain_R.TabIndex = 8;
            this.btnSet2072FactoryCurrentGain_R.Tag = "input2072Factory_CurrentGain_R|0A,24,31";
            this.btnSet2072FactoryCurrentGain_R.Text = "设置";
            this.btnSet2072FactoryCurrentGain_R.UseVisualStyleBackColor = true;
            this.btnSet2072FactoryCurrentGain_R.Visible = false;
            this.btnSet2072FactoryCurrentGain_R.Click += new System.EventHandler(this.btnSet2072FactoryCurrentGain_R_Click);
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.button17);
            this.tabPage8.Controls.Add(this.label74);
            this.tabPage8.Controls.Add(this.label69);
            this.tabPage8.Controls.Add(this.groupBox16);
            this.tabPage8.Controls.Add(this.button9);
            this.tabPage8.Controls.Add(this.rtRead);
            this.tabPage8.Controls.Add(this.button8);
            this.tabPage8.Controls.Add(this.button7);
            this.tabPage8.Controls.Add(this.rt2072);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1310, 764);
            this.tabPage8.TabIndex = 4;
            this.tabPage8.Text = "工程师界面";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(759, 28);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(75, 23);
            this.button17.TabIndex = 454;
            this.button17.Text = "读取";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(6, 322);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(47, 12);
            this.label74.TabIndex = 453;
            this.label74.Text = "发送区2";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(6, 13);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(47, 12);
            this.label69.TabIndex = 452;
            this.label69.Text = "发送区1";
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.btnGainAll);
            this.groupBox16.Controls.Add(this.label28);
            this.groupBox16.Controls.Add(this.numGainB);
            this.groupBox16.Controls.Add(this.btnGainB);
            this.groupBox16.Controls.Add(this.label29);
            this.groupBox16.Controls.Add(this.numGainG);
            this.groupBox16.Controls.Add(this.btnGainG);
            this.groupBox16.Controls.Add(this.label30);
            this.groupBox16.Controls.Add(this.numGainR);
            this.groupBox16.Controls.Add(this.btnGainR);
            this.groupBox16.Location = new System.Drawing.Point(6, 572);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(260, 120);
            this.groupBox16.TabIndex = 451;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "电流增益调节";
            // 
            // btnGainAll
            // 
            this.btnGainAll.Location = new System.Drawing.Point(189, 30);
            this.btnGainAll.Name = "btnGainAll";
            this.btnGainAll.Size = new System.Drawing.Size(64, 23);
            this.btnGainAll.TabIndex = 17;
            this.btnGainAll.Tag = "";
            this.btnGainAll.Text = "全部设置";
            this.btnGainAll.UseVisualStyleBackColor = true;
            this.btnGainAll.Click += new System.EventHandler(this.btnGainAll_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(15, 85);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(29, 12);
            this.label28.TabIndex = 16;
            this.label28.Text = "蓝色";
            // 
            // numGainB
            // 
            this.numGainB.Location = new System.Drawing.Point(56, 83);
            this.numGainB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numGainB.Name = "numGainB";
            this.numGainB.Size = new System.Drawing.Size(57, 21);
            this.numGainB.TabIndex = 15;
            // 
            // btnGainB
            // 
            this.btnGainB.Location = new System.Drawing.Point(119, 80);
            this.btnGainB.Name = "btnGainB";
            this.btnGainB.Size = new System.Drawing.Size(64, 23);
            this.btnGainB.TabIndex = 14;
            this.btnGainB.Tag = "input2072Simple12_B|0C,24,31";
            this.btnGainB.Text = "设置";
            this.btnGainB.UseVisualStyleBackColor = true;
            this.btnGainB.Click += new System.EventHandler(this.btnGainB_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(15, 60);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(29, 12);
            this.label29.TabIndex = 13;
            this.label29.Text = "绿色";
            // 
            // numGainG
            // 
            this.numGainG.Location = new System.Drawing.Point(56, 58);
            this.numGainG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numGainG.Name = "numGainG";
            this.numGainG.Size = new System.Drawing.Size(57, 21);
            this.numGainG.TabIndex = 12;
            // 
            // btnGainG
            // 
            this.btnGainG.Location = new System.Drawing.Point(119, 56);
            this.btnGainG.Name = "btnGainG";
            this.btnGainG.Size = new System.Drawing.Size(64, 23);
            this.btnGainG.TabIndex = 11;
            this.btnGainG.Tag = "input2072Simple12_G|0B,24,31";
            this.btnGainG.Text = "设置";
            this.btnGainG.UseVisualStyleBackColor = true;
            this.btnGainG.Click += new System.EventHandler(this.btnGainG_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(15, 35);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(29, 12);
            this.label30.TabIndex = 10;
            this.label30.Text = "红色";
            // 
            // numGainR
            // 
            this.numGainR.Location = new System.Drawing.Point(56, 33);
            this.numGainR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numGainR.Name = "numGainR";
            this.numGainR.Size = new System.Drawing.Size(57, 21);
            this.numGainR.TabIndex = 9;
            // 
            // btnGainR
            // 
            this.btnGainR.Location = new System.Drawing.Point(119, 32);
            this.btnGainR.Name = "btnGainR";
            this.btnGainR.Size = new System.Drawing.Size(64, 23);
            this.btnGainR.TabIndex = 8;
            this.btnGainR.Tag = "input2072Simple12_R|0A,24,31";
            this.btnGainR.Text = "设置";
            this.btnGainR.UseVisualStyleBackColor = true;
            this.btnGainR.Click += new System.EventHandler(this.btnGainR_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(759, 366);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 450;
            this.button9.Text = "发送";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // rtRead
            // 
            this.rtRead.Location = new System.Drawing.Point(6, 337);
            this.rtRead.Name = "rtRead";
            this.rtRead.Size = new System.Drawing.Size(747, 229);
            this.rtRead.TabIndex = 449;
            this.rtRead.Text = "";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(759, 337);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 448;
            this.button8.Text = "读取";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.ForeColor = System.Drawing.Color.Black;
            this.button7.Location = new System.Drawing.Point(759, 57);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 447;
            this.button7.Tag = "3,22,23";
            this.button7.Text = "发送";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // rt2072
            // 
            this.rt2072.Location = new System.Drawing.Point(6, 28);
            this.rt2072.Name = "rt2072";
            this.rt2072.Size = new System.Drawing.Size(747, 275);
            this.rt2072.TabIndex = 446;
            this.rt2072.Text = resources.GetString("rt2072.Text");
            // 
            // tabTest
            // 
            this.tabTest.BackColor = System.Drawing.SystemColors.Control;
            this.tabTest.Controls.Add(this.groupBox3);
            this.tabTest.Location = new System.Drawing.Point(4, 22);
            this.tabTest.Name = "tabTest";
            this.tabTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabTest.Size = new System.Drawing.Size(1513, 804);
            this.tabTest.TabIndex = 1;
            this.tabTest.Text = "测试页";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label103);
            this.groupBox3.Controls.Add(this.label36);
            this.groupBox3.Controls.Add(this.tbVol2);
            this.groupBox3.Controls.Add(this.btnSetVol);
            this.groupBox3.Controls.Add(this.tbVol);
            this.groupBox3.Controls.Add(this.button16);
            this.groupBox3.Controls.Add(this.button10);
            this.groupBox3.Controls.Add(this.button11);
            this.groupBox3.Controls.Add(this.groupBox12);
            this.groupBox3.Controls.Add(this.groupBox14);
            this.groupBox3.Controls.Add(this.groupBox13);
            this.groupBox3.Controls.Add(this.groupBox8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cbChipPos);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.gpTest);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1571, 790);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "FLASH操作";
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.Location = new System.Drawing.Point(894, 429);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(47, 12);
            this.label103.TabIndex = 29;
            this.label103.Text = "label36";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(894, 385);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(47, 12);
            this.label36.TabIndex = 29;
            this.label36.Text = "label36";
            // 
            // tbVol2
            // 
            this.tbVol2.AutoSize = false;
            this.tbVol2.Location = new System.Drawing.Point(635, 428);
            this.tbVol2.Maximum = 255;
            this.tbVol2.Name = "tbVol2";
            this.tbVol2.Size = new System.Drawing.Size(259, 30);
            this.tbVol2.TabIndex = 28;
            this.tbVol2.TickFrequency = 10;
            this.tbVol2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbVol2_MouseUp);
            // 
            // btnSetVol
            // 
            this.btnSetVol.Location = new System.Drawing.Point(970, 380);
            this.btnSetVol.Name = "btnSetVol";
            this.btnSetVol.Size = new System.Drawing.Size(75, 23);
            this.btnSetVol.TabIndex = 27;
            this.btnSetVol.Text = "设置";
            this.btnSetVol.UseVisualStyleBackColor = true;
            this.btnSetVol.Click += new System.EventHandler(this.btnSetVol_Click);
            // 
            // tbVol
            // 
            this.tbVol.AutoSize = false;
            this.tbVol.Location = new System.Drawing.Point(635, 380);
            this.tbVol.Maximum = 255;
            this.tbVol.Name = "tbVol";
            this.tbVol.Size = new System.Drawing.Size(259, 30);
            this.tbVol.TabIndex = 26;
            this.tbVol.TickFrequency = 10;
            this.tbVol.Scroll += new System.EventHandler(this.tbVol_Scroll);
            this.tbVol.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbVol_MouseUp);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(635, 180);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(778, 56);
            this.button16.TabIndex = 25;
            this.button16.Text = "Write CAL->SDRAM TO FLASH->READ SDRAM->READ FLASH->COMPARE SDRAM AND FLASH->WRITE" +
    " GAMMA->READ SDRAM->COMPARE SDRAM";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(635, 150);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(291, 23);
            this.button10.TabIndex = 13;
            this.button10.Text = "1.Read SDRAM->SDRAM TO FLASH->Read flash";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(635, 354);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 24;
            this.button11.Text = "button11";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.btnStopBatchWriteCal);
            this.groupBox12.Controls.Add(this.label34);
            this.groupBox12.Controls.Add(this.label33);
            this.groupBox12.Controls.Add(this.numStopRow);
            this.groupBox12.Controls.Add(this.numStartRow);
            this.groupBox12.Controls.Add(this.txtBatchFolder);
            this.groupBox12.Controls.Add(this.txtBatchCalibrationFolder);
            this.groupBox12.Controls.Add(this.label32);
            this.groupBox12.Controls.Add(this.btnBatchWriteCalibration);
            this.groupBox12.Controls.Add(this.btnChoseBatchFolder);
            this.groupBox12.Controls.Add(this.label20);
            this.groupBox12.Controls.Add(this.btnSelectBatchCalibrationFolder);
            this.groupBox12.Location = new System.Drawing.Point(6, 200);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(621, 89);
            this.groupBox12.TabIndex = 21;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "校正数据批量写入";
            // 
            // btnStopBatchWriteCal
            // 
            this.btnStopBatchWriteCal.Location = new System.Drawing.Point(514, 43);
            this.btnStopBatchWriteCal.Name = "btnStopBatchWriteCal";
            this.btnStopBatchWriteCal.Size = new System.Drawing.Size(101, 23);
            this.btnStopBatchWriteCal.TabIndex = 20;
            this.btnStopBatchWriteCal.Text = "停止";
            this.btnStopBatchWriteCal.UseVisualStyleBackColor = true;
            this.btnStopBatchWriteCal.Click += new System.EventHandler(this.btnStopBatchWriteCal_Click);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(320, 47);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(53, 12);
            this.label34.TabIndex = 19;
            this.label34.Text = "结束行：";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(320, 20);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(53, 12);
            this.label33.TabIndex = 19;
            this.label33.Text = "起始行：";
            // 
            // numStopRow
            // 
            this.numStopRow.Location = new System.Drawing.Point(373, 42);
            this.numStopRow.Name = "numStopRow";
            this.numStopRow.Size = new System.Drawing.Size(120, 21);
            this.numStopRow.TabIndex = 18;
            this.numStopRow.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numStartRow
            // 
            this.numStartRow.Location = new System.Drawing.Point(373, 15);
            this.numStartRow.Name = "numStartRow";
            this.numStartRow.Size = new System.Drawing.Size(120, 21);
            this.numStartRow.TabIndex = 18;
            // 
            // txtBatchFolder
            // 
            this.txtBatchFolder.Location = new System.Drawing.Point(65, 49);
            this.txtBatchFolder.Name = "txtBatchFolder";
            this.txtBatchFolder.Size = new System.Drawing.Size(200, 21);
            this.txtBatchFolder.TabIndex = 15;
            this.txtBatchFolder.Text = "D:\\dat";
            // 
            // txtBatchCalibrationFolder
            // 
            this.txtBatchCalibrationFolder.Location = new System.Drawing.Point(65, 20);
            this.txtBatchCalibrationFolder.Name = "txtBatchCalibrationFolder";
            this.txtBatchCalibrationFolder.Size = new System.Drawing.Size(200, 21);
            this.txtBatchCalibrationFolder.TabIndex = 15;
            this.txtBatchCalibrationFolder.Text = "D:\\dat\\批量表7-12.txt";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(1, 53);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(47, 12);
            this.label32.TabIndex = 14;
            this.label32.Text = "文件夹:";
            // 
            // btnBatchWriteCalibration
            // 
            this.btnBatchWriteCalibration.Location = new System.Drawing.Point(514, 18);
            this.btnBatchWriteCalibration.Name = "btnBatchWriteCalibration";
            this.btnBatchWriteCalibration.Size = new System.Drawing.Size(101, 23);
            this.btnBatchWriteCalibration.TabIndex = 17;
            this.btnBatchWriteCalibration.Text = "写入";
            this.btnBatchWriteCalibration.UseVisualStyleBackColor = true;
            this.btnBatchWriteCalibration.Click += new System.EventHandler(this.btnBatchWriteCalibration_Click);
            // 
            // btnChoseBatchFolder
            // 
            this.btnChoseBatchFolder.Location = new System.Drawing.Point(271, 47);
            this.btnChoseBatchFolder.Name = "btnChoseBatchFolder";
            this.btnChoseBatchFolder.Size = new System.Drawing.Size(39, 23);
            this.btnChoseBatchFolder.TabIndex = 16;
            this.btnChoseBatchFolder.Text = "...";
            this.btnChoseBatchFolder.UseVisualStyleBackColor = true;
            this.btnChoseBatchFolder.Click += new System.EventHandler(this.btnChoseBatchFolder_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 24);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(59, 12);
            this.label20.TabIndex = 14;
            this.label20.Text = "配置文件:";
            // 
            // btnSelectBatchCalibrationFolder
            // 
            this.btnSelectBatchCalibrationFolder.Location = new System.Drawing.Point(271, 18);
            this.btnSelectBatchCalibrationFolder.Name = "btnSelectBatchCalibrationFolder";
            this.btnSelectBatchCalibrationFolder.Size = new System.Drawing.Size(39, 23);
            this.btnSelectBatchCalibrationFolder.TabIndex = 16;
            this.btnSelectBatchCalibrationFolder.Text = "...";
            this.btnSelectBatchCalibrationFolder.UseVisualStyleBackColor = true;
            this.btnSelectBatchCalibrationFolder.Click += new System.EventHandler(this.btnSelectBatchCalibrationFolder_Click);
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.btnSelectLableNameFile);
            this.groupBox14.Controls.Add(this.button12);
            this.groupBox14.Controls.Add(this.txtPathLabelNameFile);
            this.groupBox14.Controls.Add(this.label35);
            this.groupBox14.Location = new System.Drawing.Point(633, 281);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(527, 71);
            this.groupBox14.TabIndex = 23;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "批量写入标签号";
            // 
            // btnSelectLableNameFile
            // 
            this.btnSelectLableNameFile.Location = new System.Drawing.Point(393, 19);
            this.btnSelectLableNameFile.Name = "btnSelectLableNameFile";
            this.btnSelectLableNameFile.Size = new System.Drawing.Size(39, 23);
            this.btnSelectLableNameFile.TabIndex = 21;
            this.btnSelectLableNameFile.Text = "...";
            this.btnSelectLableNameFile.UseVisualStyleBackColor = true;
            this.btnSelectLableNameFile.Click += new System.EventHandler(this.btnSelectLableNameFile_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(434, 20);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 20;
            this.button12.Text = "写入";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // txtPathLabelNameFile
            // 
            this.txtPathLabelNameFile.Location = new System.Drawing.Point(45, 20);
            this.txtPathLabelNameFile.Name = "txtPathLabelNameFile";
            this.txtPathLabelNameFile.Size = new System.Drawing.Size(342, 21);
            this.txtPathLabelNameFile.TabIndex = 19;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(10, 24);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(35, 12);
            this.label35.TabIndex = 18;
            this.label35.Text = "文件:";
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
            this.groupBox13.Location = new System.Drawing.Point(6, 300);
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
            this.groupBox2.Controls.Add(this.btnOnekeyDownSDRAM);
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
            // btnOnekeyDownSDRAM
            // 
            this.btnOnekeyDownSDRAM.Location = new System.Drawing.Point(254, 49);
            this.btnOnekeyDownSDRAM.Name = "btnOnekeyDownSDRAM";
            this.btnOnekeyDownSDRAM.Size = new System.Drawing.Size(101, 23);
            this.btnOnekeyDownSDRAM.TabIndex = 4;
            this.btnOnekeyDownSDRAM.Text = "一键下载";
            this.btnOnekeyDownSDRAM.UseVisualStyleBackColor = true;
            this.btnOnekeyDownSDRAM.Click += new System.EventHandler(this.btnOnekeyDownSDRAM_Click);
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
            this.btnSDRAMWriteToFlash.Location = new System.Drawing.Point(254, 19);
            this.btnSDRAMWriteToFlash.Name = "btnSDRAMWriteToFlash";
            this.btnSDRAMWriteToFlash.Size = new System.Drawing.Size(101, 23);
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
            this.gpTest.Controls.Add(this.button15);
            this.gpTest.Controls.Add(this.button14);
            this.gpTest.Controls.Add(this.button13);
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
            this.gpTest.Size = new System.Drawing.Size(890, 84);
            this.gpTest.TabIndex = 9;
            this.gpTest.TabStop = false;
            this.gpTest.Text = "稳定性测试";
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(765, 52);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(75, 23);
            this.button15.TabIndex = 14;
            this.button15.Text = "读取Busy";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(626, 52);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(133, 23);
            this.button14.TabIndex = 13;
            this.button14.Text = "SDRAM->FLASH";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(544, 49);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 12;
            this.button13.Text = "循环倒数据";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
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
            // gpVolumn
            // 
            this.gpVolumn.Controls.Add(this.lblVolumn2);
            this.gpVolumn.Controls.Add(this.lblVolumn1);
            this.gpVolumn.Controls.Add(this.tbVolumn2);
            this.gpVolumn.Controls.Add(this.tbVolumn1);
            this.gpVolumn.Location = new System.Drawing.Point(8, 135);
            this.gpVolumn.Name = "gpVolumn";
            this.gpVolumn.Size = new System.Drawing.Size(484, 97);
            this.gpVolumn.TabIndex = 22;
            this.gpVolumn.TabStop = false;
            this.gpVolumn.Text = "音量调节";
            // 
            // tbVolumn1
            // 
            this.tbVolumn1.AutoSize = false;
            this.tbVolumn1.Location = new System.Drawing.Point(7, 20);
            this.tbVolumn1.Maximum = 255;
            this.tbVolumn1.Name = "tbVolumn1";
            this.tbVolumn1.Size = new System.Drawing.Size(425, 30);
            this.tbVolumn1.TabIndex = 1;
            this.tbVolumn1.TickFrequency = 10;
            this.tbVolumn1.Value = 25;
            this.tbVolumn1.Scroll += new System.EventHandler(this.tbVolumn1_Scroll);
            this.tbVolumn1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbVolumn1_MouseUp);
            // 
            // tbVolumn2
            // 
            this.tbVolumn2.AutoSize = false;
            this.tbVolumn2.Location = new System.Drawing.Point(7, 61);
            this.tbVolumn2.Maximum = 255;
            this.tbVolumn2.Name = "tbVolumn2";
            this.tbVolumn2.Size = new System.Drawing.Size(425, 30);
            this.tbVolumn2.TabIndex = 1;
            this.tbVolumn2.TickFrequency = 10;
            this.tbVolumn2.Value = 25;
            this.tbVolumn2.Scroll += new System.EventHandler(this.tbVolumn2_Scroll);
            this.tbVolumn2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbVolumn2_MouseUp);
            // 
            // lblVolumn2
            // 
            this.lblVolumn2.AutoSize = true;
            this.lblVolumn2.Location = new System.Drawing.Point(431, 69);
            this.lblVolumn2.Name = "lblVolumn2";
            this.lblVolumn2.Size = new System.Drawing.Size(23, 12);
            this.lblVolumn2.TabIndex = 30;
            this.lblVolumn2.Text = "10%";
            // 
            // lblVolumn1
            // 
            this.lblVolumn1.AutoSize = true;
            this.lblVolumn1.Location = new System.Drawing.Point(431, 25);
            this.lblVolumn1.Name = "lblVolumn1";
            this.lblVolumn1.Size = new System.Drawing.Size(23, 12);
            this.lblVolumn1.TabIndex = 31;
            this.lblVolumn1.Text = "10%";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1521, 833);
            this.Controls.Add(this.tab2055Param);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new PluginLib.BaseFormV2.FormCloseDelegate(this.MainForm_FormClosing);
            this.UnitTypeChanged += new PluginLib.BaseFormV2.UnitTypeChangedDelegate(this.MainForm_UnitTypeChanged);
            this.IsShowDataPackageChanged += new PluginLib.BaseFormV2.IsShowDataPackageChangedDelegate(this.MainForm_IsShowDataPackageChanged);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.tabCommonCommand.ResumeLayout(false);
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGammaBit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGamma)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.gbBrightness.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrightness)).EndInit();
            this.tab2055Param.ResumeLayout(false);
            this.tabAdvance.ResumeLayout(false);
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRed)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox19.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSingleRegValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSingleRegAddr)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.gpFirmwareUpgrade.ResumeLayout(false);
            this.gpFirmwareUpgrade.PerformLayout();
            this.tab2055.ResumeLayout(false);
            this.tab2055.PerformLayout();
            this.tabRegister.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid2055)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridOtherReg)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox22.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numPreview128Reg)).EndInit();
            this.gp2019Config.ResumeLayout(false);
            this.gp2019Config.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input2019_163)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2019_162)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2019_161)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2019_160)).EndInit();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_7_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_3_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_17_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_16_8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_16_7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_14_7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_14_6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_14_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_9_6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_9_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_9_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_2_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_2_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_2_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_2_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072_3_6)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.gpSimple2019.ResumeLayout(false);
            this.gpSimple2019.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input2019Simple_163)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2019Simple_162)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2019Simple_161)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2019Simple_160)).EndInit();
            this.gpSimple2072GAMMA.ResumeLayout(false);
            this.gpSimple2072GAMMA.PerformLayout();
            this.gP2072Simple13.ResumeLayout(false);
            this.gP2072Simple13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple13_B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple13_G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple13_R)).EndInit();
            this.gP2072Simple12.ResumeLayout(false);
            this.gP2072Simple12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple12_B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple12_G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple12_R)).EndInit();
            this.gP2072Simple11.ResumeLayout(false);
            this.gP2072Simple11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple11_B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple11_G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple11_R)).EndInit();
            this.gP2072Simple10.ResumeLayout(false);
            this.gP2072Simple10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple10_B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple10_G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple10_R)).EndInit();
            this.gP2072Simple9.ResumeLayout(false);
            this.gP2072Simple9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple9_B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple9_G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple9_R)).EndInit();
            this.gP2072Simple8.ResumeLayout(false);
            this.gP2072Simple8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple8_B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple8_G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple8_R)).EndInit();
            this.gP2072Simple6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple6)).EndInit();
            this.gP2072Simple5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple5)).EndInit();
            this.gP2072Simple4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple4)).EndInit();
            this.gP2072Simple7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple7)).EndInit();
            this.gP2072Simple3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple3)).EndInit();
            this.gP2072Simple2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.input2072Simple2)).EndInit();
            this.gP2072Simple1.ResumeLayout(false);
            this.gp2072FuncTest.ResumeLayout(false);
            this.gp2072FuncTest.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.gp2072FactoryRegister.ResumeLayout(false);
            this.gp2072FactoryRegister.PerformLayout();
            this.gp2072Factory_CurrentGain.ResumeLayout(false);
            this.gp2072Factory_CurrentGain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Factory_CurrentGain_B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Factory_CurrentGain_G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input2072Factory_CurrentGain_R)).EndInit();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGainB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGainG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGainR)).EndInit();
            this.tabTest.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVol2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVol)).EndInit();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStopRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartRow)).EndInit();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
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
            this.gpVolumn.ResumeLayout(false);
            this.gpVolumn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolumn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolumn2)).EndInit();
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
        private System.Windows.Forms.TabPage tab2055;
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
        private System.Windows.Forms.Button btnUpgradeFPGA;
        private System.Windows.Forms.Button btnChoseFPGA;
        private System.Windows.Forms.TextBox txtFPGA;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnReadFPGA;
        private System.Windows.Forms.Button btnReadMCU;
        private System.Windows.Forms.Button btnReadMCUVersion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbChipPos;
        private System.Windows.Forms.ComboBox cbMCUChip;
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
        private System.Windows.Forms.Button btnReadbtnDistributeBoardFPGA;
        private System.Windows.Forms.Button btnUpdateDistributeBoardFPGA;
        private System.Windows.Forms.Button btnChoseDistributeBoardFPGA;
        private System.Windows.Forms.TextBox txtDistributeBoardFPGA;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button btnLoadFPGA;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox gp2019Config;
        private System.Windows.Forms.Label label214;
        private System.Windows.Forms.Button btnSet2019All;
        private System.Windows.Forms.Label label213;
        private System.Windows.Forms.Label label212;
        private System.Windows.Forms.Label label211;
        private System.Windows.Forms.Button btnSet2019_163;
        private System.Windows.Forms.NumericUpDown input2019_163;
        private System.Windows.Forms.Label label206;
        private System.Windows.Forms.Button btnSet2019_162;
        private System.Windows.Forms.NumericUpDown input2019_162;
        private System.Windows.Forms.Label label204;
        private System.Windows.Forms.Button btnSet2019_161;
        private System.Windows.Forms.NumericUpDown input2019_161;
        private System.Windows.Forms.Label label203;
        private System.Windows.Forms.Button btnSet2019_160;
        private System.Windows.Forms.NumericUpDown input2019_160;
        private System.Windows.Forms.Label label202;
        private System.Windows.Forms.Button btn2072_saveValueList;
        private System.Windows.Forms.CheckBox ck2072CycleTest;
        private System.Windows.Forms.Button btn2072_all;
        private System.Windows.Forms.Button btn2072_export;
        private System.Windows.Forms.Button btn2072_import;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.NumericUpDown input2072_7_1;
        private System.Windows.Forms.NumericUpDown input2072_3_1;
        private System.Windows.Forms.NumericUpDown input2072_17_2;
        private System.Windows.Forms.NumericUpDown input2072_16_8;
        private System.Windows.Forms.NumericUpDown input2072_16_7;
        private System.Windows.Forms.NumericUpDown input2072_14_7;
        private System.Windows.Forms.NumericUpDown input2072_14_6;
        private System.Windows.Forms.NumericUpDown input2072_14_5;
        private System.Windows.Forms.NumericUpDown input2072_9_6;
        private System.Windows.Forms.NumericUpDown input2072_9_5;
        private System.Windows.Forms.NumericUpDown input2072_9_4;
        private System.Windows.Forms.NumericUpDown input2072_2_4;
        private System.Windows.Forms.NumericUpDown input2072_2_3;
        private System.Windows.Forms.NumericUpDown input2072_2_2;
        private System.Windows.Forms.NumericUpDown input2072_2_1;
        private System.Windows.Forms.NumericUpDown input2072_3_6;
        private System.Windows.Forms.Button btn2072_f3;
        private System.Windows.Forms.Button btn2072_f2;
        private System.Windows.Forms.Button btn2072_f1;
        private System.Windows.Forms.Button btn2072_c;
        private System.Windows.Forms.Button btn2072_b;
        private System.Windows.Forms.Button btn2072_f0;
        private System.Windows.Forms.Button btn2072_d;
        private System.Windows.Forms.Button btn2072_9;
        private System.Windows.Forms.Button btn2072_8;
        private System.Windows.Forms.ComboBox cb2072_17_1;
        private System.Windows.Forms.Label label154;
        private System.Windows.Forms.Label label155;
        private System.Windows.Forms.Label label156;
        private System.Windows.Forms.Label label147;
        private System.Windows.Forms.Label label136;
        private System.Windows.Forms.ComboBox cb2072_16_6;
        private System.Windows.Forms.Label label138;
        private System.Windows.Forms.ComboBox cb2072_16_5;
        private System.Windows.Forms.Label label139;
        private System.Windows.Forms.ComboBox cb2072_16_4;
        private System.Windows.Forms.Label label141;
        private System.Windows.Forms.ComboBox cb2072_16_2;
        private System.Windows.Forms.ComboBox cb2072_16_3;
        private System.Windows.Forms.ComboBox cb2072_16_1;
        private System.Windows.Forms.Label label142;
        private System.Windows.Forms.Label label144;
        private System.Windows.Forms.Label label145;
        private System.Windows.Forms.Label label146;
        private System.Windows.Forms.ComboBox cb2072_15_6;
        private System.Windows.Forms.Label label175;
        private System.Windows.Forms.ComboBox cb2072_15_5;
        private System.Windows.Forms.Label label178;
        private System.Windows.Forms.ComboBox cb2072_15_4;
        private System.Windows.Forms.Label label181;
        private System.Windows.Forms.ComboBox cb2072_15_2;
        private System.Windows.Forms.ComboBox cb2072_15_3;
        private System.Windows.Forms.ComboBox cb2072_15_1;
        private System.Windows.Forms.Label label207;
        private System.Windows.Forms.Label label208;
        private System.Windows.Forms.Label label209;
        private System.Windows.Forms.Label label210;
        private System.Windows.Forms.ComboBox cb2072_12_7;
        private System.Windows.Forms.Label label126;
        private System.Windows.Forms.ComboBox cb2072_12_6;
        private System.Windows.Forms.Label label129;
        private System.Windows.Forms.ComboBox cb2072_12_5;
        private System.Windows.Forms.Label label134;
        private System.Windows.Forms.ComboBox cb2072_12_4;
        private System.Windows.Forms.Label label137;
        private System.Windows.Forms.ComboBox cb2072_12_2;
        private System.Windows.Forms.ComboBox cb2072_12_3;
        private System.Windows.Forms.ComboBox cb2072_12_1;
        private System.Windows.Forms.Label label140;
        private System.Windows.Forms.Label label143;
        private System.Windows.Forms.Label label148;
        private System.Windows.Forms.Label label151;
        private System.Windows.Forms.ComboBox cb2072_11_7;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.ComboBox cb2072_11_6;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.ComboBox cb2072_11_5;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.ComboBox cb2072_11_4;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.ComboBox cb2072_11_2;
        private System.Windows.Forms.ComboBox cb2072_11_3;
        private System.Windows.Forms.ComboBox cb2072_11_1;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.Label label117;
        private System.Windows.Forms.Label label121;
        private System.Windows.Forms.Label label158;
        private System.Windows.Forms.Label label176;
        private System.Windows.Forms.Label label177;
        private System.Windows.Forms.ComboBox cb2072_14_4;
        private System.Windows.Forms.Label label179;
        private System.Windows.Forms.ComboBox cb2072_14_2;
        private System.Windows.Forms.ComboBox cb2072_14_3;
        private System.Windows.Forms.ComboBox cb2072_14_1;
        private System.Windows.Forms.Label label180;
        private System.Windows.Forms.Label label182;
        private System.Windows.Forms.Label label183;
        private System.Windows.Forms.Label label184;
        private System.Windows.Forms.ComboBox cb2072_13_1;
        private System.Windows.Forms.ComboBox cb2072_13_10;
        private System.Windows.Forms.ComboBox cb2072_13_9;
        private System.Windows.Forms.ComboBox cb2072_13_8;
        private System.Windows.Forms.Label label159;
        private System.Windows.Forms.Label label160;
        private System.Windows.Forms.Label label161;
        private System.Windows.Forms.Button btn2072_a;
        private System.Windows.Forms.ComboBox cb2072_13_12;
        private System.Windows.Forms.ComboBox cb2072_13_11;
        private System.Windows.Forms.ComboBox cb2072_13_7;
        private System.Windows.Forms.ComboBox cb2072_13_6;
        private System.Windows.Forms.ComboBox cb2072_13_5;
        private System.Windows.Forms.ComboBox cb2072_13_4;
        private System.Windows.Forms.ComboBox cb2072_13_3;
        private System.Windows.Forms.ComboBox cb2072_13_2;
        private System.Windows.Forms.Label label162;
        private System.Windows.Forms.Label label163;
        private System.Windows.Forms.Label label165;
        private System.Windows.Forms.Label label166;
        private System.Windows.Forms.Label label167;
        private System.Windows.Forms.Label label168;
        private System.Windows.Forms.Label label169;
        private System.Windows.Forms.Label label171;
        private System.Windows.Forms.Label label173;
        private System.Windows.Forms.Label label174;
        private System.Windows.Forms.ComboBox cb2072_10_7;
        private System.Windows.Forms.Label label133;
        private System.Windows.Forms.ComboBox cb2072_10_6;
        private System.Windows.Forms.Label label135;
        private System.Windows.Forms.ComboBox cb2072_10_5;
        private System.Windows.Forms.Label label125;
        private System.Windows.Forms.ComboBox cb2072_10_4;
        private System.Windows.Forms.Label label127;
        private System.Windows.Forms.ComboBox cb2072_10_2;
        private System.Windows.Forms.ComboBox cb2072_10_3;
        private System.Windows.Forms.ComboBox cb2072_10_1;
        private System.Windows.Forms.Label label128;
        private System.Windows.Forms.Label label130;
        private System.Windows.Forms.Label label131;
        private System.Windows.Forms.Label label132;
        private System.Windows.Forms.Label label123;
        private System.Windows.Forms.Label label124;
        private System.Windows.Forms.Label label111;
        private System.Windows.Forms.ComboBox cb2072_9_1;
        private System.Windows.Forms.ComboBox cb2072_9_3;
        private System.Windows.Forms.ComboBox cb2072_9_2;
        private System.Windows.Forms.Label label112;
        private System.Windows.Forms.Label label113;
        private System.Windows.Forms.Label label120;
        private System.Windows.Forms.Label label122;
        private System.Windows.Forms.ComboBox cb2072_8_4;
        private System.Windows.Forms.Label label114;
        private System.Windows.Forms.ComboBox cb2072_8_1;
        private System.Windows.Forms.ComboBox cb2072_8_3;
        private System.Windows.Forms.ComboBox cb2072_8_2;
        private System.Windows.Forms.Label label115;
        private System.Windows.Forms.Label label116;
        private System.Windows.Forms.Label label118;
        private System.Windows.Forms.Label label119;
        private System.Windows.Forms.ComboBox cb2072_7_14;
        private System.Windows.Forms.Label label110;
        private System.Windows.Forms.ComboBox cb2072_7_11;
        private System.Windows.Forms.ComboBox cb2072_7_10;
        private System.Windows.Forms.ComboBox cb2072_7_9;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.Label label109;
        private System.Windows.Forms.Button btn2072_7;
        private System.Windows.Forms.ComboBox cb2072_7_13;
        private System.Windows.Forms.ComboBox cb2072_7_12;
        private System.Windows.Forms.ComboBox cb2072_7_8;
        private System.Windows.Forms.ComboBox cb2072_7_7;
        private System.Windows.Forms.ComboBox cb2072_7_6;
        private System.Windows.Forms.ComboBox cb2072_7_5;
        private System.Windows.Forms.ComboBox cb2072_7_4;
        private System.Windows.Forms.ComboBox cb2072_7_3;
        private System.Windows.Forms.ComboBox cb2072_7_2;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.Label label101;
        private System.Windows.Forms.Label label102;
        private System.Windows.Forms.Label label104;
        private System.Windows.Forms.Label label105;
        private System.Windows.Forms.Label label106;
        private System.Windows.Forms.Label label107;
        private System.Windows.Forms.Label label108;
        private System.Windows.Forms.ComboBox cb2072_5_4;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.ComboBox cb2072_5_1;
        private System.Windows.Forms.Button btn2072_5;
        private System.Windows.Forms.ComboBox cb2072_5_3;
        private System.Windows.Forms.ComboBox cb2072_5_2;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.ComboBox cb2072_6_6;
        private System.Windows.Forms.ComboBox cb2072_6_5;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.ComboBox cb2072_6_1;
        private System.Windows.Forms.Button btn2072_6;
        private System.Windows.Forms.ComboBox cb2072_6_4;
        private System.Windows.Forms.ComboBox cb2072_6_3;
        private System.Windows.Forms.ComboBox cb2072_6_2;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Button btn2072_4;
        private System.Windows.Forms.ComboBox cb2072_4_6;
        private System.Windows.Forms.ComboBox cb2072_4_5;
        private System.Windows.Forms.ComboBox cb2072_4_4;
        private System.Windows.Forms.ComboBox cb2072_4_3;
        private System.Windows.Forms.ComboBox cb2072_4_2;
        private System.Windows.Forms.ComboBox cb2072_4_1;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.ComboBox cb2072_3_5;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.ComboBox cb2072_3_4;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.ComboBox cb2072_3_3;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Button btn2072_3;
        private System.Windows.Forms.ComboBox cb2072_3_2;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Button btn2072_2;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Button btn2072_1;
        private System.Windows.Forms.ComboBox cb2072_1_12;
        private System.Windows.Forms.ComboBox cb2072_1_11;
        private System.Windows.Forms.ComboBox cb2072_1_10;
        private System.Windows.Forms.ComboBox cb2072_1_9;
        private System.Windows.Forms.ComboBox cb2072_1_8;
        private System.Windows.Forms.ComboBox cb2072_1_7;
        private System.Windows.Forms.ComboBox cb2072_1_6;
        private System.Windows.Forms.ComboBox cb2072_1_5;
        private System.Windows.Forms.ComboBox cb2072_1_4;
        private System.Windows.Forms.ComboBox cb2072_1_3;
        private System.Windows.Forms.ComboBox cb2072_1_2;
        private System.Windows.Forms.ComboBox cb2072_1_1;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn2072Simple2_TryCalc;
        private System.Windows.Forms.GroupBox gpSimple2019;
        private System.Windows.Forms.Label label215;
        private System.Windows.Forms.Button btnSet2019Simple_All;
        private System.Windows.Forms.Label label216;
        private System.Windows.Forms.Label label217;
        private System.Windows.Forms.Label label218;
        private System.Windows.Forms.Button btnSet2019Simple_163;
        private System.Windows.Forms.NumericUpDown input2019Simple_163;
        private System.Windows.Forms.Label label219;
        private System.Windows.Forms.Button btnSet2019Simple_162;
        private System.Windows.Forms.NumericUpDown input2019Simple_162;
        private System.Windows.Forms.Label label220;
        private System.Windows.Forms.Button btnSet2019Simple_161;
        private System.Windows.Forms.NumericUpDown input2019Simple_161;
        private System.Windows.Forms.Label label221;
        private System.Windows.Forms.Button btnSet2019Simple_160;
        private System.Windows.Forms.NumericUpDown input2019Simple_160;
        private System.Windows.Forms.Label label222;
        private System.Windows.Forms.GroupBox gpSimple2072GAMMA;
        private System.Windows.Forms.Label label201;
        private System.Windows.Forms.Button btn2072SimpleSendGAMMAFile;
        private System.Windows.Forms.Button btnSimple2072CreateGAMMAFile;
        private System.Windows.Forms.TextBox tbSimple2072GAMMAVal;
        private System.Windows.Forms.Button btn2072SimpleCalcGAMMASend;
        private System.Windows.Forms.Label label205;
        private System.Windows.Forms.ComboBox cb2072SimpleGAMMA;
        private System.Windows.Forms.ComboBox cb2072Simple5060Hz;
        private System.Windows.Forms.Button btn2072Simple_SendAll;
        private System.Windows.Forms.Button btn2072Simple_ExportFile;
        private System.Windows.Forms.Button btn2072Simple_ImportFile;
        private System.Windows.Forms.Button btn2072Simple_ResetValues;
        private System.Windows.Forms.GroupBox gP2072Simple13;
        private System.Windows.Forms.Button btn2072Simple13_All;
        private System.Windows.Forms.Label label198;
        private System.Windows.Forms.NumericUpDown input2072Simple13_B;
        private System.Windows.Forms.Button btn2072Simple13_B;
        private System.Windows.Forms.Label label199;
        private System.Windows.Forms.NumericUpDown input2072Simple13_G;
        private System.Windows.Forms.Button btn2072Simple13_G;
        private System.Windows.Forms.Label label200;
        private System.Windows.Forms.NumericUpDown input2072Simple13_R;
        private System.Windows.Forms.Button btn2072Simple13_R;
        private System.Windows.Forms.GroupBox gP2072Simple12;
        private System.Windows.Forms.Button btn2072Simple12_All;
        private System.Windows.Forms.Label label195;
        private System.Windows.Forms.NumericUpDown input2072Simple12_B;
        private System.Windows.Forms.Button btn2072Simple12_B;
        private System.Windows.Forms.Label label196;
        private System.Windows.Forms.NumericUpDown input2072Simple12_G;
        private System.Windows.Forms.Button btn2072Simple12_G;
        private System.Windows.Forms.Label label197;
        private System.Windows.Forms.NumericUpDown input2072Simple12_R;
        private System.Windows.Forms.Button btn2072Simple12_R;
        private System.Windows.Forms.GroupBox gP2072Simple11;
        private System.Windows.Forms.Button btn2072Simple11_All;
        private System.Windows.Forms.Label label192;
        private System.Windows.Forms.NumericUpDown input2072Simple11_B;
        private System.Windows.Forms.Button btn2072Simple11_B;
        private System.Windows.Forms.Label label193;
        private System.Windows.Forms.NumericUpDown input2072Simple11_G;
        private System.Windows.Forms.Button btn2072Simple11_G;
        private System.Windows.Forms.Label label194;
        private System.Windows.Forms.NumericUpDown input2072Simple11_R;
        private System.Windows.Forms.Button btn2072Simple11_R;
        private System.Windows.Forms.GroupBox gP2072Simple10;
        private System.Windows.Forms.Button btn2072Simple10_All;
        private System.Windows.Forms.Label label189;
        private System.Windows.Forms.NumericUpDown input2072Simple10_B;
        private System.Windows.Forms.Button btn2072Simple10_B;
        private System.Windows.Forms.Label label190;
        private System.Windows.Forms.NumericUpDown input2072Simple10_G;
        private System.Windows.Forms.Button btn2072Simple10_G;
        private System.Windows.Forms.Label label191;
        private System.Windows.Forms.NumericUpDown input2072Simple10_R;
        private System.Windows.Forms.Button btn2072Simple10_R;
        private System.Windows.Forms.GroupBox gP2072Simple9;
        private System.Windows.Forms.Button btn2072Simple9_All;
        private System.Windows.Forms.Label label186;
        private System.Windows.Forms.NumericUpDown input2072Simple9_B;
        private System.Windows.Forms.Button btn2072Simple9_B;
        private System.Windows.Forms.Label label187;
        private System.Windows.Forms.NumericUpDown input2072Simple9_G;
        private System.Windows.Forms.Button btn2072Simple9_G;
        private System.Windows.Forms.Label label188;
        private System.Windows.Forms.NumericUpDown input2072Simple9_R;
        private System.Windows.Forms.Button btn2072Simple9_R;
        private System.Windows.Forms.GroupBox gP2072Simple8;
        private System.Windows.Forms.Button btn2072Simple8_All;
        private System.Windows.Forms.Label label185;
        private System.Windows.Forms.NumericUpDown input2072Simple8_B;
        private System.Windows.Forms.Button btn2072Simple8_B;
        private System.Windows.Forms.Label label172;
        private System.Windows.Forms.NumericUpDown input2072Simple8_G;
        private System.Windows.Forms.Button btn2072Simple8_G;
        private System.Windows.Forms.Label label170;
        private System.Windows.Forms.NumericUpDown input2072Simple8_R;
        private System.Windows.Forms.Button btn2072Simple8_R;
        private System.Windows.Forms.GroupBox gP2072Simple6;
        private System.Windows.Forms.NumericUpDown input2072Simple6;
        private System.Windows.Forms.Button btn2072Simple6;
        private System.Windows.Forms.GroupBox gP2072Simple5;
        private System.Windows.Forms.NumericUpDown input2072Simple5;
        private System.Windows.Forms.Button btn2072Simple5;
        private System.Windows.Forms.GroupBox gP2072Simple4;
        private System.Windows.Forms.NumericUpDown input2072Simple4;
        private System.Windows.Forms.Button btn2072Simple4;
        private System.Windows.Forms.GroupBox gP2072Simple7;
        private System.Windows.Forms.Button btn2072Simple7_Calc;
        private System.Windows.Forms.NumericUpDown input2072Simple7;
        private System.Windows.Forms.Button btn2072Simple7;
        private System.Windows.Forms.GroupBox gP2072Simple3;
        private System.Windows.Forms.NumericUpDown input2072Simple3;
        private System.Windows.Forms.Button btn2072Simple3;
        private System.Windows.Forms.GroupBox gP2072Simple2;
        private System.Windows.Forms.Button btn2072Simple2_Calc;
        private System.Windows.Forms.NumericUpDown input2072Simple2;
        private System.Windows.Forms.Button btn2072Simple2;
        private System.Windows.Forms.GroupBox gP2072Simple1;
        private System.Windows.Forms.ComboBox cb2072Simple1;
        private System.Windows.Forms.Button btn2072Simple1;
        private System.Windows.Forms.GroupBox gp2072FuncTest;
        private System.Windows.Forms.TextBox input2072FuncRegAddr;
        private System.Windows.Forms.TextBox input2072FuncVal;
        private System.Windows.Forms.Button btn2072FuncTest;
        private System.Windows.Forms.Label label157;
        private System.Windows.Forms.Label label153;
        private System.Windows.Forms.ComboBox cb2072FuncTest3;
        private System.Windows.Forms.Label label152;
        private System.Windows.Forms.Label label150;
        private System.Windows.Forms.ComboBox cb2072FuncTest2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox gp2072FactoryRegister;
        private System.Windows.Forms.TextBox input2072FactoryRegisterAddr;
        private System.Windows.Forms.TextBox input2072FactoryRegisterVal;
        private System.Windows.Forms.Button btn2072FactoryRegisterSet;
        private System.Windows.Forms.Label lb2072FactoryRegister4;
        private System.Windows.Forms.Label lb2072FactoryRegister3;
        private System.Windows.Forms.ComboBox cb2072FactoryRegister_EndBit;
        private System.Windows.Forms.Label lb2072FactoryRegister2;
        private System.Windows.Forms.Label lb2072FactoryRegister1;
        private System.Windows.Forms.ComboBox cb2072FactoryRegister_StartBit;
        private System.Windows.Forms.ComboBox cb2072Factory5060Hz;
        private System.Windows.Forms.Button btn2072Factory_SendAll;
        private System.Windows.Forms.Button btn2072FactoryExport;
        private System.Windows.Forms.Button btn2072FactoryImport;
        private System.Windows.Forms.GroupBox gp2072Factory_CurrentGain;
        private System.Windows.Forms.Button btnSet2072FactoryCurrentGain_All;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.NumericUpDown input2072Factory_CurrentGain_B;
        private System.Windows.Forms.Button btnSet2072FactoryCurrentGain_B;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.NumericUpDown input2072Factory_CurrentGain_G;
        private System.Windows.Forms.Button btnSet2072FactoryCurrentGain_G;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDown input2072Factory_CurrentGain_R;
        private System.Windows.Forms.Button btnSet2072FactoryCurrentGain_R;
        private System.Windows.Forms.Button btnRead2072;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.RichTextBox rt2072;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button btnReadMap;
        private System.Windows.Forms.Button btnReadMbFPGA;
        private System.Windows.Forms.Button btnUpgradeMbFPGA;
        private System.Windows.Forms.Button btnChoseMbFPGA;
        private System.Windows.Forms.TextBox txtMbFPGA;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.RichTextBox rtRead;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.Button btnGainAll;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.NumericUpDown numGainB;
        private System.Windows.Forms.Button btnGainB;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.NumericUpDown numGainG;
        private System.Windows.Forms.Button btnGainG;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.NumericUpDown numGainR;
        private System.Windows.Forms.Button btnGainR;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.Button btnReadCalibration;
        private System.Windows.Forms.TextBox txtCalibrationFile;
        private System.Windows.Forms.Button btnUpdateCalibration;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Button btnChoseCalibration;
        private System.Windows.Forms.ComboBox cbBoardPos;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.Button btnCreateSN;
        private System.Windows.Forms.Button btnReadSN;
        private System.Windows.Forms.ComboBox cbSNPos;
        private System.Windows.Forms.TextBox txtBatchFolder;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button btnChoseBatchFolder;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.NumericUpDown numStopRow;
        private System.Windows.Forms.NumericUpDown numStartRow;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Button btnSelectLableNameFile;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.TextBox txtPathLabelNameFile;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button btnReadMbVersion;
        private System.Windows.Forms.Button btnReadDivideVersion;
        private System.Windows.Forms.Button btnReadBoardVersion;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.ComboBox cbDistributeChip;
        private System.Windows.Forms.ComboBox cbModuleChip;
        private System.Windows.Forms.ComboBox cbMBFPGAChip;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtBatchWriteCalibrationFolder;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button btnBatchWriteCal;
        private System.Windows.Forms.Button btnChoseBatchCalibrationFolder;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.ComboBox cbSNCreate;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button btnStopBatchWriteCal;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button btnLoadModuleSection;
        private System.Windows.Forms.Button btnOnekeyDownSDRAM;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.Button btnColorTempConfig;
        private System.Windows.Forms.Button btnSetColorTemp;
        private System.Windows.Forms.ComboBox cbHz;
        private System.Windows.Forms.ComboBox cbColorTempType;
        private System.Windows.Forms.ComboBox cbChipType;
        private System.Windows.Forms.Button btnReadColorTemp;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.Button btnReadGain;
        private System.Windows.Forms.Button btnSetGain;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.NumericUpDown numBlue;
        private System.Windows.Forms.NumericUpDown numGreen;
        private System.Windows.Forms.NumericUpDown numRed;
        private System.Windows.Forms.ComboBox cbChip;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btn2055Read1;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.Button btn2055Send2;
        private System.Windows.Forms.RichTextBox rt2055Send2;
        private System.Windows.Forms.Button btn2055Read2;
        private System.Windows.Forms.Button btn2055Send1;
        private System.Windows.Forms.RichTextBox rt2055Send1;
        private System.Windows.Forms.Button btnStopWriteCal;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.ComboBox cbGammFileColor;
        private System.Windows.Forms.Button btnWriteGammaFile;
        private System.Windows.Forms.Button btnChoseGammaFile;
        private System.Windows.Forms.TextBox txtGammaFile;
        private System.Windows.Forms.Button btnCreateGammaFile;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.NumericUpDown numPreview128Reg;
        private System.Windows.Forms.Button btnPreview128Reg;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numGammaBit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CoCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMinValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMaxValue;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColCNDescription;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColENDescription;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColDescription;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColOffset;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColRegisterAddress;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColRedAddress;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColGreenAddress;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColBlueAddress;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColStartBit;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColStopBit;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColRedValue;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColGreenValue;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColBlueValue;
        private System.Windows.Forms.DataGridViewButtonColumn ColSend;
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
        private System.Windows.Forms.Button btnSetVol;
        private System.Windows.Forms.TrackBar tbVol;
        private System.Windows.Forms.TrackBar tbVol2;
        private System.Windows.Forms.Label label103;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.GroupBox gpVolumn;
        private System.Windows.Forms.TrackBar tbVolumn2;
        private System.Windows.Forms.TrackBar tbVolumn1;
        private System.Windows.Forms.Label lblVolumn2;
        private System.Windows.Forms.Label lblVolumn1;
    }
}

