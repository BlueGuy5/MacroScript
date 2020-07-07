using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacroScript
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string username = Environment.UserName;
                txt_DirFiles.Text = @"C:\Users\" + username + @"\Documents\MacroScript\";

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "UserName Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            txt_ProcessName.Text = "(input process name)";
            getProcessList();
            getTxtFiles();
        }
        public void Set_window_to_forground(string keys)
        {
            int chars = 256;
            StringBuilder buff = new StringBuilder(chars);

            // Obtain the handle of the active window.
            IntPtr handle = GetForegroundWindow();

            Process[] prc = Process.GetProcessesByName(txt_ProcessName.Text);
            if (prc.Length > 0)
            {
                //set window to foreground
                SetForegroundWindow(prc[0].MainWindowHandle);
                // Update the controls.
                if (GetWindowText(handle, buff, chars) > 0)
                {
                    Thread.Sleep(1);
                    SendKeys.SendWait(keys);
                    SendKeys.Send("{Enter}");
                }              
            }
            else
            {
                MessageBox.Show("Process not found: " + txt_ProcessName.Text, "Set_window_to_forground", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void getProcessList()
        {
            foreach(Process proc in Process.GetProcesses())
            {
                list_ProcessName.Items.Add(proc.ProcessName);
            }
        }
        private string[] retDir()
        {
           string[] files = System.IO.Directory.GetFiles(txt_DirFiles.Text);
            return files;
        }
        private void getTxtFiles()
        {
            try
            {
                foreach (string file in retDir())
                {
                    list_txtFiles.Items.Add(file.Replace(txt_DirFiles.Text, ""));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "getTxtFiles()", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void readTxtFiles(object sender, EventArgs e)
        {
            string fullpath = txt_DirFiles.Text + list_txtFiles.SelectedItem;
            var linesToSort = new List<string>();

            string[] lines = System.IO.File.ReadAllLines(fullpath);
            foreach (string line in lines)
            {
                linesToSort.Add(line);
            }
            linesToSort.Sort();
            foreach (string line in linesToSort)
            {
                txt_readfiles.AppendText(line + "\r\n");
                Button btn_line = new Button();
                btn_line.Text = line;
                btn_line.AutoSize = true;
                btn_line.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                btn_line.Height = 25;
                btn_line.Click += new EventHandler(writeCMD);
                Panel_readfile.Controls.Add(btn_line);
            }
        }
        private void writeCMD(object sender, EventArgs e)
        {
            Button btn_key = (Button)sender;
            Set_window_to_forground(btn_key.Text);
        }

        private void list_ProcessName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(list_ProcessName.SelectedIndex >= 0)
            {
                txt_ProcessName.Text = list_ProcessName.SelectedItem.ToString();
            }
        }
        private void list_txtFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_txtFiles.SelectedIndex >= 0)
            {
                txt_readfiles.Text = "";
                Panel_readfile.Controls.Clear();
                readTxtFiles(sender, e);
            }
        }
    }
}
