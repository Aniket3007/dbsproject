using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Football1
{
    public partial class AAddP : Form
    {
        OracleConnection conn;
        string Fname;
        string Lname;
        string age;
        string nationality;
        string Tname;
        public AAddP()
        {
            InitializeComponent();
        }
        public void ConnectDB()
        {
            conn = new OracleConnection("DATA SOURCE=ORCL;USER ID=SYSTEM;PASSWORD =iamthebest");
            MessageBox.Show(conn.ConnectionString);


            try
            {
                conn.Open();
                MessageBox.Show("Connected");
            }
            catch (Exception e1)
            {
                MessageBox.Show("Not Connected");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Fname = textBox1.Text;
            Lname = textBox2.Text;
            age = textBox3.Text;
            nationality = textBox5.Text;
            Tname = textBox4.Text;
            ConnectDB();
            OracleCommand command1 = conn.CreateCommand();
            command1.CommandText = "insert into players values('"+ Fname +"','"+Lname+"',"+age+",'"+nationality+"','"+Tname+"')";
            command1.CommandType = CommandType.Text;
            command1.ExecuteNonQuery();
            MessageBox.Show("Inserted");
            command1.Dispose();
            conn.Close();
            Admin a2 = new Admin();
            a2.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
