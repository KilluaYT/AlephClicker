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
    public partial class Achivement : Form
    {
        private AlephClicker.Properties.Settings st = new AlephClicker.Properties.Settings();
        public Achivement()
        {
            InitializeComponent();
            byte[] fontData = res.Resources.SF_Pixelate;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, res.Resources.SF_Pixelate.Length);
            AddFontMemResourceEx(fontPtr, (uint)res.Resources.SF_Pixelate.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            myFont = new Font(fonts.Families[0], 10.0F);
        }
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
          IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        private PrivateFontCollection fonts = new PrivateFontCollection();
        Font myFont;

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Achivement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {


                this.Close();
            }
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void Achivement_Load(object sender, EventArgs e)
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
            







            label18.Text = "Completed: " + st.Achivement + "/5";
            userControl11.Value = st.Achivement;
            if (st.Achivement_OurFirstArmy == true)
            {
                label11.Text = "Achieved";
            }
            if (st.Achivement_ThisIsJustTheBeginning == true)
            {
                label12.Text = "Achieved";
            }
            if (st.Achivement_WelcomeToOsu == true)
            {
                label13.Text = "Achieved";
                label9.Text = "osu!";
            }
            if (st.Achivment_TheGod == true)
            {
                label15.Text = "Achieved";
                label16.Text = "Cookiezi is back!";
            }
            if (st.Achivement_AllAchivements == true)
            {
                label14.Text = "Achieved";
            }
        }
    }
}
