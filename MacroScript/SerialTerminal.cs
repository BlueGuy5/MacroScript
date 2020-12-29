using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

/// <summary>
/// RichTextBox = set hide selection to False in designview. Do not use scroll to carat()!
/// This will auto scroll richtextbox with the desired expectation. 
/// </summary>

namespace MacroScript
{
    public partial class SerialTerminal : Form
    {
        public SerialTerminal()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(HideSerialTerminal);
            this.KeyDown += new KeyEventHandler(SendCommand);
            this.FormClosing += new FormClosingEventHandler(OnSerialFormClosing);
        }

        private void SerialTerminal_Load(object sender, EventArgs e)
        {
            try
            {
                TreeView_Macro();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Main()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void radioButton_CheckedChanged(object sender, MouseEventArgs e)
        {
            RadioButton rb_select = (RadioButton)sender;
            foreach (RadioButton rb in groupBox3.Controls.OfType<RadioButton>())
            {               
                if(rb.Text == rb_select.Text && rb_select.Name != radioButton3.Name)
                {
                    rb.Checked = true;
                    break;
                }
                else if(rb.Text == rb_select.Text && rb_select.Name == radioButton3.Name)
                {
                    //we assume radioButton3 is what we want since the IF statement above is not true.
                    rb.Checked = true;                  
                    break;
                }
            }
        }
        private string setBaudRate()
        {
            foreach (RadioButton rb in groupBox3.Controls.OfType<RadioButton>())
            {
                if (rb.Checked == true && rb.Name != radioButton3.Name)
                {
                    lbl_Baudrate.Text = rb.Text;
                    return rb.Text;
                }
                else if (rb.Checked == true && rb.Name == radioButton3.Name)
                {
                    //we assume radioButton3 is what we want since the IF statement above is not true.
                    lbl_Baudrate.Text = txt_CustomBaudrate.Text;
                    return txt_CustomBaudrate.Text;
                }
            }
            return "0";
        }
        private string[] getPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            return ports;
        }
        private void FillPort(object sender, EventArgs e)
        {
            try
            {
                ListBox LB = new ListBox();
                LB.Name = txt_ComPort.Name;
                LB.Width = 100;
                LB.Height = 100;
                LB.ForeColor = Color.Black;
                LB.ScrollAlwaysVisible = true;
                ScrollComPorts.AttachedTo = LB;
                foreach (string port in getPorts())
                {
                    LB.Items.Add(port);
                }
                txt_ComPort.PopupControl = LB;
                LB.SelectedIndexChanged += new System.EventHandler(txt_ComPort_Click);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "getPorts()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txt_ComPort_Click(object sender, EventArgs e)
        {
            try
            {                
                ListBox lb = (ListBox)sender;
                ScrollComPorts.AttachedTo = lb;
                txt_ComPort.Text = lb.Text;
                txt_ComPort.PopupContainer.HidePopup();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "txt_ComPort_Click()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string[] retDir()
        {
            string[] files = System.IO.Directory.GetFiles(@"C:\Users\" + Environment.UserName + @"\Documents\MacroScript\");
            return files;
        }
        private void TreeView_Macro()
        {
            try
            {
                treeView_Files.Nodes.Clear();
                TreeNode rootnodes = new TreeNode();
                rootnodes = new TreeNode("All Commands");
                treeView_Files.Nodes.Add(rootnodes);
                var List_files = new List<string>();
                foreach (string file in retDir())
                {
                    if (file.IndexOf("CustomMacro") < 0)
                    {
                        List_files.Add(file.Replace(@"C:\Users\" + Environment.UserName + @"\Documents\MacroScript\", ""));           
                    }
                }
                List_files.Sort();
                foreach(string file in List_files)
                {
                    rootnodes = new TreeNode(file.Replace(@"C:\Users\" + Environment.UserName + @"\Documents\MacroScript\", ""));
                    treeView_Files.Nodes.Add(rootnodes);  
                }
                //add child node
                string path = @"C:\Users\" + Environment.UserName + @"\Documents\MacroScript\";
                int i = 1;
                var List_AllCommands = new List<string>(); //list use to sort commands in descenting order

                foreach (TreeNode node in treeView_Files.Nodes)
                {                   
                    if (node.Text != "All Commands")
                    {
                        string[] readNodes = System.IO.File.ReadAllLines(path + node.Text);
                        var ListLines = new List<string>();
                        foreach(string line in readNodes)
                        {
                            ListLines.Add(line);
                        }
                        ListLines.Sort();
                        //open textfile and read
                        foreach (string line in ListLines)
                        {
                            List_AllCommands.Add(line);
                            treeView_Files.Nodes[i].Nodes.Add(line);
                        }
                        i++;
                    }
                }
                List_AllCommands.Sort();            
                foreach (string line in List_AllCommands)
                {
                    treeView_Files.Nodes[0].Nodes.Add(line);
                }
                //treeView_Files.ExpandAll(); //Expand all nodes
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TreeView_Macro()", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void TreeView_NodeClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node.Nodes.Count < 1 && e.Node.IsSelected == true && e.Button == MouseButtons.Left)
                {
                    port.Write(e.Node.Text + "\r\n");
                }
                else if(e.Node.Nodes.Count < 1 && e.Button == MouseButtons.Right)
                {
                    txt_SendCommand.Text = e.Node.Text;
                }                     
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to Write to Serial Buffer - " + e.Node.Text + "\r", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_TreeViewReload_Click(object sender, EventArgs e)
        {
            TreeView_Macro();
        }
        bool WriteToFile = false;
        string filename;
        private StreamWriter sw;
        private void FileLogPath()
        {
            SaveFileDialog SaveFile = new SaveFileDialog();
            SaveFile.InitialDirectory = Environment.SpecialFolder.DesktopDirectory.ToString();
            //SaveFile.DefaultExt = ".txt";
            SaveFile.Filter = "Text File (*.txt)|*.txt";
            var dlgOK = SaveFile.ShowDialog();
            if (dlgOK == DialogResult.OK)
            {
                WriteToFile = true;
                filename = SaveFile.FileName;
                sw = new StreamWriter(filename);
                lbl_LogStatus.ForeColor = Color.Green;
                lbl_LogStatus.Text = "Logging";
                btn_log.Text = "Stop";
            }
        }
        private void btn_log_Click(object sender, EventArgs e)
        {
            if (WriteToFile == false)
            {
                FileLogPath();
            }
            else if(WriteToFile == true)
            {
                sw.Close();
                WriteToFile = false;
                lbl_LogStatus.Text = "";
                btn_log.Text = "Log";
            }
        }
        private void LogRightClickMenu(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                LogMenu.Show(Cursor.Position);
            }
        }
        private void ClearScreenClick(object sender, EventArgs e)
        {
            txt_RichSerialLog.Text = string.Empty;
        }
        private void AppendToLog(string text)
        {
            try
            {
                sw.WriteLine(text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(text, "Could not write serial output to logs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lbl_LogStatus.ForeColor = Color.Red;
                lbl_LogStatus.Text = ex.Message;
            }
        }
        public void FrameState(string SerialOut)
        {
            string[] Frame_State = { "connected state", "audio streaming state", "voice call state", "standby mode", "Unknown", "pairing mode", "power off state" };

            if (SerialOut.Contains("b2s edr state: " + Frame_State[0]) && lbl_Status.Text != "Connected")
            {
                lbl_Status.ForeColor = Color.Green;
                lbl_Status.Text = "Connected";
            }
            else if (SerialOut.Contains("b2s edr state: " + Frame_State[1]) && lbl_Status.Text != Frame_State[1])
            {
                lbl_Status.ForeColor = Color.Blue;
                lbl_Status.Text = "audio streaming state";
            }
            else if (SerialOut.Contains("b2s edr state: " + Frame_State[2]) && lbl_Status.Text != Frame_State[2])
            {
                lbl_Status.ForeColor = Color.Blue;
                lbl_Status.Text = "voice call state";
            }
            else if (SerialOut.Contains("b2s edr state: " + Frame_State[3]) && lbl_Status.Text != Frame_State[3])
            {
                lbl_Status.ForeColor = Color.Orange;
                lbl_Status.Text = "standby mode";
            }
            else if (SerialOut.Contains("b2s edr state: " + Frame_State[5]) && lbl_Status.Text != Frame_State[5])
            {
                lbl_Status.ForeColor = Color.Orange;
                lbl_Status.Text = "pairing mode";
            }
            else if (SerialOut.Contains("b2s edr state: " + Frame_State[6]) && lbl_Status.Text != Frame_State[6])
            {
                lbl_Status.ForeColor = Color.Red;
                lbl_Status.Text = "power off state";
            }
            else if (SerialOut.Contains("b2s edr state: ") && SerialOut.Contains("bt dump conn_state") == false && lbl_Status.Text != Frame_State[4])
            {
                lbl_Status.ForeColor = Color.Gray;
                lbl_Status.Text = "Unknown";
            }
            string BatteryCapacity = "";
            try
            {
                if (SerialOut.Contains("max1704x : capacity : "))
                {
                    int Start = SerialOut.IndexOf("max1704x : capacity : ");
                    int End = "max1704x : capacity : ".Length;
                    int StartPos = Start + End;
                    BatteryCapacity = SerialOut.Substring(StartPos, 3);
                    if (BatteryCapacity != "")
                    {
                        lbl_Status.Text = "Battery: " + BatteryCapacity.Trim() + "%";
                    }
                }
            }
            catch(Exception ex)
            {
                //Intentionally catch nothing here
            }
        }

        SerialPort port;
        private delegate void SafeCallDelegate(string text);

        private SerialPort OpenPorts()
        {
            string getRadioBaudRate = setBaudRate();
            port = new SerialPort(txt_ComPort.Text, int.Parse(getRadioBaudRate), Parity.None, 8, StopBits.One);
            return port;
        }
        private void serialCommands()
        {
            try
            {
                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                port.Open();
                lbl_ComPort.Text = txt_ComPort.Text;
                btn_Connect.Enabled = false;
                btn_Close.Enabled = true;
                statusBarAdv1.ForeColor = Color.Green;
                lbl_Status.ForeColor = Color.Green;
                lbl_Status.Text = "Connected";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "serialCommands()", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_Close.Enabled = false;
                btn_Connect.Enabled = true;
                statusBarAdv1.ForeColor = Color.Red;
                lbl_Status.Text = "Disconnected";
            }
        }
        public void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                ReadSerialBuffer(port.ReadExisting());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "port_DataReceived", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ReadSerialBuffer(string SerialOut)
        {
            try
            {
                if (txt_RichSerialLog.InvokeRequired)
                {
                    var d = new SafeCallDelegate(ReadSerialBuffer);
                    txt_RichSerialLog.BeginInvoke(d, new object[] { SerialOut });
                }
                else
                {
                    txt_RichSerialLog.AppendText(SerialOut);
                    if (WriteToFile == true)
                    {
                        AppendToLog(SerialOut);
                    }
                }
                if(txt_SendCommand.Text == "bt dump conn_state" || txt_SendCommand.Text == "dtest battery_capacity")
                { 
                    FrameState(SerialOut); //Custom Code
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ReadSerialBuffer()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void SendCommand(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    port.Write(txt_SendCommand.Text + "\r\n");

                    //Custom code added just for this issue
                    while(txt_SendCommand.Text == "bt dump conn_state" || txt_SendCommand.Text == "dtest battery_capacity")
                    {
                        await Task.Run(() => Thread.Sleep(1000));
                        if (port.IsOpen == true)
                        {
                            port.Write(txt_SendCommand.Text + "\r\n");
                        }   
                    }
                    // End of custom code
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unable to Write to Serial Buffer - " + txt_SendCommand.Text + "\r", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                OpenPorts();
                serialCommands();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connecting Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_Close.Enabled = false;
                btn_Connect.Enabled = true;
            }
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            try
            {
                port.DiscardInBuffer();
                port.DiscardOutBuffer();
                port.Close();
                statusBarAdv1.ForeColor = Color.Red;
                lbl_Status.ForeColor = Color.Red;
                lbl_Status.Text = "Disconnected";
                lbl_ComPort.Text = string.Empty;
                lbl_Baudrate.Text = string.Empty;
                btn_Close.Enabled = false;
                btn_Connect.Enabled = true;
                if (WriteToFile == true)
                {
                    sw.Close();
                    WriteToFile = false;
                    lbl_LogStatus.Text = "";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Close Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_Connect.Enabled = false;
                btn_Close.Enabled = true;
            }
            finally
            {
                btn_Close.Enabled = false;
                btn_Connect.Enabled = true;
            }
        }
        private void HideSerialTerminal(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                this.Hide();
            }
        }
        private void OnSerialFormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Hide();
                e.Cancel = true;
                port.Close();
                port.Dispose();
                statusBarAdv1.ForeColor = Color.Red;
                lbl_Status.Text = "Disconnected";
                lbl_ComPort.Text = string.Empty;
                lbl_Baudrate.Text = string.Empty;
                txt_RichSerialLog.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lbl_Status.Text = ex.Message;
            }
        }
    }
}
