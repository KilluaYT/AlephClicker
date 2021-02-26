using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace AlephClicker
{
    public partial class Upgrade : Form
    {
        private AlephClicker.Properties.Settings st = new AlephClicker.Properties.Settings();
        public Upgrade()
        {
            InitializeComponent();
            byte[] fontData = res.Resources.SF_Pixelate;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, res.Resources.SF_Pixelate.Length);
            AddFontMemResourceEx(fontPtr, (uint)res.Resources.SF_Pixelate.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            myFont = new Font(fonts.Families[0], 11.0F);
        }
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
          IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        private PrivateFontCollection fonts = new PrivateFontCollection();
        Font myFont;
        private void Upgrade_Load(object sender, EventArgs e)
        {
            label1.Font = myFont;
            label2.Font = myFont;
            label3.Font = myFont;
            label4.Font = myFont;
            label5.Font = myFont;
            label6.Font = myFont;
            label7.Font = myFont;
            label8.Font = myFont;
            label9.Font = myFont;
            label10.Font = myFont;
            label11.Font = myFont;
            label12.Font = myFont;
            label13.Font = myFont;
            label14.Font = myFont;
            label15.Font = myFont;
            label16.Font = myFont;
            label17.Font = myFont;
            label18.Font = myFont;
            label19.Font = myFont;
          
            button1.Font = myFont;
            button2.Font = myFont;
            button3.Font = myFont;
            button4.Font = myFont;




            timer1.Start();

            label5.Text = "Aleph: " + st.aleph;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (st.aleph >= st.clickM_cost)
            {
                st.aleph = st.aleph - st.clickM_cost;
                st.multiplier++;
                st.Save();
                st.clickM_cost = st.clickM_cost * 5;
                st.Save();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            label5.Text = "Aleph: " + st.aleph;
            label5.Text = "Aleph: " + st.aleph.ToString("#.0");

            // Click Multiplier
            label7.Text = "Cost: " + st.clickM_cost.ToString("#.0") + " Aleph";
            label4.Text = "Current: " + st.multiplier + "x";
            label6.Text = "Next: " + Convert.ToInt32(st.multiplier + 1) + "x";
            

            // AutoClick
            label8.Text = "Cost: " + st.ac_cost.ToString("#.0") + " Aleph";
            label10.Text = "Current: " + st.AutoClick + "/s";
            label9.Text = "Next: " + Convert.ToDouble(st.AutoClick + 0.1) + "/s";

            // MilitaryBase
            label12.Text = "Cost: " + st.AMB_cost.ToString("#.0") + " Aleph";
            label14.Text = "Current: " + st.MilitaryBase + "/s";
            label13.Text = "Next: " + Convert.ToDouble(st.MilitaryBase + 5) + "/s";

            // Anti Si Propaganda
            label16.Text = "Cost: " + st.ASP_cost.ToString("#.0") + " Aleph";
            label18.Text = "Current: " + st.Anti_Si_Propaganda + "/s";
            label17.Text = "Next: " + Convert.ToDouble(st.Anti_Si_Propaganda + 50) + "/s";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (st.aleph >= st.ac_cost)
            {
                st.aleph = st.aleph - st.ac_cost;
                st.AutoClick = st.AutoClick + 0.1;
                st.Save();
                st.ac_cost = st.ac_cost * 1.5;
                st.Save();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            st.Reload();
            label5.Text = "Aleph: " + st.aleph;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (st.aleph >= st.AMB_cost)
            {
                st.aleph = st.aleph - st.AMB_cost;
                st.MilitaryBase = st.MilitaryBase + 5;
                st.Save();
                st.AMB_cost = st.AMB_cost * 1.5;
                st.Save();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (st.aleph >= st.ASP_cost)
            {
                st.aleph = st.aleph - st.ASP_cost;
                st.Anti_Si_Propaganda = st.Anti_Si_Propaganda + 50;
                st.Save();
                st.ASP_cost = st.ASP_cost * 1.5;
                st.Save();
            }
        }

        private void Upgrade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {


                this.Close();
            }
        }
    }
}
