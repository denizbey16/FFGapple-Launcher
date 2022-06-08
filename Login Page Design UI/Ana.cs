using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Core.Downloader;
using CmlLib.Core.Version;
using Login_Page_Design_UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UpdateDLL;
using FFGuard;
using System.Management;
using System.Management.Instrumentation;
using System.IO;
using CmlLib.Core.Installer;
using System.Globalization;
using FFGapple.Language;
using CmlLib.Core.Mojang;
using MojangAPI.Model;
using System.Net.Http;
using MojangAPI;

namespace FFGapple
{
    public partial class Ana : Form
    {
        double ramgoritmaninrami;
        double dortgb;
        double sekizgb;
        double onaltigb;
        double otuzikigb;
        double altmisdortgb;
        int Move;
        int Mouse_X;
        int Mouse_Y;
        public static string user;
        private static string version;
        public static string mojang;
        private static string versionclient = "3.1";
        public static string upmodule;
        public static string usernameskin;
        public static string uuiduser;
        public static string accestoken;
        private MSession session;
        UpdateDLL.Update module = new UpdateDLL.Update();
        FFGuard.FFGuardModule guard = new FFGuard.FFGuardModule();
        MLaunchOption option = new MLaunchOption();
        MinecraftPath mcpath;
       
    

        public Ana(MSession session)
        {
            this.session = session;
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            Language.Strings.Culture = new CultureInfo(FFGapple.Properties.Settings.Default.lang);
            try
            {
                label4.Text = Language.Strings.welcome + session.Username;
                label2.Text = Language.Strings.build + versionclient;
                user = session.Username;
                uuiduser = session.UUID;
                accestoken = session.AccessToken;

                bust();
                usernameskin = label4.Text;
            }
            catch 
            {

                Environment.Exit(-1);
            }
          
        

            
        }



    public void bust()
        {
            try
            {
                var request = WebRequest.Create("https://minotar.net/avatar/" + session.Username + "/100.png");
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    pictureBox1.Image = Bitmap.FromStream(stream);
                }
            }
            catch 
            {
                //3/6/22
                //MessageBox.Show("Picture Error!" , "FFGapple", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ramgoritma()
        {
            ManagementObjectSearcher Search = new ManagementObjectSearcher("Select * From Win32_ComputerSystem");
            foreach (ManagementObject Mobject in Search.Get())
            {
               double Ram_Bytes = (Convert.ToDouble(Mobject["TotalPhysicalMemory"]));
               ramgoritmaninrami = (Ram_Bytes / 1073741824);
            }
            }

        private void launch()
        {

            user = session.Username;
            ManagementObjectSearcher Search = new ManagementObjectSearcher("Select * From Win32_ComputerSystem");
            foreach (ManagementObject Mobject in Search.Get())
            {
                double Ram_Bytes = (Convert.ToDouble(Mobject["TotalPhysicalMemory"]));
                ramgoritmaninrami = (Ram_Bytes / 1073741824);
                
            }
            
           
            CMLauncher cmLauncher = new CMLauncher(new MinecraftPath());
            cmLauncher.FileChanged += Launcher_FileChanged;
            cmLauncher.ProgressChanged += Launcher_ProgressChanged;
           

            try
            {

                //cmLauncher.FileChanged += (DownloadFileChangedHandler)(e => this.listBox1.Items.Add((object)string.Format("[{0}] {1} - {2}/{3}", (object)e.FileKind.ToString(), (object)e.FileName, (object)e.ProgressedFileCount, (object)e.TotalFileCount)));
                

                if (ramgoritmaninrami >=2 && ramgoritmaninrami <=4)
                {
                    
                    option.MaximumRamMb = 2048;
                    option.Session = session;
                }
                if (ramgoritmaninrami >=4 && ramgoritmaninrami <=8)
                {
                   
                    option.MaximumRamMb = 4096;
                    option.Session = session;
                }
                if (ramgoritmaninrami >= 8 && ramgoritmaninrami <= 16)
                {
                  
                    option.MaximumRamMb = 8192;
                    option.Session = session;
                }
                if (ramgoritmaninrami >= 16 && ramgoritmaninrami <= 32)
                {
                  
                    option.MaximumRamMb = 16384;
                    option.Session = session;
                }
                if (ramgoritmaninrami >= 32 && ramgoritmaninrami <= 64)
                {
                 
                    option.MaximumRamMb = 32768;
                    option.Session = session;
                }

                try
                {
                    Ana.version = this.guna2ComboBox1.SelectedItem.ToString();
                    option.Session = session;
                    option.VersionType = "FFGapple";
                    option.GameLauncherName = "FFGapple";
                    option.GameLauncherVersion = "3.1";
                    cmLauncher.CreateProcess(Ana.version, option).Start();
                    label1.Text = Language.Strings.fun;
                    guna2Button1.Text = Language.Strings.started;
                  if(Properties.Settings.Default.exit == true)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        guna2ProgressBar1.Visible = false;
                        label7.Visible = false;
                        guna2Button1.Enabled = true;
                        guna2Button1.Text = Language.Strings.play;
                    }
                    //MessageBox.Show("Game Is Opening Right Now. This will take 10 seconds to 3 minutes.", "FFGapple", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show(Language.Strings.selver , "FFGapple", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    guna2ProgressBar1.Visible = false;
                    label7.Visible = false;
                    guna2Button1.Enabled = true;
                    guna2Button1.Text = Language.Strings.play;
                }
            }
            catch
            {
                int num = (int)MessageBox.Show(Language.Strings.catchno, "FFGapple", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2ProgressBar1.Visible = false;
                label7.Visible = false;
                guna2Button1.Enabled = true;
                guna2Button1.Text = Language.Strings.play;
            }
        }

        private async void path()
        {
            




            try
            {
                //cmLauncher.FileChanged += (DownloadFileChangedHandler)(e => this.listBox1.Items.Add((object)string.Format("[{0}] {1} - {2}/{3}", (object)e.FileKind.ToString(), (object)e.FileName, (object)e.ProgressedFileCount, (object)e.TotalFileCount)));
                //cmLauncher.ProgressChanged += (ProgressChangedEventHandler)((s, e) => { });
                //snapshots gone, now only release versions on the list, changed at 1/6/22, in a rainy day xd.
                ServicePointManager.DefaultConnectionLimit = 256;
                CMLauncher cmLauncher = new CMLauncher(new MinecraftPath());
                label1.Text = Language.Strings.resor;
                if (Properties.Settings.Default.eskimodulmc == true)
                {
                    foreach (MVersionMetadata allVersion in cmLauncher.GetAllVersions())
                        this.guna2ComboBox1.Items.Add((object)allVersion.Name);
                }
                if (Properties.Settings.Default.eskimodulmc == false)
                {
                    MVersionCollection versions = await cmLauncher.GetAllVersionsAsync();
                    MVersion ver01 = await versions.GetVersionAsync("1.19");
                    MVersion ver1 = await versions.GetVersionAsync("1.18.2");
                    MVersion ver2 = await versions.GetVersionAsync("1.18.1");
                    MVersion ver3 = await versions.GetVersionAsync("1.18");
                    MVersion ver4 = await versions.GetVersionAsync("1.18");
                    MVersion ver5 = await versions.GetVersionAsync("1.17.1");
                    MVersion ver6 = await versions.GetVersionAsync("1.17");
                    MVersion ver7 = await versions.GetVersionAsync("1.16.5");
                    MVersion ver8 = await versions.GetVersionAsync("1.16.4");
                    MVersion ver9 = await versions.GetVersionAsync("1.16.3");
                    MVersion ver10 = await versions.GetVersionAsync("1.16.2");
                    MVersion ver11 = await versions.GetVersionAsync("1.16.1");
                    MVersion ver12 = await versions.GetVersionAsync("1.16");
                    MVersion ver13 = await versions.GetVersionAsync("1.15.2");
                    MVersion ver14 = await versions.GetVersionAsync("1.15.1");
                    MVersion ver15 = await versions.GetVersionAsync("1.15");
                    MVersion ver16 = await versions.GetVersionAsync("1.14.4");
                    MVersion ver17 = await versions.GetVersionAsync("1.14.3");
                    MVersion ver18 = await versions.GetVersionAsync("1.14.2");
                    MVersion ver19 = await versions.GetVersionAsync("1.14.1");
                    MVersion ver20 = await versions.GetVersionAsync("1.14");
                    MVersion ver21 = await versions.GetVersionAsync("1.13.2");
                    MVersion ver22 = await versions.GetVersionAsync("1.13.1");
                    MVersion ver23 = await versions.GetVersionAsync("1.13");
                    MVersion ver24 = await versions.GetVersionAsync("1.12.2");
                    MVersion ver25 = await versions.GetVersionAsync("1.12.1");
                    MVersion ver26 = await versions.GetVersionAsync("1.12");
                    MVersion ver27 = await versions.GetVersionAsync("1.11.2");
                    MVersion ver28 = await versions.GetVersionAsync("1.11.1");
                    MVersion ver29 = await versions.GetVersionAsync("1.11");
                    MVersion ver30 = await versions.GetVersionAsync("1.10.2");
                    MVersion ver31 = await versions.GetVersionAsync("1.10.1");
                    MVersion ver32 = await versions.GetVersionAsync("1.10");
                    MVersion ver33 = await versions.GetVersionAsync("1.9.4");
                    MVersion ver34 = await versions.GetVersionAsync("1.9.3");
                    MVersion ver35 = await versions.GetVersionAsync("1.9.2");
                    MVersion ver36 = await versions.GetVersionAsync("1.9.1");
                    MVersion ver37 = await versions.GetVersionAsync("1.9");
                    MVersion ver38 = await versions.GetVersionAsync("1.8.9");
                    MVersion ver39 = await versions.GetVersionAsync("1.8.8");
                    MVersion ver40 = await versions.GetVersionAsync("1.8.7");
                    MVersion ver41 = await versions.GetVersionAsync("1.8.6");
                    MVersion ver42 = await versions.GetVersionAsync("1.8.5");
                    MVersion ver43 = await versions.GetVersionAsync("1.8.4");
                    MVersion ver44 = await versions.GetVersionAsync("1.8.3");
                    MVersion ver45 = await versions.GetVersionAsync("1.8.2");
                    MVersion ver46 = await versions.GetVersionAsync("1.8.1");
                    MVersion ver47 = await versions.GetVersionAsync("1.8");
                    MVersion ver48 = await versions.GetVersionAsync("1.7.10");
                    MVersion ver49 = await versions.GetVersionAsync("1.7.9");
                    MVersion ver50 = await versions.GetVersionAsync("1.7.8");
                    MVersion ver51 = await versions.GetVersionAsync("1.7.7");
                    MVersion ver52 = await versions.GetVersionAsync("1.7.6");
                    MVersion ver53 = await versions.GetVersionAsync("1.7.5");
                    MVersion ver54 = await versions.GetVersionAsync("1.7.4");

                    MVersion ver56 = await versions.GetVersionAsync("1.7.2");
                    MVersion ver57 = await versions.GetVersionAsync("1.6.4");
                    MVersion ver58 = await versions.GetVersionAsync("1.6.2");
                    MVersion ver59 = await versions.GetVersionAsync("1.6.1");
                    MVersion ver60 = await versions.GetVersionAsync("1.5.2");
                    MVersion ver61 = await versions.GetVersionAsync("1.5.1");
                    MVersion ver62 = await versions.GetVersionAsync("1.5");
                    MVersion ver63 = await versions.GetVersionAsync("1.4.7");
                    MVersion ver64 = await versions.GetVersionAsync("1.4.6");
                    MVersion ver65 = await versions.GetVersionAsync("1.4.5");
                    MVersion ver66 = await versions.GetVersionAsync("1.4.4");
                    MVersion ver67 = await versions.GetVersionAsync("1.4.2");
                    MVersion ver68 = await versions.GetVersionAsync("1.3.2");
                    MVersion ver69 = await versions.GetVersionAsync("1.3.1");
                    MVersion ver70 = await versions.GetVersionAsync("1.2.5");
                    MVersion ver71 = await versions.GetVersionAsync("1.2.4");
                    MVersion ver72 = await versions.GetVersionAsync("1.2.3");
                    MVersion ver73 = await versions.GetVersionAsync("1.2.2");
                    MVersion ver74 = await versions.GetVersionAsync("1.2.1");
                    MVersion ver75 = await versions.GetVersionAsync("1.1");
                    MVersion ver76 = await versions.GetVersionAsync("1.1");
                    MVersion ver77 = await versions.GetVersionAsync("1.0");
                  
                    //MVersion ver78 = await versions.GetVersionAsync("1.16.5");
                    //MVersion ver79 = await versions.GetVersionAsync("1.16.5");
                    //MVersion ver80 = await versions.GetVersionAsync("1.16.5");
                    //MVersion ver81 = await versions.GetVersionAsync("1.16.5");
                    //MVersion ver82 = await versions.GetVersionAsync("1.16.5");
                    //MVersion ver83 = await versions.GetVersionAsync("1.16.5");
                    //MVersion ver84 = await versions.GetVersionAsync("1.16.5");
                    try
                    {
                        guna2ComboBox1.Items.AddRange(new object[] { ver01 , ver1, ver2, ver3, ver4, ver5, ver6, ver7, ver8, ver9, ver10, ver11, ver12, ver13, ver14, ver15, ver16, ver17, ver18, ver19, ver20, ver21, ver22, ver23, ver24, ver25, ver26, ver27, ver28, ver29, ver30, ver31, ver32, ver33, ver34, ver35, ver36, ver37, ver38, ver39, ver40, ver41, ver42, ver43, ver44, ver45, ver46, ver47, ver48, ver49, ver50, ver51, ver52, ver53, ver54, ver56, ver57, ver58, ver59, ver60, ver61, ver62, ver63, ver64, ver65, ver66, ver67, ver68, ver69, ver70, ver71, ver72, ver73, ver74, ver75, ver76, ver77 });
                        
                    }
                    
                    catch
                    {


                    }
                    label1.Text = "FFGapple";
                }















            }
            catch
            {
                int num = (int)MessageBox.Show(Language.Strings.verno, "FFGapple", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show(Language.Strings.fresh, "Update Agent", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (secenek == DialogResult.Yes)
            {
                module.logo();
            }
            else if (secenek == DialogResult.No)
            {
               
            }
        }



        
        private void Ana_Load(object sender, EventArgs e)
        {
            
            try
            {
                ManagementObjectSearcher Search = new ManagementObjectSearcher("Select * From Win32_ComputerSystem");
                foreach (ManagementObject Mobject in Search.Get())
                {
                    double Ram_Bytes = (Convert.ToDouble(Mobject["TotalPhysicalMemory"]));
                    ramgoritmaninrami = (Ram_Bytes / 1073741824);

                }
                if (ramgoritmaninrami >= 2 && ramgoritmaninrami <= 4)
                {
                    
                    label6.Text = Language.Strings.ikigb;

                }
                if (ramgoritmaninrami >= 4 && ramgoritmaninrami <= 8)
                {
                    label6.Text = Language.Strings.dortgb;

                }
                if (ramgoritmaninrami >= 8 && ramgoritmaninrami <= 16)
                {
                    label6.Text = Language.Strings.sekizgb;

                }
                if (ramgoritmaninrami >= 16 && ramgoritmaninrami <= 32)
                {
                    label6.Text = Language.Strings.otuzikigb;

                }
                if (ramgoritmaninrami >= 32 && ramgoritmaninrami <= 64)
                {
                    label6.Text = Language.Strings.altmisdortgb;

                }
             
              
                this.path();
                timer1.Start();
                if(upmodule == "broken")
                {
                    label1.Text = Language.Strings.upbroke;
                }
                guna2Button1.Text = Language.Strings.play;
                label3.Text = Language.Strings.versel;
                //label5.Text = Language.Strings.welcome;
                guna2Button2.Text = Language.Strings.modfolder;
                settingsToolStripMenuItem.Text = Language.Strings.setto;


            }
            catch 
            {

                int num = (int)MessageBox.Show(Language.Strings.mainbroke, "FFGapple", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Button1.Enabled = false;
            label7.Visible = true;
            
            guna2ProgressBar1.Visible = true;

            guna2Button1.Text = Language.Strings.prep;

            try
            {


                //option.Session = session;
               
              
               
                new Thread((ThreadStart)(() => this.launch()))
                {

                IsBackground = true

                }.Start();
               

            }
            catch
            {
                int num = (int)MessageBox.Show(Language.Strings.startfail, "FFGapple", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            module.mckonum();

            //StreamWriter Yaz = new StreamWriter(@"C:\Users\kaotic\Desktop\yaz.txt");
            //CMLauncher cmLauncher = new CMLauncher(new MinecraftPath());
            //foreach (MVersionMetadata allVersion in cmLauncher.GetAllVersions())
                
            //      Yaz.WriteLine(allVersion.Name);

            //Yaz.Close();






        }

        private void Ana_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void Ana_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
                
            }
        }

        private void Ana_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            guard.nofreeze();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mcyolu = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if(Directory.Exists(mcyolu + "/.minecraft/versions/" + guna2ComboBox1.SelectedItem.ToString()))
            {
                guna2Button1.Text = Language.Strings.ready;
            }
            else
            {
                guna2Button1.Text = Language.Strings.download;
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Language.Strings.memred , "FFGapple", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Launcher_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            try
            {
                guna2ProgressBar1.Maximum = 100;
                guna2ProgressBar1.Value = e.ProgressPercentage;
            }
            catch 
            {
                guna2ProgressBar1.Visible = false;
                label7.Visible = false;


            }
        }

        private void Launcher_FileChanged(DownloadFileChangedEventArgs e)
        {
            try
            {

                guna2ProgressBar1.Maximum = e.TotalFileCount;
                guna2ProgressBar1.Value = e.ProgressedFileCount;
                label7.Text = $"{e.FileKind} : {e.FileName} ({e.ProgressedFileCount}/{e.TotalFileCount})";
            }
            catch 
            {
                guna2ProgressBar1.Visible = false;
                label7.Visible = false;

            }
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            module.easter();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
           
          
        }

        //private void aboutFFGappleToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    About hakkinda = new About();
        //    hakkinda.ShowDialog();
        //}

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings ayarlar = new Settings();
            ayarlar.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void mojangAccountSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Account_Settings mjacc = new Account_Settings();
            mjacc.ShowDialog();
        }

        private async void guna2Button4_Click(object sender, EventArgs e)
        {
          
            
        }
        static void printResponse(MojangAPIResponse res)
        {
           

        }
    }
}
