namespace FFGapple.Forms;

public partial class Account_Settings : Form
{
    public Account_Settings()
    {
        InitializeComponent();
    }

    private void Account_Settings_Load(object sender, EventArgs e)
    {
        bust();
        LoadManager();
    }

    public void LoadManager()
    {
        guna2TextBox1.Text = Ana.usernameskin;
        guna2TextBox2.Text = Ana.uuiduser;
        guna2TextBox3.Text = Ana.accestoken;
    }

    public void bust()
    {
        try
        {
            var request = WebRequest.Create("https://minotar.net/body/" + Ana.user + "/100.png");
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                pictureBox1.Image = Image.FromStream(stream);
            }
        }
        catch
        {
            // pp olmasada olur ya. 
        }
    }
}