using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacroScript
{
    public partial class adbfiles : Form
    {
        public adbfiles()
        {
            InitializeComponent();
        }

        private void adbfiles_Load(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["Form1"];
            var Access_txtReadLines = ((Form1)f);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(f.Location.X + f.Size.Width - 300, f.Location.Y);

            try
            {
                string username = Environment.UserName;
                txt_dir.Text = @"C:\Users\" + username + @"\Documents\ADB Packs\";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, txt_dir.Text + " Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            adbGetPacks();
        }
        private void adbGetPacks()
        {
            var getFileDir = System.IO.Directory.GetFiles(txt_dir.Text,"*.*", System.IO.SearchOption.AllDirectories).Where(s => s.EndsWith(".apk",StringComparison.OrdinalIgnoreCase));
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
            if (listview_filesDir.SelectedIndices[0] >= 0)
            {
                string username = Environment.UserName;
                Form f = Application.OpenForms["Form1"];
                var Access_Form1 = ((Form1)f);
                if (Access_Form1.txt_readfiles.Lines.Length > 0)
                {
                    Access_Form1.txt_readfiles.Text = Access_Form1.txt_readfiles.Lines[0];
                    Access_Form1.txt_readfiles.Text = Access_Form1.txt_readfiles.Lines[0] + "\r\n" + txt_dir.Text + listview_filesDir.SelectedItems[0].Text;
                    startCMD(@"C:\Users\" + username + @"\Desktop\Alexa Logs\Logcat\");
                    this.Dispose();
                    this.Close();
                    Access_Form1.DropDown_Process.Text = "cmd";
                }
            }
        }
        private void startCMD(string adbPath)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.WorkingDirectory = adbPath;           
                p.StartInfo.UseShellExecute = false;
                p.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + "Path:" + adbPath, "startCMD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
