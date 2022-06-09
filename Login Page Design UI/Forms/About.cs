#region

#endregion

namespace FFGapple.Forms;

public partial class About : Form
{
    private int Mouse_X;
    private int Mouse_Y;
    private new int Move;

    public About()
    {
        InitializeComponent();
    }

    #region Events

    private void About_Load(object sender, EventArgs e)
    {
    }

    private void About_MouseUp_1(object sender, MouseEventArgs e)
    {
        Move = 0;
    }

    private void About_MouseMove_1(object sender, MouseEventArgs e)
    {
        if (Move == 1) SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
    }

    private void About_MouseDown_1(object sender, MouseEventArgs e)
    {
        Move = 1;
        Mouse_X = e.X;
        Mouse_Y = e.Y;
    }

    #endregion
}