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
            FillPort();
            TreeView_Macro();
            /*
            for(int i = 0; i< 100; i++)
            {
                txt_serialLog.AppendText("test" + "\r\n");
            }
            */
        }
        private string[] getPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            return ports;
        }
        private void FillPort()
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
                        //add root node
                        //rootnodes = new TreeNode(file.Replace(@"C:\Users\" + Environment.UserName + @"\Documents\MacroScript\", ""));
                        //treeView_Files.Nodes.Add(rootnodes);                  
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
                treeView_Files.ExpandAll(); //Expand all nodes
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
                if (e.Node.Nodes.Count < 1)
                {
                    port.Write(e.Node.Text + "\r");
                    //txt_SendCommand.Text = e.Node.Text;
                    //btn_SendCommand_Click(sender, e);
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
        SerialPort port;
        string RadioBaudrate;
        private delegate void SafeCallDelegate(string text);

        private SerialPort OpenPorts()
        {
            port = new SerialPort(txt_ComPort.Text, int.Parse(RadioBaudrate), Parity.None, 8, StopBits.One);
            return port;
        }
        private void serialCommands()
        {
            try
            {
                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                port.Open();
                statusBarAdv1.ForeColor = Color.Green;
                lbl_Status.Text = "Connected";
                lbl_ComPort.Text = txt_ComPort.Text;
                lbl_Baudrate.Text = RadioBaudrate;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "serialCommands()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ReadSerialBuffer(string text)
        {
            try
            {
                if (txt_serialLog.InvokeRequired)
                {
                    var d = new SafeCallDelegate(ReadSerialBuffer);
                    txt_serialLog.Invoke(d, new object[] { text });
                }
                else
                {
                    txt_serialLog.AppendText(text + "\r");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ReadSerialBuffer()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ReadSerialBuffer(port.ReadExisting());
        }
        private void SendCommand(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    port.WriteLine(txt_SendCommand.Text + "\r");
                    txt_SendCommand.Text = string.Empty;
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
                btn_Connect.Enabled = false;
                btn_Close.Enabled = true;
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
                port.Close();
                port.Dispose();
                statusBarAdv1.ForeColor = Color.Red;
                lbl_Status.Text = "Disconnected";
                lbl_ComPort.Text = string.Empty;
                lbl_Baudrate.Text = string.Empty;
                btn_Close.Enabled = false;
                btn_Connect.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Close Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_Connect.Enabled = false;
                btn_Close.Enabled = true;
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                RadioBaudrate = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                radioButton1.Checked = false;
                radioButton3.Checked = false;
                RadioBaudrate = radioButton2.Text;
            }
            else if (radioButton3.Checked == true)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                RadioBaudrate = txt_CustomBaudrate.Text;
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
                txt_serialLog.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lbl_Status.Text = ex.Message;
            }
        }
    }
}
