using FFGapple;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UpdateDLL;
using FFGuard;
using System.Threading;
using CmlLib.Core.Auth;
using System.Net.NetworkInformation;
using CmlLib.Core;
using System.Globalization;

//ffgapple project by x64/1336 aka marqe.

namespace Login_Page_Design_UI
{
    public partial class Giris : Form
    {

        MLogin login = new MLogin();
        MSession session;
       
        public Giris()
        {
            InitializeComponent();
            FFGapple.Language.Strings.Culture = new CultureInfo(FFGapple.Properties.Settings.Default.lang);

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
           
        }
        UpdateDLL.Update module = new UpdateDLL.Update();
        FFGuard.FFGuardModule guard = new FFGuard.FFGuardModule();
        int version = 25;
        int on = 1;
       

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           
            if (guna2TextBox1.Text != "")
            {
                if (guna2ToggleSwitch1.Checked = true)
                {
                    FFGapple.Properties.Settings.Default.username = guna2TextBox1.Text;
                    FFGapple.Properties.Settings.Default.aktif = guna2ToggleSwitch1.Checked = true;
                    FFGapple.Properties.Settings.Default.Save();
                }
                else
                {
                    guna2TextBox1.Text = "";
                    FFGapple.Properties.Settings.Default.aktif = guna2ToggleSwitch1.Checked = false;
                    FFGapple.Properties.Settings.Default.Save();
                }

                //Old Mojang Determine System, its changed at 31/5/22.
                //Ana main = new Ana(session);
                //Ana.user = guna2TextBox1.Text;
                //Ana.mojang = "offline";
                //main.Show();
                //Hide();
                UpdateSession(MSession.GetOfflineSession(guna2TextBox1.Text));
            }
            else
            {
                MessageBox.Show(FFGapple.Language.Strings.nick, "FFGapple", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
            

        }

        public void CheckConnection()
        {
            Ping ping = new Ping();
            PingReply pingDurumu = ping.Send(IPAddress.Parse("8.8.8.8"));

            if (pingDurumu.Status == IPStatus.Success)
            {
                guard.debugger();
                timer2.Start();
                //

               
            }
            if(pingDurumu.Status != IPStatus.Success)
            {
                MessageBox.Show(FFGapple.Language.Strings.inthata, "FFGapple", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }


        public void autologin()
        {
            try
            {
                var th = new Thread(() =>
                {
                    var result = login.TryAutoLogin();
                    if (result.Result != MLoginResult.Success)
                    {
                       
                    }


                    
                    Invoke(new Action(() =>
                    {


                        UpdateSession(result.Session);
                    }));
                });
                th.Start();
            }
            catch 
            {

               
            }
        }
      
        private void Form1_Load_1(object sender, EventArgs e)
        {


            //CultureInfo ci = CultureInfo.InstalledUICulture;
            
            //if(ci.LCID == 1055)
            //{
            //    FFGapple.Properties.Settings.Default.lang = "tr-TR";
               
            //}
            //if (ci.LCID == 1033)
            //{
            //    FFGapple.Properties.Settings.Default.lang = "en-US";
              
            //}
            //if (ci.LCID == 10)
            //{
            //    FFGapple.Properties.Settings.Default.lang = "es-ES";
               
            //}
            //if (ci.LCID == 7)
            //{
            //    FFGapple.Properties.Settings.Default.lang = "de-DE";
                
            //}





            //guna2ToggleSwitch1.Checked = FFGapple.Properties.Settings.Default.aktif;
            try
            {
                guna2TextBox1.PlaceholderText = FFGapple.Language.Strings.place1;
                guna2TextBox2.PlaceholderText = FFGapple.Language.Strings.place2;
                guna2Button1.Text = FFGapple.Language.Strings.girismojang;
                guna2Button2.Text = FFGapple.Language.Strings.girismojang;
                linkLabel1.Text = FFGapple.Language.Strings.orjhesap;
                linkLabel2.Text = FFGapple.Language.Strings.grdn;
                CheckConnection();
                if (FFGapple.Properties.Settings.Default.update == true)
                {
                    module.denetleyici();
                }
                else
                {
                    FFGapple.Ana.upmodule = "broken";
                }

                //if(File.Exists(Application.StartupPath + "SafeDLLModule.txt"))
                //{
                //    File.Delete(Application.StartupPath + "SafeDLLModule.txt");
                //}

                //module.dllcheck();
                //StreamReader sr = new StreamReader(Application.StartupPath + "SafeDLLModule.txt");
                //string safe = sr.ReadToEnd();
                //if(safe == "safe // // // safe // // // check succes // // //")
                //{

                //}
                //else
                //{
                //    MessageBox.Show("Security Breached!", "FFGapple", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    Environment.Exit(-1);
                //}
                //autologin is not stable, disabled at 31/5/22.
                //autologin fixed at 7/6/22 <3.
                if (FFGapple.Properties.Settings.Default.autologinset == true)
                {
                    autologin();
                }


            }
            catch 
            {

                MessageBox.Show(FFGapple.Language.Strings.pinghata, "FFGapple" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
           
            


        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            guard.nofreeze();
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (guna2ToggleSwitch1.Checked)
            {
                FFGapple.Properties.Settings.Default.username = guna2TextBox1.Text;
                FFGapple.Properties.Settings.Default.aktif = guna2ToggleSwitch1.Checked = true;
                FFGapple.Properties.Settings.Default.Save();
            }
            else
            {
                guna2TextBox1.Text = "";
                FFGapple.Properties.Settings.Default.aktif = guna2ToggleSwitch1.Checked = false;
                FFGapple.Properties.Settings.Default.Save();
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Giris resize = new Giris();
            resize.StartPosition = FormStartPosition.CenterScreen;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            guna2TextBox2.Visible = true;
            guna2Button2.Visible = true;
            guna2Button1.Visible = false;
            linkLabel1.Visible = false;
            linkLabel2.Visible = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            guna2TextBox2.Visible = false;
            guna2Button2.Visible = false;
            guna2Button1.Visible = true;
            linkLabel1.Visible = true;
            linkLabel2.Visible = false;
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            mojanglogin();
        }

        public void mojanglogin()
        {
            var th = new Thread(new ThreadStart(delegate
            {
                var result = login.Authenticate(guna2TextBox1.Text, guna2TextBox2.Text);
                if (result.Result == MLoginResult.Success)
                {
                    Invoke(new Action(() =>
                    {
                        UpdateSession(result.Session);
                    }));
                }
                else
                {
                    MessageBox.Show(FFGapple.Language.Strings.mojhata, "FFGapple", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    Invoke(new Action(() =>
                    {

                    }));
                }
            }));
            th.Start();
        }

        public void UpdateSession(MSession session)
        {
           
            var mainForm = new Ana(session);
            
            mainForm.FormClosed += (s, e) => this.Close();
            mainForm.Show();
            this.Hide();
        }


    }
}
