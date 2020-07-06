namespace MacroScript
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Panel_readfile = new System.Windows.Forms.FlowLayoutPanel();
            this.txt_readfiles = new System.Windows.Forms.TextBox();
            this.txt_DirFiles = new System.Windows.Forms.TextBox();
            this.txt_ProcessName = new System.Windows.Forms.TextBox();
            this.list_ProcessName = new System.Windows.Forms.ListBox();
            this.list_txtFiles = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Panel_readfile
            // 
            this.Panel_readfile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_readfile.AutoScroll = true;
            this.Panel_readfile.Location = new System.Drawing.Point(238, 64);
            this.Panel_readfile.Name = "Panel_readfile";
            this.Panel_readfile.Size = new System.Drawing.Size(228, 170);
            this.Panel_readfile.TabIndex = 1;
            // 
            // txt_readfiles
            // 
            this.txt_readfiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_readfiles.Location = new System.Drawing.Point(238, 240);
            this.txt_readfiles.Multiline = true;
            this.txt_readfiles.Name = "txt_readfiles";
            this.txt_readfiles.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_readfiles.Size = new System.Drawing.Size(228, 99);
            this.txt_readfiles.TabIndex = 2;
            // 
            // txt_DirFiles
            // 
            this.txt_DirFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_DirFiles.Location = new System.Drawing.Point(238, 12);
            this.txt_DirFiles.Name = "txt_DirFiles";
            this.txt_DirFiles.Size = new System.Drawing.Size(228, 20);
            this.txt_DirFiles.TabIndex = 3;
            // 
            // txt_ProcessName
            // 
            this.txt_ProcessName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ProcessName.Location = new System.Drawing.Point(238, 38);
            this.txt_ProcessName.Name = "txt_ProcessName";
            this.txt_ProcessName.Size = new System.Drawing.Size(228, 20);
            this.txt_ProcessName.TabIndex = 4;
            // 
            // list_ProcessName
            // 
            this.list_ProcessName.Dock = System.Windows.Forms.DockStyle.Right;
            this.list_ProcessName.FormattingEnabled = true;
            this.list_ProcessName.Location = new System.Drawing.Point(472, 0);
            this.list_ProcessName.Name = "list_ProcessName";
            this.list_ProcessName.Size = new System.Drawing.Size(240, 339);
            this.list_ProcessName.Sorted = true;
            this.list_ProcessName.TabIndex = 6;
            this.list_ProcessName.SelectedIndexChanged += new System.EventHandler(this.list_ProcessName_SelectedIndexChanged);
            // 
            // list_txtFiles
            // 
            this.list_txtFiles.Dock = System.Windows.Forms.DockStyle.Left;
            this.list_txtFiles.FormattingEnabled = true;
            this.list_txtFiles.Location = new System.Drawing.Point(0, 0);
            this.list_txtFiles.Name = "list_txtFiles";
            this.list_txtFiles.Size = new System.Drawing.Size(232, 339);
            this.list_txtFiles.Sorted = true;
            this.list_txtFiles.TabIndex = 7;
            this.list_txtFiles.SelectedIndexChanged += new System.EventHandler(this.list_txtFiles_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 339);
            this.Controls.Add(this.list_txtFiles);
            this.Controls.Add(this.list_ProcessName);
            this.Controls.Add(this.txt_ProcessName);
            this.Controls.Add(this.txt_DirFiles);
            this.Controls.Add(this.txt_readfiles);
            this.Controls.Add(this.Panel_readfile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MacroScript";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel Panel_readfile;
        private System.Windows.Forms.TextBox txt_readfiles;
        private System.Windows.Forms.TextBox txt_DirFiles;
        private System.Windows.Forms.TextBox txt_ProcessName;
        private System.Windows.Forms.ListBox list_ProcessName;
        private System.Windows.Forms.ListBox list_txtFiles;
    }
}

