using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacroScript
{
    public partial class FileDir : Form
    {
        public FileDir()
        {
            InitializeComponent();
        }

        private void FileDir_Load(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["Form1"];
            var Access_txtReadLines = ((Form1)f);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(f.Location.X + f.Size.Width - 300, f.Location.Y);

            try
            {
                string username = Environment.UserName;
                txt_dir.Text = @"C:\Users\" + username + @"\Documents\FW\";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, txt_dir.Text + " Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            getFWnum();
        }
        
        private void getFWnum()
        {
            string[] getFWdir = System.IO.Directory.GetDirectories(txt_dir.Text);
            DateTime Lastmodified;
            listview_filesDir.Items.Clear();
            foreach(string fw in getFWdir)
            {
                //listbox_filesDir.Items.Add(fw.Replace(txt_dir.Text, ""));
                Lastmodified = System.IO.File.GetLastWriteTime(fw);
                listview_filesDir.Items.Add(fw.Replace(txt_dir.Text, "")).SubItems.Add(Lastmodified.ToString());
            }
        }
        private void getFiles(string fw)
        {
            string file = "MIC_FR_Delta3.xlsx";
            string[] getFileDir = System.IO.Directory.GetFiles(txt_dir.Text + fw, file, System.IO.SearchOption.AllDirectories);
            DateTime Lastmodified;
            listview_filesDir.Items.Clear();
            foreach (string dir in getFileDir)
            {
                Lastmodified = System.IO.File.GetLastWriteTime(dir);
                listview_filesDir.Items.Add(dir.Replace(txt_dir.Text, "")).SubItems.Add(Lastmodified.ToString());
            }
        }
        private void listview_filesDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fw = "";
            if (listview_filesDir.SelectedIndices[0] >= 0)
            {
                fw = listview_filesDir.SelectedItems[0].Text;

                if (listview_filesDir.SelectedItems[0].Text.Length == 4)
                {
                    getFiles(fw);
                }
                else
                {
                    Form f = Application.OpenForms["Form1"];
                    var Access_txtReadLines = ((Form1)f);
                    if (Access_txtReadLines.txt_readfiles.Lines.Length > 0)
                    {
                        Access_txtReadLines.txt_readfiles.Text = Access_txtReadLines.txt_readfiles.Lines[0];
                        Access_txtReadLines.txt_readfiles.Text = Access_txtReadLines.txt_readfiles.Lines[0] + "\r\n" + "\"" + txt_dir.Text + listview_filesDir.SelectedItems[0].Text + "\"";
                        startCMD(txt_dir.Text + fw.Replace(@"\tools\MIC_FR_Delta3.xlsx", ""));
                        this.Dispose();
                        this.Close();
                        Access_txtReadLines.DropDown_Process.Text = "cmd";
                    }
                }
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            getFWnum();
        }
        private void startCMD(string fw)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.WorkingDirectory = fw;
                p.StartInfo.UseShellExecute = false;
                p.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + "Path:" + fw, "startCMD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
