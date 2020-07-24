namespace MacroScript
{
    partial class adbfiles
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
            this.txt_dir = new System.Windows.Forms.TextBox();
            this.btn_Back = new System.Windows.Forms.Button();
            this.listbox_filesDir = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txt_dir
            // 
            this.txt_dir.Location = new System.Drawing.Point(12, 12);
            this.txt_dir.Name = "txt_dir";
            this.txt_dir.Size = new System.Drawing.Size(253, 20);
            this.txt_dir.TabIndex = 2;
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(271, 11);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(57, 20);
            this.btn_Back.TabIndex = 3;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = true;
            // 
            // listbox_filesDir
            // 
            this.listbox_filesDir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listbox_filesDir.FormattingEnabled = true;
            this.listbox_filesDir.HorizontalScrollbar = true;
            this.listbox_filesDir.Location = new System.Drawing.Point(12, 41);
            this.listbox_filesDir.Name = "listbox_filesDir";
            this.listbox_filesDir.Size = new System.Drawing.Size(309, 264);
            this.listbox_filesDir.TabIndex = 4;
            this.listbox_filesDir.SelectedIndexChanged += new System.EventHandler(this.listbox_filesDir_SelectedIndexChanged);
            // 
            // adbfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 317);
            this.Controls.Add(this.listbox_filesDir);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.txt_dir);
            this.Name = "adbfiles";
            this.Text = "adbfiles";
            this.Load += new System.EventHandler(this.adbfiles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_dir;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.ListBox listbox_filesDir;
    }
}