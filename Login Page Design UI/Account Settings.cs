using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CmlLib.Core;
using MojangAPI.Model;
using MojangAPI;
using System.IO;
using CmlLib.Core.Auth;

namespace FFGapple
{
    public partial class Account_Settings : Form
    {
        private MSession session;

        public Account_Settings()
        {
           
            InitializeComponent();
        }
       
        private async void Account_Settings_Load(object sender, EventArgs e)
        {
          

            bust();
            mojangmanagment();
        }


      public void mojangmanagment()
        {
            guna2TextBox1.Text = FFGapple.Ana.usernameskin;
            guna2TextBox2.Text = FFGapple.Ana.uuiduser;
            guna2TextBox3.Text = FFGapple.Ana.accestoken;
         

        }
        public void bust()
        {
            try
            {
                var request = WebRequest.Create("https://minotar.net/body/" +  FFGapple.Ana.user + "/100.png");
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

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            //HttpClient httpClient = new HttpClient();
            //MojangAuth auth = new MojangAuth(httpClient);

            //MojangAuthResponse res;

            //res = await auth.TryAutoLogin(); // login using cached session
            //if (!res.IsSuccess) // failed to login using cached session
            //{
            //    MessageBox.Show(res.Result.ToString());

            //    // it will save your login information into json file
            //    
            //}

            //MessageBox.Show(res.ToString());

            //Session session = res.Session;

        }
       
        private async void guna2Button2_Click(object sender, EventArgs e)
        {

           
           

        }

       
    }
}
