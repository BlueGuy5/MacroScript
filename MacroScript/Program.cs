using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacroScript
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new Form1());
                Application.Run(new SerialTerminal());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception at Program Main", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
