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
            this.list_txtFiles = new System.Windows.Forms.ListBox();
            this.pic_open = new System.Windows.Forms.PictureBox();
            this.pic_PlayButton = new System.Windows.Forms.PictureBox();
            this.pic_reload = new System.Windows.Forms.PictureBox();
            this.DropDown_Process = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.btn_GetFileDir = new System.Windows.Forms.Button();
            this.btn_adb_click = new System.Windows.Forms.Button();
            this.listBox_CustomMacro = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_open)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_PlayButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_reload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DropDown_Process)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel_readfile
            // 
            this.Panel_readfile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_readfile.AutoScroll = true;
            this.Panel_readfile.ForeColor = System.Drawing.Color.White;
            this.Panel_readfile.Location = new System.Drawing.Point(240, 55);
            this.Panel_readfile.Name = "Panel_readfile";
            this.Panel_readfile.Size = new System.Drawing.Size(289, 154);
            this.Panel_readfile.TabIndex = 1;
            // 
            // txt_readfiles
            // 
            this.txt_readfiles.AllowDrop = true;
            this.txt_readfiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_readfiles.BackColor = System.Drawing.Color.Silver;
            this.txt_readfiles.Location = new System.Drawing.Point(239, 215);
            this.txt_readfiles.Multiline = true;
            this.txt_readfiles.Name = "txt_readfiles";
            this.txt_readfiles.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_readfiles.Size = new System.Drawing.Size(290, 148);
            this.txt_readfiles.TabIndex = 2;
            // 
            // txt_DirFiles
            // 
            this.txt_DirFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_DirFiles.BackColor = System.Drawing.Color.Silver;
            this.txt_DirFiles.Location = new System.Drawing.Point(239, 2);
            this.txt_DirFiles.Name = "txt_DirFiles";
            this.txt_DirFiles.Size = new System.Drawing.Size(290, 20);
            this.txt_DirFiles.TabIndex = 3;
            // 
            // list_txtFiles
            // 
            this.list_txtFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.list_txtFiles.BackColor = System.Drawing.Color.Silver;
            this.list_txtFiles.FormattingEnabled = true;
            this.list_txtFiles.Location = new System.Drawing.Point(2, 4);
            this.list_txtFiles.Name = "list_txtFiles";
            this.list_txtFiles.Size = new System.Drawing.Size(232, 199);
            this.list_txtFiles.Sorted = true;
            this.list_txtFiles.TabIndex = 7;
            this.list_txtFiles.SelectedIndexChanged += new System.EventHandler(this.list_txtFiles_SelectedIndexChanged);
            // 
            // pic_open
            // 
            this.pic_open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_open.BackgroundImage = global::MacroScript.Properties.Resources.folderimg;
            this.pic_open.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_open.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_open.Location = new System.Drawing.Point(535, 2);
            this.pic_open.Name = "pic_open";
            this.pic_open.Size = new System.Drawing.Size(28, 18);
            this.pic_open.TabIndex = 13;
            this.pic_open.TabStop = false;
            this.pic_open.Click += new System.EventHandler(this.pic_open_Click);
            // 
            // pic_PlayButton
            // 
            this.pic_PlayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_PlayButton.BackgroundImage = global::MacroScript.Properties.Resources.playbutton;
            this.pic_PlayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_PlayButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_PlayButton.Location = new System.Drawing.Point(535, 215);
            this.pic_PlayButton.Name = "pic_PlayButton";
            this.pic_PlayButton.Size = new System.Drawing.Size(30, 21);
            this.pic_PlayButton.TabIndex = 12;
            this.pic_PlayButton.TabStop = false;
            this.pic_PlayButton.Click += new System.EventHandler(this.pic_PlayButton_Click);
            // 
            // pic_reload
            // 
            this.pic_reload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_reload.BackgroundImage = global::MacroScript.Properties.Resources.macros_512;
            this.pic_reload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_reload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_reload.Location = new System.Drawing.Point(535, 28);
            this.pic_reload.Name = "pic_reload";
            this.pic_reload.Size = new System.Drawing.Size(28, 21);
            this.pic_reload.TabIndex = 11;
            this.pic_reload.TabStop = false;
            this.pic_reload.Click += new System.EventHandler(this.pic_Reload_Click);
            // 
            // DropDown_Process
            // 
            this.DropDown_Process.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DropDown_Process.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.DropDown_Process.BeforeTouchSize = new System.Drawing.Size(290, 19);
            this.DropDown_Process.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.DropDown_Process.Location = new System.Drawing.Point(239, 28);
            this.DropDown_Process.Name = "DropDown_Process";
            this.DropDown_Process.Size = new System.Drawing.Size(290, 19);
            this.DropDown_Process.Sorted = true;
            this.DropDown_Process.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black;
            this.DropDown_Process.TabIndex = 14;
            this.DropDown_Process.Text = "{Input Process Name}";
            this.DropDown_Process.ThemeName = "Office2016Black";
            this.DropDown_Process.DropDown += new System.EventHandler(this.DropDown_Process_Click);
            this.DropDown_Process.TextChanged += new System.EventHandler(this.Drodown_Process_First_TextChange);
            // 
            // btn_GetFileDir
            // 
            this.btn_GetFileDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_GetFileDir.Location = new System.Drawing.Point(533, 242);
            this.btn_GetFileDir.Name = "btn_GetFileDir";
            this.btn_GetFileDir.Size = new System.Drawing.Size(32, 28);
            this.btn_GetFileDir.TabIndex = 15;
            this.btn_GetFileDir.Text = "FW";
            this.btn_GetFileDir.UseVisualStyleBackColor = true;
            this.btn_GetFileDir.Click += new System.EventHandler(this.btn_GetFileDir_Click);
            // 
            // btn_adb_click
            // 
            this.btn_adb_click.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_adb_click.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_adb_click.Location = new System.Drawing.Point(533, 276);
            this.btn_adb_click.Name = "btn_adb_click";
            this.btn_adb_click.Size = new System.Drawing.Size(32, 28);
            this.btn_adb_click.TabIndex = 16;
            this.btn_adb_click.Text = "adb";
            this.btn_adb_click.UseVisualStyleBackColor = true;
            this.btn_adb_click.Click += new System.EventHandler(this.adb_Click);
            // 
            // listBox_CustomMacro
            // 
            this.listBox_CustomMacro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox_CustomMacro.BackColor = System.Drawing.Color.Silver;
            this.listBox_CustomMacro.FormattingEnabled = true;
            this.listBox_CustomMacro.Location = new System.Drawing.Point(2, 215);
            this.listBox_CustomMacro.Name = "listBox_CustomMacro";
            this.listBox_CustomMacro.Size = new System.Drawing.Size(231, 147);
            this.listBox_CustomMacro.Sorted = true;
            this.listBox_CustomMacro.TabIndex = 17;
            this.listBox_CustomMacro.SelectedIndexChanged += new System.EventHandler(this.listBox_CustomMacro_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(570, 371);
            this.Controls.Add(this.listBox_CustomMacro);
            this.Controls.Add(this.btn_adb_click);
            this.Controls.Add(this.btn_GetFileDir);
            this.Controls.Add(this.DropDown_Process);
            this.Controls.Add(this.pic_open);
            this.Controls.Add(this.pic_PlayButton);
            this.Controls.Add(this.pic_reload);
            this.Controls.Add(this.list_txtFiles);
            this.Controls.Add(this.txt_DirFiles);
            this.Controls.Add(this.txt_readfiles);
            this.Controls.Add(this.Panel_readfile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MacroScript";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_open)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_PlayButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_reload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DropDown_Process)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel Panel_readfile;
        private System.Windows.Forms.TextBox txt_DirFiles;
        private System.Windows.Forms.ListBox list_txtFiles;
        private System.Windows.Forms.PictureBox pic_reload;
        private System.Windows.Forms.PictureBox pic_PlayButton;
        private System.Windows.Forms.PictureBox pic_open;
        private System.Windows.Forms.Button btn_GetFileDir;
        public System.Windows.Forms.TextBox txt_readfiles;
        private System.Windows.Forms.Button btn_adb_click;
        public Syncfusion.Windows.Forms.Tools.ComboBoxAdv DropDown_Process;
        private System.Windows.Forms.ListBox listBox_CustomMacro;
    }
}

