namespace CalibrationTools
{
    partial class FrmMain
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
            this.btnConvertDatToSdat = new System.Windows.Forms.Button();
            this.btnConverZDatToSDat = new System.Windows.Forms.Button();
            this.btnDatToZDat = new System.Windows.Forms.Button();
            this.btnSDatToZDat = new System.Windows.Forms.Button();
            this.btnSDatToDat = new System.Windows.Forms.Button();
            this.btnZdatToDat = new System.Windows.Forms.Button();
            this.btnMerge = new System.Windows.Forms.Button();
            this.btnSplit = new System.Windows.Forms.Button();
            this.btnSeamCorrection = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnBatchConvert = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConvertDatToSdat
            // 
            this.btnConvertDatToSdat.Location = new System.Drawing.Point(13, 13);
            this.btnConvertDatToSdat.Name = "btnConvertDatToSdat";
            this.btnConvertDatToSdat.Size = new System.Drawing.Size(75, 23);
            this.btnConvertDatToSdat.TabIndex = 0;
            this.btnConvertDatToSdat.Text = "Dat->SDat";
            this.btnConvertDatToSdat.UseVisualStyleBackColor = true;
            this.btnConvertDatToSdat.Click += new System.EventHandler(this.btnConvertDatToSdat_Click);
            // 
            // btnConverZDatToSDat
            // 
            this.btnConverZDatToSDat.Location = new System.Drawing.Point(94, 13);
            this.btnConverZDatToSDat.Name = "btnConverZDatToSDat";
            this.btnConverZDatToSDat.Size = new System.Drawing.Size(75, 23);
            this.btnConverZDatToSDat.TabIndex = 0;
            this.btnConverZDatToSDat.Text = "ZDat->SDat";
            this.btnConverZDatToSDat.UseVisualStyleBackColor = true;
            this.btnConverZDatToSDat.Click += new System.EventHandler(this.btnConverZDatToSDat_Click);
            // 
            // btnDatToZDat
            // 
            this.btnDatToZDat.Location = new System.Drawing.Point(175, 13);
            this.btnDatToZDat.Name = "btnDatToZDat";
            this.btnDatToZDat.Size = new System.Drawing.Size(75, 23);
            this.btnDatToZDat.TabIndex = 1;
            this.btnDatToZDat.Text = "Dat->ZDat";
            this.btnDatToZDat.UseVisualStyleBackColor = true;
            this.btnDatToZDat.Click += new System.EventHandler(this.btnDatToZDat_Click);
            // 
            // btnSDatToZDat
            // 
            this.btnSDatToZDat.Location = new System.Drawing.Point(256, 13);
            this.btnSDatToZDat.Name = "btnSDatToZDat";
            this.btnSDatToZDat.Size = new System.Drawing.Size(75, 23);
            this.btnSDatToZDat.TabIndex = 1;
            this.btnSDatToZDat.Text = "SDat->ZDat";
            this.btnSDatToZDat.UseVisualStyleBackColor = true;
            this.btnSDatToZDat.Click += new System.EventHandler(this.btnSDatToZDat_Click);
            // 
            // btnSDatToDat
            // 
            this.btnSDatToDat.Location = new System.Drawing.Point(337, 13);
            this.btnSDatToDat.Name = "btnSDatToDat";
            this.btnSDatToDat.Size = new System.Drawing.Size(75, 23);
            this.btnSDatToDat.TabIndex = 1;
            this.btnSDatToDat.Text = "SDat->Dat";
            this.btnSDatToDat.UseVisualStyleBackColor = true;
            this.btnSDatToDat.Click += new System.EventHandler(this.btnSDatToDat_Click);
            // 
            // btnZdatToDat
            // 
            this.btnZdatToDat.Location = new System.Drawing.Point(418, 13);
            this.btnZdatToDat.Name = "btnZdatToDat";
            this.btnZdatToDat.Size = new System.Drawing.Size(75, 23);
            this.btnZdatToDat.TabIndex = 1;
            this.btnZdatToDat.Text = "ZDat->Dat";
            this.btnZdatToDat.UseVisualStyleBackColor = true;
            this.btnZdatToDat.Click += new System.EventHandler(this.btnZdatToDat_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(13, 42);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(75, 23);
            this.btnMerge.TabIndex = 2;
            this.btnMerge.Text = "合并";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // btnSplit
            // 
            this.btnSplit.Location = new System.Drawing.Point(94, 42);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(75, 23);
            this.btnSplit.TabIndex = 2;
            this.btnSplit.Text = "拆分";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // btnSeamCorrection
            // 
            this.btnSeamCorrection.Location = new System.Drawing.Point(175, 42);
            this.btnSeamCorrection.Name = "btnSeamCorrection";
            this.btnSeamCorrection.Size = new System.Drawing.Size(137, 23);
            this.btnSeamCorrection.TabIndex = 3;
            this.btnSeamCorrection.Text = "调边缘->Split";
            this.btnSeamCorrection.UseVisualStyleBackColor = true;
            this.btnSeamCorrection.Click += new System.EventHandler(this.btnSeamCorrection_Click);
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(319, 43);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 23);
            this.btnRename.TabIndex = 4;
            this.btnRename.Text = "文件改名";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnBatchConvert
            // 
            this.btnBatchConvert.Location = new System.Drawing.Point(401, 43);
            this.btnBatchConvert.Name = "btnBatchConvert";
            this.btnBatchConvert.Size = new System.Drawing.Size(75, 23);
            this.btnBatchConvert.TabIndex = 5;
            this.btnBatchConvert.Text = "批量转换";
            this.btnBatchConvert.UseVisualStyleBackColor = true;
            this.btnBatchConvert.Click += new System.EventHandler(this.btnBatchConvert_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Ping测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnBatchConvert);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.btnSeamCorrection);
            this.Controls.Add(this.btnSplit);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.btnZdatToDat);
            this.Controls.Add(this.btnSDatToDat);
            this.Controls.Add(this.btnSDatToZDat);
            this.Controls.Add(this.btnDatToZDat);
            this.Controls.Add(this.btnConverZDatToSDat);
            this.Controls.Add(this.btnConvertDatToSdat);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConvertDatToSdat;
        private System.Windows.Forms.Button btnConverZDatToSDat;
        private System.Windows.Forms.Button btnDatToZDat;
        private System.Windows.Forms.Button btnSDatToZDat;
        private System.Windows.Forms.Button btnSDatToDat;
        private System.Windows.Forms.Button btnZdatToDat;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.Button btnSeamCorrection;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnBatchConvert;
        private System.Windows.Forms.Button button1;
    }
}

