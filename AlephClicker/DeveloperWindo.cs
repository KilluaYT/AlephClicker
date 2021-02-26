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
    public partial class DeveloperWindo : Form
    {
        private AlephClicker.Properties.Settings st = new AlephClicker.Properties.Settings();
        public DeveloperWindo()
        {
            InitializeComponent();
        }

        private void DeveloperWindo_Load(object sender, EventArgs e)
        {
            st.Reload();
            textBox1.Text = "" + st.aleph;
            textBox2.Text = "" + st.multiplier;
            textBox3.Text = "" + st.click;
            textBox4.Text = "" + st.exp;
            textBox5.Text = "" + st.exp_max;
            textBox6.Text = "" + st.level;
            textBox7.Text = "" + st.AutoClick;
            textBox8.Text = "" + st.MilitaryBase;
            textBox9.Text = "" + st.clickM_cost;
            textBox10.Text = "" + st.Anti_Si_Propaganda;
            textBox11.Text = "" + st.AMB_cost;
            textBox12.Text = "" + st.ac_cost;
            textBox13.Text = "" + st.ASP_cost;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void reload()
        {
            st.Reload();
            textBox1.Text = "" + st.aleph;
            textBox2.Text = "" + st.multiplier;
            textBox3.Text = "" + st.click;
            textBox4.Text = "" + st.exp;
            textBox5.Text = "" + st.exp_max;
            textBox6.Text = "" + st.level;
            textBox7.Text = "" + st.AutoClick;
            textBox8.Text = "" + st.MilitaryBase;
            textBox9.Text = "" + st.clickM_cost;
            textBox10.Text = "" + st.Anti_Si_Propaganda;
            textBox11.Text = "" + st.AMB_cost;
            textBox12.Text = "" + st.ac_cost;
            textBox13.Text = "" + st.ASP_cost;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            st.Reset();
            st.Save();
            st.Reload();
            reload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            st.aleph = Convert.ToDouble(textBox1.Text);
            st.multiplier = Convert.ToDouble(textBox2.Text);
            st.click = Convert.ToDouble(textBox3.Text);
            st.exp = Convert.ToDouble(textBox4.Text);
            st.exp_max = Convert.ToDouble(textBox5.Text);
            st.level = Convert.ToInt32(textBox6.Text);
            st.AutoClick = Convert.ToDouble(textBox7.Text);
            st.MilitaryBase = Convert.ToDouble(textBox8.Text);
            st.clickM_cost = Convert.ToDouble(textBox9.Text);
            st.Anti_Si_Propaganda = Convert.ToDouble(textBox10.Text);
            st.AMB_cost = Convert.ToDouble(textBox11.Text);
            st.ac_cost = Convert.ToDouble(textBox12.Text);
            st.ASP_cost = Convert.ToDouble(textBox13.Text);
            st.Save();

           

        }
    }
}
