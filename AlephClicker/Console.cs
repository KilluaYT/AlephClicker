using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace AlephClicker
{
    public partial class Console : Form
    {
        private System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
        private AlephClicker.Properties.Settings st = new AlephClicker.Properties.Settings();
        public Console()
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


        private void Console_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                sp.Play();
                this.SuspendLayout();
                this.Close();

            }

            if (e.KeyCode == Keys.Enter)
            {
                SendCMD();
            }
        }

        private void Console_Load(object sender, EventArgs e)
        {
            sp.Stream = res.Resources.UI2;
            label1.Font = myFont = new Font(fonts.Families[0], 12.0F);
            label2.Font = myFont = new Font(fonts.Families[0], 12.0F);
            textBox1.Font = myFont = new Font(fonts.Families[0], 10.0F);
            textBox2.Font = myFont = new Font(fonts.Families[0], 15.0F);
           
        }

        private void SendCMD()
        {
            if (textBox1.Text == "/help")
            {
                textBox2.Text = textBox2.Text + Environment.NewLine + Environment.NewLine + "All Commands:" + Environment.NewLine + "/aleph" + Environment.NewLine + "/cls (clears console)" + Environment.NewLine + "/help" + Environment.NewLine + "/random (generates random number from 1-100), you can also put a message behind it like in osu! " + Environment.NewLine + "/CheatMenu";
                textBox1.Text = "";
            }
            else
            {
                if (textBox1.Text == "/aleph")
                {
                    textBox1.Text = "";
                    textBox2.Text = textBox2.Text + Environment.NewLine + Environment.NewLine + st.aleph_ascii;
                }
                else
                {
                    if (textBox1.Text == "/cls")
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                    else
                    {
                        if (textBox1.Text.StartsWith("/random"))
                        {
                            textBox1.Text = "";
                            Random r = new Random();
                            int i = r.Next(1, 100);
                            textBox2.Text = textBox2.Text + Environment.NewLine + Environment.NewLine + "Your Number: " + i;
                        }
                        else
                        {
                            if (textBox1.Text == "/CheatMenu")
                            {
                                textBox1.Text = "";
                                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ&feature=youtu.be&ab_channel=RickAstleyVEVO");
                            }
                            else
                            {
                                textBox2.Text = textBox2.Text + Environment.NewLine + Environment.NewLine + "Command not found.";
                            }
                        }
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
            this.Close();
            sp.Play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.SelectionStart = textBox2.Text.Length;
            textBox2.ScrollToCaret();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            textBox1.Focus();
        }
    }
}
