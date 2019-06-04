namespace LYDTOPDP
{
    partial class BetaVersionTipForm
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
            this.lblTip1 = new System.Windows.Forms.Label();
            this.richTextTip = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTelphone = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTip1
            // 
            this.lblTip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTip1.Font = new System.Drawing.Font("宋体", 48F, System.Drawing.FontStyle.Bold);
            this.lblTip1.ForeColor = System.Drawing.Color.Red;
            this.lblTip1.Location = new System.Drawing.Point(12, 9);
            this.lblTip1.Name = "lblTip1";
            this.lblTip1.Size = new System.Drawing.Size(959, 68);
            this.lblTip1.TabIndex = 1;
            this.lblTip1.Text = "研发内部测试版本，慎重使用！";
            // 
            // richTextTip
            // 
            this.richTextTip.Font = new System.Drawing.Font("宋体", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextTip.ForeColor = System.Drawing.Color.Green;
            this.richTextTip.Location = new System.Drawing.Point(23, 80);
            this.richTextTip.Name = "richTextTip";
            this.richTextTip.ReadOnly = true;
            this.richTextTip.Size = new System.Drawing.Size(940, 383);
            this.richTextTip.TabIndex = 2;
            this.richTextTip.Text = "测试文本测试文本测试文本测试文本测试文本测试文本测试文本测试文本测试文本测试文本测试文本";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(607, 466);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "联系人：";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAuthor.Location = new System.Drawing.Point(723, 466);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(85, 24);
            this.lblAuthor.TabIndex = 3;
            this.lblAuthor.Text = "某某某";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(607, 495);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "电话：";
            // 
            // lblTelphone
            // 
            this.lblTelphone.AutoSize = true;
            this.lblTelphone.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTelphone.Location = new System.Drawing.Point(723, 495);
            this.lblTelphone.Name = "lblTelphone";
            this.lblTelphone.Size = new System.Drawing.Size(153, 24);
            this.lblTelphone.TabIndex = 3;
            this.lblTelphone.Text = "13888888888";
            // 
            // BetaVersionTipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 543);
            this.Controls.Add(this.lblTelphone);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextTip);
            this.Controls.Add(this.lblTip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BetaVersionTipForm";
            this.Text = "提示";
            this.Load += new System.EventHandler(this.BetaVersionTipForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RichTextBox richTextTip;
        public System.Windows.Forms.Label lblTip1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblTelphone;


    }
}