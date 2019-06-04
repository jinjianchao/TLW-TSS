namespace LYDTOPDP
{
    partial class PluginManagerForm
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
            this.listNotUsedPg = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.treeMenu = new System.Windows.Forms.TreeView();
            this.btnToLeft = new System.Windows.Forms.Button();
            this.btnToRight = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnAddMenu = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listNotUsedPg
            // 
            this.listNotUsedPg.BackColor = System.Drawing.Color.LemonChiffon;
            this.listNotUsedPg.FormattingEnabled = true;
            this.listNotUsedPg.ItemHeight = 12;
            this.listNotUsedPg.Location = new System.Drawing.Point(312, 49);
            this.listNotUsedPg.Name = "listNotUsedPg";
            this.listNotUsedPg.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listNotUsedPg.Size = new System.Drawing.Size(233, 400);
            this.listNotUsedPg.TabIndex = 0;
            this.listNotUsedPg.SelectedIndexChanged += new System.EventHandler(this.listNotUsedPg_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Menu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Plugin";
            // 
            // treeMenu
            // 
            this.treeMenu.BackColor = System.Drawing.Color.LemonChiffon;
            this.treeMenu.Location = new System.Drawing.Point(3, 49);
            this.treeMenu.Name = "treeMenu";
            this.treeMenu.Size = new System.Drawing.Size(233, 404);
            this.treeMenu.TabIndex = 4;
            this.treeMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeMenu_AfterSelect);
            // 
            // btnToLeft
            // 
            this.btnToLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToLeft.Location = new System.Drawing.Point(242, 191);
            this.btnToLeft.Name = "btnToLeft";
            this.btnToLeft.Size = new System.Drawing.Size(63, 23);
            this.btnToLeft.TabIndex = 5;
            this.btnToLeft.Text = "<<";
            this.btnToLeft.UseVisualStyleBackColor = true;
            this.btnToLeft.Click += new System.EventHandler(this.btnToLeft_Click);
            // 
            // btnToRight
            // 
            this.btnToRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToRight.Location = new System.Drawing.Point(242, 222);
            this.btnToRight.Name = "btnToRight";
            this.btnToRight.Size = new System.Drawing.Size(63, 23);
            this.btnToRight.TabIndex = 6;
            this.btnToRight.Text = ">>";
            this.btnToRight.UseVisualStyleBackColor = true;
            this.btnToRight.Click += new System.EventHandler(this.btnToRight_Click);
            // 
            // btnUp
            // 
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Location = new System.Drawing.Point(242, 251);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(63, 23);
            this.btnUp.TabIndex = 7;
            this.btnUp.Text = "Move UP";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Visible = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Location = new System.Drawing.Point(242, 280);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(63, 23);
            this.btnDown.TabIndex = 8;
            this.btnDown.Text = "Mouse Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Visible = false;
            // 
            // btnAddMenu
            // 
            this.btnAddMenu.AutoSize = true;
            this.btnAddMenu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddMenu.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddMenu.Location = new System.Drawing.Point(4, 26);
            this.btnAddMenu.Name = "btnAddMenu";
            this.btnAddMenu.Size = new System.Drawing.Size(22, 22);
            this.btnAddMenu.TabIndex = 9;
            this.btnAddMenu.Text = "+";
            this.btnAddMenu.UseVisualStyleBackColor = true;
            this.btnAddMenu.Click += new System.EventHandler(this.btnAddMenu_Click);
            // 
            // button6
            // 
            this.button6.AutoSize = true;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button6.Location = new System.Drawing.Point(25, 26);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(22, 22);
            this.button6.TabIndex = 10;
            this.button6.Text = "-";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnApply
            // 
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Location = new System.Drawing.Point(385, 455);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 11;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(466, 455);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 11;
            this.button8.Text = "Cancel";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // PluginManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(549, 483);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.btnAddMenu);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnToRight);
            this.Controls.Add(this.btnToLeft);
            this.Controls.Add(this.treeMenu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listNotUsedPg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PluginManagerForm";
            this.Text = "插件管理";
            this.Load += new System.EventHandler(this.PluginManagerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listNotUsedPg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeMenu;
        private System.Windows.Forms.Button btnToLeft;
        private System.Windows.Forms.Button btnToRight;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnAddMenu;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button button8;
    }
}