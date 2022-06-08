using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CmlLib.Core;
using CmlLib.Core.Downloader;
using CmlLib.Core.Installer;
using CmlLib.Core.Version;

namespace FFGapple
{
    public partial class Settings : Form
    {

        int Move;
        int Mouse_X;
        int Mouse_Y;

        public Settings()
        {
             InitializeComponent();
            FFGapple.Language.Strings.Culture = new CultureInfo(FFGapple.Properties.Settings.Default.lang);
        }

      

        private void Settings_Load(object sender, EventArgs e)
        {
           
            guna2ToggleSwitch1.Checked = Properties.Settings.Default.exit;
            guna2ToggleSwitch2.Checked = Properties.Settings.Default.update;
            guna2ToggleSwitch3.Checked = Properties.Settings.Default.eskimodulmc;
            guna2ToggleSwitch4.Checked = Properties.Settings.Default.autologinset;
            guna2ComboBox1.SelectedItem = Properties.Settings.Default.lang;
            label1.Text = FFGapple.Language.Strings.set4;
            label2.Text = FFGapple.Language.Strings.setname;
            label3.Text = FFGapple.Language.Strings.set1;
            label4.Text = FFGapple.Language.Strings.set2;
            label5.Text = FFGapple.Language.Strings.set3;
            label6.Text = FFGapple.Language.Strings.autologin;

        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
          

          
           
           
            
                Properties.Settings.Default.exit = guna2ToggleSwitch1.Checked;
                Properties.Settings.Default.update = guna2ToggleSwitch2.Checked;
                Properties.Settings.Default.eskimodulmc = guna2ToggleSwitch3.Checked;
            Properties.Settings.Default.autologinset= guna2ToggleSwitch4.Checked;
            Properties.Settings.Default.lang = guna2ComboBox1.SelectedItem.ToString();
            
                Properties.Settings.Default.Save();

            //MessageBox.Show("To Saving The Changes, Restart The Launcher!", "FFGapple", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //DialogResult secenek = MessageBox.Show("İşlem yapılsın mı?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            //if (secenek == DialogResult.Yes)
            //{
            //    Application.Restart();
            //    Environment.Exit(0);
            //}




        }

        private void Settings_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void Settings_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void Settings_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
