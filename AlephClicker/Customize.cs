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
    public partial class Customize : Form
    {
        private AlephClicker.Properties.Settings st = new AlephClicker.Properties.Settings();
        
        public Customize()
        {
            InitializeComponent();
            byte[] fontData = res.Resources.SF_Pixelate;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, res.Resources.SF_Pixelate.Length);
            AddFontMemResourceEx(fontPtr, (uint)res.Resources.SF_Pixelate.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            myFont = new Font(fonts.Families[0], 14.0F);
        }
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
          IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        private PrivateFontCollection fonts = new PrivateFontCollection();
        Font myFont;

        private void Customize_Load(object sender, EventArgs e)
        {
            label1.Font = myFont;
            label2.Font = myFont;
            label3.Font = myFont;
            label4.Font = myFont;
            label5.Font = myFont;
           button1.Font = myFont;
            button2.Font = myFont;
            checkBox1.Font = myFont;
            button9.Font = myFont;
            ReloadImage();
            if (st.RGB == true)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        public void ReloadImage()
        {
            
            if (st.img == 1)
            {
                pictureBox1.Image = res.Resources.Aleph;
                label4.Text = "Reimu (Aleph)";
            }
            if (st.img == 2)
            {
                pictureBox1.Image = res.Resources.Cirno;
                label4.Text = "Cirno (Si)";
            }
            if (st.img == 3)
            {
                pictureBox1.Image = res.Resources.minecraft;
                label4.Text = "Minecraft Block";

            }
            if (st.img == 4)
            {
                pictureBox1.Image = res.Resources.pog1;
                label4.Text = "Pog 1";
            }
            if (st.img == 5)
            {
                pictureBox1.Image = res.Resources.pog2;
                label4.Text = "Pog 2";
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (st.img == 1)
            {
              
            }
            else
            {
                
                st.img = st.img - 1;
                st.Save();
                ReloadImage();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (st.img == 5)
            {

            }
            else
            {
                st.img = st.img + 1;
                st.Save();
                ReloadImage();
            }
            
            
         
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Customize_FormClosing(object sender, FormClosingEventArgs e)
        {
            st.changeImage = true;
            st.changeColor = true;
            st.Save();
        }

        private void Customize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {


                this.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                st.RGB = true;
                st.Save();
            }
            else
            {
                st.RGB = false;
                st.Save();
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            st.barColor = colorDialog1.Color;
            st.Save();
        }
    }
}
