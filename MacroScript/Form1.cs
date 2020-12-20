using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

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
            this.KeyDown += new KeyEventHandler(OpenSerialTerminal);
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
                MessageBox.Show(ex.Message, txt_DirFiles.Text + " Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            getPorts();
            getProcessList();
            getTxtFiles();
            getCustomMacroFiles();
        }
        SerialTerminal ST = new SerialTerminal();
        private void OpenSerialTerminal(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                ST.Show();
                ST.BringToFront();
            }
        }
        private void getPorts()
        {
            try
            {
                string[] ports = SerialPort.GetPortNames();
                txt_Ports.Text = string.Empty;
                foreach(string port in ports)
                {
                    txt_Ports.AppendText(port + "\r\n");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "getPorts()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DropDown_Process_Click(object sender, EventArgs e)
        {
            getProcessList();
        }
        private void Drodown_Process_First_TextChange(object sender, EventArgs e)
        {
            if (DropDown_Process.Text.Length == 1)
            {
                getProcessList();
            }
        }
        private void getProcessList()
        {
            DropDown_Process.Items.Clear();
            foreach(Process proc in Process.GetProcesses())
            {
                foreach (string list_proc in WhiteList_Process())
                {
                    if (proc.ProcessName == list_proc)
                    {
                        DropDown_Process.Items.Add(proc.ProcessName);
                        break;
                        
                    }
                }
            }
            DropDown_Process.MaxDropDownItems = DropDown_Process.Items.Count;
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
                list_txtFiles.Items.Clear();
                list_txtFiles.Items.Add("All Commands");
                foreach (string file in retDir())
                {
                    if (file.IndexOf("CustomMacro") < 0)
                    {                     
                        list_txtFiles.Items.Add(file.Replace(txt_DirFiles.Text, ""));
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "getTxtFiles()", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void getCustomMacroFiles()
        {
            try
            {
                listBox_CustomMacro.Items.Clear();
                foreach (string file in retDir())
                {
                    if (file.IndexOf("CustomMacro") >= 0)
                    {                    
                        listBox_CustomMacro.Items.Add(file.Replace(txt_DirFiles.Text, ""));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "getCustomMacroFiles()", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void readTxtFiles(object sender, EventArgs e)
        {
            if (sender.ToString() == "All Commands")
            {
                var list_cmd = new List<string>();
                foreach (string file in retDir())
                {
                    if (file.IndexOf("CustomMacro") < 0)
                    {
                        foreach(string line in System.IO.File.ReadLines(file))
                        {
                            list_cmd.Add(line);
                        }
                    }
                }
                list_cmd.Sort();
                foreach (string cmd in list_cmd)
                {
                    Button btn_line = new Button();
                    btn_line.Text = cmd;
                    btn_line.AutoSize = true;
                    btn_line.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    btn_line.Height = 25;
                    btn_line.Click += new EventHandler(writeCMD);
                    Panel_readfile.Controls.Add(btn_line);
                    txt_readfiles.AppendText(cmd + "\r\n");
                }
            }
            else
            {
                //string fullpath = txt_DirFiles.Text + list_txtFiles.SelectedItem;
                string fullpath = txt_DirFiles.Text + sender.ToString();
                var linesToSort = new List<string>();
                string[] lines = System.IO.File.ReadAllLines(fullpath);

                //cntlines and currentlines are included so we won't create a new line at the end of the file
                int cntlines = 0;
                int currentlines = 1;
                foreach (string line in lines)
                {
                    cntlines++;
                }
                foreach (string line in lines)
                {
                    linesToSort.Add(line);
                    if (currentlines == cntlines)
                    {
                        txt_readfiles.AppendText(line);
                    }
                    else
                    {
                        txt_readfiles.AppendText(line + "\r\n");
                        currentlines++;
                    }
                }

                linesToSort.Sort();
                foreach (string line in linesToSort)
                {
                    Button btn_line = new Button();
                    btn_line.Text = line;
                    btn_line.AutoSize = true;
                    btn_line.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    btn_line.Height = 25;
                    btn_line.Click += new EventHandler(writeCMD);
                    Panel_readfile.Controls.Add(btn_line);
                }
            }
        }

        private void list_txtFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_txtFiles.SelectedIndex >= 0)
            {
                saveCustomMacro = false;
                listBox_CustomMacro.SelectedItem = false;
                txt_readfiles.Text = "";
                Panel_readfile.Controls.Clear();
                readTxtFiles(list_txtFiles.SelectedItem, e);
                DropDown_Process.Text = "ttermpro";
            }
        }

        private void listBox_CustomMacro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_CustomMacro.SelectedIndex >= 0)
            {
                saveCustomMacro = true;
                list_txtFiles.SelectedItem = false;
                txt_readfiles.Text = "";
                Panel_readfile.Controls.Clear();
                readTxtFiles(listBox_CustomMacro.SelectedItem, e);
            }
        }

        private void pic_Reload_Click(object sender, EventArgs e)
        {
            getPorts();
            getProcessList();
            getTxtFiles();
        }     

        private void pic_open_Click(object sender, EventArgs e)
        {
            Process.Start(txt_DirFiles.Text);
        }

        private void btn_GetFileDir_Click(object sender, EventArgs e)
        {
            FileDir _fileDir = new FileDir();
            _fileDir.Show();
        }
        private void adb_Click(object sender, EventArgs e)
        {
            adbfiles _adbfiles = new adbfiles();
            _adbfiles.Show();
        }
        private List<string> WhiteList_Process()
        {
            var list_Whitelist = new List<string>();
            list_Whitelist.Add("notepad");
            list_Whitelist.Add("cmd");
            list_Whitelist.Add("ttermpro");
            list_Whitelist.Add("BTC");
            return list_Whitelist;
        }
        private int checkProcDuplicate()
        {
            string TargetProcessName = DropDown_Process.Text;
            int processNameCnt = 0;
            foreach(Process processName in Process.GetProcesses())
            {
                if(processName.ProcessName == TargetProcessName)
                {
                    processNameCnt++;
                }
            }
            return processNameCnt;
        }
        private void playFunction()
        {
            string fullpath = txt_DirFiles.Text + listBox_CustomMacro.SelectedItem;
            if (fullpath.IndexOf("CustomMacro") >= 0)
            {
                if (checkProcDuplicate() <= 1)
                {
                    //read from textbox instead of textfile
                    foreach (string line in txt_readfiles.Lines)
                    {
                        if (Set_window_to_forground() == true)
                        {
                            runMacro(line);
                        }
                        else
                        {
                            break;
                        }
                    }
                    try
                    {
                        if (saveCustomMacro == true)
                        {
                            System.IO.File.WriteAllLines(fullpath, txt_readfiles.Lines);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "btn_Run_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Duplicate Proccess Detected: " + checkProcDuplicate().ToString(), DropDown_Process.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Must Select CustomMacro.txt", "Wrong File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        bool saveCustomMacro = false;
        private void pic_PlayButton_Click(object sender, EventArgs e)
        {
            DialogResult msgresults;
            if (DropDown_Process.Text != "cmd")
            {
                msgresults = MessageBox.Show("Target Process: " + DropDown_Process.Text + "\r\n" + "Press OK to continue.", "Target Process is not CMD", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (msgresults == DialogResult.OK)
                {
                    playFunction();
                }
                else
                {
                    MessageBox.Show("User Hit Cancel", "Stopping Script", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(DropDown_Process.Text == "cmd")
            {
                playFunction();
            }
        }
        private void writeCMD(object sender, EventArgs e)
        {
            if (checkProcDuplicate() <= 1)
            {
                Button btn_key = (Button)sender;
                //Set_window_to_forground(btn_key.Text);
                if (Set_window_to_forground() == true)
                {
                    runMacro("{bs}"); //must insert an additonal keystroke
                    runMacro("{Enter}"); //must insert an additonal keystroke
                    Thread.Sleep(10);
                    runMacro(btn_key.Text);
                    runMacro("{Enter}");
                }
            }
            else
            {
                MessageBox.Show("Duplicate Proccess Detected: " + checkProcDuplicate().ToString(), DropDown_Process.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool Set_window_to_forground()
        {
            Process[] prc = Process.GetProcessesByName(DropDown_Process.Text);
            if (prc.Length > 0)
            {
                //set window to foreground
                SetForegroundWindow(prc[0].MainWindowHandle);
                return true;
            }
            else
            {
                MessageBox.Show("Process not found: " + DropDown_Process.Text, "Set_window_to_forground", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void runMacro(string keys)
        {
            int chars = 256;
            StringBuilder buff = new StringBuilder(chars);
            IntPtr handle = GetForegroundWindow();
            if (GetWindowText(handle, buff, chars) > 0)
            {
                SendKeys.SendWait(keys);
                //SendKeys.Send("{Enter}");
            }
        }
    }
}
