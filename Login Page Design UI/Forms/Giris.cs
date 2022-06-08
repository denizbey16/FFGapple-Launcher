//ffgapple project by x64/1336 aka marqe.

namespace FFGapple.Forms;

public partial class Giris : Form
{
    private readonly FFGuardModule guard = new();

    private readonly MLogin login = new();
    private readonly Update module = new();
    private int on = 1;
    private int version = 25;

    public Giris()
    {
        InitializeComponent();
        Strings.Culture = new CultureInfo(Properties.Settings.Default.lang);
    }

    private void guna2Button1_Click(object sender, EventArgs e)
    {
        if (guna2TextBox1.Text != "")
        {
            if (guna2ToggleSwitch1.Checked)
            {
                Properties.Settings.Default.username = guna2TextBox1.Text;
                Properties.Settings.Default.aktif = guna2ToggleSwitch1.Checked = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                guna2TextBox1.Text = "";
                Properties.Settings.Default.aktif = guna2ToggleSwitch1.Checked = false;
                Properties.Settings.Default.Save();
            }

            //Old Mojang Determine System, its changed at 31/5/22.
            //Ana main = new Ana(ssession);
            //Ana.user = guna2TextBox1.Text;
            //Ana.mojang = "offline";
            //main.Show();
            //Hide();
            UpdateSession(MSession.GetOfflineSession(guna2TextBox1.Text));
        }
        else
        {
            MessageBox.Show(Strings.nick, "FFGapple", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        if (pingDurumu.Status != IPStatus.Success)
        {
            MessageBox.Show(Strings.inthata, "FFGapple", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


                Invoke(new Action(() => { UpdateSession(result.Session); }));
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
            guna2TextBox1.PlaceholderText = Strings.place1;
            guna2TextBox2.PlaceholderText = Strings.place2;
            guna2Button1.Text = Strings.girismojang;
            guna2Button2.Text = Strings.girismojang;
            linkLabel1.Text = Strings.orjhesap;
            linkLabel2.Text = Strings.grdn;
            CheckConnection();
            if (Properties.Settings.Default.update)
                module.denetleyici();
            else
                Ana.upmodule = "broken";

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
            if (Properties.Settings.Default.autologinset) autologin();
        }
        catch
        {
            MessageBox.Show(Strings.pinghata, "FFGapple", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(-1);
        }
    }

    private void timer2_Tick(object sender, EventArgs e)
    {
        guard.nofreeze();
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (guna2ToggleSwitch1.Checked)
        {
            Properties.Settings.Default.username = guna2TextBox1.Text;
            Properties.Settings.Default.aktif = guna2ToggleSwitch1.Checked = true;
            Properties.Settings.Default.Save();
        }
        else
        {
            guna2TextBox1.Text = "";
            Properties.Settings.Default.aktif = guna2ToggleSwitch1.Checked = false;
            Properties.Settings.Default.Save();
        }
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
                Invoke(new Action(() => { UpdateSession(result.Session); }));
            }
            else
            {
                MessageBox.Show(Strings.mojhata, "FFGapple", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Invoke(new Action(() => { }));
            }
        }));
        th.Start();
    }

    public void UpdateSession(MSession ssession)
    {
        var mainForm = new Ana(ssession);
        mainForm.FormClosed += (s, e) => Close();
        mainForm.Show();
        Hide();
    }

    private void guna2Panel2_Paint(object sender, PaintEventArgs e)
    {
    }
}