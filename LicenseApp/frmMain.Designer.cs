namespace LicenseApp
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.protectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runProtectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeAKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabKeys = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreateKey = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnVerify = new System.Windows.Forms.Button();
            this.txtVerifyName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVerifyKey = new System.Windows.Forms.TextBox();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabKeys.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.protectToolStripMenuItem,
            this.keysToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(515, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.loadProjectToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // protectToolStripMenuItem
            // 
            this.protectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runProtectToolStripMenuItem});
            this.protectToolStripMenuItem.Name = "protectToolStripMenuItem";
            this.protectToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.protectToolStripMenuItem.Text = "Protect";
            // 
            // keysToolStripMenuItem
            // 
            this.keysToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makeAKeyToolStripMenuItem});
            this.keysToolStripMenuItem.Name = "keysToolStripMenuItem";
            this.keysToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.keysToolStripMenuItem.Text = "Keys";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newProjectToolStripMenuItem.Text = "New Project";
            // 
            // loadProjectToolStripMenuItem
            // 
            this.loadProjectToolStripMenuItem.Name = "loadProjectToolStripMenuItem";
            this.loadProjectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadProjectToolStripMenuItem.Text = "Load Project";
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveProjectToolStripMenuItem.Text = "Save Project";
            // 
            // runProtectToolStripMenuItem
            // 
            this.runProtectToolStripMenuItem.Name = "runProtectToolStripMenuItem";
            this.runProtectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.runProtectToolStripMenuItem.Text = "Run Protect";
            // 
            // makeAKeyToolStripMenuItem
            // 
            this.makeAKeyToolStripMenuItem.Name = "makeAKeyToolStripMenuItem";
            this.makeAKeyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.makeAKeyToolStripMenuItem.Text = "Make a Key";
            this.makeAKeyToolStripMenuItem.Click += new System.EventHandler(this.makeAKeyToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabKeys);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(491, 321);
            this.tabControl1.TabIndex = 1;
            // 
            // tabKeys
            // 
            this.tabKeys.Controls.Add(this.label5);
            this.tabKeys.Controls.Add(this.txtDays);
            this.tabKeys.Controls.Add(this.txtVerifyKey);
            this.tabKeys.Controls.Add(this.label3);
            this.tabKeys.Controls.Add(this.label4);
            this.tabKeys.Controls.Add(this.txtVerifyName);
            this.tabKeys.Controls.Add(this.btnVerify);
            this.tabKeys.Controls.Add(this.txtKey);
            this.tabKeys.Controls.Add(this.btnCreateKey);
            this.tabKeys.Controls.Add(this.label2);
            this.tabKeys.Controls.Add(this.txtName);
            this.tabKeys.Controls.Add(this.label1);
            this.tabKeys.Location = new System.Drawing.Point(4, 22);
            this.tabKeys.Name = "tabKeys";
            this.tabKeys.Padding = new System.Windows.Forms.Padding(3);
            this.tabKeys.Size = new System.Drawing.Size(483, 295);
            this.tabKeys.TabIndex = 0;
            this.tabKeys.Text = "Keys";
            this.tabKeys.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(483, 295);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(48, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(184, 20);
            this.txtName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Key:";
            // 
            // btnCreateKey
            // 
            this.btnCreateKey.Location = new System.Drawing.Point(340, 6);
            this.btnCreateKey.Name = "btnCreateKey";
            this.btnCreateKey.Size = new System.Drawing.Size(81, 23);
            this.btnCreateKey.TabIndex = 4;
            this.btnCreateKey.Text = "Create Key";
            this.btnCreateKey.UseVisualStyleBackColor = true;
            this.btnCreateKey.Click += new System.EventHandler(this.btnCreateKey_Click);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(48, 42);
            this.txtKey.Name = "txtKey";
            this.txtKey.ReadOnly = true;
            this.txtKey.Size = new System.Drawing.Size(286, 20);
            this.txtKey.TabIndex = 5;
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(253, 84);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(81, 23);
            this.btnVerify.TabIndex = 7;
            this.btnVerify.Text = "Verify Key";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click_1);
            // 
            // txtVerifyName
            // 
            this.txtVerifyName.Location = new System.Drawing.Point(48, 86);
            this.txtVerifyName.Name = "txtVerifyName";
            this.txtVerifyName.Size = new System.Drawing.Size(184, 20);
            this.txtVerifyName.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Key:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Name:";
            // 
            // txtVerifyKey
            // 
            this.txtVerifyKey.Location = new System.Drawing.Point(48, 116);
            this.txtVerifyKey.Name = "txtVerifyKey";
            this.txtVerifyKey.Size = new System.Drawing.Size(286, 20);
            this.txtVerifyKey.TabIndex = 12;
            // 
            // txtDays
            // 
            this.txtDays.Location = new System.Drawing.Point(288, 9);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(46, 20);
            this.txtDays.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Days:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(515, 360);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "License App";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabKeys.ResumeLayout(false);
            this.tabKeys.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem protectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runProtectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeAKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabKeys;
        private System.Windows.Forms.Button btnCreateKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtVerifyKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVerifyName;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDays;
    }
}

