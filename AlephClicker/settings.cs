using System;
using System.Windows.Forms;

namespace AlephClicker
{
    public partial class settings : Form
    {
        private Form1 Game = new Form1();
        private AlephClicker.Properties.Settings GetSettings = new AlephClicker.Properties.Settings();

        public settings()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetSettings.Reload();
            if (GetSettings.fullscreen == false)
            {
                GetSettings.fullscreen = true;
                GetSettings.Save();
                GetSettings.Reload();
            }
            else
            {
                GetSettings.fullscreen = false;
                GetSettings.Save();
                GetSettings.Reload();
            }
        }

        private void settings_Load(object sender, EventArgs e)
        {
            refrsh2.Start();
        }

        private void refrsh2_Tick(object sender, EventArgs e)
        {
            label3.Text = "Window Size" + Environment.NewLine + "X: " + Game.Size.Width + Environment.NewLine + "Y: " + Game.Size.Height;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetSettings.Reset();
            GetSettings.Save();
            Application.Restart();
        }

        private void settings_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Escape)
            {
                this.SuspendLayout();
                this.Close();
            }
        }
    }
}