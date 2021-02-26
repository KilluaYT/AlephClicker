using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlephClicker
{
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Log_KeyDown(object sender, KeyEventArgs e)
        {
           

            if (e.KeyCode == Keys.L)
            {


                this.Close();
            }
        }
    }
}
