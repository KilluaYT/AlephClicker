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
    public partial class Shop : Form
    {
        int counter = 0;
        int len = 0;
        string text;
        private System.Media.SoundPlayer sp = new System.Media.SoundPlayer();

        Form1 f = new Form1();
        private WMPLib.WindowsMediaPlayer mp = new WMPLib.WindowsMediaPlayer();
        private AlephClicker.Properties.Settings st = new AlephClicker.Properties.Settings();
        public Shop()
        {
            InitializeComponent();


    
            
            byte[] fontData = res.Resources.SF_Pixelate;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, res.Resources.SF_Pixelate.Length);
            AddFontMemResourceEx(fontPtr, (uint)res.Resources.SF_Pixelate.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            myFont = new Font(fonts.Families[0], 12.0F);
        }
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
           IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        private PrivateFontCollection fonts = new PrivateFontCollection();
        Font myFont;
      
        
        
        
        private void Shop_Load(object sender, EventArgs e)
        {
            RoundBorderForm();
            LoadFont();
            string BGMpath = Directory.GetCurrentDirectory() + "\\BGM\\Scott Buckley - Signal To Noise.mp3";
            mp.settings.volume = 20;
            mp.URL = BGMpath;
            mp.settings.setMode("loop", true);
            mp.controls.play();
            label5.Text = "Aleph: " + st.aleph.ToString("#.0");
          
        }
   
        

        private void label2_Click(object sender, EventArgs e)
        {
          
            mp.controls.stop();
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

        private void Shop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {

                mp.controls.stop();
                this.Close();
            }
        }

        private void LoadFont()
        {
            label1.Font = myFont = new Font(fonts.Families[0], 16.0F);
            label2.Font = myFont = new Font(fonts.Families[0], 16.0F);
            textBox1.Font = myFont = new Font(fonts.Families[0], 16.0F);
       
            label5.Font = myFont = new Font(fonts.Families[0], 16.0F);

        }

        public void RoundBorderForm()
        {

            SetRoundBorder(panel3, 50);
            SetRoundBorder(panel4, 50);
           


        }

        public void SetRoundBorder(Control control,int CornerRadius)
        {
            Rectangle Bounds = new Rectangle(0, 0, control.Width, control.Height);

            
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(Bounds.X, Bounds.Y, CornerRadius, CornerRadius, 180, 90);
            path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y, CornerRadius, CornerRadius, 270, 90);
            path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            path.AddArc(Bounds.X, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            path.CloseAllFigures();

            control.Region = new System.Drawing.Region(path);
        }
        private string[] lines;
        private int index = 0;
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            string s = res.Resources.npc;
            int i;
            Random r = new Random();
            i = r.Next(1, 10);




            sp.Stream = res.Resources.Text_1;


          
            text = ReadLine(s, i).Replace(i.ToString(), "");
            counter = 0;
            

            len = text.Length;
            timer1.Start();
            

        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            
            textBox1.Text = text.Substring(0, counter);
            ++counter;
                sp.Play();

            if (counter > len)
            {
                counter = 0;

                timer1.Stop();
            }

        }

        private static string ReadLine(string text, int lineNumber)
        {

            var reader = new StringReader(text);

            string line;
            int currentLineNumber = 0;

            do
            {
                currentLineNumber += 1;
                line = reader.ReadLine();
            }
            while (line != null && currentLineNumber < lineNumber);

            return (currentLineNumber == lineNumber) ? line :
                                                       string.Empty;
        }
    }
}
