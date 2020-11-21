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
            this.FormClosing += new FormClosingEventHandler(OnSerialFormClosing);
        }

        private void SerialTerminal_Load(object sender, EventArgs e)
        {

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
 
        private void btn_SendCommand_Click(object sender, EventArgs e)
        {
            try
            {
                port.WriteLine(txt_SendCommand.Text + "\r");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to Write to Serial Buffer", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            try
            {
                port.Close();
                port.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Close Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radioButton2.Checked = false;
                RadioBaudrate = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                radioButton1.Checked = false;
                RadioBaudrate = radioButton2.Text;
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
            this.Hide();
            e.Cancel = true;           
        }
    }
}
