using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFGapple
{
    public partial class About : Form
    {
        int Move;
        int Mouse_X;
        int Mouse_Y;
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {

        }

        private void About_MouseUp(object sender, MouseEventArgs e)
        {
           
        }

        private void About_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void About_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void About_MouseUp_1(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void About_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void About_MouseDown_1(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }
    }
}
