namespace TLWController
{
    partial class FrmCreateSN
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
            this.txtSN1 = new System.Windows.Forms.TextBox();
            this.lblUp = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDown = new System.Windows.Forms.Label();
            this.txtSN2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtSN1
            // 
            this.txtSN1.Location = new System.Drawing.Point(71, 21);
            this.txtSN1.MaxLength = 20;
            this.txtSN1.Name = "txtSN1";
            this.txtSN1.Size = new System.Drawing.Size(190, 21);
            this.txtSN1.TabIndex = 0;
            // 
            // lblUp
            // 
            this.lblUp.AutoSize = true;
            this.lblUp.Location = new System.Drawing.Point(12, 24);
            this.lblUp.Name = "lblUp";
            this.lblUp.Size = new System.Drawing.Size(53, 12);
            this.lblUp.TabIndex = 1;
            this.lblUp.Text = "上灯板：";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(102, 78);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "生成";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(184, 78);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblDown
            // 
            this.lblDown.AutoSize = true;
            this.lblDown.Location = new System.Drawing.Point(12, 51);
            this.lblDown.Name = "lblDown";
            this.lblDown.Size = new System.Drawing.Size(53, 12);
            this.lblDown.TabIndex = 5;
            this.lblDown.Text = "下灯板：";
            // 
            // txtSN2
            // 
            this.txtSN2.Location = new System.Drawing.Point(71, 48);
            this.txtSN2.MaxLength = 20;
            this.txtSN2.Name = "txtSN2";
            this.txtSN2.Size = new System.Drawing.Size(190, 21);
            this.txtSN2.TabIndex = 4;
            // 
            // FrmCreateSN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(270, 113);
            this.ControlBox = false;
            this.Controls.Add(this.lblDown);
            this.Controls.Add(this.txtSN2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lblUp);
            this.Controls.Add(this.txtSN1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCreateSN";
            this.ShowInTaskbar = false;
            this.Text = "自定义时间码";
            this.Load += new System.EventHandler(this.FrmCreateSN_Load);
            this.Shown += new System.EventHandler(this.FrmCreateSN_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSN1;
        private System.Windows.Forms.Label lblUp;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDown;
        private System.Windows.Forms.TextBox txtSN2;
    }
}