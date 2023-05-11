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
    public partial class Host : Form
    {
        public Host()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Result result = new Result();
            result.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
                this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Schedule schedule = new Schedule();
            schedule.Show();    
            this.Hide();
        }
    }
}
