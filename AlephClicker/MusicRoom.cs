using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using WMPLib;
using System.Drawing.Text;

namespace AlephClicker
{
    public partial class MusicRoom : Form
    {
        private System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
        private AlephClicker.Properties.Settings st = new AlephClicker.Properties.Settings();
        WMPLib.WindowsMediaPlayer mp = new WMPLib.WindowsMediaPlayer();
        
        string path = Directory.GetCurrentDirectory() + "\\BGM";

        public MusicRoom()
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
        private void MusicRoom_Load(object sender, EventArgs e)
        {
            if (st.ShowVIS == true)
            {
                checkBox1.Checked = true;
            }
            else { checkBox1.Checked = false; }
            mp.settings.volume = st.mp_Volume;
            label8.Text = "Music Volume: " + st.mp_Volume + "%";
            trackBar1.Value = st.mp_Volume;
            st.Reload();

            audioVisualization1.ColorBase = st.vis_min;

            audioVisualization1.ColorMax = st.vis_top;

            audioVisualization1.Start();
            GetBGM();

            label1.Font = myFont;
            label2.Font = myFont;
            label3.Font = myFont;
            label4.Font = myFont;
            label5.Font = myFont;
            label6.Font = myFont;
            label7.Font = myFont = new Font(fonts.Families[0], 18.0F);
            label8.Font = myFont = new Font(fonts.Families[0], 12.0F);
            label9.Font = myFont;
            button1.Font = myFont;
            button9.Font = myFont;
            listBox1.Font = myFont = new Font(fonts.Families[0], 9.0F);
            checkBox1.Font = myFont = new Font(fonts.Families[0], 12.0F);
        }

        private void MusicRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            mp.controls.stop();
            mp.close();
            this.audioVisualization1.Stop();
            this.audioVisualization1.Dispose();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Color c = new Color();
            colorDialog1.ShowDialog();
            c = colorDialog1.Color;
            st.vis_top = c;
            st.vis_min = c;
            st.Save();
            st.Reload();
            audioVisualization1.ColorBase = st.vis_min;

            audioVisualization1.ColorMax = st.vis_top;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Color c = new Color();

            colorDialog1.ShowDialog();
            c = colorDialog1.Color;
            st.vis_top = c;
            st.Save();

            colorDialog1.ShowDialog();
            c = colorDialog1.Color;
            st.vis_min = c;
            st.Save();

            st.Reload();
            audioVisualization1.ColorBase = st.vis_min;

            audioVisualization1.ColorMax = st.vis_top;
        }

        private void MusicRoom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void GetBGM()
        {
            listBox1.Items.Clear();
            
            try
            {
                string[] filelist;

                filelist = Directory.GetFiles(path);

                foreach (string s in filelist)
                {
                    if (s.Contains(".mp3"))
                    {
                        listBox1.Items.Add(s.Replace(path + "\\", "").Replace(".mp3", ""));
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                string content = path + "\\" + listBox1.GetItemText(listBox1.SelectedItem) + ".mp3";
                mp.URL = content;

                mp.controls.play();
            
            

        }

        private void mpt_Tick(object sender, EventArgs e)
        {
            if (mp.playState == WMPPlayState.wmppsPlaying)
            {


                label5.Text = mp.controls.currentItem.durationString;
                label3.Text = mp.controls.currentPositionString;
                label7.Text = mp.controls.currentItem.name;

                userControl11.Maximum = Convert.ToInt32(mp.controls.currentItem.duration);
                userControl11.Value = Convert.ToInt32(mp.controls.currentPosition);
            }
            if (mp.playState == WMPPlayState.wmppsWaiting)
            {


                label5.Text = "00:00";
                label3.Text = "00:00";
                label7.Text = "Nothing is Playing";

                userControl11.Maximum = 0;
                userControl11.Value = 0;
            }
            if (mp.playState == WMPPlayState.wmppsUndefined)
            {


                label5.Text = "00:00";
                label3.Text = "00:00";
                label7.Text = "Nothing is Playing";

                userControl11.Maximum = 0;
                userControl11.Value = 0;
            }
            if (mp.playState == WMPPlayState.wmppsStopped)
            {


                label5.Text = "00:00";
                label3.Text = "00:00";
                label7.Text = "Nothing is Playing";

                userControl11.Maximum = 0;
                userControl11.Value = 0;
            }
            if (mp.playState == WMPPlayState.wmppsMediaEnded)
            {


                label5.Text = "00:00";
                label3.Text = "00:00";
                label7.Text = "Nothing is Playing";

                userControl11.Maximum = 0;
                userControl11.Value = 0;
            }
            if (mp.playState == WMPPlayState.wmppsReady)
            {


                label5.Text = "00:00";
                label3.Text = "00:00";
                label7.Text = "Nothing is Playing";

                userControl11.Maximum = 0;
                userControl11.Value = 0;
            }


        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            mp.settings.volume = trackBar1.Value;
            label8.Text = "Music Volume: " + trackBar1.Value + "%";
            st.mp_Volume = trackBar1.Value;
            st.Save();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        { 
          
            
        }

        private void trackBar2_KeyUp(object sender, KeyEventArgs e)
        {
            double speed = trackBar2.Value;
            speed = speed / 100;
            label9.Text = "Speed: " + speed + "x";
            mp.settings.rate = Convert.ToDouble(speed);
        }

        private void trackBar2_MouseUp(object sender, MouseEventArgs e)
        {
            double speed = trackBar2.Value;
            speed = speed / 100;
            label9.Text = "Speed: " + speed + "x";
            mp.settings.rate = Convert.ToDouble(speed);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          if (checkBox1.Checked == true)
            {
                st.ShowVIS = true;
                st.Save();
            }
            else 
            {
                st.ShowVIS = false;
                st.Save();
            }
           
        }
    }
}