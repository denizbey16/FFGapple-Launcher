#region

using FFGapple.Forms;

#endregion

namespace FFGapple;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Giris());
    }
}