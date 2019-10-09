namespace TLWController
{
    partial class FrmColorTemp
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
            this.cbChipType = new System.Windows.Forms.ComboBox();
            this.numRed = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numGreen = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numBlue = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbHz1 = new System.Windows.Forms.ComboBox();
            this.cbColorTempType1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlue)).BeginInit();
            this.SuspendLayout();
            // 
            // cbChipType
            // 
            this.cbChipType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChipType.FormattingEnabled = true;
            this.cbChipType.Location = new System.Drawing.Point(12, 13);
            this.cbChipType.Name = "cbChipType";
            this.cbChipType.Size = new System.Drawing.Size(98, 20);
            this.cbChipType.TabIndex = 0;
            // 
            // numRed
            // 
            this.numRed.Location = new System.Drawing.Point(60, 52);
            this.numRed.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numRed.Name = "numRed";
            this.numRed.Size = new System.Drawing.Size(200, 21);
            this.numRed.TabIndex = 2;
            this.numRed.ValueChanged += new System.EventHandler(this.numRed_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "红色：";
            // 
            // numGreen
            // 
            this.numGreen.Location = new System.Drawing.Point(60, 79);
            this.numGreen.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numGreen.Name = "numGreen";
            this.numGreen.Size = new System.Drawing.Size(200, 21);
            this.numGreen.TabIndex = 2;
            this.numGreen.ValueChanged += new System.EventHandler(this.numGreen_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "绿色：";
            // 
            // numBlue
            // 
            this.numBlue.Location = new System.Drawing.Point(60, 106);
            this.numBlue.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numBlue.Name = "numBlue";
            this.numBlue.Size = new System.Drawing.Size(200, 21);
            this.numBlue.TabIndex = 2;
            this.numBlue.ValueChanged += new System.EventHandler(this.numBlue_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "蓝色：";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(105, 133);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "设置";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 133);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbHz1
            // 
            this.cbHz1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHz1.FormattingEnabled = true;
            this.cbHz1.Location = new System.Drawing.Point(116, 13);
            this.cbHz1.Name = "cbHz1";
            this.cbHz1.Size = new System.Drawing.Size(97, 20);
            this.cbHz1.TabIndex = 7;
            // 
            // cbColorTempType1
            // 
            this.cbColorTempType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColorTempType1.FormattingEnabled = true;
            this.cbColorTempType1.Location = new System.Drawing.Point(219, 13);
            this.cbColorTempType1.Name = "cbColorTempType1";
            this.cbColorTempType1.Size = new System.Drawing.Size(121, 20);
            this.cbColorTempType1.TabIndex = 8;
            // 
            // FrmColorTemp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 176);
            this.ControlBox = false;
            this.Controls.Add(this.cbColorTempType1);
            this.Controls.Add(this.cbHz1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numBlue);
            this.Controls.Add(this.numGreen);
            this.Controls.Add(this.numRed);
            this.Controls.Add(this.cbChipType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmColorTemp";
            this.Text = "色温定义";
            this.Load += new System.EventHandler(this.FrmColorTemp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbChipType;
        private System.Windows.Forms.NumericUpDown numRed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numGreen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numBlue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbHz1;
        private System.Windows.Forms.ComboBox cbColorTempType1;
    }
}