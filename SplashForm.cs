using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentMangementSystem
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            timer.Start();
        }
        int startpoint = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            ProgressIndicator.Start();

            if (startpoint >50)
            {
                LoginForm login = new LoginForm();
                ProgressIndicator.Stop();
                timer.Stop();
                this.Hide();
                login.Show();
            }
        }
    }
}
