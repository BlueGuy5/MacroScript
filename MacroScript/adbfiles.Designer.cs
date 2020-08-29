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
            this.listview_filesDir = new System.Windows.Forms.ListView();
            this.clm_file = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clm_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            // listview_filesDir
            // 
            this.listview_filesDir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listview_filesDir.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clm_file,
            this.clm_date});
            this.listview_filesDir.FullRowSelect = true;
            this.listview_filesDir.GridLines = true;
            this.listview_filesDir.HideSelection = false;
            this.listview_filesDir.Location = new System.Drawing.Point(12, 41);
            this.listview_filesDir.Name = "listview_filesDir";
            this.listview_filesDir.Size = new System.Drawing.Size(377, 264);
            this.listview_filesDir.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listview_filesDir.TabIndex = 5;
            this.listview_filesDir.UseCompatibleStateImageBehavior = false;
            this.listview_filesDir.View = System.Windows.Forms.View.Details;
            this.listview_filesDir.SelectedIndexChanged += new System.EventHandler(this.listview_filesDir_SelectedIndexChanged);
            // 
            // clm_file
            // 
            this.clm_file.Text = "File";
            this.clm_file.Width = 221;
            // 
            // clm_date
            // 
            this.clm_date.Text = "Date";
            this.clm_date.Width = 125;
            // 
            // adbfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 317);
            this.Controls.Add(this.listview_filesDir);
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
        private System.Windows.Forms.ListView listview_filesDir;
        private System.Windows.Forms.ColumnHeader clm_file;
        private System.Windows.Forms.ColumnHeader clm_date;
    }
}