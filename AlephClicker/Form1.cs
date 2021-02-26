using System;
using System.Diagnostics;

using System.Drawing;

using System.Threading;

using Options;
using AlephClicker;
using System.Windows.Forms;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;
using DiscordRPC;
using DiscordRPC.Events;
using DiscordRPC.Message;
using DiscordRPC.IO;
using System.Drawing.Text;
using WMPLib;
using System.IO;
using CSAudioVisualization;
using CSCore;


namespace AlephClicker
{
    public partial class Form1 : Form
    {
        private static int tick = 0, c = 0;
        private bool cntr = true, DevMode = false, clickScale = false;
        private int cps, clicks = 0, ee = 0, scale = 0, y = 0, R = 0, G = 0, B = 255, AchUP = 1, wait = 0, cookiezi = 0, scaleProgress = 0;
        private WMPLib.WindowsMediaPlayer mp = new WMPLib.WindowsMediaPlayer();
        private bool osu = false, reScale_switch = false, reScaling = false;
        private System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
        private AlephClicker.Properties.Settings st = new AlephClicker.Properties.Settings();
        private double xp;

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        private PrivateFontCollection fonts = new PrivateFontCollection();
        Font myFont;


      
        string BGMpath = Directory.GetCurrentDirectory() + "\\BGM\\ES_Ninja Training Camp - Christoffer Moe Ditlevsen.mp3";
        string key1, key2, key3;

      

        public Form1()
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

        public void changeImage()
        {
           
            try
            {
                if (st.img == 1)
                {
                    button6.BackgroundImage = res.Resources.Aleph;
                    client.UpdateLargeAsset("aleph_big", "Aleph Clicker" + Environment.NewLine + "              " + Environment.NewLine + "Aleph: " + st.aleph + " | " + "Level: " + st.level + " | " + "Clicks: " + st.click + " | " + "EXP: " + st.exp + "/" + st.exp_max);
                }
                if (st.img == 2)
                {
                    button6.BackgroundImage = res.Resources.Cirno;
                    client.UpdateLargeAsset("cirno", "Aleph Clicker" + Environment.NewLine + "              " + Environment.NewLine + "Aleph: " + st.aleph + " | " + "Level: " + st.level + " | " + "Clicks: " + st.click + " | " + "EXP: " + st.exp + "/" + st.exp_max);
                }
                if (st.img == 3)
                {
                    button6.BackgroundImage = res.Resources.minecraft;
                    client.UpdateLargeAsset("minecraft-logo", "Aleph Clicker" + Environment.NewLine + "              " + Environment.NewLine + "Aleph: " + st.aleph + " | " + "Level: " + st.level + " | " + "Clicks: " + st.click + " | " + "EXP: " + st.exp + "/" + st.exp_max);
                }
                if (st.img == 4)
                {
                    button6.BackgroundImage = res.Resources.pog1;
                    client.UpdateLargeAsset("pog1", "Aleph Clicker" + Environment.NewLine + "              " + Environment.NewLine + "Aleph: " + st.aleph + " | " + "Level: " + st.level + " | " + "Clicks: " + st.click + " | " + "EXP: " + st.exp + "/" + st.exp_max);
                }
                if (st.img == 5)
                {
                    button6.BackgroundImage = res.Resources.pog2;
                    client.UpdateLargeAsset("download", "Aleph Clicker" + Environment.NewLine + "              " + Environment.NewLine + "Aleph: " + st.aleph + " | " + "Level: " + st.level + " | " + "Clicks: " + st.click + " | " + "EXP: " + st.exp + "/" + st.exp_max);
                }
            }
            catch (Exception ex) { }
        }

        public void ResetAchivementShow()
        {
            if (timer4.Enabled == true)
            {
                timer4.Stop();
                wait = 0;
                AchUP = 1;
                y = 0;
                panel3.Size = new Size(panel3.Size.Width, 0);
                timer4.Start();
            }
            else { timer4.Start(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenSettings();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Upgrade upgr = new Upgrade();
            upgr.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Console con = new Console();

            con.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Info inf0 = new Info();
            inf0.ShowDialog();
        }

        private void button6_Click(object sender, MouseEventArgs e)
        {
            try
            {
                if (cps >= 15)
                {
                    clicks++;
                }
                else
                {
                    string i1, i2;

                    userControl11.Value = userControl11.Value + 1;
                    i1 = userControl11.Value.ToString();
                    i2 = userControl11.Maximum.ToString();
                    xp = Convert.ToDouble(i1) / Convert.ToDouble(i2);
                    xp = xp * 100;
                    i1 = "";
                    i2 = "";
                    if ((xp < 1) && (xp > 0.00000000000000000000000000000000000000000000000))
                    {
                        label8.Text = "0" + "" + xp.ToString("#.00") + "/100%";
                    }
                    else
                    {
                        label8.Text = "" + xp.ToString("#.00") + "/100%";
                    }

                    st.exp++;

                    clicks++;
                    st.click++;

                    st.aleph = st.aleph + 1 * st.multiplier;
                    label7.Text = "Clicks: " + st.click;
                    label5.Text = "Aleph: " + st.aleph.ToString("#.0");
                    st.Save();
                }
            }
            catch { }
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            reScale_switch = true;
            PlayUI();
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            reScale_switch = false;
            sp.Stream = res.Resources.UI2;
            sp.Play();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Achivement am = new Achivement();
            am.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Customize cm = new Customize();
            cm.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            mp.controls.pause();
            MusicRoom mr = new MusicRoom();
            mr.ShowDialog();
            mp.controls.play();
        }

        private void exitGame()
        {
            mp.controls.stop();
            mp.close();
            this.audioVisualization1.Stop();
            this.audioVisualization1.Dispose();
            if (button6.BackgroundImage.Equals(res.Resources.osu))
            {
                
                Application.Exit();
            }
            else
            {
                Application.Exit();
            }
        }

        private void FirstStartFalse()
        {
            st.ApplicationFirstStart = true;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            st.fullscreen = true;
            label5.Text = "Aleph: " + st.aleph;
            userControl11.Value = Convert.ToInt32(st.exp);
            userControl11.Maximum = Convert.ToInt32(st.exp_max);
            st.Save();
            st.Reload();
        }

        private void FirstStartTrue()
        {
            string i1, i2;
            st.Reload();
            label5.Text = "Aleph: " + st.aleph;
            userControl11.Maximum = Convert.ToInt32(st.exp_max);
            userControl11.Value = Convert.ToInt32(st.exp);

            label3.Text = "Level " + st.level;

            label7.Text = "Clicks: " + st.click;
            i1 = userControl11.Value.ToString();
            i2 = userControl11.Maximum.ToString();
            xp = Convert.ToDouble(i1) / Convert.ToDouble(i2);
            xp = xp * 100;
            i1 = "";
            i2 = "";

            if ((xp < 1) && (xp > 0.00000000000000000000000000000000000000000000000))
            {
                label8.Text = "0" + xp.ToString("#.00") + "/100%";
            }
            else
            {
                label8.Text = "" + xp.ToString("#.00") + "/100%";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Initialize();
            LoadFont();
            // Game.LoadKey();
            // Game.CreateSaveFile();

           
            SetRoundBorder(panel2, 40);

            VIS();


            BGM_Start();


            CheckForIllegalCrossThreadCalls = false;
            Thread TH = new Thread(RescaleImg);
            //   TH.Start();
            timer5.Start();
            reScale.Start();
            changeImage();
            st.changeColor = true;
            st.Save();
            RGBActivator.Start();
            img.Start();
            timer3.Start();
            reSize.Start();
            this.ResizeRedraw = true;
            st.Reload();
            label5.Text = "Aleph: " + st.aleph;
            timer2.Start();

            timer1.Start();

            refresh.Start();

            if (st.ApplicationFirstStart == false)
            {
                FirstStartFalse();
            }
            else
            {
                FirstStartTrue();
            }
            //   button6.Location = new Point(Convert.ToInt32((this.Size.Width / 2) - (button6.Size.Width / 2)), Convert.ToInt32((this.Size.Height / 2) - (button6.Size.Height / 2)));
            // button6.Size = new Size(Convert.ToInt32(this.Size.Width / 5), Convert.ToInt32(this.Size.Height / 2.5));
            button6.Location = new Point(Convert.ToInt32((this.Size.Width / 2) - (button6.Size.Width / 2)), Convert.ToInt32((this.Size.Height / 2) - (button6.Size.Height / 2)));
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ee = 0;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            c = 0; ee = 0; cookiezi = 0;
        }

        private void FormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D7)
            {
                ee = 0;
                c = 0;

                if (cookiezi == 1)
                {
                    cookiezi = 0;
                }

                if (cookiezi == 0)
                {
                    cookiezi = 1;
                }

                if (cookiezi == 2)
                {
                    button6.BackgroundImage = res.Resources.cookiezi;
                    cookiezi = 0;
                    if (st.Achivment_TheGod == true)
                    {
                    }
                    else
                    {
                        label11.Text = "The GOD";
                        label12.Text = "Cookiezi is back!";
                        client.UpdateLargeAsset("default_256_256", "Aleph Clicker" + Environment.NewLine + "              " + Environment.NewLine + "Aleph: " + st.aleph + " | " + "Level: " + st.level + " | " + "Clicks: " + st.click + " | " + "EXP: " + st.exp + "/" + st.exp_max);
                        st.Achivment_TheGod = true;
                        st.Achivement++;
                        st.Save();
                        ResetAchivementShow();
                    }
                }
            }

            if (e.KeyCode == Keys.D2)
            {
                ee = 0;
                c = 0;

                if (cookiezi == 2)
                {
                    cookiezi = 0;
                }

                if (cookiezi == 1)
                {
                    cookiezi = 2;
                }
            }

            if (e.KeyCode == Keys.F)
            {
                ee = 0;
                c = 0;
                cookiezi = 0;
                ee = 0;
                if (st.fullscreen == false)
                {
                    st.fullscreen = true;
                    st.Save();
                    //   button6.Size = new Size(Convert.ToInt32(this.Size.Width / 5), Convert.ToInt32(this.Size.Height / 2.5));
                    button6.Location = new Point(Convert.ToInt32((this.Size.Width / 2) - (button6.Size.Width / 2)), Convert.ToInt32((this.Size.Height / 2) - (button6.Size.Height / 2)));
                }
                else
                {
                    st.fullscreen = false;
                    st.Save();
                    this.CenterToScreen();
                    //  button6.Size = new Size(Convert.ToInt32(this.Size.Width / 5), Convert.ToInt32(this.Size.Height / 2.5));
                    button6.Location = new Point(Convert.ToInt32((this.Size.Width / 2) - (button6.Size.Width / 2)), Convert.ToInt32((this.Size.Height / 2) - (button6.Size.Height / 2)));
                }
            }

            if (e.KeyCode == Keys.O)
            {
                c = 0;
                cookiezi = 0;
                c = 0;
                if (ee == 0)
                {
                    ee++;
                }
                else { ee = 0; }
            }

            if (e.KeyCode == Keys.F5)
            {
                ee = 0;

                cookiezi = 0;
                if (c == 0)
                {
                    c++;
                }
                else
                {
                    c = 0;
                }
            }
            if (e.KeyCode == Keys.F3)
            {
                ee = 0;

                cookiezi = 0;
                if (c == 1)
                {
                    c++;
                }
                else { c = 0; }
            }
            if (e.KeyCode == Keys.F4)
            {
                ee = 0;

                cookiezi = 0;
                if (c == 2)
                {
                    c = 0;
                    DeveloperWindo dw = new DeveloperWindo();
                    dw.ShowDialog();
                }
                else { c = 0; }
            }

            if (e.KeyCode == Keys.S)
            {
                c = 0;
                cookiezi = 0;
                c = 0;
                if (ee == 1)
                {
                    ee++;
                }
                else
                {
                    ee = 0;
                }
            }

            if (e.KeyCode == Keys.U)
            {
                c = 0;
                cookiezi = 0;
                c = 0;
                if (ee == 2)
                {
                    ee++;
                    if (ee == 3)
                    {
                        if (osu == true)
                        {
                            panel1.BackgroundImage = null;
                            changeImage();
                            osu = false;
                            sp.Stream = res.Resources.See_you_next_time;
                            sp.Play();
                            ee = 0;
                            if (st.Achivement_WelcomeToOsu == true)
                            {
                            }
                            else
                            {
                                label11.Text = "Welcome to...";
                                label12.Text = "osu!";
                                st.Achivement_WelcomeToOsu = true;
                                st.Achivement++;
                                st.Save();
                                ResetAchivementShow();
                            }
                        }
                        else
                        {
                            client.UpdateLargeAsset("1200px-osu_logo__2015_svg", "Aleph Clicker" + Environment.NewLine + "              " + Environment.NewLine + "Aleph: " + st.aleph + " | " + "Level: " + st.level + " | " + "Clicks: " + st.click + " | " + "EXP: " + st.exp + "/" + st.exp_max);
                            button6.BackgroundImage = res.Resources.osu;
                            sp.Stream = res.Resources.Welcome_to_Osu_;
                            panel1.BackgroundImage = res.Resources.D6cJNa7UYAA5e6g_jpg_large;
                            osu = true;
                            sp.Play();
                            ee = 0;
                            if (st.Achivement_WelcomeToOsu == true)
                            {
                            }
                            else
                            {
                                label11.Text = "Welcome to...";
                                label12.Text = "osu!";
                                st.Achivement_WelcomeToOsu = true;
                                st.Achivement++;
                                st.Save();
                                ResetAchivementShow();
                            }
                        }

                    }
                }
                else
                {
                    ee = 0;
                }
            }

            if (e.KeyCode == Keys.R)
            {
                st.Reset();
                st.Save();
                mp.controls.stop();
                mp.close();
                this.audioVisualization1.Stop();
                this.audioVisualization1.Dispose();
                Application.Restart();
            }

            if (e.KeyCode == Keys.L)
            {
                ee = 0;
                c = 0;
                cookiezi = 0;
                Log l = new Log();
                l.ShowDialog();
            }

            if (e.KeyCode == Keys.Escape)
            {
                exitGame();
            }

            if (e.KeyCode == Keys.E)
            {
                mp.controls.stop();
                mp.close();
                this.audioVisualization1.Stop();
                this.audioVisualization1.Dispose();
                Application.Restart();
            }

            if (e.KeyCode == Keys.D)
            {
                ee = 0;
                c = 0;
                cookiezi = 0;
                if (DevMode == false)
                {
                    c = 0;
                    DevMode = true;
                    label9.Visible = true;
                    button6.FlatAppearance.BorderSize = 1;
                }
                else
                {
                    c = 0;
                    DevMode = false;
                    label9.Visible = false;
                    button6.FlatAppearance.BorderSize = 0;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mp.controls.pause();
            Shop sh = new Shop();
            sh.ShowDialog();
            mp.controls.play();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void img_Tick(object sender, EventArgs e)
        {
            if (st.changeImage == true)
            {
                st.changeImage = false;
                if (st.img == 1)
                {
                    button6.BackgroundImage = res.Resources.Aleph;
                   
                }
                if (st.img == 2)
                {
                    button6.BackgroundImage = res.Resources.Cirno;
                    
                }
                if (st.img == 3)
                {
                    button6.BackgroundImage = res.Resources.minecraft;
                   
                }
                if (st.img == 4)
                {
                    button6.BackgroundImage = res.Resources.pog1;
                    
                }
                if (st.img == 5)
                {
                    button6.BackgroundImage = res.Resources.pog2;
                    
                }
            }
        }

        private void reScale_Tick(object sender, EventArgs e)
        {
            if (reScale_switch == true)
            {
                if (scaleProgress <= -4)
                {
                }
                else
                {
                    scaleProgress--;
                    button6.Location = new Point(Convert.ToInt32((this.Size.Width / 2) - (button6.Size.Width / 2)), Convert.ToInt32((this.Size.Height / 2) - (button6.Size.Height / 2)));
                    button6.Size = new Size(Convert.ToInt32(button6.Size.Width - 4), Convert.ToInt32(button6.Size.Height - 4));
                }
            }
            else if (reScale_switch == false)
            {
                if (scaleProgress >= 0)
                {
                }
                else
                {
                    scaleProgress++;
                    button6.Location = new Point(Convert.ToInt32((this.Size.Width / 2) - (button6.Size.Width / 2)), Convert.ToInt32((this.Size.Height / 2) - (button6.Size.Height / 2)));
                    button6.Size = new Size(Convert.ToInt32(button6.Size.Width + 4), Convert.ToInt32(button6.Size.Height + 4));
                }
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {
            exitGame();
        }

        private void OpenSettings()
        {
            settings thisSettings = new settings();
            thisSettings.ShowDialog();
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            PlayUI();
            button9.ForeColor = Color.Yellow;
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            PlayUI();
            button8.ForeColor = Color.Yellow;
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            PlayUI();
            button7.ForeColor = Color.Yellow;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            PlayUI();
            button2.ForeColor = Color.Yellow;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            PlayUI();
            button3.ForeColor = Color.Yellow;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            PlayUI();
            button4.ForeColor = Color.Yellow;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            PlayUI();
            button5.ForeColor = Color.Yellow;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.ForeColor = Color.White;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.ForeColor = Color.White;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.ForeColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.White;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = Color.White;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.ForeColor = Color.White;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.ForeColor = Color.White;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Red;
            PlayUI();
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.White;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void refresh_Tick(object sender, EventArgs e)
        {
            try
            {
                label9.Text = "=======" + Environment.NewLine + "Dev Mode" + Environment.NewLine + "=======" + Environment.NewLine + "Mouse (X,Y): (" + Cursor.Position.X + "," + Cursor.Position.Y + ")" + Environment.NewLine + "button6(CenterImage) Location(X,Y): (" + button6.Location.X + "," + button6.Location.Y + ")" + Environment.NewLine + "button6(CenterImage) Size(W,H): (" + button6.Size.Width + "," + button6.Size.Height + ")" + Environment.NewLine + "Window Size(W,H): (" + this.Size.Width + "," + this.Size.Height + ")";
                label4.Text = userControl11.Value + "/" + userControl11.Maximum;
                if (userControl11.Value >= userControl11.Maximum)
                {
                    userControl11.Value = 0;
                    st.level++;
                    st.upgrade++;
                    xp = 0;
                    st.exp = 0;
                    st.exp_max = st.exp_max * 1.5;
                    st.Save();
                    userControl11.Maximum = Convert.ToInt32(st.exp_max);
                    label4.Text = userControl11.Value + "/" + userControl11.Maximum;
                    label3.Text = "Level " + st.level;
                    if ((xp < 1) && (xp > 0.00000000000000000000000000000000000000000000000))
                    {
                        label8.Text = "0" + xp.ToString("#.00") + "/100%";
                    }
                    else
                    {
                        if (xp == 0)
                        {
                            label8.Text = "0" + xp.ToString("#.00") + "/100%";
                        }
                        else
                        {
                            label8.Text = "" + xp.ToString("#.00") + "/100%";
                        }
                    }
                }

                if (st.fullscreen == false)
                {
                    this.WindowState = FormWindowState.Normal;
                    if (cntr == true)
                    {
                        this.CenterToScreen();
                        cntr = false;
                    }

                    st.Save();
                }
                else
                {
                    this.WindowState = FormWindowState.Maximized;

                    st.Save();
                }

               
            }
            catch (Exception ex) { }
        }

        private void refreshFAST_Tick(object sender, EventArgs e)
        {
        //    Initialize();
            try
            {
                try
                {
                    client.UpdateDetails("Aleph: " + st.aleph);
                    client.UpdateLargeAsset("aleph_big", "Aleph Clicker" + Environment.NewLine + "              " + Environment.NewLine + "Aleph: " + st.aleph + " | " + "Level: " + st.level + " | " + "Clicks: " + st.click + " | " + "EXP: " + st.exp + "/" + st.exp_max);
                }
                catch (Exception ex) { string useless; useless = ex.Message; }
                    button6.Location = new Point(Convert.ToInt32((this.Size.Width / 2) - (button6.Size.Width / 2)), Convert.ToInt32((this.Size.Height / 2) - (button6.Size.Height / 2)));
                label5.Text = "Aleph: " + st.aleph.ToString("#.0");
                label9.Text = "=======" + Environment.NewLine + "Dev Mode" + Environment.NewLine + "=======" + Environment.NewLine + "Mouse (X,Y): (" + Cursor.Position.X + "," + Cursor.Position.Y + ")" + Environment.NewLine + "button6(CenterImage) Location(X,Y): (" + button6.Location.X + "," + button6.Location.Y + ")" + Environment.NewLine + "button6(CenterImage) Size(W,H): (" + button6.Size.Width + "," + button6.Size.Height + ")" + Environment.NewLine + "Window Size(W,H): (" + this.Size.Width + "," + this.Size.Height + ")";
                label4.Text = userControl11.Value + "/" + userControl11.Maximum;
                int i = st.Achivement_Max - st.Achivement;
                if (i == 1)
                {
                    if (st.Achivement_AllAchivements == true)
                    {
                    }
                    else
                    {
                        label11.Text = "Any % Speedrun";
                        label12.Text = "Get every Achivement";
                        st.Achivement_AllAchivements = true;
                        st.Achivement++;
                        st.Save();
                        ResetAchivementShow();
                    }
                }

                if (st.fullscreen == false)
                {
                    this.WindowState = FormWindowState.Normal;
                    if (cntr == true)
                    {
                        this.CenterToScreen();
                        cntr = false;
                    }

                    st.Save();
                }
                else
                {
                    this.WindowState = FormWindowState.Maximized;

                    st.Save();
                }
            }
            catch (Exception ex) { // DO NOTHING
            }

            



        }

        private void RGB_Tick(object sender, EventArgs e)
        {
            try
            {
                userControl11.ProgressBarColor = Color.FromArgb(R, G, B);

                if (R > 0 && B == 0)
                {
                    R = R - 1;
                    G = 1 + G;
                }
                if (G > 0 && R == 0)
                {
                    G = G - 1;
                    B = 1 + B;
                }
                if (B > 0 && G == 0)
                {
                    B = B - 1;
                    R = R + 1;
                }
            }
            catch { }
        }

        private void RGBActivator_Tick(object sender, EventArgs e)
        {
            if (st.changeColor == true)
            {
                if (st.RGB == true)
                {
                    RGB.Start();
                    st.changeColor = false;
                    st.Save();
                }
                else
                {
                    RGB.Stop();
                    userControl11.ProgressBarColor = st.barColor;
                    st.changeColor = false;
                    st.Save();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            st.Reload();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            cps = clicks;
            label6.Text = "CPS: " + cps;
            clicks = 0;

            tick = 0;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (reScale.Enabled == true)
            {
            }
            else
            {
                button6.Location = new Point(Convert.ToInt32((this.Size.Width / 2) - (button6.Size.Width / 2)), Convert.ToInt32((this.Size.Height / 2) - (button6.Size.Height / 2)));
                button6.Size = new Size(Convert.ToInt32(this.Size.Width / 5), Convert.ToInt32(this.Size.Height / 2.5));
            }
        }

        private void timer3_Tick_1(object sender, EventArgs e)
        {
            st.aleph = st.aleph + st.AutoClick + st.MilitaryBase + st.Anti_Si_Propaganda;
            st.Save();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (AchUP == 1)
            {
                y = y + 5;
                panel3.Size = new Size(panel3.Size.Width, y);
                if (y == 90) { wait = 0; AchUP = 3; }
            }
            if (AchUP == 2)
            {
                y = y - 5;
                panel3.Size = new Size(panel3.Size.Width, y);
                if (y == 0) { timer4.Stop(); }
            }
            if (AchUP == 3)
            {
                wait++;
                if (wait >= 200)
                {
                    wait = 0;
                    AchUP = 2;
                }
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {// label11 = name // label12 = condition
            if (st.aleph >= 100)
            {
                if (st.Achivement_OurFirstArmy == true)
                {
                }
                else
                {
                    label11.Text = "Our First Army";
                    label12.Text = "Get 100 Aleph";
                    st.Achivement_OurFirstArmy = true;
                    st.Achivement++;
                    st.Save();
                    ResetAchivementShow();
                }
            }

            if (st.click >= 1000)
            {
                if (st.Achivement_ThisIsJustTheBeginning == true)
                {
                }
                else
                {
                    label11.Text = "This is just the beginning...";
                    label12.Text = "Click 1000 times";
                    st.Achivement_ThisIsJustTheBeginning = true;
                    st.Achivement++;
                    st.Save();
                    ResetAchivementShow();
                }
            }


        }

        private void RescaleImg()
        {
            while (true)
            {
                Thread.Sleep(1);
                if (reScale_switch == true)
                {
                    if (scaleProgress <= -10)
                    {
                    }
                    else
                    {
                        scaleProgress--;
                        button6.Location = new Point(Convert.ToInt32((this.Size.Width / 2) - (button6.Size.Width / 2)), Convert.ToInt32((this.Size.Height / 2) - (button6.Size.Height / 2)));
                        button6.Size = new Size(Convert.ToInt32(button6.Size.Width - 1), Convert.ToInt32(button6.Size.Height - 1));
                    }
                }
                else if (reScale_switch == false)
                {
                    if (scaleProgress >= 0)
                    {
                    }
                    else
                    {
                        scaleProgress++;
                        button6.Location = new Point(Convert.ToInt32((this.Size.Width / 2) - (button6.Size.Width / 2)), Convert.ToInt32((this.Size.Height / 2) - (button6.Size.Height / 2)));
                        button6.Size = new Size(Convert.ToInt32(button6.Size.Width + 1), Convert.ToInt32(button6.Size.Height + 1));
                    }
                }
            }
        }

        private void SaveEnrypt()
        {

        }

        private void LoadDecrypt()
        {

        }






        public DiscordRpcClient client;


        void Initialize()
        {
            /*
            Create a Discord client
            NOTE: 	If you are using Unity3D, you must use the full constructor and define
                     the pipe connection.
            */
            client = new DiscordRpcClient("814066333792206859");

            //Set the logger


            //Subscribe to events
            client.OnReady += (sender, e) =>
            {

            };

            client.OnPresenceUpdate += (sender, e) =>
            {

            };

            //Connect to the RPC
            client.Initialize();

            //Set the rich presence
            //Call this as many times as you want and anywhere in your code.

                  
            client.SetPresence(new RichPresence()
            {
                Details = "Aleph: " + st.aleph,
                State = "In Game",
                Timestamps = new Timestamps()
                {
                    
                    Start = DateTime.UtcNow,
                    //  End = DateTime.UtcNow + TimeSpan.FromSeconds(15)
                },

                Buttons = new DiscordRPC.Button[]
                {
                    new DiscordRPC.Button() { Label = "Join our Discord",Url = "https://discord.com/invite/dxggpEB8GW"}
                },

                Assets = new Assets()
                {
                    LargeImageKey = "aleph_big",
                    LargeImageText = "Aleph Clicker" + Environment.NewLine + "              " + Environment.NewLine + "Aleph: " + st.aleph + " | " + "Level: " + st.level + " | " + "Clicks: " + st.click + " | " + "EXP: " + st.exp + "/" + st.exp_max,
                    SmallImageKey = "0_big"
                }
            });

           

       
        }

        
        public void LoadFont()
        {
            label1.Font = myFont = new Font(fonts.Families[0], 16.0F);
            label2.Font = myFont;
            label3.Font = myFont = new Font(fonts.Families[0], 12.0F);
            label4.Font = myFont;
            label5.Font = myFont = new Font(fonts.Families[0], 16.0F);
            label6.Font = myFont = new Font(fonts.Families[0], 12.0F);
            label7.Font = myFont;
            label8.Font = myFont;
            label9.Font = myFont;
            label10.Font = myFont;
            label11.Font = myFont;
            label12.Font = myFont;
            
            button2.Font = myFont;
            button3.Font = myFont;
            button4.Font = myFont;
            button5.Font = myFont;
            button6.Font = myFont;
            button7.Font = myFont = new Font(fonts.Families[0], 9.0F);
            button8.Font = myFont = new Font(fonts.Families[0], 12.0F);
            button9.Font = myFont;
        }



        public void PlayUI()
        {
            sp.Stream = res.Resources.UI;
            sp.Play();
        }

        public void BGM_Start()
        {
            mp.settings.volume = 20;
            mp.URL = BGMpath;
            mp.settings.setMode("loop", true);
            mp.controls.play();
        }
        public void SetRoundBorder(Control control, int CornerRadius)
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

        public void VIS()
        {
            if (st.ShowVIS == true) 
            {
                audioVisualization1.Visible = true;
                audioVisualization1.ColorBase = st.vis_min;

                audioVisualization1.ColorMax = st.vis_top;
                audioVisualization1.Start();
            }
            else
            {
                audioVisualization1.Visible = false;
            }
        }

    }
}