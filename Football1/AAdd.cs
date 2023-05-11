using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Football1
{
    public partial class AAdd : Form
    {
        OracleConnection conn;
        public AAdd()
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Tname=textBox1.Text;
            String Fname=textBox2.Text;
            String Lname=textBox3.Text;
            String Password=textBox4.Text;
            ConnectDB();
            OracleCommand command1 = conn.CreateCommand();
            command1.CommandText = "insert into teams values('"+ Tname +"','"+Fname+"','"+Lname+"','"+Password+"')";
            command1.CommandType = CommandType.Text;
            command1.ExecuteNonQuery();
            MessageBox.Show("Inserted");
            command1.Dispose();
            conn.Close();
            Admin a1 = new Admin();
            a1.Show();
            this.Hide();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
