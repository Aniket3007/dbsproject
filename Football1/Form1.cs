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
    public partial class Form1 : Form
    {
        string username;
        string password;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            username=this.textBox1.Text;
            password=this.textBox2.Text;
            if (username == "A-123456" && password == "Banan")
            {
                Admin a1 = new Admin();
                a1.Show();
                this.Hide();
            }
            else if (username != "A-123456" && password == "Banan")
            {
                textBox3.Text = "Incorrect Username";
            }
            else if (username == "A-123456" && password != "Banan")
            {
                textBox3.Text = "Incorrect Password";
            }
            else
            {
                textBox3.Text = "Incorrect Username And Password";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
