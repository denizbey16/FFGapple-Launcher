namespace FFGapple.Forms;

public partial class Settings : Form
{
    private int Mouse_X;
    private int Mouse_Y;

    private new int Move;

    public Settings()
    {
        InitializeComponent();
        Strings.Culture = new CultureInfo(Properties.Settings.Default.lang);
    }


    private void Settings_Load(object sender, EventArgs e)
    {
        guna2ToggleSwitch1.Checked = Properties.Settings.Default.exit;
        guna2ToggleSwitch2.Checked = Properties.Settings.Default.update;
        guna2ToggleSwitch3.Checked = Properties.Settings.Default.eskimodulmc;
        guna2ToggleSwitch4.Checked = Properties.Settings.Default.autologinset;
        guna2ComboBox1.SelectedItem = Properties.Settings.Default.lang;
        label1.Text = Strings.set4;
        label2.Text = Strings.setname;
        label3.Text = Strings.set1;
        label4.Text = Strings.set2;
        label5.Text = Strings.set3;
        label6.Text = Strings.autologin;
    }

    private void Settings_FormClosing(object sender, FormClosingEventArgs e)
    {
        Properties.Settings.Default.exit = guna2ToggleSwitch1.Checked;
        Properties.Settings.Default.update = guna2ToggleSwitch2.Checked;
        Properties.Settings.Default.eskimodulmc = guna2ToggleSwitch3.Checked;
        Properties.Settings.Default.autologinset = guna2ToggleSwitch4.Checked;
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
        if (Move == 1) SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
    }

    private void Settings_MouseDown(object sender, MouseEventArgs e)
    {
        Move = 1;
        Mouse_X = e.X;
        Mouse_Y = e.Y;
    }
}