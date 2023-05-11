using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Football1
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Teamlogin a = new Teamlogin();
            a.Show(); this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Plogin a = new Plogin();
            a.Show(); this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HLogin a = new HLogin();
                a.Show(); this.Hide();
        }
    }
}
